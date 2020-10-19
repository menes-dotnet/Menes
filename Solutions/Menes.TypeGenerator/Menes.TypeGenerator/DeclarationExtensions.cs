// <copyright file="DeclarationExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods for <see cref="IDeclaration"/>.
    /// </summary>
    public static class DeclarationExtensions
    {
        /// <summary>
        /// Gets the fully qualified name of a declaration.
        /// </summary>
        /// <param name="declaration">The <see cref="IDeclaration"/> for which to get the fully qualified name.</param>
        /// <param name="separator">The separator to insert between scope name elements.</param>
        /// <returns>The fully qualified scope name, using the given <paramref name="separator"/>.</returns>
        /// <remarks>
        /// If you have three nested <see cref="IDeclaration"/> instances, with <see cref="IDeclaration.Name"/> values of =<c>Menes</c>, <c>TypeGenerator</c> and <c>Example</c>, this would
        /// then the <see cref="GetFullyQualifiedName(IDeclaration, string)"/> for <c>Example</c> would be <c>Menes.TypeGenerator.Example</c>.
        /// </remarks>
        public static string GetFullyQualifiedName(this IDeclaration declaration, string separator = ".")
        {
            var items = new List<string>();
            IDeclaration? current = declaration;
            while (!(current is null))
            {
                items.Insert(0, current.Name);
                current = current.Parent;
            }

            return string.Join(separator, items);
        }

        /// <summary>
        /// Gets the fully qualified name of a declaration.
        /// </summary>
        /// <param name="declaration">The parent <see cref="IDeclaration"/> for which to get the fully qualified name of its child.</param>
        /// <param name="childName">The name of the child for which to get the fully qualified name.</param>
        /// <param name="separator">The separator to insert between scope name elements.</param>
        /// <returns>The fully qualified scope name, using the given <paramref name="separator"/>.</returns>
        public static string GetFullyQualifiedNameForChild(this IDeclaration declaration, string childName, string separator = ".")
        {
            var items = new List<string>();
            IDeclaration? current = declaration;
            while (!(current is null))
            {
                items.Insert(0, current.Name);
                current = current.Parent;
            }

            items.Add(childName);

            return string.Join(separator, items);
        }
    }
}
