﻿// <copyright file="JsonReference.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Buffers;
    using System.Diagnostics;

    /// <summary>
    /// A JSON $ref as a URI or JsonPointer.
    /// </summary>
    [DebuggerDisplay("{reference}")]
    public readonly struct JsonReference : IEquatable<JsonReference>
    {
        private readonly ReadOnlyMemory<char> reference;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReference"/> struct.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public JsonReference(string reference)
        {
            this.reference = reference.AsMemory();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReference"/> struct.
        /// </summary>
        /// <param name="uri">The uri component of the reference without a fragment.</param>
        /// <param name="fragment">The fragment component of the reference.</param>
        public JsonReference(string uri, string fragment)
            : this(uri.AsMemory(), fragment.AsMemory())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReference"/> struct.
        /// </summary>
        /// <param name="baseUri">The base Uri component of the reference.</param>
        /// <param name="fragment">The fragment component of the reference.</param>
        public JsonReference(ReadOnlyMemory<char> baseUri, ReadOnlyMemory<char> fragment)
            : this(baseUri.Span, fragment.Span)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReference"/> struct.
        /// </summary>
        /// <param name="uri">The uri component of the reference.</param>
        /// <param name="pointer">The pointer component of the reference.</param>
        public JsonReference(ReadOnlySpan<char> uri, ReadOnlySpan<char> pointer)
        {
            int extra = (pointer.Length == 0 || pointer[0] == '#') ? 0 : 1;
            Memory<char> result = new char[uri.Length + pointer.Length + extra];
            uri.CopyTo(result.Span);
            if (pointer.Length > 0)
            {
                result.Span[uri.Length] = '#';
                pointer.CopyTo(result.Span.Slice(uri.Length + extra));
            }

            this.reference = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReference"/> struct.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public JsonReference(ReadOnlyMemory<char> reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Gets a value indicating whether the ref has an absolute uri.
        /// </summary>
        public bool HasAbsoluteUri => this.FindScheme().Length > 0;

        /// <summary>
        /// Gets the URI without the fragment.
        /// </summary>
        public ReadOnlySpan<char> Uri => this.FindUri();

        /// <summary>
        /// Gets the fragment including the leading #.
        /// </summary>
        public ReadOnlySpan<char> Fragment => this.FindFragment();

        /// <summary>
        /// Implicit conversion from a string.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public static implicit operator JsonReference?(string? reference)
        {
            return reference is string ? (JsonReference?)new JsonReference(reference) : null;
        }

        /// <summary>
        /// Implicit conversion from a string.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public static implicit operator JsonReference(string reference)
        {
            return new JsonReference(reference);
        }

        /// <summary>
        /// Implicit conversion from a string.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public static implicit operator string(JsonReference reference)
        {
            return reference.ToString();
        }

        /// <summary>
        /// Implicit conversion from a string.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public static implicit operator string?(JsonReference? reference)
        {
            return reference?.ToString();
        }

        /// <summary>
        /// Implicit conversion from a string.
        /// </summary>
        /// <param name="reference">The reference as a string.</param>
        public static implicit operator JsonReference(ReadOnlyMemory<char> reference)
        {
            return new JsonReference(reference);
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="left">The lhs of the comparison.</param>
        /// <param name="right">The rhs of the comparison.</param>
        /// <returns><c>True</c> if the left equals the right.</returns>
        public static bool operator ==(JsonReference left, JsonReference right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="left">The lhs of the comparison.</param>
        /// <param name="right">The rhs of the comparison.</param>
        /// <returns><c>True</c> if the left does not equals the right.</returns>
        public static bool operator !=(JsonReference left, JsonReference right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Replace the fragment in the reference.
        /// </summary>
        /// <param name="fragment">The fragment to replace.</param>
        /// <returns>A JSON reference with the same uri up to and including path and query, but with a different fragment.</returns>
        public JsonReference WithFragment(string fragment)
        {
            return new JsonReference(this.Uri, fragment);
        }

        /// <summary>
        /// Gets a reference builder for this reference.
        /// </summary>
        /// <returns>The <see cref="JsonReferenceBuilder"/> that gives access to the components of the reference.</returns>
        public JsonReferenceBuilder AsBuilder()
        {
            ReadOnlySpan<char> scheme = this.FindScheme();
            ReadOnlySpan<char> authority = this.FindAuthority(scheme.Length);
            ReadOnlySpan<char> path = this.FindPath(scheme.Length + authority.Length);
            ReadOnlySpan<char> query = this.FindQuery(scheme.Length + authority.Length + path.Length);
            ReadOnlySpan<char> fragment = this.FindFragment(scheme.Length + authority.Length + path.Length + query.Length);

            // Trim the trailing ':'
            if (scheme.Length > 1 && scheme[^1] == ':')
            {
                scheme = scheme[0..^1];
            }

            // Trim the leading '//'
            if (authority.Length > 2 && authority[0] == '/' && authority[1] == '/')
            {
                authority = authority.Slice(2);
            }

            // Trim the leading '?'
            if (query.Length > 1 && query[0] == '?')
            {
                query = query.Slice(1);
            }

            // Trim the leading '#'
            if (fragment.Length > 1 && fragment[0] == '#')
            {
                fragment = fragment.Slice(1);
            }

            return new JsonReferenceBuilder(scheme, authority, path, query, fragment);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is JsonReference @ref && this.Equals(@ref);
        }

        /// <inheritdoc/>
        public bool Equals(JsonReference other)
        {
            return this.reference.Equals(other.reference);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.reference);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.reference.ToString();
        }

        /// <summary>
        /// Combine this Json reference with another using the rules in rfc3986 (https://tools.ietf.org/html/rfc3986#section-5.2.2).
        /// </summary>
        /// <param name="other">The reference with which to combine.</param>
        /// <param name="strict">Whether to be 'strict' in the sense of rc3986.</param>
        /// <returns>The combined reference.</returns>
        public JsonReference Apply(JsonReference other, bool strict = true)
        {
            JsonReferenceBuilder baseReference = this.AsBuilder();
            JsonReferenceBuilder reference = other.AsBuilder();

            ReadOnlySpan<char> scheme = reference.Scheme;
            ReadOnlySpan<char> authority = reference.Authority;
            ReadOnlySpan<char> path = reference.Path;
            ReadOnlySpan<char> query = reference.Query;
            ReadOnlySpan<char> fragment = reference.Fragment;

            ReadOnlySpan<char> resultScheme;
            ReadOnlySpan<char> resultAuthority;
            ReadOnlySpan<char> resultPath;
            ReadOnlySpan<char> resultQuery;
            ReadOnlySpan<char> resultFragment;

            char[] pathBuffer = ArrayPool<char>.Shared.Rent(baseReference.Path.Length + reference.Path.Length + 1);
            Memory<char> pathMemory = pathBuffer.AsMemory();

            try
            {
                if (!strict && scheme.Equals(baseReference.Scheme, StringComparison.Ordinal))
                {
                    scheme = ReadOnlySpan<char>.Empty;
                }

                if (scheme.Length > 0)
                {
                    resultScheme = scheme;
                    resultAuthority = authority;
                    resultPath = RemoveDotSegments(ref path, in pathMemory);
                    resultQuery = query;
                }
                else
                {
                    if (authority.Length > 0)
                    {
                        resultAuthority = authority;
                        resultPath = RemoveDotSegments(ref path, in pathMemory);
                        resultQuery = query;
                    }
                    else
                    {
                        if (path.Length == 0)
                        {
                            resultPath = baseReference.Path;
                            if (query.Length > 0)
                            {
                                resultQuery = query;
                            }
                            else
                            {
                                resultQuery = baseReference.Query;
                            }
                        }
                        else
                        {
                            if (path[0] == '/')
                            {
                                resultPath = RemoveDotSegments(ref path, in pathMemory);
                            }
                            else
                            {
                                int mergedLength = Merge(baseReference.Path, ref path, baseReference.Authority.Length > 0, in pathMemory);
                                ReadOnlySpan<char> mergedPaths = pathMemory.Slice(0, mergedLength).Span;
                                resultPath = RemoveDotSegments(ref mergedPaths, in pathMemory);
                            }

                            resultQuery = query;
                        }

                        resultAuthority = baseReference.Authority;
                    }

                    resultScheme = baseReference.Scheme;
                }

                resultFragment = fragment;

                return new JsonReferenceBuilder(resultScheme, resultAuthority, resultPath, resultQuery, resultFragment).AsReference();
            }
            finally
            {
                ArrayPool<char>.Shared.Return(pathBuffer);
            }
        }

        private static int Merge(ReadOnlySpan<char> basePath, ref ReadOnlySpan<char> path, bool baseHasAuthority, in Memory<char> pathMemory)
        {
            if (baseHasAuthority && basePath.Length == 0)
            {
                pathMemory.Span[0] = '/';
                path.CopyTo(pathMemory.Span.Slice(1));
                return path.Length + 1;
            }

            int lastSlash = basePath.LastIndexOf('/');
            if (lastSlash > 0)
            {
                basePath.Slice(0, lastSlash + 1).CopyTo(pathMemory.Span);
            }

            path.CopyTo(pathMemory.Span.Slice(lastSlash + 1));

            return lastSlash + 1 + path.Length;
        }

        private static ReadOnlySpan<char> RemoveDotSegments(ref ReadOnlySpan<char> path, in Memory<char> mergedPath)
        {
            int readIndex = 0;
            int writeIndex = 0;
            bool hasLeadingSlash = false;

            while (readIndex < path.Length)
            {
                // Look for "../" or "./" and remove the prefix
                if (!hasLeadingSlash && path[readIndex] == '.')
                {
                    if (readIndex + 1 < path.Length)
                    {
                        if (path[readIndex + 1] == '/')
                        {
                            // Skip './'
                            readIndex += 2;
                        }
                        else if (path[readIndex + 1] == '.')
                        {
                            if (readIndex + 2 < path.Length)
                            {
                                if (path[readIndex + 2] == '/')
                                {
                                    // Skip '../'
                                    readIndex += 3;
                                }
                                else
                                {
                                    // Skip '..'
                                    readIndex += 2;
                                }
                            }
                            else
                            {
                                // Skip to the end
                                readIndex += 2;
                            }
                        }
                    }
                    else
                    {
                        // Skip to the end
                        readIndex += 1;
                    }
                }
                else if (hasLeadingSlash || path[readIndex] == '/')
                {
                    if (readIndex + 1 < path.Length)
                    {
                        if (path[readIndex + 1] == '.')
                        {
                            if (readIndex + 2 < path.Length)
                            {
                                if (path[readIndex + 2] == '/')
                                {
                                    // Skip '/.' leaving us at the trailing '/' as required.
                                    if (hasLeadingSlash)
                                    {
                                        readIndex += 1;
                                    }
                                    else
                                    {
                                        readIndex += 2;
                                    }

                                    // (unlike the '/.' case, we can use our real trailing slash)
                                    hasLeadingSlash = false;
                                }
                                else if (path[readIndex + 2] == '.')
                                {
                                    // This is '/..'
                                    if (readIndex + 3 < path.Length)
                                    {
                                        if (path[readIndex + 3] == '/')
                                        {
                                            // Wind back to the previous segment
                                            do
                                            {
                                                if (writeIndex > 0)
                                                {
                                                    writeIndex--;
                                                }
                                            }
                                            while (writeIndex > 0 && mergedPath.Span[writeIndex] != '/');

                                            // Skip '/..' leaving us at the trailing '/' as required.
                                            if (hasLeadingSlash)
                                            {
                                                readIndex += 2;
                                            }
                                            else
                                            {
                                                readIndex += 3;
                                            }

                                            // (unlike the '/..' case, we can use our real trailing slash)
                                            hasLeadingSlash = false;
                                        }
                                        else
                                        {
                                            WritePath(path, mergedPath, ref readIndex, ref writeIndex, ref hasLeadingSlash);
                                        }
                                    }
                                    else
                                    {
                                        // Wind back to the previous segment
                                        do
                                        {
                                            if (writeIndex > 0)
                                            {
                                                writeIndex--;
                                            }
                                        }
                                        while (writeIndex > 0 && mergedPath.Span[writeIndex] != '/');

                                        // Skip the '/..' and give us a virtual trailing slash, then write the path.
                                        readIndex += 3;
                                        hasLeadingSlash = true;
                                        WritePath(path, mergedPath, ref readIndex, ref writeIndex, ref hasLeadingSlash);
                                    }
                                }
                                else
                                {
                                    // Skip the '/.' and give us a virtual trailing slash
                                    if (!hasLeadingSlash)
                                    {
                                        readIndex += 1;
                                    }

                                    hasLeadingSlash = true;
                                }
                            }
                            else
                            {
                                // Skip the '/.' and give us a virtual trailing slash, then write the path.
                                readIndex += 2;
                                hasLeadingSlash = true;
                                WritePath(path, mergedPath, ref readIndex, ref writeIndex, ref hasLeadingSlash);
                            }
                        }
                        else
                        {
                            WritePath(path, mergedPath, ref readIndex, ref writeIndex, ref hasLeadingSlash);
                        }
                    }
                    else
                    {
                        WritePath(path, mergedPath, ref readIndex, ref writeIndex, ref hasLeadingSlash);
                    }
                }
                else
                {
                    WritePath(path, mergedPath, ref readIndex, ref writeIndex, ref hasLeadingSlash);
                }
            }

            return mergedPath.Slice(0, writeIndex).Span;

            static void WritePath(ReadOnlySpan<char> path, Memory<char> mergedPath, ref int readIndex, ref int writeIndex, ref bool hasLeadingSlash)
            {
                Span<char> span = mergedPath.Span;

                if (hasLeadingSlash)
                {
                    span[writeIndex] = '/';
                    writeIndex++;
                    hasLeadingSlash = false;
                }
                else if (path[readIndex] == '/')
                {
                    span[writeIndex] = '/';
                    writeIndex++;
                    readIndex++;
                }

                while (readIndex < path.Length && path[readIndex] != '/')
                {
                    span[writeIndex] = path[readIndex];
                    writeIndex++;
                    readIndex++;
                }
            }
        }

        private static int? FindHash(ReadOnlySpan<char> reference)
        {
            for (int i = 0; i < reference.Length; ++i)
            {
                if (reference[i] == '#')
                {
                    return i;
                }
            }

            return null;
        }

        private ReadOnlySpan<char> FindUri()
        {
            int? hashIndex = FindHash(this.reference.Span);
            if (hashIndex is int hi)
            {
                return this.reference.Span.Slice(0, hi);
            }

            return this.reference.Span;
        }

        private ReadOnlySpan<char> FindFragment()
        {
            int? hashIndex = FindHash(this.reference.Span);
            if (hashIndex is int hi)
            {
                return this.reference.Span.Slice(hi);
            }

            return ReadOnlySpan<char>.Empty;
        }

        private ReadOnlySpan<char> FindFragment(int start)
        {
            int index = start;

            if (index >= this.reference.Length)
            {
                return ReadOnlySpan<char>.Empty;
            }

            // Expect the leading '#'
            if (this.reference.Span[index] != '#')
            {
                return ReadOnlySpan<char>.Empty;
            }

            return this.reference.Span.Slice(index + 1);
        }

        private ReadOnlySpan<char> FindQuery(int start)
        {
            int index = start;

            if (index >= this.reference.Length)
            {
                return ReadOnlySpan<char>.Empty;
            }

            // Expect the leading ?
            if (this.reference.Span[index] != '?')
            {
                return ReadOnlySpan<char>.Empty;
            }

            index++;

            while (index < this.reference.Length && this.reference.Span[index] != '#')
            {
                ++index;
            }

            return this.reference.Span[start..index];
        }

        private ReadOnlySpan<char> FindPath(int start)
        {
            int index = start;

            if (index >= this.reference.Length)
            {
                return ReadOnlySpan<char>.Empty;
            }

            while (index < this.reference.Length && this.reference.Span[index] != '?' && this.reference.Span[index] != '#')
            {
                ++index;
            }

            return this.reference.Span[start..index];
        }

        private ReadOnlySpan<char> FindAuthority(int start)
        {
            int index = start;

            // Expect the leading '//'
            if (index >= this.reference.Length || this.reference.Span[index] != '/' || this.reference.Span[index + 1] != '/')
            {
                return ReadOnlySpan<char>.Empty;
            }

            index += 2;

            while (index < this.reference.Length && this.reference.Span[index] != '/' && this.reference.Span[index] != '?' && this.reference.Span[index] != '#')
            {
                ++index;
            }

            return this.reference.Span[start..index];
        }

        private ReadOnlySpan<char> FindScheme()
        {
            // First character must be a letter for this to be a scheme.
            if (this.reference.Length == 0 || !char.IsLetter(this.reference.Span[0]))
            {
                return ReadOnlySpan<char>.Empty;
            }

            // Start from the second character
            int index = 1;
            while (index < this.reference.Length && this.reference.Span[index] != ':' && (char.IsLetterOrDigit(this.reference.Span[index]) || this.reference.Span[index] == '+' || this.reference.Span[index] == '-' || this.reference.Span[index] == '/'))
            {
                index++;
            }

            if (index < this.reference.Length && this.reference.Span[index] == ':')
            {
                return this.reference.Span.Slice(0, index + 1);
            }

            return ReadOnlySpan<char>.Empty;
        }
    }
}
