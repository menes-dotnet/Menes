// <copyright file="TypeGeneratorJsonSchemaVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchemaTypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.JsonSchema;
    using Menes.TypeGenerator;

    /// <summary>
    /// A visitor for JSON schema that allows us to generate types.
    /// </summary>
    public class TypeGeneratorJsonSchemaVisitor : SchemaVisitor
    {
        private readonly Dictionary<string, ITypeDeclaration> typeDeclarations = new Dictionary<string, ITypeDeclaration>();
        private readonly Dictionary<string, NamespaceDeclaration> namespaceDeclarations = new Dictionary<string, NamespaceDeclaration>();
        private readonly List<(ReadOnlyMemory<char> uri, ReadOnlyMemory<char> name)> uriToNamespaceMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeGeneratorJsonSchemaVisitor"/> class.
        /// </summary>
        /// <param name="documentResolver">The document resolver to use.</param>
        /// <param name="root">The root json document.</param>
        /// <param name="uriToNamespaceMap">A map of uri stems to typenames.</param>
        public TypeGeneratorJsonSchemaVisitor(IDocumentResolver documentResolver, JsonDocument root, params (string, string)[] uriToNamespaceMap)
            : base(documentResolver, root)
        {
            this.uriToNamespaceMap = uriToNamespaceMap.Select(k => (k.Item1.AsMemory(), k.Item2.AsMemory())).ToList();
        }

        /// <inheritdoc/>
        public override ValueTask<(bool, Schema?)> VisitSchema(Schema? schemaToVisit)
        {
            if (!(schemaToVisit is Schema schema))
            {
                throw new ArgumentNullException(nameof(schemaToVisit));
            }

            string childName = this.GetFullyQualifiedTypeName(schema);

            IDeclaration parentDeclaration = this.GetParentDeclaration(childName);

            if (!this.typeDeclarations.ContainsKey(parentDeclaration.GetFullyQualifiedName(childName)))
            {
                return this.AddTypeDeclaration(schema, childName, parentDeclaration);
            }
            else
            {
                return base.VisitSchema(schema);
            }
        }

        private ValueTask<(bool, Schema?)> AddTypeDeclaration(Schema schema, string name, IDeclaration parent)
        {
            if (schema.Type is Schema.TypeEnum type)
            {
                return
                    (string)type switch
                    {
                        "integer" => this.BuildInteger(name, schema, parent),
                        "object" => this.BuildObject(name, schema, parent),
                        "boolean" => this.BuildBoolean(name, schema, parent),
                        "number" => this.BuildNumber(name, schema, parent),
                        "string" => this.BuildString(name, schema, parent),
                        "null" => this.BuildNull(name, schema, parent),
                        "array" => this.BuildArray(name, schema, parent),
                        _ => this.BuildAny(name, schema, parent)
                    };
            }

            return this.BuildAny(name, schema, parent);
        }

        private void AddToParent(ITypeDeclaration? result, IDeclaration parentDeclaration)
        {
            if (!(result is ITypeDeclaration child))
            {
                return;
            }

            if (parentDeclaration is NamespaceDeclaration ns)
            {
                ns.AddDeclaration(child);
            }

            if (parentDeclaration is ITypeDeclaration td)
            {
                td.AddTypeDeclaration(child);
            }
        }

        private IDeclaration GetParentDeclaration(string fullyQualifiedChildName)
        {
            string parentName = fullyQualifiedChildName.Substring(0, fullyQualifiedChildName.LastIndexOf('.'));
            if (this.typeDeclarations.TryGetValue(parentName, out ITypeDeclaration typeDeclaration))
            {
                return typeDeclaration;
            }

            if (this.namespaceDeclarations.TryGetValue(parentName, out NamespaceDeclaration namespaceDeclaration))
            {
                return namespaceDeclaration;
            }

            return this.CreateNamespaceDeclaration(parentName);
        }

        private NamespaceDeclaration CreateNamespaceDeclaration(string fullyQualifiedNamespace)
        {
            string[] segments = fullyQualifiedNamespace.Split('.', StringSplitOptions.RemoveEmptyEntries);

            NamespaceDeclaration? currentNamespace = null;

            if (segments.Length == 0)
            {
                throw new ArgumentException("The fully qualified namespace may not be empty.");
            }

            foreach (string segment in segments)
            {
                if (this.namespaceDeclarations.TryGetValue(fullyQualifiedNamespace, out NamespaceDeclaration namespaceDeclaration))
                {
                    currentNamespace = namespaceDeclaration;
                }
                else
                {
                    var newNamespace = new NamespaceDeclaration(segment);
                    if (currentNamespace is NamespaceDeclaration current)
                    {
                        current.AddDeclaration(newNamespace);
                    }

                    currentNamespace = newNamespace;
                    this.namespaceDeclarations.Add(currentNamespace.GetFullyQualifiedName(), currentNamespace);
                }
            }

            return currentNamespace ?? throw new InvalidOperationException($"Unable to create a namespace for {fullyQualifiedNamespace}");
        }

        private ValueTask<(bool, Schema?)> BuildObject(string name, Schema schemam, IDeclaration parent)
        {
            throw new NotImplementedException();
        }

        private ValueTask<(bool, Schema?)> BuildBoolean(string name, Schema schema, IDeclaration parent)
        {
            throw new NotImplementedException();
        }

        private ValueTask<(bool, Schema?)> BuildNumber(string name, Schema schema, IDeclaration parent)
        {
            throw new NotImplementedException();
        }

        private ValueTask<(bool, Schema?)> BuildString(string name, Schema schema, IDeclaration parent)
        {
            throw new NotImplementedException();
        }

        private ValueTask<(bool, Schema?)> BuildNull(string name, Schema schema, IDeclaration parent)
        {
            throw new NotImplementedException();
        }

        private ValueTask<(bool, Schema?)> BuildArray(string name, Schema schema, IDeclaration parent)
        {
            throw new NotImplementedException();
        }

        private ValueTask<(bool, Schema?)> BuildAny(string name, Schema schema, IDeclaration parent)
        {
            throw new NotImplementedException();
        }

        private async ValueTask<(bool, Schema?)> BuildInteger(string name, Schema schema, IDeclaration parent)
        {
            ITypeDeclaration typeDeclaration;
            bool isValidated = schema.IsValidated();

            if (schema.Format is JsonString format)
            {
                typeDeclaration = (string)format switch
                {
                    "int32" => isValidated ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Int32) : JsonValueTypeDeclaration.Int32,
                    "int64" => isValidated ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Int64) : JsonValueTypeDeclaration.Int64,
                    _ => throw new InvalidOperationException()
                };
            }
            else
            {
                typeDeclaration = isValidated ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Integer) : JsonValueTypeDeclaration.Integer;
            }

            // Add the child to the parent.
            this.AddToParent(typeDeclaration, parent);

            // Carry on down into the children to build them.
            (bool, Schema?) result = await base.VisitSchema(schema).ConfigureAwait(false);

            if (typeDeclaration is ValidatedJsonValueTypeDeclaration val)
            {
                // Having generated the children, we can now apply it to the parent.
                this.BuildValidations(schema, val);
            }

            return result;
        }

        private string GetFullyQualifiedTypeName(Schema schema)
        {
            if (!(schema.Id is JsonString id))
            {
                throw new InvalidOperationException("Unable to build a type name for a schema without a $id.");
            }

            var jsonRef = new JsonRef(id);
            var result = new StringBuilder();
            if (jsonRef.HasUri)
            {
                this.GetFullyQualifiedNameFromUri(jsonRef.Uri, result);
            }

            if (jsonRef.HasPointer)
            {
                if (result.Length > 0)
                {
                    result.Append(".");
                }

                this.GetFullyQualifiedNameFromPointer(jsonRef.Pointer, result);
            }

            return result.ToString();
        }

        private void GetFullyQualifiedNameFromPointer(in ReadOnlySpan<char> pointer, StringBuilder builder)
        {
            StringFormatter.FormatFragmentAsFullyQualifiedName(pointer, builder);
        }

        private void GetFullyQualifiedNameFromUri(in ReadOnlySpan<char> uri, StringBuilder builder)
        {
            if (!this.FormatWithKnownUris(uri, builder))
            {
                StringFormatter.FormatUriAsFullyQualifiedName(uri, builder);
            }
        }

        private bool FormatWithKnownUris(ReadOnlySpan<char> uri, StringBuilder builder)
        {
            foreach ((ReadOnlyMemory<char> key, ReadOnlyMemory<char> value) in this.uriToNamespaceMap)
            {
                if (uri.StartsWith(key.Span))
                {
                    builder.Append(value);
                    if (key.Length < uri.Length)
                    {
                        StringFormatter.FormatFragmentAsFullyQualifiedName(uri.Slice(key.Length), builder);
                        return true;
                    }
                }
            }

            return false;
        }

        private void BuildValidations(Schema schema, ValidatedJsonValueTypeDeclaration validatedJsonValueTypeDeclaration)
        {
            validatedJsonValueTypeDeclaration.ConstValidation = schema.Const.ToString();
            validatedJsonValueTypeDeclaration.EnumValidation = schema.Enum.ToString();
            validatedJsonValueTypeDeclaration.ExclusiveMaximumValidation = schema.ExclusiveMaximum;
            validatedJsonValueTypeDeclaration.ExclusiveMinimumValidation = schema.ExclusiveMinimum;
            validatedJsonValueTypeDeclaration.MaximumValidation = schema.Maximum;
            validatedJsonValueTypeDeclaration.MaxLengthValidation = schema.MaxLength;
            validatedJsonValueTypeDeclaration.MinimumValidation = schema.Minimum;
            validatedJsonValueTypeDeclaration.MinLengthValidation = schema.MinLength;
            validatedJsonValueTypeDeclaration.MultipleOfValidation = schema.MultipleOf;
            validatedJsonValueTypeDeclaration.NotTypeValidation = this.GetTypeDeclarationFor(schema.Not);
        }

        private ITypeDeclaration GetTypeDeclarationFor(Schema.SchemaOrReference? schemaOrReference)
        {
            if (!(schemaOrReference is Schema.SchemaOrReference sor) || !sor.IsSchema)
            {
                throw new InvalidOperationException("You must have correctly resolved references prior to calling GetTypeDeclarationFor(Schema.SchemOrReference?)");
            }

            Schema schema = sor.AsSchema();
            return this.typeDeclarations[this.GetFullyQualifiedTypeName(schema)];
        }
    }
}