// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ConsoleApp
{
    using System;
    using System.Buffers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Driver.GeneratedTypes;
    using Menes.Json.Schema;
    using Menes.JsonSchema;
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
            RootEntity entity = new JsonAny("[\"foo\", \"bar\", \"baz\"]").As<RootEntity>();
            Console.WriteLine(entity.Validate(ValidationContext.ValidContext).IsValid);

            var schema = new Draft201909Schema(
                id: "http://endjin.com/something",
                type: Draft201909MetaValidation.TypeEntity.SimpleTypesEntity.EnumValues.String,
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
