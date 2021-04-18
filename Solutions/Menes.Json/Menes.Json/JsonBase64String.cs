// <copyright file="JsonBase64String.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Buffers;
    using System.Buffers.Text;
    using System.Text;
    using System.Text.Json;
    using Corvus.Extensions;

    /// <summary>
    /// A JSON object.
    /// </summary>
    public readonly struct JsonBase64String : IJsonValue, IEquatable<JsonBase64String>
    {
        private readonly JsonElement jsonElement;
        private readonly JsonEncodedText? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="jsonElement">The JSON element from which to construct the object.</param>
        public JsonBase64String(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.value = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="value">The string value.</param>
        public JsonBase64String(JsonString value)
        {
            if (value.HasJsonElement)
            {
                this.jsonElement = value.AsJsonElement;
                this.value = default;
            }
            else
            {
                this.jsonElement = default;
                this.value = value.GetJsonEncodedText();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonBase64String(string value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="value">The base 64 encoded string value.</param>
        public JsonBase64String(JsonEncodedText value)
        {
            this.jsonElement = default;
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonBase64String(ReadOnlySpan<char> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="value">The utf8-encoded string value.</param>
        public JsonBase64String(ReadOnlySpan<byte> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
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
        public static implicit operator JsonString(JsonBase64String value)
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
        public static implicit operator JsonBase64String(JsonString value)
        {
            return new JsonBase64String(value);
        }

        /// <summary>
        /// Implicit conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(JsonBase64String value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonBase64String(JsonAny value)
        {
            return value.AsString;
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonBase64String(string value)
        {
            return new JsonBase64String(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator string(JsonBase64String value)
        {
            return value.GetString();
        }

        /// <summary>
        /// Conversion from <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonBase64String(JsonEncodedText value)
        {
            return new JsonBase64String(value);
        }

        /// <summary>
        /// Conversion to <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator JsonEncodedText(JsonBase64String value)
        {
            return value.GetJsonEncodedText();
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonBase64String(ReadOnlySpan<char> value)
        {
            return new JsonBase64String(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<char>(JsonBase64String value)
        {
            return value.AsSpan();
        }

        /// <summary>
        /// Conversion from utf8 bytes.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonBase64String(ReadOnlySpan<byte> value)
        {
            return new JsonBase64String(value);
        }

        /// <summary>
        /// Conversion to utf8 bytes.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<byte>(JsonBase64String value)
        {
            return value.GetJsonEncodedText().EncodedUtf8Bytes;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="JsonBase64String"/> struct from a byte arrary.
        /// </summary>
        /// <param name="value">The <see cref="ReadOnlySpan{T}"/> of <see cref="byte"/> from which to construct the Base64 content.</param>
        /// <returns>The base 64 encoded string represnetation of the byte array.</returns>
        /// <remarks>This encodes the byte array as a base 64 string.</remarks>
        public static JsonBase64String FromByteArray(ReadOnlySpan<byte> value)
        {
            Span<byte> utf8Bytes = stackalloc byte[Base64.GetMaxEncodedToUtf8Length(value.Length)];
            Base64.EncodeToUtf8(value, utf8Bytes, out int bytesConsumed, out int bytesWritten);
            byte[] result = new byte[bytesWritten];
            utf8Bytes.CopyTo(result);
            return new JsonBase64String(JsonEncodedText.Encode(result));
        }

        /// <summary>
        /// Get the base64 encoded string.
        /// </summary>
        /// <returns>The base 64 encoded string.</returns>
        public ReadOnlySpan<char> GetBase64EncodedString()
        {
            if (this.value is JsonEncodedText value)
            {
                Span<char> result = stackalloc char[value.EncodedUtf8Bytes.Length];
                int written = Encoding.UTF8.GetChars(value.EncodedUtf8Bytes, result);
                char[] chars = new char[written];
                result.Slice(0, written).CopyTo(chars);
                return chars;
            }
            else if (this.ValueKind == JsonValueKind.String)
            {
                string? result = this.jsonElement.GetString();
                if (result is null)
                {
                    return ReadOnlySpan<char>.Empty;
                }

                return result;
            }

            return ReadOnlySpan<char>.Empty;
        }

        /// <summary>
        /// Get the base64 encoded string.
        /// </summary>
        /// <returns>The base 64 encoded string.</returns>
        public ReadOnlySpan<byte> GetEncodedUtf8BytesBase64EncodedString()
        {
            return this.GetJsonEncodedText().EncodedUtf8Bytes;
        }

        /// <summary>
        /// Get the decoded base64 bytes.
        /// </summary>
        /// <returns>The base 64 bytes.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "StyleCop does not handle nullable arrays correctly.")]
        public ReadOnlySpan<byte> GetDecodedBase64Bytes()
        {
            if (this.value is JsonEncodedText value)
            {
                Span<byte> decoded = stackalloc byte[Base64.GetMaxDecodedFromUtf8Length(value.EncodedUtf8Bytes.Length)];
                OperationStatus operationStatus = Base64.DecodeFromUtf8(value.EncodedUtf8Bytes, decoded, out int bytesConsumed, out int bytesWritten);
                if (!operationStatus.HasFlag(OperationStatus.Done))
                {
                    return ReadOnlySpan<byte>.Empty;
                }

                Span<byte> result = new byte[bytesWritten];
                decoded.Slice(0, bytesWritten).CopyTo(result);
                return result;
            }

            if (this.jsonElement.ValueKind == JsonValueKind.String)
            {
                if (this.jsonElement.TryGetBytesFromBase64(out byte[]? decoded))
                {
                    return decoded;
                }
            }

            return ReadOnlySpan<byte>.Empty;
        }

        /// <summary>
        /// Get a value indicating whether this instance has a Base64-encodedbye array.
        /// </summary>
        /// <returns>The base 64 bytes.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "StyleCop does not handle nullable arrays correctly.")]
        public bool HasBase64Bytes()
        {
            if (this.value is JsonEncodedText value)
            {
                Span<byte> decoded = stackalloc byte[Base64.GetMaxDecodedFromUtf8Length(value.EncodedUtf8Bytes.Length)];
                OperationStatus operationStatus = Base64.DecodeFromUtf8(value.EncodedUtf8Bytes, decoded, out int bytesConsumed, out int bytesWritten);
                return operationStatus.HasFlag(OperationStatus.Done);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.String)
            {
                return this.jsonElement.TryGetBytesFromBase64(out byte[]? _);
            }

            return false;
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;

            JsonValueKind valueKind = this.ValueKind;

            if (valueKind != JsonValueKind.String)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    return result.WithResult(isValid: false, $"Validation 6.1.1 type - should have been 'string' with contentEncoding 'base64' but was '{valueKind}'.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    return result.WithResult(isValid: false, "Validation 6.1.1 type - should have been 'string' with contentEncoding 'base64'.");
                }
                else
                {
                    return result.WithResult(isValid: false);
                }
            }

            if (!this.HasBase64Bytes())
            {
                if (level >= ValidationLevel.Detailed)
                {
                    return result.WithResult(isValid: false, $"Validation 8.3 contentEncoding - should have been a base64 encoded 'string'.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    return result.WithResult(isValid: false, "Validation 8.3 contentEncoding - should have been a base64 encoded 'string'.");
                }
                else
                {
                    return result.WithResult(isValid: false);
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                return result
                    .WithResult(isValid: true, "Validation 8.3 contentEncoding - was a base64 encoded 'string'.");
            }

            return result;
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
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

            return this.As<JsonBase64String, T>();
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

            return this.Equals(other.AsString());
        }

        /// <inheritdoc/>
        public bool Equals(JsonBase64String other)
        {
            if (other.ValueKind != this.ValueKind || this.ValueKind != JsonValueKind.String)
            {
                return false;
            }

            return this.GetJsonEncodedText().Equals(other.GetJsonEncodedText());
        }
    }
}
