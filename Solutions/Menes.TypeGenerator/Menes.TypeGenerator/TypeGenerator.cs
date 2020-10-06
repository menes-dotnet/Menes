// <copyright file="TypeGenerator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Concurrent;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// Generates and stores types.
    /// </summary>
    public static class TypeGenerator
    {
        private static readonly ConcurrentDictionary<string, TypeDeclarationSyntax> DeclaredTypesByFullName = new ConcurrentDictionary<string, TypeDeclarationSyntax>();

        /// <summary>
        /// Get or add the given type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration.</param>
        /// <param name="createType">A function to create the type.</param>
        /// <returns>The type for the type declaration.</returns>
        public static TypeDeclarationSyntax GetOrAddTypeInNamespace(ITypeDeclaration typeDeclaration, Func<TypeDeclarationSyntax> createType)
        {
            if (!(typeDeclaration.Parent is NamespaceDeclaration))
            {
                throw new ArgumentException("The type must be declared in a namespace, rather than as the child of another type.", nameof(typeDeclaration));
            }

            return DeclaredTypesByFullName.GetOrAdd(typeDeclaration.GetFullyQualifiedName(), s => createType());
        }
    }
}
