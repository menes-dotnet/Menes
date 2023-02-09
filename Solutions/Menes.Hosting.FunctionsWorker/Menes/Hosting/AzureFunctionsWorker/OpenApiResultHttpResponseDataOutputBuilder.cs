// <copyright file="OpenApiResultHttpResponseDataOutputBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AzureFunctionsWorker;

using System.Collections.Generic;

using Menes.Converters;
using Menes.Internal;

using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

/// <summary>
/// Builds an <see cref="OpenApiHttpResponseDataResult"/> for an <see cref="OpenApiResult"/>, with
/// output validation against the <see cref="OpenApiOperation"/> definition.
/// </summary>
/// <remarks>
/// <para>
/// This uses the <see cref="OpenApiHttpResponseDataResult"/> for the actual output formatting and validation.
/// </para>
/// </remarks>
internal class OpenApiResultHttpResponseDataOutputBuilder : OpenApiResultOutputBuilder<IHttpResponseDataResult>
{
    /// <summary>
    /// Creates an <see cref="OpenApiResultHttpResponseDataOutputBuilder"/>.
    /// </summary>
    /// <param name="converters">The open API converters to use with the builder.</param>
    /// <param name="logger">The logger for the output builder.</param>
    public OpenApiResultHttpResponseDataOutputBuilder(
        IEnumerable<IOpenApiConverter> converters,
        ILogger<OpenApiResultHttpResponseDataOutputBuilder> logger)
        : base(converters, logger)
    {
    }

    /// <inheritdoc/>
    protected override IHttpResponseDataResult FromOpenApiResult(
        OpenApiResult openApiResult,
        OpenApiOperation operation,
        IEnumerable<IOpenApiConverter> converters,
        ILogger logger)
    {
        return OpenApiHttpResponseDataResult.FromOpenApiResult(openApiResult, operation, converters, logger);
    }

    /// <inheritdoc/>
    protected override bool CanConstructFrom(OpenApiResult openApiResult, OpenApiOperation operation)
    {
        return OpenApiHttpResponseDataResult.CanConstructFrom(openApiResult, operation);
    }
}