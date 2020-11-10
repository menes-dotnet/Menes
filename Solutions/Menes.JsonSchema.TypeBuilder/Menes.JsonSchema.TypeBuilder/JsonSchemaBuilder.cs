// <copyright file="JsonSchemaBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private readonly Dictionary<string, TypeDeclaration> builtDeclarationsByLocation = new Dictionary<string, TypeDeclaration>();
        private readonly Stack<JsonReference> absoluteKeywordLocationStack = new Stack<JsonReference>();
        private readonly HashSet<string> unresolvedElements = new HashSet<string>();

        // Note that anchors are stored as a full reference, with the base uri of the root document combined with the anchor name.
        private readonly Dictionary<string, LocatedElement> anchors = new Dictionary<string, LocatedElement>();

        private readonly Dictionary<string, LocatedElement> ids = new Dictionary<string, LocatedElement>();
        private readonly Dictionary<string, LocatedElement> locatedElementsByLocation = new Dictionary<string, LocatedElement>();

        private readonly IDocumentResolver documentResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaBuilder"/> class.
        /// </summary>
        /// <param name="documentResolver">The <see cref="IDocumentResolver"/> to use to pull down referenced schema.</param>
        public JsonSchemaBuilder(IDocumentResolver documentResolver)
        {
            this.documentResolver = documentResolver;
        }

        /// <summary>
        /// Attempts to build an entity for a <see cref="JsonElement"/> containing a schema.
        /// </summary>
        /// <param name="schema">The root schema for which to build the entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task BuildEntity(JsonElement schema)
        {
            LocatedElement namedElement = await this.GetOrCreateLocatedElement(schema).ConfigureAwait(false);

            // Verify that our schema walk and loading did not lead to any unresolved references.
            this.ValidateUnresolvedElements();

            // Nothing for us to do if the named element has already been built (or we are currently building it).
            if (this.builtDeclarationsByLocation.ContainsKey(namedElement.AbsoluteKeywordLocation))
            {
                return;
            }

            TypeDeclaration builtElement = await this.BuildTypeDeclaration(namedElement).ConfigureAwait(false);
        }

        private void ValidateUnresolvedElements()
        {
            // Strip out any that have been subsequentyl identified by anchor or ID.
            foreach (string reference in this.unresolvedElements.ToList())
            {
                if (this.ids.ContainsKey(reference) || this.anchors.ContainsKey(reference) || this.locatedElementsByLocation.ContainsKey(reference))
                {
                    this.unresolvedElements.Remove(reference);
                }
            }

            if (this.unresolvedElements.Count > 0)
            {
                throw new InvalidOperationException(this.BuildUnresolvedElementsError());
            }
        }

        private string BuildUnresolvedElementsError()
        {
            var builder = new StringBuilder();
            builder.AppendLine("The schema has unresolved references:");
            foreach (string reference in this.unresolvedElements)
            {
                builder.AppendLine(reference);
            }

            return builder.ToString();
        }
    }
}
