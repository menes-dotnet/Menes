// <copyright file="Parsing.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Immutable;
using Corvus.Json;
using Corvus.Json.UriTemplates;

namespace Menes.HttpHelpers;

/// <summary>
/// Utility functions to help with formatting values.
/// </summary>
public static class Parsing
{
    private static readonly UriTemplate SimpleTypeExpansion = new("{value}");
    private static readonly UriTemplate FormTypeExpansion = new("{?value}");
    private static readonly UriTemplate ExplodedFormTypeExpansion = new("{?value*}");

    /// <summary>
    /// Parse the value as a simple-style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static JsonAny ParseSimpleStyleValue(string value)
    {
        if (SimpleTypeExpansion.TryGetParameters(value, out ImmutableDictionary<string, JsonAny>? result))
        {
            return result!["value"];
        }

        throw new InvalidOperationException("Unable to parse the value.");
    }

    /// <summary>
    /// Parse the value as a simple-style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static JsonAny ParseSimpleStyleValue(ReadOnlySpan<char> value)
    {
        if (SimpleTypeExpansion.TryGetParameters(value.ToString(), out ImmutableDictionary<string, JsonAny>? result))
        {
            return result!["value"];
        }

        throw new InvalidOperationException("Unable to parse the value.");
    }

    /// <summary>
    /// Parse the value as a form-style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static JsonAny ParseFormStyleValue(string value)
    {
        if (FormTypeExpansion.TryGetParameters(value, out ImmutableDictionary<string, JsonAny>? result))
        {
            return result!["value"];
        }

        throw new InvalidOperationException("Unable to parse the value.");
    }

    /// <summary>
    /// Parse the value as a form-style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static JsonAny ParseFormStyleValue(ReadOnlySpan<char> value)
    {
        if (FormTypeExpansion.TryGetParameters(value.ToString(), out ImmutableDictionary<string, JsonAny>? result))
        {
            return result!["value"];
        }

        throw new InvalidOperationException("Unable to parse the value.");
    }

    /// <summary>
    /// Parse the value as an exploded form-style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static JsonAny ParseExplodedFormStyleValue(string value)
    {
        if (ExplodedFormTypeExpansion.TryGetParameters(value, out ImmutableDictionary<string, JsonAny>? result))
        {
            return result!["value"];
        }

        throw new InvalidOperationException("Unable to parse the value.");
    }

    /// <summary>
    /// Parse the value as an exploded form-style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The requested value.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static JsonAny ParseExplodedFormStyleValue(ReadOnlySpan<char> value)
    {
        if (ExplodedFormTypeExpansion.TryGetParameters(value.ToString(), out ImmutableDictionary<string, JsonAny>? result))
        {
            return result!["value"];
        }

        throw new InvalidOperationException("Unable to parse the value.");
    }

    /// <summary>
    /// Parse the value as a pipe-delimited style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static JsonAny ParsePipeDelimitedObjectStyleValue(string value)
    {
        return ParseDelimitedObjectStyleValue(value.AsSpan(), "|");
    }

    /// <summary>
    /// Parse the value as a pipe-delimited array style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static JsonAny ParsePipeDelimitedArrayStyleValue(string value)
    {
        return ParseDelimitedArrayStyleValue(value.AsSpan(), "|");
    }

    /// <summary>
    /// Parse the value as a pipe-delimited style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static JsonAny ParseSpaceDelimitedObjectStyleValue(string value)
    {
        return ParseDelimitedObjectStyleValue(value.AsSpan(), "%32");
    }

    /// <summary>
    /// Parse the value as a pipe-delimited array style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    public static JsonAny ParseSpaceDelimitedArrayStyleValue(string value)
    {
        return ParseDelimitedArrayStyleValue(value.AsSpan(), "%32");
    }

    /// <summary>
    /// Parse the value as a pipe-delimited style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    private static JsonAny ParseDelimitedObjectStyleValue(ReadOnlySpan<char> value, string delimiter)
    {
        ImmutableDictionary<JsonPropertyName, JsonAny>.Builder properties = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();

        int index = 0;
        int start = 0;
        bool lookingForName = true;

        int nameStart = 0;
        int nameLength = 0;

        int delimiterLength = delimiter.Length;
        ReadOnlySpan<char> delimiterSpan = delimiter;

        while (index < value.Length)
        {
            if (SequenceMatch(value, index, delimiterSpan))
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
                    properties.Add(propertyName, ParseSimpleStyleValue(value[start..(index - start)]));
                }
            }

            ++index;
        }

        // One more to add
        if (!lookingForName)
        {
            string propertyName = value[nameStart..nameLength].ToString();
            properties.Add(propertyName, ParseSimpleStyleValue(value[start..(index - start)]));
        }

        return properties.ToImmutable();
    }

    private static bool SequenceMatch(ReadOnlySpan<char> value, int index, ReadOnlySpan<char> delimiter)
    {
        ReadOnlySpan<char> test = value[index..];
        if (test.Length < delimiter.Length)
        {
            return false;
        }

        return test.SequenceEqual(delimiter);
    }

    /// <summary>
    /// Parse the value as a pipe-delimited style value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The string value prepared for an HTTP header.</returns>
    /// <exception cref="InvalidOperationException">The value was not in the correct format.</exception>
    private static JsonAny ParseDelimitedArrayStyleValue(ReadOnlySpan<char> value, string delimiter)
    {
        ImmutableList<JsonAny>.Builder properties = ImmutableList.CreateBuilder<JsonAny>();

        int index = 0;
        int start = 0;

        int delimiterLength = delimiter.Length;

        while (index < value.Length)
        {
            if (SequenceMatch(value, index, delimiter))
            {
                properties.Add(ParseSimpleStyleValue(value[start..(index - start)]));
                start = index + delimiterLength;
            }

            ++index;
        }

        // One more to add.
        if (start != index)
        {
            properties.Add(ParseSimpleStyleValue(value[start..(index - start)]));
        }

        return properties.ToImmutable();
    }
}