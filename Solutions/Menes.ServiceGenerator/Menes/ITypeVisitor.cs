// <copyright file="ITypeVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Visits types in an OpenApi document.
    /// </summary>
    public interface ITypeVisitor
    {
        /// <summary>
        /// Determines if this visitor is capable of visiting this operation.
        /// </summary>
        /// <param name="document">The document containing this type.</param>
        /// <param name="path">The path at which this type has been discovered.</param>
        /// <param name="operation">The operation where this type has been discovered.</param>
        /// <param name="typeSchema">The schema of the type to visit.</param>
        /// <returns>True if this visitor can handle this type.</returns>
        bool CanVisit(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema);

        /// <summary>
        /// Builds the types discovered for the operation.
        /// </summary>
        /// <param name="document">The document containing this type.</param>
        /// <param name="path">The path at which this type has been discovered.</param>
        /// <param name="operation">The operation where this type has been discovered.</param>
        /// <param name="typeSchema">The schema of the type to visit.</param>
        /// <param name="types">A collection of generated types. This collection is added to as types are discovered.</param>
        /// <param name="fallbackNameContext">The (possibly prefix of) the name to use when generating the type if it is not derived from a <see cref="OpenApiReference.Id"/>.</param>
        /// <returns>The type name for the discovered type.</returns>
        string BuildTypeDeclarationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext);
    }
}