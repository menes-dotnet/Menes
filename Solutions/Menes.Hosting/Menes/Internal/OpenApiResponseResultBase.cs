// <copyright file="OpenApiResponseResultBase.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using Menes.Converters;
using Menes.Exceptions;

using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

/// <summary>
/// Base class of types taht wraps an <see cref="Menes.OpenApiResult"/> instance with the ability to
/// apply some type of response.
/// </summary>
/// <typeparam name="TArg">The type of input supplied to this builder.</typeparam>
/// <typeparam name="TResponse">The type of response to be built or populated.</typeparam>
/// <remarks>
/// <para>
/// Given an <see cref="Menes.OpenApiResult"/> and an <see cref="OpenApiOperation"/>, this validates
/// that the result conforms to the requirements of the operation, and then writes the result to the
/// appropriate parts of the response (e.g. headers, response body).
/// </para>
/// <para>
/// CAVEAT: It does not currently support writing cookies.
/// </para>
/// </remarks>
internal abstract class OpenApiResponseResultBase<TArg, TResponse>
{
    /// <summary>
    /// Initializes an <see cref="OpenApiResponseResultBase{TRequest, TResponse}"/>.
    /// </summary>
    /// <param name="openApiResult">
    /// The result of the operation.
    /// </param>
    /// <param name="operation">
    /// The OpenAPI operation that was invoked to produce this result.
    /// </param>
    /// <param name="converters">The OpenAPI converters to use.</param>
    /// <param name="logger">A logger for the operation.</param>
    internal OpenApiResponseResultBase(
        OpenApiResult openApiResult,
        OpenApiOperation operation,
        IEnumerable<IOpenApiConverter> converters,
        ILogger logger)
    {
        this.OpenApiResult = openApiResult;
        this.Operation = operation;
        this.Converters = converters;
        this.Logger = logger;
    }

    /// <summary>
    /// Gets the <see cref="Menes.OpenApiResult"/> being wrapped.
    /// </summary>
    protected OpenApiResult OpenApiResult { get; }

    /// <summary>
    /// Gets the OpenAPI operation that was invoked to produce this result.
    /// </summary>
    protected OpenApiOperation Operation { get; }

    /// <summary>
    /// Gets the OpenAPI converters to use.
    /// </summary>
    protected IEnumerable<IOpenApiConverter> Converters { get; }

    /// <summary>
    /// Gets the diagnostic logger.
    /// </summary>
    protected ILogger Logger { get; }

    /// <summary>
    /// Use the actions described in the <see cref="OpenApiResult"/> to populate or create a
    /// <typeparamref name="TResponse"/>.
    /// </summary>
    /// <param name="argument">The input supplied to this builder.</param>
    /// <returns>A task that completes when the work is finished.</returns>
    protected async ValueTask<TResponse> ExecuteResultCoreAsync(TArg argument)
    {
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug("Executing [{actionResult}]", this.OpenApiResult.GetLoggingInformation());
        }

        try
        {
            this.Operation.Responses.TryGetResponseForStatusCode(this.OpenApiResult.StatusCode, out OpenApiResponse? response);

            TResponse httpResponse = this.InitializeResponseWithStatusCode(argument, (HttpStatusCode)this.OpenApiResult.StatusCode);

            this.BuildHeaders(httpResponse, response!);

            await this.WriteBodyAsync(httpResponse, response!);
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug("Executed [{actionResult}]", this.OpenApiResult.GetLoggingInformation());
            }

