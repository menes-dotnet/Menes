// <copyright file="HttpClientDocumentResolver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Resolves a <see cref="JsonDocument"/> from an HTTP endpoint.
    /// </summary>
    public class HttpClientDocumentResolver : IDocumentResolver
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<HttpClientDocumentResolver>? logger;
        private readonly ConcurrentDictionary<string, JsonDocument> documents = new ConcurrentDictionary<string, JsonDocument>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientDocumentResolver"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/> to use to resolve the uri.</param>
        /// <param name="logger">The logger for the resolver.</param>
        public HttpClientDocumentResolver(IHttpClientFactory httpClientFactory, ILogger<HttpClientDocumentResolver>? logger = null)
        {
            this.httpClient = httpClientFactory.CreateClient();
            this.logger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientDocumentResolver"/> class.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> to use to resolve the uri.</param>
        /// <param name="logger">The logger for the resolver.</param>
        public HttpClientDocumentResolver(HttpClient httpClient, ILogger<HttpClientDocumentResolver>? logger = null)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public bool AddDocument(string uri, JsonDocument document)
        {
            return this.documents.TryAdd(uri, document);
        }

        /// <inheritdoc/>
        public async Task<JsonDocument?> TryResolveDocument(JsonRef reference)
        {
            string uri = new string(reference.Uri);
            if (this.documents.TryGetValue(uri, out JsonDocument result))
            {
                return result;
            }

            try
            {
                using Stream stream = await this.httpClient.GetStreamAsync(uri).ConfigureAwait(false);
                result = await JsonDocument.ParseAsync(stream).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                this.logger?.LogInformation(ex, "Unable to resolve the JsonDocument at {uri}", uri);
                return default;
            }
        }

        /// <inheritdoc/>
        public void Reset()
        {
            foreach (System.Collections.Generic.KeyValuePair<string, JsonDocument> document in this.documents)
            {
                document.Value.Dispose();
            }

            this.documents.Clear();
        }
    }
}
