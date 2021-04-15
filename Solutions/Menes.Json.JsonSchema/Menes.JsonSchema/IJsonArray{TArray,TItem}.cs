// <copyright file="IJsonArray{TArray,TItem}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents any json value that can be represented as an array of items.
    /// </summary>
    /// <typeparam name="TArray">The type implementing the interface.</typeparam>
    /// <typeparam name="TItem">The general type of items in the array.</typeparam>
    public interface IJsonArray<TArray, TItem> : IJsonArray, IEnumerable, IEnumerable<TItem>
        where TArray : struct, IJsonArray<TArray, TItem>
        where TItem : struct, IJsonValue
    {
        /// <summary>
        /// Add an item to the array.
        /// </summary>
        /// <typeparam name="T1">The type of the item to add.</typeparam>
        /// <param name="item1">The item to add.</param>
        /// <returns>The array with the item added.</returns>
        TArray Add<T1>(T1 item1)
            where T1 : struct, IJsonValue;

        /// <summary>
        /// Add items to the array.
        /// </summary>
        /// <typeparam name="T1">The type of the first item to add.</typeparam>
        /// <typeparam name="T2">The type of the second item to add.</typeparam>
        /// <param name="item1">The first item to add.</param>
        /// <param name="item2">The second item to add.</param>
        /// <returns>The array with the items added.</returns>
        TArray Add<T1, T2>(T1 item1, T2 item2)
            where T1 : struct, IJsonValue
            where T2 : struct, IJsonValue;

        /// <summary>
        /// Add items to the array.
        /// </summary>
        /// <typeparam name="T1">The type of the first item to add.</typeparam>
        /// <typeparam name="T2">The type of the second item to add.</typeparam>
        /// <typeparam name="T3">The type of the third item to add.</typeparam>
        /// <param name="item1">The first item to add.</param>
        /// <param name="item2">The second item to add.</param>
        /// <param name="item3">The third item to add.</param>
        /// <returns>The array with the items added.</returns>
        TArray Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
            where T1 : struct, IJsonValue
            where T2 : struct, IJsonValue
            where T3 : struct, IJsonValue;

        /// <summary>
        /// Add items to the array.
        /// </summary>
        /// <typeparam name="T1">The type of the first item to add.</typeparam>
        /// <typeparam name="T2">The type of the second item to add.</typeparam>
        /// <typeparam name="T3">The type of the third item to add.</typeparam>
        /// <typeparam name="T4">The type of the fourth item to add.</typeparam>
        /// <param name="item1">The first item to add.</param>
        /// <param name="item2">The second item to add.</param>
        /// <param name="item3">The third item to add.</param>
        /// <param name="item4">The fourth item to add.</param>
        /// <returns>The array with the items added.</returns>
        TArray Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
            where T1 : struct, IJsonValue
            where T2 : struct, IJsonValue
            where T3 : struct, IJsonValue
            where T4 : struct, IJsonValue;

        /// <summary>
        /// Add items to the array.
        /// </summary>
        /// <typeparam name="T">The type of the items to add.</typeparam>
        /// <param name="items">The items to add.</param>
        /// <returns>The array with the items added.</returns>
        TArray Add<T>(params T[] items)
            where T : struct, IJsonValue;

        /// <summary>
        /// Insert an item into the array.
        /// </summary>
        /// <typeparam name="T">The type of the item to insert.</typeparam>
        /// <param name="index">The index at which to insert the item.</param>
        /// <param name="item1">The item to insert.</param>
        /// <returns>The array with the items inserted.</returns>
        TArray Insert<T>(int index, T item1)
            where T : struct, IJsonValue;

        /// <summary>
        /// Insert items into the array.
        /// </summary>
        /// <typeparam name="T1">The type of the first item to insert.</typeparam>
        /// <typeparam name="T2">The type of the second item to insert.</typeparam>
        /// <param name="index">The index at which to insert the item.</param>
        /// <param name="item1">The first item to insert.</param>
        /// <param name="item2">The second item to insert.</param>
        /// <returns>The array with the items inserted.</returns>
        TArray Insert<T1, T2>(int index, T1 item1, T2 item2)
            where T1 : struct, IJsonValue
            where T2 : struct, IJsonValue;

        /// <summary>
        /// Insert items into the array.
        /// </summary>
        /// <typeparam name="T1">The type of the first item to insert.</typeparam>
        /// <typeparam name="T2">The type of the second item to insert.</typeparam>
        /// <typeparam name="T3">The type of the third item to insert.</typeparam>
        /// <param name="index">The index at which to insert the item.</param>
        /// <param name="item1">The first item to insert.</param>
        /// <param name="item2">The second item to insert.</param>
        /// <param name="item3">The third item to insert.</param>
        /// <returns>The array with the items inserted.</returns>
        TArray Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
            where T1 : struct, IJsonValue
            where T2 : struct, IJsonValue
            where T3 : struct, IJsonValue;

        /// <summary>
        /// Insert items into the array.
        /// </summary>
        /// <typeparam name="T1">The type of the first item to insert.</typeparam>
        /// <typeparam name="T2">The type of the second item to insert.</typeparam>
        /// <typeparam name="T3">The type of the third item to insert.</typeparam>
        /// <typeparam name="T4">The type of the fourth item to insert.</typeparam>
        /// <param name="index">The index at which to insert the item.</param>
        /// <param name="item1">The first item to insert.</param>
        /// <param name="item2">The second item to insert.</param>
        /// <param name="item3">The third item to insert.</param>
        /// <param name="item4">The fourth item to insert.</param>
        /// <returns>The array with the items inserted.</returns>
        TArray Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
            where T1 : struct, IJsonValue
            where T2 : struct, IJsonValue
            where T3 : struct, IJsonValue
            where T4 : struct, IJsonValue;

        /// <summary>
        /// Insert items into the array.
        /// </summary>
        /// <typeparam name="T">The type of the items to insert.</typeparam>
        /// <param name="index">The index at which to insert the item.</param>
        /// <param name="items">The items to insert.</param>
        /// <returns>The array with the items inserted.</returns>
        TArray Insert<T>(int index, params T[] items)
            where T : struct, IJsonValue;

        /// <summary>
        /// Remove the item at the given index.
        /// </summary>
        /// <param name="index">The index at which to remove the item.</param>
        /// <returns>The array with the item removed.</returns>
        TArray RemoveAt(int index);

        /// <summary>
        /// Remove the items for which the predicate is true.
        /// </summary>
        /// <param name="condition">The predicate to test.</param>
        /// <returns>The array with the items that match the predicate removed.</returns>
        TArray RemoveIf(System.Predicate<TItem> condition);

        /// <summary>
        /// Remove the items for which the predicate is true.
        /// </summary>
        /// <typeparam name="T">The type of the item to test.</typeparam>
        /// <param name="condition">The predicate to test.</param>
        /// <returns>The array with the items that match the predicate removed.</returns>
        TArray RemoveIf<T>(System.Predicate<T> condition)
            where T : struct, IJsonValue;
    }
}