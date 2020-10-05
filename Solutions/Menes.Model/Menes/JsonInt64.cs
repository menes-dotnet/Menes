// <copyright file="JsonInt64.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with longs in situ, whether they
    /// originated from JSON or are a .NET long.
    /// </summary>
    public readonly struct JsonInt64 : IJsonValue
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonInt64> FromJsonElement = e => new JsonInt64(e);

        /// <summary>
        /// A <see cref="JsonInt64"/> representing a null value.
        /// </summary>
        public static readonly JsonInt64 Null = new JsonInt64(default(JsonElement));

        private readonly long? clrInt64;
        private readonly JsonElement jsonElement;

        /// <summary>
        /// Creates a <see cref="JsonInt64"/> wrapper around a .NET long.
        /// </summary>
        /// <param name="clrInt64">The .NET long.</param>
        public JsonInt64(long clrInt64)
        {
            this.clrInt64 = clrInt64;
            this.jsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonInt64"/> wrapper around a .NET long.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the long value to represent.
        /// </param>
        public JsonInt64(JsonElement jsonElement)
        {
            if (!IsConvertibleFrom(jsonElement))
            {
                throw new JsonException("The element must be a JSON number");
            }

            this.clrInt64 = null;
            this.jsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrInt64 == null && (this.jsonElement.ValueKind == JsonValueKind.Undefined || this.jsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this long as a nullable value type.
        /// </summary>
        public JsonInt64? AsOptional => this.IsNull ? default(JsonInt64?) : this;

        /// <summary>
        /// Implicit conversion to <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator long(JsonInt64 value) => value.CreateOrGetClrInt64();

        /// <summary>
        /// Implicit conversion from <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInt64(long value) => new JsonInt64(value);

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
                if (!jsonElement.TryGetInt64(out long _))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets a <see cref="JsonInt64"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonInt64"/> or null.</returns>
        public static JsonInt64 FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonInt64(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonInt64"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonInt64"/> or null.</returns>
        public static JsonInt64 FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonInt64(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonInt64"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonInt64"/> or null.</returns>
        public static JsonInt64 FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonInt64(property)
                : Null;

        /// <summary>
        /// Gets the long's value as a .NET long.
        /// </summary>
        /// <returns>The long value as a <see cref="long"/>.</returns>
        public long CreateOrGetClrInt64() => this.clrInt64 ?? this.jsonElement.GetInt64();

        /// <summary>
        /// Writes the long value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the long.</param>
        public void Write(Utf8JsonWriter writer)
        {
            if (this.clrInt64 is long int64)
            {
                writer.WriteNumberValue(int64);
            }
            else
            {
                this.jsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrInt64 is long _)
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
            return this.CreateOrGetClrInt64().ToString();
        }
    }
}
