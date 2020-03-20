// <copyright file="OperationExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Extension methods and helpers for the <see cref="OpenApiServiceOperation"/>.
    /// </summary>
    public static class OperationExtensions
    {
        /// <summary>
        /// Find and create the response types for an operation.
        /// </summary>
        /// <param name="operation">The operation for which to create the response types.</param>
        /// <param name="document">The document containing the operation.</param>
        /// <param name="path">The path for the operation.</param>
        /// <param name="typeVisitorFactory">The <see cref="TypeVisitorFactory"/> to use to build the types.</param>
        /// <param name="types">A collection of types to generate. This collection is added to as types are discovered.</param>
        /// <param name="fallbackContextName">The base name for anonymous typws created in this context.</param>
        public static void CreateResponseTypes(this OpenApiOperation operation, OpenApiDocument document, OpenApiPathItem path, TypeVisitorFactory typeVisitorFactory, IDictionary<string, TypeDeclarationSyntax> types, string fallbackContextName)
        {
            foreach (KeyValuePair<string, OpenApiResponse> response in operation.Responses)
            {
                foreach (KeyValuePair<string, OpenApiMediaType> content in response.Value.Content)
                {
                    string responseCode = NamingHelpers.ConvertCaseString(response.Key, NamingHelpers.Case.PascalCase);
                    string fallbackName = $"{fallbackContextName}{responseCode}Response";
                    typeVisitorFactory.BuildTypeDeclarationSyntax(document, path, operation, content.Value.Schema, types, fallbackName);
                }
            }
        }
    }
}
