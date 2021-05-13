// <copyright file="OpenApiHttpResponseResultBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Builds an <see cref="OpenApiHttpResponseResult"/> for an OpenAPI result and operation.
    /// </summary>
    internal class OpenApiHttpResponseResultBuilder : OpenApiResultBuilder<IHttpResponseResult>
    {
        /// <summary>
        /// Creates and instance of the <see cref="OpenApiActionResultBuilder"/>.
        /// </summary>
        /// <param name="outputBuilders">The output builders.</param>
        /// <param name="logger">The logger.</param>
        public OpenApiHttpResponseResultBuilder(
            IEnumerable<IResponseOutputBuilder<IHttpResponseResult>> outputBuilders,
            ILogger<OpenApiHttpResponseResultBuilder> logger)
            : base(outputBuilders, logger)
        {
        }

        /// <inheritdoc/>
        public override IHttpResponseResult BuildErrorResult(int statusCode)
        {
            return new StatusCodeHttpResponseResult(statusCode);
        }

        /// <inheritdoc/>
        public override IHttpResponseResult BuildServiceOperationNotFoundResult()
        {
            return new StatusCodeHttpResponseResult(404);
        }
    }
}