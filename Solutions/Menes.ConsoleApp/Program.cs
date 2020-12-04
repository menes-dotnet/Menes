// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ConsoleApp
{
    using System;
    using System.Buffers;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Driver.GeneratedTypes;
    using Menes.Json;
    using Menes.JsonSchema;
    using Menes.JsonSchema.TypeModel;

    /// <summary>
    /// Console app for the Menes type generator.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task Main()
        {
            // New up a json walker.
            var walker = new JsonWalker(new HttpClientDocumentResolver(new HttpClient()));
            var builder = new JsonSchemaBuilder(walker);

            await builder.BuildTypesFor("https://json-schema.org/draft/2019-09/schema").ConfigureAwait(false);
        }

        private static void PlayWithTheSchema()
        {
            RootEntity entity = new JsonAny("[\"foo\", \"bar\", \"baz\"]").As<RootEntity>();
            Console.WriteLine(entity.Validate(ValidationContext.ValidContext).IsValid);

            var schema = new Draft201909Schema(
                id: "http://endjin.com/schemas/SomeExample",
                type: JsonArray.From(
                    Draft201909MetaValidation.TypeEntity.SimpleTypesEntity.EnumValues.String,
                    Draft201909MetaValidation.TypeEntity.SimpleTypesEntity.EnumValues.Integer),
                format: "date-time");

            string serializedSchema = Serialize(schema);

            Draft201909Schema deserializedSchema = Deserialize<Draft201909Schema>(serializedSchema);

            Console.WriteLine(deserializedSchema.Validate(ValidationContext.ValidContext).IsValid);
        }

        private static string Serialize(IJsonValue value)
        {
            var abw = new ArrayBufferWriter<byte>();
            var utf8JsonWriter = new Utf8JsonWriter(abw);
            value.WriteTo(utf8JsonWriter);
            utf8JsonWriter.Flush();
            string serializedValue = Encoding.UTF8.GetString(abw.WrittenSpan);
            Console.WriteLine(serializedValue);
            return serializedValue;
        }

        private static T Deserialize<T>(string jsonValue)
            where T : struct, IJsonValue
        {
            using var doc = JsonDocument.Parse(jsonValue);
            return doc.RootElement.Clone().As<T>();
        }
    }
}
