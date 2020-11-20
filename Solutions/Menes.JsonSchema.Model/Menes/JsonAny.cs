// <copyright file="JsonAny.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections;
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

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
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

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
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

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="utf8PropertyName">The utf8 encoded name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
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
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.ValidResult;

            if (level == Menes.ValidationLevel.Verbose)
            {
                string? il = null;
                string? akl = null;

                instanceLocation?.TryPeek(out il);
                absoluteKeywordLocation?.TryPeek(out akl);

                result.AddResult(valid: true, message: "6.1.1.  type is '{}'", instanceLocation: il, absoluteKeywordLocation: akl);
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
