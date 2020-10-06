// <copyright file="JsonArray.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Immutable;

    /// <summary>
    /// Factory methods for a <see cref="JsonArray{TItem}"/>.
    /// </summary>
    public static class JsonArray
    {
        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <typeparam name="TItem">The type of the <see cref="IJsonValue"/> in the array.</typeparam>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<TItem> Create<TItem>(params TItem[] items)
            where TItem : struct, IJsonValue
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (TItem item in items)
            {
                array.Add(JsonReference.FromValue(item));
            }

            return new JsonArray<TItem>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <typeparam name="TItem">The type of the <see cref="IJsonValue"/> in the array.</typeparam>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<TItem> Create<TItem>(ImmutableArray<TItem> items)
            where TItem : struct, IJsonValue
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (TItem item in items)
            {
                array.Add(JsonReference.FromValue(item));
            }

            return new JsonArray<TItem>(array.ToImmutable());
        }
    }
}
