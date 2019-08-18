// <copyright file="DefaultExceptionMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ExceptionMappers
{
    using System;
    using Menes.Internal;
    using Microsoft.OpenApi.Models;

    /// <inheritdoc/>
    public class DefaultExceptionMapper : IExceptionMapper
    {
        /// <inheritdoc/>
        public int Priority => 15000;

        /// <inheritdoc/>
        public bool CanMapException(OpenApiResponses responses, Exception ex, int? statusCode)
        {
            return responses.TryGetResponseForStatusCode(statusCode, out _);
        }

        /// <inheritdoc/>
        public OpenApiResult MapException(OpenApiResponses responses, Exception ex, int? statusCode)
        {
            return new OpenApiResult { StatusCode = statusCode ?? 500 };
        }
    }
}