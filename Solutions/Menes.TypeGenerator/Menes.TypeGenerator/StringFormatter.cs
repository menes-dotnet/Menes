// <copyright file="StringFormatter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp;

    /// <summary>
    /// Methods to help format strings.
    /// </summary>
    public static class StringFormatter
    {
        private static readonly string[] Keywords = new string[]
        {
            "abstract", "as", "base", "bool",
            "break", "byte", "case", "catch",
            "char", "checked", "class", "const",
            "continue", "decimal", "default", "delegate",
            "do", "double", "else", "enum",
            "event", "explicit", "extern", "false",
            "finally", "fixed", "float", "for",
            "foreach", "goto", "if", "implicit",
            "in", "int", "interface", "internal",
            "is", "lock", "long", "namespace",
            "new", "null", "object", "operator",
            "out", "override", "params", "private",
            "protected", "public", "readonly", "ref",
            "return", "sbyte", "sealed", "short",
            "sizeof", "stackalloc", "static", "string",
            "struct", "switch", "this", "throw",
            "true", "try", "typeof", "uint",
            "ulong", "unchecked", "unsafe", "ushort",
            "using", "virtual", "void", "volatile",
            "while",
        };

        /// <summary>
        /// Convert the given name to <c>camelCase</c>.
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>The name in <c>camelCase</c>.</returns>
        public static string ToCamelCaseWithReservedWords(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            // We could possibly do a better job here by using the "in place" access to the underlying
            // string data; however, we'd still end up with a single buffer copy of at least the length
            // of the string data, so I think this is a "reasonable" approach.
            ReadOnlySpan<char> result = FixCasing(name.ToCharArray(), false, true);
            return SubstituteReservedWords(new string(result));
        }

        /// <summary>
        /// Convert the given name to <c>PascalCase</c>.
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>The name in <c>PascalCase</c>.</returns>
        public static string ToPascalCaseWithReservedWords(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            // We could possibly do a better job here by using the "in place" access to the underlying
            // string data; however, we'd still end up with a single buffer copy of at least the length
            // of the string data, so I think this is a "reasonable" approach.
            ReadOnlySpan<char> result = FixCasing(name.ToCharArray(), true, false);
            return SubstituteReservedWords(new string(result));
        }

        /// <summary>
        /// Escapes a value for embeddeding into a quoted C# string.
        /// </summary>
        /// <param name="value">The value to escape.</param>
        /// <param name="quote">Whether to quote the string.</param>
        /// <returns>The escaped value. This can be inserted into a regular quoted C# string.</returns>
        public static string? EscapeForCSharpString(string? value, bool quote)
        {
            // TODO: actually implement this. Someone must have done so already
            return value is null ? null : SymbolDisplay.FormatLiteral(value, quote);
        }

        private static string SubstituteReservedWords(string v)
        {
            if (Keywords.Contains(v))
            {
                return "@" + v;
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
