// <copyright file="TypeGeneratorJsonSchemaVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.TypeGenerator;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// A visitor for JSON schema that allows us to generate types.
    /// </summary>
    public class TypeGeneratorJsonSchemaVisitor
    {
        // Type declarations keyed by the form of the declaration.
        private readonly Dictionary<string, ITypeDeclaration> typeDeclarations = new Dictionary<string, ITypeDeclaration>();
        private readonly Stack<ITypeDeclaration> declarationStack = new Stack<ITypeDeclaration>();
        private readonly Stack<string> propertyNameStack = new Stack<string>();
        private readonly IDocumentResolver documentResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeGeneratorJsonSchemaVisitor"/> class.
        /// </summary>
        /// <param name="documentResolver">The document resolver.</param>
        public TypeGeneratorJsonSchemaVisitor(IDocumentResolver documentResolver)
        {
            this.documentResolver = documentResolver;
        }

        /// <summary>
        /// Generate the types we have found.
        /// </summary>
        /// <returns>The Type declaration syntax for the types we have found.</returns>
        public TypeDeclarationSyntax[] GenerateTypes()
        {
            return this.typeDeclarations.Values.Where(t => t.Parent is null).Select(t => t.GenerateType()).ToArray();
        }

        /// <summary>
        /// Build the types for a given schema.
        /// </summary>
        /// <param name="schema">The schema for which to build the type.</param>
        /// <param name="rootDocument">The root document containing the schema.</param>
        /// <param name="baseUri">The base URI for the document.</param>
        /// <returns>A task which completes when the types are built for the given schema.</returns>
        public async Task BuildTypes(JsonSchema schema, JsonDocument rootDocument, string baseUri)
        {
            await this.BuildTypeCore(schema, rootDocument, baseUri).ConfigureAwait(false);
        }

        private async Task<ITypeDeclaration> BuildTypeCore(JsonSchema schema, JsonDocument rootDocument, string baseUri)
        {
            ITypeDeclaration declaration = await this.CreateTypeDeclarationFor(schema).ConfigureAwait(false);

            if (declaration.ShouldGenerate)
            {
                if (schema.Id is JsonString || this.declarationStack.Count == 0)
                {
                    this.typeDeclarations.Add(declaration.Name, declaration);
                }
                else
                {
                    this.declarationStack.Peek().AddTypeDeclaration(declaration);
                }

                this.declarationStack.Push(declaration);
                this.propertyNameStack.Push(declaration.Name);
                await this.PopulateTypeDeclarationFor(declaration, schema, rootDocument, baseUri).ConfigureAwait(false);
                this.propertyNameStack.Pop();
                this.declarationStack.Pop();
            }

            return declaration;
        }

        private Task<ITypeDeclaration> CreateTypeDeclarationFor(JsonSchema schema)
        {
            string name = this.GetName(schema);

            if (schema.Type is JsonSchema.TypeEnum type)
            {
                return (string)type switch
                {
                    "integer" => this.CreateInteger(schema, name),
                    "object" => this.CreateObject(schema, name),
                    "boolean" => this.CreateBoolean(schema, name),
                    "number" => this.CreateNumber(schema, name),
                    "string" => this.CreateString(schema, name),
                    "array" => this.CreateArray(schema, name),
                    _ => this.CreateAny(schema, name),
                };
            }

            return this.CreateAny(schema, name);
        }

        private Task PopulateTypeDeclarationFor(ITypeDeclaration typeDeclaration, JsonSchema schema, JsonDocument rootDocument, string baseUri)
        {
            if (schema.Type is JsonSchema.TypeEnum type)
            {
                return (string)type switch
                {
                    "integer" => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                    "object" => this.PopulateObject(typeDeclaration, schema, rootDocument, baseUri),
                    "boolean" => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                    "number" => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                    "string" => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                    "array" => this.PopulateArray(typeDeclaration, schema, rootDocument, baseUri),
                    _ => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                };
            }

            return this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri);
        }

        private async Task<ITypeDeclaration?> GetAdditionalPropertiesType(JsonSchema schema, JsonDocument rootDocument, string baseUri)
        {
            ITypeDeclaration? additionalPropertiesType = AnyTypeDeclaration.Instance;

            if (schema.AdditionalProperties is JsonSchema.SchemaAdditionalProperties additionalProperties)
            {
                if (additionalProperties.IsJsonBoolean)
                {
                    if (!additionalProperties.AsJsonBoolean())
                    {
                        additionalPropertiesType = null;
                    }
                }
                else
                {
                    this.propertyNameStack.Push("Properties");

                    additionalPropertiesType = await this.GetTypeDeclarationFor(additionalProperties.AsSchemaOrReference(), rootDocument, baseUri).ConfigureAwait(false);

                    this.propertyNameStack.Pop();
                }
            }

            return additionalPropertiesType;
        }

        private async Task<(string, JsonDocument, JsonSchema)?> GetSchemaFor(JsonSchema.SchemaOrReference? schemaOrReference, JsonDocument rootDocument, string baseUri)
        {
            if (!(schemaOrReference is JsonSchema.SchemaOrReference sor))
            {
                return null;
            }

            if (sor.IsSchemaReference)
            {
                (baseUri, rootDocument, sor) = await sor.Resolve(baseUri, rootDocument, this.documentResolver).ConfigureAwait(false);
            }

            return (baseUri, rootDocument, sor.AsJsonSchema());
        }

        private async Task<ITypeDeclaration?> GetTypeDeclarationFor(JsonSchema.SchemaOrReference? schemaOrReference, JsonDocument rootDocument, string baseUri)
        {
            if (!(schemaOrReference is JsonSchema.SchemaOrReference sor))
            {
                return null;
            }

            string uri = baseUri;
            JsonDocument document = rootDocument;
            JsonSchema.SchemaOrReference reference = sor;

            if (sor.IsSchemaReference)
            {
                (uri, document, reference) = await sor.Resolve(baseUri, rootDocument, this.documentResolver).ConfigureAwait(false);
            }

            JsonSchema schema = reference.AsJsonSchema();

            string name = this.GetName(schema);
            if (this.typeDeclarations.TryGetValue(name, out ITypeDeclaration result))
            {
                return result;
            }

            if (schema.Id is null && this.declarationStack.Peek().ContainsTypeDeclaration(name))
            {
                ITypeDeclaration td = this.declarationStack.Peek().GetTypeDeclaration(name);
                await this.PopulateTypeDeclarationFor(td, schema, document, uri).ConfigureAwait(false);
                return td;
            }

            return await this.BuildTypeCore(schema, document, uri).ConfigureAwait(false);
        }

        private Task PopulateJsonValue(ITypeDeclaration type, JsonSchema schema, JsonDocument rootDocument, string baseUri)
        {
            if (type is ValidatedJsonValueTypeDeclaration typeDeclaration)
            {
                return this.BuildValidations(schema, typeDeclaration, rootDocument, baseUri);
            }

            return Task.CompletedTask;
        }

        private Task<ITypeDeclaration> CreateObject(JsonSchema schema, string name)
        {
            int booleanSubschemaCount = 0;
            if (schema.OneOf is JsonSchema.ValidatedArrayOfSchemaOrReference)
            {
                booleanSubschemaCount += 1;
            }

            if (schema.AnyOf is JsonSchema.ValidatedArrayOfSchemaOrReference)
            {
                booleanSubschemaCount += 1;
            }

            if (schema.AllOf is JsonSchema.ValidatedArrayOfSchemaOrReference)
            {
                booleanSubschemaCount += 1;
            }

            // We have to use the "any" type approach
            if (booleanSubschemaCount > 1)
            {
                return this.CreateAny(schema, name);
            }

            if (schema.OneOf is JsonSchema.ValidatedArrayOfSchemaOrReference || schema.AnyOf is JsonSchema.ValidatedArrayOfSchemaOrReference)
            {
                return Task.FromResult<ITypeDeclaration>(new UnionTypeDeclaration(name));
            }

            return Task.FromResult<ITypeDeclaration>(new ObjectTypeDeclaration(name));
        }

        private async Task PopulateObject(ITypeDeclaration type, JsonSchema schema, JsonDocument rootDocument, string baseUri)
        {
            if (type is UnionTypeDeclaration union)
            {
                await this.PopulateUnion(union, schema, rootDocument, baseUri).ConfigureAwait(false);
                return;
            }

            if (!(type is ObjectTypeDeclaration typeDeclaration))
            {
                throw new InvalidOperationException($"Expected an {typeof(ObjectTypeDeclaration).FullName} or a {typeof(UnionTypeDeclaration).FullName} but found a {type.GetType().FullName}.");
            }

            if (schema.AllOf is JsonSchema.ValidatedArrayOfSchemaOrReference allOf)
            {
                List<(string, JsonDocument, JsonSchema)>? allOfSchemas = await this.GetSchemasFor(allOf, rootDocument, baseUri).ConfigureAwait(false);

                if (allOfSchemas is List<(string, JsonDocument, JsonSchema)> aoses)
                {
                    foreach ((string uri, JsonDocument doc, JsonSchema aos) in aoses)
                    {
                        ITypeDeclaration? aotd = await this.GetTypeDeclarationFor(aos, doc, uri).ConfigureAwait(false);

                        if (aos.IsObjectType())
                        {
                            await this.PopulateObject(typeDeclaration, aos, doc, uri).ConfigureAwait(false);
                        }

                        if (!(aotd is ITypeDeclaration a))
                        {
                            throw new InvalidOperationException($"Unable to find a type declartion for {aos}");
                        }

                        typeDeclaration.AddAllOfType(a);
                    }
                }
            }

            typeDeclaration.AdditionalPropertiesType = await this.GetAdditionalPropertiesType(schema, rootDocument, baseUri).ConfigureAwait(false);

            if (schema.Properties is JsonSchema.SchemaProperties properties)
            {
                var requiredProperties = new List<string>();

                if (schema.Required is JsonSchema.ValidatedArrayOfJsonString required)
                {
                    requiredProperties.AddRange(required.Select(s => s.CreateOrGetClrString()));
                }

                foreach (JsonPropertyReference<JsonSchema.SchemaOrReference> property in properties.JsonAdditionalProperties)
                {
                    this.propertyNameStack.Push(property.Name);

                    ITypeDeclaration? childType = await this.GetTypeDeclarationFor(property.AsValue(), rootDocument, baseUri).ConfigureAwait(false);

                    if (!(childType is ITypeDeclaration ct))
                    {
                        throw new InvalidOperationException($"Unable to find the type for {property.Name}");
                    }

                    if (!requiredProperties.Contains(property.Name))
                    {
                        typeDeclaration.AddPropertyDeclaration(property.Name, ct.AsOptional());
                    }
                    else
                    {
                        typeDeclaration.AddPropertyDeclaration(property.Name, ct);
                    }

                    this.propertyNameStack.Pop();
                }
            }
        }

        private async Task PopulateUnion(UnionTypeDeclaration union, JsonSchema schema, JsonDocument rootDocument, string baseUri)
        {
            List<ITypeDeclaration>? anyOfTypes = await this.GetTypeDeclarationsFor(schema.AnyOf, rootDocument, baseUri).ConfigureAwait(false);
            if (anyOfTypes is List<ITypeDeclaration> any)
            {
                union.AddTypesToUnion(any.ToArray());
                return;
            }

            List<ITypeDeclaration>? oneOfTypes = await this.GetTypeDeclarationsFor(schema.OneOf, rootDocument, baseUri).ConfigureAwait(false);
            if (oneOfTypes is List<ITypeDeclaration> one)
            {
                union.AddTypesToUnion(one.ToArray());
                return;
            }
        }

        private Task<ITypeDeclaration> CreateBoolean(JsonSchema schema, string name)
        {
            return Task.FromResult(
                schema.IsValidated()
                ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Boolean)
                : (ITypeDeclaration)JsonValueTypeDeclaration.Boolean);
        }

        private Task<ITypeDeclaration> CreateNumber(JsonSchema schema, string name)
        {
            if (schema.Format is JsonString format)
            {
                return Task.FromResult(
                    (string)format switch
                    {
                        "int32" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Int32) : (ITypeDeclaration)JsonValueTypeDeclaration.Int32,
                        "int64" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Int64) : (ITypeDeclaration)JsonValueTypeDeclaration.Int64,
                        "single" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Float) : (ITypeDeclaration)JsonValueTypeDeclaration.Float,
                        "double" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Double) : (ITypeDeclaration)JsonValueTypeDeclaration.Double,
                        _ => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Number) : (ITypeDeclaration)JsonValueTypeDeclaration.Number,
                    });
            }

            return Task.FromResult(schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Number) : (ITypeDeclaration)JsonValueTypeDeclaration.Number);
        }

        private Task<ITypeDeclaration> CreateString(JsonSchema schema, string name)
        {
            if (schema.Format is JsonString format)
            {
                // TODO: Look at validations on the additional types.
                return Task.FromResult(
                    (string)format switch
                    {
                        "date-time" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.DateTime) : (ITypeDeclaration)JsonValueTypeDeclaration.DateTime,
                        "time" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Time) : (ITypeDeclaration)JsonValueTypeDeclaration.Time,
                        "date" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Date) : (ITypeDeclaration)JsonValueTypeDeclaration.Date,
                        "email" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Email) : (ITypeDeclaration)JsonValueTypeDeclaration.Email,
                        "idn-email" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                        "hostname" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.HostName) : (ITypeDeclaration)JsonValueTypeDeclaration.HostName,
                        "idn-hostname" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                        "ip-v4" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.IPv4) : (ITypeDeclaration)JsonValueTypeDeclaration.IPv4,
                        "ip-v6" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.IPv6) : (ITypeDeclaration)JsonValueTypeDeclaration.IPv6,
                        "uri" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Uri) : (ITypeDeclaration)JsonValueTypeDeclaration.Uri,
                        "uri-reference" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Uri) : (ITypeDeclaration)JsonValueTypeDeclaration.Uri,
                        "iri" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Uri) : (ITypeDeclaration)JsonValueTypeDeclaration.Uri,
                        "iri-reference" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Uri) : (ITypeDeclaration)JsonValueTypeDeclaration.Uri,
                        "uuid" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Guid) : (ITypeDeclaration)JsonValueTypeDeclaration.Guid,
                        "uri-template" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Uri) : (ITypeDeclaration)JsonValueTypeDeclaration.Uri,
                        "json-pointer" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                        "relative-json-pointer" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                        "regex" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                        _ => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                    });
            }

            return Task.FromResult(schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String);
        }

        private Task<ITypeDeclaration> CreateArray(JsonSchema schema, string name)
        {
            return Task.FromResult(schema.IsValidated() ? (ITypeDeclaration)new ValidatedArrayTypeDeclaration(name) : new ArrayTypeDeclaration());
        }

        private async Task PopulateArray(ITypeDeclaration type, JsonSchema schema, JsonDocument rootDocument, string baseUri)
        {
            if (schema.Items is JsonSchema.SchemaOrReference items)
            {
                ITypeDeclaration itemTypeDeclaration = await this.GetTypeDeclarationFor(items, rootDocument, baseUri).ConfigureAwait(false) ?? JsonValueTypeDeclaration.Any;

                if (type is ValidatedArrayTypeDeclaration validatedArrayType)
                {
                    validatedArrayType.ItemType = itemTypeDeclaration;
                    await this.BuildValidations(schema, validatedArrayType, rootDocument, baseUri).ConfigureAwait(false);
                }
                else if (type is ArrayTypeDeclaration arrayType)
                {
                    arrayType.ItemType = itemTypeDeclaration;
                }
            }
        }

        private Task<ITypeDeclaration> CreateAny(JsonSchema schema, string name)
        {
            return Task.FromResult(schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Any) : JsonValueTypeDeclaration.Any);
        }

        private Task<ITypeDeclaration> CreateInteger(JsonSchema schema, string name)
        {
            if (schema.Format is JsonString format)
            {
                return Task.FromResult(
                    (string)format switch
                    {
                        "int32" => schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Int32) : JsonValueTypeDeclaration.Int32,
                        "int64" => schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Int64) : JsonValueTypeDeclaration.Int64,
                        _ => schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Integer) : JsonValueTypeDeclaration.Integer,
                    });
            }

            return Task.FromResult(
                schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Integer) : JsonValueTypeDeclaration.Integer);
        }

        private async Task BuildValidations(JsonSchema schema, ValidatedArrayTypeDeclaration validatedJsonArrayTypeDeclaration, JsonDocument rootDocument, string baseUri)
        {
            validatedJsonArrayTypeDeclaration.ConstValidation = schema.Const?.ToString();
            validatedJsonArrayTypeDeclaration.ContainsValidation = await this.GetTypeDeclarationFor(schema.Contains, rootDocument, baseUri).ConfigureAwait(false);
            validatedJsonArrayTypeDeclaration.EnumValidation = schema.Enum?.ToString();
            validatedJsonArrayTypeDeclaration.MaxContainsValidation = schema.MaxContains;
            validatedJsonArrayTypeDeclaration.MaxItemsValidation = schema.MaxItems;
            validatedJsonArrayTypeDeclaration.MinContainsValidation = schema.MinContains;
            validatedJsonArrayTypeDeclaration.MinItemsValidation = schema.MinItems;
            validatedJsonArrayTypeDeclaration.NotTypeValidation = await this.GetTypeDeclarationFor(schema.Not, rootDocument, baseUri).ConfigureAwait(false);
            validatedJsonArrayTypeDeclaration.UniqueValidation = schema.UniqueItems;
        }

        private async Task BuildValidations(JsonSchema schema, ValidatedJsonValueTypeDeclaration validatedJsonValueTypeDeclaration, JsonDocument rootDocument, string baseUri)
        {
            validatedJsonValueTypeDeclaration.ConstValidation = schema.Const?.ToString();
            validatedJsonValueTypeDeclaration.EnumValidation = schema.Enum?.ToString();
            validatedJsonValueTypeDeclaration.ExclusiveMaximumValidation = schema.ExclusiveMaximum;
            validatedJsonValueTypeDeclaration.ExclusiveMinimumValidation = schema.ExclusiveMinimum;
            validatedJsonValueTypeDeclaration.MaximumValidation = schema.Maximum;
            validatedJsonValueTypeDeclaration.MaxLengthValidation = schema.MaxLength;
            validatedJsonValueTypeDeclaration.MinimumValidation = schema.Minimum;
            validatedJsonValueTypeDeclaration.MinLengthValidation = schema.MinLength;
            validatedJsonValueTypeDeclaration.MultipleOfValidation = schema.MultipleOf;
            validatedJsonValueTypeDeclaration.NotTypeValidation = await this.GetTypeDeclarationFor(schema.Not, rootDocument, baseUri).ConfigureAwait(false);
            validatedJsonValueTypeDeclaration.OneOfTypeValidation = await this.GetTypeDeclarationsFor(schema.OneOf, rootDocument, baseUri).ConfigureAwait(false);
            validatedJsonValueTypeDeclaration.AnyOfTypeValidation = await this.GetTypeDeclarationsFor(schema.AnyOf, rootDocument, baseUri).ConfigureAwait(false);
            validatedJsonValueTypeDeclaration.AllOfTypeValidation = await this.GetTypeDeclarationsFor(schema.AllOf, rootDocument, baseUri).ConfigureAwait(false);
            validatedJsonValueTypeDeclaration.PatternValidation = schema.Pattern;
        }

        private async Task<List<(string, JsonDocument, JsonSchema)>?> GetSchemasFor(JsonSchema.ValidatedArrayOfSchemaOrReference schemas, JsonDocument rootDocument, string baseUri)
        {
            if (!(schemas is JsonSchema.ValidatedArrayOfSchemaOrReference s))
            {
                return null;
            }

            var result = new List<(string, JsonDocument, JsonSchema)>();

            foreach (JsonSchema.SchemaOrReference sor in s)
            {
                (string, JsonDocument, JsonSchema)? item = await this.GetSchemaFor(sor, rootDocument, baseUri).ConfigureAwait(false);

                if (item is null)
                {
                    throw new InvalidOperationException($"Unable to find the schema for {sor}");
                }

                result.Add(item.Value!);
            }

            return result;
        }

        private async Task<List<ITypeDeclaration>?> GetTypeDeclarationsFor(JsonSchema.ValidatedArrayOfSchemaOrReference? schemas, JsonDocument rootDocument, string baseUri)
        {
            if (!(schemas is JsonSchema.ValidatedArrayOfSchemaOrReference s))
            {
                return null;
            }

            var result = new List<ITypeDeclaration>();

            foreach (JsonSchema.SchemaOrReference sor in s)
            {
                ITypeDeclaration? item = await this.GetTypeDeclarationFor(sor, rootDocument, baseUri).ConfigureAwait(false);

                if (item is null)
                {
                    throw new InvalidOperationException($"Unable to find the type declaration for {sor}");
                }

                result.Add(item);
            }

            return result;
        }

        private string GetName(JsonSchema schema)
        {
            if (schema.Id is JsonString id)
            {
                var jsonRef = new JsonRef(id);
                if (jsonRef.HasPointer)
                {
                    return this.GetName(jsonRef.Pointer);
                }
                else if (jsonRef.HasUri)
                {
                    return this.GetName(jsonRef.Uri);
                }
            }

            if (schema.IsValueType())
            {
                return this.GetName(this.propertyNameStack.Peek()) + "Value";
            }
            else if (schema.IsArrayType())
            {
                string itemsName;

                if (schema.Items is JsonSchema.SchemaOrReference itemsRef)
                {
                    if (itemsRef.IsSchemaReference)
                    {
                        var jsonRef = new JsonRef(itemsRef.AsSchemaReference().Ref);
                        if (jsonRef.HasPointer)
                        {
                            itemsName = this.GetName(jsonRef.Pointer);
                        }
                        else if (jsonRef.HasUri)
                        {
                            itemsName = this.GetName(jsonRef.Uri);
                        }
                        else
                        {
                            itemsName = string.Empty;
                        }
                    }
                    else
                    {
                        itemsName = this.GetName(itemsRef.AsJsonSchema());
                    }
                }
                else
                {
                    itemsName = "JsonAny";
                }

                return itemsName + this.GetName(this.propertyNameStack.Peek());
            }
            else
            {
                return this.GetName(this.propertyNameStack.Peek()) + "Entity";
            }
        }

        private string GetName(ReadOnlySpan<char> pointer)
        {
            return StringFormatter.ToPascalCaseWithReservedWords(System.IO.Path.GetFileNameWithoutExtension(pointer).ToString());
        }
    }
}