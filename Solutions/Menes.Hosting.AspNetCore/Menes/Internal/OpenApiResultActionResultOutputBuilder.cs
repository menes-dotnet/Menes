﻿// <copyright file="OpenApiResultActionResultOutputBuilder.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Endjin.OpenApi.Internal
{
    using System.Collections.Generic;
    using Endjin.OpenApi.Converters;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Builds an <see cref="IActionResult"/> for an <see cref="OpenApiResult"/>, with output validation aginst the <see cref="OpenApiOperation"/> definition.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This uses the <see cref="OpenApiActionResult"/> for the actual output formatting and validation.
    /// </para>
    /// </remarks>
    public class OpenApiResultActionResultOutputBuilder : IActionResultOutputBuilder
    {
        private readonly IEnumerable<IOpenApiConverter> converters;
        private readonly ILogger<OpenApiResultActionResultOutputBuilder> logger;
        private readonly OpenApiConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiResultActionResultOutputBuilder"/> class.
        /// </summary>
        /// <param name="configuration">The current host configuration.</param>
        /// <param name="converters">The open API converters to use with the builder.</param>
        /// <param name="logger">The logger for the output builder.</param>
        public OpenApiResultActionResultOutputBuilder(OpenApiConfiguration configuration, IEnumerable<IOpenApiConverter> converters, ILogger<OpenApiResultActionResultOutputBuilder> logger)
        {
            this.converters = converters;
            this.logger = logger;
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        public int Priority => 100;

        /// <inheritdoc/>
        public IActionResult BuildOutput(object result, OpenApiOperation operation)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                                "Building output for [{operation}]",
                                operation.GetOperationId());
            }

            // This must have been called after CanBuildOutput(), so we know these casts
            // and lookups will succeed
            var openApiResult = result as OpenApiResult;

            var actionResult = OpenApiActionResult.FromOpenApiResult(openApiResult, operation, this.configuration, this.converters, this.logger);

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                                "Built output for [{operation}]",
                                operation.GetOperationId());
            }

            return actionResult;
        }

        /// <inheritdoc/>
        public bool CanBuildOutput(object result, OpenApiOperation operation)
        {
            // Are we an OpenApi Result?
            if (!(result is OpenApiResult openApiResult))
            {
                return false;
            }

            return OpenApiActionResult.CanConstructFrom(openApiResult, operation);
        }
    }
}