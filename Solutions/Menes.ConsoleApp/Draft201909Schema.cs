// <copyright file="Draft201909Schema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Driver.GeneratedTypes
{
    public readonly struct Draft201909Schema : Menes.IJsonObject<Draft201909Schema>
    {
        public static readonly Draft201909Schema Null = default(Draft201909Schema);
        private static readonly System.ReadOnlyMemory<char> _MenesIdJsonPropertyName = System.MemoryExtensions.AsMemory("$id");
        private static readonly System.ReadOnlyMemory<char> _MenesSchemaJsonPropertyName = System.MemoryExtensions.AsMemory("$schema");
        private static readonly System.ReadOnlyMemory<char> _MenesAnchorJsonPropertyName = System.MemoryExtensions.AsMemory("$anchor");
        private static readonly System.ReadOnlyMemory<char> _MenesRefJsonPropertyName = System.MemoryExtensions.AsMemory("$ref");
        private static readonly System.ReadOnlyMemory<char> _MenesRecursiveRefJsonPropertyName = System.MemoryExtensions.AsMemory("$recursiveRef");
        private static readonly System.ReadOnlyMemory<char> _MenesRecursiveAnchorJsonPropertyName = System.MemoryExtensions.AsMemory("$recursiveAnchor");
        private static readonly System.ReadOnlyMemory<char> _MenesVocabularyJsonPropertyName = System.MemoryExtensions.AsMemory("$vocabulary");
        private static readonly System.ReadOnlyMemory<char> _MenesCommentJsonPropertyName = System.MemoryExtensions.AsMemory("$comment");
        private static readonly System.ReadOnlyMemory<char> _MenesDefsJsonPropertyName = System.MemoryExtensions.AsMemory("$defs");
        private static readonly System.ReadOnlyMemory<char> _MenesAdditionalItemsJsonPropertyName = System.MemoryExtensions.AsMemory("additionalItems");
        private static readonly System.ReadOnlyMemory<char> _MenesUnevaluatedItemsJsonPropertyName = System.MemoryExtensions.AsMemory("unevaluatedItems");
        private static readonly System.ReadOnlyMemory<char> _MenesItemsJsonPropertyName = System.MemoryExtensions.AsMemory("items");
        private static readonly System.ReadOnlyMemory<char> _MenesContainsJsonPropertyName = System.MemoryExtensions.AsMemory("contains");
        private static readonly System.ReadOnlyMemory<char> _MenesAdditionalPropertiesJsonPropertyName = System.MemoryExtensions.AsMemory("additionalProperties");
        private static readonly System.ReadOnlyMemory<char> _MenesUnevaluatedPropertiesJsonPropertyName = System.MemoryExtensions.AsMemory("unevaluatedProperties");
        private static readonly System.ReadOnlyMemory<char> _MenesPropertiesJsonPropertyName = System.MemoryExtensions.AsMemory("properties");
        private static readonly System.ReadOnlyMemory<char> _MenesPatternPropertiesJsonPropertyName = System.MemoryExtensions.AsMemory("patternProperties");
        private static readonly System.ReadOnlyMemory<char> _MenesDependentSchemasJsonPropertyName = System.MemoryExtensions.AsMemory("dependentSchemas");
        private static readonly System.ReadOnlyMemory<char> _MenesPropertyNamesJsonPropertyName = System.MemoryExtensions.AsMemory("propertyNames");
        private static readonly System.ReadOnlyMemory<char> _MenesIfJsonPropertyName = System.MemoryExtensions.AsMemory("if");
        private static readonly System.ReadOnlyMemory<char> _MenesThenJsonPropertyName = System.MemoryExtensions.AsMemory("then");
        private static readonly System.ReadOnlyMemory<char> _MenesElseJsonPropertyName = System.MemoryExtensions.AsMemory("else");
        private static readonly System.ReadOnlyMemory<char> _MenesAllOfJsonPropertyName = System.MemoryExtensions.AsMemory("allOf");
        private static readonly System.ReadOnlyMemory<char> _MenesAnyOfJsonPropertyName = System.MemoryExtensions.AsMemory("anyOf");
        private static readonly System.ReadOnlyMemory<char> _MenesOneOfJsonPropertyName = System.MemoryExtensions.AsMemory("oneOf");
        private static readonly System.ReadOnlyMemory<char> _MenesNotJsonPropertyName = System.MemoryExtensions.AsMemory("not");
        private static readonly System.ReadOnlyMemory<char> _MenesMultipleOfJsonPropertyName = System.MemoryExtensions.AsMemory("multipleOf");
        private static readonly System.ReadOnlyMemory<char> _MenesMaximumJsonPropertyName = System.MemoryExtensions.AsMemory("maximum");
        private static readonly System.ReadOnlyMemory<char> _MenesExclusiveMaximumJsonPropertyName = System.MemoryExtensions.AsMemory("exclusiveMaximum");
        private static readonly System.ReadOnlyMemory<char> _MenesMinimumJsonPropertyName = System.MemoryExtensions.AsMemory("minimum");
        private static readonly System.ReadOnlyMemory<char> _MenesExclusiveMinimumJsonPropertyName = System.MemoryExtensions.AsMemory("exclusiveMinimum");
        private static readonly System.ReadOnlyMemory<char> _MenesMaxLengthJsonPropertyName = System.MemoryExtensions.AsMemory("maxLength");
        private static readonly System.ReadOnlyMemory<char> _MenesMinLengthJsonPropertyName = System.MemoryExtensions.AsMemory("minLength");
        private static readonly System.ReadOnlyMemory<char> _MenesPatternJsonPropertyName = System.MemoryExtensions.AsMemory("pattern");
        private static readonly System.ReadOnlyMemory<char> _MenesMaxItemsJsonPropertyName = System.MemoryExtensions.AsMemory("maxItems");
        private static readonly System.ReadOnlyMemory<char> _MenesMinItemsJsonPropertyName = System.MemoryExtensions.AsMemory("minItems");
        private static readonly System.ReadOnlyMemory<char> _MenesUniqueItemsJsonPropertyName = System.MemoryExtensions.AsMemory("uniqueItems");
        private static readonly System.ReadOnlyMemory<char> _MenesMaxContainsJsonPropertyName = System.MemoryExtensions.AsMemory("maxContains");
        private static readonly System.ReadOnlyMemory<char> _MenesMinContainsJsonPropertyName = System.MemoryExtensions.AsMemory("minContains");
        private static readonly System.ReadOnlyMemory<char> _MenesMaxPropertiesJsonPropertyName = System.MemoryExtensions.AsMemory("maxProperties");
        private static readonly System.ReadOnlyMemory<char> _MenesMinPropertiesJsonPropertyName = System.MemoryExtensions.AsMemory("minProperties");
        private static readonly System.ReadOnlyMemory<char> _MenesRequiredJsonPropertyName = System.MemoryExtensions.AsMemory("required");
        private static readonly System.ReadOnlyMemory<char> _MenesDependentRequiredJsonPropertyName = System.MemoryExtensions.AsMemory("dependentRequired");
        private static readonly System.ReadOnlyMemory<char> _MenesConstJsonPropertyName = System.MemoryExtensions.AsMemory("const");
        private static readonly System.ReadOnlyMemory<char> _MenesEnumJsonPropertyName = System.MemoryExtensions.AsMemory("enum");
        private static readonly System.ReadOnlyMemory<char> _MenesTypeJsonPropertyName = System.MemoryExtensions.AsMemory("type");
        private static readonly System.ReadOnlyMemory<char> _MenesTitleJsonPropertyName = System.MemoryExtensions.AsMemory("title");
        private static readonly System.ReadOnlyMemory<char> _MenesDescriptionJsonPropertyName = System.MemoryExtensions.AsMemory("description");
        private static readonly System.ReadOnlyMemory<char> _MenesDefaultJsonPropertyName = System.MemoryExtensions.AsMemory("default");
        private static readonly System.ReadOnlyMemory<char> _MenesDeprecatedJsonPropertyName = System.MemoryExtensions.AsMemory("deprecated");
        private static readonly System.ReadOnlyMemory<char> _MenesReadOnlyJsonPropertyName = System.MemoryExtensions.AsMemory("readOnly");
        private static readonly System.ReadOnlyMemory<char> _MenesWriteOnlyJsonPropertyName = System.MemoryExtensions.AsMemory("writeOnly");
        private static readonly System.ReadOnlyMemory<char> _MenesExamplesJsonPropertyName = System.MemoryExtensions.AsMemory("examples");
        private static readonly System.ReadOnlyMemory<char> _MenesFormatJsonPropertyName = System.MemoryExtensions.AsMemory("format");
        private static readonly System.ReadOnlyMemory<char> _MenesContentMediaTypeJsonPropertyName = System.MemoryExtensions.AsMemory("contentMediaType");
        private static readonly System.ReadOnlyMemory<char> _MenesContentEncodingJsonPropertyName = System.MemoryExtensions.AsMemory("contentEncoding");
        private static readonly System.ReadOnlyMemory<char> _MenesContentSchemaJsonPropertyName = System.MemoryExtensions.AsMemory("contentSchema");
        private static readonly System.ReadOnlyMemory<char> _MenesDefinitionsJsonPropertyName = System.MemoryExtensions.AsMemory("definitions");
        private static readonly System.ReadOnlyMemory<char> _MenesDependenciesJsonPropertyName = System.MemoryExtensions.AsMemory("dependencies");
        private static readonly System.ReadOnlyMemory<byte> _MenesIdUtf8JsonPropertyName = new byte[] { 36, 105, 100 };
        private static readonly System.ReadOnlyMemory<byte> _MenesSchemaUtf8JsonPropertyName = new byte[] { 36, 115, 99, 104, 101, 109, 97 };
        private static readonly System.ReadOnlyMemory<byte> _MenesAnchorUtf8JsonPropertyName = new byte[] { 36, 97, 110, 99, 104, 111, 114 };
        private static readonly System.ReadOnlyMemory<byte> _MenesRefUtf8JsonPropertyName = new byte[] { 36, 114, 101, 102 };
        private static readonly System.ReadOnlyMemory<byte> _MenesRecursiveRefUtf8JsonPropertyName = new byte[] { 36, 114, 101, 99, 117, 114, 115, 105, 118, 101, 82, 101, 102 };
        private static readonly System.ReadOnlyMemory<byte> _MenesRecursiveAnchorUtf8JsonPropertyName = new byte[] { 36, 114, 101, 99, 117, 114, 115, 105, 118, 101, 65, 110, 99, 104, 111, 114 };
        private static readonly System.ReadOnlyMemory<byte> _MenesVocabularyUtf8JsonPropertyName = new byte[] { 36, 118, 111, 99, 97, 98, 117, 108, 97, 114, 121 };
        private static readonly System.ReadOnlyMemory<byte> _MenesCommentUtf8JsonPropertyName = new byte[] { 36, 99, 111, 109, 109, 101, 110, 116 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDefsUtf8JsonPropertyName = new byte[] { 36, 100, 101, 102, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesAdditionalItemsUtf8JsonPropertyName = new byte[] { 97, 100, 100, 105, 116, 105, 111, 110, 97, 108, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesUnevaluatedItemsUtf8JsonPropertyName = new byte[] { 117, 110, 101, 118, 97, 108, 117, 97, 116, 101, 100, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesItemsUtf8JsonPropertyName = new byte[] { 105, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesContainsUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 97, 105, 110, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesAdditionalPropertiesUtf8JsonPropertyName = new byte[] { 97, 100, 100, 105, 116, 105, 111, 110, 97, 108, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesUnevaluatedPropertiesUtf8JsonPropertyName = new byte[] { 117, 110, 101, 118, 97, 108, 117, 97, 116, 101, 100, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesPropertiesUtf8JsonPropertyName = new byte[] { 112, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesPatternPropertiesUtf8JsonPropertyName = new byte[] { 112, 97, 116, 116, 101, 114, 110, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDependentSchemasUtf8JsonPropertyName = new byte[] { 100, 101, 112, 101, 110, 100, 101, 110, 116, 83, 99, 104, 101, 109, 97, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesPropertyNamesUtf8JsonPropertyName = new byte[] { 112, 114, 111, 112, 101, 114, 116, 121, 78, 97, 109, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesIfUtf8JsonPropertyName = new byte[] { 105, 102 };
        private static readonly System.ReadOnlyMemory<byte> _MenesThenUtf8JsonPropertyName = new byte[] { 116, 104, 101, 110 };
        private static readonly System.ReadOnlyMemory<byte> _MenesElseUtf8JsonPropertyName = new byte[] { 101, 108, 115, 101 };
        private static readonly System.ReadOnlyMemory<byte> _MenesAllOfUtf8JsonPropertyName = new byte[] { 97, 108, 108, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> _MenesAnyOfUtf8JsonPropertyName = new byte[] { 97, 110, 121, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> _MenesOneOfUtf8JsonPropertyName = new byte[] { 111, 110, 101, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> _MenesNotUtf8JsonPropertyName = new byte[] { 110, 111, 116 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMultipleOfUtf8JsonPropertyName = new byte[] { 109, 117, 108, 116, 105, 112, 108, 101, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMaximumUtf8JsonPropertyName = new byte[] { 109, 97, 120, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> _MenesExclusiveMaximumUtf8JsonPropertyName = new byte[] { 101, 120, 99, 108, 117, 115, 105, 118, 101, 77, 97, 120, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMinimumUtf8JsonPropertyName = new byte[] { 109, 105, 110, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> _MenesExclusiveMinimumUtf8JsonPropertyName = new byte[] { 101, 120, 99, 108, 117, 115, 105, 118, 101, 77, 105, 110, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMaxLengthUtf8JsonPropertyName = new byte[] { 109, 97, 120, 76, 101, 110, 103, 116, 104 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMinLengthUtf8JsonPropertyName = new byte[] { 109, 105, 110, 76, 101, 110, 103, 116, 104 };
        private static readonly System.ReadOnlyMemory<byte> _MenesPatternUtf8JsonPropertyName = new byte[] { 112, 97, 116, 116, 101, 114, 110 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMaxItemsUtf8JsonPropertyName = new byte[] { 109, 97, 120, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMinItemsUtf8JsonPropertyName = new byte[] { 109, 105, 110, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesUniqueItemsUtf8JsonPropertyName = new byte[] { 117, 110, 105, 113, 117, 101, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMaxContainsUtf8JsonPropertyName = new byte[] { 109, 97, 120, 67, 111, 110, 116, 97, 105, 110, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMinContainsUtf8JsonPropertyName = new byte[] { 109, 105, 110, 67, 111, 110, 116, 97, 105, 110, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMaxPropertiesUtf8JsonPropertyName = new byte[] { 109, 97, 120, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesMinPropertiesUtf8JsonPropertyName = new byte[] { 109, 105, 110, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesRequiredUtf8JsonPropertyName = new byte[] { 114, 101, 113, 117, 105, 114, 101, 100 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDependentRequiredUtf8JsonPropertyName = new byte[] { 100, 101, 112, 101, 110, 100, 101, 110, 116, 82, 101, 113, 117, 105, 114, 101, 100 };
        private static readonly System.ReadOnlyMemory<byte> _MenesConstUtf8JsonPropertyName = new byte[] { 99, 111, 110, 115, 116 };
        private static readonly System.ReadOnlyMemory<byte> _MenesEnumUtf8JsonPropertyName = new byte[] { 101, 110, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> _MenesTypeUtf8JsonPropertyName = new byte[] { 116, 121, 112, 101 };
        private static readonly System.ReadOnlyMemory<byte> _MenesTitleUtf8JsonPropertyName = new byte[] { 116, 105, 116, 108, 101 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDescriptionUtf8JsonPropertyName = new byte[] { 100, 101, 115, 99, 114, 105, 112, 116, 105, 111, 110 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDefaultUtf8JsonPropertyName = new byte[] { 100, 101, 102, 97, 117, 108, 116 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDeprecatedUtf8JsonPropertyName = new byte[] { 100, 101, 112, 114, 101, 99, 97, 116, 101, 100 };
        private static readonly System.ReadOnlyMemory<byte> _MenesReadOnlyUtf8JsonPropertyName = new byte[] { 114, 101, 97, 100, 79, 110, 108, 121 };
        private static readonly System.ReadOnlyMemory<byte> _MenesWriteOnlyUtf8JsonPropertyName = new byte[] { 119, 114, 105, 116, 101, 79, 110, 108, 121 };
        private static readonly System.ReadOnlyMemory<byte> _MenesExamplesUtf8JsonPropertyName = new byte[] { 101, 120, 97, 109, 112, 108, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesFormatUtf8JsonPropertyName = new byte[] { 102, 111, 114, 109, 97, 116 };
        private static readonly System.ReadOnlyMemory<byte> _MenesContentMediaTypeUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 77, 101, 100, 105, 97, 84, 121, 112, 101 };
        private static readonly System.ReadOnlyMemory<byte> _MenesContentEncodingUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 69, 110, 99, 111, 100, 105, 110, 103 };
        private static readonly System.ReadOnlyMemory<byte> _MenesContentSchemaUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 83, 99, 104, 101, 109, 97 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDefinitionsUtf8JsonPropertyName = new byte[] { 100, 101, 102, 105, 110, 105, 116, 105, 111, 110, 115 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDependenciesUtf8JsonPropertyName = new byte[] { 100, 101, 112, 101, 110, 100, 101, 110, 99, 105, 101, 115 };
        private static readonly System.Text.Json.JsonEncodedText _MenesIdEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesIdUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesSchemaEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesSchemaUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesAnchorEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesAnchorUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesRefEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesRefUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesRecursiveRefEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesRecursiveRefUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesRecursiveAnchorEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesRecursiveAnchorUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesVocabularyEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesVocabularyUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesCommentEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesCommentUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDefsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDefsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesAdditionalItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesAdditionalItemsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesUnevaluatedItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesUnevaluatedItemsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesItemsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesContainsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContainsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesAdditionalPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesAdditionalPropertiesUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesUnevaluatedPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesUnevaluatedPropertiesUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesPropertiesUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesPatternPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesPatternPropertiesUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDependentSchemasEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDependentSchemasUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesPropertyNamesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesPropertyNamesUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesIfEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesIfUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesThenEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesThenUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesElseEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesElseUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesAllOfEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesAllOfUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesAnyOfEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesAnyOfUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesOneOfEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesOneOfUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesNotEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesNotUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMultipleOfEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMultipleOfUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMaximumEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMaximumUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesExclusiveMaximumEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesExclusiveMaximumUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMinimumEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMinimumUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesExclusiveMinimumEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesExclusiveMinimumUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMaxLengthEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMaxLengthUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMinLengthEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMinLengthUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesPatternEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesPatternUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMaxItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMaxItemsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMinItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMinItemsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesUniqueItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesUniqueItemsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMaxContainsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMaxContainsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMinContainsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMinContainsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMaxPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMaxPropertiesUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesMinPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMinPropertiesUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesRequiredEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesRequiredUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDependentRequiredEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDependentRequiredUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesConstEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesConstUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesEnumEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesEnumUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesTypeEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesTypeUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesTitleEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesTitleUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDescriptionEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDescriptionUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDefaultEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDefaultUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDeprecatedEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDeprecatedUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesReadOnlyEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesReadOnlyUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesWriteOnlyEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesWriteOnlyUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesExamplesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesExamplesUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesFormatEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFormatUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesContentMediaTypeEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContentMediaTypeUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesContentEncodingEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContentEncodingUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesContentSchemaEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContentSchemaUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDefinitionsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDefinitionsUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDependenciesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDependenciesUtf8JsonPropertyName.Span);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
        private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
        private readonly Draft201909MetaCore.IdValue? id;
        private readonly Menes.JsonUri? schema;
        private readonly Draft201909MetaCore.AnchorValue? anchor;
        private readonly Menes.JsonUriReference? @ref;
        private readonly Menes.JsonUriReference? recursiveRef;
        private readonly Menes.JsonBoolean? recursiveAnchor;
        private readonly Draft201909MetaCore.VocabularyEntity? vocabulary;
        private readonly Menes.JsonString? comment;
        private readonly Draft201909MetaCore.DefsEntity? defs;
        private readonly Draft201909MetaApplicator? additionalItems;
        private readonly Draft201909MetaApplicator? unevaluatedItems;
        private readonly Draft201909MetaApplicator.ItemsEntity? items;
        private readonly Draft201909MetaApplicator? contains;
        private readonly Draft201909MetaApplicator? additionalProperties;
        private readonly Draft201909MetaApplicator? unevaluatedProperties;
        private readonly Draft201909MetaApplicator.PropertiesEntity? properties;
        private readonly Draft201909MetaApplicator.PatternPropertiesEntity? patternProperties;
        private readonly Draft201909MetaApplicator.DependentSchemasEntity? dependentSchemas;
        private readonly Draft201909MetaApplicator? propertyNames;
        private readonly Draft201909MetaApplicator? @if;
        private readonly Draft201909MetaApplicator? then;
        private readonly Draft201909MetaApplicator? @else;
        private readonly Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? allOf;
        private readonly Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? anyOf;
        private readonly Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? oneOf;
        private readonly Draft201909MetaApplicator? not;
        private readonly Draft201909MetaValidation.MultipleOfValue? multipleOf;
        private readonly Menes.JsonNumber? maximum;
        private readonly Menes.JsonNumber? exclusiveMaximum;
        private readonly Menes.JsonNumber? minimum;
        private readonly Menes.JsonNumber? exclusiveMinimum;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxLength;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minLength;
        private readonly Menes.JsonRegex? pattern;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxItems;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minItems;
        private readonly Menes.JsonBoolean? uniqueItems;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxContains;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minContains;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxProperties;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minProperties;
        private readonly Draft201909MetaValidation.StringArrayEntity? required;
        private readonly Draft201909MetaValidation.DependentRequiredEntity? dependentRequired;
        private readonly Menes.JsonAny? @const;
        private readonly Draft201909MetaValidation.EnumArray? @enum;
        private readonly Draft201909MetaValidation.TypeEntity? type;
        private readonly Menes.JsonString? title;
        private readonly Menes.JsonString? description;
        private readonly Menes.JsonAny? @default;
        private readonly Menes.JsonBoolean? deprecated;
        private readonly Menes.JsonBoolean? readOnly;
        private readonly Menes.JsonBoolean? writeOnly;
        private readonly Draft201909MetaMetaData.ExamplesArray? examples;
        private readonly Menes.JsonString? format;
        private readonly Menes.JsonString? contentMediaType;
        private readonly Menes.JsonString? contentEncoding;
        private readonly Draft201909MetaContent? contentSchema;
        private readonly Menes.JsonValueBacking definitions;
        private readonly Draft201909Schema.DependenciesEntity? dependencies;
        public Draft201909Schema(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
            this.id = default;
            this.schema = default;
            this.anchor = default;
            this.@ref = default;
            this.recursiveRef = default;
            this.recursiveAnchor = default;
            this.vocabulary = default;
            this.comment = default;
            this.defs = default;
            this.additionalItems = default;
            this.unevaluatedItems = default;
            this.items = default;
            this.contains = default;
            this.additionalProperties = default;
            this.unevaluatedProperties = default;
            this.properties = default;
            this.patternProperties = default;
            this.dependentSchemas = default;
            this.propertyNames = default;
            this.@if = default;
            this.then = default;
            this.@else = default;
            this.allOf = default;
            this.anyOf = default;
            this.oneOf = default;
            this.not = default;
            this.multipleOf = default;
            this.maximum = default;
            this.exclusiveMaximum = default;
            this.minimum = default;
            this.exclusiveMinimum = default;
            this.maxLength = default;
            this.minLength = default;
            this.pattern = default;
            this.maxItems = default;
            this.minItems = default;
            this.uniqueItems = default;
            this.maxContains = default;
            this.minContains = default;
            this.maxProperties = default;
            this.minProperties = default;
            this.required = default;
            this.dependentRequired = default;
            this.@const = default;
            this.@enum = default;
            this.type = default;
            this.title = default;
            this.description = default;
            this.@default = default;
            this.deprecated = default;
            this.readOnly = default;
            this.writeOnly = default;
            this.examples = default;
            this.format = default;
            this.contentMediaType = default;
            this.contentEncoding = default;
            this.contentSchema = default;
            this.definitions = default;
            this.dependencies = default;
        }
        public Draft201909Schema(Draft201909MetaCore.IdValue? id = null, Menes.JsonUri? schema = null, Draft201909MetaCore.AnchorValue? anchor = null, Menes.JsonUriReference? @ref = null, Menes.JsonUriReference? recursiveRef = null, Menes.JsonBoolean? recursiveAnchor = null, Draft201909MetaCore.VocabularyEntity? vocabulary = null, Menes.JsonString? comment = null, Draft201909MetaCore.DefsEntity? defs = null, Draft201909MetaApplicator? additionalItems = null, Draft201909MetaApplicator? unevaluatedItems = null, Draft201909MetaApplicator.ItemsEntity? items = null, Draft201909MetaApplicator? contains = null, Draft201909MetaApplicator? additionalProperties = null, Draft201909MetaApplicator? unevaluatedProperties = null, Draft201909MetaApplicator.PropertiesEntity? properties = null, Draft201909MetaApplicator.PatternPropertiesEntity? patternProperties = null, Draft201909MetaApplicator.DependentSchemasEntity? dependentSchemas = null, Draft201909MetaApplicator? propertyNames = null, Draft201909MetaApplicator? @if = null, Draft201909MetaApplicator? then = null, Draft201909MetaApplicator? @else = null, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? allOf = null, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? anyOf = null, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? oneOf = null, Draft201909MetaApplicator? not = null, Draft201909MetaValidation.MultipleOfValue? multipleOf = null, Menes.JsonNumber? maximum = null, Menes.JsonNumber? exclusiveMaximum = null, Menes.JsonNumber? minimum = null, Menes.JsonNumber? exclusiveMinimum = null, Draft201909MetaValidation.NonNegativeIntegerValue? maxLength = null, Draft201909MetaValidation.NonNegativeIntegerValue? minLength = null, Menes.JsonRegex? pattern = null, Draft201909MetaValidation.NonNegativeIntegerValue? maxItems = null, Draft201909MetaValidation.NonNegativeIntegerValue? minItems = null, Menes.JsonBoolean? uniqueItems = null, Draft201909MetaValidation.NonNegativeIntegerValue? maxContains = null, Draft201909MetaValidation.NonNegativeIntegerValue? minContains = null, Draft201909MetaValidation.NonNegativeIntegerValue? maxProperties = null, Draft201909MetaValidation.NonNegativeIntegerValue? minProperties = null, Draft201909MetaValidation.StringArrayEntity? required = null, Draft201909MetaValidation.DependentRequiredEntity? dependentRequired = null, Menes.JsonAny? @const = null, Draft201909MetaValidation.EnumArray? @enum = null, Draft201909MetaValidation.TypeEntity? type = null, Menes.JsonString? title = null, Menes.JsonString? description = null, Menes.JsonAny? @default = null, Menes.JsonBoolean? deprecated = null, Menes.JsonBoolean? readOnly = null, Menes.JsonBoolean? writeOnly = null, Draft201909MetaMetaData.ExamplesArray? examples = null, Menes.JsonString? format = null, Menes.JsonString? contentMediaType = null, Menes.JsonString? contentEncoding = null, Draft201909MetaContent? contentSchema = null, Draft201909Schema.DefinitionsEntity? definitions = null, Draft201909Schema.DependenciesEntity? dependencies = null)
        {
            this._menesJsonElementBacking = default;
            this.id = id;
            this.schema = schema;
            this.anchor = anchor;
            this.@ref = @ref;
            this.recursiveRef = recursiveRef;
            this.recursiveAnchor = recursiveAnchor;
            this.vocabulary = vocabulary;
            this.comment = comment;
            this.defs = defs;
            this.additionalItems = additionalItems;
            this.unevaluatedItems = unevaluatedItems;
            this.items = items;
            this.contains = contains;
            this.additionalProperties = additionalProperties;
            this.unevaluatedProperties = unevaluatedProperties;
            this.properties = properties;
            this.patternProperties = patternProperties;
            this.dependentSchemas = dependentSchemas;
            this.propertyNames = propertyNames;
            this.@if = @if;
            this.then = then;
            this.@else = @else;
            this.allOf = allOf;
            this.anyOf = anyOf;
            this.oneOf = oneOf;
            this.not = not;
            this.multipleOf = multipleOf;
            this.maximum = maximum;
            this.exclusiveMaximum = exclusiveMaximum;
            this.minimum = minimum;
            this.exclusiveMinimum = exclusiveMinimum;
            this.maxLength = maxLength;
            this.minLength = minLength;
            this.pattern = pattern;
            this.maxItems = maxItems;
            this.minItems = minItems;
            this.uniqueItems = uniqueItems;
            this.maxContains = maxContains;
            this.minContains = minContains;
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            this.required = required;
            this.dependentRequired = dependentRequired;
            this.@const = @const;
            this.@enum = @enum;
            this.type = type;
            this.title = title;
            this.description = description;
            this.@default = @default;
            this.deprecated = deprecated;
            this.readOnly = readOnly;
            this.writeOnly = writeOnly;
            this.examples = examples;
            this.format = format;
            this.contentMediaType = contentMediaType;
            this.contentEncoding = contentEncoding;
            this.contentSchema = contentSchema;
            this.definitions = Menes.JsonValueBacking.From<Draft201909Schema.DefinitionsEntity>(definitions);
            this.dependencies = dependencies;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
        }
        public Draft201909Schema(Menes.JsonBoolean value)
        {
            this._menesJsonElementBacking = default;
            this._menesBooleanTypeBacking = value;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this.id = default;
            this.schema = default;
            this.anchor = default;
            this.@ref = default;
            this.recursiveRef = default;
            this.recursiveAnchor = default;
            this.vocabulary = default;
            this.comment = default;
            this.defs = default;
            this.additionalItems = default;
            this.unevaluatedItems = default;
            this.items = default;
            this.contains = default;
            this.additionalProperties = default;
            this.unevaluatedProperties = default;
            this.properties = default;
            this.patternProperties = default;
            this.dependentSchemas = default;
            this.propertyNames = default;
            this.@if = default;
            this.then = default;
            this.@else = default;
            this.allOf = default;
            this.anyOf = default;
            this.oneOf = default;
            this.not = default;
            this.multipleOf = default;
            this.maximum = default;
            this.exclusiveMaximum = default;
            this.minimum = default;
            this.exclusiveMinimum = default;
            this.maxLength = default;
            this.minLength = default;
            this.pattern = default;
            this.maxItems = default;
            this.minItems = default;
            this.uniqueItems = default;
            this.maxContains = default;
            this.minContains = default;
            this.maxProperties = default;
            this.minProperties = default;
            this.required = default;
            this.dependentRequired = default;
            this.@const = default;
            this.@enum = default;
            this.type = default;
            this.title = default;
            this.description = default;
            this.@default = default;
            this.deprecated = default;
            this.readOnly = default;
            this.writeOnly = default;
            this.examples = default;
            this.format = default;
            this.contentMediaType = default;
            this.contentEncoding = default;
            this.contentSchema = default;
            this.definitions = default;
            this.dependencies = default;
        }
        private Draft201909Schema(Draft201909MetaCore.IdValue? id, Menes.JsonUri? schema, Draft201909MetaCore.AnchorValue? anchor, Menes.JsonUriReference? @ref, Menes.JsonUriReference? recursiveRef, Menes.JsonBoolean? recursiveAnchor, Draft201909MetaCore.VocabularyEntity? vocabulary, Menes.JsonString? comment, Draft201909MetaCore.DefsEntity? defs, Draft201909MetaApplicator? additionalItems, Draft201909MetaApplicator? unevaluatedItems, Draft201909MetaApplicator.ItemsEntity? items, Draft201909MetaApplicator? contains, Draft201909MetaApplicator? additionalProperties, Draft201909MetaApplicator? unevaluatedProperties, Draft201909MetaApplicator.PropertiesEntity? properties, Draft201909MetaApplicator.PatternPropertiesEntity? patternProperties, Draft201909MetaApplicator.DependentSchemasEntity? dependentSchemas, Draft201909MetaApplicator? propertyNames, Draft201909MetaApplicator? @if, Draft201909MetaApplicator? then, Draft201909MetaApplicator? @else, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? allOf, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? anyOf, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? oneOf, Draft201909MetaApplicator? not, Draft201909MetaValidation.MultipleOfValue? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, Draft201909MetaValidation.NonNegativeIntegerValue? maxLength, Draft201909MetaValidation.NonNegativeIntegerValue? minLength, Menes.JsonRegex? pattern, Draft201909MetaValidation.NonNegativeIntegerValue? maxItems, Draft201909MetaValidation.NonNegativeIntegerValue? minItems, Menes.JsonBoolean? uniqueItems, Draft201909MetaValidation.NonNegativeIntegerValue? maxContains, Draft201909MetaValidation.NonNegativeIntegerValue? minContains, Draft201909MetaValidation.NonNegativeIntegerValue? maxProperties, Draft201909MetaValidation.NonNegativeIntegerValue? minProperties, Draft201909MetaValidation.StringArrayEntity? required, Draft201909MetaValidation.DependentRequiredEntity? dependentRequired, Menes.JsonAny? @const, Draft201909MetaValidation.EnumArray? @enum, Draft201909MetaValidation.TypeEntity? type, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonAny? @default, Menes.JsonBoolean? deprecated, Menes.JsonBoolean? readOnly, Menes.JsonBoolean? writeOnly, Draft201909MetaMetaData.ExamplesArray? examples, Menes.JsonString? format, Menes.JsonString? contentMediaType, Menes.JsonString? contentEncoding, Draft201909MetaContent? contentSchema, Menes.JsonValueBacking definitions, Draft201909Schema.DependenciesEntity? dependencies, Menes.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
        {
            this._menesJsonElementBacking = default;
            this.id = id;
            this.schema = schema;
            this.anchor = anchor;
            this.@ref = @ref;
            this.recursiveRef = recursiveRef;
            this.recursiveAnchor = recursiveAnchor;
            this.vocabulary = vocabulary;
            this.comment = comment;
            this.defs = defs;
            this.additionalItems = additionalItems;
            this.unevaluatedItems = unevaluatedItems;
            this.items = items;
            this.contains = contains;
            this.additionalProperties = additionalProperties;
            this.unevaluatedProperties = unevaluatedProperties;
            this.properties = properties;
            this.patternProperties = patternProperties;
            this.dependentSchemas = dependentSchemas;
            this.propertyNames = propertyNames;
            this.@if = @if;
            this.then = then;
            this.@else = @else;
            this.allOf = allOf;
            this.anyOf = anyOf;
            this.oneOf = oneOf;
            this.not = not;
            this.multipleOf = multipleOf;
            this.maximum = maximum;
            this.exclusiveMaximum = exclusiveMaximum;
            this.minimum = minimum;
            this.exclusiveMinimum = exclusiveMinimum;
            this.maxLength = maxLength;
            this.minLength = minLength;
            this.pattern = pattern;
            this.maxItems = maxItems;
            this.minItems = minItems;
            this.uniqueItems = uniqueItems;
            this.maxContains = maxContains;
            this.minContains = minContains;
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            this.required = required;
            this.dependentRequired = dependentRequired;
            this.@const = @const;
            this.@enum = @enum;
            this.type = type;
            this.title = title;
            this.description = description;
            this.@default = @default;
            this.deprecated = deprecated;
            this.readOnly = readOnly;
            this.writeOnly = writeOnly;
            this.examples = examples;
            this.format = format;
            this.contentMediaType = contentMediaType;
            this.contentEncoding = contentEncoding;
            this.contentSchema = contentSchema;
            this.definitions = definitions;
            this.dependencies = dependencies;
            this._menesBooleanTypeBacking = _menesBooleanTypeBacking;
            this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
        }
        public static implicit operator Menes.JsonBoolean(Draft201909Schema value)
        {
            return value.As<Menes.JsonBoolean>();
        }
        public static implicit operator Draft201909Schema(Menes.JsonBoolean value)
        {
            return value.As<Draft201909Schema>();
        }
        public static implicit operator bool(Draft201909Schema value)
        {
            return (bool)(Menes.JsonBoolean)value;
        }
        public static implicit operator Draft201909Schema(bool value)
        {
            return (Draft201909Schema)(Menes.JsonBoolean)value;
        }
        public static implicit operator Draft201909MetaCore(Draft201909Schema value)
        {
            return value.As<Draft201909MetaCore>();
        }
        public static implicit operator Draft201909Schema(Draft201909MetaCore value)
        {
            return value.As<Draft201909Schema>();
        }
        public static implicit operator Draft201909MetaApplicator(Draft201909Schema value)
        {
            return value.As<Draft201909MetaApplicator>();
        }
        public static implicit operator Draft201909Schema(Draft201909MetaApplicator value)
        {
            return value.As<Draft201909Schema>();
        }
        public static implicit operator Draft201909MetaValidation(Draft201909Schema value)
        {
            return value.As<Draft201909MetaValidation>();
        }
        public static implicit operator Draft201909Schema(Draft201909MetaValidation value)
        {
            return value.As<Draft201909Schema>();
        }
        public static implicit operator Draft201909MetaMetaData(Draft201909Schema value)
        {
            return value.As<Draft201909MetaMetaData>();
        }
        public static implicit operator Draft201909Schema(Draft201909MetaMetaData value)
        {
            return value.As<Draft201909Schema>();
        }
        public static implicit operator Draft201909MetaFormat(Draft201909Schema value)
        {
            return value.As<Draft201909MetaFormat>();
        }
        public static implicit operator Draft201909Schema(Draft201909MetaFormat value)
        {
            return value.As<Draft201909Schema>();
        }
        public static implicit operator Draft201909MetaContent(Draft201909Schema value)
        {
            return value.As<Draft201909MetaContent>();
        }
        public static implicit operator Draft201909Schema(Draft201909MetaContent value)
        {
            return value.As<Draft201909Schema>();
        }
        /// <inheritdoc />
        public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
        /// <inheritdoc />
        public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
        /// <inheritdoc />
        public bool IsNumber => false;
        /// <inheritdoc />
        public bool IsInteger => false;
        /// <inheritdoc />
        public bool IsString => false;
        /// <inheritdoc />
        public bool IsObject => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object) || (!this.HasJsonElement && !this.AllBackingFieldsAreNull());
        /// <inheritdoc />
        public bool IsBoolean => (this.HasJsonElement && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.True || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.False)) || (!this.HasJsonElement && _menesBooleanTypeBacking is not null);
        /// <inheritdoc />
        public bool IsArray => false;
        /// <inheritdoc />
        public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        /// <inheritdoc />
        public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
        public Draft201909MetaCore.IdValue? Id => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.IdValue>(_MenesIdUtf8JsonPropertyName.Span) : this.id;
        public Menes.JsonUri? Schema => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonUri>(_MenesSchemaUtf8JsonPropertyName.Span) : this.schema;
        public Draft201909MetaCore.AnchorValue? Anchor => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.AnchorValue>(_MenesAnchorUtf8JsonPropertyName.Span) : this.anchor;
        public Menes.JsonUriReference? Ref => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonUriReference>(_MenesRefUtf8JsonPropertyName.Span) : this.@ref;
        public Menes.JsonUriReference? RecursiveRef => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonUriReference>(_MenesRecursiveRefUtf8JsonPropertyName.Span) : this.recursiveRef;
        public Menes.JsonBoolean? RecursiveAnchor => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonBoolean>(_MenesRecursiveAnchorUtf8JsonPropertyName.Span) : this.recursiveAnchor;
        public Draft201909MetaCore.VocabularyEntity? Vocabulary => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.VocabularyEntity>(_MenesVocabularyUtf8JsonPropertyName.Span) : this.vocabulary;
        public Menes.JsonString? Comment => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesCommentUtf8JsonPropertyName.Span) : this.comment;
        public Draft201909MetaCore.DefsEntity? Defs => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.DefsEntity>(_MenesDefsUtf8JsonPropertyName.Span) : this.defs;
        public Draft201909MetaApplicator? AdditionalItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesAdditionalItemsUtf8JsonPropertyName.Span) : this.additionalItems;
        public Draft201909MetaApplicator? UnevaluatedItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesUnevaluatedItemsUtf8JsonPropertyName.Span) : this.unevaluatedItems;
        public Draft201909MetaApplicator.ItemsEntity? Items => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity>(_MenesItemsUtf8JsonPropertyName.Span) : this.items;
        public Draft201909MetaApplicator? Contains => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesContainsUtf8JsonPropertyName.Span) : this.contains;
        public Draft201909MetaApplicator? AdditionalProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesAdditionalPropertiesUtf8JsonPropertyName.Span) : this.additionalProperties;
        public Draft201909MetaApplicator? UnevaluatedProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesUnevaluatedPropertiesUtf8JsonPropertyName.Span) : this.unevaluatedProperties;
        public Draft201909MetaApplicator.PropertiesEntity? Properties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.PropertiesEntity>(_MenesPropertiesUtf8JsonPropertyName.Span) : this.properties;
        public Draft201909MetaApplicator.PatternPropertiesEntity? PatternProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.PatternPropertiesEntity>(_MenesPatternPropertiesUtf8JsonPropertyName.Span) : this.patternProperties;
        public Draft201909MetaApplicator.DependentSchemasEntity? DependentSchemas => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.DependentSchemasEntity>(_MenesDependentSchemasUtf8JsonPropertyName.Span) : this.dependentSchemas;
        public Draft201909MetaApplicator? PropertyNames => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesPropertyNamesUtf8JsonPropertyName.Span) : this.propertyNames;
        public Draft201909MetaApplicator? If => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesIfUtf8JsonPropertyName.Span) : this.@if;
        public Draft201909MetaApplicator? Then => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesThenUtf8JsonPropertyName.Span) : this.then;
        public Draft201909MetaApplicator? Else => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesElseUtf8JsonPropertyName.Span) : this.@else;
        public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? AllOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesAllOfUtf8JsonPropertyName.Span) : this.allOf;
        public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? AnyOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesAnyOfUtf8JsonPropertyName.Span) : this.anyOf;
        public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? OneOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesOneOfUtf8JsonPropertyName.Span) : this.oneOf;
        public Draft201909MetaApplicator? Not => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesNotUtf8JsonPropertyName.Span) : this.not;
        public Draft201909MetaValidation.MultipleOfValue? MultipleOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.MultipleOfValue>(_MenesMultipleOfUtf8JsonPropertyName.Span) : this.multipleOf;
        public Menes.JsonNumber? Maximum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonNumber>(_MenesMaximumUtf8JsonPropertyName.Span) : this.maximum;
        public Menes.JsonNumber? ExclusiveMaximum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonNumber>(_MenesExclusiveMaximumUtf8JsonPropertyName.Span) : this.exclusiveMaximum;
        public Menes.JsonNumber? Minimum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonNumber>(_MenesMinimumUtf8JsonPropertyName.Span) : this.minimum;
        public Menes.JsonNumber? ExclusiveMinimum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonNumber>(_MenesExclusiveMinimumUtf8JsonPropertyName.Span) : this.exclusiveMinimum;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MaxLength => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxLengthUtf8JsonPropertyName.Span) : this.maxLength;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MinLength => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinLengthUtf8JsonPropertyName.Span) : this.minLength;
        public Menes.JsonRegex? Pattern => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonRegex>(_MenesPatternUtf8JsonPropertyName.Span) : this.pattern;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MaxItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxItemsUtf8JsonPropertyName.Span) : this.maxItems;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MinItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinItemsUtf8JsonPropertyName.Span) : this.minItems;
        public Menes.JsonBoolean? UniqueItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonBoolean>(_MenesUniqueItemsUtf8JsonPropertyName.Span) : this.uniqueItems;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MaxContains => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxContainsUtf8JsonPropertyName.Span) : this.maxContains;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MinContains => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinContainsUtf8JsonPropertyName.Span) : this.minContains;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MaxProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxPropertiesUtf8JsonPropertyName.Span) : this.maxProperties;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MinProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinPropertiesUtf8JsonPropertyName.Span) : this.minProperties;
        public Draft201909MetaValidation.StringArrayEntity? Required => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.StringArrayEntity>(_MenesRequiredUtf8JsonPropertyName.Span) : this.required;
        public Draft201909MetaValidation.DependentRequiredEntity? DependentRequired => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.DependentRequiredEntity>(_MenesDependentRequiredUtf8JsonPropertyName.Span) : this.dependentRequired;
        public Menes.JsonAny? Const => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonAny>(_MenesConstUtf8JsonPropertyName.Span) : this.@const;
        public Draft201909MetaValidation.EnumArray? Enum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.EnumArray>(_MenesEnumUtf8JsonPropertyName.Span) : this.@enum;
        public Draft201909MetaValidation.TypeEntity? Type => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.TypeEntity>(_MenesTypeUtf8JsonPropertyName.Span) : this.type;
        public Menes.JsonString? Title => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesTitleUtf8JsonPropertyName.Span) : this.title;
        public Menes.JsonString? Description => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesDescriptionUtf8JsonPropertyName.Span) : this.description;
        public Menes.JsonAny? Default => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonAny>(_MenesDefaultUtf8JsonPropertyName.Span) : this.@default;
        public Menes.JsonBoolean? Deprecated => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonBoolean>(_MenesDeprecatedUtf8JsonPropertyName.Span) : this.deprecated;
        public Menes.JsonBoolean? ReadOnly => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonBoolean>(_MenesReadOnlyUtf8JsonPropertyName.Span) : this.readOnly;
        public Menes.JsonBoolean? WriteOnly => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonBoolean>(_MenesWriteOnlyUtf8JsonPropertyName.Span) : this.writeOnly;
        public Draft201909MetaMetaData.ExamplesArray? Examples => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaMetaData.ExamplesArray>(_MenesExamplesUtf8JsonPropertyName.Span) : this.examples;
        public Menes.JsonString? Format => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesFormatUtf8JsonPropertyName.Span) : this.format;
        public Menes.JsonString? ContentMediaType => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesContentMediaTypeUtf8JsonPropertyName.Span) : this.contentMediaType;
        public Menes.JsonString? ContentEncoding => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesContentEncodingUtf8JsonPropertyName.Span) : this.contentEncoding;
        public Draft201909MetaContent? ContentSchema => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaContent>(_MenesContentSchemaUtf8JsonPropertyName.Span) : this.contentSchema;
        public Draft201909Schema.DefinitionsEntity? Definitions => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema.DefinitionsEntity>(_MenesDefinitionsUtf8JsonPropertyName.Span) : this.definitions.As<Draft201909Schema.DefinitionsEntity>();
        public Draft201909Schema.DependenciesEntity? Dependencies => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema.DependenciesEntity>(_MenesDependenciesUtf8JsonPropertyName.Span) : this.dependencies;
        public int PropertyCount
        {
            get
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        jsonPropertyIndex++;
                    }
                    return jsonPropertyIndex;
                }
                else
                {
                    return 59 + this._menesAdditionalPropertiesBacking.Length;
                }
            }
        }
        /// <inheritdoc />
        public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
        {
            evaluatedProperties = evaluatedProperties ?? new System.Collections.Generic.HashSet<string>();
            var composedEvaluatedProperties = new System.Collections.Generic.HashSet<string>();
            var composedEvaluatedIndices = new System.Collections.Generic.HashSet<int>();
            Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
            if (!this.IsObject && !this.IsBoolean)
            {
                if (level >= Menes.ValidationLevel.Basic)
                {
                    string? il = null;
                    string? akl = null;
                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);
                    result.AddResult(valid: false, message: "6.1.1.  type - item must be one of object,boolean", instanceLocation: il, absoluteKeywordLocation: akl);
                }
                else
                {
                    result.SetValid(false);
                }
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
                }
            }
            result = ValidateAllOf(this, result, level, composedEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
            if (this.IsObject)
            {
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush57)
                {
                    aklPush57.Push("https://json-schema.org/draft/2019-09/schema#/definitions");
                }
                evaluatedProperties?.Add("definitions");
                if (this.TryGetProperty<Draft201909Schema.DefinitionsEntity>(_MenesDefinitionsJsonPropertyName.Span, out Draft201909Schema.DefinitionsEntity value57))
                {
                    result = value57.Validate(result, level, null, absoluteKeywordLocation, instanceLocation);
                    if (level == Menes.ValidationLevel.Flag && !result.Valid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        string? il = null;
                        string? akl = null;
                        instanceLocation?.TryPeek(out il);
                        absoluteKeywordLocation?.TryPeek(out akl);
                        result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
                    }
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop57)
                {
                    aklPop57.Pop();
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush58)
                {
                    aklPush58.Push("https://json-schema.org/draft/2019-09/schema#/dependencies");
                }
                evaluatedProperties?.Add("dependencies");
                if (this.TryGetProperty<Draft201909Schema.DependenciesEntity>(_MenesDependenciesJsonPropertyName.Span, out Draft201909Schema.DependenciesEntity value58))
                {
                    result = value58.Validate(result, level, null, absoluteKeywordLocation, instanceLocation);
                    if (level == Menes.ValidationLevel.Flag && !result.Valid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        string? il = null;
                        string? akl = null;
                        instanceLocation?.TryPeek(out il);
                        absoluteKeywordLocation?.TryPeek(out akl);
                        result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
                    }
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop58)
                {
                    aklPop58.Pop();
                }
            }
            if (this.IsObject)
            {
                foreach (var property in this.EnumerateObject())
                {
                }
            }
            return result;
            Menes.ValidationResult ValidateAllOf(in Draft201909Schema that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                Menes.ValidationResult result = validationResult;
                System.Collections.Generic.HashSet<string> localEvaluatedProperties = new System.Collections.Generic.HashSet<string>();
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush0)
                {
                    aklPush0.Push("https://json-schema.org/draft/2019-09/schema#/allOf/0");
                }
                var allOf0 = that.AsDraft201909MetaCore();
                localEvaluatedProperties.Clear();
                result = allOf0.Validate(result, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
                }
                foreach (var item in localEvaluatedProperties)
                {
                    evaluatedProperties.Add(item);
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop0)
                {
                    aklPop0.Pop();
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush1)
                {
                    aklPush1.Push("https://json-schema.org/draft/2019-09/schema#/allOf/1");
                }
                var allOf1 = that.AsDraft201909MetaApplicator();
                localEvaluatedProperties.Clear();
                result = allOf1.Validate(result, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
                }
                foreach (var item in localEvaluatedProperties)
                {
                    evaluatedProperties.Add(item);
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop1)
                {
                    aklPop1.Pop();
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush2)
                {
                    aklPush2.Push("https://json-schema.org/draft/2019-09/schema#/allOf/2");
                }
                var allOf2 = that.AsDraft201909MetaValidation();
                localEvaluatedProperties.Clear();
                result = allOf2.Validate(result, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
                }
                foreach (var item in localEvaluatedProperties)
                {
                    evaluatedProperties.Add(item);
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop2)
                {
                    aklPop2.Pop();
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush3)
                {
                    aklPush3.Push("https://json-schema.org/draft/2019-09/schema#/allOf/3");
                }
                var allOf3 = that.AsDraft201909MetaMetaData();
                localEvaluatedProperties.Clear();
                result = allOf3.Validate(result, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
                }
                foreach (var item in localEvaluatedProperties)
                {
                    evaluatedProperties.Add(item);
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop3)
                {
                    aklPop3.Pop();
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush4)
                {
                    aklPush4.Push("https://json-schema.org/draft/2019-09/schema#/allOf/4");
                }
                var allOf4 = that.AsDraft201909MetaFormat();
                localEvaluatedProperties.Clear();
                result = allOf4.Validate(result, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
                }
                foreach (var item in localEvaluatedProperties)
                {
                    evaluatedProperties.Add(item);
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop4)
                {
                    aklPop4.Pop();
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush5)
                {
                    aklPush5.Push("https://json-schema.org/draft/2019-09/schema#/allOf/5");
                }
                var allOf5 = that.AsDraft201909MetaContent();
                localEvaluatedProperties.Clear();
                result = allOf5.Validate(result, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
                }
                foreach (var item in localEvaluatedProperties)
                {
                    evaluatedProperties.Add(item);
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop5)
                {
                    aklPop5.Pop();
                }
                return result;
            }
        }
        /// <inheritdoc />
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
                return;
            }
            writer.WriteStartObject();
            if (this.id is Draft201909MetaCore.IdValue id)
            {
                writer.WritePropertyName(_MenesIdEncodedJsonPropertyName);
                id.WriteTo(writer);
            }
            if (this.schema is Menes.JsonUri schema)
            {
                writer.WritePropertyName(_MenesSchemaEncodedJsonPropertyName);
                schema.WriteTo(writer);
            }
            if (this.anchor is Draft201909MetaCore.AnchorValue anchor)
            {
                writer.WritePropertyName(_MenesAnchorEncodedJsonPropertyName);
                anchor.WriteTo(writer);
            }
            if (this.@ref is Menes.JsonUriReference @ref)
            {
                writer.WritePropertyName(_MenesRefEncodedJsonPropertyName);
                @ref.WriteTo(writer);
            }
            if (this.recursiveRef is Menes.JsonUriReference recursiveRef)
            {
                writer.WritePropertyName(_MenesRecursiveRefEncodedJsonPropertyName);
                recursiveRef.WriteTo(writer);
            }
            if (this.recursiveAnchor is Menes.JsonBoolean recursiveAnchor)
            {
                writer.WritePropertyName(_MenesRecursiveAnchorEncodedJsonPropertyName);
                recursiveAnchor.WriteTo(writer);
            }
            if (this.vocabulary is Draft201909MetaCore.VocabularyEntity vocabulary)
            {
                writer.WritePropertyName(_MenesVocabularyEncodedJsonPropertyName);
                vocabulary.WriteTo(writer);
            }
            if (this.comment is Menes.JsonString comment)
            {
                writer.WritePropertyName(_MenesCommentEncodedJsonPropertyName);
                comment.WriteTo(writer);
            }
            if (this.defs is Draft201909MetaCore.DefsEntity defs)
            {
                writer.WritePropertyName(_MenesDefsEncodedJsonPropertyName);
                defs.WriteTo(writer);
            }
            if (this.additionalItems is Draft201909MetaApplicator additionalItems)
            {
                writer.WritePropertyName(_MenesAdditionalItemsEncodedJsonPropertyName);
                additionalItems.WriteTo(writer);
            }
            if (this.unevaluatedItems is Draft201909MetaApplicator unevaluatedItems)
            {
                writer.WritePropertyName(_MenesUnevaluatedItemsEncodedJsonPropertyName);
                unevaluatedItems.WriteTo(writer);
            }
            if (this.items is Draft201909MetaApplicator.ItemsEntity items)
            {
                writer.WritePropertyName(_MenesItemsEncodedJsonPropertyName);
                items.WriteTo(writer);
            }
            if (this.contains is Draft201909MetaApplicator contains)
            {
                writer.WritePropertyName(_MenesContainsEncodedJsonPropertyName);
                contains.WriteTo(writer);
            }
            if (this.additionalProperties is Draft201909MetaApplicator additionalProperties)
            {
                writer.WritePropertyName(_MenesAdditionalPropertiesEncodedJsonPropertyName);
                additionalProperties.WriteTo(writer);
            }
            if (this.unevaluatedProperties is Draft201909MetaApplicator unevaluatedProperties)
            {
                writer.WritePropertyName(_MenesUnevaluatedPropertiesEncodedJsonPropertyName);
                unevaluatedProperties.WriteTo(writer);
            }
            if (this.properties is Draft201909MetaApplicator.PropertiesEntity properties)
            {
                writer.WritePropertyName(_MenesPropertiesEncodedJsonPropertyName);
                properties.WriteTo(writer);
            }
            if (this.patternProperties is Draft201909MetaApplicator.PatternPropertiesEntity patternProperties)
            {
                writer.WritePropertyName(_MenesPatternPropertiesEncodedJsonPropertyName);
                patternProperties.WriteTo(writer);
            }
            if (this.dependentSchemas is Draft201909MetaApplicator.DependentSchemasEntity dependentSchemas)
            {
                writer.WritePropertyName(_MenesDependentSchemasEncodedJsonPropertyName);
                dependentSchemas.WriteTo(writer);
            }
            if (this.propertyNames is Draft201909MetaApplicator propertyNames)
            {
                writer.WritePropertyName(_MenesPropertyNamesEncodedJsonPropertyName);
                propertyNames.WriteTo(writer);
            }
            if (this.@if is Draft201909MetaApplicator @if)
            {
                writer.WritePropertyName(_MenesIfEncodedJsonPropertyName);
                @if.WriteTo(writer);
            }
            if (this.then is Draft201909MetaApplicator then)
            {
                writer.WritePropertyName(_MenesThenEncodedJsonPropertyName);
                then.WriteTo(writer);
            }
            if (this.@else is Draft201909MetaApplicator @else)
            {
                writer.WritePropertyName(_MenesElseEncodedJsonPropertyName);
                @else.WriteTo(writer);
            }
            if (this.allOf is Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity allOf)
            {
                writer.WritePropertyName(_MenesAllOfEncodedJsonPropertyName);
                allOf.WriteTo(writer);
            }
            if (this.anyOf is Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity anyOf)
            {
                writer.WritePropertyName(_MenesAnyOfEncodedJsonPropertyName);
                anyOf.WriteTo(writer);
            }
            if (this.oneOf is Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity oneOf)
            {
                writer.WritePropertyName(_MenesOneOfEncodedJsonPropertyName);
                oneOf.WriteTo(writer);
            }
            if (this.not is Draft201909MetaApplicator not)
            {
                writer.WritePropertyName(_MenesNotEncodedJsonPropertyName);
                not.WriteTo(writer);
            }
            if (this.multipleOf is Draft201909MetaValidation.MultipleOfValue multipleOf)
            {
                writer.WritePropertyName(_MenesMultipleOfEncodedJsonPropertyName);
                multipleOf.WriteTo(writer);
            }
            if (this.maximum is Menes.JsonNumber maximum)
            {
                writer.WritePropertyName(_MenesMaximumEncodedJsonPropertyName);
                maximum.WriteTo(writer);
            }
            if (this.exclusiveMaximum is Menes.JsonNumber exclusiveMaximum)
            {
                writer.WritePropertyName(_MenesExclusiveMaximumEncodedJsonPropertyName);
                exclusiveMaximum.WriteTo(writer);
            }
            if (this.minimum is Menes.JsonNumber minimum)
            {
                writer.WritePropertyName(_MenesMinimumEncodedJsonPropertyName);
                minimum.WriteTo(writer);
            }
            if (this.exclusiveMinimum is Menes.JsonNumber exclusiveMinimum)
            {
                writer.WritePropertyName(_MenesExclusiveMinimumEncodedJsonPropertyName);
                exclusiveMinimum.WriteTo(writer);
            }
            if (this.maxLength is Draft201909MetaValidation.NonNegativeIntegerValue maxLength)
            {
                writer.WritePropertyName(_MenesMaxLengthEncodedJsonPropertyName);
                maxLength.WriteTo(writer);
            }
            if (this.minLength is Draft201909MetaValidation.NonNegativeIntegerValue minLength)
            {
                writer.WritePropertyName(_MenesMinLengthEncodedJsonPropertyName);
                minLength.WriteTo(writer);
            }
            if (this.pattern is Menes.JsonRegex pattern)
            {
                writer.WritePropertyName(_MenesPatternEncodedJsonPropertyName);
                pattern.WriteTo(writer);
            }
            if (this.maxItems is Draft201909MetaValidation.NonNegativeIntegerValue maxItems)
            {
                writer.WritePropertyName(_MenesMaxItemsEncodedJsonPropertyName);
                maxItems.WriteTo(writer);
            }
            if (this.minItems is Draft201909MetaValidation.NonNegativeIntegerValue minItems)
            {
                writer.WritePropertyName(_MenesMinItemsEncodedJsonPropertyName);
                minItems.WriteTo(writer);
            }
            if (this.uniqueItems is Menes.JsonBoolean uniqueItems)
            {
                writer.WritePropertyName(_MenesUniqueItemsEncodedJsonPropertyName);
                uniqueItems.WriteTo(writer);
            }
            if (this.maxContains is Draft201909MetaValidation.NonNegativeIntegerValue maxContains)
            {
                writer.WritePropertyName(_MenesMaxContainsEncodedJsonPropertyName);
                maxContains.WriteTo(writer);
            }
            if (this.minContains is Draft201909MetaValidation.NonNegativeIntegerValue minContains)
            {
                writer.WritePropertyName(_MenesMinContainsEncodedJsonPropertyName);
                minContains.WriteTo(writer);
            }
            if (this.maxProperties is Draft201909MetaValidation.NonNegativeIntegerValue maxProperties)
            {
                writer.WritePropertyName(_MenesMaxPropertiesEncodedJsonPropertyName);
                maxProperties.WriteTo(writer);
            }
            if (this.minProperties is Draft201909MetaValidation.NonNegativeIntegerValue minProperties)
            {
                writer.WritePropertyName(_MenesMinPropertiesEncodedJsonPropertyName);
                minProperties.WriteTo(writer);
            }
            if (this.required is Draft201909MetaValidation.StringArrayEntity required)
            {
                writer.WritePropertyName(_MenesRequiredEncodedJsonPropertyName);
                required.WriteTo(writer);
            }
            if (this.dependentRequired is Draft201909MetaValidation.DependentRequiredEntity dependentRequired)
            {
                writer.WritePropertyName(_MenesDependentRequiredEncodedJsonPropertyName);
                dependentRequired.WriteTo(writer);
            }
            if (this.@const is Menes.JsonAny @const)
            {
                writer.WritePropertyName(_MenesConstEncodedJsonPropertyName);
                @const.WriteTo(writer);
            }
            if (this.@enum is Draft201909MetaValidation.EnumArray @enum)
            {
                writer.WritePropertyName(_MenesEnumEncodedJsonPropertyName);
                @enum.WriteTo(writer);
            }
            if (this.type is Draft201909MetaValidation.TypeEntity type)
            {
                writer.WritePropertyName(_MenesTypeEncodedJsonPropertyName);
                type.WriteTo(writer);
            }
            if (this.title is Menes.JsonString title)
            {
                writer.WritePropertyName(_MenesTitleEncodedJsonPropertyName);
                title.WriteTo(writer);
            }
            if (this.description is Menes.JsonString description)
            {
                writer.WritePropertyName(_MenesDescriptionEncodedJsonPropertyName);
                description.WriteTo(writer);
            }
            if (this.@default is Menes.JsonAny @default)
            {
                writer.WritePropertyName(_MenesDefaultEncodedJsonPropertyName);
                @default.WriteTo(writer);
            }
            if (this.deprecated is Menes.JsonBoolean deprecated)
            {
                writer.WritePropertyName(_MenesDeprecatedEncodedJsonPropertyName);
                deprecated.WriteTo(writer);
            }
            if (this.readOnly is Menes.JsonBoolean readOnly)
            {
                writer.WritePropertyName(_MenesReadOnlyEncodedJsonPropertyName);
                readOnly.WriteTo(writer);
            }
            if (this.writeOnly is Menes.JsonBoolean writeOnly)
            {
                writer.WritePropertyName(_MenesWriteOnlyEncodedJsonPropertyName);
                writeOnly.WriteTo(writer);
            }
            if (this.examples is Draft201909MetaMetaData.ExamplesArray examples)
            {
                writer.WritePropertyName(_MenesExamplesEncodedJsonPropertyName);
                examples.WriteTo(writer);
            }
            if (this.format is Menes.JsonString format)
            {
                writer.WritePropertyName(_MenesFormatEncodedJsonPropertyName);
                format.WriteTo(writer);
            }
            if (this.contentMediaType is Menes.JsonString contentMediaType)
            {
                writer.WritePropertyName(_MenesContentMediaTypeEncodedJsonPropertyName);
                contentMediaType.WriteTo(writer);
            }
            if (this.contentEncoding is Menes.JsonString contentEncoding)
            {
                writer.WritePropertyName(_MenesContentEncodingEncodedJsonPropertyName);
                contentEncoding.WriteTo(writer);
            }
            if (this.contentSchema is Draft201909MetaContent contentSchema)
            {
                writer.WritePropertyName(_MenesContentSchemaEncodedJsonPropertyName);
                contentSchema.WriteTo(writer);
            }
            if (this.definitions is Menes.JsonValueBacking definitions && !definitions.IsNull)
            {
                writer.WritePropertyName(_MenesDefinitionsEncodedJsonPropertyName);
                definitions.WriteTo(writer);
            }
            if (this.dependencies is Draft201909Schema.DependenciesEntity dependencies)
            {
                writer.WritePropertyName(_MenesDependenciesEncodedJsonPropertyName);
                dependencies.WriteTo(writer);
            }
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                property.WriteTo(writer);
            }
            writer.WriteEndObject();
        }
        /// <inheritdoc />
        public T As<T>()
            where T : struct, Menes.IJsonValue
        {
            if (typeof(T) == typeof(Draft201909Schema))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }
            return Menes.JsonValue.As<Draft201909Schema, T>(this);
        }
        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, Menes.IJsonValue
        {
            if (typeof(T) == typeof(Draft201909Schema))
            {
                return this.Validate().Valid;
            }
            return this.As<T>().Validate().Valid;
        }
        public readonly Draft201909MetaCore AsDraft201909MetaCore()
        {
            return this.As<Draft201909MetaCore>();
        }
        public readonly Draft201909MetaApplicator AsDraft201909MetaApplicator()
        {
            return this.As<Draft201909MetaApplicator>();
        }
        public readonly Draft201909MetaValidation AsDraft201909MetaValidation()
        {
            return this.As<Draft201909MetaValidation>();
        }
        public readonly Draft201909MetaMetaData AsDraft201909MetaMetaData()
        {
            return this.As<Draft201909MetaMetaData>();
        }
        public readonly Draft201909MetaFormat AsDraft201909MetaFormat()
        {
            return this.As<Draft201909MetaFormat>();
        }
        public readonly Draft201909MetaContent AsDraft201909MetaContent()
        {
            return this.As<Draft201909MetaContent>();
        }
        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, Menes.IJsonValue
        {
            return false;
        }
        /// <inheritdoc/>
        public bool HasProperty(System.ReadOnlySpan<char> propertyName)
        {
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
            {
                return true;
            }
            else
            {
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContainsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentSchemasJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertyNamesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIfJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesThenJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesElseJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAllOfJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnyOfJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesOneOfJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesNotJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMultipleOfJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaximumJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMaximumJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinimumJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMinimumJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxLengthJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinLengthJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUniqueItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxContainsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinContainsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRequiredJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentRequiredJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesConstJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesEnumJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTypeJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefinitionsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependenciesJsonPropertyName.Span))
                {
                    return true;
                }
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <inheritdoc/>
        public bool HasProperty(string propertyName)
        {
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
            {
                return true;
            }
            else
            {
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesIdJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesSchemaJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAnchorJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRefJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRecursiveRefJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRecursiveAnchorJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesVocabularyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesCommentJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDefsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAdditionalItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesUnevaluatedItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContainsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAdditionalPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesUnevaluatedPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesPatternPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDependentSchemasJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesPropertyNamesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesIfJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesThenJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesElseJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAllOfJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAnyOfJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesOneOfJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesNotJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMultipleOfJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMaximumJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesExclusiveMaximumJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMinimumJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesExclusiveMinimumJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMaxLengthJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMinLengthJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesPatternJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMaxItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMinItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesUniqueItemsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMaxContainsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMinContainsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMaxPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMinPropertiesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRequiredJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDependentRequiredJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesConstJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesEnumJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesTypeJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesTitleJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDescriptionJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDefaultJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDeprecatedJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesReadOnlyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesWriteOnlyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesExamplesJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFormatJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentMediaTypeJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentEncodingJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentSchemaJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDefinitionsJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDependenciesJsonPropertyName.Span))
                {
                    return true;
                }
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <inheritdoc/>
        public bool HasProperty(System.ReadOnlySpan<byte> propertyName)
        {
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
            {
                return true;
            }
            else
            {
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalItemsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedItemsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesItemsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContainsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalPropertiesUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedPropertiesUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertiesUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternPropertiesUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentSchemasUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertyNamesUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIfUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesThenUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesElseUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAllOfUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnyOfUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesOneOfUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesNotUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMultipleOfUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaximumUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMaximumUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinimumUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMinimumUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxLengthUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinLengthUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxItemsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinItemsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUniqueItemsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxContainsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinContainsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxPropertiesUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinPropertiesUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRequiredUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentRequiredUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesConstUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesEnumUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTypeUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefinitionsUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependenciesUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <inheritdoc />
        public bool TryGetProperty<T>(System.ReadOnlySpan<char> propertyName, out T property)
            where T : struct, Menes.IJsonValue
        {
            if (this.HasJsonElement)
            {
                if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                {
                    property = Menes.JsonValue.As<T>(value);
                    return true;
                }
                property = default;
                return false;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdJsonPropertyName.Span))
            {
                if (!(this.Id?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaJsonPropertyName.Span))
            {
                if (!(this.Schema?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorJsonPropertyName.Span))
            {
                if (!(this.Anchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefJsonPropertyName.Span))
            {
                if (!(this.Ref?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefJsonPropertyName.Span))
            {
                if (!(this.RecursiveRef?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorJsonPropertyName.Span))
            {
                if (!(this.RecursiveAnchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyJsonPropertyName.Span))
            {
                if (!(this.Vocabulary?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentJsonPropertyName.Span))
            {
                if (!(this.Comment?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsJsonPropertyName.Span))
            {
                if (!(this.Defs?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalItemsJsonPropertyName.Span))
            {
                if (!(this.AdditionalItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedItemsJsonPropertyName.Span))
            {
                if (!(this.UnevaluatedItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesItemsJsonPropertyName.Span))
            {
                if (!(this.Items?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContainsJsonPropertyName.Span))
            {
                if (!(this.Contains?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalPropertiesJsonPropertyName.Span))
            {
                if (!(this.AdditionalProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedPropertiesJsonPropertyName.Span))
            {
                if (!(this.UnevaluatedProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertiesJsonPropertyName.Span))
            {
                if (!(this.Properties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternPropertiesJsonPropertyName.Span))
            {
                if (!(this.PatternProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentSchemasJsonPropertyName.Span))
            {
                if (!(this.DependentSchemas?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertyNamesJsonPropertyName.Span))
            {
                if (!(this.PropertyNames?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIfJsonPropertyName.Span))
            {
                if (!(this.If?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesThenJsonPropertyName.Span))
            {
                if (!(this.Then?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesElseJsonPropertyName.Span))
            {
                if (!(this.Else?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAllOfJsonPropertyName.Span))
            {
                if (!(this.AllOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnyOfJsonPropertyName.Span))
            {
                if (!(this.AnyOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesOneOfJsonPropertyName.Span))
            {
                if (!(this.OneOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesNotJsonPropertyName.Span))
            {
                if (!(this.Not?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMultipleOfJsonPropertyName.Span))
            {
                if (!(this.MultipleOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaximumJsonPropertyName.Span))
            {
                if (!(this.Maximum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMaximumJsonPropertyName.Span))
            {
                if (!(this.ExclusiveMaximum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinimumJsonPropertyName.Span))
            {
                if (!(this.Minimum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMinimumJsonPropertyName.Span))
            {
                if (!(this.ExclusiveMinimum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxLengthJsonPropertyName.Span))
            {
                if (!(this.MaxLength?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinLengthJsonPropertyName.Span))
            {
                if (!(this.MinLength?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternJsonPropertyName.Span))
            {
                if (!(this.Pattern?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxItemsJsonPropertyName.Span))
            {
                if (!(this.MaxItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinItemsJsonPropertyName.Span))
            {
                if (!(this.MinItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUniqueItemsJsonPropertyName.Span))
            {
                if (!(this.UniqueItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxContainsJsonPropertyName.Span))
            {
                if (!(this.MaxContains?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinContainsJsonPropertyName.Span))
            {
                if (!(this.MinContains?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxPropertiesJsonPropertyName.Span))
            {
                if (!(this.MaxProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinPropertiesJsonPropertyName.Span))
            {
                if (!(this.MinProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRequiredJsonPropertyName.Span))
            {
                if (!(this.Required?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentRequiredJsonPropertyName.Span))
            {
                if (!(this.DependentRequired?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesConstJsonPropertyName.Span))
            {
                if (!(this.Const?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesEnumJsonPropertyName.Span))
            {
                if (!(this.Enum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTypeJsonPropertyName.Span))
            {
                if (!(this.Type?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleJsonPropertyName.Span))
            {
                if (!(this.Title?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionJsonPropertyName.Span))
            {
                if (!(this.Description?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultJsonPropertyName.Span))
            {
                if (!(this.Default?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedJsonPropertyName.Span))
            {
                if (!(this.Deprecated?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyJsonPropertyName.Span))
            {
                if (!(this.ReadOnly?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyJsonPropertyName.Span))
            {
                if (!(this.WriteOnly?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesJsonPropertyName.Span))
            {
                if (!(this.Examples?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatJsonPropertyName.Span))
            {
                if (!(this.Format?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeJsonPropertyName.Span))
            {
                if (!(this.ContentMediaType?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingJsonPropertyName.Span))
            {
                if (!(this.ContentEncoding?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaJsonPropertyName.Span))
            {
                if (!(this.ContentSchema?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefinitionsJsonPropertyName.Span))
            {
                if (!(this.Definitions?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependenciesJsonPropertyName.Span))
            {
                if (!(this.Dependencies?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
            {
                if (additionalProperty.NameEquals(propertyName))
                {
                    property = additionalProperty.Value.As<T>();
                    return true;
                }
            }
            property = default;
            return false;
        }
        /// <inheritdoc />
        public bool TryGetProperty<T>(string propertyName, out T property)
            where T : struct, Menes.IJsonValue
        {
            if (this.HasJsonElement)
            {
                if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                {
                    property = Menes.JsonValue.As<T>(value);
                    return true;
                }
                property = default;
                return false;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesIdJsonPropertyName.Span))
            {
                if (!(this.Id?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesSchemaJsonPropertyName.Span))
            {
                if (!(this.Schema?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAnchorJsonPropertyName.Span))
            {
                if (!(this.Anchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRefJsonPropertyName.Span))
            {
                if (!(this.Ref?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRecursiveRefJsonPropertyName.Span))
            {
                if (!(this.RecursiveRef?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRecursiveAnchorJsonPropertyName.Span))
            {
                if (!(this.RecursiveAnchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesVocabularyJsonPropertyName.Span))
            {
                if (!(this.Vocabulary?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesCommentJsonPropertyName.Span))
            {
                if (!(this.Comment?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDefsJsonPropertyName.Span))
            {
                if (!(this.Defs?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAdditionalItemsJsonPropertyName.Span))
            {
                if (!(this.AdditionalItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesUnevaluatedItemsJsonPropertyName.Span))
            {
                if (!(this.UnevaluatedItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesItemsJsonPropertyName.Span))
            {
                if (!(this.Items?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContainsJsonPropertyName.Span))
            {
                if (!(this.Contains?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAdditionalPropertiesJsonPropertyName.Span))
            {
                if (!(this.AdditionalProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesUnevaluatedPropertiesJsonPropertyName.Span))
            {
                if (!(this.UnevaluatedProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesPropertiesJsonPropertyName.Span))
            {
                if (!(this.Properties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesPatternPropertiesJsonPropertyName.Span))
            {
                if (!(this.PatternProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDependentSchemasJsonPropertyName.Span))
            {
                if (!(this.DependentSchemas?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesPropertyNamesJsonPropertyName.Span))
            {
                if (!(this.PropertyNames?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesIfJsonPropertyName.Span))
            {
                if (!(this.If?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesThenJsonPropertyName.Span))
            {
                if (!(this.Then?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesElseJsonPropertyName.Span))
            {
                if (!(this.Else?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAllOfJsonPropertyName.Span))
            {
                if (!(this.AllOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAnyOfJsonPropertyName.Span))
            {
                if (!(this.AnyOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesOneOfJsonPropertyName.Span))
            {
                if (!(this.OneOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesNotJsonPropertyName.Span))
            {
                if (!(this.Not?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMultipleOfJsonPropertyName.Span))
            {
                if (!(this.MultipleOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMaximumJsonPropertyName.Span))
            {
                if (!(this.Maximum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesExclusiveMaximumJsonPropertyName.Span))
            {
                if (!(this.ExclusiveMaximum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMinimumJsonPropertyName.Span))
            {
                if (!(this.Minimum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesExclusiveMinimumJsonPropertyName.Span))
            {
                if (!(this.ExclusiveMinimum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMaxLengthJsonPropertyName.Span))
            {
                if (!(this.MaxLength?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMinLengthJsonPropertyName.Span))
            {
                if (!(this.MinLength?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesPatternJsonPropertyName.Span))
            {
                if (!(this.Pattern?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMaxItemsJsonPropertyName.Span))
            {
                if (!(this.MaxItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMinItemsJsonPropertyName.Span))
            {
                if (!(this.MinItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesUniqueItemsJsonPropertyName.Span))
            {
                if (!(this.UniqueItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMaxContainsJsonPropertyName.Span))
            {
                if (!(this.MaxContains?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMinContainsJsonPropertyName.Span))
            {
                if (!(this.MinContains?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMaxPropertiesJsonPropertyName.Span))
            {
                if (!(this.MaxProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMinPropertiesJsonPropertyName.Span))
            {
                if (!(this.MinProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRequiredJsonPropertyName.Span))
            {
                if (!(this.Required?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDependentRequiredJsonPropertyName.Span))
            {
                if (!(this.DependentRequired?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesConstJsonPropertyName.Span))
            {
                if (!(this.Const?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesEnumJsonPropertyName.Span))
            {
                if (!(this.Enum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesTypeJsonPropertyName.Span))
            {
                if (!(this.Type?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesTitleJsonPropertyName.Span))
            {
                if (!(this.Title?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDescriptionJsonPropertyName.Span))
            {
                if (!(this.Description?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDefaultJsonPropertyName.Span))
            {
                if (!(this.Default?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDeprecatedJsonPropertyName.Span))
            {
                if (!(this.Deprecated?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesReadOnlyJsonPropertyName.Span))
            {
                if (!(this.ReadOnly?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesWriteOnlyJsonPropertyName.Span))
            {
                if (!(this.WriteOnly?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesExamplesJsonPropertyName.Span))
            {
                if (!(this.Examples?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFormatJsonPropertyName.Span))
            {
                if (!(this.Format?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentMediaTypeJsonPropertyName.Span))
            {
                if (!(this.ContentMediaType?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentEncodingJsonPropertyName.Span))
            {
                if (!(this.ContentEncoding?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesContentSchemaJsonPropertyName.Span))
            {
                if (!(this.ContentSchema?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDefinitionsJsonPropertyName.Span))
            {
                if (!(this.Definitions?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDependenciesJsonPropertyName.Span))
            {
                if (!(this.Dependencies?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
            {
                if (additionalProperty.NameEquals(propertyName))
                {
                    property = additionalProperty.Value.As<T>();
                    return true;
                }
            }
            property = default;
            return false;
        }
        /// <inheritdoc />
        public bool TryGetProperty<T>(System.ReadOnlySpan<byte> propertyName, out T property)
            where T : struct, Menes.IJsonValue
        {
            if (this.HasJsonElement)
            {
                if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                {
                    property = Menes.JsonValue.As<T>(value);
                    return true;
                }
                property = default;
                return false;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdUtf8JsonPropertyName.Span))
            {
                if (!(this.Id?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaUtf8JsonPropertyName.Span))
            {
                if (!(this.Schema?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorUtf8JsonPropertyName.Span))
            {
                if (!(this.Anchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefUtf8JsonPropertyName.Span))
            {
                if (!(this.Ref?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefUtf8JsonPropertyName.Span))
            {
                if (!(this.RecursiveRef?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorUtf8JsonPropertyName.Span))
            {
                if (!(this.RecursiveAnchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyUtf8JsonPropertyName.Span))
            {
                if (!(this.Vocabulary?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentUtf8JsonPropertyName.Span))
            {
                if (!(this.Comment?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsUtf8JsonPropertyName.Span))
            {
                if (!(this.Defs?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalItemsUtf8JsonPropertyName.Span))
            {
                if (!(this.AdditionalItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedItemsUtf8JsonPropertyName.Span))
            {
                if (!(this.UnevaluatedItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesItemsUtf8JsonPropertyName.Span))
            {
                if (!(this.Items?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContainsUtf8JsonPropertyName.Span))
            {
                if (!(this.Contains?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalPropertiesUtf8JsonPropertyName.Span))
            {
                if (!(this.AdditionalProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedPropertiesUtf8JsonPropertyName.Span))
            {
                if (!(this.UnevaluatedProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertiesUtf8JsonPropertyName.Span))
            {
                if (!(this.Properties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternPropertiesUtf8JsonPropertyName.Span))
            {
                if (!(this.PatternProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentSchemasUtf8JsonPropertyName.Span))
            {
                if (!(this.DependentSchemas?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertyNamesUtf8JsonPropertyName.Span))
            {
                if (!(this.PropertyNames?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIfUtf8JsonPropertyName.Span))
            {
                if (!(this.If?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesThenUtf8JsonPropertyName.Span))
            {
                if (!(this.Then?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesElseUtf8JsonPropertyName.Span))
            {
                if (!(this.Else?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAllOfUtf8JsonPropertyName.Span))
            {
                if (!(this.AllOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnyOfUtf8JsonPropertyName.Span))
            {
                if (!(this.AnyOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesOneOfUtf8JsonPropertyName.Span))
            {
                if (!(this.OneOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesNotUtf8JsonPropertyName.Span))
            {
                if (!(this.Not?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMultipleOfUtf8JsonPropertyName.Span))
            {
                if (!(this.MultipleOf?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaximumUtf8JsonPropertyName.Span))
            {
                if (!(this.Maximum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMaximumUtf8JsonPropertyName.Span))
            {
                if (!(this.ExclusiveMaximum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinimumUtf8JsonPropertyName.Span))
            {
                if (!(this.Minimum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMinimumUtf8JsonPropertyName.Span))
            {
                if (!(this.ExclusiveMinimum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxLengthUtf8JsonPropertyName.Span))
            {
                if (!(this.MaxLength?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinLengthUtf8JsonPropertyName.Span))
            {
                if (!(this.MinLength?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternUtf8JsonPropertyName.Span))
            {
                if (!(this.Pattern?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxItemsUtf8JsonPropertyName.Span))
            {
                if (!(this.MaxItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinItemsUtf8JsonPropertyName.Span))
            {
                if (!(this.MinItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUniqueItemsUtf8JsonPropertyName.Span))
            {
                if (!(this.UniqueItems?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxContainsUtf8JsonPropertyName.Span))
            {
                if (!(this.MaxContains?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinContainsUtf8JsonPropertyName.Span))
            {
                if (!(this.MinContains?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxPropertiesUtf8JsonPropertyName.Span))
            {
                if (!(this.MaxProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinPropertiesUtf8JsonPropertyName.Span))
            {
                if (!(this.MinProperties?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRequiredUtf8JsonPropertyName.Span))
            {
                if (!(this.Required?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentRequiredUtf8JsonPropertyName.Span))
            {
                if (!(this.DependentRequired?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesConstUtf8JsonPropertyName.Span))
            {
                if (!(this.Const?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesEnumUtf8JsonPropertyName.Span))
            {
                if (!(this.Enum?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTypeUtf8JsonPropertyName.Span))
            {
                if (!(this.Type?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleUtf8JsonPropertyName.Span))
            {
                if (!(this.Title?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionUtf8JsonPropertyName.Span))
            {
                if (!(this.Description?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultUtf8JsonPropertyName.Span))
            {
                if (!(this.Default?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedUtf8JsonPropertyName.Span))
            {
                if (!(this.Deprecated?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyUtf8JsonPropertyName.Span))
            {
                if (!(this.ReadOnly?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyUtf8JsonPropertyName.Span))
            {
                if (!(this.WriteOnly?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesUtf8JsonPropertyName.Span))
            {
                if (!(this.Examples?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatUtf8JsonPropertyName.Span))
            {
                if (!(this.Format?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeUtf8JsonPropertyName.Span))
            {
                if (!(this.ContentMediaType?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingUtf8JsonPropertyName.Span))
            {
                if (!(this.ContentEncoding?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaUtf8JsonPropertyName.Span))
            {
                if (!(this.ContentSchema?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefinitionsUtf8JsonPropertyName.Span))
            {
                if (!(this.Definitions?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependenciesUtf8JsonPropertyName.Span))
            {
                if (!(this.Dependencies?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
            {
                if (additionalProperty.NameEquals(propertyName))
                {
                    property = additionalProperty.Value.As<T>();
                    return true;
                }
            }
            property = default;
            return false;
        }
        /// <inheritdoc />
        public bool TryGetPropertyAtIndex(int index, out Menes.IProperty result)
        {
            var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<Draft201909Schema> prop);
            result = prop;
            return rc;
        }
        public Draft201909Schema RemoveProperty(string propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public Draft201909Schema RemoveProperty(System.ReadOnlySpan<char> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public Draft201909Schema RemoveProperty(System.ReadOnlySpan<byte> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public Draft201909Schema SetProperty<T>(string name, T value)
        where T : struct, Menes.IJsonValue
        {
            var propertyName = System.MemoryExtensions.AsSpan(name);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdJsonPropertyName.Span))
            {
                return this.WithId(value.As<Draft201909MetaCore.IdValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaJsonPropertyName.Span))
            {
                return this.WithSchema(value.As<Menes.JsonUri>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorJsonPropertyName.Span))
            {
                return this.WithAnchor(value.As<Draft201909MetaCore.AnchorValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefJsonPropertyName.Span))
            {
                return this.WithRef(value.As<Menes.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefJsonPropertyName.Span))
            {
                return this.WithRecursiveRef(value.As<Menes.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorJsonPropertyName.Span))
            {
                return this.WithRecursiveAnchor(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyJsonPropertyName.Span))
            {
                return this.WithVocabulary(value.As<Draft201909MetaCore.VocabularyEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentJsonPropertyName.Span))
            {
                return this.WithComment(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsJsonPropertyName.Span))
            {
                return this.WithDefs(value.As<Draft201909MetaCore.DefsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalItemsJsonPropertyName.Span))
            {
                return this.WithAdditionalItems(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedItemsJsonPropertyName.Span))
            {
                return this.WithUnevaluatedItems(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesItemsJsonPropertyName.Span))
            {
                return this.WithItems(value.As<Draft201909MetaApplicator.ItemsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContainsJsonPropertyName.Span))
            {
                return this.WithContains(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalPropertiesJsonPropertyName.Span))
            {
                return this.WithAdditionalProperties(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedPropertiesJsonPropertyName.Span))
            {
                return this.WithUnevaluatedProperties(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertiesJsonPropertyName.Span))
            {
                return this.WithProperties(value.As<Draft201909MetaApplicator.PropertiesEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternPropertiesJsonPropertyName.Span))
            {
                return this.WithPatternProperties(value.As<Draft201909MetaApplicator.PatternPropertiesEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentSchemasJsonPropertyName.Span))
            {
                return this.WithDependentSchemas(value.As<Draft201909MetaApplicator.DependentSchemasEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertyNamesJsonPropertyName.Span))
            {
                return this.WithPropertyNames(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIfJsonPropertyName.Span))
            {
                return this.WithIf(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesThenJsonPropertyName.Span))
            {
                return this.WithThen(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesElseJsonPropertyName.Span))
            {
                return this.WithElse(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAllOfJsonPropertyName.Span))
            {
                return this.WithAllOf(value.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnyOfJsonPropertyName.Span))
            {
                return this.WithAnyOf(value.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesOneOfJsonPropertyName.Span))
            {
                return this.WithOneOf(value.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesNotJsonPropertyName.Span))
            {
                return this.WithNot(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMultipleOfJsonPropertyName.Span))
            {
                return this.WithMultipleOf(value.As<Draft201909MetaValidation.MultipleOfValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaximumJsonPropertyName.Span))
            {
                return this.WithMaximum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMaximumJsonPropertyName.Span))
            {
                return this.WithExclusiveMaximum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinimumJsonPropertyName.Span))
            {
                return this.WithMinimum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMinimumJsonPropertyName.Span))
            {
                return this.WithExclusiveMinimum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxLengthJsonPropertyName.Span))
            {
                return this.WithMaxLength(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinLengthJsonPropertyName.Span))
            {
                return this.WithMinLength(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternJsonPropertyName.Span))
            {
                return this.WithPattern(value.As<Menes.JsonRegex>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxItemsJsonPropertyName.Span))
            {
                return this.WithMaxItems(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinItemsJsonPropertyName.Span))
            {
                return this.WithMinItems(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUniqueItemsJsonPropertyName.Span))
            {
                return this.WithUniqueItems(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxContainsJsonPropertyName.Span))
            {
                return this.WithMaxContains(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinContainsJsonPropertyName.Span))
            {
                return this.WithMinContains(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxPropertiesJsonPropertyName.Span))
            {
                return this.WithMaxProperties(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinPropertiesJsonPropertyName.Span))
            {
                return this.WithMinProperties(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRequiredJsonPropertyName.Span))
            {
                return this.WithRequired(value.As<Draft201909MetaValidation.StringArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentRequiredJsonPropertyName.Span))
            {
                return this.WithDependentRequired(value.As<Draft201909MetaValidation.DependentRequiredEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesConstJsonPropertyName.Span))
            {
                return this.WithConst(value.As<Menes.JsonAny>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesEnumJsonPropertyName.Span))
            {
                return this.WithEnum(value.As<Draft201909MetaValidation.EnumArray>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTypeJsonPropertyName.Span))
            {
                return this.WithType(value.As<Draft201909MetaValidation.TypeEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleJsonPropertyName.Span))
            {
                return this.WithTitle(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionJsonPropertyName.Span))
            {
                return this.WithDescription(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultJsonPropertyName.Span))
            {
                return this.WithDefault(value.As<Menes.JsonAny>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedJsonPropertyName.Span))
            {
                return this.WithDeprecated(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyJsonPropertyName.Span))
            {
                return this.WithReadOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyJsonPropertyName.Span))
            {
                return this.WithWriteOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesJsonPropertyName.Span))
            {
                return this.WithExamples(value.As<Draft201909MetaMetaData.ExamplesArray>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatJsonPropertyName.Span))
            {
                return this.WithFormat(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeJsonPropertyName.Span))
            {
                return this.WithContentMediaType(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingJsonPropertyName.Span))
            {
                return this.WithContentEncoding(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaJsonPropertyName.Span))
            {
                return this.WithContentSchema(value.As<Draft201909MetaContent>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefinitionsJsonPropertyName.Span))
            {
                return this.WithDefinitions(value.As<Draft201909Schema.DefinitionsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependenciesJsonPropertyName.Span))
            {
                return this.WithDependencies(value.As<Draft201909Schema.DependenciesEntity>());
            }
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
            bool added = false;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (!property.NameEquals(propertyName))
                {
                    arrayBuilder.Add(property);
                }
                else
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
                    added = true;
                }
            }
            if (!added)
            {
                arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
            }
            return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
            return this;
        }
        public Draft201909Schema SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
        where T : struct, Menes.IJsonValue
        {
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdJsonPropertyName.Span))
            {
                return this.WithId(value.As<Draft201909MetaCore.IdValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaJsonPropertyName.Span))
            {
                return this.WithSchema(value.As<Menes.JsonUri>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorJsonPropertyName.Span))
            {
                return this.WithAnchor(value.As<Draft201909MetaCore.AnchorValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefJsonPropertyName.Span))
            {
                return this.WithRef(value.As<Menes.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefJsonPropertyName.Span))
            {
                return this.WithRecursiveRef(value.As<Menes.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorJsonPropertyName.Span))
            {
                return this.WithRecursiveAnchor(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyJsonPropertyName.Span))
            {
                return this.WithVocabulary(value.As<Draft201909MetaCore.VocabularyEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentJsonPropertyName.Span))
            {
                return this.WithComment(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsJsonPropertyName.Span))
            {
                return this.WithDefs(value.As<Draft201909MetaCore.DefsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalItemsJsonPropertyName.Span))
            {
                return this.WithAdditionalItems(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedItemsJsonPropertyName.Span))
            {
                return this.WithUnevaluatedItems(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesItemsJsonPropertyName.Span))
            {
                return this.WithItems(value.As<Draft201909MetaApplicator.ItemsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContainsJsonPropertyName.Span))
            {
                return this.WithContains(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalPropertiesJsonPropertyName.Span))
            {
                return this.WithAdditionalProperties(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedPropertiesJsonPropertyName.Span))
            {
                return this.WithUnevaluatedProperties(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertiesJsonPropertyName.Span))
            {
                return this.WithProperties(value.As<Draft201909MetaApplicator.PropertiesEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternPropertiesJsonPropertyName.Span))
            {
                return this.WithPatternProperties(value.As<Draft201909MetaApplicator.PatternPropertiesEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentSchemasJsonPropertyName.Span))
            {
                return this.WithDependentSchemas(value.As<Draft201909MetaApplicator.DependentSchemasEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertyNamesJsonPropertyName.Span))
            {
                return this.WithPropertyNames(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIfJsonPropertyName.Span))
            {
                return this.WithIf(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesThenJsonPropertyName.Span))
            {
                return this.WithThen(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesElseJsonPropertyName.Span))
            {
                return this.WithElse(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAllOfJsonPropertyName.Span))
            {
                return this.WithAllOf(value.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnyOfJsonPropertyName.Span))
            {
                return this.WithAnyOf(value.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesOneOfJsonPropertyName.Span))
            {
                return this.WithOneOf(value.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesNotJsonPropertyName.Span))
            {
                return this.WithNot(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMultipleOfJsonPropertyName.Span))
            {
                return this.WithMultipleOf(value.As<Draft201909MetaValidation.MultipleOfValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaximumJsonPropertyName.Span))
            {
                return this.WithMaximum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMaximumJsonPropertyName.Span))
            {
                return this.WithExclusiveMaximum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinimumJsonPropertyName.Span))
            {
                return this.WithMinimum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMinimumJsonPropertyName.Span))
            {
                return this.WithExclusiveMinimum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxLengthJsonPropertyName.Span))
            {
                return this.WithMaxLength(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinLengthJsonPropertyName.Span))
            {
                return this.WithMinLength(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternJsonPropertyName.Span))
            {
                return this.WithPattern(value.As<Menes.JsonRegex>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxItemsJsonPropertyName.Span))
            {
                return this.WithMaxItems(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinItemsJsonPropertyName.Span))
            {
                return this.WithMinItems(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUniqueItemsJsonPropertyName.Span))
            {
                return this.WithUniqueItems(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxContainsJsonPropertyName.Span))
            {
                return this.WithMaxContains(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinContainsJsonPropertyName.Span))
            {
                return this.WithMinContains(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxPropertiesJsonPropertyName.Span))
            {
                return this.WithMaxProperties(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinPropertiesJsonPropertyName.Span))
            {
                return this.WithMinProperties(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRequiredJsonPropertyName.Span))
            {
                return this.WithRequired(value.As<Draft201909MetaValidation.StringArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentRequiredJsonPropertyName.Span))
            {
                return this.WithDependentRequired(value.As<Draft201909MetaValidation.DependentRequiredEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesConstJsonPropertyName.Span))
            {
                return this.WithConst(value.As<Menes.JsonAny>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesEnumJsonPropertyName.Span))
            {
                return this.WithEnum(value.As<Draft201909MetaValidation.EnumArray>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTypeJsonPropertyName.Span))
            {
                return this.WithType(value.As<Draft201909MetaValidation.TypeEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleJsonPropertyName.Span))
            {
                return this.WithTitle(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionJsonPropertyName.Span))
            {
                return this.WithDescription(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultJsonPropertyName.Span))
            {
                return this.WithDefault(value.As<Menes.JsonAny>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedJsonPropertyName.Span))
            {
                return this.WithDeprecated(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyJsonPropertyName.Span))
            {
                return this.WithReadOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyJsonPropertyName.Span))
            {
                return this.WithWriteOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesJsonPropertyName.Span))
            {
                return this.WithExamples(value.As<Draft201909MetaMetaData.ExamplesArray>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatJsonPropertyName.Span))
            {
                return this.WithFormat(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeJsonPropertyName.Span))
            {
                return this.WithContentMediaType(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingJsonPropertyName.Span))
            {
                return this.WithContentEncoding(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaJsonPropertyName.Span))
            {
                return this.WithContentSchema(value.As<Draft201909MetaContent>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefinitionsJsonPropertyName.Span))
            {
                return this.WithDefinitions(value.As<Draft201909Schema.DefinitionsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependenciesJsonPropertyName.Span))
            {
                return this.WithDependencies(value.As<Draft201909Schema.DependenciesEntity>());
            }
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
            bool added = false;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (!property.NameEquals(propertyName))
                {
                    arrayBuilder.Add(property);
                }
                else
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
                    added = true;
                }
            }
            if (!added)
            {
                arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
            }
            return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
            return this;
        }
        public Draft201909Schema SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
        where T : struct, Menes.IJsonValue
        {
            System.Span<char> name = stackalloc char[utf8Name.Length];
            int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
            var propertyName = name.Slice(0, writtenCount);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdJsonPropertyName.Span))
            {
                return this.WithId(value.As<Draft201909MetaCore.IdValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaJsonPropertyName.Span))
            {
                return this.WithSchema(value.As<Menes.JsonUri>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorJsonPropertyName.Span))
            {
                return this.WithAnchor(value.As<Draft201909MetaCore.AnchorValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefJsonPropertyName.Span))
            {
                return this.WithRef(value.As<Menes.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefJsonPropertyName.Span))
            {
                return this.WithRecursiveRef(value.As<Menes.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorJsonPropertyName.Span))
            {
                return this.WithRecursiveAnchor(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyJsonPropertyName.Span))
            {
                return this.WithVocabulary(value.As<Draft201909MetaCore.VocabularyEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentJsonPropertyName.Span))
            {
                return this.WithComment(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsJsonPropertyName.Span))
            {
                return this.WithDefs(value.As<Draft201909MetaCore.DefsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalItemsJsonPropertyName.Span))
            {
                return this.WithAdditionalItems(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedItemsJsonPropertyName.Span))
            {
                return this.WithUnevaluatedItems(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesItemsJsonPropertyName.Span))
            {
                return this.WithItems(value.As<Draft201909MetaApplicator.ItemsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContainsJsonPropertyName.Span))
            {
                return this.WithContains(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalPropertiesJsonPropertyName.Span))
            {
                return this.WithAdditionalProperties(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedPropertiesJsonPropertyName.Span))
            {
                return this.WithUnevaluatedProperties(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertiesJsonPropertyName.Span))
            {
                return this.WithProperties(value.As<Draft201909MetaApplicator.PropertiesEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternPropertiesJsonPropertyName.Span))
            {
                return this.WithPatternProperties(value.As<Draft201909MetaApplicator.PatternPropertiesEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentSchemasJsonPropertyName.Span))
            {
                return this.WithDependentSchemas(value.As<Draft201909MetaApplicator.DependentSchemasEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPropertyNamesJsonPropertyName.Span))
            {
                return this.WithPropertyNames(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIfJsonPropertyName.Span))
            {
                return this.WithIf(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesThenJsonPropertyName.Span))
            {
                return this.WithThen(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesElseJsonPropertyName.Span))
            {
                return this.WithElse(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAllOfJsonPropertyName.Span))
            {
                return this.WithAllOf(value.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnyOfJsonPropertyName.Span))
            {
                return this.WithAnyOf(value.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesOneOfJsonPropertyName.Span))
            {
                return this.WithOneOf(value.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesNotJsonPropertyName.Span))
            {
                return this.WithNot(value.As<Draft201909MetaApplicator>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMultipleOfJsonPropertyName.Span))
            {
                return this.WithMultipleOf(value.As<Draft201909MetaValidation.MultipleOfValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaximumJsonPropertyName.Span))
            {
                return this.WithMaximum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMaximumJsonPropertyName.Span))
            {
                return this.WithExclusiveMaximum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinimumJsonPropertyName.Span))
            {
                return this.WithMinimum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExclusiveMinimumJsonPropertyName.Span))
            {
                return this.WithExclusiveMinimum(value.As<Menes.JsonNumber>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxLengthJsonPropertyName.Span))
            {
                return this.WithMaxLength(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinLengthJsonPropertyName.Span))
            {
                return this.WithMinLength(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesPatternJsonPropertyName.Span))
            {
                return this.WithPattern(value.As<Menes.JsonRegex>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxItemsJsonPropertyName.Span))
            {
                return this.WithMaxItems(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinItemsJsonPropertyName.Span))
            {
                return this.WithMinItems(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUniqueItemsJsonPropertyName.Span))
            {
                return this.WithUniqueItems(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxContainsJsonPropertyName.Span))
            {
                return this.WithMaxContains(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinContainsJsonPropertyName.Span))
            {
                return this.WithMinContains(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMaxPropertiesJsonPropertyName.Span))
            {
                return this.WithMaxProperties(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMinPropertiesJsonPropertyName.Span))
            {
                return this.WithMinProperties(value.As<Draft201909MetaValidation.NonNegativeIntegerValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRequiredJsonPropertyName.Span))
            {
                return this.WithRequired(value.As<Draft201909MetaValidation.StringArrayEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependentRequiredJsonPropertyName.Span))
            {
                return this.WithDependentRequired(value.As<Draft201909MetaValidation.DependentRequiredEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesConstJsonPropertyName.Span))
            {
                return this.WithConst(value.As<Menes.JsonAny>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesEnumJsonPropertyName.Span))
            {
                return this.WithEnum(value.As<Draft201909MetaValidation.EnumArray>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTypeJsonPropertyName.Span))
            {
                return this.WithType(value.As<Draft201909MetaValidation.TypeEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleJsonPropertyName.Span))
            {
                return this.WithTitle(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionJsonPropertyName.Span))
            {
                return this.WithDescription(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultJsonPropertyName.Span))
            {
                return this.WithDefault(value.As<Menes.JsonAny>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedJsonPropertyName.Span))
            {
                return this.WithDeprecated(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyJsonPropertyName.Span))
            {
                return this.WithReadOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyJsonPropertyName.Span))
            {
                return this.WithWriteOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesJsonPropertyName.Span))
            {
                return this.WithExamples(value.As<Draft201909MetaMetaData.ExamplesArray>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatJsonPropertyName.Span))
            {
                return this.WithFormat(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentMediaTypeJsonPropertyName.Span))
            {
                return this.WithContentMediaType(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentEncodingJsonPropertyName.Span))
            {
                return this.WithContentEncoding(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContentSchemaJsonPropertyName.Span))
            {
                return this.WithContentSchema(value.As<Draft201909MetaContent>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefinitionsJsonPropertyName.Span))
            {
                return this.WithDefinitions(value.As<Draft201909Schema.DefinitionsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDependenciesJsonPropertyName.Span))
            {
                return this.WithDependencies(value.As<Draft201909Schema.DependenciesEntity>());
            }
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
            bool added = false;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (!property.NameEquals(propertyName))
                {
                    arrayBuilder.Add(property);
                }
                else
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
                    added = true;
                }
            }
            if (!added)
            {
                arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
            }
            return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
            return this;
        }
        public Draft201909Schema.MenesPropertyEnumerator GetEnumerator()
        {
            return new MenesPropertyEnumerator(this);
        }
        /// <summary>
        /// Enumerate the properties in the object.
        /// </summary>
        /// <returns>The object enumerator.</returns>
        public MenesPropertyEnumerator EnumerateObject()
        {
            return new MenesPropertyEnumerator(this);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        System.Collections.Generic.IEnumerator<Menes.Property<Draft201909Schema>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909Schema>>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public Draft201909Schema WithId(Draft201909MetaCore.IdValue value)
        {
            return new Draft201909Schema(value, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithSchema(Menes.JsonUri value)
        {
            return new Draft201909Schema(this.id, value, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithAnchor(Draft201909MetaCore.AnchorValue value)
        {
            return new Draft201909Schema(this.id, this.schema, value, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithRef(Menes.JsonUriReference value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, value, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithRecursiveRef(Menes.JsonUriReference value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, value, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithRecursiveAnchor(Menes.JsonBoolean value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, value, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithVocabulary(Draft201909MetaCore.VocabularyEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, value, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithComment(Menes.JsonString value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, value, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithDefs(Draft201909MetaCore.DefsEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, value, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithAdditionalItems(Draft201909MetaApplicator value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, value, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithUnevaluatedItems(Draft201909MetaApplicator value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, value, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithItems(Draft201909MetaApplicator.ItemsEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, value, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithContains(Draft201909MetaApplicator value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, value, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithAdditionalProperties(Draft201909MetaApplicator value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, value, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithUnevaluatedProperties(Draft201909MetaApplicator value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, value, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithProperties(Draft201909MetaApplicator.PropertiesEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, value, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithPatternProperties(Draft201909MetaApplicator.PatternPropertiesEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, value, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithDependentSchemas(Draft201909MetaApplicator.DependentSchemasEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, value, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithPropertyNames(Draft201909MetaApplicator value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, value, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithIf(Draft201909MetaApplicator value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, value, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithThen(Draft201909MetaApplicator value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, value, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithElse(Draft201909MetaApplicator value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, value, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithAllOf(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, value, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithAnyOf(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, value, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithOneOf(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, value, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithNot(Draft201909MetaApplicator value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, value, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMultipleOf(Draft201909MetaValidation.MultipleOfValue value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, value, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMaximum(Menes.JsonNumber value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, value, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithExclusiveMaximum(Menes.JsonNumber value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, value, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMinimum(Menes.JsonNumber value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, value, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithExclusiveMinimum(Menes.JsonNumber value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, value, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMaxLength(Draft201909MetaValidation.NonNegativeIntegerValue value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, value, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMinLength(Draft201909MetaValidation.NonNegativeIntegerValue value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, value, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithPattern(Menes.JsonRegex value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, value, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMaxItems(Draft201909MetaValidation.NonNegativeIntegerValue value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, value, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMinItems(Draft201909MetaValidation.NonNegativeIntegerValue value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, value, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithUniqueItems(Menes.JsonBoolean value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, value, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMaxContains(Draft201909MetaValidation.NonNegativeIntegerValue value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, value, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMinContains(Draft201909MetaValidation.NonNegativeIntegerValue value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, value, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMaxProperties(Draft201909MetaValidation.NonNegativeIntegerValue value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, value, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithMinProperties(Draft201909MetaValidation.NonNegativeIntegerValue value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, value, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithRequired(Draft201909MetaValidation.StringArrayEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, value, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithDependentRequired(Draft201909MetaValidation.DependentRequiredEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, value, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithConst(Menes.JsonAny value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, value, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithEnum(Draft201909MetaValidation.EnumArray value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, value, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithType(Draft201909MetaValidation.TypeEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, value, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithTitle(Menes.JsonString value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, value, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithDescription(Menes.JsonString value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, value, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithDefault(Menes.JsonAny value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, value, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithDeprecated(Menes.JsonBoolean value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, value, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithReadOnly(Menes.JsonBoolean value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, value, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithWriteOnly(Menes.JsonBoolean value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, value, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithExamples(Draft201909MetaMetaData.ExamplesArray value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, value, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithFormat(Menes.JsonString value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, value, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithContentMediaType(Menes.JsonString value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, value, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithContentEncoding(Menes.JsonString value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, value, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithContentSchema(Draft201909MetaContent value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, value, this.definitions, this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithDefinitions(Draft201909Schema.DefinitionsEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, Menes.JsonValueBacking.From<Draft201909Schema.DefinitionsEntity>(value), this.dependencies, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909Schema WithDependencies(Draft201909Schema.DependenciesEntity value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, value, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        private TPropertyValue GetPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
            where TPropertyValue : struct, Menes.IJsonValue
        {
            return this.GetOptionalPropertyFromJsonElement<TPropertyValue>(propertyName) ?? default;
        }
        private TPropertyValue? GetOptionalPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
            where TPropertyValue : struct, Menes.IJsonValue
        {
            return this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object ?
                 (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                     ? Menes.JsonValue.As<TPropertyValue>(property)
                     : null)
                 : null;
        }
        private bool AllBackingFieldsAreNull()
        {
            if (this.id is not null)
            {
                return false;
            }
            if (this.schema is not null)
            {
                return false;
            }
            if (this.anchor is not null)
            {
                return false;
            }
            if (this.@ref is not null)
            {
                return false;
            }
            if (this.recursiveRef is not null)
            {
                return false;
            }
            if (this.recursiveAnchor is not null)
            {
                return false;
            }
            if (this.vocabulary is not null)
            {
                return false;
            }
            if (this.comment is not null)
            {
                return false;
            }
            if (this.defs is not null)
            {
                return false;
            }
            if (this.additionalItems is not null)
            {
                return false;
            }
            if (this.unevaluatedItems is not null)
            {
                return false;
            }
            if (this.items is not null)
            {
                return false;
            }
            if (this.contains is not null)
            {
                return false;
            }
            if (this.additionalProperties is not null)
            {
                return false;
            }
            if (this.unevaluatedProperties is not null)
            {
                return false;
            }
            if (this.properties is not null)
            {
                return false;
            }
            if (this.patternProperties is not null)
            {
                return false;
            }
            if (this.dependentSchemas is not null)
            {
                return false;
            }
            if (this.propertyNames is not null)
            {
                return false;
            }
            if (this.@if is not null)
            {
                return false;
            }
            if (this.then is not null)
            {
                return false;
            }
            if (this.@else is not null)
            {
                return false;
            }
            if (this.allOf is not null)
            {
                return false;
            }
            if (this.anyOf is not null)
            {
                return false;
            }
            if (this.oneOf is not null)
            {
                return false;
            }
            if (this.not is not null)
            {
                return false;
            }
            if (this.multipleOf is not null)
            {
                return false;
            }
            if (this.maximum is not null)
            {
                return false;
            }
            if (this.exclusiveMaximum is not null)
            {
                return false;
            }
            if (this.minimum is not null)
            {
                return false;
            }
            if (this.exclusiveMinimum is not null)
            {
                return false;
            }
            if (this.maxLength is not null)
            {
                return false;
            }
            if (this.minLength is not null)
            {
                return false;
            }
            if (this.pattern is not null)
            {
                return false;
            }
            if (this.maxItems is not null)
            {
                return false;
            }
            if (this.minItems is not null)
            {
                return false;
            }
            if (this.uniqueItems is not null)
            {
                return false;
            }
            if (this.maxContains is not null)
            {
                return false;
            }
            if (this.minContains is not null)
            {
                return false;
            }
            if (this.maxProperties is not null)
            {
                return false;
            }
            if (this.minProperties is not null)
            {
                return false;
            }
            if (this.required is not null)
            {
                return false;
            }
            if (this.dependentRequired is not null)
            {
                return false;
            }
            if (this.@const is not null)
            {
                return false;
            }
            if (this.@enum is not null)
            {
                return false;
            }
            if (this.type is not null)
            {
                return false;
            }
            if (this.title is not null)
            {
                return false;
            }
            if (this.description is not null)
            {
                return false;
            }
            if (this.@default is not null)
            {
                return false;
            }
            if (this.deprecated is not null)
            {
                return false;
            }
            if (this.readOnly is not null)
            {
                return false;
            }
            if (this.writeOnly is not null)
            {
                return false;
            }
            if (this.examples is not null)
            {
                return false;
            }
            if (this.format is not null)
            {
                return false;
            }
            if (this.contentMediaType is not null)
            {
                return false;
            }
            if (this.contentEncoding is not null)
            {
                return false;
            }
            if (this.contentSchema is not null)
            {
                return false;
            }
            if (!this.definitions.IsNull)
            {
                return false;
            }
            if (this.dependencies is not null)
            {
                return false;
            }
            if (this._menesAdditionalPropertiesBacking.Length > 0)
            {
                return false;
            }
            if (this._menesBooleanTypeBacking is not null)
            {
                return false;
            }
            return true;
        }
        /// <inheritdoc />
        private bool TryGetPropertyAtIndex(int index, out Menes.Property<Draft201909Schema> result)
        {
            if (this.HasJsonElement)
            {
                int jsonPropertyIndex = 0;
                foreach (var property in this.JsonElement.EnumerateObject())
                {
                    if (jsonPropertyIndex == index)
                    {
                        result = new Menes.Property<Draft201909Schema>(property);
                        return true;
                    }
                    jsonPropertyIndex++;
                }
            }
            int currentIndex = 0;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesIdJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesSchemaJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesAnchorJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesRefJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesRecursiveRefJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesRecursiveAnchorJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesVocabularyJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesCommentJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesDefsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesAdditionalItemsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesUnevaluatedItemsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesItemsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesContainsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesAdditionalPropertiesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesUnevaluatedPropertiesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesPropertiesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesPatternPropertiesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesDependentSchemasJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesPropertyNamesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesIfJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesThenJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesElseJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesAllOfJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesAnyOfJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesOneOfJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesNotJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMultipleOfJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMaximumJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesExclusiveMaximumJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMinimumJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesExclusiveMinimumJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMaxLengthJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMinLengthJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesPatternJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMaxItemsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMinItemsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesUniqueItemsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMaxContainsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMinContainsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMaxPropertiesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesMinPropertiesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesRequiredJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesDependentRequiredJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesConstJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesEnumJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesTypeJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesTitleJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesDescriptionJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesDefaultJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesDeprecatedJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesReadOnlyJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesWriteOnlyJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesExamplesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesFormatJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesContentMediaTypeJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesContentEncodingJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesContentSchemaJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesDefinitionsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909Schema>(this, _MenesDependenciesJsonPropertyName);
                return true;
            }
            currentIndex++;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (currentIndex == index)
                {
                    result = new Menes.Property<Draft201909Schema>(this, property.NameAsMemory);
                    return true;
                }
                currentIndex++;
            }
            result = default; ;
            return false;
        }
        private Draft201909Schema WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
        {
            return new Draft201909Schema(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this.format, this.contentMediaType, this.contentEncoding, this.contentSchema, this.definitions, this.dependencies, this._menesBooleanTypeBacking, value);
        }
        public readonly struct DefinitionsEntity : Menes.IJsonObject<DefinitionsEntity>
        {
            public static readonly DefinitionsEntity Null = default(DefinitionsEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking;
            public DefinitionsEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty>.Empty;
            }
            private DefinitionsEntity(in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
            }
            /// <inheritdoc />
            public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
            /// <inheritdoc />
            public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool IsNumber => false;
            /// <inheritdoc />
            public bool IsInteger => false;
            /// <inheritdoc />
            public bool IsString => false;
            /// <inheritdoc />
            public bool IsObject => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object) || (!this.HasJsonElement && !this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool IsBoolean => false;
            /// <inheritdoc />
            public bool IsArray => false;
            /// <inheritdoc />
            public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            /// <inheritdoc />
            public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
            public int PropertyCount
            {
                get
                {
                    if (this.HasJsonElement)
                    {
                        int jsonPropertyIndex = 0;
                        foreach (var property in this.JsonElement.EnumerateObject())
                        {
                            jsonPropertyIndex++;
                        }
                        return jsonPropertyIndex;
                    }
                    else
                    {
                        return this._menesAdditionalPropertiesBacking.Length;
                    }
                }
            }
            /// <inheritdoc />
            public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                evaluatedProperties = evaluatedProperties ?? new System.Collections.Generic.HashSet<string>();
                var composedEvaluatedProperties = new System.Collections.Generic.HashSet<string>();
                var composedEvaluatedIndices = new System.Collections.Generic.HashSet<int>();
                Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
                if (!this.IsObject)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        string? il = null;
                        string? akl = null;
                        instanceLocation?.TryPeek(out il);
                        absoluteKeywordLocation?.TryPeek(out akl);
                        result.AddResult(valid: false, message: "6.1.1.  type - item must be one of object", instanceLocation: il, absoluteKeywordLocation: akl);
                    }
                    else
                    {
                        result.SetValid(false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.Valid)
                    {
                        return result;
                    }
                }
                if (this.IsObject)
                {
                    foreach (var property in this.EnumerateObject())
                    {
                        if (!evaluatedProperties?.Contains(property.Name) ?? true)
                        {
                            evaluatedProperties?.Add(property.Name);
                            result = property.Value<Draft201909Schema>().Validate(result, level, null, absoluteKeywordLocation, instanceLocation);
                            if (level == Menes.ValidationLevel.Flag && !result.Valid)
                            {
                                return result;
                            }
                        }
                    }
                }
                return result;
            }
            /// <inheritdoc />
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                    return;
                }
                writer.WriteStartObject();
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    property.WriteTo(writer);
                }
                writer.WriteEndObject();
            }
            /// <inheritdoc />
            public T As<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(DefinitionsEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<DefinitionsEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909Schema.DefinitionsEntity))
                {
                    return this.Validate().Valid;
                }
                return this.As<T>().Validate().Valid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(T other)
                where T : struct, Menes.IJsonValue
            {
                if (!other.IsObject)
                {
                    return false;
                }
                var otherObject = Corvus.Extensions.CastTo<Menes.IJsonObject>.From(other);
                MenesPropertyEnumerator firstEnumerator = this.EnumerateObject();
                if (this.PropertyCount != otherObject.PropertyCount)
                {
                    return false;
                }
                while (firstEnumerator.MoveNext())
                {
                    if (!otherObject.TryGetProperty<Menes.JsonAny>(firstEnumerator.Current.NameAsMemory.Span, out Menes.JsonAny otherProperty))
                    {
                        return false;
                    }
                    if (!firstEnumerator.Current.Value<Menes.JsonAny>().Equals(otherProperty))
                    {
                        return false;
                    }
                }
                return true;
            }
            /// <inheritdoc/>
            public bool HasProperty(System.ReadOnlySpan<char> propertyName)
            {
                if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
                {
                    return true;
                }
                else
                {
                    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                    {
                        if (additionalProperty.NameEquals(propertyName))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            /// <inheritdoc/>
            public bool HasProperty(string propertyName)
            {
                if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
                {
                    return true;
                }
                else
                {
                    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                    {
                        if (additionalProperty.NameEquals(propertyName))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            /// <inheritdoc/>
            public bool HasProperty(System.ReadOnlySpan<byte> propertyName)
            {
                if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
                {
                    return true;
                }
                else
                {
                    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                    {
                        if (additionalProperty.NameEquals(propertyName))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            /// <inheritdoc />
            public bool TryGetProperty<T>(System.ReadOnlySpan<char> propertyName, out T property)
                where T : struct, Menes.IJsonValue
            {
                if (this.HasJsonElement)
                {
                    if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                    {
                        property = Menes.JsonValue.As<T>(value);
                        return true;
                    }
                    property = default;
                    return false;
                }
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        property = additionalProperty.Value<Draft201909Schema>()?.As<T>() ?? default;
                        return true;
                    }
                }
                property = default;
                return false;
            }
            /// <inheritdoc />
            public bool TryGetProperty<T>(string propertyName, out T property)
                where T : struct, Menes.IJsonValue
            {
                if (this.HasJsonElement)
                {
                    if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                    {
                        property = Menes.JsonValue.As<T>(value);
                        return true;
                    }
                    property = default;
                    return false;
                }
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        property = additionalProperty.Value<Draft201909Schema>()?.As<T>() ?? default;
                        return true;
                    }
                }
                property = default;
                return false;
            }
            /// <inheritdoc />
            public bool TryGetProperty<T>(System.ReadOnlySpan<byte> propertyName, out T property)
                where T : struct, Menes.IJsonValue
            {
                if (this.HasJsonElement)
                {
                    if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                    {
                        property = Menes.JsonValue.As<T>(value);
                        return true;
                    }
                    property = default;
                    return false;
                }
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        property = additionalProperty.Value<Draft201909Schema>()?.As<T>() ?? default;
                        return true;
                    }
                }
                property = default;
                return false;
            }
            /// <inheritdoc />
            public bool TryGetPropertyAtIndex(int index, out Menes.IProperty result)
            {
                var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<DefinitionsEntity> prop);
                result = prop;
                return rc;
            }
            public DefinitionsEntity RemoveProperty(string propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public DefinitionsEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public DefinitionsEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public DefinitionsEntity SetProperty<T>(string name, T value)
            where T : struct, Menes.IJsonValue
            {
                var propertyName = System.MemoryExtensions.AsSpan(name);
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.AdditionalProperty(propertyName, Menes.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty(propertyName, Menes.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public DefinitionsEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
            where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.AdditionalProperty(propertyName, Menes.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty(propertyName, Menes.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public DefinitionsEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
            where T : struct, Menes.IJsonValue
            {
                System.Span<char> name = stackalloc char[utf8Name.Length];
                int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
                var propertyName = name.Slice(0, writtenCount);
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.AdditionalProperty(propertyName, Menes.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty(propertyName, Menes.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public Draft201909Schema.DefinitionsEntity.MenesPropertyEnumerator GetEnumerator()
            {
                return new MenesPropertyEnumerator(this);
            }
            /// <summary>
            /// Enumerate the properties in the object.
            /// </summary>
            /// <returns>The object enumerator.</returns>
            public MenesPropertyEnumerator EnumerateObject()
            {
                return new MenesPropertyEnumerator(this);
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Menes.Property<Draft201909Schema.DefinitionsEntity>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909Schema.DefinitionsEntity>>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            private TPropertyValue GetPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
                where TPropertyValue : struct, Menes.IJsonValue
            {
                return this.GetOptionalPropertyFromJsonElement<TPropertyValue>(propertyName) ?? default;
            }
            private TPropertyValue? GetOptionalPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
                where TPropertyValue : struct, Menes.IJsonValue
            {
                return this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object ?
                     (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                         ? Menes.JsonValue.As<TPropertyValue>(property)
                         : null)
                     : null;
            }
            private bool AllBackingFieldsAreNull()
            {
                if (this._menesAdditionalPropertiesBacking.Length > 0)
                {
                    return false;
                }
                return true;
            }
            /// <inheritdoc />
            private bool TryGetPropertyAtIndex(int index, out Menes.Property<DefinitionsEntity> result)
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        if (jsonPropertyIndex == index)
                        {
                            result = new Menes.Property<DefinitionsEntity>(property);
                            return true;
                        }
                        jsonPropertyIndex++;
                    }
                }
                int currentIndex = 0;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (currentIndex == index)
                    {
                        result = new Menes.Property<DefinitionsEntity>(this, property.NameAsMemory);
                        return true;
                    }
                    currentIndex++;
                }
                result = default; ;
                return false;
            }
            private DefinitionsEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> value)
            {
                return new DefinitionsEntity(value);
            }
            /// <summary>
            /// An enumerator for the properties in a <see cref="DefinitionsEntity"/>.
            /// </summary>
            public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<DefinitionsEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<DefinitionsEntity>>, System.Collections.IEnumerator
            {
                private DefinitionsEntity instance;
                private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                private int propertyCount;
                internal MenesPropertyEnumerator(DefinitionsEntity instance)
                {
                    this.instance = instance;
                    this.propertyCount = instance.PropertyCount;
                    if (this.instance.HasJsonElement)
                    {
                        this.index = -2;
                        this.hasJsonEnumerator = true;
                        this.jsonEnumerator = this.instance.JsonElement.EnumerateObject();
                    }
                    else
                    {
                        this.index = -1;
                        this.hasJsonEnumerator = false;
                        this.jsonEnumerator = default;
                    }
                }
                /// <inheritdoc/>
                public Menes.Property<DefinitionsEntity> Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.Property<DefinitionsEntity>(this.jsonEnumerator.Current);
                        }
                        else if (this.index >= 0)
                        {
                            if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<DefinitionsEntity> result))
                            {
                                return result;
                            }
                            throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                        }
                        return new Menes.Property<DefinitionsEntity>(this.instance, default);
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the properties in a <see cref="DefinitionsEntity"/>.</returns>
                public MenesPropertyEnumerator GetEnumerator()
                {
                    MenesPropertyEnumerator result = this;
                    result.Reset();
                    return result;
                }
                /// <inheritdoc/>
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc/>
                System.Collections.Generic.IEnumerator<Menes.Property<DefinitionsEntity>> System.Collections.Generic.IEnumerable<Menes.Property<DefinitionsEntity>>.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc/>
                public void Dispose()
                {
                    if (this.hasJsonEnumerator)
                    {
                        this.jsonEnumerator.Dispose();
                    }
                }
                /// <inheritdoc/>
                public void Reset()
                {
                    if (this.hasJsonEnumerator)
                    {
                        this.jsonEnumerator.Reset();
                    }
                }
                /// <inheritdoc/>
                public bool MoveNext()
                {
                    if (this.hasJsonEnumerator)
                    {
                        return this.jsonEnumerator.MoveNext();
                    }
                    else
                    {
                        if (this.index + 1 < this.propertyCount)
                        {
                            this.index++;
                            return true;
                        }
                        return false;
                    }
                }
            }
        }
        public readonly struct DependenciesEntity : Menes.IJsonObject<DependenciesEntity>
        {
            public static readonly DependenciesEntity Null = default(DependenciesEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>> _menesAdditionalPropertiesBacking;
            public DependenciesEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>>.Empty;
            }
            private DependenciesEntity(in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>> _menesAdditionalPropertiesBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
            }
            /// <inheritdoc />
            public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
            /// <inheritdoc />
            public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool IsNumber => false;
            /// <inheritdoc />
            public bool IsInteger => false;
            /// <inheritdoc />
            public bool IsString => false;
            /// <inheritdoc />
            public bool IsObject => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object) || (!this.HasJsonElement && !this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool IsBoolean => false;
            /// <inheritdoc />
            public bool IsArray => false;
            /// <inheritdoc />
            public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            /// <inheritdoc />
            public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
            public int PropertyCount
            {
                get
                {
                    if (this.HasJsonElement)
                    {
                        int jsonPropertyIndex = 0;
                        foreach (var property in this.JsonElement.EnumerateObject())
                        {
                            jsonPropertyIndex++;
                        }
                        return jsonPropertyIndex;
                    }
                    else
                    {
                        return this._menesAdditionalPropertiesBacking.Length;
                    }
                }
            }
            /// <inheritdoc />
            public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                evaluatedProperties = evaluatedProperties ?? new System.Collections.Generic.HashSet<string>();
                var composedEvaluatedProperties = new System.Collections.Generic.HashSet<string>();
                var composedEvaluatedIndices = new System.Collections.Generic.HashSet<int>();
                Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
                if (!this.IsObject)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        string? il = null;
                        string? akl = null;
                        instanceLocation?.TryPeek(out il);
                        absoluteKeywordLocation?.TryPeek(out akl);
                        result.AddResult(valid: false, message: "6.1.1.  type - item must be one of object", instanceLocation: il, absoluteKeywordLocation: akl);
                    }
                    else
                    {
                        result.SetValid(false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.Valid)
                    {
                        return result;
                    }
                }
                if (this.IsObject)
                {
                    foreach (var property in this.EnumerateObject())
                    {
                        if (!evaluatedProperties?.Contains(property.Name) ?? true)
                        {
                            evaluatedProperties?.Add(property.Name);
                            result = property.Value<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>().Validate(result, level, null, absoluteKeywordLocation, instanceLocation);
                            if (level == Menes.ValidationLevel.Flag && !result.Valid)
                            {
                                return result;
                            }
                        }
                    }
                }
                return result;
            }
            /// <inheritdoc />
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                    return;
                }
                writer.WriteStartObject();
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    property.WriteTo(writer);
                }
                writer.WriteEndObject();
            }
            /// <inheritdoc />
            public T As<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(DependenciesEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<DependenciesEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909Schema.DependenciesEntity))
                {
                    return this.Validate().Valid;
                }
                return this.As<T>().Validate().Valid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(T other)
                where T : struct, Menes.IJsonValue
            {
                if (!other.IsObject)
                {
                    return false;
                }
                var otherObject = Corvus.Extensions.CastTo<Menes.IJsonObject>.From(other);
                MenesPropertyEnumerator firstEnumerator = this.EnumerateObject();
                if (this.PropertyCount != otherObject.PropertyCount)
                {
                    return false;
                }
                while (firstEnumerator.MoveNext())
                {
                    if (!otherObject.TryGetProperty<Menes.JsonAny>(firstEnumerator.Current.NameAsMemory.Span, out Menes.JsonAny otherProperty))
                    {
                        return false;
                    }
                    if (!firstEnumerator.Current.Value<Menes.JsonAny>().Equals(otherProperty))
                    {
                        return false;
                    }
                }
                return true;
            }
            /// <inheritdoc/>
            public bool HasProperty(System.ReadOnlySpan<char> propertyName)
            {
                if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
                {
                    return true;
                }
                else
                {
                    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                    {
                        if (additionalProperty.NameEquals(propertyName))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            /// <inheritdoc/>
            public bool HasProperty(string propertyName)
            {
                if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
                {
                    return true;
                }
                else
                {
                    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                    {
                        if (additionalProperty.NameEquals(propertyName))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            /// <inheritdoc/>
            public bool HasProperty(System.ReadOnlySpan<byte> propertyName)
            {
                if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
                {
                    return true;
                }
                else
                {
                    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                    {
                        if (additionalProperty.NameEquals(propertyName))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            /// <inheritdoc />
            public bool TryGetProperty<T>(System.ReadOnlySpan<char> propertyName, out T property)
                where T : struct, Menes.IJsonValue
            {
                if (this.HasJsonElement)
                {
                    if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                    {
                        property = Menes.JsonValue.As<T>(value);
                        return true;
                    }
                    property = default;
                    return false;
                }
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        property = additionalProperty.Value.As<T>();
                        return true;
                    }
                }
                property = default;
                return false;
            }
            /// <inheritdoc />
            public bool TryGetProperty<T>(string propertyName, out T property)
                where T : struct, Menes.IJsonValue
            {
                if (this.HasJsonElement)
                {
                    if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                    {
                        property = Menes.JsonValue.As<T>(value);
                        return true;
                    }
                    property = default;
                    return false;
                }
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        property = additionalProperty.Value.As<T>();
                        return true;
                    }
                }
                property = default;
                return false;
            }
            /// <inheritdoc />
            public bool TryGetProperty<T>(System.ReadOnlySpan<byte> propertyName, out T property)
                where T : struct, Menes.IJsonValue
            {
                if (this.HasJsonElement)
                {
                    if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                    {
                        property = Menes.JsonValue.As<T>(value);
                        return true;
                    }
                    property = default;
                    return false;
                }
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        property = additionalProperty.Value.As<T>();
                        return true;
                    }
                }
                property = default;
                return false;
            }
            /// <inheritdoc />
            public bool TryGetPropertyAtIndex(int index, out Menes.IProperty result)
            {
                var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<DependenciesEntity> prop);
                result = prop;
                return rc;
            }
            public DependenciesEntity RemoveProperty(string propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public DependenciesEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public DependenciesEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public DependenciesEntity SetProperty<T>(string name, T value)
            where T : struct, Menes.IJsonValue
            {
                var propertyName = System.MemoryExtensions.AsSpan(name);
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>(propertyName, value.As<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>()));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>(propertyName, value.As<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>()));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public DependenciesEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
            where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>(propertyName, value.As<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>()));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>(propertyName, value.As<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>()));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public DependenciesEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
            where T : struct, Menes.IJsonValue
            {
                System.Span<char> name = stackalloc char[utf8Name.Length];
                int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
                var propertyName = name.Slice(0, writtenCount);
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>(propertyName, value.As<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>()));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>(propertyName, value.As<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>()));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public Draft201909Schema.DependenciesEntity.MenesPropertyEnumerator GetEnumerator()
            {
                return new MenesPropertyEnumerator(this);
            }
            /// <summary>
            /// Enumerate the properties in the object.
            /// </summary>
            /// <returns>The object enumerator.</returns>
            public MenesPropertyEnumerator EnumerateObject()
            {
                return new MenesPropertyEnumerator(this);
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Menes.Property<Draft201909Schema.DependenciesEntity>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909Schema.DependenciesEntity>>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            private TPropertyValue GetPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
                where TPropertyValue : struct, Menes.IJsonValue
            {
                return this.GetOptionalPropertyFromJsonElement<TPropertyValue>(propertyName) ?? default;
            }
            private TPropertyValue? GetOptionalPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
                where TPropertyValue : struct, Menes.IJsonValue
            {
                return this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object ?
                     (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                         ? Menes.JsonValue.As<TPropertyValue>(property)
                         : null)
                     : null;
            }
            private bool AllBackingFieldsAreNull()
            {
                if (this._menesAdditionalPropertiesBacking.Length > 0)
                {
                    return false;
                }
                return true;
            }
            /// <inheritdoc />
            private bool TryGetPropertyAtIndex(int index, out Menes.Property<DependenciesEntity> result)
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        if (jsonPropertyIndex == index)
                        {
                            result = new Menes.Property<DependenciesEntity>(property);
                            return true;
                        }
                        jsonPropertyIndex++;
                    }
                }
                int currentIndex = 0;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (currentIndex == index)
                    {
                        result = new Menes.Property<DependenciesEntity>(this, property.NameAsMemory);
                        return true;
                    }
                    currentIndex++;
                }
                result = default; ;
                return false;
            }
            private DependenciesEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>> value)
            {
                return new DependenciesEntity(value);
            }
            public readonly struct AdditionalPropertiesEntity : Menes.IJsonValue
            {
                public static readonly AdditionalPropertiesEntity Null = default(AdditionalPropertiesEntity);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                public AdditionalPropertiesEntity(System.Text.Json.JsonElement jsonElement)
                {
                    this._menesJsonElementBacking = jsonElement;
                }
                public static implicit operator Draft201909Schema(AdditionalPropertiesEntity value)
                {
                    return value.As<Draft201909Schema>();
                }
                public static implicit operator AdditionalPropertiesEntity(Draft201909Schema value)
                {
                    return value.As<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>();
                }
                public static implicit operator Draft201909MetaValidation.StringArrayEntity(AdditionalPropertiesEntity value)
                {
                    return value.As<Draft201909MetaValidation.StringArrayEntity>();
                }
                public static implicit operator AdditionalPropertiesEntity(Draft201909MetaValidation.StringArrayEntity value)
                {
                    return value.As<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>();
                }
                public static implicit operator AdditionalPropertiesEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonString> items)
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                    foreach (var item in items)
                    {
                        arrayBuilder.Add((Menes.JsonString)item);
                    }
                    return (AdditionalPropertiesEntity)(Draft201909MetaValidation.StringArrayEntity)arrayBuilder.ToImmutable();
                }
                /// <inheritdoc />
                public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
                /// <inheritdoc />
                public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
                /// <inheritdoc />
                public bool IsNumber => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number;
                /// <inheritdoc />
                public bool IsInteger => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number;
                /// <inheritdoc />
                public bool IsString => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String;
                /// <inheritdoc />
                public bool IsObject => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object;
                /// <inheritdoc />
                public bool IsBoolean => this.HasJsonElement && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.True || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.False);
                /// <inheritdoc />
                public bool IsArray => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Array;
                /// <inheritdoc />
                public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
                /// <inheritdoc />
                public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
                /// <inheritdoc />
                public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
                {
                    evaluatedProperties = evaluatedProperties ?? new System.Collections.Generic.HashSet<string>();
                    var composedEvaluatedProperties = new System.Collections.Generic.HashSet<string>();
                    var composedEvaluatedIndices = new System.Collections.Generic.HashSet<int>();
                    Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
                    result = ValidateAnyOf(this, result, level, composedEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                    return result;
                    Menes.ValidationResult ValidateAnyOf(in Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
                    {
                        System.Collections.Generic.HashSet<string> localEvaluatedProperties = new System.Collections.Generic.HashSet<string>();
                        if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush0)
                        {
                            aklPush0.Push("https://json-schema.org/draft/2019-09/schema#/properties/dependencies/additionalProperties/anyOf/0");
                        }
                        localEvaluatedProperties.Clear();
                        Menes.ValidationResult anyOfResult0;
                        var anyOf0 = that.AsDraft201909Schema();
                        anyOfResult0 = anyOf0.Validate(null, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                        if (level == Menes.ValidationLevel.Flag && anyOfResult0.Valid)
                        {
                            return result;
                        }
                        if (anyOfResult0.Valid)
                        {
                            foreach (var item in localEvaluatedProperties)
                            {
                                evaluatedProperties.Add(item);
                            }
                        }
                        if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop0)
                        {
                            aklPop0.Pop();
                        }
                        if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush1)
                        {
                            aklPush1.Push("https://json-schema.org/draft/2019-09/schema#/properties/dependencies/additionalProperties/anyOf/1");
                        }
                        localEvaluatedProperties.Clear();
                        Menes.ValidationResult anyOfResult1;
                        var anyOf1 = that.AsStringArrayEntity();
                        anyOfResult1 = anyOf1.Validate(null, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                        if (level == Menes.ValidationLevel.Flag && anyOfResult1.Valid)
                        {
                            return result;
                        }
                        if (anyOfResult1.Valid)
                        {
                            foreach (var item in localEvaluatedProperties)
                            {
                                evaluatedProperties.Add(item);
                            }
                        }
                        if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop1)
                        {
                            aklPop1.Pop();
                        }
                        if (!anyOfResult0.Valid && !anyOfResult1.Valid)
                        {
                            if (level >= Menes.ValidationLevel.Basic)
                            {
                                string? il = null;
                                string? akl = null;
                                instanceLocation?.TryPeek(out il);
                                absoluteKeywordLocation?.TryPeek(out akl);
                                result.AddResult(valid: false, message: "9.2.1.2. anyOf", instanceLocation: il, absoluteKeywordLocation: akl);
                            }
                            else
                            {
                                result.SetValid(false);
                            }
                        }
                        else
                        {
                            if (level == Menes.ValidationLevel.Verbose)
                            {
                                string? il = null;
                                string? akl = null;
                                instanceLocation?.TryPeek(out il);
                                absoluteKeywordLocation?.TryPeek(out akl);
                                result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
                            }
                        }
                        return result;
                    }
                }
                /// <inheritdoc />
                public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
                {
                    if (this.HasJsonElement)
                    {
                        this.JsonElement.WriteTo(writer);
                        return;
                    }
                }
                /// <inheritdoc />
                public T As<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(AdditionalPropertiesEntity))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<AdditionalPropertiesEntity, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity))
                    {
                        return this.Validate().Valid;
                    }
                    return this.As<T>().Validate().Valid;
                }
                public readonly Draft201909Schema AsDraft201909Schema()
                {
                    return this.As<Draft201909Schema>();
                }
                public readonly Draft201909MetaValidation.StringArrayEntity AsStringArrayEntity()
                {
                    return this.As<Draft201909MetaValidation.StringArrayEntity>();
                }
                /// <inheritdoc/>
                public bool Equals<T>(T other)
                    where T : struct, Menes.IJsonValue
                {
                    return false;
                }
                private bool AllBackingFieldsAreNull()
                {
                    return true;
                }
            }
            /// <summary>
            /// An enumerator for the properties in a <see cref="DependenciesEntity"/>.
            /// </summary>
            public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<DependenciesEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<DependenciesEntity>>, System.Collections.IEnumerator
            {
                private DependenciesEntity instance;
                private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                private int propertyCount;
                internal MenesPropertyEnumerator(DependenciesEntity instance)
                {
                    this.instance = instance;
                    this.propertyCount = instance.PropertyCount;
                    if (this.instance.HasJsonElement)
                    {
                        this.index = -2;
                        this.hasJsonEnumerator = true;
                        this.jsonEnumerator = this.instance.JsonElement.EnumerateObject();
                    }
                    else
                    {
                        this.index = -1;
                        this.hasJsonEnumerator = false;
                        this.jsonEnumerator = default;
                    }
                }
                /// <inheritdoc/>
                public Menes.Property<DependenciesEntity> Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.Property<DependenciesEntity>(this.jsonEnumerator.Current);
                        }
                        else if (this.index >= 0)
                        {
                            if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<DependenciesEntity> result))
                            {
                                return result;
                            }
                            throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                        }
                        return new Menes.Property<DependenciesEntity>(this.instance, default);
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the properties in a <see cref="DependenciesEntity"/>.</returns>
                public MenesPropertyEnumerator GetEnumerator()
                {
                    MenesPropertyEnumerator result = this;
                    result.Reset();
                    return result;
                }
                /// <inheritdoc/>
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc/>
                System.Collections.Generic.IEnumerator<Menes.Property<DependenciesEntity>> System.Collections.Generic.IEnumerable<Menes.Property<DependenciesEntity>>.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc/>
                public void Dispose()
                {
                    if (this.hasJsonEnumerator)
                    {
                        this.jsonEnumerator.Dispose();
                    }
                }
                /// <inheritdoc/>
                public void Reset()
                {
                    if (this.hasJsonEnumerator)
                    {
                        this.jsonEnumerator.Reset();
                    }
                }
                /// <inheritdoc/>
                public bool MoveNext()
                {
                    if (this.hasJsonEnumerator)
                    {
                        return this.jsonEnumerator.MoveNext();
                    }
                    else
                    {
                        if (this.index + 1 < this.propertyCount)
                        {
                            this.index++;
                            return true;
                        }
                        return false;
                    }
                }
            }
        }
        /// <summary>
        /// An enumerator for the properties in a <see cref="Draft201909Schema"/>.
        /// </summary>
        public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<Draft201909Schema>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<Draft201909Schema>>, System.Collections.IEnumerator
        {
            private Draft201909Schema instance;
            private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
            private bool hasJsonEnumerator;
            private int index;
            private int propertyCount;
            internal MenesPropertyEnumerator(Draft201909Schema instance)
            {
                this.instance = instance;
                this.propertyCount = instance.PropertyCount;
                if (this.instance.HasJsonElement)
                {
                    this.index = -2;
                    this.hasJsonEnumerator = true;
                    this.jsonEnumerator = this.instance.JsonElement.EnumerateObject();
                }
                else
                {
                    this.index = -1;
                    this.hasJsonEnumerator = false;
                    this.jsonEnumerator = default;
                }
            }
            /// <inheritdoc/>
            public Menes.Property<Draft201909Schema> Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new Menes.Property<Draft201909Schema>(this.jsonEnumerator.Current);
                    }
                    else if (this.index >= 0)
                    {
                        if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<Draft201909Schema> result))
                        {
                            return result;
                        }
                        throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                    }
                    return new Menes.Property<Draft201909Schema>(this.instance, default);
                }
            }
            /// <inheritdoc/>
            object System.Collections.IEnumerator.Current => this.Current;
            /// <summary>
            /// Returns a fresh copy of the enumerator
            /// </summary>
            /// <returns>An enumerator for the properties in a <see cref="Draft201909Schema"/>.</returns>
            public MenesPropertyEnumerator GetEnumerator()
            {
                MenesPropertyEnumerator result = this;
                result.Reset();
                return result;
            }
            /// <inheritdoc/>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            /// <inheritdoc/>
            System.Collections.Generic.IEnumerator<Menes.Property<Draft201909Schema>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909Schema>>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            /// <inheritdoc/>
            public void Dispose()
            {
                if (this.hasJsonEnumerator)
                {
                    this.jsonEnumerator.Dispose();
                }
            }
            /// <inheritdoc/>
            public void Reset()
            {
                if (this.hasJsonEnumerator)
                {
                    this.jsonEnumerator.Reset();
                }
            }
            /// <inheritdoc/>
            public bool MoveNext()
            {
                if (this.hasJsonEnumerator)
                {
                    return this.jsonEnumerator.MoveNext();
                }
                else
                {
                    if (this.index + 1 < this.propertyCount)
                    {
                        this.index++;
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}
