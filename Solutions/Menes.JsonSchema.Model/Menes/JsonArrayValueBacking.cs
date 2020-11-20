// <copyright file="JsonArrayValueBacking.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Text.Json;

    /// <summary>
    /// A boxing backing field for a <see cref="IJsonValue"/>.
    /// </summary>
    /// <remarks>
    /// This will box the <see cref="IJsonValue"/> if it is not backed by a <see cref="JsonElement"/>. It is used in the implementation
    /// of the entities where they have properties which recursively contain instances of the parent property.
    /// </remarks>
    public readonly struct JsonArrayValueBacking
    {
        private readonly IJsonValue? value;
        private readonly JsonElement jsonElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonArrayValueBacking"/> struct.
        /// </summary>
        /// <param name="value">The <see cref="JsonValue"/> with which to construct the backing value.</param>
        internal JsonArrayValueBacking(IJsonValue value)
        {
            this.value = value;
            this.jsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonArrayValueBacking"/> struct.
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> from which to construct the backing value.</param>
        internal JsonArrayValueBacking(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.value = default;
        }

        /// <summary>
        /// Gets a value indicating whether this reference is null.
        /// </summary>
        public bool IsNull => (this.jsonElement.ValueKind == JsonValueKind.Undefined || this.jsonElement.ValueKind == JsonValueKind.Null) && this.value is null;

        /// <summary>
        /// Generate a boxing backing value for a <see cref="IJsonValue"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IJsonValue"/>.</typeparam>
        /// <param name="source">The source <see cref="IJsonValue"/>.</param>
        /// <returns>An instance of the <see cref="JsonArrayValueBacking"/> for the given <see cref="IJsonValue"/>.</returns>
        public static JsonArrayValueBacking From<T>(T source)
            where T : struct, IJsonValue
        {
            if (source is T s && s.HasJsonElement)
            {
                return new JsonArrayValueBacking(s.JsonElement);
            }

            return new JsonArrayValueBacking(source);
        }

        /// <summary>
        /// Write the element to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the element this is backing.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                this.jsonElement.WriteTo(writer);
            }

            if (this.value is IJsonValue value)
            {
                value.WriteTo(writer);
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <returns>The value, constructed from the <see cref="jsonElement"/> if available, otherwise cast from the boxed instance.</returns>
        public TValue As<TValue>()
            where TValue : struct, IJsonValue
        {
            if (this.value is not null)
            {
                return this.value.As<TValue>();
            }

            if (this.jsonElement.ValueKind != JsonValueKind.Null && this.jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                return this.jsonElement.As<TValue>();
            }

            return default;
        }
    }
}
