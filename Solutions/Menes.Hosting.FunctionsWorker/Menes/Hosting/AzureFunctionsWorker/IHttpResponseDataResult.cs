// <copyright file="IHttpResponseDataResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AzureFunctionsWorker;

using Microsoft.Azure.Functions.Worker.Http;

/// <summary>
/// Populates an <see cref="HttpResponseData"/> with the outcome (or failure) of an operation.
/// </summary>
/// <remarks>
/// Used in Azure Functions isolated mode (<see cref="OpenApiHostAzureFunctionsWorkerExtensions.HandleRequestAsync(IOpenApiHost{HttpRequestData, IHttpResponseDataResult}, HttpRequestData, object)"/>).
/// This enables Menes to build a description of how the HTTP response is to be generated,
/// which can then be applied to the <see cref="HttpRequestData"/> supplied by Functions once
/// Menes is done.
/// </remarks>
public interface IHttpResponseDataResult
{
    /// <summary>
    /// Populates the response.
    /// </summary>
    /// <param name="request">The request from which to build the response.</param>
    /// <returns>A task that completes when the response has been populated.</returns>
    ValueTask<HttpResponseData> ExecuteResultAsync(HttpRequestData request);
}