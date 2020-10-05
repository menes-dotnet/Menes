// <copyright file="JsonUri.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with Uris in situ, whether they
    /// originated from JSON or are a .NET Uri.
    /// </summary>
    public readonly struct JsonUri : IJsonValue
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonUri> FromJsonElement = e => new JsonUri(e);

        /// <summary>
        /// A <see cref="JsonUri"/> representing a null value.
        /// </summary>
        public static readonly JsonUri Null = new JsonUri(default(JsonElement));

        private readonly string? clrUri;

        /// <summary>
        /// Creates a <see cref="JsonUri"/> wrapper around a .NET Uri.
        /// </summary>
        /// <param name="clrUri">The .NET Uri.</param>
        public JsonUri(Uri clrUri)
        {
            this.clrUri = clrUri.ToString();
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonUri"/> wrapper around a .NET Uri.
        /// </summary>
        /// <param name="clrUri">The .NET Uri.</param>
        public JsonUri(string clrUri)
        {
            this.clrUri = clrUri;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonUri"/> wrapper around a .NET Uri.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Uri value to represent.
        /// </param>
        public JsonUri(JsonElement jsonElement)
        {
            if (jsonElement.ValueKind != JsonValueKind.String)
            {
                throw new JsonException("The element must be a JSON string");
            }

            this.clrUri = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrUri == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this Uri as a nullable value type.
        /// </summary>
        public JsonUri? AsOptional => this.IsNull ? default(JsonUri?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="Uri"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Uri(JsonUri value) => value.CreateOrGetClrUri();

        /// <summary>
        /// Implicit conversion from an <see cref="Uri"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonUri(Uri value) => new JsonUri(value);

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
                // TODO: This is expensive because we allocate the string. We could optimize
                // by processing the underlying byte stream.
                if (!Uri.TryCreate(jsonElement.ToString(), UriKind.RelativeOrAbsolute, out Uri _))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets a <see cref="JsonUri"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonUri"/> or null.</returns>
        public static JsonUri FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonUri(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonUri"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonUri"/> or null.</returns>
        public static JsonUri FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonUri(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonUri"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonUri"/> or null.</returns>
        public static JsonUri FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonUri(property)
                : Null;

        /// <summary>
        /// Gets the Uri's value as a .NET Uri.
        /// </summary>
        /// <returns>The Uri value as a <see cref="Uri"/>.</returns>
        public Uri CreateOrGetClrUri() => new Uri(this.CreateOrGetClrString(), UriKind.RelativeOrAbsolute);

        /// <summary>
        /// Writes the Uri value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Uri.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrUri is string uri)
            {
                writer.WriteStringValue(uri);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrUri is string _)
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
            // We are ensuring we behave like Uri.ToString() but without the overhead
            // of creating the Uri instance.
            return this.CreateOrGetClrString();
        }

        private string CreateOrGetClrString()
        {
            return this.clrUri ?? this.JsonElement.GetString();
        }
    }
}
