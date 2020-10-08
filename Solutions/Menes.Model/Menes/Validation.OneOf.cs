// <copyright file="Validation.OneOf.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Valdation helpers.
    /// </summary>
    public static partial class Validation
    {
        /// <summary>
        /// Validates that exactly one type was correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="children">The validated contexts.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateOneOf(in ValidationContext validationContext, params (string, ValidationContext)[] children)
        {
            StringBuilder? builder = null;
            bool isValid = false;

            for (int i = 0; i < children.Length - 1; ++i)
            {
                (string type1, ValidationContext child1) = children[i];

                if (child1.IsValid)
                {
                    isValid = true;
                    for (int j = i + 1; j < children.Length; ++j)
                    {
                        (string type2, ValidationContext child2) = children[j];

                        if (child2.IsValid)
                        {
                            builder = EnsureBuilderForOneOf(type1, builder);
                            builder.Append(", ");
                            builder.Append(type2);
                        }
                    }

                    if (builder is StringBuilder result)
                    {
                        return validationContext.WithError(result.ToString());
                    }
                }
            }

            return isValid ? validationContext : validationContext.MergeErrors(children.Select(c => c.Item2).ToArray());
        }

        /// <summary>
        /// Validates that exactly one type was correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="child1">The results of validating the element against the first type.</param>
        /// <param name="child2">The results of validating the element against the second type.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateOneOf(in ValidationContext validationContext, in (string type, ValidationContext context) child1, in (string type, ValidationContext context) child2)
        {
            StringBuilder? builder = null;
            bool isValid = false;

            if (child1.context.IsValid)
            {
                isValid = true;
                if (child2.context.IsValid)
                {
                    builder = EnsureBuilderForOneOf(child1.type, builder);
                    builder.Append(", ");
                    builder.Append(child2.type);
                }
            }
            else if (child2.context.IsValid)
            {
                isValid = true;
            }

            if (builder is StringBuilder result)
            {
                return validationContext.WithError(result.ToString());
            }

            return isValid ? validationContext : validationContext.MergeErrors(child1.context, child2.context);
        }

        /// <summary>
        /// Validates that exactly one type was correctly validated.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="child1">The results of validating the element against the first type.</param>
        /// <param name="child2">The results of validating the element against the second type.</param>
        /// <param name="child3">The results of validating the element against the third type.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public static ValidationContext ValidateOneOf(in ValidationContext validationContext, in (string type, ValidationContext context) child1, in (string type, ValidationContext context) child2, in (string type, ValidationContext context) child3)
        {
            StringBuilder? builder = null;
            bool isValid = false;

            if (child1.context.IsValid)
            {
                isValid = true;
                if (child2.context.IsValid)
                {
                    builder = EnsureBuilderForOneOf(child1.type, builder);
                    builder.Append(", ");
                    builder.Append(child2.type);
                }

                if (child3.context.IsValid)
                {
                    builder = EnsureBuilderForOneOf(child1.type, builder);
                    builder.Append(", ");
                    builder.Append(child3.type);
                }
            }
            else if (child2.context.IsValid)
            {
                isValid = true;

                if (child3.context.IsValid)
                {
                    builder = EnsureBuilderForOneOf(child2.type, builder);
                    builder.Append(", ");
                    builder.Append(child3.type);
                }
            }
            else if (child3.context.IsValid)
            {
                isValid = true;
            }

            if (builder is StringBuilder result)
            {
                return validationContext.WithError(result.ToString());
            }

            return isValid ? validationContext : validationContext.MergeErrors(child1.context, child2.context, child3.context);
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
        public static ValidationContext ValidateOneOf(in ValidationContext validationContext, in (string type, ValidationContext context) child1, in (string type, ValidationContext context) child2, in (string type, ValidationContext context) child3, in (string type, ValidationContext context) child4)
        {
            StringBuilder? builder = null;
            bool isValid = false;

            if (child1.context.IsValid)
            {
                isValid = true;
                if (child2.context.IsValid)
                {
                    builder = EnsureBuilderForOneOf(child1.type, builder);
                    builder.Append(", ");
                    builder.Append(child2.type);
                }

                if (child3.context.IsValid)
                {
                    builder = EnsureBuilderForOneOf(child1.type, builder);
                    builder.Append(", ");
                    builder.Append(child3.type);
                }

                if (child4.context.IsValid)
                {
                    builder = EnsureBuilderForOneOf(child1.type, builder);
                    builder.Append(", ");
                    builder.Append(child4.type);
                }
            }
            else if (child2.context.IsValid)
            {
                isValid = true;

                if (child3.context.IsValid)
                {
                    builder = EnsureBuilderForOneOf(child2.type, builder);
                    builder.Append(", ");
                    builder.Append(child3.type);
                }

                if (child4.context.IsValid)
                {
                    builder = EnsureBuilderForOneOf(child2.type, builder);
                    builder.Append(", ");
                    builder.Append(child4.type);
                }
            }
            else if (child3.context.IsValid)
            {
                isValid = true;

                if (child4.context.IsValid)
                {
                    builder = EnsureBuilderForOneOf(child3.type, builder);
                    builder.Append(", ");
                    builder.Append(child4.type);
                }
            }
            else if (child4.context.IsValid)
            {
                isValid = true;
            }

            if (builder is StringBuilder result)
            {
                return validationContext.WithError(result.ToString());
            }

            return isValid ? validationContext : validationContext.MergeErrors(child1.context, child2.context, child3.context, child4.context);
        }

        private static StringBuilder EnsureBuilderForOneOf(string firstType, StringBuilder? builder)
        {
            return builder ?? new StringBuilder($"core 9.2.1.3. oneOf: The type validated against {firstType}");
        }
    }
}
