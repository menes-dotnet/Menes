// <copyright file="JsonRegex.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Text;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using Corvus.Extensions;

    /// <summary>
    /// A JSON object.
    /// </summary>
    public readonly struct JsonRegex : IJsonValue, IEquatable<JsonRegex>
    {
        private static readonly Regex Empty = new Regex(".*", RegexOptions.None);
        private readonly JsonElement jsonElement;
        private readonly JsonEncodedText? value;
        private readonly Regex? localRegexValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRegex"/> struct.
        /// </summary>
        /// <param name="jsonElement">The JSON element from which to construct the object.</param>
        public JsonRegex(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.value = default;
            this.localRegexValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRegex"/> struct.
        /// </summary>
        /// <param name="value">The string value.</param>
        public JsonRegex(JsonString value)
        {
            if (value.HasJsonElement)
            {
                this.jsonElement = value.AsJsonElement;
                this.value = default;
                this.localRegexValue = default;
            }
            else
            {
                this.jsonElement = default;
                this.value = value.GetJsonEncodedText();
                this.localRegexValue = default;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRegex"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonRegex(string value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localRegexValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRegex"/> struct.
        /// </summary>
        /// <param name="value">The base 64 encoded string value.</param>
        public JsonRegex(JsonEncodedText value)
        {
            this.jsonElement = default;
            this.value = value;
            this.localRegexValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRegex"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonRegex(ReadOnlySpan<char> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localRegexValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRegex"/> struct.
        /// </summary>
        /// <param name="value">The utf8-encoded string value.</param>
        public JsonRegex(ReadOnlySpan<byte> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localRegexValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRegex"/> struct.
        /// </summary>
        /// <param name="value">The Regex value.</param>
        public JsonRegex(Regex value)
        {
            this.jsonElement = default;
            this.value = FormatRegex(value);
            this.localRegexValue = value;
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
        public static implicit operator JsonString(JsonRegex value)
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
        public static implicit operator JsonRegex(JsonString value)
        {
            return new JsonRegex(value);
        }

        /// <summary>
        /// Implicit conversion to Regex.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Regex(JsonRegex value)
        {
            return value.GetRegex();
        }

        /// <summary>
        /// Implicit conversion from Regex.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonRegex(Regex value)
        {
            return new JsonRegex(value);
        }

        /// <summary>
        /// Implicit conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(JsonRegex value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonRegex(JsonAny value)
        {
            return value.AsString;
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonRegex(string value)
        {
            return new JsonRegex(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator string(JsonRegex value)
        {
            return value.GetString();
        }

        /// <summary>
        /// Conversion from <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonRegex(JsonEncodedText value)
        {
            return new JsonRegex(value);
        }

        /// <summary>
        /// Conversion to <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator JsonEncodedText(JsonRegex value)
        {
            return value.GetJsonEncodedText();
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonRegex(ReadOnlySpan<char> value)
        {
            return new JsonRegex(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<char>(JsonRegex value)
        {
            return value.AsSpan();
        }

        /// <summary>
        /// Conversion from utf8 bytes.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonRegex(ReadOnlySpan<byte> value)
        {
            return new JsonRegex(value);
        }

        /// <summary>
        /// Conversion to utf8 bytes.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<byte>(JsonRegex value)
        {
            return value.GetJsonEncodedText().EncodedUtf8Bytes;
        }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(JsonRegex lhs, JsonRegex rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(JsonRegex lhs, JsonRegex rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;

            return Json.Validate.TypeRegex(this, result, level);
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonRegex))
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

            return this.As<JsonRegex, T>();
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
        /// Gets the value as a Regex.
        /// </summary>
        /// <param name="options">The regular experssion options (<see cref="RegexOptions.None"/> by default).</param>
        /// <returns>The value as a Regex.</returns>
        public Regex GetRegex(RegexOptions options = RegexOptions.None)
        {
            if (this.TryGetRegex(out Regex result, options))
            {
                return result;
            }

            return Empty;
        }

        /// <summary>
        /// Try to get the Regex value.
        /// </summary>
        /// <param name="result">The regex value.</param>
        /// <param name="options">The regular experssion options (<see cref="RegexOptions.None"/> by default).</param>
        /// <returns><c>True</c> if it was possible to get a regex value from the instance.</returns>
        public bool TryGetRegex(out Regex result, RegexOptions options = RegexOptions.None)
        {
            if (this.localRegexValue is Regex localRegex)
            {
                result = localRegex;
                return true;
            }

            if (this.value is JsonEncodedText value)
            {
                return TryParseRegex(value, options, out result);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.String)
            {
                string? str = this.jsonElement.GetString();
                return TryParseRegex(str!, options, out result);
            }

            result = Empty;
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
            if (obj is JsonRegex jany)
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
        public bool Equals(JsonRegex other)
        {
            if (other.ValueKind != this.ValueKind || this.ValueKind != JsonValueKind.String)
            {
                return false;
            }

            return this.AsString().Equals(other.AsString());
        }

        private static JsonEncodedText FormatRegex(Regex value)
        {
            return JsonEncodedText.Encode(value.ToString());
        }

        private static bool TryParseRegex(JsonEncodedText text, RegexOptions options, out Regex value)
        {
            return TryParseRegex(text.ToString(), options, out value);
        }

        private static bool TryParseRegex(string text, RegexOptions options, out Regex value)
        {
            try
            {
                value = new Regex(text, options);
                return true;
            }
            catch (Exception)
            {
                value = Empty;
                return false;
            }
        }
    }
}
