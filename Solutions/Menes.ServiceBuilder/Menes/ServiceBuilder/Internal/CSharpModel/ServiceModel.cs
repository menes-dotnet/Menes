// <copyright file="ServiceModel.cs" company="Endjin Limited">
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
    /// Represents the C# declaration of a service.
    /// </summary>
    internal class ServiceModel
    {
        private readonly ServiceBuilderOptions serviceBuilderOptions;
        private Dictionary<string, ServiceOperationModel> serviceOperationsByOperationId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceModel"/> class.
        /// </summary>
        /// <param name="parentProjectModel">The parent project model.</param>
        /// <param name="semanticModel">The semantic model associated with the class.</param>
        /// <param name="classDeclaration">The class declaration that corresponds to this service.</param>
        /// <param name="serviceBuilderOptions">The service builder options.</param>
        public ServiceModel(CSharpSolutionModel parentProjectModel, SemanticModel semanticModel, ClassDeclarationSyntax classDeclaration, ServiceBuilderOptions serviceBuilderOptions)
        {
            this.ParentProjectModel = parentProjectModel ?? throw new ArgumentNullException(nameof(parentProjectModel));
            this.SemanticModel = semanticModel ?? throw new ArgumentNullException(nameof(semanticModel));
            this.ClassDeclaration = classDeclaration ?? throw new System.ArgumentNullException(nameof(classDeclaration));
            this.serviceBuilderOptions = serviceBuilderOptions ?? throw new ArgumentNullException(nameof(serviceBuilderOptions));
            this.BuildServiceOperations();
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
        /// Gets the class declaration for the service.
        /// </summary>
        public ClassDeclarationSyntax ClassDeclaration { get; }

        /// <summary>
        /// Gets the <see cref="ServiceOperationModel"/>s for this service by Operation ID.
        /// </summary>
        public IDictionary<string, ServiceOperationModel> ServiceOperationsByOperationId => this.serviceOperationsByOperationId ?? (this.serviceOperationsByOperationId = new Dictionary<string, ServiceOperationModel>());

        private void BuildServiceOperations()
        {
            IEnumerable<MethodDeclarationSyntax> methods =
                this.ClassDeclaration.DescendantNodes()
                    .OfType<MethodDeclarationSyntax>()
                    .Where(
                        m => m.AttributeLists.SelectMany(l => l.Attributes)
                            .Any(t => this.IsOperationIdAttribute(t)));

            this.serviceOperationsByOperationId = methods.ToDictionary(m => this.GetOperationId(m), m => new ServiceOperationModel(this.ParentProjectModel, this.SemanticModel, m, this.serviceBuilderOptions));
        }

        private string GetOperationId(MethodDeclarationSyntax m)
        {
            AttributeSyntax operationIdAttribute = m.AttributeLists.SelectMany(l => l.Attributes)
                            .Where(t =>
                                this.IsOperationIdAttribute(t)).SingleOrDefault();

            AttributeArgumentSyntax attributeArgumentSyntax = operationIdAttribute?.ArgumentList.Arguments.FirstOrDefault();
            if (attributeArgumentSyntax is null)
            {
                return $"MissingOperationIdArgumentError {Guid.NewGuid().ToString()}";
            }

            Optional<object> optionalValue = this.SemanticModel.GetConstantValue(attributeArgumentSyntax.Expression);
            if (!(optionalValue.Value is string valueString))
            {
                return $"OperationIdValueTypeError {Guid.NewGuid().ToString()}";
            }

            return valueString;
        }

        private bool IsOperationIdAttribute(AttributeSyntax t)
        {
            ITypeSymbol convertedType = this.SemanticModel.GetTypeInfo(t).ConvertedType;
            return convertedType.Name == nameof(OperationIdAttribute) && convertedType.ContainingNamespace.Name == nameof(Menes);
        }
    }
}
