// <copyright file="JsonContent.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System;
    using System.Text.Json;

    /// <summary>
    /// Represents the application/json json media type.
    /// </summary>
    public readonly struct JsonContent : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonContent Null = default;

        private readonly JsonDocument? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonContent"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element containing a base 64 string.</param>
        public JsonContent(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonContent"/> struct.
        /// </summary>
        /// <param name="value">The backing document.</param>
        public JsonContent(JsonDocument value)
        {
            this.value = value;
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonContent"/> struct.
        /// </summary>
        /// <param name="value">The backing string.</param>
        public JsonContent(string value)
        {
            this.value = JsonDocument.Parse(value);
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonContent"/> struct.
        /// </summary>
        /// <param name="value">The backing string.</param>
        public JsonContent(ReadOnlyMemory<char> value)
        {
            this.value = JsonDocument.Parse(value);
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
        /// Implicit conversion from a string.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonContent(string value)
        {
            return new JsonContent(value);
        }

        /// <summary>
        /// Implicit conversion to a <see cref="string"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator string(JsonContent value)
        {
            return value.GetString();
        }

        /// <summary>
        /// Implicit conversion from string.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonContent(ReadOnlyMemory<char> value)
        {
            return new JsonContent(value);
        }

        /// <summary>
        /// Implicit conversion from <see cref="JsonDocument"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonContent(JsonDocument value)
        {
            return new JsonContent(value);
        }

        /// <summary>
        /// Implicit conversion to a <see cref="JsonDocument"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonDocument(JsonContent value)
        {
            return value.GetJsonDocument();
        }

        /// <summary>
        /// Gets the <see cref="JsonContent"/> as a base64 encoded <see cref="string"/>.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public string GetString()
        {
            return (this.HasJsonElement ? this.JsonElement.GetString() : this.value is JsonDocument value ? value.ToString() : null) ?? string.Empty;
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
            if (typeof(T) == typeof(JsonContent))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<JsonContent, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonContent))
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

            JsonContent otherContent = other.As<JsonContent>();
            if (!otherContent.Validate(ValidationContext.ValidContext).IsValid)
            {
                return false;
            }

            return this.GetString() == otherContent.GetString();
        }

        /// <inheritdoc />
        public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
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
                writer.WriteStringValue(v.ToString());
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.IsNull ? "null" : this.GetString();
        }

        private static JsonDocument? Parse(JsonElement jsonElement)
        {
            string? value = jsonElement.GetString();
            if (value is null)
            {
                return default;
            }

            try
            {
                return JsonDocument.Parse(value);
            }
            catch (Exception)
            {
            }

            return default;
        }
    }
}
