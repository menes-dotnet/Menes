// <copyright file="HttpRequestParameterBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

using Menes.Converters;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

/// <summary>
/// An implementation of an <see cref="IOpenApiParameterBuilder{HttpRequest}"/>.
/// </summary>
internal class HttpRequestParameterBuilder : OpenApiParameterBuilderBase<HttpRequest>
{
    /// <summary>
    /// Creates a <see cref="HttpRequestParameterBuilder"/>.
    /// </summary>
    /// <param name="converters">The registered <see cref="IOpenApiConverter"/>s.</param>
    /// <param name="logger">The logger <see cref="ILogger"/>.</param>
    public HttpRequestParameterBuilder(
        IEnumerable<IOpenApiConverter> converters,
        ILogger<HttpRequestParameterBuilder> logger)
        : base(converters, logger)
    {
    }

    /// <inheritdoc/>
    protected override (string Path, string Method) GetPathAndMethod(HttpRequest request) => (request.Path, request.Method);

    /// <inheritdoc/>
    protected override (Stream? Body, string? ContentType) GetBodyAndContentType(HttpRequest request)
         => (request.Body, request.ContentType);

    /// <inheritdoc/>
    protected override bool TryGetCookieValue(HttpRequest request, string key, [NotNullWhen(true)] out string? value)
    {
        IRequestCookieCollection cookies = request.Cookies;
        if (cookies == null)
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug(
                    "Failed to get parameter from cookies for parameter [{parameter}], cookies are null",
                    key);
            }
        }
        else if (cookies.TryGetValue(key, out value))
        {
            return value is not null;
        }

        value = null;
        return false;
    }

    /// <inheritdoc/>
    protected override bool TryGetHeaderValue(HttpRequest request, string key, [NotNullWhen(true)] out string? value)
    {
        IHeaderDictionary headers = request.Headers;
        if (headers is null)
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug(
                    "Failed to get parameter from headers for parameter [{parameter}], headers are null",
                    key);
            }
        }
        else if (headers.TryGetValue(key, out Microsoft.Extensions.Primitives.StringValues values))
        {
            value = values.ToString();
            return true;
        }

        value = null;
        return false;
    }

    /// <inheritdoc/>
    protected override bool TryGetQueryValue(HttpRequest request, string key, [NotNullWhen(true)] out string? value)
    {
        IQueryCollection query = request.Query;
        if (query == null)
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug(
                    "Failed to get parameter from query for parameter [{parameter}], query is null",
                    key);
            }
        }
        else if (query.TryGetValue(key, out Microsoft.Extensions.Primitives.StringValues values))
        {
            value = values[0];
            return true;
        }

        value = null;
        return false;
    }
}