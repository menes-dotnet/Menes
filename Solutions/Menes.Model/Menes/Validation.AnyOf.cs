// <copyright file="Validation.AnyOf.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Valdation helpers.
    /// </summary>
    public static partial class Validation
    {
        private const string OneOfStartErrorMessage = "core 9.2.1.2. anyOf: The element did not match any of the expected types.";
        private const string OneOfEndErrorMessage = "core 9.2.1.2. anyOf: (see above)";

        /// <summary>
        /// Validates that one or more types were correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="children">The validated contexts.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateAnyOf(in ValidationContext validationContext, params ValidationContext[] children)
        {
            bool isValid = false;

            for (int i = 0; i < children.Length; ++i)
            {
                if (children[i].IsValid)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid ? validationContext : validationContext.WithError(OneOfStartErrorMessage).MergeErrors(children).WithError(OneOfEndErrorMessage);
        }

        /// <summary>
        /// Validates that exactly one type was correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="child1">The results of validating the element against the first type.</param>
        /// <param name="child2">The results of validating the element against the second type.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateAnyOf(in ValidationContext validationContext, in ValidationContext child1, in ValidationContext child2)
        {
            return (child1.IsValid || child2.IsValid) ? validationContext : validationContext.WithError(OneOfStartErrorMessage).MergeErrors(child1, child2).WithError(OneOfEndErrorMessage);
        }

        /// <summary>
        /// Validates that exactly one type was correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="child1">The results of validating the element against the first type.</param>
        /// <param name="child2">The results of validating the element against the second type.</param>
        /// <param name="child3">The results of validating the element against the third type.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateAnyOf(in ValidationContext validationContext, in ValidationContext child1, in ValidationContext child2, in ValidationContext child3)
        {
            return (child1.IsValid || child2.IsValid || child3.IsValid) ? validationContext : validationContext.WithError(OneOfStartErrorMessage).MergeErrors(child1, child2, child3).WithError(OneOfEndErrorMessage);
        }

        /// <summary>
        /// Validates that exactly one type was correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="child1">The results of validating the element against the first type.</param>
        /// <param name="child2">The results of validating the element against the second type.</param>
        /// <param name="child3">The results of validating the element against the third type.</param>
        /// <param name="child4">The results of validating the element against the fourth type.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateAnyOf(in ValidationContext validationContext, in ValidationContext child1, in ValidationContext child2, in ValidationContext child3, in ValidationContext child4)
        {
            return (child1.IsValid || child2.IsValid || child3.IsValid || child4.IsValid) ? validationContext : validationContext.WithError(OneOfStartErrorMessage).MergeErrors(child1, child2, child3, child4).WithError(OneOfEndErrorMessage);
        }
    }
}
