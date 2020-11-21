// <copyright file="ValidationResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    /// <summary>
    /// A validation error.
    /// </summary>
    public class ValidationResult : IEquatable<ValidationResult>
    {
        private bool valid;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> struct.
        /// </summary>
        /// <param name="valid">A value indicating whether this is a valid result.</param>
        /// <param name="message">The error message.</param>
        /// <param name="instanceLocation">The instance location.</param>
        /// <param name="keywordLocation">The keyword location.</param>
        /// <param name="absoluteKeywordLocation">The absolute keyword location.</param>
        /// <param name="errors">The child errors.</param>
        public ValidationResult(bool valid, string? message = null, string? instanceLocation = null, string? keywordLocation = null, string? absoluteKeywordLocation = null, ImmutableArray<ValidationResult>? errors = null)
        {
            this.valid = valid;
            this.Error = message;
            this.InstanceLocation = instanceLocation;
            this.KeywordLocation = keywordLocation;
            this.AbsoluteKeywordLocation = absoluteKeywordLocation;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets a valid validation result.
        /// </summary>
        public static ValidationResult ValidResult => new ValidationResult(true);

        /// <summary>
        /// Gets a valid validation result.
        /// </summary>
        public static ValidationResult InvalidResult => new ValidationResult(false);

        /// <summary>
        /// Gets a value indicating whether the item was valid.
        /// </summary>
        public bool Valid
        {
            get
            {
                return this.valid && (this.Errors is not ImmutableArray<ValidationResult> errors || errors.All(child => child.Valid));
            }
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string? Error { get; private set; }

        /// <summary>
        /// Gets the instance location.
        /// </summary>
        public string? InstanceLocation { get; private set; }

        /// <summary>
        /// Gets the keyword location.
        /// </summary>
        public string? KeywordLocation { get; private set; }

        /// <summary>
        /// Gets the absolute keyword location.
        /// </summary>
        public string? AbsoluteKeywordLocation { get; private set; }

        /// <summary>
        /// Gets the child errors.
        /// </summary>/
        public ImmutableArray<ValidationResult>? Errors { get; private set; }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="left">The lhs of the comparison.</param>
        /// <param name="right">The rhs of the comparison.</param>
        /// <returns><c>True</c> if the left equals the right.</returns>
        public static bool operator ==(ValidationResult left, ValidationResult right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="left">The lhs of the comparison.</param>
        /// <param name="right">The rhs of the comparison.</param>
        /// <returns><c>True</c> if the left does not equals the right.</returns>
        public static bool operator !=(ValidationResult left, ValidationResult right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is ValidationResult error && this.Equals(error);
        }

        /// <inheritdoc/>
        public bool Equals(ValidationResult other)
        {
            return this.Error == other.Error;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Error);
        }

        /// <summary>
        /// Adds a child result to this validation result.
        /// </summary>
        /// <param name="valid">Indicates that the result is invalid.</param>
        /// <param name="message">The message.</param>
        /// <param name="instanceLocation">The instance location.</param>
        /// <param name="keywordLocation">The keyword location.</param>
        /// <param name="absoluteKeywordLocation">The absolute keyword location.</param>
        public void AddResult(bool valid, string? message = null, string? instanceLocation = null, string? keywordLocation = null, string? absoluteKeywordLocation = null)
        {
            this.Errors =
                this.Errors?.Add(new ValidationResult(valid, message, instanceLocation, keywordLocation, absoluteKeywordLocation, ImmutableArray<ValidationResult>.Empty))
                ?? ImmutableArray.Create(new ValidationResult(valid, message, instanceLocation, keywordLocation, absoluteKeywordLocation, ImmutableArray<ValidationResult>.Empty));
        }

        /// <summary>
        /// Sets the validity of the validation result.
        /// </summary>
        /// <param name="valid"><c>True</c> if valid, otherwise false.</param>
        public void SetValid(bool valid)
        {
            this.valid = valid;
        }
    }
}