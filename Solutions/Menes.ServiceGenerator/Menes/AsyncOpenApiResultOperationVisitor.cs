// <copyright file="AsyncOpenApiResultOperationVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Menes.Internal;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;
    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// An <see cref="IOperationVisitor"/> that generates services that return <see cref="Task{OpenApiResult}"/>.
    /// </summary>
    internal class AsyncOpenApiResultOperationVisitor : IOperationVisitor
    {
        private readonly TypeVisitorFactory typeVisitorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncOpenApiResultOperationVisitor"/> class.
        /// </summary>
        /// <param name="typeVisitorFactory">The type visitor factor with which to generate type information.</param>
        public AsyncOpenApiResultOperationVisitor(TypeVisitorFactory typeVisitorFactory)
        {
            this.typeVisitorFactory = typeVisitorFactory;
        }

        /// <inheritdoc/>
        public MethodDeclarationSyntax BuildOperationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, IDictionary<string, TypeDeclarationSyntax> types)
        {
            string methodName = NamingHelpers.ConvertCaseString(operation.OperationId, NamingHelpers.Case.PascalCase);

            operation.CreateResponseTypes(document, path, this.typeVisitorFactory, types, methodName);

            return
                CreateMethodDeclarationAndBody(methodName)
                .AddOperationIdAttribute(operation)
                .AddOperationParameters(document, path, operation, this.typeVisitorFactory, types, methodName);
        }

        /// <inheritdoc/>
        public bool CanVisit(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation)
        {
            // We can always visit the operation
            return true;
        }

        private static MethodDeclarationSyntax CreateMethodDeclarationAndBody(string methodName)
        {
            return SF.MethodDeclaration(SF.ParseTypeName("Task<OpenApiResult>"), methodName)
                    .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
                    .AddBodyStatements(SF.ParseStatement("throw new NotImplementedException();"));
        }
    }
}
