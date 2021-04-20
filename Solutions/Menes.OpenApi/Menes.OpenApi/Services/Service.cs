// <copyright file="Service.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApi.Services
{
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Helper functions for Menes Open API service implementations.
    /// </summary>
    public static class Service
    {
        /// <summary>
        /// The key for the request body parameter.
        /// </summary>
        private const string RequestBodyParameter = "Menes__RequestBodyParameter";

        /// <summary>
        /// Gets the JsonDocument for the request body.
        /// </summary>
        /// <param name="context">The context from which to retrieve the request body.</param>
        /// <returns>The corresponding <see cref="JsonDocument"/>.</returns>
        /// <remarks>
        /// This will always return the same <see cref="JsonDocument"/> instance for a given request, and
        /// manages the lifetime of the document for you.
        /// </remarks>
        public static JsonDocument GetRequestBodyJsonDocument(HttpContext context)
        {
            if (!context.Items.TryGetValue(Service.RequestBodyParameter, out object requestBody))
            {
                requestBody = JsonDocument.Parse(context.Request.Body);
                context.Items.Add(RequestBodyParameter, requestBody);
            }

            return (JsonDocument)requestBody;
        }

        /// <summary>
        /// Determines if the request content type matches the given media type regular expression.
        /// </summary>
        /// <param name="context">The current <see cref="HttpContext"/> for the request.</param>
        /// <param name="mediaType">The regular expression matching the media type.</param>
        /// <returns>True if the <see cref="HttpRequest.ContentType"/> matches the media type.</returns>
        public static bool MatchRequestContentType(HttpContext context, Regex mediaType)
        {
            return mediaType.IsMatch(context.Request.ContentType);
        }

        /// <summary>
        /// Complete processing of a request.
        /// </summary>
        /// <param name="context">The context in which to complete processing.</param>
        /// <returns>A <see cref="Task"/> which completes when processing is complete.</returns>
        internal static Task CompleteProcessing(HttpContext context)
        {
            if (context.Items.TryGetValue(Service.RequestBodyParameter, out object requestBody) && requestBody is JsonDocument rb)
            {
                rb.Dispose();
            }

            return Task.CompletedTask;
        }
    }
}
