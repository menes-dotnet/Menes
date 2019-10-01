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
        /// <param name="semanticModel">The semantic model for the parameter.</param>
        /// <param name="parameterSyntax">The parameter syntax.</param>
        /// <param name="serviceBuilderOptions">The service builder options.</param>
        public RequestParameterModel(SemanticModel semanticModel, ParameterSyntax parameterSyntax, ServiceBuilderOptions serviceBuilderOptions)
        {
            this.SemanticModel = semanticModel ?? throw new ArgumentNullException(nameof(semanticModel));
            this.ParameterSyntax = parameterSyntax ?? throw new ArgumentNullException(nameof(parameterSyntax));
            this.serviceBuilderOptions = serviceBuilderOptions ?? throw new ArgumentNullException(nameof(serviceBuilderOptions));
            this.BuildParameterType();
        }

        /// <summary>
        /// Gets the semantic model for the parameter.
        /// </summary>
        public SemanticModel SemanticModel { get; }

        /// <summary>
        /// Gets the parameter syntax.
        /// </summary>
        public ParameterSyntax ParameterSyntax { get; }

        private void BuildParameterType()
        {
        }
    }
}
