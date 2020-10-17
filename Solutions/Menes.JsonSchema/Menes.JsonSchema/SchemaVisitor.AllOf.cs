// <copyright file="SchemaVisitor.AllOf.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System.Collections.Immutable;
    using System.Threading.Tasks;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        /// <summary>
        /// Visit a schema node.
        /// </summary>
        /// <param name="arrayOfSchemaOrReferenceToUpdate">The array of schema or reference to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="Schema.ValidatedArrayOfSchemaOrReference"/>.</returns>
        protected virtual async ValueTask<(bool, Schema.ValidatedArrayOfSchemaOrReference?)> VisitAllOf(Schema.ValidatedArrayOfSchemaOrReference? arrayOfSchemaOrReferenceToUpdate)
        {
            bool wasUpdated = false;
            Schema.ValidatedArrayOfSchemaOrReference? updatedArrayOfSchemaOrReference = arrayOfSchemaOrReferenceToUpdate;

            if (arrayOfSchemaOrReferenceToUpdate is Schema.ValidatedArrayOfSchemaOrReference arrayOfSchemaOrReference)
            {
                ImmutableArray<Schema.SchemaOrReference>.Builder builder = ImmutableArray.CreateBuilder<Schema.SchemaOrReference>();

                int index = 0;
                foreach (Schema.SchemaOrReference schemaOrReferenceToUpdate in arrayOfSchemaOrReference)
                {
                    this.PushPointerElement($"[i]");
                    (bool wasUpdatedSchemaOrReference, Schema.SchemaOrReference? updatedSchemaOrReference) = await this.VisitSchemaOrReference(schemaOrReferenceToUpdate).ConfigureAwait(false);
                    if (wasUpdatedSchemaOrReference)
                    {
                        wasUpdated = true;
                        if (updatedSchemaOrReference is Schema.SchemaOrReference sor)
                        {
                            builder.Add(sor);
                        }
                        else
                        {
                            throw new JsonSchemaException("The schema or reference in an allOf array cannot be null. To modify the array, override VisitAllOf(Schema.ValidatedArrayOfSchemaOrReference?).");
                        }
                    }
                    else
                    {
                        builder.Add(schemaOrReferenceToUpdate);
                    }

                    this.PopPointerElement();
                    ++index;
                }

                if (wasUpdated)
                {
                    updatedArrayOfSchemaOrReference = new Schema.ValidatedArrayOfSchemaOrReference(JsonArray.Create(builder.ToImmutable()));
                }
            }

            return (wasUpdated, updatedArrayOfSchemaOrReference);
        }
    }
}
