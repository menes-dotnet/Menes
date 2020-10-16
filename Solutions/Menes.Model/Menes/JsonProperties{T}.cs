// <copyright file="JsonProperties{T}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with additional properties in situ, whether they
    /// originated from JSON or are an array of dotnet properties.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IJsonValue"/>.</typeparam>
    public readonly struct JsonProperties<T>
        where T : struct, IJsonValue
    {
        /// <summary>
        /// An empty list of properties.
        /// </summary>
        public static readonly JsonProperties<T> Empty = default;

        /// <summary>
        /// Creates a <see cref="JsonProperties{T}"/> wrapper around a .NET item array.
        /// </summary>
        /// <param name="clrItems">The .NET items.</param>
        public JsonProperties(ImmutableArray<JsonPropertyReference<T>> clrItems)
        {
            this.ClrItems = clrItems;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonProperties{T}"/> wrapper around a JsonElement.
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
        /// Gets the backing <see cref="ImmutableArray{T}"/> of <see cref="JsonPropertyReference{T}"/>.
        /// </summary>
        /// <remarks>
        /// This will be <see cref="JsonValueKind.Undefined"/> if it is not backed
        /// by a <see cref="JsonElement"/>. See <see cref="HasJsonElement"/>.
        /// </remarks>
        public ImmutableArray<JsonPropertyReference<T>>? ClrItems { get; }

        /// <summary>
        /// Gets an instance of <see cref="JsonProperties{T}"/> from a set of named <see cref="IJsonValue"/>.
        /// </summary>
        /// <param name="item1">The first <see cref="IJsonValue"/> instance.</param>
        /// <returns>An instance of the <see cref="JsonProperties{T}"/> initialized with the values.</returns>
        public static JsonProperties<T> FromValues((string name, T value) item1)
        {
            return new JsonProperties<T>(ImmutableArray.Create(JsonPropertyReference<T>.From(item1.name, item1.value)));
        }

        /// <summary>
        /// Gets an instance of <see cref="JsonProperties{T}"/> from a set of named <see cref="IJsonValue"/>.
        /// </summary>
        /// <param name="clrItems">The <see cref="IJsonValue"/> instances.</param>
        /// <returns>An instance of the <see cref="JsonProperties{T}"/> initialized with the values.</returns>
        public static JsonProperties<T> FromValues(params (string name, T value)[] clrItems)
        {
            ImmutableArray<JsonPropertyReference<T>>.Builder array = ImmutableArray.CreateBuilder<JsonPropertyReference<T>>();
            foreach ((string name, T value) in clrItems)
            {
                array.Add(JsonPropertyReference<T>.From(name, value));
            }

            return new JsonProperties<T>(array.ToImmutable());
        }

        /// <summary>
        /// Represents an enumerator for the properties of the resource.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct JsonPropertyEnumerator : IEnumerable<JsonPropertyReference<T>>, IEnumerable, IEnumerator<JsonPropertyReference<T>>, IEnumerator, IDisposable
        {
            private readonly ImmutableArray<ReadOnlyMemory<byte>> knownProperties;
            private readonly bool[] seenProperties;
            private readonly bool hasJsonEnumerator;

            private JsonElement.ObjectEnumerator jsonEnumerator;
            private ImmutableArray<JsonPropertyReference<T>>.Enumerator clrEnumerator;

            /// <summary>
            /// Initializes a new instance of the <see cref="JsonPropertyEnumerator"/> struct.
            /// </summary>
            /// <param name="items">The target property values.</param>
            /// <param name="knownProperties">The names of the properties that we already know.</param>
            public JsonPropertyEnumerator(JsonProperties<T> items, in ImmutableArray<ReadOnlyMemory<byte>> knownProperties)
            {
                if (items.HasJsonElement)
                {
                    this.hasJsonEnumerator = true;
                    this.jsonEnumerator = items.JsonElement.EnumerateObject();
                    this.clrEnumerator = default;
                }
                else
                {
                    this.clrEnumerator = items.ClrItems.HasValue ? items.ClrItems.Value.GetEnumerator() : ImmutableArray<JsonPropertyReference<T>>.Empty.GetEnumerator();
                    this.jsonEnumerator = default;
                    this.hasJsonEnumerator = false;
                }

                this.knownProperties = knownProperties;
                this.seenProperties = new bool[knownProperties.Length];
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="JsonPropertyEnumerator"/> struct.
            /// </summary>
            /// <param name="jsonElement">The <see cref="JsonElement"/> whose properties we are going to enumerate.</param>
            /// <param name="knownProperties">The names of the properties that we already know.</param>
            public JsonPropertyEnumerator(JsonElement jsonElement, in ImmutableArray<ReadOnlyMemory<byte>> knownProperties)
            {
                if (jsonElement.ValueKind != JsonValueKind.Object)
                {
                    throw new JsonException("Unable to enumerate a non-object");
                }

                this.clrEnumerator = default;
                this.jsonEnumerator = jsonElement.EnumerateObject();
                this.hasJsonEnumerator = true;
                this.knownProperties = knownProperties;
                this.seenProperties = new bool[knownProperties.Length];
            }

            /// <inheritdoc/>
            public JsonPropertyReference<T> Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new JsonPropertyReference<T>(this.jsonEnumerator.Current);
                    }

                    return this.clrEnumerator.Current;
                }
            }

            /// <inheritdoc/>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Returns an enumerator that iterates the links on the document for a particular relation.
            /// </summary>
            /// <returns>An enumerator that can be used to iterate through the links on the document for the relation.</returns>
            public JsonPropertyEnumerator GetEnumerator()
            {
                JsonPropertyEnumerator result = this;
                result.Reset();
                return result;
            }

            /// <inheritdoc/>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            /// <inheritdoc/>
            IEnumerator<JsonPropertyReference<T>> IEnumerable<JsonPropertyReference<T>>.GetEnumerator()
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
                bool result;

                if (this.hasJsonEnumerator)
                {
                    do
                    {
                        result = this.jsonEnumerator.MoveNext();
                    }
                    while (result && this.IsKnownProperty(this.jsonEnumerator.Current));

                    return result;
                }

                do
                {
                    result = this.clrEnumerator.MoveNext();
                }
                while (result && this.IsKnownProperty(this.clrEnumerator.Current));

                return result;
            }

            private bool IsKnownProperty(in JsonPropertyReference<T> current)
            {
                for (int i = 0; i < this.knownProperties.Length; ++i)
                {
                    if (!this.seenProperties[i] && current.NameEquals(this.knownProperties[i].Span))
                    {
                        this.seenProperties[i] = true;
                        return true;
                    }
                }

                return false;
            }

            private bool IsKnownProperty(in JsonProperty current)
            {
                for (int i = 0; i < this.knownProperties.Length; ++i)
                {
                    if (!this.seenProperties[i] && current.NameEquals(this.knownProperties[i].Span))
                    {
                        this.seenProperties[i] = true;
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
