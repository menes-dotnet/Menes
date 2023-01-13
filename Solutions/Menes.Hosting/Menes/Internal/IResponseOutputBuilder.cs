// <copyright file="IResponseOutputBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Interface implemented by types that are used to build outputs to be used with the Menes
    /// host.
    /// </summary>
    /// <typeparam name="TResponse">
    /// The response type. Corresponds to the 2nd type argument in
    /// <see cref="IOpenApiHost{TRequest, TResponse}"/>.
    /// </typeparam>
    public interface IResponseOutputBuilder<TResponse>
    {
        /// <summary>
        /// Gets the priority of the output builder.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The candidate output builders will be executed in priority order, lowest to highest.
        /// </para>
        /// </remarks>
        int Priority { get; }

        /// <summary>
        /// Indicates whether the builder can build a result for the given operation and result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="operation">The operation.</param>
        /// <returns>True if the builder can handle the operation and result.</returns>
        bool CanBuildOutput(object result, OpenApiOperation operation);

        /// <summary>
        /// Build the result for the operation.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="operation">The operation.</param>
        /// <returns>The <typeparamref name="TResponse"/> constructed from the operation and result.</returns>
        TResponse BuildOutput(object result, OpenApiOperation operation);
    }
}