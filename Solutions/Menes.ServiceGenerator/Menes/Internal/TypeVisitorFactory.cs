// <copyright file="TypeVisitorFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// A type visitor that dispatches to the first of an ordered list of visitors.
    /// </summary>
    public class TypeVisitorFactory : ITypeVisitor
    {
        private ITypeVisitor? lastVisitor;
        private (OpenApiDocument, OpenApiSchema) lastVisitorCriteria;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeVisitorFactory"/> class.
        /// </summary>
        /// <param name="typeVisitors">An ordered list of type visitors that it will try in turn when visiting a type.</param>
        public TypeVisitorFactory(IEnumerable<ITypeVisitor> typeVisitors)
        {
            this.TypeVisitors = new List<ITypeVisitor>(typeVisitors);
        }

        /// <summary>
        /// Gets the ordered list of type visitors.
        /// </summary>
        public IList<ITypeVisitor> TypeVisitors { get; }

        /// <inheritdoc/>
        public string BuildTypeDeclarationSyntax(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            if (this.CanVisit(document, path, operation, typeSchema))
            {
                return this.lastVisitor!.BuildTypeDeclarationSyntax(document, path, operation, typeSchema, types, fallbackNameContext);
            }

            throw new InvalidOperationException($"There is no visitor that can visit this type declaration. Consider registering a default type visitor when you construct a {nameof(TypeVisitorFactory)}.");
        }

        /// <inheritdoc/>
        public bool CanVisit(OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiSchema typeSchema)
        {
            if (this.lastVisitorCriteria != (document, typeSchema))
            {
                this.lastVisitorCriteria = (document, typeSchema);
                this.lastVisitor = this.TypeVisitors.FirstOrDefault(t => t.CanVisit(document, path, operation, typeSchema));
            }

            return this.lastVisitor != null;
        }
    }
}
