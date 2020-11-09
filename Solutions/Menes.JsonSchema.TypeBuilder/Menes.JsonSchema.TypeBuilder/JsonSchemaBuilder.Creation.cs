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
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// Build a named element, update the relevant location stacks, and the <see cref="locatedElements"/> list.
        /// </summary>
        private async Task<LocatedElement> GetOrCreateLocatedElement(JsonElement schema)
        {
            int propertyCount = 0;
            JsonReference? inplaceReference = null;
            string? dollaranchor = null;
            string? dollarid = null;
            bool updatedAbsoluteKeywordLocationStack;
            if (schema.ValueKind == JsonValueKind.Object)
            {
                if (schema.TryGetProperty("$id", out JsonElement dollaridElement))
                {
                    dollarid = dollaridElement.GetString();
                }

                updatedAbsoluteKeywordLocationStack = this.UpdateKeywordLocationStacks(dollarid);
                bool recursiveReference = false;

                foreach (JsonProperty property in schema.EnumerateObject())
                {
                    this.keywordLocationStack.Push(property.Name);
                    this.PushPropertyToAbsoluteKeywordLocationStack(property);

                    // We treat all refs as if they could be recursive.
                    if (property.NameEquals("$ref"))
                    {
                        ValidateDollarRef(property);

                        inplaceReference = property.Value.GetString();
                    }
                    else if (property.NameEquals("$recursiveRef"))
                    {
                        ValidateDollarRecursiveRef(property);
                        recursiveReference = true;
                        inplaceReference = property.Value.GetString();
                    }
                    else if (property.NameEquals("$anchor"))
                    {
                        ValidateDollarAnchor(property);
                        dollaranchor = property.Value.GetString();
                    }

                    if (!property.NameEquals("$defs"))
                    {
                        propertyCount++;
                    }

                    if (property.Value.ValueKind == JsonValueKind.Object)
                    {
                        await this.GetOrCreateLocatedElement(property.Value).ConfigureAwait(false);
                    }

                    this.keywordLocationStack.Pop();
                    this.absoluteKeywordLocationStack.Pop();
                }

                // If this is "just" a reference, with no other composing
                // content, then just follow the reference.
                if (!recursiveReference && propertyCount == 1 && inplaceReference is JsonReference reference)
                {
                    return await this.GetOrCreateLocatedElement(reference).ConfigureAwait(false);
                }
            }
            else
            {
                updatedAbsoluteKeywordLocationStack = this.UpdateKeywordLocationStacks(null);
            }

            try
            {
                return this.CreateLocatedElement(schema, dollarid, dollaranchor);
            }
            finally
            {
                if (updatedAbsoluteKeywordLocationStack)
                {
                    this.absoluteKeywordLocationStack.Pop();
                }
            }
        }

        private void PushPropertyToAbsoluteKeywordLocationStack(JsonProperty property)
        {
            if (this.absoluteKeywordLocationStack.TryPeek(out JsonReference current))
            {
                this.absoluteKeywordLocationStack.Push(current.AppendUnencodedPropertyNameToFragment(property.Name));
            }
            else
            {
                this.absoluteKeywordLocationStack.Push(JsonReference.FromUriAndUnencodedPropertyName("/", property.Name));
            }
        }

        /// <summary>
        /// Creates a located element using the location on the <see cref="absoluteKeywordLocationStack"/>,
        /// and adds it to the <see cref="locatedElementsByLocation"/> map.
        /// </summary>
        private LocatedElement CreateLocatedElement(JsonElement schema, string? id, string? anchor)
        {
            JsonReference? parentLocation = this.FindParentEntityLocation();
            var result = new LocatedElement(parentLocation, this.absoluteKeywordLocationStack.Peek(), schema);
            this.locatedElements.Add(result.AbsoluteKeywordLocation, result);
            this.locatedElementsByLocation.Add(result.AbsoluteKeywordLocation, result);
            if (anchor is string anchorFragment)
            {
                // Turn the anchor into a fragment for a URI based on the current absolute URI
                // to distinguish fragments anchors with the same name in different contexts.
                JsonReference absoluteAnchor = (id ?? (parentLocation is JsonReference pl ? pl.Uri.ToString() : null) ?? string.Empty) + "#" + anchorFragment;
                this.anchors.Add(absoluteAnchor, result);
            }

            return result;
        }

        /// <summary>
        /// Updates the <see cref="keywordLocationStack"/> and the <see cref="absoluteKeywordLocationStack"/>
        /// using the optional relative or absolute reference.
        /// </summary>
        /// <returns>True if we updated the absolute keyword location stack.</returns>
        private bool UpdateKeywordLocationStacks(JsonReference? dollarid)
        {
            bool updated = false;
            if (this.absoluteKeywordLocationStack.TryPeek(out JsonReference currentLocation))
            {
                if (dollarid is JsonReference did)
                {
                    this.absoluteKeywordLocationStack.Push(currentLocation.Apply(did));
                    updated = true;
                }
            }
            else
            {
                this.absoluteKeywordLocationStack.Push("#");
                updated = true;
            }

            this.keywordLocationStack.Push("#");
            return updated;
        }

        /// <summary>
        /// <para>
        /// In this method we push the fact we are following the refernce reference to the keyword location stack,
        /// using the required #/$ref/[ref/er/ence] syntax,, then either make a nested call into <see cref="GetOrCreateLocatedElement(JsonElement)"/>
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
            JsonReference absoluteLocation = this.GetAbsoluteKeywordLocation(reference);

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

                if (this.anchors.TryGetValue(absoluteLocation, out LocatedElement anchoredElement))
                {
                    return Task.FromResult(anchoredElement);
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
