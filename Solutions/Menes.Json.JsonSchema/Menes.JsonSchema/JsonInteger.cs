// <copyright file="JsonInteger.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System;
    using System.Text.Json;

    /// <summary>
    /// Represents the integer json type.
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
        public bool IsNumber => true;

        /// <inheritdoc />
        public bool IsInteger => (this.JsonElement.ValueKind == JsonValueKind.Number && this.JsonElement.GetDouble() == Math.Floor(this.JsonElement.GetDouble())) || (!this.HasJsonElement && this.valueAsInt64 is not null);

        /// <inheritdoc />
        public bool IsString => false;

        /// <inheritdoc />
        public bool IsObject => false;

        /// <inheritdoc />
        public bool IsBoolean => false;

        /// <inheritdoc />
        public bool IsArray => false;

        /// <inheritdoc />
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc />
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion from <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInteger(int value)
        {
            return new JsonInteger(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonInteger"/> to convert.</param>
        public static implicit operator int(JsonInteger value)
        {
            return value.GetInt32();
        }

        /// <summary>
        /// Implicit conversion from <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInteger(long value)
        {
            return new JsonInteger(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="JsonInteger"/> to convert.</param>
        public static implicit operator long(JsonInteger value)
        {
            return value.GetInt64();
        }

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
                if (this.JsonElement.TryGetInt64(out value))
                {
                    return true;
                }

                if (this.JsonElement.TryGetDouble(out double valueDouble) && valueDouble == Math.Floor(valueDouble))
                {
                    value = (long)valueDouble;
                    return true;
                }
            }
            else if (this.valueAsInt64 is long val)
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
                if (this.JsonElement.TryGetInt32(out value))
                {
                    return true;
                }

                if (this.JsonElement.TryGetDouble(out double valueDouble) && valueDouble == Math.Floor(valueDouble))
                {
                    value = (int)valueDouble;
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
            if (typeof(T) == typeof(JsonInteger))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<JsonInteger, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonInteger))
            {
                return this.Validate(ValidationContext.ValidContext).IsValid;
            }

            return this.As<T>().Validate(ValidationContext.ValidContext).IsValid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(in T other)
            where T : struct, IJsonValue
        {
            if (!other.IsNumber && !other.IsInteger)
            {
                return false;
            }

            JsonInteger otherInteger = other.As<JsonInteger>();
            if (!otherInteger.Validate(ValidationContext.ValidContext).IsValid)
            {
                return false;
            }

            return (long)this == otherInteger;
        }

        /// <inheritdoc />
        public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
        {
            if (this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.Number || this.JsonElement.GetDouble() != Math.Floor(this.JsonElement.GetDouble())))
            {
                if (level >= ValidationLevel.Basic)
                {
                    return validationContext.WithResult(isValid: false, message: $"6.1.1.  type - should have been 'integer'.");
                }
                else
                {
                    return validationContext.WithResult(isValid: false);
                }
            }
            else
            {
                if (level == ValidationLevel.Verbose)
                {
                    return validationContext.WithResult(isValid: true);
                }
            }

            return validationContext;
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
