// <copyright file="SourceGenerator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.IO;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    /// <summary>
    /// A source generator for Menes JsonSchema-based type models.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For each JSON schema file for which you want to generate schema,
    /// include a JSON file in the csproj.
    /// </para>
    /// <code>
    /// <![CDATA[
    /// <ItemGroup>
    ///   <AdditionalFiles Include="SomeSchema.json" />
    ///   <AdditionalFiles Include="SomeSchema.json" RootNamespace="Some.Example" />
    ///   <AdditionalFiles Include="AnotherSchema.csv" RootPath="#/foo/bar/baz" RebaseToRootPath="true" />
    /// </ItemGroup>
    /// ]]>
    /// </code>
    /// <para>
    /// You can include an optional "RootPath" property which will point the generator
    /// into the JSON document and use that as the root element to generate. You can optionally rebase
    /// to that element as if it were a root document itself (the rest of the document is then "invisible" to it,
    /// except as an external reference).
    /// </para>
    /// <para>
    /// It will generate all the types found in the dependency tree for the element to which you point
    /// it. The namespace will be that of the ambient location of the JsonSchema document, unless overridden
    /// with the RootNamespace option.
    /// </para>
    /// </remarks>
    [Generator]
    public class SourceGenerator : ISourceGenerator
    {
        /// <inheritdoc/>
        public void Execute(GeneratorExecutionContext context)
        {
            ImmutableDictionary<string, (string, string)> sources = ImmutableDictionary<string, (string, string)>.Empty;

            foreach (AdditionalText additionalFile in context.AdditionalFiles)
            {
                if (Path.GetExtension(additionalFile.Path).Equals(".json", StringComparison.OrdinalIgnoreCase))
                {
                    sources = this.Merge(sources, this.HandleJsonFile(context, additionalFile, this.GetPathToGenerate(context, additionalFile), this.GetRootNamespace(context, additionalFile), this.GetRebaseToRootPath(context, additionalFile)));
                }
            }

            this.Generate(context, sources);
        }

        /// <inheritdoc/>
        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
#endif
        }

        /// <summary>
        /// Gets the path to generate in the file from the properties.
        /// </summary>
        /// <param name="context">The generator context.</param>
        /// <param name="additionalFile">The file to process.</param>
        /// <returns>The path into the file.</returns>
        private string GetPathToGenerate(GeneratorExecutionContext context, AdditionalText additionalFile)
        {
            if (context.AnalyzerConfigOptions.GetOptions(additionalFile)
                .TryGetValue("build_metadata.additionalfiles.RootPath", out string? rootPathToGenerate))
            {
                return rootPathToGenerate;
            }
            else
            {
                return string.Empty;
            }
        }

        private bool GetRebaseToRootPath(GeneratorExecutionContext context, AdditionalText additionalFile)
        {
            if (context.AnalyzerConfigOptions.GetOptions(additionalFile)
                .TryGetValue("build_metadata.additionalfiles.RebaseToRootPath", out string? rootPathToGenerate))
            {
                if (bool.TryParse(rootPathToGenerate, out bool rpg))
                {
                    return rpg;
                }
            }

            return false;
        }

        private string GetRootNamespace(GeneratorExecutionContext context, AdditionalText additionalFile)
        {
            if (context.AnalyzerConfigOptions.GetOptions(additionalFile)
                .TryGetValue("build_metadata.additionalfiles.RootNamespace", out string? rootNamepsace))
            {
                return rootNamepsace;
            }

            return context.Compilation.GlobalNamespace.Name;
        }

        private ImmutableDictionary<string, (string, string)> HandleJsonFile(GeneratorExecutionContext context, AdditionalText additionalFile, string rootPathToGenerate, string rootNamespace, bool rebaseToRootPath)
        {
            return ImmutableDictionary<string, (string, string)>.Empty;
        }

        private ImmutableDictionary<string, (string, string)> Merge(ImmutableDictionary<string, (string, string)> sources, ImmutableDictionary<string, (string, string)> added)
        {
            ImmutableDictionary<string, (string, string)>.Builder? builder = ImmutableDictionary.CreateBuilder<string, (string, string)>();
            builder.AddRange(sources);
            foreach (KeyValuePair<string, (string, string)> item in added)
            {
                if (!builder.ContainsKey(item.Key))
                {
                    builder.Add(item);
                }
            }

            return builder.ToImmutable();
        }

        private void Generate(GeneratorExecutionContext context, ImmutableDictionary<string, (string, string)> sources)
        {
            foreach (KeyValuePair<string, (string typeName, string sourceCode)> source in sources)
            {
                context.AddSource(
                    source.Key,
                    SyntaxFactory.ParseCompilationUnit(source.Value.sourceCode)
                      .NormalizeWhitespace()
                      .GetText()
                      .ToString());
            }
        }
    }
}
