// <copyright file="JsonDiscriminatedUnionExample.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Examples
{
    using System;
    using System.Buffers;
    using System.Text;
    using System.Text.Json;
    using Menes;

    /// <summary>
    /// A union over a Json element.
    /// </summary>
    public readonly struct JsonDiscriminatedUnionExample : IJsonValue
    {
        /// <summary>
        /// A <see cref="JsonDiscriminatedUnionExample"/> representing a null value.
        /// </summary>
        public static readonly JsonDiscriminatedUnionExample Null = new JsonDiscriminatedUnionExample(default(JsonElement));

        private static readonly ReadOnlyMemory<byte> DiscriminatorPropertyName = Encoding.UTF8.GetBytes("DiscriminatorProperty");

        private static readonly ReadOnlyMemory<byte> JsonDateTimeDiscriminatorValue = Encoding.UTF8.GetBytes("JsonDateTimeDiscriminatorValue");

        private static readonly ReadOnlyMemory<byte> JsonGuidDiscriminatorValue = Encoding.UTF8.GetBytes("JsonGuidDiscriminatorValue");

        private readonly JsonDateTime? firstInstance;
        private readonly JsonGuid? secondInstance;
        private readonly JsonElement jsonElement;

        /// <summary>
        /// Creates a <see cref="JsonBoolean"/> wrapper around a .NET boolean.
        /// </summary>
        /// <param name="clrInstance">The .NET instance.</param>
        public JsonDiscriminatedUnionExample(JsonDateTime clrInstance)
        {
            this.firstInstance = clrInstance;
            this.secondInstance = null;
            this.jsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonBoolean"/> wrapper around a .NET boolean.
        /// </summary>
        /// <param name="clrInstance">The .NET instance.</param>
        public JsonDiscriminatedUnionExample(JsonGuid clrInstance)
        {
            this.firstInstance = null;
            this.secondInstance = clrInstance;
            this.jsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonBoolean"/> wrapper around a .NET bool.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the bool value to represent.
        /// </param>
        public JsonDiscriminatedUnionExample(JsonElement jsonElement)
        {
            this.firstInstance = null;
            this.secondInstance = null;
            this.jsonElement = jsonElement;
        }

        /// <summary>
        /// Gets a value indicating whether this represents a null value.
        /// </summary>
        public bool IsNull => this.firstInstance is null && this.secondInstance is null && (this.jsonElement.ValueKind == JsonValueKind.Undefined || this.jsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets a value indicating whether this represents a JsonDateTime value.
        /// </summary>
        public bool IsJsonDateTime => this.firstInstance is JsonDateTime || this.jsonElement.GetProperty(DiscriminatorPropertyName.Span).ValueEquals(JsonDateTimeDiscriminatorValue.Span);

        /// <summary>
        /// Gets a value indicating whether this represents a JsonDateTime value.
        /// </summary>
        public bool IsJsonGuid => this.secondInstance is JsonGuid || this.jsonElement.GetProperty(DiscriminatorPropertyName.Span).ValueEquals(JsonGuidDiscriminatorValue.Span);

        /// <summary>
        /// Gets this value as a nullable value type.
        /// </summary>
        public JsonDiscriminatedUnionExample? AsOptional => this.IsNull ? default(JsonDiscriminatedUnionExample?) : this;

        /// <summary>
        /// Implicit conversion from <see cref="JsonDateTime"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDiscriminatedUnionExample(in JsonDateTime value) => new JsonDiscriminatedUnionExample(value);

        /// <summary>
        /// Implicit conversion from <see cref="JsonGuid"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDiscriminatedUnionExample(in JsonGuid value) => new JsonDiscriminatedUnionExample(value);

        /// <summary>
        /// Gets a <see cref="JsonDiscriminatedUnionExample"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDiscriminatedUnionExample"/> or null.</returns>
        public static JsonDiscriminatedUnionExample FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDiscriminatedUnionExample(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDiscriminatedUnionExample"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDiscriminatedUnionExample"/> or null.</returns>
        public static JsonDiscriminatedUnionExample FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDiscriminatedUnionExample(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDiscriminatedUnionExample"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonDiscriminatedUnionExample"/> or null.</returns>
        public static JsonDiscriminatedUnionExample FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonDiscriminatedUnionExample(property)
                : Null;

        /// <summary>
        /// Gets the value as an instance of the first .NET type.
        /// </summary>
        /// <returns>The value as a <see cref="JsonDateTime"/>.</returns>
        public JsonDateTime CreateOrGetClrFirst() => this.IsJsonDateTime ? this.firstInstance ?? new JsonDateTime(this.jsonElement) : throw new JsonException("The union value is not a JsonDateTime");

        /// <summary>
        /// Gets the value as an instance of the second .NET type.
        /// </summary>
        /// <returns>The value as a <see cref="JsonGuid"/>.</returns>
        public JsonGuid CreateOrGetClrSecond() => this.IsJsonGuid ? this.secondInstance ?? new JsonGuid(this.jsonElement) : throw new JsonException("The union value is not a JsonGuid");

        /// <summary>
        /// Writes the bool value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the bool.</param>
        public void Write(Utf8JsonWriter writer)
        {
            if (this.firstInstance is JsonDateTime first)
            {
                first.Write(writer);
            }
            else if (this.secondInstance is JsonGuid second)
            {
                second.Write(writer);
            }
            else
            {
                this.jsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.firstInstance is JsonDateTime first)
            {
                return WriteToAny(first);
            }

            if (this.secondInstance is JsonGuid second)
            {
                return WriteToAny(second);
            }

            return new JsonAny(this.jsonElement);
        }

        private static JsonAny WriteToAny<T>(in T value)
            where T : IJsonValue
        {
            var abw = new ArrayBufferWriter<byte>();
            using var utfw = new Utf8JsonWriter(abw);
            value.Write(utfw);
            utfw.Flush();
            return new JsonAny(abw.WrittenMemory);
        }
    }
}
