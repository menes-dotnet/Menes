// <copyright file="ValidationResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;

    /// <summary>
    /// A validation error.
    /// </summary>
    public struct ValidationResult : IEquatable<ValidationResult>
    {
        /// <summary>
        /// Gets a valid validation result.
        /// </summary>
        public static readonly ValidationResult ValidResult = new ValidationResult(true);

        /// <summary>
        /// Gets a valid validation result.
        /// </summary>
        public static readonly ValidationResult InvalidResult = new ValidationResult(false);

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> struct.
        /// </summary>
        /// <param name="error">The error message.</param>
        /// <param name="instanceLocation">The instance location.</param>
        /// <param name="keywordLocation">The keyword location.</param>
        /// <param name="absoluteKeywordLocation">The absolute keyword location.</param>
        /// <param name="errors">The child errors.</param>
        public ValidationResult(string error, string? instanceLocation, string? keywordLocation, string? absoluteKeywordLocation, ImmutableArray<ValidationResult> errors)
        {
            this.Error = error;
            this.InstanceLocation = instanceLocation;
            this.KeywordLocation = keywordLocation;
            this.AbsoluteKeywordLocation = absoluteKeywordLocation;
            this.Errors = errors;
            this.Valid = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> struct.
        /// </summary>
        /// <param name="valid">A value indicating whether this is a valid result.</param>
        /// <param name="instanceLocation">The instance location.</param>
        /// <param name="keywordLocation">The keyword location.</param>
        /// <param name="absoluteKeywordLocation">The absolute keyword location.</param>
        /// <param name="errors">The child errors.</param>
        public ValidationResult(bool valid, string? instanceLocation = null, string? keywordLocation = null, string? absoluteKeywordLocation = null, ImmutableArray<ValidationResult>? errors = null)
        {
            this.Valid = valid;
            this.Error = null;
            this.InstanceLocation = instanceLocation;
            this.KeywordLocation = keywordLocation;
            this.AbsoluteKeywordLocation = absoluteKeywordLocation;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets a value indicating whether the item was valid.
        /// </summary>
        public bool Valid { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string? Error { get; }

        /// <summary>
        /// Gets the instance location.
        /// </summary>
        public string? InstanceLocation { get; }

        /// <summary>
        /// Gets the keyword location.
        /// </summary>
        public string? KeywordLocation { get; }

        /// <summary>
        /// Gets the absolute keyword location.
        /// </summary>
        public string? AbsoluteKeywordLocation { get; }

        /// <summary>
        /// Gets the child errors.
        /// </summary>/
        public ImmutableArray<ValidationResult>? Errors { get; }

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
    }
}