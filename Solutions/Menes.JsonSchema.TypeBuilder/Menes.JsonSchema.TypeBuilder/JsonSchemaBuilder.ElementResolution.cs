// <copyright file="JsonSchemaBuilder.ElementResolution.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// Given a reference, get the absolute keyword location for the current context.
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
        /// <remarks>
        /// <para>
        /// If the reference cannot be resolved, it is pushed onto teh <see cref="unresolvedElements"/> stack.
        /// </para>
        /// <para>
        /// If the reference is resolved, it is removed from the <see cref="unresolvedElements"/> stack, if it was present.
        /// </para>
        /// <para>
        /// The caller can examine the <see cref="unresolvedElements"/> when the whole tree has been walked to determine if any
        /// elements remained unresolved.
        /// </para>
        /// </remarks>
        private async Task<JsonElement?> TryResolveElement(JsonReference absoluteLocation)
        {
            if (this.ids.TryGetValue(absoluteLocation, out LocatedElement elementById))
            {
                return elementById.JsonElement;
            }

            if (this.anchors.TryGetValue(absoluteLocation, out LocatedElement elementByAnchor))
            {
                return elementByAnchor.JsonElement;
            }

            if (this.locatedElementsByLocation.TryGetValue(absoluteLocation, out LocatedElement elementByLocation))
            {
                return elementByLocation.JsonElement;
            }

            // We need to load the element from the relevant document.
            JsonElement? element = await this.documentResolver.TryResolve(absoluteLocation).ConfigureAwait(false);
            if (element is null)
            {
                this.unresolvedElements.Add(absoluteLocation.ToString());
            }
            else
            {
                this.unresolvedElements.Remove(absoluteLocation.ToString());
            }

            return element;
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
                if (!reference.HasFragment)
                {
                    return reference;
                }
            }

            return null;
        }
    }
}
