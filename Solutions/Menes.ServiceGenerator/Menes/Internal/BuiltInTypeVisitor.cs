// <copyright file="BuiltInTypeVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// A type visitor for the standard built-in types.
    /// </summary>
    /// <remarks>
    /// This should typically be the last, fall-back type visitor in a set of visitors.
    /// </remarks>
    public class BuiltInTypeVisitor : ITypeVisitor
    {
        /// <inheritdoc/>
        public string BuildTypeDeclarationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            if (typeSchema is null)
            {
                return "object";
            }

            if (typeSchema.UnresolvedReference)
            {
                typeSchema = (OpenApiSchema)document.ResolveReference(typeSchema.Reference);
            }

            return typeSchema switch
            {
                { Type: "string", Format: "date", Nullable: true } => "DateTimeOffset?",
                { Type: "string", Format: "date" } => "DateTimeOffset",
                { Type: "string", Format: "date-time", Nullable: true } => "DateTimeOffset?",
                { Type: "string", Format: "date-time" } => "DateTimeOffset",
                { Type: "string", Format: "byte", Nullable: true } => "byte[]?",
                { Type: "string", Format: "byte" } => "byte[]",
                { Type: "string", Format: "binary", Nullable: true } => "Stream?",
                { Type: "string", Format: "binary" } => "Stream[]",
                { Type: "string", Format: "uri", Nullable: true } => "Uri?",
                { Type: "string", Format: "uri" } => "Uri",
                { Type: "string", Format: "uuid", Nullable: true } => "Guid?",
                { Type: "string", Format: "uuid" } => "Guid",
                { Type: "string", Format: "guid", Nullable: true } => "Guid?",
                { Type: "string", Format: "guid" } => "Guid",
                { Type: "string", Nullable: true } => "string?",
                { Type: "string" } => "string",
                { Type: "boolean", Nullable: true } => "bool?",
                { Type: "boolean" } => "bool",
                { Type: "number", Format: "float", Nullable: true } => "float?",
                { Type: "number", Format: "float" } => "float",
                { Type: "number", Format: "double", Nullable: true } => "double?",
                { Type: "number", Format: "double" } => "double",
                { Type: "number", Format: "decimal", Nullable: true } => "decimal?",
                { Type: "number", Format: "decimal" } => "decimal",
                { Type: "number", Nullable: true } => "double?",
                { Type: "number" } => "double",
                { Type: "integer", Format: "int32", Nullable: true } => "int?",
                { Type: "integer", Format: "int32" } => "int",
                { Type: "integer", Format: "int64", Nullable: true } => "long?",
                { Type: "integer", Format: "int64" } => "long",
                { Type: "integer", Nullable: true } => "int?",
                { Type: "integer" } => "int",
                _ => "object",
            };
        }

        /// <inheritdoc/>
        public bool CanVisit(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema)
        {
            // This is the fallback. We can deal with anything.
            return true;
        }
    }
}
