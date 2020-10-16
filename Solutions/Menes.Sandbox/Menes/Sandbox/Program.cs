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
    using System.Threading.Tasks;
    using Examples;
    using Menes.JsonSchema;
    using Menes.JsonSchema.Generator;
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
        /////// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static /*async Task*/ void Main()
        {
            ////(JsonDocument root, Schema schema) = await SchemaParser.LoadSchema("exampleschema.json", DocumentResolver.Default).ConfigureAwait(false);

            ////ValidationContext validationContext = ValidationContext.Root;
            ////validationContext = schema.Validate(validationContext);
            ////if (validationContext.IsValid)
            ////{
            ////    Console.WriteLine("Valid schema!");
            ////}
            ////else
            ////{
            ////    validationContext.Errors.ForEach(p => Console.WriteLine($"{p.path}: {p.error}"));
            ////}

            ////await RecursiveWriteSchema(root, schema, DocumentResolver.Default).ConfigureAwait(false);

            ////Serialize(schema);

            string val = StringFormatter.ToPascalCaseWithReservedWords("allOf");

            TypeDeclarationSyntax jsonSchema = JsonSchemaModelGenerator.BuildModelForJsonSchema();
            SyntaxNode formattedJsonSchema = Formatter.Format(jsonSchema, new AdhocWorkspace());
            Console.WriteLine();
            Console.WriteLine(formattedJsonSchema.ToFullString());
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

        private static async Task RecursiveWriteSchema(JsonDocument root, Schema schema, IDocumentResolver resolver)
        {
            Console.WriteLine($"type, {schema.Type}");
            Console.WriteLine($"required, {schema.Required}");
            Console.WriteLine($"uniqueItems, {schema.UniqueItems}");

            if (schema.Properties is Schema.SchemaProperties properties)
            {
                JsonProperties<Schema.SchemaOrReference>.JsonPropertyEnumerator propertiesEnumerator = properties.JsonAdditionalProperties;
                while (propertiesEnumerator.MoveNext())
                {
                    Console.Write($"{propertiesEnumerator.Current.Name}, ");
                    (JsonDocument childDoc, Schema.SchemaOrReference childSchema) = await propertiesEnumerator.Current.AsValue().Resolve(root, resolver);
                    await RecursiveWriteSchema(childDoc, childSchema.AsSchema(), resolver).ConfigureAwait(false);
                }
            }

            JsonProperties<JsonAny>.JsonPropertyEnumerator additionalProperties = schema.JsonAdditionalProperties.GetEnumerator();
            while (additionalProperties.MoveNext())
            {
                Console.WriteLine($"{additionalProperties.Current.Name}, {additionalProperties.Current.AsValue()}");
            }
        }
    }
}
