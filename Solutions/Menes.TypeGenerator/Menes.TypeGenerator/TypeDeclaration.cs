// <copyright file="TypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// A base class for type declarations.
    /// </summary>
    public abstract class TypeDeclaration : ITypeDeclaration
    {
        /// <summary>
        /// Gets an empty property declaration list.
        /// </summary>
        internal static readonly IReadOnlyCollection<PropertyDeclaration> EmptyPropertyDeclarations = new List<PropertyDeclaration>().AsReadOnly();

        /// <summary>
        /// Gets an empty property declaration list.
        /// </summary>
        internal static readonly IReadOnlyCollection<ITypeDeclaration> EmptyTypeDeclarations = new List<ITypeDeclaration>().AsReadOnly();

        /// <summary>
        /// Gets an empty property declaration list.
        /// </summary>
        internal static readonly IReadOnlyCollection<MethodDeclaration> EmptyMethodDeclarations = new List<MethodDeclaration>().AsReadOnly();

        private readonly Dictionary<string, ITypeDeclaration> typeDeclarations;
        private readonly Dictionary<string, PropertyDeclaration> propertyDeclarations;
        private readonly Dictionary<string, MethodDeclaration> methodDeclarations;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDeclaration"/> class.
        /// </summary>
        /// <param name="parent">The parent <see cref="IDeclaration"/>.</param>
        /// <param name="name">The name of the type.</param>
        protected TypeDeclaration(IDeclaration parent, string name)
        {
            this.typeDeclarations = new Dictionary<string, ITypeDeclaration>();
            this.propertyDeclarations = new Dictionary<string, PropertyDeclaration>();
            this.methodDeclarations = new Dictionary<string, MethodDeclaration>();
            this.Parent = parent;
            this.Name = name;
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<ITypeDeclaration> TypeDeclarations => this.typeDeclarations.Values.ToList().AsReadOnly();

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public IDeclaration Parent { get; }

        /// <inheritdoc/>
        public IReadOnlyCollection<PropertyDeclaration> Properties => this.propertyDeclarations.Values.ToList().AsReadOnly();

        /// <inheritdoc/>
        public IReadOnlyCollection<MethodDeclaration> Methods => this.methodDeclarations.Values.ToList().AsReadOnly();

        /// <inheritdoc/>
        public bool ShouldGenerate => true;

        /// <inheritdoc/>
        public virtual bool IsCompoundType => true;

        /// <inheritdoc/>
        public virtual void AddMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            if (methodDeclaration.Parent != this)
            {
                throw new InvalidOperationException("Incorrect parent for methodDeclaration.");
            }

            if (this.ContainsMethod(methodDeclaration.Name))
            {
                // Idempotent to multiple adds.
                return;
            }

            this.methodDeclarations.Add(methodDeclaration.Name, methodDeclaration);
        }

        /// <inheritdoc/>
        public virtual void AddPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            if (propertyDeclaration.Parent != this)
            {
                throw new InvalidOperationException("Incorrect parent for propertyDeclaration.");
            }

            if (this.ContainsProperty(propertyDeclaration.JsonPropertyName))
            {
                this.TryReplacePropertyIfPermitted(propertyDeclaration);
                return;
            }

            this.propertyDeclarations.Add(propertyDeclaration.JsonPropertyName, propertyDeclaration);
        }

        /// <inheritdoc/>
        public virtual void AddTypeDeclaration(ITypeDeclaration typeDeclaration)
        {
            if (typeDeclaration.Parent != this)
            {
                throw new InvalidOperationException("Incorrect parent for typeDeclaration.");
            }

            if (this.ContainsTypeDeclaration(typeDeclaration.Name))
            {
                // Idempotent to multiple adds.
                return;
            }

            this.typeDeclarations.Add(typeDeclaration.Name, typeDeclaration);
        }

        /// <inheritdoc/>
        public bool ContainsMethod(string name)
        {
            return this.methodDeclarations.ContainsKey(name);
        }

        /// <inheritdoc/>
        public bool ContainsProperty(string name)
        {
            return this.propertyDeclarations.ContainsKey(name);
        }

        /// <inheritdoc/>
        public bool ContainsTypeDeclaration(string name)
        {
            return this.typeDeclarations.ContainsKey(name);
        }

        /// <inheritdoc/>
        public abstract TypeDeclarationSyntax GenerateType();

        /// <inheritdoc/>
        public IDeclaration GetTypeDeclaration(string name)
        {
            if (this.typeDeclarations.TryGetValue(name, out ITypeDeclaration declaration))
            {
                return declaration;
            }

            throw new ArgumentException($"The type {this.GetFullyQualifiedName()} does not contain the type {name}", nameof(name));
        }

        /// <inheritdoc/>
        public abstract bool IsSpecializedBy(ITypeDeclaration type);

        private void TryReplacePropertyIfPermitted(PropertyDeclaration propertyDeclaration)
        {
            if (this.propertyDeclarations.TryGetValue(propertyDeclaration.JsonPropertyName, out PropertyDeclaration current))
            {
                if (current.Type == propertyDeclaration.Type)
                {
                    // Nothing to do if the property types match.
                    return;
                }

                // If the overriding declaration is more specialized than the existing
                // declaration, then we allow it.
                if (current.Type.IsSpecializedBy(propertyDeclaration.Type))
                {
                    this.propertyDeclarations.Remove(propertyDeclaration.JsonPropertyName);
                    this.propertyDeclarations.Add(propertyDeclaration.JsonPropertyName, propertyDeclaration);
                }
            }
        }
    }
}
