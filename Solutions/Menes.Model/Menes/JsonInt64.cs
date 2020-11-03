// <copyright file="JsonInt64.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with longs in situ, whether they
    /// originated from JSON or are a .NET long.
    /// </summary>
    public readonly struct JsonInt64 : IJsonValue, IEquatable<JsonInt64>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonInt64> FromJsonElement = e => new JsonInt64(e);

        /// <summary>
        /// A <see cref="JsonInt64"/> representing a null value.
        /// </summary>
        public static readonly JsonInt64 Null = new JsonInt64(default(JsonElement));

        private readonly long? clrInt64;

        /// <summary>
        /// Creates a <see cref="JsonInt64"/> wrapper around a .NET long.
        /// </summary>
        /// <param name="clrInt64">The .NET long.</param>
        public JsonInt64(long clrInt64)
        {
            this.clrInt64 = clrInt64;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonInt64"/> wrapper around a .NET long.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the long value to represent.
        /// </param>
        public JsonInt64(JsonElement jsonElement)
        {
            this.clrInt64 = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrInt64 == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this long as a nullable value type.
        /// </summary>
        public JsonInt64? AsOptional => this.IsNull ? default(JsonInt64?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator long(JsonInt64 value) => value.CreateOrGetClrInt64();

        /// <summary>
        /// Implicit conversion from <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInt64(long value) => new JsonInt64(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonInt64 item) => JsonAny.From(item);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement)
        {
            return jsonElement.ValueKind == JsonValueKind.Number || jsonElement.ValueKind == JsonValueKind.Null;
        }

        /// <summary>
        /// Gets a <see cref="JsonInt64"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonInt64"/> or null.</returns>
        public static JsonInt64 FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonInt64(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonInt64"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonInt64"/> or null.</returns>
        public static JsonInt64 FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonInt64(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonInt64"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonInt64"/> or null.</returns>
        public static JsonInt64 FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonInt64(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets the long's value as a .NET long.
        /// </summary>
        /// <returns>The long value as a <see cref="long"/>.</returns>
        public long CreateOrGetClrInt64() => this.clrInt64 ?? this.JsonElement.GetInt64();

        /// <summary>
        /// Writes the long value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the long.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrInt64 is long int64)
            {
                writer.WriteNumberValue(int64);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.IsNull ? string.Empty : this.CreateOrGetClrInt64().ToString();
        }

        /// <inheritdoc/>
        public bool Equals(JsonInt64 other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            return this.CreateOrGetClrInt64().Equals(other.CreateOrGetClrInt64());
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {JsonValueKind.Number}");
            }

            if (this.HasJsonElement && this.JsonElement.ValueKind == JsonValueKind.Number && !this.JsonElement.TryGetInt64(out _))
            {
                return validationContext.WithError("6.1.1. type: the element is not convertible to an int64.");
            }

            return validationContext;
        }

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
        public ValidationContext ValidateAsNumber(in ValidationContext validationContext, long? multipleOf = null, long? maximum = null, long? exclusiveMaximum = null, long? minimum = null, long? exclusiveMinimum = null, in ImmutableArray<long>? enumeration = null, in long? constValue = null)
        {
            ValidationContext schemaValidation = this.Validate(ValidationContext.Root);
            if (!schemaValidation.IsValid)
            {
                return validationContext;
            }

            ValidationContext context = validationContext;

            long value = this.CreateOrGetClrInt64();
            if (multipleOf is long mo && (value % mo != 0))
            {
                context = context.WithError($"6.2.1 multipleOf: The value should have been a multiple of '{mo}', but was '{value}' with remainder '{value % mo}'");
            }

            if (maximum is long max && (value > max))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been <= '{max}', but was '{value}'");
            }

            if (exclusiveMaximum is long exMax && (value >= exMax))
            {
                context = context.WithError($"6.2.3 maximum: The value should have been < '{exMax}', but was '{value}'");
            }

            if (minimum is long min && (value < min))
            {
                context = context.WithError($"6.2.4 minimum: The value should have been >= '{min}', but was '{value}'");
            }

            if (exclusiveMinimum is long exMin && (value <= exMin))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been > '{exMin}', but was '{value}'");
            }

            if (enumeration is ImmutableArray<long> values)
            {
                context = Validation.ValidateEnum(context, value, values);
            }

            if (constValue is long cv)
            {
                context = Validation.ValidateConst(context, value, cv);
            }

            return context;
        }
    }
}
