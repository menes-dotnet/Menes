﻿// <copyright file="JsonTime.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Text;
    using System.Text.Json;
    using Corvus.Extensions;
    using NodaTime;
    using NodaTime.Text;

    /// <summary>
    /// A JSON object.
    /// </summary>
    public readonly struct JsonTime : IJsonValue, IEquatable<JsonTime>
    {
        private readonly JsonElement jsonElement;
        private readonly JsonEncodedText? value;
        private readonly OffsetTime? localDateValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTime"/> struct.
        /// </summary>
        /// <param name="jsonElement">The JSON element from which to construct the object.</param>
        public JsonTime(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.value = default;
            this.localDateValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTime"/> struct.
        /// </summary>
        /// <param name="value">The string value.</param>
        public JsonTime(JsonString value)
        {
            if (value.HasJsonElement)
            {
                this.jsonElement = value.AsJsonElement;
                this.value = default;
                this.localDateValue = default;
            }
            else
            {
                this.jsonElement = default;
                this.value = value.GetJsonEncodedText();
                this.localDateValue = default;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTime"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonTime(string value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localDateValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTime"/> struct.
        /// </summary>
        /// <param name="value">The base 64 encoded string value.</param>
        public JsonTime(JsonEncodedText value)
        {
            this.jsonElement = default;
            this.value = value;
            this.localDateValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTime"/> struct.
        /// </summary>
        /// <param name="value">The base64 encoded string value.</param>
        public JsonTime(ReadOnlySpan<char> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localDateValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTime"/> struct.
        /// </summary>
        /// <param name="value">The utf8-encoded string value.</param>
        public JsonTime(ReadOnlySpan<byte> value)
        {
            this.jsonElement = default;
            this.value = JsonEncodedText.Encode(value);
            this.localDateValue = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTime"/> struct.
        /// </summary>
        /// <param name="value">The NodaTime time value.</param>
        public JsonTime(OffsetTime value)
        {
            this.jsonElement = default;
            this.value = FormatTime(value);
            this.localDateValue = value;
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
        public static implicit operator JsonString(JsonTime value)
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
        public static implicit operator JsonTime(JsonString value)
        {
            return new JsonTime(value);
        }

        /// <summary>
        /// Implicit conversion to OffsetTime.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator OffsetTime(JsonTime value)
        {
            return value.GetDate();
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonTime(OffsetTime value)
        {
            return new JsonTime(value);
        }

        /// <summary>
        /// Implicit conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(JsonTime value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonTime(JsonAny value)
        {
            return value.AsString;
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonTime(string value)
        {
            return new JsonTime(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator string(JsonTime value)
        {
            return value.GetString();
        }

        /// <summary>
        /// Conversion from <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonTime(JsonEncodedText value)
        {
            return new JsonTime(value);
        }

        /// <summary>
        /// Conversion to <see cref="JsonEncodedText"/>.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator JsonEncodedText(JsonTime value)
        {
            return value.GetJsonEncodedText();
        }

        /// <summary>
        /// Conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonTime(ReadOnlySpan<char> value)
        {
            return new JsonTime(value);
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<char>(JsonTime value)
        {
            return value.AsSpan();
        }

        /// <summary>
        /// Conversion from utf8 bytes.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonTime(ReadOnlySpan<byte> value)
        {
            return new JsonTime(value);
        }

        /// <summary>
        /// Conversion to utf8 bytes.
        /// </summary>
        /// <param name="value">The number from which to convert.</param>
        public static implicit operator ReadOnlySpan<byte>(JsonTime value)
        {
            return value.GetJsonEncodedText().EncodedUtf8Bytes;
        }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(JsonTime lhs, JsonTime rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(JsonTime lhs, JsonTime rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;

            return Json.Validate.TypeTime(this, result, level);
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonTime))
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

            return this.As<JsonTime, T>();
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
        /// Gets the value as a OffsetTime.
        /// </summary>
        /// <returns>The value as a OffsetTime.</returns>
        public OffsetTime GetDate()
        {
            if (this.TryGetTime(out OffsetTime result))
            {
                return result;
            }

            return default;
        }

        /// <summary>
        /// Try to get the time value.
        /// </summary>
        /// <param name="result">The time value.</param>
        /// <returns><c>True</c> if it was possible to get a time value from the instance.</returns>
        public bool TryGetTime(out OffsetTime result)
        {
            if (this.localDateValue is OffsetTime localDateValue)
            {
                result = localDateValue;
                return true;
            }

            if (this.value is JsonEncodedText value)
            {
                return TryParseTime(value, out result);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.String)
            {
                string? str = this.jsonElement.GetString();
                return TryParseTime(str!, out result);
            }

            result = default;
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
            if (obj is JsonTime jany)
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

            if (!TryParseTime((string)other.AsString(), out OffsetTime otherDate))
            {
                return false;
            }

            if (!this.TryGetTime(out OffsetTime thisDate))
            {
                return false;
            }

            return thisDate.Equals(otherDate);
        }

        /// <inheritdoc/>
        public bool Equals(JsonTime other)
        {
            if (other.ValueKind != this.ValueKind || this.ValueKind != JsonValueKind.String)
            {
                return false;
            }

            if (!this.TryGetTime(out OffsetTime thisDate))
            {
                return false;
            }

            if (!other.TryGetTime(out OffsetTime otherDate))
            {
                return false;
            }

            return thisDate.Equals(otherDate);
        }

        private static JsonEncodedText FormatTime(OffsetTime value)
        {
            return JsonEncodedText.Encode(OffsetTimePattern.ExtendedIso.Format(value));
        }

        private static bool TryParseTime(JsonEncodedText text, out OffsetTime value)
        {
            return TryParseTime(text.ToString(), out value);
        }

        private static bool TryParseTime(string text, out OffsetTime value)
        {
            ParseResult<OffsetTime> parseResult = OffsetTimePattern.ExtendedIso.Parse(text);
            if (parseResult.Success)
            {
                value = parseResult.Value;
                return true;
            }

            value = default;
            return false;
        }
    }
}
