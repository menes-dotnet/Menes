// <copyright file="SchemaVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        private readonly IDocumentResolver? documentResolver;
        private readonly Stack<JsonDocument>? documentStack;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaVisitor"/> class.
        /// </summary>
        /// <remarks>
        /// Using this constructor, the visitor will not perform schema reference resolution.
        /// </remarks>
        public SchemaVisitor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaVisitor"/> class.
        /// </summary>
        /// <param name="documentResolver">The document resolver.</param>
        /// <param name="root">The root json document for the schema.</param>
        /// <remarks>
        /// Using this constructor, the visitor will perform schema reference resolution.
        /// </remarks>
        public SchemaVisitor(IDocumentResolver documentResolver, JsonDocument root)
        {
            this.documentResolver = documentResolver;
            this.documentStack = new Stack<JsonDocument>();
            this.documentStack.Push(root);
        }

        /// <summary>
        /// Gets a value indicating whether this visitor is resolving references.
        /// </summary>
        public bool ResolveReferences => !(this.documentResolver is null);

        /// <summary>
        /// Gets the <see cref="IDocumentResolver"/>.
        /// </summary>
        protected IDocumentResolver DocumentResolver => this.documentResolver is IDocumentResolver dr ? dr : throw new InvalidOperationException("The document resolver was not set.");

        /// <summary>
        /// Gets the <see cref="Stack{T}"/> of <see cref="JsonDocument"/>.
        /// </summary>
        protected Stack<JsonDocument> DocumentStack => this.documentStack is Stack<JsonDocument> stack ? stack : throw new InvalidOperationException("The document stack was not set.");
    }
}
