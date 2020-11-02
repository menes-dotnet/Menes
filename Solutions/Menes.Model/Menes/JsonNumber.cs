// <copyright file="JsonNumber.cs" company="Endjin Limited">
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
    public readonly struct JsonNumber : IJsonValue, IEquatable<JsonNumber>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonNumber> FromJsonElement = e => new JsonNumber(e);

        /// <summary>
        /// A <see cref="JsonNumber"/> representing a null value.
        /// </summary>
        public static readonly JsonNumber Null = new JsonNumber(default(JsonElement));

        private readonly int? clrInt;
        private readonly long? clrLong;
        private readonly double? clrDouble;
        private readonly float? clrFloat;
        private readonly decimal? clrDecimal;

        /// <summary>
        /// Creates a <see cref="JsonNumber"/> wrapper around a .NET int.
        /// </summary>
        /// <param name="clrNumber">The .NET int.</param>
        public JsonNumber(int clrNumber)
        {
            this.clrInt = clrNumber;
            this.clrLong = null;
            this.clrDouble = null;
            this.clrFloat = null;
            this.clrDecimal = null;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonNumber"/> wrapper around a .NET long.
        /// </summary>
        /// <param name="clrNumber">The .NET long.</param>
        public JsonNumber(long clrNumber)
        {
            this.clrInt = null;
            this.clrLong = clrNumber;
            this.clrDouble = null;
            this.clrFloat = null;
            this.clrDecimal = null;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonNumber"/> wrapper around a .NET double.
        /// </summary>
        /// <param name="clrNumber">The .NET double.</param>
        public JsonNumber(double clrNumber)
        {
            this.clrInt = null;
            this.clrLong = null;
            this.clrDouble = clrNumber;
            this.clrFloat = null;
            this.clrDecimal = null;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonNumber"/> wrapper around a .NET float.
        /// </summary>
        /// <param name="clrNumber">The .NET float.</param>
        public JsonNumber(float clrNumber)
        {
            this.clrInt = null;
            this.clrLong = null;
            this.clrDouble = null;
            this.clrFloat = clrNumber;
            this.clrDecimal = null;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonNumber"/> wrapper around a .NET decimal.
        /// </summary>
        /// <param name="clrNumber">The .NET decimal.</param>
        public JsonNumber(decimal clrNumber)
        {
            this.clrInt = null;
            this.clrLong = null;
            this.clrDouble = null;
            this.clrFloat = null;
            this.clrDecimal = clrNumber;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonNumber"/> wrapper around a .NET int.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the int value to represent.
        /// </param>
        public JsonNumber(JsonElement jsonElement)
        {
            this.clrInt = null;
            this.clrLong = null;
            this.clrDouble = null;
            this.clrFloat = null;
            this.clrDecimal = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrInt is null && this.clrLong is null && this.clrDouble is null && this.clrFloat is null && this.clrDecimal is null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this int as a nullable value type.
        /// </summary>
        public JsonNumber? AsOptional => this.IsNull ? default(JsonNumber?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Explicit conversion to <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator int(JsonNumber value) => value.CreateOrGetClrInt();

        /// <summary>
        /// Explicit conversion to <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator long(JsonNumber value) => value.CreateOrGetClrLong();

        /// <summary>
        /// Explicit conversion to <see cref="float"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator float(JsonNumber value) => value.CreateOrGetClrFloat();

        /// <summary>
        /// Explicit conversion to <see cref="double"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator double(JsonNumber value) => value.CreateOrGetClrDouble();

        /// <summary>
        /// Explicit conversion to <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator decimal(JsonNumber value) => value.CreateOrGetClrDecimal();

        /// <summary>
        /// Implicit conversion from an <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(int value) => new JsonNumber(value);

        /// <summary>
        /// Implicit conversion from an <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(long value) => new JsonNumber(value);

        /// <summary>
        /// Implicit conversion from an <see cref="float"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(float value) => new JsonNumber(value);

        /// <summary>
        /// Implicit conversion from an <see cref="double"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(double value) => new JsonNumber(value);

        /// <summary>
        /// Implicit conversion from an <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(decimal value) => new JsonNumber(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonNumber item) => JsonAny.From(item);

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
        /// Gets a <see cref="JsonNumber"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonNumber"/> or null.</returns>
        public static JsonNumber FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonNumber(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonNumber"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonNumber"/> or null.</returns>
        public static JsonNumber FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonNumber(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonNumber"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonNumber"/> or null.</returns>
        public static JsonNumber FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonNumber(property)
                    : Null)
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

            if (this.clrLong is long clrLong)
            {
                result = (int)clrLong;
                return true;
            }

            if (this.clrFloat is float clrFloat)
            {
                result = (int)clrFloat;
                return true;
            }

            if (this.clrDouble is double clrDouble)
            {
                result = (int)clrDouble;
                return true;
            }

            if (this.JsonElement.ValueKind == JsonValueKind.Number)
            {
                return this.JsonElement.TryGetInt32(out result);
            }

            result = default;
            return false;
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

            if (this.clrFloat is float clrFloat)
            {
                result = (long)clrFloat;
                return true;
            }

            if (this.clrDouble is double clrDouble)
            {
                result = (long)clrDouble;
                return true;
            }

            if (this.JsonElement.ValueKind == JsonValueKind.Number)
            {
                return this.JsonElement.TryGetInt64(out result);
            }

            result = default;
            return false;
        }

        /// <summary>
        /// Gets the number's value as a .NET float.
        /// </summary>
        /// <param name="result">The value as a float.</param>
        /// <returns><c>True</c> if the value could be returned as float.</returns>
        public bool TryGetSingle([NotNullWhen(true)] out float result)
        {
            if (this.clrFloat is float clrFloat)
            {
                result = clrFloat;
                return true;
            }

            if (this.clrDouble is double clrDouble)
            {
                result = (float)clrDouble;
                return true;
            }

            if (this.clrInt is int clrInt)
            {
                result = clrInt;
                return true;
            }

            if (this.clrLong is long clrLong)
            {
                result = clrLong;
                return true;
            }

            if (this.JsonElement.ValueKind == JsonValueKind.Number)
            {
                return this.JsonElement.TryGetSingle(out result);
            }

            result = default;
            return false;
        }

        /// <summary>
        /// Gets the number's value as a .NET float.
        /// </summary>
        /// <param name="result">The value as a float.</param>
        /// <returns><c>True</c> if the value could be returned as float.</returns>
        public bool TryGetDouble([NotNullWhen(true)] out double result)
        {
            if (this.clrDouble is double clrDouble)
            {
                result = clrDouble;
                return true;
            }

            if (this.clrFloat is float clrFloat)
            {
                result = clrFloat;
                return true;
            }

            if (this.clrInt is int clrInt)
            {
                result = clrInt;
                return true;
            }

            if (this.clrLong is long clrLong)
            {
                result = clrLong;
                return true;
            }

            if (this.JsonElement.ValueKind == JsonValueKind.Number)
            {
                return this.JsonElement.TryGetDouble(out result);
            }

            result = default;
            return false;
        }

        /// <summary>
        /// Gets the number's value as a .NET float.
        /// </summary>
        /// <param name="result">The value as a float.</param>
        /// <returns><c>True</c> if the value could be returned as float.</returns>
        public bool TryGetDecimal([NotNullWhen(true)] out decimal result)
        {
            if (this.clrDecimal is decimal clrDecimal)
            {
                result = clrDecimal;
                return true;
            }

            if (this.clrDouble is double clrDouble)
            {
                result = (decimal)clrDouble;
                return true;
            }

            if (this.clrFloat is float clrFloat)
            {
                result = (decimal)clrFloat;
                return true;
            }

            if (this.JsonElement.ValueKind == JsonValueKind.Number)
            {
                return this.JsonElement.TryGetDecimal(out result);
            }

            result = default;
            return false;
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
        /// Gets the number's value as a .NET float.
        /// </summary>
        /// <returns>The value as a <see cref="float"/>.</returns>
        public float CreateOrGetClrFloat() => this.clrFloat ?? this.JsonElement.GetSingle();

        /// <summary>
        /// Gets the number's value as a .NET double.
        /// </summary>
        /// <returns>The value as a <see cref="double"/>.</returns>
        public double CreateOrGetClrDouble() => this.clrDouble ?? this.JsonElement.GetDouble();

        /// <summary>
        /// Gets the number's value as a .NET decimal.
        /// </summary>
        /// <returns>The value as a <see cref="decimal"/>.</returns>
        public decimal CreateOrGetClrDecimal() => this.clrDecimal ?? this.JsonElement.GetDecimal();

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
            else if (this.clrFloat is float single)
            {
                writer.WriteNumberValue(single);
            }
            else if (this.clrDouble is double clrDouble)
            {
                writer.WriteNumberValue(clrDouble);
            }
            else if (this.clrDecimal is decimal clrDecimal)
            {
                writer.WriteNumberValue(clrDecimal);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.clrInt is int int32)
            {
                return int32.ToString();
            }

            if (this.clrLong is long int64)
            {
                return int64.ToString();
            }

            if (this.clrFloat is float single)
            {
                return single.ToString();
            }

            if (this.clrDouble is double clrDouble)
            {
                return clrDouble.ToString();
            }

            if (this.clrDecimal is decimal clrDecimal)
            {
                return clrDecimal.ToString();
            }

            if (this.HasJsonElement)
            {
                return this.JsonElement.GetRawText();
            }

            return string.Empty;
        }

        /// <inheritdoc/>
        public bool Equals(JsonNumber other)
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

            if (this.TryGetDouble(out double lhsd) && other.TryGetDouble(out double rhsd))
            {
                return lhsd == rhsd;
            }

            if (this.TryGetSingle(out float lhss) && other.TryGetSingle(out float rhss))
            {
                return lhss == rhss;
            }

            if (this.TryGetDecimal(out decimal lhsm) && other.TryGetDecimal(out decimal rhsm))
            {
                return lhsm == rhsm;
            }

            return false;
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {JsonValueKind.Number}");
            }

            if (this.HasJsonElement && !this.JsonElement.TryGetDecimal(out _))
            {
                return validationContext.WithError("6.1.1. type: the element is not convertible to a number.");
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
        public ValidationContext ValidateAsNumber(in ValidationContext validationContext, JsonNumber? multipleOf = null, JsonNumber? maximum = null, JsonNumber? exclusiveMaximum = null, JsonNumber? minimum = null, JsonNumber? exclusiveMinimum = null, in ImmutableArray<JsonNumber>? enumeration = null, in JsonNumber? constValue = null)
        {
            ValidationContext context = this.ValidateAsNumberCore(validationContext, multipleOf, maximum, exclusiveMaximum, minimum, exclusiveMinimum);

            if (enumeration is ImmutableArray<JsonNumber> values)
            {
                context = Validation.ValidateEnum(context, this, values);
            }

            if (constValue is JsonNumber cv)
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
        public bool IsMultipleOf(JsonNumber other)
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

            if (this.TryGetDouble(out double lhsd) && other.TryGetDouble(out double rhsd))
            {
                return lhsd % rhsd == 0;
            }

            if (this.TryGetSingle(out float lhss) && other.TryGetSingle(out float rhss))
            {
                return lhss % rhss == 0;
            }

            if (this.TryGetDecimal(out decimal lhsm) && other.TryGetDecimal(out decimal rhsm))
            {
                return lhsm % rhsm == 0;
            }

            return false;
        }

        /// <summary>
        /// Determines if the number is greater than another number.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns><c>True</c> if this number is greater than the other number.</returns>
        public bool IsGreaterThan(JsonNumber other)
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

            if (this.TryGetDouble(out double lhsd) && other.TryGetDouble(out double rhsd))
            {
                return lhsd > rhsd;
            }

            if (this.TryGetSingle(out float lhss) && other.TryGetSingle(out float rhss))
            {
                return lhss > rhss;
            }

            if (this.TryGetDecimal(out decimal lhsm) && other.TryGetDecimal(out decimal rhsm))
            {
                return lhsm > rhsm;
            }

            return false;
        }

        /// <summary>
        /// Determines if the number is greater than or equal to another number.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns><c>True</c> if this number is greater than or equal to the other number.</returns>
        public bool IsGreaterThanOrEqualTo(JsonNumber other)
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

            if (this.TryGetDouble(out double lhsd) && other.TryGetDouble(out double rhsd))
            {
                return lhsd >= rhsd;
            }

            if (this.TryGetSingle(out float lhss) && other.TryGetSingle(out float rhss))
            {
                return lhss >= rhss;
            }

            if (this.TryGetDecimal(out decimal lhsm) && other.TryGetDecimal(out decimal rhsm))
            {
                return lhsm >= rhsm;
            }

            return false;
        }

        /// <summary>
        /// Determines if the number is less than another number.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns><c>True</c> if this number is less than the other number.</returns>
        public bool IsLessThan(JsonNumber other)
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

            if (this.TryGetDouble(out double lhsd) && other.TryGetDouble(out double rhsd))
            {
                return lhsd < rhsd;
            }

            if (this.TryGetSingle(out float lhss) && other.TryGetSingle(out float rhss))
            {
                return lhss < rhss;
            }

            if (this.TryGetDecimal(out decimal lhsm) && other.TryGetDecimal(out decimal rhsm))
            {
                return lhsm < rhsm;
            }

            return false;
        }

        /// <summary>
        /// Determines if the number is less than or equal to another number.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns><c>True</c> if this number is less than or equal to the other number.</returns>
        public bool IsLessThanOrEqualTo(JsonNumber other)
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

            if (this.TryGetDouble(out double lhsd) && other.TryGetDouble(out double rhsd))
            {
                return lhsd <= rhsd;
            }

            if (this.TryGetSingle(out float lhss) && other.TryGetSingle(out float rhss))
            {
                return lhss <= rhss;
            }

            if (this.TryGetDecimal(out decimal lhsm) && other.TryGetDecimal(out decimal rhsm))
            {
                return lhsm <= rhsm;
            }

            return false;
        }

        private ValidationContext ValidateAsNumberCore(ValidationContext validationContext, JsonNumber? multipleOf, JsonNumber? maximum, JsonNumber? exclusiveMaximum, JsonNumber? minimum, JsonNumber? exclusiveMinimum)
        {
            ValidationContext context = this.Validate(validationContext);
            if (multipleOf is JsonNumber mo && !this.IsMultipleOf(mo))
            {
                context = context.WithError($"6.2.1 multipleOf: The value should have been a multiple of '{mo}', but was '{this}'.");
            }

            if (maximum is JsonNumber max && this.IsGreaterThan(max))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been <= '{max}', but was '{this}'");
            }

            if (exclusiveMaximum is JsonNumber exMax && this.IsGreaterThanOrEqualTo(exMax))
            {
                context = context.WithError($"6.2.3 maximum: The value should have been < '{exMax}', but was '{this}'");
            }

            if (minimum is JsonNumber min && this.IsLessThan(min))
            {
                context = context.WithError($"6.2.4 minimum: The value should have been >= '{min}', but was '{this}'");
            }

            if (exclusiveMinimum is JsonNumber exMin && this.IsLessThanOrEqualTo(exMin))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been > '{exMin}', but was '{this}'");
            }

            return context;
        }
    }
}
