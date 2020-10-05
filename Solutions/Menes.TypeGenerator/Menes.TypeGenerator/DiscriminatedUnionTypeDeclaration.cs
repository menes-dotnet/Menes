// <copyright file="DiscriminatedUnionTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// A discriminated union of other types.
    /// </summary>
    public class DiscriminatedUnionTypeDeclaration : TypeDeclaration
    {
        private readonly Dictionary<string, (ITypeDeclaration, string)> typesInUnion = new Dictionary<string, (ITypeDeclaration, string)>();
        private readonly string discriminatorPropertyName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscriminatedUnionTypeDeclaration"/> class.
        /// </summary>
        /// <param name="parent">The parent declaration.</param>
        /// <param name="name">The name of this type.</param>
        /// <param name="discriminatorPropertyName">The name of the common property that discriminates between the types.</param>
        public DiscriminatedUnionTypeDeclaration(IDeclaration parent, string name, string discriminatorPropertyName)
            : base(parent, name)
        {
            this.discriminatorPropertyName = discriminatorPropertyName;
        }

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
