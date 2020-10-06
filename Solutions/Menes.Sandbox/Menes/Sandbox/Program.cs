// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Sandbox
{
    using System;
    using System.Buffers;
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

            Console.WriteLine(myValue);

            myValue = "Greetings";

            Console.WriteLine(myValue + " world!");

            var example = new JsonObjectExample(
                first: "Hello",
                second: 42,
                third: Duration.FromHours(3),
                children: new[] { new JsonObjectExample("Child", 1), new JsonObjectExample("Child", 2) },
                ("foo", "Here's a foo"),
                ("bar", "Here's a bar"));

            //// At this point we have an object whose values are all CLR types.
            //// THe children are boxed into the array as JsonReference objects.

            ReadOnlyMemory<byte> serialized = Serialize(example);

            using var doc = JsonDocument.Parse(serialized);
            var roundtrip = new JsonObjectExample(doc.RootElement);

            //// At this point "roundtrip" is a JsonObjectExample backed by a single JsonElement.

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
        }

        private static ReadOnlyMemory<byte> Serialize(in JsonObjectExample example)
        {
            var abw = new ArrayBufferWriter<byte>();
            using var utf8JsonWriter = new Utf8JsonWriter(abw);
            example.WriteTo(utf8JsonWriter);
            utf8JsonWriter.Flush();
            Console.WriteLine(Encoding.UTF8.GetString(abw.WrittenSpan));
            return abw.WrittenMemory;
        }

        private static void WriteExample(in JsonObjectExample example)
        {
            Console.WriteLine($"FirstProperty: {example.First}");
            Console.WriteLine($"SecondProperty: {example.Second}");
            Console.WriteLine($"OptionalThirdProperty: {example.Third}");

            foreach (JsonPropertyReference property in example.AdditionalProperties)
            {
                Console.WriteLine($"{property.Name}: {property.AsValue<JsonString>()}");
            }
        }
    }
}
