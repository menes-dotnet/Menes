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

                (bool wasUpdatedIf, Schema.SchemaOrReference? updatedIf) = await this.VisitIf(schema.If).ConfigureAwait(false);
                if (wasUpdatedIf)
                {
                    schema = schema.WithIf(updatedIf);
                    wasUpdated = true;
                }

                (bool wasUpdatedThen, Schema.SchemaOrReference? updatedThen) = await this.VisitThen(schema.Then).ConfigureAwait(false);
                if (wasUpdatedThen)
                {
                    schema = schema.WithThen(updatedThen);
                    wasUpdated = true;
                }

                (bool wasUpdatedElse, Schema.SchemaOrReference? updatedElse) = await this.VisitElse(schema.Else).ConfigureAwait(false);
                if (wasUpdatedElse)
                {
                    schema = schema.WithElse(updatedElse);
                    wasUpdated = true;
                }

                (bool wasUpdatedDependentSchemas, Schema.SchemaProperties? updatedDependentSchemas) = await this.VisitDependentSchemas(schema.DependentSchemas).ConfigureAwait(false);
                if (wasUpdatedDependentSchemas)
                {
                    schema = schema.WithDependentSchemas(updatedDependentSchemas);
                    wasUpdated = true;
                }

                (bool wasUpdatedMaxItems, Schema.NonNegativeInteger? updatedMaxItems) = await this.VisitMaxItems(schema.MaxItems).ConfigureAwait(false);
                if (wasUpdatedMaxItems)
                {
                    schema = schema.WithMaxItems(updatedMaxItems);
                    wasUpdated = true;
                }

                (bool wasUpdatedMinItems, Schema.NonNegativeInteger? updatedMinItems) = await this.VisitMinItems(schema.MinItems).ConfigureAwait(false);
                if (wasUpdatedMinItems)
                {
                    schema = schema.WithMinItems(updatedMinItems);
                    wasUpdated = true;
                }

                (bool wasUpdatedMaxLength, Schema.NonNegativeInteger? updatedMaxLength) = await this.VisitMaxLength(schema.MaxLength).ConfigureAwait(false);
                if (wasUpdatedMaxLength)
                {
                    schema = schema.WithMaxLength(updatedMaxLength);
                    wasUpdated = true;
                }

                (bool wasUpdatedMinLength, Schema.NonNegativeInteger? updatedMinLength) = await this.VisitMinLength(schema.MinLength).ConfigureAwait(false);
                if (wasUpdatedMinLength)
                {
                    schema = schema.WithMinLength(updatedMinLength);
                    wasUpdated = true;
                }

                (bool wasUpdatedMaxProperties, Schema.NonNegativeInteger? updatedMaxProperties) = await this.VisitMaxProperties(schema.MaxProperties).ConfigureAwait(false);
                if (wasUpdatedMaxProperties)
                {
                    schema = schema.WithMaxProperties(updatedMaxProperties);
                    wasUpdated = true;
                }

                (bool wasUpdatedMinProperties, Schema.NonNegativeInteger? updatedMinProperties) = await this.VisitMinProperties(schema.MinProperties).ConfigureAwait(false);
                if (wasUpdatedMinProperties)
                {
                    schema = schema.WithMinProperties(updatedMinProperties);
                    wasUpdated = true;
                }

                (bool wasUpdatedMultipleOf, Schema.PositiveNumber? updatedMultipleOf) = await this.VisitMultipleOf(schema.MultipleOf).ConfigureAwait(false);
                if (wasUpdatedMultipleOf)
                {
                    schema = schema.WithMultipleOf(updatedMultipleOf);
                    wasUpdated = true;
                }

                (bool wasUpdatedNot, Schema.SchemaOrReference? updatedNot) = await this.VisitNot(schema.Not).ConfigureAwait(false);
                if (wasUpdatedNot)
                {
                    schema = schema.WithNot(updatedNot);
                    wasUpdated = true;
                }

                (bool wasUpdatedOneOf, Schema.ValidatedArrayOfSchemaOrReference? updatedOneOf) = await this.VisitOneOf(schema.OneOf).ConfigureAwait(false);
                if (wasUpdatedOneOf)
                {
                    schema = schema.WithOneOf(updatedOneOf);
                    wasUpdated = true;
                }

                (bool wasUpdatedPattern, JsonString? updatedPattern) = await this.VisitPattern(schema.Pattern).ConfigureAwait(false);
                if (wasUpdatedPattern)
                {
                    schema = schema.WithPattern(updatedPattern);
                    wasUpdated = true;
                }

                (bool wasUpdatedPatternProperties, Schema.SchemaProperties? updatedPatternProperties) = await this.VisitPatternProperties(schema.PatternProperties).ConfigureAwait(false);
                if (wasUpdatedPatternProperties)
                {
                    schema = schema.WithPatternProperties(updatedPatternProperties);
                    wasUpdated = true;
                }

                (bool wasUpdatedProperties, Schema.SchemaProperties? updatedProperties) = await this.VisitProperties(schema.Properties).ConfigureAwait(false);
                if (wasUpdatedProperties)
                {
                    schema = schema.WithProperties(updatedProperties);
                    wasUpdated = true;
                }

                (bool wasUpdatedPropertyNames, Schema.SchemaOrReference? updatedPropertyNames) = await this.VisitPropertyNames(schema.PropertyNames).ConfigureAwait(false);
                if (wasUpdatedPropertyNames)
                {
                    schema = schema.WithPropertyNames(updatedPropertyNames);
                    wasUpdated = true;
                }

                (bool wasUpdatedRequired, Schema.ValidatedArrayOfJsonString? updatedRequired) = await this.VisitRequired(schema.Required).ConfigureAwait(false);
                if (wasUpdatedRequired)
                {
                    schema = schema.WithRequired(updatedRequired);
                    wasUpdated = true;
                }

                (bool wasUpdatedType, Schema.TypeEnum? updatedType) = await this.VisitType(schema.Type).ConfigureAwait(false);
                if (wasUpdatedType)
                {
                    schema = schema.WithType(updatedType);
                    wasUpdated = true;
                }

                (bool wasUpdatedUniqueItems, JsonBoolean? updatedUniqueItems) = await this.VisitUniqueItems(schema.UniqueItems).ConfigureAwait(false);
                if (wasUpdatedUniqueItems)
                {
                    schema = schema.WithUniqueItems(updatedUniqueItems);
                    wasUpdated = true;
                }

                updatedSchema = schema;
            }

            return (wasUpdated, updatedSchema);
        }
    }
}
