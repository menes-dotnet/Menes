// <copyright file="PocoHttpResponseOutputBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;

    using Menes.Converters;

    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Builds an <see cref="OpenApiHttpResponseResult"/> for a POCO, with output validation aginst the <see cref="OpenApiOperation"/> definition.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This uses the <see cref="OpenApiHttpResponseResult"/> for the actual output formatting and validation.
    /// </para>
    /// </remarks>
    public class PocoHttpResponseOutputBuilder : IResponseOutputBuilder<IHttpResponseResult>
    {
        private readonly IEnumerable<IOpenApiConverter> converters;
        private readonly ILogger<PocoHttpResponseOutputBuilder> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PocoActionResultOutputBuilder"/> class.
        /// </summary>
        /// <param name="converters">The open API converters to use with the builder.</param>
        /// <param name="logger">The logger for the output builder.</param>
        public PocoHttpResponseOutputBuilder(
            IEnumerable<IOpenApiConverter> converters,
            ILogger<PocoHttpResponseOutputBuilder> logger)
        {
            this.converters = converters;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public int Priority => 10000;

        /// <inheritdoc/>
        public IHttpResponseResult BuildOutput(object result, OpenApiOperation operation)
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
            var httpResponseResult = OpenApiHttpResponseResult.FromPoco(result, operation, this.converters, this.logger);

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                                "Built output [{actionResult}] for [{operation}] using result [{@result}]",
                                httpResponseResult,
                                operation.OperationId,
                                result);
            }

            return httpResponseResult;
        }

        /// <inheritdoc/>
        public bool CanBuildOutput(object result, OpenApiOperation operation)
        {
            return !(result is OpenApiResult) && OpenApiHttpResponseResult.CanConstructFrom(result, operation, this.logger);
        }
    }
}
