// <copyright file="JsonSchemaBuilder.ElementResolution.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// Given a dollarref value, get the absolute keyword location for the current context.
        /// </summary>
        /// <param name="reference">The <c>$ref</c> or <c>$recursiveRef</c> value.</param>
        /// <returns>An absolute keyword location as a <see cref="JsonReference"/> formed by combining the given reference with the current absolute keyword location.</returns>
        private JsonReference GetAbsoluteKeywordLocation(JsonReference reference)
        {
            if (this.absoluteKeywordLocationStack.TryPeek(out JsonReference current))
            {
                return current.Apply(reference);
            }

            return reference;
        }

        /// <summary>
        /// Find the element at the given absolute location, loading it using the <see cref="IDocumentResolver"/>
        /// if it is not already resolved.
        /// </summary>
        private Task<JsonElement> ResolveElement(JsonReference absoluteLocation)
        {
            if (this.ids.TryGetValue(absoluteLocation, out LocatedElement elementById))
            {
                return Task.FromResult(elementById.JsonElement);
            }

            JsonReferenceBuilder location = absoluteLocation.AsBuilder();

            if (location.HasFragment && this.anchors.TryGetValue(location.Fragment.ToString(), out LocatedElement elementByAnchor))
            {
                return Task.FromResult(elementByAnchor.JsonElement);
            }

            if (this.locatedElementsByLocation.TryGetValue(absoluteLocation, out LocatedElement elementByLocation))
            {
                return Task.FromResult(elementByLocation.JsonElement);
            }

            // We need to load the element from the relevant document.
            return this.documentResolver.TryResolve(absoluteLocation).ContinueWith(t => t.Result ?? throw new ArgumentException("Unable to resolve the schema."));
        }

        /// <summary>
        /// <para>
        /// This find the first location below us in the stack that has a corresponding
        /// located entity.
        /// </para>
        /// <para>
        /// This will be treated as our parent entity location.
        /// </para>
        /// <para>
        /// We are expecting the top element on the Stack to be our current location.
        /// </para>
        /// </summary>
        private JsonReference? FindParentEntityLocation()
        {
            // Work up the stack, skipping the first one.
            foreach (JsonReference reference in this.absoluteKeywordLocationStack.Skip(1))
            {
                if (this.locatedElementsByLocation.TryGetValue(reference, out LocatedElement _))
                {
                    return reference;
                }
            }

            return null;
        }
    }
}
