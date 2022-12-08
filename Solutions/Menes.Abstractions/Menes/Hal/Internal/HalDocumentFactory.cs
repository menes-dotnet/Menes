// <copyright file="HalDocumentFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal.Internal
{
    using System.Text.Json;

    /// <summary>
    /// Creates <see cref="HalDocument"/> instances from an object.
    /// </summary>
    public class HalDocumentFactory : IHalDocumentFactory
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="HalDocumentFactory"/> class.
        /// </summary>
        /// <param name="jsonSerializerOptions">JSON serialiation settings.</param>
        public HalDocumentFactory(JsonSerializerOptions jsonSerializerOptions)
        {
            this.jsonSerializerOptions  = jsonSerializerOptions;
        }

        /// <inheritdoc/>
        public HalDocument CreateHalDocument()
        {
            return new HalDocument(this.jsonSerializerOptions);
        }

        /// <inheritdoc/>
        public HalDocument CreateHalDocumentFrom<T>(T entity)
            where T : notnull
        {
            HalDocument halDocument = new(this.jsonSerializerOptions);
            halDocument.SetProperties(entity);
            return halDocument;
        }
    }
}