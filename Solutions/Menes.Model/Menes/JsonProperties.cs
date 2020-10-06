// <copyright file="JsonProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Immutable;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with additional properties in situ, whether they
    /// originated from JSON or are an array of dotnet properties.
    /// </summary>
    public readonly struct JsonProperties
    {
        /// <summary>
        /// An empty list of properties.
        /// </summary>
        public static readonly JsonProperties Empty = default;

        /// <summary>
        /// Creates a <see cref="JsonProperties"/> wrapper around a .NET item array.
        /// </summary>
        /// <param name="clrItems">The .NET items.</param>
        public JsonProperties(ImmutableArray<JsonPropertyReference> clrItems)
        {
            this.ClrItems = clrItems;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonProperties"/> wrapper around a JsonElement.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the array value to represent.
        /// </param>
        public JsonProperties(JsonElement jsonElement)
        {
            this.ClrItems = null;
            this.JsonElement = jsonElement;
        }

        /// <summary>
        /// Gets a value indicating whether the entity is backed by a <see cref="JsonElement"/>.
        /// </summary>
        public bool HasJsonElement => this.JsonElement.ValueKind == JsonValueKind.Object;

        /// <summary>
        /// Gets the backing <see cref="JsonElement"/>.
        /// </summary>
        /// <remarks>
        /// This will be <see cref="JsonValueKind.Undefined"/> if it is not backed
        /// by a <see cref="JsonElement"/>. See <see cref="HasJsonElement"/>.
        /// </remarks>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Gets the backing <see cref="ImmutableArray{T}"/> of <see cref="JsonPropertyReference"/>.
        /// </summary>
        /// <remarks>
        /// This will be <see cref="JsonValueKind.Undefined"/> if it is not backed
        /// by a <see cref="JsonElement"/>. See <see cref="HasJsonElement"/>.
        /// </remarks>
        public ImmutableArray<JsonPropertyReference>? ClrItems { get; }

        /// <summary>
        /// Gets an instance of <see cref="JsonProperties"/> from a set of named <see cref="IJsonValue"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/>.</typeparam>
        /// <param name="clrItems">The <see cref="IJsonValue"/> instances.</param>
        /// <returns>An instance of the <see cref="JsonProperties"/> initialized with the values.</returns>
        public static JsonProperties FromValues<TValue>(params (string name, TValue value)[] clrItems)
            where TValue : struct, IJsonValue
        {
            ImmutableArray<JsonPropertyReference>.Builder array = ImmutableArray.CreateBuilder<JsonPropertyReference>();
            foreach ((string name, TValue value) in clrItems)
            {
                array.Add(JsonPropertyReference.From(name, value));
            }

            return new JsonProperties(array.ToImmutable());
        }
    }
}
