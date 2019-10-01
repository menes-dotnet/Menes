// <copyright file="TypeModel.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder.Internal.CSharpModel
{
    using System;
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
        /// <param name="parentSolutionModel">The parent solution model.</param>
        /// <param name="semanticModel">The semantic model.</param>
        /// <param name="typeSymbol">The type symbol.</param>
        /// <param name="serviceBuilderOptions">The service builder options.</param>
        public TypeModel(CSharpSolutionModel parentSolutionModel, SemanticModel semanticModel, ITypeSymbol typeSymbol, ServiceBuilderOptions serviceBuilderOptions)
        {
            this.ParentSolutionModel = parentSolutionModel ?? throw new ArgumentNullException(nameof(parentSolutionModel));
            this.SemanticModel = semanticModel ?? throw new ArgumentNullException(nameof(semanticModel));
            this.TypeSymbol = typeSymbol;
            this.serviceBuilderOptions = serviceBuilderOptions;
            this.BuildType();
        }

        /// <summary>
        /// Gets the parent solution model.
        /// </summary>
        public CSharpSolutionModel ParentSolutionModel { get; }

        /// <summary>
        /// Gets the semantic model.
        /// </summary>
        public SemanticModel SemanticModel { get; }

        /// <summary>
        /// Gets the type symbol.
        /// </summary>
        public ITypeSymbol TypeSymbol { get; }

        private void BuildType()
        {
            // Note that we can get the
            // declaring syntax references from the symbol, if we need to walk this type
            // later for modification.
        }
    }
}
