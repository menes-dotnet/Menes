// <copyright file="SchemaExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes;

    /// <summary>
    /// Extension methods to manipulate JSON schema.
    /// </summary>
    public static class SchemaExtensions
    {
        /// <summary>
        /// Resolves the schema in a schema or reference.
        /// </summary>
        /// <param name="schemaToResolve">The schema or reference to resolve.</param>
        /// <param name="baseUri">The current base URI.</param>
        /// <param name="root">The root document for this schema instance.</param>
        /// <param name="documentResolver">The document resolver that can load a document from a json reference.</param>
        /// <returns>The resolved reference.</returns>
        /// <remarks>If any additional documents were loaded as part of this exercise, they will be added to the collection.</remarks>
        public static async Task<(string uri, JsonDocument document, JsonSchema reference)> Resolve(this JsonSchema schemaToResolve, string baseUri, JsonDocument root, IDocumentResolver documentResolver)
        {
            if (schemaToResolve.IsNull)
            {
                return (baseUri, root, schemaToResolve);
            }

            if (schemaToResolve.Ref is JsonString jsonRef)
            {
                var reference = new JsonRef(jsonRef);
                if (!reference.HasUri)
                {
                    reference = reference.WithUri(baseUri);
                }

                return await ResolveReference(reference, root, documentResolver).ConfigureAwait(false);
            }

            return (baseUri, root, schemaToResolve);
        }

        /// <summary>
        /// Resolve a JSON reference.
        /// </summary>
        /// <param name="reference">The JSON reference to resolve.</param>
        /// <param name="documentResolver">The document resolver.</param>
        /// <returns>A <see cref="Task"/> that provides the <see cref="JsonSchema.Schema"/>.</returns>
        public static Task<(string, JsonDocument, JsonSchema)> Resolve(this JsonRef reference, IDocumentResolver documentResolver)
        {
            return ResolveReference(reference, null, documentResolver);
        }

        private static async Task<(string, JsonDocument, JsonSchema)> ResolveReference(JsonRef reference, JsonDocument? root, IDocumentResolver documentResolver)
        {
            JsonDocument? document = root;

            if (reference.HasUri)
            {
                document = await documentResolver.TryResolveDocument(reference).ConfigureAwait(false);
            }

            if (document is null)
            {
                throw new JsonSchemaException($"Unable to resolve the document at URI {reference.Uri.ToString()}");
            }

            return (reference.Uri.ToString(), document, ResolveSchema(document, reference));
        }

        private static JsonSchema ResolveSchema(JsonDocument document, JsonRef reference)
        {
            JsonSchema schema;
            if (reference.HasPointer)
            {
                schema = new JsonSchema(JsonPointer.ResolvePointer(document.RootElement, reference.Pointer));
            }
            else
            {
                schema = new JsonSchema(document.RootElement);
            }

            if (schema.Id is null && !schema.IsBooleanSchema())
            {
                schema = schema.WithId(BuildId(reference));
            }

            return schema;
        }

        private static JsonString BuildId(JsonRef reference)
        {
            return reference.ToString();
        }
    }
}
