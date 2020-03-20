// <copyright file="OperationVisitorFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An <see cref="IOperationVisitor"/> that dispatches to the first of an ordered list of <see cref="IOperationVisitor"/>s.
    /// </summary>
    public class OperationVisitorFactory : IOperationVisitor
    {
        private readonly List<IOperationVisitor> operationVisitors;
        private readonly TypeVisitorFactory typeVisitorFactory;
        private (OpenApiDocument document, OpenApiOperation operation) lastVisitorCriteria;
        private IOperationVisitor? lastVisitor;

        /// <summary>
        /// Initializes a new instance of <see cref="OperationVisitorFactory"/> class.
        /// </summary>
        /// <param name="typeVisitorFactory">The type visitor factory to use for the operations.</param>
        public OperationVisitorFactory(TypeVisitorFactory typeVisitorFactory)
        {
            this.operationVisitors = new List<IOperationVisitor>() { new AsyncOpenApiResultOperationVisitor(typeVisitorFactory) };
            this.typeVisitorFactory = typeVisitorFactory;
        }

        /// <summary>
        /// Adds a visitor to the end of the list (i.e. lowest priority).
        /// </summary>
        /// <param name="visitor">The visitor to add.</param>
        public void AppendVisitor(IOperationVisitor visitor)
        {
            this.operationVisitors.Add(visitor);
        }

        /// <summary>
        /// Removes the type visitor of the given type.
        /// </summary>
        /// <typeparam name="T">The type of visitor to remove.</typeparam>
        public void RemoveVisitor<T>()
            where T : IOperationVisitor
        {
            this.operationVisitors.RemoveAll(t => t.GetType() == typeof(T));
        }

        /// <summary>
        /// Adds a visitor to the start of the list (i.e. highest priority).
        /// </summary>
        /// <param name="visitor">The visitor to add.</param>
        public void PrependVisitor(IOperationVisitor visitor)
        {
            this.operationVisitors.Insert(0, visitor);
        }

        /// <inheritdoc/>
        public MethodDeclarationSyntax BuildOperationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, IDictionary<string, TypeDeclarationSyntax> types)
        {
            if (this.CanVisit(document, path, operation))
            {
                return this.lastVisitor!.BuildOperationSyntax(document, path, operation, types);
            }

            throw new InvalidOperationException($"There is no visitor that can visit this operation declaration. Consider registering a default type visitor when you construct a {nameof(OperationVisitorFactory)}.");
        }

        /// <inheritdoc/>
        public bool CanVisit(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation)
        {
            if (this.lastVisitorCriteria != (document, operation))
            {
                this.lastVisitorCriteria = (document, operation);
                this.lastVisitor = this.operationVisitors.Find(t => t.CanVisit(document, path, operation));
            }

            return this.lastVisitor != null;
        }
    }
}
