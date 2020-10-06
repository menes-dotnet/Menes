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
    using System.Reflection;
    using System.Text.Json;
    using Corvus.Extensions;

    /// <summary>
    /// Enables the Json resources to work with arrays in situ, whether they
    /// originated from JSON or are a .NET array.
    /// </summary>
    /// <typeparam name="TItem">The type of <see cref="IJsonValue"/> that represents the items.</typeparam>
    public readonly struct JsonArray<TItem> : IJsonValue, IEnumerable<TItem>, IEnumerable
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

        private static readonly Func<JsonElement, TItem> ItemFactory = GetItemFactory();

        private static readonly Func<JsonElement, bool, bool> IsItemConvertibleFrom = GetIsItemConvertibleFrom();

        private readonly ImmutableList<Reference>? clrItems;

        /// <summary>
        /// Creates a <see cref="JsonArray{TItem}"/> wrapper around a .NET item array.
        /// </summary>
        /// <param name="clrItems">The .NET items.</param>
        public JsonArray(IEnumerable<TItem> clrItems)
            : this(clrItems.Select(i => new Reference(i)).ToImmutableList())
        {
        }

        /// <summary>
        /// Creates a <see cref="JsonArray{TItem}"/> wrapper around a JsonElement.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the array value to represent.
        /// </param>
        public JsonArray(JsonElement jsonElement)
        {
            if (!IsConvertibleFrom(jsonElement))
            {
                throw new JsonException("The element must be a JSON Array");
            }

            this.clrItems = null;
            this.JsonElement = jsonElement;
        }

        private JsonArray(ImmutableList<Reference> clrItems)
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
        /// Gets an enumerator for the property with the given name.
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
        /// <param name="checkKindOnly">If <c>true</c>, check the <see cref="JsonElement.ValueKind"/> only.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement, bool checkKindOnly = true)
        {
            if (jsonElement.ValueKind != JsonValueKind.Array && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                return false;
            }

            if (!checkKindOnly && typeof(TItem) != typeof(JsonAny) && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                JsonElement.ArrayEnumerator enumerator = jsonElement.EnumerateArray();
                while (enumerator.MoveNext())
                {
                    if (!IsItemConvertibleFrom(enumerator.Current, checkKindOnly))
                    {
                        return false;
                    }
                }
            }

            return true;
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
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? JsonArray<TItem>.FromJsonElement(property)
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
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? JsonArray<TItem>.FromJsonElement(property)
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
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? JsonArray<TItem>.FromJsonElement(property)
                : Null;

        /// <summary>
        /// Enumerate the array.
        /// </summary>
        /// <returns>The enumerator for the array.</returns>
        public JsonArrayEnumerator GetEnumerator()
        {
            if (this.clrItems is ImmutableList<Reference> clrItems)
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
            if (this.clrItems is ImmutableList<Reference> items)
            {
                writer.WriteStartArray();

                foreach (Reference item in items)
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

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrItems is ImmutableList<Reference> _)
            {
                var abw = new ArrayBufferWriter<byte>();
                using var utfw = new Utf8JsonWriter(abw);
                this.WriteTo(utfw);
                utfw.Flush();
                return new JsonAny(abw.WrittenMemory);
            }

            return new JsonAny(this.JsonElement);
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

        private static Func<JsonElement, TItem> GetItemFactory()
        {
            FieldInfo? fieldInfo = typeof(TItem).GetField("FromJsonElement", BindingFlags.Static | BindingFlags.Public);
            if (fieldInfo is null)
            {
                throw new Exception($"The item type {typeof(TItem).FullName} must provide a static public field: 'Func<JsonElement, TItem> FromJsonElement'");
            }

            return CastTo<Func<JsonElement, TItem>>.From(fieldInfo.GetValue(null));
        }

        private static Func<JsonElement, bool, bool> GetIsItemConvertibleFrom()
        {
            MethodInfo? method = typeof(TItem).GetMethod("IsConvertibleFrom", BindingFlags.Static | BindingFlags.Public);

            if (method is null)
            {
                throw new Exception($"The item type {typeof(TItem).FullName} must provide a static public method: 'bool IsConvertibleFrom(JsonElement jsonElement, bool checkKindOnly)'");
            }

            return (Func<JsonElement, bool, bool>)Delegate.CreateDelegate(typeof(Func<JsonElement, bool, bool>), method);
        }

        /// <summary>
        /// An enumerator for a <see cref="JsonArray{TItem}"/>.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct JsonArrayEnumerator : IEnumerable<TItem>, IEnumerable, IEnumerator<TItem>, IEnumerator, IDisposable
        {
            private readonly bool hasJsonEnumerator;

            private JsonElement.ArrayEnumerator jsonEnumerator;
            private ImmutableList<Reference>.Enumerator clrEnumerator;

            /// <summary>
            /// Initializes a new instance of the <see cref="JsonArrayEnumerator"/> struct.
            /// </summary>
            /// <param name="items">The target property values.</param>
            internal JsonArrayEnumerator(ImmutableList<Reference> items)
            {
                this.clrEnumerator = items.GetEnumerator();
                this.jsonEnumerator = default;
                this.hasJsonEnumerator = false;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="JsonArrayEnumerator"/> struct.
            /// </summary>
            /// <param name="jsonElement">The <see cref="JsonElement"/> whose properties we are going to enumerate.</param>
            internal JsonArrayEnumerator(JsonElement jsonElement)
            {
                if (jsonElement.ValueKind != JsonValueKind.Array)
                {
                    throw new JsonException("Unable to enumerate a non-array");
                }

                this.clrEnumerator = default;
                this.jsonEnumerator = jsonElement.EnumerateArray();
                this.hasJsonEnumerator = true;
            }

            /// <inheritdoc/>
            public TItem Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return ItemFactory(this.jsonEnumerator.Current);
                    }

                    return this.clrEnumerator.Current.AsValue<TItem>();
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

                return this.clrEnumerator.MoveNext();
            }
        }
    }
}
