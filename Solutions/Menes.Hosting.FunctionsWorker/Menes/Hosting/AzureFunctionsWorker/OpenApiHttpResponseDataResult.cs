// <copyright file="OpenApiHttpResponseDataResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AzureFunctionsWorker;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Menes.Converters;
using Menes.Exceptions;
using Menes.Internal;

using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

/// <summary>
/// Wraps an <see cref="OpenApiResult"/> instance with the ability to apply the result to an
/// <see cref="HttpResponseData"/>.
/// </summary>
/// <remarks>
/// <para>
/// Given an <see cref="OpenApiResult"/> and an <see cref="OpenApiOperation"/>, this validates
/// that the result conforms to the requirements of the operation, and then writes the result to the
/// appropriate parts of the response (e.g. headers, response body).
/// </para>
/// <para>
/// CAVEAT: It does not currently support writing cookies.
/// </para>
/// </remarks>
internal class OpenApiHttpResponseDataResult : OpenApiResponseResultBase<HttpRequestData, HttpResponseData>, IHttpResponseDataResult
{
    /// <summary>
    /// Creates an <see cref="OpenApiHttpResponseDataResult"/>.
    /// </summary>
    /// <param name="openApiResult">
    /// The result of the operation.
    /// </param>
    /// <param name="operation">
    /// The OpenAPI operation that was invoked to produce this result.
    /// </param>
    /// <param name="converters">The OpenAPI converters to use.</param>
    /// <param name="logger">A logger for the operation.</param>
    internal OpenApiHttpResponseDataResult(
        OpenApiResult openApiResult,
        OpenApiOperation operation,
        IEnumerable<IOpenApiConverter> converters,
        ILogger logger)
        : base(openApiResult, operation, converters, logger)
    {
    }

    /// <inheritdoc/>
    public async ValueTask<HttpResponseData> ExecuteResultAsync(HttpRequestData request)
    {
        return await this.ExecuteResultCoreAsync(request);
    }

    /// <summary>
    /// Creates a new <see cref="OpenApiHttpResponseDataResult"/> from an <see cref="OpenApiResult"/>.
    /// </summary>
    /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
    /// <param name="operation">The OpenAPI operation definition.</param>
    /// <param name="converters">The OpenAPI converters to use.</param>
    /// <param name="logger">A logger for the operation.</param>
    /// <returns>A new <see cref="OpenApiHttpResponseDataResult"/>.</returns>
    internal static OpenApiHttpResponseDataResult FromOpenApiResult(
        OpenApiResult openApiResult,
        OpenApiOperation operation,
        IEnumerable<IOpenApiConverter> converters,
        ILogger logger)
        => new(openApiResult, operation, converters, logger);

    /// <summary>
    /// Creates a new <see cref="OpenApiHttpResponseDataResult"/> from a plain object.
    /// </summary>
    /// <param name="result">The result object, or null.</param>
    /// <param name="operation">The OpenAPI operation definition.</param>
    /// <param name="converters">The OpenAPI converters to use.</param>
    /// <param name="logger">A logger for the operation.</param>
    /// <returns>A new <see cref="OpenApiHttpResponseDataResult"/>.</returns>
    internal static OpenApiHttpResponseDataResult FromPoco(
        object result,
        OpenApiOperation operation,
        IEnumerable<IOpenApiConverter> converters,
        ILogger logger)
        => new(GetOpenApiResultForPoco(result, operation, logger), operation, converters, logger);

