// <copyright file="PetHalDocumentMapperWithContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps.TestClasses
{
    using System;
    using System.Threading.Tasks;
    using Menes.Hal;

    public class PetHalDocumentMapperWithContext : IHalDocumentMapper<Pet, MappingContext>
    {
        public bool LinkMapConfigured { get; private set; }

        public void ConfigureLinkMap(IOpenApiLinkOperationMap links)
        {
            this.LinkMapConfigured = true;
        }

        public ValueTask<HalDocument> MapAsync(Pet resource, MappingContext context)
        {
            throw new NotSupportedException();
        }
    }
}
