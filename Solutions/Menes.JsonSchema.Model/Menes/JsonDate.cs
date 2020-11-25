// <copyright file="JsonDate.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Text.Json;
    using NodaTime;

    /// <summary>
    /// Represents the {}/true json type.
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
        public static implicit operator JsonDate(LocalDate value) => new JsonDate(value);

        /// <summary>
        /// Implicit conversion to <see cref="LocalDate"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator LocalDate(JsonDate value) => value.GetNodaTimeLocalDate();

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
                return this.Validate().Valid;
            }

            return this.As<T>().Validate().Valid;
        }

        /// <inheritdoc />
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.ValidResult;

            if (this.HasJsonElement && this.JsonElement.ValueKind != JsonValueKind.True && this.JsonElement.ValueKind != JsonValueKind.False)
            {
                if (level >= ValidationLevel.Basic)
                {
                    string? il = null;
                    string? akl = null;

                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);
                    result.AddResult(valid: false, message: $"6.1.1.  type - should have been 'True' or 'False' but was '{this.JsonElement.ValueKind}'.", instanceLocation: il, absoluteKeywordLocation: akl);
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

            NodaTime.Text.ParseResult<LocalDate> result = NodaTime.Text.LocalDatePattern.Iso.Parse(date);
            result.TryGetValue(default, out LocalDate dateResult);
            return dateResult;
        }
    }
}
