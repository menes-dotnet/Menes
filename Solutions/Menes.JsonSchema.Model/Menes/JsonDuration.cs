// <copyright file="JsonDuration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using NodaTime;

    /// <summary>
    /// Represents the duration json type.
    /// </summary>
    public readonly struct JsonDuration : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonDuration Null = default;

        private static readonly Regex DurationPattern = new Regex(@"^P(?!$)((\d+(?:\.\d+)?Y)?(\d+(?:\.\d+)?M)?|(\d+(?:\.\d+)?W)?)?(\d+(?:\.\d+)?D)?(T(?=\d)(\d+(?:\.\d+)?H)?(\d+(?:\.\d+)?M)?(\d+(?:\.\d+)?S)?)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly Period? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDuration"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonDuration(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDuration"/> struct.
        /// </summary>
        /// <param name="value">The backing NodaTime.Period value.</param>
        public JsonDuration(Period value)
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
        /// Implicit conversion from <see cref="Period"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonDuration(Period value)
        {
            return new JsonDuration(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="Period"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator Period(JsonDuration value)
        {
            return value.GetNodaTimeDuration();
        }

        /// <summary>
        /// Gets the <see cref="JsonDuration"/> as a <see cref="bool"/>.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public Period GetNodaTimeDuration()
        {
            return (this.HasJsonElement ? this.Parse(this.JsonElement) : this.value) ?? Period.Zero;
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonDuration))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<JsonDuration, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonDuration))
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

            JsonDuration otherDuration = other.As<JsonDuration>();
            if (!otherDuration.Validate().Valid)
            {
                return false;
            }

            return (Period)this == otherDuration;
        }

        /// <inheritdoc />
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.ValidResult;

            if (this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || !DurationPattern.IsMatch(this.JsonElement.GetString())))
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

            if (this.value is Period v)
            {
                writer.WriteStringValue(NodaTime.Text.PeriodPattern.NormalizingIso.Format(v));
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.IsNull ? "null" : this.GetNodaTimeDuration().ToString();
        }

        private Period? Parse(JsonElement jsonElement)
        {
            string? date = jsonElement.GetString();
            if (date is null)
            {
                return default;
            }

            NodaTime.Text.ParseResult<Period> result = NodaTime.Text.PeriodPattern.NormalizingIso.Parse(date.ToUpperInvariant());
            if (result.TryGetValue(Period.Zero, out Period dateResult))
            {
                return dateResult;
            }

            return default;
        }
    }
}
