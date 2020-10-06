// <copyright file="ArrayTypeDeclaration.cs" company="Endjin Limited">
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
    public class ArrayTypeDeclaration : ITypeDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayTypeDeclaration"/> class.
        /// </summary>
        /// <param name="itemType">The type of the item in the array.</param>
        public ArrayTypeDeclaration(ITypeDeclaration itemType)
        {
            this.ItemType = itemType;
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<MethodDeclaration> Methods => TypeDeclaration.EmptyMethodDeclarations;

        /// <inheritdoc/>
        public IReadOnlyCollection<PropertyDeclaration> Properties => TypeDeclaration.EmptyPropertyDeclarations;

        /// <inheritdoc/>
        public IReadOnlyCollection<ITypeDeclaration> TypeDeclarations => TypeDeclaration.EmptyTypeDeclarations;

        /// <inheritdoc/>
        public string Name => $"Menes.JsonArray<{this.ItemType.GetFullyQualifiedName()}>";

        /// <inheritdoc/>
        public IDeclaration? Parent => null;

        /// <inheritdoc/>
        public bool ShouldGenerate => false;

        /// <summary>
        /// Gets the type of the item in the array.
        /// </summary>
        public ITypeDeclaration ItemType { get; }

        /// <inheritdoc/>
        /// <remarks>
        /// The array type is only compound if the elements in the array are compound, or it is an array of arrays.
        /// If not, it is simple.
        /// </remarks>
        public bool IsCompoundType => this.ItemType.IsCompoundType || this.ItemType is ArrayTypeDeclaration;

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
        public IDeclaration GetTypeDeclaration(string name)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public bool IsSpecializedBy(ITypeDeclaration type)
        {
            // The array is specialized by an array of a type which is a specialized version of this item type.
            return type is ArrayTypeDeclaration arrayType && this.ItemType.IsSpecializedBy(arrayType.ItemType);
        }
    }
}
