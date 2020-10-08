// <copyright file="IJsonAdditionalProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Implemented by types which offer iterable <see cref="IJsonValue"/> properties.
    /// </summary>
    public interface IJsonAdditionalProperties
    {
        /// <summary>
        /// Gets the enumerator for the additional properties.
        /// </summary>
        /// <returns>The enumerator for the additional properties.</returns>
        JsonPropertyEnumerator AdditionalProperties { get; }

        /// <summary>
        /// Gets the number of properties in the additional properties.
        /// </summary>
        int AdditionalPropertiesCount { get; }
    }
}
