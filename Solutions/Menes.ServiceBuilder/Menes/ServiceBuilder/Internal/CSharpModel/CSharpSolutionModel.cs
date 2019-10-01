// <copyright file="CSharpSolutionModel.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder.Internal.CSharpModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading.Tasks;
    using Corvus.Extensions;
    using Menes.ServiceBuilder;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.MSBuild;

    /// <summary>
    /// A model of a CSharp project.
    /// </summary>
    internal class CSharpSolutionModel : IDisposable
    {
        private IList<ServiceModel> services;
        private IList<TypeModel> serviceTypes;

        /// <summary>
        /// Construct a CSharp project model of the OpenApi project.
        /// </summary>
        /// <param name="workspace">The workspace containing the project.</param>
        /// <param name="solution">The solution containing the OpenApi services.</param>
        public CSharpSolutionModel(MSBuildWorkspace workspace, Solution solution)
        {
            this.Workspace = workspace ?? throw new ArgumentNullException(nameof(workspace));
            this.Solution = solution ?? throw new ArgumentNullException(nameof(solution));
        }

        /// <summary>
        /// Gets the <see cref="MSBuildWorkspace"/> for the project.
        /// </summary>
        public MSBuildWorkspace Workspace { get; }

        /// <summary>
        /// Gets the <see cref="Solution"/> containing the OpenApi services.
        /// </summary>
        public Solution Solution { get; }

        /// <summary>
        ///  Gets the list of service types implemented by the project.
        /// </summary>
        public IList<ServiceModel> Services => this.services ?? (this.services = new List<ServiceModel>());

        /// <summary>
        /// Gets the list of types that are used by the services implemented by the project.
        /// </summary>
        public IList<TypeModel> ServiceTypes => this.serviceTypes ?? (this.serviceTypes = new List<TypeModel>());

        /// <summary>
        /// Build the list of services found in the solution.
        /// </summary>
        /// <param name="serviceBuilderOptions">The service builder options.</param>
        /// <returns>A <see cref="Task"/> which completes when the services list is built.</returns>
        public async Task BuildServicesAsync(ServiceBuilderOptions serviceBuilderOptions)
        {
            if (serviceBuilderOptions is null)
            {
                throw new ArgumentNullException(nameof(serviceBuilderOptions));
            }

            foreach (ProjectId projectId in this.Solution.GetProjectDependencyGraph().GetTopologicallySortedProjects())
            {
                Project project = this.Solution.GetProject(projectId);
                Compilation compilation = await project.GetCompilationAsync();
                ImmutableArray<Diagnostic> diagnostics = compilation.GetDiagnostics();

                if (diagnostics.Any(d => d.Severity == DiagnosticSeverity.Error))
                {
                    throw new InvalidOperationException($"The project {project.Name} does not currently build. Please fix build errors before continuing.")
                        .AddProblemDetailsExtension("Diagnostics", diagnostics);
                }

                foreach (SyntaxTree tree in compilation.SyntaxTrees)
                {
                    SemanticModel semanticModel = compilation.GetSemanticModel(tree);

                    this.Services.AddRange(
                        tree.GetRoot()
                            .DescendantNodes()
                            .OfType<ClassDeclarationSyntax>()
                            .Where(c =>
                                c.BaseList.Types.Any(
                                    t =>
                                    {
                                        ITypeSymbol type = semanticModel.GetTypeInfo(t.Type).ConvertedType;
                                        return type.Name == nameof(IOpenApiService) && type.ContainingNamespace.Name == nameof(Menes);
                                    }))
                            .Select(s => new ServiceModel(this, semanticModel, s, serviceBuilderOptions)));
                }
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Workspace.Dispose();
        }
    }
}