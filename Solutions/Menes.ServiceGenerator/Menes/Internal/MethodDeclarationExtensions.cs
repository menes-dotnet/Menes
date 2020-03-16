// <copyright file="MethodDeclarationExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.OpenApi.Models;
    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Extensions for generating method declarations.
    /// </summary>
    public static class MethodDeclarationExtensions
    {
        /// <summary>
        /// Add the operation ID attribute for an operation.
        /// </summary>
        /// <param name="md">Th method declaration to which to add the operation ID attribute.</param>
        /// <param name="operation">The operation whose ID should be added.</param>
        /// <returns>The method declaration with the operation ID added.</returns>
        public static MethodDeclarationSyntax AddOperationIdAttribute(this MethodDeclarationSyntax md, OpenApiOperation operation)
        {
            AttributeListSyntax attributeList = SF.AttributeList();
            attributeList = attributeList.AddAttributes(
                SF.Attribute(SF.ParseName("OperationIdAttribute"))
                    .AddArgumentListArguments(
                        SF.AttributeArgument(
                            SF.GetStandaloneExpression(SF.ParseExpression($"\"{operation.OperationId}\"")))));

            return md.AddAttributeLists(attributeList);
        }

        /// <summary>
        /// Adds parameters to a method declaration.
        /// </summary>
        /// <param name="md">Th method declaration to which to add the operation ID attribute.</param>
        /// <param name="document">The document containing this type.</param>
        /// <param name="path">The path at which this type has been discovered.</param>
        /// <param name="operation">The operation where this type has been discovered.</param>
        /// <param name="typeVisitorFactory">The type visitor factory to use to resolve types.</param>
        /// <param name="types">A collection of generated types. This collection is added to as types are discovered.</param>
        /// <param name="fallbackNameContext">The (base of the) fallback name to use for the type if there is no <see cref="OpenApiReference.Id"/> on which to base it.</param>
        /// <returns>The method declaration with the parameters added.</returns>
        public static MethodDeclarationSyntax AddOperationParameters(this MethodDeclarationSyntax md, OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, TypeVisitorFactory typeVisitorFactory, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            return md
                .AddPathSpecificParameters(document, path, operation, typeVisitorFactory, types, fallbackNameContext)
                .AddOperationSpecificParameters(document, path, operation, typeVisitorFactory, types, fallbackNameContext)
                .AddRequestBodyParameter(document, path, operation, typeVisitorFactory, types, fallbackNameContext);
        }

        /// <summary>
        /// Adds the operation-specific parameters to a method declaration.
        /// </summary>
        /// <param name="md">Th method declaration to which to add the operation ID attribute.</param>
        /// <param name="document">The document containing this type.</param>
        /// <param name="path">The path at which this type has been discovered.</param>
        /// <param name="operation">The operation where this type has been discovered.</param>
        /// <param name="typeVisitorFactory">The type visitor factory to use to resolve types.</param>
        /// <param name="types">A collection of generated types. This collection is added to as types are discovered.</param>
        /// <param name="fallbackNameContext">The (base of the) fallback name to use for the type if there is no <see cref="OpenApiReference.Id"/> on which to base it.</param>
        /// <returns>The method declaration with the parameters added.</returns>
        public static MethodDeclarationSyntax AddOperationSpecificParameters(this MethodDeclarationSyntax md, OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, TypeVisitorFactory typeVisitorFactory, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            foreach (OpenApiParameter parameter in operation.Parameters)
            {
                md = md.AddOperationParameter(document, path, operation, parameter, typeVisitorFactory, types, fallbackNameContext);
            }

            return md;
        }

        /// <summary>
        /// Adds the path-specific parameters to a method declaration.
        /// </summary>
        /// <param name="md">Th method declaration to which to add the operation ID attribute.</param>
        /// <param name="document">The document containing this type.</param>
        /// <param name="path">The path at which this type has been discovered.</param>
        /// <param name="operation">The operation where this type has been discovered.</param>
        /// <param name="typeVisitorFactory">The type visitor factory to use to resolve types.</param>
        /// <param name="types">A collection of generated types. This collection is added to as types are discovered.</param>
        /// <param name="fallbackNameContext">The (base of the) fallback name to use for the type if there is no <see cref="OpenApiReference.Id"/> on which to base it.</param>
        /// <returns>The method declaration with the parameters added.</returns>
        public static MethodDeclarationSyntax AddPathSpecificParameters(this MethodDeclarationSyntax md, OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, TypeVisitorFactory typeVisitorFactory, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            foreach (OpenApiParameter parameter in path.Parameters)
            {
                md = md.AddOperationParameter(document, path, operation, parameter, typeVisitorFactory, types, fallbackNameContext);
            }

            return md;
        }

        /// <summary>
        /// Adds a parameter to a method declaration.
        /// </summary>
        /// <param name="md">Th method declaration to which to add the operation ID attribute.</param>
        /// <param name="document">The document containing this type.</param>
        /// <param name="path">The path at which this type has been discovered.</param>
        /// <param name="operation">The operation where this type has been discovered.</param>
        /// <param name="typeVisitorFactory">The type visitor factory to use to resolve types.</param>
        /// <param name="types">A collection of generated types. This collection is added to as types are discovered.</param>
        /// <param name="fallbackNameContext">The (base of the) fallback name to use for the type if there is no <see cref="OpenApiReference.Id"/> on which to base it.</param>
        /// <returns>The method declaration with the parameter added.</returns>
        public static MethodDeclarationSyntax AddRequestBodyParameter(this MethodDeclarationSyntax md, OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, TypeVisitorFactory typeVisitorFactory, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            if (operation.RequestBody == null || operation.RequestBody.Content == null || operation.RequestBody.Content.Count == 0)
            {
                return md;
            }

            if (operation.RequestBody.Content.Count > 1)
            {
                throw new InvalidOperationException("Unable to handle request with multiple possible request body media types.");
            }

            OpenApiMediaType requestBodySchema = operation.RequestBody.Content.Values.First();

            string typeName = typeVisitorFactory.BuildTypeDeclarationSyntax(document, path, operation, requestBodySchema.Schema, types, fallbackNameContext);

            ParameterSyntax parameterSyntax =
                SF.Parameter(SF.Identifier("body"))
                    .WithType(SF.ParseTypeName(typeName));

            md.AddParameterListParameters(parameterSyntax);

            return md;
        }

        /// <summary>
        /// Adds a parameter to a method declaration.
        /// </summary>
        /// <param name="md">Th method declaration to which to add the operation ID attribute.</param>
        /// <param name="document">The document containing this type.</param>
        /// <param name="path">The path at which this type has been discovered.</param>
        /// <param name="operation">The operation where this type has been discovered.</param>
        /// <param name="parameter">The parameter to add to the method declaration.</param>
        /// <param name="typeVisitorFactory">The type visitor factory to use to resolve types.</param>
        /// <param name="types">A collection of generated types. This collection is added to as types are discovered.</param>
        /// <param name="fallbackNameContext">The (base of the) fallback name to use for the type if there is no <see cref="OpenApiReference.Id"/> on which to base it.</param>
        /// <returns>The method declaration with the parameter added.</returns>
        public static MethodDeclarationSyntax AddOperationParameter(this MethodDeclarationSyntax md, OpenApiDocument document, OpenApiPathItem path, OpenApiOperation operation, OpenApiParameter parameter, TypeVisitorFactory typeVisitorFactory, IDictionary<string, TypeDeclarationSyntax> types, string fallbackNameContext)
        {
            string parameterName = NamingHelpers.ConvertCaseString(parameter.Name, NamingHelpers.Case.CamelCase);
            string nameContextName = NamingHelpers.ConvertCaseString(parameter.Name, NamingHelpers.Case.PascalCase);
            string typeName = typeVisitorFactory.BuildTypeDeclarationSyntax(document, path, operation, parameter.Schema, types, fallbackNameContext + nameContextName);

            ParameterSyntax parameterSyntax =
                SF.Parameter(SF.Identifier(parameterName))
                    .WithType(SF.ParseTypeName(typeName));

            if (parameter.Name != parameter.Name)
            {
                parameterSyntax = parameterSyntax.AddOpenApiParameterAttribute(parameter);
            }

            return md.AddParameterListParameters(parameterSyntax);
        }

        /// <summary>
        /// Adds the OpenApiParameter attribute to an operation parameter.
        /// </summary>
        /// <param name="parameterSyntax">The parameter syntax to which to add the <c>[OpenApiParameter]</c> attribute.</param>
        /// <param name="parameter">The parameter for which to add the attribute.</param>
        /// <returns>The updated parameter syntax.</returns>
        public static ParameterSyntax AddOpenApiParameterAttribute(this ParameterSyntax parameterSyntax, OpenApiParameter parameter)
        {
            AttributeListSyntax attributeList = SF.AttributeList();
            attributeList = attributeList.AddAttributes(
                SF.Attribute(SF.ParseName("OpenApiParameter"))
                    .AddArgumentListArguments(
                        SF.AttributeArgument(
                            SF.GetStandaloneExpression(SF.ParseExpression($"\"{parameter.Name}\"")))));

            return parameterSyntax.AddAttributeLists(attributeList);
        }
    }
}
