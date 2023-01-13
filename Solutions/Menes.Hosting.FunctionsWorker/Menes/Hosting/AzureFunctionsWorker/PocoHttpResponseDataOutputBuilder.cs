// <copyright file="PocoHttpResponseDataOutputBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AzureFunctionsWorker;

using System.Collections.Generic;

using Menes.Converters;
using Menes.Internal;

using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

/// <summary>
/// Builds an <see cref="OpenApiHttpResponseDataResult"/> for a POCO, with output validation
/// against the <see cref="OpenApiOperation"/> definition.
/// </summary>
/// <remarks>
/// <para>
/// This uses the <see cref="OpenApiHttpResponseDataResult"/> for the actual output formatting and validation.
/// </para>
/// </remarks>
internal class PocoHttpResponseDataOutputBuilder : PocoOutputBuilder<IHttpResponseDataResult>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PocoHttpResponseDataOutputBuilder"/> class.
    /// </summary>
    /// <param name="converters">The open API converters to use with the builder.</param>
    /// <param name="logger">The logger for the output builder.</param>
    public PocoHttpResponseDataOutputBuilder(
        IEnumerable<IOpenApiConverter> converters,
        ILogger<PocoHttpResponseDataOutputBuilder> logger)
        : base(converters, logger)
    {
    }

    /// <inheritdoc/>
    protected override IHttpResponseDataResult FromPoco(
        object result,
        OpenApiOperation operation,
        IEnumerable<IOpenApiConverter> converters,
        ILogger logger)
    {
        return OpenApiHttpResponseDataResult.FromPoco(result, operation, converters, logger);
    }

    /// <inheritdoc/>
    protected override bool CanConstructFrom(
        OpenApiResult openApiResult,
        OpenApiOperation operation,
        ILogger logger)
    {
        return OpenApiHttpResponseDataResult.CanConstructFrom(openApiResult, operation, logger);
    }
}