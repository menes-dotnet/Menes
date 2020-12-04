// <copyright file="JsonSchemaWalker.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeModel
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;

    /// <summary>
    /// A walker for <see cref="Draft201909Schema"/>.
    /// </summary>
    internal class JsonSchemaWalker
    {
        /// <summary>
        /// The content type of Draft201909Schema elements.
        /// </summary>
        public const string Draft201909SchemaContent = "application/vnd.menes.jsonschemawalker.draft201909schemacontent";

        private readonly Dictionary<string, LocatedElement> anchoredSchema = new Dictionary<string, LocatedElement>();

        /// <summary>
        /// Register this with the given <see cref="JsonWalker"/>.
        /// </summary>
        /// <param name="walker">The walker with which to register this schema walker.</param>
        public void RegisterWith(JsonWalker walker)
        {
            walker.RegisterHandler(this.HandleElement);
            walker.RegisterResolver(this.ResolveReference);
        }

        private static Draft201909Schema EnsureDraft201909SchemaContent(LocatedElement referencedElement)
        {
            if (referencedElement.ContentType == JsonWalker.DefaultContent)
            {
                Draft201909Schema draft201909Schema = referencedElement.Element.As<Draft201909Schema>();
                if (draft201909Schema.Validate(ValidationContext.ValidContext).IsValid)
                {
                    return draft201909Schema;
                }
            }
            else if (referencedElement.ContentType != Draft201909SchemaContent)
            {
                throw new InvalidOperationException("A reference within Draft201909SchemaContent must be to Draft201909SchemaContent.");
            }

            return referencedElement.Element.As<Draft201909Schema>();
        }

        private async Task<LocatedElement?> ResolveReference(JsonWalker walker, JsonReference reference, bool isRecursiveReference, Func<Task<LocatedElement?>> resolve)
        {
            if (this.anchoredSchema.TryGetValue(reference, out LocatedElement value))
            {
                EnsureDraft201909SchemaContent(value);
                return this.ResolveRecursiveAnchor(walker, value, isRecursiveReference);
            }

            LocatedElement? resolvedElement = await resolve().ConfigureAwait(false);
            return this.ResolveRecursiveAnchor(walker, resolvedElement, isRecursiveReference);
        }

        private LocatedElement? ResolveRecursiveAnchor(JsonWalker walker, LocatedElement? locatedElement, bool isRecursiveReference)
        {
            if (locatedElement is null)
            {
                return default;
            }

            if (!isRecursiveReference)
            {
                return locatedElement;
            }

            // We can't resolve recursive anchors on non-schema content.
            if (locatedElement.ContentType != Draft201909SchemaContent)
            {
                return locatedElement;
            }

            LocatedElement? lastRecursiveAnchor = null;
            if (this.HasRecursiveAnchor(locatedElement))
            {
                // Enumerate the recursive anchors up the stack, skipping the start location
                foreach (LocatedElement item in walker.EnumerateLocationStack(1))
                {
                    if (this.HasRecursiveAnchor(item))
                    {
                        lastRecursiveAnchor = item;
                    }
                }
            }

            return lastRecursiveAnchor ?? locatedElement;
        }

        private bool HasRecursiveAnchor(LocatedElement locatedElement)
        {
            if (locatedElement.ContentType != Draft201909SchemaContent)
            {
                return false;
            }

            Draft201909Schema schema = locatedElement.Element.As<Draft201909Schema>();
            return schema.RecursiveAnchor is JsonBoolean recursiveAnchor && recursiveAnchor;
        }

        private async Task<bool> HandleElement(JsonWalker walker, JsonElement element)
        {
            Draft201909Schema schema = element.As<Draft201909Schema>();
            if (!schema.Validate(ValidationContext.ValidContext).IsValid)
            {
                return false;
            }

            // If it is valid as a schema, but empty apart from unkown extensions, we will not handle it.
            if (schema.EmptyButWithUnknownExtensions())
            {
                return false;
            }

            if (!schema.IsBoolean && !schema.IsObject)
            {
                return false;
            }

            // Tell the walker that this is our content.
            if (!walker.AddOrUpdateLocatedElement(element, Draft201909SchemaContent))
            {
                return true;
            }

            if (schema.Id is Draft201909MetaCore.IdValue id)
            {
                // Update the scope with the ID value
                walker.PushScopeToLocationStack(id);

                // And add our element at that scope too
                if (!walker.AddOrUpdateLocatedElement(element, Draft201909SchemaContent))
                {
                    walker.PopLocationStack();
                    return true;
                }
            }

            if (schema.Anchor is Draft201909MetaCore.AnchorValue anchor)
            {
                this.anchoredSchema.Add(anchor, walker.CurrentElement);
            }

            if (schema.Ref is JsonUriReference reference)
            {
                walker.PushPropertyToLocationStack("$ref");
                LocatedElement referencedElement = await walker.ResolveReference(new JsonReference(reference.GetUri().OriginalString), isRecursiveReference: false).ConfigureAwait(false);
                walker.AddOrUpdateLocatedElement(referencedElement);
                EnsureDraft201909SchemaContent(referencedElement);
                walker.PopLocationStack();
            }

            if (schema.RecursiveRef is JsonUriReference recursiveReference)
            {
                walker.PushPropertyToLocationStack("$recursiveRef");

                LocatedElement referencedElement = await walker.ResolveReference(new JsonReference(recursiveReference.GetUri().OriginalString), isRecursiveReference: true).ConfigureAwait(false);
                walker.AddOrUpdateLocatedElement(referencedElement);

                // Our resolver will have resolved this to a referenced element, taking into account the recursive reference element, so we
                // can now check that we've got a schema back.
                EnsureDraft201909SchemaContent(referencedElement);
                walker.PopLocationStack();
            }

            if (schema.IsObject)
            {
                // This is an object schema, not a boolean schema
                // so we will walk all our properties, giving every handler the chance to deal with it.
                await walker.WalkContentsOfObjectOrArray(schema.JsonElement).ConfigureAwait(false);
            }

            if (schema.Id is Draft201909MetaCore.IdValue)
            {
                // We pushed our ID onto the stack, so pop it back off again.
                walker.PopLocationStack();
            }

            return true;
        }
    }
}