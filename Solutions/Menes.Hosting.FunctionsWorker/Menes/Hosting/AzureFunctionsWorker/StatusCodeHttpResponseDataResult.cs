// <copyright file="StatusCodeHttpResponseDataResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AzureFunctionsWorker;

using System.Net;
using System.Threading.Tasks;

using Microsoft.Azure.Functions.Worker.Http;

/// <summary>
/// <see cref="IHttpResponseDataResult"/> that returns just a particular HTTP status code.
/// </summary>
internal sealed class StatusCodeHttpResponseDataResult : IHttpResponseDataResult
{
    private readonly int statusCode;

    /// <summary>
    /// Creates a <see cref="StatusCodeHttpResponseDataResult"/>.
    /// </summary>
    /// <param name="statusCode">The HTTP status code to return.</param>
    public StatusCodeHttpResponseDataResult(int statusCode)
    {
        this.statusCode = statusCode;
    }

    /// <inheritdoc/>
    public ValueTask<HttpResponseData> ExecuteResultAsync(HttpRequestData request)
    {
        return new ValueTask<HttpResponseData>(request.CreateResponse((HttpStatusCode)this.statusCode));
    }
}