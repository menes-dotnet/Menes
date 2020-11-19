// <copyright file="IJsonObject.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;

    /// <summary>
    /// Represents any object value that can be represented as Json.
    /// </summary>
    public interface IJsonObject : IJsonValue
    {
        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
        bool TryGetProperty<T>(ReadOnlySpan<char> propertyName, out T property)
            where T : struct, IJsonValue;

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
        bool TryGetProperty<T>(string propertyName, out T property)
            where T : struct, IJsonValue;

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="utf8PropertyName">The utf8 encoded name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
        bool TryGetProperty<T>(ReadOnlySpan<byte> utf8PropertyName, out T property)
            where T : struct, IJsonValue;
    }
}