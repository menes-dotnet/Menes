// <copyright file="JsonTime.cs" company="Endjin Limited">
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
    /// Enables the Json resources to work with Times in situ, whether they
    /// originated from JSON or are a .NET time.
    /// </summary>
    public readonly struct JsonTime : IJsonValue
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
        private readonly JsonElement jsonElement;

        /// <summary>
        /// Creates a <see cref="JsonTime"/> wrapper around a .NET time.
        /// </summary>
        /// <param name="clrTime">The .NET time.</param>
        public JsonTime(OffsetTime clrTime)
        {
            this.clrTime = clrTime;
            this.jsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonTime"/> wrapper around a .NET time.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Time value to represent.
        /// </param>
        public JsonTime(JsonElement jsonElement)
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
        /// Gets this Time as a nullable value type.
        /// </summary>
        public JsonTime? AsOptional => this.IsNull ? default(JsonTime?) : this;

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
                if (!ParseTime(in jsonElement).Success)
                {
                    return false;
                }
            }

            return true;
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
        public OffsetTime CreateOrGetClrTime() => this.clrTime ?? ParseTime(this.jsonElement).GetValueOrThrow();

        /// <summary>
        /// Writes the Time value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Time.</param>
        public void Write(Utf8JsonWriter writer)
        {
            if (this.clrTime is OffsetTime time)
            {
                // TODO: convert this to a write which does not allocate a string
                writer.WriteStringValue(OffsetTimePattern.ExtendedIso.Format(time));
            }
            else
            {
                this.jsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrTime is OffsetTime _)
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
            return this.CreateOrGetClrTime().ToString();
        }

        private static ParseResult<OffsetTime> ParseTime(in JsonElement jsonElement)
        {
            return OffsetTimePattern.ExtendedIso.Parse(jsonElement.GetString());
        }
    }
}
