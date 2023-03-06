// <copyright file="OpenApiHttpResponseResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Menes.Converters;
    using Menes.Exceptions;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Primitives;
    using Microsoft.Net.Http.Headers;
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json.Linq;

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
    internal class OpenApiHttpResponseResult : IHttpResponseResult
    {
        private readonly OpenApiResult openApiResult;
        private readonly OpenApiOperation operation;
        private readonly IEnumerable<IOpenApiConverter> converters;
        private readonly ILogger logger;

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
        {
            this.openApiResult = openApiResult;
            this.operation = operation;
            this.converters = converters;
            this.logger = logger;
        }

        /// <summary>
        /// Apply the actions described in the <see cref="OpenApiResult"/> to an <see cref="HttpResponse"/>.
        /// </summary>
        /// <param name="httpResponse">The response to populate.</param>
        /// <returns>A task that completes when the work is finished.</returns>
        public async Task ExecuteResultAsync(HttpResponse httpResponse)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug("Executing [{actionResult}]", this.openApiResult.GetLoggingInformation());
            }

            try
            {
                this.operation.Responses.TryGetResponseForStatusCode(this.openApiResult.StatusCode, out OpenApiResponse? response);

                httpResponse.StatusCode = this.openApiResult.StatusCode;

                this.BuildHeaders(httpResponse, response!);

                await this.WriteBodyAsync(httpResponse, response!);
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug("Executed [{actionResult}]", this.openApiResult.GetLoggingInformation());
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("Failed to execute OpenApiActionResult [{actionResult}], [{exMessage}]", this.openApiResult.GetLoggingInformation(), ex.Message);
                throw;
            }
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
                throw new OpenApiServiceMismatchException($"An OpenApi service can only return a plain old CLR object (POCO) for operations that define exactly one success response (including the default response, if present), but '{operation.OperationId}' defines '{successResponses.Count}'. Return an {nameof(OpenApiResult)} instead, or modify the service definition to define a single successful response.");
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

        private Task WriteBodyAsync(HttpResponse httpResponse, OpenApiResponse response)
        {
            if (response.Content?.Count > 0)
            {
                // TODO: We should probably find the first one where we can also convert the value, rather than just the first one!
                KeyValuePair<string, OpenApiMediaType> responseContent = response.Content.First(c => this.openApiResult.Results.ContainsKey(c.Key));
                object responseValue = this.openApiResult.Results[responseContent.Key];

                httpResponse.ContentType = responseContent.Key;

                if (responseValue is Stream responseAsStream)
                {
                    return responseAsStream.CopyToAsync(httpResponse.Body);
                }
                else
                {
                    string outputValue = this.ConvertValue(responseContent.Value.Schema, responseValue);
                    return httpResponse.WriteAsync(outputValue);
                }
            }

            return Task.CompletedTask;
        }

        private string ConvertValue(OpenApiSchema schema, object value)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug("Converting value to match [{schema}]", schema.GetLoggingInformation());
            }

            foreach (IOpenApiConverter converter in this.converters)
            {
                if (converter.CanConvert(schema))
                {
                    if (this.logger.IsEnabled(LogLevel.Debug))
                    {
                        this.logger.LogDebug(
                                            "Matched converter [{converter}] to the [{schema}]",
                                            converter.GetType(),
                                            schema.GetLoggingInformation());
                    }

                    return converter.ConvertTo(value, schema);
                }
            }

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                                "Failed to convert value with [{schema}], falling back to just type",
                                schema.GetLoggingInformation());
            }

            // We didn't hit anything directly, so let's fall back to just the type alone
            foreach (IOpenApiConverter converter in this.converters)
            {
                if (converter.CanConvert(schema, true))
                {
                    if (this.logger.IsEnabled(LogLevel.Debug))
                    {
                        this.logger.LogDebug(
                                                "Matched converter [{converter}] to the [{schema}], ignoring format",
                                                converter.GetType(),
                                                schema.GetLoggingInformation());
                    }

                    return converter.ConvertTo(value, schema);
                }
            }

            this.logger.LogError(
                "Failed to convert value with [{schema}]",
                schema.GetLoggingInformation());

            throw new OpenApiServiceMismatchException($"Failed to convert value to match [{schema.GetLoggingInformation()}]");
        }

        private void BuildHeaders(HttpResponse httpResponse, OpenApiResponse response)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug("Building headers for response [{response}]", response.Description);
            }

            foreach (KeyValuePair<string, OpenApiHeader> header in response.Headers)
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug("Attempting to add header for response [{response}]", response.Description);
                }

                if (this.openApiResult.Results.TryGetValue(header.Key, out object? value))
                {
                    string? convertedValue = null;

                    if (value is Func<string> valueAsFuncOfString)
                    {
                        convertedValue = this.ConvertValue(header.Value.Schema, valueAsFuncOfString());
                    }
                    else
                    {
                        convertedValue = this.ConvertValue(header.Value.Schema, value);
                    }

                    // If the input value was a string, it will have been returned as if it were a serialized JSON element.
                    // This means it will be quoted, which we don't want for values going in the headers, so we'll get rid
                    // of the quotes if they are present.
                    StringSegment processedValue = HeaderUtilities.RemoveQuotes(convertedValue);

                    httpResponse.Headers.Add(header.Key, new StringValues(processedValue.Value));

                    if (this.logger.IsEnabled(LogLevel.Debug))
                    {
                        this.logger.LogDebug("Added header for response [{response}]", response.Description);
                    }
                }
            }
        }
    }
}