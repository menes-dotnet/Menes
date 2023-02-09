// <copyright file="OpenApiHttpResponseResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Menes.Converters;
    using Menes.Exceptions;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Wraps an <see cref="OpenApiResult"/> instance with the ability to apply the result to an
    /// <see cref="HttpResponse"/>.
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
    internal class OpenApiHttpResponseResult : OpenApiResponseResultBase<HttpResponse, HttpResponse>, IHttpResponseResult
    {
        /// <summary>
        /// Creates an <see cref="OpenApiHttpResponseResult"/>.
        /// </summary>
        /// <param name="openApiResult">
        /// The result of the operation.
        /// </param>
        /// <param name="operation">
        /// The OpenAPI operation that was invoked to produce this result.
        /// </param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        internal OpenApiHttpResponseResult(
            OpenApiResult openApiResult,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
        : base(openApiResult, operation, converters, logger)
        {
        }

        /// <summary>
        /// Apply the actions described in the <see cref="OpenApiResult"/> to an <see cref="HttpResponse"/>.
        /// </summary>
        /// <param name="httpResponse">The response to populate.</param>
        /// <returns>A task that completes when the work is finished.</returns>
        public async Task ExecuteResultAsync(HttpResponse httpResponse)
        {
            await this.ExecuteResultCoreAsync(httpResponse);
        }

        /// <summary>
        /// Creates a new <see cref="OpenApiHttpResponseResult"/> from an <see cref="OpenApiResult"/>.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        /// <returns>A new <see cref="OpenApiHttpResponseResult"/>.</returns>
        internal static OpenApiHttpResponseResult FromOpenApiResult(
            OpenApiResult openApiResult,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
            => new(openApiResult, operation, converters, logger);

        /// <summary>
        /// Creates a new <see cref="OpenApiHttpResponseResult"/> from a plain object.
        /// </summary>
        /// <param name="result">The result object, or null.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        /// <returns>A new <see cref="OpenApiActionResult"/>.</returns>
        internal static OpenApiHttpResponseResult FromPoco(
            object result,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
            => new(OpenApiActionResult.GetOpenApiResultForPoco(result, operation, logger), operation, converters, logger);

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
            return CanConstructFrom(OpenApiActionResult.GetOpenApiResultForPoco(poco, operation, logger), operation);
        }

        /// <inheritdoc/>
        protected override HttpResponse InitializeResponseWithStatusCode(HttpResponse httpResponse, HttpStatusCode statusCode)
        {
            httpResponse.StatusCode = (int)statusCode;
            return httpResponse;
        }

        /// <inheritdoc/>
        protected override void AddHeader(HttpResponse response, string key, string value)
        {
            response.Headers.Add(key, new Microsoft.Extensions.Primitives.StringValues(value));
        }

        /// <inheritdoc/>
        protected override void SetResponseContentType(HttpResponse response, string contentType)
        {
            response.ContentType = contentType;
        }

        /// <inheritdoc/>
        protected override Task SetResponseBodyAsStream(HttpResponse response, Stream bodyStream)
        {
            return bodyStream.CopyToAsync(response.Body);
        }

        /// <inheritdoc/>
        protected override Task SetResponseBodyAsString(HttpResponse response, string body)
        {
            return response.WriteAsync(body);
        }
    }
}