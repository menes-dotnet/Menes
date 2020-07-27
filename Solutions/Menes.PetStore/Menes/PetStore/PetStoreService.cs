// <copyright file="PetStoreService.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Web;
    using Corvus.Extensions;
    using Menes.Exceptions;
    using Menes.Hal;
    using Menes.Links;
    using Menes.PetStore.Responses;
    using Menes.PetStore.Responses.Mappers;

    /// <inheritdoc/>
    public class PetStoreService : IOpenApiService
    {
        private static readonly Regex MatchContinuationToken = new Regex("skip=([0-9]*)");
        private readonly List<PetResource> pets;
        private readonly PetListResourceMapper petListMapper;
        private readonly PetResourceMapper petMapper;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly PetResource secretPet;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetStoreService"/> class.
        /// </summary>
        /// <param name="petListMapper">Mapper for pet list responses.</param>
        /// <param name="petMapper">Mapper for pet responses.</param>
        /// <param name="httpClientFactory">Source of <c>HttpClient</c>s.</param>
        public PetStoreService(
            PetListResourceMapper petListMapper,
            PetResourceMapper petMapper,
            IHttpClientFactory httpClientFactory)
        {
            // Initialise list with known items
            this.pets = new List<PetResource>
                            {
                                new PetResource("Suki", "Cat") { Id = 1, Size = Size.Small, GlobalIdentifier = Guid.NewGuid() },
                                new PetResource("Caspar", "Dog") { Id = 2, Size = Size.Medium, GlobalIdentifier = Guid.NewGuid() },
                                new PetResource("Tim", "Goldfish") { Id = 3, Size = Size.Large, GlobalIdentifier = Guid.NewGuid() },
                            };

            // Now add a load more random ones so it's possible to verify that limit/continuation on the list endpoint works.
            this.pets.AddRange(Enumerable.Range(4, 100)
                .Select(id => new PetResource(Guid.NewGuid().ToString(), Guid.NewGuid().ToString())
                {
                    Id = id,
                    Size = Size.Medium,
                    GlobalIdentifier = Guid.NewGuid(),
                }));

            this.petListMapper = petListMapper;
            this.petMapper = petMapper;
            this.httpClientFactory = httpClientFactory;
            this.secretPet = new PetResource("Yogi", "Bear") { Id = 0, Size = Size.Large, GlobalIdentifier = Guid.NewGuid() };
        }

        /// <summary>
        /// The list pets endpoint.
        /// </summary>
        /// <param name="limit">The maximum number of results in the search.</param>
        /// <param name="continuationToken">The optional continuation token.</param>
        /// <returns>
        /// An <see cref="IEnumerable{Pet}"/> containing all pets.
        /// </returns>
        [OperationId("listPets")]
        public OpenApiResult ListPets(int limit = 10, string? continuationToken = null)
        {
            int skip = ParseContinuationToken(continuationToken);

            PetResource[] pets = this.pets.Skip(skip).Take(limit).ToArray();

            string? nextContinuationToken = (skip + limit < this.pets.Count) ? BuildContinuationToken(limit + skip) : null;
            HalDocument response = this.petListMapper.Map(new PetListResource(pets) { TotalCount = this.pets.Count, PageSize = limit, CurrentContinuationToken = continuationToken,  NextContinuationToken = nextContinuationToken });

            OpenApiResult result = this.OkResult(response, "application/hal+json");

            // We also add the next page link to the header, just to demonstrate that it's possible
            // to use WebLink items in this way.
            WebLink nextLink = response.GetLinksForRelation("next").FirstOrDefault();
            if (nextLink != default)
            {
                result.Results.Add("x-next", nextLink.Href);
            }

            result.AddAuditData(("skip", skip), ("limit", limit));

            return result;
        }

        /// <summary>
        /// The show pets endpoint.
        /// </summary>
        /// <param name="petId">
        /// The pet id.
        /// </param>
        /// <returns>
        /// The <see cref="PetResource"/>.
        /// </returns>
        [OperationId("showPetById")]
        public OpenApiResult ShowPet(string petId)
        {
            long.TryParse(petId, out long idAsLong);
            PetResource result = this.pets.SingleOrDefault(p => p.Id == idAsLong);

            return this.MapAndReturnPet(result);
        }

        /// <summary>
        /// The show pets endpoint.
        /// </summary>
        /// <param name="petIdWithParameterNameSetByAttribute">
        /// The pet id. This name is deliberately different from the name defined for this parameter
        /// in the OpenApi service definition to enable testing of <see cref="OpenApiParameterAttribute"/>.
        /// </param>
        /// <returns>
        /// The <see cref="PetResource"/>.
        /// </returns>
        [OperationId("showPetByLongId")]
        public OpenApiResult ShowPet(
            [OpenApiParameter("petId")] long petIdWithParameterNameSetByAttribute)
        {
            PetResource result = this.pets.SingleOrDefault(p => p.Id == petIdWithParameterNameSetByAttribute);

            return this.MapAndReturnPet(result);
        }

        /// <summary>
        /// The show pets endpoint.
        /// </summary>
        /// <param name="xPetId">
        /// The pet id. This corresponds to the <c>X-PET-ID</c> header in the request. Because non-exact
        /// parameter name matching is enabled by default, we can use this simplified name.
        /// </param>
        /// <returns>
        /// The <see cref="PetResource"/>.
        /// </returns>
        [OperationId("showPetByLongIdInHeader")]
        public OpenApiResult ShowPetWithIdInHeader(
            long xPetId)
        {
            PetResource result = this.pets.SingleOrDefault(p => p.Id == xPetId);

            return this.MapAndReturnPet(result);
        }

        /// <summary>
        /// The show pets by global ID endpoint.
        /// </summary>
        /// <param name="petId">
        /// The pet id.
        /// </param>
        /// <returns>
        /// The <see cref="PetResource"/>.
        /// </returns>
        [OperationId("showPetByGlobalId")]
        public OpenApiResult ShowPet(Guid petId)
        {
            PetResource result = this.pets.SingleOrDefault(p => p.GlobalIdentifier == petId);

            return this.MapAndReturnPet(result);
        }

        /// <summary>
        /// The show secret pet endpoint.
        /// </summary>
        /// <param name="openApiContext">The Open API context.</param>
        /// <returns>
        /// The <see cref="PetResource"/>.
        /// </returns>
        [OperationId("showSecretPet")]
        public OpenApiResult ShowSecretPet(IOpenApiContext openApiContext)
        {
            if (openApiContext.CurrentPrincipal?.IsInRole("admin") == true)
            {
                return this.MapAndReturnPet(this.secretPet);
            }

            return new OpenApiResult { StatusCode = (int)HttpStatusCode.Unauthorized };
        }

        /// <summary>
        /// Create a pet.
        /// </summary>
        /// <param name="body">The pet to create.</param>
        /// <returns>Created if the pet is created.</returns>
        [OperationId("createPets")]
        public OpenApiResult CreatePets(PetResource body)
        {
            if (!this.pets.Any(p => p.Id == body.Id))
            {
                body.GlobalIdentifier = Guid.NewGuid();

                this.pets.Add(body);
            }

            HalDocument response = this.petMapper.Map(body);
            WebLink location = response.GetLinksForRelation("self").First();
            return this.CreatedResult(location.Href, response, "application/hal+json").WithAuditData(("id", (object)body.Id));
        }

        /// <summary>
        /// The get pet image endpoint.
        /// </summary>
        /// <param name="petId">
        /// The pet id.
        /// </param>
        /// <returns>
        /// The image of the pet.
        /// </returns>
        [OperationId("petImage")]
        public async Task<OpenApiResult> ShowPetImage(string petId)
        {
            long.TryParse(petId, out long idAsLong);
            PetResource pet = this.pets.SingleOrDefault(p => p.Id == idAsLong);

            Stream result = await this.GetImageForPetAsync(pet).ConfigureAwait(false);

            return this.OkResult(result, "image/jpeg");
        }

        /// <summary>
        /// The get pet image endpoint.
        /// </summary>
        /// <param name="petId">
        /// The pet id.
        /// </param>
        /// <returns>
        /// The image of the pet, as a raw stream.
        /// </returns>
        [OperationId("petImagePoco")]
        public Task<Stream> ShowPetImagePoco(string petId)
        {
            long.TryParse(petId, out long idAsLong);
            PetResource pet = this.pets.SingleOrDefault(p => p.Id == idAsLong);

            return this.GetImageForPetAsync(pet);
        }

        private static string BuildContinuationToken(int skip)
        {
            return $"skip={skip}".Base64UrlEncode();
        }

        private static int ParseContinuationToken(string? continuationToken)
        {
            if (continuationToken == null)
            {
                return 0;
            }

            string decodedContinuationToken = continuationToken.Base64UrlDecode();
            Match match = MatchContinuationToken.Match(decodedContinuationToken);
            if (!match.Success)
            {
                throw new OpenApiBadRequestException(
                    "Bad continuation token",
                    "The continuation token could not be decoded",
                    "/petstore/errors/continuation/unable-to-decode")
                    .AddProblemDetailsExtension("continuationToken", continuationToken);
            }

            if (match.Groups.Count != 2)
            {
                throw new OpenApiBadRequestException(
                    "Bad continuation token",
                    "The continuation token is corrupted",
                    "/petstore/errors/continuation/unable-to-match")
                    .AddProblemDetailsExtension("continuationToken", continuationToken);
            }

            if (!int.TryParse(match.Groups[1].Value, out int skip))
            {
                throw new OpenApiBadRequestException(
                    "Bad continuation token",
                    "The continuation token is corrupted",
                    "/petstore/errors/continuation/token-data-invalid")
                    .AddProblemDetailsExtension("continuationToken", continuationToken);
            }

            return skip;
        }

        private async Task<Stream> GetImageForPetAsync(PetResource pet)
        {
            using HttpClient client = this.httpClientFactory.CreateClient();
            string uri = $"https://loremflickr.com/320/240/{HttpUtility.UrlEncode(pet.Tag)},{pet.Size}";
            byte[] image = await client.GetByteArrayAsync(uri).ConfigureAwait(false);
            return new MemoryStream(image);
        }

        private OpenApiResult MapAndReturnPet(PetResource result)
        {
            if (result == null)
            {
                throw new OpenApiNotFoundException();
            }

            HalDocument response = this.petMapper.Map(result);

            return this
                .OkResult(response, "application/hal+json")
                .WithAuditData(("id", (object)result.Id));
        }
    }
}