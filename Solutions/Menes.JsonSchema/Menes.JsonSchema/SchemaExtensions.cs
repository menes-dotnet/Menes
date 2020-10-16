// <copyright file="SchemaExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods to manipulate JSON schema.
    /// </summary>
    public static class SchemaExtensions
    {
        /// <summary>
        /// Resolves the schema in a schema or reference.
        /// </summary>
        /// <param name="schemaToResolve">The schema or reference to resolve.</param>
        /// <param name="root">The root document for this schema instance.</param>
        /// <param name="documentResolver">The document resolver that can load a document from a json reference.</param>
        /// <returns>The resolved reference.</returns>
        /// <remarks>If any additional documents were loaded as part of this exercise, they will be added to the collection.</remarks>
        public static async ValueTask<(JsonDocument, Schema.SchemaOrReference)> Resolve(this Schema.SchemaOrReference schemaToResolve, JsonDocument root, IDocumentResolver documentResolver)
        {
            if (schemaToResolve.IsNull || schemaToResolve.IsSchema)
            {
                return (root, schemaToResolve);
            }

            var reference = new JsonRef(schemaToResolve.AsSchemaReference().Ref);

            return await ResolveReference(reference, root, documentResolver).ConfigureAwait(false);
        }

        /// <summary>
        /// Resolve a JSON reference.
        /// </summary>
        /// <param name="reference">The JSON reference to resolve.</param>
        /// <param name="documentResolver">The document resolver.</param>
        /// <returns>A <see cref="ValueTask"/> that provides the <see cref="Schema.SchemaOrReference"/>.</returns>
        public static ValueTask<(JsonDocument, Schema.SchemaOrReference)> Resolve(this JsonRef reference, IDocumentResolver documentResolver)
        {
            return ResolveReference(reference, null, documentResolver);
        }

        private static async ValueTask<(JsonDocument, Schema.SchemaOrReference)> ResolveReference(JsonRef reference, JsonDocument? root, IDocumentResolver documentResolver)
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

            return (document, ResolveSchema(document, reference));
        }

        private static Schema.SchemaOrReference ResolveSchema(JsonDocument document, JsonRef reference)
        {
            if (reference.HasPointer)
            {
                return new Schema.SchemaOrReference(JsonPointer.ResolvePointer(document.RootElement, reference.Pointer));
            }

            return new Schema.SchemaOrReference(document.RootElement);
        }
    }
}
