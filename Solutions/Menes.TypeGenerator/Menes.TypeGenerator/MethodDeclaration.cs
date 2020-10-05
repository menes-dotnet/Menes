// <copyright file="MethodDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implemented by method declarations.
    /// </summary>
    public class MethodDeclaration
    {
        private static readonly IReadOnlyCollection<ParameterDeclaration> EmptyParameterList = new List<ParameterDeclaration>().AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodDeclaration"/> class.
        /// </summary>
        /// <param name="parent">The parent type for the method.</param>
        /// <param name="name">The name of the method.</param>
        /// <param name="bodyExpression">The body expression for the method.</param>
        /// <param name="returnType">The (optional) return type of the method.</param>
        /// <param name="parameters">The (optional) parameters for the method.</param>
        public MethodDeclaration(ITypeDeclaration parent, string name, string bodyExpression, ITypeDeclaration? returnType = null, IEnumerable<ParameterDeclaration>? parameters = null)
        {
            this.Parent = parent;
            this.Name = name;
            this.BodyExpression = bodyExpression;
            this.ReturnType = returnType ?? VoidTypeDeclaration.Instance;
            this.Parameters = parameters?.ToList()?.AsReadOnly() ?? EmptyParameterList;
        }

        /// <summary>
        /// Gets the (unqualified) name of the method.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the body expression of the method.
        /// </summary>
        public string BodyExpression { get; }

        /// <summary>
        /// Gets the parent type declaring the method.
        /// </summary>
        public ITypeDeclaration Parent { get; }

        /// <summary>
        /// Gets the return type of the method.
        /// </summary>
        public ITypeDeclaration ReturnType { get; }

        /// <summary>
        /// Gets the collection of parameters for the method.
        /// </summary>
        public IReadOnlyCollection<ParameterDeclaration> Parameters { get; }
    }
}
