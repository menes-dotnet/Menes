// <copyright file="JsonDate.cs" company="Endjin Limited">
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
    /// Enables the Json resources to work with Dates in situ, whether they
    /// originated from JSON or are a .NET date.
    /// </summary>
    public readonly struct JsonDate : IJsonValue, IEquatable<JsonDate>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonDate> FromJsonElement = e => new JsonDate(e);

        /// <summary>
        /// A <see cref="JsonDate"/> representing a null value.
        /// </summary>
        public static readonly JsonDate Null = new JsonDate(default(JsonElement));

        private readonly LocalDate? clrDate;

        /// <summary>
        /// Creates a <see cref="JsonDate"/> wrapper around a .NET Date.
        /// </summary>
        /// <param name="clrDate">The .NET Date.</param>
        public JsonDate(LocalDate clrDate)
        {
            this.clrDate = clrDate;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonDate"/> wrapper around a .NET Date.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Date value to represent.
        /// </param>
        public JsonDate(JsonElement jsonElement)
        {
            this.clrDate = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrDate == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this Date as a nullable value type.
        /// </summary>
        public JsonDate? AsOptional => this.IsNull ? default(JsonDate?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="LocalDate"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator LocalDate(JsonDate value) => value.CreateOrGetClrDate();

        /// <summary>
        /// Implicit conversion from an <see cref="LocalDate"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDate(LocalDate value) => new JsonDate(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonDate item) => JsonAny.From(item);

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
        /// Gets a <see cref="JsonDate"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDate"/> or null.</returns>
        public static JsonDate FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDate(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDate"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDate"/> or null.</returns>
        public static JsonDate FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDate(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDate"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonDate"/> or null.</returns>
        public static JsonDate FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonDate(property)
                : Null;

        /// <summary>
        /// Gets the Date's value as a .NET Date.
        /// </summary>
        /// <returns>The Date value as a <see cref="LocalDate"/>.</returns>
        /// <remarks>This allocates an unnecessary string because it is not possible to get the span for the token directly. To avoid this allocation, we would have to use our own reader.</remarks>
        public LocalDate CreateOrGetClrDate() => this.clrDate ?? ParseDate(this.JsonElement).GetValueOrThrow();

        /// <summary>
        /// Writes the Date value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Date.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrDate is LocalDate date)
            {
                // TODO: convert this to a write which does not allocate a string
                writer.WriteStringValue(FormatDateToString(date));
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
        /// <param name="enumeration">The string must match one of these values.</param>
        /// <param name="constValue">The constant value which the string must match.</param>
        /// <returns>The validation context updated to reflect the results of the validation.</returns>
        /// <remarks>These are rolled up into a single method to ensure string conversion occurs only once.</remarks>
        public ValidationContext ValidateAsString(in ValidationContext validationContext, int? minLength = null, int? maxLength = null, Regex? pattern = null, in ImmutableArray<string>? enumeration = null, in string? constValue = null)
        {
            return Validation.ValidateString(validationContext, this.ToString(), minLength, maxLength, pattern, enumeration, constValue);
        }

        /// <inheritdoc/>
        public bool Equals(JsonDate other)
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

            return this.CreateOrGetClrDate().Equals(other.CreateOrGetClrDate());
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

            return FormatDateToString(this.CreateOrGetClrDate());
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

        private static string FormatDateToString(LocalDate date)
        {
            return LocalDatePattern.Iso.Format(date);
        }

        private static ParseResult<LocalDate> ParseDate(in JsonElement jsonElement)
        {
            return LocalDatePattern.Iso.Parse(jsonElement.GetString());
        }
    }
}
