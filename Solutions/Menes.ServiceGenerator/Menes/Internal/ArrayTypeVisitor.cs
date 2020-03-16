// <copyright file="ArrayTypeVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// A visitor for array types.
    /// </summary>
    public class ArrayTypeVisitor : ITypeVisitor
    {
        private readonly TypeVisitorFactory typeVisitorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayTypeVisitor"/> class.
        /// </summary>
        /// <param name="typeVisitorFactory">The type visitor factory to use for nested types.</param>
        public ArrayTypeVisitor(TypeVisitorFactory typeVisitorFactory)
        {
            this.typeVisitorFactory = typeVisitorFactory;
        }

        /// <inheritdoc/>
        public string BuildTypeDeclarationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            if (typeSchema is null)
            {
                throw new ArgumentException($"The schema was not supported by the {nameof(ArrayTypeVisitor)}.", nameof(typeSchema));
            }

            if (typeSchema.UnresolvedReference)
            {
                typeSchema = (OpenApiSchema)document.ResolveReference(typeSchema.Reference);
            }

            string itemTypeName = this.typeVisitorFactory.BuildTypeDeclarationSyntax(document, path, operation, typeSchema.Items, types, fallbackNameContext);
            return $"IList<{itemTypeName}>";
        }

        /// <inheritdoc/>
        public bool CanVisit(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema)
        {
            if (typeSchema is null)
            {
                return false;
            }

            if (typeSchema.UnresolvedReference)
            {
                typeSchema = (OpenApiSchema)document.ResolveReference(typeSchema.Reference);
            }

            return typeSchema.Type == "array";
        }
    }
}
