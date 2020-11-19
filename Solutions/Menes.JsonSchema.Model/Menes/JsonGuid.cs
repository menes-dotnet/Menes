// <copyright file="JsonGuid.cs" company="Endjin Limited">
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
    public readonly struct JsonGuid : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonGuid Null = default;

        private readonly Guid? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonGuid"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonGuid(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonGuid"/> struct.
        /// </summary>
        /// <param name="value">The backing Guid value.</param>
        public JsonGuid(Guid value)
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

        /// <summary>
        /// Implicit conversion from <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator JsonGuid(Guid value) => new JsonGuid(value);

        /// <summary>
        /// Implicit conversion to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The bool value from which to convert.</param>
        public static implicit operator Guid(JsonGuid value) => value.GetGuid();

        /// <summary>
        /// Gets the <see cref="JsonGuid"/> as a <see cref="bool"/>.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public Guid GetGuid()
        {
            return this.HasJsonElement ? this.JsonElement.GetGuid() : (this.value ?? Guid.Empty);
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.FlattenToJsonElementBacking().JsonElement.As<T>();
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonGuid))
            {
                return this.Validate().Valid;
            }

            return this.FlattenToJsonElementBacking().As<T>().Validate().Valid;
        }

        /// <inheritdoc />
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.ValidResult;

            if (this.HasJsonElement && this.JsonElement.ValueKind != JsonValueKind.True && this.JsonElement.ValueKind != JsonValueKind.False)
            {
                if (level >= ValidationLevel.Basic)
                {
                    string? il = null;
                    string? akl = null;

                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);
                    result.AddResult(valid: false, message: $"6.1.1.  type - should have been 'True' or 'False' but was '{this.JsonElement.ValueKind}'.", instanceLocation: il, absoluteKeywordLocation: akl);
                }
                else
                {
                    result.SetValid(false);
                }
            }
            else
            {
                if (level == ValidationLevel.Verbose)
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

            if (this.value is Guid v)
            {
                writer.WriteStringValue(v);
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}
