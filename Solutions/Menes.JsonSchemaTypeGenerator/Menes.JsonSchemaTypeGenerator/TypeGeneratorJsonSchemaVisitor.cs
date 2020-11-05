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
        private readonly Dictionary<string, ITypeDeclaration> anchors = new Dictionary<string, ITypeDeclaration>();
        private readonly Stack<ITypeDeclaration> declarationStack = new Stack<ITypeDeclaration>();
        private readonly Stack<string> propertyNameStack = new Stack<string>();
        private readonly ISchemaResolver schemaResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeGeneratorJsonSchemaVisitor"/> class.
        /// </summary>
        /// <param name="schemaResolver">The schema resolver.</param>
        public TypeGeneratorJsonSchemaVisitor(ISchemaResolver schemaResolver)
        {
            this.schemaResolver = schemaResolver;
            this.RootTypeName = string.Empty;
        }

        /// <summary>
        /// Gets the name of the root type in the schema.
        /// </summary>
        public string RootTypeName { get; private set; }

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
        /// <param name="baseUri">The base URI for the document.</param>
        /// <param name="rootDocument">The root document containing the schema.</param>
        /// <param name="schema">The schema for which to build the type.</param>
        /// <returns>A task which completes when the types are built for the given schema.</returns>
        public async Task BuildTypes(string baseUri, JsonDocument rootDocument, JsonSchema schema)
        {
            (string baseUri, JsonDocument rootDocument, JsonSchema schema) result = (baseUri, rootDocument, schema);

            if (schema.IsSchemaReference())
            {
                result = await this.ResolveSchemaReference(schema, rootDocument, baseUri).ConfigureAwait(false);
            }

            ITypeDeclaration rootType = await this.BuildTypeCore(result.baseUri, result.rootDocument, result.schema).ConfigureAwait(false);
            this.RootTypeName = rootType.GetFullyQualifiedName();
        }

        private async Task<ITypeDeclaration> BuildTypeCore(string baseUri, JsonDocument rootDocument, JsonSchema schema)
        {
            ITypeDeclaration declaration = await this.CreateTypeDeclarationFor(schema).ConfigureAwait(false);

            if (schema.Anchor is JsonString anchor)
            {
                this.anchors.Add(anchor, declaration);
            }

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
            // Special case boolean schema
            if (schema.HasJsonElement && schema.JsonElement.ValueKind == JsonValueKind.True)
            {
                return Task.FromResult((ITypeDeclaration)JsonValueTypeDeclaration.Any);
            }

            if (schema.HasJsonElement && schema.JsonElement.ValueKind == JsonValueKind.False)
            {
                return Task.FromResult((ITypeDeclaration)JsonValueTypeDeclaration.NotAny);
            }

            string name = this.GetName(schema);

            if (schema.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum type && type.IsTypeEnum)
            {
                return (string)type.AsTypeEnum() switch
                {
                    "integer" => this.CreateInteger(schema, name),
                    "object" => this.CreateObject(schema, name),
                    "boolean" => this.CreateBoolean(schema, name),
                    "number" => this.CreateNumber(schema, name),
                    "string" => this.CreateString(schema, name),
                    "array" => this.CreateArray(schema, name),
                    "null" => this.CreateNull(),
                    _ => this.CreateAny(schema, name),
                };
            }

            // If we have defined any properties, or this is a root, treat it as an object
            if (schema.IsInferredObject())
            {
                return this.CreateObject(schema, name);
            }

            if (schema.IsInferredArray())
            {
                return this.CreateArray(schema, name);
            }

            return this.CreateAny(schema, name);
        }

        private Task PopulateTypeDeclarationFor(ITypeDeclaration typeDeclaration, JsonSchema schema, JsonDocument rootDocument, string baseUri)
        {
            if (schema.HasJsonElement && schema.JsonElement.ValueKind == JsonValueKind.True)
            {
                return Task.CompletedTask;
            }

            if (schema.HasJsonElement && schema.JsonElement.ValueKind == JsonValueKind.False)
            {
                return Task.CompletedTask;
            }

            if (schema.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum type && type.IsTypeEnum)
            {
                return (string)type.AsTypeEnum() switch
                {
                    "integer" => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                    "object" => this.PopulateObject(typeDeclaration, schema, rootDocument, baseUri),
                    "boolean" => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                    "number" => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                    "string" => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                    "null" => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                    "array" => this.PopulateArray(typeDeclaration, schema, rootDocument, baseUri),
                    _ => this.PopulateJsonValue(typeDeclaration, schema, rootDocument, baseUri),
                };
            }

            // If we have defined any properties, or this is a root, treat it as an object
            if (schema.IsInferredObject())
            {
                return this.PopulateObject(typeDeclaration, schema, rootDocument, baseUri);
            }

            if (schema.IsInferredArray())
            {
                return this.PopulateArray(typeDeclaration, schema, rootDocument, baseUri);
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

                    additionalPropertiesType = await this.GetTypeDeclarationFor(additionalProperties.AsJsonSchema(), rootDocument, baseUri).ConfigureAwait(false);

                    this.propertyNameStack.Pop();
                }
            }

            return additionalPropertiesType;
        }

        private async Task<(string, JsonDocument, JsonSchema)> ResolveSchemaReference(JsonSchema schemaOrReference, JsonDocument rootDocument, string baseUri)
        {
            if (schemaOrReference.IsSchemaReference())
            {
                (baseUri, rootDocument, schemaOrReference) = await this.schemaResolver.Resolve(baseUri, rootDocument, schemaOrReference).ConfigureAwait(false);
            }

            return (baseUri, rootDocument, schemaOrReference);
        }

        private async Task<ITypeDeclaration?> GetTypeDeclarationFor(JsonSchema? schemaOrReference, JsonDocument rootDocument, string baseUri)
        {
            if (!(schemaOrReference is JsonSchema sor))
            {
                return null;
            }

            string uri = baseUri;
            JsonDocument document = rootDocument;
            JsonSchema reference = sor;
            string name = this.GetName(sor);

            if (this.typeDeclarations.TryGetValue(name, out ITypeDeclaration result))
            {
                return result;
            }

            (uri, document, reference) = await this.schemaResolver.Resolve(baseUri, rootDocument, sor).ConfigureAwait(false);

            JsonSchema schema = reference;

            name = this.GetName(schema);

            if (this.typeDeclarations.TryGetValue(name, out ITypeDeclaration result2))
            {
                return result2;
            }

            if (schema.Id is null && schema.Ref is null && this.declarationStack.Peek().ContainsTypeDeclaration(name))
            {
                ITypeDeclaration td = this.declarationStack.Peek().GetTypeDeclaration(name);
                await this.PopulateTypeDeclarationFor(td, schema, document, uri).ConfigureAwait(false);
                return td;
            }

            return await this.BuildTypeCore(uri, document, schema).ConfigureAwait(false);
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
            if (schema.OneOf is JsonSchema.NonEmptySubschemaArray)
            {
                booleanSubschemaCount += 1;
            }

            if (schema.AnyOf is JsonSchema.NonEmptySubschemaArray)
            {
                booleanSubschemaCount += 1;
            }

            if (schema.AllOf is JsonSchema.NonEmptySubschemaArray)
            {
                booleanSubschemaCount += 1;
            }

            // We have to use the "any" type approach
            if (booleanSubschemaCount > 1)
            {
                return this.CreateAny(schema, name);
            }

            if (schema.OneOf is JsonSchema.NonEmptySubschemaArray)
            {
                return Task.FromResult<ITypeDeclaration>(new UnionTypeDeclaration(name, UnionTypeDeclaration.UnionKind.OneOf));
            }

            if (schema.AnyOf is JsonSchema.NonEmptySubschemaArray)
            {
                return Task.FromResult<ITypeDeclaration>(new UnionTypeDeclaration(name, UnionTypeDeclaration.UnionKind.AnyOf));
            }

            if (schema.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum type && type.IsArrayOfTypeEnum)
            {
                return Task.FromResult<ITypeDeclaration>(new UnionTypeDeclaration(name, UnionTypeDeclaration.UnionKind.AnyOf));
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

            if (schema.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum schemaType && schemaType.IsTypeEnum && schemaType.AsTypeEnum() == JsonSchema.TypeEnum.Object)
            {
                typeDeclaration.ValidateAsObject = true;
            }

            if (schema.AllOf is JsonSchema.NonEmptySubschemaArray allOf)
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

            this.declarationStack.Push(typeDeclaration);
            typeDeclaration.AdditionalPropertiesType = await this.GetAdditionalPropertiesType(schema, rootDocument, baseUri).ConfigureAwait(false);

            if (schema.PatternProperties is JsonSchema.SchemaProperties patternProperties)
            {
                var patternPropertyValidation = new List<(string, ITypeDeclaration)>();
                foreach (JsonPropertyReference<JsonSchema> patternProperty in patternProperties.JsonAdditionalProperties)
                {
                    ITypeDeclaration patternType = await this.GetTypeDeclarationFor(patternProperty.AsValue(), rootDocument, baseUri).ConfigureAwait(false) ?? AnyTypeDeclaration.Instance;
                    patternPropertyValidation.Add((patternProperty.Name, patternType));
                }

                if (patternPropertyValidation.Count > 0)
                {
                    typeDeclaration.PatternPropertiesValidation = patternPropertyValidation;
                }
            }

            var requiredProperties = new List<string>();

            if (schema.Required is JsonSchema.UniqueStringArray required)
            {
                requiredProperties.AddRange(required.Select(s => s.CreateOrGetClrString()));
            }

            if (schema.MaxProperties is JsonSchema.NonNegativeInteger maxProperties)
            {
                typeDeclaration.MaxPropertiesValidation = maxProperties;
            }

            if (schema.MinProperties is JsonSchema.NonNegativeInteger minProperties)
            {
                typeDeclaration.MinPropertiesValidation = minProperties;
            }

            if (schema.Properties is JsonSchema.SchemaProperties properties)
            {
                foreach (JsonPropertyReference<JsonSchema> property in properties.JsonAdditionalProperties)
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
                        requiredProperties.Remove(property.Name);
                    }

                    this.propertyNameStack.Pop();
                }
            }

            if (requiredProperties.Count > 0)
            {
                typeDeclaration.RequiredPropertiesValidation = requiredProperties;
            }

            this.declarationStack.Pop();
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

            if (schema.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum type && type.IsArrayOfTypeEnum)
            {
                foreach (JsonSchema.TypeEnum typeEnum in type.AsArrayOfTypeEnum())
                {
                    var typeSchema = new JsonSchema(type: typeEnum);
                    ITypeDeclaration? td = await this.GetTypeDeclarationFor(typeSchema, rootDocument, baseUri).ConfigureAwait(false);
                    if (!(td is ITypeDeclaration typd))
                    {
                        throw new InvalidOperationException($"Unable to create type declaration for Type Enumeration {typeEnum}");
                    }

                    union.AddTypeToUnion(typd);
                }
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
            if (schema.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum schemaType && schemaType.IsTypeEnum && schemaType.AsTypeEnum() == JsonSchema.TypeEnum.Array)
            {
                if (type is ValidatedArrayTypeDeclaration vat)
                {
                    vat.ValidateAsArray = true;
                }
            }

            this.declarationStack.Push(type);

            if (schema.Items is JsonSchema.SchemaItems schemaItems)
            {
                ITypeDeclaration itemTypeDeclaration;

                if (schemaItems.IsBooleanTrueSchema())
                {
                    itemTypeDeclaration = JsonValueTypeDeclaration.Any;
                }
                else if (schemaItems.IsBooleanFalseSchema())
                {
                    itemTypeDeclaration = JsonValueTypeDeclaration.NotAny;
                }
                else if (schemaItems.IsJsonSchema)
                {
                    itemTypeDeclaration = await this.GetTypeDeclarationFor(schemaItems.AsJsonSchema(), rootDocument, baseUri).ConfigureAwait(false) ?? JsonValueTypeDeclaration.Any;
                }
                else
                {
                    itemTypeDeclaration = JsonValueTypeDeclaration.Any;
                }

                if (type is ValidatedArrayTypeDeclaration validatedArrayType)
                {
                    validatedArrayType.ItemType = itemTypeDeclaration;
                }
                else if (type is ArrayTypeDeclaration arrayType)
                {
                    arrayType.ItemType = itemTypeDeclaration;
                }
            }

            if (type is ValidatedArrayTypeDeclaration validatedArrayType2)
            {
                await this.BuildValidations(schema, validatedArrayType2, rootDocument, baseUri).ConfigureAwait(false);
            }

            this.declarationStack.Pop();
        }

        private Task<ITypeDeclaration> CreateAny(JsonSchema schema, string name)
        {
            return Task.FromResult(schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Any) : JsonValueTypeDeclaration.Any);
        }

        private Task<ITypeDeclaration> CreateNull()
        {
            return Task.FromResult((ITypeDeclaration)JsonValueTypeDeclaration.Null);
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
            this.propertyNameStack.Push("ContainsValidation");
            validatedJsonArrayTypeDeclaration.ContainsValidation = await this.GetTypeDeclarationFor(schema.Contains, rootDocument, baseUri).ConfigureAwait(false);
            this.propertyNameStack.Pop();
            validatedJsonArrayTypeDeclaration.EnumValidation = schema.Enum?.ToString();
            validatedJsonArrayTypeDeclaration.MaxContainsValidation = schema.MaxContains;
            validatedJsonArrayTypeDeclaration.MaxItemsValidation = schema.MaxItems;
            validatedJsonArrayTypeDeclaration.MinContainsValidation = schema.MinContains;
            validatedJsonArrayTypeDeclaration.MinItemsValidation = schema.MinItems;
            this.propertyNameStack.Push("NotTypeValidation");
            validatedJsonArrayTypeDeclaration.NotTypeValidation = await this.GetTypeDeclarationFor(schema.Not, rootDocument, baseUri).ConfigureAwait(false);
            this.propertyNameStack.Pop();
            validatedJsonArrayTypeDeclaration.UniqueValidation = schema.UniqueItems;
            this.propertyNameStack.Push("ItemsValidation");
            validatedJsonArrayTypeDeclaration.ItemsValidation = await this.GetTypeDeclarationsFor(schema.Items, rootDocument, baseUri).ConfigureAwait(false);
            this.propertyNameStack.Pop();
            this.propertyNameStack.Push("AdditionalItemsValidation");
            validatedJsonArrayTypeDeclaration.AdditionalItemsValidation = await this.GetTypeDeclarationFor(schema.AdditionalItems, rootDocument, baseUri).ConfigureAwait(false);
            this.propertyNameStack.Pop();
        }

        private async Task<ITypeDeclaration?> GetTypeDeclarationFor(JsonSchema.SchemaAdditionalItems? additionalItems, JsonDocument rootDocument, string baseUri)
        {
            if (additionalItems is JsonSchema.SchemaAdditionalItems ai)
            {
                if (ai.IsJsonBoolean)
                {
                    if (ai.AsJsonBoolean())
                    {
                        return AnyTypeDeclaration.Instance;
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (ai.IsJsonSchema)
                {
                    return await this.GetTypeDeclarationFor(ai.AsJsonSchema(), rootDocument, baseUri).ConfigureAwait(false);
                }
            }

            return AnyTypeDeclaration.Instance;
        }

        private async Task<List<ITypeDeclaration>?> GetTypeDeclarationsFor(JsonSchema.SchemaItems? items, JsonDocument rootDocument, string baseUri)
        {
            if (items is JsonSchema.SchemaItems schemaItems)
            {
                if (schemaItems.IsNonEmptyBooleanArray)
                {
                    return this.GetTypeDeclarationsFor(schemaItems.AsNonEmptyBooleanArray());
                }

                if (schemaItems.IsNonEmptySubschemaArray)
                {
                    return await this.GetTypeDeclarationsFor(schemaItems.AsNonEmptySubschemaArray(), rootDocument, baseUri).ConfigureAwait(false);
                }
            }

            return null;
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
            this.propertyNameStack.Push("NotTypeValidation");
            validatedJsonValueTypeDeclaration.NotTypeValidation = await this.GetTypeDeclarationFor(schema.Not, rootDocument, baseUri).ConfigureAwait(false);
            this.propertyNameStack.Pop();
            this.propertyNameStack.Push("OneOfValidation");
            validatedJsonValueTypeDeclaration.OneOfTypeValidation = await this.GetTypeDeclarationsFor(schema.OneOf, rootDocument, baseUri).ConfigureAwait(false);
            this.propertyNameStack.Pop();
            this.propertyNameStack.Push("AnyOfValidation");
            validatedJsonValueTypeDeclaration.AnyOfTypeValidation = await this.GetTypeDeclarationsFor(schema.AnyOf, rootDocument, baseUri).ConfigureAwait(false);
            this.propertyNameStack.Pop();
            this.propertyNameStack.Push("AllOfValidation");
            validatedJsonValueTypeDeclaration.AllOfTypeValidation = await this.GetTypeDeclarationsFor(schema.AllOf, rootDocument, baseUri).ConfigureAwait(false);
            this.propertyNameStack.Pop();
            validatedJsonValueTypeDeclaration.PatternValidation = schema.Pattern;
        }

        private async Task<List<(string, JsonDocument, JsonSchema)>?> GetSchemasFor(JsonSchema.NonEmptySubschemaArray schemas, JsonDocument rootDocument, string baseUri)
        {
            if (!(schemas is JsonSchema.NonEmptySubschemaArray s))
            {
                return null;
            }

            var result = new List<(string, JsonDocument, JsonSchema)>();

            foreach (JsonSchema sor in s)
            {
                (string, JsonDocument, JsonSchema)? item = await this.ResolveSchemaReference(sor, rootDocument, baseUri).ConfigureAwait(false);

                if (item is null)
                {
                    throw new InvalidOperationException($"Unable to find the schema for {sor}");
                }

                result.Add(item.Value!);
            }

            return result;
        }

        private List<ITypeDeclaration>? GetTypeDeclarationsFor(JsonSchema.NonEmptyBooleanArray? schemas)
        {
            if (!(schemas is JsonSchema.NonEmptyBooleanArray s))
            {
                return null;
            }

            var result = new List<ITypeDeclaration>();

            foreach (JsonBoolean b in s)
            {
                if (b)
                {
                    result.Add(JsonValueTypeDeclaration.Any);
                }
                else
                {
                    result.Add(JsonValueTypeDeclaration.NotAny);
                }
            }

            return result;
        }

        private async Task<List<ITypeDeclaration>?> GetTypeDeclarationsFor(JsonSchema.NonEmptySubschemaArray? schemas, JsonDocument rootDocument, string baseUri)
        {
            if (!(schemas is JsonSchema.NonEmptySubschemaArray s))
            {
                return null;
            }

            var result = new List<ITypeDeclaration>();

            int itemIndex = 1;
            foreach (JsonSchema sor in s)
            {
                if (sor.IsBooleanTrueSchema())
                {
                    result.Add(JsonValueTypeDeclaration.Any);
                    continue;
                }
                else if (sor.IsBooleanFalseSchema())
                {
                    result.Add(JsonValueTypeDeclaration.NotAny);
                    continue;
                }

                this.propertyNameStack.Push($"{this.propertyNameStack.Peek()}Item{itemIndex}");

                try
                {
                    ITypeDeclaration? item = await this.GetTypeDeclarationFor(sor, rootDocument, baseUri).ConfigureAwait(false);

                    if (item is null)
                    {
                        throw new InvalidOperationException($"Unable to find the type declaration for {sor}");
                    }

                    result.Add(item);
                }
                finally
                {
                    this.propertyNameStack.Pop();
                }

                itemIndex++;
            }

            return result;
        }

        private string GetName(JsonSchema schema)
        {
            string? idMatch = schema.Id;

            if (idMatch is null)
            {
                if (schema.Ref is JsonString reference)
                {
                    if (reference == "#")
                    {
                        return this.declarationStack.Peek().Name;
                    }

                    var jsonRef = new JsonRef(reference);
                    if (jsonRef.HasPointer)
                    {
                        idMatch = jsonRef.Pointer.ToString();
                    }
                    else if (new Uri(jsonRef.Uri.ToString(), UriKind.RelativeOrAbsolute).IsAbsoluteUri)
                    {
                        idMatch = jsonRef.Uri.ToString();
                    }
                    else
                    {
                        idMatch = null;
                    }
                }
            }

            if (idMatch is string id)
            {
                var jsonRef = new JsonRef(id);
                if (jsonRef.HasPointer)
                {
                    string n = this.GetName(jsonRef.Pointer);
                    if (!string.IsNullOrEmpty(n))
                    {
                        return n;
                    }
                }
                else if (jsonRef.HasUri)
                {
                    string n = this.GetName(jsonRef.Uri);
                    if (!string.IsNullOrEmpty(n))
                    {
                        return n;
                    }
                }
            }

            string name;

            if (this.propertyNameStack.Count == 0)
            {
                return "Entity";
            }

            if (schema.IsValueType())
            {
                name = this.GetName(this.propertyNameStack.Peek()) + "Value";
            }
            else if (schema.IsArrayType())
            {
                name = this.GetName(this.propertyNameStack.Peek()) + "Array";
            }
            else
            {
                name = this.GetName(this.propertyNameStack.Peek()) + "Entity";
            }

            if (name == this.declarationStack.Peek().Name)
            {
                name += "Child";
            }

            return name;
        }

        private string GetName(ReadOnlySpan<char> pointer)
        {
            return StringFormatter.ToPascalCaseWithReservedWords(pointer.ToString());
        }
    }
}