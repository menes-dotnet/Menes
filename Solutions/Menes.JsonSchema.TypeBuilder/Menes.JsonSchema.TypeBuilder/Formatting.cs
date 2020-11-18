﻿// <copyright file="Formatting.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Menes.Json;
    using Microsoft.CodeAnalysis.CSharp;

    /// <summary>
    /// Formatting utilities.
    /// </summary>
    internal static class Formatting
    {
        private static readonly ReadOnlyMemory<char> HttpsScheme = "https://".AsMemory();
        private static readonly ReadOnlyMemory<char> HttpScheme = "http://".AsMemory();
        private static readonly ReadOnlyMemory<char> FileScheme = "file://".AsMemory();
        private static readonly ReadOnlyMemory<char> Value = "Value".AsMemory();
        private static readonly ReadOnlyMemory<char> Item = "Item".AsMemory();
        private static readonly ReadOnlyMemory<char> Root = "RootEntity".AsMemory();

        private static readonly ReadOnlyMemory<char>[] Keywords = new ReadOnlyMemory<char>[]
        {
            "abstract".AsMemory(), "as".AsMemory(), "base".AsMemory(), "bool".AsMemory(),
            "break".AsMemory(), "byte".AsMemory(), "case".AsMemory(), "catch".AsMemory(),
            "char".AsMemory(), "checked".AsMemory(), "class".AsMemory(), "const".AsMemory(),
            "continue".AsMemory(), "decimal".AsMemory(), "default".AsMemory(), "delegate".AsMemory(),
            "do".AsMemory(), "double".AsMemory(), "else".AsMemory(), "enum".AsMemory(),
            "event".AsMemory(), "explicit".AsMemory(), "extern".AsMemory(), "false".AsMemory(),
            "finally".AsMemory(), "fixed".AsMemory(), "float".AsMemory(), "for".AsMemory(),
            "foreach".AsMemory(), "goto".AsMemory(), "if".AsMemory(), "implicit".AsMemory(),
            "in".AsMemory(), "int".AsMemory(), "interface".AsMemory(), "internal".AsMemory(),
            "is".AsMemory(), "lock".AsMemory(), "long".AsMemory(), "namespace".AsMemory(),
            "new".AsMemory(), "null".AsMemory(), "object".AsMemory(), "operator".AsMemory(),
            "out".AsMemory(), "override".AsMemory(), "params".AsMemory(), "private".AsMemory(),
            "protected".AsMemory(), "public".AsMemory(), "readonly".AsMemory(), "ref".AsMemory(),
            "return".AsMemory(), "sbyte".AsMemory(), "sealed".AsMemory(), "short".AsMemory(),
            "sizeof".AsMemory(), "stackalloc".AsMemory(), "static".AsMemory(), "string".AsMemory(),
            "struct".AsMemory(), "switch".AsMemory(), "this".AsMemory(), "throw".AsMemory(),
            "true".AsMemory(), "try".AsMemory(), "typeof".AsMemory(), "uint".AsMemory(),
            "ulong".AsMemory(), "unchecked".AsMemory(), "unsafe".AsMemory(), "ushort".AsMemory(),
            "using".AsMemory(), "virtual".AsMemory(), "void".AsMemory(), "volatile".AsMemory(),
            "while".AsMemory(),
        };

        /// <summary>
        /// Escapes a value for embeddeding into a quoted C# string.
        /// </summary>
        /// <param name="value">The value to escape.</param>
        /// <param name="quote">Whether to quote the string.</param>
        /// <returns>The escaped value. This can be inserted into a regular quoted C# string.</returns>
        [return: NotNullIfNotNull("value")]
        public static string? FormatLiteralOrNull(string? value, bool quote)
        {
            return value is null ? null : SymbolDisplay.FormatLiteral(value, quote);
        }

        /// <summary>
        /// Convert the given name to <c>camelCase</c>.
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>The name in <c>camelCase</c>.</returns>
        public static ReadOnlySpan<char> ToCamelCaseWithReservedWords(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            // We could possibly do a better job here by using the "in place" access to the underlying
            // string data; however, we'd still end up with a single buffer copy of at least the length
            // of the string data, so I think this is a "reasonable" approach.
            ReadOnlySpan<char> result = FixCasing(name.ToCharArray(), false, true);
            return SubstituteReservedWords(result);
        }

        /// <summary>
        /// Convert the given name to <c>PascalCase</c>.
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>The name in <c>PascalCase</c>.</returns>
        public static ReadOnlySpan<char> ToPascalCaseWithReservedWords(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            // We could possibly do a better job here by using the "in place" access to the underlying
            // string data; however, we'd still end up with a single buffer copy of at least the length
            // of the string data, so I think this is a "reasonable" approach.
            ReadOnlySpan<char> result = FixCasing(name.ToCharArray(), true, false);
            return SubstituteReservedWords(result);
        }

        /// <summary>
        /// Formats a reference as a PascalCased name />.
        /// </summary>
        /// <param name="reference">The reference to format.</param>
        /// <returns>The reference formateted as a name.</returns>
        public static ReadOnlyMemory<char> FormatReferenceAsName(JsonReference reference)
        {
            JsonReferenceBuilder refBuilder = reference.AsBuilder();

            if (refBuilder.HasFragment)
            {
                int startCopy = 0;
                int lastSlash = 0;
                lastSlash = refBuilder.Fragment.LastIndexOf('/');
                if (lastSlash > 0)
                {
                    if (char.IsDigit(refBuilder.Fragment[lastSlash + 1]))
                    {
                        startCopy = refBuilder.Fragment.Slice(0, lastSlash).LastIndexOf('/');
                    }
                    else
                    {
                        startCopy = lastSlash;
                    }
                }

                Span<char> output = stackalloc char[refBuilder.Fragment.Length - startCopy];
                refBuilder.Fragment[startCopy..].CopyTo(output);
                ReadOnlySpan<char> result = FixCasing(output, true, false);
                if (result.Length == 0)
                {
                    return Root;
                }

                var memory = new Memory<char>(new char[result.Length]);
                result.CopyTo(memory.Span);
                return memory;
            }
            else if (refBuilder.HasPath)
            {
                ReadOnlySpan<char> trimmedSpan = TrimFileExtension(refBuilder.Path);
                Span<char> output = stackalloc char[trimmedSpan.Length];
                trimmedSpan.CopyTo(output);
                ReadOnlySpan<char> result = FixCasing(output, true, false);
                if (result.Length == 0)
                {
                    return Root;
                }

                var memory = new Memory<char>(new char[result.Length]);
                result.CopyTo(memory.Span);
                return memory;
            }
            else
            {
                return Root;
            }
        }

        private static ReadOnlySpan<char> TrimFileExtension(ReadOnlySpan<char> uriFragment)
        {
            int lastDot = -1;

            // Don't need to check the last character or the first character
            // ('.blah' and 'blah.' will translate fine)
            for (int i = uriFragment.Length - 2; i > 0; --i)
            {
                if (uriFragment[i] == '/')
                {
                    break;
                }

                if (uriFragment[i] == '.')
                {
                    lastDot = i;
                    break;
                }
            }

            if (lastDot == -1)
            {
                return uriFragment;
            }

            return uriFragment.Slice(0, lastDot);
        }

        private static ReadOnlySpan<char> SubstituteReservedWords(ReadOnlySpan<char> v)
        {
            foreach (ReadOnlyMemory<char> k in Keywords)
            {
                if (k.Span.SequenceEqual(v))
                {
                    Span<char> buffer = new char[v.Length + 1];
                    buffer[0] = '@';
                    v.CopyTo(buffer[1..]);
                    return buffer;
                }
            }

            if (v.Length == 0)
            {
                return v;
            }

            if (char.IsDigit(v[0]))
            {
                Span<char> buffer2 = new char[v.Length + 5];
                Value.Span.CopyTo(buffer2);
                v.CopyTo(buffer2[5..]);
                return buffer2;
            }

            return v;
        }

        private static ReadOnlySpan<char> FixCasing(Span<char> chars, bool capitalizeFirst, bool lowerCaseFirst)
        {
            int setIndex = 0;
            bool capitalizeNext = capitalizeFirst;
            bool lowercaseNext = lowerCaseFirst;
            int uppercasedCount = 0;

            for (int readIndex = 0; readIndex < chars.Length; readIndex++)
            {
                if (char.IsLetter(chars[readIndex]))
                {
                    if (capitalizeNext)
                    {
                        chars[setIndex] = char.ToUpperInvariant(chars[readIndex]);
                        uppercasedCount += 1;
                    }
                    else if (lowercaseNext)
                    {
                        chars[setIndex] = char.ToLowerInvariant(chars[readIndex]);
                        uppercasedCount = 0;
                        lowercaseNext = false;
                    }
                    else
                    {
                        if (char.ToUpperInvariant(chars[readIndex]) == chars[readIndex])
                        {
                            uppercasedCount += 1;
                            if (uppercasedCount > 2)
                            {
                                chars[setIndex] = char.ToLowerInvariant(chars[readIndex]);
                                uppercasedCount = 0;
                                continue;
                            }
                        }
                        else
                        {
                            uppercasedCount = 0;
                        }

                        chars[setIndex] = chars[readIndex];
                    }

                    capitalizeNext = false;
                    setIndex++;
                }
                else if (char.IsDigit(chars[readIndex]))
                {
                    chars[setIndex] = chars[readIndex];

                    // We capitalize the next character we find after a run of digits
                    capitalizeNext = true;
                    setIndex++;
                }
                else
                {
                    // Don't increment the set index; we just skip this non-letter-or-digit character
                    // but start a new word, if we have already written a character.
                    // (If we haven't then capitalizeNext will remain set according to our capitalizeFirst request.)
                    if (setIndex > 0)
                    {
                        capitalizeNext = true;
                    }
                }
            }

            return chars.Slice(0, setIndex);
        }
    }
}
