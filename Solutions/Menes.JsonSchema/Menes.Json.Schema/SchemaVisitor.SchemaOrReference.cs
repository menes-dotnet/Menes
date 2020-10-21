// <copyright file="SchemaVisitor.SchemaOrReference.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        /// <summary>
        /// Visit the <see cref="JsonSchema.AdditionalProperties"/> node.
        /// </summary>
        /// <param name="schemaOrReferenceToUpdate">The <see cref="JsonSchema.SchemaOrReference"/> to visit.</param>
        /// <returns><c>True</c> if the <see cref="JsonSchema.SchemaOrReference"/> was updated.</returns>
        protected virtual async ValueTask<(bool, JsonSchema.SchemaOrReference?)> VisitSchemaOrReference(JsonSchema.SchemaOrReference? schemaOrReferenceToUpdate)
        {
            bool wasUpdated = false;
            JsonSchema.SchemaOrReference? updatedSchemaOrReference = schemaOrReferenceToUpdate;

            if (schemaOrReferenceToUpdate is JsonSchema.SchemaOrReference schemaOrReference)
            {
                bool pushedDocument = false;

                if (this.ResolveReferences)
                {
                    (string uri, JsonDocument document) = this.DocumentStack.Peek();
                    (string uri, JsonDocument document, JsonSchema.SchemaOrReference schemaOrReference) result = await schemaOrReference.Resolve(uri, this.Path, document, this.DocumentResolver).ConfigureAwait(false);

                    if (result.document != document)
                    {
                        this.DocumentStack.Push((result.uri, result.document));
                        pushedDocument = true;
                    }

                    wasUpdated = true;
                }

                if (!schemaOrReference.IsSchemaReference)
                {
                    (bool wasSchemaUpdated, JsonSchema? updatedSchema) = await this.VisitSchema(schemaOrReference.AsJsonSchema()).ConfigureAwait(false);

                    if (wasSchemaUpdated)
                    {
                        if (!(updatedSchema is JsonSchema schema))
                        {
                            throw new JsonSchemaException("The Schema may not be null for SchemaOrReference. To convert to a Reference, replace the entire Schema using 'Visit(Schema.SchemaOrReference?, out Schema.SchemaOrReference?)'.");
                        }

                        wasUpdated = true;
                        schemaOrReference = new JsonSchema.SchemaOrReference(schema);
                    }
                }

                if (this.ResolveReferences)
                {
                    if (pushedDocument)
                    {
                        this.DocumentStack.Pop();
                    }
                }

                updatedSchemaOrReference = schemaOrReference;
            }

            return (wasUpdated, updatedSchemaOrReference);
        }
    }
}
