// <copyright file="PetResourceMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Responses.Mappers
{
    using Menes.Links;
    using Menes.PetStore.Abstractions;

    /// <summary>
    /// Maps Pets to PetResources.
    /// </summary>
    public class PetResourceMapper
    {
        private readonly IOpenApiWebLinkResolver linkResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetResourceMapper"/> class.
        /// </summary>
        /// <param name="linkResolver">The link resolver to build the links collection.</param>
        public PetResourceMapper(IOpenApiWebLinkResolver linkResolver)
        {
            this.linkResolver = linkResolver;
        }

        /// <summary>
        /// Performs the mapping.
        /// </summary>
        /// <param name="input">The Pet to map.</param>
        /// <returns>The mapped PetResource.</returns>
        public HalDocument<Pet> Map(Pet input)
        {
            var response = new HalDocument<Pet>
            {
                Data = input,
            };

            response.Links.ResolveAndAdd(this.linkResolver, response.Data, "self", ("petId", response.Data.Id));
            response.Links.ResolveAndAdd(this.linkResolver, response.Data, "image", ("petId", response.Data.Id));
            response.Links.ResolveAndAdd(this.linkResolver, response.Data, "pocoimage", ("petId", response.Data.Id));

            return response;
        }
    }
}
