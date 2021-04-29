// <copyright file="JsonUuid.cs" company="Endjin Limited">
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
    public readonly struct JsonUuid : IJsonValue, IEquatable<JsonUuid>
    {
        private readonly JsonElement jsonElement;
        private readonly JsonEncodedText? value;
        private readonly Guid? localGuidValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUuid"/> struct.
        /// </summary>
        /// <param name="jsonElement">The JSON element from which to construct the object.</param>
        public JsonUuid(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.value = default;
            this.localGuidValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUuid"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonUuid(string value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localGuidValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUuid"/> struct.
        /// </summary>
        /// <param name="value">The base 64 encoded string value.</param>
        public JsonUuid(JsonEncodedText value)
        {
            this.jsonElement = default;
            this.value = value;
            this.localGuidValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUuid"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonUuid(ReadOnlySpan<char> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localGuidValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUuid"/> struct.
        /// </summary>
        /// <param name="value">The utf8-encoded string value.</param>
        public JsonUuid(ReadOnlySpan<byte> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localGuidValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUuid"/> struct.
        /// </summary>
        /// <param name="value">The Guid value.</param>
        public JsonUuid(Guid value)
        {
            this.jsonElement = default;
            this.value = FormatGuid(value);
            this.localGuidValue = value;
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
        public static implicit operator JsonString(JsonUuid value)
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
        public static implicit operator JsonUuid(JsonString value)
        {
            if (value.HasJsonElement)
            {
                return new JsonUuid(value.AsJsonElement);
            }
            else
            {
                return new JsonUuid((JsonEncodedText)value);
            }
        }

        /// <summary>
        /// Implicit conversion to Guid.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Guid(JsonUuid value)
        {
            return value.GetGuid();
        }

        /// <summary>
        /// Implicit conversion from Guid.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonUuid(Guid value)
        {
            return new JsonUuid(value);
        }

        /// <summary>
        /// Implicit conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(JsonUuid value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonUuid(JsonAny value)
        {
            return value.AsString;
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonUuid(string value)
        {
            return new JsonUuid(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator string(JsonUuid value)
        {
            return value.GetString();
        }

        /// <summary>
        /// Conversion from <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonUuid(JsonEncodedText value)
        {
            return new JsonUuid(value);
        }

        /// <summary>
        /// Conversion to <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator JsonEncodedText(JsonUuid value)
        {
            return value.GetJsonEncodedText();
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonUuid(ReadOnlySpan<char> value)
        {
            return new JsonUuid(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<char>(JsonUuid value)
        {
            return value.AsSpan();
        }

        /// <summary>
        /// Conversion from utf8 bytes.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonUuid(ReadOnlySpan<byte> value)
        {
            return new JsonUuid(value);
        }

        /// <summary>
        /// Conversion to utf8 bytes.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<byte>(JsonUuid value)
        {
            return value.GetJsonEncodedText().EncodedUtf8Bytes;
        }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(JsonUuid lhs, JsonUuid rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(JsonUuid lhs, JsonUuid rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;

            return Json.Validate.TypeUuid(this, result, level);
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonUuid))
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

            return this.As<JsonUuid, T>();
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
        public Guid GetGuid()
        {
            if (this.TryGetGuid(out Guid result))
            {
                return result;
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Try to get the Guid value.
        /// </summary>
        /// <param name="result">The guid value.</param>
        /// <returns><c>True</c> if it was possible to get a guid value from the instance.</returns>
        public bool TryGetGuid(out Guid result)
        {
            if (this.localGuidValue is Guid localGuid)
            {
                result = localGuid;
                return true;
            }

            if (this.value is JsonEncodedText value)
            {
                return TryParseGuid(value, out result);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.String)
            {
                string? str = this.jsonElement.GetString();
                return TryParseGuid(str!, out result);
            }

            result = Guid.Empty;
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
            if (obj is JsonUuid jany)
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
        public bool Equals(JsonUuid other)
        {
            if (other.ValueKind != this.ValueKind || this.ValueKind != JsonValueKind.String)
            {
                return false;
            }

            return this.AsString().Equals(other.AsString());
        }

        private static JsonEncodedText FormatGuid(Guid value)
        {
            return JsonEncodedText.Encode(value.ToString("D"));
        }

        private static bool TryParseGuid(JsonEncodedText text, out Guid value)
        {
            return TryParseGuid(text.ToString(), out value);
        }

        private static bool TryParseGuid(string text, out Guid value)
        {
            return Guid.TryParse(text, out value);
        }
    }
}
