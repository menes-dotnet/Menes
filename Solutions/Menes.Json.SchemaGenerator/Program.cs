namespace Menes.Json.SchemaGenerator
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.CommandLine;
    using System.CommandLine.Invocation;
    using System.IO;
    using System.Threading.Tasks;
    using Menes.Json.SchemaModel;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    class Program
    {
        static Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new Option<string>(
                    "--rootNamespace",
                    description: "The default root namespace for generated types"),
                new Option<string>(
                    "--rootPath",
                    description: "The path in the document for the root type."),
                new Option<string>(
                    "--outputPath",
                    description: "The output directory."),
                new Option<bool>(
                    "--rebaseToRootPath",
                    "If a --rootPath is specified, rebase the document as if it was rooted on the specified element."),
            };

            rootCommand.Description = "Generate C# types from a JSON schema.";
            
            rootCommand.AddArgument(
                new Argument<string>(
                    "schemaFile",
                    "The path to the schema file to process")
                {
                    Arity = ArgumentArity.ExactlyOne,
                });


            // Note that the parameters of the handler method are matched according to the names of the options
            rootCommand.Handler = CommandHandler.Create<string, string, string, bool, string>((schemaFile, rootNamespace, rootPath, rebaseToRootPath, outputPath) =>
              {
                  return GenerateTypes(schemaFile, rootNamespace, rootPath, rebaseToRootPath, outputPath);
              });

            // Parse the incoming args and invoke the handler
            return rootCommand.InvokeAsync(args);
        }

        private static async Task<int> GenerateTypes(string schemaFile, string rootNamespace, string rootPath, bool rebaseToRootPath, string outputPath)
        {
            var walker = new JsonWalker(DocumentResolver.Default);
            var builder = new JsonSchemaBuilder(walker);
            (_, ImmutableDictionary<string, (string, string)> generatedTypes) = await builder.BuildTypesFor(new JsonReference(schemaFile).Apply(new JsonReference(rootPath)), rootNamespace, rebaseToRootPath).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            foreach (KeyValuePair<string, (string, string)> generatedType in generatedTypes)
            {
                string source = SyntaxFactory.ParseCompilationUnit(generatedType.Value.Item2)
                     .NormalizeWhitespace()
                     .GetText()
                     .ToString();

                File.WriteAllText(Path.ChangeExtension(Path.Combine(outputPath, generatedType.Value.Item1), ".cs"), source);
            }

            return 0;
        }
    }
}
