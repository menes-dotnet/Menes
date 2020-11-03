// <copyright file="JsonSchemaExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    /// <summary>
    /// Extension methods for <see cref="JsonSchema"/>.
    /// </summary>
    public static class JsonSchemaExtensions
    {
        /// <summary>
        /// Gets a value indicating whether the schema has validations.
        /// </summary>
        /// <param name="schema">The schema to test.</param>
        /// <returns><c>True</c> if the schema has any non-structural validations.</returns>
        public static bool IsValidated(this JsonSchema schema)
        {
            return
                schema.AllOf.HasValue || schema.AnyOf.HasValue || schema.Const.HasValue ||
                schema.Const.HasValue || schema.Contains.HasValue || schema.DependentSchemas.HasValue ||
                schema.Else.HasValue || schema.Enum.HasValue || schema.ExclusiveMaximum.HasValue ||
                schema.ExclusiveMinimum.HasValue || schema.If.HasValue || schema.Items.HasValue ||
                schema.AdditionalItems.HasValue ||
                schema.MaxContains.HasValue || schema.Maximum.HasValue || schema.MaxItems.HasValue ||
                schema.MaxLength.HasValue || schema.MaxProperties.HasValue || schema.MinContains.HasValue ||
                schema.Minimum.HasValue || schema.MinItems.HasValue || schema.MinLength.HasValue ||
                schema.MinProperties.HasValue || schema.MultipleOf.HasValue || schema.Not.HasValue ||
                schema.OneOf.HasValue || schema.Pattern.HasValue || schema.PatternProperties.HasValue ||
                schema.Properties.HasValue || schema.PropertyNames.HasValue || schema.Required.HasValue ||
                schema.Then.HasValue || schema.UniqueItems.HasValue;
        }

        /// <summary>
        /// Gets a value indicating whether the schema is inferred to be an array.
        /// </summary>
        /// <param name="schema">The schema to test.</param>
        /// <returns><c>True</c> if the schema has any array-like validations.</returns>
        public static bool IsInferredObject(this JsonSchema schema)
        {
            return
                (schema.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum type && type.IsArrayOfTypeEnum) ||
                schema.MaxProperties.HasValue ||
                schema.MinProperties.HasValue ||
                schema.PatternProperties.HasValue ||
                schema.Properties.HasValue || schema.PropertyNames.HasValue || schema.Required.HasValue;
        }

        /// <summary>
        /// Gets a value indicating whether the schema is inferred to be an array.
        /// </summary>
        /// <param name="schema">The schema to test.</param>
        /// <returns><c>True</c> if the schema has any array-like validations.</returns>
        public static bool IsInferredArray(this JsonSchema schema)
        {
            return
                schema.Contains.HasValue ||
                schema.Items.HasValue ||
                schema.AdditionalItems.HasValue ||
                schema.MaxContains.HasValue ||
                schema.MinContains.HasValue ||
                schema.MinItems.HasValue;
        }

        /// <summary>
        /// Returns true if this represents a value-like entity, as opposed to an object- or array- like entity.
        /// </summary>
        /// <param name="schema">The schema to test.</param>
        /// <returns><c>True</c> is the entity is a string, integer, number, or boolean.</returns>
        public static bool IsValueType(this JsonSchema schema)
        {
            return !(schema.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum type && type.IsTypeEnum) || type.AsTypeEnum() == "integer" || type.AsTypeEnum() == "string" || type.AsTypeEnum() == "boolean" || type.AsTypeEnum() == "number" || type.AsTypeEnum() == "null";
        }

        /// <summary>
        /// Returns true if this represents a object-like entity, as opposed to an value- or array- like entity.
        /// </summary>
        /// <param name="schema">The schema to test.</param>
        /// <returns><c>True</c> is the entity is an object.</returns>
        public static bool IsObjectType(this JsonSchema schema)
        {
            return (schema.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum type) && type.IsTypeEnum && type.AsTypeEnum() == "object";
        }

        /// <summary>
        /// Returns true if this represents a array-like entity, as opposed to an value- or object- like entity.
        /// </summary>
        /// <param name="schema">The schema to test.</param>
        /// <returns><c>True</c> is the entity is an object.</returns>
        public static bool IsArrayType(this JsonSchema schema)
        {
            return (schema.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum type) && type.IsTypeEnum && type.AsTypeEnum() == "array";
        }
    }
}
