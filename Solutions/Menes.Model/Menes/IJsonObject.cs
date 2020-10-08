// <copyright file="IJsonObject.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Implemented by compound JSON objects.
    /// </summary>
    public interface IJsonObject : IJsonValue
    {
        /// <summary>
        /// Gets the number of properties on this object.
        /// </summary>
        int PropertiesCount { get; }
    }
}
