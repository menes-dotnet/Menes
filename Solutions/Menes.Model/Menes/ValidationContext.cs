// <copyright file="ValidationContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Immutable;

    /// <summary>
    /// Provides a validation context.
    /// </summary>
    public readonly struct ValidationContext
    {
        /// <summary>
        /// Gets the root validation context.
        /// </summary>
        public static readonly ValidationContext Root = new ValidationContext("$", ImmutableArray<(string, string)>.Empty);

        private ValidationContext(string path, ImmutableArray<(string, string)> errors)
        {
            this.Path = path;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets the errors found during validation.
        /// </summary>
        public ImmutableArray<(string, string)> Errors { get; }

        /// <summary>
        /// Gets the path for the context.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets a value indicating whether the validation context is valid.
        /// </summary>
        public bool IsValid => this.Errors.Length == 0;

        /// <summary>
        /// Adds an error to the validation context.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>The updated <see cref="ValidationContext"/>.</returns>
        public ValidationContext WithError(string errorMessage)
        {
            return new ValidationContext(this.Path, this.Errors.Add((this.Path, errorMessage)));
        }

        /// <summary>
        /// Sets the path element in the validation context.
        /// </summary>
        /// <param name="path">The new path element.</param>
        /// <returns>The updated <see cref="ValidationContext"/>.</returns>
        public ValidationContext WithPath(string path)
        {
            return new ValidationContext(path, this.Errors);
        }

        /// <summary>
        /// Validate the given item, appending the specified path
        /// and restoring the path once the results have been returned.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to validate.</typeparam>
        /// <param name="item">The item to validate.</param>
        /// <param name="pathToAppend">The path to append for the item.</param>
        /// <returns>The updated validation context after validation has completed.</returns>
        public ValidationContext Validate<TItem>(in TItem item, string pathToAppend)
            where TItem : struct, IJsonValue
        {
            return item.Validate(this.WithPath(this.Path + pathToAppend)).WithPath(this.Path);
        }

        /// <summary>
        /// Merge the errors from the other validation into this validation context.
        /// </summary>
        /// <param name="contexts">The contexts to merge.</param>
        /// <returns>The validation context with errors merged in.</returns>
        public ValidationContext MergeErrors(params ValidationContext[] contexts)
        {
            ValidationContext context = this;
            foreach (ValidationContext vc in contexts)
            {
                context = context.MergeErrors(vc);
            }

            return context;
        }

        /// <summary>
        /// Merge the errors from the other validation into this validation context.
        /// </summary>
        /// <param name="context1">The context to merge.</param>
        /// <returns>The validation context with errors merged in.</returns>
        public ValidationContext MergeErrors(in ValidationContext context1)
        {
            ValidationContext context = this;
            foreach ((string, string) error in context1.Errors)
            {
                context = new ValidationContext(this.Path, this.Errors.Add(error));
            }

            return context;
        }

        /// <summary>
        /// Merge the errors from the other validation into this validation context.
        /// </summary>
        /// <param name="context1">The first context to merge.</param>
        /// <param name="context2">The second context to merge.</param>
        /// <returns>The validation context with errors merged in.</returns>
        public ValidationContext MergeErrors(in ValidationContext context1, in ValidationContext context2)
        {
            return this.MergeErrors(context1).MergeErrors(context2);
        }

        /// <summary>
        /// Merge the errors from the other validation into this validation context.
        /// </summary>
        /// <param name="context1">The first context to merge.</param>
        /// <param name="context2">The second context to merge.</param>
        /// <param name="context3">The third context to merge.</param>
        /// <returns>The validation context with errors merged in.</returns>
        public ValidationContext MergeErrors(in ValidationContext context1, in ValidationContext context2, in ValidationContext context3)
        {
            return this.MergeErrors(context1).MergeErrors(context2).MergeErrors(context3);
        }

        /// <summary>
        /// Merge the errors from the other validation into this validation context.
        /// </summary>
        /// <param name="context1">The first context to merge.</param>
        /// <param name="context2">The second context to merge.</param>
        /// <param name="context3">The third context to merge.</param>
        /// <param name="context4">The fourth context to merge.</param>
        /// <returns>The validation context with errors merged in.</returns>
        public ValidationContext MergeErrors(in ValidationContext context1, in ValidationContext context2, in ValidationContext context3, in ValidationContext context4)
        {
            return this.MergeErrors(context1).MergeErrors(context2).MergeErrors(context3).MergeErrors(context4);
        }
    }
}
