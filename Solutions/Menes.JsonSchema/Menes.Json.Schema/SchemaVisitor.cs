// <copyright file="SchemaVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text.Json;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        private readonly IDocumentResolver? documentResolver;

        private readonly Stack<(string, JsonDocument)> documentStack;
        private readonly List<string> pathList;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaVisitor"/> class.
        /// </summary>
        /// <remarks>
        /// Using this constructor, the visitor will not perform schema reference resolution.
        /// </remarks>
        public SchemaVisitor()
        {
            this.pathList = new List<string>();
            this.documentStack = new Stack<(string, JsonDocument)>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaVisitor"/> class.
        /// </summary>
        /// <param name="documentResolver">The document resolver.</param>
        /// <param name="uri">The root uri.</param>
        /// <param name="root">The root json document for the schema.</param>
        /// <remarks>
        /// Using this constructor, the visitor will perform schema reference resolution.
        /// </remarks>
        public SchemaVisitor(IDocumentResolver documentResolver, string uri, JsonDocument root)
            : this()
        {
            this.documentResolver = documentResolver;
            this.documentStack.Push((uri, root));
        }

        /// <summary>
        /// Gets a value indicating whether this visitor is resolving references.
        /// </summary>
        public bool ResolveReferences => !(this.documentResolver is null);

        /// <summary>
        /// Gets the path to the current element in the current document on the document stack.
        /// </summary>
        public string Path
        {
            get
            {
                // Find the last root.
                int index = this.pathList.LastIndexOf("#");
                return string.Join(string.Empty, this.pathList.Skip(index));
            }
        }

        /// <summary>
        /// Gets the current base URI.
        /// </summary>
        protected string CurrentBaseUri => this.documentStack.Peek().Item1;

        /// <summary>
        /// Gets the current document.
        /// </summary>
        protected JsonDocument CurrentDocument => this.documentStack.Peek().Item2;

        /// <summary>
        /// Gets the <see cref="IDocumentResolver"/>.
        /// </summary>
        protected IDocumentResolver DocumentResolver => this.documentResolver is IDocumentResolver dr ? dr : throw new InvalidOperationException("The document resolver was not set.");

        /// <summary>
        /// Push a document onto the document stack.
        /// </summary>
        /// <param name="uri">The uri of the document to push.</param>
        /// <param name="document">The document to push.</param>
        protected void PushDocument(string uri, JsonDocument document)
        {
            this.documentStack.Push((uri, document));
        }

        /// <summary>
        /// Pops a document from the document stack.
        /// </summary>
        protected void PopDocument()
        {
            this.documentStack.Pop();
        }

        /// <summary>
        /// Push the current path element onto the stack.
        /// </summary>
        /// <param name="path">The path element to add.</param>
        protected void PushPointerElement(string path)
        {
            if (path == "#")
            {
                this.pathList.Add(path);
            }
            else
            {
                this.pathList.Add("/" + path);
            }
        }

        /// <summary>
        /// Pops the last path element off the stack.
        /// </summary>
        protected void PopPointerElement()
        {
            if (this.pathList.Count > 0)
            {
                this.pathList.RemoveAt(this.pathList.Count - 1);
            }
        }
    }
}
