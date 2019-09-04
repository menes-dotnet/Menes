// <copyright file="PocoActionResultOutputBuilder.cs" company="Endjin Limited">
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
    /// Builds an <see cref="IActionResult"/> for a POCO, with output validation aginst the <see cref="OpenApiOperation"/> definition.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This uses the <see cref="OpenApiActionResult"/> for the actual output formatting and validation.
    /// </para>
    /// </remarks>
    public class PocoActionResultOutputBuilder : IActionResultOutputBuilder
    {
        private readonly IEnumerable<IOpenApiConverter> converters;
        private readonly ILogger<PocoActionResultOutputBuilder> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PocoActionResultOutputBuilder"/> class.
        /// </summary>
        /// <param name="converters">The open API converters to use with the builder.</param>
        /// <param name="logger">The logger for the output builder.</param>
        public PocoActionResultOutputBuilder(IEnumerable<IOpenApiConverter> converters, ILogger<PocoActionResultOutputBuilder> logger)
        {
            this.converters = converters;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public int Priority => 10000;

        /// <inheritdoc/>
        public IActionResult BuildOutput(object result, OpenApiOperation operation)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                                "Building output for [{operation}] using result [{@result}]",
                                operation.OperationId,
                                result);
            }

            // This must have been called after CanBuildOutput(), so we know these casts
            // and lookups will succeed
            var actionResult = OpenApiActionResult.FromPoco(result, operation, this.converters, this.logger);

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                                "Built output [{actionResult}] for [{operation}] using result [{@result}]",
                                actionResult,
                                operation.OperationId,
                                result);
            }

            return actionResult;
        }

        /// <inheritdoc/>
        public bool CanBuildOutput(object result, OpenApiOperation operation)
        {
            return !(result is OpenApiResult) && OpenApiActionResult.CanConstructFrom(result, operation, this.logger);
        }
    }
}