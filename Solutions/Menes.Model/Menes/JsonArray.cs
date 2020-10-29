// <copyright file="JsonArray.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using NodaTime;

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
        public static JsonArray<JsonTime> Create(params OffsetTime[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (OffsetTime item in items)
            {
                array.Add(JsonReference.FromValue((JsonTime)item));
            }

            return new JsonArray<JsonTime>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonTime> Create(OffsetTime item1)
        {
            return new JsonArray<JsonTime>(ImmutableArray.Create(JsonReference.FromValue((JsonTime)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonTime> Create(OffsetTime item1, OffsetTime item2)
        {
            return new JsonArray<JsonTime>(ImmutableArray.Create(JsonReference.FromValue((JsonTime)item1), JsonReference.FromValue((JsonTime)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonTime> Create(OffsetTime item1, OffsetTime item2, OffsetTime item3)
        {
            return new JsonArray<JsonTime>(ImmutableArray.Create(JsonReference.FromValue((JsonTime)item1), JsonReference.FromValue((JsonTime)item2), JsonReference.FromValue((JsonTime)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonTime> Create(OffsetTime item1, OffsetTime item2, OffsetTime item3, OffsetTime item4)
        {
            return new JsonArray<JsonTime>(ImmutableArray.Create(JsonReference.FromValue((JsonTime)item1), JsonReference.FromValue((JsonTime)item2), JsonReference.FromValue((JsonTime)item3), JsonReference.FromValue((JsonTime)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDuration> Create(params Duration[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (Duration item in items)
            {
                array.Add(JsonReference.FromValue((JsonDuration)item));
            }

            return new JsonArray<JsonDuration>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDuration> Create(Duration item1)
        {
            return new JsonArray<JsonDuration>(ImmutableArray.Create(JsonReference.FromValue((JsonDuration)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDuration> Create(Duration item1, Duration item2)
        {
            return new JsonArray<JsonDuration>(ImmutableArray.Create(JsonReference.FromValue((JsonDuration)item1), JsonReference.FromValue((JsonDuration)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDuration> Create(Duration item1, Duration item2, Duration item3)
        {
            return new JsonArray<JsonDuration>(ImmutableArray.Create(JsonReference.FromValue((JsonDuration)item1), JsonReference.FromValue((JsonDuration)item2), JsonReference.FromValue((JsonDuration)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDuration> Create(Duration item1, Duration item2, Duration item3, Duration item4)
        {
            return new JsonArray<JsonDuration>(ImmutableArray.Create(JsonReference.FromValue((JsonDuration)item1), JsonReference.FromValue((JsonDuration)item2), JsonReference.FromValue((JsonDuration)item3), JsonReference.FromValue((JsonDuration)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDateTime> Create(params OffsetDateTime[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (OffsetDateTime item in items)
            {
                array.Add(JsonReference.FromValue((JsonDateTime)item));
            }

            return new JsonArray<JsonDateTime>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDateTime> Create(OffsetDateTime item1)
        {
            return new JsonArray<JsonDateTime>(ImmutableArray.Create(JsonReference.FromValue((JsonDateTime)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDateTime> Create(OffsetDateTime item1, OffsetDateTime item2)
        {
            return new JsonArray<JsonDateTime>(ImmutableArray.Create(JsonReference.FromValue((JsonDateTime)item1), JsonReference.FromValue((JsonDateTime)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDateTime> Create(OffsetDateTime item1, OffsetDateTime item2, OffsetDateTime item3)
        {
            return new JsonArray<JsonDateTime>(ImmutableArray.Create(JsonReference.FromValue((JsonDateTime)item1), JsonReference.FromValue((JsonDateTime)item2), JsonReference.FromValue((JsonDateTime)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDateTime> Create(OffsetDateTime item1, OffsetDateTime item2, OffsetDateTime item3, OffsetDateTime item4)
        {
            return new JsonArray<JsonDateTime>(ImmutableArray.Create(JsonReference.FromValue((JsonDateTime)item1), JsonReference.FromValue((JsonDateTime)item2), JsonReference.FromValue((JsonDateTime)item3), JsonReference.FromValue((JsonDateTime)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDate> Create(params LocalDate[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (LocalDate item in items)
            {
                array.Add(JsonReference.FromValue((JsonDate)item));
            }

            return new JsonArray<JsonDate>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDate> Create(LocalDate item1)
        {
            return new JsonArray<JsonDate>(ImmutableArray.Create(JsonReference.FromValue((JsonDate)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDate> Create(LocalDate item1, LocalDate item2)
        {
            return new JsonArray<JsonDate>(ImmutableArray.Create(JsonReference.FromValue((JsonDate)item1), JsonReference.FromValue((JsonDate)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDate> Create(LocalDate item1, LocalDate item2, LocalDate item3)
        {
            return new JsonArray<JsonDate>(ImmutableArray.Create(JsonReference.FromValue((JsonDate)item1), JsonReference.FromValue((JsonDate)item2), JsonReference.FromValue((JsonDate)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDate> Create(LocalDate item1, LocalDate item2, LocalDate item3, LocalDate item4)
        {
            return new JsonArray<JsonDate>(ImmutableArray.Create(JsonReference.FromValue((JsonDate)item1), JsonReference.FromValue((JsonDate)item2), JsonReference.FromValue((JsonDate)item3), JsonReference.FromValue((JsonDate)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonBoolean> Create(params bool[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (bool item in items)
            {
                array.Add(JsonReference.FromValue((JsonBoolean)item));
            }

            return new JsonArray<JsonBoolean>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonBoolean> Create(bool item1)
        {
            return new JsonArray<JsonBoolean>(ImmutableArray.Create(JsonReference.FromValue((JsonBoolean)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonBoolean> Create(bool item1, bool item2)
        {
            return new JsonArray<JsonBoolean>(ImmutableArray.Create(JsonReference.FromValue((JsonBoolean)item1), JsonReference.FromValue((JsonBoolean)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonBoolean> Create(bool item1, bool item2, bool item3)
        {
            return new JsonArray<JsonBoolean>(ImmutableArray.Create(JsonReference.FromValue((JsonBoolean)item1), JsonReference.FromValue((JsonBoolean)item2), JsonReference.FromValue((JsonBoolean)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonBoolean> Create(bool item1, bool item2, bool item3, bool item4)
        {
            return new JsonArray<JsonBoolean>(ImmutableArray.Create(JsonReference.FromValue((JsonBoolean)item1), JsonReference.FromValue((JsonBoolean)item2), JsonReference.FromValue((JsonBoolean)item3), JsonReference.FromValue((JsonBoolean)item4)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDecimal> Create(params decimal[] items)
        {
            ImmutableArray<JsonReference>.Builder array = ImmutableArray.CreateBuilder<JsonReference>();

            foreach (decimal item in items)
            {
                array.Add(JsonReference.FromValue((JsonDecimal)item));
            }

            return new JsonArray<JsonDecimal>(array.ToImmutable());
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDecimal> Create(decimal item1)
        {
            return new JsonArray<JsonDecimal>(ImmutableArray.Create(JsonReference.FromValue((JsonDecimal)item1)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDecimal> Create(decimal item1, decimal item2)
        {
            return new JsonArray<JsonDecimal>(ImmutableArray.Create(JsonReference.FromValue((JsonDecimal)item1), JsonReference.FromValue((JsonDecimal)item2)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDecimal> Create(decimal item1, decimal item2, decimal item3)
        {
            return new JsonArray<JsonDecimal>(ImmutableArray.Create(JsonReference.FromValue((JsonDecimal)item1), JsonReference.FromValue((JsonDecimal)item2), JsonReference.FromValue((JsonDecimal)item3)));
        }

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="item1">The first item from which to create a JSON array.</param>
        /// <param name="item2">The second item from which to create a JSON array.</param>
        /// <param name="item3">The third item from which to create a JSON array.</param>
        /// <param name="item4">The fourth item from which to create a JSON array.</param>
        /// <returns>The new JsonArray.</returns>
        public static JsonArray<JsonDecimal> Create(decimal item1, decimal item2, decimal item3, decimal item4)
        {
            return new JsonArray<JsonDecimal>(ImmutableArray.Create(JsonReference.FromValue((JsonDecimal)item1), JsonReference.FromValue((JsonDecimal)item2), JsonReference.FromValue((JsonDecimal)item3), JsonReference.FromValue((JsonDecimal)item4)));
        }

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
