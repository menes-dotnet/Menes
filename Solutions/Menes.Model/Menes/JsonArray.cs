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
        /// <param name="item1">The item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<TItem> Create<TItem>(TItem item1)
            where TItem : struct, IJsonValue
        {
            return new JsonArray<TItem>(ImmutableArray.Create(JsonReference.FromValue(item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <typeparam name="TItem">The type of the <see cref="IJsonValue"/> in the array.</typeparam>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<TItem> Create<TItem>(TItem item1, TItem item2)
            where TItem : struct, IJsonValue
        {
            return new JsonArray<TItem>(ImmutableArray.Create(JsonReference.FromValue(item1), JsonReference.FromValue(item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <typeparam name="TItem">The type of the <see cref="IJsonValue"/> in the array.</typeparam>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<TItem> Create<TItem>(TItem item1, TItem item2, TItem item3)
            where TItem : struct, IJsonValue
        {
            return new JsonArray<TItem>(ImmutableArray.Create(JsonReference.FromValue(item1), JsonReference.FromValue(item2), JsonReference.FromValue(item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <typeparam name="TItem">The type of the <see cref="IJsonValue"/> in the array.</typeparam>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<TItem> Create<TItem>(TItem item1, TItem item2, TItem item3, TItem item4)
            where TItem : struct, IJsonValue
        {
            return new JsonArray<TItem>(ImmutableArray.Create(JsonReference.FromValue(item1), JsonReference.FromValue(item2), JsonReference.FromValue(item3), JsonReference.FromValue(item4)));
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
