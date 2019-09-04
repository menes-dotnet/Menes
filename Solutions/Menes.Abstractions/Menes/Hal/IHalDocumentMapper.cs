// <copyright file="IHalDocumentMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    /// <summary>
    /// Implemented by types which can map a resource to a HAL document.
    /// </summary>
    public interface IHalDocumentMapper
    {
        /// <summary>
        /// Configure link mappings for the resource.
        /// </summary>
        /// <param name="links">The links to map.</param>
        void ConfigureLinkMap(IOpenApiLinkOperationMap links);
    }

    /// <summary>
    /// Implemented by types which can map a resource to a HAL document.
    /// </summary>
    /// <typeparam name="T">The type of the resource to map.</typeparam>
    public interface IHalDocumentMapper<T> : IHalDocumentMapper
    {
        /// <summary>
        /// Map a resource to a HAL document.
        /// </summary>
        /// <param name="resource">The resource to map.</param>
        /// <returns>The <see cref="HalDocument"/> for the resource.</returns>
        HalDocument Map(T resource);
    }
}
