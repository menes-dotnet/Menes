// <copyright file="JsonBase64Content.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Text.Json;

    /// <summary>
    /// Represents the uuid json type.
    /// </summary>
    public readonly struct JsonBase64Content : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonBase64Content Null = default;

        private readonly JsonDocument? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64Content"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element containing a base 64 string.</param>
        public JsonBase64Content(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64Content"/> struct.
        /// </summary>
        /// <param name="value">The backing base64-encoded string.</param>
        public JsonBase64Content(JsonDocument value)
        {
            this.value = value;
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64Content"/> struct.
        /// </summary>
        /// <param name="value">The backing base64-encoded string.</param>
        public JsonBase64Content(string value)
        {
            this.value = JsonDocument.Parse(Convert.FromBase64String(value));
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64Content"/> struct.
        /// </summary>
        /// <param name="value">The backing base64-encoded string.</param>
        public JsonBase64Content(ReadOnlySpan<char> value)
        {
            Span<byte> bytes = stackalloc byte[value.Length];
            Convert.TryFromBase64Chars(value, bytes, out int bytesWritten);
            this.value = JsonDocument.Parse(bytes.Slice(0, bytesWritten).ToArray());
            this.JsonElement = default;
        }

        /// <inheritdoc />
        public bool IsUndefined => this.JsonElement.ValueKind == JsonValueKind.Undefined && this.value is null;

        /// <inheritdoc />
        public bool IsNull => (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null) && this.value is null;

        /// <inheritdoc />
        public bool IsNumber => false;

        /// <inheritdoc />
        public bool IsInteger => false;

        /// <inheritdoc />
        public bool IsString => this.JsonElement.ValueKind == JsonValueKind.String || this.value is not null;

        /// <inheritdoc />
        public bool IsObject => false;

        /// <inheritdoc />
        public bool IsBoolean => false;

        /// <inheritdoc />
        public bool IsArray => false;

        /// <inheritdoc />
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc />
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion from a base64 encoded string.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonBase64Content(string value)
        {
            return new JsonBase64Content(value);
        }

        /// <summary>
        /// Implicit conversion to a base64-encoded <see cref="string"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator string(JsonBase64Content value)
        {
            return value.GetBase64EncodedString();
        }

        /// <summary>
        /// Implicit conversion from a base64 encoded string.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonBase64Content(ReadOnlySpan<char> value)
        {
            return new JsonBase64Content(value);
        }

        /// <summary>
        /// Implicit conversion from <see cref="JsonDocument"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonBase64Content(JsonDocument value)
        {
            return new JsonBase64Content(value);
        }

        /// <summary>
        /// Implicit conversion to a <see cref="JsonDocument"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonDocument(JsonBase64Content value)
        {
            return value.GetJsonDocument();
        }

        /// <summary>
        /// Gets the <see cref="JsonBase64Content"/> as a base64 encoded <see cref="string"/>.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public string GetBase64EncodedString()
        {
            return (this.HasJsonElement ? this.JsonElement.GetString() : this.value is JsonDocument value ? Convert.ToBase64String(ToBytes(value)) : null) ?? string.Empty;
        }

        /// <summary>
        /// Gets the JsonBase64 string as a byte array.
        /// </summary>
        /// <returns>The byte array represented by the Base64 encoded string.</returns>
        public ReadOnlyMemory<byte> GetByteArrayFromBase64EncodedString()
        {
            return (this.HasJsonElement ? GetByteArray(this.JsonElement) : this.value is JsonDocument value ? ToBytes(value).ToArray() : null) ?? ReadOnlyMemory<byte>.Empty;
        }

        /// <summary>
        /// Gets the <see cref="JsonDocument"/> represented by this content.
        /// </summary>
        /// <returns>The <see cref="JsonDocument"/> for the content.</returns>
        public JsonDocument GetJsonDocument()
        {
            return this.value ?? Parse(this.JsonElement) ?? throw new InvalidOperationException("Unable to parse a null document.");
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonBase64Content))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<JsonBase64Content, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonBase64Content))
            {
                return this.IsString && this.Validate(ValidationContext.ValidContext).IsValid;
            }

            return this.As<T>().Validate(ValidationContext.ValidContext).IsValid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            if (!other.IsString)
            {
                return false;
            }

            JsonBase64Content otherBase64String = other.As<JsonBase64Content>();
            if (!otherBase64String.Validate(ValidationContext.ValidContext).IsValid)
            {
                return false;
            }

            return this.GetByteArrayFromBase64EncodedString().Span.SequenceEqual(otherBase64String.GetByteArrayFromBase64EncodedString().Span);
        }

        /// <inheritdoc />
        public ValidationContext Validate(ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
        {
            if (!this.IsString)
            {
                // Ignore non-strings.
                return validationContext;
            }

            if (this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || Parse(this.JsonElement) is null))
            {
                if (level >= ValidationLevel.Basic)
                {
                    return validationContext.WithResult(isValid: false, message: $"6.1.1.  type - should have been 'string', with valid base64 encoding.");
                }
                else
                {
                    return validationContext.WithResult(isValid: false);
                }
            }
            else
            {
                if (level == ValidationLevel.Verbose)
                {
                    return validationContext.WithResult(isValid: true);
                }
            }

            return validationContext;
        }

        /// <inheritdoc />
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
                return;
            }

            if (this.value is JsonDocument v)
            {
                writer.WriteBase64StringValue(ToBytes(v));
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.IsNull ? "null" : this.GetBase64EncodedString();
        }

        private static ReadOnlySpan<byte> ToBytes(JsonDocument value)
        {
            var abw = new ArrayBufferWriter<byte>();
            using var writer = new Utf8JsonWriter(abw);
            value.WriteTo(writer);
            writer.Flush();
            return abw.WrittenSpan;
        }

        private static JsonDocument? Parse(JsonElement jsonElement)
        {
            ReadOnlyMemory<byte>? bytes = GetByteArray(jsonElement);
            if (bytes is not ReadOnlyMemory<byte> b)
            {
                return default;
            }

            try
            {
                var reader = new Utf8JsonReader(b.Span);
                if (JsonDocument.TryParseValue(ref reader, out JsonDocument? document))
                {
                    return document;
                }
            }
            catch (Exception)
            {
            }

            return default;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "Stylecop is not dealing with nullable arrays.")]
        private static ReadOnlyMemory<byte>? GetByteArray(JsonElement jsonElement)
        {
            if (jsonElement.TryGetBytesFromBase64(out byte[]? value))
            {
                return value;
            }

            return default;
        }
    }
}
