// <copyright file="JsonSchemaBuilder.Creation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// Build a named element, and update the relevant stacks, and the <see cref="locatedElements"/> list.
        /// </summary>
        private async Task<LocatedElement> GetOrCreateLocatedElement(JsonElement schema)
        {
            // TODO: We also need to walk the tree here and build all the anchors and IDs
            // in this element. If we find the element in the anchors and ids already
            // we can stop looking inside, as it must have been done by a parent.
            int propertyCount = 0;
            JsonReference? inPlacereference = null;
            JsonReference? dollarid = null;
            foreach (JsonProperty property in schema.EnumerateObject())
            {
                // We treat all refs as if they could be recursive.
                // However, an actuall $recursiveRef lets us shortcut
                // that decision making.
                if (property.NameEquals("$ref"))
                {
                    ValidateDollarRef(property);

                    inPlacereference = property.Value.GetString();
                }
                else if (property.NameEquals("$recursiveRef"))
                {
                    ValidateDollarRecursiveRef(property);

                    inPlacereference = property.Value.GetString();
                }
                else if (property.NameEquals("$defs") || property.NameEquals("title") || property.NameEquals("decription"))
                {
                    continue;
                }
                else if (property.NameEquals("$id"))
                {
                    ValidateDollarId(property);
                    dollarid = property.Value.GetString();
                }

                propertyCount++;
            }

            this.UpdateKeywordLocationStacks(dollarid);

            // If this is "just" a reference, with no other composing
            // content, then just follow the reference.
            if (propertyCount == 1 && inPlacereference is JsonReference reference)
            {
                return await this.GetOrCreateLocatedElement(reference).ConfigureAwait(false);
            }

            return this.CreateLocatedELement(schema);
        }

        /// <summary>
        /// Creates a located element using the location on the <see cref="absoluteKeywordLocationStack"/>,
        /// and adds it to the <see cref="locatedElementsByLocation"/> map.
        /// </summary>
        private LocatedElement CreateLocatedELement(JsonElement schema)
        {
            JsonReference? parentLocation = this.FindParentEntityLocation();
            var result = new LocatedElement(parentLocation, this.absoluteKeywordLocationStack.Peek(), schema);
            this.locatedElements.Add(result);
            this.locatedElementsByLocation.Add(result.AbsoluteKeywordLocation, result);
            return result;
        }

        /// <summary>
        /// Updates the <see cref="keywordLocationStack"/> and the <see cref="absoluteKeywordLocationStack"/>
        /// using the optional relative or absolute reference.
        /// </summary>
        private void UpdateKeywordLocationStacks(JsonReference? dollarid)
        {
            JsonReference currentLocation = this.absoluteKeywordLocationStack.Peek();
            JsonReference newLocation = currentLocation;

            if (dollarid is JsonReference did)
            {
                newLocation = currentLocation.Apply(did);
            }

            this.keywordLocationStack.Push("#");
            this.absoluteKeywordLocationStack.Push(newLocation);
        }

        /// <summary>
        /// <para>
        /// In this method we push to the keyword location stack and the absolute keyword location
        /// stack for this locale, then either make a nested call into GetOrCreateLocatedElement
        /// to follow our reference (which will, of course, push more onto the stack, then pop back up), or retrieve
        /// the existing item from the cache (which will not require us to go down the stack further).
        /// </para>
        /// <para>
        /// This method must be called *after* the absolute keyword location for the current reference
        /// as been pushed onto the stack (as is the case when called from <see cref="GetOrCreateLocatedElement(JsonElement)"/>.
        /// </para>
        /// </summary>
        private Task<LocatedElement> GetOrCreateLocatedElement(JsonReference reference)
        {
            try
            {
                var keywordPath = new StringBuilder("#");
                keywordPath.Append("/$ref");

                ReadOnlySpan<char> fragment = reference.Fragment;

                if (fragment.Length > 0)
                {
                    keywordPath.Append("/");
                    keywordPath.Append(fragment);
                }

                this.keywordLocationStack.Push(keywordPath.ToString());

                JsonReference absoluteLocation = this.GetAbsoluteKeywordLocation(reference);
                this.absoluteKeywordLocationStack.Push(absoluteLocation);

                if (reference == "#")
                {
                    // Self referential, so peek the item off the stack
                    if (this.locatedElementsByLocation.TryGetValue(absoluteLocation, out LocatedElement locatedElement))
                    {
                        return Task.FromResult(locatedElement);
                    }
                    else
                    {
                        throw new InvalidOperationException("The root element cannot be an in-place self reference.");
                    }
                }

                if (this.locatedElementsByLocation.TryGetValue(absoluteLocation, out LocatedElement referencedElement))
                {
                    return Task.FromResult(referencedElement);
                }

                return this.ResolveElement(absoluteLocation).ContinueWith(t => this.GetOrCreateLocatedElement(t.Result)).Unwrap();
            }
            catch (Exception ex)
            {
                return Task.FromException<LocatedElement>(ex);
            }
        }
    }
}
