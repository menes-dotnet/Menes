// <copyright file="OpenApiActionResultBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Builds an IActionResult for an OpenAPI result and operation.
    /// </summary>
    internal class OpenApiActionResultBuilder : OpenApiResultBuilder<IActionResult>
    {
        /// <summary>
        /// Creates and instance of the <see cref="OpenApiActionResultBuilder"/>.
        /// </summary>
        /// <param name="outputBuilders">The output builders.</param>
        /// <param name="logger">The logger.</param>
        public OpenApiActionResultBuilder(
            IEnumerable<IResponseOutputBuilder<IActionResult>> outputBuilders,
            ILogger<OpenApiActionResultBuilder> logger)
            : base(outputBuilders, logger)
        {
        }

        /// <inheritdoc/>
        public override IActionResult BuildErrorResult(int statusCode)
        {
            return new StatusCodeResult(statusCode);
        }

        /// <inheritdoc/>
        public override IActionResult BuildServiceOperationNotFoundResult()
        {
            return new NotFoundResult();
        }
    }
}