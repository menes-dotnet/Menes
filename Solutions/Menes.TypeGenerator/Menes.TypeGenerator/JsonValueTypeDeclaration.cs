// <copyright file="JsonValueTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// A simple type declaration for an <see cref="IJsonValue"/>-backed type.
    /// </summary>
    public partial class JsonValueTypeDeclaration : ITypeDeclaration
    {
        private JsonValueTypeDeclaration(string name, string clrType, ValueKind kind)
        {
            this.Name = name;
            this.RawClrType = clrType;
            this.Kind = kind;
        }

        /// <summary>
        /// The underlying JSON value kind of the JSON value type.
        /// </summary>
        public enum ValueKind
        {
            /// <summary>
            /// A numeric type (e.g. integer, single, double).
            /// </summary>
            Number,

            /// <summary>
            /// The decimal numeric type.
            /// </summary>
            /// <remarks>This has to be handled as a special case in the code generator.</remarks>
            Decimal,

            /// <summary>
            /// A string type (e.g. string, guid, date, time).
            /// </summary>
            String,

            /// <summary>
            /// A boolean type.
            /// </summary>
            Boolean,
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<PropertyDeclaration> Properties => TypeDeclaration.EmptyPropertyDeclarations;

        /// <inheritdoc/>
        public IReadOnlyCollection<ITypeDeclaration> TypeDeclarations => TypeDeclaration.EmptyTypeDeclarations;

        /// <inheritdoc/>
        public IReadOnlyCollection<MethodDeclaration> Methods => TypeDeclaration.EmptyMethodDeclarations;

        /// <inheritdoc/>
        public string Name { get; }

        /// <summary>
        /// Gets the CLR type that corresponds to the underlying representation of this json type.
        /// </summary>
        public string RawClrType { get; }

        /// <inheritdoc/>
        public IDeclaration? Parent { get; set; }

        /// <inheritdoc/>
        public bool ShouldGenerate => false;

        /// <inheritdoc/>
        public bool IsCompoundType => false;

        /// <summary>
        /// Gets the value kind of the JSON value.
        /// </summary>
        public ValueKind Kind { get; }

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
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public IDeclaration GetTypeDeclaration(string name)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public bool IsSpecializedBy(ITypeDeclaration type)
        {
            // We are specialized by a validated version of this type.
            return type is ValidatedJsonValueTypeDeclaration validatedType && validatedType.ValidatedType == this;
        }
    }
}
