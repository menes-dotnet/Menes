// <copyright file="SpecWriter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.SpecGenerator
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// Write .feature files for specs from the json schema specs.
    /// </summary>
    /// <remarks>
    /// https://github.com/json-schema-org/JSON-Schema-Test-Suite/tree/master/tests/draft2019-09.
    /// </remarks>
    internal class SpecWriter
    {
        /// <summary>
        /// Write the feature files for the json specs.
        /// </summary>
        /// <param name="specDirectories">The spec directories.</param>
        internal static void Write(SpecDirectories specDirectories)
        {
            foreach ((string inputFile, string outputFile) in specDirectories.EnumerateTests())
            {
                Console.WriteLine($"Reading: {inputFile}");
                Console.WriteLine($"Writing: {outputFile}");
                Console.WriteLine();
                WriteFeatureFile(inputFile, outputFile);
            }
        }

        private static void WriteFeatureFile(string inputFile, string outputFile)
        {
            string inputFileUri = Path.GetFileName(inputFile);
            using var testDocument = JsonDocument.Parse(File.ReadAllText(inputFile));

            var builder = new StringBuilder();

            WriteFeatureHeading(Path.GetFileNameWithoutExtension(inputFile), builder);

            int index = 0;
            foreach (JsonElement scenarioDefinition in testDocument.RootElement.EnumerateArray())
            {
                WriteScenario(inputFileUri, index, scenarioDefinition, builder);
                ++index;
            }

            File.WriteAllText(outputFile, builder.ToString());
        }

        private static void WriteScenario(string inputFileUri, int scenarioIndex, JsonElement scenarioDefinition, StringBuilder builder)
        {
            string inputSchemaReference = $"#/{scenarioIndex}/schema";

            string scenarioTitle = scenarioDefinition.GetProperty("description").GetString();
            scenarioTitle = NormalizeTitleForDeduplication(scenarioTitle);

            builder.AppendLine();
            builder.AppendLine($"Scenario Outline: {scenarioTitle}");
            builder.AppendLine("/* Schema: ");
            builder.AppendLine(scenarioDefinition.GetProperty("schema").ToString());
            builder.AppendLine("*/");
            builder.AppendLine($"    Given the input JSON file \"{inputFileUri}\"");
            builder.AppendLine($"    And the schema at \"{inputSchemaReference}\"");
            builder.AppendLine("    And the input data at \"<inputDataReference>\"");
            builder.AppendLine("    And I generate a type for the schema");
            builder.AppendLine("    And I construct an instance of the schema type from the data");
            builder.AppendLine("    When I validate the instance");
            builder.AppendLine("    Then the result will be <valid>");
            builder.AppendLine();
            builder.AppendLine("    Examples:");
            builder.AppendLine("        | inputDataReference   | valid | description                                                                      |");

            int testIndex = 0;
            foreach (JsonElement test in scenarioDefinition.GetProperty("tests").EnumerateArray())
            {
                WriteExample(scenarioIndex, testIndex, test, builder);
                ++testIndex;
            }
        }

        private static string NormalizeTitleForDeduplication(string scenarioTitle)
        {
            scenarioTitle = scenarioTitle
                .Replace("[", "array[")
                .Replace("<=", " less than or equal ")
                .Replace("<", " less than ")
                .Replace(">=", " greater than or equal ")
                .Replace(">", " greater than ")
                .Replace("==", " equals ")
                .Replace("=", " equals ");
            return scenarioTitle;
        }

        private static void WriteFeatureHeading(string featureName, StringBuilder builder)
        {
            builder.AppendLine($"Feature: {featureName}");
            builder.AppendLine("    In order to use json-schema");
            builder.AppendLine("    As a developer");
            builder.AppendLine($"    I want to support {featureName}");
        }

        private static void WriteExample(int scenarioIndex, int testIndex, JsonElement test, StringBuilder builder)
        {
            string inputDataReference = $"#/{scenarioIndex:D3}/tests/{testIndex:D3}/data";

            string valid;
            if (test.GetProperty("valid").ValueKind == JsonValueKind.False)
            {
                valid = "false";
            }
            else
            {
                valid = "true ";
            }

            string description = test.GetProperty("description").GetString();
            description = description.PadRight(80);

            builder.AppendLine($"        | {inputDataReference} | {valid} | {description} |");
        }
    }
}