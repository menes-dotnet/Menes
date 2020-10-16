// <copyright file="IDocumentResolver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// A factory which can resolve a <see cref="JsonDocument"/>
    /// from a <see cref="JsonRef"/>.
    /// </summary>
    public interface IDocumentResolver
    {
        /// <summary>
        /// Gets the document at the given <see cref="JsonRef.Uri"/> in the <paramref name="reference"/>.
        /// </summary>
        /// <param name="reference">The reference containing the document URI.</param>
        /// <returns>A <see cref="ValueTask{TResult}"/> which provides the <see cref="JsonDocument"/>, or <c>null</c> if it could not be retrieved.</returns>
        ValueTask<JsonDocument?> TryResolveDocument(JsonRef reference);

        /// <summary>
        /// Add an existing document to the cache.
        /// </summary>
        /// <param name="uri">The URI of the document.</param>
        /// <param name="document">The document to add.</param>
        /// <returns><c>True</c> if the document was added, otherwise false.</returns>
        bool AddDocument(string uri, JsonDocument document);
    }
}