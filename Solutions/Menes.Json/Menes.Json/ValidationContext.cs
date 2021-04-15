// <copyright file="ValidationContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;

    /// <summary>
    /// The current validation context.
    /// </summary>
    public readonly struct ValidationContext
    {
        /// <summary>
        /// Gets a valid context.
        /// </summary>
        public static readonly ValidationContext ValidContext = new ValidationContext(true);

        /// <summary>
        /// Gets an invalid context.
        /// </summary>
        public static readonly ValidationContext InvalidContext = new ValidationContext(false);

        private readonly int localEvaluatedItemIndex;
        private readonly ImmutableHashSet<JsonEncodedText> localEvaluatedProperties;
        private readonly int appliedEvaluatedItemIndex;
        private readonly ImmutableHashSet<JsonEncodedText> appliedEvaluatedProperties;
        private readonly ImmutableStack<string>? absoluteKeywordLocationStack;
        private readonly ImmutableStack<JsonEncodedText>? locationStack;
        private readonly ImmutableArray<ValidationResult>? results;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationContext"/> struct.
        /// </summary>
        /// <param name="isValid">Whether this context is valid.</param>
        /// <param name="localEvaluatedItemIndex">The maximum locally evaluated item index.</param>
        /// <param name="localEvaluatedProperties">The hash set of locally evaluated properties in this location.</param>
        /// <param name="appliedEvaluatedItemIndex">The maximum evaluated item index from applied schema.</param>
        /// <param name="appliedEvaluatedProperties">The hash set of evaluated properties from applied schema.</param>
        /// <param name="locationStack">The current location stack.</param>
        /// <param name="absoluteKeywordLocationStack">The current absolute keyword location stack.</param>
        /// <param name="results">The validation results.</param>
        private ValidationContext(bool isValid, int? localEvaluatedItemIndex = null, in ImmutableHashSet<JsonEncodedText>? localEvaluatedProperties = null, int? appliedEvaluatedItemIndex = null, in ImmutableHashSet<JsonEncodedText>? appliedEvaluatedProperties = null, in ImmutableStack<JsonEncodedText>? locationStack = null, in ImmutableStack<string>? absoluteKeywordLocationStack = null, in ImmutableArray<ValidationResult>? results = null)
        {
            this.localEvaluatedItemIndex = localEvaluatedItemIndex ?? -1;
            this.localEvaluatedProperties = localEvaluatedProperties ?? ImmutableHashSet<JsonEncodedText>.Empty;
            this.appliedEvaluatedItemIndex = appliedEvaluatedItemIndex ?? -1;
            this.appliedEvaluatedProperties = appliedEvaluatedProperties ?? ImmutableHashSet<JsonEncodedText>.Empty;
            this.locationStack = locationStack;
            this.absoluteKeywordLocationStack = absoluteKeywordLocationStack;
            this.IsValid = isValid;
            this.results = results;
        }

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
            return new ValidationContext(this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.locationStack ?? ImmutableStack<JsonEncodedText>.Empty, this.absoluteKeywordLocationStack ?? ImmutableStack<string>.Empty, this.results);
        }

        /// <summary>
        /// Use the evaluated properties set.
        /// </summary>
        /// <returns>The validation context enabled with evaluated properties.</returns>
        public ValidationContext UsingEvaluatedProperties()
        {
            return new ValidationContext(this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.locationStack ?? ImmutableStack<JsonEncodedText>.Empty, this.absoluteKeywordLocationStack ?? ImmutableStack<string>.Empty, this.results);
        }

        /// <summary>
        /// Determines if a property has been locally evaluated.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns><c>True</c> if the property has been evaluated locally.</returns>
        public bool HasEvaluatedLocalProperty(JsonEncodedText propertyName)
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
        public bool HasEvaluatedLocalOrAppliedProperty(JsonEncodedText propertyName)
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
            return new ValidationContext(this.IsValid && isValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.locationStack, this.absoluteKeywordLocationStack, message is string msg ? this.results?.Add(new ValidationResult(isValid, msg, this.absoluteKeywordLocationStack?.Peek(), this.locationStack?.Peek())) : this.results);
        }

        /// <summary>
        /// Adds an item index to the evaluated items array.
        /// </summary>
        /// <param name="index">The index to add.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext WithLocalItemIndex(int index)
        {
            return new ValidationContext(this.IsValid, Math.Max(this.localEvaluatedItemIndex, index), this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.locationStack, this.absoluteKeywordLocationStack, this.results);
        }

        /// <summary>
        /// Adds an property name to the evaluated properties array.
        /// </summary>
        /// <param name="propertyName">The property name to add.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext WithLocalProperty(JsonEncodedText propertyName)
        {
            return new ValidationContext(this.IsValid, this.localEvaluatedItemIndex, this.AddLocalEvaluatedProperty(propertyName), this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.locationStack, this.absoluteKeywordLocationStack, this.results);
        }

        /// <summary>
        /// Merges the local and applied evaluated entities from a child context into the applied evaluated entities in a parent context.
        /// </summary>
        /// <param name="childContext">The evaluated child context.</param>
        /// <param name="includeResults">Also merge the results into the parent.</param>
        /// <returns>The updated validation context.</returns>
        public ValidationContext MergeChildContext(in ValidationContext childContext, bool includeResults)
        {
            return new ValidationContext(includeResults ? this.IsValid && childContext.IsValid : this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, Math.Max(this.appliedEvaluatedItemIndex, Math.Max(childContext.localEvaluatedItemIndex, childContext.appliedEvaluatedItemIndex)), this.CombineProperties(childContext), this.locationStack, this.absoluteKeywordLocationStack, includeResults && childContext.results is not null ? this.results?.AddRange(childContext.results) : this.results);
        }

        /// <summary>
        /// Pushes a location onto the location stack for the context.
        /// </summary>
        /// <param name="location">The location to push.</param>
        /// <param name="absoluteKeywordLocation">The abolute keyword location to push.</param>
        /// <returns>The context updated with the given location.</returns>
        public ValidationContext PushLocation(JsonEncodedText location, string absoluteKeywordLocation)
        {
            return new ValidationContext(this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.locationStack?.Push(location), this.absoluteKeywordLocationStack?.Push(absoluteKeywordLocation), this.results);
        }

        /// <summary>
        /// Pops a location off the location stack.
        /// </summary>
        /// <returns>The updated context.</returns>
        public ValidationContext PopLocation()
        {
            return new ValidationContext(this.IsValid, this.localEvaluatedItemIndex, this.localEvaluatedProperties, this.appliedEvaluatedItemIndex, this.appliedEvaluatedProperties, this.locationStack?.Pop(), this.absoluteKeywordLocationStack?.Pop(), this.results);
        }

        /// <summary>
        /// Creates a child context from the current location.
        /// </summary>
        /// <returns>A new (valid) validation context with no evaluated items or properties, at the current location.</returns>
        public ValidationContext CreateChildContext()
        {
            return new ValidationContext(this.IsValid, null, null, null, null, this.locationStack, this.absoluteKeywordLocationStack, null);
        }

        /// <summary>
        /// Creates a child context from the current location.
        /// </summary>
        /// <param name="location">The location for the child context.</param>
        /// <param name="absoluteKeywordLocation">The absolute keyword location for the child context.</param>
        /// <returns>A new (valid) validation context with no evaluated items or properties, at the current location.</returns>
        public ValidationContext CreateChildContext(JsonEncodedText location, string absoluteKeywordLocation)
        {
            return new ValidationContext(this.IsValid, null, null, null, null, this.locationStack?.Push(location), this.absoluteKeywordLocationStack?.Push(absoluteKeywordLocation), null);
        }

        /// <summary>
        /// Merge the messages for a given set of results into this result,
        /// applying the given validity at the end, regardless of the individual
        /// validity of the results in the set.
        /// </summary>
        /// <param name="isValid">The ultimate validity of this context.</param>
        /// <param name="level">The current validation level for the context.</param>
        /// <param name="result1">The first result.</param>
        /// <returns>The updated validation context.</returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="MergeChildContext(in ValidationContext, bool)"/>, which merges the elements
        /// that were visited, this simply takes the contextual messages from the children, adds them to this context,
        /// and sets the validity as per the <paramref name="isValid"/> parameter.
        /// </para>
        /// <para>
        /// This is typically used when one of a number of validations may be valid, and the ultimate result is some
        /// function of those child validations, but you wish to capture the details about the validation.
        /// </para>
        /// </remarks>
        public ValidationContext MergeResults(bool isValid, ValidationLevel level, in ValidationContext result1)
        {
            if (level == ValidationLevel.Flag && isValid)
            {
                return this;
            }

            ImmutableArray<ValidationResult>.Builder builder = ImmutableArray.CreateBuilder<ValidationResult>();

            if (this.results is ImmutableArray<ValidationResult> thisResults)
            {
                builder.AddRange(thisResults);
            }

            if (result1.results is ImmutableArray<ValidationResult> result1Results)
            {
                builder.AddRange(result1Results);
            }

            return new ValidationContext(
                isValid,
                this.localEvaluatedItemIndex,
                this.localEvaluatedProperties,
                this.appliedEvaluatedItemIndex,
                this.appliedEvaluatedProperties,
                this.locationStack,
                this.absoluteKeywordLocationStack,
                builder.ToImmutable());
        }

        /// <summary>
        /// Merge the messages for a given set of results into this result,
        /// applying the given validity at the end, regardless of the individual
        /// validity of the results in the set.
        /// </summary>
        /// <param name="isValid">The ultimate validity of this context.</param>
        /// <param name="level">The current validation level for the context.</param>
        /// <param name="result1">The first result.</param>
        /// <param name="result2">The second result.</param>
        /// <returns>The updated validation context.</returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="MergeChildContext(in ValidationContext, bool)"/>, which merges the elements
        /// that were visited, this simply takes the contextual messages from the children, adds them to this context,
        /// and sets the validity as per the <paramref name="isValid"/> parameter.
        /// </para>
        /// <para>
        /// This is typically used when one of a number of validations may be valid, and the ultimate result is some
        /// function of those child validations, but you wish to capture the details about the validation.
        /// </para>
        /// </remarks>
        public ValidationContext MergeResults(bool isValid, ValidationLevel level, in ValidationContext result1, in ValidationContext result2)
        {
            if (level == ValidationLevel.Flag && isValid)
            {
                return this;
            }

            ImmutableArray<ValidationResult>.Builder builder = ImmutableArray.CreateBuilder<ValidationResult>();

            if (this.results is ImmutableArray<ValidationResult> thisResults)
            {
                builder.AddRange(thisResults);
            }

            if (result1.results is ImmutableArray<ValidationResult> result1Results)
            {
                builder.AddRange(result1Results);
            }

            if (result2.results is ImmutableArray<ValidationResult> result2Results)
            {
                builder.AddRange(result2Results);
            }

            return new ValidationContext(
                isValid,
                this.localEvaluatedItemIndex,
                this.localEvaluatedProperties,
                this.appliedEvaluatedItemIndex,
                this.appliedEvaluatedProperties,
                this.locationStack,
                this.absoluteKeywordLocationStack,
                builder.ToImmutable());
        }

        /// <summary>
        /// Merge the messages for a given set of results into this result,
        /// applying the given validity at the end, regardless of the individual
        /// validity of the results in the set.
        /// </summary>
        /// <param name="isValid">The ultimate validity of this context.</param>
        /// <param name="level">The current validation level for the context.</param>
        /// <param name="result1">The first result.</param>
        /// <param name="result2">The second result.</param>
        /// <param name="result3">The third result.</param>
        /// <returns>The updated validation context.</returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="MergeChildContext(in ValidationContext, bool)"/>, which merges the elements
        /// that were visited, this simply takes the contextual messages from the children, adds them to this context,
        /// and sets the validity as per the <paramref name="isValid"/> parameter.
        /// </para>
        /// <para>
        /// This is typically used when one of a number of validations may be valid, and the ultimate result is some
        /// function of those child validations, but you wish to capture the details about the validation.
        /// </para>
        /// </remarks>
        public ValidationContext MergeResults(bool isValid, ValidationLevel level, in ValidationContext result1, in ValidationContext result2, in ValidationContext result3)
        {
            if (level == ValidationLevel.Flag && isValid)
            {
                return this;
            }

            ImmutableArray<ValidationResult>.Builder builder = ImmutableArray.CreateBuilder<ValidationResult>();

            if (this.results is ImmutableArray<ValidationResult> thisResults)
            {
                builder.AddRange(thisResults);
            }

            if (result1.results is ImmutableArray<ValidationResult> result1Results)
            {
                builder.AddRange(result1Results);
            }

            if (result2.results is ImmutableArray<ValidationResult> result2Results)
            {
                builder.AddRange(result2Results);
            }

            if (result3.results is ImmutableArray<ValidationResult> result3Results)
            {
                builder.AddRange(result3Results);
            }

            return new ValidationContext(
                isValid,
                this.localEvaluatedItemIndex,
                this.localEvaluatedProperties,
                this.appliedEvaluatedItemIndex,
                this.appliedEvaluatedProperties,
                this.locationStack,
                this.absoluteKeywordLocationStack,
                builder.ToImmutable());
        }

        /// <summary>
        /// Merge the messages for a given set of results into this result,
        /// applying the given validity at the end, regardless of the individual
        /// validity of the results in the set.
        /// </summary>
        /// <param name="isValid">The ultimate validity of this context.</param>
        /// <param name="level">The current validation level for the context.</param>
        /// <param name="result1">The first result.</param>
        /// <param name="result2">The second result.</param>
        /// <param name="result3">The third result.</param>
        /// <param name="result4">The fourth result.</param>
        /// <returns>The updated validation context.</returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="MergeChildContext(in ValidationContext, bool)"/>, which merges the elements
        /// that were visited, this simply takes the contextual messages from the children, adds them to this context,
        /// and sets the validity as per the <paramref name="isValid"/> parameter.
        /// </para>
        /// <para>
        /// This is typically used when one of a number of validations may be valid, and the ultimate result is some
        /// function of those child validations, but you wish to capture the details about the validation.
        /// </para>
        /// </remarks>
        public ValidationContext MergeResults(bool isValid, ValidationLevel level, in ValidationContext result1, in ValidationContext result2, in ValidationContext result3, in ValidationContext result4)
        {
            if (level == ValidationLevel.Flag && isValid)
            {
                return this;
            }

            ImmutableArray<ValidationResult>.Builder builder = ImmutableArray.CreateBuilder<ValidationResult>();

            if (this.results is ImmutableArray<ValidationResult> thisResults)
            {
                builder.AddRange(thisResults);
            }

            if (result1.results is ImmutableArray<ValidationResult> result1Results)
            {
                builder.AddRange(result1Results);
            }

            if (result2.results is ImmutableArray<ValidationResult> result2Results)
            {
                builder.AddRange(result2Results);
            }

            if (result3.results is ImmutableArray<ValidationResult> result3Results)
            {
                builder.AddRange(result3Results);
            }

            if (result4.results is ImmutableArray<ValidationResult> result4Results)
            {
                builder.AddRange(result4Results);
            }

            return new ValidationContext(
                isValid,
                this.localEvaluatedItemIndex,
                this.localEvaluatedProperties,
                this.appliedEvaluatedItemIndex,
                this.appliedEvaluatedProperties,
                this.locationStack,
                this.absoluteKeywordLocationStack,
                builder.ToImmutable());
        }

        /// <summary>
        /// Merge the messages for a given set of results into this result,
        /// applying the given validity at the end, regardless of the individual
        /// validity of the results in the set.
        /// </summary>
        /// <param name="isValid">The ultimate validity of this context.</param>
        /// <param name="level">The current validation level for the context.</param>
        /// <param name="result1">The first result.</param>
        /// <param name="result2">The second result.</param>
        /// <param name="result3">The third result.</param>
        /// <param name="result4">The fourth result.</param>
        /// <param name="result5">The fifth result.</param>
        /// <returns>The updated validation context.</returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="MergeChildContext(in ValidationContext, bool)"/>, which merges the elements
        /// that were visited, this simply takes the contextual messages from the children, adds them to this context,
        /// and sets the validity as per the <paramref name="isValid"/> parameter.
        /// </para>
        /// <para>
        /// This is typically used when one of a number of validations may be valid, and the ultimate result is some
        /// function of those child validations, but you wish to capture the details about the validation.
        /// </para>
        /// </remarks>
        public ValidationContext MergeResults(bool isValid, ValidationLevel level, in ValidationContext result1, in ValidationContext result2, in ValidationContext result3, in ValidationContext result4, in ValidationContext result5)
        {
            if (level == ValidationLevel.Flag && isValid)
            {
                return this;
            }

            ImmutableArray<ValidationResult>.Builder builder = ImmutableArray.CreateBuilder<ValidationResult>();

            if (this.results is ImmutableArray<ValidationResult> thisResults)
            {
                builder.AddRange(thisResults);
            }

            if (result1.results is ImmutableArray<ValidationResult> result1Results)
            {
                builder.AddRange(result1Results);
            }

            if (result2.results is ImmutableArray<ValidationResult> result2Results)
            {
                builder.AddRange(result2Results);
            }

            if (result3.results is ImmutableArray<ValidationResult> result3Results)
            {
                builder.AddRange(result3Results);
            }

            if (result4.results is ImmutableArray<ValidationResult> result4Results)
            {
                builder.AddRange(result4Results);
            }

            if (result5.results is ImmutableArray<ValidationResult> result5Results)
            {
                builder.AddRange(result5Results);
            }

            return new ValidationContext(
                isValid,
                this.localEvaluatedItemIndex,
                this.localEvaluatedProperties,
                this.appliedEvaluatedItemIndex,
                this.appliedEvaluatedProperties,
                this.locationStack,
                this.absoluteKeywordLocationStack,
                builder.ToImmutable());
        }

        /// <summary>
        /// Merge the messages for a given set of results into this result,
        /// applying the given validity at the end, regardless of the individual
        /// validity of the results in the set.
        /// </summary>
        /// <param name="isValid">The ultimate validity of this context.</param>
        /// <param name="level">The current validation level for the context.</param>
        /// <param name="result1">The first result.</param>
        /// <param name="result2">The second result.</param>
        /// <param name="result3">The third result.</param>
        /// <param name="result4">The fourth result.</param>
        /// <param name="result5">The fifth result.</param>
        /// <param name="result6">The sixth result.</param>
        /// <returns>The updated validation context.</returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="MergeChildContext(in ValidationContext, bool)"/>, which merges the elements
        /// that were visited, this simply takes the contextual messages from the children, adds them to this context,
        /// and sets the validity as per the <paramref name="isValid"/> parameter.
        /// </para>
        /// <para>
        /// This is typically used when one of a number of validations may be valid, and the ultimate result is some
        /// function of those child validations, but you wish to capture the details about the validation.
        /// </para>
        /// </remarks>
        public ValidationContext MergeResults(bool isValid, ValidationLevel level, in ValidationContext result1, in ValidationContext result2, in ValidationContext result3, in ValidationContext result4, in ValidationContext result5, in ValidationContext result6)
        {
            if (level == ValidationLevel.Flag && isValid)
            {
                return this;
            }

            ImmutableArray<ValidationResult>.Builder builder = ImmutableArray.CreateBuilder<ValidationResult>();

            if (this.results is ImmutableArray<ValidationResult> thisResults)
            {
                builder.AddRange(thisResults);
            }

            if (result1.results is ImmutableArray<ValidationResult> result1Results)
            {
                builder.AddRange(result1Results);
            }

            if (result2.results is ImmutableArray<ValidationResult> result2Results)
            {
                builder.AddRange(result2Results);
            }

            if (result3.results is ImmutableArray<ValidationResult> result3Results)
            {
                builder.AddRange(result3Results);
            }

            if (result4.results is ImmutableArray<ValidationResult> result4Results)
            {
                builder.AddRange(result4Results);
            }

            if (result5.results is ImmutableArray<ValidationResult> result5Results)
            {
                builder.AddRange(result5Results);
            }

            if (result6.results is ImmutableArray<ValidationResult> result6Results)
            {
                builder.AddRange(result6Results);
            }

            return new ValidationContext(
                isValid,
                this.localEvaluatedItemIndex,
                this.localEvaluatedProperties,
                this.appliedEvaluatedItemIndex,
                this.appliedEvaluatedProperties,
                this.locationStack,
                this.absoluteKeywordLocationStack,
                builder.ToImmutable());
        }

        /// <summary>
        /// Merge the messages for a given set of results into this result,
        /// applying the given validity at the end, regardless of the individual
        /// validity of the results in the set.
        /// </summary>
        /// <param name="isValid">The ultimate validity of this context.</param>
        /// <param name="level">The current validation level for the context.</param>
        /// <param name="result1">The first result.</param>
        /// <param name="result2">The second result.</param>
        /// <param name="result3">The third result.</param>
        /// <param name="result4">The fourth result.</param>
        /// <param name="result5">The fifth result.</param>
        /// <param name="result6">The sixth result.</param>
        /// <param name="result7">The seventh result.</param>
        /// <returns>The updated validation context.</returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="MergeChildContext(in ValidationContext, bool)"/>, which merges the elements
        /// that were visited, this simply takes the contextual messages from the children, adds them to this context,
        /// and sets the validity as per the <paramref name="isValid"/> parameter.
        /// </para>
        /// <para>
        /// This is typically used when one of a number of validations may be valid, and the ultimate result is some
        /// function of those child validations, but you wish to capture the details about the validation.
        /// </para>
        /// </remarks>
        public ValidationContext MergeResults(bool isValid, ValidationLevel level, in ValidationContext result1, in ValidationContext result2, in ValidationContext result3, in ValidationContext result4, in ValidationContext result5, in ValidationContext result6, in ValidationContext result7)
        {
            if (level == ValidationLevel.Flag && isValid)
            {
                return this;
            }

            ImmutableArray<ValidationResult>.Builder builder = ImmutableArray.CreateBuilder<ValidationResult>();

            if (this.results is ImmutableArray<ValidationResult> thisResults)
            {
                builder.AddRange(thisResults);
            }

            if (result1.results is ImmutableArray<ValidationResult> result1Results)
            {
                builder.AddRange(result1Results);
            }

            if (result2.results is ImmutableArray<ValidationResult> result2Results)
            {
                builder.AddRange(result2Results);
            }

            if (result3.results is ImmutableArray<ValidationResult> result3Results)
            {
                builder.AddRange(result3Results);
            }

            if (result4.results is ImmutableArray<ValidationResult> result4Results)
            {
                builder.AddRange(result4Results);
            }

            if (result5.results is ImmutableArray<ValidationResult> result5Results)
            {
                builder.AddRange(result5Results);
            }

            if (result6.results is ImmutableArray<ValidationResult> result6Results)
            {
                builder.AddRange(result6Results);
            }

            if (result7.results is ImmutableArray<ValidationResult> result7Results)
            {
                builder.AddRange(result7Results);
            }

            return new ValidationContext(
                isValid,
                this.localEvaluatedItemIndex,
                this.localEvaluatedProperties,
                this.appliedEvaluatedItemIndex,
                this.appliedEvaluatedProperties,
                this.locationStack,
                this.absoluteKeywordLocationStack,
                builder.ToImmutable());
        }

        /// <summary>
        /// Merge the messages for a given set of results into this result,
        /// applying the given validity at the end, regardless of the individual
        /// validity of the results in the set.
        /// </summary>
        /// <param name="isValid">The ultimate validity of this context.</param>
        /// <param name="level">The current validation level for the context.</param>
        /// <param name="result1">The first result.</param>
        /// <param name="result2">The second result.</param>
        /// <param name="result3">The third result.</param>
        /// <param name="result4">The fourth result.</param>
        /// <param name="result5">The fifth result.</param>
        /// <param name="result6">The sixth result.</param>
        /// <param name="result7">The seventh result.</param>
        /// <param name="result8">The eighth result.</param>
        /// <returns>The updated validation context.</returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="MergeChildContext(in ValidationContext, bool)"/>, which merges the elements
        /// that were visited, this simply takes the contextual messages from the children, adds them to this context,
        /// and sets the validity as per the <paramref name="isValid"/> parameter.
        /// </para>
        /// <para>
        /// This is typically used when one of a number of validations may be valid, and the ultimate result is some
        /// function of those child validations, but you wish to capture the details about the validation.
        /// </para>
        /// </remarks>
        public ValidationContext MergeResults(bool isValid, ValidationLevel level, in ValidationContext result1, in ValidationContext result2, in ValidationContext result3, in ValidationContext result4, in ValidationContext result5, in ValidationContext result6, in ValidationContext result7, in ValidationContext result8)
        {
            if (level == ValidationLevel.Flag && isValid)
            {
                return this;
            }

            ImmutableArray<ValidationResult>.Builder builder = ImmutableArray.CreateBuilder<ValidationResult>();

            if (this.results is ImmutableArray<ValidationResult> thisResults)
            {
                builder.AddRange(thisResults);
            }

            if (result1.results is ImmutableArray<ValidationResult> result1Results)
            {
                builder.AddRange(result1Results);
            }

            if (result2.results is ImmutableArray<ValidationResult> result2Results)
            {
                builder.AddRange(result2Results);
            }

            if (result3.results is ImmutableArray<ValidationResult> result3Results)
            {
                builder.AddRange(result3Results);
            }

            if (result4.results is ImmutableArray<ValidationResult> result4Results)
            {
                builder.AddRange(result4Results);
            }

            if (result5.results is ImmutableArray<ValidationResult> result5Results)
            {
                builder.AddRange(result5Results);
            }

            if (result6.results is ImmutableArray<ValidationResult> result6Results)
            {
                builder.AddRange(result6Results);
            }

            if (result7.results is ImmutableArray<ValidationResult> result7Results)
            {
                builder.AddRange(result7Results);
            }

            if (result8.results is ImmutableArray<ValidationResult> result8Results)
            {
                builder.AddRange(result8Results);
            }

            return new ValidationContext(
                isValid,
                this.localEvaluatedItemIndex,
                this.localEvaluatedProperties,
                this.appliedEvaluatedItemIndex,
                this.appliedEvaluatedProperties,
                this.locationStack,
                this.absoluteKeywordLocationStack,
                builder.ToImmutable());
        }

        /// <summary>
        /// Merge the messages for a given set of results into this result,
        /// applying the given validity at the end, regardless of the individual
        /// validity of the results in the set.
        /// </summary>
        /// <param name="isValid">The ultimate validity of this context.</param>
        /// <param name="level">The current validation level for the context.</param>
        /// <param name="results">The array of results to merege.</param>
        /// <returns>The updated validation context.</returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="MergeChildContext(in ValidationContext, bool)"/>, which merges the elements
        /// that were visited, this simply takes the contextual messages from the children, adds them to this context,
        /// and sets the validity as per the <paramref name="isValid"/> parameter.
        /// </para>
        /// <para>
        /// This is typically used when one of a number of validations may be valid, and the ultimate result is some
        /// function of those child validations, but you wish to capture the details about the validation.
        /// </para>
        /// </remarks>
        public ValidationContext MergeResults(bool isValid, ValidationLevel level, params ValidationContext[] results)
        {
            if (level == ValidationLevel.Flag && isValid)
            {
                return this;
            }

            ImmutableArray<ValidationResult>.Builder builder = ImmutableArray.CreateBuilder<ValidationResult>();

            if (this.results is ImmutableArray<ValidationResult> thisResults)
            {
                builder.AddRange(thisResults);
            }

            foreach (ValidationContext result in results)
            {
                if (result.results is ImmutableArray<ValidationResult> resultResults)
                {
                    builder.AddRange(resultResults);
                }
            }

            return new ValidationContext(
                isValid,
                this.localEvaluatedItemIndex,
                this.localEvaluatedProperties,
                this.appliedEvaluatedItemIndex,
                this.appliedEvaluatedProperties,
                this.locationStack,
                this.absoluteKeywordLocationStack,
                builder.ToImmutable());
        }

        private ImmutableHashSet<JsonEncodedText>? AddLocalEvaluatedProperty(JsonEncodedText propertyName)
        {
            if (this.localEvaluatedProperties is ImmutableHashSet<JsonEncodedText> lep)
            {
                if (!lep.Contains(propertyName))
                {
                    return lep.Add(propertyName);
                }
            }

            return this.localEvaluatedProperties;
        }

        private ImmutableHashSet<JsonEncodedText>? CombineProperties(in ValidationContext childContext)
        {
            if (this.appliedEvaluatedProperties is null)
            {
                return null;
            }

            if (childContext.appliedEvaluatedProperties is not null || childContext.localEvaluatedProperties is not null)
            {
                ImmutableHashSet<JsonEncodedText> result = ImmutableHashSet<JsonEncodedText>.Empty;
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
