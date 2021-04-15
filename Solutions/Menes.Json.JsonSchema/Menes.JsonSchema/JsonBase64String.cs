// <copyright file="JsonBase64String.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System;
    using System.Text.Json;

    /// <summary>
    /// Represents the contentEncoding base64 json type.
    /// </summary>
    public readonly struct JsonBase64String : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonBase64String Null = default;

        private readonly ReadOnlyMemory<byte>? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element containing a base 64 string.</param>
        public JsonBase64String(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="value">The backing base64-encoded string.</param>
        public JsonBase64String(ReadOnlyMemory<byte> value)
        {
            this.value = value;
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="value">The backing base64-encoded string.</param>
        public JsonBase64String(ReadOnlySpan<byte> value)
        {
            this.value = value.ToArray();
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="value">The backing base64-encoded string.</param>
        public JsonBase64String(string value)
        {
            this.value = Convert.FromBase64String(value);
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBase64String"/> struct.
        /// </summary>
        /// <param name="value">The backing base64-encoded string.</param>
        public JsonBase64String(ReadOnlySpan<char> value)
        {
            Span<byte> bytes = stackalloc byte[value.Length];
            Convert.TryFromBase64Chars(value, bytes, out int bytesWritten);
            this.value = bytes.Slice(0, bytesWritten).ToArray();
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
        public static implicit operator JsonBase64String(string value)
        {
            return new JsonBase64String(value);
        }

        /// <summary>
        /// Implicit conversion to a base64-encoded <see cref="string"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator string(JsonBase64String value)
        {
            return value.GetBase64EncodedString();
        }

        /// <summary>
        /// Implicit conversion from a base64 encoded string.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonBase64String(ReadOnlySpan<char> value)
        {
            return new JsonBase64String(value);
        }

        /// <summary>
        /// Implicit conversion from a base64 encoded string.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonBase64String(ReadOnlySpan<byte> value)
        {
            return new JsonBase64String(value);
        }

        /// <summary>
        /// Implicit conversion from <see cref="Memory{T}"/> of <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonBase64String(ReadOnlyMemory<byte> value)
        {
            return new JsonBase64String(value);
        }

        /// <summary>
        /// Implicit conversion to a <see cref="Memory{T}"/> of <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator ReadOnlyMemory<byte>(JsonBase64String value)
        {
            return value.GetByteArrayFromBase64EncodedString();
        }

        /// <summary>
        /// Gets the <see cref="JsonBase64String"/> as a base64 encoded <see cref="string"/>.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public string GetBase64EncodedString()
        {
            return (this.HasJsonElement ? this.JsonElement.GetString() : (this.value is ReadOnlyMemory<byte> v ? Convert.ToBase64String(v.Span) : null)) ?? string.Empty;
        }

        /// <summary>
        /// Gets the JsonBase64 string as a byte array.
        /// </summary>
        /// <returns>The byte array represented by the Base64 encoded string.</returns>
        public ReadOnlyMemory<byte> GetByteArrayFromBase64EncodedString()
        {
            return (this.HasJsonElement ? this.Parse(this.JsonElement) : this.value) ?? ReadOnlyMemory<byte>.Empty;
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonBase64String))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<JsonBase64String, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonBase64String))
            {
                return this.IsString && this.Validate(ValidationContext.ValidContext).IsValid;
            }

            return this.As<T>().Validate(ValidationContext.ValidContext).IsValid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(in T other)
            where T : struct, IJsonValue
        {
            if (!other.IsString)
            {
                return false;
            }

            JsonBase64String otherBase64String = other.As<JsonBase64String>();
            if (!otherBase64String.Validate(ValidationContext.ValidContext).IsValid)
            {
                return false;
            }

            return this.GetByteArrayFromBase64EncodedString().Span.SequenceEqual(otherBase64String.GetByteArrayFromBase64EncodedString().Span);
        }

        /// <inheritdoc />
        public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
        {
            if (!this.IsString)
            {
                // Ignore non-strings.
                return validationContext;
            }

            if (this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || this.Parse(this.JsonElement) is null))
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

            if (this.value is ReadOnlyMemory<byte> v)
            {
                writer.WriteBase64StringValue(v.Span);
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "Stylecop is not dealing with nullable arrays.")]
        private ReadOnlyMemory<byte>? Parse(JsonElement jsonElement)
        {
            if (jsonElement.TryGetBytesFromBase64(out byte[]? value))
            {
                return value;
            }

            return default;
        }
    }
}
