// <copyright file="IAsyncHalDocumentMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    using System.Threading.Tasks;

    /// <summary>
    /// Implemented by types which can map a resource to a HAL document.
    /// </summary>
    /// <typeparam name="T">The type of the resource to map.</typeparam>
    public interface IAsyncHalDocumentMapper<T> : IHalDocumentMapper
    {
        /// <summary>
        /// Map a resource to a HAL document.
        /// </summary>
        /// <param name="resource">The resource to map.</param>
        /// <returns>The <see cref="HalDocument"/> for the resource.</returns>
        Task<HalDocument> MapAsync(T resource);
    }

    /// <summary>
    /// Implemented by types which can map a resource to a HAL document and require additional context for the mapping.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource to map.</typeparam>
    /// <typeparam name="TContext">The type of the object that provides additional context to the mapping.</typeparam>
    public interface IAsyncHalDocumentMapper<TResource, TContext> : IHalDocumentMapper
    {
        /// <summary>
        /// Map a resource to a HAL document.
        /// </summary>
        /// <param name="resource">The resource to map.</param>
        /// <param name="context">The additional context information.</param>
        /// <returns>The <see cref="HalDocument"/> for the resource.</returns>
        Task<HalDocument> MapAsync(TResource resource, TContext context);
    }
}
