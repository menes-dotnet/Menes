﻿// <copyright file="JsonPointerUtilities.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// Utility function to resolve the JsonElement referenced by a json pointer into a json element.
    /// </summary>
    /// <remarks>
    /// Note that we don't support <c>$anchor</c> or <c>$id</c> with this implementation.
    /// </remarks>
    public static class JsonPointerUtilities
    {
        private static readonly HashSet<char> ReservedCharacters = new () { '%', '"' };
        private static readonly char[] HexDigits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root document from which to start resolving the pointer.</param>
        /// <param name="fragment">The fragment in <c>#/blah/foo/3/bar/baz</c> form.</param>
        /// <returns><c>true</c> if the element was found.</returns>
        public static JsonElement ResolvePointer(JsonDocument root, in ReadOnlySpan<char> fragment)
        {
            if (TryResolvePointer(root.RootElement, fragment, true, out JsonElement? element))
            {
                return element.Value;
            }

            throw new InvalidOperationException("Internal error: TryResolveFragment() should have thrown if it failed to resolve a fragment");
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root element from which to start resolving the pointer.</param>
        /// <param name="fragment">The fragment in <c>#/blah/foo/3/bar/baz</c> form.</param>
        /// <returns><c>true</c> if the element was found.</returns>
        public static JsonElement ResolvePointer(JsonElement root, in ReadOnlySpan<char> fragment)
        {
            if (TryResolvePointer(root, fragment, true, out JsonElement? element))
            {
                return element.Value;
            }

            throw new InvalidOperationException("Internal error: TryResolveFragment() should have thrown if it failed to resolve a fragment");
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root document from which to start resolving the pointer.</param>
        /// <param name="fragment">The fragment in <c>#/blah/foo/3/bar/baz</c> form.</param>
        /// <param name="element">The element found at the given location.</param>
        /// <returns><c>true</c> if the element was found.</returns>
        public static bool TryResolvePointer(JsonDocument root, in ReadOnlySpan<char> fragment, [NotNullWhen(true)] out JsonElement? element)
        {
            return TryResolvePointer(root.RootElement, fragment, false, out element);
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root eleement from which to start resolving the pointer.</param>
        /// <param name="fragment">The fragment in <c>#/blah/foo/3/bar/baz</c> form.</param>
        /// <param name="element">The element found at the given location.</param>
        /// <returns><c>true</c> if the element was found.</returns>
        public static bool TryResolvePointer(JsonElement root, in ReadOnlySpan<char> fragment, [NotNullWhen(true)] out JsonElement? element)
        {
            return TryResolvePointer(root, fragment, false, out element);
        }

        /// <summary>
        /// Encodes the ~ encoding in a pointer.
        /// </summary>
        /// <param name="unencodedFragment">The encoded fragment.</param>
        /// <param name="fragment">The span into which to write the result.</param>
        /// <returns>The length of the decoded fragment.</returns>
        internal static int EncodePointer(in ReadOnlySpan<char> unencodedFragment, ref Span<char> fragment)
        {
            int readIndex = 0;
            int writeIndex = 0;

            while (readIndex < unencodedFragment.Length)
            {
                if (unencodedFragment[readIndex] == '~')
                {
                    fragment[writeIndex] = '~';
                    fragment[writeIndex + 1] = '0';
                    readIndex += 1;
                    writeIndex += 2;
                }
                else if (unencodedFragment[readIndex] == '/')
                {
                    fragment[writeIndex] = '~';
                    fragment[writeIndex + 1] = '1';
                    readIndex += 1;
                    writeIndex += 2;
                }
                else
                {
                    fragment[writeIndex] = unencodedFragment[readIndex];
                    readIndex++;
                    writeIndex++;
                }
            }

            return writeIndex;
        }

        /// <summary>
        /// Decodes the hex encoding in a reference.
        /// </summary>
        /// <param name="encodedFragment">The encoded reference.</param>
        /// <param name="fragment">The span into which to write the result.</param>
        /// <returns>The length of the decoded reference.</returns>
        internal static int DecodeHexPointer(ReadOnlySpan<char> encodedFragment, Span<char> fragment)
        {
            int readIndex = 0;
            int writeIndex = 0;

            while (readIndex < encodedFragment.Length)
            {
                if (encodedFragment[readIndex] != '%')
                {
                    fragment[writeIndex] = encodedFragment[readIndex];
                    readIndex++;
                    writeIndex++;
                }
                else
                {
                    int writtenBytes = 0;
                    Span<byte> utf8bytes = stackalloc byte[encodedFragment.Length - readIndex];

                    while (encodedFragment[readIndex] == '%')
                    {
                        if (readIndex >= encodedFragment.Length - 2)
                        {
                            throw new JsonException($"Unexpected end of sequence in escaped %. Expected two digits but found the end of the element: {fragment.ToString()}");
                        }

                        if (int.TryParse(encodedFragment.Slice(readIndex + 1, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int characterCode))
                        {
                            utf8bytes[writtenBytes] = (byte)characterCode;
                            writtenBytes += 1;
                        }
                        else
                        {
                            throw new JsonException($"Unexpected end of sequence in escaped %. Expected two digits but could not parse.");
                        }

                        readIndex += 3;
                    }

                    Encoding.UTF8.GetChars(utf8bytes.Slice(0, writtenBytes), fragment.Slice(writeIndex, writtenBytes));
                    writeIndex += writtenBytes;
                }
            }

            return writeIndex;
        }

        /// <summary>
        /// Decodes the ~ encoding in a reference.
        /// </summary>
        /// <param name="encodedFragment">The encoded reference.</param>
        /// <param name="fragment">The span into which to write the result.</param>
        /// <returns>The length of the decoded reference.</returns>
        internal static int DecodePointer(ReadOnlySpan<char> encodedFragment, Span<char> fragment)
        {
            int readIndex = 0;
            int writeIndex = 0;

            while (readIndex < encodedFragment.Length)
            {
                if (encodedFragment[readIndex] != '~')
                {
                    fragment[writeIndex] = encodedFragment[readIndex];
                    readIndex++;
                    writeIndex++;
                }
                else
                {
                    if (readIndex >= encodedFragment.Length - 1)
                    {
                        throw new JsonException($"Expected to find 0, 1 or 2 after '~' in the component {encodedFragment.ToString()} at index {readIndex}, but found the end of the component.");
                    }

                    if (encodedFragment[readIndex + 1] == '0')
                    {
                        fragment[writeIndex] = '~';
                    }
                    else if (encodedFragment[readIndex + 1] == '1')
                    {
                        fragment[writeIndex] = '/';
                    }
                    else
                    {
                        throw new JsonException($"Expected to find 0, or 2 after '~' in the component {encodedFragment.ToString()} at index {readIndex}, but found {encodedFragment[readIndex + 1]}");
                    }

                    readIndex += 2;
                    writeIndex += 1;
                }
            }

            return writeIndex;
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root eleement from which to start resolving the pointer.</param>
        /// <param name="fragment">The fragment in <c>#/blah/foo/3/bar/baz</c> form.</param>
        /// <param name="throwOnFailure">If true, we throw on failure.</param>
        /// <param name="element">The element found at the given location.</param>
        /// <returns><c>true</c> if the element was found.</returns>
        private static bool TryResolvePointer(JsonElement root, in ReadOnlySpan<char> fragment, bool throwOnFailure, [NotNullWhen(true)] out JsonElement? element)
        {
            JsonElement current = root;
            int index = 0;
            int startRun = 0;
            while (index < fragment.Length)
            {
                if (index == 0 && fragment[index] == '#')
                {
                    ++index;
                }

                if (fragment[index] == '/')
                {
                    ++index;
                }

                startRun = index;

                if (index >= fragment.Length)
                {
                    break;
                }

                while (index < fragment.Length && fragment[index] != '/')
                {
                    ++index;
                }

                // We've either reached the fragment.Length (so have to go 1 back from the end)
                // or we're sitting on the terminating '/'
                int endRun = index;
                ReadOnlySpan<char> encodedComponent = fragment[startRun..endRun];
                Span<char> decodedComponent = stackalloc char[encodedComponent.Length];
                int decodedWritten = DecodePointer(encodedComponent, decodedComponent);
                ReadOnlySpan<char> component = decodedComponent.Slice(0, decodedWritten);
                if (current.ValueKind == JsonValueKind.Object)
                {
                    if (current.TryGetProperty(component, out JsonElement next))
                    {
                        current = next;
                    }
                    else
                    {
                        // We were unable to find the element at that location.
                        if (throwOnFailure)
                        {
                            throw new JsonException($"Unable to find the element at path {fragment[0..endRun].ToString()}.");
                        }
                        else
                        {
                            element = default;
                            return false;
                        }
                    }
                }
                else if (current.ValueKind == JsonValueKind.Array)
                {
                    if (int.TryParse(component, out int targetArrayIndex))
                    {
                        int arrayIndex = 0;
                        JsonElement.ArrayEnumerator enumerator = current.EnumerateArray();
                        while (enumerator.MoveNext() && arrayIndex < targetArrayIndex)
                        {
                            arrayIndex++;
                        }

                        // Check to see if we reached the target, and didn't go off the end of the enumeration.
                        if (arrayIndex == targetArrayIndex && enumerator.Current.ValueKind != JsonValueKind.Undefined)
                        {
                            current = enumerator.Current;
                        }
                        else
                        {
                            // We were unable to find the element at that index in the array.
                            if (throwOnFailure)
                            {
                                throw new JsonException($"Unable to find the array element at path {fragment[0..endRun].ToString()}.");
                            }
                            else
                            {
                                element = default;
                                return false;
                            }
                        }
                    }
                    else
                    {
                        // We couldn't parse the integer of the index
                        if (throwOnFailure)
                        {
                            throw new JsonException($"Expected to find an integer array index at path {fragment[0..endRun].ToString()}, but found {fragment[startRun..endRun].ToString()}.");
                        }
                        else
                        {
                            element = default;
                            return false;
                        }
                    }
                }
            }

            element = current;
            return true;
        }
    }
}
