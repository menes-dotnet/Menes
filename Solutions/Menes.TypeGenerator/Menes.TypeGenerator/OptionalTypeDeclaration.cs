// <copyright file="OptionalTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    ///  An optional version of a type declaration.
    /// </summary>
    public class OptionalTypeDeclaration : ITypeDeclaration
    {
        private readonly ITypeDeclaration typeDeclaration;

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionalTypeDeclaration"/> class.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to optionalize.</param>
        internal OptionalTypeDeclaration(ITypeDeclaration typeDeclaration)
        {
            this.typeDeclaration = typeDeclaration;
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<PropertyDeclaration> Properties => this.typeDeclaration.Properties;

        /// <inheritdoc/>
        public IReadOnlyCollection<MethodDeclaration> Methods => this.typeDeclaration.Methods;

        /// <inheritdoc/>
        public IReadOnlyCollection<ITypeDeclaration> TypeDeclarations => this.typeDeclaration.TypeDeclarations;

        /// <inheritdoc/>
        public string Name => this.typeDeclaration.Name;

        /// <inheritdoc/>
        public IDeclaration? Parent => this.typeDeclaration.Parent;

        /// <inheritdoc/>
        public bool ShouldGenerate => this.typeDeclaration.ShouldGenerate;

        /// <inheritdoc/>
        public bool IsCompoundType => this.typeDeclaration.IsCompoundType;

        /// <inheritdoc/>
        public void AddMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            this.typeDeclaration.AddMethodDeclaration(methodDeclaration);
        }

        /// <inheritdoc/>
        public void AddPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            this.typeDeclaration.AddPropertyDeclaration(propertyDeclaration);
        }

        /// <inheritdoc/>
        public void AddTypeDeclaration(ITypeDeclaration typeDeclaration)
        {
            this.typeDeclaration.AddTypeDeclaration(typeDeclaration);
        }

        /// <inheritdoc/>
        public bool ContainsMethod(string name)
        {
            return this.typeDeclaration.ContainsMethod(name);
        }

        /// <inheritdoc/>
        public bool ContainsProperty(string name)
        {
            return this.typeDeclaration.ContainsProperty(name);
        }

        /// <inheritdoc/>
        public bool ContainsTypeDeclaration(string name)
        {
            return this.typeDeclaration.ContainsTypeDeclaration(name);
        }

        /// <inheritdoc/>
        public TypeDeclarationSyntax GenerateType()
        {
            return this.typeDeclaration.GenerateType();
        }

        /// <inheritdoc/>
        public IDeclaration GetTypeDeclaration(string name)
        {
            return this.typeDeclaration.GetTypeDeclaration(name);
        }

        /// <inheritdoc/>
        public bool IsSpecializedBy(ITypeDeclaration type)
        {
            return this.typeDeclaration.IsSpecializedBy(type);
        }
    }
}
