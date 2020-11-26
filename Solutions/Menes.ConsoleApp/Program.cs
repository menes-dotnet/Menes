﻿// <copyright file="Program.cs" company="Endjin Limited">
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
    using Menes.Json.Schema;
    using Menes.JsonSchema.TypeBuilder;
    using NodaTime;
    using TestSpace;

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
            ////var test = new Test(default(Test));
            ////var schema = new Draft201909Schema(type: JsonArray.From("string", "array"));

            ////if (schema.Type!.Value!.Validate().Valid)
            ////{
            ////    Console.WriteLine("Hooray!");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("Boo!");
            ////}

            ////if (schema.Validate().Valid)
            ////{
            ////    Console.WriteLine("Hooray!");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("Boo!");
            ////}

            ////if (schema.Type is Draft201909MetaValidation.TypeEntity type)
            ////{
            ////    foreach (string item in type.AsAnyOf1Array())
            ////    {
            ////        Console.WriteLine(item);
            ////    }
            ////}

            ////schema = schema.WithTitle("Hello dolly!");

            ////string serializedSchema = Serialize(schema);

            ////using var doc = JsonDocument.Parse(serializedSchema);
            ////var deserializedSchema = new Draft201909Schema(doc.RootElement);

            ////if (deserializedSchema.Validate().Valid)
            ////{
            ////    Console.WriteLine("Hooray!");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("Boo!");
            ////}

            ////if (deserializedSchema.Type is Draft201909MetaValidation.TypeEntity type2)
            ////{
            ////    foreach (string item in type2.AsAnyOf1Array())
            ////    {
            ////        Console.WriteLine(item);
            ////    }
            ////}

            ////var tree =
            ////    new Tree(
            ////        "Root",
            ////        JsonArray.From(
            ////            new Tree.NodeEntity(
            ////                3,
            ////                new Tree(
            ////                    "Subtree 1",
            ////                    JsonArray.From(
            ////                        new Tree.NodeEntity(4),
            ////                        new Tree.NodeEntity(5)))),
            ////            new Tree.NodeEntity(
            ////                6,
            ////                new Tree(
            ////                    "Subtree 2",
            ////                    JsonArray.From(
            ////                        new Tree.NodeEntity(7),
            ////                        new Tree.NodeEntity(8))))));

            ////Serialize(tree);

            ////tree = tree.WithNodes(
            ////    tree.Nodes
            ////        .Add(new Tree.NodeEntity(999), new Tree.NodeEntity(1000))
            ////        .Insert(0, new Tree.NodeEntity(42), new Tree.NodeEntity(54), new Tree.NodeEntity(33.333))
            ////        .Insert(3, new Tree.NodeEntity(6), new Tree.NodeEntity(7), new Tree.NodeEntity(8), new Tree.NodeEntity(9), new Tree.NodeEntity(10))
            ////        .RemoveIf(n => n.Value < 5));

            ////tree = tree.SetProperty("meta", "Hello");
            ////tree = tree.SetProperty("foo", "Bar");
            ////tree = tree.SetProperty("frob", "Bob");
            ////tree = tree.SetProperty("numbery", 33);
            ////tree = tree.SetProperty("veryNumbery", 99.9);
            ////tree = tree.SetProperty("dateIsh", DateTimeOffset.Now);
            ////tree = tree.RemoveProperty("frob");

            ////Serialize(tree);

            ////foreach (Property<Tree> property in tree)
            ////{
            ////    if (property.NameEquals("meta"))
            ////    {
            ////        Console.WriteLine($"{property.Name}: {property.Value<JsonString>()}");
            ////    }

            ////    if (property.NameEquals("nodes"))
            ////    {
            ////        Console.WriteLine($"{property.Name}:");
            ////        foreach (Tree.NodeEntity node in property.Value<Tree.NodesArray>())
            ////        {
            ////            if (node.TryGetProperty("value", out JsonNumber nodeVal))
            ////            {
            ////                Console.WriteLine($"\t{nodeVal}");
            ////            }
            ////        }
            ////    }
            ////}

            ////// Now do the same but through a JsonAny. This will cause boxing through the interfaces.
            ////JsonAny treeAny = tree.As<JsonAny>();
            ////foreach (IProperty property in treeAny.EnumerateObject())
            ////{
            ////    if (property.NameEquals("meta"))
            ////    {
            ////        Console.WriteLine($"{property.Name}: {property.Value<JsonString>()}");
            ////    }

            ////    if (property.NameEquals("nodes"))
            ////    {
            ////        Console.WriteLine($"{property.Name}:");
            ////        foreach (JsonAny node in property.Value<JsonAny>().EnumerateArray())
            ////        {
            ////            if (node.TryGetProperty("value", out JsonNumber nodeVal))
            ////            {
            ////                Console.WriteLine($"\t{nodeVal}");
            ////            }
            ////        }
            ////    }
            ////}
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
