// <copyright file="HttpContextExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Immutable;
using System.Text.Json;
using System.Text.RegularExpressions;
using Corvus.Json;
using Corvus.Json.UriTemplates;
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
    private const string PathParameters = "Menes__PathParameters";

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
    /// <param name="context">The HTTP context from which to get the path parameters.</param>
    /// <param name="template">The URI template to match.</param>
    /// <returns>The parameters extracted from the path.</returns>
    public static ImmutableDictionary<string, JsonAny> GetPathParameters(this HttpContext context, UriTemplate template)
    {
        ImmutableDictionary<string, JsonAny> result;

        if (context.Items.TryGetValue(PathParameters, out object? pathParameters))
        {
            result = (ImmutableDictionary<string, JsonAny>)pathParameters!;
        }
        else
        {
            if (template.TryGetParameters(new Uri(Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(context.Request), UriKind.Absolute), out ImmutableDictionary<string, JsonAny>? pp))
            {
                context.Items.Add(PathParameters, pp);
                result = pp;
            }
            else
            {
                throw new InvalidOperationException("Unable to decode the path parameters for the matched URI template.");
            }
        }

        return result;
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
}