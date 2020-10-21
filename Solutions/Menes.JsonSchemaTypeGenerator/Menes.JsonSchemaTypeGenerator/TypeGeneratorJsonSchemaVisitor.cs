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
    public class TypeGeneratorJsonSchemaVisitor : SchemaVisitor
    {
        // Type declarations keyed by the form of the declaration.
        private readonly Dictionary<string, ITypeDeclaration> typeDeclarations = new Dictionary<string, ITypeDeclaration>();
        private readonly Stack<ITypeDeclaration> declarationStack = new Stack<ITypeDeclaration>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeGeneratorJsonSchemaVisitor"/> class.
        /// </summary>
        /// <param name="documentResolver">The document resolver to use.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="root">The root json document.</param>
        public TypeGeneratorJsonSchemaVisitor(IDocumentResolver documentResolver, string baseUri, JsonDocument root)
            : base(documentResolver, baseUri, root)
        {
        }

        /// <summary>
        /// Generate the types we have found.
        /// </summary>
        /// <returns>The Type declaration syntax for the types we have found.</returns>
        public TypeDeclarationSyntax[] GenerateTypes()
        {
            return this.typeDeclarations.Values.Where(t => t.Parent is null).Select(t => t.GenerateType()).ToArray();
        }

        /// <inheritdoc/>
        protected override async ValueTask<(bool, JsonSchema)> BeginVisitSchema(JsonSchema schema)
        {
            string? optionalKey = this.GetKeyFor(schema);
            if (!(optionalKey is string key) || this.typeDeclarations.ContainsKey(key))
            {
                return (false, schema);
            }

            ITypeDeclaration typeDeclaration = await this.CreateTypeDeclarationFor(schema).ConfigureAwait(false);

            if (typeDeclaration.ShouldGenerate)
            {
                this.typeDeclarations.Add(key, typeDeclaration);

                if (schema.Id is null)
                {
                    if (this.declarationStack.TryPeek(out ITypeDeclaration parent))
                    {
                        parent.AddTypeDeclaration(typeDeclaration);
                    }
                }

                this.declarationStack.Push(typeDeclaration);
            }

            return (false, schema);
        }

        /// <inheritdoc/>
        protected override ValueTask<(bool wasUpdated, JsonSchema updatedSchema)> EndVisitSchema(JsonSchema schema)
        {
            string? optionalKey = this.GetKeyFor(schema);
            if (!(optionalKey is string key) || !this.typeDeclarations.ContainsKey(key))
            {
                return new ValueTask<(bool wasUpdated, JsonSchema updatedSchema)>((false, schema));
            }

            ITypeDeclaration typeDeclaration = this.typeDeclarations[key];
            this.PopulateTypeDeclarationFor(typeDeclaration, schema);
            this.declarationStack.Pop();
            return new ValueTask<(bool wasUpdated, JsonSchema updatedSchema)>((false, schema));
        }

        private ValueTask<ITypeDeclaration> CreateTypeDeclarationFor(JsonSchema schema)
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

        private Task PopulateTypeDeclarationFor(ITypeDeclaration typeDeclaration, JsonSchema schema)
        {
            if (schema.Type is JsonSchema.TypeEnum type)
            {
                return (string)type switch
                {
                    "integer" => this.PopulateJsonValue(typeDeclaration, schema),
                    "object" => this.PopulateObject(typeDeclaration, schema),
                    "boolean" => this.PopulateJsonValue(typeDeclaration, schema),
                    "number" => this.PopulateJsonValue(typeDeclaration, schema),
                    "string" => this.PopulateJsonValue(typeDeclaration, schema),
                    "array" => this.PopulateArray(typeDeclaration, schema),
                    _ => this.PopulateJsonValue(typeDeclaration, schema),
                };
            }

            return this.PopulateJsonValue(typeDeclaration, schema);
        }

        private async ValueTask<ITypeDeclaration?> GetAdditionalPropertiesType(JsonSchema schema)
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
                    additionalPropertiesType = await this.GetTypeDeclarationFor(additionalProperties.AsSchemaOrReference()).ConfigureAwait(false);
                }
            }

            return additionalPropertiesType;
        }

        private Task PopulateJsonValue(ITypeDeclaration type, JsonSchema schema)
        {
            if (type is ValidatedJsonValueTypeDeclaration typeDeclaration)
            {
                return this.BuildValidations(schema, typeDeclaration);
            }

            return Task.CompletedTask;
        }

        private ValueTask<ITypeDeclaration> CreateObject(JsonSchema schema, string name)
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

            return new ValueTask<ITypeDeclaration>(new ObjectTypeDeclaration(name));
        }

        private async Task PopulateObject(ITypeDeclaration type, JsonSchema schema)
        {
            if (!(type is ObjectTypeDeclaration typeDeclaration))
            {
                throw new InvalidOperationException($"Expected an {typeof(ObjectTypeDeclaration).FullName} but found a {type.GetType().FullName}.");
            }

            this.PushPointerElement(typeDeclaration.Name);

            ITypeDeclaration? additionalPropertiesType = await this.GetAdditionalPropertiesType(schema).ConfigureAwait(false);

            if (schema.Properties is JsonSchema.SchemaProperties properties)
            {
                var requiredProperties = new List<string>();

                if (schema.Required is JsonSchema.ValidatedArrayOfJsonString required)
                {
                    requiredProperties.AddRange(required.Select(s => s.CreateOrGetClrString()));
                }

                foreach (JsonPropertyReference<JsonSchema.SchemaOrReference> property in properties.JsonAdditionalProperties)
                {
                    this.PushPointerElement(property.Name);

                    ITypeDeclaration? childType = await this.GetTypeDeclarationFor(property.AsValue()).ConfigureAwait(false);

                    if (!(childType is ITypeDeclaration ct))
                    {
                        throw new InvalidOperationException($"Unable to find the type for {this.Path}/{property.Name}");
                    }

                    if (!requiredProperties.Contains(property.Name))
                    {
                        typeDeclaration.AddPropertyDeclaration(property.Name, ct.AsOptional());
                    }
                    else
                    {
                        typeDeclaration.AddPropertyDeclaration(property.Name, ct);
                    }

                    this.PopPointerElement();
                }
            }

            this.PopPointerElement();
        }

        private ValueTask<ITypeDeclaration> CreateBoolean(JsonSchema schema, string name)
        {
            return new ValueTask<ITypeDeclaration>(
                schema.IsValidated()
                ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Boolean)
                : (ITypeDeclaration)JsonValueTypeDeclaration.Boolean);
        }

        private ValueTask<ITypeDeclaration> CreateNumber(JsonSchema schema, string name)
        {
            if (schema.Format is JsonString format)
            {
                return new ValueTask<ITypeDeclaration>(
                    (string)format switch
                    {
                        "int32" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Int32) : (ITypeDeclaration)JsonValueTypeDeclaration.Int32,
                        "int64" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Int64) : (ITypeDeclaration)JsonValueTypeDeclaration.Int64,
                        "single" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Float) : (ITypeDeclaration)JsonValueTypeDeclaration.Float,
                        "double" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Double) : (ITypeDeclaration)JsonValueTypeDeclaration.Double,
                        _ => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Number) : (ITypeDeclaration)JsonValueTypeDeclaration.Number,
                    });
            }

            return new ValueTask<ITypeDeclaration>(schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Number) : (ITypeDeclaration)JsonValueTypeDeclaration.Number);
        }

        private ValueTask<ITypeDeclaration> CreateString(JsonSchema schema, string name)
        {
            if (schema.Format is JsonString format)
            {
                // TODO: Look at validations on the additional types.
                return new ValueTask<ITypeDeclaration>(
                    (string)format switch
                    {
                        "date-time" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.DateTime) : (ITypeDeclaration)JsonValueTypeDeclaration.DateTime,
                        "time" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Time) : (ITypeDeclaration)JsonValueTypeDeclaration.Time,
                        "date" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Date) : (ITypeDeclaration)JsonValueTypeDeclaration.Date,
                        "email" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                        "idn-email" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                        "hostname" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                        "idn-hostname" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                        "ip-v4" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
                        "ip-v6" => schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String,
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

            return new ValueTask<ITypeDeclaration>(schema.IsValidated() ? new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.String) : (ITypeDeclaration)JsonValueTypeDeclaration.String);
        }

        private async ValueTask<ITypeDeclaration> CreateArray(JsonSchema schema, string name)
        {
            ITypeDeclaration itemTypeDeclaration = await this.GetTypeDeclarationFor(schema.Items).ConfigureAwait(false) ?? JsonValueTypeDeclaration.Any;
            return schema.IsValidated() ? (ITypeDeclaration)new ValidatedArrayTypeDeclaration(name, itemTypeDeclaration) : new ArrayTypeDeclaration(itemTypeDeclaration);
        }

        private Task PopulateArray(ITypeDeclaration type, JsonSchema schema)
        {
            if (type is ValidatedArrayTypeDeclaration typeDeclaration)
            {
                return this.BuildValidations(schema, typeDeclaration);
            }

            return Task.CompletedTask;
        }

        private ValueTask<ITypeDeclaration> CreateAny(JsonSchema schema, string name)
        {
            return new ValueTask<ITypeDeclaration>(schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Any) : JsonValueTypeDeclaration.Any);
        }

        private ValueTask<ITypeDeclaration> CreateInteger(JsonSchema schema, string name)
        {
            if (schema.Format is JsonString format)
            {
                return new ValueTask<ITypeDeclaration>(
                    (string)format switch
                    {
                        "int32" => schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Int32) : JsonValueTypeDeclaration.Int32,
                        "int64" => schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Int64) : JsonValueTypeDeclaration.Int64,
                        _ => schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Integer) : JsonValueTypeDeclaration.Integer,
                    });
            }

            return new ValueTask<ITypeDeclaration>(
                schema.IsValidated() ? (ITypeDeclaration)new ValidatedJsonValueTypeDeclaration(name, JsonValueTypeDeclaration.Integer) : JsonValueTypeDeclaration.Integer);
        }

        private async Task BuildValidations(JsonSchema schema, ValidatedArrayTypeDeclaration validatedJsonArrayTypeDeclaration)
        {
            validatedJsonArrayTypeDeclaration.ConstValidation = schema.Const?.ToString();
            validatedJsonArrayTypeDeclaration.ContainsValidation = await this.GetTypeDeclarationFor(schema.Contains).ConfigureAwait(false);
            validatedJsonArrayTypeDeclaration.EnumValidation = schema.Enum?.ToString();
            validatedJsonArrayTypeDeclaration.MaxContainsValidation = schema.MaxContains;
            validatedJsonArrayTypeDeclaration.MaxItemsValidation = schema.MaxItems;
            validatedJsonArrayTypeDeclaration.MinContainsValidation = schema.MinContains;
            validatedJsonArrayTypeDeclaration.MinItemsValidation = schema.MinItems;
            validatedJsonArrayTypeDeclaration.NotTypeValidation = await this.GetTypeDeclarationFor(schema.Not).ConfigureAwait(false);
            validatedJsonArrayTypeDeclaration.UniqueValidation = schema.UniqueItems;
        }

        private async Task BuildValidations(JsonSchema schema, ValidatedJsonValueTypeDeclaration validatedJsonValueTypeDeclaration)
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
            validatedJsonValueTypeDeclaration.NotTypeValidation = await this.GetTypeDeclarationFor(schema.Not).ConfigureAwait(false);
            validatedJsonValueTypeDeclaration.OneOfTypeValidation = await this.GetTypeDeclarationsFor(schema.OneOf).ConfigureAwait(false);
            validatedJsonValueTypeDeclaration.AnyOfTypeValidation = await this.GetTypeDeclarationsFor(schema.AnyOf).ConfigureAwait(false);
            validatedJsonValueTypeDeclaration.AllOfTypeValidation = await this.GetTypeDeclarationsFor(schema.AllOf).ConfigureAwait(false);
            validatedJsonValueTypeDeclaration.PatternValidation = schema.Pattern;
        }

        private async ValueTask<ITypeDeclaration?> GetTypeDeclarationFor(JsonSchema.SchemaOrReference? schemaOrReference)
        {
            if (!(schemaOrReference is JsonSchema.SchemaOrReference sor))
            {
                return null;
            }

            string? key = await this.GetKeyFor(sor).ConfigureAwait(false);
            if (!(key is string k))
            {
                return null;
            }

            if (this.typeDeclarations.TryGetValue(k, out ITypeDeclaration value))
            {
                return value;
            }

            if (sor.IsJsonSchema)
            {
                JsonSchema schema = sor.AsJsonSchema();

                if (!schema.IsValidated())
                {
                    return await this.CreateTypeDeclarationFor(schema).ConfigureAwait(false);
                }
            }

            return null;
        }

        private async ValueTask<List<ITypeDeclaration>?> GetTypeDeclarationsFor(JsonSchema.ValidatedArrayOfSchemaOrReference? validatedArray)
        {
            if (!(validatedArray is JsonSchema.ValidatedArrayOfSchemaOrReference vasor))
            {
                return null;
            }

            var result = new List<ITypeDeclaration>();

            foreach (JsonSchema.SchemaOrReference item in vasor)
            {
                ITypeDeclaration? td = await this.GetTypeDeclarationFor(item).ConfigureAwait(false);
                if (td is ITypeDeclaration t)
                {
                    result.Add(t);
                }
            }

            if (result.Count > 0)
            {
                return result;
            }

            return null;
        }

        private async ValueTask<string?> GetKeyFor(JsonSchema.SchemaOrReference? schemaOrReference)
        {
            if (schemaOrReference is JsonSchema.SchemaOrReference sor)
            {
                if (sor.IsSchemaReference)
                {
                    (string uri, JsonDocument document) = this.DocumentStack.Peek();
                    (string uri, JsonDocument document, JsonSchema.SchemaOrReference schemaOrReference) result = await sor.Resolve(uri, this.Path, document, this.DocumentResolver).ConfigureAwait(false);
                    return this.GetKeyFor(result.schemaOrReference.AsJsonSchema());
                }
                else
                {
                    return this.GetKeyFor(sor.AsJsonSchema());
                }
            }

            return null;
        }

        private string? GetKeyFor(JsonSchema schema)
        {
            return JsonAny.From(schema).ToString();
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
                    string? name = this.GetName(jsonRef.Uri);
                    if (name is string n)
                    {
                        return n;
                    }
                }
            }

            if (schema.IsValueType())
            {
                return this.GetName(this.Path) + "Value";
            }
            else
            {
                return this.GetName(this.Path) + "Entity";
            }
        }

        private string GetName(ReadOnlySpan<char> pointer)
        {
            return StringFormatter.ToPascalCaseWithReservedWords(System.IO.Path.GetFileNameWithoutExtension(pointer).ToString());
        }
    }
}