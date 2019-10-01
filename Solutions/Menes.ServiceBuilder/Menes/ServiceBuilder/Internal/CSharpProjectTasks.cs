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
        /// <param name="projectFile">The target project file.</param>
        /// <returns>The <see cref="CSharpProjectModel"/> for the project.</returns>
        internal static async Task<CSharpProjectModel> LoadServiceProjectAsync(CommandLineApplication app, string projectFile)
        {
            MSBuildLocator.RegisterDefaults();
            var workspace = MSBuildWorkspace.Create();
            Project project = await workspace.OpenProjectAsync(projectFile, new ProgressReporter(app)).ConfigureAwait(false);
            return new CSharpProjectModel(workspace, project);
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
