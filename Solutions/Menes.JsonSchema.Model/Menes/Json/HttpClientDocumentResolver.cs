// <copyright file="HttpClientDocumentResolver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Resolves a <see cref="JsonDocument"/> from an HTTP endpoint.
    /// </summary>
    public class HttpClientDocumentResolver : IDocumentResolver
    {
        private readonly HttpClient httpClient;
        private readonly Dictionary<string, JsonDocument> documents = new Dictionary<string, JsonDocument>();
        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientDocumentResolver"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/> to use to resolve the uri.</param>
        public HttpClientDocumentResolver(IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientDocumentResolver"/> class.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> to use to resolve the uri.</param>
        public HttpClientDocumentResolver(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <inheritdoc/>
        public bool AddDocument(string uri, JsonDocument document)
        {
            this.CheckDisposed();

            return this.documents.TryAdd(uri, document);
        }

        /// <inheritdoc/>
        public async Task<JsonElement?> TryResolve(JsonReference reference)
        {
            this.CheckDisposed();

            string uri = new string(reference.Uri);
            if (this.documents.TryGetValue(uri, out JsonDocument? result))
            {
                return JsonFragment.ResolveFragment(result, reference.Fragment);
            }

            try
            {
                using Stream stream = await this.httpClient.GetStreamAsync(uri).ConfigureAwait(false);
                result = await JsonDocument.ParseAsync(stream).ConfigureAwait(false);
                if (JsonFragment.TryResolveFragment(result, reference.Fragment, out JsonElement? element))
                {
                    return element;
                }

                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <inheritdoc/>
        public void Reset()
        {
            this.CheckDisposed();

            this.DisposeDocumentsAndClear();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Implements the dispose pattern.
        /// </summary>
        /// <param name="disposing">True if we are disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.DisposeDocumentsAndClear();
                }

                this.disposedValue = true;
            }
        }

        private void DisposeDocumentsAndClear()
        {
            foreach (KeyValuePair<string, JsonDocument> document in this.documents)
            {
                document.Value.Dispose();
            }

            this.documents.Clear();
        }

        private void CheckDisposed()
        {
            if (this.disposedValue)
            {
                throw new ObjectDisposedException(nameof(CompoundDocumentResolver));
            }
        }
    }
}
