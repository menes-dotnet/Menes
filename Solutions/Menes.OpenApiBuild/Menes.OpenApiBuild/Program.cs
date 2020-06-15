// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApiBuild
{
    using System;
    using System.Collections.Generic;
    using System.CommandLine;
    using System.IO;
    using System.Linq;
    using Microsoft.Extensions.FileSystemGlobbing;
    using Microsoft.OpenApi;
    using Microsoft.OpenApi.Extensions;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;
    using Microsoft.OpenApi.Services;
    using Microsoft.OpenApi.Validations;

    /// <summary>
    /// The main program.
    /// </summary>
    internal static class Program
    {
#pragma warning disable RCS1213 // Remove unused member declaration.
        /// <summary>
        /// The main program entry point.
        /// </summary>
        /// <param name="input">A glob to match the input OpenAPI document files which are to have their external referenced merged in.</param>
        /// <param name="output">The ouptut directory into which the merged files are to be written.</param>
        /// <param name="root">An optional root directory which to start the search. The default is the current directory.</param>
        /// <param name="console">The abstraction for the console.</param>
        private static void Main(string input, DirectoryInfo output, DirectoryInfo? root = null, IConsole? console = null)
        {
            root ??= new DirectoryInfo(Environment.CurrentDirectory);

            try
            {
                var matcher = new Matcher();
                matcher.AddInclude(input);
                foreach (string result in matcher.GetResultsInFullPath(root.FullName))
                {
                    var currentInput = new FileInfo(result);

                    OpenApiDocument openApiDocument = LoadOpenApiDocument(currentInput);

                    MergeExternalReferences(openApiDocument, currentInput.Directory);

                    ThrowOnError(openApiDocument.Validate(ValidationRuleSet.GetDefaultRuleSet()));

                    SaveOpenApiDocument(openApiDocument, new FileInfo(Path.Combine(output.FullName, currentInput.Name)));
                }
            }
            catch (Exception ex)
            {
                console?.Error.Write(ex.Message);
                return;
            }
        }
#pragma warning restore RCS1213 // Remove unused member declaration.

        private static void SaveOpenApiDocument(OpenApiDocument openApiDocument, FileInfo output)
        {
            // Ensure the directory exists
            output.Directory.Create();

            using var textWriter = new StreamWriter(output.Open(FileMode.Create, FileAccess.Write, FileShare.None));
            textWriter.Write(openApiDocument.SerializeAsYaml(OpenApiSpecVersion.OpenApi3_0));
        }

        private static void MergeExternalReferences(OpenApiDocument openApiDocument, DirectoryInfo directory)
        {
            var walker = new OpenApiWalkerEx(new MergeReferencesVisitor(openApiDocument, directory));

            // First walk loads everything, recursively
            walker.Walk(openApiDocument);
        }

        private static OpenApiDocument LoadOpenApiDocument(FileInfo input)
        {
            OpenApiDocument openApiDocument;
            using (StreamReader? textReader = input.OpenText())
            {
                var reader = new OpenApiTextReaderReader();
                openApiDocument = reader.Read(textReader, out OpenApiDiagnostic diagnostic);

                ThrowOnError(diagnostic.Errors);
            }

            return openApiDocument;
        }

        private static void ThrowOnError(IEnumerable<OpenApiError> errors)
        {
            if (errors.Any())
            {
                throw new Exception(string.Join(Environment.NewLine, errors.Select(e => e.Message)));
            }
        }
    }
}
