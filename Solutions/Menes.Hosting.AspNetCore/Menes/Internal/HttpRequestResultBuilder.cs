// <copyright file="HttpRequestResultBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Builds an IActionResult for an OpenAPI result and operation.
    /// </summary>
    public class HttpRequestResultBuilder : IOpenApiResultBuilder<IActionResult>
    {
        private readonly ILogger<HttpRequestResultBuilder> logger;
        private readonly IEnumerable<IActionResultOutputBuilder> outputBuilders;

        /// <summary>
        /// Creates and instance of the <see cref="HttpRequestResultBuilder"/>.
        /// </summary>
        /// <param name="outputBuilders">The output builders.</param>
        /// <param name="logger">The logger.</param>
        public HttpRequestResultBuilder(IEnumerable<IActionResultOutputBuilder> outputBuilders, ILogger<HttpRequestResultBuilder> logger)
        {
            this.logger = logger;
            this.outputBuilders = outputBuilders.OrderBy(b => b.Priority).ToList();
        }

        /// <inheritdoc/>
        public IActionResult BuildErrorResult(int statusCode)
        {
            return new StatusCodeResult(statusCode);
        }

        /// <inheritdoc/>
        public IActionResult BuildServiceOperationNotFoundResult()
        {
            return new NotFoundResult();
        }

        /// <inheritdoc/>
        public IActionResult BuildResult(object result, OpenApiOperation operation)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Building result for [{operation}]",
                    operation.OperationId);
            }

            foreach (IActionResultOutputBuilder outputBuilder in this.outputBuilders)
            {
                if (outputBuilder.CanBuildOutput(result, operation))
                {
                    IActionResult output = outputBuilder.BuildOutput(result, operation);
                    if (this.logger.IsEnabled(LogLevel.Information))
                    {
                        this.logger.LogInformation(
                            "Built result for [{operation}]",
                            operation.OperationId);
                    }

                    return output;
                }
            }

            this.logger.LogError(
                "Failed to build result for [{operation}] no output builder has been registered that can handle the operation and result",
                operation.OperationId);
            throw new OutputBuilderNotFoundException(result, operation);
        }
    }
}
