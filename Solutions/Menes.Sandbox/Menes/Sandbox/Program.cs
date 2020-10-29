// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Sandbox
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Examples;
    using Menes.Json.Schema;
    using Menes.Json.Schema.Generator;
    using Menes.Json.Schema.TypeGenerator;
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
        private static readonly HashSet<string> SchemasBeingWritten = new HashSet<string>();

        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static Task Main()
        {
            ////var builder = new StringBuilder();
            ////StringFormatter.FormatUriAsFullyQualifiedName("c:\\some\\location\\myProperty.json", builder);
            ////Console.WriteLine(builder.ToString());
            ////builder.Clear();
            ////StringFormatter.FormatUriAsFullyQualifiedName("https://endjin.com:8080/some/location/myProperty.json", builder);
            ////Console.WriteLine(builder.ToString());
            ////builder.Clear();
            ////StringFormatter.FormatFragmentAsFullyQualifiedName("/components/schema/someType", builder);
            ////Console.WriteLine(builder.ToString());
            ////builder.Clear();
            ////StringFormatter.FormatUriAsFullyQualifiedName("https://endjin.com/foo", builder);
            ////Console.WriteLine(builder.ToString());

            ////SimpleExamples();
            ////GenerateJsonSchemaModel();
            ////return UseJsonSchemaModel("exampleschema2.json");
            ////return GenerateTypesForSchema("exampleschema2.json");
            ////return GenerateTypesForSchema("resourcesAndLinks.json#/schemas/Resource");
            ////return GenerateTypesForSchema("person.json#/schemas/Person");

            UseGeneratedCode();
            return Task.CompletedTask;
        }

        private static void UseGeneratedCode()
        {
            var person =
                new GeneratedPerson(
                    links: new GeneratedPerson.LinksEntity(
                        self: new Link("http://endjin.com/something"),
                        primaryName: new Link("http://endjin.com/somename"),
                        ("foo", new Link("http://endjin.com/something")),
                        ("bar", new Link("http://endjin.com/something")),
                        ("baz", JsonArray.Create(new Link("http://endjin.com/something"), new Link("http://endjin.com/somethingelse")))));

            Validate(person);

            var resource =
                new Resource(
                    links: new Resource.LinksEntity(
                        self: new Link("http://endjin.com/something"),
                        ("foo", new Link("http://endjin.com/something")),
                        ("bar", new Link("http://endjin.com/something")),
                        ("baz", JsonArray.Create(new Link("http://endjin.com/something"), new Link("http://endjin.com/somethingelse")))));

            Validate(resource);

            if (resource.Links.TryGet("baz", out Links value))
            {
                if (value.IsLink)
                {
                    Console.WriteLine(value.AsLink().Href);
                }
                else
                {
                    foreach (Link link in value.AsLinkCollection())
                    {
                        Console.WriteLine(link.Href);
                    }
                }
            }

            Person instance =
                new Person("Ian", "Griffiths")
                    .WithAge(21)
                    .WithContact((JsonEmail)"matthew.adams@endjin.com");

            Validate(instance);
            Serialize(instance);
        }

        private static async Task UseJsonSchemaModel(string uri)
        {
            (string baseUri, JsonDocument root, JsonSchema schema) = await DocumentResolver.Default.LoadSchema(uri).ConfigureAwait(false);

            Validate(schema);

            await RecursiveWriteSchema(baseUri, string.Empty, root, schema, DocumentResolver.Default).ConfigureAwait(false);

            Serialize(schema);
        }

        private static void Validate<T>(T value)
            where T : struct, IJsonValue
        {
            var sw = Stopwatch.StartNew();
            ValidationContext validationContext = ValidationContext.Root;
            validationContext = value.Validate(validationContext);
            sw.Stop();
            Console.WriteLine($"Took: {sw.ElapsedMilliseconds}ms");

            if (validationContext.IsValid)
            {
                Console.WriteLine($"Valid {typeof(T).Name}!");
            }
            else
            {
                validationContext.Errors.ForEach(p => Console.WriteLine($"{p.path}: {p.error}"));
            }
        }

        private static async Task GenerateTypesForSchema(string uri)
        {
            (string baseUri, JsonDocument root, JsonSchema schema) = await DocumentResolver.Default.LoadSchema(uri).ConfigureAwait(false);

            Validate(schema);

            var typeGenerator = new TypeGeneratorJsonSchemaVisitor(DocumentResolver.Default);
            try
            {
                await typeGenerator.BuildTypes(schema, root, baseUri).ConfigureAwait(false);

                TypeDeclarationSyntax[] tds = typeGenerator.GenerateTypes();
                foreach (TypeDeclarationSyntax t in tds)
                {
                    SyntaxNode formattedJsonSchema = Formatter.Format(t, new AdhocWorkspace());
                    Console.WriteLine(formattedJsonSchema.ToFullString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void GenerateJsonSchemaModel()
        {
            TypeDeclarationSyntax jsonSchema = JsonSchemaModelGenerator.BuildModelForJsonSchema();
            SyntaxNode formattedJsonSchema = Formatter.Format(jsonSchema, new AdhocWorkspace());
            Console.WriteLine();
            Console.WriteLine(formattedJsonSchema.ToFullString());
        }

        private static void SimpleExamples()
        {
            var example = new JsonObjectExample(
                first: "Hello",
                second: 42,
                third: Duration.FromHours(3),
                age: 37,
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
                age: null,
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

            if (anotherOne.TryGet("foo", out JsonString value))
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
        }

        private static void BuildAnExampleType()
        {
            var exampleNamespace = new NamespaceDeclaration("Examples");

            var exampleObjectType = new ObjectTypeDeclaration("JsonObjectExample", JsonValueTypeDeclaration.String);

            exampleNamespace.AddDeclaration(exampleObjectType);

            var arrayType = new ValidatedArrayTypeDeclaration("MinimumLengthArray", exampleObjectType)
            {
                MinItemsValidation = 10,
            };

            var enumeratedInteger = new ValidatedJsonValueTypeDeclaration("EnumeratedInt32", JsonValueTypeDeclaration.Int32)
            {
                EnumValidation = JsonEnum.From<JsonInt32>(100, 200, 300),
            };

            var positiveInteger = new ValidatedJsonValueTypeDeclaration("PositiveInteger", JsonValueTypeDeclaration.Integer)
            {
                ExclusiveMinimumValidation = 0,
            };

            exampleObjectType.AddPropertyDeclaration("first", JsonValueTypeDeclaration.String);
            exampleObjectType.AddPropertyDeclaration("second", enumeratedInteger);
            exampleObjectType.AddOptionalPropertyDeclaration("third", JsonValueTypeDeclaration.Duration);
            exampleObjectType.AddOptionalPropertyDeclaration("age", positiveInteger);
            exampleObjectType.AddOptionalPropertyDeclaration("children", arrayType);
            exampleObjectType.AddTypeDeclaration(arrayType);
            exampleObjectType.AddTypeDeclaration(enumeratedInteger);
            exampleObjectType.AddTypeDeclaration(positiveInteger);

            TypeDeclarationSyntax tds = exampleObjectType.GenerateType();

            SyntaxNode formattedNode = Formatter.Format(tds, new AdhocWorkspace());
            Console.WriteLine();
            Console.WriteLine(formattedNode.ToFullString());
        }

        private static void CustomObjectExample()
        {
            //// We can build up arbitrary Json structures from the model
            //// It's easy not to be super-efficient, but it is functional for those edge
            //// cases where you don't have any schema but want the same programming model.
            var idObject = new JsonObject(JsonProperties<JsonAny>.FromValues(("id", new JsonGuid(Guid.NewGuid()))));

            var greetingObject = new JsonObject(
                                JsonProperties<JsonAny>.FromValues(
                                    ("greet", new JsonString("Hello!")),
                                    ("frequency", new JsonInt32(100)),
                                    ("child", idObject)));

            var array = new JsonObject(
                JsonProperties<JsonAny>.FromValues(
                    ("id", new JsonInt32(100)),
                    ("date", new JsonDate(LocalDate.FromDateTime(DateTime.Today))),
                    ("greeting", greetingObject)));

            Console.WriteLine();
            Serialize(array);
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

            foreach (JsonPropertyReference<JsonString> property in example.JsonAdditionalProperties)
            {
                Console.WriteLine($"{tabString}\t{property.Name}: {property.AsValue()}");
            }
        }

        private static async Task RecursiveWriteSchema(string baseUri, string pointer, JsonDocument root, JsonSchema schema, IDocumentResolver resolver)
        {
            if (SchemasBeingWritten.Contains(schema.Id ?? "unknown"))
            {
                Console.Write("{...}, ");
                return;
            }

            if (schema.Id is JsonString id)
            {
                SchemasBeingWritten.Add(id);
            }

            Console.Write("{");
            if (schema.Type.HasValue)
            {
                Console.Write($"'type': {schema.Type}, ");
            }

            if (schema.Required.HasValue)
            {
                Console.Write($"'required': {schema.Required}, ");
            }

            if (schema.UniqueItems.HasValue)
            {
                Console.Write($"'uniqueItems': {schema.UniqueItems}, ");
            }

            if (schema.Properties is JsonSchema.SchemaProperties properties)
            {
                JsonProperties<JsonSchema.SchemaOrReference>.JsonPropertyEnumerator propertiesEnumerator = properties.JsonAdditionalProperties;
                while (propertiesEnumerator.MoveNext())
                {
                    Console.Write($"'{propertiesEnumerator.Current.Name}': ");
                    (string childBaseUri, JsonDocument childDoc, JsonSchema.SchemaOrReference childSchema) = await propertiesEnumerator.Current.AsValue().Resolve(baseUri, root, resolver);
                    await RecursiveWriteSchema(childBaseUri, pointer + "." + propertiesEnumerator.Current.Name, childDoc, childSchema.AsJsonSchema(), resolver).ConfigureAwait(false);
                }
            }

            JsonProperties<JsonAny>.JsonPropertyEnumerator additionalProperties = schema.JsonAdditionalProperties.GetEnumerator();
            while (additionalProperties.MoveNext())
            {
                Console.Write($"'{additionalProperties.Current.Name}': {additionalProperties.Current.AsValue()}, ");
            }

            Console.Write("}, ");

            if (schema.Id is JsonString id2)
            {
                SchemasBeingWritten.Remove(id2);
            }
        }
    }
}
