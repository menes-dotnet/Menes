// <copyright file="IHalDocumentFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    /// <summary>
    /// Creates instances of a <see cref="HalDocument"/>.
    /// </summary>
    public interface IHalDocumentFactory
    {
        /// <summary>
        /// Creates a <see cref="HalDocument"/> from an entity.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity with which to set the properties of the HAL document.</param>
        /// <returns>A <see cref="HalDocument"/>, configured with the properties from the entity.</returns>
        HalDocument CreateHalDocumentFrom<T>(T entity);

        /// <summary>
        /// Creates an empty <see cref="HalDocument"/>.
        /// </summary>
        /// <returns>The <see cref="HalDocument"/>.</returns>
        HalDocument CreateHalDocument();
    }
}