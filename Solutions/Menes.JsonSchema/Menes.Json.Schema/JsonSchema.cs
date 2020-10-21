﻿// <copyright file="JsonSchema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501, SA1119, IDE0047, IDE0034

namespace Menes.Json.Schema
{
    public readonly struct JsonSchema : Menes.IJsonObject, System.IEquatable<JsonSchema>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly JsonSchema Null = new JsonSchema(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema> FromJsonElement = e => new JsonSchema(e);
        private const string IdPropertyNamePath = ".$id";
        private const string SchemaPropertyNamePath = ".$schema";
        private const string TitlePropertyNamePath = ".title";
        private const string DescriptionPropertyNamePath = ".description";
        private const string CommentPropertyNamePath = ".$comment";
        private const string TypePropertyNamePath = ".type";
        private const string FormatPropertyNamePath = ".format";
        private const string EnumPropertyNamePath = ".enum";
        private const string ConstPropertyNamePath = ".const";
        private const string AllOfPropertyNamePath = ".allOf";
        private const string AnyOfPropertyNamePath = ".anyOf";
        private const string OneOfPropertyNamePath = ".oneOf";
        private const string NotPropertyNamePath = ".not";
        private const string IfPropertyNamePath = ".if";
        private const string ThenPropertyNamePath = ".then";
        private const string ElsePropertyNamePath = ".else";
        private const string DependentSchemasPropertyNamePath = ".dependentSchemas";
        private const string MultipleOfPropertyNamePath = ".multipleOf";
        private const string MaximumPropertyNamePath = ".maximum";
        private const string ExclusiveMaximumPropertyNamePath = ".exclusiveMaximum";
        private const string MinimumPropertyNamePath = ".minimum";
        private const string ExclusiveMinimumPropertyNamePath = ".exclusiveMinimum";
        private const string MaxLengthPropertyNamePath = ".maxLength";
        private const string MinLengthPropertyNamePath = ".minLength";
        private const string PatternPropertyNamePath = ".pattern";
        private const string MaxItemsPropertyNamePath = ".maxItems";
        private const string MinItemsPropertyNamePath = ".minItems";
        private const string UniqueItemsPropertyNamePath = ".uniqueItems";
        private const string MaxContainsPropertyNamePath = ".maxContains";
        private const string MinContainsPropertyNamePath = ".minContains";
        private const string ItemsPropertyNamePath = ".items";
        private const string ContainsPropertyNamePath = ".contains";
        private const string MaxPropertiesPropertyNamePath = ".maxProperties";
        private const string MinPropertiesPropertyNamePath = ".minProperties";
        private const string RequiredPropertyNamePath = ".required";
        private const string PropertiesPropertyNamePath = ".properties";
        private const string AdditionalPropertiesPropertyNamePath = ".additionalProperties";
        private const string PatternPropertiesPropertyNamePath = ".patternProperties";
        private const string PropertyNamesPropertyNamePath = ".propertyNames";
        private static readonly System.ReadOnlyMemory<byte> IdPropertyNameBytes = new byte[] { 36, 105, 100 };
        private static readonly System.ReadOnlyMemory<byte> SchemaPropertyNameBytes = new byte[] { 36, 115, 99, 104, 101, 109, 97 };
        private static readonly System.ReadOnlyMemory<byte> TitlePropertyNameBytes = new byte[] { 116, 105, 116, 108, 101 };
        private static readonly System.ReadOnlyMemory<byte> DescriptionPropertyNameBytes = new byte[] { 100, 101, 115, 99, 114, 105, 112, 116, 105, 111, 110 };
        private static readonly System.ReadOnlyMemory<byte> CommentPropertyNameBytes = new byte[] { 36, 99, 111, 109, 109, 101, 110, 116 };
        private static readonly System.ReadOnlyMemory<byte> TypePropertyNameBytes = new byte[] { 116, 121, 112, 101 };
        private static readonly System.ReadOnlyMemory<byte> FormatPropertyNameBytes = new byte[] { 102, 111, 114, 109, 97, 116 };
        private static readonly System.ReadOnlyMemory<byte> EnumPropertyNameBytes = new byte[] { 101, 110, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> ConstPropertyNameBytes = new byte[] { 99, 111, 110, 115, 116 };
        private static readonly System.ReadOnlyMemory<byte> AllOfPropertyNameBytes = new byte[] { 97, 108, 108, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> AnyOfPropertyNameBytes = new byte[] { 97, 110, 121, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> OneOfPropertyNameBytes = new byte[] { 111, 110, 101, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> NotPropertyNameBytes = new byte[] { 110, 111, 116 };
        private static readonly System.ReadOnlyMemory<byte> IfPropertyNameBytes = new byte[] { 105, 102 };
        private static readonly System.ReadOnlyMemory<byte> ThenPropertyNameBytes = new byte[] { 116, 104, 101, 110 };
        private static readonly System.ReadOnlyMemory<byte> ElsePropertyNameBytes = new byte[] { 101, 108, 115, 101 };
        private static readonly System.ReadOnlyMemory<byte> DependentSchemasPropertyNameBytes = new byte[] { 100, 101, 112, 101, 110, 100, 101, 110, 116, 83, 99, 104, 101, 109, 97, 115 };
        private static readonly System.ReadOnlyMemory<byte> MultipleOfPropertyNameBytes = new byte[] { 109, 117, 108, 116, 105, 112, 108, 101, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> MaximumPropertyNameBytes = new byte[] { 109, 97, 120, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> ExclusiveMaximumPropertyNameBytes = new byte[] { 101, 120, 99, 108, 117, 115, 105, 118, 101, 77, 97, 120, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> MinimumPropertyNameBytes = new byte[] { 109, 105, 110, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> ExclusiveMinimumPropertyNameBytes = new byte[] { 101, 120, 99, 108, 117, 115, 105, 118, 101, 77, 105, 110, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> MaxLengthPropertyNameBytes = new byte[] { 109, 97, 120, 76, 101, 110, 103, 116, 104 };
        private static readonly System.ReadOnlyMemory<byte> MinLengthPropertyNameBytes = new byte[] { 109, 105, 110, 76, 101, 110, 103, 116, 104 };
        private static readonly System.ReadOnlyMemory<byte> PatternPropertyNameBytes = new byte[] { 112, 97, 116, 116, 101, 114, 110 };
        private static readonly System.ReadOnlyMemory<byte> MaxItemsPropertyNameBytes = new byte[] { 109, 97, 120, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> MinItemsPropertyNameBytes = new byte[] { 109, 105, 110, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> UniqueItemsPropertyNameBytes = new byte[] { 117, 110, 105, 113, 117, 101, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> MaxContainsPropertyNameBytes = new byte[] { 109, 97, 120, 67, 111, 110, 116, 97, 105, 110, 115 };
        private static readonly System.ReadOnlyMemory<byte> MinContainsPropertyNameBytes = new byte[] { 109, 105, 110, 67, 111, 110, 116, 97, 105, 110, 115 };
        private static readonly System.ReadOnlyMemory<byte> ItemsPropertyNameBytes = new byte[] { 105, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> ContainsPropertyNameBytes = new byte[] { 99, 111, 110, 116, 97, 105, 110, 115 };
        private static readonly System.ReadOnlyMemory<byte> MaxPropertiesPropertyNameBytes = new byte[] { 109, 97, 120, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> MinPropertiesPropertyNameBytes = new byte[] { 109, 105, 110, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> RequiredPropertyNameBytes = new byte[] { 114, 101, 113, 117, 105, 114, 101, 100 };
        private static readonly System.ReadOnlyMemory<byte> PropertiesPropertyNameBytes = new byte[] { 112, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> AdditionalPropertiesPropertyNameBytes = new byte[] { 97, 100, 100, 105, 116, 105, 111, 110, 97, 108, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> PatternPropertiesPropertyNameBytes = new byte[] { 112, 97, 116, 116, 101, 114, 110, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> PropertyNamesPropertyNameBytes = new byte[] { 112, 114, 111, 112, 101, 114, 116, 121, 78, 97, 109, 101, 115 };
        private static readonly System.Text.Json.JsonEncodedText EncodedIdPropertyName = System.Text.Json.JsonEncodedText.Encode(IdPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedSchemaPropertyName = System.Text.Json.JsonEncodedText.Encode(SchemaPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedTitlePropertyName = System.Text.Json.JsonEncodedText.Encode(TitlePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedDescriptionPropertyName = System.Text.Json.JsonEncodedText.Encode(DescriptionPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedCommentPropertyName = System.Text.Json.JsonEncodedText.Encode(CommentPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedTypePropertyName = System.Text.Json.JsonEncodedText.Encode(TypePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedFormatPropertyName = System.Text.Json.JsonEncodedText.Encode(FormatPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedEnumPropertyName = System.Text.Json.JsonEncodedText.Encode(EnumPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedConstPropertyName = System.Text.Json.JsonEncodedText.Encode(ConstPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedAllOfPropertyName = System.Text.Json.JsonEncodedText.Encode(AllOfPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedAnyOfPropertyName = System.Text.Json.JsonEncodedText.Encode(AnyOfPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedOneOfPropertyName = System.Text.Json.JsonEncodedText.Encode(OneOfPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedNotPropertyName = System.Text.Json.JsonEncodedText.Encode(NotPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedIfPropertyName = System.Text.Json.JsonEncodedText.Encode(IfPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedThenPropertyName = System.Text.Json.JsonEncodedText.Encode(ThenPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedElsePropertyName = System.Text.Json.JsonEncodedText.Encode(ElsePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedDependentSchemasPropertyName = System.Text.Json.JsonEncodedText.Encode(DependentSchemasPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMultipleOfPropertyName = System.Text.Json.JsonEncodedText.Encode(MultipleOfPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaximumPropertyName = System.Text.Json.JsonEncodedText.Encode(MaximumPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedExclusiveMaximumPropertyName = System.Text.Json.JsonEncodedText.Encode(ExclusiveMaximumPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMinimumPropertyName = System.Text.Json.JsonEncodedText.Encode(MinimumPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedExclusiveMinimumPropertyName = System.Text.Json.JsonEncodedText.Encode(ExclusiveMinimumPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaxLengthPropertyName = System.Text.Json.JsonEncodedText.Encode(MaxLengthPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMinLengthPropertyName = System.Text.Json.JsonEncodedText.Encode(MinLengthPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedPatternPropertyName = System.Text.Json.JsonEncodedText.Encode(PatternPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaxItemsPropertyName = System.Text.Json.JsonEncodedText.Encode(MaxItemsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMinItemsPropertyName = System.Text.Json.JsonEncodedText.Encode(MinItemsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedUniqueItemsPropertyName = System.Text.Json.JsonEncodedText.Encode(UniqueItemsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaxContainsPropertyName = System.Text.Json.JsonEncodedText.Encode(MaxContainsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMinContainsPropertyName = System.Text.Json.JsonEncodedText.Encode(MinContainsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedItemsPropertyName = System.Text.Json.JsonEncodedText.Encode(ItemsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedContainsPropertyName = System.Text.Json.JsonEncodedText.Encode(ContainsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaxPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(MaxPropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMinPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(MinPropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedRequiredPropertyName = System.Text.Json.JsonEncodedText.Encode(RequiredPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(PropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedAdditionalPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(AdditionalPropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedPatternPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(PatternPropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedPropertyNamesPropertyName = System.Text.Json.JsonEncodedText.Encode(PropertyNamesPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(IdPropertyNameBytes, SchemaPropertyNameBytes, TitlePropertyNameBytes, DescriptionPropertyNameBytes, CommentPropertyNameBytes, TypePropertyNameBytes, FormatPropertyNameBytes, EnumPropertyNameBytes, ConstPropertyNameBytes, AllOfPropertyNameBytes, AnyOfPropertyNameBytes, OneOfPropertyNameBytes, NotPropertyNameBytes, IfPropertyNameBytes, ThenPropertyNameBytes, ElsePropertyNameBytes, DependentSchemasPropertyNameBytes, MultipleOfPropertyNameBytes, MaximumPropertyNameBytes, ExclusiveMaximumPropertyNameBytes, MinimumPropertyNameBytes, ExclusiveMinimumPropertyNameBytes, MaxLengthPropertyNameBytes, MinLengthPropertyNameBytes, PatternPropertyNameBytes, MaxItemsPropertyNameBytes, MinItemsPropertyNameBytes, UniqueItemsPropertyNameBytes, MaxContainsPropertyNameBytes, MinContainsPropertyNameBytes, ItemsPropertyNameBytes, ContainsPropertyNameBytes, MaxPropertiesPropertyNameBytes, MinPropertiesPropertyNameBytes, RequiredPropertyNameBytes, PropertiesPropertyNameBytes, AdditionalPropertiesPropertyNameBytes, PatternPropertiesPropertyNameBytes, PropertyNamesPropertyNameBytes);
        private readonly Menes.JsonString? id;
        private readonly Menes.JsonString? schema;
        private readonly Menes.JsonString? title;
        private readonly Menes.JsonString? description;
        private readonly Menes.JsonString? comment;
        private readonly JsonSchema.TypeEnum? type;
        private readonly Menes.JsonString? format;
        private readonly Menes.JsonArray<Menes.JsonAny>? @enum;
        private readonly Menes.JsonAny? @const;
        private readonly Menes.JsonReference? allOf;
        private readonly Menes.JsonReference? anyOf;
        private readonly Menes.JsonReference? oneOf;
        private readonly Menes.JsonReference? not;
        private readonly Menes.JsonReference? @if;
        private readonly Menes.JsonReference? then;
        private readonly Menes.JsonReference? @else;
        private readonly Menes.JsonReference? dependentSchemas;
        private readonly JsonSchema.PositiveNumber? multipleOf;
        private readonly Menes.JsonNumber? maximum;
        private readonly Menes.JsonNumber? exclusiveMaximum;
        private readonly Menes.JsonNumber? minimum;
        private readonly Menes.JsonNumber? exclusiveMinimum;
        private readonly JsonSchema.NonNegativeInteger? maxLength;
        private readonly JsonSchema.NonNegativeInteger? minLength;
        private readonly Menes.JsonString? pattern;
        private readonly JsonSchema.NonNegativeInteger? maxItems;
        private readonly JsonSchema.NonNegativeInteger? minItems;
        private readonly Menes.JsonBoolean? uniqueItems;
        private readonly JsonSchema.NonNegativeInteger? maxContains;
        private readonly JsonSchema.NonNegativeInteger? minContains;
        private readonly Menes.JsonReference? items;
        private readonly Menes.JsonReference? contains;
        private readonly JsonSchema.NonNegativeInteger? maxProperties;
        private readonly JsonSchema.NonNegativeInteger? minProperties;
        private readonly Menes.JsonReference? required;
        private readonly Menes.JsonReference? properties;
        private readonly Menes.JsonReference? additionalProperties;
        private readonly Menes.JsonReference? patternProperties;
        private readonly Menes.JsonReference? propertyNames;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public JsonSchema(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.id = null;
            this.schema = null;
            this.title = null;
            this.description = null;
            this.comment = null;
            this.type = null;
            this.format = null;
            this.@enum = null;
            this.@const = null;
            this.allOf = null;
            this.anyOf = null;
            this.oneOf = null;
            this.not = null;
            this.@if = null;
            this.then = null;
            this.@else = null;
            this.dependentSchemas = null;
            this.multipleOf = null;
            this.maximum = null;
            this.exclusiveMaximum = null;
            this.minimum = null;
            this.exclusiveMinimum = null;
            this.maxLength = null;
            this.minLength = null;
            this.pattern = null;
            this.maxItems = null;
            this.minItems = null;
            this.uniqueItems = null;
            this.maxContains = null;
            this.minContains = null;
            this.items = null;
            this.contains = null;
            this.maxProperties = null;
            this.minProperties = null;
            this.required = null;
            this.properties = null;
            this.additionalProperties = null;
            this.patternProperties = null;
            this.propertyNames = null;
            this.additionalPropertiesBacking = null;
        }
        public JsonSchema(Menes.JsonString? id, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.ValidatedArrayOfSchemaOrReference? allOf, JsonSchema.ValidatedArrayOfSchemaOrReference? anyOf, JsonSchema.ValidatedArrayOfSchemaOrReference? oneOf, JsonSchema.SchemaOrReference? not, JsonSchema.SchemaOrReference? @if, JsonSchema.SchemaOrReference? then, JsonSchema.SchemaOrReference? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaOrReference? items, JsonSchema.SchemaOrReference? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.ValidatedArrayOfJsonString? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema.SchemaOrReference? propertyNames, Menes.JsonProperties<Menes.JsonAny> additionalPropertiesBacking)
        {
            this.id = id;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema.SchemaOrReference item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema.SchemaOrReference item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema.SchemaOrReference item7)
            {
                this.@else = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.@else = null;
            }
            if (dependentSchemas is JsonSchema.SchemaProperties item8)
            {
                this.dependentSchemas = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.dependentSchemas = null;
            }
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
            if (items is JsonSchema.SchemaOrReference item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (contains is JsonSchema.SchemaOrReference item10)
            {
                this.contains = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            if (required is JsonSchema.ValidatedArrayOfJsonString item11)
            {
                this.required = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.required = null;
            }
            if (properties is JsonSchema.SchemaProperties item12)
            {
                this.properties = Menes.JsonReference.FromValue(item12);
            }
            else
            {
                this.properties = null;
            }
            if (additionalProperties is JsonSchema.SchemaAdditionalProperties item13)
            {
                this.additionalProperties = Menes.JsonReference.FromValue(item13);
            }
            else
            {
                this.additionalProperties = null;
            }
            if (patternProperties is JsonSchema.SchemaProperties item14)
            {
                this.patternProperties = Menes.JsonReference.FromValue(item14);
            }
            else
            {
                this.patternProperties = null;
            }
            if (propertyNames is JsonSchema.SchemaOrReference item15)
            {
                this.propertyNames = Menes.JsonReference.FromValue(item15);
            }
            else
            {
                this.propertyNames = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public JsonSchema(Menes.JsonString? id, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.ValidatedArrayOfSchemaOrReference? allOf, JsonSchema.ValidatedArrayOfSchemaOrReference? anyOf, JsonSchema.ValidatedArrayOfSchemaOrReference? oneOf, JsonSchema.SchemaOrReference? not, JsonSchema.SchemaOrReference? @if, JsonSchema.SchemaOrReference? then, JsonSchema.SchemaOrReference? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaOrReference? items, JsonSchema.SchemaOrReference? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.ValidatedArrayOfJsonString? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema.SchemaOrReference? propertyNames, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.id = id;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema.SchemaOrReference item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema.SchemaOrReference item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema.SchemaOrReference item7)
            {
                this.@else = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.@else = null;
            }
            if (dependentSchemas is JsonSchema.SchemaProperties item8)
            {
                this.dependentSchemas = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.dependentSchemas = null;
            }
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
            if (items is JsonSchema.SchemaOrReference item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (contains is JsonSchema.SchemaOrReference item10)
            {
                this.contains = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            if (required is JsonSchema.ValidatedArrayOfJsonString item11)
            {
                this.required = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.required = null;
            }
            if (properties is JsonSchema.SchemaProperties item12)
            {
                this.properties = Menes.JsonReference.FromValue(item12);
            }
            else
            {
                this.properties = null;
            }
            if (additionalProperties is JsonSchema.SchemaAdditionalProperties item13)
            {
                this.additionalProperties = Menes.JsonReference.FromValue(item13);
            }
            else
            {
                this.additionalProperties = null;
            }
            if (patternProperties is JsonSchema.SchemaProperties item14)
            {
                this.patternProperties = Menes.JsonReference.FromValue(item14);
            }
            else
            {
                this.patternProperties = null;
            }
            if (propertyNames is JsonSchema.SchemaOrReference item15)
            {
                this.propertyNames = Menes.JsonReference.FromValue(item15);
            }
            else
            {
                this.propertyNames = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public JsonSchema(Menes.JsonString? id, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.ValidatedArrayOfSchemaOrReference? allOf, JsonSchema.ValidatedArrayOfSchemaOrReference? anyOf, JsonSchema.ValidatedArrayOfSchemaOrReference? oneOf, JsonSchema.SchemaOrReference? not, JsonSchema.SchemaOrReference? @if, JsonSchema.SchemaOrReference? then, JsonSchema.SchemaOrReference? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaOrReference? items, JsonSchema.SchemaOrReference? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.ValidatedArrayOfJsonString? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema.SchemaOrReference? propertyNames)
        {
            this.id = id;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema.SchemaOrReference item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema.SchemaOrReference item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema.SchemaOrReference item7)
            {
                this.@else = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.@else = null;
            }
            if (dependentSchemas is JsonSchema.SchemaProperties item8)
            {
                this.dependentSchemas = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.dependentSchemas = null;
            }
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
            if (items is JsonSchema.SchemaOrReference item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (contains is JsonSchema.SchemaOrReference item10)
            {
                this.contains = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            if (required is JsonSchema.ValidatedArrayOfJsonString item11)
            {
                this.required = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.required = null;
            }
            if (properties is JsonSchema.SchemaProperties item12)
            {
                this.properties = Menes.JsonReference.FromValue(item12);
            }
            else
            {
                this.properties = null;
            }
            if (additionalProperties is JsonSchema.SchemaAdditionalProperties item13)
            {
                this.additionalProperties = Menes.JsonReference.FromValue(item13);
            }
            else
            {
                this.additionalProperties = null;
            }
            if (patternProperties is JsonSchema.SchemaProperties item14)
            {
                this.patternProperties = Menes.JsonReference.FromValue(item14);
            }
            else
            {
                this.patternProperties = null;
            }
            if (propertyNames is JsonSchema.SchemaOrReference item15)
            {
                this.propertyNames = Menes.JsonReference.FromValue(item15);
            }
            else
            {
                this.propertyNames = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public JsonSchema(Menes.JsonString? id, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.ValidatedArrayOfSchemaOrReference? allOf, JsonSchema.ValidatedArrayOfSchemaOrReference? anyOf, JsonSchema.ValidatedArrayOfSchemaOrReference? oneOf, JsonSchema.SchemaOrReference? not, JsonSchema.SchemaOrReference? @if, JsonSchema.SchemaOrReference? then, JsonSchema.SchemaOrReference? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaOrReference? items, JsonSchema.SchemaOrReference? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.ValidatedArrayOfJsonString? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema.SchemaOrReference? propertyNames, (string, Menes.JsonAny) additionalProperty1)
        {
            this.id = id;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema.SchemaOrReference item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema.SchemaOrReference item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema.SchemaOrReference item7)
            {
                this.@else = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.@else = null;
            }
            if (dependentSchemas is JsonSchema.SchemaProperties item8)
            {
                this.dependentSchemas = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.dependentSchemas = null;
            }
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
            if (items is JsonSchema.SchemaOrReference item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (contains is JsonSchema.SchemaOrReference item10)
            {
                this.contains = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            if (required is JsonSchema.ValidatedArrayOfJsonString item11)
            {
                this.required = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.required = null;
            }
            if (properties is JsonSchema.SchemaProperties item12)
            {
                this.properties = Menes.JsonReference.FromValue(item12);
            }
            else
            {
                this.properties = null;
            }
            if (additionalProperties is JsonSchema.SchemaAdditionalProperties item13)
            {
                this.additionalProperties = Menes.JsonReference.FromValue(item13);
            }
            else
            {
                this.additionalProperties = null;
            }
            if (patternProperties is JsonSchema.SchemaProperties item14)
            {
                this.patternProperties = Menes.JsonReference.FromValue(item14);
            }
            else
            {
                this.patternProperties = null;
            }
            if (propertyNames is JsonSchema.SchemaOrReference item15)
            {
                this.propertyNames = Menes.JsonReference.FromValue(item15);
            }
            else
            {
                this.propertyNames = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public JsonSchema(Menes.JsonString? id, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.ValidatedArrayOfSchemaOrReference? allOf, JsonSchema.ValidatedArrayOfSchemaOrReference? anyOf, JsonSchema.ValidatedArrayOfSchemaOrReference? oneOf, JsonSchema.SchemaOrReference? not, JsonSchema.SchemaOrReference? @if, JsonSchema.SchemaOrReference? then, JsonSchema.SchemaOrReference? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaOrReference? items, JsonSchema.SchemaOrReference? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.ValidatedArrayOfJsonString? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema.SchemaOrReference? propertyNames, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.id = id;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema.SchemaOrReference item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema.SchemaOrReference item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema.SchemaOrReference item7)
            {
                this.@else = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.@else = null;
            }
            if (dependentSchemas is JsonSchema.SchemaProperties item8)
            {
                this.dependentSchemas = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.dependentSchemas = null;
            }
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
            if (items is JsonSchema.SchemaOrReference item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (contains is JsonSchema.SchemaOrReference item10)
            {
                this.contains = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            if (required is JsonSchema.ValidatedArrayOfJsonString item11)
            {
                this.required = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.required = null;
            }
            if (properties is JsonSchema.SchemaProperties item12)
            {
                this.properties = Menes.JsonReference.FromValue(item12);
            }
            else
            {
                this.properties = null;
            }
            if (additionalProperties is JsonSchema.SchemaAdditionalProperties item13)
            {
                this.additionalProperties = Menes.JsonReference.FromValue(item13);
            }
            else
            {
                this.additionalProperties = null;
            }
            if (patternProperties is JsonSchema.SchemaProperties item14)
            {
                this.patternProperties = Menes.JsonReference.FromValue(item14);
            }
            else
            {
                this.patternProperties = null;
            }
            if (propertyNames is JsonSchema.SchemaOrReference item15)
            {
                this.propertyNames = Menes.JsonReference.FromValue(item15);
            }
            else
            {
                this.propertyNames = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public JsonSchema(Menes.JsonString? id, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.ValidatedArrayOfSchemaOrReference? allOf, JsonSchema.ValidatedArrayOfSchemaOrReference? anyOf, JsonSchema.ValidatedArrayOfSchemaOrReference? oneOf, JsonSchema.SchemaOrReference? not, JsonSchema.SchemaOrReference? @if, JsonSchema.SchemaOrReference? then, JsonSchema.SchemaOrReference? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaOrReference? items, JsonSchema.SchemaOrReference? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.ValidatedArrayOfJsonString? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema.SchemaOrReference? propertyNames, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.id = id;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema.SchemaOrReference item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema.SchemaOrReference item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema.SchemaOrReference item7)
            {
                this.@else = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.@else = null;
            }
            if (dependentSchemas is JsonSchema.SchemaProperties item8)
            {
                this.dependentSchemas = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.dependentSchemas = null;
            }
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
            if (items is JsonSchema.SchemaOrReference item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (contains is JsonSchema.SchemaOrReference item10)
            {
                this.contains = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            if (required is JsonSchema.ValidatedArrayOfJsonString item11)
            {
                this.required = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.required = null;
            }
            if (properties is JsonSchema.SchemaProperties item12)
            {
                this.properties = Menes.JsonReference.FromValue(item12);
            }
            else
            {
                this.properties = null;
            }
            if (additionalProperties is JsonSchema.SchemaAdditionalProperties item13)
            {
                this.additionalProperties = Menes.JsonReference.FromValue(item13);
            }
            else
            {
                this.additionalProperties = null;
            }
            if (patternProperties is JsonSchema.SchemaProperties item14)
            {
                this.patternProperties = Menes.JsonReference.FromValue(item14);
            }
            else
            {
                this.patternProperties = null;
            }
            if (propertyNames is JsonSchema.SchemaOrReference item15)
            {
                this.propertyNames = Menes.JsonReference.FromValue(item15);
            }
            else
            {
                this.propertyNames = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public JsonSchema(Menes.JsonString? id, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.ValidatedArrayOfSchemaOrReference? allOf, JsonSchema.ValidatedArrayOfSchemaOrReference? anyOf, JsonSchema.ValidatedArrayOfSchemaOrReference? oneOf, JsonSchema.SchemaOrReference? not, JsonSchema.SchemaOrReference? @if, JsonSchema.SchemaOrReference? then, JsonSchema.SchemaOrReference? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaOrReference? items, JsonSchema.SchemaOrReference? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.ValidatedArrayOfJsonString? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema.SchemaOrReference? propertyNames, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.id = id;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema.SchemaOrReference item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema.SchemaOrReference item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema.SchemaOrReference item7)
            {
                this.@else = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.@else = null;
            }
            if (dependentSchemas is JsonSchema.SchemaProperties item8)
            {
                this.dependentSchemas = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.dependentSchemas = null;
            }
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
            if (items is JsonSchema.SchemaOrReference item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (contains is JsonSchema.SchemaOrReference item10)
            {
                this.contains = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            if (required is JsonSchema.ValidatedArrayOfJsonString item11)
            {
                this.required = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.required = null;
            }
            if (properties is JsonSchema.SchemaProperties item12)
            {
                this.properties = Menes.JsonReference.FromValue(item12);
            }
            else
            {
                this.properties = null;
            }
            if (additionalProperties is JsonSchema.SchemaAdditionalProperties item13)
            {
                this.additionalProperties = Menes.JsonReference.FromValue(item13);
            }
            else
            {
                this.additionalProperties = null;
            }
            if (patternProperties is JsonSchema.SchemaProperties item14)
            {
                this.patternProperties = Menes.JsonReference.FromValue(item14);
            }
            else
            {
                this.patternProperties = null;
            }
            if (propertyNames is JsonSchema.SchemaOrReference item15)
            {
                this.propertyNames = Menes.JsonReference.FromValue(item15);
            }
            else
            {
                this.propertyNames = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private JsonSchema(Menes.JsonString? id, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Menes.JsonReference? allOf, Menes.JsonReference? anyOf, Menes.JsonReference? oneOf, Menes.JsonReference? not, Menes.JsonReference? @if, Menes.JsonReference? then, Menes.JsonReference? @else, Menes.JsonReference? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, Menes.JsonReference? items, Menes.JsonReference? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, Menes.JsonReference? required, Menes.JsonReference? properties, Menes.JsonReference? additionalProperties, Menes.JsonReference? patternProperties, Menes.JsonReference? propertyNames, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.id = id;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is Menes.JsonReference item1)
            {
                this.allOf = item1;
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is Menes.JsonReference item2)
            {
                this.anyOf = item2;
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is Menes.JsonReference item3)
            {
                this.oneOf = item3;
            }
            else
            {
                this.oneOf = null;
            }
            if (not is Menes.JsonReference item4)
            {
                this.not = item4;
            }
            else
            {
                this.not = null;
            }
            if (@if is Menes.JsonReference item5)
            {
                this.@if = item5;
            }
            else
            {
                this.@if = null;
            }
            if (then is Menes.JsonReference item6)
            {
                this.then = item6;
            }
            else
            {
                this.then = null;
            }
            if (@else is Menes.JsonReference item7)
            {
                this.@else = item7;
            }
            else
            {
                this.@else = null;
            }
            if (dependentSchemas is Menes.JsonReference item8)
            {
                this.dependentSchemas = item8;
            }
            else
            {
                this.dependentSchemas = null;
            }
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
            if (items is Menes.JsonReference item9)
            {
                this.items = item9;
            }
            else
            {
                this.items = null;
            }
            if (contains is Menes.JsonReference item10)
            {
                this.contains = item10;
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            if (required is Menes.JsonReference item11)
            {
                this.required = item11;
            }
            else
            {
                this.required = null;
            }
            if (properties is Menes.JsonReference item12)
            {
                this.properties = item12;
            }
            else
            {
                this.properties = null;
            }
            if (additionalProperties is Menes.JsonReference item13)
            {
                this.additionalProperties = item13;
            }
            else
            {
                this.additionalProperties = null;
            }
            if (patternProperties is Menes.JsonReference item14)
            {
                this.patternProperties = item14;
            }
            else
            {
                this.patternProperties = null;
            }
            if (propertyNames is Menes.JsonReference item15)
            {
                this.propertyNames = item15;
            }
            else
            {
                this.propertyNames = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.id is null || this.id.Value.IsNull) && (this.schema is null || this.schema.Value.IsNull) && (this.title is null || this.title.Value.IsNull) && (this.description is null || this.description.Value.IsNull) && (this.comment is null || this.comment.Value.IsNull) && (this.type is null || this.type.Value.IsNull) && (this.format is null || this.format.Value.IsNull) && (this.@enum is null || this.@enum.Value.IsNull) && (this.@const is null || this.@const.Value.IsNull) && (this.allOf is null || this.allOf.Value.IsNull) && (this.anyOf is null || this.anyOf.Value.IsNull) && (this.oneOf is null || this.oneOf.Value.IsNull) && (this.not is null || this.not.Value.IsNull) && (this.@if is null || this.@if.Value.IsNull) && (this.then is null || this.then.Value.IsNull) && (this.@else is null || this.@else.Value.IsNull) && (this.dependentSchemas is null || this.dependentSchemas.Value.IsNull) && (this.multipleOf is null || this.multipleOf.Value.IsNull) && (this.maximum is null || this.maximum.Value.IsNull) && (this.exclusiveMaximum is null || this.exclusiveMaximum.Value.IsNull) && (this.minimum is null || this.minimum.Value.IsNull) && (this.exclusiveMinimum is null || this.exclusiveMinimum.Value.IsNull) && (this.maxLength is null || this.maxLength.Value.IsNull) && (this.minLength is null || this.minLength.Value.IsNull) && (this.pattern is null || this.pattern.Value.IsNull) && (this.maxItems is null || this.maxItems.Value.IsNull) && (this.minItems is null || this.minItems.Value.IsNull) && (this.uniqueItems is null || this.uniqueItems.Value.IsNull) && (this.maxContains is null || this.maxContains.Value.IsNull) && (this.minContains is null || this.minContains.Value.IsNull) && (this.items is null || this.items.Value.IsNull) && (this.contains is null || this.contains.Value.IsNull) && (this.maxProperties is null || this.maxProperties.Value.IsNull) && (this.minProperties is null || this.minProperties.Value.IsNull) && (this.required is null || this.required.Value.IsNull) && (this.properties is null || this.properties.Value.IsNull) && (this.additionalProperties is null || this.additionalProperties.Value.IsNull) && (this.patternProperties is null || this.patternProperties.Value.IsNull) && (this.propertyNames is null || this.propertyNames.Value.IsNull);
        public JsonSchema? AsOptional => this.IsNull ? default(JsonSchema?) : this;
        public Menes.JsonString? Id => this.id ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, IdPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Schema => this.schema ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, SchemaPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Title => this.title ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, TitlePropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Description => this.description ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, DescriptionPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Comment => this.comment ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, CommentPropertyNameBytes.Span).AsOptional;
        public JsonSchema.TypeEnum? Type => this.type ?? JsonSchema.TypeEnum.FromOptionalProperty(this.JsonElement, TypePropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Format => this.format ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, FormatPropertyNameBytes.Span).AsOptional;
        public Menes.JsonArray<Menes.JsonAny>? Enum => this.@enum ?? Menes.JsonArray<Menes.JsonAny>.FromOptionalProperty(this.JsonElement, EnumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonAny? Const => this.@const ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, ConstPropertyNameBytes.Span).AsOptional;
        public JsonSchema.ValidatedArrayOfSchemaOrReference? AllOf => this.allOf?.AsValue<JsonSchema.ValidatedArrayOfSchemaOrReference>() ?? JsonSchema.ValidatedArrayOfSchemaOrReference.FromOptionalProperty(this.JsonElement, AllOfPropertyNameBytes.Span).AsOptional;
        public JsonSchema.ValidatedArrayOfSchemaOrReference? AnyOf => this.anyOf?.AsValue<JsonSchema.ValidatedArrayOfSchemaOrReference>() ?? JsonSchema.ValidatedArrayOfSchemaOrReference.FromOptionalProperty(this.JsonElement, AnyOfPropertyNameBytes.Span).AsOptional;
        public JsonSchema.ValidatedArrayOfSchemaOrReference? OneOf => this.oneOf?.AsValue<JsonSchema.ValidatedArrayOfSchemaOrReference>() ?? JsonSchema.ValidatedArrayOfSchemaOrReference.FromOptionalProperty(this.JsonElement, OneOfPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaOrReference? Not => this.not?.AsValue<JsonSchema.SchemaOrReference>() ?? JsonSchema.SchemaOrReference.FromOptionalProperty(this.JsonElement, NotPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaOrReference? If => this.@if?.AsValue<JsonSchema.SchemaOrReference>() ?? JsonSchema.SchemaOrReference.FromOptionalProperty(this.JsonElement, IfPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaOrReference? Then => this.then?.AsValue<JsonSchema.SchemaOrReference>() ?? JsonSchema.SchemaOrReference.FromOptionalProperty(this.JsonElement, ThenPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaOrReference? Else => this.@else?.AsValue<JsonSchema.SchemaOrReference>() ?? JsonSchema.SchemaOrReference.FromOptionalProperty(this.JsonElement, ElsePropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaProperties? DependentSchemas => this.dependentSchemas?.AsValue<JsonSchema.SchemaProperties>() ?? JsonSchema.SchemaProperties.FromOptionalProperty(this.JsonElement, DependentSchemasPropertyNameBytes.Span).AsOptional;
        public JsonSchema.PositiveNumber? MultipleOf => this.multipleOf ?? JsonSchema.PositiveNumber.FromOptionalProperty(this.JsonElement, MultipleOfPropertyNameBytes.Span).AsOptional;
        public Menes.JsonNumber? Maximum => this.maximum ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, MaximumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonNumber? ExclusiveMaximum => this.exclusiveMaximum ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, ExclusiveMaximumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonNumber? Minimum => this.minimum ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, MinimumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonNumber? ExclusiveMinimum => this.exclusiveMinimum ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, ExclusiveMinimumPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonNegativeInteger? MaxLength => this.maxLength ?? JsonSchema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxLengthPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonNegativeInteger? MinLength => this.minLength ?? JsonSchema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinLengthPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Pattern => this.pattern ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, PatternPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonNegativeInteger? MaxItems => this.maxItems ?? JsonSchema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxItemsPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonNegativeInteger? MinItems => this.minItems ?? JsonSchema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinItemsPropertyNameBytes.Span).AsOptional;
        public Menes.JsonBoolean? UniqueItems => this.uniqueItems ?? Menes.JsonBoolean.FromOptionalProperty(this.JsonElement, UniqueItemsPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonNegativeInteger? MaxContains => this.maxContains ?? JsonSchema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxContainsPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonNegativeInteger? MinContains => this.minContains ?? JsonSchema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinContainsPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaOrReference? Items => this.items?.AsValue<JsonSchema.SchemaOrReference>() ?? JsonSchema.SchemaOrReference.FromOptionalProperty(this.JsonElement, ItemsPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaOrReference? Contains => this.contains?.AsValue<JsonSchema.SchemaOrReference>() ?? JsonSchema.SchemaOrReference.FromOptionalProperty(this.JsonElement, ContainsPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonNegativeInteger? MaxProperties => this.maxProperties ?? JsonSchema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxPropertiesPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonNegativeInteger? MinProperties => this.minProperties ?? JsonSchema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinPropertiesPropertyNameBytes.Span).AsOptional;
        public JsonSchema.ValidatedArrayOfJsonString? Required => this.required?.AsValue<JsonSchema.ValidatedArrayOfJsonString>() ?? JsonSchema.ValidatedArrayOfJsonString.FromOptionalProperty(this.JsonElement, RequiredPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaProperties? Properties => this.properties?.AsValue<JsonSchema.SchemaProperties>() ?? JsonSchema.SchemaProperties.FromOptionalProperty(this.JsonElement, PropertiesPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaAdditionalProperties? AdditionalProperties => this.additionalProperties?.AsValue<JsonSchema.SchemaAdditionalProperties>() ?? JsonSchema.SchemaAdditionalProperties.FromOptionalProperty(this.JsonElement, AdditionalPropertiesPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaProperties? PatternProperties => this.patternProperties?.AsValue<JsonSchema.SchemaProperties>() ?? JsonSchema.SchemaProperties.FromOptionalProperty(this.JsonElement, PatternPropertiesPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaOrReference? PropertyNames => this.propertyNames?.AsValue<JsonSchema.SchemaOrReference>() ?? JsonSchema.SchemaOrReference.FromOptionalProperty(this.JsonElement, PropertyNamesPropertyNameBytes.Span).AsOptional;
        public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
        public int JsonAdditionalPropertiesCount
        {
            get
            {
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                int count = 0;

                while (enumerator.MoveNext())
                {
                    count++;
                }

                return count;
            }
        }
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
        {
            get
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> ap)
                {
                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(ap, KnownProperties);
                }

                if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                }

                return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonAny>.Empty, KnownProperties);
            }
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
        }
        public static JsonSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new JsonSchema(property)
                    : Null)
                : Null;
        public static JsonSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new JsonSchema(property)
                    : Null)
                : Null;
        public static JsonSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new JsonSchema(property)
                    : Null)
            : Null;
        public JsonSchema WithId(Menes.JsonString? value)
        {
            return new JsonSchema(value, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithSchema(Menes.JsonString? value)
        {
            return new JsonSchema(this.Id, value, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithTitle(Menes.JsonString? value)
        {
            return new JsonSchema(this.Id, this.Schema, value, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithDescription(Menes.JsonString? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, value, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithComment(Menes.JsonString? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, value, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithType(JsonSchema.TypeEnum? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, value, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithFormat(Menes.JsonString? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, value, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithEnum(Menes.JsonArray<Menes.JsonAny>? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, value, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithConst(Menes.JsonAny? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, value, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithAllOf(JsonSchema.ValidatedArrayOfSchemaOrReference? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, Menes.JsonReference.FromValue(value), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithAnyOf(JsonSchema.ValidatedArrayOfSchemaOrReference? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), Menes.JsonReference.FromValue(value), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithOneOf(JsonSchema.ValidatedArrayOfSchemaOrReference? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), Menes.JsonReference.FromValue(value), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithNot(JsonSchema.SchemaOrReference? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), Menes.JsonReference.FromValue(value), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithIf(JsonSchema.SchemaOrReference? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), Menes.JsonReference.FromValue(value), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithThen(JsonSchema.SchemaOrReference? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), Menes.JsonReference.FromValue(value), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithElse(JsonSchema.SchemaOrReference? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), Menes.JsonReference.FromValue(value), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithDependentSchemas(JsonSchema.SchemaProperties? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), Menes.JsonReference.FromValue(value), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMultipleOf(JsonSchema.PositiveNumber? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), value, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMaximum(Menes.JsonNumber? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, value, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithExclusiveMaximum(Menes.JsonNumber? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, value, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMinimum(Menes.JsonNumber? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, value, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithExclusiveMinimum(Menes.JsonNumber? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, value, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMaxLength(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, value, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMinLength(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, value, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithPattern(Menes.JsonString? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, value, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMaxItems(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, value, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMinItems(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, value, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithUniqueItems(Menes.JsonBoolean? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, value, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMaxContains(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, value, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMinContains(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, value, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithItems(JsonSchema.SchemaOrReference? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, Menes.JsonReference.FromValue(value), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithContains(JsonSchema.SchemaOrReference? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), Menes.JsonReference.FromValue(value), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMaxProperties(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), value, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMinProperties(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, value, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithRequired(JsonSchema.ValidatedArrayOfJsonString? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, Menes.JsonReference.FromValue(value), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithProperties(JsonSchema.SchemaProperties? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), Menes.JsonReference.FromValue(value), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithAdditionalProperties(JsonSchema.SchemaAdditionalProperties? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), Menes.JsonReference.FromValue(value), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithPatternProperties(JsonSchema.SchemaProperties? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), Menes.JsonReference.FromValue(value), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithPropertyNames(JsonSchema.SchemaOrReference? value)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), Menes.JsonReference.FromValue(value), this.GetJsonProperties());
        }
        public JsonSchema WithAdditionalProperties(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), newAdditional);
        }
        public JsonSchema WithAdditionalProperties(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public JsonSchema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public JsonSchema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public JsonSchema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public JsonSchema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new JsonSchema(this.Id, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
        }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }
            else
            {
                writer.WriteStartObject();
                if (this.id is Menes.JsonString id)
                {
                    writer.WritePropertyName(EncodedIdPropertyName);
                    id.WriteTo(writer);
                }
                if (this.schema is Menes.JsonString schema)
                {
                    writer.WritePropertyName(EncodedSchemaPropertyName);
                    schema.WriteTo(writer);
                }
                if (this.title is Menes.JsonString title)
                {
                    writer.WritePropertyName(EncodedTitlePropertyName);
                    title.WriteTo(writer);
                }
                if (this.description is Menes.JsonString description)
                {
                    writer.WritePropertyName(EncodedDescriptionPropertyName);
                    description.WriteTo(writer);
                }
                if (this.comment is Menes.JsonString comment)
                {
                    writer.WritePropertyName(EncodedCommentPropertyName);
                    comment.WriteTo(writer);
                }
                if (this.type is JsonSchema.TypeEnum type)
                {
                    writer.WritePropertyName(EncodedTypePropertyName);
                    type.WriteTo(writer);
                }
                if (this.format is Menes.JsonString format)
                {
                    writer.WritePropertyName(EncodedFormatPropertyName);
                    format.WriteTo(writer);
                }
                if (this.@enum is Menes.JsonArray<Menes.JsonAny> @enum)
                {
                    writer.WritePropertyName(EncodedEnumPropertyName);
                    @enum.WriteTo(writer);
                }
                if (this.@const is Menes.JsonAny @const)
                {
                    writer.WritePropertyName(EncodedConstPropertyName);
                    @const.WriteTo(writer);
                }
                if (this.allOf is Menes.JsonReference allOf)
                {
                    writer.WritePropertyName(EncodedAllOfPropertyName);
                    allOf.WriteTo(writer);
                }
                if (this.anyOf is Menes.JsonReference anyOf)
                {
                    writer.WritePropertyName(EncodedAnyOfPropertyName);
                    anyOf.WriteTo(writer);
                }
                if (this.oneOf is Menes.JsonReference oneOf)
                {
                    writer.WritePropertyName(EncodedOneOfPropertyName);
                    oneOf.WriteTo(writer);
                }
                if (this.not is Menes.JsonReference not)
                {
                    writer.WritePropertyName(EncodedNotPropertyName);
                    not.WriteTo(writer);
                }
                if (this.@if is Menes.JsonReference @if)
                {
                    writer.WritePropertyName(EncodedIfPropertyName);
                    @if.WriteTo(writer);
                }
                if (this.then is Menes.JsonReference then)
                {
                    writer.WritePropertyName(EncodedThenPropertyName);
                    then.WriteTo(writer);
                }
                if (this.@else is Menes.JsonReference @else)
                {
                    writer.WritePropertyName(EncodedElsePropertyName);
                    @else.WriteTo(writer);
                }
                if (this.dependentSchemas is Menes.JsonReference dependentSchemas)
                {
                    writer.WritePropertyName(EncodedDependentSchemasPropertyName);
                    dependentSchemas.WriteTo(writer);
                }
                if (this.multipleOf is JsonSchema.PositiveNumber multipleOf)
                {
                    writer.WritePropertyName(EncodedMultipleOfPropertyName);
                    multipleOf.WriteTo(writer);
                }
                if (this.maximum is Menes.JsonNumber maximum)
                {
                    writer.WritePropertyName(EncodedMaximumPropertyName);
                    maximum.WriteTo(writer);
                }
                if (this.exclusiveMaximum is Menes.JsonNumber exclusiveMaximum)
                {
                    writer.WritePropertyName(EncodedExclusiveMaximumPropertyName);
                    exclusiveMaximum.WriteTo(writer);
                }
                if (this.minimum is Menes.JsonNumber minimum)
                {
                    writer.WritePropertyName(EncodedMinimumPropertyName);
                    minimum.WriteTo(writer);
                }
                if (this.exclusiveMinimum is Menes.JsonNumber exclusiveMinimum)
                {
                    writer.WritePropertyName(EncodedExclusiveMinimumPropertyName);
                    exclusiveMinimum.WriteTo(writer);
                }
                if (this.maxLength is JsonSchema.NonNegativeInteger maxLength)
                {
                    writer.WritePropertyName(EncodedMaxLengthPropertyName);
                    maxLength.WriteTo(writer);
                }
                if (this.minLength is JsonSchema.NonNegativeInteger minLength)
                {
                    writer.WritePropertyName(EncodedMinLengthPropertyName);
                    minLength.WriteTo(writer);
                }
                if (this.pattern is Menes.JsonString pattern)
                {
                    writer.WritePropertyName(EncodedPatternPropertyName);
                    pattern.WriteTo(writer);
                }
                if (this.maxItems is JsonSchema.NonNegativeInteger maxItems)
                {
                    writer.WritePropertyName(EncodedMaxItemsPropertyName);
                    maxItems.WriteTo(writer);
                }
                if (this.minItems is JsonSchema.NonNegativeInteger minItems)
                {
                    writer.WritePropertyName(EncodedMinItemsPropertyName);
                    minItems.WriteTo(writer);
                }
                if (this.uniqueItems is Menes.JsonBoolean uniqueItems)
                {
                    writer.WritePropertyName(EncodedUniqueItemsPropertyName);
                    uniqueItems.WriteTo(writer);
                }
                if (this.maxContains is JsonSchema.NonNegativeInteger maxContains)
                {
                    writer.WritePropertyName(EncodedMaxContainsPropertyName);
                    maxContains.WriteTo(writer);
                }
                if (this.minContains is JsonSchema.NonNegativeInteger minContains)
                {
                    writer.WritePropertyName(EncodedMinContainsPropertyName);
                    minContains.WriteTo(writer);
                }
                if (this.items is Menes.JsonReference items)
                {
                    writer.WritePropertyName(EncodedItemsPropertyName);
                    items.WriteTo(writer);
                }
                if (this.contains is Menes.JsonReference contains)
                {
                    writer.WritePropertyName(EncodedContainsPropertyName);
                    contains.WriteTo(writer);
                }
                if (this.maxProperties is JsonSchema.NonNegativeInteger maxProperties)
                {
                    writer.WritePropertyName(EncodedMaxPropertiesPropertyName);
                    maxProperties.WriteTo(writer);
                }
                if (this.minProperties is JsonSchema.NonNegativeInteger minProperties)
                {
                    writer.WritePropertyName(EncodedMinPropertiesPropertyName);
                    minProperties.WriteTo(writer);
                }
                if (this.required is Menes.JsonReference required)
                {
                    writer.WritePropertyName(EncodedRequiredPropertyName);
                    required.WriteTo(writer);
                }
                if (this.properties is Menes.JsonReference properties)
                {
                    writer.WritePropertyName(EncodedPropertiesPropertyName);
                    properties.WriteTo(writer);
                }
                if (this.additionalProperties is Menes.JsonReference additionalProperties)
                {
                    writer.WritePropertyName(EncodedAdditionalPropertiesPropertyName);
                    additionalProperties.WriteTo(writer);
                }
                if (this.patternProperties is Menes.JsonReference patternProperties)
                {
                    writer.WritePropertyName(EncodedPatternPropertiesPropertyName);
                    patternProperties.WriteTo(writer);
                }
                if (this.propertyNames is Menes.JsonReference propertyNames)
                {
                    writer.WritePropertyName(EncodedPropertyNamesPropertyName);
                    propertyNames.WriteTo(writer);
                }
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(JsonSchema other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }
            if (this.HasJsonElement && other.HasJsonElement)
            {
                return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
            }
            return this.Id.Equals(other.Id) && this.Schema.Equals(other.Schema) && this.Title.Equals(other.Title) && this.Description.Equals(other.Description) && this.Comment.Equals(other.Comment) && this.Type.Equals(other.Type) && this.Format.Equals(other.Format) && this.Enum.Equals(other.Enum) && this.Const.Equals(other.Const) && this.AllOf.Equals(other.AllOf) && this.AnyOf.Equals(other.AnyOf) && this.OneOf.Equals(other.OneOf) && this.Not.Equals(other.Not) && this.If.Equals(other.If) && this.Then.Equals(other.Then) && this.Else.Equals(other.Else) && this.DependentSchemas.Equals(other.DependentSchemas) && this.MultipleOf.Equals(other.MultipleOf) && this.Maximum.Equals(other.Maximum) && this.ExclusiveMaximum.Equals(other.ExclusiveMaximum) && this.Minimum.Equals(other.Minimum) && this.ExclusiveMinimum.Equals(other.ExclusiveMinimum) && this.MaxLength.Equals(other.MaxLength) && this.MinLength.Equals(other.MinLength) && this.Pattern.Equals(other.Pattern) && this.MaxItems.Equals(other.MaxItems) && this.MinItems.Equals(other.MinItems) && this.UniqueItems.Equals(other.UniqueItems) && this.MaxContains.Equals(other.MaxContains) && this.MinContains.Equals(other.MinContains) && this.Items.Equals(other.Items) && this.Contains.Equals(other.Contains) && this.MaxProperties.Equals(other.MaxProperties) && this.MinProperties.Equals(other.MinProperties) && this.Required.Equals(other.Required) && this.Properties.Equals(other.Properties) && this.AdditionalProperties.Equals(other.AdditionalProperties) && this.PatternProperties.Equals(other.PatternProperties) && this.PropertyNames.Equals(other.PropertyNames) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.ValidationContext context = validationContext;
            if (this.Id is Menes.JsonString id)
            {
                context = Menes.Validation.ValidateProperty(context, id, IdPropertyNamePath);
            }
            if (this.Schema is Menes.JsonString schema)
            {
                context = Menes.Validation.ValidateProperty(context, schema, SchemaPropertyNamePath);
            }
            if (this.Title is Menes.JsonString title)
            {
                context = Menes.Validation.ValidateProperty(context, title, TitlePropertyNamePath);
            }
            if (this.Description is Menes.JsonString description)
            {
                context = Menes.Validation.ValidateProperty(context, description, DescriptionPropertyNamePath);
            }
            if (this.Comment is Menes.JsonString comment)
            {
                context = Menes.Validation.ValidateProperty(context, comment, CommentPropertyNamePath);
            }
            if (this.Type is JsonSchema.TypeEnum type)
            {
                context = Menes.Validation.ValidateProperty(context, type, TypePropertyNamePath);
            }
            if (this.Format is Menes.JsonString format)
            {
                context = Menes.Validation.ValidateProperty(context, format, FormatPropertyNamePath);
            }
            if (this.Enum is Menes.JsonArray<Menes.JsonAny> @enum)
            {
                context = Menes.Validation.ValidateProperty(context, @enum, EnumPropertyNamePath);
            }
            if (this.Const is Menes.JsonAny @const)
            {
                context = Menes.Validation.ValidateProperty(context, @const, ConstPropertyNamePath);
            }
            if (this.AllOf is JsonSchema.ValidatedArrayOfSchemaOrReference allOf)
            {
                context = Menes.Validation.ValidateProperty(context, allOf, AllOfPropertyNamePath);
            }
            if (this.AnyOf is JsonSchema.ValidatedArrayOfSchemaOrReference anyOf)
            {
                context = Menes.Validation.ValidateProperty(context, anyOf, AnyOfPropertyNamePath);
            }
            if (this.OneOf is JsonSchema.ValidatedArrayOfSchemaOrReference oneOf)
            {
                context = Menes.Validation.ValidateProperty(context, oneOf, OneOfPropertyNamePath);
            }
            if (this.Not is JsonSchema.SchemaOrReference not)
            {
                context = Menes.Validation.ValidateProperty(context, not, NotPropertyNamePath);
            }
            if (this.If is JsonSchema.SchemaOrReference @if)
            {
                context = Menes.Validation.ValidateProperty(context, @if, IfPropertyNamePath);
            }
            if (this.Then is JsonSchema.SchemaOrReference then)
            {
                context = Menes.Validation.ValidateProperty(context, then, ThenPropertyNamePath);
            }
            if (this.Else is JsonSchema.SchemaOrReference @else)
            {
                context = Menes.Validation.ValidateProperty(context, @else, ElsePropertyNamePath);
            }
            if (this.DependentSchemas is JsonSchema.SchemaProperties dependentSchemas)
            {
                context = Menes.Validation.ValidateProperty(context, dependentSchemas, DependentSchemasPropertyNamePath);
            }
            if (this.MultipleOf is JsonSchema.PositiveNumber multipleOf)
            {
                context = Menes.Validation.ValidateProperty(context, multipleOf, MultipleOfPropertyNamePath);
            }
            if (this.Maximum is Menes.JsonNumber maximum)
            {
                context = Menes.Validation.ValidateProperty(context, maximum, MaximumPropertyNamePath);
            }
            if (this.ExclusiveMaximum is Menes.JsonNumber exclusiveMaximum)
            {
                context = Menes.Validation.ValidateProperty(context, exclusiveMaximum, ExclusiveMaximumPropertyNamePath);
            }
            if (this.Minimum is Menes.JsonNumber minimum)
            {
                context = Menes.Validation.ValidateProperty(context, minimum, MinimumPropertyNamePath);
            }
            if (this.ExclusiveMinimum is Menes.JsonNumber exclusiveMinimum)
            {
                context = Menes.Validation.ValidateProperty(context, exclusiveMinimum, ExclusiveMinimumPropertyNamePath);
            }
            if (this.MaxLength is JsonSchema.NonNegativeInteger maxLength)
            {
                context = Menes.Validation.ValidateProperty(context, maxLength, MaxLengthPropertyNamePath);
            }
            if (this.MinLength is JsonSchema.NonNegativeInteger minLength)
            {
                context = Menes.Validation.ValidateProperty(context, minLength, MinLengthPropertyNamePath);
            }
            if (this.Pattern is Menes.JsonString pattern)
            {
                context = Menes.Validation.ValidateProperty(context, pattern, PatternPropertyNamePath);
            }
            if (this.MaxItems is JsonSchema.NonNegativeInteger maxItems)
            {
                context = Menes.Validation.ValidateProperty(context, maxItems, MaxItemsPropertyNamePath);
            }
            if (this.MinItems is JsonSchema.NonNegativeInteger minItems)
            {
                context = Menes.Validation.ValidateProperty(context, minItems, MinItemsPropertyNamePath);
            }
            if (this.UniqueItems is Menes.JsonBoolean uniqueItems)
            {
                context = Menes.Validation.ValidateProperty(context, uniqueItems, UniqueItemsPropertyNamePath);
            }
            if (this.MaxContains is JsonSchema.NonNegativeInteger maxContains)
            {
                context = Menes.Validation.ValidateProperty(context, maxContains, MaxContainsPropertyNamePath);
            }
            if (this.MinContains is JsonSchema.NonNegativeInteger minContains)
            {
                context = Menes.Validation.ValidateProperty(context, minContains, MinContainsPropertyNamePath);
            }
            if (this.Items is JsonSchema.SchemaOrReference items)
            {
                context = Menes.Validation.ValidateProperty(context, items, ItemsPropertyNamePath);
            }
            if (this.Contains is JsonSchema.SchemaOrReference contains)
            {
                context = Menes.Validation.ValidateProperty(context, contains, ContainsPropertyNamePath);
            }
            if (this.MaxProperties is JsonSchema.NonNegativeInteger maxProperties)
            {
                context = Menes.Validation.ValidateProperty(context, maxProperties, MaxPropertiesPropertyNamePath);
            }
            if (this.MinProperties is JsonSchema.NonNegativeInteger minProperties)
            {
                context = Menes.Validation.ValidateProperty(context, minProperties, MinPropertiesPropertyNamePath);
            }
            if (this.Required is JsonSchema.ValidatedArrayOfJsonString required)
            {
                context = Menes.Validation.ValidateProperty(context, required, RequiredPropertyNamePath);
            }
            if (this.Properties is JsonSchema.SchemaProperties properties)
            {
                context = Menes.Validation.ValidateProperty(context, properties, PropertiesPropertyNamePath);
            }
            if (this.AdditionalProperties is JsonSchema.SchemaAdditionalProperties additionalProperties)
            {
                context = Menes.Validation.ValidateProperty(context, additionalProperties, AdditionalPropertiesPropertyNamePath);
            }
            if (this.PatternProperties is JsonSchema.SchemaProperties patternProperties)
            {
                context = Menes.Validation.ValidateProperty(context, patternProperties, PatternPropertiesPropertyNamePath);
            }
            if (this.PropertyNames is JsonSchema.SchemaOrReference propertyNames)
            {
                context = Menes.Validation.ValidateProperty(context, propertyNames, PropertyNamesPropertyNamePath);
            }
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
            }
            context = Menes.Validation.ValidateNot<JsonSchema, JsonSchema.SchemaReference>(context, this);
            return context;
        }
        public bool TryGetAdditionalProperty(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny? value)
        {
            return this.TryGetAdditionalProperty(System.MemoryExtensions.AsSpan(propertyName), out value);
        }
        public bool TryGetAdditionalProperty(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny? value)
        {
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (property.NameEquals(utf8PropertyName))
                {
                    value = property.AsValue();
                    return true;
                }
            }
            value = default;
            return false;
        }
        public bool TryGetAdditionalProperty(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny? value)
        {
            System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
            int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
            return this.TryGetAdditionalProperty(bytes.Slice(0, written), out value);
        }
        public override string? ToString()
        {
            return Menes.JsonAny.From(this).ToString();
        }
        private Menes.JsonReference? GetAllOf()
        {
            if (this.allOf is Menes.JsonReference)
            {
                return this.allOf;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(AllOfPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetAnyOf()
        {
            if (this.anyOf is Menes.JsonReference)
            {
                return this.anyOf;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(AnyOfPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetOneOf()
        {
            if (this.oneOf is Menes.JsonReference)
            {
                return this.oneOf;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(OneOfPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetNot()
        {
            if (this.not is Menes.JsonReference)
            {
                return this.not;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(NotPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetIf()
        {
            if (this.@if is Menes.JsonReference)
            {
                return this.@if;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(IfPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetThen()
        {
            if (this.then is Menes.JsonReference)
            {
                return this.then;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(ThenPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetElse()
        {
            if (this.@else is Menes.JsonReference)
            {
                return this.@else;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(ElsePropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetDependentSchemas()
        {
            if (this.dependentSchemas is Menes.JsonReference)
            {
                return this.dependentSchemas;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(DependentSchemasPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetItems()
        {
            if (this.items is Menes.JsonReference)
            {
                return this.items;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(ItemsPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetContains()
        {
            if (this.contains is Menes.JsonReference)
            {
                return this.contains;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(ContainsPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetRequired()
        {
            if (this.required is Menes.JsonReference)
            {
                return this.required;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(RequiredPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetProperties()
        {
            if (this.properties is Menes.JsonReference)
            {
                return this.properties;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(PropertiesPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetAdditionalProperties()
        {
            if (this.additionalProperties is Menes.JsonReference)
            {
                return this.additionalProperties;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(AdditionalPropertiesPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetPatternProperties()
        {
            if (this.patternProperties is Menes.JsonReference)
            {
                return this.patternProperties;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(PatternPropertiesPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetPropertyNames()
        {
            if (this.propertyNames is Menes.JsonReference)
            {
                return this.propertyNames;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(PropertyNamesPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
        {
            if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
            {
                return props;
            }
            return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
        }

        public readonly struct SchemaReference : Menes.IJsonObject, System.IEquatable<JsonSchema.SchemaReference>
        {
            public static readonly JsonSchema.SchemaReference Null = new JsonSchema.SchemaReference(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema.SchemaReference> FromJsonElement = e => new JsonSchema.SchemaReference(e);
            private const string RefPropertyNamePath = ".$ref";
            private static readonly System.ReadOnlyMemory<byte> RefPropertyNameBytes = new byte[] { 36, 114, 101, 102 };
            private static readonly System.Text.Json.JsonEncodedText EncodedRefPropertyName = System.Text.Json.JsonEncodedText.Encode(RefPropertyNameBytes.Span);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(RefPropertyNameBytes);
            private readonly Menes.JsonString? @ref;
            public SchemaReference(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.@ref = null;
            }
            public SchemaReference(Menes.JsonString @ref)
            {
                this.@ref = @ref;
                this.JsonElement = default;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.@ref is null || this.@ref.Value.IsNull);
            public JsonSchema.SchemaReference? AsOptional => this.IsNull ? default(JsonSchema.SchemaReference?) : this;
            public Menes.JsonString Ref => this.@ref ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, RefPropertyNameBytes.Span);
            public int PropertiesCount => KnownProperties.Length;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static JsonSchema.SchemaReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new JsonSchema.SchemaReference(property)
                        : Null)
                    : Null;
            public static JsonSchema.SchemaReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new JsonSchema.SchemaReference(property)
                        : Null)
                    : Null;
            public static JsonSchema.SchemaReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new JsonSchema.SchemaReference(property)
                        : Null)
                : Null;
            public JsonSchema.SchemaReference WithRef(Menes.JsonString value)
            {
                return new JsonSchema.SchemaReference(value);
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else
                {
                    writer.WriteStartObject();
                    if (this.@ref is Menes.JsonString @ref)
                    {
                        writer.WritePropertyName(EncodedRefPropertyName);
                        @ref.WriteTo(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(JsonSchema.SchemaReference other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return this.Ref.Equals(other.Ref);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.ValidationContext context = validationContext;
                context = Menes.Validation.ValidateRequiredProperty(context, this.Ref, RefPropertyNamePath);
                return context;
            }
            public override string? ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
        }

        public readonly struct SchemaOrReference : Menes.IJsonValue
        {
            public static readonly SchemaOrReference Null = new SchemaOrReference(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema.SchemaOrReference> FromJsonElement = e => new JsonSchema.SchemaOrReference(e);
            private readonly Menes.JsonReference? item1;
            private readonly Menes.JsonReference? item2;
            public SchemaOrReference(JsonSchema clrInstance)
            {
                if (clrInstance.HasJsonElement)
                {
                    this.JsonElement = clrInstance.JsonElement;
                    this.item1 = null;
                }
                else
                {
                    this.item1 = Menes.JsonReference.FromValue(clrInstance);
                    this.JsonElement = default;
                }
                this.item2 = null;
            }
            public SchemaOrReference(JsonSchema.SchemaReference clrInstance)
            {
                if (clrInstance.HasJsonElement)
                {
                    this.JsonElement = clrInstance.JsonElement;
                    this.item2 = null;
                }
                else
                {
                    this.item2 = Menes.JsonReference.FromValue(clrInstance);
                    this.JsonElement = default;
                }
                this.item1 = null;
            }
            public SchemaOrReference(System.Text.Json.JsonElement jsonElement)
            {
                this.item1 = null;
                this.item2 = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public SchemaOrReference? AsOptional => this.IsNull ? default(SchemaOrReference?) : this;
            public bool IsJsonSchema => this.item1 is Menes.JsonReference || (JsonSchema.IsConvertibleFrom(this.JsonElement) && JsonSchema.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool IsSchemaReference => this.item2 is Menes.JsonReference || (JsonSchema.SchemaReference.IsConvertibleFrom(this.JsonElement) && JsonSchema.SchemaReference.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator JsonSchema(SchemaOrReference value) => value.AsJsonSchema();
            public static implicit operator SchemaOrReference(JsonSchema value) => new SchemaOrReference(value);
            public static explicit operator JsonSchema.SchemaReference(SchemaOrReference value) => value.AsSchemaReference();
            public static implicit operator SchemaOrReference(JsonSchema.SchemaReference value) => new SchemaOrReference(value);
            public static SchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaOrReference(property)
                        : Null)
                    : Null;
            public static SchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaOrReference(property)
                        : Null)
                    : Null;
            public static SchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaOrReference(property)
                        : Null)
                    : Null;
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                if (JsonSchema.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                if (JsonSchema.SchemaReference.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                return false;
            }
            public JsonSchema AsJsonSchema() => this.item1?.AsValue<JsonSchema>() ?? new JsonSchema(this.JsonElement);
            public JsonSchema.SchemaReference AsSchemaReference() => this.item2?.AsValue<JsonSchema.SchemaReference>() ?? new JsonSchema.SchemaReference(this.JsonElement);
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.item1 is Menes.JsonReference item1)
                {
                    item1.WriteTo(writer);
                }
                else if (this.item2 is Menes.JsonReference item2)
                {
                    item2.WriteTo(writer);
                }
                else
                {
                    this.JsonElement.WriteTo(writer);
                }
            }
            public override string? ToString()
            {
                var builder = new System.Text.StringBuilder();
                if (this.IsJsonSchema)
                {
                    builder.Append("{");
                    builder.Append("JsonSchema");
                    builder.Append(", ");
                    builder.Append(this.AsJsonSchema().ToString());
                    builder.AppendLine("}");
                }
                if (this.IsSchemaReference)
                {
                    builder.Append("{");
                    builder.Append("SchemaReference");
                    builder.Append(", ");
                    builder.Append(this.AsSchemaReference().ToString());
                    builder.AppendLine("}");
                }
                return builder.Length > 0 ? builder.ToString() : this.JsonElement.ToString();
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                if (this.IsNull)
                {
                    return validationContext;
                }
                Menes.ValidationContext validationContext1 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
                Menes.ValidationContext validationContext2 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
                if (this.IsJsonSchema)
                {
                    validationContext1 = this.AsJsonSchema().Validate(validationContext1);
                }
                else
                {
                    validationContext1 = validationContext1.WithError("The value is not convertible to a JsonSchema.");
                }
                if (this.IsSchemaReference)
                {
                    validationContext2 = this.AsSchemaReference().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a JsonSchema.SchemaReference.");
                }
                return Menes.Validation.ValidateAnyOf(validationContext, validationContext1, validationContext2);
            }
        }
        public readonly struct TypeEnum : Menes.IJsonValue, System.IEquatable<TypeEnum>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, TypeEnum> FromJsonElement = e => new TypeEnum(e);
            public static readonly TypeEnum Null = new TypeEnum(default(System.Text.Json.JsonElement));
            private static readonly string? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<string>? EnumValues = BuildEnumValues();
            private static readonly int? MaxLength = null;
            private static readonly int? MinLength = null;
            private static readonly System.Text.RegularExpressions.Regex? Pattern = null;
            private readonly Menes.JsonString? value;
            public TypeEnum(Menes.JsonString value)
            {
                if (value.HasJsonElement)
                {
                    this.JsonElement = value.JsonElement;
                    this.value = null;
                }
                else
                {
                    this.value = value;
                    this.JsonElement = default;
                }
            }
            public TypeEnum(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public TypeEnum? AsOptional => this.IsNull ? default(TypeEnum?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator TypeEnum(Menes.JsonString value)
            {
                return new TypeEnum(value);
            }
            public static implicit operator TypeEnum(string value)
            {
                return new TypeEnum(value);
            }
            public static implicit operator string(TypeEnum value)
            {
                return (string)(Menes.JsonString)value;
            }
            public static implicit operator Menes.JsonString(TypeEnum value)
            {
                if (value.value is Menes.JsonString clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonString(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonString.IsConvertibleFrom(jsonElement);
            }
            public static TypeEnum FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TypeEnum(property)
                        : Null)
                    : Null;
            public static TypeEnum FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TypeEnum(property)
                        : Null)
                    : Null;
            public static TypeEnum FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new TypeEnum(property)
                        : Null)
                    : Null;
            public bool Equals(TypeEnum other)
            {
                return this.Equals((Menes.JsonString)other);
            }
            public bool Equals(Menes.JsonString other)
            {
                return ((Menes.JsonString)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonString value = this;
                Menes.ValidationContext context = validationContext;
                context = value.Validate(context);
                context = value.ValidateAsString(context, MinLength, MaxLength, Pattern, EnumValues, ConstValue);
                return context;
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else if (this.value is Menes.JsonString clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public override string? ToString()
            {
                if (this.value is Menes.JsonString clrValue)
                {
                    return clrValue.ToString();
                }
                else
                {
                    return this.JsonElement.GetRawText();
                }
            }
            private static string? BuildConstValue()
            {
                return null;
            }
            private static System.Collections.Immutable.ImmutableArray<string>? BuildEnumValues()
            {
                System.Collections.Immutable.ImmutableArray<string>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<string>();
                arrayBuilder.Add("null");
                arrayBuilder.Add("boolean");
                arrayBuilder.Add("object");
                arrayBuilder.Add("array");
                arrayBuilder.Add("number");
                arrayBuilder.Add("string");
                arrayBuilder.Add("integer");
                return arrayBuilder.ToImmutable();
            }
        }
        public readonly struct PositiveNumber : Menes.IJsonValue, System.IEquatable<PositiveNumber>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, PositiveNumber> FromJsonElement = e => new PositiveNumber(e);
            public static readonly PositiveNumber Null = new PositiveNumber(default(System.Text.Json.JsonElement));
            private static readonly Menes.JsonNumber? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>? EnumValues = BuildEnumValues();
            private static readonly Menes.JsonNumber? MultipleOf = null;
            private static readonly Menes.JsonNumber? Maximum = null;
            private static readonly Menes.JsonNumber? ExclusiveMaximum = null;
            private static readonly Menes.JsonNumber? Minimum = null;
            private static readonly Menes.JsonNumber? ExclusiveMinimum = 0;
            private readonly Menes.JsonNumber? value;
            public PositiveNumber(Menes.JsonNumber value)
            {
                if (value.HasJsonElement)
                {
                    this.JsonElement = value.JsonElement;
                    this.value = null;
                }
                else
                {
                    this.value = value;
                    this.JsonElement = default;
                }
            }
            public PositiveNumber(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public PositiveNumber? AsOptional => this.IsNull ? default(PositiveNumber?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator PositiveNumber(Menes.JsonNumber value)
            {
                return new PositiveNumber(value);
            }
            public static implicit operator PositiveNumber(float value)
            {
                return new PositiveNumber(value);
            }
            public static implicit operator PositiveNumber(double value)
            {
                return new PositiveNumber(value);
            }
            public static implicit operator PositiveNumber(decimal value)
            {
                return new PositiveNumber(value);
            }
            public static implicit operator PositiveNumber(int value)
            {
                return new PositiveNumber(value);
            }
            public static implicit operator PositiveNumber(long value)
            {
                return new PositiveNumber(value);
            }
            public static implicit operator float(PositiveNumber value)
            {
                return (float)(Menes.JsonNumber)value;
            }
            public static implicit operator double(PositiveNumber value)
            {
                return (double)(Menes.JsonNumber)value;
            }
            public static implicit operator decimal(PositiveNumber value)
            {
                return (decimal)(Menes.JsonNumber)value;
            }
            public static implicit operator int(PositiveNumber value)
            {
                return (int)(Menes.JsonNumber)value;
            }
            public static implicit operator long(PositiveNumber value)
            {
                return (long)(Menes.JsonNumber)value;
            }
            public static implicit operator Menes.JsonNumber(PositiveNumber value)
            {
                if (value.value is Menes.JsonNumber clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonNumber(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonNumber.IsConvertibleFrom(jsonElement);
            }
            public static PositiveNumber FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new PositiveNumber(property)
                        : Null)
                    : Null;
            public static PositiveNumber FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new PositiveNumber(property)
                        : Null)
                    : Null;
            public static PositiveNumber FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new PositiveNumber(property)
                        : Null)
                    : Null;
            public bool Equals(PositiveNumber other)
            {
                return this.Equals((Menes.JsonNumber)other);
            }
            public bool Equals(Menes.JsonNumber other)
            {
                return ((Menes.JsonNumber)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonNumber value = this;
                Menes.ValidationContext context = validationContext;
                context = value.Validate(context);
                context = value.ValidateAsNumber(context, MultipleOf, Maximum, ExclusiveMaximum, Minimum, ExclusiveMinimum, EnumValues, ConstValue);
                return context;
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else if (this.value is Menes.JsonNumber clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public override string? ToString()
            {
                if (this.value is Menes.JsonNumber clrValue)
                {
                    return clrValue.ToString();
                }
                else
                {
                    return this.JsonElement.GetRawText();
                }
            }
            private static Menes.JsonNumber? BuildConstValue()
            {
                return null;
            }
            private static System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>? BuildEnumValues()
            {
                return null;
            }
        }
        public readonly struct NonNegativeInteger : Menes.IJsonValue, System.IEquatable<NonNegativeInteger>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, NonNegativeInteger> FromJsonElement = e => new NonNegativeInteger(e);
            public static readonly NonNegativeInteger Null = new NonNegativeInteger(default(System.Text.Json.JsonElement));
            private static readonly Menes.JsonInteger? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>? EnumValues = BuildEnumValues();
            private static readonly Menes.JsonInteger? MultipleOf = null;
            private static readonly Menes.JsonInteger? Maximum = null;
            private static readonly Menes.JsonInteger? ExclusiveMaximum = null;
            private static readonly Menes.JsonInteger? Minimum = 0;
            private static readonly Menes.JsonInteger? ExclusiveMinimum = null;
            private readonly Menes.JsonInteger? value;
            public NonNegativeInteger(Menes.JsonInteger value)
            {
                if (value.HasJsonElement)
                {
                    this.JsonElement = value.JsonElement;
                    this.value = null;
                }
                else
                {
                    this.value = value;
                    this.JsonElement = default;
                }
            }
            public NonNegativeInteger(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public NonNegativeInteger? AsOptional => this.IsNull ? default(NonNegativeInteger?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator NonNegativeInteger(Menes.JsonInteger value)
            {
                return new NonNegativeInteger(value);
            }
            public static implicit operator NonNegativeInteger(int value)
            {
                return new NonNegativeInteger(value);
            }
            public static implicit operator NonNegativeInteger(long value)
            {
                return new NonNegativeInteger(value);
            }
            public static implicit operator int(NonNegativeInteger value)
            {
                return (int)(Menes.JsonInteger)value;
            }
            public static implicit operator long(NonNegativeInteger value)
            {
                return (long)(Menes.JsonInteger)value;
            }
            public static implicit operator Menes.JsonInteger(NonNegativeInteger value)
            {
                if (value.value is Menes.JsonInteger clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonInteger(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonInteger.IsConvertibleFrom(jsonElement);
            }
            public static NonNegativeInteger FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new NonNegativeInteger(property)
                        : Null)
                    : Null;
            public static NonNegativeInteger FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new NonNegativeInteger(property)
                        : Null)
                    : Null;
            public static NonNegativeInteger FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new NonNegativeInteger(property)
                        : Null)
                    : Null;
            public bool Equals(NonNegativeInteger other)
            {
                return this.Equals((Menes.JsonInteger)other);
            }
            public bool Equals(Menes.JsonInteger other)
            {
                return ((Menes.JsonInteger)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonInteger value = this;
                Menes.ValidationContext context = validationContext;
                context = value.Validate(context);
                context = value.ValidateAsNumber(context, MultipleOf, Maximum, ExclusiveMaximum, Minimum, ExclusiveMinimum, EnumValues, ConstValue);
                return context;
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else if (this.value is Menes.JsonInteger clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public override string? ToString()
            {
                if (this.value is Menes.JsonInteger clrValue)
                {
                    return clrValue.ToString();
                }
                else
                {
                    return this.JsonElement.GetRawText();
                }
            }
            private static Menes.JsonInteger? BuildConstValue()
            {
                return null;
            }
            private static System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>? BuildEnumValues()
            {
                return null;
            }
        }
        public readonly struct ValidatedArrayOfJsonString : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonString>, System.Collections.IEnumerable, System.IEquatable<ValidatedArrayOfJsonString>, System.IEquatable<Menes.JsonArray<Menes.JsonString>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, ValidatedArrayOfJsonString> FromJsonElement = e => new ValidatedArrayOfJsonString(e);
            public static readonly ValidatedArrayOfJsonString Null = new ValidatedArrayOfJsonString(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<Menes.JsonString>? value;
            public ValidatedArrayOfJsonString(Menes.JsonArray<Menes.JsonString> jsonArray)
            {
                if (jsonArray.HasJsonElement)
                {
                    this.JsonElement = jsonArray.JsonElement;
                    this.value = null;
                }
                else
                {
                    this.value = jsonArray;
                    this.JsonElement = default;
                }
            }
            public ValidatedArrayOfJsonString(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public ValidatedArrayOfJsonString? AsOptional => this.IsNull ? default(ValidatedArrayOfJsonString?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator ValidatedArrayOfJsonString(Menes.JsonArray<Menes.JsonString> value)
            {
                return new ValidatedArrayOfJsonString(value);
            }
            public static implicit operator Menes.JsonArray<Menes.JsonString>(ValidatedArrayOfJsonString value)
            {
                if (value.value is Menes.JsonArray<Menes.JsonString> clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonArray<Menes.JsonString>(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonArray<Menes.JsonString>.IsConvertibleFrom(jsonElement);
            }
            public static ValidatedArrayOfJsonString FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new ValidatedArrayOfJsonString(property)
                        : Null)
                    : Null;
            public static ValidatedArrayOfJsonString FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new ValidatedArrayOfJsonString(property)
                        : Null)
                    : Null;
            public static ValidatedArrayOfJsonString FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new ValidatedArrayOfJsonString(property)
                        : Null)
                    : Null;
            public bool Equals(ValidatedArrayOfJsonString other)
            {
                return this.Equals((Menes.JsonArray<Menes.JsonString>)other);
            }
            public bool Equals(Menes.JsonArray<Menes.JsonString> other)
            {
                return ((Menes.JsonArray<Menes.JsonString>)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonArray<Menes.JsonString> array = this;
                Menes.ValidationContext context = validationContext;
                context = array.Validate(context);
                return array.ValidateUniqueItems(context, true);
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                if (this.value is Menes.JsonArray<Menes.JsonString> clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public Menes.JsonArray<Menes.JsonString>.JsonArrayEnumerator GetEnumerator()
            {
                return ((Menes.JsonArray<Menes.JsonString>)this).GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Menes.JsonString> System.Collections.Generic.IEnumerable<Menes.JsonString>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
        public readonly struct ValidatedArrayOfSchemaOrReference : Menes.IJsonValue, System.Collections.Generic.IEnumerable<JsonSchema.SchemaOrReference>, System.Collections.IEnumerable, System.IEquatable<ValidatedArrayOfSchemaOrReference>, System.IEquatable<Menes.JsonArray<JsonSchema.SchemaOrReference>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, ValidatedArrayOfSchemaOrReference> FromJsonElement = e => new ValidatedArrayOfSchemaOrReference(e);
            public static readonly ValidatedArrayOfSchemaOrReference Null = new ValidatedArrayOfSchemaOrReference(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<JsonSchema.SchemaOrReference>? value;
            public ValidatedArrayOfSchemaOrReference(Menes.JsonArray<JsonSchema.SchemaOrReference> jsonArray)
            {
                if (jsonArray.HasJsonElement)
                {
                    this.JsonElement = jsonArray.JsonElement;
                    this.value = null;
                }
                else
                {
                    this.value = jsonArray;
                    this.JsonElement = default;
                }
            }
            public ValidatedArrayOfSchemaOrReference(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public ValidatedArrayOfSchemaOrReference? AsOptional => this.IsNull ? default(ValidatedArrayOfSchemaOrReference?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator ValidatedArrayOfSchemaOrReference(Menes.JsonArray<JsonSchema.SchemaOrReference> value)
            {
                return new ValidatedArrayOfSchemaOrReference(value);
            }
            public static implicit operator Menes.JsonArray<JsonSchema.SchemaOrReference>(ValidatedArrayOfSchemaOrReference value)
            {
                if (value.value is Menes.JsonArray<JsonSchema.SchemaOrReference> clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonArray<JsonSchema.SchemaOrReference>(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonArray<JsonSchema.SchemaOrReference>.IsConvertibleFrom(jsonElement);
            }
            public static ValidatedArrayOfSchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new ValidatedArrayOfSchemaOrReference(property)
                        : Null)
                    : Null;
            public static ValidatedArrayOfSchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new ValidatedArrayOfSchemaOrReference(property)
                        : Null)
                    : Null;
            public static ValidatedArrayOfSchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new ValidatedArrayOfSchemaOrReference(property)
                        : Null)
                    : Null;
            public bool Equals(ValidatedArrayOfSchemaOrReference other)
            {
                return this.Equals((Menes.JsonArray<JsonSchema.SchemaOrReference>)other);
            }
            public bool Equals(Menes.JsonArray<JsonSchema.SchemaOrReference> other)
            {
                return ((Menes.JsonArray<JsonSchema.SchemaOrReference>)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonArray<JsonSchema.SchemaOrReference> array = this;
                Menes.ValidationContext context = validationContext;
                context = array.Validate(context);
                context = array.ValidateMinItems(context, 1);
                return array.ValidateItems(context);
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                if (this.value is Menes.JsonArray<JsonSchema.SchemaOrReference> clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public Menes.JsonArray<JsonSchema.SchemaOrReference>.JsonArrayEnumerator GetEnumerator()
            {
                return ((Menes.JsonArray<JsonSchema.SchemaOrReference>)this).GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<JsonSchema.SchemaOrReference> System.Collections.Generic.IEnumerable<JsonSchema.SchemaOrReference>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public readonly struct SchemaProperties : Menes.IJsonObject, System.IEquatable<JsonSchema.SchemaProperties>, Menes.IJsonAdditionalProperties<JsonSchema.SchemaOrReference>
        {
            public static readonly JsonSchema.SchemaProperties Null = new JsonSchema.SchemaProperties(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema.SchemaProperties> FromJsonElement = e => new JsonSchema.SchemaProperties(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties<JsonSchema.SchemaOrReference>? additionalPropertiesBacking;
            public SchemaProperties(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalPropertiesBacking = null;
            }
            public SchemaProperties(params (string, JsonSchema.SchemaOrReference)[] additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<JsonSchema.SchemaOrReference>.FromValues(additionalPropertiesBacking);
            }
            public SchemaProperties((string, JsonSchema.SchemaOrReference) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<JsonSchema.SchemaOrReference>.FromValues(additionalProperty1);
            }
            public SchemaProperties((string, JsonSchema.SchemaOrReference) additionalProperty1, (string, JsonSchema.SchemaOrReference) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<JsonSchema.SchemaOrReference>.FromValues(additionalProperty1, additionalProperty2);
            }
            public SchemaProperties((string, JsonSchema.SchemaOrReference) additionalProperty1, (string, JsonSchema.SchemaOrReference) additionalProperty2, (string, JsonSchema.SchemaOrReference) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<JsonSchema.SchemaOrReference>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public SchemaProperties((string, JsonSchema.SchemaOrReference) additionalProperty1, (string, JsonSchema.SchemaOrReference) additionalProperty2, (string, JsonSchema.SchemaOrReference) additionalProperty3, (string, JsonSchema.SchemaOrReference) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<JsonSchema.SchemaOrReference>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private SchemaProperties(Menes.JsonProperties<JsonSchema.SchemaOrReference>? additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public JsonSchema.SchemaProperties? AsOptional => this.IsNull ? default(JsonSchema.SchemaProperties?) : this;
            public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
            public int JsonAdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonProperties<JsonSchema.SchemaOrReference>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    int count = 0;

                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    return count;
                }
            }
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public Menes.JsonProperties<JsonSchema.SchemaOrReference>.JsonPropertyEnumerator JsonAdditionalProperties
            {
                get
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<JsonSchema.SchemaOrReference> ap)
                    {
                        return new Menes.JsonProperties<JsonSchema.SchemaOrReference>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<JsonSchema.SchemaOrReference>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<JsonSchema.SchemaOrReference>.JsonPropertyEnumerator(Menes.JsonProperties<JsonSchema.SchemaOrReference>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static JsonSchema.SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new JsonSchema.SchemaProperties(property)
                        : Null)
                    : Null;
            public static JsonSchema.SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new JsonSchema.SchemaProperties(property)
                        : Null)
                    : Null;
            public static JsonSchema.SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new JsonSchema.SchemaProperties(property)
                        : Null)
                : Null;
            public JsonSchema.SchemaProperties WithAdditionalProperties(Menes.JsonProperties<JsonSchema.SchemaOrReference> newAdditional)
            {
                return new JsonSchema.SchemaProperties(newAdditional);
            }
            public JsonSchema.SchemaProperties WithAdditionalProperties(params (string, JsonSchema.SchemaOrReference)[] newAdditional)
            {
                return new JsonSchema.SchemaProperties(Menes.JsonProperties<JsonSchema.SchemaOrReference>.FromValues(newAdditional));
            }
            public JsonSchema.SchemaProperties WithAdditionalProperties((string, JsonSchema.SchemaOrReference) newAdditional1)
            {
                return new JsonSchema.SchemaProperties(Menes.JsonProperties<JsonSchema.SchemaOrReference>.FromValues(newAdditional1));
            }
            public JsonSchema.SchemaProperties WithAdditionalProperties((string, JsonSchema.SchemaOrReference) newAdditional1, (string, JsonSchema.SchemaOrReference) newAdditional2)
            {
                return new JsonSchema.SchemaProperties(Menes.JsonProperties<JsonSchema.SchemaOrReference>.FromValues(newAdditional1, newAdditional2));
            }
            public JsonSchema.SchemaProperties WithAdditionalProperties((string, JsonSchema.SchemaOrReference) newAdditional1, (string, JsonSchema.SchemaOrReference) newAdditional2, (string, JsonSchema.SchemaOrReference) newAdditional3)
            {
                return new JsonSchema.SchemaProperties(Menes.JsonProperties<JsonSchema.SchemaOrReference>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public JsonSchema.SchemaProperties WithAdditionalProperties((string, JsonSchema.SchemaOrReference) newAdditional1, (string, JsonSchema.SchemaOrReference) newAdditional2, (string, JsonSchema.SchemaOrReference) newAdditional3, (string, JsonSchema.SchemaOrReference) newAdditional4)
            {
                return new JsonSchema.SchemaProperties(Menes.JsonProperties<JsonSchema.SchemaOrReference>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else
                {
                    writer.WriteStartObject();
                    Menes.JsonProperties<JsonSchema.SchemaOrReference>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(JsonSchema.SchemaProperties other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.ValidationContext context = validationContext;
                foreach (Menes.JsonPropertyReference<JsonSchema.SchemaOrReference> property in this.JsonAdditionalProperties)
                {
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
                return context;
            }
            public bool TryGetAdditionalProperty(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JsonSchema.SchemaOrReference? value)
            {
                return this.TryGetAdditionalProperty(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGetAdditionalProperty(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JsonSchema.SchemaOrReference? value)
            {
                foreach (Menes.JsonPropertyReference<JsonSchema.SchemaOrReference> property in this.JsonAdditionalProperties)
                {
                    if (property.NameEquals(utf8PropertyName))
                    {
                        value = property.AsValue();
                        return true;
                    }
                }
                value = default;
                return false;
            }
            public bool TryGetAdditionalProperty(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JsonSchema.SchemaOrReference? value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGetAdditionalProperty(bytes.Slice(0, written), out value);
            }
            public override string? ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonProperties<JsonSchema.SchemaOrReference> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<JsonSchema.SchemaOrReference> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<JsonSchema.SchemaOrReference>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }

        public readonly struct SchemaAdditionalProperties : Menes.IJsonValue
        {
            public static readonly SchemaAdditionalProperties Null = new SchemaAdditionalProperties(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema.SchemaAdditionalProperties> FromJsonElement = e => new JsonSchema.SchemaAdditionalProperties(e);
            private readonly Menes.JsonReference? item1;
            private readonly Menes.JsonBoolean? item2;
            public SchemaAdditionalProperties(JsonSchema.SchemaOrReference clrInstance)
            {
                if (clrInstance.HasJsonElement)
                {
                    this.JsonElement = clrInstance.JsonElement;
                    this.item1 = null;
                }
                else
                {
                    this.item1 = Menes.JsonReference.FromValue(clrInstance);
                    this.JsonElement = default;
                }
                this.item2 = null;
            }
            public SchemaAdditionalProperties(Menes.JsonBoolean clrInstance)
            {
                if (clrInstance.HasJsonElement)
                {
                    this.JsonElement = clrInstance.JsonElement;
                    this.item2 = null;
                }
                else
                {
                    this.item2 = clrInstance;
                    this.JsonElement = default;
                }
                this.item1 = null;
            }
            public SchemaAdditionalProperties(System.Text.Json.JsonElement jsonElement)
            {
                this.item1 = null;
                this.item2 = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public SchemaAdditionalProperties? AsOptional => this.IsNull ? default(SchemaAdditionalProperties?) : this;
            public bool IsSchemaOrReference => this.item1 is Menes.JsonReference || (JsonSchema.SchemaOrReference.IsConvertibleFrom(this.JsonElement) && JsonSchema.SchemaOrReference.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool IsJsonBoolean => this.item2 is Menes.JsonBoolean || (Menes.JsonBoolean.IsConvertibleFrom(this.JsonElement) && Menes.JsonBoolean.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator JsonSchema.SchemaOrReference(SchemaAdditionalProperties value) => value.AsSchemaOrReference();
            public static implicit operator SchemaAdditionalProperties(JsonSchema.SchemaOrReference value) => new SchemaAdditionalProperties(value);
            public static explicit operator Menes.JsonBoolean(SchemaAdditionalProperties value) => value.AsJsonBoolean();
            public static implicit operator SchemaAdditionalProperties(Menes.JsonBoolean value) => new SchemaAdditionalProperties(value);
            public static SchemaAdditionalProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaAdditionalProperties(property)
                        : Null)
                    : Null;
            public static SchemaAdditionalProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaAdditionalProperties(property)
                        : Null)
                    : Null;
            public static SchemaAdditionalProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaAdditionalProperties(property)
                        : Null)
                    : Null;
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                if (JsonSchema.SchemaOrReference.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                if (Menes.JsonBoolean.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                return false;
            }
            public JsonSchema.SchemaOrReference AsSchemaOrReference() => this.item1?.AsValue<JsonSchema.SchemaOrReference>() ?? new JsonSchema.SchemaOrReference(this.JsonElement);
            public Menes.JsonBoolean AsJsonBoolean() => this.item2 ?? new Menes.JsonBoolean(this.JsonElement);
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.item1 is Menes.JsonReference item1)
                {
                    item1.WriteTo(writer);
                }
                else if (this.item2 is Menes.JsonBoolean item2)
                {
                    item2.WriteTo(writer);
                }
                else
                {
                    this.JsonElement.WriteTo(writer);
                }
            }
            public override string? ToString()
            {
                var builder = new System.Text.StringBuilder();
                if (this.IsSchemaOrReference)
                {
                    builder.Append("{");
                    builder.Append("SchemaOrReference");
                    builder.Append(", ");
                    builder.Append(this.AsSchemaOrReference().ToString());
                    builder.AppendLine("}");
                }
                if (this.IsJsonBoolean)
                {
                    builder.Append("{");
                    builder.Append("JsonBoolean");
                    builder.Append(", ");
                    builder.Append(this.AsJsonBoolean().ToString());
                    builder.AppendLine("}");
                }
                return builder.Length > 0 ? builder.ToString() : this.JsonElement.ToString();
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                if (this.IsNull)
                {
                    return validationContext;
                }
                Menes.ValidationContext validationContext1 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
                Menes.ValidationContext validationContext2 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
                if (this.IsSchemaOrReference)
                {
                    validationContext1 = this.AsSchemaOrReference().Validate(validationContext1);
                }
                else
                {
                    validationContext1 = validationContext1.WithError("The value is not convertible to a JsonSchema.SchemaOrReference.");
                }
                if (this.IsJsonBoolean)
                {
                    validationContext2 = this.AsJsonBoolean().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a Menes.JsonBoolean.");
                }
                return Menes.Validation.ValidateOneOf(validationContext, ("JsonSchema.SchemaOrReference", validationContext1), ("Menes.JsonBoolean", validationContext2));
            }
        }
    }
}