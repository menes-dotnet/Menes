// <copyright file="DocumentResolverExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Parse json schema.
    /// </summary>
    public static class DocumentResolverExtensions
    {
        /// <summary>
        /// Loads schema via a <see cref="JsonRef"/>.
        /// </summary>
        /// <param name="resolver">The <see cref="IDocumentResolver"/> to load the document in the reference.</param>
        /// <param name="reference">The json reference at which to load the schema.</param>
        /// <returns>A <see cref="Task{TResult}"/> which produces the <see cref="JsonSchema"/>.</returns>
        public static async Task<(string, JsonDocument, JsonSchema)> LoadSchema(this IDocumentResolver resolver, JsonRef reference)
        {
            (string baseUri, JsonDocument document, JsonSchema.SchemaOrReference schemaOrReference) = await reference.Resolve(resolver).ConfigureAwait(false);
            JsonSchema schema = schemaOrReference.AsJsonSchema();
            return (baseUri, document, schema);
        }
    }
}
