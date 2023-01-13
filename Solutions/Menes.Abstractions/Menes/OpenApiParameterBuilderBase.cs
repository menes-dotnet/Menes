// <copyright file="OpenApiParameterBuilderBase.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Menes.Converters;
using Menes.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

/// <summary>
/// Implementation of non-request-type-specific aspects of <see cref="IOpenApiParameterBuilder{TRequest}"/>.
/// </summary>
/// <typeparam name="TRequest">The request type.</typeparam>
public abstract class OpenApiParameterBuilderBase<TRequest> : IOpenApiParameterBuilder<TRequest>
{
    private readonly IEnumerable<IOpenApiConverter> converters;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenApiParameterBuilderBase{TRequest}"/> class.
    /// </summary>
    /// <param name="converters">The registered <see cref="IOpenApiConverter"/>s.</param>
    /// <param name="logger">The logger <see cref="ILogger"/>.</param>
    protected OpenApiParameterBuilderBase(
        IEnumerable<IOpenApiConverter> converters,
        ILogger<OpenApiParameterBuilderBase<TRequest>> logger)
    {
        this.converters = converters;
        this.Logger = logger;
    }

    /// <summary>
    /// Gets the logger for this builder.
    /// </summary>
    protected ILogger<OpenApiParameterBuilderBase<TRequest>> Logger { get; }

    /// <inheritdoc/>
    public async Task<IDictionary<string, object>> BuildParametersAsync(
        TRequest request,
        OpenApiOperationPathTemplate operationPathTemplate)
    {
        (string path, string method) = this.GetPathAndMethod(request);
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug("Building parameters for request path [{path}] and method [{method}]", path, method);
        }

        var parameters = new Dictionary<string, object>();

        IList<OpenApiParameter> openApiParameters = operationPathTemplate.BuildOpenApiParameters();
        IDictionary<string, object>? templateParameterValues = operationPathTemplate.BuildTemplateParameterValues(new Uri(path, UriKind.Relative));

