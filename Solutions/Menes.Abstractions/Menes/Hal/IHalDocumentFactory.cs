// <copyright file="IHalDocumentFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    using System;

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
        /// Creates a <see cref="IHalDocument"/> from an entity.
        /// </summary>
        /// <typeparam name="THal">The type of the hal document.</typeparam>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity with which to set the properties of the HAL document.</param>
        /// <returns>A <see cref="IHalDocument"/>, configured with the properties from the entity.</returns>
        THal CreateHalDocumentFrom<THal, T>(T entity)
            where THal : IHalDocument;

        /// <summary>
        /// Creates an empty <see cref="IHalDocument"/>.
        /// </summary>
        /// <returns>The <see cref="IHalDocument"/>.</returns>
        IHalDocument CreateHalDocument();

        /// <summary>
        /// Creates an empty <see cref="IHalDocument"/> of a specific type.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IHalDocument"/>.</typeparam>
        /// <returns>The <see cref="IHalDocument"/>.</returns>
        T CreateHalDocument<T>()
            where T : IHalDocument;

        /// <summary>
        /// Creates an empty <see cref="IHalDocument"/> of a specific type.
        /// </summary>
        /// <param name="halDocumentType">The type of the <see cref="IHalDocument"/>.</param>
        /// <returns>The <see cref="IHalDocument"/>.</returns>
        IHalDocument CreateHalDocument(Type halDocumentType);
    }
}