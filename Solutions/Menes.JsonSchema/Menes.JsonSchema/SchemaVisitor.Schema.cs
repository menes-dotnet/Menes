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
                this.PushPointerElement("#");

                this.PushPointerElement("additionalProperties");

                (bool wasUpdatedAdditionalProperties, Schema.SchemaAdditionalProperties? updatedSchemaAdditionalProperties) = await this.VisitAdditionalProperties(schema.AdditionalProperties).ConfigureAwait(false);
                if (wasUpdatedAdditionalProperties)
                {
                    schema = schema.WithAdditionalProperties(updatedSchemaAdditionalProperties);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("allOf");

                (bool wasUpdatedAllOf, Schema.ValidatedArrayOfSchemaOrReference? updatedAllOf) = await this.VisitAllOf(schema.AllOf).ConfigureAwait(false);
                if (wasUpdatedAllOf)
                {
                    schema = schema.WithAllOf(updatedAllOf);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("anyOf");

                (bool wasUpdatedAnyOf, Schema.ValidatedArrayOfSchemaOrReference? updatedAnyOf) = await this.VisitAnyOf(schema.AnyOf).ConfigureAwait(false);
                if (wasUpdatedAnyOf)
                {
                    schema = schema.WithAnyOf(updatedAnyOf);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("const");

                (bool wasUpdatedConst, JsonAny? updatedConst) = await this.VisitConst(schema.Const).ConfigureAwait(false);
                if (wasUpdatedConst)
                {
                    schema = schema.WithConst(updatedConst);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("contains");

                (bool wasUpdatedContains, Schema.SchemaOrReference? updatedContains) = await this.VisitContains(schema.Contains).ConfigureAwait(false);
                if (wasUpdatedContains)
                {
                    schema = schema.WithContains(updatedContains);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("enum");

                (bool wasUpdatedEnum, JsonArray<JsonAny>? updatedEnum) = await this.VisitEnum(schema.Enum).ConfigureAwait(false);
                if (wasUpdatedEnum)
                {
                    schema = schema.WithEnum(updatedEnum);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("exclusiveMaximum");

                (bool wasUpdatedExclusiveMaximum, JsonNumber? updatedExclusiveMaximum) = await this.VisitExclusiveMaximum(schema.ExclusiveMaximum).ConfigureAwait(false);
                if (wasUpdatedExclusiveMaximum)
                {
                    schema = schema.WithExclusiveMaximum(updatedExclusiveMaximum);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("exclusiveMinimum");

                (bool wasUpdatedExclusiveMinimum, JsonNumber? updatedExlusiveMinimum) = await this.VisitExclusiveMinimum(schema.ExclusiveMinimum).ConfigureAwait(false);
                if (wasUpdatedExclusiveMinimum)
                {
                    schema = schema.WithExclusiveMinimum(updatedExlusiveMinimum);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("format");

                (bool wasUpdatedFormat, JsonString? updatedFormat) = await this.VisitFormat(schema.Format).ConfigureAwait(false);
                if (wasUpdatedFormat)
                {
                    schema = schema.WithFormat(updatedFormat);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("items");

                (bool wasUpdatedItems, Schema.SchemaOrReference? updatedItems) = await this.VisitItems(schema.Items).ConfigureAwait(false);
                if (wasUpdatedItems)
                {
                    schema = schema.WithItems(updatedItems);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("maxContains");

                (bool wasUpdatedMaxContains, Schema.NonNegativeInteger? updatedMaxContains) = await this.VisitMaxContains(schema.MaxContains).ConfigureAwait(false);
                if (wasUpdatedMaxContains)
                {
                    schema = schema.WithMaxContains(updatedMaxContains);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("minContains");

                (bool wasUpdatedMinContains, Schema.NonNegativeInteger? updatedMinContains) = await this.VisitMinContains(schema.MaxContains).ConfigureAwait(false);
                if (wasUpdatedMinContains)
                {
                    schema = schema.WithMaxContains(updatedMinContains);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("maximum");

                (bool wasUpdatedMaximum, JsonNumber? updatedMaximum) = await this.VisitMaximum(schema.Maximum).ConfigureAwait(false);
                if (wasUpdatedMaximum)
                {
                    schema = schema.WithMaximum(updatedMaximum);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("minimum");

                (bool wasUpdatedMinimum, JsonNumber? updatedMinimum) = await this.VisitMinimum(schema.Minimum).ConfigureAwait(false);
                if (wasUpdatedMinimum)
                {
                    schema = schema.WithMinimum(updatedMinimum);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("if");

                (bool wasUpdatedIf, Schema.SchemaOrReference? updatedIf) = await this.VisitIf(schema.If).ConfigureAwait(false);
                if (wasUpdatedIf)
                {
                    schema = schema.WithIf(updatedIf);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("then");

                (bool wasUpdatedThen, Schema.SchemaOrReference? updatedThen) = await this.VisitThen(schema.Then).ConfigureAwait(false);
                if (wasUpdatedThen)
                {
                    schema = schema.WithThen(updatedThen);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("else");

                (bool wasUpdatedElse, Schema.SchemaOrReference? updatedElse) = await this.VisitElse(schema.Else).ConfigureAwait(false);
                if (wasUpdatedElse)
                {
                    schema = schema.WithElse(updatedElse);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("dependentSchemas");

                (bool wasUpdatedDependentSchemas, Schema.SchemaProperties? updatedDependentSchemas) = await this.VisitDependentSchemas(schema.DependentSchemas).ConfigureAwait(false);
                if (wasUpdatedDependentSchemas)
                {
                    schema = schema.WithDependentSchemas(updatedDependentSchemas);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("maxItems");

                (bool wasUpdatedMaxItems, Schema.NonNegativeInteger? updatedMaxItems) = await this.VisitMaxItems(schema.MaxItems).ConfigureAwait(false);
                if (wasUpdatedMaxItems)
                {
                    schema = schema.WithMaxItems(updatedMaxItems);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("minItems");

                (bool wasUpdatedMinItems, Schema.NonNegativeInteger? updatedMinItems) = await this.VisitMinItems(schema.MinItems).ConfigureAwait(false);
                if (wasUpdatedMinItems)
                {
                    schema = schema.WithMinItems(updatedMinItems);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("maxLength");

                (bool wasUpdatedMaxLength, Schema.NonNegativeInteger? updatedMaxLength) = await this.VisitMaxLength(schema.MaxLength).ConfigureAwait(false);
                if (wasUpdatedMaxLength)
                {
                    schema = schema.WithMaxLength(updatedMaxLength);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("minLength");

                (bool wasUpdatedMinLength, Schema.NonNegativeInteger? updatedMinLength) = await this.VisitMinLength(schema.MinLength).ConfigureAwait(false);
                if (wasUpdatedMinLength)
                {
                    schema = schema.WithMinLength(updatedMinLength);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("maxProperties");

                (bool wasUpdatedMaxProperties, Schema.NonNegativeInteger? updatedMaxProperties) = await this.VisitMaxProperties(schema.MaxProperties).ConfigureAwait(false);
                if (wasUpdatedMaxProperties)
                {
                    schema = schema.WithMaxProperties(updatedMaxProperties);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("minProperties");

                (bool wasUpdatedMinProperties, Schema.NonNegativeInteger? updatedMinProperties) = await this.VisitMinProperties(schema.MinProperties).ConfigureAwait(false);
                if (wasUpdatedMinProperties)
                {
                    schema = schema.WithMinProperties(updatedMinProperties);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("multipleOf");

                (bool wasUpdatedMultipleOf, Schema.PositiveNumber? updatedMultipleOf) = await this.VisitMultipleOf(schema.MultipleOf).ConfigureAwait(false);
                if (wasUpdatedMultipleOf)
                {
                    schema = schema.WithMultipleOf(updatedMultipleOf);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("not");

                (bool wasUpdatedNot, Schema.SchemaOrReference? updatedNot) = await this.VisitNot(schema.Not).ConfigureAwait(false);
                if (wasUpdatedNot)
                {
                    schema = schema.WithNot(updatedNot);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("oneOf");

                (bool wasUpdatedOneOf, Schema.ValidatedArrayOfSchemaOrReference? updatedOneOf) = await this.VisitOneOf(schema.OneOf).ConfigureAwait(false);
                if (wasUpdatedOneOf)
                {
                    schema = schema.WithOneOf(updatedOneOf);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("pattern");

                (bool wasUpdatedPattern, JsonString? updatedPattern) = await this.VisitPattern(schema.Pattern).ConfigureAwait(false);
                if (wasUpdatedPattern)
                {
                    schema = schema.WithPattern(updatedPattern);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("patternProperties");

                (bool wasUpdatedPatternProperties, Schema.SchemaProperties? updatedPatternProperties) = await this.VisitPatternProperties(schema.PatternProperties).ConfigureAwait(false);
                if (wasUpdatedPatternProperties)
                {
                    schema = schema.WithPatternProperties(updatedPatternProperties);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("properties");

                (bool wasUpdatedProperties, Schema.SchemaProperties? updatedProperties) = await this.VisitProperties(schema.Properties).ConfigureAwait(false);
                if (wasUpdatedProperties)
                {
                    schema = schema.WithProperties(updatedProperties);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("propertyNames");

                (bool wasUpdatedPropertyNames, Schema.SchemaOrReference? updatedPropertyNames) = await this.VisitPropertyNames(schema.PropertyNames).ConfigureAwait(false);
                if (wasUpdatedPropertyNames)
                {
                    schema = schema.WithPropertyNames(updatedPropertyNames);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("required");

                (bool wasUpdatedRequired, Schema.ValidatedArrayOfJsonString? updatedRequired) = await this.VisitRequired(schema.Required).ConfigureAwait(false);
                if (wasUpdatedRequired)
                {
                    schema = schema.WithRequired(updatedRequired);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("type");

                (bool wasUpdatedType, Schema.TypeEnum? updatedType) = await this.VisitType(schema.Type).ConfigureAwait(false);
                if (wasUpdatedType)
                {
                    schema = schema.WithType(updatedType);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("uniqueItems");

                (bool wasUpdatedUniqueItems, JsonBoolean? updatedUniqueItems) = await this.VisitUniqueItems(schema.UniqueItems).ConfigureAwait(false);
                if (wasUpdatedUniqueItems)
                {
                    schema = schema.WithUniqueItems(updatedUniqueItems);
                    wasUpdated = true;
                }

                this.PopPointerElement();
                this.PopPointerElement();

                updatedSchema = schema;
            }

            return (wasUpdated, updatedSchema);
        }
    }
}
