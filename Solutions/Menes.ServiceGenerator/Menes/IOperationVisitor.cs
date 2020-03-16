// <copyright file="IOperationVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Visits operations in an OpenApi document.
    /// </summary>
    public interface IOperationVisitor
    {
        /// <summary>
        /// Determines if this visitor is capable of visiting this operation.
        /// </summary>
        /// <param name="document">The document containing this operation.</param>
        /// <param name="path">The path at which this operation is to be found.</param>
        /// <param name="operation">The operation to visit.</param>
        /// <returns>True if this visitor can handle this operation.</returns>
        bool CanVisit(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation);

        /// <summary>
        /// Builds the method declaration syntax for the operation.
        /// </summary>
        /// <param name="document">The document containing this operation.</param>
        /// <param name="path">The path at which this operation is to be found.</param>
        /// <param name="operation">The operation to visit.</param>
        /// <param name="types">A collection of types to generate. This collection is added to as types are discovered.</param>
        /// <returns>The method declaration syntax for the operation.</returns>
        MethodDeclarationSyntax BuildOperationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, IDictionary<string, TypeDeclarationSyntax> types);
    }
}
