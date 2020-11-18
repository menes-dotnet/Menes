// <copyright file="Draft201909Schema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
using System;

namespace TestSpace
{
    public readonly struct Draft201909Schema : Menes.IJsonValue
    {
        public static readonly Draft201909Schema Null = default(Draft201909Schema);
        private static readonly System.ReadOnlyMemory<char> _MenesIdJsonPropertyName = System.MemoryExtensions.AsMemory("id");
        private static readonly System.ReadOnlyMemory<char> _MenesSchemaJsonPropertyName = System.MemoryExtensions.AsMemory("schema");
        private static readonly System.ReadOnlyMemory<char> _MenesAnchorJsonPropertyName = System.MemoryExtensions.AsMemory("anchor");
        private static readonly System.ReadOnlyMemory<char> _MenesRefJsonPropertyName = System.MemoryExtensions.AsMemory("@ref");
        private static readonly System.ReadOnlyMemory<char> _MenesRecursiveRefJsonPropertyName = System.MemoryExtensions.AsMemory("recursiveRef");
        private static readonly System.ReadOnlyMemory<char> _MenesRecursiveAnchorJsonPropertyName = System.MemoryExtensions.AsMemory("recursiveAnchor");
        private static readonly System.ReadOnlyMemory<char> _MenesVocabularyJsonPropertyName = System.MemoryExtensions.AsMemory("vocabulary");
        private static readonly System.ReadOnlyMemory<char> _MenesCommentJsonPropertyName = System.MemoryExtensions.AsMemory("comment");
        private static readonly System.ReadOnlyMemory<char> _MenesDefsJsonPropertyName = System.MemoryExtensions.AsMemory("defs");
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
        private static readonly System.ReadOnlyMemory<char> _MenesIfJsonPropertyName = System.MemoryExtensions.AsMemory("@if");
        private static readonly System.ReadOnlyMemory<char> _MenesThenJsonPropertyName = System.MemoryExtensions.AsMemory("then");
        private static readonly System.ReadOnlyMemory<char> _MenesElseJsonPropertyName = System.MemoryExtensions.AsMemory("@else");
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
        private static readonly System.ReadOnlyMemory<char> _MenesConstJsonPropertyName = System.MemoryExtensions.AsMemory("@const");
        private static readonly System.ReadOnlyMemory<char> _MenesEnumJsonPropertyName = System.MemoryExtensions.AsMemory("@enum");
        private static readonly System.ReadOnlyMemory<char> _MenesTypeJsonPropertyName = System.MemoryExtensions.AsMemory("type");
        private static readonly System.ReadOnlyMemory<char> _MenesTitleJsonPropertyName = System.MemoryExtensions.AsMemory("title");
        private static readonly System.ReadOnlyMemory<char> _MenesDescriptionJsonPropertyName = System.MemoryExtensions.AsMemory("description");
        private static readonly System.ReadOnlyMemory<char> _MenesDefaultJsonPropertyName = System.MemoryExtensions.AsMemory("@default");
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
        private readonly Draft201909MetaCore.SchemaValue? schema;
        private readonly Draft201909MetaCore.AnchorValue? anchor;
        private readonly Draft201909MetaCore.RefValue? @ref;
        private readonly Draft201909MetaCore.RecursiveRefValue? recursiveRef;
        private readonly Draft201909MetaCore.RecursiveAnchorValue? recursiveAnchor;
        private readonly Draft201909MetaCore.VocabularyEntity? vocabulary;
        private readonly Draft201909MetaCore.CommentValue? comment;
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
        private readonly Draft201909MetaValidation.MaximumValue? maximum;
        private readonly Draft201909MetaValidation.ExclusiveMaximumValue? exclusiveMaximum;
        private readonly Draft201909MetaValidation.MinimumValue? minimum;
        private readonly Draft201909MetaValidation.ExclusiveMinimumValue? exclusiveMinimum;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxLength;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minLength;
        private readonly Draft201909MetaValidation.PatternValue? pattern;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxItems;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minItems;
        private readonly Draft201909MetaValidation.UniqueItemsValue? uniqueItems;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxContains;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minContains;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxProperties;
        private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minProperties;
        private readonly Draft201909MetaValidation.StringArrayEntity? required;
        private readonly Draft201909MetaValidation.DependentRequiredEntity? dependentRequired;
        private readonly Draft201909MetaValidation.ConstEntity? @const;
        private readonly Draft201909MetaValidation.EnumArray? @enum;
        private readonly Draft201909MetaValidation.TypeEntity? type;
        private readonly Draft201909MetaMetaData.TitleValue? title;
        private readonly Draft201909MetaMetaData.DescriptionValue? description;
        private readonly Draft201909MetaMetaData.DefaultEntity? @default;
        private readonly Draft201909MetaMetaData.DeprecatedValue? deprecated;
        private readonly Draft201909MetaMetaData.ReadOnlyValue? readOnly;
        private readonly Draft201909MetaMetaData.WriteOnlyValue? writeOnly;
        private readonly Draft201909MetaMetaData.ExamplesArray? examples;
        private readonly Draft201909MetaFormat.FormatValue? format;
        private readonly Draft201909MetaContent.ContentMediaTypeValue? contentMediaType;
        private readonly Draft201909MetaContent.ContentEncodingValue? contentEncoding;
        private readonly Draft201909MetaContent? contentSchema;
        private readonly Draft201909Schema.DefinitionsEntity? definitions;
        private readonly Draft201909Schema.DependenciesEntity? dependencies;
        /// <inheritdoc />
        public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
        /// <inheritdoc />
        public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
        /// <inheritdoc />
        public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        /// <inheritdoc />
        public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
        public Draft201909MetaCore.IdValue? Id => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.IdValue>(_MenesIdUtf8JsonPropertyName.Span) : this.id;
        public Draft201909MetaCore.SchemaValue? Schema => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.SchemaValue>(_MenesSchemaUtf8JsonPropertyName.Span) : this.schema;
        public Draft201909MetaCore.AnchorValue? Anchor => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.AnchorValue>(_MenesAnchorUtf8JsonPropertyName.Span) : this.anchor;
        public Draft201909MetaCore.RefValue? Ref => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.RefValue>(_MenesRefUtf8JsonPropertyName.Span) : this.@ref;
        public Draft201909MetaCore.RecursiveRefValue? RecursiveRef => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.RecursiveRefValue>(_MenesRecursiveRefUtf8JsonPropertyName.Span) : this.recursiveRef;
        public Draft201909MetaCore.RecursiveAnchorValue? RecursiveAnchor => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.RecursiveAnchorValue>(_MenesRecursiveAnchorUtf8JsonPropertyName.Span) : this.recursiveAnchor;
        public Draft201909MetaCore.VocabularyEntity? Vocabulary => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.VocabularyEntity>(_MenesVocabularyUtf8JsonPropertyName.Span) : this.vocabulary;
        public Draft201909MetaCore.CommentValue? Comment => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.CommentValue>(_MenesCommentUtf8JsonPropertyName.Span) : this.comment;
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
        public Draft201909MetaValidation.MaximumValue? Maximum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.MaximumValue>(_MenesMaximumUtf8JsonPropertyName.Span) : this.maximum;
        public Draft201909MetaValidation.ExclusiveMaximumValue? ExclusiveMaximum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.ExclusiveMaximumValue>(_MenesExclusiveMaximumUtf8JsonPropertyName.Span) : this.exclusiveMaximum;
        public Draft201909MetaValidation.MinimumValue? Minimum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.MinimumValue>(_MenesMinimumUtf8JsonPropertyName.Span) : this.minimum;
        public Draft201909MetaValidation.ExclusiveMinimumValue? ExclusiveMinimum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.ExclusiveMinimumValue>(_MenesExclusiveMinimumUtf8JsonPropertyName.Span) : this.exclusiveMinimum;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MaxLength => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxLengthUtf8JsonPropertyName.Span) : this.maxLength;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MinLength => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinLengthUtf8JsonPropertyName.Span) : this.minLength;
        public Draft201909MetaValidation.PatternValue? Pattern => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.PatternValue>(_MenesPatternUtf8JsonPropertyName.Span) : this.pattern;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MaxItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxItemsUtf8JsonPropertyName.Span) : this.maxItems;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MinItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinItemsUtf8JsonPropertyName.Span) : this.minItems;
        public Draft201909MetaValidation.UniqueItemsValue? UniqueItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.UniqueItemsValue>(_MenesUniqueItemsUtf8JsonPropertyName.Span) : this.uniqueItems;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MaxContains => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxContainsUtf8JsonPropertyName.Span) : this.maxContains;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MinContains => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinContainsUtf8JsonPropertyName.Span) : this.minContains;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MaxProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxPropertiesUtf8JsonPropertyName.Span) : this.maxProperties;
        public Draft201909MetaValidation.NonNegativeIntegerValue? MinProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinPropertiesUtf8JsonPropertyName.Span) : this.minProperties;
        public Draft201909MetaValidation.StringArrayEntity? Required => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.StringArrayEntity>(_MenesRequiredUtf8JsonPropertyName.Span) : this.required;
        public Draft201909MetaValidation.DependentRequiredEntity? DependentRequired => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.DependentRequiredEntity>(_MenesDependentRequiredUtf8JsonPropertyName.Span) : this.dependentRequired;
        public Draft201909MetaValidation.ConstEntity? Const => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.ConstEntity>(_MenesConstUtf8JsonPropertyName.Span) : this.@const;
        public Draft201909MetaValidation.EnumArray? Enum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.EnumArray>(_MenesEnumUtf8JsonPropertyName.Span) : this.@enum;
        public Draft201909MetaValidation.TypeEntity? Type => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.TypeEntity>(_MenesTypeUtf8JsonPropertyName.Span) : this.type;
        public Draft201909MetaMetaData.TitleValue? Title => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaMetaData.TitleValue>(_MenesTitleUtf8JsonPropertyName.Span) : this.title;
        public Draft201909MetaMetaData.DescriptionValue? Description => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaMetaData.DescriptionValue>(_MenesDescriptionUtf8JsonPropertyName.Span) : this.description;
        public Draft201909MetaMetaData.DefaultEntity? Default => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaMetaData.DefaultEntity>(_MenesDefaultUtf8JsonPropertyName.Span) : this.@default;
        public Draft201909MetaMetaData.DeprecatedValue? Deprecated => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaMetaData.DeprecatedValue>(_MenesDeprecatedUtf8JsonPropertyName.Span) : this.deprecated;
        public Draft201909MetaMetaData.ReadOnlyValue? ReadOnly => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaMetaData.ReadOnlyValue>(_MenesReadOnlyUtf8JsonPropertyName.Span) : this.readOnly;
        public Draft201909MetaMetaData.WriteOnlyValue? WriteOnly => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaMetaData.WriteOnlyValue>(_MenesWriteOnlyUtf8JsonPropertyName.Span) : this.writeOnly;
        public Draft201909MetaMetaData.ExamplesArray? Examples => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaMetaData.ExamplesArray>(_MenesExamplesUtf8JsonPropertyName.Span) : this.examples;
        public Draft201909MetaFormat.FormatValue? Format => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaFormat.FormatValue>(_MenesFormatUtf8JsonPropertyName.Span) : this.format;
        public Draft201909MetaContent.ContentMediaTypeValue? ContentMediaType => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaContent.ContentMediaTypeValue>(_MenesContentMediaTypeUtf8JsonPropertyName.Span) : this.contentMediaType;
        public Draft201909MetaContent.ContentEncodingValue? ContentEncoding => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaContent.ContentEncodingValue>(_MenesContentEncodingUtf8JsonPropertyName.Span) : this.contentEncoding;
        public Draft201909MetaContent? ContentSchema => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaContent>(_MenesContentSchemaUtf8JsonPropertyName.Span) : this.contentSchema;
        public Draft201909Schema.DefinitionsEntity? Definitions => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema.DefinitionsEntity>(_MenesDefinitionsUtf8JsonPropertyName.Span) : this.definitions;
        public Draft201909Schema.DependenciesEntity? Dependencies => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema.DependenciesEntity>(_MenesDependenciesUtf8JsonPropertyName.Span) : this.dependencies;
        /// <inheritdoc />
        public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
        {
            Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
            Draft201909Schema flattened = Menes.JsonValue.FlattenToJsonElementBacking(this);
            result = ValidateAllOf(flattened, result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);
            return result;
            Menes.ValidationResult ValidateAllOf(in Draft201909Schema that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                Menes.ValidationResult result = validationResult;
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush0)
                {
                    aklPush0.Push("https://json-schema.org/draft/2019-09/schema#/allOf/0");
                }
                var allOf0 = that.AsDraft201909MetaCore();
                result = allOf0.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
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
                result = allOf1.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
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
                result = allOf2.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
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
                result = allOf3.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
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
                result = allOf4.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
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
                result = allOf5.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);
                if (level == Menes.ValidationLevel.Flag && !result.Valid)
                {
                    return result;
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
            if (this.id is Draft201909MetaCore.IdValue id)
            {
                writer.WritePropertyName(_MenesIdEncodedJsonPropertyName);
                id.WriteTo(writer);
            }
            if (this.schema is Draft201909MetaCore.SchemaValue schema)
            {
                writer.WritePropertyName(_MenesSchemaEncodedJsonPropertyName);
                schema.WriteTo(writer);
            }
            if (this.anchor is Draft201909MetaCore.AnchorValue anchor)
            {
                writer.WritePropertyName(_MenesAnchorEncodedJsonPropertyName);
                anchor.WriteTo(writer);
            }
            if (this.@ref is Draft201909MetaCore.RefValue @ref)
            {
                writer.WritePropertyName(_MenesRefEncodedJsonPropertyName);
                @ref.WriteTo(writer);
            }
            if (this.recursiveRef is Draft201909MetaCore.RecursiveRefValue recursiveRef)
            {
                writer.WritePropertyName(_MenesRecursiveRefEncodedJsonPropertyName);
                recursiveRef.WriteTo(writer);
            }
            if (this.recursiveAnchor is Draft201909MetaCore.RecursiveAnchorValue recursiveAnchor)
            {
                writer.WritePropertyName(_MenesRecursiveAnchorEncodedJsonPropertyName);
                recursiveAnchor.WriteTo(writer);
            }
            if (this.vocabulary is Draft201909MetaCore.VocabularyEntity vocabulary)
            {
                writer.WritePropertyName(_MenesVocabularyEncodedJsonPropertyName);
                vocabulary.WriteTo(writer);
            }
            if (this.comment is Draft201909MetaCore.CommentValue comment)
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
            if (this.maximum is Draft201909MetaValidation.MaximumValue maximum)
            {
                writer.WritePropertyName(_MenesMaximumEncodedJsonPropertyName);
                maximum.WriteTo(writer);
            }
            if (this.exclusiveMaximum is Draft201909MetaValidation.ExclusiveMaximumValue exclusiveMaximum)
            {
                writer.WritePropertyName(_MenesExclusiveMaximumEncodedJsonPropertyName);
                exclusiveMaximum.WriteTo(writer);
            }
            if (this.minimum is Draft201909MetaValidation.MinimumValue minimum)
            {
                writer.WritePropertyName(_MenesMinimumEncodedJsonPropertyName);
                minimum.WriteTo(writer);
            }
            if (this.exclusiveMinimum is Draft201909MetaValidation.ExclusiveMinimumValue exclusiveMinimum)
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
            if (this.pattern is Draft201909MetaValidation.PatternValue pattern)
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
            if (this.uniqueItems is Draft201909MetaValidation.UniqueItemsValue uniqueItems)
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
            if (this.@const is Draft201909MetaValidation.ConstEntity @const)
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
            if (this.title is Draft201909MetaMetaData.TitleValue title)
            {
                writer.WritePropertyName(_MenesTitleEncodedJsonPropertyName);
                title.WriteTo(writer);
            }
            if (this.description is Draft201909MetaMetaData.DescriptionValue description)
            {
                writer.WritePropertyName(_MenesDescriptionEncodedJsonPropertyName);
                description.WriteTo(writer);
            }
            if (this.@default is Draft201909MetaMetaData.DefaultEntity @default)
            {
                writer.WritePropertyName(_MenesDefaultEncodedJsonPropertyName);
                @default.WriteTo(writer);
            }
            if (this.deprecated is Draft201909MetaMetaData.DeprecatedValue deprecated)
            {
                writer.WritePropertyName(_MenesDeprecatedEncodedJsonPropertyName);
                deprecated.WriteTo(writer);
            }
            if (this.readOnly is Draft201909MetaMetaData.ReadOnlyValue readOnly)
            {
                writer.WritePropertyName(_MenesReadOnlyEncodedJsonPropertyName);
                readOnly.WriteTo(writer);
            }
            if (this.writeOnly is Draft201909MetaMetaData.WriteOnlyValue writeOnly)
            {
                writer.WritePropertyName(_MenesWriteOnlyEncodedJsonPropertyName);
                writeOnly.WriteTo(writer);
            }
            if (this.examples is Draft201909MetaMetaData.ExamplesArray examples)
            {
                writer.WritePropertyName(_MenesExamplesEncodedJsonPropertyName);
                examples.WriteTo(writer);
            }
            if (this.format is Draft201909MetaFormat.FormatValue format)
            {
                writer.WritePropertyName(_MenesFormatEncodedJsonPropertyName);
                format.WriteTo(writer);
            }
            if (this.contentMediaType is Draft201909MetaContent.ContentMediaTypeValue contentMediaType)
            {
                writer.WritePropertyName(_MenesContentMediaTypeEncodedJsonPropertyName);
                contentMediaType.WriteTo(writer);
            }
            if (this.contentEncoding is Draft201909MetaContent.ContentEncodingValue contentEncoding)
            {
                writer.WritePropertyName(_MenesContentEncodingEncodedJsonPropertyName);
                contentEncoding.WriteTo(writer);
            }
            if (this.contentSchema is Draft201909MetaContent contentSchema)
            {
                writer.WritePropertyName(_MenesContentSchemaEncodedJsonPropertyName);
                contentSchema.WriteTo(writer);
            }
            if (this.definitions is Draft201909Schema.DefinitionsEntity definitions)
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
            this._menesBooleanTypeBacking?.WriteTo(writer);
        }
        /// <inheritdoc />
        public T As<T>()
            where T : struct, Menes.IJsonValue
        {
            return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
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
        private readonly Draft201909MetaCore AsDraft201909MetaCore()
        {
            return this.As<Draft201909MetaCore>();
        }
        private readonly Draft201909MetaApplicator AsDraft201909MetaApplicator()
        {
            return this.As<Draft201909MetaApplicator>();
        }
        private readonly Draft201909MetaValidation AsDraft201909MetaValidation()
        {
            return this.As<Draft201909MetaValidation>();
        }
        private readonly Draft201909MetaMetaData AsDraft201909MetaMetaData()
        {
            return this.As<Draft201909MetaMetaData>();
        }
        private readonly Draft201909MetaFormat AsDraft201909MetaFormat()
        {
            return this.As<Draft201909MetaFormat>();
        }
        private readonly Draft201909MetaContent AsDraft201909MetaContent()
        {
            return this.As<Draft201909MetaContent>();
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
            if (propertyName.SequenceEqual(_MenesIdJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesSchemaJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesAnchorJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesRefJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesRecursiveRefJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesRecursiveAnchorJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesVocabularyJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesCommentJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDefsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesAdditionalItemsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesUnevaluatedItemsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesItemsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesContainsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesAdditionalPropertiesJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesUnevaluatedPropertiesJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesPropertiesJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesPatternPropertiesJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDependentSchemasJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesPropertyNamesJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesIfJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesThenJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesElseJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesAllOfJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesAnyOfJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesOneOfJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesNotJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMultipleOfJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMaximumJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesExclusiveMaximumJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMinimumJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesExclusiveMinimumJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMaxLengthJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMinLengthJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesPatternJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMaxItemsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMinItemsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesUniqueItemsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMaxContainsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMinContainsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMaxPropertiesJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMinPropertiesJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesRequiredJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDependentRequiredJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesConstJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesEnumJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesTypeJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesTitleJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDescriptionJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDefaultJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDeprecatedJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesReadOnlyJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesWriteOnlyJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesExamplesJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesFormatJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesContentMediaTypeJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesContentEncodingJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesContentSchemaJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDefinitionsJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDependenciesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesIdJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesSchemaJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesAnchorJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesRefJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesRecursiveRefJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesRecursiveAnchorJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesVocabularyJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesCommentJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesDefsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesAdditionalItemsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesUnevaluatedItemsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesItemsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesContainsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesAdditionalPropertiesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesUnevaluatedPropertiesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesPropertiesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesPatternPropertiesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesDependentSchemasJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesPropertyNamesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesIfJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesThenJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesElseJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesAllOfJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesAnyOfJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesOneOfJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesNotJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMultipleOfJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMaximumJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesExclusiveMaximumJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMinimumJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesExclusiveMinimumJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMaxLengthJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMinLengthJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesPatternJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMaxItemsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMinItemsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesUniqueItemsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMaxContainsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMinContainsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMaxPropertiesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMinPropertiesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesRequiredJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesDependentRequiredJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesConstJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesEnumJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesTypeJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesTitleJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesDescriptionJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesDefaultJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesDeprecatedJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesReadOnlyJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesWriteOnlyJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesExamplesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesFormatJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesContentMediaTypeJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesContentEncodingJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesContentSchemaJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesDefinitionsJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesDependenciesJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesIdUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesSchemaUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesAnchorUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesRefUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesRecursiveRefUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesRecursiveAnchorUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesVocabularyUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesCommentUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDefsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesAdditionalItemsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesUnevaluatedItemsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesItemsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesContainsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesAdditionalPropertiesUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesUnevaluatedPropertiesUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesPropertiesUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesPatternPropertiesUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDependentSchemasUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesPropertyNamesUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesIfUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesThenUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesElseUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesAllOfUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesAnyOfUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesOneOfUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesNotUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMultipleOfUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMaximumUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesExclusiveMaximumUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMinimumUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesExclusiveMinimumUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMaxLengthUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMinLengthUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesPatternUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMaxItemsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMinItemsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesUniqueItemsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMaxContainsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMinContainsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMaxPropertiesUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMinPropertiesUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesRequiredUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDependentRequiredUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesConstUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesEnumUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesTypeUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesTitleUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDescriptionUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDefaultUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDeprecatedUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesReadOnlyUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesWriteOnlyUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesExamplesUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesFormatUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesContentMediaTypeUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesContentEncodingUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesContentSchemaUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDefinitionsUtf8JsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesDependenciesUtf8JsonPropertyName.Span))
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
            if (this.definitions is not null)
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
        public readonly struct DefinitionsEntity : Menes.IJsonValue
        {
            public static readonly DefinitionsEntity Null = default(DefinitionsEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking;
            /// <inheritdoc />
            public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
            /// <inheritdoc />
            public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            /// <inheritdoc />
            public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
            /// <inheritdoc />
            public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
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
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    property.WriteTo(writer);
                }
            }
            /// <inheritdoc />
            public T As<T>()
                where T : struct, Menes.IJsonValue
            {
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
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
        }
        public readonly struct DependenciesEntity : Menes.IJsonValue
        {
            public static readonly DependenciesEntity Null = default(DependenciesEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking;
            /// <inheritdoc />
            public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
            /// <inheritdoc />
            public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            /// <inheritdoc />
            public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
            /// <inheritdoc />
            public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
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
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    property.WriteTo(writer);
                }
            }
            /// <inheritdoc />
            public T As<T>()
                where T : struct, Menes.IJsonValue
            {
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
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
                        property = additionalProperty.Value<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>()?.As<T>() ?? default;
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
                        property = additionalProperty.Value<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>()?.As<T>() ?? default;
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
                        property = additionalProperty.Value<Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity>()?.As<T>() ?? default;
                        return true;
                    }
                }
                property = default;
                return false;
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
            public readonly struct AdditionalPropertiesEntity : Menes.IJsonValue
            {
                public static readonly AdditionalPropertiesEntity Null = default(AdditionalPropertiesEntity);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                /// <inheritdoc />
                public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
                /// <inheritdoc />
                public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
                /// <inheritdoc />
                public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
                /// <inheritdoc />
                public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
                /// <inheritdoc />
                public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
                {
                    Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
                    AdditionalPropertiesEntity flattened = Menes.JsonValue.FlattenToJsonElementBacking(this);
                    result = ValidateAnyOf(flattened, result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);
                    return result;
                    Menes.ValidationResult ValidateAnyOf(in Draft201909Schema.DependenciesEntity.AdditionalPropertiesEntity that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
                    {
                        if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush0)
                        {
                            aklPush0.Push("https://json-schema.org/draft/2019-09/schema#/properties/dependencies/additionalProperties/anyOf/0");
                        }
                        var anyOf0 = that.AsDraft201909Schema();
                        var anyOfResult0 = anyOf0.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);
                        if (level == Menes.ValidationLevel.Flag && anyOfResult0.Valid)
                        {
                            return result;
                        }
                        if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop0)
                        {
                            aklPop0.Pop();
                        }
                        if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush1)
                        {
                            aklPush1.Push("https://json-schema.org/draft/2019-09/schema#/properties/dependencies/additionalProperties/anyOf/1");
                        }
                        var anyOf1 = that.AsStringArrayEntity();
                        var anyOfResult1 = anyOf1.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);
                        if (level == Menes.ValidationLevel.Flag && anyOfResult1.Valid)
                        {
                            return result;
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
                    return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
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
                private readonly Draft201909Schema AsDraft201909Schema()
                {
                    return this.As<Draft201909Schema>();
                }
                private readonly Draft201909MetaValidation.StringArrayEntity AsStringArrayEntity()
                {
                    return this.As<Draft201909MetaValidation.StringArrayEntity>();
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
                    property = default;
                    return false;
                }
                private bool AllBackingFieldsAreNull()
                {
                    return true;
                }
            }
        }
    }
}
