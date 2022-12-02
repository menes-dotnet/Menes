// <copyright file="Parsing.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Corvus.Json;
using Corvus.UriTemplates;

namespace Menes.HttpHelpers;

/// <summary>
/// Utility functions to help with formatting values.
/// </summary>
public static class Parsing
{
    private static readonly IUriTemplateParser FormTypeExpansion = UriTemplateParserFactory.CreateParser("{?value}");
    private static readonly IUriTemplateParser ExplodedFormTypeExpansion = UriTemplateParserFactory.CreateParser("{?value*}");

    /// <summary>
    /// Parse the value as a simple-style value.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static T ParseSimpleStyleValue<T>(string value)
        where T : struct, IJsonValue<T>
    {
        return ParseSimpleStyleValue<T>(value.AsSpan());
    }

    /// <summary>
    /// Parse the value as a simple-style value.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static T ParseSimpleStyleValue<T>(ReadOnlySpan<char> value)
        where T : struct, IJsonValue<T>
    {
        Span<byte> buffer = stackalloc byte[Encoding.UTF8.GetMaxByteCount(value.Length)];
        int written = Encoding.UTF8.GetBytes(value, buffer);
        var reader = new Utf8JsonReader(buffer[..written]);
        try
        {
            if (JsonElement.TryParseValue(ref reader, out JsonElement? element))
            {
                return T.FromJson(element.Value);
            }
        }
        catch
        {
            // Maybe log that it wasn't a non-string value?
        }

        return T.FromString(new JsonString(value));
    }

    /// <summary>
    /// Parse the value as a form-style value.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static T ParseFormStyleValue<T>(string value)
        where T : struct, IJsonValue<T>
    {
        Span<byte> buffer = stackalloc byte[Encoding.UTF8.GetMaxByteCount(value.Length)];
        int written = Encoding.UTF8.GetBytes(value, buffer);
        var reader = new Utf8JsonReader(buffer[..written]);
        try
        {
            if (JsonElement.TryParseValue(ref reader, out JsonElement? element))
            {
                return T.FromJson(element.Value);
            }
        }
        catch
        {
            // Maybe log that it wasn't a non-string value?
        }

        return T.FromString(new JsonString(value));
    }

    /// <summary>
    /// Parse the value as a form-style value.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static T ParseFormStyleValue<T>(ReadOnlySpan<char> value)
        where T : struct, IJsonValue<T>
    {
        T result = T.Undefined;
        if (FormTypeExpansion.EnumerateParameters(value, ParseSimpleParameter, ref result, initialCapacity: 1))
        {
            return result;
        }

        throw new InvalidOperationException("Unable to parse the value.");
    }

    /// <summary>
    /// Parse the value as an exploded form-style value.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static T ParseExplodedFormStyleValue<T>(string value)
        where T : struct, IJsonValue<T>
    {
        return ParseExplodedFormStyleValue<T>(value.AsSpan());
    }

    /// <summary>
    /// Parse the value as an exploded form-style value.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static T ParseExplodedFormStyleValue<T>(ReadOnlySpan<char> value)
        where T : struct, IJsonValue<T>
    {
        T result = T.Undefined;
        if (ExplodedFormTypeExpansion.EnumerateParameters(value, ParseSimpleParameter, ref result, initialCapacity: 1))
        {
            return result;
        }

        throw new InvalidOperationException("Unable to parse the value.");
    }

    /// <summary>
    /// Parse the value as a pipe-delimited style value.
    /// </summary>
    /// <typeparam name="T">The type of the value to produce.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static T ParsePipeDelimitedObjectStyleValue<T>(string value)
        where T : struct, IJsonValue<T>
    {
        return ParseDelimitedObjectStyleValue<T>(value.AsSpan(), "|");
    }

    /// <summary>
    /// Parse the value as a pipe-delimited array style value.
    /// </summary>
    /// <typeparam name="T">The type of the value to produce.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static T ParsePipeDelimitedArrayStyleValue<T>(string value)
        where T : struct, IJsonValue<T>
    {
        return ParseDelimitedArrayStyleValue<T>(value.AsSpan(), "|");
    }

    /// <summary>
    /// Parse the value as a pipe-delimited style value.
    /// </summary>
    /// <typeparam name="T">The type of the value to produce.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static T ParseSpaceDelimitedObjectStyleValue<T>(string value)
        where T : struct, IJsonValue<T>
    {
        return ParseDelimitedObjectStyleValue<T>(value.AsSpan(), "%32");
    }

