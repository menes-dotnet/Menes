// <copyright file="SchemaVisitor.Schema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        /// <summary>
        /// Visit a schema node.
        /// </summary>
        /// <param name="schemaToUpdate">The schema to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="Schema"/>.</returns>
        public virtual async ValueTask<(bool, Schema?)> VisitSchema(Schema? schemaToUpdate)
        {
            Schema? updatedSchema = schemaToUpdate;
            bool wasUpdated = false;
            if (updatedSchema is Schema schema)
            {
                (bool wasUpdatedAdditionalProperties, Schema.SchemaAdditionalProperties? updatedSchemaAdditionalProperties) = await this.VisitAdditionalProperties(schema.AdditionalProperties).ConfigureAwait(false);
                if (wasUpdatedAdditionalProperties)
                {
                    schema = schema.WithAdditionalProperties(updatedSchemaAdditionalProperties);
                    wasUpdated = true;
                }

                (bool wasUpdatedAllOf, Schema.ValidatedArrayOfSchemaOrReference? updatedAllOf) = await this.VisitAllOf(schema.AllOf).ConfigureAwait(false);
                if (wasUpdatedAllOf)
                {
                    schema = schema.WithAllOf(updatedAllOf);
                    wasUpdated = true;
                }

                (bool wasUpdatedAnyOf, Schema.ValidatedArrayOfSchemaOrReference? updatedAnyOf) = await this.VisitAnyOf(schema.AnyOf).ConfigureAwait(false);
                if (wasUpdatedAnyOf)
                {
                    schema = schema.WithAnyOf(updatedAnyOf);
                    wasUpdated = true;
                }

                updatedSchema = schema;
            }

            return (wasUpdated, updatedSchema);
        }
    }
}
