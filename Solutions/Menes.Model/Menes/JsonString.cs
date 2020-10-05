// <copyright file="JsonString.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with strings in situ, whether they
    /// originated from JSON or are a .NET string.
    /// </summary>
    public readonly struct JsonString : IJsonValue
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonString> FromJsonElement = e => new JsonString(e);

        /// <summary>
        /// A <see cref="JsonString"/> representing a null value.
        /// </summary>
        public static readonly JsonString Null = new JsonString(default(JsonElement));

        private readonly string? clrString;
        private readonly JsonElement jsonElement;

        /// <summary>
        /// Creates a <see cref="JsonString"/> wrapper around a .NET string.
        /// </summary>
        /// <param name="clrString">The .NET string.</param>
        public JsonString(string clrString)
        {
            this.clrString = clrString;
            this.jsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonString"/> wrapper around a .NET string.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the string value to represent.
        /// </param>
        public JsonString(JsonElement jsonElement)
        {
            if (!IsConvertibleFrom(jsonElement))
            {
                throw new JsonException("The element must be a JSON string");
            }

            this.clrString = null;
            this.jsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrString == null && (this.jsonElement.ValueKind == JsonValueKind.Undefined || this.jsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this string as a nullable value type.
        /// </summary>
        public JsonString? AsOptional => this.IsNull ? default(JsonString?) : this;

        /// <summary>
        /// Implicit conversion to string.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator string(JsonString value) => value.CreateOrGetClrString();

        /// <summary>
        /// Implicit conversion from string.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonString(string value) => new JsonString(value);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <param name="checkKindOnly">If <c>true</c>, check the <see cref="JsonElement.ValueKind"/> only.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static bool IsConvertibleFrom(JsonElement jsonElement, bool checkKindOnly = true)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (jsonElement.ValueKind != JsonValueKind.String && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets a <see cref="JsonString"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonString"/> or null.</returns>
        public static JsonString FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonString(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonString"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonString"/> or null.</returns>
        public static JsonString FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonString(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonString"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonString"/> or null.</returns>
        public static JsonString FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonString(property)
                : Null;

        /// <summary>
        /// Gets the string's value as a .NET string. This will allocate a new string if the
        /// underlying representation was not already a .NET string.
        /// </summary>
        /// <returns>The string value as a <see cref="string"/>.</returns>
        public string CreateOrGetClrString() => this.clrString ?? this.jsonElement.GetString();

        /// <summary>
        /// Writes the string value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the string.</param>
        public void Write(Utf8JsonWriter writer)
        {
            if (this.clrString is string text)
            {
                writer.WriteStringValue(text);
            }
            else
            {
                this.jsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrString is string _)
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
            return this.CreateOrGetClrString();
        }
    }
}
