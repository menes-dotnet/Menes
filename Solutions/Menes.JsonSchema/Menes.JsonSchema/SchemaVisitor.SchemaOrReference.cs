// <copyright file="SchemaVisitor.SchemaOrReference.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        /// <summary>
        /// Visit the <see cref="Schema.AdditionalProperties"/> node.
        /// </summary>
        /// <param name="schemaOrReferenceToUpdate">The <see cref="Schema.SchemaOrReference"/> to visit.</param>
        /// <returns><c>True</c> if the <see cref="Schema.SchemaOrReference"/> was updated.</returns>
        protected virtual async ValueTask<(bool, Schema.SchemaOrReference?)> VisitSchemaOrReference(Schema.SchemaOrReference? schemaOrReferenceToUpdate)
        {
            bool wasUpdated = false;
            Schema.SchemaOrReference? updatedSchemaOrReference = schemaOrReferenceToUpdate;

            if (schemaOrReferenceToUpdate is Schema.SchemaOrReference schemaOrReference)
            {
                bool pushedDocument = false;

                if (this.ResolveReferences)
                {
                    JsonDocument document;

                    (document, schemaOrReference) = await schemaOrReference.Resolve(this.DocumentStack.Peek(), this.DocumentResolver).ConfigureAwait(false);

                    if (this.DocumentStack.Peek() != document)
                    {
                        this.DocumentStack.Push(document);
                        pushedDocument = true;
                    }

                    wasUpdated = true;
                }

                if (schemaOrReference.IsSchema)
                {
                    (bool wasSchemaUpdated, Schema? updatedSchema) = await this.VisitSchema(schemaOrReference.AsSchema()).ConfigureAwait(false);

                    if (wasSchemaUpdated)
                    {
                        if (!(updatedSchema is Schema schema))
                        {
                            throw new JsonSchemaException("The Schema may not be null for SchemaOrReference. To convert to a Reference, replace the entire Schema using 'Visit(Schema.SchemaOrReference?, out Schema.SchemaOrReference?)'.");
                        }

                        wasUpdated = true;
                        schemaOrReference = new Schema.SchemaOrReference(schema);
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
