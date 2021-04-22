// <copyright file="JsonArray.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Buffers;
    using System.Collections.Immutable;
    using System.Text.Json;

    /// <summary>
    /// A JSON array.
    /// </summary>
    public readonly struct JsonArray : IJsonArray<JsonArray>, IEquatable<JsonArray>
    {
        /// <summary>
        /// An empty JsonArray.
        /// </summary>
        public static readonly JsonArray Empty = new JsonArray(ImmutableList<JsonAny>.Empty);

        private readonly JsonElement jsonElement;
        private readonly ImmutableList<JsonAny>? items;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonArray"/> struct.
        /// </summary>
        /// <param name="jsonElement">The JSON element from which to construct the array.</param>
        public JsonArray(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.items = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonArray"/> struct.
        /// </summary>
        /// <param name="items">An immutable list of items in the array.</param>
        public JsonArray(ImmutableList<JsonAny> items)
        {
            this.jsonElement = default;
            this.items = items;
        }

        /// <summary>
        /// Gets the <see cref="JsonValueKind"/>.
        /// </summary>
        public JsonValueKind ValueKind
        {
            get
            {
                if (this.items is not null)
                {
                    return JsonValueKind.Array;
                }

                return this.jsonElement.ValueKind;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is backed by a <see cref="JsonElement"/>.
        /// </summary>
        public bool HasJsonElement => this.items is null;

        /// <inheritdoc/>
        public int Length
        {
            get
            {
                if (this.items is ImmutableList<JsonAny> items)
                {
                    return items.Count;
                }

                return this.jsonElement.GetArrayLength();
            }
        }

        /// <summary>
        /// Gets the backing <see cref="JsonElement"/>.
        /// </summary>
        public JsonElement AsJsonElement
        {
            get
            {
                if (this.items is ImmutableList<JsonAny> items)
                {
                    return ItemsToJsonElement(items);
                }

                return this.jsonElement;
            }
        }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
                return new JsonAny(this);
            }
        }

        /// <summary>
        /// Gets the instance as a list of <see cref="JsonAny"/>.
        /// </summary>
        public ImmutableList<JsonAny> AsItemsList
        {
            get
            {
                if (this.items is ImmutableList<JsonAny> items)
                {
                    return items;
                }

                if (this.jsonElement.ValueKind == JsonValueKind.Array)
                {
                    ImmutableList<JsonAny>.Builder builder = ImmutableList.CreateBuilder<JsonAny>();
                    foreach (JsonElement item in this.jsonElement.EnumerateArray())
                    {
                        builder.Add(new JsonAny(item));
                    }

                    return builder.ToImmutable();
                }

                return ImmutableList<JsonAny>.Empty;
            }
        }

        /// <summary>
        /// Implicit conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(JsonArray value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonArray(JsonAny value)
        {
            return value.AsArray;
        }

        /// <summary>
        /// Implicit conversion to an <see cref="ImmutableList{T}"/> of <see cref="JsonAny"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator ImmutableList<JsonAny>(JsonArray value)
        {
            return value.AsItemsList;
        }

        /// <summary>
        /// Implicit conversion from an <see cref="ImmutableList{T}"/> of <see cref="JsonAny"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonArray(ImmutableList<JsonAny> value)
        {
            return new JsonArray(value);
        }

        /// <summary>
        /// Create an array from the given items.
        /// </summary>
        /// <param name="items">The items from which to create the array.</param>
        /// <returns>The new array created from the items.</returns>
        public static JsonArray From(params JsonAny[] items)
        {
            return new JsonArray(items.ToImmutableList());
        }

        /// <summary>
        /// Create an array from the given items.
        /// </summary>
        /// <param name="item1">The items from which to create the array.</param>
        /// <returns>The new array created from the items.</returns>
        public static JsonArray From(JsonAny item1)
        {
            return new JsonArray(ImmutableList.Create(item1));
        }

        /// <summary>
        /// Create an array from the given items.
        /// </summary>
        /// <param name="item1">The first item from which to create the array.</param>
        /// <param name="item2">The second item from which to create the array.</param>
        /// <returns>The new array created from the items.</returns>
        public static JsonArray From(JsonAny item1, JsonAny item2)
        {
            return new JsonArray(ImmutableList.Create(item1, item2));
        }

        /// <summary>
        /// Create an array from the given items.
        /// </summary>
        /// <param name="item1">The first item from which to create the array.</param>
        /// <param name="item2">The second item from which to create the array.</param>
        /// <param name="item3">The third item from which to create the array.</param>
        /// <returns>The new array created from the items.</returns>
        public static JsonArray From(JsonAny item1, JsonAny item2, JsonAny item3)
        {
            return new JsonArray(ImmutableList.Create(item1, item2, item3));
        }

        /// <summary>
        /// Create an array from the given items.
        /// </summary>
        /// <param name="item1">The first item from which to create the array.</param>
        /// <param name="item2">The second item from which to create the array.</param>
        /// <param name="item3">The third item from which to create the array.</param>
        /// <param name="item4">The fourth item from which to create the array.</param>
        /// <returns>The new array created from the items.</returns>
        public static JsonArray From(JsonAny item1, JsonAny item2, JsonAny item3, JsonAny item4)
        {
            return new JsonArray(ImmutableList.Create(item1, item2, item3, item4));
        }

        /// <summary>
        /// Convert an items array to a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="items">The items to convert.</param>
        /// <returns>The <see cref="JsonElement"/>.</returns>
        public static JsonElement ItemsToJsonElement(ImmutableList<JsonAny> items)
        {
            var abw = new ArrayBufferWriter<byte>();
            using var writer = new Utf8JsonWriter(abw);
            WriteItems(items, writer);
            writer.Flush();
            var reader = new Utf8JsonReader(abw.WrittenSpan);
            using var document = JsonDocument.ParseValue(ref reader);
            return document.RootElement.Clone();
        }

        /// <summary>
        /// Write an items array to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="items">The items to write.</param>
        /// <param name="writer">The writer to which to write the array.</param>
        public static void WriteItems(ImmutableList<JsonAny> items, Utf8JsonWriter writer)
        {
            writer.WriteStartArray();

            foreach (JsonAny item in items)
            {
                item.WriteTo(writer);
            }

            writer.WriteEndArray();
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.As<JsonArray, T>();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;

            return Json.Validate.TypeArray(this.ValueKind, result, level);
        }

        /// <summary>
        /// Writes the array to the <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the array.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.items is ImmutableList<JsonAny> items)
            {
                WriteItems(items, writer);
            }
            else
            {
                this.jsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonArrayEnumerator EnumerateArray()
        {
            if (this.items is ImmutableList<JsonAny> items)
            {
                return new JsonArrayEnumerator(items);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.Array)
            {
                return new JsonArrayEnumerator(this.jsonElement);
            }

            return default;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            if (other.ValueKind != JsonValueKind.Array)
            {
                return false;
            }

            return this.Equals(other.AsArray());
        }

        /// <inheritdoc/>
        public bool Equals(JsonArray other)
        {
            if (other.ValueKind != this.ValueKind || this.ValueKind != JsonValueKind.Array)
            {
                return false;
            }

            JsonArrayEnumerator lhs = this.EnumerateArray();
            JsonArrayEnumerator rhs = other.EnumerateArray();
            while (lhs.MoveNext())
            {
                if (!rhs.MoveNext())
                {
                    return false;
                }

                if (!lhs.Current.Equals(rhs.Current))
                {
                    return false;
                }
            }

            if (rhs.MoveNext())
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public JsonArray Add<TItem>(TItem item)
            where TItem : struct, IJsonValue
        {
            return new JsonArray(this.AsItemsList.Add(item.AsAny));
        }

        /// <inheritdoc/>
        public JsonArray Insert<TItem>(int index, TItem item)
            where TItem : struct, IJsonValue
        {
            return new JsonArray(this.AsItemsList.Insert(index, item.AsAny));
        }

        /// <inheritdoc/>
        public JsonArray Replace<TItem>(TItem oldValue, TItem newValue)
            where TItem : struct, IJsonValue
        {
            return new JsonArray(this.AsItemsList.Replace(oldValue.AsAny, newValue.AsAny));
        }

        /// <inheritdoc/>
        public JsonArray SetItem<TItem>(int index, TItem value)
            where TItem : struct, IJsonValue
        {
            return new JsonArray(this.AsItemsList.SetItem(index, value.AsAny));
        }

        /// <inheritdoc/>
        public JsonArray RemoveAt(int index)
        {
            return new JsonArray(this.AsItemsList.RemoveAt(index));
        }

        /// <inheritdoc/>
        public JsonArray RemoveRange(int index, int count)
        {
            return new JsonArray(this.AsItemsList.RemoveRange(index, count));
        }
    }
}
