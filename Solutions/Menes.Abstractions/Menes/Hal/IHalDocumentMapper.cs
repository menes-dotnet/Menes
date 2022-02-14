// <copyright file="IHalDocumentMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    using System.Threading.Tasks;

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
        /// <remarks>
        /// This method returns <see cref="ValueTask{T}" /> rather than <see cref="Task{T}"/>
        /// because we expect that in a majority of cases, the implementation will be
        /// synchronous. As a rule, asynchronous operations such as data loading or lookup
        /// should be done prior to the mapper being invoked, and the results of those
        /// operations supplied to the mapper via
        /// <see cref="IHalDocumentMapper{TResource, TContext}.MapAsync(TResource, TContext)"/>.
        /// </remarks>
        ValueTask<HalDocument> MapAsync(T resource);
    }

    /// <summary>
    /// Implemented by types which can map a resource to a HAL document and require additional context for the mapping.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource to map.</typeparam>
    /// <typeparam name="TContext">The type of the object that provides additional context to the mapping.</typeparam>
    public interface IHalDocumentMapper<TResource, TContext> : IHalDocumentMapper
    {
        /// <summary>
        /// Map a resource to a HAL document.
        /// </summary>
        /// <param name="resource">The resource to map.</param>
        /// <param name="context">The additional context information.</param>
        /// <returns>The <see cref="HalDocument"/> for the resource.</returns>
        /// <remarks>
        /// This method returns <see cref="ValueTask{T}" /> rather than <see cref="Task{T}"/>
        /// because we expect that in a majority of cases, the implementation will be
        /// synchronous. As a rule, asynchronous operations such as data loading or lookup
        /// should be done prior to the mapper being invoked, and the results of those
        /// operations supplied via the <c>context</c> parameter.
        /// </remarks>
        ValueTask<HalDocument> MapAsync(TResource resource, TContext context);
    }
}