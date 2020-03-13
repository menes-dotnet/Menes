// <copyright file="HalDocumentFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal.Internal
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Creates <see cref="HalDocument"/> instances from an object.
    /// </summary>
    public class HalDocumentFactory : IHalDocumentFactory
    {
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="HalDocumentFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public HalDocumentFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public IHalDocument CreateHalDocument()
        {
            return this.serviceProvider.GetService<IHalDocument>();
        }

        /// <inheritdoc/>
        public T CreateHalDocument<T>()
            where T : IHalDocument
        {
            return this.serviceProvider.GetService<T>();
        }

        /// <inheritdoc/>
        public IHalDocument CreateHalDocument(Type halDocumentType)
        {
            if (!typeof(IHalDocument).IsAssignableFrom(halDocumentType))
            {
                throw new ArgumentException($"Unable to cast {halDocumentType} to a {nameof(IHalDocument)}.", nameof(halDocumentType));
            }

            return (IHalDocument)this.serviceProvider.GetService(halDocumentType);
        }

        /// <inheritdoc/>
        public IHalDocument CreateHalDocumentFrom<T>(T entity)
        {
            IHalDocument halDocument = this.serviceProvider.GetService<IHalDocument>();
            halDocument.SetProperties(entity);
            return halDocument;
        }

        /// <inheritdoc/>
        public THal CreateHalDocumentFrom<THal, T>(T entity)
            where THal : IHalDocument
        {
            THal halDocument = this.serviceProvider.GetService<THal>();
            halDocument.SetProperties(entity);
            return halDocument;
        }
    }
}
