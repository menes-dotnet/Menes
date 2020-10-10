// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Sandbox
{
    using System;
    using System.Buffers;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using Menes.Examples;
    using Menes.TypeGenerator;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Formatting;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Formatting;
    using Microsoft.CodeAnalysis.Options;
    using NodaTime;

    /// <summary>
    /// Main program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        public static void Main()
        {
            var example = new JsonObjectExample2(
                first: "Hello",
                second: 42,
                third: Duration.FromHours(3),
                children: JsonArray.Create(new JsonObjectExample2("Sibling A", 1), new JsonObjectExample2("Sibling B", 2)),
                //// You could also initialize this with array syntax as below. They both implicitly convert to JsonArray<TItem>.
                //// However, they also allocate additional arrays; up to 4 items is optimized for ImmutableArray creation, so we
                //// take advantage of that with our JsonArray.Create() overloads.
                ////
                //// children: new [] { new JsonObjectExample2("Sibling A", 1), new JsonObjectExample2("Sibling B", 2) },
                //// children: ImmutableArray.Create( new JsonObjectExample2("Sibling A", 1), new JsonObjectExample2("Sibling B", 2) ),
                ////
                //// Similarly, the additionalProperties we add have
                //// overloads to optimize the 1-4 values case.
                ("foo", "Here's a foo"),
                ("bar", "Here's a bar"));

            //// At this point we have an object whose values are all CLR types.
            //// The 'children' are boxed into the array as JsonReference objects.

            ReadOnlyMemory<byte> serialized = Serialize(example);

            using var doc = JsonDocument.Parse(serialized);
            var roundtrip = new JsonObjectExample2(doc.RootElement);

            //// At this point "roundtrip" is a JsonObjectExample2 backed by a single JsonElement.

            var anotherExample = new JsonObjectExample2(
                first: "Goodbye",
                second: example.Second,
                third: Duration.FromHours(3),
                children: roundtrip.Children,
                ("daisy", "Here's a daisy"),
                ("poppy", "Here's a poppy"));

            //// This is an interesting case. anotherExample has its own CLR properties, plus a copy of the CLR value of Second from 'example'
            //// plus a reference to the 'children' from roundtrip - it is literally a new wrapper for the same block of memory backing a JsonElement.

            WriteExample(roundtrip);

            Console.WriteLine();

            JsonObjectExample2 anotherOne = roundtrip.WithFirst("Not the first now");

            //// anotherOne has replaced a single value (the "First" property) with a string value.
            //// All the remaining values have become stack-allocated wrappers around the original JsonElements
            //// that were children of the original parent JsonELement referened by roundtrip, including the
            //// JsonArray that is a stack allocated JsonReference.

            WriteExample(anotherOne);

            _ = Serialize(anotherOne);

            Console.WriteLine();

            if (anotherOne.TryGetAdditionalProperty("foo", out JsonString? value))
            {
                Console.WriteLine($"Found foo: {value}");
            }

            ValidationContext validationContext = anotherOne.Validate(ValidationContext.Root);

            if (validationContext.IsValid)
            {
                Console.WriteLine("Validated succesfully.");
            }
            else
            {
                foreach ((string path, string error) in validationContext.Errors)
                {
                    Console.WriteLine($"Path: \"{path}\" Error: \"{error}\"");
                }
            }

            //// We can build up arbitrary Json structures from the model
            //// It's easy not to be super-efficient, but it is functional for those edge
            //// cases where you don't have any schema but want the same programming model.
            var idObject = new JsonObject(JsonProperties.FromValues(("id", new JsonGuid(Guid.NewGuid()))));

            var greetingObject = new JsonObject(
                                JsonProperties.FromValues(
                                    ("greet", new JsonString("Hello!")),
                                    ("frequency", new JsonInt32(100)),
                                    ("child", idObject)));

            var array = new JsonObject(
                JsonProperties.FromValues(
                    ("id", new JsonInt32(100)),
                    ("date", new JsonDate(LocalDate.FromDateTime(DateTime.Today))),
                    ("greeting", greetingObject)));

            Console.WriteLine();
            Serialize(array);

            var exampleObjectType = new ObjectTypeDeclaration(new NamespaceDeclaration("Menes.Examples"), "JsonObjectExample2", JsonValueTypeDeclaration.String);

            exampleObjectType.AddPropertyDeclaration(new PropertyDeclaration(exampleObjectType, "first", JsonValueTypeDeclaration.String));
            exampleObjectType.AddPropertyDeclaration(new PropertyDeclaration(exampleObjectType, "second", JsonValueTypeDeclaration.Int32));
            exampleObjectType.AddPropertyDeclaration(new PropertyDeclaration(exampleObjectType, "third", JsonValueTypeDeclaration.Duration.AsOptional()));
            exampleObjectType.AddOptionalArrayProperty("children", exampleObjectType);

            TypeDeclarationSyntax tds = exampleObjectType.GenerateType();
            var workspace = new AdhocWorkspace();
            OptionSet options = workspace.Options;
            options = options.WithChangedOption(CSharpFormattingOptions.IndentBlock, true);
            options = options.WithChangedOption(CSharpFormattingOptions.IndentBraces, false);
            options = options.WithChangedOption(CSharpFormattingOptions.IndentSwitchCaseSection, true);
            options = options.WithChangedOption(CSharpFormattingOptions.IndentSwitchCaseSectionWhenBlock, true);
            options = options.WithChangedOption(CSharpFormattingOptions.IndentSwitchSection, true);
            options = options.WithChangedOption(CSharpFormattingOptions.LabelPositioning, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLineForCatch, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLineForClausesInQuery, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLineForElse, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLineForFinally, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLineForMembersInAnonymousTypes, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLineForMembersInObjectInit, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInAccessors, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInAnonymousMethods, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInAnonymousTypes, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInControlBlocks, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInLambdaExpressionBody, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInMethods, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInObjectCollectionArrayInitializers, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInProperties, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInTypes, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceAfterCast, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceAfterColonInBaseTypeDeclaration, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceAfterComma, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceAfterControlFlowStatementKeyword, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceAfterDot, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceAfterMethodCallName, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceAfterSemicolonsInForStatement, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceBeforeColonInBaseTypeDeclaration, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceBeforeComma, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceBeforeDot, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceBeforeOpenSquareBracket, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceBeforeSemicolonsInForStatement, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceBetweenEmptyMethodCallParentheses, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceBetweenEmptyMethodDeclarationParentheses, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceBetweenEmptySquareBrackets, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpacesIgnoreAroundVariableDeclaration, true);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceWithinCastParentheses, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceWithinExpressionParentheses, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceWithinMethodCallParentheses, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceWithinMethodDeclarationParenthesis, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceWithinOtherParentheses, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpaceWithinSquareBrackets, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpacingAfterMethodDeclarationName, false);
            options = options.WithChangedOption(CSharpFormattingOptions.SpacingAroundBinaryOperator, BinaryOperatorSpacingOptions.Single);
            options = options.WithChangedOption(CSharpFormattingOptions.WrappingKeepStatementsOnSingleLine, true);
            options = options.WithChangedOption(CSharpFormattingOptions.WrappingPreserveSingleLine, false);
            workspace.TryApplyChanges(workspace.CurrentSolution.WithOptions(options));

            SyntaxNode formattedNode = Formatter.Format(tds, workspace);
            Console.WriteLine();
            Console.WriteLine(formattedNode.ToFullString());

            var methodBody = new StringBuilder();
            methodBody.AppendLine("System.Console.WriteLine(\"Hello\");");
            methodBody.AppendLine("if (global)");
            methodBody.AppendLine("{");
            methodBody.AppendLine("System.Console.WriteLine(\"world.\");");
            methodBody.AppendLine("}");
            methodBody.AppendLine("else");
            methodBody.AppendLine("{");
            methodBody.AppendLine("System.Console.WriteLine(\"Cambridge.\");");
            methodBody.AppendLine("}");

            var exampleMethod = new MethodDeclaration(exampleObjectType, "TestMethod", methodBody.ToString(), VoidTypeDeclaration.Instance, new ParameterDeclaration("global", "bool"));
            SyntaxNode formattedMethod = Formatter.Format(exampleMethod.GenerateMethod(), workspace);
            Console.WriteLine();
            Console.WriteLine(formattedMethod.ToFullString());
        }

        private static ReadOnlyMemory<byte> Serialize<T>(in T example)
            where T : struct, IJsonValue
        {
            var abw = new ArrayBufferWriter<byte>();
            using var utf8JsonWriter = new Utf8JsonWriter(abw);
            example.WriteTo(utf8JsonWriter);
            utf8JsonWriter.Flush();
            Console.WriteLine();
            Console.WriteLine(Encoding.UTF8.GetString(abw.WrittenSpan));
            Console.WriteLine();
            return abw.WrittenMemory;
        }

        private static void WriteExample(in JsonObjectExample2 example, int tabs = 0)
        {
            string tabString = tabs > 0 ? string.Concat(Enumerable.Repeat("\t", tabs)) : string.Empty;

            Console.WriteLine($"{tabString}{example.First}");
            Console.WriteLine($"{tabString}\tSecond: {example.Second}");
            Console.WriteLine($"{tabString}\tThird: {example.Third?.ToString() ?? "null"}");

            if (example.Children is JsonArray<JsonObjectExample2> children)
            {
                Console.WriteLine($"{tabString}\tChildren:");

                foreach (JsonObjectExample2 child in children)
                {
                    WriteExample(child, tabs + 2);
                }
            }

            foreach (JsonPropertyReference property in example.AdditionalProperties)
            {
                Console.WriteLine($"{tabString}\t{property.Name}: {property.AsValue<JsonString>()}");
            }
        }
    }
}
