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
                schema.MaxContains.HasValue || schema.Maximum.HasValue || schema.MaxItems.HasValue ||
                schema.MaxLength.HasValue || schema.MaxProperties.HasValue || schema.MinContains.HasValue ||
                schema.Minimum.HasValue || schema.MinItems.HasValue || schema.MinLength.HasValue ||
                schema.MinProperties.HasValue || schema.MultipleOf.HasValue || schema.Not.HasValue ||
                schema.OneOf.HasValue || schema.Pattern.HasValue || schema.PatternProperties.HasValue ||
                schema.Properties.HasValue || schema.PropertyNames.HasValue || schema.Required.HasValue ||
                schema.Then.HasValue || schema.UniqueItems.HasValue;
        }

        /// <summary>
        /// Returns true if this represents a value-like entity, as opposed to an object- or array- like entity.
        /// </summary>
        /// <param name="schema">The schema to test.</param>
        /// <returns><c>True</c> is the entity is a string, integer, number, or boolean.</returns>
        public static bool IsValueType(this JsonSchema schema)
        {
            return !(schema.Type is JsonSchema.TypeEnum type) || type == "integer" || type == "string" || type == "boolean" || type == "number";
        }

        /// <summary>
        /// Returns true if this represents a object-like entity, as opposed to an value- or array- like entity.
        /// </summary>
        /// <param name="schema">The schema to test.</param>
        /// <returns><c>True</c> is the entity is an object.</returns>
        public static bool IsObjectType(this JsonSchema schema)
        {
            return (schema.Type is JsonSchema.TypeEnum type) && type == "object";
        }

        /// <summary>
        /// Returns true if this represents a array-like entity, as opposed to an value- or object- like entity.
        /// </summary>
        /// <param name="schema">The schema to test.</param>
        /// <returns><c>True</c> is the entity is an object.</returns>
        public static bool IsArrayType(this JsonSchema schema)
        {
            return (schema.Type is JsonSchema.TypeEnum type) && type == "array";
        }
    }
}
