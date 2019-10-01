// <copyright file="CSharpProjectTasks.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder.Internal
{
    using System;
    using System.Threading.Tasks;
    using McMaster.Extensions.CommandLineUtils;
    using Menes.ServiceBuilder.Internal.CSharpModel;
    using Microsoft.Build.Locator;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.MSBuild;

    /// <summary>
    /// Common tasks related to the OpenApi document.
    /// </summary>
    internal static class CSharpProjectTasks
    {
        /// <summary>
        /// Load the service definitions for a csharp project.
        /// </summary>
        /// <param name="app">The command line application context.</param>
        /// <param name="solutionFile">The target solution file.</param>
        /// <returns>The <see cref="CSharpSolutionModel"/> for the project.</returns>
        internal static async Task<CSharpSolutionModel> LoadServiceSolution(CommandLineApplication app, string solutionFile)
        {
            MSBuildLocator.RegisterDefaults();
            var workspace = MSBuildWorkspace.Create();
            Solution solution = await workspace.OpenSolutionAsync(solutionFile, new ProgressReporter(app)).ConfigureAwait(false);
            return new CSharpSolutionModel(workspace, solution);
        }

        private class ProgressReporter : IProgress<ProjectLoadProgress>
        {
            private readonly CommandLineApplication app;

            public ProgressReporter(CommandLineApplication app)
            {
                this.app = app;
            }

            public void Report(ProjectLoadProgress value)
            {
                this.app.Out.WriteLine($"Loading project [{value.ElapsedTime.TotalMilliseconds}]: {value.Operation.ToString()}");
            }
        }
    }
}
