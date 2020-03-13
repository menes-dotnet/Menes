// <copyright file="IHalDocumentFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    /// <summary>
    /// Creates instances of an <see cref="IHalDocument"/>.
    /// </summary>
    public interface IHalDocumentFactory
    {
        /// <summary>
        /// Creates a <see cref="IHalDocument"/> from an entity.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity with which to set the properties of the HAL document.</param>
        /// <returns>A <see cref="IHalDocument"/>, configured with the properties from the entity.</returns>
        IHalDocument CreateHalDocumentFrom<T>(T entity);

        /// <summary>
        /// Creates an empty <see cref="IHalDocument"/>.
        /// </summary>
        /// <returns>The <see cref="IHalDocument"/>.</returns>
        IHalDocument CreateHalDocument();
    }
}