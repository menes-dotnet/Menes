// <copyright file="JsonPropertyEnumerator{TValue}.cs" company="Endjin Limited">
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
    /// Represents an enumerator for the properties of the resource.
    /// </summary>
    /// <typeparam name="TValue">The type of <see cref="IJsonValue"/> being enumerated.</typeparam>
    [DebuggerDisplay("{Current,nq}")]
    public struct JsonPropertyEnumerator<TValue> : IEnumerable<JsonProperty<TValue>>, IEnumerable, IEnumerator<JsonProperty<TValue>>, IEnumerator, IDisposable
        where TValue : IJsonValue
    {
        private readonly ImmutableArray<ReadOnlyMemory<byte>> knownProperties;
        private readonly bool[] seenProperties;
        private readonly bool hasJsonEnumerator;

        private JsonElement.ObjectEnumerator jsonEnumerator;
        private ImmutableDictionary<ReadOnlyMemory<byte>, TValue>.Enumerator clrEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPropertyEnumerator{TValue}"/> struct.
        /// </summary>
        /// <param name="items">The target property values.</param>
        /// <param name="knownProperties">The names of the properties that we already know.</param>
        public JsonPropertyEnumerator(ImmutableDictionary<ReadOnlyMemory<byte>, TValue> items, in ImmutableArray<ReadOnlyMemory<byte>> knownProperties)
        {
            this.clrEnumerator = items.GetEnumerator();
            this.jsonEnumerator = default;
            this.hasJsonEnumerator = false;
            this.knownProperties = knownProperties;
            this.seenProperties = new bool[knownProperties.Length];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPropertyEnumerator{TValue}"/> struct.
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
        public JsonProperty<TValue> Current
        {
            get
            {
                if (this.hasJsonEnumerator)
                {
                    return new JsonProperty<TValue>(this.jsonEnumerator.Current);
                }

                return new JsonProperty<TValue>(this.clrEnumerator.Current.Key, this.clrEnumerator.Current.Value);
            }
        }

        /// <inheritdoc/>
        object IEnumerator.Current => this.Current;

        /// <summary>
        /// Returns an enumerator that iterates the links on the document for a particular relation.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the links on the document for the relation.</returns>
        public JsonPropertyEnumerator<TValue> GetEnumerator()
        {
            JsonPropertyEnumerator<TValue> result = this;
            result.Reset();
            return result;
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator<JsonProperty<TValue>> IEnumerable<JsonProperty<TValue>>.GetEnumerator()
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

        private bool IsKnownProperty(in KeyValuePair<ReadOnlyMemory<byte>, TValue> current)
        {
            for (int i = 0; i < this.knownProperties.Length; ++i)
            {
                if (!this.seenProperties[i] && this.knownProperties[i].Span.SequenceEqual(current.Key.Span))
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
