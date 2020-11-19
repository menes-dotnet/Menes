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
        private static void ValidateBoolean(JsonElement boolean)
        {
            if (boolean.ValueKind != JsonValueKind.True && boolean.ValueKind != JsonValueKind.False)
            {
                throw new InvalidOperationException($"Unsuppported boolean: {boolean.ValueKind}.");
            }
        }

        private static void ValidateNumber(JsonElement number)
        {
            if (number.ValueKind != JsonValueKind.Number)
            {
                throw new InvalidOperationException($"Unsuppported positive integer: {number.ValueKind}.");
            }
        }

        private static void ValidateArray(JsonElement array)
        {
            if (array.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Unsuppported array: {array.ValueKind}.");
            }
        }

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

        private static void ValidateObject(JsonProperty properties)
        {
            ValidateObject(properties.Value);
        }

        private static void ValidateObject(JsonElement properties)
        {
            if (properties.ValueKind != JsonValueKind.Object)
            {
                throw new InvalidOperationException($"Unsuppported object: {properties.ValueKind}.");
            }
        }

        private static void ValidateStringOrArray(JsonProperty property)
        {
            ValidateStringOrArray(property.Value);
        }

        private static void ValidateStringOrArray(JsonElement property)
        {
            if (property.ValueKind != JsonValueKind.String && property.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Unsuppported string or array: {property.ValueKind}.");
            }
        }

        private static void ValidateString(JsonProperty property)
        {
            ValidateString(property.Value);
        }

        private static void ValidateString(JsonElement property)
        {
            if (property.ValueKind != JsonValueKind.String)
            {
                throw new InvalidOperationException($"Unsuppported string: {property.ValueKind}.");
            }
        }

        private static string ValidateTypeString(JsonElement property)
        {
            if (property.ValueKind != JsonValueKind.String)
            {
                throw new InvalidOperationException($"Unsuppported type string: {property.ValueKind}.");
            }

            string typeString = property.GetString();
            if (typeString == "null" || typeString == "boolean" || typeString == "object" ||
                typeString == "array" || typeString == "number" || typeString == "string" || typeString == "integer")
            {
                return typeString;
            }

            throw new InvalidOperationException($"Unsuppported type string value: '{typeString}'.");
        }

        private static string GetTypeStringForValueKind(JsonElement property)
        {
            return property.ValueKind switch
            {
                JsonValueKind.Array => "array",
                JsonValueKind.False => "boolean",
                JsonValueKind.True => "boolean",
                JsonValueKind.Null => "null",
                JsonValueKind.Number => "number",
                JsonValueKind.Object => "object",
                JsonValueKind.String => "string",
                _ => throw new InvalidOperationException($"Unsuppported type value: '{property.ValueKind}'.")
            };
        }

        private static void ValidateSchemaOrArray(JsonProperty property)
        {
            ValidateSchemaOrArray(property.Value);
        }

        private static void ValidateSchemaOrArray(JsonElement property)
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
                throw new InvalidOperationException($"Unsuppported schema: {property.ValueKind}.");
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
