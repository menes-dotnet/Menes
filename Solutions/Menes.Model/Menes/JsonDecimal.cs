// <copyright file="JsonDecimal.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with decimals in situ, whether they
    /// originated from JSON or are a .NET decimal.
    /// </summary>
    public readonly struct JsonDecimal : IJsonValue, IEquatable<JsonDecimal>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonDecimal> FromJsonElement = e => new JsonDecimal(e);

        /// <summary>
        /// A <see cref="JsonDecimal"/> representing a null value.
        /// </summary>
        public static readonly JsonDecimal Null = new JsonDecimal(default(JsonElement));

        private readonly decimal? clrDecimal;

        /// <summary>
        /// Creates a <see cref="JsonDecimal"/> wrapper around a .NET decimal.
        /// </summary>
        /// <param name="clrDecimal">The .NET decimal.</param>
        public JsonDecimal(decimal clrDecimal)
        {
            this.clrDecimal = clrDecimal;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonDecimal"/> wrapper around a .NET decimal.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the decimal value to represent.
        /// </param>
        public JsonDecimal(JsonElement jsonElement)
        {
            this.clrDecimal = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrDecimal == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this decimal as a nullable value type.
        /// </summary>
        public JsonDecimal? AsOptional => this.IsNull ? default(JsonDecimal?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator decimal(JsonDecimal value) => value.CreateOrGetClrDecimal();

        /// <summary>
        /// Implicit conversion from <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDecimal(decimal value) => new JsonDecimal(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonDecimal item) => JsonAny.From(item);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static bool IsConvertibleFrom(JsonElement jsonElement)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            return jsonElement.ValueKind == JsonValueKind.Number || jsonElement.ValueKind == JsonValueKind.Null;
        }

        /// <summary>
        /// Gets a <see cref="JsonDecimal"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDecimal"/> or null.</returns>
        public static JsonDecimal FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonDecimal(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDecimal"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDecimal"/> or null.</returns>
        public static JsonDecimal FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonDecimal(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDecimal"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonDecimal"/> or null.</returns>
        public static JsonDecimal FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonDecimal(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets the decimal's value as a .NET decimal.
        /// </summary>
        /// <returns>The decimal value as a <see cref="decimal"/>.</returns>
        public decimal CreateOrGetClrDecimal() => this.clrDecimal ?? this.JsonElement.GetDecimal();

        /// <summary>
        /// Provides the numeric validations.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="multipleOf">A value which, when divided into the value, produces a remainder of zero.</param>
        /// <param name="maximum">The value is less than or equal to the maximum value.</param>
        /// <param name="exclusiveMaximum">The value is less than the exclusive maximum value.</param>
        /// <param name="minimum">The value is greater than or equal to the minimum value.</param>
        /// <param name="exclusiveMinimum">The value is greater than the exclusive minimum value.</param>
        /// <param name="enumeration">The value must equal one of the values in the enumeration.</param>
        /// <param name="constValue">The value must equal the constant value.</param>
        /// <returns>The validation context updated to reflect the results of the validation.</returns>
        /// <remarks>These are rolled up into a single method to ensure string conversion occurs only once.</remarks>
        public ValidationContext ValidateAsNumber(in ValidationContext validationContext, decimal? multipleOf = null, decimal? maximum = null, decimal? exclusiveMaximum = null, decimal? minimum = null, decimal? exclusiveMinimum = null, in ImmutableArray<decimal>? enumeration = null, in decimal? constValue = null)
        {
            ValidationContext schemaValidation = this.Validate(ValidationContext.Root);
            if (!schemaValidation.IsValid)
            {
                return validationContext;
            }

            ValidationContext context = validationContext;

            decimal value = this.CreateOrGetClrDecimal();

            if (multipleOf is decimal mo && (value % mo != 0))
            {
                context = context.WithError($"6.2.1 multipleOf: The value should have been a multiple of '{mo}', but was '{value}' with remainder '{value % mo}'");
            }

            if (maximum is decimal max && (value > max))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been <= '{max}', but was '{value}'");
            }

            if (exclusiveMaximum is decimal exMax && (value >= exMax))
            {
                context = context.WithError($"6.2.3 maximum: The value should have been < '{exMax}', but was '{value}'");
            }

            if (minimum is decimal min && (value < min))
            {
                context = context.WithError($"6.2.4 minimum: The value should have been >= '{min}', but was '{value}'");
            }

            if (exclusiveMinimum is decimal exMin && (value <= exMin))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been > '{exMin}', but was '{value}'");
            }

            if (enumeration is ImmutableArray<decimal> values)
            {
                context = Validation.ValidateEnum(context, value, values);
            }

            if (constValue is decimal cv)
            {
                context = Validation.ValidateConst(context, value, cv);
            }

            return context;
        }

        /// <summary>
        /// Writes the decimal value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the decimal.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrDecimal is decimal single)
            {
                writer.WriteNumberValue(single);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.IsNull ? string.Empty : this.CreateOrGetClrDecimal().ToString();
        }

        /// <inheritdoc/>
        public bool Equals(JsonDecimal other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            return this.CreateOrGetClrDecimal().Equals(other.CreateOrGetClrDecimal());
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {JsonValueKind.Number}");
            }

            if (this.HasJsonElement && this.JsonElement.ValueKind == JsonValueKind.Number)
            {
                if (!this.JsonElement.TryGetDecimal(out _))
                {
                    return validationContext.WithError($"6.1.1. type: the element is not convertible to a decimal.");
                }
            }

            return validationContext;
        }
    }
}
