// <copyright file="RequestParameterModel.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder.Internal.CSharpModel
{
    using System;
    using Menes.ServiceBuilder;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// Represents a request parameter in a <see cref="ServiceOperationModel"/>.
    /// </summary>
    internal class RequestParameterModel
    {
        private readonly ServiceBuilderOptions serviceBuilderOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestParameterModel"/> class.
        /// </summary>
        /// <param name="parentSolutionModel">The parent solution model.</param>
        /// <param name="semanticModel">The semantic model for the parameter.</param>
        /// <param name="parameterSyntax">The parameter syntax.</param>
        /// <param name="serviceBuilderOptions">The service builder options.</param>
        public RequestParameterModel(CSharpSolutionModel parentSolutionModel, SemanticModel semanticModel, ParameterSyntax parameterSyntax, ServiceBuilderOptions serviceBuilderOptions)
        {
            this.ParentSolutionModel = parentSolutionModel ?? throw new ArgumentNullException(nameof(parentSolutionModel));
            this.SemanticModel = semanticModel ?? throw new ArgumentNullException(nameof(semanticModel));
            this.ParameterSyntax = parameterSyntax ?? throw new ArgumentNullException(nameof(parameterSyntax));
            this.serviceBuilderOptions = serviceBuilderOptions ?? throw new ArgumentNullException(nameof(serviceBuilderOptions));
            this.BuildParameterType();
        }

        /// <summary>
        /// Gets the parent solution model.
        /// </summary>
        public CSharpSolutionModel ParentSolutionModel { get; }

        /// <summary>
        /// Gets the semantic model for the parameter.
        /// </summary>
        public SemanticModel SemanticModel { get; }

        /// <summary>
        /// Gets the parameter syntax.
        /// </summary>
        public ParameterSyntax ParameterSyntax { get; }

        /// <summary>
        /// Gets the type model for this parameter.
        /// </summary>
        public TypeModel Type { get; private set; }

        private void BuildParameterType()
        {
            ITypeSymbol parameterType = this.SemanticModel.GetTypeInfo(this.ParameterSyntax.Type).ConvertedType;
            this.Type = this.ParentSolutionModel.GetOrAddTypeModel(this.SemanticModel, parameterType, this.serviceBuilderOptions);
        }
    }
}
