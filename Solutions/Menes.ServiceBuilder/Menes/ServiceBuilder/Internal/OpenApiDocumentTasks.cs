// <copyright file="OpenApiDocumentTasks.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder.Internal
{
    using System.IO;
    using System.Linq;
    using McMaster.Extensions.CommandLineUtils;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;

    /// <summary>
    /// Common tasks related to the OpenApi document.
    /// </summary>
    internal static class OpenApiDocumentTasks
    {
        /// <summary>
        /// Attemps to load an OpenAPI document.
        /// </summary>
        /// <param name="app">The command line application context.</param>
        /// <param name="openApiDocumentPath">The openapi document path.</param>
        /// <param name="document">The document to load.</param>
        /// <returns>A value which indicates whether the load was successful.</returns>
        internal static bool TryLoadOpenApiDocument(CommandLineApplication app, string openApiDocumentPath, out OpenApiDocument document)
        {
            using Stream stream = File.OpenRead(openApiDocumentPath);
            document = new OpenApiStreamReader().Read(stream, out OpenApiDiagnostic diagnostics);
            if (diagnostics.Errors.Any())
            {
                diagnostics.Errors.ForEach(e => app.Error.WriteLine($"[{e.Pointer}: {e.Message}"));
                return false;
            }

            return true;
        }
    }
}
