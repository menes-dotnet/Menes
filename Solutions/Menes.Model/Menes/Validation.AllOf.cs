// <copyright file="Validation.AllOf.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Valdation helpers.
    /// </summary>
    public static partial class Validation
    {
        private const string AllOfStartErrorMessage = "core 9.2.1.1. allOf: The element did not match all of the expected types.";
        private const string AllOfEndErrorMessage = "core 9.2.1.1. allOf: (see above)";

        /// <summary>
        /// Validates that all types were correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="children">The validated contexts.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateAllOf(in ValidationContext validationContext, params ValidationContext[] children)
        {
            bool isValid = true;

            for (int i = 0; i < children.Length; ++i)
            {
                if (!children[i].IsValid)
                {
                    isValid = false;
                    break;
                }
            }

            return isValid ? validationContext : validationContext.WithError(AllOfStartErrorMessage).MergeErrors(children).WithError(AllOfEndErrorMessage);
        }

        /// <summary>
        /// Validates that all types were correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="child1">The results of validating the element against the first type.</param>
        /// <param name="child2">The results of validating the element against the second type.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateAllOf(in ValidationContext validationContext, in ValidationContext child1, in ValidationContext child2)
        {
            return (child1.IsValid && child2.IsValid) ? validationContext : validationContext.WithError(AllOfStartErrorMessage).MergeErrors(child1, child2).WithError(AllOfEndErrorMessage);
        }

        /// <summary>
        /// Validates that all types were correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="child1">The results of validating the element against the first type.</param>
        /// <param name="child2">The results of validating the element against the second type.</param>
        /// <param name="child3">The results of validating the element against the third type.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateAllOf(in ValidationContext validationContext, in ValidationContext child1, in ValidationContext child2, in ValidationContext child3)
        {
            return (child1.IsValid && child2.IsValid && child3.IsValid) ? validationContext : validationContext.WithError(AllOfStartErrorMessage).MergeErrors(child1, child2, child3).WithError(AllOfEndErrorMessage);
        }

        /// <summary>
        /// Validates that all types were correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="child1">The results of validating the element against the first type.</param>
        /// <param name="child2">The results of validating the element against the second type.</param>
        /// <param name="child3">The results of validating the element against the third type.</param>
        /// <param name="child4">The results of validating the element against the fourth type.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateAllOf(in ValidationContext validationContext, in ValidationContext child1, in ValidationContext child2, in ValidationContext child3, in ValidationContext child4)
        {
            return (child1.IsValid && child2.IsValid && child3.IsValid && child4.IsValid) ? validationContext : validationContext.WithError(AllOfStartErrorMessage).MergeErrors(child1, child2, child3, child4).WithError(AllOfEndErrorMessage);
        }
    }
}
