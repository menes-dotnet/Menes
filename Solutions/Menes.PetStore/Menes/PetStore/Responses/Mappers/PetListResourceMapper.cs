// <copyright file="PetListResourceMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Responses.Mappers
{
    using System.Linq;
    using Menes.Hal;
    using Menes.Links;
    using Menes.PetStore.Abstractions;

    /// <summary>
    /// Maps a list of Pets to a PetListResource.
    /// </summary>
    public class PetListResourceMapper
    {
        private const string PetsRelation = "pets";
        private readonly IHalDocumentFactory halDocumentFactory;
        private readonly IOpenApiWebLinkResolver linkResolver;
        private readonly PetResourceMapper petResourceMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetListResourceMapper"/> class.
        /// </summary>
        /// <param name="halDocumentFactory">The factoryh with which to create <see cref="HalDocument"/> instances.</param>
        /// <param name="linkResolver">The link resolver to build the links collection.</param>
        /// <param name="petResourceMapper">The mapper for individual Pets.</param>
        public PetListResourceMapper(IHalDocumentFactory halDocumentFactory, IOpenApiWebLinkResolver linkResolver, PetResourceMapper petResourceMapper)
        {
            this.halDocumentFactory = halDocumentFactory;
            this.linkResolver = linkResolver;
            this.petResourceMapper = petResourceMapper;
        }

        /// <summary>
        /// Performs the mapping.
        /// </summary>
        /// <param name="pets">The list of pets.</param>
        /// <param name="totalPets">The total number of available pets.</param>
        /// <param name="limit">The page size.</param>
        /// <param name="currentContinuationToken">The continuation token for the current page.</param>
        /// <param name="nextContinuationToken">The continuation token for the next page.</param>
        /// <returns>The mapped PetListResource.</returns>
        public HalDocument Map(Pet[] pets, long totalPets, int limit, string currentContinuationToken, string nextContinuationToken)
        {
            var resource = new PetListResource
            {
                TotalCount = totalPets,
                PageSize = limit,
            };

            HalDocument response = this.halDocumentFactory.CreateHalDocumentFrom(resource);

            pets.ForEach(pet =>
            {
                response.AddEmbeddedResource(PetsRelation, this.petResourceMapper.Map(pet));
            });

            response.ResolveAndAdd(this.linkResolver, response, "self", ("limit", limit), ("continuationToken", currentContinuationToken));
            response.ResolveAndAdd(this.linkResolver, response, "create");

            if (!string.IsNullOrEmpty(nextContinuationToken))
            {
                response.ResolveAndAdd(this.linkResolver, response, "next", ("limit", limit), ("continuationToken", nextContinuationToken));
            }

            return response;
        }
    }
}
