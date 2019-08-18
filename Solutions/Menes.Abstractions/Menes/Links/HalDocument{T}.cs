// <copyright file="HalDocument{T}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Links
{
    using System.Collections.Generic;
    using Menes.Internal;
    using Newtonsoft.Json;

    /// <summary>
    /// A generic container object that contains a <see cref="HalDocument"/>
    /// and an entity. When serialized, properties from both child objects
    /// will be merged into a single Json document, giving an end result
    /// that looks like a <see cref="HalDocument"/> with all the properties of
    /// the payload attached.
    /// </summary>
    /// <typeparam name="T">The type of the payload.</typeparam>
    public sealed class HalDocument<T> : HalDocument
        where T : new()
    {
        private T data;

        /// <summary>
        /// Initializes a new instance of the <see cref="HalDocument{T}"/> class.
        /// </summary>
        public HalDocument()
        {
            this.HalDocumentInternal = new HalDocument();
        }

        /// <summary>
        /// Gets or sets the payload data.
        /// </summary>
        /// <remarks>
        /// This property should never be set to null. Since the idea is that all of
        /// it's properties will be lifted up to appear as part of the HalDocument
        /// response, it doesn't make sense to allow null values here. In order to prevent
        /// this problem, if Data has been set to null then retreiving the value will
        /// get a new instance of T.
        /// </remarks>
        public T Data
        {
            get
            {
                if (this.data == null)
                {
                    return new T();
                }

                return this.data;
            }

            set
            {
                this.data = value;
            }
        }

        /// <inheritdoc/>
        public override HalWebLinkCollection Links => this.HalDocumentInternal.Links;

        /// <inheritdoc/>
        public override IDictionary<string, object> EmbeddedResources => this.HalDocumentInternal.EmbeddedResources;

        /// <summary>
        /// Gets the internal HalDocument, used for managing links and resources.
        /// </summary>
        /// <remarks>
        /// Using an internal HalDocument in this way simplifies the implementation of
        /// the corresponding <see cref="JsonConverter"/> for this class, <see cref="HalDocumentJsonConverter"/>.
        /// </remarks>
        internal HalDocument HalDocumentInternal { get; } = new HalDocument();
    }
}