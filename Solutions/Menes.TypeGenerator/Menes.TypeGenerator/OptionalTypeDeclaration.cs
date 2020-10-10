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
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionalTypeDeclaration"/> class.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to optionalize.</param>
        internal OptionalTypeDeclaration(ITypeDeclaration typeDeclaration)
        {
            this.TypeDeclaration = typeDeclaration;
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<PropertyDeclaration> Properties => this.TypeDeclaration.Properties;

        /// <inheritdoc/>
        public IReadOnlyCollection<MethodDeclaration> Methods => this.TypeDeclaration.Methods;

        /// <inheritdoc/>
        public IReadOnlyCollection<ITypeDeclaration> TypeDeclarations => this.TypeDeclaration.TypeDeclarations;

        /// <inheritdoc/>
        public string Name => this.TypeDeclaration.Name;

        /// <inheritdoc/>
        public IDeclaration? Parent
        {
            get => this.TypeDeclaration.Parent;
            set => this.TypeDeclaration.Parent = value;
        }

        /// <inheritdoc/>
        public bool ShouldGenerate => this.TypeDeclaration.ShouldGenerate;

        /// <inheritdoc/>
        public bool IsCompoundType => this.TypeDeclaration.IsCompoundType;

        /// <summary>
        /// Gets the type declaration for which this is optional.
        /// </summary>
        public ITypeDeclaration TypeDeclaration { get; }

        /// <inheritdoc/>
        public void AddMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            this.TypeDeclaration.AddMethodDeclaration(methodDeclaration);
        }

        /// <inheritdoc/>
        public void AddPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            this.TypeDeclaration.AddPropertyDeclaration(propertyDeclaration);
        }

        /// <inheritdoc/>
        public void AddTypeDeclaration(ITypeDeclaration typeDeclaration)
        {
            this.TypeDeclaration.AddTypeDeclaration(typeDeclaration);
        }

        /// <inheritdoc/>
        public bool ContainsMethod(string name)
        {
            return this.TypeDeclaration.ContainsMethod(name);
        }

        /// <inheritdoc/>
        public bool ContainsProperty(string name)
        {
            return this.TypeDeclaration.ContainsProperty(name);
        }

        /// <inheritdoc/>
        public bool ContainsTypeDeclaration(string name)
        {
            return this.TypeDeclaration.ContainsTypeDeclaration(name);
        }

        /// <inheritdoc/>
        public TypeDeclarationSyntax GenerateType()
        {
            return this.TypeDeclaration.GenerateType();
        }

        /// <inheritdoc/>
        public IDeclaration GetTypeDeclaration(string name)
        {
            return this.TypeDeclaration.GetTypeDeclaration(name);
        }

        /// <inheritdoc/>
        public bool IsSpecializedBy(ITypeDeclaration type)
        {
            return this.TypeDeclaration.IsSpecializedBy(type);
        }
    }
}
