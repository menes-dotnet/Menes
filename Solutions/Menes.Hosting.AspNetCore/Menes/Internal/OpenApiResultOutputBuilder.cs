// <copyright file="OpenApiResultOutputBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;

    using Menes.Converters;

    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Common logic for building a response for an <see cref="OpenApiResult"/>, with output
    /// validation against the <see cref="OpenApiOperation"/> definition.
    /// </summary>
    /// <typeparam name="TResponse">The response type.</typeparam>
    internal abstract class OpenApiResultOutputBuilder<TResponse> : IResponseOutputBuilder<TResponse>
    {
        private readonly IEnumerable<IOpenApiConverter> converters;
        private readonly ILogger logger;

        /// <summary>
        /// Creates an <see cref="OpenApiResultOutputBuilder{TResponse}"/>.
        /// </summary>
        /// <param name="converters">The open API converters to use with the builder.</param>
        /// <param name="logger">The logger for the output builder.</param>
        protected OpenApiResultOutputBuilder(
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
        {
            this.converters = converters;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public int Priority => 100;

        /// <inheritdoc/>
        public TResponse BuildOutput(object result, OpenApiOperation operation)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                                "Building output for [{operation}]",
                                operation.GetOperationId());
            }

            // This must have been called after CanBuildOutput(), so we know these casts
            // and lookups will succeed
            var openApiResult = (OpenApiResult)result;

            TResponse response = this.FromOpenApiResult(openApiResult, operation, this.converters, this.logger);

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                                "Built output for [{operation}]",
                                operation.GetOperationId());
            }

            return response;
        }

        /// <inheritdoc/>
        public bool CanBuildOutput(object result, OpenApiOperation operation)
        {
            // Are we an OpenApi Result?
            if (result is not OpenApiResult openApiResult)
            {
                return false;
            }

            return this.CanConstructFrom(openApiResult, operation);
        }

        /// <summary>
        /// Creates a response object from an <see cref="OpenApiResult"/>.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        /// <returns>A new <typeparamref name="TResponse"/>.</returns>
        protected abstract TResponse FromOpenApiResult(
            OpenApiResult openApiResult,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger);

        /// <summary>
        /// Determines if the action result can be constructed from the provided result and operation definition.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <returns>True if an action result can be constructed from this operation result.</returns>
        protected abstract bool CanConstructFrom(OpenApiResult openApiResult, OpenApiOperation operation);
    }
}