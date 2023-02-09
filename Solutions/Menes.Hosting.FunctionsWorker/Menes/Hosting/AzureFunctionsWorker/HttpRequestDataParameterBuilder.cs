// <copyright file="HttpRequestDataParameterBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AzureFunctionsWorker;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Web;

using Menes.Converters;

using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

/// <summary>
/// An implementation of an <see cref="IOpenApiParameterBuilder{HttpRequestData}"/>.
/// </summary>
internal class HttpRequestDataParameterBuilder : OpenApiParameterBuilderBase<HttpRequestData>
{
    /// <summary>
    /// Creates a <see cref="HttpRequestDataParameterBuilder"/>.
    /// </summary>
    /// <param name="converters">The registered <see cref="IOpenApiConverter"/>s.</param>
    /// <param name="logger">The logger <see cref="ILogger"/>.</param>
    public HttpRequestDataParameterBuilder(
        IEnumerable<IOpenApiConverter> converters,
        ILogger<OpenApiParameterBuilderBase<HttpRequestData>> logger)
        : base(converters, logger)
    {
    }

    /// <inheritdoc/>
    protected override (Stream? Body, string? ContentType) GetBodyAndContentType(HttpRequestData request)
    {
        string? contentType = request.Headers.TryGetValues("Content-Type", out IEnumerable<string>? values)
            ? values.FirstOrDefault() : null;
        return (request.Body, contentType);
    }

    /// <inheritdoc/>
    protected override (string Path, string Method) GetPathAndMethod(HttpRequestData request)
    {
        return (request.Url.AbsolutePath, request.Method);
    }

    /// <inheritdoc/>
    protected override bool TryGetCookieValue(HttpRequestData request, string key, [NotNullWhen(true)] out string? value)
    {
        value = request.Cookies.FirstOrDefault(c => c.Name == key)?.Value;
        return value is not null;
    }

    /// <inheritdoc/>
    protected override bool TryGetHeaderValue(HttpRequestData request, string key, [NotNullWhen(true)] out string? value)
    {
        if (request.Headers.TryGetValues(key, out IEnumerable<string>? values))
        {
            value = values.First();
            return true;
        }

        value = null;
        return false;
    }

    /// <inheritdoc/>
    protected override bool TryGetQueryValue(HttpRequestData request, string key, [NotNullWhen(true)] out string? value)
    {
        NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(request.Url.Query);
        value = queryStringCollection[key];
        return value is not null;
    }
}