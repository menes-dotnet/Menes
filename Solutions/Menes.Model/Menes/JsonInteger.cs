// <copyright file="JsonInteger.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with ints in situ, whether they
    /// originated from JSON or are a .NET int.
    /// </summary>
    public readonly struct JsonInteger : IJsonValue, IEquatable<JsonInteger>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonInteger> FromJsonElement = e => new JsonInteger(e);

        /// <summary>
        /// A <see cref="JsonInteger"/> representing a null value.
        /// </summary>
        public static readonly JsonInteger Null = new JsonInteger(default(JsonElement));

        private readonly int? clrInt;
        private readonly long? clrLong;

        /// <summary>
        /// Creates a <see cref="JsonInteger"/> wrapper around a .NET int.
        /// </summary>
        /// <param name="clrInteger">The .NET int.</param>
        public JsonInteger(int clrInteger)
        {
            this.clrInt = clrInteger;
            this.clrLong = null;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonInteger"/> wrapper around a .NET long.
        /// </summary>
        /// <param name="clrInteger">The .NET long.</param>
        public JsonInteger(long clrInteger)
        {
            this.clrInt = null;
            this.clrLong = clrInteger;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonInteger"/> wrapper around a JsonElement.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the int value to represent.
        /// </param>
        public JsonInteger(JsonElement jsonElement)
        {
            this.clrInt = null;
            this.clrLong = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrInt is null && this.clrLong is null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this int as a nullable value type.
        /// </summary>
        public JsonInteger? AsOptional => this.IsNull ? default(JsonInteger?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="JsonNumber"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(JsonInteger value)
        {
            if (value.clrInt is int int32)
            {
                return new JsonNumber(int32);
            }
            else if (value.clrLong is long int64)
            {
                return new JsonNumber(int64);
            }
            else
            {
                return new JsonNumber(value.JsonElement);
            }
        }

        /// <summary>
        /// Explicit conversion to <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator int(JsonInteger value) => value.CreateOrGetClrInt();

        /// <summary>
        /// Explicit conversion to <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator long(JsonInteger value) => value.CreateOrGetClrLong();

        /// <summary>
        /// Implicit conversion from an <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInteger(int value) => new JsonInteger(value);

        /// <summary>
        /// Implicit conversion from an <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInteger(long value) => new JsonInteger(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonInteger item) => JsonAny.From(item);

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
        /// Gets a <see cref="JsonInteger"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonInteger"/> or null.</returns>
        public static JsonInteger FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonInteger(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonInteger"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonInteger"/> or null.</returns>
        public static JsonInteger FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonInteger(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonInteger"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonInteger"/> or null.</returns>
        public static JsonInteger FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonInteger(property)
                : Null;

        /// <summary>
        /// Gets the number's value as a .NET int.
        /// </summary>
        /// <param name="result">The value as an int.</param>
        /// <returns><c>True</c> if the value could be returned as an int.</returns>
        public bool TryGetInt32([NotNullWhen(true)] out int result)
        {
            if (this.clrInt is int clrInt)
            {
                result = clrInt;
                return true;
            }

            if (this.clrLong is long clrLong && clrLong <= int.MaxValue && clrLong >= int.MinValue)
            {
                result = (int)clrLong;
                return true;
            }

            return this.JsonElement.TryGetInt32(out result);
        }

        /// <summary>
        /// Gets the number's value as a .NET long.
        /// </summary>
        /// <param name="result">The value as an long.</param>
        /// <returns><c>True</c> if the value could be returned as an long.</returns>
        public bool TryGetInt64([NotNullWhen(true)] out long result)
        {
            if (this.clrLong is long clrLong)
            {
                result = clrLong;
                return true;
            }

            if (this.clrInt is int clrInt)
            {
                result = clrInt;
                return true;
            }

            return this.JsonElement.TryGetInt64(out result);
        }

        /// <summary>
        /// Gets the number's value as a .NET int.
        /// </summary>
        /// <returns>The value as a <see cref="int"/>.</returns>
        public int CreateOrGetClrInt() => this.clrInt ?? this.JsonElement.GetInt32();

        /// <summary>
        /// Gets the number's value as a .NET long.
        /// </summary>
        /// <returns>The value as a <see cref="long"/>.</returns>
        public long CreateOrGetClrLong() => this.clrLong ?? this.JsonElement.GetInt64();

        /// <summary>
        /// Writes the int value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the int.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrInt is int int32)
            {
                writer.WriteNumberValue(int32);
            }
            else if (this.clrLong is long int64)
            {
                writer.WriteNumberValue(int64);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            if (this.clrInt is int int32)
            {
                return int32.ToString();
            }

            if (this.clrLong is long int64)
            {
                return int64.ToString();
            }

            if (this.HasJsonElement)
            {
                return this.JsonElement.GetString();
            }

            return null;
        }

        /// <inheritdoc/>
        public bool Equals(JsonInteger other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.TryGetInt64(out long lhs) && other.TryGetInt64(out long rhs))
            {
                return lhs == rhs;
            }

            if (this.TryGetInt32(out int lhs32) && other.TryGetInt32(out int rhs32))
            {
                return lhs32 == rhs32;
            }

            return false;
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError("6.1.1. type: the element is not convertible from the given type");
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
        public ValidationContext ValidateAsNumber(in ValidationContext validationContext, JsonInteger? multipleOf = null, JsonInteger? maximum = null, JsonInteger? exclusiveMaximum = null, JsonInteger? minimum = null, JsonInteger? exclusiveMinimum = null, in ImmutableArray<JsonInteger>? enumeration = null, in JsonInteger? constValue = null)
        {
            ValidationContext context = validationContext;
            if (multipleOf is JsonInteger mo && !this.IsMultipleOf(mo))
            {
                context = context.WithError($"6.2.1 multipleOf: The value should have been a multiple of '{mo}', but was '{this}'.");
            }

            if (maximum is JsonInteger max && this.IsGreaterThan(max))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been <= '{max}', but was '{this}'");
            }

            if (exclusiveMaximum is JsonInteger exMax && this.IsGreaterThanOrEqualTo(exMax))
            {
                context = context.WithError($"6.2.3 maximum: The value should have been < '{exMax}', but was '{this}'");
            }

            if (minimum is JsonInteger min && this.IsLessThan(min))
            {
                context = context.WithError($"6.2.4 minimum: The value should have been >= '{min}', but was '{this}'");
            }

            if (exclusiveMinimum is JsonInteger exMin && this.IsLessThanOrEqualTo(exMin))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been > '{exMin}', but was '{this}'");
            }

            if (enumeration is ImmutableArray<JsonInteger> values)
            {
                context = Validation.ValidateEnum(context, this, values);
            }

            if (constValue is JsonInteger cv)
            {
                context = Validation.ValidateConst(context, this, cv);
            }

            return context;
        }

        /// <summary>
        /// Determines if the number is a multiple of another number.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns><c>True</c> if this number is a multiple of the other number.</returns>
        public bool IsMultipleOf(JsonInteger other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.TryGetInt64(out long lhs) && other.TryGetInt64(out long rhs))
            {
                return lhs % rhs == 0;
            }

            if (this.TryGetInt32(out int lhs32) && other.TryGetInt32(out int rhs32))
            {
                return lhs32 % rhs32 == 0;
            }

            return false;
        }

        /// <summary>
        /// Determines if the number is greater than another number.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns><c>True</c> if this number is greater than the other number.</returns>
        public bool IsGreaterThan(JsonInteger other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.TryGetInt64(out long lhs) && other.TryGetInt64(out long rhs))
            {
                return lhs > rhs;
            }

            if (this.TryGetInt32(out int lhs32) && other.TryGetInt32(out int rhs32))
            {
                return lhs32 > rhs32;
            }

            return false;
        }

        /// <summary>
        /// Determines if the number is greater than or equal to another number.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns><c>True</c> if this number is greater than or equal to the other number.</returns>
        public bool IsGreaterThanOrEqualTo(JsonInteger other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.TryGetInt64(out long lhs) && other.TryGetInt64(out long rhs))
            {
                return lhs >= rhs;
            }

            if (this.TryGetInt32(out int lhs32) && other.TryGetInt32(out int rhs32))
            {
                return lhs32 >= rhs32;
            }

            return false;
        }

        /// <summary>
        /// Determines if the number is less than another number.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns><c>True</c> if this number is less than the other number.</returns>
        public bool IsLessThan(JsonInteger other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.TryGetInt64(out long lhs) && other.TryGetInt64(out long rhs))
            {
                return lhs < rhs;
            }

            if (this.TryGetInt32(out int lhs32) && other.TryGetInt32(out int rhs32))
            {
                return lhs32 < rhs32;
            }

            return false;
        }

        /// <summary>
        /// Determines if the number is less than or equal to another number.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns><c>True</c> if this number is less than or equal to the other number.</returns>
        public bool IsLessThanOrEqualTo(JsonInteger other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.TryGetInt64(out long lhs) && other.TryGetInt64(out long rhs))
            {
                return lhs <= rhs;
            }

            if (this.TryGetInt32(out int lhs32) && other.TryGetInt32(out int rhs32))
            {
                return lhs32 <= rhs32;
            }

            return false;
        }
    }
}
