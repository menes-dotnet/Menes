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
    /// Builds an <see cref="OpenApiHttpResponseResult"/> for a POCO, with output validation
    /// against the <see cref="OpenApiOperation"/> definition.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This uses the <see cref="OpenApiHttpResponseResult"/> for the actual output formatting and validation.
    /// </para>
    /// </remarks>
    internal class PocoHttpResponseOutputBuilder : PocoOutputBuilder<IHttpResponseResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PocoActionResultOutputBuilder"/> class.
        /// </summary>
        /// <param name="converters">The open API converters to use with the builder.</param>
        /// <param name="logger">The logger for the output builder.</param>
        public PocoHttpResponseOutputBuilder(
            IEnumerable<IOpenApiConverter> converters,
            ILogger<PocoHttpResponseOutputBuilder> logger)
            : base(converters, logger)
        {
        }

        /// <inheritdoc/>
        protected override IHttpResponseResult FromPoco(
            object result,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
        {
            return OpenApiHttpResponseResult.FromPoco(result, operation, converters, logger);
        }

        /// <inheritdoc/>
        protected override bool CanConstructFrom(
            object result,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
        {
            return OpenApiHttpResponseResult.CanConstructFrom(result, operation, logger);
        }
    }
}