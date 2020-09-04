// <copyright file="HttpRequestParameterBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Menes.Converters;
    using Menes.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// An implementation of an <see cref="IOpenApiParameterBuilder{TRequest}"/>.
    /// </summary>
    public class HttpRequestParameterBuilder : IOpenApiParameterBuilder<HttpRequest>
    {
        private readonly IEnumerable<IOpenApiConverter> converters;
        private readonly ILogger<HttpRequestParameterBuilder> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestParameterBuilder"/> class.
        /// </summary>
        /// <param name="converters">The registered <see cref="IOpenApiConverter"/>s.</param>
        /// <param name="logger">The logger <see cref="ILogger"/>.</param>
        public HttpRequestParameterBuilder(IEnumerable<IOpenApiConverter> converters, ILogger<HttpRequestParameterBuilder> logger)
        {
            this.converters = converters;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IDictionary<string, object>> BuildParametersAsync(HttpRequest request, OpenApiOperationPathTemplate operationPathTemplate)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug("Building parameters for request path [{path}] and method [{method}]", request.Path, request.Method);
            }

            var parameters = new Dictionary<string, object>();

            IList<OpenApiParameter> openApiParameters = operationPathTemplate.BuildOpenApiParameters();
            IDictionary<string, object> templateParameterValues = operationPathTemplate.BuildTemplateParameterValues(new Uri(request.Path.Value, UriKind.Relative));

            foreach (OpenApiParameter parameter in openApiParameters)
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug("Building parameters for parameter [{parameter}]", parameter.Name);
                }

                switch (parameter.In)
                {
                    case ParameterLocation.Cookie:
                        if (this.TryGetParameterFromCookie(request.Cookies, parameter, out object? cookieResult))
                        {
                            if (this.logger.IsEnabled(LogLevel.Debug))
                            {
                                this.logger.LogDebug(
                                    "Added parameter from cookie for parameter [{parameter}]",
                                    parameter.Name);
                            }

                            parameters.Add(parameter.Name, cookieResult);
                        }
                        else if (parameter.Required)
                        {
                            this.logger.LogError(
                                "Failed to get the required cookie parameters from the cookie for the parameter [{parameter}]",
                                parameter.Name);
                            throw new OpenApiBadRequestException(
                                "Missing cookie",
                                $"Failed to get the required cookie for the parameter {parameter.Name}");
                        }

                        break;
                    case ParameterLocation.Header:
                        if (this.TryGetParameterFromHeader(request.Headers, parameter, out object? headerResult))
                        {
                            if (this.logger.IsEnabled(LogLevel.Debug))
                            {
                                this.logger.LogDebug(
                                    "Added parameter from headers for parameter [{parameter}]",
                                    parameter.Name);
                            }

                            parameters.Add(parameter.Name, headerResult);
                        }
                        else if (parameter.Required)
                        {
                            this.logger.LogError(
                                "Failed to get the required header parameters from the header for the parameter [{parameter}]",
                                parameter.Name);
                            throw new OpenApiBadRequestException(
                                "Missing header",
                                $"Failed to get the required header for the parameter {parameter.Name}");
                        }

                        break;
                    case ParameterLocation.Path:
                        if (this.TryGetParameterFromPath(templateParameterValues, parameter, out object? pathResult))
                        {
                            if (this.logger.IsEnabled(LogLevel.Debug))
                            {
                                this.logger.LogDebug(
                                    "Added parameter from path for parameter [{parameter}]",
                                    parameter.Name);
                            }

                            parameters.Add(parameter.Name, pathResult);
                        }
                        else if (parameter.Required)
                        {
                            this.logger.LogError(
                                "Failed to get the required path parameters from the path for the parameter [{parameter}]",
                                parameter.Name);
                            throw new OpenApiBadRequestException(
                                "Missing path parameter",
                                $"Failed to get the required path element for the parameter {parameter.Name}");
                        }

                        break;
                    case ParameterLocation.Query:
                        if (this.TryGetParameterFromQuery(request.Query, parameter, out object? queryResult))
                        {
                            if (this.logger.IsEnabled(LogLevel.Debug))
                            {
                                this.logger.LogDebug(
                                    "Added parameter from query for parameter [{parameter}]",
                                    parameter.Name);
                            }

                            parameters.Add(parameter.Name, queryResult);
                        }
                        else if (parameter.Required)
                        {
                            this.logger.LogError(
                                "Failed to get the required query parameters from the query for the parameter [{parameter}]",
                                parameter.Name);
                            throw new OpenApiBadRequestException(
                                "Missing query parameter",
                                $"Failed to get the required query string entry for the parameter {parameter.Name}");
                        }

                        break;
                    default:
                        this.logger.LogError(
                            "Failed to get the required parameters for the parameter [{parameter}], case not found",
                            parameter.Name);
                        throw new OpenApiBadRequestException(
                                "Missing parameter",
                                $"Failed to get the required parameter {parameter.Name}");
                }
            }

            await this.TryAddBody(request, operationPathTemplate, parameters).ConfigureAwait(false);
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Added parameters [{@parameters}] for request [{path}] [{method}]",
                    parameters.Keys,
                    request.Path,
                    request.Method);
            }

            return parameters;
        }

        private static object? TryGetDefaultValueFromSchema(OpenApiSchema schema, IOpenApiAny? defaultValue)
        {
            return defaultValue switch
            {
                //// Convert to DateTimeOffset rather than use the DateTime supplied by default to be consistent with our converters.
                OpenApiDate d       when schema.Format == "date"        => new DateTimeOffset(DateTime.SpecifyKind(d.Value, DateTimeKind.Utc)),
                //// Convert to string rather than use the DateTimeOffset supplied by default to be consistent with our current (lack of) support for strings with format "date-time".
                OpenApiDateTime dt  when schema.Format == "date-time"   => dt.Value.ToString("yyyy-MM-ddTHH:mm:ssK"),
                OpenApiPassword p   when schema.Format == "password"    => p.Value,
                OpenApiByte by      when schema.Format == "byte"        => by.Value,
                OpenApiString gu     when schema.Format == "uuid" || schema.Format == "guid" => new Guid(gu.Value),
                OpenApiString uri     when schema.Format == "uri"        => new Uri(uri.Value),
                OpenApiString s     when schema.Type == "string"        => s.Value,
                OpenApiBoolean b    when schema.Type == "boolean"       => b.Value,
                OpenApiLong l       when schema.Format == "int64"       => l.Value,
                OpenApiInteger i    when schema.Type == "integer"       => i.Value,
                OpenApiFloat f      when schema.Format == "float"       => f.Value,
                OpenApiDouble db    when schema.Format == "double"      => db.Value,
                OpenApiArray a      when schema.Type == "array"         => HandleArray(schema.Items, a),
                OpenApiObject o     when schema.Type == "object"        => HandleObject(schema.Properties, o),
                _ => throw new OpenApiSpecificationException("Default value for parameter not valid.")
            };

            static object HandleArray(OpenApiSchema schema, OpenApiArray array)
            {
                var values = new JArray();

                foreach (IOpenApiAny? item in array)
                {
                    object? obj = TryGetDefaultValueFromSchema(schema, item);

                    values.Add(obj);
                }

                return values;
            }

            static object HandleObject(IDictionary<string, OpenApiSchema> properties, OpenApiObject inputObj)
            {
                var values = new JObject();

                foreach (string key in inputObj.Keys)
                {
                    object? obj = TryGetDefaultValueFromSchema(properties[key], inputObj[key]);

                    values.Add(key, JToken.FromObject(obj));
                }

                return values;
            }
        }

        private async Task TryAddBody(HttpRequest request, OpenApiOperationPathTemplate operationPathTemplate, Dictionary<string, object> parameters)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Trying to add body for request [{path}] [{method}]",
                    request.Path,
                    request.Method);
            }

            // Map the body in to our list too
            if (operationPathTemplate.Operation.RequestBody == null)
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                        "Skipped adding body for request [{path}] [{method}], operation request body is null but not required",
                        request.Path,
                        request.Method);
                }

                // No request body, we're just fine
                return;
            }

            if (request.Body == null)
            {
                if (operationPathTemplate.Operation.RequestBody.Required)
                {
                    this.logger.LogError(
                        "Failed to add body for request [{path}] [{method}], request body is null but it is required",
                        request.Path,
                        request.Method);
                    throw new OpenApiBadRequestException("The request body is missing.");
                }
                else
                {
                    if (this.logger.IsEnabled(LogLevel.Debug))
                    {
                        this.logger.LogDebug(
                            "Skipped adding body for request [{path}] [{method}], request body is null but not required",
                            request.Path,
                            request.Method);
                    }

                    return;
                }
            }

            string? requestBaseContentType = this.GetBaseContentType(request.ContentType);

            if (string.IsNullOrEmpty(requestBaseContentType) || !operationPathTemplate.Operation.RequestBody.Content.TryGetValue(requestBaseContentType, out OpenApiMediaType openApiMediaType))
            {
                if (operationPathTemplate.Operation.RequestBody.Required)
                {
                    string message = $"The request body does not have a supported media type. It is '{request.ContentType}', but should be one of {string.Join(", ", operationPathTemplate.Operation.RequestBody.Content.Keys)}";
                    var exception = new OpenApiBadRequestException(message, message);
                    this.logger.LogError(
                        exception,
                        "Failed to add body for request [{path}] [{method}], [{exception}]",
                        request.Path,
                        request.Method,
                        exception.Message);
                    throw exception;
                }
                else
                {
                    if (this.logger.IsEnabled(LogLevel.Debug))
                    {
                        this.logger.LogDebug(
                            "Skipped adding body for request [{path}] [{method}], request body does not have a supported media type. It is '[{requestContentType}]', but should be one of [{requestBody}] and is not required",
                            request.Path,
                            request.Method,
                            request.ContentType,
                            string.Join(", ", operationPathTemplate?.Operation?.RequestBody?.Content?.Keys));
                    }

                    return;
                }
            }

            parameters.Add("body", await this.ConvertBodyAsync(openApiMediaType.Schema, request.Body).ConfigureAwait(false));
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Added body for request [{path}] [{method}]",
                    request.Path,
                    request.Method);
            }
        }

        private string? GetBaseContentType(string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                return null;
            }

            int separator = contentType.IndexOf(';');

            return separator != -1 ? contentType.Substring(0, separator) : contentType;
        }

        private bool TryGetParameterFromCookie(
            IRequestCookieCollection cookies,
            OpenApiParameter parameter,
            [NotNullWhen(true)] out object? result)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Trying to get parameter from cookies for parameter [{parameter}]",
                    parameter.Name);
            }

            if (cookies == null)
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                        "Failed to get parameter from cookies for parameter [{parameter}], cookies are null",
                        parameter.Name);
                }

                result = null;
                return false;
            }

            if (cookies.TryGetValue(parameter.Name, out string value))
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                        "Got parameter from cookies for parameter [{parameter}]",
                        parameter.Name);
                }

                result = this.ConvertValue(parameter.Schema, value);
                return true;
            }

            if (parameter.Schema.Default != null)
            {
                try
                {
                    result = TryGetDefaultValueFromSchema(parameter.Schema, parameter.Schema.Default);

                    if (result != null)
                    {
                        this.logger.LogDebug(
                            "Got default value for parameter [{parameter}] from the OpenAPI specification.",
                            parameter.Name);

                        return true;
                    }
                }
                catch (OpenApiSpecificationException ex)
                {
                    this.logger.LogError(
                        "Failed to parse default value for parameter [{parameter}] with [{schema}].",
                        parameter.Name,
                        parameter.Schema.GetLoggingInformation());

                    throw ex;
                }
            }

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Failed to get parameter from cookies for parameter [{parameter}]",
                    parameter.Name);
            }

            result = null;
            return false;
        }

        private async Task<object> ConvertBodyAsync(OpenApiSchema schema, Stream body)
        {
            string value;
            using (var reader = new StreamReader(body))
            {
                value = await reader.ReadToEndAsync().ConfigureAwait(false);
            }

            return this.ConvertValue(schema, value);
        }

        private bool TryGetParameterFromHeader(
            IHeaderDictionary headers,
            OpenApiParameter parameter,
            [NotNullWhen(true)] out object? result)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Trying to get parameter from headers for parameter [{parameter}]",
                    parameter.Name);
            }

            if (headers == null)
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                        "Failed to get parameter from headers for parameter [{parameter}], headers are null",
                        parameter.Name);
                }

                result = null;
                return false;
            }

            if (headers.TryGetValue(parameter.Name, out Microsoft.Extensions.Primitives.StringValues value))
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                        "Got parameter from headers for parameter [{parameter}]",
                        parameter.Name);
                }

                result = this.ConvertValue(parameter.Schema, value.ToString());
                return true;
            }

            if (parameter.Schema.Default != null)
            {
                try
                {
                    result = TryGetDefaultValueFromSchema(parameter.Schema, parameter.Schema.Default);

                    if (result != null)
                    {
                        this.logger.LogDebug(
                            "Got default value for parameter [{parameter}] from the OpenAPI specification.",
                            parameter.Name);

                        return true;
                    }
                }
                catch (OpenApiSpecificationException ex)
                {
                    this.logger.LogError(
                        "Failed to parse default value for parameter [{parameter}] with [{schema}].",
                        parameter.Name,
                        parameter.Schema.GetLoggingInformation());

                    throw ex;
                }
            }

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Failed to get parameter from headers for parameter [{parameter}], could not get the value of the headers",
                    parameter.Name);
            }

            result = null;
            return false;
        }

        private bool TryGetParameterFromPath(
            IDictionary<string, object> templateParameters,
            OpenApiParameter parameter,
            [NotNullWhen(true)] out object? result)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Trying to get parameter from path for parameter [{parameter}]",
                    parameter.Name);
            }

            if (templateParameters == null)
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                        "Failed to get parameter from path for parameter [{parameter}], path is null",
                        parameter.Name);
                }

                result = null;
                return false;
            }

            if (templateParameters.TryGetValue(parameter.Name, out object value))
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                        "Got parameter from path for parameter [{parameter}]",
                        parameter.Name);
                }

                result = this.ConvertValue(parameter.Schema, value.ToString());
                return true;
            }

            //// No default value handling since Path parameters aren't optional if they've been defined (and therefore default values are redundant).
            //// This is as per the the Open API spec, as seen here: https://github.com/OAI/OpenAPI-Specification/blob/master/versions/3.1.0.md#parameterObject.

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Failed to get parameter from path for parameter [{parameter}], could not get the value of the path",
                    parameter.Name);
            }

            result = null;
            return false;
        }

        private bool TryGetParameterFromQuery(
            IQueryCollection query,
            OpenApiParameter parameter,
            [NotNullWhen(true)] out object? result)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Trying to get parameter from query for parameter [{parameter}]",
                    parameter.Name);
            }

            if (query == null)
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                        "Failed to get parameter from query for parameter [{parameter}], query is null",
                        parameter.Name);
                }

                result = null;
                return false;
            }

            if (query.TryGetValue(parameter.Name, out Microsoft.Extensions.Primitives.StringValues value))
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                        "Got parameter from query for parameter [{parameter}]",
                        parameter.Name);
                }

                result = this.ConvertValue(parameter.Schema, value.FirstOrDefault());
                return true;
            }

            if (parameter.Schema.Default != null)
            {
                try
                {
                    result = TryGetDefaultValueFromSchema(parameter.Schema, parameter.Schema.Default);

                    if (parameter.Schema.Type == "array" || parameter.Schema.Type == "object")
                    {
                        result = JsonConvert.SerializeObject(result);
                    }

                    if (result != null)
                    {
                        this.logger.LogDebug(
                        "Got default value for parameter [{parameter}] from the OpenAPI specification.",
                        parameter.Name);

                        return true;
                    }
                }
                catch (OpenApiSpecificationException ex)
                {
                    this.logger.LogError(
                        "Failed to parse default value for parameter [{parameter}] with [{schema}].",
                        parameter.Name,
                        parameter.Schema.GetLoggingInformation());

                    throw ex;
                }
            }

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Failed to get parameter from query for parameter [{parameter}], could not get the value of the query",
                    parameter.Name);
            }

            result = null;
            return false;
        }

        private object ConvertValue(OpenApiSchema schema, string value)
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

                    return converter.ConvertFrom(value, schema);
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
                            "Matched converter [{converter}] to the [{schema}] for value, ignoring format",
                            converter.GetType(),
                            schema.GetLoggingInformation());
                    }

                    return converter.ConvertFrom(value, schema);
                }
            }

            this.logger.LogError(
                "Failed to convert value with [{schema}]",
                schema.GetLoggingInformation());

            throw new OpenApiServiceMismatchException($"Unable to convert value to match [{schema.GetLoggingInformation()}]");
        }
    }
}
