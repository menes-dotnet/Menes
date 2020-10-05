// <copyright file="JsonInt32.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with ints in situ, whether they
    /// originated from JSON or are a .NET int.
    /// </summary>
    public readonly struct JsonInt32 : IJsonValue
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonInt32> FromJsonElement = e => new JsonInt32(e);

        /// <summary>
        /// A <see cref="JsonInt32"/> representing a null value.
        /// </summary>
        public static readonly JsonInt32 Null = new JsonInt32(default(JsonElement));

        private readonly int? clrInt32;
        private readonly JsonElement jsonElement;

        /// <summary>
        /// Creates a <see cref="JsonInt32"/> wrapper around a .NET int.
        /// </summary>
        /// <param name="clrInt32">The .NET int.</param>
        public JsonInt32(int clrInt32)
        {
            this.clrInt32 = clrInt32;
            this.jsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonInt32"/> wrapper around a .NET int.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the int value to represent.
        /// </param>
        public JsonInt32(JsonElement jsonElement)
        {
            if (!IsConvertibleFrom(jsonElement))
            {
                throw new JsonException("The element must be a JSON number");
            }

            this.clrInt32 = null;
            this.jsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrInt32 == null && (this.jsonElement.ValueKind == JsonValueKind.Undefined || this.jsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this int as a nullable value type.
        /// </summary>
        public JsonInt32? AsOptional => this.IsNull ? default(JsonInt32?) : this;

        /// <summary>
        /// Implicit conversion to <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator int(JsonInt32 value) => value.CreateOrGetClrInt32();

        /// <summary>
        /// Implicit conversion from an <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInt32(int value) => new JsonInt32(value);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <param name="checkKindOnly">If <c>true</c>, check the <see cref="JsonElement.ValueKind"/> only.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement, bool checkKindOnly = true)
        {
            if (jsonElement.ValueKind != JsonValueKind.Number && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                return false;
            }

            if (!checkKindOnly && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                if (!jsonElement.TryGetInt32(out int _))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets a <see cref="JsonInt32"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonInt32"/> or null.</returns>
        public static JsonInt32 FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonInt32(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonInt32"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonInt32"/> or null.</returns>
        public static JsonInt32 FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonInt32(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonInt32"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonInt32"/> or null.</returns>
        public static JsonInt32 FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonInt32(property)
                : Null;

        /// <summary>
        /// Gets the int's value as a .NET int.
        /// </summary>
        /// <returns>The int value as a <see cref="int"/>.</returns>
        public int CreateOrGetClrInt32() => this.clrInt32 ?? this.jsonElement.GetInt32();

        /// <summary>
        /// Writes the int value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the int.</param>
        public void Write(Utf8JsonWriter writer)
        {
            if (this.clrInt32 is int int32)
            {
                writer.WriteNumberValue(int32);
            }
            else
            {
                this.jsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrInt32 is int _)
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
            return this.CreateOrGetClrInt32().ToString();
        }
    }
}
