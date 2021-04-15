// <copyright file="JsonArray.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System.Collections.Immutable;

    /// <summary>
    /// Helpers for creating arrays of <see cref="IJsonValue"/> instances.
    /// </summary>
    public static class JsonArray
    {
        /// <summary>
        /// Create an array from a collection of values.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IJsonValue"/> from which to create the array.</typeparam>
        /// <param name="value">The value to create.</param>
        /// <returns>An <see cref="ImmutableArray{T}"/> of the target value type.</returns>
        public static ImmutableArray<T> From<T>(T value)
        {
            return ImmutableArray.Create(value);
        }

        /// <summary>
        /// Create an array from a collection of values.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IJsonValue"/> from which to create the array.</typeparam>
        /// <param name="value1">The first value to create.</param>
        /// <param name="value2">The second value to create.</param>
        /// <returns>An <see cref="ImmutableArray{T}"/> of the target value type.</returns>
        public static ImmutableArray<T> From<T>(T value1, T value2)
        {
            return ImmutableArray.Create(value1, value2);
        }

        /// <summary>
        /// Create an array from a collection of values.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IJsonValue"/> from which to create the array.</typeparam>
        /// <param name="value1">The first value to create.</param>
        /// <param name="value2">The second value to create.</param>
        /// <param name="value3">The third value to create.</param>
        /// <returns>An <see cref="ImmutableArray{T}"/> of the target value type.</returns>
        public static ImmutableArray<T> From<T>(T value1, T value2, T value3)
        {
            return ImmutableArray.Create(value1, value2, value3);
        }

        /// <summary>
        /// Create an array from a collection of values.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IJsonValue"/> from which to create the array.</typeparam>
        /// <param name="value1">The first value to create.</param>
        /// <param name="value2">The second value to create.</param>
        /// <param name="value3">The third value to create.</param>
        /// <param name="value4">The fourth value to create.</param>
        /// <returns>An <see cref="ImmutableArray{T}"/> of the target value type.</returns>
        public static ImmutableArray<T> From<T>(T value1, T value2, T value3, T value4)
        {
            return ImmutableArray.Create(value1, value2, value3, value4);
        }

        /// <summary>
        /// Create an array from a collection of values.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IJsonValue"/> from which to create the array.</typeparam>
        /// <param name="values">The values to create.</param>
        /// <returns>An <see cref="ImmutableArray{T}"/> of the target value type.</returns>
        public static ImmutableArray<T> From<T>(params T[] values)
        {
            return ImmutableArray.Create(values);
        }
    }
}
