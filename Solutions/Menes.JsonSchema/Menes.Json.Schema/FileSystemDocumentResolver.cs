// <copyright file="FileSystemDocumentResolver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Resolves a <see cref="JsonDocument"/> from the local filesystem.
    /// </summary>
    public class FileSystemDocumentResolver : IDocumentResolver
    {
        private readonly string baseDirectory;
        private readonly ILogger<FileSystemDocumentResolver>? logger;
        private readonly ConcurrentDictionary<string, JsonDocument> documents = new ConcurrentDictionary<string, JsonDocument>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemDocumentResolver"/> class.
        /// </summary>
        /// <param name="baseDirectory">The base directory for the file system resolver.</param>
        /// <param name="logger">The logger for the resolver.</param>
        public FileSystemDocumentResolver(string baseDirectory, ILogger<FileSystemDocumentResolver>? logger = null)
        {
            if (string.IsNullOrEmpty(baseDirectory))
            {
                throw new ArgumentException($"'{nameof(baseDirectory)}' cannot be null or empty", nameof(baseDirectory));
            }

            this.baseDirectory = baseDirectory;
            this.logger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemDocumentResolver"/> class.
        /// </summary>
        /// <param name="logger">The logger for the resolver.</param>
        /// <remarks>The default base directory is <see cref="Environment.CurrentDirectory"/>.</remarks>
        public FileSystemDocumentResolver(ILogger<FileSystemDocumentResolver>? logger = null)
        {
            this.baseDirectory = Environment.CurrentDirectory;
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
            string path = Path.Combine(this.baseDirectory, new string(reference.Uri));

            if (this.documents.TryGetValue(path, out JsonDocument result))
            {
                return result;
            }

            try
            {
                using Stream stream = File.OpenRead(path);
                result = await JsonDocument.ParseAsync(stream).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                this.logger?.LogInformation(ex, "Unable to resolve the JsonDocument at {path}", path);
                return default;
            }
        }
    }
}
