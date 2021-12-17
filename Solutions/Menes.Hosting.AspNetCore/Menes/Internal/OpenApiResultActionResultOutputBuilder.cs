// <copyright file="OpenApiResultActionResultOutputBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;

    using Menes.Converters;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Builds an <see cref="IActionResult"/> for an <see cref="OpenApiResult"/>, with output
    /// validation against the <see cref="OpenApiOperation"/> definition.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This uses the <see cref="OpenApiActionResult"/> for the actual output formatting and validation.
    /// </para>
    /// </remarks>
    internal class OpenApiResultActionResultOutputBuilder : OpenApiResultOutputBuilder<IActionResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiResultActionResultOutputBuilder"/> class.
        /// </summary>
        /// <param name="converters">The open API converters to use with the builder.</param>
        /// <param name="logger">The logger for the output builder.</param>
        public OpenApiResultActionResultOutputBuilder(
            IEnumerable<IOpenApiConverter> converters,
            ILogger<OpenApiResultActionResultOutputBuilder> logger)
            : base(converters, logger)
        {
        }

        /// <inheritdoc/>
        protected override IActionResult FromOpenApiResult(
            OpenApiResult openApiResult,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
        {
            return OpenApiActionResult.FromOpenApiResult(openApiResult, operation, converters, logger);
        }

        /// <inheritdoc/>
        protected override bool CanConstructFrom(OpenApiResult openApiResult, OpenApiOperation operation)
        {
            return OpenApiActionResult.CanConstructFrom(openApiResult, operation);
        }
    }
}