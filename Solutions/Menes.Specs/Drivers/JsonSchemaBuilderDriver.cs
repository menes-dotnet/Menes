// <copyright file="JsonSchemaBuilderDriver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Drivers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Loader;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Corvus.Extensions;
    using Menes;
    using Menes.Json;
    using Menes.Json.Schema;
    using Menes.JsonSchema.TypeBuilder;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Emit;
    using Microsoft.CodeAnalysis.Text;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// A driver for specs for the <see cref="JsonSchemaBuilder"/>.
    /// </summary>
    public class JsonSchemaBuilderDriver : IDisposable
    {
        private const string NamespaceName = "Driver.GeneratedTypes";
        private readonly IConfiguration configuration;
        private readonly JsonSchemaBuilder builder;
        private readonly IDocumentResolver documentResolver = new FileSystemDocumentResolver();

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaBuilderDriver"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="builder">The <see cref="JsonSchemaBuilder"/> instance to drive.</param>
        public JsonSchemaBuilderDriver(IConfiguration configuration, JsonSchemaBuilder builder)
        {
            this.configuration = configuration;
            this.builder = builder;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.documentResolver.Dispose();
        }

        /// <summary>
        /// Get the <see cref="JsonElement"/> at the given reference location.
        /// </summary>
        /// <param name="filename">The name of the file containing the element.</param>
        /// <param name="referenceFragment">The local reference to the element in the file.</param>
        /// <returns>The element, found in the specified document.</returns>
        public Task<JsonElement?> GetElement(string filename, string referenceFragment)
        {
            string baseDirectory = this.configuration["jsonSchemaBuilderDriverSettings:testBaseDirectory"];
            string path = Path.Combine(baseDirectory, filename);
            return this.documentResolver.TryResolve(new JsonReference(path, referenceFragment));
        }

        /// <summary>
        /// Generates a type for the given root schema element.
        /// </summary>
        /// <param name="schema">The schema for which to generate the type.</param>
        /// <returns>The fully qualified type name of the entity we have generated.</returns>
        public async Task<Type> GenerateTypeFor(JsonElement schema)
        {
            // In reality, we are going to do something rather more complicated than this.
            string rootTypeName = await this.builder.BuildEntity(schema).ConfigureAwait(false);

            ImmutableDictionary<string, string> generatedTypes = this.builder.BuildTypes(NamespaceName);

            rootTypeName = $"{NamespaceName}.{rootTypeName}";
            IEnumerable<SyntaxTree> syntaxTrees = ParseSyntaxTrees(generatedTypes);

            // We are happy with the defaults (debug etc.)
            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
            IEnumerable<MetadataReference> references = BuildMetadataReferences();
            var compilation = CSharpCompilation.Create($"Drivered.GeneratedTypes_{Guid.NewGuid()}", syntaxTrees, references, options);

            using var outputStream = new MemoryStream();
            EmitResult result = compilation.Emit(outputStream);

            if (!result.Success)
            {
                throw new Exception("Unable to compile generated code\r\n" + BuildCompilationErrors(result));
            }

            outputStream.Flush();
            outputStream.Position = 0;

            Assembly generatedAssembly = AssemblyLoadContext.Default.LoadFromStream(outputStream);

            return generatedAssembly.ExportedTypes.Where(t => t.FullName == rootTypeName).Single();
        }

        /// <summary>
        /// Create an instance of the given <see cref="IJsonValue"/> type from
        /// the json data provided.
        /// </summary>
        /// <param name="type">The type (which must be a <see cref="IJsonValue"/> and have a constructor with a single <see cref="JsonElement"/> parameter.</param>
        /// <param name="data">The JSON data from which to initialize the value.</param>
        /// <returns>An instance of a <see cref="IJsonValue"/> initialized from the data.</returns>
        public IJsonValue CreateInstance(Type type, JsonElement data)
        {
            ConstructorInfo? constructor = type.GetConstructor(new[] { typeof(JsonElement) });
            if (constructor is null)
            {
                throw new InvalidOperationException($"Unable to find the public JsonElement constructor on type '{type.FullName}'");
            }

            return CastTo<IJsonValue>.From(constructor.Invoke(new object[] { data }));
        }

        private static string BuildCompilationErrors(EmitResult result)
        {
            var builder = new StringBuilder();
            foreach (Diagnostic diagnostic in result.Diagnostics)
            {
                builder.AppendLine(diagnostic.ToString());
            }

            return builder.ToString();
        }

        private static IEnumerable<MetadataReference> BuildMetadataReferences()
        {
            return new MetadataReference[]
            {
                MetadataReference.CreateFromFile(AppDomain.CurrentDomain.GetAssemblies().Single(a => a.GetName().Name == "netstandard").Location),
                MetadataReference.CreateFromFile(AppDomain.CurrentDomain.GetAssemblies().Single(a => a.GetName().Name == "System.Runtime").Location),
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(IEnumerable<>).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(JavaScriptEncoder).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Stack<>).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(JsonElement).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(CastTo<>).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ImmutableArray).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(JsonAny).Assembly.Location),
            };
        }

        private static IEnumerable<SyntaxTree> ParseSyntaxTrees(ImmutableDictionary<string, string> generatedTypes)
        {
            foreach (KeyValuePair<string, string> type in generatedTypes)
            {
                yield return CSharpSyntaxTree.ParseText(type.Value);
            }
        }
    }
}
