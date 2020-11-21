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
    using Menes.Json.Schema;
    using Menes.JsonSchema.TypeBuilder;
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
            var test = new Test(default(Test));
            var schema = new Draft201909Schema(type: JsonArray.From("string", "array"));

            if (schema.Type!.Value!.Validate().Valid)
            {
                Console.WriteLine("Hooray!");
            }
            else
            {
                Console.WriteLine("Boo!");
            }

            if (schema.Validate().Valid)
            {
                Console.WriteLine("Hooray!");
            }
            else
            {
                Console.WriteLine("Boo!");
            }

            if (schema.Type is Draft201909MetaValidation.TypeEntity type)
            {
                foreach (string item in type.AsAnyOf1Array())
                {
                    Console.WriteLine(item);
                }
            }

            schema = schema.WithTitle("Hello dolly!");

            string serializedSchema = Serialize(schema);

            using var doc = JsonDocument.Parse(serializedSchema);
            var deserializedSchema = new Draft201909Schema(doc.RootElement);

            if (deserializedSchema.Validate().Valid)
            {
                Console.WriteLine("Hooray!");
            }
            else
            {
                Console.WriteLine("Boo!");
            }

            if (deserializedSchema.Type is Draft201909MetaValidation.TypeEntity type2)
            {
                foreach (string item in type2.AsAnyOf1Array())
                {
                    Console.WriteLine(item);
                }
            }

            var tree =
                new Tree(
                    "Root",
                    JsonArray.From(
                        new Tree.NodeEntity(
                            3,
                            new Tree(
                                "Subtree 1",
                                JsonArray.From(
                                    new Tree.NodeEntity(4),
                                    new Tree.NodeEntity(5)))),
                        new Tree.NodeEntity(
                            6,
                            new Tree(
                                "Subtree 2",
                                JsonArray.From(
                                    new Tree.NodeEntity(7),
                                    new Tree.NodeEntity(8))))));

            Serialize(tree);

            tree = tree.WithNodes(
                tree.Nodes
                    .Add(new Tree.NodeEntity(999), new Tree.NodeEntity(1000))
                    .Insert(0, new Tree.NodeEntity(42), new Tree.NodeEntity(54), new Tree.NodeEntity(33.333))
                    .Insert(3, new Tree.NodeEntity(6), new Tree.NodeEntity(7), new Tree.NodeEntity(8), new Tree.NodeEntity(9), new Tree.NodeEntity(10))
                    .RemoveIf(n => n.Value < 5));

            tree = tree.SetProperty("meta", (JsonString)"Hello");
            tree = tree.SetProperty("foo", (JsonString)"Bar");
            tree = tree.SetProperty("frob", (JsonString)"Bob");
            tree = tree.RemoveProperty("frob");

            Serialize(tree);

            foreach (Property<Tree> property in tree)
            {
                if (property.NameEquals("meta"))
                {
                    Console.WriteLine($"{property.Name}: {property.Value<JsonString>()}");
                }

                if (property.NameEquals("nodes"))
                {
                    Console.WriteLine($"{property.Name}:");
                    foreach (Tree.NodeEntity node in property.Value<Tree.NodesArray>())
                    {
                        if (node.TryGetProperty("value", out JsonNumber nodeVal))
                        {
                            Console.WriteLine($"\t{nodeVal}");
                        }
                    }
                }
            }
        }

        private static async Task BuildJsonObjectType()
        {
            var builder = new JsonSchemaBuilder(new FileSystemDocumentResolver());
            string schema = "{ \"id\": \"https://endjin.com/menes/schema/JsonObject\", \"type\": \"object\" }";
            using var doc = JsonDocument.Parse(schema);
            await builder.BuildEntity(doc.RootElement).ConfigureAwait(false);
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

        /// <summary>
        /// A test <see cref="IJsonValue"/>.
        /// </summary>
        public readonly struct Test : IJsonValue
        {
            private readonly JsonValueBacking child;
#pragma warning disable SA1309 // Field names should not begin with underscore
            private readonly JsonElement _menesBackingElement;
#pragma warning restore SA1309 // Field names should not begin with underscore

            /// <summary>
            /// Initializes a new instance of the <see cref="Test"/> struct.
            /// </summary>
            /// <param name="child">The optional child.</param>
            public Test(Test? child = null)
            {
                this.child = JsonValueBacking.From(child);
                this._menesBackingElement = default;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Test"/> struct.
            /// </summary>
            /// <param name="jsonElement">The <see cref="JsonElement"/> backing this instance.</param>
            public Test(JsonElement jsonElement)
            {
                this.child = default;
                this._menesBackingElement = jsonElement;
            }

            /// <summary>
            /// Gets the child value.
            /// </summary>
            public Test? Child => this.child.As<Test>();

            /// <inheritdoc/>
            public bool IsUndefined => this.JsonElement.ValueKind == JsonValueKind.Undefined && this.AllBackingFieldsAreNull();

            /// <inheritdoc/>
            public bool IsNull => (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null) && this.AllBackingFieldsAreNull();

            /// <inheritdoc />
            public bool IsNumber => false;

            /// <inheritdoc />
            public bool IsInteger => false;

            /// <inheritdoc />
            public bool IsString => false;

            /// <inheritdoc />
            public bool IsObject => true;

            /// <inheritdoc />
            public bool IsBoolean => false;

            /// <inheritdoc />
            public bool IsArray => false;

            /// <inheritdoc/>
            public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

            /// <inheritdoc/>
            public JsonElement JsonElement => this._menesBackingElement;

            /// <inheritdoc/>
            public T As<T>()
                where T : struct, Menes.IJsonValue
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            public ValidationResult Validate(ValidationResult? validationContext = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            public void WriteTo(Utf8JsonWriter writer)
            {
                throw new NotImplementedException();
            }

            private bool AllBackingFieldsAreNull()
            {
                if (this.child.IsNull)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
