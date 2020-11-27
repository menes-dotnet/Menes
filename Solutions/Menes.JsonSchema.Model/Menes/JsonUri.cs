﻿// <copyright file="JsonUri.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    /// <summary>
    /// Represents the uri json type.
    /// </summary>
    public readonly struct JsonUri : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonUri Null = default;

        private static readonly Uri Empty = new Uri(string.Empty, UriKind.RelativeOrAbsolute);

        private readonly Uri? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUri"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonUri(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUri"/> struct.
        /// </summary>
        /// <param name="value">The backing Uri value.</param>
        public JsonUri(Uri value)
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
        public static implicit operator JsonUri(Uri value) => new JsonUri(value);

        /// <summary>
        /// Implicit conversion to <see cref="Uri"/>.
        /// </summary>
        /// <param name="value">The Uri value from which to convert.</param>
        public static implicit operator Uri(JsonUri value) => value.GetUri();

        /// <summary>
        /// Gets the <see cref="JsonUri"/> as a <see cref="Uri"/>.
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
            if (typeof(T) == typeof(JsonUri))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<T>(JsonValue.FlattenToJsonElementBacking(this).JsonElement);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonUri))
            {
                return this.Validate().Valid;
            }

            return this.As<T>().Validate().Valid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            if (!other.IsString)
            {
                return false;
            }

            JsonUri otherUri = other.As<JsonUri>();
            if (!otherUri.Validate().Valid)
            {
                return false;
            }

            return this.GetUri().Equals(otherUri.GetUri());
        }

        /// <inheritdoc />
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.ValidResult;

            if (this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || !(Uri.TryCreate(this.JsonElement.GetString(), UriKind.Absolute, out Uri testUri) && (!testUri.IsAbsoluteUri || !testUri.IsUnc))))
            {
                if (level >= ValidationLevel.Basic)
                {
                    string? il = null;
                    string? akl = null;

                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);
                    result.AddResult(valid: false, message: $"6.1.1.  type - should have been a URI string but was '{this.JsonElement.ValueKind}'.", instanceLocation: il, absoluteKeywordLocation: akl);
                }
                else
                {
                    result.SetValid(false);
                }
            }
            else
            {
                if (this.value is Uri value && (!value.IsWellFormedOriginalString() || (value.IsAbsoluteUri && value.IsUnc)))
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        string? il = null;
                        string? akl = null;

                        instanceLocation?.TryPeek(out il);
                        absoluteKeywordLocation?.TryPeek(out akl);
                        result.AddResult(valid: false, message: $"6.1.1.  type - should have been a URI string but was '{this.JsonElement.ValueKind}'.", instanceLocation: il, absoluteKeywordLocation: akl);
                    }
                    else
                    {
                        result.SetValid(false);
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    string? il = null;
                    string? akl = null;

                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);

                    result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
                }
            }

            return result;
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
    }
}
