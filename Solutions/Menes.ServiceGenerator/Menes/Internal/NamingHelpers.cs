// <copyright file="NamingHelpers.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Helpers for generating identifier names.
    /// </summary>
    internal static class NamingHelpers
    {
        /// <summary>
        /// The common casing patterns.
        /// </summary>
        internal enum Case
        {
            /// <summary>
            /// Naming using PascalCase.
            /// </summary>
            PascalCase,

            /// <summary>
            /// Naming using camelCase.
            /// </summary>
            CamelCase,
        }

        /// <summary>
        /// Convert a string to the relevant casing.
        /// </summary>
        /// <param name="phrase">The string or phrase to convert to the relevant casing.</param>
        /// <param name="casing">The desired casing of the phrase.</param>
        /// <returns>The string in the appropriate casing.</returns>
        internal static string ConvertCaseString(string phrase, Case casing)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return string.Empty;
            }

            var resultBuilder = new StringBuilder();

            bool wasUpper = false;

            foreach (char c in phrase)
            {
                // Replace anything, but letters and digits, with space
                if (!char.IsLetterOrDigit(c))
                {
                    resultBuilder.Append(" ");
                }
                else
                {
                    if (char.IsUpper(c))
                    {
                        if (!wasUpper)
                        {
                            resultBuilder.Append(" ");
                            wasUpper = true;
                        }
                    }
                    else if (wasUpper)
                    {
                        wasUpper = false;
                    }

                    resultBuilder.Append(c);
                }
            }

            string result = resultBuilder.ToString();

            // Make result string all lowercase, because ToTitleCase does not change all uppercase correctly
            result = result.ToLower();

            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

            result = myTI.ToTitleCase(result).Replace(" ", string.Empty);

            if (casing == Case.CamelCase)
            {
                char[] a = result.ToCharArray();
                a[0] = char.ToLower(a[0]);

                return new string(a);
            }

            return result;
        }

        /// <summary>
        /// Build a name for an anonymous schema.
        /// </summary>
        /// <param name="baseTypeName">The base name for the type.</param>
        /// <param name="anonymousSchemaCount">The number of anonymous schemas we have seen that would like to use this base type name.</param>
        /// <returns>For the first type, it will return the base type name. For subsequent types, it will append <c>1</c>, <c>2</c>, etc.</returns>
        internal static string BuildAnonymousSchemaTypeName(string baseTypeName, int anonymousSchemaCount)
        {
            return anonymousSchemaCount == 0 ? baseTypeName : $"{baseTypeName}{anonymousSchemaCount}";
        }
    }
}
