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
        /// <param name="root">The root json document for the schema.</param>
        /// <remarks>
        /// Using this constructor, the visitor will perform schema reference resolution.
        /// </remarks>
        public SchemaVisitor(IDocumentResolver documentResolver, JsonDocument root)
            : this()
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
        /// Gets the <see cref="IDocumentResolver"/>.
        /// </summary>
        protected IDocumentResolver DocumentResolver => this.documentResolver is IDocumentResolver dr ? dr : throw new InvalidOperationException("The document resolver was not set.");

        /// <summary>
        /// Gets the <see cref="Stack{T}"/> of <see cref="JsonDocument"/>.
        /// </summary>
        protected Stack<JsonDocument> DocumentStack => this.documentStack is Stack<JsonDocument> stack ? stack : throw new InvalidOperationException("The document stack was not set.");

        /// <summary>
        /// Push the current path element onto the stack.
        /// </summary>
        /// <param name="path">The path element to add.</param>
        protected void PushPointerElement(string path)
        {
            this.pathList.Add("/" + path);
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
        protected void PushPointerElementForSchemaOrReference(Schema.SchemaOrReference schemaOrReference)
        {
            if (schemaOrReference.IsSchemaReference)
            {
                var jsonref = new JsonRef(schemaOrReference.AsSchemaReference().Ref);
                this.PushPointerElement(jsonref.HasPointer ? jsonref.Pointer.ToString() : "#");
            }
        }
    }
}
