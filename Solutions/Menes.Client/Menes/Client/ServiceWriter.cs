// <copyright file="ServiceWriter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Client.Menes.Client
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Formatting;
    using Microsoft.CodeAnalysis.Options;
    using Microsoft.OpenApi.Models;
    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Generates code for a service from an OpenAPI document.
    /// </summary>
    internal static class ServiceWriter
    {
        private static readonly Regex MatchValidParameterName = new Regex("^[a-z]+[a-z,A-Z,0-9]*$", RegexOptions.Compiled);

        private enum Case
        {
            PascalCase,
            CamelCase,
        }

        /// <summary>
        /// Build the Compilation units for the types discovered while building the services.
        /// </summary>
        /// <param name="doc">The OpenApi document.</param>
        /// <param name="typeMap">The types we have discovered while building the services.</param>
        /// <param name="namespaceIdentifier">The namespace into which to build the types.</param>
        /// <returns>The map of type names to the compilation units for the given types.</returns>
        internal static IList<(string, CompilationUnitSyntax)> WriteTypes(OpenApiDocument doc, IList<(string, OpenApiSchema)> typeMap, string namespaceIdentifier)
        {
            var types = new List<(string, CompilationUnitSyntax)>();

            for (int i = 0; i < typeMap.Count; ++i)
            {
                (string, OpenApiSchema) type = typeMap[i];
                CompilationUnitSyntax cu = SF.CompilationUnit();
                NamespaceDeclarationSyntax ns = SF.NamespaceDeclaration(SF.IdentifierName(namespaceIdentifier));
                ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("System.Collecions.Generic")));
                ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("System.IO")));
                ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("Menes")));
                ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("NodaTime")));

                ClassDeclarationSyntax c =
                    SF.ClassDeclaration(type.Item1);
                c = c.AddModifiers(SF.Token(SyntaxKind.PublicKeyword));

                c = BuildClass(doc, typeMap, type.Item2, c);

                ns = ns.AddMembers(c);
                cu = cu.AddMembers(ns);
                types.Add((type.Item1, cu));
            }

            return types;
        }

        private static ClassDeclarationSyntax BuildClass(OpenApiDocument doc, IList<(string, OpenApiSchema)> typeMap, OpenApiSchema schema, ClassDeclarationSyntax c)
        {
            return schema switch
            {
                { Format: "application/vnd.menes.resource" } => BuildClassResource(c),
                _ => BuildClassDefault(doc, typeMap, schema, c),
            };
        }

        private static ClassDeclarationSyntax BuildClassResource(ClassDeclarationSyntax c)
        {
            return c.AddBaseListTypes(SF.SimpleBaseType(SF.ParseTypeName("IResource")));
        }

        private static ClassDeclarationSyntax BuildClassDefault(OpenApiDocument doc, IList<(string, OpenApiSchema)> typeMap, OpenApiSchema schema, ClassDeclarationSyntax c)
        {
            IEnumerable<KeyValuePair<string, OpenApiSchema>> properties = Enumerable.Empty<KeyValuePair<string, OpenApiSchema>>();

            properties = properties.Union(GetProperties(doc, schema));

            foreach (KeyValuePair<string, OpenApiSchema> property in properties)
            {
                string propertyName = BuildPascalCaseNameFor(property.Key);
                PropertyDeclarationSyntax propertyDeclaration =
                    SF.PropertyDeclaration(GetTypeSyntaxForSchema(doc, property.Value, typeMap, propertyName), propertyName)
                        .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
                        .AddAccessorListAccessors(
                            SF.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                .WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)),
                            SF.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                .WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)));
                c = c.AddMembers(propertyDeclaration);
            }

            if (schema.AdditionalPropertiesAllowed && schema.AllOf.Count == 0 && schema.AnyOf.Count == 0 && schema.OneOf.Count == 0)
            {
                PropertyDeclarationSyntax propertyDeclaration =
                    SF.PropertyDeclaration(SF.ParseTypeName("PropertyBag"), "AdditionalProperties")
                        .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
                        .AddAccessorListAccessors(
                            SF.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                .WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)),
                            SF.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                .WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)));
                c = c.AddMembers(propertyDeclaration);

                MethodDeclarationSyntax tryGetDeclaration =
                    SF.MethodDeclaration(SF.ParseTypeName("bool"), "TryGet")
                        .AddTypeParameterListParameters(SF.TypeParameter("T"))
                        .AddParameterListParameters(
                            SF.Parameter(SF.Identifier("key")).WithType(SF.ParseTypeName("string")),
                            SF.Parameter(SF.Identifier("result")).WithType(SF.ParseTypeName("T")).AddModifiers(SF.Token(SyntaxKind.OutKeyword)))
                        .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
                        .AddBodyStatements(SF.ParseStatement("throw new NotImplementedException();"));

                MethodDeclarationSyntax setDeclaration =
                    SF.MethodDeclaration(SF.ParseTypeName("void"), "Set")
                        .AddTypeParameterListParameters(SF.TypeParameter("T"))
                        .AddParameterListParameters(
                            SF.Parameter(SF.Identifier("key")).WithType(SF.ParseTypeName("string")),
                            SF.Parameter(SF.Identifier("value")).WithType(SF.ParseTypeName("T")))
                        .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
                        .AddBodyStatements(SF.ParseStatement("throw new NotImplementedException();"));

                c = c.AddMembers(tryGetDeclaration, setDeclaration);
            }

            return c;
        }

        /// <summary>
        /// Write the service defined by the given OpenApi paths to a compilation unit.
        /// </summary>
        /// <param name="doc">The OpenAPI document.</param>
        /// <param name="cu">The compilation unit to which to write the service.</param>
        /// <param name="namespaceIdentifier">The fully-qualified identifier of the namespace into which to put the generated code.</param>
        /// <param name="serviceName">The name of the service to generate.</param>
        /// <param name="typeMap">The types found in the definition.</param>
        /// <returns>The updated compilation unit syntax.</returns>
        internal static CompilationUnitSyntax WriteService(OpenApiDocument doc, CompilationUnitSyntax cu, string namespaceIdentifier, string serviceName, IList<(string, OpenApiSchema)> typeMap)
        {
            NamespaceDeclarationSyntax ns = SF.NamespaceDeclaration(SF.IdentifierName(namespaceIdentifier));

            ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("System.Collecions.Generic")));
            ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("System.IO")));
            ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("System.Threading.Tasks")));
            ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("Menes")));
            ns = ns.AddUsings(SF.UsingDirective(SF.IdentifierName("NodaTime")));

            ClassDeclarationSyntax c =
                SF.ClassDeclaration(serviceName)
                    .AddBaseListTypes(SF.SimpleBaseType(SF.ParseTypeName("IOpenApiService")));
            c = c.AddModifiers(SF.Token(SyntaxKind.PublicKeyword));
            c = c.AddModifiers(SF.Token(SyntaxKind.PartialKeyword));

            foreach (KeyValuePair<string, OpenApiPathItem> pathItem in doc.Paths)
            {
                foreach (KeyValuePair<OperationType, OpenApiOperation> operation in pathItem.Value.Operations)
                {
                    c = WriteOperation(doc, c, operation.Value.OperationId, ServiceWriter.GetNameFor(operation.Value), pathItem.Value.Parameters.Union(operation.Value.Parameters).ToList(), operation.Value.RequestBody, operation.Value.Responses, typeMap);
                }
            }

            ns = ns.AddMembers(c);
            cu = cu.AddMembers(ns);

            return cu;
        }

        /// <summary>
        /// Build the service from the compilation unit.
        /// </summary>
        /// <param name="compilationUnit">The compilation unit for which to build the service.</param>
        /// <returns>A string containing the code defining the service.</returns>
        internal static string BuildService(CompilationUnitSyntax compilationUnit)
        {
            var workspace = new AdhocWorkspace();
            OptionSet options = workspace.Options;
            SyntaxNode formattedNode = Formatter.Format(compilationUnit, workspace, options);
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                formattedNode.WriteTo(writer);
            }

            return sb.ToString();
        }

        private static IEnumerable<KeyValuePair<string, OpenApiSchema>> GetProperties(OpenApiDocument doc, OpenApiSchema schema)
        {
            if (schema.UnresolvedReference)
            {
                schema = (OpenApiSchema)doc.ResolveReference(schema.Reference);
            }

            IEnumerable<KeyValuePair<string, OpenApiSchema>> properties = Enumerable.Empty<KeyValuePair<string, OpenApiSchema>>();

            properties = properties.Union(schema.Properties);

            // TODO: Manage all of/any of "custom" property and class modification
            if (schema.AllOf != null)
            {
                properties = properties.Union(schema.AllOf.SelectMany(t => GetProperties(doc, t)));
            }

            if (schema.AnyOf != null)
            {
                properties = properties.Union(schema.AnyOf.SelectMany(t => GetProperties(doc, t)));
            }

            if (schema.OneOf != null)
            {
                properties = properties.Union(schema.OneOf.SelectMany(t => GetProperties(doc, t)));
            }

            return properties.Distinct(KeyComparer.Instance);
        }

        private static ClassDeclarationSyntax WriteOperation(OpenApiDocument doc, ClassDeclarationSyntax cd, string operationId, string operationName, IList<OpenApiParameter> parameters, OpenApiRequestBody body, OpenApiResponses responses, IList<(string, OpenApiSchema)> typeMap)
        {
            MethodDeclarationSyntax md =
                SF.MethodDeclaration(SF.ParseTypeName("Task<OpenApiResult>"), operationName)
                    .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
                    .AddBodyStatements(SF.ParseStatement("throw new NotImplementedException();"));

            AttributeListSyntax attributeList = SF.AttributeList();
            attributeList = attributeList.AddAttributes(
                SF.Attribute(SF.ParseName("OperationIdAttribute"))
                    .AddArgumentListArguments(
                        SF.AttributeArgument(
                            SF.GetStandaloneExpression(SF.ParseExpression($"\"{operationId}\"")))));

            md = md.AddAttributeLists(attributeList);

            foreach (OpenApiParameter parameter in parameters)
            {
                md = ServiceWriter.WriteParameter(doc, md, parameter, typeMap, operationName);
            }

            if (body != null)
            {
                md = AddBodyParameter(doc, body, md, typeMap, operationName);
            }

            foreach (KeyValuePair<string, OpenApiResponse> response in responses)
            {
                foreach (KeyValuePair<string, OpenApiMediaType> content in response.Value.Content)
                {
                    // Build the schema for the inlined responses, but we don't actually need to do anything with them
                    // in here.
                    _ = GetTypeSyntaxForSchema(doc, content.Value.Schema, typeMap, $"{operationName}Response");
                }
            }

            return cd.AddMembers(md);
        }

        private static MethodDeclarationSyntax AddBodyParameter(OpenApiDocument doc, OpenApiRequestBody body, MethodDeclarationSyntax md, IList<(string, OpenApiSchema)> typeMap, string contextName)
        {
            OpenApiMediaType mediaType = body.Content.Values.First();
            TypeSyntax bodyTypeSyntax = GetTypeSyntaxForSchema(doc, mediaType.Schema, typeMap, $"{contextName}Request");
            ParameterSyntax parameterSyntax = SF.Parameter(SF.Identifier("body")).WithType(bodyTypeSyntax);
            return md.AddParameterListParameters(parameterSyntax);
        }

        private static string GetNameFor(OpenApiOperation operation)
        {
            return BuildPascalCaseNameFor(operation.OperationId);
        }

        private static MethodDeclarationSyntax WriteParameter(OpenApiDocument doc, MethodDeclarationSyntax md, OpenApiParameter parameter, IList<(string, OpenApiSchema)> typeMap, string contextName)
        {
            string parameterName = BuildValidParameterName(parameter.Name);
            ParameterSyntax parameterSyntax = SF.Parameter(SF.Identifier(parameterName)).WithType(GetTypeSyntax(doc, parameter, typeMap, $"{contextName}{BuildPascalCaseNameFor(parameterName)}"));
            if (!IsValidParameterName(parameter.Name))
            {
                AttributeListSyntax attributeList = SF.AttributeList();
                attributeList = attributeList.AddAttributes(
                    SF.Attribute(SF.ParseName("OpenApiParameter"))
                        .AddArgumentListArguments(
                            SF.AttributeArgument(
                                SF.GetStandaloneExpression(SF.ParseExpression($"\"{parameter.Name}\"")))));

                parameterSyntax = parameterSyntax.AddAttributeLists(attributeList);
            }

            return md.AddParameterListParameters(parameterSyntax);
        }

        private static TypeSyntax GetTypeSyntax(OpenApiDocument doc, OpenApiParameter parameter, IList<(string, OpenApiSchema)> typeMap, string contextName)
        {
            return GetTypeSyntaxForSchema(doc, parameter.Schema, typeMap, contextName);
        }

        private static TypeSyntax GetTypeSyntaxForSchema(OpenApiDocument doc, OpenApiSchema schema, IList<(string, OpenApiSchema)> typeMap, string contextName)
        {
            return schema switch
            {
                { Type: "object" } => BuildTypeSyntaxForObjectType(doc, schema, typeMap, contextName),
                { Type: null } => BuildTypeSyntaxForObjectType(doc, schema, typeMap, contextName),
                { Type: "string", Format: "date", Nullable: true } => SF.ParseTypeName("OffsetDate?"),
                { Type: "string", Format: "date" } => SF.ParseTypeName("OffsetDate"),
                { Type: "string", Format: "date-time", Nullable: true } => SF.ParseTypeName("OffsetDateTime?"),
                { Type: "string", Format: "date-time" } => SF.ParseTypeName("OffsetDateTime"),
                { Type: "string", Format: "byte", Nullable: true } => SF.ParseTypeName("byte[]?"),
                { Type: "string", Format: "byte" } => SF.ParseTypeName("byte[]"),
                { Type: "string", Format: "binary", Nullable: true } => SF.ParseTypeName("Stream?"),
                { Type: "string", Format: "binary" } => SF.ParseTypeName("Stream[]"),
                { Type: "string", Format: "uri", Nullable: true } => SF.ParseTypeName("Uri?"),
                { Type: "string", Format: "uri" } => SF.ParseTypeName("Uri"),
                { Type: "string", Format: "uuid", Nullable: true } => SF.ParseTypeName("Guid?"),
                { Type: "string", Format: "uuid" } => SF.ParseTypeName("Guid"),
                { Type: "string", Format: "guid", Nullable: true } => SF.ParseTypeName("Guid?"),
                { Type: "string", Format: "guid" } => SF.ParseTypeName("Guid"),
                { Type: "string", Nullable: true } => SF.ParseTypeName("string?"),
                { Type: "string" } => SF.ParseTypeName("string"),
                { Type: "boolean", Nullable: true } => SF.ParseTypeName("bool?"),
                { Type: "boolean" } => SF.ParseTypeName("bool"),
                { Type: "number", Format: "float", Nullable: true } => SF.ParseTypeName("float?"),
                { Type: "number", Format: "float" } => SF.ParseTypeName("float"),
                { Type: "number", Format: "double", Nullable: true } => SF.ParseTypeName("double?"),
                { Type: "number", Format: "double" } => SF.ParseTypeName("double"),
                { Type: "number", Format: "decimal", Nullable: true } => SF.ParseTypeName("decimal?"),
                { Type: "number", Format: "decimal" } => SF.ParseTypeName("decimal"),
                { Type: "number", Nullable: true } => SF.ParseTypeName("double?"),
                { Type: "number" } => SF.ParseTypeName("double"),
                { Type: "integer", Format: "int32", Nullable: true } => SF.ParseTypeName("int?"),
                { Type: "integer", Format: "int32" } => SF.ParseTypeName("int"),
                { Type: "integer", Format: "int64", Nullable: true } => SF.ParseTypeName("long?"),
                { Type: "integer", Format: "int64" } => SF.ParseTypeName("long"),
                { Type: "integer", Nullable: true } => SF.ParseTypeName("int?"),
                { Type: "integer" } => SF.ParseTypeName("int"),
                { Type: "array" } => BuildTypeSyntaxForArrayType(doc, schema, typeMap, $"{contextName}Item"),
                _ => SF.ParseTypeName("object"),
            };
        }

        private static TypeSyntax BuildTypeSyntaxForArrayType(OpenApiDocument doc, OpenApiSchema schema, IList<(string, OpenApiSchema)> typeMap, string contextName)
        {
            GenericNameSyntax genericName = SF.GenericName("IList");
            return genericName.AddTypeArgumentListArguments(GetTypeSyntaxForSchema(doc, schema.Items, typeMap, contextName));
        }

        private static TypeSyntax BuildTypeSyntaxForObjectType(OpenApiDocument doc, OpenApiSchema schema, IList<(string, OpenApiSchema)> typeMap, string contextName)
        {
            if (schema is null)
            {
                return SF.ParseTypeName("object");
            }

            if (schema.UnresolvedReference)
            {
                schema = (OpenApiSchema)doc.ResolveReference(schema.Reference);
            }

            if (!string.IsNullOrEmpty(schema.Reference?.Id))
            {
                string typeName = BuildPascalCaseNameFor(schema.Reference!.Id);

                if (!typeMap.Any(t => t.Item1 == typeName))
                {
                    typeMap.Add((typeName, schema));
                }

                return SF.ParseTypeName(typeName);
            }

            if (!typeMap.Any(t => t.Item1 == contextName))
            {
                typeMap.Add((contextName, schema));
            }

            if (schema.AllOf != null)
            {
                // Recurse into the all-of schema.
                foreach (OpenApiSchema allOfSchema in schema.AllOf)
                {
                    _ = GetTypeSyntaxForSchema(doc, allOfSchema, typeMap, contextName);
                }
            }

            if (schema.AnyOf != null)
            {
                // Recurse into the any-of schema.
                foreach (OpenApiSchema anyOfSchema in schema.AnyOf)
                {
                    _ = GetTypeSyntaxForSchema(doc, anyOfSchema, typeMap, contextName);
                }
            }

            if (schema.OneOf != null)
            {
                // Recurse into the any-of schema.
                foreach (OpenApiSchema oneOf in schema.OneOf)
                {
                    _ = GetTypeSyntaxForSchema(doc, oneOf, typeMap, contextName);
                }
            }

            // Recurse into the properties.
            foreach (KeyValuePair<string, OpenApiSchema> property in schema.Properties)
            {
                string propertyName = BuildPascalCaseNameFor(property.Key);
                _ = GetTypeSyntaxForSchema(doc, property.Value, typeMap, propertyName);
            }

            return SF.ParseTypeName(contextName);
        }

        private static string BuildPascalCaseNameFor(string summary)
        {
            return ConvertCaseString(summary, Case.PascalCase);
        }

        private static string BuildValidParameterName(string name)
        {
            return ConvertCaseString(name, Case.CamelCase);
        }

        private static bool IsValidParameterName(string name)
        {
            return MatchValidParameterName.IsMatch(name);
        }

        private static string ConvertCaseString(string phrase, Case cases)
        {
            string[] splittedPhrase = phrase.Split(' ', '-', '.', '_');
            var sb = new StringBuilder();

            if (cases == Case.CamelCase)
            {
                sb.Append(splittedPhrase[0].ToLower());
                splittedPhrase[0] = string.Empty;
            }
            else if (cases == Case.PascalCase)
            {
                sb = new StringBuilder();
            }

            foreach (string s in splittedPhrase)
            {
                char[] splittedPhraseChars = s.ToCharArray();
                if (splittedPhraseChars.Length > 0)
                {
                    splittedPhraseChars[0] = new string(splittedPhraseChars[0], 1).ToUpper()[0];
                }

                sb.Append(new string(splittedPhraseChars));
            }

            return sb.ToString();
        }

        private class KeyComparer : IEqualityComparer<KeyValuePair<string, OpenApiSchema>>
        {
            public static KeyComparer Instance => new KeyComparer();

            public bool Equals(KeyValuePair<string, OpenApiSchema> x, KeyValuePair<string, OpenApiSchema> y)
            {
                return x.Key == y.Key;
            }

            public int GetHashCode(KeyValuePair<string, OpenApiSchema> obj)
            {
                return obj.Key.GetHashCode();
            }
        }
    }
}
