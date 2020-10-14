// <copyright file="JsonConst.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    /// <summary>
    /// An enumeration builder for json const values.
    /// </summary>
    public static class JsonConst
    {
        /// <summary>
        /// Build a JSON array string from an array of <see cref="IJsonValue"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to create.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>The json array of booleans.</returns>
        public static string? From<T>(T? value)
            where T : struct, IJsonValue
        {
            return value?.ToString() ?? null;
        }
    }
}
