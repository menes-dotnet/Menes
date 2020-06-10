// <copyright file="PetHalDocumentMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps.TestClasses
{
    using System;
    using System.Threading.Tasks;
    using Menes.Hal;

    public class PetHalDocumentMapper : IHalDocumentMapper<Pet>
    {
        public bool LinkMapConfigured { get; private set; }

        public void ConfigureLinkMap(IOpenApiLinkOperationMap links)
        {
            this.LinkMapConfigured = true;
        }

        public ValueTask<HalDocument> MapAsync(Pet resource)
        {
            throw new NotSupportedException();
        }
    }
}
