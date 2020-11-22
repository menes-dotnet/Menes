// <copyright file="IJsonArray.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections;

    /// <summary>
    /// Represents any object value that can be represented as Json.
    /// </summary>
    public interface IJsonArray : IJsonValue, IEnumerable
    {
        /// <summary>
        /// Gets the length of the array.
        /// </summary>
        /// <returns>The length of the array.</returns>
        int GetArrayLength();

        /// <summary>
        /// Gets the item at the given index in the array.
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <param name="index">The index at which to get the item.</param>
        /// <returns>An instance of the item at the given index as the given type.</returns>
        T GetItemAtIndex<T>(int index)
            where T : struct, IJsonValue;
    }
}