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
    public static partial class Validation
    {
        /// <summary>
        /// Validate an <see cref="IJsonObject"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the <see cref="IJsonObject"/> to validate.</typeparam>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="value">The object to validate.</param>
        /// <param name="maxProperties">The maximum number of properties on the object.</param>
        /// <param name="minProperties">The minimum number of properties on the object.</param>
        /// <returns>The validation context, updated with any validation errors.</returns>
        public static ValidationContext ValidateObject<TObject>(in ValidationContext validationContext, in TObject value, int? maxProperties = null, int? minProperties = null)
            where TObject : struct, IJsonObject
        {
            ValidationContext context = validationContext;
            int propertiesCount = value.PropertiesCount;

            if (maxProperties is int max && propertiesCount > max)
            {
                context = context.WithError($"6.5.1. maxProperties: The object should have had a maximum number of properties of '{max}', but actually had '{propertiesCount}'");
            }

            if (minProperties is int min && propertiesCount < min)
            {
                context = context.WithError($"6.5.2. minProperties: The object should have had a minimum number of properties of '{min}', but actually had '{propertiesCount}'");
            }

            return context;
        }

        /// <summary>
        /// Validate a json value against an enumeration.
        /// </summary>
        /// <typeparam name="TValue">The type of the value against which to validate.</typeparam>
        /// <typeparam name="TEnumerable">The enumerable of items to be compared.</typeparam>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="value">The value to validate.</param>
        /// <param name="enumeration">The array of values against which to validate.</param>
        /// <returns>The validation context, updated with any validation errors.</returns>
        public static ValidationContext ValidateEnum<TValue, TEnumerable>(in ValidationContext validationContext, in TValue value, in TEnumerable enumeration)
            where TEnumerable : IEnumerable<TValue>
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
        public static ValidationContext ValidateString(in ValidationContext validationContext, in string? value, int? maxLength, int? minLength, Regex? pattern, in ImmutableArray<string>? enumeration, string? constValue)
        {
            if (value is null)
            {
                return validationContext;
            }

            ValidationContext context = validationContext;
            int length = value.Length;
            if (maxLength is int maxl && length > maxl)
            {
                context = context.WithError($"6.3.1. maxLength: The string should have had a maximum length of {maxl} but was length {length}.");
            }

            if (minLength is int minl && length < minl)
            {
                context = context.WithError($"6.3.2. minLength: The string should have had a minimum length of {minl} but was length {length}.");
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

        /// <summary>
        /// Validate the given item, appending the specified path
        /// and restoring the path once the results have been returned.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to validate.</typeparam>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="value">The item to validate.</param>
        /// <param name="propertyPathToAppend">The path to append for the item.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateProperty<TItem>(in ValidationContext validationContext, in TItem value, string propertyPathToAppend)
            where TItem : struct, IJsonValue
        {
            return value.Validate(validationContext.WithPath(validationContext.Path + propertyPathToAppend)).WithPath(validationContext.Path);
        }

        /// <summary>
        /// Validate the given item, appending the specified path
        /// and restoring the path once the results have been returned.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to validate.</typeparam>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="value">The item to validate.</param>
        /// <param name="propertyPathToAppend">The path to append to the context for the item.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateRequiredProperty<TItem>(in ValidationContext validationContext, in TItem value, string propertyPathToAppend)
            where TItem : struct, IJsonValue
        {
            ValidationContext context = validationContext.WithPath(validationContext.Path + propertyPathToAppend);
            if (value.IsNull)
            {
                context = context.WithError($"6.5.3. required: The property was not present.");
            }

            return value.Validate(context).WithPath(validationContext.Path);
        }

        /// <summary>
        /// Validates that the value is not the given schema.
        /// </summary>
        /// <typeparam name="TItem">The type of the value.</typeparam>
        /// <typeparam name="TNot">The type of the schema to validate against.</typeparam>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="value">The value to validate.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateNot<TItem, TNot>(in ValidationContext validationContext, in TItem value)
            where TItem : struct, IJsonValue
            where TNot : struct, IJsonValue
        {
            TNot notValue = JsonAny.From(value).As<TNot>();

            if (notValue.Validate(ValidationContext.Root).IsValid)
            {
                return validationContext.WithError($"core 9.2.1.4. not: the value should not have validated against the type '{typeof(TNot).FullName}'");
            }

            return validationContext;
        }
    }
}
