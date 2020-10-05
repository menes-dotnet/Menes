// <copyright file="JsonDateTime.cs" company="Endjin Limited">
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
    /// Enables the Json resources to work with date-times in situ, whether they
    /// originated from JSON or are a .NET date-time.
    /// </summary>
    public readonly struct JsonDateTime : IJsonValue
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
        private readonly JsonElement jsonElement;

        /// <summary>
        /// Creates a <see cref="JsonDateTime"/> wrapper around a .NET date-time.
        /// </summary>
        /// <param name="clrTime">The .NET Time.</param>
        public JsonDateTime(OffsetDateTime clrTime)
        {
            this.clrTime = clrTime;
            this.jsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonDateTime"/> wrapper around a .NET date-time.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Time value to represent.
        /// </param>
        public JsonDateTime(JsonElement jsonElement)
        {
            if (!IsConvertibleFrom(jsonElement))
            {
                throw new JsonException("The element must be a JSON string");
            }

            this.clrTime = null;
            this.jsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrTime == null && (this.jsonElement.ValueKind == JsonValueKind.Undefined || this.jsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this date-time as a nullable value type.
        /// </summary>
        public JsonDateTime? AsOptional => this.IsNull ? default(JsonDateTime?) : this;

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
                if (!ParseDateTime(in jsonElement).Success)
                {
                    return false;
                }
            }

            return true;
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
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDateTime(property)
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
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDateTime(property)
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
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonDateTime(property)
                : Null;

        /// <summary>
        /// Gets the date-time's value as a .NET date-time.
        /// </summary>
        /// <returns>The date-time value as a <see cref="OffsetDateTime"/>.</returns>
        /// <remarks>This allocates an unnecessary string because it is not possible to get the span for the token directly. To avoid this allocation, we would have to use our own reader.</remarks>
        public OffsetDateTime CreateOrGetClrDateTime() => this.clrTime ?? ParseDateTime(this.jsonElement).GetValueOrThrow();

        /// <summary>
        /// Writes the Time value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Time.</param>
        public void Write(Utf8JsonWriter writer)
        {
            if (this.clrTime is OffsetDateTime time)
            {
                // TODO: convert this to a write which does not allocate a string
                writer.WriteStringValue(OffsetDateTimePattern.FullRoundtrip.Format(time));
            }
            else
            {
                this.jsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrTime is OffsetDateTime _)
            {
                var abw = new ArrayBufferWriter<byte>();
                using var utfw = new Utf8JsonWriter(abw);
                this.Write(utfw);
                utfw.Flush();
                return new JsonAny(abw.WrittenMemory);
            }

            return new JsonAny(this.jsonElement);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.CreateOrGetClrDateTime().ToString();
        }

        private static ParseResult<OffsetDateTime> ParseDateTime(in JsonElement jsonElement)
        {
            return OffsetDateTimePattern.FullRoundtrip.Parse(jsonElement.GetString());
        }
    }
}
