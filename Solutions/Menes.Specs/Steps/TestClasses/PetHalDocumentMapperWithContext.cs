// <copyright file="PetHalDocumentMapperWithContext.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps.TestClasses
{
    using Menes.Hal;

    public class PetHalDocumentMapperWithContext : IHalDocumentMapper<Pet, MappingContext>
    {
        public void ConfigureLinkMap(IOpenApiLinkOperationMap links)
        {
        }

        public HalDocument Map(Pet resource, MappingContext context)
        {
            return null;
        }
    }
}
