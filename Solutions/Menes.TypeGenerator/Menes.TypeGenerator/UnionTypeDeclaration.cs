// <copyright file="UnionTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// A union of other types.
    /// </summary>
    public class UnionTypeDeclaration : TypeDeclaration
    {
        private readonly Dictionary<string, ITypeDeclaration> typesInUnion = new Dictionary<string, ITypeDeclaration>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UnionTypeDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name of this type.</param>
        public UnionTypeDeclaration(string name)
            : base(name)
        {
        }

        /// <inheritdoc/>
        /// <remarks>
        /// The union type is a compound type if and only if any of its children is a compound type, Union type or Discriminated Union type.
        /// </remarks>
        public override bool IsCompoundType => this.typesInUnion.Any(t => t.Value is UnionTypeDeclaration || t.Value is DiscriminatedUnionTypeDeclaration || t.Value.IsCompoundType);

        /// <summary>
        /// Adds the given type to the union.
        /// </summary>
        /// <param name="type">The type to add to the union.</param>
        public void AddTypeToUnion(ITypeDeclaration type)
        {
            // Idempotent based on the name of the type.
            this.typesInUnion.TryAdd(type.GetFullyQualifiedName(), type);
        }

        /// <summary>
        /// Gets a value which indicates whether the given type is a part of this union.
        /// </summary>
        /// <param name="fullyQualifiedTypeName">The fully qualified name of the type.</param>
        /// <returns><c>True</c> if the type is in the union, otherwise false.</returns>
        public bool ContainsTypeInUnion(string fullyQualifiedTypeName)
        {
            return this.typesInUnion.ContainsKey(fullyQualifiedTypeName);
        }

        /// <inheritdoc/>
        public override TypeDeclarationSyntax GenerateType()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override bool IsSpecializedBy(ITypeDeclaration type)
        {
            return this.ContainsTypeInUnion(type.GetFullyQualifiedName());
        }

        /// <inheritdoc/>
        public override void AddPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public override void AddMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            throw new NotSupportedException();
        }
    }
}
