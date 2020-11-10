// <copyright file="JsonSchemaBuilder.WalkTreeAndLocateElements.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
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
        /// Walk the tree from the given schema, creating <see cref="LocatedElement"/> instances from that schema.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This makes a depth-first walk of the element to find all its contained elements, follows and resolves references (loading external schema if appropriate).
        /// </para>
        /// <para>
        /// At the end of this we know we have a referentially sound schema, with canonical resolution of all the references, via anchors and IDs.
        /// </para>
        /// </remarks>
        private async Task<LocatedElement> WalkTreeAndLocateElementsFrom(JsonElement schema)
        {
            JsonReference? inplaceReference = null;
            string? dollaranchor = null;
            string? dollarid = null;
            bool updatedAbsoluteKeywordLocationStack;
            LocatedElement createdElement;

            if (schema.ValueKind == JsonValueKind.Object)
            {
                if (schema.TryGetProperty("$id", out JsonElement dollaridElement))
                {
                    ValidateDollarId(dollaridElement);
                    dollarid = dollaridElement.GetString();
                }

                if (schema.TryGetProperty("$anchor", out JsonElement dollaranchorElement))
                {
                    dollaranchor = dollaranchorElement.GetString();
                }

                updatedAbsoluteKeywordLocationStack = this.UpdateKeywordLocationStacks(JsonReference.FromEncodedJsonString(dollarid));
                bool recursiveReference = false;

                if (this.absoluteKeywordLocationStack.TryPeek(out JsonReference peekedLocation) && this.locatedElementsByLocation.TryGetValue(peekedLocation, out LocatedElement previousInstance))
                {
                    return previousInstance;
                }

                createdElement = this.CreateLocatedElement(schema, dollarid, dollaranchor);

                foreach (JsonProperty property in schema.EnumerateObject())
                {
                    this.PushPropertyToAbsoluteKeywordLocationStack(property);

                    // We treat all refs as if they could be recursive.
                    if (property.NameEquals("$ref"))
                    {
                        ValidateDollarRef(property);

                        inplaceReference = JsonReference.FromEncodedJsonString(property.Value.GetString());
                    }
                    else if (property.NameEquals("$recursiveRef"))
                    {
                        ValidateDollarRecursiveRef(property);
                        recursiveReference = true;
                        inplaceReference = JsonReference.FromEncodedJsonString(property.Value.GetString());
                    }
                    else if (property.NameEquals("properties") || property.NameEquals("patternProperties") || property.NameEquals("dependentSchemas") || property.NameEquals("$defs"))
                    {
                        ValidateObjectWithSchemaProperties(property);
                        foreach (JsonProperty schemaProperty in property.Value.EnumerateObject())
                        {
                            this.PushPropertyToAbsoluteKeywordLocationStack(schemaProperty);
                            ValidateSchema(schemaProperty);
                            await this.WalkTreeAndLocateElementsFrom(schemaProperty.Value).ConfigureAwait(false);
                            this.absoluteKeywordLocationStack.Pop();
                        }
                    }
                    else if (property.NameEquals("anyOf") || property.NameEquals("allOf") || property.NameEquals("oneOf"))
                    {
                        ValidateSchemaArray(property);
                        await EnumerateSchemaArray(property).ConfigureAwait(false);
                    }
                    else if (property.NameEquals("items"))
                    {
                        ValidateSchemaOrArrayOfSchema(property);
                        if (property.Value.ValueKind == JsonValueKind.Array)
                        {
                            await EnumerateSchemaArray(property).ConfigureAwait(false);
                        }
                        else if (property.Value.ValueKind == JsonValueKind.Object || property.Value.ValueKind == JsonValueKind.True || property.Value.ValueKind == JsonValueKind.False)
                        {
                            await this.WalkTreeAndLocateElementsFrom(property.Value).ConfigureAwait(false);
                        }
                    }
                    else if (property.NameEquals("not") ||
                        property.NameEquals("if") || property.NameEquals("then") || property.NameEquals("else") ||
                        property.NameEquals("additionalItems") || property.NameEquals("unevaluatedItems") || property.NameEquals("contains") ||
                        property.NameEquals("additionalProperties") || property.NameEquals("unevaluatedProperties") || property.NameEquals("propertyNames"))
                    {
                        ValidateSchema(property);
                        await this.WalkTreeAndLocateElementsFrom(property.Value).ConfigureAwait(false);
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }

                // If this is "just" a reference, with no other composing
                // content, then just follow the reference, unless there aren't yet any references and we're trying to get the root element
                if (!recursiveReference && inplaceReference is JsonReference reference)
                {
                    await this.GetOrCreateLocatedElement(reference).ConfigureAwait(false);
                }
            }
            else
            {
                updatedAbsoluteKeywordLocationStack = this.UpdateKeywordLocationStacks(null);
                createdElement = this.CreateLocatedElement(schema, dollarid, dollaranchor);
            }

            try
            {
                return createdElement;
            }
            finally
            {
                if (updatedAbsoluteKeywordLocationStack)
                {
                    this.absoluteKeywordLocationStack.Pop();
                }
            }

            async Task EnumerateSchemaArray(JsonProperty property)
            {
                int arrayIndex = 0;
                foreach (JsonElement element in property.Value.EnumerateArray())
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(arrayIndex);
                    ValidateSchema(element);
                    await this.WalkTreeAndLocateElementsFrom(element).ConfigureAwait(false);
                    this.absoluteKeywordLocationStack.Pop();
                    arrayIndex++;
                }
            }
        }

        private void PushPropertyToAbsoluteKeywordLocationStack(string unencodedPropertyName)
        {
            if (this.absoluteKeywordLocationStack.TryPeek(out JsonReference current))
            {
                this.absoluteKeywordLocationStack.Push(current.AppendUnencodedPropertyNameToFragment(unencodedPropertyName));
            }
            else
            {
                this.absoluteKeywordLocationStack.Push(JsonReference.FromUriAndUnencodedPropertyName("/", unencodedPropertyName));
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

        private void PushArrayIndexToAbsoluteKeywordLocationStack(int index)
        {
            if (this.absoluteKeywordLocationStack.TryPeek(out JsonReference current))
            {
                this.absoluteKeywordLocationStack.Push(current.AppendUnencodedPropertyNameToFragment($"{index}"));
            }
            else
            {
                this.absoluteKeywordLocationStack.Push(JsonReference.FromUriAndUnencodedPropertyName("/", $"{index}"));
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
            this.locatedElementsByLocation.Add(result.AbsoluteKeywordLocation, result);
            if (anchor is string anchorFragment)
            {
                // Turn the anchor into a fragment for a URI based on the current absolute URI
                // to distinguish fragments anchors with the same name in different contexts.
                var absoluteAnchor = new JsonReference((id ?? (parentLocation is JsonReference pl ? pl.Uri.ToString() : null) ?? string.Empty) + "#" + anchorFragment);
                this.anchors.Add(absoluteAnchor, result);
            }

            return result;
        }

        /// <summary>
        /// Updates the <see cref="absoluteKeywordLocationStack"/>
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
            else if (dollarid is JsonReference did)
            {
                this.absoluteKeywordLocationStack.Push(did);
                updated = true;
            }
            else
            {
                this.absoluteKeywordLocationStack.Push(new JsonReference("#"));
                updated = true;
            }

            return updated;
        }

        /// <summary>
        /// <para>
        /// In this method we push the fact we are following the refernce reference to the keyword location stack,
        /// using the required #/$ref/[ref/er/ence] syntax,, then either make a nested call into <see cref="WalkTreeAndLocateElementsFrom(JsonElement)"/>
        /// to follow our reference (which will, of course, push more onto the stack, then pop back up), or retrieve
        /// the existing item from the cache (which will not require us to go down the stack further).
        /// </para>
        /// <para>
        /// This method must be called *after* the absolute keyword location for the current reference
        /// as been pushed onto the stack (as is the case when called from <see cref="WalkTreeAndLocateElementsFrom(JsonElement)"/>.
        /// </para>
        /// </summary>
        private async Task<LocatedElement?> GetOrCreateLocatedElement(JsonReference reference)
        {
            JsonReference absoluteLocation = this.GetAbsoluteKeywordLocation(reference);

            ////if (absoluteLocation == "#")
            ////{
            ////    // Self referential, so peek the item off the stack
            ////    if (this.locatedElementsByLocation.TryGetValue(absoluteLocation, out LocatedElement locatedElement))
            ////    {
            ////        return locatedElement;
            ////    }
            ////    else
            ////    {
            ////        return null;
            ////    }
            ////}

            if (this.anchors.TryGetValue(absoluteLocation, out LocatedElement anchoredElement))
            {
                return anchoredElement;
            }

            if (this.locatedElementsByLocation.TryGetValue(absoluteLocation, out LocatedElement referencedElement))
            {
                return referencedElement;
            }

            JsonElement? resolvedElementOrNull = await this.TryResolveElement(absoluteLocation).ConfigureAwait(false);
            if (resolvedElementOrNull is not JsonElement resolvedElement)
            {
                return null;
            }

            this.absoluteKeywordLocationStack.Push(absoluteLocation);

            try
            {
                return await this.WalkTreeAndLocateElementsFrom(resolvedElement).ConfigureAwait(false);
            }
            finally
            {
                this.absoluteKeywordLocationStack.Pop();
            }
        }
    }
}
