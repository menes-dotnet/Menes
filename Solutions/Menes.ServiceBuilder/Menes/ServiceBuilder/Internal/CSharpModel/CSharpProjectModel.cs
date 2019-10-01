// <copyright file="CSharpProjectModel.cs" company="Endjin Limited">
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
    internal class CSharpProjectModel : IDisposable
    {
        private Compilation compilation;
        private IList<ServiceModel> services;

        /// <summary>
        /// Construct a CSharp project model of the OpenApi project.
        /// </summary>
        /// <param name="workspace">The workspace containing the project.</param>
        /// <param name="project">The project containing the OpenApi service.</param>
        public CSharpProjectModel(MSBuildWorkspace workspace, Project project)
        {
            this.Workspace = workspace ?? throw new ArgumentNullException(nameof(workspace));
            this.Project = project ?? throw new ArgumentNullException(nameof(project));
        }

        /// <summary>
        /// Gets the <see cref="MSBuildWorkspace"/> for the project.
        /// </summary>
        public MSBuildWorkspace Workspace { get; }

        /// <summary>
        /// Gets the <see cref="Project"/> containing the OpenApi service.
        /// </summary>
        public Project Project { get; }

        /// <summary>
        ///  Gets the list of service types implemented by the project.
        /// </summary>
        public IList<ServiceModel> Services => this.services ?? (this.services = new List<ServiceModel>());

        /// <summary>
        /// Build the list of services found in the project.
        /// </summary>
        /// <param name="serviceBuilderOptions">The service builder options.</param>
        /// <returns>A <see cref="Task"/> which completes when the services list is built.</returns>
        public async Task BuildServicesAsync(ServiceBuilderOptions serviceBuilderOptions)
        {
            if (serviceBuilderOptions is null)
            {
                throw new ArgumentNullException(nameof(serviceBuilderOptions));
            }

            this.compilation = await this.Project.GetCompilationAsync();
            ImmutableArray<Diagnostic> diagnostics = this.compilation.GetDiagnostics();

            if (diagnostics.Any(d => d.Severity == DiagnosticSeverity.Error))
            {
                throw new InvalidOperationException("The project does not currently build.");
            }

            foreach (SyntaxTree tree in this.compilation.SyntaxTrees)
            {
                SemanticModel semanticModel = this.compilation.GetSemanticModel(tree);

                this.Services.AddRange(
                    tree.GetRoot()
                        .DescendantNodes()
                        .OfType<ClassDeclarationSyntax>()
                        .Where(c =>
                            c.BaseList.Types.Any(
                                t =>
                                    semanticModel.GetTypeInfo(t.Type).ConvertedType.Name == nameof(IOpenApiService)
                                    && semanticModel.GetTypeInfo(t.Type).ConvertedType.ContainingNamespace.Name == nameof(Menes)))
                        .Select(s => new ServiceModel(semanticModel, s, serviceBuilderOptions)));
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Workspace.Dispose();
        }
    }
}