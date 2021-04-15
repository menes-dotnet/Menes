// <copyright file="IJsonObject{T}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents any object value that can be represented as Json.
    /// </summary>
    /// <typeparam name="T">The type implementing the <see cref="IJsonObject{T}"/>.</typeparam>
    public interface IJsonObject<T> : IJsonObject, IEnumerable<Property<T>>
        where T : struct, IJsonObject<T>
    {
        /// <summary>
        /// Remove a property.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of the object with the property removed.</returns>
        T RemoveProperty(string propertyName);

        /// <summary>
        /// Remove a property.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of the object with the property removed.</returns>
        T RemoveProperty(System.ReadOnlySpan<char> propertyName);

        /// <summary>
        /// Remove a property.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <returns>An instance of the object with the property removed.</returns>
        T RemoveProperty(System.ReadOnlySpan<byte> name);

        /// <summary>
        /// Sets a property.
        /// </summary>
        /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/> to set.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>An instance of the object with the property set.</returns>
        T SetProperty<TValue>(string propertyName, TValue value)
        where TValue : struct, IJsonValue;

        /// <summary>
        /// Sets a property.
        /// </summary>
        /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/> to set.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>An instance of the object with the property set.</returns>
        T SetProperty<TValue>(System.ReadOnlySpan<char> propertyName, TValue value)
        where TValue : struct, IJsonValue;

        /// <summary>
        /// Sets a property.
        /// </summary>
        /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/> to set.</typeparam>
        /// <param name="utf8Name">The name of the property.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>An instance of the object with the property set.</returns>
        T SetProperty<TValue>(System.ReadOnlySpan<byte> utf8Name, TValue value)
        where TValue : struct, IJsonValue;
    }
}