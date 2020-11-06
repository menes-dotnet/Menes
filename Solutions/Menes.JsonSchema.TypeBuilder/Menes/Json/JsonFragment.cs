// <copyright file="JsonFragment.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Buffers;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// Utility function to resolve the JsonElement referenced by a json fragment pointer into a json element.
    /// </summary>
    /// <remarks>
    /// Note that we don't support <c>$anchor</c> or <c>$id</c> with this implementation.
    /// </remarks>
    public static class JsonFragment
    {
        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root document from which to start resolving the pointer.</param>
        /// <param name="pointer">The pointer in <c>#/blah/foo[3]/bar/baz</c> form.</param>
        /// <param name="element">The element found at the given location.</param>
        /// <returns><c>true</c> if the element was found.</returns>
        public static bool TryResolveFragment(JsonDocument root, in ReadOnlySpan<char> pointer, [NotNullWhen(true)] out JsonElement? element)
        {
            return TryResolveFragment(root.RootElement, pointer, out element);
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root document from which to start resolving the pointer.</param>
        /// <param name="pointer">The pointer in <c>#/blah/foo[3]/bar/baz</c> form.</param>
        /// <param name="element">The element found at the given location.</param>
        /// <returns><c>true</c> if the element was found.</returns>
        public static bool TryResolveFragment(in JsonElement root, in ReadOnlySpan<char> pointer, [NotNullWhen(true)] out JsonElement? element)
        {
            (JsonElement result, string? error) = ResolvePointerCore(root, pointer);
            if (error is string)
            {
                element = default;
                return false;
            }

            element = result;
            return true;
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root document from which to start resolving the pointer.</param>
        /// <param name="pointer">The pointer in <c>#/blah/foo[3]/bar/baz</c> form.</param>
        /// <returns>The <see cref="JsonElement"/> at that point in the document.</returns>
        public static JsonElement ResolveFragment(JsonDocument root, in ReadOnlySpan<char> pointer)
        {
            return ResolvePointer(root.RootElement, pointer);
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root document from which to start resolving the pointer.</param>
        /// <param name="pointer">The pointer in <c>#/blah/foo[3]/bar/baz</c> form.</param>
        /// <returns>The <see cref="JsonElement"/> at that point in the document.</returns>
        public static JsonElement ResolvePointer(in JsonElement root, in ReadOnlySpan<char> pointer)
        {
            (JsonElement result, string? error) = ResolvePointerCore(root, pointer);
            if (error is string)
            {
                throw new InvalidOperationException(error);
            }

            return result;
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root document from which to start resolving the pointer.</param>
        /// <param name="pointer">The pointer in <c>#/blah/foo[3]/bar/baz</c> form.</param>
        /// <returns>The <see cref="JsonElement"/> at that point in the document.</returns>
        private static (JsonElement, string?) ResolvePointerCore(JsonDocument root, in ReadOnlySpan<char> pointer)
        {
            return ResolvePointerCore(root.RootElement, pointer);
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root element from which to start resolving the pointer.</param>
        /// <param name="pointer">The pointer in <c>#/blah/foo[3]/bar/baz</c> form.</param>
        /// <returns>The <see cref="JsonElement"/> at that point in the document.</returns>
        private static (JsonElement, string?) ResolvePointerCore(in JsonElement root, in ReadOnlySpan<char> pointer)
        {
            var stateMachine = new ResolutionState() { CurrentElement = root, StartRunIndex = 0 };

            for (int i = 0; i < pointer.Length; ++i)
            {
                if (i == 0 && pointer[i] == '#')
                {
                    stateMachine.StartRunIndex = 1;
                    continue;
                }

                if (pointer[i] == '~')
                {
                    // Skip over the next character is we have escaped
                    i += 1;
                }
                else if (pointer[i] == '/')
                {
                    if (i > stateMachine.StartRunIndex)
                    {
                        if (stateMachine.CurrentElement.ValueKind == JsonValueKind.Object)
                        {
                            stateMachine = GetPropertyFromEscapedValue(pointer, stateMachine, i);
                        }
                        else if (stateMachine.CurrentElement.ValueKind == JsonValueKind.Array)
                        {
                            if (i > stateMachine.StartRunIndex)
                            {
                                try
                                {
                                    while (pointer[stateMachine.StartRunIndex] == '/')
                                    {
                                        stateMachine.StartRunIndex += 1;
                                    }

                                    int arrayIndex = int.Parse(pointer[stateMachine.StartRunIndex..i]);
                                    try
                                    {
                                        JsonElement.ArrayEnumerator enumerator = stateMachine.CurrentElement.EnumerateArray();
                                        int index = 0;
                                        while (enumerator.MoveNext() && index < arrayIndex)
                                        {
                                            ++index;
                                        }

                                        if (index != arrayIndex)
                                        {
                                            return (default, $"The index in the array at position {stateMachine.StartRunIndex} for pointer {pointer.ToString()} was outside the bounds of the array. Expected '{arrayIndex}' but array length was '{index}'.Text was: '{pointer[stateMachine.StartRunIndex..i].ToString()}'");
                                        }

                                        stateMachine.CurrentElement = enumerator.Current;
                                        stateMachine.StartRunIndex = i + 1;
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        return (default, $"Expected the current element to be an array at position {stateMachine.StartRunIndex} for pointer {pointer.ToString()}, but found a '{stateMachine.CurrentElement.ValueKind}'. Text was: '{pointer[stateMachine.StartRunIndex..i].ToString()}'");
                                    }
                                }
                                catch (FormatException)
                                {
                                    return (default, $"Expected to find an array index inside the array indexer at position {stateMachine.StartRunIndex} for pointer {pointer.ToString()}. Text was: '{pointer[stateMachine.StartRunIndex..i].ToString()}'");
                                }
                            }
                            else
                            {
                                return (default, $"Expected to find an array index inside the array indexer at position {stateMachine.StartRunIndex} for pointer {pointer.ToString()}. Text was: '{pointer[stateMachine.StartRunIndex..i].ToString()}'");
                            }
                        }

                        stateMachine.StartRunIndex = i + 1;
                    }
                }
            }

            if (stateMachine.StartRunIndex < pointer.Length)
            {
                if (stateMachine.CurrentElement.ValueKind == JsonValueKind.Object)
                {
                    stateMachine = GetPropertyFromEscapedValue(pointer, stateMachine, pointer.Length);
                }
                else if (stateMachine.CurrentElement.ValueKind == JsonValueKind.Array)
                {
                    int arrayIndex = int.Parse(pointer.Slice(stateMachine.StartRunIndex));
                    try
                    {
                        JsonElement.ArrayEnumerator enumerator = stateMachine.CurrentElement.EnumerateArray();
                        int index = 0;
                        while (enumerator.MoveNext() && index < arrayIndex)
                        {
                            ++index;
                        }

                        if (index != arrayIndex)
                        {
                            return (default, $"The index in the array at position {stateMachine.StartRunIndex} for pointer {pointer.ToString()} was outside the bounds of the array. Expected '{arrayIndex}' but array length was '{index}'.");
                        }

                        stateMachine.CurrentElement = enumerator.Current;
                    }
                    catch (InvalidOperationException)
                    {
                        return (default, $"Expected the current element to be an array at position {stateMachine.StartRunIndex} for pointer {pointer.ToString()}, but found a '{stateMachine.CurrentElement.ValueKind}'. Text was: '{pointer.Slice(stateMachine.StartRunIndex).ToString()}'");
                    }
                }
            }

            return (stateMachine.CurrentElement, null);
        }

        private static ResolutionState GetPropertyFromEscapedValue(ReadOnlySpan<char> pointer, ResolutionState stateMachine, int i)
        {
            int writtenCount = 0;
            char[] unescaped = ArrayPool<char>.Shared.Rent(i - stateMachine.StartRunIndex);
            try
            {
                for (int e = stateMachine.StartRunIndex; e < i; ++e)
                {
                    if (pointer[e] == '%')
                    {
                        int writtenBytes = 0;
                        Span<byte> utf8bytes = stackalloc byte[i - e];

                        while (pointer[e] == '%')
                        {
                            if (e >= i - 2)
                            {
                                throw new JsonException($"Unexpected end of sequence in escaped %. Expected two digits but found the end of the element.");
                            }

                            if (int.TryParse(pointer.Slice(e + 1, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int characterCode))
                            {
                                utf8bytes[writtenBytes] = (byte)characterCode;
                                writtenBytes += 1;
                            }
                            else
                            {
                                throw new JsonException($"Unexpected end of sequence in escaped %. Expected two digits but could not parse.");
                            }

                            e += 3;
                        }

                        Encoding.UTF8.GetChars(utf8bytes.Slice(0, writtenBytes), unescaped.AsSpan(writtenCount));

                        // We're going to add it on again in a second when we go around the loop
                        e -= 1;
                        writtenCount += writtenBytes;
                    }
                    else if (pointer[e] == '~')
                    {
                        if (e >= i - 1)
                        {
                            throw new JsonException($"Unexpected end of sequence in escape character. Expected '0' or '1' but found the end of the element.");
                        }

                        if (pointer[e + 1] == '0')
                        {
                            unescaped[writtenCount] = '~';
                        }
                        else if (pointer[e + 1] == '1')
                        {
                            unescaped[writtenCount] = '/';
                        }
                        else
                        {
                            throw new JsonException($"Unexpected escape character. Expected '0' or '1' but found '{pointer[e + 1]}'");
                        }

                        e += 1;
                        writtenCount++;
                    }
                    else
                    {
                        unescaped[writtenCount] = pointer[e];
                        writtenCount++;
                    }
                }

                int offset = 0;

                while (unescaped[offset] == '/')
                {
                    offset += 1;
                }

                stateMachine.CurrentElement = stateMachine.CurrentElement.GetProperty(unescaped.AsSpan()[offset..writtenCount]);
            }
            finally
            {
                ArrayPool<char>.Shared.Return(unescaped);
            }

            return stateMachine;
        }

        private struct ResolutionState
        {
            public int StartRunIndex { get; set; }

            public JsonElement CurrentElement { get; set; }
        }
    }
}
