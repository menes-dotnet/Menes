// <copyright file="JsonNull.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Text.Json;

    /// <summary>
    /// Represents the {}/true json type.
    /// </summary>
    public readonly struct JsonNull : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonNull Null = default;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNull"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonNull(JsonElement jsonElement)
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
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.ValidResult;

            if (!this.IsNull)
            {
                if (level >= ValidationLevel.Basic)
                {
                    string? il = null;
                    string? akl = null;

                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);
                    result.AddResult(valid: false, message: $"6.1.1.  type - should have been 'null' but was '{this.JsonElement.ValueKind}'.", instanceLocation: il, absoluteKeywordLocation: akl);
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
            this.JsonElement.WriteTo(writer);
        }
    }
}
