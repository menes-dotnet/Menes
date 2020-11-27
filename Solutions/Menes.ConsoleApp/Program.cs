// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ConsoleApp
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Driver.GeneratedTypes;
    using Menes.Json.Schema;
    using Menes.JsonSchema.TypeBuilder;

    /// <summary>
    /// Console app for the Menes type generator.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main program entry point.
        /// </summary>
        public static void Main()
        {
            RootEntity entity = new JsonAny("{\"prop1\": \"match\"}").As<RootEntity>();
            entity.Validate();
        }

        private static async Task BuildJsonObjectType()
        {
            var builder = new JsonSchemaBuilder(new FileSystemDocumentResolver());
            string schema = "{ \"id\": \"https://endjin.com/menes/schema/JsonObject\", \"type\": \"object\" }";
            using var doc = JsonDocument.Parse(schema);
            await builder.BuildEntity(doc.RootElement, $"RootEntity{Guid.NewGuid()}").ConfigureAwait(false);
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
    }
}
