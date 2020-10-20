// <copyright file="DocumentResolverExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
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
        /// <returns>A <see cref="ValueTask{TResult}"/> which produces the <see cref="Schema"/>.</returns>
        public static async ValueTask<(string, JsonDocument, Schema)> LoadSchema(this IDocumentResolver resolver, JsonRef reference, bool resolveReferences = true)
        {
            (string baseUri, JsonDocument document, Schema.SchemaOrReference schemaOrReference) = await reference.Resolve(resolver).ConfigureAwait(false);
            Schema schema = schemaOrReference.AsSchema();

            if (resolveReferences)
            {
                var visitor = new SchemaVisitor(resolver, reference.Uri.ToString(), document);
                (bool wasModified, Schema? schema) result = await visitor.VisitSchema(schema).ConfigureAwait(false);
                if (result.wasModified && result.schema is Schema s)
                {
                    schema = s;
                }
            }

            return (baseUri, document, schema);
        }
    }
}
