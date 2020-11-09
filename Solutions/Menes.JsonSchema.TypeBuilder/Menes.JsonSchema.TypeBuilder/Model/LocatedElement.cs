// <copyright file="LocatedElement.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    using System;
    using System.Text.Json;
    using Menes.Json;

    /// <summary>
    /// A <see cref="JsonElement"/> annotated with its absolute keyword location, and the absolute keyword location of its parent.
    /// </summary>
    public readonly struct LocatedElement : IEquatable<LocatedElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocatedElement"/> struct.
        /// </summary>
        /// <param name="absoluteParentKeywordLocation">The absolute location of the parent element.</param>
        /// <param name="absoluteKeywordLocation">The absolute keyword location of this element.</param>
        /// <param name="jsonElement">The corresponding JsonElement containing the related schema.</param>
        public LocatedElement(JsonReference? absoluteParentKeywordLocation, JsonReference absoluteKeywordLocation, JsonElement jsonElement)
        {
            this.AbsoluteParentKeywordLocation = absoluteParentKeywordLocation;
            this.AbsoluteKeywordLocation = absoluteKeywordLocation;
            this.JsonElement = jsonElement;
        }

        /// <summary>
        /// Gets the absolute keyword location of the parent entity in the stack.
        /// </summary>
        public JsonReference? AbsoluteParentKeywordLocation { get; }

        /// <summary>
        /// Gets the absolute keyword location of this element.
        /// </summary>
        public JsonReference AbsoluteKeywordLocation { get; }

        /// <summary>
        /// Gets the corresponding <see cref="JsonElement"/> representing the schema.
        /// </summary>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="left">The lhs of the comparison.</param>
        /// <param name="right">The rhs of the comparison.</param>
        /// <returns><c>true</c> if the values are equal.</returns>
        public static bool operator ==(LocatedElement left, LocatedElement right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="left">The lhs of the comparison.</param>
        /// <param name="right">The rhs of the comparison.</param>
        /// <returns><c>true</c> if the values are not equal.</returns>
        public static bool operator !=(LocatedElement left, LocatedElement right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is LocatedElement element && this.Equals(element);
        }

        /// <inheritdoc/>
        public bool Equals(LocatedElement other)
        {
            return this.AbsoluteKeywordLocation == other.AbsoluteKeywordLocation;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.AbsoluteKeywordLocation);
        }
    }
}
