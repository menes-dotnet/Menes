// <copyright file="OpenApiResultBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Builds a response object for an OpenAPI result and operation.
    /// </summary>
    /// <typeparam name="TResponse">
    /// The response type.
    /// </typeparam>
    internal abstract class OpenApiResultBuilder<TResponse> : IOpenApiResultBuilder<TResponse>
    {
        private readonly ILogger<OpenApiResultBuilder<TResponse>> logger;
        private readonly IEnumerable<IResponseOutputBuilder<TResponse>> outputBuilders;

        /// <summary>
        /// Initializes an <see cref="OpenApiResultBuilder{TResponse}"/>.
        /// </summary>
        /// <param name="outputBuilders">The output builders.</param>
        /// <param name="logger">The logger.</param>
        protected OpenApiResultBuilder(
            IEnumerable<IResponseOutputBuilder<TResponse>> outputBuilders,
            ILogger<OpenApiResultBuilder<TResponse>> logger)
        {
            this.logger = logger;
            this.outputBuilders = outputBuilders.OrderBy(b => b.Priority).ToList();
        }

        /// <inheritdoc/>
        public abstract TResponse BuildErrorResult(int statusCode);

        /// <inheritdoc/>
        public TResponse BuildResult(object result, OpenApiOperation operation)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Building result for [{operation}]",
                    operation.OperationId);
            }

            foreach (IResponseOutputBuilder<TResponse> outputBuilder in this.outputBuilders)
            {
                if (outputBuilder.CanBuildOutput(result, operation))
                {
                    TResponse output = outputBuilder.BuildOutput(result, operation);
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

        /// <inheritdoc/>
        public abstract TResponse BuildServiceOperationNotFoundResult();
    }
}