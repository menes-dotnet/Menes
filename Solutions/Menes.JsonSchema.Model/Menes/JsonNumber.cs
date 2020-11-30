// <copyright file="JsonNumber.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    /// <summary>
    /// Represents the {}/true json type.
    /// </summary>
    public readonly struct JsonNumber : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonNumber Null = default;

        private readonly long? valueAsInt64;
        private readonly double? valueAsDouble;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNumber"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonNumber(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.valueAsInt64 = null;
            this.valueAsDouble = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNumber"/> struct.
        /// </summary>
        /// <param name="value">The backing long value.</param>
        public JsonNumber(long value)
        {
            this.valueAsInt64 = value;
            this.valueAsDouble = null;
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNumber"/> struct.
        /// </summary>
        /// <param name="value">The backing long value.</param>
        public JsonNumber(double value)
        {
            this.valueAsInt64 = null;
            this.valueAsDouble = value;
            this.JsonElement = default;
        }

        /// <inheritdoc />
        public bool IsUndefined => this.JsonElement.ValueKind == JsonValueKind.Undefined && this.valueAsDouble is null && this.valueAsInt64 is null;

        /// <inheritdoc />
        public bool IsNull => (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null) && this.valueAsDouble is null && this.valueAsInt64 is null;

        /// <inheritdoc />
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc />
        public JsonElement JsonElement { get; }

        /// <inheritdoc />
        public bool IsNumber => true;

        /// <inheritdoc />
        public bool IsInteger => false;

        /// <inheritdoc />
        public bool IsString => false;

        /// <inheritdoc />
        public bool IsObject => false;

        /// <inheritdoc />
        public bool IsBoolean => false;

        /// <inheritdoc />
        public bool IsArray => false;

        /// <summary>
        /// Implicit conversion from <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(int value)
        {
            return new JsonNumber(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonNumber"/> to convert.</param>
        public static implicit operator int(JsonNumber value)
        {
            return value.GetInt32();
        }

        /// <summary>
        /// Implicit conversion from <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(long value)
        {
            return new JsonNumber(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonNumber"/> to convert.</param>
        public static implicit operator long(JsonNumber value)
        {
            return value.GetInt64();
        }

        /// <summary>
        /// Implicit conversion from <see cref="float"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(float value)
        {
            return new JsonNumber(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonNumber"/> to convert.</param>
        public static implicit operator float(JsonNumber value)
        {
            return value.GetSingle();
        }

        /// <summary>
        /// Implicit conversion from <see cref="double"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(double value)
        {
            return new JsonNumber(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonNumber"/> to convert.</param>
        public static implicit operator double(JsonNumber value)
        {
            return value.GetDouble();
        }

        /// <summary>
        /// Implicit conversion from <see cref="JsonInteger"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber(JsonInteger value)
        {
            return new JsonNumber(value);
        }

        /// <summary>
        /// Gets the <see cref="JsonNumber"/> as a <see cref="double"/>.
        /// </summary>
        /// <returns>The <see cref="double"/>.</returns>
        public double GetDouble()
        {
            if (this.TryGetDouble(out double value))
            {
                return value;
            }

            throw new InvalidOperationException("Unable to get this JsonNumber as a double.");
        }

        /// <summary>
        /// Try to get a <see cref="double"/> value from this <see cref="JsonNumber"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonNumber"/> as a <see cref="double"/>.</param>
        /// <returns><c>True</c> if we were able to get the value.</returns>
        public bool TryGetDouble(out double value)
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.TryGetDouble(out value);
            }

            if (this.valueAsDouble is double vad)
            {
                value = vad;
                return true;
            }

            if (this.valueAsInt64 is long val)
            {
                if (val >= double.MinValue && val <= double.MaxValue)
                {
                    value = val;
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Gets the <see cref="JsonNumber"/> as a <see cref="float"/>.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetSingle()
        {
            if (this.TryGetSingle(out float value))
            {
                return value;
            }

            throw new InvalidOperationException("Unable to get the JsonNumber as a single.");
        }

        /// <summary>
        /// Try to get a <see cref="float"/> value from this <see cref="JsonNumber"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonNumber"/> as a <see cref="float"/>.</param>
        /// <returns><c>True</c> if we were able to get the value.</returns>
        public bool TryGetSingle(out float value)
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.TryGetSingle(out value);
            }

            if (this.valueAsDouble is double vad)
            {
                if (vad >= float.MinValue && vad <= float.MaxValue)
                {
                    value = (float)vad;
                    return true;
                }
            }

            if (this.valueAsInt64 is long val)
            {
                if (val >= float.MinValue && val <= float.MaxValue)
                {
                    value = val;
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Gets the <see cref="JsonNumber"/> as a <see cref="long"/>.
        /// </summary>
        /// <returns>The <see cref="long"/>.</returns>
        public long GetInt64()
        {
            if (this.TryGetInt64(out long value))
            {
                return value;
            }

            throw new InvalidOperationException("Unable to get the JsonNumber as an int64.");
        }

        /// <summary>
        /// Try to get a <see cref="long"/> value from this <see cref="JsonNumber"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonNumber"/> as a <see cref="long"/>.</param>
        /// <returns><c>True</c> if we were able to get the value.</returns>
        public bool TryGetInt64(out long value)
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.TryGetInt64(out value);
            }

            if (this.valueAsDouble is double vad)
            {
                if (vad >= long.MinValue && vad <= long.MaxValue)
                {
                    value = (long)vad;
                    return true;
                }
            }

            if (this.valueAsInt64 is long val)
            {
                value = val;
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Gets the <see cref="JsonNumber"/> as an <see cref="int"/>.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetInt32()
        {
            if (this.TryGetInt32(out int value))
            {
                return value;
            }

            throw new InvalidOperationException("Unable to get the JsonNumber as an int32.");
        }

        /// <summary>
        /// Try to get a <see cref="int"/> value from this <see cref="JsonNumber"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonNumber"/> as a <see cref="int"/>.</param>
        /// <returns><c>True</c> if we were able to get the value.</returns>
        public bool TryGetInt32(out int value)
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.TryGetInt32(out value);
            }

            if (this.valueAsDouble is double vad)
            {
                if (vad >= int.MinValue && vad <= int.MaxValue)
                {
                    value = (int)vad;
                    return true;
                }
            }

            if (this.valueAsInt64 is long val)
            {
                if (val >= int.MinValue && val <= int.MaxValue)
                {
                    value = (int)val;
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonNumber))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<JsonNumber, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonNumber))
            {
                return this.Validate().Valid;
            }

            return this.As<T>().Validate(ValidationResult.ValidResult, ValidationLevel.Flag).Valid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            if (!other.IsString)
            {
                return false;
            }

            JsonNumber otherNumber = other.As<JsonNumber>();
            if (!otherNumber.Validate().Valid)
            {
                return false;
            }

            return (double)this == otherNumber;
        }

        /// <inheritdoc />
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.ValidResult;

            if (this.HasJsonElement && this.JsonElement.ValueKind != JsonValueKind.Number)
            {
                AddError(level, absoluteKeywordLocation, instanceLocation, result);
            }
            else
            {
                AddSuccess(level, absoluteKeywordLocation, instanceLocation, result);
            }

            return result;
        }

        /// <inheritdoc />
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
                return;
            }

            if (this.valueAsInt64 is long v64)
            {
                writer.WriteNumberValue(v64);
            }
            else if (this.valueAsDouble is double vd)
            {
                writer.WriteNumberValue(vd);
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.IsNull ? "null" : this.GetDouble().ToString();
        }

        private static ValidationResult AddSuccess(ValidationLevel level, Stack<string>? absoluteKeywordLocation, Stack<string>? instanceLocation, ValidationResult result)
        {
            if (level == ValidationLevel.Verbose)
            {
                string? il = null;
                string? akl = null;

                instanceLocation?.TryPeek(out il);
                absoluteKeywordLocation?.TryPeek(out akl);

                result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
            }

            return result;
        }

        private static ValidationResult AddError(ValidationLevel level, Stack<string>? absoluteKeywordLocation, Stack<string>? instanceLocation, ValidationResult result)
        {
            if (level >= ValidationLevel.Basic)
            {
                string? il = null;
                string? akl = null;

                instanceLocation?.TryPeek(out il);
                absoluteKeywordLocation?.TryPeek(out akl);
                result.AddResult(valid: false, message: $"6.1.1.  type - should have been convertible to 'number'.", instanceLocation: il, absoluteKeywordLocation: akl);
            }
            else
            {
                result.SetValid(false);
            }

            return result;
        }
    }
}
