// <copyright file="SchemaVisitor.Schema.cs" company="Endjin Limited">
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

                (bool wasUpdatedConst, JsonAny? updatedConst) = await this.VisitConst(schema.Const).ConfigureAwait(false);
                if (wasUpdatedConst)
                {
                    schema = schema.WithConst(updatedConst);
                    wasUpdated = true;
                }

                (bool wasUpdatedContains, Schema.SchemaOrReference? updatedContains) = await this.VisitContains(schema.Contains).ConfigureAwait(false);
                if (wasUpdatedContains)
                {
                    schema = schema.WithContains(updatedContains);
                    wasUpdated = true;
                }

                (bool wasUpdatedEnum, JsonArray<JsonAny>? updatedEnum) = await this.VisitEnum(schema.Enum).ConfigureAwait(false);
                if (wasUpdatedEnum)
                {
                    schema = schema.WithEnum(updatedEnum);
                    wasUpdated = true;
                }

                (bool wasUpdatedExclusiveMaximum, JsonNumber? updatedExlusiveMaximum) = await this.VisitExclusiveMaximum(schema.ExclusiveMaximum).ConfigureAwait(false);
                if (wasUpdatedExclusiveMaximum)
                {
                    schema = schema.WithExclusiveMaximum(updatedExlusiveMaximum);
                    wasUpdated = true;
                }

                (bool wasUpdatedExclusiveMinimum, JsonNumber? updatedExlusiveMinimum) = await this.VisitExclusiveMinimum(schema.ExclusiveMinimum).ConfigureAwait(false);
                if (wasUpdatedExclusiveMinimum)
                {
                    schema = schema.WithExclusiveMinimum(updatedExlusiveMinimum);
                    wasUpdated = true;
                }

                (bool wasUpdatedFormat, JsonString? updatedFormat) = await this.VisitFormat(schema.Format).ConfigureAwait(false);
                if (wasUpdatedFormat)
                {
                    schema = schema.WithFormat(updatedFormat);
                    wasUpdated = true;
                }

                (bool wasUpdatedItems, Schema.SchemaOrReference? updatedItems) = await this.VisitItems(schema.Items).ConfigureAwait(false);
                if (wasUpdatedItems)
                {
                    schema = schema.WithItems(updatedItems);
                    wasUpdated = true;
                }

                (bool wasUpdatedMaxContains, Schema.NonNegativeInteger? updatedMaxContains) = await this.VisitMaxContains(schema.MaxContains).ConfigureAwait(false);
                if (wasUpdatedMaxContains)
                {
                    schema = schema.WithMaxContains(updatedMaxContains);
                    wasUpdated = true;
                }

                (bool wasUpdatedMinContains, Schema.NonNegativeInteger? updatedMinContains) = await this.VisitMinContains(schema.MaxContains).ConfigureAwait(false);
                if (wasUpdatedMinContains)
                {
                    schema = schema.WithMaxContains(updatedMinContains);
                    wasUpdated = true;
                }

                (bool wasUpdatedMaximum, JsonNumber? updatedMaximum) = await this.VisitMaximum(schema.Maximum).ConfigureAwait(false);
                if (wasUpdatedMaximum)
                {
                    schema = schema.WithMaximum(updatedMaximum);
                    wasUpdated = true;
                }

                (bool wasUpdatedMinimum, JsonNumber? updatedMinimum) = await this.VisitMinimum(schema.Maximum).ConfigureAwait(false);
                if (wasUpdatedMinimum)
                {
                    schema = schema.WithMaximum(updatedMinimum);
                    wasUpdated = true;
                }

                updatedSchema = schema;
            }

            return (wasUpdated, updatedSchema);
        }
    }
}
