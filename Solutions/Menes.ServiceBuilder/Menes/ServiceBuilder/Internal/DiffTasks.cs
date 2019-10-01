// <copyright file="DiffTasks.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder.Internal
{
    using System.Threading.Tasks;
    using McMaster.Extensions.CommandLineUtils;
    using Menes.ServiceBuilder.Internal.CSharpModel;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Diffing operations between <see cref="CSharpProjectModel"/> and an <see cref="OpenApiDocument"/>.
    /// </summary>
    internal class DiffTasks
    {
        /// <summary>
        /// Generate diffs between an OpenApi document and a project model.
        /// </summary>
        /// <param name="app">The command line application context.</param>
        /// <param name="openApiDocument">The open api document.</param>
        /// <param name="projectModel">The project model.</param>
        /// <returns>A <see cref="Task"/> which completes when the diff operation is complete.</returns>
        internal static Task DiffAsync(CommandLineApplication app, OpenApiDocument openApiDocument, CSharpProjectModel projectModel)
        {
            return Task.CompletedTask;
        }
    }
}