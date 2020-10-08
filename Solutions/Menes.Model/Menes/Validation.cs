// <copyright file="Validation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Valdation helpers.
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Validate a json value against an enumeration.
        /// </summary>
        /// <typeparam name="TValue">The type of the value against which to validate.</typeparam>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="value">The value to validate.</param>
        /// <param name="enumeration">The array of values against which to validate.</param>
        /// <returns>The validation context, updated with any validation errors.</returns>
        public static ValidationContext ValidateEnum<TValue>(in ValidationContext validationContext, in TValue value, in ImmutableArray<TValue> enumeration)
        {
            EqualityComparer<TValue> comparer = EqualityComparer<TValue>.Default;
            foreach (TValue item in enumeration)
            {
                if (comparer.Equals(value, item))
                {
                    return validationContext;
                }
            }

            return validationContext.WithError($"6.1.2. enum: Expected the value to match one of '{string.Join(", ", enumeration)}' but was '{value}'");
        }

        /// <summary>
        /// Validate a json value against a constant value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value against which to validate.</typeparam>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="value">The value to validate.</param>
        /// <param name="item">The constant value against which to validate.</param>
        /// <returns>The validation context, updated with any validation errors.</returns>
        public static ValidationContext ValidateConst<TValue>(in ValidationContext validationContext, in TValue value, TValue item)
        {
            EqualityComparer<TValue> comparer = EqualityComparer<TValue>.Default;

            if (comparer.Equals(value, item))
            {
                return validationContext;
            }

            return validationContext.WithError($"6.1.3. const: Expected the match '{item}' but was '{value}'");
        }

        /// <summary>
        /// Provides the string validations.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="value">The string value to validate.</param>
        /// <param name="maxLength">The maximum length of the string representation.</param>
        /// <param name="minLength">The minimum length of the string representation.</param>
        /// <param name="pattern">The pattern to which the string must conform.</param>
        /// <param name="enumeration">The values which the string must match.</param>
        /// <param name="constValue">A constant value which the string must match.</param>
        /// <returns>The validation context updated to reflect the results of the validation.</returns>
        /// <remarks>These are rolled up into a single method to ensure string conversion occurs only once.</remarks>
        public static ValidationContext ValidateString(in ValidationContext validationContext, string value, int? maxLength, int? minLength, Regex? pattern, in ImmutableArray<string>? enumeration, string? constValue)
        {
            ValidationContext context = validationContext;
            if (maxLength is int maxl && value.Length > maxl)
            {
                context = context.WithError($"6.3.1. maxLength: The string should have had a maximum length of {maxl} but was length {value.Length}.");
            }

            if (minLength is int minl && value.Length < minl)
            {
                context = context.WithError($"6.3.2. minLength: The string should have had a minimum length of {minl} but was length {value.Length}.");
            }

            if (pattern is Regex p && !p.IsMatch(value))
            {
                context = context.WithError($"6.3.3. pattern: The string should match {p} but was {value}.");
            }

            if (enumeration is ImmutableArray<string> values)
            {
                context = ValidateEnum(context, value, values);
            }

            if (constValue is string cv)
            {
                context = ValidateConst(context, value, cv);
            }

            return context;
        }
    }
}
