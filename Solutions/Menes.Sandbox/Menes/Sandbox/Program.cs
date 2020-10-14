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
    using Examples;
    using Menes.TypeGenerator;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Formatting;
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
            var example = new JsonObjectExample(
                first: "Hello",
                second: 42,
                third: Duration.FromHours(3),
                children: JsonArray.Create(new JsonObjectExample("Sibling A", 1), new JsonObjectExample("Sibling B", 2)),
                //// You could also initialize this with array syntax as below. They both implicitly convert to JsonArray<TItem>.
                //// However, they also allocate additional arrays; up to 4 items is optimized for ImmutableArray creation, so we
                //// take advantage of that with our JsonArray.Create() overloads.
                ////
                //// children: new [] { new JsonObjectExample("Sibling A", 1), new JsonObjectExample("Sibling B", 2) },
                //// children: ImmutableArray.Create( new JsonObjectExample("Sibling A", 1), new JsonObjectExample("Sibling B", 2) ),
                ////
                //// Similarly, the additionalProperties we add have
                //// overloads to optimize the 1-4 values case.
                ("foo", "Here's a foo"),
                ("bar", "Here's a bar"));

            //// At this point we have an object whose values are all CLR types.
            //// The 'children' are boxed into the array as JsonReference objects.

            ReadOnlyMemory<byte> serialized = Serialize(example);

            using var doc = JsonDocument.Parse(serialized);
            var roundtrip = new JsonObjectExample(doc.RootElement);

            //// At this point "roundtrip" is a JsonObjectExample backed by a single JsonElement.

            var anotherExample = new JsonObjectExample(
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

            JsonObjectExample anotherOne = roundtrip.WithFirst("Not the first now");

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

            //// Let's try a Union type

            var unionInt = new JsonUnionExample(32);
            var unionBool = new JsonUnionExample(true);
            var unionJsonObject = new JsonUnionExample(roundtrip);

            JsonUnionExample implicitCreation = (JsonInt64)32;

            Validate(unionInt);
            Validate(unionBool);
            Validate(unionJsonObject);

            ReadOnlyMemory<byte> s1 = Serialize(unionInt);
            ReadOnlyMemory<byte> s2 = Serialize(unionBool);
            ReadOnlyMemory<byte> s3 = Serialize(unionJsonObject);

            using var d1 = JsonDocument.Parse(s1);
            var roundtrip1 = new JsonUnionExample(d1.RootElement);
            using var d2 = JsonDocument.Parse(s2);
            var roundtrip2 = new JsonUnionExample(d2.RootElement);
            using var d3 = JsonDocument.Parse(s3);
            var roundtrip3 = new JsonUnionExample(d3.RootElement);

            Validate(roundtrip1);
            Validate(roundtrip2);
            Validate(roundtrip3);

            Console.WriteLine(roundtrip1.ToString());
            Console.WriteLine(roundtrip2.ToString());
            Console.WriteLine(roundtrip3.ToString());

            Console.WriteLine($"unionInt is a boolean: {roundtrip1.IsJsonBoolean}");
            Console.WriteLine($"unionInt is a int64: {roundtrip1.IsJsonInt64}");
            Console.WriteLine($"unionInt is a JsonObjectExample: {roundtrip1.IsJsonObjectExample}");

            Console.WriteLine($"unionBool is a boolean: {roundtrip2.IsJsonBoolean}");
            Console.WriteLine($"unionBool is a int64: {roundtrip2.IsJsonInt64}");
            Console.WriteLine($"unionBool is a JsonObjectExample: {roundtrip2.IsJsonObjectExample}");

            Console.WriteLine($"unionJsonObject is a boolean: {roundtrip3.IsJsonBoolean}");
            Console.WriteLine($"unionJsonObject is a int64: {roundtrip3.IsJsonInt64}");
            Console.WriteLine($"unionJsonObject is a JsonObjectExample: {roundtrip3.IsJsonObjectExample}");

            var workspace = new AdhocWorkspace();
            SetWorkspaceOptions(workspace);

            var exampleNamespace = new NamespaceDeclaration("Examples");

            var exampleObjectType = new ObjectTypeDeclaration("JsonObjectExample", JsonValueTypeDeclaration.String);

            exampleNamespace.AddDeclaration(exampleObjectType);

            var arrayType = new ValidatedArrayTypeDeclaration(exampleObjectType)
            {
                MinItemsValidation = 10,
            };

            var intType = new ValidatedJsonValueTypeDeclaration("EnumeratedInt32", JsonValueTypeDeclaration.Int32)
            {
                EnumValidation = JsonEnum.From<JsonInt32>(100, 200, 300),
            };

            exampleObjectType.AddPropertyDeclaration("first", JsonValueTypeDeclaration.String);
            exampleObjectType.AddPropertyDeclaration("second", intType);
            exampleObjectType.AddOptionalPropertyDeclaration("third", JsonValueTypeDeclaration.Duration);
            exampleObjectType.AddOptionalPropertyDeclaration("children", arrayType);
            exampleObjectType.AddTypeDeclaration(arrayType);
            exampleObjectType.AddTypeDeclaration(intType);

            TypeDeclarationSyntax tds = exampleObjectType.GenerateType();

            SyntaxNode formattedNode = Formatter.Format(tds, workspace);
            Console.WriteLine();
            Console.WriteLine(formattedNode.ToFullString());

            var exampleUnionType = new UnionTypeDeclaration("JsonUnionExample");
            exampleUnionType.AddTypesToUnion(
                JsonValueTypeDeclaration.Boolean,
                JsonValueTypeDeclaration.Int64,
                exampleObjectType);

            TypeDeclarationSyntax utds = exampleUnionType.GenerateType();

            SyntaxNode formattedUnionNode = Formatter.Format(utds, workspace);
            Console.WriteLine();
            Console.WriteLine(formattedUnionNode.ToFullString());

            var exampleDiscriminatedUnionType = new DiscriminatedUnionTypeDeclaration("JsonDiscriminatedUnionExample", "contentType");
            exampleDiscriminatedUnionType.AddTypesToUnion(
                ("abitfake", JsonValueTypeDeclaration.Boolean),
                ("stillquitefake", JsonValueTypeDeclaration.Int64),
                ("totalFakery", exampleObjectType));

            TypeDeclarationSyntax dutds = exampleDiscriminatedUnionType.GenerateType();

            SyntaxNode formattedDiscriminatedUnionNode = Formatter.Format(dutds, workspace);
            Console.WriteLine();
            Console.WriteLine(formattedDiscriminatedUnionNode.ToFullString());

            TryCreatingAMethod(exampleObjectType, workspace);
        }

        private static void Validate<TValue>(TValue value)
            where TValue : IJsonValue
        {
            ValidationContext validationContext = value.Validate(ValidationContext.Root);

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
        }

        private static void TryCreatingAMethod(ObjectTypeDeclaration exampleObjectType, AdhocWorkspace workspace)
        {
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

        private static void SetWorkspaceOptions(AdhocWorkspace workspace)
        {
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

        private static void WriteExample(in JsonObjectExample example, int tabs = 0)
        {
            string tabString = tabs > 0 ? string.Concat(Enumerable.Repeat("\t", tabs)) : string.Empty;

            Console.WriteLine($"{tabString}{example.First}");
            Console.WriteLine($"{tabString}\tSecond: {example.Second}");
            Console.WriteLine($"{tabString}\tThird: {example.Third?.ToString() ?? "null"}");

            if (example.Children is JsonObjectExample.ValidatedArrayOfJsonObjectExample children)
            {
                Console.WriteLine($"{tabString}\tChildren:");

                foreach (JsonObjectExample child in children)
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
