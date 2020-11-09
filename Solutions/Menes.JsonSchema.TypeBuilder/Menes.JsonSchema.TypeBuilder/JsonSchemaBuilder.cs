// <copyright file="JsonSchemaBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private readonly Dictionary<string, LocatedElement> locatedElements = new Dictionary<string, LocatedElement>();
        private readonly Dictionary<string, LocatedElement> builtElements = new Dictionary<string, LocatedElement>();
        private readonly Stack<string> keywordLocationStack = new Stack<string>();
        private readonly Stack<JsonReference> absoluteKeywordLocationStack = new Stack<JsonReference>();

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

            // Nothing for us to do if the named element has already been built (or we are currently building it).
            if (this.builtElements.ContainsKey(namedElement.AbsoluteKeywordLocation))
            {
                return;
            }

            // Add ourselves to the built element list,
            // and push ourselves onto the located
            this.builtElements.Add(namedElement.AbsoluteKeywordLocation, namedElement);
        }
    }
}
