// <copyright file="JsonIriReference.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Text;
    using System.Text.Json;
    using Corvus.Extensions;

    /// <summary>
    /// A JSON object.
    /// </summary>
    public readonly struct JsonIriReference : IJsonValue, IEquatable<JsonIriReference>
    {
        private static readonly Uri EmptyUri = new Uri(string.Empty, UriKind.RelativeOrAbsolute);

        private readonly JsonElement jsonElement;
        private readonly JsonEncodedText? value;
        private readonly Uri? localUriValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIriReference"/> struct.
        /// </summary>
        /// <param name="jsonElement">The JSON element from which to construct the object.</param>
        public JsonIriReference(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.value = default;
            this.localUriValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIriReference"/> struct.
        /// </summary>
        /// <param name="value">The string value.</param>
        public JsonIriReference(JsonString value)
        {
            if (value.HasJsonElement)
            {
                this.jsonElement = value.AsJsonElement;
                this.value = default;
                this.localUriValue = default;
            }
            else
            {
                this.jsonElement = default;
                this.value = value.GetJsonEncodedText();
                this.localUriValue = default;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIriReference"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonIriReference(string value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localUriValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIriReference"/> struct.
        /// </summary>
        /// <param name="value">The base 64 encoded string value.</param>
        public JsonIriReference(JsonEncodedText value)
        {
            this.jsonElement = default;
            this.value = value;
            this.localUriValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIriReference"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonIriReference(ReadOnlySpan<char> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localUriValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIriReference"/> struct.
        /// </summary>
        /// <param name="value">The utf8-encoded string value.</param>
        public JsonIriReference(ReadOnlySpan<byte> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localUriValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIriReference"/> struct.
        /// </summary>
        /// <param name="value">The Uri value.</param>
        public JsonIriReference(Uri value)
        {
            this.jsonElement = default;
            this.value = FormatUri(value);
            this.localUriValue = value;
        }

        /// <summary>
        /// Gets the <see cref="JsonValueKind"/>.
        /// </summary>
        public JsonValueKind ValueKind
        {
            get
            {
                if (this.value is not null)
                {
                    return JsonValueKind.String;
                }

                return this.jsonElement.ValueKind;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is backed by a <see cref="JsonElement"/>.
        /// </summary>
        public bool HasJsonElement => this.value is null;

        /// <summary>
        /// Gets the backing <see cref="JsonElement"/>.
        /// </summary>
        public JsonElement AsJsonElement
        {
            get
            {
                if (this.value is JsonEncodedText value)
                {
                    return JsonString.StringToJsonElement(value);
                }

                return this.jsonElement;
            }
        }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
                if (this.value is JsonEncodedText value)
                {
                    return new JsonAny(value);
                }
                else
                {
                    return new JsonAny(this.jsonElement);
                }
            }
        }

        /// <summary>
        /// Implicit conversion to JsonString.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonString(JsonIriReference value)
        {
            if (value.value is JsonEncodedText jet)
            {
                return new JsonString(jet);
            }
            else
            {
                return new JsonString(value.jsonElement);
            }
        }

        /// <summary>
        /// Implicit conversion from JsonString.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIriReference(JsonString value)
        {
            return new JsonIriReference(value);
        }

        /// <summary>
        /// Implicit conversion to Uri.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Uri(JsonIriReference value)
        {
            return value.GetUri();
        }

        /// <summary>
        /// Implicit conversion from Uri.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIriReference(Uri value)
        {
            return new JsonIriReference(value);
        }

        /// <summary>
        /// Implicit conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(JsonIriReference value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIriReference(JsonAny value)
        {
            return value.AsString;
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIriReference(string value)
        {
            return new JsonIriReference(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator string(JsonIriReference value)
        {
            return value.GetString();
        }

        /// <summary>
        /// Conversion from <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIriReference(JsonEncodedText value)
        {
            return new JsonIriReference(value);
        }

        /// <summary>
        /// Conversion to <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator JsonEncodedText(JsonIriReference value)
        {
            return value.GetJsonEncodedText();
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIriReference(ReadOnlySpan<char> value)
        {
            return new JsonIriReference(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<char>(JsonIriReference value)
        {
            return value.AsSpan();
        }

        /// <summary>
        /// Conversion from utf8 bytes.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIriReference(ReadOnlySpan<byte> value)
        {
            return new JsonIriReference(value);
        }

        /// <summary>
        /// Conversion to utf8 bytes.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<byte>(JsonIriReference value)
        {
            return value.GetJsonEncodedText().EncodedUtf8Bytes;
        }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(JsonIriReference lhs, JsonIriReference rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(JsonIriReference lhs, JsonIriReference rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;

            return Json.Validate.TypeIriReference(this, result, level);
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonIriReference))
            {
                return CastTo<T>.From(this);
            }

            if (typeof(T) == typeof(JsonString))
            {
                if (this.value is JsonEncodedText value)
                {
                    return CastTo<T>.From(new JsonString(value));
                }
                else
                {
                    return CastTo<T>.From(new JsonString(this.jsonElement));
                }
            }

            return this.As<JsonIriReference, T>();
        }

        /// <summary>
        /// Get the value as <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <returns>The JsonEncodedText.</returns>
        public JsonEncodedText GetJsonEncodedText()
        {
            if (this.TryGetJsonEncodedText(out JsonEncodedText result))
            {
                return result;
            }

            return default;
        }

        /// <summary>
        /// Gets the string as <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="result">The value as JsonEncodedText.</param>
        /// <returns><c>True</c> if the value could be retrieved.</returns>
        public bool TryGetJsonEncodedText(out JsonEncodedText result)
        {
            if (this.value is JsonEncodedText value)
            {
                result = value;
                return true;
            }

            if (this.jsonElement.ValueKind == JsonValueKind.String)
            {
                string? str = this.jsonElement.GetString();
                result = JsonEncodedText.Encode(str!);
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// Gets the value as a string.
        /// </summary>
        /// <returns>The value as a string.</returns>
        public string GetString()
        {
            if (this.TryGetString(out string result))
            {
                return result;
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the value as a string.
        /// </summary>
        /// <param name="result">The value as a string.</param>
        /// <returns><c>True</c> if the value could be retrieved.</returns>
        public bool TryGetString(out string result)
        {
            if (this.value is JsonEncodedText value)
            {
                result = value.ToString();
                return true;
            }

            if (this.jsonElement.ValueKind == JsonValueKind.String)
            {
                string? str = this.jsonElement.GetString();
                result = str!;
                return true;
            }

            result = string.Empty;
            return false;
        }

        /// <summary>
        /// Gets the value as a Guid.
        /// </summary>
        /// <returns>The value as a Guid.</returns>
        public Uri GetUri()
        {
            if (this.TryGetUri(out Uri result))
            {
                return result;
            }

            return EmptyUri;
        }

        /// <summary>
        /// Try to get the date value.
        /// </summary>
        /// <param name="result">The date value.</param>
        /// <returns><c>True</c> if it was possible to get a date value from the instance.</returns>
        public bool TryGetUri(out Uri result)
        {
            if (this.localUriValue is Uri localUri)
            {
                result = localUri;
                return true;
            }

            if (this.value is JsonEncodedText value)
            {
                return TryParseUri(value, out result);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.String)
            {
                string? str = this.jsonElement.GetString();
                return TryParseUri(str!, out result);
            }

            result = EmptyUri;
            return false;
        }

        /// <summary>
        /// Gets the value as a span.
        /// </summary>
        /// <returns>The value as a span of char.</returns>
        public ReadOnlySpan<char> AsSpan()
        {
            if (this.value is JsonEncodedText value)
            {
                Span<char> output = stackalloc char[value.EncodedUtf8Bytes.Length];
                int writtenChars = Encoding.UTF8.GetChars(value.EncodedUtf8Bytes, output);
                Span<char> result = new char[writtenChars];
                output.Slice(0, writtenChars).CopyTo(result);
                return result;
            }

            if (this.jsonElement.ValueKind == JsonValueKind.String)
            {
                string? str = this.jsonElement.GetString();
                return str!.AsSpan();
            }

            return ReadOnlySpan<char>.Empty;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is JsonIriReference jany)
            {
                return this.Equals(jany);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            JsonValueKind valueKind = this.ValueKind;

            return valueKind switch
            {
                JsonValueKind.String => this.AsString().GetHashCode(),
                JsonValueKind.Null => JsonNull.NullHashCode,
                _ => 0,
            };
        }

        /// <summary>
        /// Writes the string to the <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.value is JsonEncodedText value)
            {
                writer.WriteStringValue(value);
            }
            else
            {
                this.jsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            if (other.ValueKind != JsonValueKind.String)
            {
                return false;
            }

            return this.AsString().Equals(other.AsString());
        }

        /// <inheritdoc/>
        public bool Equals(JsonIriReference other)
        {
            if (other.ValueKind != this.ValueKind || this.ValueKind != JsonValueKind.String)
            {
                return false;
            }

            return this.AsString().Equals(other.AsString());
        }

        private static JsonEncodedText FormatUri(Uri value)
        {
            return JsonEncodedText.Encode(value.OriginalString);
        }

        private static bool TryParseUri(JsonEncodedText text, out Uri value)
        {
            return TryParseUri(text.ToString(), out value);
        }

        private static bool TryParseUri(string text, out Uri value)
        {
            return Uri.TryCreate(text, UriKind.RelativeOrAbsolute, out value);
        }
    }
}
