// <copyright file="IOpenApiResultBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Builds a response for the result of an Open API operation.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface IOpenApiResultBuilder<TResponse>
    {
        /// <summary>
        /// Build a response for the request of a service operation.
        /// </summary>
        /// <param name="result">The result of the service operation.</param>
        /// <param name="operation">The Open API operation definition.</param>
        /// <returns>A response corresponding to the result of the request.</returns>
        TResponse BuildResult(object result, OpenApiOperation operation);

        /// <summary>
        /// Build a response for the given status code.
        /// </summary>
        /// <param name="statusCode">The specified status code.</param>
        /// <returns>A repsonse corresponding to the relevant status code.</returns>
        TResponse BuildErrorResult(int statusCode);

        /// <summary>
        /// Build a response for the case where a service operation is not found that corresponds to the request.
        /// </summary>
        /// <returns>A response for when the service operation is not found.</returns>
        TResponse BuildServiceOperationNotFoundResult();
    }
}