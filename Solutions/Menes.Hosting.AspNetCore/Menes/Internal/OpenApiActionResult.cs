// <copyright file="OpenApiActionResult.cs" company="Endjin Limited">
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
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An <see cref="ActionResult"/> for <see cref="OpenApiResult"/> instances.
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
    internal sealed class OpenApiActionResult : ActionResult
    {
        private readonly OpenApiResult openApiResult;
        private readonly OpenApiOperation operation;
        private readonly IEnumerable<IOpenApiConverter> converters;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiActionResult"/> class.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        private OpenApiActionResult(
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
        /// Creates a new <see cref="OpenApiActionResult"/> from an <see cref="OpenApiResult"/>.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        /// <returns>A new <see cref="OpenApiActionResult"/>.</returns>
        public static OpenApiActionResult FromOpenApiResult(
            OpenApiResult openApiResult,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
            => new OpenApiActionResult(openApiResult, operation, converters, logger);

        /// <summary>
        /// Creates a new <see cref="OpenApiActionResult"/> from a plain object.
        /// </summary>
        /// <param name="result">The result object, or null.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        /// <returns>A new <see cref="OpenApiActionResult"/>.</returns>
        public static OpenApiActionResult FromPoco(
            object result,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
            => new OpenApiActionResult(GetOpenApiResultForPoco(result, operation, logger), operation, converters, logger);

        /// <summary>
        /// Determines if the action result can be constructed from the provided result and operation definition.
        /// </summary>
        /// <param name="poco">The poco from which to attempt to construct a result.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <returns>True if an action result can be constructed from this operation result.</returns>
        public static bool CanConstructFrom(object poco, OpenApiOperation operation, ILogger logger)
        {
            return CanConstructFrom(GetOpenApiResultForPoco(poco, operation, logger), operation);
        }

        /// <summary>
        /// Determines if the action result can be constructed from the provided result and operation definition.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <returns>True if an action result can be constructed from this operation result.</returns>
        public static bool CanConstructFrom(OpenApiResult openApiResult, OpenApiOperation operation)
        {
            if (!operation.Responses.TryGetResponseForStatusCode(openApiResult.StatusCode, out OpenApiResponse response))
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

        /// <inheritdoc/>
        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug("Executing [{actionResult}]", this.openApiResult.GetLoggingInformation());
            }

            try
            {
                this.operation.Responses.TryGetResponseForStatusCode(this.openApiResult.StatusCode, out OpenApiResponse response);

                HttpResponse httpResponse = context.HttpContext.Response;

                httpResponse.StatusCode = this.openApiResult.StatusCode;

                this.BuildHeaders(httpResponse, response);

                Task task = this.WriteBodyAsync(httpResponse, response);
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug("Executed [{actionResult}]", this.openApiResult.GetLoggingInformation());
                }

                return task;
            }
            catch (Exception ex)
            {
                this.logger.LogError("Failed to execute OpenApiActionResult [{actionResult}], [{exMessage}]", this.openApiResult.GetLoggingInformation(), ex.Message);
                throw;
            }
        }

        private static OpenApiResult GetOpenApiResultForPoco(object result, OpenApiOperation operation, ILogger logger)
        {
            logger.LogDebug(
                "Attempting to get OpenAPI result for with POCO with [{operation}]",
                operation.GetOperationId());
#pragma warning disable IDE0007 // Use implicit type - see https://github.com/dotnet/roslyn/issues/30450
            List<KeyValuePair<string, OpenApiResponse>> successResponses = operation
#pragma warning restore IDE0007 // Use implicit type
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

                if (this.openApiResult.Results.TryGetValue(header.Key, out object value))
                {
                    string convertedValue = null;

                    if (value is Func<string> valueAsFuncOfString)
                    {
                        convertedValue = this.ConvertValue(header.Value.Schema, valueAsFuncOfString());
                    }
                    else
                    {
                        convertedValue = this.ConvertValue(header.Value.Schema, value);
                    }

                    httpResponse.Headers.Add(header.Key, new Microsoft.Extensions.Primitives.StringValues(convertedValue));

                    if (this.logger.IsEnabled(LogLevel.Debug))
                    {
                        this.logger.LogDebug("Added header for response [{response}]", response.Description);
                    }
                }
            }
        }
    }
}