            return httpResponse;
        }
        catch (Exception ex)
        {
            this.Logger.LogError("Failed to execute OpenApiActionResult [{actionResult}], [{exMessage}]", this.OpenApiResult.GetLoggingInformation(), ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Creates or initializes the response.
    /// </summary>
    /// <param name="arg">The argument that was passed into the builder.</param>
    /// <param name="statusCode">The status code to set.</param>
    /// <returns>The initialized response.</returns>
    protected abstract TResponse InitializeResponseWithStatusCode(TArg arg, HttpStatusCode statusCode);

    /// <summary>
    /// Add a header to the response.
    /// </summary>
    /// <param name="response">The response to which to add the header.</param>
    /// <param name="key">The header name.</param>
    /// <param name="value">The header value.</param>
    protected abstract void AddHeader(TResponse response, string key, string value);

    /// <summary>
    /// Sets the content type of the response.
    /// </summary>
    /// <param name="response">The response on which to set the content type.</param>
    /// <param name="contentType">The content type.</param>
    protected abstract void SetResponseContentType(TResponse response, string contentType);

    /// <summary>
    /// Sets the body of the response as a stream.
    /// </summary>
    /// <param name="response">The response on which to set the body.</param>
    /// <param name="bodyStream">The response body.</param>
    /// <returns>A task that completes when the body has been written.</returns>
    protected abstract Task SetResponseBodyAsStream(TResponse response, Stream bodyStream);

    /// <summary>
    /// Sets the body of the response as a string.
    /// </summary>
    /// <param name="response">The response on which to set the body.</param>
    /// <param name="body">The response body.</param>
    /// <returns>A task that completes when the body has been written.</returns>
    protected abstract Task SetResponseBodyAsString(TResponse response, string body);

    private void BuildHeaders(TResponse httpResponse, OpenApiResponse response)
    {
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug("Building headers for response [{response}]", response.Description);
        }

        foreach (KeyValuePair<string, OpenApiHeader> header in response.Headers)
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                this.Logger.LogDebug("Attempting to add header for response [{response}]", response.Description);
            }

            if (this.OpenApiResult.Results.TryGetValue(header.Key, out object? value))
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

                if (header.Value.Schema.Type == "string")
                {
                    // When IOpenApiConverters produce a JSON string, there are two issues:
                    //  1.  The value is surrounded by double quotes, because those are necessary for
                    //          the result to be valid JSON.
                    //  2.  Some characters might be escaped, either because they have to be (e.g.,
                    //          because the string itself contains double quotes), or just because
                    //          they are allowed to be (JSON receivers are required to treat quoted
                    //          characters identically to unquoted ones in cases where either would
                    //          be valid; System.Text.Json sometimes takes advantage of this to
                    //          escape characters in a way that can mitigate certain security holes).
                    // But when we put string values in headers, we do not want them in JSON format.
                    // We want them as plain strings.
                    convertedValue = JsonNode.Parse(convertedValue)?.GetValue<string>();
                }

                this.AddHeader(httpResponse, header.Key, convertedValue!);

                if (this.Logger.IsEnabled(LogLevel.Debug))
                {
                    this.Logger.LogDebug("Added header for response [{response}]", response.Description);
                }
            }
        }
    }

    private Task WriteBodyAsync(TResponse outputResponse, OpenApiResponse openApiResponse)
    {
        if (openApiResponse.Content?.Count > 0)
        {
            // TODO: We should probably find the first one where we can also convert the value, rather than just the first one!
            KeyValuePair<string, OpenApiMediaType> responseContent = openApiResponse.Content.First(c => this.OpenApiResult.Results.ContainsKey(c.Key));
            object responseValue = this.OpenApiResult.Results[responseContent.Key];

            this.SetResponseContentType(outputResponse, responseContent.Key);

            if (responseValue is Stream responseAsStream)
            {
                return this.SetResponseBodyAsStream(outputResponse, responseAsStream);
            }
            else
            {
                string outputValue = this.ConvertValue(responseContent.Value.Schema, responseValue);
                return this.SetResponseBodyAsString(outputResponse, outputValue);
            }
        }

        return Task.CompletedTask;
    }

    private string ConvertValue(OpenApiSchema schema, object value)
    {
        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug("Converting value to match [{schema}]", schema.GetLoggingInformation());
        }

        foreach (IOpenApiConverter converter in this.Converters)
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

                return converter.ConvertTo(value, schema);
            }
        }

        if (this.Logger.IsEnabled(LogLevel.Debug))
        {
            this.Logger.LogDebug(
                            "Failed to convert value with [{schema}], falling back to just type",
                            schema.GetLoggingInformation());
        }

        // We didn't hit anything directly, so let's fall back to just the type alone
        foreach (IOpenApiConverter converter in this.Converters)
        {
            if (converter.CanConvert(schema, true))
            {
                if (this.Logger.IsEnabled(LogLevel.Debug))
                {
                    this.Logger.LogDebug(
                                            "Matched converter [{converter}] to the [{schema}], ignoring format",
                                            converter.GetType(),
                                            schema.GetLoggingInformation());
                }

                return converter.ConvertTo(value, schema);
            }
        }

        this.Logger.LogError(
            "Failed to convert value with [{schema}]",
            schema.GetLoggingInformation());

        throw new OpenApiServiceMismatchException($"Failed to convert value to match [{schema.GetLoggingInformation()}]");
    }
}