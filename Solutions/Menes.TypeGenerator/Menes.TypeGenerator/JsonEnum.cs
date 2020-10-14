// <copyright file="JsonEnum.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    /// <summary>
    /// An enumeration builder for json formatted values.
    /// </summary>
    public static class JsonEnum
    {
        /// <summary>
        /// Build a JSON array string from an array of <see cref="IJsonValue"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to create.</typeparam>
        /// <param name="values">The values to convert.</param>
        /// <returns>The json array of booleans.</returns>
        public static string From<T>(params T[] values)
            where T : struct, IJsonValue
        {
            return JsonArray.Create(values).ToString() ?? "[]";
        }
    }
}
