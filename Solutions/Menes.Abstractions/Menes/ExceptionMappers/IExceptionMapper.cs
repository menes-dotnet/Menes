// <copyright file="IExceptionMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ExceptionMappers
{
    using System;

    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Maps an exception to an Open API response.
    /// </summary>
    public interface IExceptionMapper
    {
        /// <summary>
        /// Gets the priority of the exception mapper.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The candidate exception mappers will be executed in priority order, lowest to highest when searching for a default
        /// mapper in the event that no explict mapper is set for the Open API operation.
        /// </para>
        /// </remarks>
        int Priority { get; }

        /// <summary>
        /// Determines if a mapper can map a specific exception for an operation response.
        /// </summary>
        /// <param name="responses">The possible responses for the operation.</param>
        /// <param name="ex">The exception that has occurred.</param>
        /// <param name="statusCode">The status code for the ressonse.</param>
        /// <returns>True if this mapper can map the exception for this response.</returns>
        bool CanMapException(OpenApiResponses responses, Exception ex, int? statusCode);

        /// <summary>
        /// Maps and exception for an operation response.
        /// </summary>
        /// <param name="responses">The possible responses for the operation.</param>
        /// <param name="ex">The exception that has occurred.</param>
        /// <param name="statusCode">The status code for the ressonse.</param>
        /// <returns>The Open API result for the exception response.</returns>
        OpenApiResult MapException(OpenApiResponses responses, Exception ex, int? statusCode);
    }
}