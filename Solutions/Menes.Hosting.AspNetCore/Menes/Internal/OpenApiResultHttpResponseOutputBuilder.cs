// <copyright file="OpenApiResultHttpResponseOutputBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;

    using Menes.Converters;

    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Builds an <see cref="OpenApiHttpResponseResult"/> for an <see cref="OpenApiResult"/>, with
    /// output validation against the <see cref="OpenApiOperation"/> definition.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This uses the <see cref="OpenApiHttpResponseResult"/> for the actual output formatting and validation.
    /// </para>
    /// </remarks>
    internal class OpenApiResultHttpResponseOutputBuilder : OpenApiResultOutputBuilder<IHttpResponseResult>
    {
        /// <summary>
        /// Creates an <see cref="OpenApiResultHttpResponseOutputBuilder"/>.
        /// </summary>
        /// <param name="converters">The open API converters to use with the builder.</param>
        /// <param name="logger">The logger for the output builder.</param>
        public OpenApiResultHttpResponseOutputBuilder(
            IEnumerable<IOpenApiConverter> converters,
            ILogger<OpenApiResultHttpResponseOutputBuilder> logger)
            : base(converters, logger)
        {
        }

        /// <inheritdoc/>
        protected override IHttpResponseResult FromOpenApiResult(
            OpenApiResult openApiResult,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
        {
            return OpenApiHttpResponseResult.FromOpenApiResult(openApiResult, operation, converters, logger);
        }

        /// <inheritdoc/>
        protected override bool CanConstructFrom(OpenApiResult openApiResult, OpenApiOperation operation)
        {
            return OpenApiHttpResponseResult.CanConstructFrom(openApiResult, operation);
        }
    }
}