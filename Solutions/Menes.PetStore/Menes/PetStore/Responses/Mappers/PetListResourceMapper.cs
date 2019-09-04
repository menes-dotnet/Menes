﻿// <copyright file="PetListResourceMapper.cs" company="Endjin Limited">
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
    public class PetListResourceMapper : IHalDocumentMapper<PetListResource>
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

        /// <inheritdoc/>
        public void ConfigureLinkMap(IOpenApiLinkOperationMap links)
        {
            links.Map<PetListResource>("self", "listPets");
            links.Map<PetListResource>("create", "createPets");
            links.Map<PetListResource>("next", "listPets");
        }

        /// <inheritdoc/>
        public HalDocument Map(PetListResource pets)
        {
            HalDocument response = this.halDocumentFactory.CreateHalDocumentFrom(pets);
            response.AddEmbeddedResources(PetsRelation, pets.Pets.Select(this.petResourceMapper.Map));

            response.ResolveAndAdd(this.linkResolver, response, "self", ("limit", pets.PageSize), ("continuationToken", pets.CurrentContinuationToken));
            response.ResolveAndAdd(this.linkResolver, response, "create");

            if (!string.IsNullOrEmpty(pets.NextContinuationToken))
            {
                response.ResolveAndAdd(this.linkResolver, response, "next", ("limit", pets.PageSize), ("continuationToken", pets.NextContinuationToken));
            }

            return response;
        }
    }
}
