// <copyright file="AllOfTypeVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;
    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// A visitor for schema using the allOf construction.
    /// </summary>
    public class AllOfTypeVisitor : ITypeVisitor
    {
        private readonly TypeVisitorFactory typeVisitorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllOfTypeVisitor"/> class.
        /// </summary>
        /// <param name="typeVisitorFactory">The type visitor factory to use for nested types.</param>
        public AllOfTypeVisitor(TypeVisitorFactory typeVisitorFactory)
        {
            this.typeVisitorFactory = typeVisitorFactory;
        }

        /// <inheritdoc/>
        public string BuildTypeDeclarationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            if (typeSchema is null)
            {
                throw new ArgumentException($"The schema was not supported by the {nameof(AllOfTypeVisitor)}.", nameof(typeSchema));
            }

            if (typeSchema.UnresolvedReference)
            {
                typeSchema = (OpenApiSchema)document.ResolveReference(typeSchema.Reference);
            }

            if (!HasAllOf(typeSchema))
            {
                throw new ArgumentException($"The schema was not supported by the {nameof(AllOfTypeVisitor)}.", nameof(typeSchema));
            }

            string typeName = typeSchema.GetTypeName(fallbackNameContext);

            if (!types.Any(t => t.Key == typeName))
            {
                types.Add(typeName, this.BuildSyntax(typeName, document, path, operation, typeSchema, types));
            }

            return typeName;
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

            return HasAllOf(typeSchema);
        }

        private static bool HasAllOf(OpenApiSchema typeSchema)
        {
            return typeSchema.IsObjectType() && typeSchema.AllOf?.Count > 0;
        }

        private TypeDeclarationSyntax BuildSyntax(string typeName, OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types)
        {
            TypeDeclarationSyntax tds =
                SF.ClassDeclaration(SF.Identifier(typeName))
                    .AddModifiers(SF.Token(SyntaxKind.PublicKeyword));

            string contentTypeName = $"{typeName}Content";

            foreach (OpenApiSchema allofSchema in typeSchema.AllOf)
            {
                string allOfTypeName = this.typeVisitorFactory.BuildTypeDeclarationSyntax(document, path, operation, allofSchema, types, contentTypeName);

                TypeDeclarationSyntax sourceType = types[allOfTypeName];
                tds = tds.CopyUniquePropertiesFrom(sourceType);

                if (allOfTypeName != contentTypeName)
                {
                    tds = tds.AddMapperMethod(sourceType);
                }
                else
                {
                    types.Remove(contentTypeName);
                }
            }

            return tds;
        }
    }
}
