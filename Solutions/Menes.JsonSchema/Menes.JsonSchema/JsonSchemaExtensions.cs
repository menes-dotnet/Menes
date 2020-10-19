// <copyright file="JsonSchemaExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    /// <summary>
    /// Extension methods for <see cref="Schema"/>.
    /// </summary>
    public static class JsonSchemaExtensions
    {
        /// <summary>
        /// Gets a value indicating whether the schema has validations.
        /// </summary>
        /// <param name="schema">The schema to test.</param>
        /// <returns><c>True</c> if the schema has any non-structural validations.</returns>
        public static bool IsValidated(this Schema schema)
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
    }
}
