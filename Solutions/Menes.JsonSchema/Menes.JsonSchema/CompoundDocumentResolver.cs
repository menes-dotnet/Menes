// <copyright file="CompoundDocumentResolver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System.Collections.Concurrent;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Delegates <see cref="JsonDocument"/> resolution to one of a set of <see cref="IDocumentResolver"/> instances.
    /// </summary>
    public class CompoundDocumentResolver : IDocumentResolver
    {
        private readonly IDocumentResolver[] documentResolvers;
        private readonly ConcurrentDictionary<string, JsonDocument> documents = new ConcurrentDictionary<string, JsonDocument>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CompoundDocumentResolver"/> class.
        /// </summary>
        /// <param name="documentResolvers">The document resolvers to which to delegate.</param>
        public CompoundDocumentResolver(params IDocumentResolver[] documentResolvers)
        {
            this.documentResolvers = documentResolvers;
        }

        /// <inheritdoc/>
        public bool AddDocument(string uri, JsonDocument document)
        {
            return this.documents.TryAdd(uri, document);
        }

        /// <inheritdoc/>
        public async ValueTask<JsonDocument?> TryResolveDocument(JsonRef reference)
        {
            string uri = new string(reference.Uri);
            if (this.documents.TryGetValue(uri, out JsonDocument result))
            {
                return result;
            }

            foreach (IDocumentResolver resolver in this.documentResolvers)
            {
                JsonDocument? document = await resolver.TryResolveDocument(reference).ConfigureAwait(false);
                if (document is JsonDocument jd)
                {
                    return jd;
                }
            }

            return default;
        }
    }
}
