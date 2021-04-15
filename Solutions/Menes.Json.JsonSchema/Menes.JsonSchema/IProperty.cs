// <copyright file="IProperty.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System;

    /// <summary>
    /// An interface implemented by a property.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the name of the property as a <see cref="ReadOnlyMemory{T}"/> of <see cref="char"/>.
        /// </summary>
        ReadOnlyMemory<char> NameAsMemory { get; }

        /// <summary>
        /// Determines if the name equals a particular value.
        /// </summary>
        /// <param name="utf8Name">The utf8 encoded byte array of the string value to compare.</param>
        /// <returns><c>true</c> if the property name equals the given value.</returns>
        bool NameEquals(ReadOnlySpan<byte> utf8Name);

        /// <summary>
        /// Determines if the name equals a particular value.
        /// </summary>
        /// <param name="name">The the string value to compare.</param>
        /// <returns><c>true</c> if the property name equals the given value.</returns>
        bool NameEquals(ReadOnlySpan<char> name);

        /// <summary>
        /// Determines if the name equals a particular value.
        /// </summary>
        /// <param name="name">The string value to compare.</param>
        /// <returns><c>true</c> if the property name equals the given value.</returns>
        bool NameEquals(string name);

        /// <summary>
        /// Gets the value of the property as the given <see cref="IJsonValue"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/> to get.</typeparam>
        /// <returns>The value of the property.</returns>
        TValue Value<TValue>()
            where TValue : struct, IJsonValue;
    }
}