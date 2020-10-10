﻿// <copyright file="DiscriminatedUnionTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// A discriminated union of other types.
    /// </summary>
    public class DiscriminatedUnionTypeDeclaration : TypeDeclaration
    {
        private readonly Dictionary<string, (ITypeDeclaration, string)> typesInUnion = new Dictionary<string, (ITypeDeclaration, string)>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscriminatedUnionTypeDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name of this type.</param>
        /// <param name="discriminatorPropertyName">The name of the common property that discriminates between the types.</param>
        public DiscriminatedUnionTypeDeclaration(string name, string discriminatorPropertyName)
            : base(name)
        {
            this.DiscriminatorPropertyName = discriminatorPropertyName;
        }

        /// <inheritdoc/>
        /// <remarks>
        /// The discriminated union type is a compound type if and only if any of its children is a compound type, Union type or Discriminated Union type.
        /// </remarks>
        public override bool IsCompoundType => this.typesInUnion.Any(t => t.Value.Item1 is UnionTypeDeclaration || t.Value.Item1 is DiscriminatedUnionTypeDeclaration || t.Value.Item1.IsCompoundType);

        /// <summary>
        /// Gets the discriminator property name.
        /// </summary>
        public string DiscriminatorPropertyName { get; }

        /// <summary>
        /// Adds the given type to the union.
        /// </summary>
        /// <param name="type">The type to add to the union.</param>
        /// <param name="discriminatorValue">The value of the discriminator for this type.</param>
        public void AddTypeToUnion(ITypeDeclaration type, string discriminatorValue)
        {
            // Idempotent based on the name of the type.
            this.typesInUnion.TryAdd(type.GetFullyQualifiedName(), (type, discriminatorValue));
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
