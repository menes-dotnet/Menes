// <copyright file="ServiceOperationModel.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder.Internal.CSharpModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Menes.ServiceBuilder;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// Represents a C# declaration of an operation in a <see cref="ServiceModel"/>.
    /// </summary>
    internal class ServiceOperationModel
    {
        private readonly ServiceBuilderOptions serviceBuilderOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceOperationModel"/> class.
        /// </summary>
        /// <param name="parentProjectModel">The parent project model.</param>
        /// <param name="semanticModel">The semantic model for the service.</param>
        /// <param name="methodDeclaration">The method that implements the OperationID.</param>
        /// <param name="serviceBuilderOptions">The service builder options.</param>
        public ServiceOperationModel(CSharpSolutionModel parentProjectModel, SemanticModel semanticModel, MethodDeclarationSyntax methodDeclaration, ServiceBuilderOptions serviceBuilderOptions)
        {
            this.ParentProjectModel = parentProjectModel ?? throw new ArgumentNullException(nameof(parentProjectModel));
            this.SemanticModel = semanticModel ?? throw new ArgumentNullException(nameof(semanticModel));
            this.MethodDeclaration = methodDeclaration ?? throw new ArgumentNullException(nameof(methodDeclaration));
            this.serviceBuilderOptions = serviceBuilderOptions ?? throw new ArgumentNullException(nameof(serviceBuilderOptions));
            this.BuildParameters();
        }

        /// <summary>
        /// Gets the parent project model.
        /// </summary>
        public CSharpSolutionModel ParentProjectModel { get; }

        /// <summary>
        /// Gets the semantic model for the service.
        /// </summary>
        public SemanticModel SemanticModel { get; }

        /// <summary>
        /// Gets the method that implements the operation ID.
        /// </summary>
        public MethodDeclarationSyntax MethodDeclaration { get; }

        /// <summary>
        /// Gets the map of operation parameter names to the operation parameters.
        /// </summary>
        /// <remarks>This takes account of any mapping in the <see cref="OpenApiParameterAttribute"/>.</remarks>
        public IDictionary<string, RequestParameterModel> RequestParameters { get; private set; }

        private void BuildParameters()
        {
            this.BuildResponseParameters();
            this.BuildRequestParameters();
        }

        private void BuildRequestParameters()
        {
            this.RequestParameters = this.MethodDeclaration.ParameterList.Parameters.ToDictionary(p => this.GetParameterName(p), p => new RequestParameterModel(this.ParentProjectModel, this.SemanticModel, p, this.serviceBuilderOptions));
        }

        private string GetParameterName(ParameterSyntax p)
        {
            AttributeSyntax openApiAttribute = p.AttributeLists.SelectMany(l => l.Attributes)
                            .Where(t =>
                            {
                                ITypeSymbol convertedType = this.SemanticModel.GetTypeInfo(t).ConvertedType;
                                return convertedType.Name == nameof(OpenApiParameterAttribute) && convertedType.ContainingNamespace.Name == nameof(Menes);
                            }).SingleOrDefault();

            if (openApiAttribute is null)
            {
                return p.Identifier.ValueText;
            }

            AttributeArgumentSyntax attributeArgumentSyntax = openApiAttribute.ArgumentList.Arguments.FirstOrDefault();
            if (attributeArgumentSyntax is null)
            {
                return $"MissingOpenApiParameterArgumentError {p.Identifier.ValueText}";
            }

            Optional<object> optionalValue = this.SemanticModel.GetConstantValue(attributeArgumentSyntax.Expression);
            if (!(optionalValue.Value is string valueString))
            {
                return $"OpenApiParameterValueTypeError {p.Identifier.ValueText}";
            }

            return valueString;
        }

        private void BuildResponseParameters()
        {
        }
    }
}