// <copyright file="TypeModel.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder.Internal.CSharpModel
{
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Represents a type used in an OpenAPI operation.
    /// </summary>
    internal class TypeModel
    {
        private readonly ServiceBuilderOptions serviceBuilderOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeModel"/> class.
        /// </summary>
        /// <param name="parentProjectModel">The parent project model.</param>
        /// <param name="semanticModel">The semantic model.</param>
        /// <param name="serviceBuilderOptions">The service builder options.</param>
        public TypeModel(CSharpSolutionModel parentProjectModel, SemanticModel semanticModel, ServiceBuilderOptions serviceBuilderOptions)
        {
            this.ParentProjectModel = parentProjectModel ?? throw new System.ArgumentNullException(nameof(parentProjectModel));
            this.SemanticModel = semanticModel ?? throw new System.ArgumentNullException(nameof(semanticModel));
            this.serviceBuilderOptions = serviceBuilderOptions;
        }

        /// <summary>
        /// Gets the parent project model.
        /// </summary>
        public CSharpSolutionModel ParentProjectModel { get; }

        /// <summary>
        /// Gets the semantic model.
        /// </summary>
        public SemanticModel SemanticModel { get; }
    }
}
