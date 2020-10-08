// <copyright file="JsonDuration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Collections.Immutable;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using NodaTime;
    using NodaTime.Text;

    /// <summary>
    /// Enables the Json resources to work with date-times in situ, whether they
    /// originated from JSON or are a .NET duration.
    /// </summary>
    public readonly struct JsonDuration : IJsonValue, IEquatable<JsonDuration>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonDuration> FromJsonElement = e => new JsonDuration(e);

        /// <summary>
        /// A <see cref="JsonDuration"/> representing a null value.
        /// </summary>
        public static readonly JsonDuration Null = new JsonDuration(default(JsonElement));

        private readonly Duration? clrTime;

        /// <summary>
        /// Creates a <see cref="JsonDuration"/> wrapper around a .NET duration.
        /// </summary>
        /// <param name="clrTime">The .NET Time.</param>
        public JsonDuration(Duration clrTime)
        {
            this.clrTime = clrTime;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonDuration"/> wrapper around a .NET duration.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Time value to represent.
        /// </param>
        public JsonDuration(JsonElement jsonElement)
        {
            this.clrTime = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrTime == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this duration as a nullable value type.
        /// </summary>
        public JsonDuration? AsOptional => this.IsNull ? default(JsonDuration?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="Duration"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Duration(JsonDuration value) => value.CreateOrGetClrDuration();

        /// <summary>
        /// Implicit conversion from an <see cref="Duration"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDuration(Duration value) => new JsonDuration(value);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement)
        {
            return jsonElement.ValueKind == JsonValueKind.String || jsonElement.ValueKind == JsonValueKind.Null;
        }

        /// <summary>
        /// Gets a <see cref="JsonDuration"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDuration"/> or null.</returns>
        public static JsonDuration FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDuration(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDuration"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDuration"/> or null.</returns>
        public static JsonDuration FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDuration(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDuration"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonDuration"/> or null.</returns>
        public static JsonDuration FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonDuration(property)
                : Null;

        /// <summary>
        /// Gets the duration's value as a .NET duration.
        /// </summary>
        /// <returns>The duration value as a <see cref="Duration"/>.</returns>
        /// <remarks>This allocates an unnecessary string because it is not possible to get the span for the token directly. To avoid this allocation, we would have to use our own reader.</remarks>
        public Duration CreateOrGetClrDuration() => this.clrTime ?? ParseDuration(this.JsonElement).GetValueOrThrow();

        /// <summary>
        /// Writes the Time value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Time.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrTime is Duration time)
            {
                // TODO: convert this to a write which does not allocate a string
                writer.WriteStringValue(FormatDuration(time));
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrTime is Duration _)
            {
                var abw = new ArrayBufferWriter<byte>();
                using var utfw = new Utf8JsonWriter(abw);
                this.WriteTo(utfw);
                utfw.Flush();
                return new JsonAny(abw.WrittenMemory);
            }

            return new JsonAny(this.JsonElement);
        }

        /// <summary>
        /// Provides the string validations.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="maxLength">The maximum length of the string representation.</param>
        /// <param name="minLength">The minimum length of the string representation.</param>
        /// <param name="pattern">The pattern to which the string must conform.</param>
        /// <param name="enumeration">The values which the string must match.</param>
        /// <param name="constValue">A constant value against which the string must match.</param>
        /// <returns>The validation context updated to reflect the results of the validation.</returns>
        /// <remarks>These are rolled up into a single method to ensure string conversion occurs only once.</remarks>
        public ValidationContext ValidateAsString(in ValidationContext validationContext, int? maxLength = null, int? minLength = null, Regex? pattern = null, in ImmutableArray<string>? enumeration = null, string? constValue = null)
        {
            return Validation.ValidateString(validationContext, this.ToString(), maxLength, minLength, pattern, enumeration, constValue);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.GetRawText();
            }

            return FormatDuration(this.CreateOrGetClrDuration());
        }

        /// <inheritdoc/>
        public bool Equals(JsonDuration other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.HasJsonElement && other.HasJsonElement)
            {
                // Faster just to write the JsonElement directly to a memory buffer and compare the sequences
                // - it would be even better if we could just access the underlying buffer!
                this.AsJsonAny().Equals(other.AsJsonAny());
            }

            return this.CreateOrGetClrDuration().Equals(other.CreateOrGetClrDuration());
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

        private static string FormatDuration(Duration time)
        {
            return DurationPattern.JsonRoundtrip.Format(time);
        }

        private static ParseResult<Duration> ParseDuration(in JsonElement jsonElement)
        {
            return DurationPattern.JsonRoundtrip.Parse(jsonElement.GetString());
        }
    }
}
