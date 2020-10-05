// <copyright file="JsonProperties{TItem}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with additional properties in situ, whether they
    /// originated from JSON or are an array of dotnet properties.
    /// </summary>
    /// <typeparam name="TItem">The type of <see cref="IJsonValue"/> that represents the items.</typeparam>
    public readonly struct JsonProperties<TItem>
        where TItem : struct, IJsonValue
    {
        /// <summary>
        /// An empty list of properties.
        /// </summary>
        public static readonly JsonProperties<TItem> Empty = new JsonProperties<TItem>(new (string name, TItem value)[0]);

        /// <summary>
        /// Creates a <see cref="JsonProperties{TItem}"/> wrapper around a .NET properties array.
        /// </summary>
        /// <param name="clrItems">The .NET items.</param>
        public JsonProperties(params (string name, TItem value)[] clrItems)
        {
            this.ClrItems = clrItems.Select(i => new JsonProperty<TItem>(i.name, i.value)).ToImmutableList();
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonProperties{TItem}"/> wrapper around a .NET item array.
        /// </summary>
        /// <param name="clrItems">The .NET items.</param>
        public JsonProperties(IEnumerable<JsonProperty<TItem>> clrItems)
        {
            this.ClrItems = clrItems.ToImmutableList();
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonProperties{TItem}"/> wrapper around a JsonElement.
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
        /// Gets the backing <see cref="ImmutableList{T}"/> of <see cref="JsonProperty{TItem}"/>.
        /// </summary>
        /// <remarks>
        /// This will be <see cref="JsonValueKind.Undefined"/> if it is not backed
        /// by a <see cref="JsonElement"/>. See <see cref="HasJsonElement"/>.
        /// </remarks>
        public ImmutableList<JsonProperty<TItem>>? ClrItems { get; }
    }
}
