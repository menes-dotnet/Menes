// <copyright file="NodatimeTypeVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// A type visitor for Nodatime date/time types.
    /// </summary>
    /// <remarks>
    /// This should typically be the last, fall-back type visitor in a set of visitors.
    /// </remarks>
    public class NodatimeTypeVisitor : ITypeVisitor
    {
        /// <inheritdoc/>
        public string BuildTypeDeclarationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            if (typeSchema is null)
            {
                throw new ArgumentException($"The schema was not supported by the {nameof(NodatimeTypeVisitor)}.", nameof(typeSchema));
            }

            if (typeSchema.UnresolvedReference)
            {
                typeSchema = (OpenApiSchema)document.ResolveReference(typeSchema.Reference);
            }

            return typeSchema switch
            {
                { Type: "string", Format: "date", Nullable: true } => "OffsetDate?",
                { Type: "string", Format: "date" } => "OffsetDate",
                { Type: "string", Format: "date-time", Nullable: true } => "OffsetDateTime?",
                { Type: "string", Format: "date-time" } => "OffsetDateTime",
                _ => throw new ArgumentException($"The schema was not supported by the {nameof(NodatimeTypeVisitor)}.", nameof(typeSchema)),
            };
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

            return typeSchema switch
            {
                { Type: "string", Format: "date", Nullable: true } => true,
                { Type: "string", Format: "date" } => true,
                { Type: "string", Format: "date-time", Nullable: true } => true,
                { Type: "string", Format: "date-time" } => true,
                _ => false,
            };
        }
    }
}
