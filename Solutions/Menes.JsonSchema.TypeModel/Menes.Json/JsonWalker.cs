﻿// <copyright file="JsonWalker.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Walks a JsonElement to identify and locate entities with particular types.
    /// </summary>
    public class JsonWalker
    {
        /// <summary>
        /// Gets the default content type.
        /// </summary>
        public const string DefaultContent = "application/vnd.menes.element-default";

        private readonly List<Func<JsonWalker, JsonElement, Task<bool>>> handlers = new List<Func<JsonWalker, JsonElement, Task<bool>>>();
        private readonly List<Func<JsonWalker, JsonReference, bool, Func<Task<LocatedElement?>>, Task<LocatedElement?>>> resolvers = new List<Func<JsonWalker, JsonReference, bool, Func<Task<LocatedElement?>>, Task<LocatedElement?>>>();

        private readonly Dictionary<string, LocatedElement> locatedElements = new Dictionary<string, LocatedElement>();

        private readonly Stack<string> scopedLocationStack = new Stack<string>();
        private readonly IDocumentResolver documentResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonWalker"/> class.
        /// </summary>
        /// <param name="documentResolver">The document resolver to use.</param>
        /// <param name="baseLocation">The initial base location.</param>
        public JsonWalker(IDocumentResolver documentResolver, string baseLocation = "#")
        {
            this.scopedLocationStack.Push(baseLocation);
            this.handlers.Add(DefaultHandler);
            this.resolvers.Add(DefaultResolver);
            this.documentResolver = documentResolver;
        }

        /// <summary>
        /// Gets the element at the current scoped location.
        /// </summary>
        public LocatedElement CurrentElement
        {
            get
            {
                return this.locatedElements[this.scopedLocationStack.Peek()];
            }
        }

        /// <summary>
        /// Enumerate the located elements.
        /// </summary>
        /// <returns>An enumerable of the located elements.</returns>
        public IEnumerable<LocatedElement> EnumerateLocatedElements()
        {
            foreach (KeyValuePair<string, LocatedElement> element in this.locatedElements)
            {
                yield return element.Value;
            }
        }

        /// <summary>
        /// Walks the contents of an object or array.
        /// </summary>
        /// <param name="element">The content to walk.</param>
        /// <returns>A <see cref="Task"/> which completes once the walk is complete.</returns>
        /// <remarks>This is used by handlers to walk into their object properties or array members.</remarks>
        public async Task WalkContentsOfObjectOrArray(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null || element.ValueKind == JsonValueKind.Undefined)
            {
                // Silently ignore nulls and undefineds.
                return;
            }

            if (element.ValueKind == JsonValueKind.Object)
            {
                JsonElement.ObjectEnumerator enumerator = element.EnumerateObject();

                while (enumerator.MoveNext())
                {
                    this.PushPropertyToLocationStack(enumerator.Current.Name);
                    await this.WalkElement(enumerator.Current.Value).ConfigureAwait(false);
                    this.PopLocationStack();
                }
            }
            else if (element.ValueKind == JsonValueKind.Array)
            {
                JsonElement.ArrayEnumerator enumerator = element.EnumerateArray();

                int index = 0;
                while (enumerator.MoveNext())
                {
                    this.PushArrayIndexToLocationStack(index);
                    await this.WalkElement(enumerator.Current).ConfigureAwait(false);
                    this.PopLocationStack();
                    ++index;
                }
            }
            else
            {
                throw new ArgumentException("The element must be an object or an array", nameof(element));
            }
        }

        /// <summary>
        /// Gets a previously located element.
        /// </summary>
        /// <param name="location">The location for which to find the element.</param>
        /// <returns>The located element.</returns>
        public LocatedElement GetLocatedElement(string location)
        {
            if (this.locatedElements.TryGetValue(location, out LocatedElement value))
            {
                return value;
            }

            throw new ArgumentException($"Unable to find the element at location '{location}'", nameof(location));
        }

        /// <summary>
        /// Register a handler with the schema walker.
        /// </summary>
        /// <param name="handler">The handler to register.</param>
        /// <remarks>
        /// This function will be called to attempt to handle the element at the
        /// given location. It will be provided the <see cref="JsonWalker"/> and the
        /// <see cref="JsonElement"/> being handled. It should return a <see cref="Task{TResult}"/>
        /// with a <see cref="bool"/> that indicates whether we handled the element.
        /// </remarks>
        public void RegisterHandler(Func<JsonWalker, JsonElement, Task<bool>> handler)
        {
            this.handlers.Insert(this.handlers.Count - 1, handler);
        }

        /// <summary>
        /// Registers a resolver with the schema walker.
        /// </summary>
        /// <param name="resolver">The resovler function to resolve a reference.</param>
        /// <remarks>
        /// This function will be provided with the <see cref="JsonWalker"/>, the <see cref="JsonReference"/> to resolve,
        /// and a function to call if you wish to delegate this resolution on to other handlers in the chain, and then work
        /// on that element that has been returned. It returns a <see cref="Task{TResult}"/> which, when complete, provides
        /// the <see cref="LocatedElement"/> or <c>null</c> if the element could not be located.
        /// </remarks>
        public void RegisterResolver(Func<JsonWalker, JsonReference, bool, Func<Task<LocatedElement?>>, Task<LocatedElement?>> resolver)
        {
            this.resolvers.Insert(this.resolvers.Count - 1, resolver);
        }

        /// <summary>
        /// Enumerate the located elements in the location stack.
        /// </summary>
        /// <param name="skip">The number of items to skip of the top of the stack before starting enumeration.</param>
        /// <returns>An enumerable of elements in the located element stack.</returns>
        public IEnumerable<LocatedElement> EnumerateLocationStack(int skip = 0)
        {
            foreach (string location in this.scopedLocationStack.Skip(skip))
            {
                if (this.locatedElements.TryGetValue(location, out LocatedElement value))
                {
                    yield return value;
                }
                else
                {
                    throw new InvalidOperationException($"Unable to find the element for the location '{location}'.");
                }
            }
        }

        /// <summary>
        /// Adds or updates a located element in the cache.
        /// </summary>
        /// <param name="element">The element we have located.</param>
        /// <param name="contentType">The content type to associate with the element.</param>
        /// <remarks>This is used by handlers to add an element they have located to the location cache.</remarks>
        /// <returns><c>True</c> if this added or updated the element, otherwise false.</returns>
        public bool AddOrUpdateLocatedElement(JsonElement element, string contentType)
        {
            string location = this.scopedLocationStack.Peek();
            if (this.locatedElements.TryGetValue(location, out LocatedElement value))
            {
                return value.Update(element, contentType);
            }
            else
            {
                this.locatedElements.Add(location, new LocatedElement(location, element, contentType));
                return true;
            }
        }

        /// <summary>
        /// Adds or updates a located element in the cache.
        /// </summary>
        /// <param name="locatedElement">The previously located element which is now being referenced at this location.</param>
        /// <remarks>This is used by handlers to add an element they have previously located to a new place in the location cache.</remarks>
        public void TryAddLocatedElement(LocatedElement locatedElement)
        {
            string location = this.scopedLocationStack.Peek();
            if (!this.locatedElements.ContainsKey(location))
            {
                this.locatedElements.Add(location, locatedElement);
            }
        }

        /// <summary>
        /// Walks the schema and identifies referenced elements.
        /// </summary>
        /// <param name="element">The element to walk.</param>
        /// <returns>A <see cref="Task"/> which completes once the elements have been walked.</returns>
        public async Task WalkElement(JsonElement element)
        {
            foreach (Func<JsonWalker, JsonElement, Task<bool>>? handler in this.handlers)
            {
                if (await handler(this, element).ConfigureAwait(false))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Resolve the reference at the given uri-reference.
        /// </summary>
        /// <param name="reference">The reference to resolve.</param>
        /// <param name="isRecursiveReference">True if the reference is recursive.</param>
        /// <returns>A <see cref="Task"/> which completes when the reference is resolved, providing the location of the resolved element.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "GetEnumerator() produces a long and complicated enumerator type that obscures the intent.")]
        public async Task<LocatedElement> ResolveReference(JsonReference reference, bool isRecursiveReference)
        {
            // The current location is the current place in the stack, with the reference applied.
            var currentLocation = new JsonReference(this.scopedLocationStack.Peek()).Apply(reference);

            var enumerator = this.resolvers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var result = await enumerator.Current(this, currentLocation, isRecursiveReference, () => RecursivelyResolve(enumerator, this, currentLocation, isRecursiveReference)).ConfigureAwait(false);
                if (result != null)
                {
                    return result;
                }
            }

            throw new ArgumentException("Unable to resolve reference.", nameof(reference));
        }

        /// <summary>
        /// Pop the current location stack.
        /// </summary>
        public void PopLocationStack()
        {
            this.scopedLocationStack.Pop();
        }

        /// <summary>
        /// Push the given (unencoded) property name to the location stack.
        /// </summary>
        /// <param name="name">The unencoded property name to push to the stack.</param>
        public void PushPropertyToLocationStack(string name)
        {
            var currentLocation = new JsonReference(this.scopedLocationStack.Peek());
            this.scopedLocationStack.Push(currentLocation.AppendUnencodedPropertyNameToFragment(name));
        }

        /// <summary>
        /// Push the given array index to the location stack.
        /// </summary>
        /// <param name="index">The array index to push to the stack.</param>
        public void PushArrayIndexToLocationStack(int index)
        {
            var currentLocation = new JsonReference(this.scopedLocationStack.Peek());
            this.scopedLocationStack.Push(currentLocation.AppendArrayIndexToFragment(index));
        }

        /// <summary>
        /// Push the given scope change to the location stack.
        /// </summary>
        /// <param name="scope">The scope change to push to the stack.</param>
        public void PushScopeToLocationStack(string scope)
        {
            var currentLocation = new JsonReference(this.scopedLocationStack.Peek());
            this.scopedLocationStack.Push(currentLocation.Apply(new JsonReference(scope)));
        }

        private static Task<LocatedElement?> RecursivelyResolve(List<Func<JsonWalker, JsonReference, bool, Func<Task<LocatedElement?>>, Task<LocatedElement?>>>.Enumerator enumerator, JsonWalker walker, JsonReference reference, bool isRecursiveReference)
        {
            if (enumerator.MoveNext())
            {
                return enumerator.Current(walker, reference, isRecursiveReference, () => RecursivelyResolve(enumerator, walker, reference, isRecursiveReference));
            }

            return Task.FromResult<LocatedElement?>(default);
        }

        private static async Task<LocatedElement?> DefaultResolver(JsonWalker walker, JsonReference reference, bool isRecursiveReference, Func<Task<LocatedElement?>> resolve)
        {
            if (walker.locatedElements.TryGetValue(reference, out LocatedElement element))
            {
                return element;
            }

            JsonElement? jsonElement = await walker.documentResolver.TryResolve(reference).ConfigureAwait(false);
            if (jsonElement is JsonElement resolvedElement)
            {
                walker.PushScopeToLocationStack(reference);
                walker.AddOrUpdateLocatedElement(resolvedElement, DefaultContent);
                walker.PopLocationStack();
                await walker.WalkElement(resolvedElement).ConfigureAwait(false);
                if (walker.locatedElements.TryGetValue(reference, out LocatedElement resolvedAndLocatedElement))
                {
                    return resolvedAndLocatedElement;
                }
            }

            return null;
        }

        /// <summary>
        /// The default handler iterates the elements in the document and adds them to the map.
        /// </summary>
        private static async Task<bool> DefaultHandler(JsonWalker walker, JsonElement element)
        {
            if (!walker.TryAddLocatedElement(element, DefaultContent))
            {
                return true;
            }

            if (element.ValueKind == JsonValueKind.Object || element.ValueKind == JsonValueKind.Array)
            {
                await walker.WalkContentsOfObjectOrArray(element).ConfigureAwait(false);
            }

            return true;
        }

        private bool TryAddLocatedElement(JsonElement element, string contentType)
        {
            string location = this.scopedLocationStack.Peek();
            if (!this.locatedElements.ContainsKey(location))
            {
                this.locatedElements.Add(location, new LocatedElement(location, element, contentType));
                return true;
            }

            return false;
        }
    }
}
