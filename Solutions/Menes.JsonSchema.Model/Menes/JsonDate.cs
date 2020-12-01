// <copyright file="JsonDate.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Text.Json;
    using NodaTime;

    /// <summary>
    /// Represents the date json type.
    /// </summary>
    public readonly struct JsonDate : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonDate Null = default;

        private readonly LocalDate? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDate"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonDate(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDate"/> struct.
        /// </summary>
        /// <param name="value">The backing NodaTime.LocalDate value.</param>
        public JsonDate(LocalDate value)
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
        /// Implicit conversion from <see cref="LocalDate"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonDate(LocalDate value)
        {
            return new JsonDate(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="LocalDate"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator LocalDate(JsonDate value)
        {
            return value.GetNodaTimeLocalDate();
        }

        /// <summary>
        /// Gets the <see cref="JsonDate"/> as a <see cref="bool"/>.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public LocalDate GetNodaTimeLocalDate()
        {
            return (this.HasJsonElement ? this.Parse(this.JsonElement) : this.value) ?? default;
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonDate))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<JsonDate, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonDate))
            {
                return this.Validate(ValidationContext.ValidContext).IsValid;
            }

            return this.As<T>().Validate(ValidationContext.ValidContext).IsValid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            if (!other.IsString)
            {
                return false;
            }

            JsonDate otherDate = other.As<JsonDate>();
            if (!otherDate.Validate(ValidationContext.ValidContext).IsValid)
            {
                return false;
            }

            return (LocalDate)this == otherDate;
        }

        /// <inheritdoc />
        public ValidationContext Validate(ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
        {
            if (this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || this.Parse(this.JsonElement) is null))
            {
                if (level >= ValidationLevel.Basic)
                {
                    return validationContext.WithResult(isValid: false, message: $"6.1.1. type - should have been 'string' with format 'date'.");
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

            if (this.value is LocalDate v)
            {
                writer.WriteStringValue(NodaTime.Text.LocalDatePattern.Iso.Format(v));
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.IsNull ? "null" : this.GetNodaTimeLocalDate().ToString();
        }

        private LocalDate? Parse(JsonElement jsonElement)
        {
            string? date = jsonElement.GetString();
            if (date is null)
            {
                return default;
            }

            NodaTime.Text.ParseResult<LocalDate> result = NodaTime.Text.LocalDatePattern.Iso.Parse(date.ToUpperInvariant());
            if (result.TryGetValue(default, out LocalDate dateResult))
            {
                return dateResult;
            }

            return default;
        }
    }
}