    /// <summary>
    /// Parse the value as a pipe-delimited array style value.
    /// </summary>
    /// <typeparam name="T">The type of the value to produce.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static T ParseSpaceDelimitedArrayStyleValue<T>(string value)
        where T : struct, IJsonValue<T>
    {
        return ParseDelimitedArrayStyleValue<T>(value.AsSpan(), "%32");
    }

    /// <summary>
    /// Parse the value as a pipe-delimited style value.
    /// </summary>
    /// <typeparam name="T">The type of the value to produce.</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The parsed value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    private static T ParseDelimitedObjectStyleValue<T>(ReadOnlySpan<char> value, ReadOnlySpan<char> delimiter)
        where T : struct, IJsonValue<T>
    {
        ImmutableDictionary<JsonPropertyName, JsonAny>.Builder properties = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();

        int index = 0;
        int start = 0;
        bool lookingForName = true;

        int nameStart = 0;
        int nameLength = 0;

        int delimiterLength = delimiter.Length;
        if (delimiterLength == 1)
        {
            char delimiterChar = delimiter[0];
            while (index < value.Length)
            {
                if (SequenceMatch(value, index, delimiterChar))
                {
                    HandleMatch(value, properties, index, ref start, ref lookingForName, ref nameStart, ref nameLength, delimiterLength);
                }

                ++index;
            }
        }
        else
        {
            while (index < (value.Length - delimiterLength) + 1)
            {
                if (SequenceMatch(value, index, delimiter))
                {
                    HandleMatch(value, properties, index, ref start, ref lookingForName, ref nameStart, ref nameLength, delimiterLength);
                }

                ++index;
            }
        }

        // One more to add
        if (!lookingForName)
        {
            string propertyName = value[nameStart..nameLength].ToString();
            properties.Add(propertyName, ParseSimpleStyleValue<JsonAny>(value[start..(index - start)]));
        }

        return JsonAny.FromProperties(properties.ToImmutable()).As<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void HandleMatch(ReadOnlySpan<char> value, ImmutableDictionary<JsonPropertyName, JsonAny>.Builder properties, int index, ref int start, ref bool lookingForName, ref int nameStart, ref int nameLength, int delimiterLength)
        {
            if (lookingForName)
            {
                // We've found the end of the name
                lookingForName = false;
                nameStart = start;
                nameLength = index - start;
                start = index + delimiterLength;
            }
            else
            {
                // We've found the end of the value
                lookingForName = true;
                string propertyName = value[nameStart..nameLength].ToString();
                properties.Add(propertyName, ParseSimpleStyleValue<JsonAny>(value[start..(index - start)]));
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool SequenceMatch(ReadOnlySpan<char> value, int index, char delimiter)
    {
        return value[index] == delimiter;
    }

    private static bool SequenceMatch(ReadOnlySpan<char> value, int index, ReadOnlySpan<char> delimiter)
    {
        return value[index..].SequenceEqual(delimiter);
    }

    private static void ParseSimpleParameter<T>(ReadOnlySpan<char> name, ReadOnlySpan<char> value, ref T state)
    where T : struct, IJsonValue<T>
    {
        if (!name.SequenceEqual("value"))
        {
            throw new InvalidOperationException($"Unexpected parameter: '{name}'");
        }

        state = ParseSimpleStyleValue<T>(value);
    }

    /// <summary>
    /// Parse the value as a pipe-delimited style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    private static T ParseDelimitedArrayStyleValue<T>(ReadOnlySpan<char> value, string delimiter)
        where T : struct, IJsonValue<T>
    {
        ImmutableList<JsonAny>.Builder properties = ImmutableList.CreateBuilder<JsonAny>();

        int index = 0;
        int start = 0;

        int delimiterLength = delimiter.Length;

        if (delimiterLength == 1)
        {
            char delimiterChar = delimiter[0];
            while (index < value.Length)
            {
                if (SequenceMatch(value, index, delimiterChar))
                {
                    properties.Add(ParseSimpleStyleValue<JsonAny>(value[start..(index - start)]));
                    start = index + delimiterLength;
                }

                ++index;
            }
        }
        else
        {
            while (index < (value.Length - delimiterLength) + 1)
            {
                if (SequenceMatch(value, index, delimiter))
                {
                    properties.Add(ParseSimpleStyleValue<JsonAny>(value[start..(index - start)]));
                    start = index + delimiterLength;
                }

                ++index;
            }
        }

        // One more to add.
        if (start != index)
        {
            properties.Add(ParseSimpleStyleValue<JsonAny>(value[start..(index - start)]));
        }

        return JsonAny.FromItems(properties.ToImmutable()).As<T>();
    }
}