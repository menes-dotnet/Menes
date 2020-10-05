// <copyright file="NameFormatter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;

    /// <summary>
    /// Methods to help format names.
    /// </summary>
    public static class NameFormatter
    {
        /// <summary>
        /// Convert the given name to <c>camelCase</c>.
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>The name in <c>camelCase</c>.</returns>
        public static string ToCamelCase(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            // We could possibly do a better job here by using the "in place" access to the underlying
            // string data; however, we'd still end up with a single buffer copy of at least the length
            // of the string data, so I think this is a "reasonable" approach.
            ReadOnlySpan<char> result = FixCasing(name.ToCharArray(), false);
            return new string(result);
        }

        /// <summary>
        /// Convert the given name to <c>PascalCase</c>.
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>The name in <c>PascalCase</c>.</returns>
        public static string ToPascalCase(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            // We could possibly do a better job here by using the "in place" access to the underlying
            // string data; however, we'd still end up with a single buffer copy of at least the length
            // of the string data, so I think this is a "reasonable" approach.
            ReadOnlySpan<char> result = FixCasing(name.ToCharArray(), true);
            return new string(result);
        }

        private static ReadOnlySpan<char> FixCasing(Span<char> chars, bool capitalizeFirst)
        {
            int setIndex = 0;
            bool capitalizeNext = capitalizeFirst;

            for (int readIndex = 0; readIndex < chars.Length; readIndex++)
            {
                if (char.IsLetter(chars[readIndex]))
                {
                    if (capitalizeNext)
                    {
                        chars[setIndex] = char.ToUpperInvariant(chars[readIndex]);
                    }
                    else
                    {
                        chars[setIndex] = char.ToLowerInvariant(chars[readIndex]);
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
