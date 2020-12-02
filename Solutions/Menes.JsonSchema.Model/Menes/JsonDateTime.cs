// <copyright file="JsonDateTime.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Text.Json;
    using NodaTime;

    /// <summary>
    /// Represents the datetime json type.
    /// </summary>
    public readonly struct JsonDateTime : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonDateTime Null = default;

        private readonly OffsetDateTime? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDateTime"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonDateTime(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDateTime"/> struct.
        /// </summary>
        /// <param name="value">The backing NodaTime.OffsetDateTime value.</param>
        public JsonDateTime(OffsetDateTime value)
        {
            this.value = value;
            this.JsonElement = default;
        }

        /// <inheritdoc />
        public bool IsUndefined => this.JsonElement.ValueKind == JsonValueKind.Undefined && this.value is null;

        /// <inheritdoc />
        public bool IsNull => (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null) && this.value is null;

        /// <inheritdoc />
        public bool IsNumber => false;

        /// <inheritdoc />
        public bool IsInteger => false;

        /// <inheritdoc />
        public bool IsString => true;

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
        /// Implicit conversion from <see cref="OffsetDateTime"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonDateTime(OffsetDateTime value)
        {
            return new JsonDateTime(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="OffsetDateTime"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator OffsetDateTime(JsonDateTime value)
        {
            return value.GetNodaTimeOffsetDateTime();
        }

        /// <summary>
        /// Gets the <see cref="JsonDateTime"/> as a <see cref="bool"/>.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public OffsetDateTime GetNodaTimeOffsetDateTime()
        {
            return (this.HasJsonElement ? this.Parse(this.JsonElement) : this.value) ?? default;
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonDateTime))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<JsonDateTime, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonDateTime))
            {
                return this.Validate(ValidationContext.ValidContext).IsValid;
            }

            return this.As<T>().Validate(ValidationContext.ValidContext).IsValid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(in T other)
            where T : struct, IJsonValue
        {
            if (!other.IsString)
            {
                return false;
            }

            JsonDateTime otherDate = other.As<JsonDateTime>();
            if (!otherDate.Validate(ValidationContext.ValidContext).IsValid)
            {
                return false;
            }

            return (OffsetDateTime)this == otherDate;
        }

        /// <inheritdoc />
        public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
        {
            if (this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || this.Parse(this.JsonElement) is null))
            {
                if (level >= ValidationLevel.Basic)
                {
                    return validationContext.WithResult(isValid: false, message: $"6.1.1. type - should have been 'string' with format 'date-time'.");
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

            if (this.value is OffsetDateTime v)
            {
                writer.WriteStringValue(NodaTime.Text.OffsetDateTimePattern.ExtendedIso.Format(v));
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.IsNull ? "null" : this.GetNodaTimeOffsetDateTime().ToString();
        }

        private OffsetDateTime? Parse(JsonElement jsonElement)
        {
            string? date = jsonElement.GetString();
            if (date is null)
            {
                return default;
            }

            NodaTime.Text.ParseResult<OffsetDateTime> result = NodaTime.Text.OffsetDateTimePattern.ExtendedIso.Parse(date.ToUpperInvariant());
            if (result.TryGetValue(default, out OffsetDateTime dateResult))
            {
                return dateResult;
            }

            return default;
        }
    }
}
