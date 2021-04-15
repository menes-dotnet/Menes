// <copyright file="JsonNull.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System.Text.Json;

    /// <summary>
    /// The JSON null value.
    /// </summary>
    public readonly struct JsonNull : IJsonValue
    {
        /// <summary>
        /// Gets a null value.
        /// </summary>
        public static readonly JsonNull Instance = default;

        private readonly JsonElement? jsonElementBacking;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNull"/> struct.
        /// </summary>
        /// <param name="jsonElement">The json element from which to construct the value.</param>
        public JsonNull(JsonElement jsonElement)
        {
            this.jsonElementBacking = jsonElement;
        }

        /// <inheritdoc/>
        public JsonElement AsJsonElement => this.jsonElementBacking ?? default;

        /// <inheritdoc/>
        public bool HasJsonElement => this.jsonElementBacking is not null;

        /// <inheritdoc/>
        public JsonValueKind ValueKind => JsonValueKind.Null;

        /// <inheritdoc/>
        public JsonAny AsAny => default;

        /// <summary>
        /// Implicit conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(JsonNull value)
        {
            return default;
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonNull(JsonAny value)
        {
            return default;
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            if (this.jsonElementBacking is JsonElement je)
            {
                return Json.Validate.TypeNull(je.ValueKind, validationContext ?? ValidationContext.ValidContext, level);
            }

            return Json.Validate.TypeNull(JsonValueKind.Null, validationContext ?? ValidationContext.ValidContext, level);
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return default;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            return this.ValueKind == other.ValueKind;
        }

        /// <inheritdoc/>
        public void WriteTo(Utf8JsonWriter writer)
        {
            writer.WriteNullValue();
        }
    }
}
