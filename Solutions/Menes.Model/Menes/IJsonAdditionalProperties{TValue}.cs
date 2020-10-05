// <copyright file="IJsonAdditionalProperties{TValue}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json;

    /// <summary>
    /// Implemented by types which offer iterable <see cref="IJsonValue"/> properties constrained to type <typeparamref name="TValue"/>.
    /// </summary>
    /// <typeparam name="TValue">The type of <see cref="IJsonValue"/>.</typeparam>
    public interface IJsonAdditionalProperties<TValue>
            where TValue : IJsonValue
    {
        /// <summary>
        /// Gets the enumerator for the additional properties.
        /// </summary>
        /// <returns>The enumerator for the additional properties.</returns>
        JsonPropertyEnumerator<TValue> AdditionalProperties { get; }

        /// <summary>
        /// Try to get a property with the given name.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The output value.</param>
        /// <returns><c>True</c> if the property was found, otherwise false.</returns>
        /// <exception cref="JsonException">The property could not be parsed to the requested type.</exception>
        bool TryGetAdditionalProperty(string propertyName, [NotNullWhen(true)] out TValue value);

        /// <summary>
        /// Try to get a property with the given name.
        /// </summary>
        /// <param name="utf8PropertyName">The name of the property as a UTF8 byte array.</param>
        /// <param name="value">The output value.</param>
        /// <returns><c>True</c> if the property was found, otherwise false.</returns>
        /// <exception cref="JsonException">The property could not be parsed to the requested type.</exception>
        bool TryGetAdditionalProperty(ReadOnlySpan<byte> utf8PropertyName, [NotNullWhen(true)] out TValue value);

        /// <summary>
        /// Try to get a property with the given name.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The output value.</param>
        /// <returns><c>True</c> if the property was found, otherwise false.</returns>
        /// <exception cref="JsonException">The property could not be parsed to the requested type.</exception>
        bool TryGetAdditionalProperty(ReadOnlySpan<char> propertyName, [NotNullWhen(true)] out TValue value);
    }
}
