// <copyright file="HalDocumentFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal.Internal
{
    using System;
    using Menes.Links;
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
        public HalDocument CreateHalDocument()
        {
            return this.serviceProvider.GetService<HalDocument>();
        }

        /// <inheritdoc/>
        public HalDocument CreateHalDocumentFrom<T>(T entity)
        {
            HalDocument halDocument = this.serviceProvider.GetService<HalDocument>();
            halDocument.SetProperties(entity);
            return halDocument;
        }
    }
}
