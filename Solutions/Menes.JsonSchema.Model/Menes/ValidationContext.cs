// <copyright file="ValidationContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;

    /// <summary>
    /// The current validation environment.
    /// </summary>
    public readonly struct ValidationContext
    {
        private readonly int localEvaluatedItemIndex;
        private readonly ImmutableHashSet<string> localEvaluatedProperties;
        private readonly int appliedEvaluatedItemIndex;
        private readonly ImmutableHashSet<string> appliedEvaluatedProperties;
        private readonly ImmutableStack<string>? keywordLocationStack;
        private readonly ImmutableArray<ValidationResult>? results;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationContext"/> struct.
        /// </summary>
        /// <param name="isValid">Whether this context is valid.</param>
        /// <param name="localEvaluatedItemIndex">The maximum locally evaluated item index.</param>
        /// <param name="localEvaluatedProperties">The hash set of locally evaluated properties in this location.</param>
        /// <param name="appliedEvaluatedItemIndex">The maximum evaluated item index from applied schema.</param>
        /// <param name="appliedEvaluatedProperties">The hash set of evaluated properties from applied schema.</param>
        /// <param name="keywordLocationStack">The current keyword location stack.</param>
        /// <param name="results">The validation results.</param>
        private ValidationContext(bool isValid, int? localEvaluatedItemIndex = null, in ImmutableHashSet<string>? localEvaluatedProperties = null, int? appliedEvaluatedItemIndex = null, in ImmutableHashSet<string>? appliedEvaluatedProperties = null, in ImmutableStack<string>? keywordLocationStack = null, in ImmutableArray<ValidationResult>? results = null)
        {
            this.localEvaluatedItemIndex = localEvaluatedItemIndex ?? -1;
            this.localEvaluatedProperties = localEvaluatedProperties ?? ImmutableHashSet<string>.Empty;
            this.appliedEvaluatedItemIndex = appliedEvaluatedItemIndex ?? -1;
            this.appliedEvaluatedProperties = appliedEvaluatedProperties ?? ImmutableHashSet<string>.Empty;
            this.keywordLocationStack = keywordLocationStack;
            this.IsValid = isValid;
            this.results = results;
        }

        /// <summary>
        /// Gets a new valid context.
        /// </summary>
        public static ValidationContext ValidContext => new ValidationContext(true);

        /// <summary>
        /// Gets a new invalid context.
        /// </summary>
        public static ValidationContext InvalidContext => new ValidationContext(false);

        /// <summary>
        /// Gets a value indicating whether the context is valid.
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        /// Use the keyword stack.
        /// </summary>
        /// <returns>The validation context enabled with the keyword stack.</returns>
        public ValidationContext UsingStack()
        {
            return new ValidationContext(this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.keywordLocationStack ?? ImmutableStack<string>.Empty, this.results);
        }

        /// <summary>
        /// Use the evaluated properties set.
        /// </summary>
        /// <returns>The validation context enabled with evaluated properties.</returns>
        public ValidationContext UsingEvaluatedProperties()
        {
            return new ValidationContext(this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.keywordLocationStack ?? ImmutableStack<string>.Empty, this.results);
        }

        /// <summary>
        /// Determines if a property has been locally evaluated.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns><c>True</c> if the property has been evaluated locally.</returns>
        public bool HasEvaluatedLocalProperty(string propertyName)
        {
            return this.localEvaluatedProperties?.Contains(propertyName) ?? false;
        }

        /// <summary>
        /// Determines if an item has been locally evaluated.
        /// </summary>
        /// <param name="itemIndex">The index of the item.</param>
        /// <returns><c>True</c> if the item has been evaluated locally.</returns>
        public bool HasEvaluatedLocalItemIndex(int itemIndex)
        {
            return this.localEvaluatedItemIndex >= itemIndex;
        }

        /// <summary>
        /// Determines if a property has been evaluated locally or by applied schema.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns><c>True</c> if the property has been evaluated either locally or by applied schema.</returns>
        public bool HasEvaluatedLocalOrAppliedProperty(string propertyName)
        {
            return (this.localEvaluatedProperties?.Contains(propertyName) ?? false) || (this.appliedEvaluatedProperties?.Contains(propertyName) ?? false);
        }

        /// <summary>
        /// Determines if an item has been evaluated locally or by applied schema.
        /// </summary>
        /// <param name="itemIndex">The index of the item.</param>
        /// <returns><c>True</c> if an item has been evaluated either locally or by applied schema.</returns>
        public bool HasEvaluatedLocalOrAppliedItemIndex(int itemIndex)
        {
            return this.localEvaluatedItemIndex >= itemIndex || this.appliedEvaluatedItemIndex >= itemIndex;
        }

        /// <summary>
        /// Adds a result to the validation context.
        /// </summary>
        /// <param name="isValid">Whether the result is valid.</param>
        /// <param name="message">The validation message.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext WithResult(bool isValid, string? message = null)
        {
            return new ValidationContext(this.IsValid && isValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.keywordLocationStack, message is string msg ? this.results?.Add(new ValidationResult(isValid, msg, this.keywordLocationStack?.Peek())) : this.results);
        }

        /// <summary>
        /// Adds an item index to the evaluated items array.
        /// </summary>
        /// <param name="index">The index to add.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext WithLocalItemIndex(int index)
        {
            return new ValidationContext(this.IsValid, Math.Max(this.localEvaluatedItemIndex, index), this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.keywordLocationStack, this.results);
        }

        /// <summary>
        /// Adds an property name to the evaluated properties array.
        /// </summary>
        /// <param name="propertyName">The property name to add.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext WithLocalProperty(string propertyName)
        {
            return new ValidationContext(this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties?.Add(propertyName), this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.keywordLocationStack, this.results);
        }

        /// <summary>
        /// Merges the local and applied evaluated entities from a child context into the applied evaluated entities in a parent context.
        /// </summary>
        /// <param name="childContext">The evaluated child context.</param>
        /// <param name="includeResults">Also merge the results into the parent.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext MergeChildContext(in ValidationContext childContext, bool includeResults)
        {
            return new ValidationContext(includeResults ? this.IsValid && childContext.IsValid : this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, Math.Max(this.appliedEvaluatedItemIndex, Math.Max(childContext.localEvaluatedItemIndex, childContext.appliedEvaluatedItemIndex)), this.CombineProperties(childContext), this.keywordLocationStack, includeResults && childContext.results is not null ? this.results?.AddRange(childContext.results) : this.results);
        }

        /// <summary>
        /// Pushes a location onto the location stack for the context.
        /// </summary>
        /// <param name="location">The location to push.</param>
        /// <returns>The context updated with the given location.</returns>
        public ValidationContext PushLocation(string location)
        {
            return new ValidationContext(this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.keywordLocationStack?.Push(location), this.results);
        }

        /// <summary>
        /// Pops a location off the keyword location stack.
        /// </summary>
        /// <returns>The updated context.</returns>
        public ValidationContext PopLocation()
        {
            return new ValidationContext(this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.keywordLocationStack?.Pop(), this.results);
        }

        /// <summary>
        /// Creates a child context from the current location.
        /// </summary>
        /// <returns>A new (valid) validation context with no evaluated items or properties, at the current location.</returns>
        public ValidationContext CreateChildContext()
        {
            return new ValidationContext(this.IsValid, null, null, null, null, this.keywordLocationStack, null);
        }

        /// <summary>
        /// Creates a child context from the current location.
        /// </summary>
        /// <param name="absoluteKeywordLocation">The (optional) absolute keyword location for the child context.</param>
        /// <returns>A new (valid) validation context with no evaluated items or properties, at the current location.</returns>
        public ValidationContext CreateChildContext(string absoluteKeywordLocation)
        {
            return new ValidationContext(this.IsValid, null, null, null, null, this.keywordLocationStack?.Push(absoluteKeywordLocation), null);
        }

        private ImmutableHashSet<string>? CombineProperties(in ValidationContext childContext)
        {
            if (this.appliedEvaluatedProperties is null)
            {
                return null;
            }

            if (childContext.appliedEvaluatedProperties is not null || childContext.localEvaluatedProperties is not null)
            {
                ImmutableHashSet<string> result = ImmutableHashSet<string>.Empty;
                if (childContext.appliedEvaluatedProperties is not null)
                {
                    result = childContext.appliedEvaluatedProperties.Union(this.appliedEvaluatedProperties);
                }

                if (childContext.localEvaluatedProperties is not null)
                {
                    result = result.Union(childContext.localEvaluatedProperties);
                }

                return result;
            }

            return null;
        }
    }
}
