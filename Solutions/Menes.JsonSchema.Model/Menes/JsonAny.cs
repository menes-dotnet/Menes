// <copyright file="JsonAny.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    /// <summary>
    /// Represents the {}/true json type.
    /// </summary>
    public readonly struct JsonAny : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonAny Null = default;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonAny"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonAny(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc />
        public bool IsUndefined => this.JsonElement.ValueKind == JsonValueKind.Undefined;

        /// <inheritdoc />
        public bool IsNull => this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null;

        /// <inheritdoc />
        public bool HasJsonElement => true;

        /// <inheritdoc />
        public JsonElement JsonElement { get; }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.JsonElement.As<T>();
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            return this.JsonElement.As<T>().Validate(ValidationResult.ValidResult, ValidationLevel.Flag).Valid;
        }

        /// <inheritdoc />
        public bool TryGetProperty<T>(ReadOnlySpan<char> propertyName, out T property)
            where T : struct, IJsonValue
        {
            if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
            {
                property = value.As<T>();
                return true;
            }

            property = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryGetProperty<T>(string propertyName, out T property)
            where T : struct, IJsonValue
        {
            if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
            {
                property = value.As<T>();
                return true;
            }

            property = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryGetProperty<T>(ReadOnlySpan<byte> utf8PropertyName, out T property)
            where T : struct, IJsonValue
        {
            if (this.JsonElement.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement value))
            {
                property = value.As<T>();
                return true;
            }

            property = default;
            return false;
        }

        /// <inheritdoc />
        public ValidationResult Validate(in ValidationResult validationResult, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null)
        {
            ValidationResult result = validationResult;
            if (level == Menes.ValidationLevel.Verbose)
            {
                result = result.AddResult(valid: true, message: "{}/true validation");
            }

            return result;
        }

        /// <inheritdoc />
        public void WriteTo(Utf8JsonWriter writer)
        {
            this.JsonElement.WriteTo(writer);
        }
    }
}
