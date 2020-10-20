// <copyright file="JsonDateTime.cs" company="Endjin Limited">
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
    /// Enables the Json resources to work with date-times in situ, whether they
    /// originated from JSON or are a .NET date-time.
    /// </summary>
    public readonly struct JsonDateTime : IJsonValue, IEquatable<JsonDateTime>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonDateTime> FromJsonElement = e => new JsonDateTime(e);

        /// <summary>
        /// A <see cref="JsonDateTime"/> representing a null value.
        /// </summary>
        public static readonly JsonDateTime Null = new JsonDateTime(default(JsonElement));

        private readonly OffsetDateTime? clrTime;

        /// <summary>
        /// Creates a <see cref="JsonDateTime"/> wrapper around a .NET date-time.
        /// </summary>
        /// <param name="clrTime">The .NET Time.</param>
        public JsonDateTime(OffsetDateTime clrTime)
        {
            this.clrTime = clrTime;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonDateTime"/> wrapper around a .NET date-time.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Time value to represent.
        /// </param>
        public JsonDateTime(JsonElement jsonElement)
        {
            this.clrTime = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrTime == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this date-time as a nullable value type.
        /// </summary>
        public JsonDateTime? AsOptional => this.IsNull ? default(JsonDateTime?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="OffsetDateTime"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator OffsetDateTime(JsonDateTime value) => value.CreateOrGetClrDateTime();

        /// <summary>
        /// Implicit conversion from an <see cref="OffsetDateTime"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDateTime(OffsetDateTime value) => new JsonDateTime(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonDateTime item) => JsonAny.From(item);

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
        /// Gets a <see cref="JsonDateTime"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDateTime"/> or null.</returns>
        public static JsonDateTime FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonDateTime(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDateTime"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDateTime"/> or null.</returns>
        public static JsonDateTime FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonDateTime(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDateTime"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonDateTime"/> or null.</returns>
        public static JsonDateTime FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonDateTime(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets the date-time's value as a .NET date-time.
        /// </summary>
        /// <returns>The date-time value as a <see cref="OffsetDateTime"/>.</returns>
        /// <remarks>This allocates an unnecessary string because it is not possible to get the span for the token directly. To avoid this allocation, we would have to use our own reader.</remarks>
        public OffsetDateTime CreateOrGetClrDateTime() => this.clrTime ?? ParseDateTime(this.JsonElement).GetValueOrThrow();

        /// <summary>
        /// Writes the Time value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Time.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrTime is OffsetDateTime time)
            {
                // TODO: convert this to a write which does not allocate a string
                writer.WriteStringValue(FormatDateTime(time));
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
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

        /// <inheritdoc/>
        public override string? ToString()
        {
            if (this.IsNull)
            {
                return null;
            }

            if (this.HasJsonElement)
            {
                return this.JsonElement.GetString();
            }

            return FormatDateTime(this.CreateOrGetClrDateTime());
        }

        /// <inheritdoc/>
        public bool Equals(JsonDateTime other)
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

            return this.CreateOrGetClrDateTime().Equals(other.CreateOrGetClrDateTime());
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

        private static string FormatDateTime(OffsetDateTime time)
        {
            return OffsetDateTimePattern.FullRoundtrip.Format(time);
        }

        private static ParseResult<OffsetDateTime> ParseDateTime(in JsonElement jsonElement)
        {
            return OffsetDateTimePattern.FullRoundtrip.Parse(jsonElement.GetString());
        }
    }
}
