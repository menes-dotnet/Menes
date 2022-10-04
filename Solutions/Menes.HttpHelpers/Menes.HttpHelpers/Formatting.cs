// <copyright file="Formatting.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Text;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.UriTemplates;

namespace Menes.HttpHelpers;

/// <summary>
/// Utility functions to help with formatting values.
/// </summary>
public static class Formatting
{
    private static readonly UriTemplate SimpleStyleExpansionTemplate = new("{value}");
    private static readonly UriTemplate PathStyleExpansionTemplate = new("{;value}");
    private static readonly UriTemplate ExplodedPathStyleExpansionTemplate = new("{;value*}");
    private static readonly UriTemplate FormStyleExpansionTemplate = new("{?value}");
    private static readonly UriTemplate ExplodedFormStyleExpansionTemplate = new("{?value*}");
    private static readonly UriTemplate LabelStyleExpansionTemplate = new("{.value}");
    private static readonly UriTemplate ExplodedLabelStyleExpansionTemplate = new("{.value*}");

    /// <summary>
    /// Format the value as a simple-style value.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representing the simple-style value.</returns>
    /// <exception cref="InvalidOperationException">The value was not supported.</exception>
    public static string FormatSimpleStyleValue(in JsonAny value)
    {
        if (value.ValueKind == JsonValueKind.Undefined)
        {
            throw new InvalidOperationException("Unable to format an undefined value.");
        }

        UriTemplate expansion = SimpleStyleExpansionTemplate.SetParameter("value", value);
        return expansion.Resolve();
    }

    /// <summary>
    /// Format the value as a path-style value.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representing the path-style value.</returns>
    /// <exception cref="InvalidOperationException">The value was not supported.</exception>
    public static string FormatPathStyleValue(in JsonAny value)
    {
        if (value.ValueKind == JsonValueKind.Undefined)
        {
            throw new InvalidOperationException("Unable to format an undefined value.");
        }

        UriTemplate expansion = PathStyleExpansionTemplate.SetParameter("value", value);
        return expansion.Resolve();
    }

    /// <summary>
    /// Format the value as an exploded path-style value.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representing the exploded path-style value.</returns>
    /// <exception cref="InvalidOperationException">The value was not supported.</exception>
    public static string FormatExplodedPathStyleValue(in JsonAny value)
    {
        if (value.ValueKind == JsonValueKind.Undefined)
        {
            throw new InvalidOperationException("Unable to format an undefined value.");
        }

        UriTemplate expansion = ExplodedPathStyleExpansionTemplate.SetParameter("value", value);
        return expansion.Resolve();
    }

    /// <summary>
    /// Format the value as a form-style value.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representing the form-style value.</returns>
    /// <exception cref="InvalidOperationException">The value was not supported.</exception>
    public static string FormatFormStyleValue(in JsonAny value)
    {
        if (value.ValueKind == JsonValueKind.Undefined)
        {
            throw new InvalidOperationException("Unable to format an undefined value.");
        }

        UriTemplate expansion = FormStyleExpansionTemplate.SetParameter("value", value);
        return expansion.Resolve();
    }

    /// <summary>
    /// Format the value as an exploded form-style value.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representing the exploded form-style value.</returns>
    /// <exception cref="InvalidOperationException">The value was not supported.</exception>
    public static string FormatExplodedFormStyleValue(in JsonAny value)
    {
        if (value.ValueKind == JsonValueKind.Undefined)
        {
            throw new InvalidOperationException("Unable to format an undefined value.");
        }

        UriTemplate expansion = ExplodedFormStyleExpansionTemplate.SetParameter("value", value);
        return expansion.Resolve();
    }

    /// <summary>
    /// Format the value as a label-style value.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representing the label-style value.</returns>
    /// <exception cref="InvalidOperationException">The value was not supported.</exception>
    public static string FormatLabelStyleValue(in JsonAny value)
    {
        if (value.ValueKind == JsonValueKind.Undefined)
        {
            throw new InvalidOperationException("Unable to format an undefined value.");
        }

        UriTemplate expansion = LabelStyleExpansionTemplate.SetParameter("value", value);
        return expansion.Resolve();
    }

    /// <summary>
    /// Format the value as an exploded label-style value.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representing the exploded label-style value.</returns>
    /// <exception cref="InvalidOperationException">The value was not supported.</exception>
    public static string FormatExplodedLabelStyleValue(in JsonAny value)
    {
        if (value.ValueKind == JsonValueKind.Undefined)
        {
            throw new InvalidOperationException("Unable to format an undefined value.");
        }

        UriTemplate expansion = ExplodedLabelStyleExpansionTemplate.SetParameter("value", value);
        return expansion.Resolve();
    }

    /// <summary>
    /// Formats the value as a space delimited value.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representing the space-delimited value.</returns>
    /// <exception cref="InvalidOperationException">The value was not supported.</exception>
    public static string FormatSpaceDelimitedStyleValue(in JsonAny value)
    {
        // We have pre-encoded our space delimiter
        return FormatWithDelimiter(value, "%20");
    }

    /// <summary>
    /// Formats the value as a pipe delimited value.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representing the pipe-delimited value.</returns>
    /// <exception cref="InvalidOperationException">The value was not supported.</exception>
    public static string FormatPipeDelimitedStyleValue(in JsonAny value)
    {
        return FormatWithDelimiter(value, "|");
    }

    /// <summary>
    /// Formats the value as a deep-object value.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representing the deep-object value.</returns>
    /// <exception cref="InvalidOperationException">The value was not supported.</exception>
    public static string FormatDeepObjectStyleValue(in JsonAny value)
    {
        throw new InvalidOperationException("Format DeepObject is not supported.");
    }

    private static string FormatWithDelimiter(in JsonAny value, string delimiter)
    {
        if (value.ValueKind == JsonValueKind.Object)
        {
            StringBuilder builder = new();
            foreach (JsonObjectProperty property in value.EnumerateObject())
            {
                if (builder.Length > 0)
                {
                    builder.Append(delimiter);
                }

                builder.Append(property.Name);
                builder.Append(delimiter);
                builder.Append(FormatSimpleStyleValue(property.Value));
            }

            return builder.ToString();
        }

        if (value.ValueKind == JsonValueKind.Array)
        {
            StringBuilder builder = new();
            foreach (JsonAny item in value.EnumerateArray())
            {
                if (builder.Length > 0)
                {
                    builder.Append(delimiter);
                }

                builder.Append(FormatSimpleStyleValue(item));
            }

            return builder.ToString();
        }

        UriTemplate expansion = SimpleStyleExpansionTemplate.SetParameter("value", value);
        return expansion.Resolve();
    }
}