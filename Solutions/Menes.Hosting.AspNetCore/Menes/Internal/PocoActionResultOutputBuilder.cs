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
    /// Builds an <see cref="IActionResult"/> for a POCO, with output validation against the
    /// <see cref="OpenApiOperation"/> definition.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This uses the <see cref="OpenApiActionResult"/> for the actual output formatting and validation.
    /// </para>
    /// </remarks>
    internal class PocoActionResultOutputBuilder : PocoOutputBuilder<IActionResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PocoActionResultOutputBuilder"/> class.
        /// </summary>
        /// <param name="converters">The open API converters to use with the builder.</param>
        /// <param name="logger">The logger for the output builder.</param>
        public PocoActionResultOutputBuilder(
            IEnumerable<IOpenApiConverter> converters,
            ILogger<PocoActionResultOutputBuilder> logger)
            : base(converters, logger)
        {
        }

        /// <inheritdoc/>
        protected override IActionResult FromPoco(
            object result,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
        {
            return OpenApiActionResult.FromPoco(result, operation, converters, logger);
        }

        /// <inheritdoc/>
        protected override bool CanConstructFrom(OpenApiResult openApiResult, OpenApiOperation operation, ILogger logger)
        {
            return OpenApiActionResult.CanConstructFrom(openApiResult, operation, logger);
        }
    }
}