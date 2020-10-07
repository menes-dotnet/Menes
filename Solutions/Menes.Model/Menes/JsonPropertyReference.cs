// <copyright file="JsonPropertyReference.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with strongly-typed properties in situ, whether they
    /// originated from JSON or are a .NET value.
    /// </summary>
    /// <remarks>If the element is not backed by a JsonElement, this boxes the <see cref="IJsonValue"/>.</remarks>
    public readonly struct JsonPropertyReference : IEquatable<JsonPropertyReference>
    {
        private readonly JsonProperty jsonProperty;
        private readonly ReadOnlyMemory<byte>? propertyName;
        private readonly JsonReference? reference;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPropertyReference"/> struct.
        /// </summary>
        /// <param name="jsonProperty">The json property to wrap.</param>
        public JsonPropertyReference(JsonProperty jsonProperty)
        {
            this.jsonProperty = jsonProperty;
            this.propertyName = null;
            this.reference = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPropertyReference"/> struct.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="reference">The JSON reference.</param>
        public JsonPropertyReference(string name, JsonReference reference)
        {
            this.jsonProperty = default;
            this.propertyName = Encoding.UTF8.GetBytes(name);
            this.reference = reference;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPropertyReference"/> struct.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="reference">The JSON reference.</param>
        public JsonPropertyReference(ReadOnlyMemory<byte> name, JsonReference reference)
        {
            this.jsonProperty = default;
            this.propertyName = name;
            this.reference = reference;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPropertyReference"/> struct.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="reference">The JSON reference.</param>
        public JsonPropertyReference(ReadOnlySpan<char> name, JsonReference reference)
        {
            this.jsonProperty = default;

            Span<byte> output = stackalloc byte[name.Length * 4];
            int bytesWritten = Encoding.UTF8.GetBytes(name, output);
            this.propertyName = output.Slice(0, bytesWritten).ToArray();
            this.reference = reference;
        }

        /// <summary>
        /// Gets the name of this property.
        /// </summary>
        public string Name
        {
            get
            {
                if (this.propertyName is ReadOnlyMemory<byte> pn)
                {
                    return Encoding.UTF8.GetString(pn.Span);
                }

                return this.jsonProperty.Name;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPropertyReference"/> struct.
        /// </summary>
        /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/>.</typeparam>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The JSON value.</param>
        /// <returns>The property reference.</returns>
        public static JsonPropertyReference From<TValue>(string name, TValue value)
            where TValue : struct, IJsonValue
        {
            return new JsonPropertyReference(name, JsonReference.FromValue(value));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPropertyReference"/> struct.
        /// </summary>
        /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/>.</typeparam>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        /// <returns>The property reference.</returns>
        public static JsonPropertyReference From<TValue>(ReadOnlyMemory<byte> name, TValue value)
            where TValue : struct, IJsonValue
        {
            return new JsonPropertyReference(name, JsonReference.FromValue(value));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPropertyReference"/> struct.
        /// </summary>
        /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/>.</typeparam>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        /// <returns>The property reference.</returns>
        public static JsonPropertyReference From<TValue>(ReadOnlySpan<char> name, TValue value)
            where TValue : struct, IJsonValue
        {
            return new JsonPropertyReference(name, JsonReference.FromValue(value));
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/>.</typeparam>
        /// <returns>The value.</returns>
        public TValue AsValue<TValue>()
            where TValue : struct, IJsonValue
        {
            if (this.reference is JsonReference reference)
            {
                return reference.AsValue<TValue>();
            }

            return JsonAny.As<TValue>(this.jsonProperty.Value);
        }

        /// <inheritdoc/>
        public bool Equals(JsonPropertyReference other)
        {
            if (this.reference is JsonReference reference && other.reference is JsonReference otherReference && this.propertyName is ReadOnlyMemory<byte> name && other.propertyName is ReadOnlyMemory<byte> otherName)
            {
                return name.Span.SequenceEqual(otherName.Span) && reference.AsValue<JsonAny>().Equals(otherReference.AsValue<JsonAny>());
            }

            if (this.reference is JsonReference referenceB && this.propertyName is ReadOnlyMemory<byte> nameB)
            {
                return other.NameEquals(nameB.Span) && referenceB.AsValue<JsonAny>().Equals(new JsonAny(other.jsonProperty.Value));
            }

            if (other.reference is JsonReference referenceC && other.propertyName is ReadOnlyMemory<byte> nameC)
            {
                return this.NameEquals(nameC.Span) && referenceC.AsValue<JsonAny>().Equals(new JsonAny(this.jsonProperty.Value));
            }

            return this.jsonProperty.NameEquals(other.jsonProperty.Name) && JsonAny.FromJsonElement(this.jsonProperty.Value).Equals(JsonAny.FromJsonElement(other.jsonProperty.Value));
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="text">The text to match.</param>
        /// <returns><c>True</c> if the text matches the name of the property.</returns>
        public bool NameEquals(string text)
        {
            if (this.propertyName is ReadOnlyMemory<byte> _)
            {
                return this.NameEquals(Encoding.UTF8.GetBytes(text));
            }

            return this.jsonProperty.NameEquals(text);
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="text">The text to match.</param>
        /// <returns><c>True</c> if the text matches the name of the property.</returns>
        public bool NameEquals(ReadOnlySpan<char> text)
        {
            if (this.propertyName is ReadOnlyMemory<byte> pn)
            {
                Span<byte> output = stackalloc byte[text.Length * 4];
                int bytesWritten = Encoding.UTF8.GetBytes(text, output);
                return this.NameEquals(output.Slice(0, bytesWritten));
            }

            return this.jsonProperty.NameEquals(text);
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="utf8Text">The text to match.</param>
        /// <returns><c>True</c> if the text matches the name of the property.</returns>
        public bool NameEquals(ReadOnlySpan<byte> utf8Text)
        {
            if (this.propertyName is ReadOnlyMemory<byte> pn)
            {
                return pn.Span.SequenceEqual(utf8Text);
            }

            return this.jsonProperty.NameEquals(utf8Text);
        }

        /// <summary>
        /// Write the property.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to which to write the property.</param>
        public void Write(Utf8JsonWriter writer)
        {
            if (this.propertyName is ReadOnlyMemory<byte> pn)
            {
                writer.WritePropertyName(pn.Span);
                this.reference!.Value.WriteTo(writer);
            }
            else
            {
                this.jsonProperty.WriteTo(writer);
            }
        }
    }
}
