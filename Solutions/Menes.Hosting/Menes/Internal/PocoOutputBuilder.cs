// <copyright file="PocoOutputBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;

    using Menes.Converters;

    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Common logic for building a response for a POCO, with output validation against the
    /// <see cref="OpenApiOperation"/> definition.
    /// </summary>
    /// <typeparam name="TResponse">The response type.</typeparam>
    internal abstract class PocoOutputBuilder<TResponse> : IResponseOutputBuilder<TResponse>
    {
        private readonly IEnumerable<IOpenApiConverter> converters;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PocoOutputBuilder{TResponse}"/> class.
        /// </summary>
        /// <param name="converters">The open API converters to use with the builder.</param>
        /// <param name="logger">The logger for the output builder.</param>
        protected PocoOutputBuilder(
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
        {
            this.converters = converters;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public int Priority => 10000;

        /// <inheritdoc/>
        public TResponse BuildOutput(object result, OpenApiOperation operation)
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
            TResponse response = this.FromPoco(result, operation, this.converters, this.logger);

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                                "Built output [{actionResult}] for [{operation}] using result [{@result}]",
                                response,
                                operation.OperationId,
                                result);
            }

            return response;
        }

        /// <inheritdoc/>
        public bool CanBuildOutput(object result, OpenApiOperation operation)
        {
            return result is not OpenApiResult && this.CanConstructFrom(result, operation, this.converters, this.logger);
        }

        /// <summary>
        /// Creates a response object from a plain object.
        /// </summary>
        /// <param name="result">The result object, or null.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        /// <returns>A new <typeparamref name="TResponse"/>.</returns>
        protected abstract TResponse FromPoco(
            object result,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger);

        /// <summary>
        /// Determines if the resposne can be constructed from the provided result and operation definition.
        /// </summary>
        /// <param name="result">The POCO result.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        /// <returns>True if an action result can be constructed from this operation result.</returns>
        protected abstract bool CanConstructFrom(
            object result,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger);
    }
}