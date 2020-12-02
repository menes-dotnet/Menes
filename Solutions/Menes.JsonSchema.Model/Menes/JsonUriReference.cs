﻿// <copyright file="JsonUriReference.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Text.Json;

    /// <summary>
    /// Represents the uri json type.
    /// </summary>
    public readonly struct JsonUriReference : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonUriReference Null = default;

        private static readonly Uri Empty = new Uri(string.Empty, UriKind.RelativeOrAbsolute);

        private readonly Uri? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUriReference"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonUriReference(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUriReference"/> struct.
        /// </summary>
        /// <param name="value">The backing Uri value.</param>
        public JsonUriReference(Uri value)
        {
            this.value = value;
            this.JsonElement = default;
        }

        /// <inheritdoc />
        public bool IsUndefined => this.JsonElement.ValueKind == JsonValueKind.Undefined && this.value is null;

        /// <inheritdoc />
        public bool IsNull => (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null) && this.value is null;

        /// <inheritdoc />
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc />
        public JsonElement JsonElement { get; }

        /// <inheritdoc />
        public bool IsNumber => false;

        /// <inheritdoc />
        public bool IsInteger => false;

        /// <inheritdoc />
        public bool IsString => true;

        /// <inheritdoc />
        public bool IsObject => false;

        /// <inheritdoc />
        public bool IsArray => false;

        /// <inheritdoc />
        public bool IsBoolean => false;

        /// <summary>
        /// Implicit conversion from <see cref="Uri"/>.
        /// </summary>
        /// <param name="value">The Uri value from which to convert.</param>
        public static implicit operator JsonUriReference(Uri value)
        {
            return new JsonUriReference(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="Uri"/>.
        /// </summary>
        /// <param name="value">The Uri value from which to convert.</param>
        public static implicit operator Uri(JsonUriReference value)
        {
            return value.GetUri();
        }

        /// <summary>
        /// Gets the <see cref="JsonUriReference"/> as a <see cref="Uri"/>.
        /// </summary>
        /// <returns>The <see cref="Uri"/>.</returns>
        public Uri GetUri()
        {
            return this.HasJsonElement ? new Uri(this.JsonElement.GetString(), UriKind.RelativeOrAbsolute) : (this.value ?? Empty);
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonUriReference))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<T>(JsonValue.FlattenToJsonElementBacking(this).JsonElement);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonUriReference))
            {
                return this.Validate(ValidationContext.ValidContext).IsValid;
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

            JsonUriReference otherUri = other.As<JsonUriReference>();
            if (!otherUri.Validate(ValidationContext.ValidContext).IsValid)
            {
                return false;
            }

            return this.GetUri().Equals(otherUri.GetUri());
        }

        /// <inheritdoc />
        public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
        {
            if (this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || this.Parse(this.JsonElement.GetString()) is null))
            {
                if (level >= ValidationLevel.Basic)
                {
                    return validationContext.WithResult(isValid: false, message: $"6.1.1.  type - should have been 'string' with format 'uri-reference'.");
                }
                else
                {
                    return validationContext.WithResult(isValid: false);
                }
            }
            else
            {
                if (this.value is Uri value)
                {
                    if (value.OriginalString.StartsWith("\\\\") ||
                        (value.IsAbsoluteUri && value.Fragment.Contains('\\')) ||
                        (value.OriginalString.StartsWith('#') && value.OriginalString.Contains('\\')))
                    {
                        if (level >= ValidationLevel.Basic)
                        {
                            return validationContext.WithResult(isValid: false, message: $"6.1.1.  type - should have been 'string' with format 'uri-reference'.");
                        }
                        else
                        {
                            return validationContext.WithResult(isValid: false);
                        }
                    }
                }

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

            if (this.value is Uri v)
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
            return this.IsNull ? "null" : this.GetUri().ToString();
        }

        private Uri? Parse(string? value)
        {
            if (value is null)
            {
                return default;
            }

            if (value.StartsWith("\\\\"))
            {
                return default;
            }

            if (value.StartsWith('#') && value.Contains('\\'))
            {
                return default;
            }

            if (!Uri.TryCreate(this.JsonElement.GetString(), UriKind.RelativeOrAbsolute, out Uri testUri))
            {
                return default;
            }

            if (testUri.IsAbsoluteUri && testUri.Fragment.Contains('\\'))
            {
                return default;
            }

            return testUri;
        }
    }
}
