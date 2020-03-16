// <copyright file="TypeVisitorFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// A type visitor that dispatches to the first of an ordered list of visitors.
    /// </summary>
    public class TypeVisitorFactory : ITypeVisitor
    {
        private readonly List<ITypeVisitor> typeVisitors;
        private ITypeVisitor? lastVisitor;
        private (OpenApiDocument, OpenApiSchema) lastVisitorCriteria;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeVisitorFactory"/> class.
        /// </summary>
        /// <param name="typeVisitors">An ordered list of type visitors that it will try in turn when visiting a type.</param>
        public TypeVisitorFactory(IEnumerable<ITypeVisitor> typeVisitors)
        {
            this.typeVisitors = new List<ITypeVisitor>(typeVisitors);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TypeVisitorFactory"/> class.
        /// </summary>
        public TypeVisitorFactory()
        {
            this.typeVisitors = new List<ITypeVisitor>();
        }

        /// <summary>
        /// Gets the ordered list of type visitors.
        /// </summary>
        public IEnumerable<ITypeVisitor> TypeVisitors => this.typeVisitors;

        /// <summary>
        /// Create a type visitor factory with the default configuration.
        /// </summary>
        /// <returns>An instance of a <see cref="TypeVisitorFactory"/> configured with the default values.</returns>
        public static TypeVisitorFactory CreateDefaultInstance()
        {
            var result = new TypeVisitorFactory();
            result.AppendVisitor(new AllOfTypeVisitor(result));
            result.AppendVisitor(new AnyOfTypeVisitor(result));
            result.AppendVisitor(new OneOfTypeVisitor(result));
            result.AppendVisitor(new ArrayTypeVisitor(result));
            result.AppendVisitor(new ObjectTypeVisitor(result));
            result.AppendVisitor(new NodatimeTypeVisitor());
            result.AppendVisitor(new BuiltInTypeVisitor());
            return result;
        }

        /// <summary>
        /// Adds a visitor to the end of the list (i.e. lowest priority).
        /// </summary>
        /// <param name="visitor">The visitor to add.</param>
        public void AppendVisitor(ITypeVisitor visitor)
        {
            this.typeVisitors.Add(visitor);
        }

        /// <summary>
        /// Removes the type visitor of the given type.
        /// </summary>
        /// <typeparam name="T">The type of visitor to remove.</typeparam>
        public void RemoveVisitor<T>()
        {
            this.typeVisitors.RemoveAll(t => t.GetType() == typeof(T));
        }

        /// <summary>
        /// Adds a visitor to the start of the list (i.e. highest priority).
        /// </summary>
        /// <param name="visitor">The visitor to add.</param>
        public void PrependVisitor(ITypeVisitor visitor)
        {
            this.typeVisitors.Insert(0, visitor);
        }

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
                this.lastVisitor = this.typeVisitors.Find(t => t.CanVisit(document, path, operation, typeSchema));
            }

            return this.lastVisitor != null;
        }
    }
}
