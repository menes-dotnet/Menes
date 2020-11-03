// <copyright file="Validation.OneOf.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Valdation helpers.
    /// </summary>
    public static partial class Validation
    {
        private const string OneOfStartMessageWithNoMatches = "core 9.2.1.3. oneOf: The element did not match any of the expected types.";
        private const string OneOfStartMessageWithMultipleMatches = "core 9.2.1.3. oneOf: The element matched several of the expected types.";
        private const string OneOfEndErrorMessage = "core 9.2.1.3. oneOf: (see above)";

        /// <summary>
        /// Validates that one or more types were correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="children">The validated contexts.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateOneOf(in ValidationContext validationContext, params ValidationContext[] children)
        {
            int isValid = 0;

            for (int i = 0; i < children.Length; ++i)
            {
                if (children[i].IsValid)
                {
                    isValid++;
                }
            }

            return isValid == 1 ? validationContext : isValid == 0 ? validationContext.WithError(OneOfStartMessageWithNoMatches).MergeErrors(children).WithError(OneOfEndErrorMessage) : validationContext.WithError(OneOfStartMessageWithMultipleMatches).MergeErrors(children).WithError(OneOfEndErrorMessage);
        }

        /// <summary>
        /// Validates that exactly one type was correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="child1">The results of validating the element against the first type.</param>
        /// <param name="child2">The results of validating the element against the second type.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateOneOf(in ValidationContext validationContext, in ValidationContext child1, in ValidationContext child2)
        {
            int isValid = 0;
            if (child1.IsValid)
            {
                isValid++;
            }

            if (child2.IsValid)
            {
                isValid++;
            }

            return isValid == 1 ? validationContext : isValid == 0 ? validationContext.WithError(OneOfStartMessageWithNoMatches).MergeErrors(child1, child2).WithError(OneOfEndErrorMessage) : validationContext.WithError(OneOfStartMessageWithMultipleMatches).MergeErrors(child1, child2).WithError(OneOfEndErrorMessage);
        }

        /// <summary>
        /// Validates that exactly one type was correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="child1">The results of validating the element against the first type.</param>
        /// <param name="child2">The results of validating the element against the second type.</param>
        /// <param name="child3">The results of validating the element against the third type.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateOneOf(in ValidationContext validationContext, in ValidationContext child1, in ValidationContext child2, in ValidationContext child3)
        {
            int isValid = 0;
            if (child1.IsValid)
            {
                isValid++;
            }

            if (child2.IsValid)
            {
                isValid++;
            }

            if (child3.IsValid)
            {
                isValid++;
            }

            return isValid == 1 ? validationContext : isValid == 0 ? validationContext.WithError(OneOfStartMessageWithNoMatches).MergeErrors(child1, child2, child3).WithError(OneOfEndErrorMessage) : validationContext.WithError(OneOfStartMessageWithMultipleMatches).MergeErrors(child1, child2, child3).WithError(OneOfEndErrorMessage);
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
        public static ValidationContext ValidateOneOf(in ValidationContext validationContext, in ValidationContext child1, in ValidationContext child2, in ValidationContext child3, in ValidationContext child4)
        {
            int isValid = 0;
            if (child1.IsValid)
            {
                isValid++;
            }

            if (child2.IsValid)
            {
                isValid++;
            }

            if (child3.IsValid)
            {
                isValid++;
            }

            if (child4.IsValid)
            {
                isValid++;
            }

            return isValid == 1 ? validationContext : isValid == 0 ? validationContext.WithError(OneOfStartMessageWithNoMatches).MergeErrors(child1, child2, child3, child4).WithError(OneOfEndErrorMessage) : validationContext.WithError(OneOfStartMessageWithMultipleMatches).MergeErrors(child1, child2, child3, child4).WithError(OneOfEndErrorMessage);
        }
    }
}
