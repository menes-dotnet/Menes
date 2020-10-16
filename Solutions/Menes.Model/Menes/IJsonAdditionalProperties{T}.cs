// <copyright file="IJsonAdditionalProperties{T}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
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
    }
}
