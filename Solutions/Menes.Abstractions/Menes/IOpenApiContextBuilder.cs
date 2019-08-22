// <copyright file="IOpenApiContextBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface implemented by types responsible for building an <see cref="IOpenApiContext"/> for an incoming request.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    public interface IOpenApiContextBuilder<TRequest>
    {
        /// <summary>
        /// Builds an <see cref="IOpenApiContext" /> for an incoming request.
        /// </summary>
        /// <param name="request">The incoming reqeust.</param>
        /// <param name="parameters">A dynamic parameters object for the context builder.</param>
        /// <returns>The context for the request.</returns>
        /// <remarks>The parameters are defined by the particular context builder, and may include e.g. tenancy.</remarks>
        Task<IOpenApiContext> BuildAsync(TRequest request, dynamic parameters);
    }
}