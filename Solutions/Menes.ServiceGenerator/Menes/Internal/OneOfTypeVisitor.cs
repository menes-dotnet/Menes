// <copyright file="OneOfTypeVisitor.cs" company="Endjin Limited">
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
    public class OneOfTypeVisitor : ITypeVisitor
    {
        private readonly TypeVisitorFactory typeVisitorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfTypeVisitor"/> class.
        /// </summary>
        /// <param name="typeVisitorFactory">The type visitor factory to use for nested types.</param>
        public OneOfTypeVisitor(TypeVisitorFactory typeVisitorFactory)
        {
            this.typeVisitorFactory = typeVisitorFactory;
        }

        /// <inheritdoc/>
        public string BuildTypeDeclarationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            if (typeSchema is null)
            {
                throw new ArgumentException($"The schema was not supported by the {nameof(OneOfTypeVisitor)}.", nameof(typeSchema));
            }

            if (typeSchema.UnresolvedReference)
            {
                typeSchema = (OpenApiSchema)document.ResolveReference(typeSchema.Reference);
            }

            if (!HasOneOf(typeSchema))
            {
                throw new ArgumentException($"The schema was not supported by the {nameof(OneOfTypeVisitor)}.", nameof(typeSchema));
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

            return HasOneOf(typeSchema);
        }

        private static bool HasOneOf(OpenApiSchema typeSchema)
        {
            return typeSchema.IsObjectType() && typeSchema.OneOf?.Count > 0;
        }

        private TypeDeclarationSyntax BuildSyntax(string typeName, OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types)
        {
            TypeDeclarationSyntax tds =
                SF.ClassDeclaration(SF.Identifier(typeName))
                    .AddModifiers(SF.Token(SyntaxKind.PublicKeyword));

            string contentTypeName = $"{typeName}Content";
            int contentIndex = 0;

            foreach (OpenApiSchema anyOfSchema in typeSchema.OneOf)
            {
                string anonymousSchemaTypeName = NamingHelpers.BuildAnonymousSchemaTypeName(contentTypeName, contentIndex);
                string anyOfTypeName = this.typeVisitorFactory.BuildTypeDeclarationSyntax(document, path, operation, anyOfSchema, types, anonymousSchemaTypeName);

                if (anyOfTypeName == anonymousSchemaTypeName)
                {
                    // We've used an anonymous schema, so we need to increment a numeric identifier to distinguish the next one
                    // We recommend not using multiple anonymous schema for this reason - prefer a referenced type.
                    contentIndex++;
                }

                TypeDeclarationSyntax sourceType = types[anyOfTypeName];
                tds = tds.CopyUniquePropertiesFrom(sourceType);
                tds = tds.AddMapperMethod(sourceType);
            }

            return tds;
        }
    }
}
