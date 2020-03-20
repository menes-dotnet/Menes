// <copyright file="ServiceCompiler.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Formatting;
    using Microsoft.CodeAnalysis.Options;
    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Compiles the service types into appropriate compilation units.
    /// </summary>
    /// <remarks>
    /// This is a useful for testing at the moment.
    /// </remarks>
    public class ServiceCompiler
    {
        /// <summary>
        /// Compiles the service types to their text representations.
        /// </summary>
        /// <param name="serviceName">The name of the service.</param>
        /// <param name="serviceNamespaceIdentifier">The namespace for the service itself.</param>
        /// <param name="typesNamespaceIdentifier">The namespace for the supporting types.</param>
        /// <param name="types">The types themselves.</param>
        /// <returns>A map of the type names to their compiled code.</returns>
        public IDictionary<string, string> CompileService(string serviceName, string serviceNamespaceIdentifier, string typesNamespaceIdentifier, IDictionary<string, TypeDeclarationSyntax> types)
        {
            var results = new Dictionary<string, string>();

            var workspace = new AdhocWorkspace();
            OptionSet options = workspace.Options;

            foreach (KeyValuePair<string, TypeDeclarationSyntax> typeInfo in types)
            {
                CompilationUnitSyntax compilationUnit = SF.CompilationUnit();

                bool typeIsOpenApiService = serviceName == typeInfo.Key;
                NamespaceDeclarationSyntax ns = SF.NamespaceDeclaration(SF.IdentifierName(typeIsOpenApiService ? serviceNamespaceIdentifier : typesNamespaceIdentifier));

                ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("System.Collecions.Generic")));
                ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("System.IO")));
                ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("System.Threading.Tasks")));
                ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("Menes")));
                ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("NodaTime")));

                if (typeIsOpenApiService && serviceNamespaceIdentifier != typesNamespaceIdentifier)
                {
                    ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName(typesNamespaceIdentifier)));
                }

                ns = ns.AddMembers(typeInfo.Value);

                compilationUnit = compilationUnit.AddMembers(ns);

                SyntaxNode formattedNode = Formatter.Format(compilationUnit, workspace, options);
                var sb = new StringBuilder();
                using (var writer = new StringWriter(sb))
                {
                    formattedNode.WriteTo(writer);
                }

                results.Add(typeInfo.Key, sb.ToString());
            }

            return results;
        }
    }
}
