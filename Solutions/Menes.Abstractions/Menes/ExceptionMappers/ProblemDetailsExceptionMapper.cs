// <copyright file="ProblemDetailsExceptionMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ExceptionMappers
{
    using System;
    using System.Collections.Generic;
    using Menes.Internal;
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// An exception mapper for the standard ProblemDetails RFC7807.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This maps from an exception to the standard ProblemDetails json response as
    /// defined in https://datatracker.ietf.org/doc/rfc7807/?include_text=1.
    /// </para>
    /// <para>
    /// It requires the response media type for the error status code in your Open API definition to be "application/problem+json".
    /// </para>
    /// <para>
    /// The exception is expected to carry the values of the extension properties defined by the schema
    /// in its <see cref="Exception.Data"/> dictionary. They will be serialized to the output JSON using the
    /// standard JSON.NET serializers (as this is always a JSON payload).
    /// </para>
    /// <para>
    /// If any required properties are missing from the dictionary, then an <see cref="InvalidOperationException"/> will be thrown, which will result in a 500
    /// error from the Open API pipeline.
    /// </para>
    /// <para>
    /// If you provide a "status" property in the exception data, it will be ignored and the required status code for the response will be used.
    /// </para>
    /// <para>
    /// If you provide a "details" property in the exception data, then it will be used. Otherwise, it will fall back on the <see cref="Exception.Message"/>.
    /// </para>
    /// </remarks>
    public class ProblemDetailsExceptionMapper : IExceptionMapper
    {
        private const string ProblemDetailContentType = "application/problem+json";

        /// <summary>
        /// Unfortunately, AutoRest chokes on application/problem+json, so we also need to support application/json.
        /// </summary>
        private const string ProblemDetailAlternateContentType = "application/json";

        /// <inheritdoc/>
        public int Priority => 10000;

        /// <inheritdoc/>
        public bool CanMapException(OpenApiResponses responses, Exception ex, int? statusCode)
        {
            if (responses.TryGetResponseForStatusCode(statusCode, out OpenApiResponse? response))
            {
                return response.Content.ContainsKey(ProblemDetailContentType)
                    || response.Content.ContainsKey(ProblemDetailAlternateContentType);
            }

            return false;
        }

        /// <inheritdoc/>
        public OpenApiResult MapException(OpenApiResponses responses, Exception ex, int? statusCode)
        {
            responses.TryGetResponseForStatusCode(statusCode, out OpenApiResponse? openApiResponse);

            var response = new JObject();
            bool useAlternateType = false;
            if (!openApiResponse!.Content.TryGetValue(ProblemDetailContentType, out OpenApiMediaType? responseMediaType))
            {
                responseMediaType = openApiResponse.Content[ProblemDetailAlternateContentType];
                useAlternateType = true;
            }

            var result = new OpenApiResult
            {
                StatusCode = statusCode ?? 500,
                Results = { { useAlternateType ? ProblemDetailAlternateContentType : ProblemDetailContentType, response } },
            };

            foreach (KeyValuePair<string, OpenApiSchema> property in responseMediaType.Schema.Properties)
            {
                switch (property.Key)
                {
                    // Use the status code for the status property
                    case "status":
                        response["status"] = result.StatusCode;
                        break;

                    // We fall through to the detail exception data if it is present, otherwise we default to the exception message
                    case "detail" when !ex.Data.Contains(property.Key):
                        response["detail"] = ex.Message;
                        break;

                    default:
                        if (!ex.Data.Contains(property.Key))
                        {
                            if (responseMediaType.Schema.Required.Contains(property.Key))
                            {
                                // This was a required property and the key was not present, so blow up
                                throw new InvalidOperationException();
                            }
                        }
                        else
                        {
                            response[property.Key] = JToken.FromObject(ex.Data[property.Key]!);
                        }

                        break;
                }
            }

            return result;
        }
    }
}