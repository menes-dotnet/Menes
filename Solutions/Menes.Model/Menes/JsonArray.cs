// <copyright file="JsonArray.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;

    /// <summary>
    /// Factory methods for a <see cref="JsonArray{TItem}"/>.
    /// </summary>
    public static class JsonArray
    {
        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonString> Create(params string[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (string item in items)
            {
                array.Add(JsonReference.FromValue((JsonString)item));
            }

            return new JsonArray<JsonString>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonString> Create(string item1)
        {
            return new JsonArray<JsonString>(ImmutableArray.Create(JsonReference.FromValue((JsonString)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonString> Create(string item1, string item2)
        {
            return new JsonArray<JsonString>(ImmutableArray.Create(JsonReference.FromValue((JsonString)item1), JsonReference.FromValue((JsonString)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonString> Create(string item1, string item2, string item3)
        {
            return new JsonArray<JsonString>(ImmutableArray.Create(JsonReference.FromValue((JsonString)item1), JsonReference.FromValue((JsonString)item2), JsonReference.FromValue((JsonString)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonString> Create(string item1, string item2, string item3, string item4)
        {
            return new JsonArray<JsonString>(ImmutableArray.Create(JsonReference.FromValue((JsonString)item1), JsonReference.FromValue((JsonString)item2), JsonReference.FromValue((JsonString)item3), JsonReference.FromValue((JsonString)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDouble> Create(params double[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (double item in items)
            {
                array.Add(JsonReference.FromValue((JsonDouble)item));
            }

            return new JsonArray<JsonDouble>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDouble> Create(double item1)
        {
            return new JsonArray<JsonDouble>(ImmutableArray.Create(JsonReference.FromValue((JsonDouble)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDouble> Create(double item1, double item2)
        {
            return new JsonArray<JsonDouble>(ImmutableArray.Create(JsonReference.FromValue((JsonDouble)item1), JsonReference.FromValue((JsonDouble)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDouble> Create(double item1, double item2, double item3)
        {
            return new JsonArray<JsonDouble>(ImmutableArray.Create(JsonReference.FromValue((JsonDouble)item1), JsonReference.FromValue((JsonDouble)item2), JsonReference.FromValue((JsonDouble)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDouble> Create(double item1, double item2, double item3, double item4)
        {
            return new JsonArray<JsonDouble>(ImmutableArray.Create(JsonReference.FromValue((JsonDouble)item1), JsonReference.FromValue((JsonDouble)item2), JsonReference.FromValue((JsonDouble)item3), JsonReference.FromValue((JsonDouble)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonSingle> Create(params float[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (float item in items)
            {
                array.Add(JsonReference.FromValue((JsonSingle)item));
            }

            return new JsonArray<JsonSingle>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonSingle> Create(float item1)
        {
            return new JsonArray<JsonSingle>(ImmutableArray.Create(JsonReference.FromValue((JsonSingle)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonSingle> Create(float item1, float item2)
        {
            return new JsonArray<JsonSingle>(ImmutableArray.Create(JsonReference.FromValue((JsonSingle)item1), JsonReference.FromValue((JsonSingle)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonSingle> Create(float item1, float item2, float item3)
        {
            return new JsonArray<JsonSingle>(ImmutableArray.Create(JsonReference.FromValue((JsonSingle)item1), JsonReference.FromValue((JsonSingle)item2), JsonReference.FromValue((JsonSingle)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonSingle> Create(float item1, float item2, float item3, float item4)
        {
            return new JsonArray<JsonSingle>(ImmutableArray.Create(JsonReference.FromValue((JsonSingle)item1), JsonReference.FromValue((JsonSingle)item2), JsonReference.FromValue((JsonSingle)item3), JsonReference.FromValue((JsonSingle)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonInt32> Create(params int[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (int item in items)
            {
                array.Add(JsonReference.FromValue((JsonInt32)item));
            }

            return new JsonArray<JsonInt32>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonInt32> Create(int item1)
        {
            return new JsonArray<JsonInt32>(ImmutableArray.Create(JsonReference.FromValue((JsonInt32)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonInt32> Create(int item1, int item2)
        {
            return new JsonArray<JsonInt32>(ImmutableArray.Create(JsonReference.FromValue((JsonInt32)item1), JsonReference.FromValue((JsonInt32)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonInt32> Create(int item1, int item2, int item3)
        {
            return new JsonArray<JsonInt32>(ImmutableArray.Create(JsonReference.FromValue((JsonInt32)item1), JsonReference.FromValue((JsonInt32)item2), JsonReference.FromValue((JsonInt32)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonInt32> Create(int item1, int item2, int item3, int item4)
        {
            return new JsonArray<JsonInt32>(ImmutableArray.Create(JsonReference.FromValue((JsonInt32)item1), JsonReference.FromValue((JsonInt32)item2), JsonReference.FromValue((JsonInt32)item3), JsonReference.FromValue((JsonInt32)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonInt64> Create(params long[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (long item in items)
            {
                array.Add(JsonReference.FromValue((JsonInt64)item));
            }

            return new JsonArray<JsonInt64>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonInt64> Create(long item1)
        {
            return new JsonArray<JsonInt64>(ImmutableArray.Create(JsonReference.FromValue((JsonInt64)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonInt64> Create(long item1, long item2)
        {
            return new JsonArray<JsonInt64>(ImmutableArray.Create(JsonReference.FromValue((JsonInt64)item1), JsonReference.FromValue((JsonInt64)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonInt64> Create(long item1, long item2, long item3)
        {
            return new JsonArray<JsonInt64>(ImmutableArray.Create(JsonReference.FromValue((JsonInt64)item1), JsonReference.FromValue((JsonInt64)item2), JsonReference.FromValue((JsonInt64)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonInt64> Create(long item1, long item2, long item3, long item4)
        {
            return new JsonArray<JsonInt64>(ImmutableArray.Create(JsonReference.FromValue((JsonInt64)item1), JsonReference.FromValue((JsonInt64)item2), JsonReference.FromValue((JsonInt64)item3), JsonReference.FromValue((JsonInt64)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonUri> Create(params Uri[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (Uri item in items)
            {
                array.Add(JsonReference.FromValue((JsonUri)item));
            }

            return new JsonArray<JsonUri>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonUri> Create(Uri item1)
        {
            return new JsonArray<JsonUri>(ImmutableArray.Create(JsonReference.FromValue((JsonUri)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonUri> Create(Uri item1, Uri item2)
        {
            return new JsonArray<JsonUri>(ImmutableArray.Create(JsonReference.FromValue((JsonUri)item1), JsonReference.FromValue((JsonUri)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonUri> Create(Uri item1, Uri item2, Uri item3)
        {
            return new JsonArray<JsonUri>(ImmutableArray.Create(JsonReference.FromValue((JsonUri)item1), JsonReference.FromValue((JsonUri)item2), JsonReference.FromValue((JsonUri)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonUri> Create(Uri item1, Uri item2, Uri item3, Uri item4)
        {
            return new JsonArray<JsonUri>(ImmutableArray.Create(JsonReference.FromValue((JsonUri)item1), JsonReference.FromValue((JsonUri)item2), JsonReference.FromValue((JsonUri)item3), JsonReference.FromValue((JsonUri)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonGuid> Create(params Guid[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (Guid item in items)
            {
                array.Add(JsonReference.FromValue((JsonGuid)item));
            }

            return new JsonArray<JsonGuid>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonGuid> Create(Guid item1)
        {
            return new JsonArray<JsonGuid>(ImmutableArray.Create(JsonReference.FromValue((JsonGuid)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonGuid> Create(Guid item1, Guid item2)
        {
            return new JsonArray<JsonGuid>(ImmutableArray.Create(JsonReference.FromValue((JsonGuid)item1), JsonReference.FromValue((JsonGuid)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonGuid> Create(Guid item1, Guid item2, Guid item3)
        {
            return new JsonArray<JsonGuid>(ImmutableArray.Create(JsonReference.FromValue((JsonGuid)item1), JsonReference.FromValue((JsonGuid)item2), JsonReference.FromValue((JsonGuid)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonGuid> Create(Guid item1, Guid item2, Guid item3, Guid item4)
        {
            return new JsonArray<JsonGuid>(ImmutableArray.Create(JsonReference.FromValue((JsonGuid)item1), JsonReference.FromValue((JsonGuid)item2), JsonReference.FromValue((JsonGuid)item3), JsonReference.FromValue((JsonGuid)item4)));
        }

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
