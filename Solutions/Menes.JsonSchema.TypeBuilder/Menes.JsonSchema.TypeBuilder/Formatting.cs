// <copyright file="Formatting.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    /// <summary>
    /// Formatting utilities.
    /// </summary>
    internal static class Formatting
    {
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
    }
}
