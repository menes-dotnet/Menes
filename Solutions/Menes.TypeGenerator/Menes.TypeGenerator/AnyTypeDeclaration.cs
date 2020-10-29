// <copyright file="AnyTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// Represents <c>any</c> type.
    /// </summary>
    public class AnyTypeDeclaration : ITypeDeclaration
    {
        /// <summary>
        /// Gets the instance of the any type declaration.
        /// </summary>
        public static readonly AnyTypeDeclaration Instance = new AnyTypeDeclaration();

        private AnyTypeDeclaration()
        {
            this.Parent = MenesNamespace;
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<MethodDeclaration> Methods => TypeDeclaration.EmptyMethodDeclarations;

        /// <inheritdoc/>
        public IReadOnlyCollection<PropertyDeclaration> Properties => TypeDeclaration.EmptyPropertyDeclarations;

        /// <inheritdoc/>
        public IReadOnlyCollection<ITypeDeclaration> TypeDeclarations => TypeDeclaration.EmptyTypeDeclarations;

        /// <inheritdoc/>
        public string Name => typeof(JsonAny).Name;

        /// <inheritdoc/>
        public IDeclaration? Parent { get; set; }

        /// <inheritdoc/>
        public bool ShouldGenerate => false;

        /// <inheritdoc/>
        public bool IsCompoundType => false;

        private static NamespaceDeclaration MenesNamespace => new NamespaceDeclaration("Menes");

        /// <inheritdoc/>
        public void AddMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public void AddPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public void AddTypeDeclaration(ITypeDeclaration typeDeclaration)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public bool ContainsMethod(string name)
        {
            return false;
        }

        /// <inheritdoc/>
        public bool ContainsProperty(string name)
        {
            return false;
        }

        /// <inheritdoc/>
        public bool ContainsTypeDeclaration(string name)
        {
            return false;
        }

        /// <inheritdoc/>
        public TypeDeclarationSyntax GenerateType()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public ITypeDeclaration GetTypeDeclaration(string name)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public bool IsSpecializedBy(ITypeDeclaration type)
        {
            // Every type is a more specialized version of the Any type.
            return true;
        }
    }
}
