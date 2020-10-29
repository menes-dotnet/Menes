// <copyright file="IJsonAdditionalProperties{T}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Implemented by types which offer iterable <see cref="IJsonValue"/> properties.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="IJsonValue"/> in the additional properties.</typeparam>
    public interface IJsonAdditionalProperties<T>
        where T : struct, IJsonValue
    {
        /// <summary>
        /// Gets the enumerator for the additional properties.
        /// </summary>
        /// <returns>The enumerator for the additional properties.</returns>
        JsonProperties<T>.JsonPropertyEnumerator JsonAdditionalProperties { get; }

        /// <summary>
        /// Gets the number of properties in the additional properties.
        /// </summary>
        int JsonAdditionalPropertiesCount { get; }

        /// <summary>
        /// Try to get the property with the given name.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="propertyValue">The resulting value of the property.</param>
        /// <returns><c>True</c> if the property was obtained.</returns>
        bool TryGet(string propertyName, [NotNullWhen(true)] out T propertyValue);

        /// <summary>
        /// Try to get the property with the given name.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="propertyValue">The resulting value of the property.</param>
        /// <returns><c>True</c> if the property was obtained.</returns>
        bool TryGet(ReadOnlySpan<char> propertyName, [NotNullWhen(true)] out T propertyValue);

        /// <summary>
        /// Try to get the property with the given name.
        /// </summary>
        /// <param name="utf8PropertyName">The name of the property as a UTF8 byte stream.</param>
        /// <param name="propertyValue">The resulting value of the property.</param>
        /// <returns><c>True</c> if the property was obtained.</returns>
        bool TryGet(ReadOnlySpan<byte> utf8PropertyName, [NotNullWhen(true)] out T propertyValue);
    }
}
