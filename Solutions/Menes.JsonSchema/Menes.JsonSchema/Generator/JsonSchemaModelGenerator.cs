// <copyright file="JsonSchemaModelGenerator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.Generator
{
    using Menes.TypeGenerator;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// A model generator for the JSON Schema object model as described in
    /// https://tools.ietf.org/html/draft-handrews-json-schema-validation-02.
    /// </summary>
    public static class JsonSchemaModelGenerator
    {
        /// <summary>
        /// Builds the type model for JsonSchema.
        /// </summary>
        /// <returns>The type declaration syntax for Json Schema.</returns>
        public static TypeDeclarationSyntax BuildModelForJsonSchema()
        {
            var schema = new ObjectTypeDeclaration("Schema", AnyTypeDeclaration.Instance);

            var reference = new ObjectTypeDeclaration("SchemaReference");
            reference.AddPropertyDeclaration("$ref", JsonValueTypeDeclaration.String);
            schema.AddTypeDeclaration(reference);

            var subschema = new UnionTypeDeclaration("SchemaOrReference");
            subschema.AddTypesToUnion(schema, reference);
            schema.AddTypeDeclaration(subschema);

            var schemaType = new ValidatedJsonValueTypeDeclaration("TypeEnum", JsonValueTypeDeclaration.String)
            {
                EnumValidation = JsonEnum.From<JsonString>("null", "boolean", "object", "array", "number", "string", "integer"),
            };
            schema.AddTypeDeclaration(schemaType);

            var schemaPositiveNumber = new ValidatedJsonValueTypeDeclaration("PositiveNumber", JsonValueTypeDeclaration.Number)
            {
                ExclusiveMinimumValidation = 0,
            };
            schema.AddTypeDeclaration(schemaPositiveNumber);

            var schemaNonNegativeInteger = new ValidatedJsonValueTypeDeclaration("NonNegativeInteger", JsonValueTypeDeclaration.Integer)
            {
                MinimumValidation = 0,
            };
            schema.AddTypeDeclaration(schemaNonNegativeInteger);

            var schemaUniqueStringArray = new ValidatedArrayTypeDeclaration(JsonValueTypeDeclaration.String)
            {
                UniqueValidation = true,
            };
            schema.AddTypeDeclaration(schemaUniqueStringArray);

            var nonEmptySubschemaArray = new ValidatedArrayTypeDeclaration(subschema)
            {
                MinItemsValidation = 1,
            };
            schema.AddTypeDeclaration(nonEmptySubschemaArray);

            var schemaProperties = new ObjectTypeDeclaration("SchemaProperties", subschema);
            schema.AddTypeDeclaration(schemaProperties);

            var schemaAdditionalProperties = new UnionTypeDeclaration("SchemaAdditionalProperties", UnionTypeDeclaration.UnionKind.OneOf);
            schemaAdditionalProperties.AddTypesToUnion(subschema, JsonValueTypeDeclaration.Boolean);
            schema.AddTypeDeclaration(schemaAdditionalProperties);

            // Common
            schema.AddOptionalPropertyDeclaration("type", schemaType);
            schema.AddOptionalPropertyDeclaration("format", JsonValueTypeDeclaration.String);
            schema.AddOptionalArrayPropertyDeclaration("enum", AnyTypeDeclaration.Instance);
            schema.AddOptionalPropertyDeclaration("const", AnyTypeDeclaration.Instance);

            schema.AddOptionalPropertyDeclaration("allOf", nonEmptySubschemaArray);
            schema.AddOptionalPropertyDeclaration("anyOf", nonEmptySubschemaArray);
            schema.AddOptionalPropertyDeclaration("oneOf", nonEmptySubschemaArray);
            schema.AddOptionalPropertyDeclaration("not", subschema);

            // Number
            schema.AddOptionalPropertyDeclaration("multipleOf", schemaPositiveNumber);
            schema.AddOptionalPropertyDeclaration("maximum", JsonValueTypeDeclaration.Number);
            schema.AddOptionalPropertyDeclaration("exclusiveMaximum", JsonValueTypeDeclaration.Number);
            schema.AddOptionalPropertyDeclaration("minimum", JsonValueTypeDeclaration.Number);
            schema.AddOptionalPropertyDeclaration("exclusiveMinimum", JsonValueTypeDeclaration.Number);

            // String
            schema.AddOptionalPropertyDeclaration("maxLength", schemaNonNegativeInteger);
            schema.AddOptionalPropertyDeclaration("minLength", schemaNonNegativeInteger);
            schema.AddOptionalPropertyDeclaration("pattern", JsonValueTypeDeclaration.String);

            // Array
            schema.AddOptionalPropertyDeclaration("maxItems", schemaNonNegativeInteger);
            schema.AddOptionalPropertyDeclaration("minItems", schemaNonNegativeInteger);
            schema.AddOptionalPropertyDeclaration("uniqueItems", JsonValueTypeDeclaration.Boolean);
            schema.AddOptionalPropertyDeclaration("maxContains", schemaNonNegativeInteger);
            schema.AddOptionalPropertyDeclaration("items", subschema);
            schema.AddOptionalPropertyDeclaration("contains", subschema);

            // Object
            schema.AddOptionalPropertyDeclaration("maxProperties", schemaNonNegativeInteger);
            schema.AddOptionalPropertyDeclaration("minProperties", schemaNonNegativeInteger);
            schema.AddOptionalPropertyDeclaration("required", schemaUniqueStringArray);
            schema.AddOptionalPropertyDeclaration("properties", schemaProperties);
            schema.AddOptionalPropertyDeclaration("additionalProperties", schemaAdditionalProperties);

            return schema.GenerateType();
        }
    }
}
