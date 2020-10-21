// <copyright file="SchemaVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
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
        private readonly Stack<(string, JsonDocument)>? documentStack;
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
            this.documentStack = new Stack<(string, JsonDocument)>();
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
                return string.Join(string.Empty, this.pathList.GetRange(index, this.pathList.Count - index));
            }
        }

        /// <summary>
        /// Gets the current base URI.
        /// </summary>
        public string CurrentBaseUri => this.DocumentStack.Peek().uri;

        /// <summary>
        /// Gets the current document.
        /// </summary>
        public JsonDocument CurrentDocument => this.DocumentStack.Peek().document;

        /// <summary>
        /// Gets the <see cref="IDocumentResolver"/>.
        /// </summary>
        protected IDocumentResolver DocumentResolver => this.documentResolver is IDocumentResolver dr ? dr : throw new InvalidOperationException("The document resolver was not set.");

        /// <summary>
        /// Gets the <see cref="Stack{T}"/> of <see cref="JsonDocument"/>.
        /// </summary>
        protected Stack<(string uri, JsonDocument document)> DocumentStack => this.documentStack is Stack<(string, JsonDocument)> stack ? stack : throw new InvalidOperationException("The document stack was not set.");

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
            this.pathList.RemoveAt(this.pathList.Count - 1);
        }

        /// <summary>
        /// Pushes a pointer element for a schema reference.
        /// </summary>
        /// <param name="schemaOrReference">The schema or reference for which to push a pointer element.</param>
        /// <remarks>
        /// If the SchemaOrReference was a reference, this will push a pointer for the reference onto the stack.
        /// </remarks>
        protected void PushPointerElementForSchemaOrReference(JsonSchema.SchemaOrReference schemaOrReference)
        {
            if (schemaOrReference.IsSchemaReference)
            {
                var jsonref = new JsonRef(schemaOrReference.AsSchemaReference().Ref);
                this.PushPointerElement(jsonref.HasPointer ? jsonref.Pointer.ToString() : "#");
            }
        }
    }
}
