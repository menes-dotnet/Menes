﻿// <copyright file="JsonIpV4.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Net;
    using System.Text;
    using System.Text.Json;
    using Corvus.Extensions;
    using NodaTime;
    using NodaTime.Text;

    /// <summary>
    /// A JSON object.
    /// </summary>
    public readonly struct JsonIpV4 : IJsonValue, IEquatable<JsonIpV4>
    {
        private readonly JsonElement jsonElement;
        private readonly JsonEncodedText? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIpV4"/> struct.
        /// </summary>
        /// <param name="jsonElement">The JSON element from which to construct the object.</param>
        public JsonIpV4(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.value = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIpV4"/> struct.
        /// </summary>
        /// <param name="value">The string value.</param>
        public JsonIpV4(JsonString value)
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
        /// Initializes a new instance of the <see cref="JsonIpV4"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonIpV4(string value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIpV4"/> struct.
        /// </summary>
        /// <param name="value">The base 64 encoded string value.</param>
        public JsonIpV4(JsonEncodedText value)
        {
            this.jsonElement = default;
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIpV4"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonIpV4(ReadOnlySpan<char> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIpV4"/> struct.
        /// </summary>
        /// <param name="value">The utf8-encoded string value.</param>
        public JsonIpV4(ReadOnlySpan<byte> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIpV4"/> struct.
        /// </summary>
        /// <param name="value">The utf8-encoded string value.</param>
        public JsonIpV4(IPAddress value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value.ToString());
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
        public static implicit operator JsonString(JsonIpV4 value)
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
        public static implicit operator JsonIpV4(JsonString value)
        {
            return new JsonIpV4(value);
        }

        /// <summary>
        /// Implicit conversion to IPAddress.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator IPAddress(JsonIpV4 value)
        {
            return value.GetIPAddress();
        }

        /// <summary>
        /// Implicit conversion from IPaddress.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIpV4(IPAddress value)
        {
            return new JsonIpV4(value);
        }

        /// <summary>
        /// Implicit conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(JsonIpV4 value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIpV4(JsonAny value)
        {
            return value.AsString;
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIpV4(string value)
        {
            return new JsonIpV4(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator string(JsonIpV4 value)
        {
            return value.GetString();
        }

        /// <summary>
        /// Conversion from <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIpV4(JsonEncodedText value)
        {
            return new JsonIpV4(value);
        }

        /// <summary>
        /// Conversion to <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator JsonEncodedText(JsonIpV4 value)
        {
            return value.GetJsonEncodedText();
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIpV4(ReadOnlySpan<char> value)
        {
            return new JsonIpV4(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<char>(JsonIpV4 value)
        {
            return value.AsSpan();
        }

        /// <summary>
        /// Conversion from utf8 bytes.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonIpV4(ReadOnlySpan<byte> value)
        {
            return new JsonIpV4(value);
        }

        /// <summary>
        /// Conversion to utf8 bytes.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<byte>(JsonIpV4 value)
        {
            return value.GetJsonEncodedText().EncodedUtf8Bytes;
        }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(JsonIpV4 lhs, JsonIpV4 rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(JsonIpV4 lhs, JsonIpV4 rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;

            return Json.Validate.TypeIpV4(this, result, level);
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonIpV4))
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

            return this.As<JsonIpV4, T>();
        }

        /// <summary>
        /// Get the value as <see cref="IPAddress"/>.
        /// </summary>
        /// <returns>The IPAddress.</returns>
        public IPAddress GetIPAddress()
        {
            if (this.TryGetIPAddress(out IPAddress result))
            {
                return result;
            }

            return IPAddress.None;
        }

        /// <summary>
        /// Gets the string as <see cref="IPAddress"/>.
        /// </summary>
        /// <param name="result">The value as IPAddress.</param>
        /// <returns><c>True</c> if the value could be retrieved.</returns>
        public bool TryGetIPAddress(out IPAddress result)
        {
            if (this.value is JsonEncodedText jet)
            {
                Span<char> ipadr = stackalloc char[Encoding.UTF8.GetMaxCharCount(jet.EncodedUtf8Bytes.Length)];
                int charsWritten = Encoding.UTF8.GetChars(jet.EncodedUtf8Bytes, ipadr);

                return IPAddress.TryParse(ipadr.Slice(0, charsWritten), out result);
            }
            else if (this.jsonElement.ValueKind == JsonValueKind.String)
            {
                return IPAddress.TryParse(this.jsonElement.GetString(), out result);
            }

            result = IPAddress.None;
            return false;
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

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is JsonIpV4 jany)
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
        public bool Equals(JsonIpV4 other)
        {
            if (other.ValueKind != this.ValueKind || this.ValueKind != JsonValueKind.String)
            {
                return false;
            }

            return this.AsString().Equals(other.AsString());
        }

        private static JsonEncodedText FormatPeriod(Period value)
        {
            return JsonEncodedText.Encode(PeriodPattern.NormalizingIso.Format(value));
        }

        private static bool TryParseDate(JsonEncodedText text, out Period value)
        {
            return TryParseDate(text.ToString(), out value);
        }

        private static bool TryParseDate(string text, out Period value)
        {
            string tupper = text;
            foreach (char character in text)
            {
                if (char.IsLower(character))
                {
                    tupper = text.ToUpperInvariant();
                    break;
                }
            }

            ParseResult<Period> parseResult = PeriodPattern.NormalizingIso.Parse(tupper);
            if (parseResult.Success)
            {
                value = parseResult.Value;
                return true;
            }

            value = Period.Zero;
            return false;
        }
    }
}
