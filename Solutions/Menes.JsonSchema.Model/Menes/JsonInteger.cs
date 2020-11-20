// <copyright file="JsonInteger.cs" company="Endjin Limited">
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
    public readonly struct JsonInteger : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonInteger Null = default;

        private readonly long? valueAsInt64;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonInteger"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonInteger(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.valueAsInt64 = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonInteger"/> struct.
        /// </summary>
        /// <param name="value">The backing long value.</param>
        public JsonInteger(long value)
        {
            this.valueAsInt64 = value;
            this.JsonElement = default;
        }

        /// <inheritdoc />
        public bool IsUndefined => this.JsonElement.ValueKind == JsonValueKind.Undefined && this.valueAsInt64 is null;

        /// <inheritdoc />
        public bool IsNull => (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null) && this.valueAsInt64 is null;

        /// <inheritdoc />
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc />
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion from <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInteger(int value) => new JsonInteger(value);

        /// <summary>
        /// Implicit conversion to <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonInteger"/> to convert.</param>
        public static implicit operator int(JsonInteger value) => value.GetInt32();

        /// <summary>
        /// Implicit conversion from <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInteger(long value) => new JsonInteger(value);

        /// <summary>
        /// Implicit conversion to <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonInteger"/> to convert.</param>
        public static implicit operator long(JsonInteger value) => value.GetInt64();

        /// <summary>
        /// Gets the <see cref="JsonInteger"/> as a <see cref="long"/>.
        /// </summary>
        /// <returns>The <see cref="long"/>.</returns>
        public long GetInt64()
        {
            if (this.TryGetInt64(out long value))
            {
                return value;
            }

            throw new InvalidOperationException("Unable to get the JsonInteger as an int64.");
        }

        /// <summary>
        /// Try to get a <see cref="long"/> value from this <see cref="JsonInteger"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonInteger"/> as a <see cref="long"/>.</param>
        /// <returns><c>True</c> if we were able to get the value.</returns>
        public bool TryGetInt64(out long value)
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.TryGetInt64(out value);
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
        /// Gets the <see cref="JsonInteger"/> as an <see cref="int"/>.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetInt32()
        {
            if (this.TryGetInt32(out int value))
            {
                return value;
            }

            throw new InvalidOperationException("Unable to get the JsonInteger as an int32.");
        }

        /// <summary>
        /// Try to get a <see cref="int"/> value from this <see cref="JsonInteger"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonInteger"/> as a <see cref="int"/>.</param>
        /// <returns><c>True</c> if we were able to get the value.</returns>
        public bool TryGetInt32(out int value)
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.TryGetInt32(out value);
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
            if (typeof(T) == typeof(JsonInteger))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<T>(JsonValue.FlattenToJsonElementBacking(this).JsonElement);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonInteger))
            {
                return this.Validate().Valid;
            }

            return this.As<T>().Validate().Valid;
        }

        /// <inheritdoc />
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.ValidResult;

            if (this.HasJsonElement && this.JsonElement.ValueKind != JsonValueKind.Number)
            {
                if (level >= ValidationLevel.Basic)
                {
                    string? il = null;
                    string? akl = null;

                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);
                    result.AddResult(valid: false, message: $"6.1.1.  type - should have been 'number' but was '{this.JsonElement.ValueKind}'.", instanceLocation: il, absoluteKeywordLocation: akl);
                }
                else
                {
                    result.SetValid(false);
                }
            }
            else
            {
                if (level == ValidationLevel.Verbose)
                {
                    string? il = null;
                    string? akl = null;

                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);

                    result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
                }
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
            else
            {
                writer.WriteNullValue();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.IsNull ? "null" : this.GetInt64().ToString();
        }
    }
}
