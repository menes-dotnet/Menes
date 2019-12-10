// <copyright file="PetResourceMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Responses.Mappers
{
    using Menes.Hal;
    using Menes.Links;

    /// <summary>
    /// Maps Pets to PetResources.
    /// </summary>
    public class PetResourceMapper : IHalDocumentMapper<PetResource>
    {
        private readonly IHalDocumentFactory halDocumentFactory;
        private readonly IOpenApiWebLinkResolver linkResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetResourceMapper"/> class.
        /// </summary>
        /// <param name="halDocumentFactory">The service provider to construct <see cref="HalDocument"/> instances.</param>
        /// <param name="linkResolver">The link resolver to build the links collection.</param>
        public PetResourceMapper(IHalDocumentFactory halDocumentFactory, IOpenApiWebLinkResolver linkResolver)
        {
            this.halDocumentFactory = halDocumentFactory;
            this.linkResolver = linkResolver;
        }

        /// <inheritdoc/>
        public void ConfigureLinkMap(IOpenApiLinkOperationMap links)
        {
            links.MapByContentTypeAndRelationTypeAndOperationId(PetResource.ContentTypeBase, "self", "showPetById");
            links.MapByContentTypeAndRelationTypeAndOperationId(PetResource.ContentTypeBase, "image", "petImage");
            links.MapByContentTypeAndRelationTypeAndOperationId(PetResource.ContentTypeBase, "pocoimage", "petImagePoco");
        }

        /// <inheritdoc/>
        public HalDocument Map(PetResource input)
        {
            HalDocument response = this.halDocumentFactory.CreateHalDocumentFrom(input);
            response.ResolveAndAddByOwnerAndRelationType(this.linkResolver, input, "self", ("petId", input.Id));
            response.ResolveAndAddByOwnerAndRelationType(this.linkResolver, input, "image", ("petId", input.Id));
            response.ResolveAndAddByOwnerAndRelationType(this.linkResolver, input, "pocoimage", ("petId", input.Id));

            return response;
        }
    }
}
