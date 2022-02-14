// <copyright file="IOpenApiContextBuilderComponent.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface implemented by types responsible for setting properties on an <see cref="IOpenApiContext"/> for an incoming request.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    public interface IOpenApiContextBuilderComponent<TRequest>
    {
        /// <summary>
        /// Sets properties on an <see cref="IOpenApiContext"/> for an incoming request.
        /// </summary>
        /// <param name="context">The <see cref="IOpenApiContext"/> for the current request.</param>
        /// <param name="request">The incoming request.</param>
        /// <param name="parameters">A dyamically built parameters object passed to the builder.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task BuildAsync(IOpenApiContext context, TRequest request, object parameters);
    }
}