        foreach (OpenApiParameter parameter in openApiParameters)
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug("Building parameters for parameter [{parameter}]", parameter.Name);
            }

            try
            {
                switch (parameter.In)
                {
                    case ParameterLocation.Cookie:
                        if (this.TryGetParameterFromCookie(request, parameter, out object? cookieResult))
                        {
                            if (this.Logger.IsEnabled(LogLevel.Debug))
                            {
                                this.Logger.LogDebug(
                                    "Added parameter from cookie for parameter [{parameter}]",
                                    parameter.Name);
                            }

                            parameters.Add(parameter.Name, cookieResult);
                        }
                        else if (parameter.Required)
                        {
                            this.Logger.LogError(
                                "Failed to get the required cookie parameters from the cookie for the parameter [{parameter}]",
                                parameter.Name);
                            throw new OpenApiBadRequestException(
                                "Missing cookie",
                                $"Failed to get the required cookie for the parameter {parameter.Name}");
                        }

                        break;
                    case ParameterLocation.Header:
                        if (this.TryGetParameterFromHeader(request, parameter, out object? headerResult))
                        {
                            if (this.Logger.IsEnabled(LogLevel.Debug))
                            {
                                this.Logger.LogDebug(
                                    "Added parameter from headers for parameter [{parameter}]",
                                    parameter.Name);
                            }

                            parameters.Add(parameter.Name, headerResult);
                        }
                        else if (parameter.Required)
                        {
                            this.Logger.LogError(
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
                            if (this.Logger.IsEnabled(LogLevel.Debug))
                            {
                                this.Logger.LogDebug(
                                    "Added parameter from path for parameter [{parameter}]",
                                    parameter.Name);
                            }

                            parameters.Add(parameter.Name, pathResult);
                        }
                        else if (parameter.Required)
                        {
                            this.Logger.LogError(
                                "Failed to get the required path parameters from the path for the parameter [{parameter}]",
                                parameter.Name);
                            throw new OpenApiBadRequestException(
                                "Missing path parameter",
                                $"Failed to get the required path element for the parameter {parameter.Name}");
                        }

                        break;
                    case ParameterLocation.Query:
                        if (this.TryGetParameterFromQuery(request, parameter, out object? queryResult))
                        {
                            if (this.Logger.IsEnabled(LogLevel.Debug))
                            {
                                this.Logger.LogDebug(
                                    "Added parameter from query for parameter [{parameter}]",
                                    parameter.Name);
                            }

                            parameters.Add(parameter.Name, queryResult);
                        }
                        else if (parameter.Required)
                        {
                            this.Logger.LogError(
                                "Failed to get the required query parameters from the query for the parameter [{parameter}]",
                                parameter.Name);
                            throw new OpenApiBadRequestException(
                                "Missing query parameter",
                                $"Failed to get the required query string entry for the parameter {parameter.Name}");
                        }

                        break;
                    default:
                        this.Logger.LogError(
                            "Failed to get the required parameters for the parameter [{parameter}], case not found",
                            parameter.Name);
                        throw new OpenApiBadRequestException(
                                "Missing parameter",
                                $"Failed to get the required parameter {parameter.Name}");
                }
            }
            catch (OpenApiInvalidFormatException x)
            {
                throw new OpenApiBadRequestException(x);
            }
            catch (FormatException)
            {
                throw new OpenApiBadRequestException($"Parameter {parameter} did not have the required format");
            }
        }

        await this.TryAddBody(request, path, method, operationPathTemplate, parameters).ConfigureAwait(false);
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Added parameters [{@parameters}] for request [{path}] [{method}]",
                parameters.Keys,
                path,
                method);
        }

        return parameters;
    }

    /// <summary>
    /// Gets the path and HTTP method from the request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The request path and method.</returns>
    protected abstract (string Path, string Method) GetPathAndMethod(TRequest request);

    /// <summary>
    /// Gets the path and HTTP method from the request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The request path and method.</returns>
    protected abstract (Stream? Body, string? ContentType) GetBodyAndContentType(TRequest request);

    /// <summary>
    /// Retrieve the value for a particular cookie, if it is present.
    /// </summary>
    /// <param name="request">The request from which to read the cookie.</param>
    /// <param name="key">The cookie name.</param>
    /// <param name="value">
    /// The cookie value, or null if there is no cookie with this name
    /// is present.
    /// </param>
    /// <returns>True if a cookie with this name was present.</returns>
    protected abstract bool TryGetCookieValue(TRequest request, string key, [NotNullWhen(true)] out string? value);

    /// <summary>
    /// Retrieve the value for a particular header, if it is present.
    /// </summary>
    /// <param name="request">The request from which to read the header.</param>
    /// <param name="key">The header name.</param>
    /// <param name="value">
    /// The header value if there is a single header with this name. A comma-separated list of
    /// values if there are multiple headers with this name. Null if no header with this name
    /// is present.
    /// </param>
    /// <returns>True if at least one header with this name was present.</returns>
    protected abstract bool TryGetHeaderValue(TRequest request, string key, [NotNullWhen(true)] out string? value);

    /// <summary>
    /// Retrieve the value for a particular query string entry, if it is present.
    /// </summary>
    /// <param name="request">The request from which to read the query string.</param>
    /// <param name="key">The query string entry name.</param>
    /// <param name="value">
    /// The value of the first query string entry with this name, or null if no entries with
    /// this name are present.
    /// </param>
    /// <returns>True if at least one entry with this name was present.</returns>
    /// <remarks>
    /// This is inconsistent with the header handling: with headers, multiple entries with
    /// the same name result in a comma-separated list, whereas here we discard all but the
    /// first. That's because Menes has always worked that way (albeit probably by accident).
    /// </remarks>
    protected abstract bool TryGetQueryValue(TRequest request, string key, [NotNullWhen(true)] out string? value);

    private static string? GetBaseContentType(string contentType)
    {
        if (string.IsNullOrEmpty(contentType))
        {
            return null;
        }

        int separator = contentType.IndexOf(';');

        return separator != -1 ? contentType[..separator] : contentType;
    }

    private object? TryGetDefaultValueFromSchema(OpenApiSchema schema, IOpenApiAny? defaultValue)
    {
        try
        {
            return defaultValue switch
            {
                //// Convert to DateTimeOffset rather than use the DateTime supplied by default to be consistent with our converters.
                OpenApiDate d when schema.Format == "date" => new DateTimeOffset(DateTime.SpecifyKind(d.Value, DateTimeKind.Utc)),
                //// Convert to string rather than use the DateTimeOffset supplied by default to be consistent with our current (lack of) support for strings with format "date-time".
                OpenApiDateTime dt when schema.Format == "date-time" => dt.Value.ToString("yyyy-MM-ddTHH:mm:ssK"),
                OpenApiPassword p when schema.Format == "password" => p.Value,
                OpenApiByte by when schema.Format == "byte" => by.Value,
                OpenApiString s when schema.Type == "string" => this.ConvertValue(schema, s.Value),
                OpenApiBoolean b when schema.Type == "boolean" => b.Value,
                OpenApiLong l when schema.Format == "int64" => l.Value,
                OpenApiInteger i when schema.Type == "integer" => i.Value,
                OpenApiFloat f when schema.Format == "float" => f.Value,
                OpenApiDouble db when schema.Type == "number" => db.Value,
                OpenApiArray a when schema.Type == "array" => HandleArray(schema.Items, a),
                OpenApiObject o when schema.Type == "object" => HandleObject(schema.Properties, o),
                _ => throw new OpenApiSpecificationException("Default value for parameter not valid."),
            };
        }
        catch (OpenApiInvalidFormatException x)
        {
            throw new OpenApiSpecificationException($"Default value for parameter not valid ({x.Message}).");
        }
        catch (FormatException)
        {
            throw new OpenApiSpecificationException("Default value for parameter not valid.");
        }

        object HandleArray(OpenApiSchema schema, OpenApiArray array)
        {
            var values = new JsonArray();

            foreach (IOpenApiAny? item in array)
            {
                object? obj = this.TryGetDefaultValueFromSchema(schema, item);

                values.Add(obj);
            }

            return values;
        }

        object HandleObject(IDictionary<string, OpenApiSchema> properties, OpenApiObject inputObj)
        {
            var values = new JsonObject();

            foreach (string key in inputObj.Keys)
            {
                object? obj = this.TryGetDefaultValueFromSchema(properties[key], inputObj[key]);

                using var stream = new MemoryStream();
                using (Utf8JsonWriter w = new(stream))
                {
                    if (obj is null)
                    {
                        w.WriteNullValue();
                    }
                    else
                    {
                        JsonSerializer.Serialize(w, obj, obj.GetType());
                    }

                    w.Flush();
                }

                stream.Position = 0;
                values.Add(key, JsonObject.Parse(stream));
            }

            return values;
        }
    }

    private async Task TryAddBody(
        TRequest request,
        string path,
        string method,
        OpenApiOperationPathTemplate operationPathTemplate,
        Dictionary<string, object> parameters)
    {
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Trying to add body for request [{path}] [{method}]",
                path,
                method);
        }

        // Map the body in to our list too
        if (operationPathTemplate.Operation.RequestBody == null)
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug(
                    "Skipped adding body for request [{path}] [{method}], operation request body is null but not required",
                    path,
                    method);
            }

            // No request body, we're just fine
            return;
        }

        (Stream? body, string? contentType) = this.GetBodyAndContentType(request);

        if (body == null)
        {
            if (operationPathTemplate.Operation.RequestBody.Required)
            {
                this.Logger.LogError(
                    "Failed to add body for request [{path}] [{method}], request body is null but it is required",
                    path,
                    method);
                throw new OpenApiBadRequestException("The request body is missing.");
            }
            else
            {
                if (this.Logger.IsEnabled(LogLevel.Debug))
                {
                    this.Logger.LogDebug(
                        "Skipped adding body for request [{path}] [{method}], request body is null but not required",
                        path,
                        method);
                }

                return;
            }
        }

        string? requestBaseContentType = contentType is null
            ? null
            : GetBaseContentType(contentType);

        if (string.IsNullOrEmpty(requestBaseContentType) || !operationPathTemplate.Operation.RequestBody.Content.TryGetValue(requestBaseContentType, out OpenApiMediaType? openApiMediaType))
        {
            if (operationPathTemplate.Operation.RequestBody.Required)
            {
                string message = $"The request body does not have a supported media type. It is '{contentType}', but should be one of {string.Join(", ", operationPathTemplate.Operation.RequestBody.Content.Keys)}";
                var exception = new OpenApiBadRequestException(message, message);
                this.Logger.LogError(
                    exception,
                    "Failed to add body for request [{path}] [{method}], [{exception}]",
                    path,
                    method,
                    exception.Message);
                throw exception;
            }
            else
            {
                if (this.Logger.IsEnabled(LogLevel.Debug))
                {
                    this.Logger.LogDebug(
                        "Skipped adding body for request [{path}] [{method}], request body does not have a supported media type. It is '[{requestContentType}]', but should be one of [{requestBody}] and is not required",
                        path,
                        method,
                        contentType,
                        string.Join(", ", operationPathTemplate?.Operation?.RequestBody?.Content?.Keys ?? Array.Empty<string>()));
                }

                return;
            }
        }

        parameters.Add("body", await this.ConvertBodyAsync(openApiMediaType.Schema, body).ConfigureAwait(false));
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Added body for request [{path}] [{method}]",
                path,
                method);
        }
    }

    private bool TryGetParameterFromCookie(
        TRequest request,
        OpenApiParameter parameter,
        [NotNullWhen(true)] out object? result)
    {
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Trying to get parameter from cookies for parameter [{parameter}]",
                parameter.Name);
        }

        if (this.TryGetCookieValue(request, parameter.Name, out string? value))
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug(
                    "Got parameter from cookies for parameter [{parameter}]",
                    parameter.Name);
            }

            result = this.ConvertValue(parameter.Schema, value!);
            return true;
        }

        if (parameter.Schema.Default != null)
        {
            try
            {
                result = this.TryGetDefaultValueFromSchema(parameter.Schema, parameter.Schema.Default);

                if (result != null)
                {
                    this.Logger.LogDebug(
                        "Got default value for parameter [{parameter}] from the OpenAPI specification.",
                        parameter.Name);

                    return true;
                }
            }
            catch (OpenApiSpecificationException)
            {
                this.Logger.LogError(
                    "Failed to parse default value for parameter [{parameter}] with [{schema}].",
                    parameter.Name,
                    parameter.Schema.GetLoggingInformation());

                throw;
            }
        }

        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
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

        try
        {
            // The funky thing about IOpenApiConverter is that although in most cases
            // the string we pass for conversion is in its JSON format, strings are the
            // exception: those appear unquoted. That's because converters are also
            // passed values from headers, query strings, paths, and cookies, where
            // strings are not quoted.
            // Since we know we're receiving actual JSON, it's our job to detect when
            // it's a string, and if it is, strip off the quotes and process any escaped
            // characters inside.
            if (value.Length >= 2 && value[0] == '"' && value[^1] == '"')
            {
                value = JsonSerializer.Deserialize<string>(value)!;
            }

            return this.ConvertValue(schema, value);
        }
        catch (OpenApiInvalidFormatException x)
        {
            throw new OpenApiBadRequestException(x);
        }
        catch (FormatException)
        {
            throw new OpenApiBadRequestException("Request body did not have the required format");
        }
    }

    private bool TryGetParameterFromHeader(
        TRequest request,
        OpenApiParameter parameter,
        [NotNullWhen(true)] out object? result)
    {
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Trying to get parameter from headers for parameter [{parameter}]",
                parameter.Name);
        }

        if (this.TryGetHeaderValue(request, parameter.Name, out string? value))
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug(
                    "Got parameter from headers for parameter [{parameter}]",
                    parameter.Name);
            }

            result = this.ConvertValue(parameter.Schema, value);
            return true;
        }

        if (parameter.Schema.Default != null)
        {
            try
            {
                result = this.TryGetDefaultValueFromSchema(parameter.Schema, parameter.Schema.Default);

                if (result != null)
                {
                    this.Logger.LogDebug(
                        "Got default value for parameter [{parameter}] from the OpenAPI specification.",
                        parameter.Name);

                    return true;
                }
            }
            catch (OpenApiSpecificationException)
            {
                this.Logger.LogError(
                    "Failed to parse default value for parameter [{parameter}] with [{schema}].",
                    parameter.Name,
                    parameter.Schema.GetLoggingInformation());

                throw;
            }
        }

        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Failed to get parameter from headers for parameter [{parameter}], could not get the value of the headers",
                parameter.Name);
        }

        result = null;
        return false;
    }

    private bool TryGetParameterFromPath(
        IDictionary<string, object>? templateParameters,
        OpenApiParameter parameter,
        [NotNullWhen(true)] out object? result)
    {
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Trying to get parameter from path for parameter [{parameter}]",
                parameter.Name);
        }

        if (templateParameters == null)
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug(
                    "Failed to get parameter from path for parameter [{parameter}], path is null",
                    parameter.Name);
            }

            result = null;
            return false;
        }

        if (templateParameters.TryGetValue(parameter.Name, out object? value))
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug(
                    "Got parameter from path for parameter [{parameter}]",
                    parameter.Name);
            }

            result = this.ConvertValue(parameter.Schema, value.ToString()!);
            return true;
        }

        // No default value handling since Path parameters aren't optional if they've been defined (and therefore default values are redundant).
        // This is as per the the Open API spec, as seen here: https://github.com/OAI/OpenAPI-Specification/blob/master/versions/3.1.0.md#parameterObject.
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Failed to get parameter from path for parameter [{parameter}], could not get the value of the path",
                parameter.Name);
        }

        result = null;
        return false;
    }

    private bool TryGetParameterFromQuery(
        TRequest request,
        OpenApiParameter parameter,
        [NotNullWhen(true)] out object? result)
    {
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Trying to get parameter from query for parameter [{parameter}]",
                parameter.Name);
        }

        if (this.TryGetQueryValue(request, parameter.Name, out string? value))
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug(
                    "Got parameter from query for parameter [{parameter}]",
                    parameter.Name);
            }

            result = this.ConvertValue(parameter.Schema, value);
            return true;
        }

        if (parameter.Schema.Default != null)
        {
            try
            {
                result = this.TryGetDefaultValueFromSchema(parameter.Schema, parameter.Schema.Default);

                if (parameter.Schema.Type == "array" || parameter.Schema.Type == "object")
                {
                    result = JsonSerializer.Serialize(result);
                }

                if (result != null)
                {
                    this.Logger.LogDebug(
                    "Got default value for parameter [{parameter}] from the OpenAPI specification.",
                    parameter.Name);

                    return true;
                }
            }
            catch (OpenApiSpecificationException)
            {
                this.Logger.LogError(
                    "Failed to parse default value for parameter [{parameter}] with [{schema}].",
                    parameter.Name,
                    parameter.Schema.GetLoggingInformation());

                throw;
            }
        }

        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Failed to get parameter from query for parameter [{parameter}], could not get the value of the query",
                parameter.Name);
        }

        result = null;
        return false;
    }

    private object ConvertValue(OpenApiSchema schema, string value)
    {
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug("Converting value to match [{schema}]", schema.GetLoggingInformation());
        }

        foreach (IOpenApiConverter converter in this.converters)
        {
            if (converter.CanConvert(schema))
            {
                if (this.Logger.IsEnabled(LogLevel.Debug))
                {
                    this.Logger.LogDebug(
                        "Matched converter [{converter}] to the [{schema}]",
                        converter.GetType(),
                        schema.GetLoggingInformation());
                }

                return converter.ConvertFrom(value, schema);
            }
        }

        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                "Failed to convert value with [{schema}], falling back to just type",
                schema.GetLoggingInformation());
        }

        // We didn't hit anything directly, so let's fall back to just the type alone
        foreach (IOpenApiConverter converter in this.converters)
        {
            if (converter.CanConvert(schema, true))
            {
                if (this.Logger.IsEnabled(LogLevel.Debug))
                {
                    this.Logger.LogDebug(
                        "Matched converter [{converter}] to the [{schema}] for value, ignoring format",
                        converter.GetType(),
                        schema.GetLoggingInformation());
                }

                return converter.ConvertFrom(value, schema);
            }
        }

        this.Logger.LogError(
            "Failed to convert value with [{schema}]",
            schema.GetLoggingInformation());

        throw new OpenApiServiceMismatchException($"Unable to convert value to match [{schema.GetLoggingInformation()}]");
    }
}