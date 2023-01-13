// <copyright file="OpenApiHttpResponseDataResultBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AzureFunctionsWorker;

using Menes.Internal;

using Microsoft.Extensions.Logging;

/// <summary>
/// Builds an <see cref="OpenApiHttpResponseDataResult"/> for an OpenAPI result and operation.
/// </summary>
internal class OpenApiHttpResponseDataResultBuilder : OpenApiResultBuilder<IHttpResponseDataResult>
{
    /// <summary>
    /// Creates an <see cref="OpenApiHttpResponseDataResultBuilder"/>.
    /// </summary>
    /// <param name="outputBuilders">The output builders.</param>
    /// <param name="logger">The logger.</param>
    public OpenApiHttpResponseDataResultBuilder(
        IEnumerable<IResponseOutputBuilder<IHttpResponseDataResult>> outputBuilders,
        ILogger<OpenApiHttpResponseDataResultBuilder> logger)
        : base(outputBuilders, logger)
    {
    }

    /// <inheritdoc/>
    public override IHttpResponseDataResult BuildErrorResult(int statusCode)
    {
        return new StatusCodeHttpResponseDataResult(statusCode);
    }

    /// <inheritdoc/>
    public override IHttpResponseDataResult BuildServiceOperationNotFoundResult()
    {
        return new StatusCodeHttpResponseDataResult(404);
    }
}