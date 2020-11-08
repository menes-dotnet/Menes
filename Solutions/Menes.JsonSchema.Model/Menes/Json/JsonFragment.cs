// <copyright file="JsonFragment.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Diagnostics.CodeAnalysis;
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
        /// <param name="fragment">The fragment in <c>#/blah/foo/3/bar/baz</c> form.</param>
        /// <returns><c>true</c> if the element was found.</returns>
        public static JsonElement ResolveFragment(JsonDocument root, in ReadOnlySpan<char> fragment)
        {
            if (TryResolveFragment(root.RootElement, fragment, true, out JsonElement? element))
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
        public static JsonElement ResolveFragment(JsonElement root, in ReadOnlySpan<char> fragment)
        {
            if (TryResolveFragment(root, fragment, true, out JsonElement? element))
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
        public static bool TryResolveFragment(JsonDocument root, in ReadOnlySpan<char> fragment, [NotNullWhen(true)] out JsonElement? element)
        {
            return TryResolveFragment(root.RootElement, fragment, false, out element);
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root eleement from which to start resolving the pointer.</param>
        /// <param name="fragment">The fragment in <c>#/blah/foo/3/bar/baz</c> form.</param>
        /// <param name="element">The element found at the given location.</param>
        /// <returns><c>true</c> if the element was found.</returns>
        public static bool TryResolveFragment(JsonElement root, in ReadOnlySpan<char> fragment, [NotNullWhen(true)] out JsonElement? element)
        {
            return TryResolveFragment(root, fragment, false, out element);
        }

        /// <summary>
        /// Resolve a json element from a fragment pointer into a json document.
        /// </summary>
        /// <param name="root">The root eleement from which to start resolving the pointer.</param>
        /// <param name="fragment">The fragment in <c>#/blah/foo/3/bar/baz</c> form.</param>
        /// <param name="throwOnFailure">If true, we throw on failure.</param>
        /// <param name="element">The element found at the given location.</param>
        /// <returns><c>true</c> if the element was found.</returns>
        private static bool TryResolveFragment(JsonElement root, in ReadOnlySpan<char> fragment, bool throwOnFailure, [NotNullWhen(true)] out JsonElement? element)
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
                ReadOnlySpan<char> component = fragment[startRun..endRun];

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
