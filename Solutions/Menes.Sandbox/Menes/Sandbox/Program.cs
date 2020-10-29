// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Sandbox
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json.Schema;
    using Menes.Json.Schema.Generator;
    using Menes.Json.Schema.TypeGenerator;
    using Menes.TypeGenerator;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Formatting;
    using NodaTime;
    using NodaTime.Text;
    using OtherExamples;

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
            ////return GenerateJsonSchemaModel();
            ////return UseJsonSchemaModel("exampleschema2.json");
            ////return GenerateTypesForSchema("exampleschema2.json");
            ////return GenerateTypesForSchema("resourcesAndLinks.json#/schemas/Resource");
            ////return GenerateTypesForSchema("person.json#/schemas/Person");
            ////return GenerateTypesForSchema(new[] { "peopleApi.json#/components/schemas/PersonListResource", "peopleApi.json#/components/schemas/EmailAddressListResource", "peopleApi.json#/components/schemas/TelephoneNumberListResource", "peopleApi.json#/components/schemas/RelatedPeopleListResource", "peopleApi.json#/components/schemas/PersonNameListResource" }, "./output/");

            return UseGeneratedCode();
        }

        private static Task UseGeneratedCode()
        {
            PersonName personName = new PersonName(
                givenName: "Matthew",
                familyName: "Adams",
                otherNames: JsonArray.Create("William"))
                .Add(
                    ("fish", "Hello"),
                    ("cushion", "Goodbye"),
                    ("someTime", OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now)));

            Validate(personName);
            Serialize(personName);

            var personListResource = new PersonListResource(
                contentType: "application/vnd.menes.personListResource",
                embedded: new PersonListResource.EmbeddedEntity(
                    items: JsonArray.Create(
                        new PersonResource(
                            contentType: "application/vnd.menes.personResource",
                            links: new PersonResource.LinksEntity(
                                self: new Link("http://endjin.com/examples/people/1"),
                                primaryName: new Link("http://endjin.com/examples/people/1/names/1"))))),
                links: new PersonListResource.LinksEntity(
                    self: new Link("http:/endjin.com/examples/query/people/?id=1&id=2"),
                    items: JsonArray.Create(new Link("http://endjin.com/examples/people/1"), new Link("http://endjin.com/examples/people/2")),
                    next: new Link("http:/endjin.com/examples/query/people/?id=3&id=4"),
                    prev: null));

            Validate(personListResource);
            Serialize(personListResource);
            Validate(personListResource);

            var person =
                new Examples.GeneratedPerson(
                    contentType: "application/vnd.menes.person",
                    links: new Examples.GeneratedPerson.LinksEntity(
                        self: new Examples.Link("http://endjin.com/something"),
                        primaryName: new Examples.Link("http://endjin.com/somename"),
                        ("foo", new Examples.Link("http://endjin.com/something/fooIsh")),
                        ("bar", new Examples.Link("http://endjin.com/something")),
                        ("baz", JsonArray.Create(new Examples.Link("http://endjin.com/something"), new Examples.Link("http://endjin.com/somethingelse")))));

            Validate(person);

            person = person.WithLinks(
                person.Links
                    .Remove(FilterFooIshLinks)
                    .Remove("baz")
                    .Add(("woz", new Examples.Link("http://apple.com"))));

            static bool FilterFooIshLinks(JsonPropertyReference<Examples.Links> p)
            {
                Examples.Links links = p.AsValue();
                return links.IsLink && GetPath(links.AsLink().Href).EndsWith("fooIsh");
            }

            static string GetPath(Uri uri)
            {
                return uri.GetLeftPart(UriPartial.Path);
            }

            ReadOnlyMemory<byte> serializedPerson = Serialize(person);
            var document = JsonDocument.Parse(serializedPerson);
            var deserializedPerson = new Examples.GeneratedPerson(document.RootElement);
            Validate(deserializedPerson);

            var resource =
                new Resource(
                    links: new Resource.LinksEntity(
                        self: new Link("http://endjin.com/something"),
                        ("foo", new Link("http://endjin.com/something")),
                        ("bar", new Link("http://endjin.com/something")),
                        ("baz", JsonArray.Create(new Link("http://endjin.com/something"), new Link("http://endjin.com/somethingelse")))));

            Validate(resource);

            if (resource.Links.TryGet("baz", out Resource.LinksEntity.PropertiesEntity value))
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

            Examples.GeneratedPerson personFromResource = JsonAny.From(resource).As<Examples.GeneratedPerson>();

            // Should be invalid, because we don't have a primaryName link
            Validate(personFromResource);

            Resource resourceWithPrimaryNameLink =
                resource.WithLinks(
                    resource.Links.Add(("primaryName", new Link("http://endjin.com/primaryName"))));

            Examples.GeneratedPerson personFromResourceWithPrimaryName = JsonAny.From(resourceWithPrimaryNameLink).As<Examples.GeneratedPerson>();
            Validate(personFromResourceWithPrimaryName);

            Examples.Person instance =
                new Examples.Person("Ian", "Griffiths")
                    .WithAge(21)
                    .WithContact((JsonEmail)"matthew.adams@endjin.com");

            Validate(instance);
            Serialize(instance);
            return Task.CompletedTask;
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

        private static async Task GenerateTypesForSchema(string[] uris, string? outputPath = null)
        {
            var typeGenerator = new TypeGeneratorJsonSchemaVisitor(DocumentResolver.Default);

            foreach (string uri in uris)
            {
                await GenerateTypesForSchema(uri, typeGenerator).ConfigureAwait(false);
            }

            WriteTypes(typeGenerator, outputPath);
        }

        private static async Task GenerateTypesForSchema(string uri, string? outputPath = null)
        {
            var typeGenerator = new TypeGeneratorJsonSchemaVisitor(DocumentResolver.Default);

            await GenerateTypesForSchema(uri, typeGenerator).ConfigureAwait(false);
            WriteTypes(typeGenerator, outputPath);
        }

        private static async Task GenerateTypesForSchema(string uri, TypeGeneratorJsonSchemaVisitor typeGenerator)
        {
            (string baseUri, JsonDocument root, JsonSchema schema) = await DocumentResolver.Default.LoadSchema(uri).ConfigureAwait(false);

            Validate(schema);

            try
            {
                await typeGenerator.BuildTypes(schema, root, baseUri).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void WriteTypes(TypeGeneratorJsonSchemaVisitor typeGenerator, string? outputPath)
        {
            try
            {
                string? path = null;
                if (outputPath is string op)
                {
                    path = Path.GetFullPath(op);
                    Directory.CreateDirectory(path);
                    path = Path.Combine(path, "output.cs");
                    File.Delete(path);
                    Console.WriteLine(path);
                }

                TypeDeclarationSyntax[] tds = typeGenerator.GenerateTypes();

                foreach (TypeDeclarationSyntax t in tds)
                {
                    SyntaxNode formattedJsonSchema = Formatter.Format(t, new AdhocWorkspace());
                    if (path is string p)
                    {
                        File.AppendAllText(p, formattedJsonSchema.ToFullString());
                    }
                    else
                    {
                        Console.WriteLine(formattedJsonSchema.ToFullString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static Task GenerateJsonSchemaModel()
        {
            TypeDeclarationSyntax jsonSchema = JsonSchemaModelGenerator.BuildModelForJsonSchema();
            SyntaxNode formattedJsonSchema = Formatter.Format(jsonSchema, new AdhocWorkspace());
            Console.WriteLine();
            Console.WriteLine(formattedJsonSchema.ToFullString());
            return Task.CompletedTask;
        }

        private static void SimpleExamples()
        {
            var example = new Examples.JsonObjectExample(
                first: "Hello",
                second: 42,
                third: Duration.FromHours(3),
                age: 37,
                children: JsonArray.Create(new Examples.JsonObjectExample("Sibling A", 1), new Examples.JsonObjectExample("Sibling B", 2)),
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
            var roundtrip = new Examples.JsonObjectExample(doc.RootElement);

            //// At this point "roundtrip" is a JsonObjectExample backed by a single JsonElement.

            var anotherExample = new Examples.JsonObjectExample(
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

            Examples.JsonObjectExample anotherOne = roundtrip.WithFirst("Not the first now");

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

        private static void WriteExample(in Examples.JsonObjectExample example, int tabs = 0)
        {
            string tabString = tabs > 0 ? string.Concat(Enumerable.Repeat("\t", tabs)) : string.Empty;

            Console.WriteLine($"{tabString}{example.First}");
            Console.WriteLine($"{tabString}\tSecond: {example.Second}");
            Console.WriteLine($"{tabString}\tThird: {example.Third?.ToString() ?? "null"}");

            if (example.Children is Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample children)
            {
                Console.WriteLine($"{tabString}\tChildren:");

                foreach (Examples.JsonObjectExample child in children)
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
