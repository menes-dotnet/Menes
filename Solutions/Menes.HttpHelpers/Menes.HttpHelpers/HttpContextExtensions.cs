// <copyright file="HttpContextExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using Corvus.Json;
using Corvus.UriTemplates;
using Microsoft.AspNetCore.Http;

namespace Menes.HttpHelpers;

/// <summary>
/// Helper functions for Menes Open API service implementations.
/// </summary>
public static class HttpContextExtensions
{
    /// <summary>
    /// The key for the request body parameter.
    /// </summary>
    private const string RequestBodyParameter = "Menes__RequestBodyParameter";

    /// <summary>
    /// The key for the strongly typed path parameters.
    /// </summary>
    private const string PathParameters = "Menes__PathParameters";

    /// <summary>
    /// The key for the raw path parameters.
    /// </summary>
    private const string PathParametersStringCache = "Menes__PathParametersStringCache";

    /// <summary>
    /// Gets the JsonDocument for the request body.
    /// </summary>
    /// <param name="context">The context from which to retrieve the request body.</param>
    /// <returns>The corresponding <see cref="JsonDocument"/>.</returns>
    /// <remarks>
    /// This will always return the same <see cref="JsonDocument"/> instance for a given request, and
    /// manages the lifetime of the document for you.
    /// </remarks>
    public static JsonDocument GetRequestBodyJsonDocument(this HttpContext context)
    {
        JsonDocument document;
        if (context.Items.TryGetValue(RequestBodyParameter, out object? requestBody))
        {
            document = (JsonDocument)requestBody!;
        }
        else
        {
            document = JsonDocument.Parse(context.Request.Body);
            requestBody = document;
            context.Items.Add(RequestBodyParameter, requestBody);
            context.Response.RegisterForDispose(document);
        }

        return document;
    }

    /// <summary>
    /// Gets the path parameters from the request context.
    /// </summary>
    /// <typeparam name="T">The type of the resulting value.</typeparam>
    /// <param name="context">The HTTP context from which to get the path parameters.</param>
    /// <param name="template">The URI template parser to match.</param>
    /// <param name="parameterName">The name of the parameter to get.</param>
    /// <returns>The parameters extracted from the path.</returns>
    /// <remarks>
    /// The path parameters are cached in request local storage. This method is used by Menes
    /// code generation to prepare parameters for the request object.
    /// </remarks>
    public static T GetPathParameter<T>(this HttpContext context, IUriTemplateParser template, string parameterName)
        where T : struct, IJsonValue<T>
    {
        Dictionary<string, JsonAny> existingParameters;

        if (context.Items.TryGetValue(PathParameters, out object? pathParameters))
        {
            existingParameters = (Dictionary<string, JsonAny>)pathParameters!;
        }
        else
        {
            existingParameters = new();
            context.Items.Add(PathParameters, existingParameters);
        }

        if (existingParameters.TryGetValue(parameterName, out JsonAny value))
        {
            return value.As<T>();
        }

        PathParameterCache pathParameterCache = EnsurePathParameterCache(context, template);
        T result = T.Undefined;
        if (!pathParameterCache.TryProcessParameter(parameterName, HandlePathParameter, ref result))
        {
            // Maybe log the missing parameter?
        }

        // Cache the parameter (including the Undefined case)
        existingParameters.Add(parameterName, result.AsAny);
        return result;

        static void HandlePathParameter(ReadOnlySpan<char> name, ReadOnlySpan<char> value, ref T state)
        {
            state = Parsing.ParseSimpleStyleValue<T>(value);
        }
    }

    /// <summary>
    /// Determines if the request content type matches the given media type regular expression.
    /// </summary>
    /// <param name="context">The current <see cref="HttpContext"/> for the request.</param>
    /// <param name="mediaType">The regular expression matching the media type.</param>
    /// <returns>True if the <see cref="HttpRequest.ContentType"/> matches the media type.</returns>
    public static bool MatchRequestContentType(this HttpContext context, Regex mediaType)
    {
        string? contentType = context.Request.ContentType;
        return (contentType is string ct) && mediaType.IsMatch(ct);
    }

    private static PathParameterCache EnsurePathParameterCache(HttpContext context, IUriTemplateParser templateParser)
    {
        if (context.Items.TryGetValue(PathParametersStringCache, out object? cache))
        {
            Debug.Assert(cache != null, "The value set for PathParametersStringCache cannot be null.");
            return (PathParameterCache)cache;
        }

        // Build the parameter cache and stash in the context
        var newCache = PathParameterCache.BuildCache(templateParser, context.Request.PathBase.HasValue ? context.Request.PathBase + context.Request.Path : context.Request.Path);
        context.Items.Add(PathParametersStringCache, newCache);

        // Then register our cached parameters for disposal once we're done with the response.
        context.Response.RegisterForDispose(newCache);

        return newCache;
    }
}