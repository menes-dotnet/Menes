// <copyright file="NamespaceDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A namespace declaration.
    /// </summary>
    public class NamespaceDeclaration : IDeclaration
    {
        private readonly Dictionary<string, IDeclaration> declarations;

        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceDeclaration"/> class.
        /// </summary>
        /// <param name="name">The local name of the namespace.</param>
        /// <remarks>The name can be a dotted namespace declaration in itself (e.g. <c>Menes.Example.Child</c>) and/or
        /// you can build namespaces by nesting namespace declarations (e.g. one called <c>Menes.Example</c> containing another called <c>Child</c>).
        /// </remarks>
        public NamespaceDeclaration(string name)
        {
            this.declarations = new Dictionary<string, IDeclaration>();
            this.Name = name;
        }

        /// <summary>
        /// Gets the declarations within this namespace.
        /// </summary>
        public IReadOnlyCollection<IDeclaration> Declarations => this.declarations.Values.ToList().AsReadOnly();

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public IDeclaration? Parent { get; set; }

        /// <summary>
        /// Adds a child declaration to this scope.
        /// </summary>
        /// <param name="declaration">The declaration to add.</param>
        public void AddDeclaration(IDeclaration declaration)
        {
            if (declaration.Parent != this && declaration.Parent != null)
            {
                throw new InvalidOperationException($"Incorrect parent for {nameof(declaration)}.");
            }

            declaration.Parent = this;

            if (this.ContainsDeclaration(declaration.Name))
            {
                // Idempotent to multiple adds.
                return;
            }

            this.declarations.Add(declaration.Name, declaration);
        }

        /// <summary>
        /// Determines if the scope contains a particular declaration.
        /// </summary>
        /// <param name="name">The local (unqualified) name of the declaration.</param>
        /// <returns><c>True</c> if an entity with this name is declared in the scope.</returns>
        public bool ContainsDeclaration(string name)
        {
            return this.declarations.ContainsKey(name);
        }

        /// <summary>
        /// Get the directly contained declaration with the given name.
        /// </summary>
        /// <param name="name">The name of the declaration to get.</param>
        /// <returns>An instance of the type with that name.</returns>
        /// <exception cref="ArgumentException">The type with that name was not present in this scope.</exception>
        public IDeclaration GetDeclaration(string name)
        {
            if (this.declarations.TryGetValue(name, out IDeclaration declaration))
            {
                return declaration;
            }

            throw new ArgumentException($"The scope '{this.Name}' does not contain a declaration named '{name}'.", nameof(name));
        }
    }
}
