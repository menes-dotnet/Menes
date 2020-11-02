// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json.Schema.TypeGenerator;
    using Menes.TypeGenerator;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Formatting;

    /// <summary>
    /// Generates code for the json schema test suites.
    /// </summary>
    internal class Program
    {
        private const string FileHeader =
            "// <copyright file=\"<FN>\" company=\"Endjin Limited\">\r\n// Copyright (c) Endjin Limited. All rights reserved.\r\n// </copyright>\r\n#pragma warning disable\r\nnamespace Menes.Json.Schema.Tests.<NS>\r\n{\r\n";

        private const string FileFooter = "}";

        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args">Program arguments.</param>
        /// <returns>A <see cref="Task"/> which completes once program execution is complete.</returns>
        private static Task Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("You must provide the path to the tests.");
                return Task.CompletedTask;
            }

            string output = Path.Combine(args[0], "../tests");

            var uris = new List<(string, string)>();

            foreach (string file in Directory.EnumerateFiles(args[0]))
            {
                using var doc = JsonDocument.Parse(File.ReadAllText(file));
                int length = doc.RootElement.GetArrayLength();
                for (int i = 0; i < length; ++i)
                {
                    uris.Add(($"{file}#/{i}/schema", Path.GetFileNameWithoutExtension(file) + $"{i:D3}"));
                }
            }

            return GenerateTypesForSchema(uris.ToArray(), output);
        }

        private static async Task GenerateTypesForSchema((string, string)[] uris, string outputPath)
        {
            foreach ((string, string) uri in uris)
            {
                var typeGenerator = new TypeGeneratorJsonSchemaVisitor(DocumentResolver.Default);
                await GenerateTypesForSchema(uri.Item1, typeGenerator).ConfigureAwait(false);
                WriteTypes(typeGenerator, Path.ChangeExtension(Path.Combine(outputPath, uri.Item2), ".cs"), StringFormatter.ToPascalCaseWithReservedWords(uri.Item2));
            }
        }

        private static async Task GenerateTypesForSchema(string uri, TypeGeneratorJsonSchemaVisitor typeGenerator)
        {
            (string baseUri, JsonDocument root, JsonSchema schema) = await DocumentResolver.Default.LoadSchema(uri).ConfigureAwait(false);

            try
            {
                await typeGenerator.BuildTypes(schema, root, baseUri).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void WriteTypes(TypeGeneratorJsonSchemaVisitor typeGenerator, string outputPath, string ns)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                File.Delete(outputPath);
                Console.WriteLine(outputPath);

                TypeDeclarationSyntax[] tds = typeGenerator.GenerateTypes();

                File.AppendAllText(outputPath, FileHeader.Replace("<NS>", ns).Replace("<FN>", Path.GetFileName(outputPath)));

                foreach (TypeDeclarationSyntax t in tds)
                {
                    SyntaxNode formattedJsonSchema = Formatter.Format(t, new AdhocWorkspace());

                    File.AppendAllText(outputPath, formattedJsonSchema.ToFullString());
                }

                File.AppendAllText(outputPath, FileFooter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
