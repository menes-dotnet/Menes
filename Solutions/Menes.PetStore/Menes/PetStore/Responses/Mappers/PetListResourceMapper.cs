// <copyright file="PetListResourceMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Responses.Mappers
{
    using System.Linq;
    using Menes.Hal;
    using Menes.Links;

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
        /// Map links for the resource.
        /// </summary>
        /// <param name="links">The links to map.</param>
        /// <returns>The link operation map with the links mapped.</returns>
        public static IOpenApiLinkOperationMap MapLinks(IOpenApiLinkOperationMap links)
        {
            links.Map<PetListResource>("self", "listPets");
            links.Map<PetListResource>("create", "createPets");
            links.Map<PetListResource>("next", "listPets");
            return links;
        }

        /// <summary>
        /// Performs the mapping.
        /// </summary>
        /// <param name="pets">The list of pets.</param>
        /// <param name="currentContinuationToken">The continuation token for the current page.</param>
        /// <param name="nextContinuationToken">The continuation token for the next page.</param>
        /// <returns>The mapped PetListResource.</returns>
        public HalDocument Map(PetListResource pets, string currentContinuationToken, string nextContinuationToken)
        {
            HalDocument response = this.halDocumentFactory.CreateHalDocumentFrom(pets);
            response.AddEmbeddedResources(PetsRelation, pets.Pets.Select(this.petResourceMapper.Map));

            response.ResolveAndAdd(this.linkResolver, response, "self", ("limit", pets.PageSize), ("continuationToken", currentContinuationToken));
            response.ResolveAndAdd(this.linkResolver, response, "create");

            if (!string.IsNullOrEmpty(nextContinuationToken))
            {
                response.ResolveAndAdd(this.linkResolver, response, "next", ("limit", pets.PageSize), ("continuationToken", nextContinuationToken));
            }

            return response;
        }
    }
}
