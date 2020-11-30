// <copyright file="JsonTime.cs" company="Endjin Limited">
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
    public readonly struct JsonTime : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonTime Null = default;

        private readonly OffsetTime? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTime"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonTime(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTime"/> struct.
        /// </summary>
        /// <param name="value">The backing NodaTime.OffsetTime value.</param>
        public JsonTime(OffsetTime value)
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
        /// Implicit conversion from <see cref="OffsetTime"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonTime(OffsetTime value)
        {
            return new JsonTime(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="OffsetTime"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator OffsetTime(JsonTime value)
        {
            return value.GetNodaTimeOffsetTime();
        }

        /// <summary>
        /// Gets the <see cref="JsonTime"/> as a <see cref="bool"/>.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public OffsetTime GetNodaTimeOffsetTime()
        {
            return (this.HasJsonElement ? this.Parse(this.JsonElement) : this.value) ?? default;
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonTime))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<JsonTime, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonTime))
            {
                return this.Validate().Valid;
            }

            return this.As<T>().Validate().Valid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            if (!other.IsString)
            {
                return false;
            }

            JsonTime otherTime = other.As<JsonTime>();
            if (!otherTime.Validate().Valid)
            {
                return false;
            }

            return (OffsetTime)this == otherTime;
        }

        /// <inheritdoc />
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.ValidResult;

            if (this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || this.Parse(this.JsonElement) is null))
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

            if (this.value is OffsetTime v)
            {
                writer.WriteStringValue(NodaTime.Text.OffsetTimePattern.ExtendedIso.Format(v));
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.IsNull ? "null" : this.GetNodaTimeOffsetTime().ToString();
        }

        private OffsetTime? Parse(JsonElement jsonElement)
        {
            string? date = jsonElement.GetString();
            if (date is null)
            {
                return default;
            }

            NodaTime.Text.ParseResult<OffsetTime> result = NodaTime.Text.OffsetTimePattern.ExtendedIso.Parse(date.ToUpperInvariant());
            if (result.TryGetValue(default, out OffsetTime dateResult))
            {
                return dateResult;
            }

            return default;
        }
    }
}
