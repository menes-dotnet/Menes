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
        /// <param name="baseAbsoluteKeywordLocation">A base absolute keyword locatoin for the schema.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// Use this overload when your base schema is not the root of a document, and you need to treat it
        /// as if it is located in place. Relative references may therefore be applied outside the scope
        /// of this element into its parent document.
        /// </para>
        /// <para>
        /// You may use this, for example, when referencing a schema element from an OpenAPI document.
        /// </para>
        /// </remarks>
        public async Task BuildEntity(JsonElement schema, JsonReference baseAbsoluteKeywordLocation)
        {
            this.absoluteKeywordLocationStack.Push(baseAbsoluteKeywordLocation);
            await this.BuildEntity(schema);
            this.absoluteKeywordLocationStack.Pop();
        }

        /// <summary>
        /// Attempts to build an entity for a <see cref="JsonElement"/> containing a schema.
        /// </summary>
        /// <param name="schema">The root schema for which to build the entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks>
        /// Use this overload when your base schema is not the root of a document, and you need to treat it
        /// as if it is located at the root of a document. Relative references may not, therefore be applied outside the scope
        /// of this element into its parent document, as it is as if that document does not exist.
        /// </remarks>
        public async Task BuildEntity(JsonElement schema)
        {
            LocatedElement rootElement = await this.WalkTreeAndLocateElementsFrom(schema).ConfigureAwait(false);

            // Verify that our schema walk and loading did not lead to any unresolved references.
            this.ValidateUnresolvedElements();

            // Nothing for us to do if the named element has already been built (or we are currently building it).
            if (this.builtDeclarationsByLocation.ContainsKey(rootElement.AbsoluteKeywordLocation))
            {
                return;
            }

            TypeDeclaration root = await this.CreateTypeDeclarations(rootElement).ConfigureAwait(false);
            TypeDeclaration loweredResult = root.Lower();
        }
    }
}
