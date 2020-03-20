// <copyright file="ServiceBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using Menes.Internal;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;
    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Builds a service definition from an OpenApi Document.
    /// </summary>
    public class ServiceBuilder
    {
        private readonly OperationVisitorFactory operationVisitorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBuilder"/> class.
        /// </summary>
        /// <param name="operationVisitorFactory">The operation visitor factory with which to iterate the service operations.</param>
        public ServiceBuilder(OperationVisitorFactory operationVisitorFactory)
        {
            this.operationVisitorFactory = operationVisitorFactory;
        }

        /// <summary>
        /// Builds the types for a service.
        /// </summary>
        /// <param name="document">The Open API document for which to build the types.</param>
        /// <param name="serviceName">The name of the service.</param>
        /// <param name="types">A collection of types to generate. This collection is added to as types are discovered.</param>
        public void BuildService(OpenApiDocument document, string serviceName, IDictionary<string, TypeDeclarationSyntax> types)
        {
            ClassDeclarationSyntax c =
                SF.ClassDeclaration(serviceName)
                    .AddBaseListTypes(SF.SimpleBaseType(SF.ParseTypeName("IOpenApiService")));
            c = c.AddModifiers(SF.Token(SyntaxKind.PublicKeyword));

            foreach (KeyValuePair<string, OpenApiPathItem> pathItem in document.Paths)
            {
                foreach (KeyValuePair<OperationType, OpenApiOperation> operation in pathItem.Value.Operations)
                {
                    c = c.AddMembers(this.operationVisitorFactory.BuildOperationSyntax(document, pathItem.Value, operation.Value, types));
                }
            }

            types.Add(serviceName, c);
        }
    }
}