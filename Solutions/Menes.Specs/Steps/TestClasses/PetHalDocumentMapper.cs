// <copyright file="PetHalDocumentMapperWithContext.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps.TestClasses
{
    using System;
    using Menes.Hal;

    public class PetHalDocumentMapper : IHalDocumentMapper<Pet>
    {
        public bool LinkMapConfigured { get; private set; }

        public void ConfigureLinkMap(IOpenApiLinkOperationMap links)
        {
            this.LinkMapConfigured = true;
        }

        public IHalDocument Map(Pet resource)
        {
            throw new NotSupportedException();
        }
    }
}
