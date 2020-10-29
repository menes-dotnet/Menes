// <copyright file="StringFormatter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Microsoft.CodeAnalysis.CSharp;

    /// <summary>
    /// Methods to help format strings.
    /// </summary>
    public static class StringFormatter
    {
        private static readonly ReadOnlyMemory<char> HttpsScheme = "https://".AsMemory();
        private static readonly ReadOnlyMemory<char> HttpScheme = "http://".AsMemory();
        private static readonly ReadOnlyMemory<char> FileScheme = "file://".AsMemory();

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
            return SubstituteReservedWords(result);
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
            return SubstituteReservedWords(result);
        }

        /// <summary>
        /// Formats a fragment as a PascalCased name, and writes it to a <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="fragment">The file or URI fragment to format as a type name.</param>
        /// <param name="builder">The builder to which to write the output.</param>
        public static void FormatFragmentAsFullyQualifiedName(in ReadOnlySpan<char> fragment, StringBuilder builder)
        {
            Span<char> output = stackalloc char[fragment.Length];
            int written = 0;
            written = ProcessFragment(written, output, false, fragment.TrimEnd('/'));
            builder.Append(output.Slice(0, written));
        }

        /// <summary>
        /// Formats a URI as a PascalCased name, and writes it to a <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="fragment">The file or URI fragment to format as a type name.</param>
        /// <param name="builder">The builder to which to write the output.</param>
        public static void FormatUriAsFullyQualifiedName(in ReadOnlySpan<char> fragment, StringBuilder builder)
        {
            Span<char> output = stackalloc char[fragment.Length];

            int lookingForHttpCount = 0;
            int lookingForHttpsCount = 0;
            int lookingForFileCount = 0;
            int start = 0;
            bool isUri = false;

            foreach (char ch in fragment)
            {
                if (lookingForHttpCount >= 0)
                {
                    if (HttpScheme.Span[lookingForHttpCount] == ch)
                    {
                        lookingForHttpCount++;
                    }
                    else
                    {
                        lookingForHttpCount = -1;
                    }
                }

                if (lookingForHttpCount == HttpScheme.Length)
                {
                    start = HttpScheme.Length;
                    isUri = true;
                    break;
                }

                if (lookingForHttpsCount >= 0)
                {
                    if (HttpsScheme.Span[lookingForHttpsCount] == ch)
                    {
                        lookingForHttpsCount++;
                    }
                    else
                    {
                        lookingForHttpsCount = -1;
                    }
                }

                if (lookingForHttpsCount == HttpsScheme.Length)
                {
                    start = HttpsScheme.Length;
                    isUri = true;
                    break;
                }

                if (lookingForFileCount >= 0)
                {
                    if (FileScheme.Span[lookingForFileCount] == ch)
                    {
                        lookingForFileCount++;
                    }
                    else
                    {
                        lookingForFileCount = -1;
                    }
                }

                if (lookingForFileCount == FileScheme.Length)
                {
                    start = FileScheme.Length;
                    isUri = true;
                    break;
                }

                if (lookingForHttpCount == -1 && lookingForHttpsCount == -1 && lookingForFileCount == -1)
                {
                    break;
                }
            }

            int written = 0;

            if (isUri)
            {
                ReadOnlySpan<char> uriFragment = fragment.Slice(start).TrimEnd('/');

                written = ProcessFragment(written, output, isUri, TrimFileExtension(uriFragment));
            }
            else
            {
                ReadOnlySpan<char> directory = Path.GetDirectoryName(fragment.Slice(Path.GetPathRoot(fragment).Length));

                if (directory.Length > 0)
                {
                    written = ProcessFragment(written, output, false, directory);
                }

                ReadOnlySpan<char> fileWithoutExtension = Path.GetFileNameWithoutExtension(fragment);

                if (written > 0)
                {
                    output[written] = '.';
                    written++;
                }

                if (fileWithoutExtension.Length > 0)
                {
                    written = ProcessFragment(written, output, false, fileWithoutExtension);
                }
            }

            builder.Append(output.Slice(0, written));
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

        private static int ProcessFragment(int written, Span<char> output, bool isUri, ReadOnlySpan<char> fragment)
        {
            bool skippingPort = isUri;
            bool ignoreUntilPortSkipped = false;
            bool capitalizeNext = true;
            int uppercasedCount = 0;

            foreach (char c in fragment)
            {
                if (skippingPort && c == ':')
                {
                    ignoreUntilPortSkipped = true;
                }
                else if (ignoreUntilPortSkipped)
                {
                    if (c == '/')
                    {
                        skippingPort = false;
                        ignoreUntilPortSkipped = false;
                        capitalizeNext = true;
                        if (written > 0 && output[written - 1] != '.')
                        {
                            output[written] = '.';
                            written++;
                        }
                    }
                }
                else if (c == '/' || c == '.' || c == '\\')
                {
                    if (written > 0 && output[written - 1] != '.')
                    {
                        output[written] = '.';
                        written++;
                    }

                    capitalizeNext = true;
                    uppercasedCount = 0;
                }
                else if (char.IsLetter(c))
                {
                    if (capitalizeNext)
                    {
                        output[written] = char.ToUpperInvariant(c);
                        uppercasedCount += 1;
                        capitalizeNext = false;
                    }
                    else if (char.ToUpperInvariant(c) == c)
                    {
                        uppercasedCount += 1;
                        if (uppercasedCount > 2)
                        {
                            output[written] = char.ToLowerInvariant(c);
                            uppercasedCount = 0;
                        }
                        else
                        {
                            output[written] = c;
                        }
                    }
                    else
                    {
                        uppercasedCount = 0;
                        output[written] = c;
                    }

                    written++;
                }
                else if (char.IsDigit(c))
                {
                    output[written] = c;

                    // We capitalize the next character we find after a run of digits
                    capitalizeNext = true;
                    written++;
                }
                else
                {
                    // Don't increment the set index; we just skip this non-letter-or-digit character
                    // but start a new word, if we have already written a character.
                    // (If we haven't then capitalizeNext will remain set)
                    if (written > 0)
                    {
                        capitalizeNext = true;
                    }
                }
            }

            return written;
        }

        private static string SubstituteReservedWords(ReadOnlySpan<char> v)
        {
            foreach (ReadOnlyMemory<char> k in Keywords)
            {
                if (k.Span.SequenceEqual(v))
                {
                    Span<char> buffer = stackalloc char[v.Length + 1];
                    buffer[0] = '@';
                    v.CopyTo(buffer.Slice(1));
                    return new string(buffer);
                }
            }

            return new string(v);
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
