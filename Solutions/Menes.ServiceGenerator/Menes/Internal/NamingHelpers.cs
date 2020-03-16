﻿// <copyright file="NamingHelpers.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
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
            string[] splitPhrase = phrase.Split(' ', '-', '.', '_');
            var sb = new StringBuilder();

            if (casing == Case.CamelCase)
            {
                sb.Append(splitPhrase[0].ToLower());
                splitPhrase[0] = string.Empty;
            }
            else if (casing == Case.PascalCase)
            {
                sb = new StringBuilder();
            }

            foreach (string s in splitPhrase)
            {
                char[] splitPhraseChars = s.ToCharArray();
                if (splitPhraseChars.Length > 0)
                {
                    splitPhraseChars[0] = new string(splitPhraseChars[0], 1).ToUpper()[0];
                }

                sb.Append(new string(splitPhraseChars));
            }

            return sb.ToString();
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
