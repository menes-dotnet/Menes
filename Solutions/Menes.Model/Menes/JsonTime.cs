// <copyright file="JsonTime.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using NodaTime;
    using NodaTime.Text;

    /// <summary>
    /// Enables the Json resources to work with Times in situ, whether they
    /// originated from JSON or are a .NET time.
    /// </summary>
    public readonly struct JsonTime : IJsonValue, IEquatable<JsonTime>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonTime> FromJsonElement = e => new JsonTime(e);

        /// <summary>
        /// A <see cref="JsonTime"/> representing a null value.
        /// </summary>
        public static readonly JsonTime Null = new JsonTime(default(JsonElement));

        private readonly OffsetTime? clrTime;

        /// <summary>
        /// Creates a <see cref="JsonTime"/> wrapper around a .NET time.
        /// </summary>
        /// <param name="clrTime">The .NET time.</param>
        public JsonTime(OffsetTime clrTime)
        {
            this.clrTime = clrTime;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonTime"/> wrapper around a .NET time.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Time value to represent.
        /// </param>
        public JsonTime(JsonElement jsonElement)
        {
            this.clrTime = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrTime == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this Time as a nullable value type.
        /// </summary>
        public JsonTime? AsOptional => this.IsNull ? default(JsonTime?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="OffsetTime"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator OffsetTime(JsonTime value) => value.CreateOrGetClrTime();

        /// <summary>
        /// Implicit conversion from an <see cref="OffsetTime"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonTime(OffsetTime value) => new JsonTime(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonTime item) => JsonAny.From(item);

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
        /// Gets a <see cref="JsonTime"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonTime"/> or null.</returns>
        public static JsonTime FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonTime(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonTime"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonTime"/> or null.</returns>
        public static JsonTime FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonTime(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonTime"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonTime"/> or null.</returns>
        public static JsonTime FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonTime(property)
                : Null;

        /// <summary>
        /// Gets the Time's value as a .NET time.
        /// </summary>
        /// <returns>The Time value as a <see cref="OffsetTime"/>.</returns>
        /// <remarks>This allocates an unnecessary string because it is not possible to get the span for the token directly. To avoid this allocation, we would have to use our own reader.</remarks>
        public OffsetTime CreateOrGetClrTime() => this.clrTime ?? ParseTime(this.JsonElement).GetValueOrThrow();

        /// <summary>
        /// Writes the Time value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Time.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrTime is OffsetTime time)
            {
                // TODO: convert this to a write which does not allocate a string
                writer.WriteStringValue(FormatTime(time));
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.GetRawText();
            }

            return FormatTime(this.CreateOrGetClrTime());
        }

        /// <inheritdoc/>
        public bool Equals(JsonTime other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.HasJsonElement && other.HasJsonElement)
            {
                // Faster just to write the JsonElement directly to a memory buffer and compare the sequences
                // - it would be even better if we could just access the underlying buffer!
                JsonAny.From(this).Equals(JsonAny.From(other));
            }

            return this.CreateOrGetClrTime().Equals(other.CreateOrGetClrTime());
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

        /// <summary>
        /// Provides the string validations.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="minLength">The minimum length of the string representation.</param>
        /// <param name="maxLength">The maximum length of the string representation.</param>
        /// <param name="pattern">The pattern to which the string must conform.</param>
        /// <param name="enumeration">The values which the string must match.</param>
        /// <param name="constValue">A constant value against which the string must match.</param>
        /// <returns>The validation context updated to reflect the results of the validation.</returns>
        /// <remarks>These are rolled up into a single method to ensure string conversion occurs only once.</remarks>
        public ValidationContext ValidateAsString(in ValidationContext validationContext, int? minLength = null, int? maxLength = null, Regex? pattern = null, in ImmutableArray<string>? enumeration = null, string? constValue = null)
        {
            return Validation.ValidateString(validationContext, this.ToString(), minLength, maxLength, pattern, enumeration, constValue);
        }

        private static string FormatTime(OffsetTime time)
        {
            return OffsetTimePattern.ExtendedIso.Format(time);
        }

        private static ParseResult<OffsetTime> ParseTime(in JsonElement jsonElement)
        {
            return OffsetTimePattern.ExtendedIso.Parse(jsonElement.GetString());
        }
    }
}
