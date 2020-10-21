// <copyright file="SchemaVisitor.Schema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        private readonly HashSet<string> schemasBeingVisited = new HashSet<string>();

        /// <summary>
        /// Visit a schema node.
        /// </summary>
        /// <param name="schemaToVisit">The schema to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema"/>.</returns>
        public virtual async ValueTask<(bool, JsonSchema?)> VisitSchema(JsonSchema? schemaToVisit)
        {
            JsonSchema? updatedSchema = schemaToVisit;
            bool wasUpdated = false;
            if (updatedSchema is JsonSchema schema)
            {
                string? pushedId = null;
                if (schema.Id is JsonString id)
                {
                    // Prevent it recursing into a schema we are currently visiting.
                    if (this.schemasBeingVisited.Contains(id))
                    {
                        return (false, schemaToVisit);
                    }

                    pushedId = id;
                    this.schemasBeingVisited.Add(id);
                }

                (bool wasUpdatedStart, JsonSchema updatedSchemaStart) = await this.BeginVisitSchema(schema).ConfigureAwait(false);

                this.PushPointerElement("#");

                if (wasUpdatedStart)
                {
                    schema = updatedSchemaStart;
                    wasUpdated = true;
                }

                this.PushPointerElement("additionalProperties");

                (bool wasUpdatedAdditionalProperties, JsonSchema.SchemaAdditionalProperties? updatedSchemaAdditionalProperties) = await this.VisitAdditionalProperties(schema.AdditionalProperties).ConfigureAwait(false);
                if (wasUpdatedAdditionalProperties)
                {
                    schema = schema.WithAdditionalProperties(updatedSchemaAdditionalProperties);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("allOf");

                (bool wasUpdatedAllOf, JsonSchema.ValidatedArrayOfSchemaOrReference? updatedAllOf) = await this.VisitAllOf(schema.AllOf).ConfigureAwait(false);
                if (wasUpdatedAllOf)
                {
                    schema = schema.WithAllOf(updatedAllOf);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("anyOf");

                (bool wasUpdatedAnyOf, JsonSchema.ValidatedArrayOfSchemaOrReference? updatedAnyOf) = await this.VisitAnyOf(schema.AnyOf).ConfigureAwait(false);
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

                (bool wasUpdatedContains, JsonSchema.SchemaOrReference? updatedContains) = await this.VisitContains(schema.Contains).ConfigureAwait(false);
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

                (bool wasUpdatedItems, JsonSchema.SchemaOrReference? updatedItems) = await this.VisitItems(schema.Items).ConfigureAwait(false);
                if (wasUpdatedItems)
                {
                    schema = schema.WithItems(updatedItems);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("maxContains");

                (bool wasUpdatedMaxContains, JsonSchema.NonNegativeInteger? updatedMaxContains) = await this.VisitMaxContains(schema.MaxContains).ConfigureAwait(false);
                if (wasUpdatedMaxContains)
                {
                    schema = schema.WithMaxContains(updatedMaxContains);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("minContains");

                (bool wasUpdatedMinContains, JsonSchema.NonNegativeInteger? updatedMinContains) = await this.VisitMinContains(schema.MaxContains).ConfigureAwait(false);
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

                (bool wasUpdatedIf, JsonSchema.SchemaOrReference? updatedIf) = await this.VisitIf(schema.If).ConfigureAwait(false);
                if (wasUpdatedIf)
                {
                    schema = schema.WithIf(updatedIf);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("then");

                (bool wasUpdatedThen, JsonSchema.SchemaOrReference? updatedThen) = await this.VisitThen(schema.Then).ConfigureAwait(false);
                if (wasUpdatedThen)
                {
                    schema = schema.WithThen(updatedThen);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("else");

                (bool wasUpdatedElse, JsonSchema.SchemaOrReference? updatedElse) = await this.VisitElse(schema.Else).ConfigureAwait(false);
                if (wasUpdatedElse)
                {
                    schema = schema.WithElse(updatedElse);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("dependentSchemas");

                (bool wasUpdatedDependentSchemas, JsonSchema.SchemaProperties? updatedDependentSchemas) = await this.VisitDependentSchemas(schema.DependentSchemas).ConfigureAwait(false);
                if (wasUpdatedDependentSchemas)
                {
                    schema = schema.WithDependentSchemas(updatedDependentSchemas);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("maxItems");

                (bool wasUpdatedMaxItems, JsonSchema.NonNegativeInteger? updatedMaxItems) = await this.VisitMaxItems(schema.MaxItems).ConfigureAwait(false);
                if (wasUpdatedMaxItems)
                {
                    schema = schema.WithMaxItems(updatedMaxItems);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("minItems");

                (bool wasUpdatedMinItems, JsonSchema.NonNegativeInteger? updatedMinItems) = await this.VisitMinItems(schema.MinItems).ConfigureAwait(false);
                if (wasUpdatedMinItems)
                {
                    schema = schema.WithMinItems(updatedMinItems);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("maxLength");

                (bool wasUpdatedMaxLength, JsonSchema.NonNegativeInteger? updatedMaxLength) = await this.VisitMaxLength(schema.MaxLength).ConfigureAwait(false);
                if (wasUpdatedMaxLength)
                {
                    schema = schema.WithMaxLength(updatedMaxLength);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("minLength");

                (bool wasUpdatedMinLength, JsonSchema.NonNegativeInteger? updatedMinLength) = await this.VisitMinLength(schema.MinLength).ConfigureAwait(false);
                if (wasUpdatedMinLength)
                {
                    schema = schema.WithMinLength(updatedMinLength);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("maxProperties");

                (bool wasUpdatedMaxProperties, JsonSchema.NonNegativeInteger? updatedMaxProperties) = await this.VisitMaxProperties(schema.MaxProperties).ConfigureAwait(false);
                if (wasUpdatedMaxProperties)
                {
                    schema = schema.WithMaxProperties(updatedMaxProperties);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("minProperties");

                (bool wasUpdatedMinProperties, JsonSchema.NonNegativeInteger? updatedMinProperties) = await this.VisitMinProperties(schema.MinProperties).ConfigureAwait(false);
                if (wasUpdatedMinProperties)
                {
                    schema = schema.WithMinProperties(updatedMinProperties);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("multipleOf");

                (bool wasUpdatedMultipleOf, JsonSchema.PositiveNumber? updatedMultipleOf) = await this.VisitMultipleOf(schema.MultipleOf).ConfigureAwait(false);
                if (wasUpdatedMultipleOf)
                {
                    schema = schema.WithMultipleOf(updatedMultipleOf);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("not");

                (bool wasUpdatedNot, JsonSchema.SchemaOrReference? updatedNot) = await this.VisitNot(schema.Not).ConfigureAwait(false);
                if (wasUpdatedNot)
                {
                    schema = schema.WithNot(updatedNot);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("oneOf");

                (bool wasUpdatedOneOf, JsonSchema.ValidatedArrayOfSchemaOrReference? updatedOneOf) = await this.VisitOneOf(schema.OneOf).ConfigureAwait(false);
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

                (bool wasUpdatedPatternProperties, JsonSchema.SchemaProperties? updatedPatternProperties) = await this.VisitPatternProperties(schema.PatternProperties).ConfigureAwait(false);
                if (wasUpdatedPatternProperties)
                {
                    schema = schema.WithPatternProperties(updatedPatternProperties);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("properties");

                (bool wasUpdatedProperties, JsonSchema.SchemaProperties? updatedProperties) = await this.VisitProperties(schema.Properties).ConfigureAwait(false);
                if (wasUpdatedProperties)
                {
                    schema = schema.WithProperties(updatedProperties);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("propertyNames");

                (bool wasUpdatedPropertyNames, JsonSchema.SchemaOrReference? updatedPropertyNames) = await this.VisitPropertyNames(schema.PropertyNames).ConfigureAwait(false);
                if (wasUpdatedPropertyNames)
                {
                    schema = schema.WithPropertyNames(updatedPropertyNames);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("required");

                (bool wasUpdatedRequired, JsonSchema.ValidatedArrayOfJsonString? updatedRequired) = await this.VisitRequired(schema.Required).ConfigureAwait(false);
                if (wasUpdatedRequired)
                {
                    schema = schema.WithRequired(updatedRequired);
                    wasUpdated = true;
                }

                this.PopPointerElement();

                this.PushPointerElement("type");

                (bool wasUpdatedType, JsonSchema.TypeEnum? updatedType) = await this.VisitType(schema.Type).ConfigureAwait(false);
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

                (bool wasUpdatedEnd, JsonSchema updatedSchemaEnd) = await this.EndVisitSchema(schema).ConfigureAwait(false);
                if (wasUpdatedEnd)
                {
                    schema = updatedSchemaEnd;
                    wasUpdated = true;
                }

                this.PopPointerElement();

                updatedSchema = schema;

                if (pushedId is string pid)
                {
                    this.schemasBeingVisited.Remove(pid);
                }
            }

            return (wasUpdated, updatedSchema);
        }

        /// <summary>
        /// Override this method to visit the schema before the base visitor has walked the children.
        /// </summary>
        /// <param name="schema">The schema to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema"/>.</returns>
        protected virtual ValueTask<(bool wasUpdated, JsonSchema updatedSchema)> BeginVisitSchema(JsonSchema schema)
        {
            return new ValueTask<(bool wasUpdated, JsonSchema updatedSchema)>((false, schema));
        }

        /// <summary>
        /// Override this method to visit the schema before the base visitor has walked the children.
        /// </summary>
        /// <param name="schema">The schema to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema"/>.</returns>
        protected virtual ValueTask<(bool wasUpdated, JsonSchema updatedSchema)> EndVisitSchema(JsonSchema schema)
        {
            return new ValueTask<(bool wasUpdated, JsonSchema updatedSchema)>((false, schema));
        }
    }
}
