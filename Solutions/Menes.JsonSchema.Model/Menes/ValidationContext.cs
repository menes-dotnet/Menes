// <copyright file="ValidationContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Immutable;

    /// <summary>
    /// The current validation environment.
    /// </summary>
    public readonly struct ValidationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationContext"/> struct.
        /// </summary>
        /// <param name="isValid">Whether this context is valid.</param>
        /// <param name="localEvaluatedItemIndices">The hash set of locally evaluated item indices.</param>
        /// <param name="localEvaluatedProperties">The hash set of locally evaluated properties in this location.</param>
        /// <param name="appliedEvaluatedItemIndices">The hash set of evaluated item indices from applied schema.</param>
        /// <param name="appliedEvaluatedProperties">The hash set of evaluated properties from applied schema.</param>
        /// <param name="keywordLocationStack">The current keyword location stack.</param>
        /// <param name="results">The validation results.</param>
        private ValidationContext(bool isValid, ImmutableHashSet<int>? localEvaluatedItemIndices = null, ImmutableHashSet<string>? localEvaluatedProperties = null, ImmutableHashSet<int>? appliedEvaluatedItemIndices = null, ImmutableHashSet<string>? appliedEvaluatedProperties = null, ImmutableStack<string>? keywordLocationStack = null, ImmutableArray<ValidationResult>? results = null)
        {
            this.LocalEvaluatedItemIndices = localEvaluatedItemIndices ?? ImmutableHashSet<int>.Empty;
            this.LocalEvaluatedProperties = localEvaluatedProperties ?? ImmutableHashSet<string>.Empty;
            this.AppliedEvaluatedItemIndices = appliedEvaluatedItemIndices ?? ImmutableHashSet<int>.Empty;
            this.AppliedEvaluatedProperties = appliedEvaluatedProperties ?? ImmutableHashSet<string>.Empty;
            this.KeywordLocationStack = keywordLocationStack ?? ImmutableStack<string>.Empty;
            this.IsValid = isValid;
            this.Results = results ?? ImmutableArray<ValidationResult>.Empty;
        }

        /// <summary>
        /// Gets a new valid context.
        /// </summary>
        public static ValidationContext ValidContext => new ValidationContext(true);

        /// <summary>
        /// Gets a new invalid context.
        /// </summary>
        public static ValidationContext  InvalidContext => new ValidationContext(false);

        /// <summary>
        /// Gets the list of evaluated item indices in this context.
        /// </summary>
        public ImmutableHashSet<int> LocalEvaluatedItemIndices { get; }

        /// <summary>
        /// Gets the list of evaluated properties in this context.
        /// </summary>
        public ImmutableHashSet<string> LocalEvaluatedProperties { get; }

        /// <summary>
        /// Gets the list of item indices evaluated by applied schema.
        /// </summary>
        public ImmutableHashSet<int> AppliedEvaluatedItemIndices { get; }

        /// <summary>
        /// Gets the list of propery names evaluated by applied schema.
        /// </summary>
        public ImmutableHashSet<string> AppliedEvaluatedProperties { get; }

        /// <summary>
        /// Gets the keyword location stack.
        /// </summary>
        public ImmutableStack<string> KeywordLocationStack { get; }

        /// <summary>
        /// Gets a value indicating whether the context is valid.
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        /// Gets the validation results accumulated in this context.
        /// </summary>
        public ImmutableArray<ValidationResult> Results { get; }

        /// <summary>
        /// Determines if a property has been locally evaluated.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns><c>True</c> if the property has been evaluated locally.</returns>
        public bool HasEvaluatedLocalProperty(string propertyName)
        {
            return this.LocalEvaluatedProperties.Contains(propertyName);
        }

        /// <summary>
        /// Determines if an item has been locally evaluated.
        /// </summary>
        /// <param name="itemIndex">The index of the item.</param>
        /// <returns><c>True</c> if the item has been evaluated locally.</returns>
        public bool HasEvaluatedLocalItemIndex(int itemIndex)
        {
            return this.LocalEvaluatedItemIndices.Contains(itemIndex);
        }

        /// <summary>
        /// Determines if a property has been evaluated locally or by applied schema.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns><c>True</c> if the property has been evaluated either locally or by applied schema.</returns>
        public bool HasEvaluatedLocalOrAppliedProperty(string propertyName)
        {
            return this.LocalEvaluatedProperties.Contains(propertyName) || this.AppliedEvaluatedProperties.Contains(propertyName);
        }

        /// <summary>
        /// Determines if an item has been evaluated locally or by applied schema.
        /// </summary>
        /// <param name="itemIndex">The index of the item.</param>
        /// <returns><c>True</c> if an item has been evaluated either locally or by applied schema.</returns>
        public bool HasEvaluatedLocalOrAppliedItemIndex(int itemIndex)
        {
            return this.LocalEvaluatedItemIndices.Contains(itemIndex) || this.AppliedEvaluatedItemIndices.Contains(itemIndex);
        }

        /// <summary>
        /// Adds a result to the validation context.
        /// </summary>
        /// <param name="isValid">Whether the result is valid.</param>
        /// <param name="message">The validation message.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext WithResult(bool isValid, string? message = null)
        {
            return new ValidationContext(this.IsValid && isValid, this.LocalEvaluatedItemIndices, this.LocalEvaluatedProperties, this.AppliedEvaluatedItemIndices, this.AppliedEvaluatedProperties, this.KeywordLocationStack, this.Results.Add(new ValidationResult(isValid, message, this.KeywordLocationStack.IsEmpty ? null : this.KeywordLocationStack.Peek())));
        }

        /// <summary>
        /// Adds an item index to the evaluated items array.
        /// </summary>
        /// <param name="index">The index to add.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext WithLocalItemIndex(int index)
        {
            return new ValidationContext(this.IsValid, this.LocalEvaluatedItemIndices.Add(index), this.LocalEvaluatedProperties, this.AppliedEvaluatedItemIndices, this.AppliedEvaluatedProperties, this.KeywordLocationStack, this.Results);
        }

        /// <summary>
        /// Adds an property name to the evaluated properties array.
        /// </summary>
        /// <param name="propertyName">The property name to add.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext WithLocalProperty(string propertyName)
        {
            return new ValidationContext(this.IsValid, this.LocalEvaluatedItemIndices, this.LocalEvaluatedProperties.Add(propertyName), this.AppliedEvaluatedItemIndices, this.AppliedEvaluatedProperties, this.KeywordLocationStack, this.Results);
        }

        /// <summary>
        /// Merges the local and applied evaluated entities from a child context into the applied evaluated entities in a parent context.
        /// </summary>
        /// <param name="childContext">The evaluated child context.</param>
        /// <param name="includeResults">Also merge the results into the parent.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext MergeChildContext(ValidationContext childContext, bool includeResults)
        {
            return new ValidationContext(includeResults ? this.IsValid && childContext.IsValid : this.IsValid, this.LocalEvaluatedItemIndices, this.LocalEvaluatedProperties, this.AppliedEvaluatedItemIndices.Union(childContext.LocalEvaluatedItemIndices).Union(childContext.AppliedEvaluatedItemIndices), this.AppliedEvaluatedProperties.Union(childContext.LocalEvaluatedProperties).Union(childContext.AppliedEvaluatedProperties), this.KeywordLocationStack, includeResults ? this.Results.AddRange(childContext.Results) : this.Results);
        }

        /// <summary>
        /// Pushes a location onto the location stack for the context.
        /// </summary>
        /// <param name="location">The location to push.</param>
        /// <returns>The context updated with the given location.</returns>
        public ValidationContext PushLocation(string location)
        {
            return new ValidationContext(this.IsValid, this.LocalEvaluatedItemIndices, this.LocalEvaluatedProperties, this.AppliedEvaluatedItemIndices, this.AppliedEvaluatedProperties, this.KeywordLocationStack.Push(location), this.Results);
        }

        /// <summary>
        /// Pops a location off the keyword location stack.
        /// </summary>
        /// <returns>The updated context.</returns>
        public ValidationContext PopLocation()
        {
            return new ValidationContext(this.IsValid, this.LocalEvaluatedItemIndices, this.LocalEvaluatedProperties, this.AppliedEvaluatedItemIndices, this.AppliedEvaluatedProperties, this.KeywordLocationStack.Pop(), this.Results);
        }

        /// <summary>
        /// Creates a child context from the current location.
        /// </summary>
        /// <returns>A new (valid) validation context with no evaluated items or properties, at the current location.</returns>
        public ValidationContext CreateChildContext()
        {
            return new ValidationContext(this.IsValid, null, null, null, null, this.KeywordLocationStack, null);
        }

        /// <summary>
        /// Creates a child context from the current location.
        /// </summary>
        /// <param name="absoluteKeywordLocation">The (optional) absolute keyword location for the child context.</param>
        /// <returns>A new (valid) validation context with no evaluated items or properties, at the current location.</returns>
        public ValidationContext CreateChildContext(string absoluteKeywordLocation)
        {
            return new ValidationContext(this.IsValid, null, null, null, null, this.KeywordLocationStack.Push(absoluteKeywordLocation), null);
        }
    }
}
