// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Sandbox
{
    using System;
    using System.Buffers;
    using System.Collections.Immutable;
    using System.Text;
    using System.Text.Json;
    using Menes.Examples;
    using Menes.TypeGenerator;
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
            Console.WriteLine(NameFormatter.ToPascalCase("  Hello world!"));
            Console.WriteLine(NameFormatter.ToPascalCase("  Hello 3  world!"));
            Console.WriteLine(NameFormatter.ToPascalCase("  Hello ! _ world!"));
            Console.WriteLine(NameFormatter.ToPascalCase("_embedded"));
            Console.WriteLine(NameFormatter.ToPascalCase("_links"));

            Console.WriteLine(NameFormatter.ToCamelCase("  Hello world!"));
            Console.WriteLine(NameFormatter.ToCamelCase("  Hello 3  world!"));
            Console.WriteLine(NameFormatter.ToCamelCase("  Hello ! _ world!"));
            Console.WriteLine(NameFormatter.ToCamelCase("_embedded"));
            Console.WriteLine(NameFormatter.ToCamelCase("_links"));

            var myValue = new JsonString("Hello");
            myValue = "Greetings";

            Console.WriteLine(myValue + " world!");

            var example = new JsonObjectExample(
                "Hello",
                42,
                Duration.FromHours(3),
                additionalProperties: new (string, JsonString)[] { ("Foo", "First"), ("Bar", "Second") });

            var abw = new ArrayBufferWriter<byte>();
            using var utf8JsonWriter = new Utf8JsonWriter(abw);
            example.Write(utf8JsonWriter);
            utf8JsonWriter.Flush();
            Console.WriteLine(Encoding.UTF8.GetString(abw.WrittenSpan));

            using var doc = JsonDocument.Parse(abw.WrittenMemory);
            var roundtrip = new JsonObjectExample(doc.RootElement);

            Console.WriteLine($"FirstProperty: {roundtrip.First}");
            Console.WriteLine($"SecondProperty: {roundtrip.Second}");
            Console.WriteLine($"OptionalThirdProperty: {roundtrip.Third}");

            foreach (JsonProperty<JsonString> property in roundtrip.AdditionalProperties)
            {
                Console.WriteLine($"{property.Name}: {property.Value}");
            }

            Console.WriteLine();

            JsonString defaultString = default;
            Console.WriteLine(defaultString.IsNull ? "null" : (string)defaultString);
        }
    }
}
