// <copyright file="JsonRef.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System;

    /// <summary>
    /// A JSON $ref as a URI or JsonPointer.
    /// </summary>
    public readonly struct JsonRef
    {
        private readonly ReadOnlyMemory<char> reference;
        private readonly int hashIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRef"/> struct.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public JsonRef(string reference)
        {
            this.reference = reference.AsMemory();
            this.hashIndex = FindHash(reference);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRef"/> struct.
        /// </summary>
        /// <param name="uri">The uri component of the reference.</param>
        /// <param name="pointer">The pointer component of the reference.</param>
        public JsonRef(string uri, string pointer)
            : this(uri.AsMemory(), pointer.AsMemory())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRef"/> struct.
        /// </summary>
        /// <param name="uri">The uri component of the reference.</param>
        /// <param name="pointer">The pointer component of the reference.</param>
        public JsonRef(ReadOnlyMemory<char> uri, ReadOnlyMemory<char> pointer)
            : this(uri.Span, pointer.Span)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRef"/> struct.
        /// </summary>
        /// <param name="uri">The uri component of the reference.</param>
        /// <param name="pointer">The pointer component of the reference.</param>
        public JsonRef(ReadOnlySpan<char> uri, ReadOnlySpan<char> pointer)
        {
            int extra = (pointer.Length == 0 || pointer[0] == '#') ? 0 : 1;
            Memory<char> result = new char[uri.Length + pointer.Length + extra];
            this.hashIndex = pointer.Length == 0 ? -1 : uri.Length;
            uri.CopyTo(result.Span);
            if (extra == 1)
            {
                result.Span[this.hashIndex] = '#';
            }

            if (pointer.Length > 0)
            {
                pointer.CopyTo(result.Span.Slice(this.hashIndex + extra));
            }

            this.reference = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRef"/> struct.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public JsonRef(ReadOnlyMemory<char> reference)
        {
            this.reference = reference;
            this.hashIndex = FindHash(reference.Span);
        }

        /// <summary>
        /// Gets a value indicating whether the ref has a pointer.
        /// </summary>
        public bool HasPointer => this.hashIndex >= 0;

        /// <summary>
        /// Gets a value indicating whether the ref has a uri.
        /// </summary>
        public bool HasUri => this.hashIndex > 0 || this.hashIndex == -1;

        /// <summary>
        /// Gets the pointer part of the reference.
        /// </summary>
        public ReadOnlySpan<char> Pointer => this.HasPointer ? this.reference.Span.Slice(this.hashIndex + 1) : ReadOnlySpan<char>.Empty;

        /// <summary>
        /// Gets the uri part of the reference.
        /// </summary>
        public ReadOnlySpan<char> Uri => this.HasUri
            ? this.hashIndex > 0 ? this.reference.Span.Slice(0, this.hashIndex) : this.reference.Span
            : ReadOnlySpan<char>.Empty;

        /// <summary>
        /// Implicit conversion from a string.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public static implicit operator JsonRef(string reference)
        {
            return new JsonRef(reference);
        }

        /// <summary>
        /// Implicit conversion from a string.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public static implicit operator JsonRef(ReadOnlyMemory<char> reference)
        {
            return new JsonRef(reference);
        }

        /// <summary>
        /// Copy the reference with a different URI.
        /// </summary>
        /// <param name="baseUri">The new base URI.</param>
        /// <returns>The updated reference.</returns>
        public JsonRef WithUri(string baseUri)
        {
            return new JsonRef(baseUri.AsSpan(), this.Pointer);
        }

        /// <summary>
        /// Copy the reference with a different URI.
        /// </summary>
        /// <param name="baseUri">The new base URI.</param>
        /// <returns>The updated reference.</returns>
        public JsonRef WithUri(ReadOnlySpan<char> baseUri)
        {
            return new JsonRef(baseUri, this.Pointer);
        }

        /// <summary>
        /// Copy the reference with a different pointer.
        /// </summary>
        /// <param name="pointer">The new pointer.</param>
        /// <returns>The updated reference.</returns>
        public JsonRef WithPointer(string pointer)
        {
            return new JsonRef(this.Uri, pointer.AsSpan());
        }

        /// <summary>
        /// Copy the reference with a different pointer.
        /// </summary>
        /// <param name="pointer">The new pointer.</param>
        /// <returns>The updated reference.</returns>
        public JsonRef WithPointer(ReadOnlySpan<char> pointer)
        {
            return new JsonRef(this.Uri, pointer);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.reference.ToString();
        }

        private static int FindHash(ReadOnlySpan<char> reference)
        {
            for (int i = 0; i < reference.Length; ++i)
            {
                if (reference[i] == '#')
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
