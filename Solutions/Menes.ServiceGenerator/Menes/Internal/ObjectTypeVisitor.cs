// <copyright file="ObjectTypeVisitor.cs" company="Endjin Limited">
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
    public class ObjectTypeVisitor : ITypeVisitor
    {
        private readonly TypeVisitorFactory typeVisitorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectTypeVisitor"/> class.
        /// </summary>
        /// <param name="typeVisitorFactory">The type visitor factory to use for nested types.</param>
        public ObjectTypeVisitor(TypeVisitorFactory typeVisitorFactory)
        {
            this.typeVisitorFactory = typeVisitorFactory;
        }

        /// <inheritdoc/>
        public string BuildTypeDeclarationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            if (typeSchema is null)
            {
                throw new ArgumentException($"The schema was not supported by the {nameof(ObjectTypeVisitor)}.", nameof(typeSchema));
            }

            if (typeSchema.UnresolvedReference)
            {
                typeSchema = (OpenApiSchema)document.ResolveReference(typeSchema.Reference);
            }

            if (!HasObject(typeSchema))
            {
                throw new ArgumentException($"The schema was not supported by the {nameof(ObjectTypeVisitor)}.", nameof(typeSchema));
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

            return HasObject(typeSchema);
        }

        private static bool HasObject(OpenApiSchema typeSchema)
        {
            return typeSchema.IsObjectType();
        }

        private TypeDeclarationSyntax BuildSyntax(string typeName, OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types)
        {
            TypeDeclarationSyntax tds =
                SF.ClassDeclaration(SF.Identifier(typeName))
                    .AddModifiers(SF.Token(SyntaxKind.PublicKeyword));

            foreach (KeyValuePair<string, OpenApiSchema> property in typeSchema.Properties)
            {
                string propertyName = NamingHelpers.ConvertCaseString(property.Key, NamingHelpers.Case.PascalCase);
                string anonymousSchemaTypeName = $"{typeName}{propertyName}";
                string propertyTypeName = this.typeVisitorFactory.BuildTypeDeclarationSyntax(document, path, operation, property.Value, types, anonymousSchemaTypeName);

                tds = tds.AddAutoProperty(propertyTypeName, propertyName);
            }

            return tds;
        }
    }
}
