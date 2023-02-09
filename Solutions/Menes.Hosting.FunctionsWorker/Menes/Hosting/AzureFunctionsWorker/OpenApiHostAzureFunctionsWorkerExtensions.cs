// <copyright file="OpenApiHostAzureFunctionsWorkerExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AzureFunctionsWorker;

using System.Threading.Tasks;

using Microsoft.Azure.Functions.Worker.Http;

/// <summary>
/// Extension methods for <see cref="IOpenApiHost{HttpRequest, IHttpResponseResult}"/>.
/// </summary>
/// <remarks>
/// <para>
/// Applications typically call this from an HTTP trigger method..
/// </para>
/// </remarks>
public static class OpenApiHostAzureFunctionsWorkerExtensions
{
    /// <summary>
    /// Uses the <see cref="IOpenApiHost{HttpRequest, IActionResult}"/> to handle the request.
    /// </summary>
    /// <param name="host">The host to handle the request.</param>
    /// <param name="request">The request to handle.</param>
    /// <param name="parameters">Any dynamically constructed parameters sent to the request.</param>
    /// <returns>The result of the request.</returns>
    public static async Task<HttpResponseData> HandleRequestAsync(
        this IOpenApiHost<HttpRequestData, IHttpResponseDataResult> host,
        HttpRequestData request,
        object parameters)
    {
        IHttpResponseDataResult result = await host.HandleRequestAsync(
            request.Url.AbsolutePath,
            request.Method,
            request,
            parameters);
        return await result.ExecuteResultAsync(request);
    }
}