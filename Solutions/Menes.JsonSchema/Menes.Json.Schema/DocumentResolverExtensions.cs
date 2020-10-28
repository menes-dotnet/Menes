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
        /// <param name="resolveReferences">Whether to resolve references on load.</param>
        /// <returns>A <see cref="Task{TResult}"/> which produces the <see cref="JsonSchema"/>.</returns>
        public static async Task<(string, JsonDocument, JsonSchema)> LoadSchema(this IDocumentResolver resolver, JsonRef reference, bool resolveReferences = true)
        {
            (string baseUri, JsonDocument document, JsonSchema.SchemaOrReference schemaOrReference) = await reference.Resolve(resolver).ConfigureAwait(false);
            JsonSchema schema = schemaOrReference.AsJsonSchema();

            if (resolveReferences)
            {
                var visitor = new SchemaVisitor(resolver, reference.Uri.ToString(), document);
                (bool wasModified, JsonSchema? schema) result = await visitor.VisitSchema(schema).ConfigureAwait(false);
                if (result.wasModified && result.schema is JsonSchema s)
                {
                    schema = s;
                }
            }

            return (baseUri, document, schema);
        }
    }
}
