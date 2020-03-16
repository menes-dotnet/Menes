// <copyright file="ServiceBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Client.Menes.Client
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Builds a service for an OpenApi document.
    /// </summary>
    public class ServiceBuilder
    {
        /// <summary>
        /// Build a service implementation shell for an Open API document.
        /// </summary>
        /// <param name="document">The OpenAPI document for which to create the service implementation.</param>
        /// <param name="ns">The namespace into which to generate the types.</param>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns>The code generated for the service.</returns>
        public string BuildService(OpenApiDocument document, string ns, string serviceName)
        {
            // We could find one in an existing project, but let's just create one for now.
            CompilationUnitSyntax compilationUnit = SyntaxFactory.CompilationUnit();

            var typeMap = new List<(string, OpenApiSchema)>();
            compilationUnit = ServiceWriter.WriteService(document, compilationUnit, ns, serviceName, typeMap);

            IList<(string, CompilationUnitSyntax)> types = ServiceWriter.WriteTypes(document, typeMap, ns);

            foreach ((string, CompilationUnitSyntax) type in types)
            {
                string result = ServiceWriter.BuildService(type.Item2);
            }

            return ServiceWriter.BuildService(compilationUnit);
        }
    }
}
