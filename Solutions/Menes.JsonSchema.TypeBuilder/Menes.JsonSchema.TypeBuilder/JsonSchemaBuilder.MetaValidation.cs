// <copyright file="JsonSchemaBuilder.MetaValidation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Text.Json;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private static void ValidateAllOf(JsonElement allOf)
        {
            if (allOf.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Unsuppported allOf: {allOf.ValueKind}.");
            }
        }

        private static void ValidateAnyOf(JsonElement anyOf)
        {
            if (anyOf.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Unsuppported anyOf: {anyOf.ValueKind}.");
            }
        }

        private static void ValidateOneOf(JsonElement oneOf)
        {
            if (oneOf.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Unsuppported anyOf: {oneOf.ValueKind}.");
            }
        }

        private static void ValidateObjectWithSchemaProperties(JsonProperty properties)
        {
            ValidateObjectWithSchemaProperties(properties.Value);
        }

        private static void ValidateObjectWithSchemaProperties(JsonElement properties)
        {
            if (properties.ValueKind != JsonValueKind.Object)
            {
                throw new InvalidOperationException($"Unsuppported properties: {properties.ValueKind}.");
            }
        }

        private static void ValidateSchemaOrArrayOfSchema(JsonProperty property)
        {
            ValidateSchemaOrArrayOfSchema(property.Value);
        }

        private static void ValidateSchemaOrArrayOfSchema(JsonElement property)
        {
            if (property.ValueKind != JsonValueKind.Object && property.ValueKind != JsonValueKind.True && property.ValueKind != JsonValueKind.False && property.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Unsuppported schema or array of schema: {property.ValueKind}.");
            }
        }

        private static void ValidateSchemaArray(JsonProperty properties)
        {
            ValidateSchemaArray(properties.Value);
        }

        private static void ValidateSchemaArray(JsonElement properties)
        {
            if (properties.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Unsuppported schema array: {properties.ValueKind}.");
            }
        }

        private static void ValidateSchema(JsonProperty property)
        {
            ValidateSchema(property.Value);
        }

        private static void ValidateSchema(JsonElement property)
        {
            if (property.ValueKind != JsonValueKind.Object && property.ValueKind != JsonValueKind.True && property.ValueKind != JsonValueKind.False)
            {
                throw new InvalidOperationException($"Unsuppported property: {property.ValueKind}.");
            }
        }

        private static void ValidateDollarRef(JsonProperty dollarref)
        {
            ValidateDollarRef(dollarref.Value);
        }

        private static void ValidateDollarRef(JsonElement dollarref)
        {
            if (dollarref.ValueKind != JsonValueKind.String)
            {
                throw new InvalidOperationException($"Unsuppported $ref: {dollarref.ValueKind}.");
            }
        }

        private static void ValidateDollarRecursiveRef(JsonProperty dollarref)
        {
            ValidateDollarRecursiveRef(dollarref.Value);
        }

        private static void ValidateDollarRecursiveRef(JsonElement dollarrecursiveref)
        {
            if (dollarrecursiveref.ValueKind != JsonValueKind.String)
            {
                throw new InvalidOperationException($"Unsuppported $recursiveRef: {dollarrecursiveref.ValueKind}.");
            }
        }

        private static void ValidateDollarAnchor(JsonProperty dollaranchor)
        {
            ValidateDollarAnchor(dollaranchor.Value);
        }

        private static void ValidateDollarAnchor(JsonElement dollaranchor)
        {
            if (dollaranchor.ValueKind != JsonValueKind.String)
            {
                throw new InvalidOperationException($"Unsuppported $anchor: {dollaranchor.ValueKind}");
            }
        }

        private static void ValidateDollarId(JsonProperty dollarid)
        {
            ValidateDollarId(dollarid.Value);
        }

        private static void ValidateDollarId(JsonElement dollarid)
        {
            if (dollarid.ValueKind != JsonValueKind.String)
            {
                throw new InvalidOperationException($"Unsuppported $id: {dollarid.ValueKind}");
            }
        }

        private static void ValidateDollarSchema(JsonProperty dollarschema)
        {
            ValidateDollarSchema(dollarschema.Value);
        }

        private static void ValidateDollarSchema(JsonElement dollarschema)
        {
            if (dollarschema.ValueKind != JsonValueKind.String)
            {
                throw new InvalidOperationException($"Unsuppported $schema: {dollarschema.ValueKind}");
            }

            if (!dollarschema.ValueEquals("https://json-schema.org/draft/2019-09/schema"))
            {
                throw new InvalidOperationException($"Unsuppported $schema: {dollarschema.GetString()}");
            }
        }
    }
}
