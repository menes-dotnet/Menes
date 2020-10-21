﻿// <copyright file="SchemaExtensions.cs" company="Endjin Limited">
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
        /// <param name="currentPointer">The current path in the document.</param>
        /// <param name="root">The root document for this schema instance.</param>
        /// <param name="documentResolver">The document resolver that can load a document from a json reference.</param>
        /// <returns>The resolved reference.</returns>
        /// <remarks>If any additional documents were loaded as part of this exercise, they will be added to the collection.</remarks>
        public static async ValueTask<(string uri, JsonDocument document, JsonSchema.SchemaOrReference reference)> Resolve(this JsonSchema.SchemaOrReference schemaToResolve, string baseUri, string currentPointer, JsonDocument root, IDocumentResolver documentResolver)
        {
            if (schemaToResolve.IsNull)
            {
                return (baseUri, root, schemaToResolve);
            }

            if (schemaToResolve.IsSchemaReference)
            {
                var reference = new JsonRef(schemaToResolve.AsSchemaReference().Ref);
                if (!reference.HasUri)
                {
                    reference = reference.WithUri(baseUri);
                }

                return await ResolveReference(reference, root, documentResolver).ConfigureAwait(false);
            }

            JsonSchema schema = schemaToResolve.AsJsonSchema();

            if (schema.Id is null)
            {
                return (baseUri, root, new JsonSchema.SchemaOrReference(schema.WithId(new JsonRef(baseUri, currentPointer).ToString())));
            }

            return (baseUri, root, schemaToResolve);
        }

        /// <summary>
        /// Resolve a JSON reference.
        /// </summary>
        /// <param name="reference">The JSON reference to resolve.</param>
        /// <param name="documentResolver">The document resolver.</param>
        /// <returns>A <see cref="ValueTask"/> that provides the <see cref="JsonSchema.SchemaOrReference"/>.</returns>
        public static ValueTask<(string, JsonDocument, JsonSchema.SchemaOrReference)> Resolve(this JsonRef reference, IDocumentResolver documentResolver)
        {
            return ResolveReference(reference, null, documentResolver);
        }

        private static async ValueTask<(string, JsonDocument, JsonSchema.SchemaOrReference)> ResolveReference(JsonRef reference, JsonDocument? root, IDocumentResolver documentResolver)
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

        private static JsonSchema.SchemaOrReference ResolveSchema(JsonDocument document, JsonRef reference)
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

            if (schema.Id is null)
            {
                schema = schema.WithId(BuildId(reference));
            }

            return new JsonSchema.SchemaOrReference(schema);
        }

        private static JsonString BuildId(JsonRef reference)
        {
            return reference.ToString();
        }
    }
}