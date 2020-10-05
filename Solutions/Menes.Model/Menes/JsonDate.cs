// <copyright file="JsonDate.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Text.Json;
    using NodaTime;
    using NodaTime.Text;

    /// <summary>
    /// Enables the Json resources to work with Dates in situ, whether they
    /// originated from JSON or are a .NET date.
    /// </summary>
    public readonly struct JsonDate : IJsonValue
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
            if (!IsConvertibleFrom(jsonElement))
            {
                throw new JsonException("The element must be a JSON string");
            }

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
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <param name="checkKindOnly">If <c>true</c>, check the <see cref="JsonElement.ValueKind"/> only.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement, bool checkKindOnly = true)
        {
            if (jsonElement.ValueKind != JsonValueKind.String && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                return false;
            }

            if (!checkKindOnly && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                // TODO: This is very expensive while our parse allocates a string -
                // it would be better to validate that it is parsable from the byte array
                if (!ParseDate(in jsonElement).Success)
                {
                    return false;
                }
            }

            return true;
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
                writer.WriteStringValue(LocalDatePattern.Iso.Format(date));
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrDate is LocalDate _)
            {
                var abw = new ArrayBufferWriter<byte>();
                using var utfw = new Utf8JsonWriter(abw);
                this.WriteTo(utfw);
                utfw.Flush();
                return new JsonAny(abw.WrittenMemory);
            }

            return new JsonAny(this.JsonElement);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.CreateOrGetClrDate().ToString();
        }

        private static ParseResult<LocalDate> ParseDate(in JsonElement jsonElement)
        {
            return LocalDatePattern.Iso.Parse(jsonElement.GetString());
        }
    }
}
