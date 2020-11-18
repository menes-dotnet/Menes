// <copyright file="JsonSchemaBuilder.ElementResolution.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Diagnostics.CodeAnalysis;
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
        /// Gets the absolute location for a given schema element.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This peeks the absolute keyword location off the stack, and applies the $id for the schema if present.
        /// </para>
        /// <para>
        /// It is used by the Type building when looking for schema in properties.
        /// </para>
        /// </remarks>
        private JsonReference GetLocationForSchemaElement(JsonElement schema)
        {
            JsonReference baseReference = this.absoluteKeywordLocationStack.Peek();
            if (schema.ValueKind == JsonValueKind.Object && schema.TryGetProperty("$id", out JsonElement dollarid) && dollarid.ValueKind == JsonValueKind.String)
            {
                return baseReference.Apply(new JsonReference(dollarid.GetString()));
            }

            return baseReference;
        }

        /// <summary>
        /// Find the element at the given absolute location, loading it using the <see cref="IDocumentResolver"/>
        /// if it is not already resolved.
        /// </summary>
        /// <remarks>
        /// <para>This is used by the schema walker to find referenced elements by their absolute location.</para>
        /// <para>
        /// If the reference cannot be resolved, it is pushed onto the <see cref="unresolvedElements"/> stack.
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
            if (this.TryGetResolvedElement(absoluteLocation, out LocatedElement resolvedElement))
            {
                return resolvedElement.JsonElement;
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
        /// This is used by both the schema resolution and the type building to find
        /// a previously located element by its absolute location.
        /// </summary>
        private bool TryGetResolvedElement(JsonReference absoluteLocation, [NotNullWhen(true)] out LocatedElement element)
        {
            if (this.anchors.TryGetValue(absoluteLocation, out element))
            {
                return true;
            }

            if (this.locatedElementsByLocation.TryGetValue(absoluteLocation, out element))
            {
                return true;
            }

            element = default;
            return false;
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
            JsonReference current = this.absoluteKeywordLocationStack.Peek();

            // Work up the stack, skipping the first one.
            foreach (JsonReference reference in this.absoluteKeywordLocationStack.Skip(1))
            {
                if (reference == "#")
                {
                    return reference;
                }

                if (!reference.HasFragment)
                {
                    if (reference != current)
                    {
                        return reference;
                    }

                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// This looks through the unresolved elements list that was created during the walk of the schema,
        /// and removes any that were resolved later.
        /// </summary>
        private void ValidateUnresolvedElements()
        {
            // Strip out any that have been subsequentyl identified by anchor or ID.
            foreach (string reference in this.unresolvedElements.ToList())
            {
                if (this.anchors.ContainsKey(reference) || this.locatedElementsByLocation.ContainsKey(reference))
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