    /// <summary>
    /// Builds an <see cref="OpenApiResult"/> for a POCO.
    /// </summary>
    /// <param name="result">
    /// The POCO result returned by the underlying operation implementation.
    /// </param>
    /// <param name="operation">
    /// The OpenAPI operation that was invoked.
    /// </param>
    /// <param name="logger">A logger.</param>
    /// <returns>An <see cref="OpenApiResult"/>.</returns>
    internal static OpenApiResult GetOpenApiResultForPoco(object result, OpenApiOperation operation, ILogger logger)
    {
        logger.LogDebug(
            "Attempting to get OpenAPI result for with POCO with [{operation}]",
            operation.GetOperationId());

        // Due to https://github.com/dotnet/roslyn/issues/30450, VS wants us to use var here.
        // And there seems to be a bug meaning that if we add a pragma to disable the IDE0007,
        // VS reports that as an IDE0079 unnecessary suppression! So we're reduced either to
        // having the (frankly non-obvious) type name remain obscure, or to put it in a comment.
        // It's a List<KeyValuePair<string, OpenApiResponse>>
        var successResponses = operation
            .Responses
            .Where(r => r.Key == "default" || (r.Key.Length == 3 && r.Key[0] == '2'))
            .ToList();
        if (successResponses.Count != 1)
        {
            throw new OpenApiServiceMismatchException($"An OpenApi service can only return a plain old CLR object (POCO) for operations that define exactly one success response (including the default response, if present), but '{operation.OperationId}' defines '{successResponses.Count}'. Return an {nameof(Menes.OpenApiResult)} instead, or modify the service definition to define a single successful response.");
        }

        KeyValuePair<string, OpenApiResponse> response = successResponses.Single();
        var openApiResult = new OpenApiResult
        {
            // Use the status code for the first response
            StatusCode = int.Parse(response.Key),
        };

        foreach (KeyValuePair<string, OpenApiMediaType> mediaType in response.Value.Content)
        {
            // Add all our candidate media types in
            openApiResult.Results.Add(mediaType.Key, result);
        }

        logger.LogDebug(
            "Got openAPIResult [{apiResult}] for poco with [{operation}]",
            openApiResult.Results.Keys,
            operation.GetOperationId());
        return openApiResult;
    }

    /// <summary>
    /// Determines if the result can be constructed from the provided result and operation definition.
    /// </summary>
    /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
    /// <param name="operation">The OpenAPI operation definition.</param>
    /// <returns>True if an action result can be constructed from this operation result.</returns>
    internal static bool CanConstructFrom(OpenApiResult openApiResult, OpenApiOperation operation)
    {
        if (!operation.Responses.TryGetResponseForStatusCode(openApiResult.StatusCode, out OpenApiResponse? response))
        {
            return false;
        }

        // Validate the required headers
        if (!response.Headers.Where(h => h.Value.Required).All(h => openApiResult.Results.ContainsKey(h.Key)))
        {
            return false;
        }

        // Validate the response body
        return response.Content == null || response.Content.Count == 0 || response.Content.Any(c => openApiResult.Results.ContainsKey(c.Key));
    }

    /// <summary>
    /// Determines if the action result can be constructed from the provided result and operation definition.
    /// </summary>
    /// <param name="poco">The poco from which to attempt to construct a result.</param>
    /// <param name="operation">The OpenAPI operation definition.</param>
    /// <param name="logger">The <see cref="ILogger"/>.</param>
    /// <returns>True if an action result can be constructed from this operation result.</returns>
    internal static bool CanConstructFrom(object poco, OpenApiOperation operation, ILogger logger)
    {
        return CanConstructFrom(GetOpenApiResultForPoco(poco, operation, logger), operation);
    }

    /// <inheritdoc/>
    protected override HttpResponseData InitializeResponseWithStatusCode(HttpRequestData request, HttpStatusCode statusCode)
    {
        return request.CreateResponse(statusCode);
    }

    /// <inheritdoc/>
    protected override void AddHeader(HttpResponseData response, string key, string value)
    {
        response.Headers.Add(key, value);
    }

    /// <inheritdoc/>
    protected override void SetResponseContentType(HttpResponseData response, string contentType)
    {
        response.Headers.Add("Content-Type", contentType);
    }

    /// <inheritdoc/>
    protected override Task SetResponseBodyAsStream(HttpResponseData response, Stream bodyStream)
    {
        return bodyStream.CopyToAsync(response.Body);
    }

    /// <inheritdoc/>
    protected override Task SetResponseBodyAsString(HttpResponseData response, string body)
    {
        return response.WriteStringAsync(body);
    }
}