// <copyright file="MethodDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

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
        /// <param name="returnTypeName">The (optional) return type name of the method.</param>
        /// <param name="parameters">The (optional) parameters for the method.</param>
        public MethodDeclaration(ITypeDeclaration parent, string name, string bodyExpression, string returnTypeName, params ParameterDeclaration[] parameters)
        {
            this.Parent = parent;
            this.Name = name;
            this.Body = bodyExpression;
            this.ReturnTypeName = returnTypeName;
            this.Parameters = parameters?.ToList()?.AsReadOnly() ?? EmptyParameterList;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodDeclaration"/> class.
        /// </summary>
        /// <param name="parent">The parent type for the method.</param>
        /// <param name="name">The name of the method.</param>
        /// <param name="bodyExpression">The body expression for the method.</param>
        /// <param name="returnType">The (optional) return type of the method.</param>
        /// <param name="parameters">The (optional) parameters for the method.</param>
        public MethodDeclaration(ITypeDeclaration parent, string name, string bodyExpression, ITypeDeclaration returnType, params ParameterDeclaration[] parameters)
        {
            this.Parent = parent;
            this.Name = name;
            this.Body = bodyExpression;
            this.ReturnTypeName = returnType.GetFullyQualifiedName();
            this.Parameters = parameters?.ToList()?.AsReadOnly() ?? EmptyParameterList;
        }

        /// <summary>
        /// Gets the (unqualified) name of the method.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the body of the method.
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// Gets the parent type declaring the method.
        /// </summary>
        public ITypeDeclaration Parent { get; }

        /// <summary>
        /// Gets the name of the return type of the method.
        /// </summary>
        public string ReturnTypeName { get; }

        /// <summary>
        /// Gets the collection of parameters for the method.
        /// </summary>
        public IReadOnlyCollection<ParameterDeclaration> Parameters { get; }

        /// <summary>
        /// Generate the method declarationfrom the definition.
        /// </summary>
        /// <returns>The generated <see cref="MethodDeclarationSyntax"/>.</returns>
        public MethodDeclarationSyntax GenerateMethod()
        {
            var builder = new StringBuilder();
            builder.Append($"public {this.ReturnTypeName} {this.Name}(");
            builder.Append(string.Join(", ", this.Parameters.Select(p => $"{p.TypeName} {StringFormatter.ToCamelCase(p.Name)}")));
            builder.AppendLine(")");
            builder.AppendLine("{");
            builder.AppendLine(this.Body.Trim());
            builder.AppendLine("}");

            return (MethodDeclarationSyntax)SF.ParseMemberDeclaration(builder.ToString());
        }
    }
}
