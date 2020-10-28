// <copyright file="SchemaVisitor.AdditionalProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System.Threading.Tasks;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        /// <summary>
        /// Visit the <see cref="JsonSchema.AdditionalProperties"/> node.
        /// </summary>
        /// <param name="additionalPropertiesToUpdate">The AdditionalProperties to visit.</param>
        /// <returns><c>True</c> if the schema was updated.</returns>
        protected virtual async Task<(bool, JsonSchema.SchemaAdditionalProperties?)> VisitAdditionalProperties(JsonSchema.SchemaAdditionalProperties? additionalPropertiesToUpdate)
        {
            JsonSchema.SchemaAdditionalProperties? updatedAdditionalProperties = additionalPropertiesToUpdate;

            bool wasUpdated = false;
            if (additionalPropertiesToUpdate is JsonSchema.SchemaAdditionalProperties additionalProperties)
            {
                if (additionalProperties.IsSchemaOrReference)
                {
                    JsonSchema.SchemaOrReference? updatedSchemaOrReference;
                    (wasUpdated, updatedSchemaOrReference) = await this.VisitSchemaOrReference(additionalProperties.AsSchemaOrReference()).ConfigureAwait(false);
                    if (wasUpdated)
                    {
                        if (!(updatedSchemaOrReference is JsonSchema.SchemaOrReference sor))
                        {
                            throw new JsonSchemaException("The Schema.SchemaOrReference may not be null for Schema.AdditionalProperties. To convert to a boolean value, replace the entire Schema.SchemaAdditionalProperties using 'Visit(Schema.SchemaAdditionalProperties?, out Schema.SchemaAdditionalProperties?)'.");
                        }

                        additionalProperties = new JsonSchema.SchemaAdditionalProperties(sor);
                    }
                }

                updatedAdditionalProperties = additionalProperties;
            }

            return (wasUpdated, updatedAdditionalProperties);
        }
    }
}
