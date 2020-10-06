// <copyright file="ITypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// A type declaration.
    /// </summary>
    public interface ITypeDeclaration : IDeclaration
    {
        /// <summary>
        /// Gets the properties declared in the type.
        /// </summary>
        IReadOnlyCollection<PropertyDeclaration> Properties { get; }

        /// <summary>
        /// Gets the methods declared in the type.
        /// </summary>
        IReadOnlyCollection<MethodDeclaration> Methods { get; }

        /// <summary>
        /// Gets the type declarations found within the type.
        /// </summary>
        IReadOnlyCollection<ITypeDeclaration> TypeDeclarations { get; }

        /// <summary>
        /// Gets a value indicating whether the type should be generated.
        /// </summary>
        bool ShouldGenerate { get; }

        /// <summary>
        /// Gets a value indicating whether this is a compound type.
        /// </summary>
        /// <remarks>
        /// If this is a compound type, it references other types in its declaration
        /// and needs to be generated with the <see cref="Reference"/> wrapper pattern.
        /// </remarks>
        bool IsCompoundType { get; }

        /// <summary>
        /// Determines if the type contains a property of a particular name.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <returns><c>True</c> if a property with this name is declared in the scope.</returns>
        bool ContainsProperty(string name);

        /// <summary>
        /// Determines if the type contains a method of a particular name.
        /// </summary>
        /// <param name="name">The name of the method.</param>
        /// <returns><c>True</c> if a method with this name is declared in the scope.</returns>
        bool ContainsMethod(string name);

        /// <summary>
        /// Adds a property declaration to the scope.
        /// </summary>
        /// <param name="propertyDeclaration">The property declaration to add.</param>
        void AddPropertyDeclaration(PropertyDeclaration propertyDeclaration);

        /// <summary>
        /// Adds a method declaration to the scope.
        /// </summary>
        /// <param name="methodDeclaration">The method declaration to add.</param>
        void AddMethodDeclaration(MethodDeclaration methodDeclaration);

        /// <summary>
        /// Determines if the scope contains a particular declaration.
        /// </summary>
        /// <param name="name">The local (unqualified) name of the declaration.</param>
        /// <returns><c>True</c> if an entity with this name is declared in the scope.</returns>
        bool ContainsTypeDeclaration(string name);

        /// <summary>
        /// Get the directly contained declaration with the given name.
        /// </summary>
        /// <param name="name">The name of the declaration to get.</param>
        /// <returns>An instance of the type with that name.</returns>
        /// <exception cref="ArgumentException">The type with that name was not present in this scope.</exception>
        IDeclaration GetTypeDeclaration(string name);

        /// <summary>
        /// Adds a child type declaration to this type.
        /// </summary>
        /// <param name="typeDeclaration">The declaration to add.</param>
        void AddTypeDeclaration(ITypeDeclaration typeDeclaration);

        /// <summary>
        /// Generate the type represented by this instance.
        /// </summary>
        /// <returns>An instance of a <see cref="TypeDeclarationSyntax"/> for this instanace.</returns>
        TypeDeclarationSyntax GenerateType();

        /// <summary>
        /// Determines if this type declaration is specialized by the given type declaration.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>True</c> if the <paramref name="type"/> is a more constrained version of this type.</returns>
        /// <remarks>
        /// This is typically used to determine in an allOf type whether a property with a less-constrained value in one of the allOf types (e.g. 'any'
        /// or 'oneOf' a number of types) should be overridden by a property of the same name with a compatible, but more-constrained value in another of the allOf types
        /// (e.g. one of the 'oneOf' types).
        /// </remarks>
        bool IsSpecializedBy(ITypeDeclaration type);
    }
}
