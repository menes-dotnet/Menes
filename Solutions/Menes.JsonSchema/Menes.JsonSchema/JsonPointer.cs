// <copyright file="JsonPointer.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System;
    using System.Text.Json;

    /// <summary>
    /// Utility function to resolve a json pointer from a json element.
    /// </summary>
    public static class JsonPointer
    {
        private enum PointerState
        {
            ConsumingUntilSlash,
        }

        /// <summary>
        /// Resolve a json pointer from a json document.
        /// </summary>
        /// <param name="root">The root document from which to start resolving the pointer.</param>
        /// <param name="pointer">The pointer in <c>#/blah/foo[3]/bar/baz</c> form.</param>
        /// <returns>The <see cref="JsonElement"/> at that point in the document.</returns>
        public static JsonElement ResolvePointer(JsonDocument root, in ReadOnlySpan<char> pointer)
        {
            return ResolvePointer(root.RootElement, pointer);
        }

        /// <summary>
        /// Resolve a json pointer from a json element.
        /// </summary>
        /// <param name="root">The root element from which to start resolving the pointer.</param>
        /// <param name="pointer">The pointer in <c>#/blah/foo[3]/bar/baz</c> form.</param>
        /// <returns>The <see cref="JsonElement"/> at that point in the document.</returns>
        public static JsonElement ResolvePointer(in JsonElement root, in ReadOnlySpan<char> pointer)
        {
            var stateMachine = new PointerStateMachine() { State = PointerState.ConsumingUntilSlash, CurrentElement = root, StartRunIndex = 0 };

            for (int i = 0; i < pointer.Length; ++i)
            {
                if (stateMachine.State == PointerState.ConsumingUntilSlash)
                {
                    if (i == 0 && pointer[i] == '#')
                    {
                        stateMachine.StartRunIndex = 1;
                        continue;
                    }

                    if (pointer[i] == '/')
                    {
                        if (i > stateMachine.StartRunIndex)
                        {
                            if (stateMachine.CurrentElement.ValueKind == JsonValueKind.Object)
                            {
                                stateMachine.CurrentElement = stateMachine.CurrentElement.GetProperty(pointer[stateMachine.StartRunIndex..i]);
                            }
                            else if (stateMachine.CurrentElement.ValueKind == JsonValueKind.Array)
                            {
                                if (i > stateMachine.StartRunIndex)
                                {
                                    try
                                    {
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
                                                throw new FormatException($"The index in the array at position {i} for pointer {pointer.ToString()} was outside the bounds of the array. Expected '{arrayIndex}' but array length was '{index}'.");
                                            }

                                            stateMachine.CurrentElement = enumerator.Current;
                                            stateMachine.StartRunIndex = i + 1;
                                            stateMachine.State = PointerState.ConsumingUntilSlash;
                                        }
                                        catch (InvalidOperationException ex)
                                        {
                                            throw new FormatException($"Expected the current element to be an array at position {i} for pointer {pointer.ToString()}, but found a '{stateMachine.CurrentElement.ValueKind}'.", ex);
                                        }
                                    }
                                    catch (FormatException ex)
                                    {
                                        throw new FormatException($"Expected to find an array index inside the array indexer at position {i} for pointer {pointer.ToString()}", ex);
                                    }
                                }
                                else
                                {
                                    throw new FormatException($"Expected to find an array index inside the array indexer at position {i} for pointer {pointer.ToString()}");
                                }
                            }

                            stateMachine.StartRunIndex = i + 1;
                        }
                    }
                }
            }

            return stateMachine.CurrentElement;
        }

        private struct PointerStateMachine
        {
            public PointerState State { get; set; }

            public int StartRunIndex { get; set; }

            public JsonElement CurrentElement { get; set; }
        }
    }
}
