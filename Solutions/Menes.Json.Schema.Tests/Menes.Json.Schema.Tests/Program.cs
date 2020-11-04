// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema.Tests
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
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
        private static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("You must provide the path to the tests.");
                return;
            }

            if (args[0] == "run")
            {
                TestExecutor.ExecuteTests();
                return;
            }

            string output = Path.Combine(args[0], "..\\tests");
            string remotes = Path.Combine(args[0], "..\\remotes");

            var uris = new List<(string, string, string, int)>();

            foreach (string file in Directory.EnumerateFiles(args[0]))
            {
                using var doc = JsonDocument.Parse(File.ReadAllText(file));
                int length = doc.RootElement.GetArrayLength();
                for (int i = 0; i < length; ++i)
                {
                    uris.Add(($"{file}#/{i}/schema", Path.GetFileNameWithoutExtension(file) + $"{i:D3}", file, i));
                }
            }

            var testsToExecute = new List<string?>();

            await GenerateTypesForSchema(uris.ToArray(), output, remotes, testsToExecute).ConfigureAwait(false);

            WriteTestExecutor(Path.Combine(output, "TestExecutor.cs"), testsToExecute);
        }

        private static void WriteTestExecutor(string outputFile, List<string?> testsToExecute)
        {
            var builder = new StringBuilder();
            builder.AppendLine(FileHeader.Replace(".<NS>", string.Empty).Replace("<FN>", Path.GetFileName(outputFile)));

            builder.AppendLine("public static class TestExecutor");
            builder.AppendLine("{");
            builder.AppendLine("    public static int executedCount = 0;");
            builder.AppendLine("    public static int ignoredCount = 0;");
            builder.AppendLine("    public static int passedCount = 0;");
            builder.AppendLine("    public static int failedCount = 0;");
            builder.AppendLine("    public static void ExecuteTests()");
            builder.AppendLine("    {");

            foreach (string? t in testsToExecute)
            {
                if (t is string test)
                {
                    builder.AppendLine("executedCount++;");
                    builder.Append("if(");
                    builder.Append(test);
                    builder.AppendLine(")");
                    builder.AppendLine("{");
                    builder.AppendLine("    passedCount++;");
                    builder.AppendLine("}");
                    builder.AppendLine("else");
                    builder.AppendLine("{");
                    builder.AppendLine("    failedCount++;");
                    builder.AppendLine("}");
                }
                else
                {
                    builder.AppendLine("ignoredCount++;");
                }
            }

            builder.AppendLine("System.Console.WriteLine($\"Total: {executedCount + ignoredCount} Executed: {executedCount} Passed: {passedCount} Failed: {failedCount} Ignored: {ignoredCount}\");");

            builder.AppendLine("    }");
            builder.AppendLine("}");

            builder.AppendLine(FileFooter);

            File.WriteAllText(outputFile, builder.ToString());
        }

        private static async Task GenerateTypesForSchema((string, string, string, int)[] uris, string outputPath, string remotes, List<string?> testsToExecute)
        {
            IDocumentResolver documentResolver = new CompoundDocumentResolver(new FakeWebDocumentResolver(remotes), new FileSystemDocumentResolver());
            ISchemaResolver schemaResolver = new SchemaResolver(documentResolver);

            foreach ((string, string, string, int) uri in uris)
            {
                string ns = StringFormatter.ToPascalCaseWithReservedWords(uri.Item2);

                schemaResolver.Reset();

                var typeGenerator = new TypeGeneratorJsonSchemaVisitor(schemaResolver);
                await GenerateTypesForSchema(uri.Item1, typeGenerator, schemaResolver).ConfigureAwait(false);
                string outputFile = Path.ChangeExtension(Path.Combine(outputPath, uri.Item2), ".cs");

                Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

                File.Delete(outputFile);
                File.AppendAllText(outputFile, FileHeader.Replace("<NS>", ns).Replace("<FN>", Path.GetFileName(outputFile)));

                try
                {
                    string rootTypeName = WriteTypes(typeGenerator, outputFile);
                    WriteTests(outputFile, uri.Item3, uri.Item4, ns, testsToExecute, rootTypeName);
                }
                catch (Exception ex)
                {
                    WriteTests(outputFile, uri.Item3, uri.Item4, ns, testsToExecute);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(outputFile);
                    Console.ResetColor();
                    Console.WriteLine(ex.ToString());
                }

                File.AppendAllText(outputFile, FileFooter);
            }
        }

        private static void WriteTests(string outputFile, string inputFile, int index, string ns, List<string?> testsToExecute, string? typeName = null)
        {
            using var document = JsonDocument.Parse(File.ReadAllText(inputFile));
            JsonElement spec = document.RootElement.EnumerateArray().Skip(index).Take(1).Single();
            var builder = new StringBuilder();

            if (!string.IsNullOrEmpty(typeName))
            {
                builder.AppendLine("///  <summary>");
                builder.AppendLine($"/// {spec.GetProperty("description").GetString()}");
                builder.AppendLine("/// </summary>");
                builder.AppendLine("public static class Tests");
                builder.AppendLine("{");
            }

            int testIndex = 0;

            foreach (JsonElement test in spec.GetProperty("tests").EnumerateArray())
            {
                if (!string.IsNullOrEmpty(typeName))
                {
                    builder.AppendLine("/// <summary>");
                    string description = test.GetProperty("description").GetString();
                    builder.AppendLine($"/// {description}");
                    builder.AppendLine("/// </summary>");
                    builder.AppendLine($"    public static bool Test{testIndex}()");
                    builder.AppendLine("    {");
                    builder.AppendLine($"        using var doc = System.Text.Json.JsonDocument.Parse({StringFormatter.EscapeForCSharpString(test.GetProperty("data").GetRawText(), true)});");
                    builder.AppendLine($"        var schema = new {typeName}(doc.RootElement);");
                    builder.AppendLine("        var context = schema.Validate(Menes.ValidationContext.Root);");
                    bool expectValid = test.GetProperty("valid").GetBoolean();
                    if (expectValid)
                    {
                        builder.AppendLine("        if (!context.IsValid)");
                    }
                    else
                    {
                        builder.AppendLine("        if (context.IsValid)");
                    }

                    string expected = expectValid ? "valid" : "invalid";
                    string actual = expectValid ? "invalid" : "valid";

                    builder.AppendLine("        {");
                    builder.AppendLine($"            System.Console.WriteLine(\"Failed {ns}.Tests.Test{testIndex}: {StringFormatter.EscapeForCSharpString(description, true)?.Trim('"')}\");");
                    builder.AppendLine($"            System.Console.WriteLine(\"Expected: {expected} but was {actual}\");");
                    builder.AppendLine("            return false;");
                    builder.AppendLine("        }");
                    builder.AppendLine("            return true;");
                    builder.AppendLine("    }");
                    testsToExecute.Add($"{ns}.Tests.Test{testIndex}()");
                }
                else
                {
                    testsToExecute.Add(null);
                }

                testIndex++;
            }

            if (!string.IsNullOrEmpty(typeName))
            {
                builder.AppendLine("}");
                File.AppendAllText(outputFile, builder.ToString());
            }
        }

        private static async Task GenerateTypesForSchema(string uri, TypeGeneratorJsonSchemaVisitor typeGenerator, ISchemaResolver schemaResolver)
        {
            (string baseUri, JsonDocument root, JsonSchema schema) resolved = await schemaResolver.LoadSchema(uri).ConfigureAwait(false);

            var abf = new ArrayBufferWriter<byte>();
            using var writer = new Utf8JsonWriter(abf);
            resolved.schema.WriteTo(writer);
            writer.Flush();

            var root = JsonDocument.Parse(abf.WrittenMemory);
            string baseUri = resolved.baseUri + "\\" + Guid.NewGuid().ToString();
            JsonSchema schema = JsonSchema.FromJsonElement(root.RootElement);
            if (!schema.IsBooleanSchema())
            {
                if (schema.Id is JsonString id)
                {
                    baseUri = schema.Id;
                }
                else
                {
                    schema = schema.WithId(baseUri + "#TestSchema");
                    schema = schema.WithRef(baseUri);
                }
            }

            schemaResolver.AddSchema(baseUri, root, schema);

            try
            {
                await typeGenerator.BuildTypes(schema, root, baseUri).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(uri);
                Console.ResetColor();
                Console.WriteLine(ex.ToString());
            }
        }

        private static string WriteTypes(TypeGeneratorJsonSchemaVisitor typeGenerator, string outputFile)
        {
            TypeDeclarationSyntax[] tds = typeGenerator.GenerateTypes();

            foreach (TypeDeclarationSyntax t in tds)
            {
                SyntaxNode formattedJsonSchema = Formatter.Format(t, new AdhocWorkspace());
                File.AppendAllText(outputFile, formattedJsonSchema.ToFullString());
            }

            return typeGenerator.RootTypeName;
        }
    }
}
