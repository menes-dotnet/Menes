// <copyright file="IJsonAdditionalProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json;

    /// <summary>
    /// Implemented by types which offer additional iterable <see cref="IJsonValue"/> properties.
    /// </summary>
    public interface IJsonAdditionalProperties : IJsonAdditionalProperties<JsonAny>
    {
        /// <summary>
        /// Try to get a property with the given name.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to get.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The output value.</param>
        /// <returns><c>True</c> if the property was found, otherwise false.</returns>
        /// <exception cref="JsonException">The property could not be parsed to the requested type.</exception>
        bool TryGetAdditionalProperty<TValue>(string propertyName, [NotNullWhen(true)] out TValue value)
            where TValue : struct, IJsonValue;

        /// <summary>
        /// Try to get a property with the given name.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to get.</typeparam>
        /// <param name="utf8PropertyName">The name of the property as a UTF8 byte array.</param>
        /// <param name="value">The output value.</param>
        /// <returns><c>True</c> if the property was found, otherwise false.</returns>
        /// <exception cref="JsonException">The property could not be parsed to the requested type.</exception>
        bool TryGetAdditionalProperty<TValue>(ReadOnlySpan<byte> utf8PropertyName, [NotNullWhen(true)] out TValue value)
            where TValue : struct, IJsonValue;

        /// <summary>
        /// Try to get a property with the given name.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to get.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The output value.</param>
        /// <returns><c>True</c> if the property was found, otherwise false.</returns>
        /// <exception cref="JsonException">The property could not be parsed to the requested type.</exception>
        bool TryGetAdditionalProperty<TValue>(ReadOnlySpan<char> propertyName, [NotNullWhen(true)] out TValue value)
            where TValue : struct, IJsonValue;
    }
}
