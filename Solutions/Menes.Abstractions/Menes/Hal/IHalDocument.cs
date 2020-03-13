// <copyright file="IHalDocument.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    using Menes.Links;

    /// <summary>
    /// A standard representation of a HAL document resource.
    /// </summary>
    public interface IHalDocument : IEmbeddedResourcesCollection, IExtendedPropertiesCollection, ILinkCollection
    {
    }
}
