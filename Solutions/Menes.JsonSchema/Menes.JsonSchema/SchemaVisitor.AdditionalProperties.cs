// <copyright file="SchemaVisitor.AdditionalProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System.Threading.Tasks;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        /// <summary>
        /// Visit the <see cref="Schema.AdditionalProperties"/> node.
        /// </summary>
        /// <param name="additionalPropertiesToUpdate">The AdditionalProperties to visit.</param>
        /// <returns><c>True</c> if the schema was updated.</returns>
        public virtual async ValueTask<(bool, Schema.SchemaAdditionalProperties?)> VisitAdditionalProperties(Schema.SchemaAdditionalProperties? additionalPropertiesToUpdate)
        {
            Schema.SchemaAdditionalProperties? updatedAdditionalProperties = additionalPropertiesToUpdate;

            bool wasUpdated = false;
            if (additionalPropertiesToUpdate is Schema.SchemaAdditionalProperties additionalProperties)
            {
                if (additionalProperties.IsSchemaOrReference)
                {
                    Schema.SchemaOrReference? updatedSchemaOrReference;
                    (wasUpdated, updatedSchemaOrReference) = await this.VisitSchemaOrReference(additionalProperties.AsSchemaOrReference()).ConfigureAwait(false);
                    if (wasUpdated)
                    {
                        if (!(updatedSchemaOrReference is Schema.SchemaOrReference sor))
                        {
                            throw new JsonSchemaException("The Schema.SchemaOrReference may not be null for Schema.AdditionalProperties. To convert to a boolean value, replace the entire Schema.SchemaAdditionalProperties using 'Visit(Schema.SchemaAdditionalProperties?, out Schema.SchemaAdditionalProperties?)'.");
                        }

                        additionalProperties = new Schema.SchemaAdditionalProperties(sor);
                    }
                }

                updatedAdditionalProperties = additionalProperties;
            }

            return (wasUpdated, updatedAdditionalProperties);
        }
    }
}
