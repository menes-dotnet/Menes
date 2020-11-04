// <copyright file="JsonArray{TItem}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with arrays in situ, whether they
    /// originated from JSON or are a .NET array.
    /// </summary>
    /// <typeparam name="TItem">The type of <see cref="IJsonValue"/> that represents the items.</typeparam>
    public readonly struct JsonArray<TItem> : IJsonValue, IEnumerable<TItem>, IEnumerable, IEquatable<JsonArray<TItem>>
        where TItem : struct, IJsonValue
    {
        /// <summary>
        /// The function that constructs an instance from a <see cref="JsonElement"/>.
        /// </summary>
        public static readonly Func<JsonElement, JsonArray<TItem>> FromJsonElement = e => new JsonArray<TItem>(e);

        /// <summary>
        /// A <see cref="JsonArray{TItem}"/> representing a null value.
        /// </summary>
        public static readonly JsonArray<TItem> Null = new JsonArray<TItem>(default(JsonElement));

        private readonly ImmutableArray<JsonReference>? clrItems;

        /// <summary>
        /// Creates a <see cref="JsonArray{TItem}"/> wrapper around a JsonElement.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the array value to represent.
        /// </param>
        public JsonArray(JsonElement jsonElement)
        {
            this.clrItems = null;
            this.JsonElement = jsonElement;
        }

        /// <summary>
        /// Construct from an array of <see cref="JsonReference"/>.
        /// </summary>
        /// <param name="clrItems">The json references to the items.</param>
        internal JsonArray(ImmutableArray<JsonReference> clrItems)
        {
            this.clrItems = clrItems;
            this.JsonElement = default;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrItems == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this boolean as a nullable value type.
        /// </summary>
        public JsonArray<TItem>? AsOptional => this.IsNull ? default(JsonArray<TItem>?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Gets the length of the array.
        /// </summary>
        public int Length
        {
            get
            {
                if (this.HasJsonElement)
                {
                    return this.JsonElement.GetArrayLength();
                }

                if (this.clrItems is ImmutableArray<JsonReference> items)
                {
                    return items.Length;
                }

                return 0;
            }
        }

        /// <summary>
        /// Create a JsonArray from an array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        public static implicit operator JsonArray<TItem>(TItem[] items) => JsonArray.Create(items);

        /// <summary>
        /// Create a JsonArray from an immutable array of items.
        /// </summary>
        /// <param name="items">The items from which to create a JSON array.</param>
        public static implicit operator JsonArray<TItem>(ImmutableArray<TItem> items) => JsonArray.Create(items);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonArray<TItem> item) => JsonAny.From(item);

        /// <summary>
        /// Gets an enumerator for the array.
        /// </summary>
        /// <param name="arrayElement">The array element, or <see cref="JsonValueKind.Undefined"/> if not available.</param>
        /// <param name="jsonElement">The element for which to retrieve the property enumerator.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An enumerator for the property, or null if the property does not exist, or is not an array.</returns>
        public static JsonArrayEnumerator? GetEnumerator(in JsonElement arrayElement, in JsonElement jsonElement, ReadOnlySpan<byte> propertyName)
        {
            if (arrayElement.ValueKind == JsonValueKind.Array)
            {
                return new JsonArrayEnumerator(arrayElement);
            }

            if (jsonElement.TryGetProperty(propertyName, out JsonElement value) && value.ValueKind == JsonValueKind.Array)
            {
                return new JsonArrayEnumerator(value);
            }

            return default;
        }

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement)
        {
            return jsonElement.ValueKind == JsonValueKind.Array || jsonElement.ValueKind == JsonValueKind.Null;
        }

        /// <summary>
        /// Gets a <see cref="JsonArray{TItem}"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonArray{TItem}"/> or null.</returns>
        public static JsonArray<TItem> FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonArray<TItem>(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonArray{TItem}"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonArray{TItem}"/> or null.</returns>
        public static JsonArray<TItem> FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonArray<TItem>(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonArray{TItem}"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonArray{TItem}"/> or null.</returns>
        public static JsonArray<TItem> FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonArray<TItem>(property)
                    : Null)
                : Null;

        /// <summary>
        /// Enumerate the array.
        /// </summary>
        /// <returns>The enumerator for the array.</returns>
        public JsonArrayEnumerator GetEnumerator()
        {
            if (this.clrItems is ImmutableArray<JsonReference> clrItems)
            {
                return new JsonArrayEnumerator(clrItems);
            }

            return new JsonArrayEnumerator(this.JsonElement);
        }

        /// <summary>
        /// Writes the array value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the array.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrItems is ImmutableArray<JsonReference> items)
            {
                writer.WriteStartArray();

                foreach (JsonReference item in items)
                {
                    item.AsValue<TItem>().WriteTo(writer);
                }

                writer.WriteEndArray();
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <summary>
        /// Validate the maximum number of items in the array.
        /// </summary>
        /// <param name="validationContext">The validation context for this item.</param>
        /// <param name="maxItems">The maximum permitted number of items.</param>
        /// <returns>The validation context updated with the result of the check.</returns>
        public ValidationContext ValidateMaxItems(in ValidationContext validationContext, long maxItems)
        {
            if (this.Length > maxItems)
            {
                return validationContext.WithError($"6.4.1. maxItems: Expected no more than {maxItems} in the array, but found {this.Length}.");
            }

            return validationContext;
        }

        /// <summary>
        /// Validate the maximum number of items in the array.
        /// </summary>
        /// <param name="validationContext">The validation context for this item.</param>
        /// <param name="minItems">The minimum permitted number of items.</param>
        /// <returns>The validation context updated with the result of the check.</returns>
        public ValidationContext ValidateMinItems(in ValidationContext validationContext, long minItems)
        {
            if (this.Length < minItems)
            {
                return validationContext.WithError($"6.4.2. minItems: Expected no fewer than {minItems} in the array, but found {this.Length}.");
            }

            return validationContext;
        }

        /// <summary>
        /// Determines if all the items in the array are unique.
        /// </summary>
        /// <param name="validationContext">The validation context for this item.</param>
        /// <param name="validateItems">Whether to validate the items in the array during the iteration.</param>
        /// <returns>The validation context updated with the result of the check.</returns>
        public ValidationContext ValidateUniqueItems(in ValidationContext validationContext, bool validateItems)
        {
            ValidationContext result = validationContext;
            int index = 0;
            ImmutableArray<TItem>.Builder items = ImmutableArray.CreateBuilder<TItem>();
            JsonArray<TItem>.JsonArrayEnumerator enumerator = this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (!items.Any(i => i.Equals(enumerator.Current)))
                {
                    items.Add(enumerator.Current);
                }

                if (validateItems)
                {
                    result = Validation.ValidateProperty(result, enumerator.Current, $"[{index}]");
                }

                index++;
            }

            if (items.Count != this.Length)
            {
                result = result.WithError($"6.4.3. uniqueItems: Expected all items to be unique, but there were {this.Length - items.Count} duplicates.");
            }

            return result;
        }

        /// <summary>
        /// Validate the items in the array.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation context updated with the result of the check.</returns>
        public ValidationContext ValidateItems(in ValidationContext validationContext)
        {
            ValidationContext result = validationContext;
            JsonArray<TItem>.JsonArrayEnumerator enumerator = this.GetEnumerator();
            int index = 0;

            while (enumerator.MoveNext())
            {
                result = Validation.ValidateProperty(result, enumerator.Current, $"[{index}]");
                index++;
            }

            return result;
        }

        /// <summary>
        /// Determines how many items there are that are convertible to the given item type.
        /// </summary>
        /// <typeparam name="TItemType">The type of the item.</typeparam>
        /// <param name="validationContext">The validation context for this item.</param>
        /// <param name="minItems">The minimum number of items that match the given schema.</param>
        /// <param name="maxItems">The maximum number of items that match the given schema.</param>
        /// <param name="requireUnique">Require the items to be unique.</param>
        /// <param name="validateItems">Whether to validate the items in the array during the iteration.</param>
        /// <returns>The validation context updated with the result of the check.</returns>
        /// <remnarks>
        /// This gives you the ability to validate uniqueness, min, and/or max, and the validity of the items contained within the array, in a single interation of the array.
        /// </remnarks>
        public ValidationContext ValidateRangeContains<TItemType>(in ValidationContext validationContext, int minItems, int maxItems, bool requireUnique, bool validateItems)
            where TItemType : struct, IJsonValue
        {
            ValidationContext result = validationContext;
            ImmutableArray<TItem>.Builder items = ImmutableArray.CreateBuilder<TItem>();

            int count = 0;
            int index = 0;
            JsonArray<TItem>.JsonArrayEnumerator enumerator = this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (JsonAny.From(enumerator.Current).As<TItemType>().Validate(ValidationContext.Root).IsValid)
                {
                    count++;
                    if (count == maxItems + 1)
                    {
                        result = result.WithError($"6.4.4. maxContains: Expected there to be no more than {maxItems} matching type {typeof(TItemType).FullName} in the array.");
                    }
                }

                if (requireUnique)
                {
                    if (!items.Any(i => i.Equals(enumerator.Current)))
                    {
                        items.Add(enumerator.Current);
                    }
                }

                if (validateItems)
                {
                    result = Validation.ValidateProperty(result, enumerator.Current, $"[{index}]");
                }

                index++;
            }

            if (count < minItems)
            {
                result = result.WithError($"6.4.5. minContains: Expected there to be no fewer than {minItems} matching type {typeof(TItemType).FullName} in the array.");
            }

            if (requireUnique && items.Count != this.Length)
            {
                result = result.WithError($"6.4.3. uniqueItems: Expected all items to be unique, but there were {this.Length - items.Count} duplicates.");
            }

            return result;
        }

        /// <inheritdoc/>
        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <inheritdoc/>
        public bool Equals(JsonArray<TItem> other)
        {
            if (this.Length != other.Length)
            {
                return false;
            }

            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            JsonArray<TItem>.JsonArrayEnumerator first = this.GetEnumerator();
            JsonArray<TItem>.JsonArrayEnumerator second = other.GetEnumerator();

            EqualityComparer<TItem> comparer = EqualityComparer<TItem>.Default;
            while (first.MoveNext() && second.MoveNext())
            {
                if (!comparer.Equals(first.Current, second.Current))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.IsNull || (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement)))
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind}  is not convertible to the type {typeof(TItem).FullName}");
            }

            // Note that this doesn't validate the items. You call ValidateItems() explicitly if you want
            // them to be validated. This allows you to avoid iterating the array more than once.
            return validationContext;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.IsNull)
            {
                return string.Empty;
            }

            var abw = new ArrayBufferWriter<byte>();
            using var writer = new Utf8JsonWriter(abw);
            this.WriteTo(writer);
            writer.Flush();
            return Encoding.UTF8.GetString(abw.WrittenSpan);
        }

        /// <summary>
        /// Add items to the array.
        /// </summary>
        /// <param name="items">The items to add.</param>
        /// <returns>A new array instance, with the added items.</returns>
        public JsonArray<TItem> Add(params TItem[] items)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                arrayBuilder.Add(item);
            }

            foreach (TItem item in items)
            {
                arrayBuilder.Add(item);
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Add items to the array.
        /// </summary>
        /// <param name="item1">The item to add.</param>
        /// <returns>A new array instance, with the added item.</returns>
        public JsonArray<TItem> Add(in TItem item1)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                arrayBuilder.Add(item);
            }

            arrayBuilder.Add(item1);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Add items to the array.
        /// </summary>
        /// <param name="item1">The first item to add.</param>
        /// <param name="item2">The second item to add.</param>
        /// <returns>A new array instance, with the added items.</returns>
        public JsonArray<TItem> Add(in TItem item1, in TItem item2)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                arrayBuilder.Add(item);
            }

            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Add items to the array.
        /// </summary>
        /// <param name="item1">The first item to add.</param>
        /// <param name="item2">The second item to add.</param>
        /// <param name="item3">The third item to add.</param>
        /// <returns>A new array instance, with the added items.</returns>
        public JsonArray<TItem> Add(in TItem item1, in TItem item2, in TItem item3)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                arrayBuilder.Add(item);
            }

            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            arrayBuilder.Add(item3);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Add items to the array.
        /// </summary>
        /// <param name="item1">The first item to add.</param>
        /// <param name="item2">The second item to add.</param>
        /// <param name="item3">The third item to add.</param>
        /// <param name="item4">The fourth item to add.</param>
        /// <returns>A new array instance, with the added items.</returns>
        public JsonArray<TItem> Add(in TItem item1, in TItem item2, in TItem item3, in TItem item4)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                arrayBuilder.Add(item);
            }

            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            arrayBuilder.Add(item3);
            arrayBuilder.Add(item4);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Insert items into the array.
        /// </summary>
        /// <param name="indexToInsert">The index at which to insert the items.</param>
        /// <param name="items">The items to insert.</param>
        /// <returns>A new array instance, with the inserted items.</returns>
        public JsonArray<TItem> Insert(int indexToInsert, params TItem[] items)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            int index = 0;
            foreach (TItem item in this)
            {
                if (index == indexToInsert)
                {
                    foreach (TItem itemToInsert in items)
                    {
                        arrayBuilder.Add(itemToInsert);
                    }
                }

                arrayBuilder.Add(item);
                ++index;
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// insert an item into the array.
        /// </summary>
        /// <param name="indexToInsert">The index at which to insert the item.</param>
        /// <param name="item1">The item to insert.</param>
        /// <returns>A new array instance, with the inserted item.</returns>
        public JsonArray<TItem> Insert(int indexToInsert, in TItem item1)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            int index = 0;
            foreach (TItem item in this)
            {
                if (index == indexToInsert)
                {
                    arrayBuilder.Add(item1);
                }

                arrayBuilder.Add(item);
                ++index;
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Insert items into the array.
        /// </summary>
        /// <param name="indexToInsert">The index at which to insert the items.</param>
        /// <param name="item1">The first item to insert.</param>
        /// <param name="item2">The second item to insert.</param>
        /// <returns>A new array instance, with the inserted items.</returns>
        public JsonArray<TItem> Insert(int indexToInsert, in TItem item1, in TItem item2)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            int index = 0;
            foreach (TItem item in this)
            {
                if (index == indexToInsert)
                {
                    arrayBuilder.Add(item1);
                    arrayBuilder.Add(item2);
                }

                arrayBuilder.Add(item);
                ++index;
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Insert items into the array.
        /// </summary>
        /// <param name="indexToInsert">The index at which to insert the items.</param>
        /// <param name="item1">The first item to insert.</param>
        /// <param name="item2">The second item to insert.</param>
        /// <param name="item3">The third item to insert.</param>
        /// <returns>A new array instance, with the inserted items.</returns>
        public JsonArray<TItem> Insert(int indexToInsert, in TItem item1, in TItem item2, in TItem item3)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            int index = 0;
            foreach (TItem item in this)
            {
                if (index == indexToInsert)
                {
                    arrayBuilder.Add(item1);
                    arrayBuilder.Add(item2);
                    arrayBuilder.Add(item3);
                }

                arrayBuilder.Add(item);
                ++index;
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Insert items into the array.
        /// </summary>
        /// <param name="indexToInsert">The index at which to insert the items.</param>
        /// <param name="item1">The first item to insert.</param>
        /// <param name="item2">The second item to insert.</param>
        /// <param name="item3">The third item to insert.</param>
        /// <param name="item4">The fourth item to insert.</param>
        /// <returns>A new array instance, with the inserted items.</returns>
        public JsonArray<TItem> Insert(int indexToInsert, in TItem item1, in TItem item2, in TItem item3, in TItem item4)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            int index = 0;
            foreach (TItem item in this)
            {
                if (index == indexToInsert)
                {
                    arrayBuilder.Add(item1);
                    arrayBuilder.Add(item2);
                    arrayBuilder.Add(item3);
                    arrayBuilder.Add(item4);
                }

                arrayBuilder.Add(item);
                ++index;
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Remove items from the array.
        /// </summary>
        /// <param name="items">The items to remove.</param>
        /// <returns>A new array instance, with the items removed.</returns>
        public JsonArray<TItem> Remove(params TItem[] items)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                bool found = false;
                foreach (TItem itemToRemove in items)
                {
                    if (itemToRemove.Equals(item))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    arrayBuilder.Add(item);
                }
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Remove items from the array.
        /// </summary>
        /// <param name="item1">The item to remove.</param>
        /// <returns>A new array instance, with the item removed.</returns>
        public JsonArray<TItem> Remove(TItem item1)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                if (item1.Equals(item))
                {
                    break;
                }

                arrayBuilder.Add(item);
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Remove items from the array.
        /// </summary>
        /// <param name="item1">The first item to remove.</param>
        /// <param name="item2">The second item to remove.</param>
        /// <returns>A new array instance, with the items removed.</returns>
        public JsonArray<TItem> Remove(TItem item1, TItem item2)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                if (item1.Equals(item) || item2.Equals(item))
                {
                    break;
                }

                arrayBuilder.Add(item);
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Remove items from the array.
        /// </summary>
        /// <param name="item1">The first item to remove.</param>
        /// <param name="item2">The second item to remove.</param>
        /// <param name="item3">The third item to remove.</param>
        /// <returns>A new array instance, with the items removed.</returns>
        public JsonArray<TItem> Remove(TItem item1, TItem item2, TItem item3)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                {
                    break;
                }

                arrayBuilder.Add(item);
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Remove items from the array.
        /// </summary>
        /// <param name="item1">The first item to remove.</param>
        /// <param name="item2">The second item to remove.</param>
        /// <param name="item3">The third item to remove.</param>
        /// <param name="item4">The fourth item to remove.</param>
        /// <returns>A new array instance, with the items removed.</returns>
        public JsonArray<TItem> Remove(TItem item1, TItem item2, TItem item3, TItem item4)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                {
                    break;
                }

                arrayBuilder.Add(item);
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Remove an item from the array at the given index.
        /// </summary>
        /// <param name="indexToRemove">The index of the item to remove.</param>
        /// <returns>A new array instance, with the item removed.</returns>
        public JsonArray<TItem> RemoveAt(int indexToRemove)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            int index = 0;
            foreach (TItem item in this)
            {
                if (index == indexToRemove)
                {
                    index++;
                    continue;
                }

                arrayBuilder.Add(item);
                index++;
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Remove an item from the array at the given index.
        /// </summary>
        /// <param name="startIndex">The start index of the range to remove.</param>
        /// <param name="length">The length of the range to remove.</param>
        /// <returns>A new array instance, with the item removed.</returns>
        public JsonArray<TItem> RemoveRange(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex > this.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (length < 1 || startIndex + length > this.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            int index = 0;
            foreach (TItem item in this)
            {
                if (index >= startIndex && index < startIndex + length)
                {
                    index++;
                    continue;
                }

                arrayBuilder.Add(item);
                index++;
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// Remove items from the array if they match a given predicate.
        /// </summary>
        /// <param name="removeIfTrue">A predicate which, if true, will cause the item to be removed.</param>
        /// <returns>A new array instance, with the matching items removed.</returns>
        public JsonArray<TItem> Remove(Predicate<TItem> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<TItem>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<TItem>();
            foreach (TItem item in this)
            {
                if (removeIfTrue(item))
                {
                    continue;
                }

                arrayBuilder.Add(item);
            }

            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }

        /// <summary>
        /// An enumerator for a <see cref="JsonArray{TItem}"/>.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct JsonArrayEnumerator : IEnumerable<TItem>, IEnumerable, IEnumerator<TItem>, IEnumerator, IDisposable
        {
            private readonly bool hasJsonEnumerator;
            private readonly bool hasClrEnumerator;

            private JsonElement.ArrayEnumerator jsonEnumerator;
            private ImmutableArray<JsonReference>.Enumerator clrEnumerator;

            /// <summary>
            /// Initializes a new instance of the <see cref="JsonArrayEnumerator"/> struct.
            /// </summary>
            /// <param name="items">The target property values.</param>
            internal JsonArrayEnumerator(ImmutableArray<JsonReference> items)
            {
                this.clrEnumerator = items.GetEnumerator();
                this.jsonEnumerator = default;
                this.hasJsonEnumerator = false;
                this.hasClrEnumerator = true;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="JsonArrayEnumerator"/> struct.
            /// </summary>
            /// <param name="jsonElement">The <see cref="JsonElement"/> whose properties we are going to enumerate.</param>
            internal JsonArrayEnumerator(JsonElement jsonElement)
            {
                if (jsonElement.ValueKind != JsonValueKind.Array)
                {
                    this.clrEnumerator = default;
                    this.jsonEnumerator = default;
                    this.hasJsonEnumerator = false;
                    this.hasClrEnumerator = false;
                }
                else
                {
                    this.clrEnumerator = default;
                    this.hasClrEnumerator = false;
                    this.jsonEnumerator = jsonElement.EnumerateArray();
                    this.hasJsonEnumerator = true;
                }
            }

            /// <inheritdoc/>
            public TItem Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return JsonAny.As<TItem>(this.jsonEnumerator.Current);
                    }
                    else if (this.hasClrEnumerator)
                    {
                        return this.clrEnumerator.Current.AsValue<TItem>();
                    }

                    return default;
                }
            }

            /// <inheritdoc/>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Returns an enumerator that iterates the links on the document for a particular relation.
            /// </summary>
            /// <returns>An enumerator that can be used to iterate through the links on the document for the relation.</returns>
            public JsonArrayEnumerator GetEnumerator()
            {
                JsonArrayEnumerator result = this;
                result.Reset();
                return result;
            }

            /// <inheritdoc/>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            /// <inheritdoc/>
            IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            /// <inheritdoc/>
            public void Dispose()
            {
                if (this.hasJsonEnumerator)
                {
                    this.jsonEnumerator.Dispose();
                }
            }

            /// <inheritdoc/>
            public void Reset()
            {
                if (this.hasJsonEnumerator)
                {
                    this.jsonEnumerator.Reset();
                }
            }

            /// <inheritdoc/>
            public bool MoveNext()
            {
                if (this.hasJsonEnumerator)
                {
                    return this.jsonEnumerator.MoveNext();
                }
                else if (this.hasClrEnumerator)
                {
                    return this.clrEnumerator.MoveNext();
                }

                return false;
            }
        }
    }
}
