// <copyright file="JsonSchema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable

namespace Menes.Json.Schema
{
    public readonly struct JsonSchema : Menes.IJsonObject, System.IEquatable<JsonSchema>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly JsonSchema Null = new JsonSchema(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema> FromJsonElement = e => new JsonSchema(e);
        private const string RefPropertyNamePath = ".$ref";
        private const string DefsPropertyNamePath = ".$defs";
        private const string IdPropertyNamePath = ".$id";
        private const string AnchorPropertyNamePath = ".$anchor";
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
        private const string AdditionalItemsPropertyNamePath = ".additionalItems";
        private const string ContainsPropertyNamePath = ".contains";
        private const string MaxPropertiesPropertyNamePath = ".maxProperties";
        private const string MinPropertiesPropertyNamePath = ".minProperties";
        private const string RequiredPropertyNamePath = ".required";
        private const string PropertiesPropertyNamePath = ".properties";
        private const string AdditionalPropertiesPropertyNamePath = ".additionalProperties";
        private const string PatternPropertiesPropertyNamePath = ".patternProperties";
        private const string PropertyNamesPropertyNamePath = ".propertyNames";
        private static readonly System.ReadOnlyMemory<byte> RefPropertyNameBytes = new byte[] { 36, 114, 101, 102 };
        private static readonly System.ReadOnlyMemory<byte> DefsPropertyNameBytes = new byte[] { 36, 100, 101, 102, 115 };
        private static readonly System.ReadOnlyMemory<byte> IdPropertyNameBytes = new byte[] { 36, 105, 100 };
        private static readonly System.ReadOnlyMemory<byte> AnchorPropertyNameBytes = new byte[] { 36, 97, 110, 99, 104, 111, 114 };
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
        private static readonly System.ReadOnlyMemory<byte> AdditionalItemsPropertyNameBytes = new byte[] { 97, 100, 100, 105, 116, 105, 111, 110, 97, 108, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> ContainsPropertyNameBytes = new byte[] { 99, 111, 110, 116, 97, 105, 110, 115 };
        private static readonly System.ReadOnlyMemory<byte> MaxPropertiesPropertyNameBytes = new byte[] { 109, 97, 120, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> MinPropertiesPropertyNameBytes = new byte[] { 109, 105, 110, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> RequiredPropertyNameBytes = new byte[] { 114, 101, 113, 117, 105, 114, 101, 100 };
        private static readonly System.ReadOnlyMemory<byte> PropertiesPropertyNameBytes = new byte[] { 112, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> AdditionalPropertiesPropertyNameBytes = new byte[] { 97, 100, 100, 105, 116, 105, 111, 110, 97, 108, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> PatternPropertiesPropertyNameBytes = new byte[] { 112, 97, 116, 116, 101, 114, 110, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> PropertyNamesPropertyNameBytes = new byte[] { 112, 114, 111, 112, 101, 114, 116, 121, 78, 97, 109, 101, 115 };
        private static readonly System.Text.Json.JsonEncodedText EncodedRefPropertyName = System.Text.Json.JsonEncodedText.Encode(RefPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedDefsPropertyName = System.Text.Json.JsonEncodedText.Encode(DefsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedIdPropertyName = System.Text.Json.JsonEncodedText.Encode(IdPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedAnchorPropertyName = System.Text.Json.JsonEncodedText.Encode(AnchorPropertyNameBytes.Span);
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
        private static readonly System.Text.Json.JsonEncodedText EncodedAdditionalItemsPropertyName = System.Text.Json.JsonEncodedText.Encode(AdditionalItemsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedContainsPropertyName = System.Text.Json.JsonEncodedText.Encode(ContainsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaxPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(MaxPropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMinPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(MinPropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedRequiredPropertyName = System.Text.Json.JsonEncodedText.Encode(RequiredPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(PropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedAdditionalPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(AdditionalPropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedPatternPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(PatternPropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedPropertyNamesPropertyName = System.Text.Json.JsonEncodedText.Encode(PropertyNamesPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(RefPropertyNameBytes, DefsPropertyNameBytes, IdPropertyNameBytes, AnchorPropertyNameBytes, SchemaPropertyNameBytes, TitlePropertyNameBytes, DescriptionPropertyNameBytes, CommentPropertyNameBytes, TypePropertyNameBytes, FormatPropertyNameBytes, EnumPropertyNameBytes, ConstPropertyNameBytes, AllOfPropertyNameBytes, AnyOfPropertyNameBytes, OneOfPropertyNameBytes, NotPropertyNameBytes, IfPropertyNameBytes, ThenPropertyNameBytes, ElsePropertyNameBytes, DependentSchemasPropertyNameBytes, MultipleOfPropertyNameBytes, MaximumPropertyNameBytes, ExclusiveMaximumPropertyNameBytes, MinimumPropertyNameBytes, ExclusiveMinimumPropertyNameBytes, MaxLengthPropertyNameBytes, MinLengthPropertyNameBytes, PatternPropertyNameBytes, MaxItemsPropertyNameBytes, MinItemsPropertyNameBytes, UniqueItemsPropertyNameBytes, MaxContainsPropertyNameBytes, MinContainsPropertyNameBytes, ItemsPropertyNameBytes, AdditionalItemsPropertyNameBytes, ContainsPropertyNameBytes, MaxPropertiesPropertyNameBytes, MinPropertiesPropertyNameBytes, RequiredPropertyNameBytes, PropertiesPropertyNameBytes, AdditionalPropertiesPropertyNameBytes, PatternPropertiesPropertyNameBytes, PropertyNamesPropertyNameBytes);
        private readonly Menes.JsonString? @ref;
        private readonly Menes.JsonAny? defs;
        private readonly Menes.JsonString? id;
        private readonly Menes.JsonString? anchor;
        private readonly Menes.JsonString? schema;
        private readonly Menes.JsonString? title;
        private readonly Menes.JsonString? description;
        private readonly Menes.JsonString? comment;
        private readonly JsonSchema.TypeEnumOrArrayOfTypeEnum? type;
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
        private readonly Menes.JsonReference? additionalItems;
        private readonly Menes.JsonReference? contains;
        private readonly JsonSchema.NonNegativeInteger? maxProperties;
        private readonly JsonSchema.NonNegativeInteger? minProperties;
        private readonly JsonSchema.UniqueStringArray? required;
        private readonly Menes.JsonReference? properties;
        private readonly Menes.JsonReference? additionalProperties;
        private readonly Menes.JsonReference? patternProperties;
        private readonly Menes.JsonReference? propertyNames;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public JsonSchema(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.@ref = null;
            this.defs = null;
            this.id = null;
            this.anchor = null;
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
            this.additionalItems = null;
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
        public JsonSchema(Menes.JsonString? @ref, Menes.JsonAny? defs, Menes.JsonString? id, Menes.JsonString? anchor, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnumOrArrayOfTypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.NonEmptySubschemaArray? allOf, JsonSchema.NonEmptySubschemaArray? anyOf, JsonSchema.NonEmptySubschemaArray? oneOf, JsonSchema? not, JsonSchema? @if, JsonSchema? then, JsonSchema? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaItems? items, JsonSchema.SchemaAdditionalItems? additionalItems, JsonSchema? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.UniqueStringArray? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema? propertyNames, Menes.JsonProperties<Menes.JsonAny> additionalPropertiesBacking)
        {
            this.@ref = @ref;
            this.defs = defs;
            this.id = id;
            this.anchor = anchor;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.NonEmptySubschemaArray item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.NonEmptySubschemaArray item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.NonEmptySubschemaArray item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema item7)
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
            if (items is JsonSchema.SchemaItems item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (additionalItems is JsonSchema.SchemaAdditionalItems item10)
            {
                this.additionalItems = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.additionalItems = null;
            }
            if (contains is JsonSchema item11)
            {
                this.contains = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            this.required = required;
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
            if (propertyNames is JsonSchema item15)
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
        public JsonSchema(Menes.JsonString? @ref, Menes.JsonAny? defs, Menes.JsonString? id, Menes.JsonString? anchor, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnumOrArrayOfTypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.NonEmptySubschemaArray? allOf, JsonSchema.NonEmptySubschemaArray? anyOf, JsonSchema.NonEmptySubschemaArray? oneOf, JsonSchema? not, JsonSchema? @if, JsonSchema? then, JsonSchema? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaItems? items, JsonSchema.SchemaAdditionalItems? additionalItems, JsonSchema? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.UniqueStringArray? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema? propertyNames, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.@ref = @ref;
            this.defs = defs;
            this.id = id;
            this.anchor = anchor;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.NonEmptySubschemaArray item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.NonEmptySubschemaArray item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.NonEmptySubschemaArray item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema item7)
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
            if (items is JsonSchema.SchemaItems item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (additionalItems is JsonSchema.SchemaAdditionalItems item10)
            {
                this.additionalItems = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.additionalItems = null;
            }
            if (contains is JsonSchema item11)
            {
                this.contains = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            this.required = required;
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
            if (propertyNames is JsonSchema item15)
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
        public JsonSchema(Menes.JsonString? @ref = null, Menes.JsonAny? defs = null, Menes.JsonString? id = null, Menes.JsonString? anchor = null, Menes.JsonString? schema = null, Menes.JsonString? title = null, Menes.JsonString? description = null, Menes.JsonString? comment = null, JsonSchema.TypeEnumOrArrayOfTypeEnum? type = null, Menes.JsonString? format = null, Menes.JsonArray<Menes.JsonAny>? @enum = null, Menes.JsonAny? @const = null, JsonSchema.NonEmptySubschemaArray? allOf = null, JsonSchema.NonEmptySubschemaArray? anyOf = null, JsonSchema.NonEmptySubschemaArray? oneOf = null, JsonSchema? not = null, JsonSchema? @if = null, JsonSchema? then = null, JsonSchema? @else = null, JsonSchema.SchemaProperties? dependentSchemas = null, JsonSchema.PositiveNumber? multipleOf = null, Menes.JsonNumber? maximum = null, Menes.JsonNumber? exclusiveMaximum = null, Menes.JsonNumber? minimum = null, Menes.JsonNumber? exclusiveMinimum = null, JsonSchema.NonNegativeInteger? maxLength = null, JsonSchema.NonNegativeInteger? minLength = null, Menes.JsonString? pattern = null, JsonSchema.NonNegativeInteger? maxItems = null, JsonSchema.NonNegativeInteger? minItems = null, Menes.JsonBoolean? uniqueItems = null, JsonSchema.NonNegativeInteger? maxContains = null, JsonSchema.NonNegativeInteger? minContains = null, JsonSchema.SchemaItems? items = null, JsonSchema.SchemaAdditionalItems? additionalItems = null, JsonSchema? contains = null, JsonSchema.NonNegativeInteger? maxProperties = null, JsonSchema.NonNegativeInteger? minProperties = null, JsonSchema.UniqueStringArray? required = null, JsonSchema.SchemaProperties? properties = null, JsonSchema.SchemaAdditionalProperties? additionalProperties = null, JsonSchema.SchemaProperties? patternProperties = null, JsonSchema? propertyNames = null)
        {
            this.@ref = @ref;
            this.defs = defs;
            this.id = id;
            this.anchor = anchor;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.NonEmptySubschemaArray item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.NonEmptySubschemaArray item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.NonEmptySubschemaArray item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema item7)
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
            if (items is JsonSchema.SchemaItems item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (additionalItems is JsonSchema.SchemaAdditionalItems item10)
            {
                this.additionalItems = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.additionalItems = null;
            }
            if (contains is JsonSchema item11)
            {
                this.contains = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            this.required = required;
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
            if (propertyNames is JsonSchema item15)
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
        public JsonSchema(Menes.JsonString? @ref, Menes.JsonAny? defs, Menes.JsonString? id, Menes.JsonString? anchor, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnumOrArrayOfTypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.NonEmptySubschemaArray? allOf, JsonSchema.NonEmptySubschemaArray? anyOf, JsonSchema.NonEmptySubschemaArray? oneOf, JsonSchema? not, JsonSchema? @if, JsonSchema? then, JsonSchema? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaItems? items, JsonSchema.SchemaAdditionalItems? additionalItems, JsonSchema? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.UniqueStringArray? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema? propertyNames, (string, Menes.JsonAny) additionalProperty1)
        {
            this.@ref = @ref;
            this.defs = defs;
            this.id = id;
            this.anchor = anchor;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.NonEmptySubschemaArray item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.NonEmptySubschemaArray item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.NonEmptySubschemaArray item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema item7)
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
            if (items is JsonSchema.SchemaItems item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (additionalItems is JsonSchema.SchemaAdditionalItems item10)
            {
                this.additionalItems = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.additionalItems = null;
            }
            if (contains is JsonSchema item11)
            {
                this.contains = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            this.required = required;
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
            if (propertyNames is JsonSchema item15)
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
        public JsonSchema(Menes.JsonString? @ref, Menes.JsonAny? defs, Menes.JsonString? id, Menes.JsonString? anchor, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnumOrArrayOfTypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.NonEmptySubschemaArray? allOf, JsonSchema.NonEmptySubschemaArray? anyOf, JsonSchema.NonEmptySubschemaArray? oneOf, JsonSchema? not, JsonSchema? @if, JsonSchema? then, JsonSchema? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaItems? items, JsonSchema.SchemaAdditionalItems? additionalItems, JsonSchema? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.UniqueStringArray? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema? propertyNames, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.@ref = @ref;
            this.defs = defs;
            this.id = id;
            this.anchor = anchor;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.NonEmptySubschemaArray item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.NonEmptySubschemaArray item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.NonEmptySubschemaArray item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema item7)
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
            if (items is JsonSchema.SchemaItems item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (additionalItems is JsonSchema.SchemaAdditionalItems item10)
            {
                this.additionalItems = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.additionalItems = null;
            }
            if (contains is JsonSchema item11)
            {
                this.contains = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            this.required = required;
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
            if (propertyNames is JsonSchema item15)
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
        public JsonSchema(Menes.JsonString? @ref, Menes.JsonAny? defs, Menes.JsonString? id, Menes.JsonString? anchor, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnumOrArrayOfTypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.NonEmptySubschemaArray? allOf, JsonSchema.NonEmptySubschemaArray? anyOf, JsonSchema.NonEmptySubschemaArray? oneOf, JsonSchema? not, JsonSchema? @if, JsonSchema? then, JsonSchema? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaItems? items, JsonSchema.SchemaAdditionalItems? additionalItems, JsonSchema? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.UniqueStringArray? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema? propertyNames, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.@ref = @ref;
            this.defs = defs;
            this.id = id;
            this.anchor = anchor;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.NonEmptySubschemaArray item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.NonEmptySubschemaArray item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.NonEmptySubschemaArray item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema item7)
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
            if (items is JsonSchema.SchemaItems item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (additionalItems is JsonSchema.SchemaAdditionalItems item10)
            {
                this.additionalItems = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.additionalItems = null;
            }
            if (contains is JsonSchema item11)
            {
                this.contains = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            this.required = required;
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
            if (propertyNames is JsonSchema item15)
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
        public JsonSchema(Menes.JsonString? @ref, Menes.JsonAny? defs, Menes.JsonString? id, Menes.JsonString? anchor, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnumOrArrayOfTypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, JsonSchema.NonEmptySubschemaArray? allOf, JsonSchema.NonEmptySubschemaArray? anyOf, JsonSchema.NonEmptySubschemaArray? oneOf, JsonSchema? not, JsonSchema? @if, JsonSchema? then, JsonSchema? @else, JsonSchema.SchemaProperties? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, JsonSchema.SchemaItems? items, JsonSchema.SchemaAdditionalItems? additionalItems, JsonSchema? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.UniqueStringArray? required, JsonSchema.SchemaProperties? properties, JsonSchema.SchemaAdditionalProperties? additionalProperties, JsonSchema.SchemaProperties? patternProperties, JsonSchema? propertyNames, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.@ref = @ref;
            this.defs = defs;
            this.id = id;
            this.anchor = anchor;
            this.schema = schema;
            this.title = title;
            this.description = description;
            this.comment = comment;
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allOf is JsonSchema.NonEmptySubschemaArray item1)
            {
                this.allOf = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allOf = null;
            }
            if (anyOf is JsonSchema.NonEmptySubschemaArray item2)
            {
                this.anyOf = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyOf = null;
            }
            if (oneOf is JsonSchema.NonEmptySubschemaArray item3)
            {
                this.oneOf = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneOf = null;
            }
            if (not is JsonSchema item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            if (@if is JsonSchema item5)
            {
                this.@if = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.@if = null;
            }
            if (then is JsonSchema item6)
            {
                this.then = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.then = null;
            }
            if (@else is JsonSchema item7)
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
            if (items is JsonSchema.SchemaItems item9)
            {
                this.items = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.items = null;
            }
            if (additionalItems is JsonSchema.SchemaAdditionalItems item10)
            {
                this.additionalItems = Menes.JsonReference.FromValue(item10);
            }
            else
            {
                this.additionalItems = null;
            }
            if (contains is JsonSchema item11)
            {
                this.contains = Menes.JsonReference.FromValue(item11);
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            this.required = required;
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
            if (propertyNames is JsonSchema item15)
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
        private JsonSchema(Menes.JsonString? @ref, Menes.JsonAny? defs, Menes.JsonString? id, Menes.JsonString? anchor, Menes.JsonString? schema, Menes.JsonString? title, Menes.JsonString? description, Menes.JsonString? comment, JsonSchema.TypeEnumOrArrayOfTypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Menes.JsonReference? allOf, Menes.JsonReference? anyOf, Menes.JsonReference? oneOf, Menes.JsonReference? not, Menes.JsonReference? @if, Menes.JsonReference? then, Menes.JsonReference? @else, Menes.JsonReference? dependentSchemas, JsonSchema.PositiveNumber? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, JsonSchema.NonNegativeInteger? maxLength, JsonSchema.NonNegativeInteger? minLength, Menes.JsonString? pattern, JsonSchema.NonNegativeInteger? maxItems, JsonSchema.NonNegativeInteger? minItems, Menes.JsonBoolean? uniqueItems, JsonSchema.NonNegativeInteger? maxContains, JsonSchema.NonNegativeInteger? minContains, Menes.JsonReference? items, Menes.JsonReference? additionalItems, Menes.JsonReference? contains, JsonSchema.NonNegativeInteger? maxProperties, JsonSchema.NonNegativeInteger? minProperties, JsonSchema.UniqueStringArray? required, Menes.JsonReference? properties, Menes.JsonReference? additionalProperties, Menes.JsonReference? patternProperties, Menes.JsonReference? propertyNames, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.@ref = @ref;
            this.defs = defs;
            this.id = id;
            this.anchor = anchor;
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
            if (additionalItems is Menes.JsonReference item10)
            {
                this.additionalItems = item10;
            }
            else
            {
                this.additionalItems = null;
            }
            if (contains is Menes.JsonReference item11)
            {
                this.contains = item11;
            }
            else
            {
                this.contains = null;
            }
            this.maxProperties = maxProperties;
            this.minProperties = minProperties;
            this.required = required;
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
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.@ref is null || this.@ref.Value.IsNull) && (this.defs is null || this.defs.Value.IsNull) && (this.id is null || this.id.Value.IsNull) && (this.anchor is null || this.anchor.Value.IsNull) && (this.schema is null || this.schema.Value.IsNull) && (this.title is null || this.title.Value.IsNull) && (this.description is null || this.description.Value.IsNull) && (this.comment is null || this.comment.Value.IsNull) && (this.type is null || this.type.Value.IsNull) && (this.format is null || this.format.Value.IsNull) && (this.@enum is null || this.@enum.Value.IsNull) && (this.@const is null || this.@const.Value.IsNull) && (this.allOf is null || this.allOf.Value.IsNull) && (this.anyOf is null || this.anyOf.Value.IsNull) && (this.oneOf is null || this.oneOf.Value.IsNull) && (this.not is null || this.not.Value.IsNull) && (this.@if is null || this.@if.Value.IsNull) && (this.then is null || this.then.Value.IsNull) && (this.@else is null || this.@else.Value.IsNull) && (this.dependentSchemas is null || this.dependentSchemas.Value.IsNull) && (this.multipleOf is null || this.multipleOf.Value.IsNull) && (this.maximum is null || this.maximum.Value.IsNull) && (this.exclusiveMaximum is null || this.exclusiveMaximum.Value.IsNull) && (this.minimum is null || this.minimum.Value.IsNull) && (this.exclusiveMinimum is null || this.exclusiveMinimum.Value.IsNull) && (this.maxLength is null || this.maxLength.Value.IsNull) && (this.minLength is null || this.minLength.Value.IsNull) && (this.pattern is null || this.pattern.Value.IsNull) && (this.maxItems is null || this.maxItems.Value.IsNull) && (this.minItems is null || this.minItems.Value.IsNull) && (this.uniqueItems is null || this.uniqueItems.Value.IsNull) && (this.maxContains is null || this.maxContains.Value.IsNull) && (this.minContains is null || this.minContains.Value.IsNull) && (this.items is null || this.items.Value.IsNull) && (this.additionalItems is null || this.additionalItems.Value.IsNull) && (this.contains is null || this.contains.Value.IsNull) && (this.maxProperties is null || this.maxProperties.Value.IsNull) && (this.minProperties is null || this.minProperties.Value.IsNull) && (this.required is null || this.required.Value.IsNull) && (this.properties is null || this.properties.Value.IsNull) && (this.additionalProperties is null || this.additionalProperties.Value.IsNull) && (this.patternProperties is null || this.patternProperties.Value.IsNull) && (this.propertyNames is null || this.propertyNames.Value.IsNull);
        public JsonSchema? AsOptional => this.IsNull ? default(JsonSchema?) : this;
        public Menes.JsonString? Ref => this.@ref ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, RefPropertyNameBytes.Span).AsOptional;
        public Menes.JsonAny? Defs => this.defs ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, DefsPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Id => this.id ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, IdPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Anchor => this.anchor ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, AnchorPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Schema => this.schema ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, SchemaPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Title => this.title ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, TitlePropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Description => this.description ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, DescriptionPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Comment => this.comment ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, CommentPropertyNameBytes.Span).AsOptional;
        public JsonSchema.TypeEnumOrArrayOfTypeEnum? Type => this.type ?? JsonSchema.TypeEnumOrArrayOfTypeEnum.FromOptionalProperty(this.JsonElement, TypePropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Format => this.format ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, FormatPropertyNameBytes.Span).AsOptional;
        public Menes.JsonArray<Menes.JsonAny>? Enum => this.@enum ?? Menes.JsonArray<Menes.JsonAny>.FromOptionalProperty(this.JsonElement, EnumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonAny? Const => this.@const ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, ConstPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonEmptySubschemaArray? AllOf => this.allOf?.AsValue<JsonSchema.NonEmptySubschemaArray>() ?? JsonSchema.NonEmptySubschemaArray.FromOptionalProperty(this.JsonElement, AllOfPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonEmptySubschemaArray? AnyOf => this.anyOf?.AsValue<JsonSchema.NonEmptySubschemaArray>() ?? JsonSchema.NonEmptySubschemaArray.FromOptionalProperty(this.JsonElement, AnyOfPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonEmptySubschemaArray? OneOf => this.oneOf?.AsValue<JsonSchema.NonEmptySubschemaArray>() ?? JsonSchema.NonEmptySubschemaArray.FromOptionalProperty(this.JsonElement, OneOfPropertyNameBytes.Span).AsOptional;
        public JsonSchema? Not => this.not?.AsValue<JsonSchema>() ?? JsonSchema.FromOptionalProperty(this.JsonElement, NotPropertyNameBytes.Span).AsOptional;
        public JsonSchema? If => this.@if?.AsValue<JsonSchema>() ?? JsonSchema.FromOptionalProperty(this.JsonElement, IfPropertyNameBytes.Span).AsOptional;
        public JsonSchema? Then => this.then?.AsValue<JsonSchema>() ?? JsonSchema.FromOptionalProperty(this.JsonElement, ThenPropertyNameBytes.Span).AsOptional;
        public JsonSchema? Else => this.@else?.AsValue<JsonSchema>() ?? JsonSchema.FromOptionalProperty(this.JsonElement, ElsePropertyNameBytes.Span).AsOptional;
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
        public JsonSchema.SchemaItems? Items => this.items?.AsValue<JsonSchema.SchemaItems>() ?? JsonSchema.SchemaItems.FromOptionalProperty(this.JsonElement, ItemsPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaAdditionalItems? AdditionalItems => this.additionalItems?.AsValue<JsonSchema.SchemaAdditionalItems>() ?? JsonSchema.SchemaAdditionalItems.FromOptionalProperty(this.JsonElement, AdditionalItemsPropertyNameBytes.Span).AsOptional;
        public JsonSchema? Contains => this.contains?.AsValue<JsonSchema>() ?? JsonSchema.FromOptionalProperty(this.JsonElement, ContainsPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonNegativeInteger? MaxProperties => this.maxProperties ?? JsonSchema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxPropertiesPropertyNameBytes.Span).AsOptional;
        public JsonSchema.NonNegativeInteger? MinProperties => this.minProperties ?? JsonSchema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinPropertiesPropertyNameBytes.Span).AsOptional;
        public JsonSchema.UniqueStringArray? Required => this.required ?? JsonSchema.UniqueStringArray.FromOptionalProperty(this.JsonElement, RequiredPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaProperties? Properties => this.properties?.AsValue<JsonSchema.SchemaProperties>() ?? JsonSchema.SchemaProperties.FromOptionalProperty(this.JsonElement, PropertiesPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaAdditionalProperties? AdditionalProperties => this.additionalProperties?.AsValue<JsonSchema.SchemaAdditionalProperties>() ?? JsonSchema.SchemaAdditionalProperties.FromOptionalProperty(this.JsonElement, AdditionalPropertiesPropertyNameBytes.Span).AsOptional;
        public JsonSchema.SchemaProperties? PatternProperties => this.patternProperties?.AsValue<JsonSchema.SchemaProperties>() ?? JsonSchema.SchemaProperties.FromOptionalProperty(this.JsonElement, PatternPropertiesPropertyNameBytes.Span).AsOptional;
        public JsonSchema? PropertyNames => this.propertyNames?.AsValue<JsonSchema>() ?? JsonSchema.FromOptionalProperty(this.JsonElement, PropertyNamesPropertyNameBytes.Span).AsOptional;
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
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new JsonSchema(property)
                    : Null)
                : Null;
        public static JsonSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new JsonSchema(property)
                    : Null)
                : Null;
        public static JsonSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new JsonSchema(property)
                    : Null)
            : Null;
        public JsonSchema WithRef(Menes.JsonString? value)
        {
            return new JsonSchema(value, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithDefs(Menes.JsonAny? value)
        {
            return new JsonSchema(this.Ref, value, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithId(Menes.JsonString? value)
        {
            return new JsonSchema(this.Ref, this.Defs, value, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithAnchor(Menes.JsonString? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, value, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithSchema(Menes.JsonString? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, value, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithTitle(Menes.JsonString? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, value, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithDescription(Menes.JsonString? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, value, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithComment(Menes.JsonString? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, value, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithType(JsonSchema.TypeEnumOrArrayOfTypeEnum? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, value, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithFormat(Menes.JsonString? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, value, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithEnum(Menes.JsonArray<Menes.JsonAny>? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, value, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithConst(Menes.JsonAny? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, value, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithAllOf(JsonSchema.NonEmptySubschemaArray? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, Menes.JsonReference.FromValue(value), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithAnyOf(JsonSchema.NonEmptySubschemaArray? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), Menes.JsonReference.FromValue(value), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithOneOf(JsonSchema.NonEmptySubschemaArray? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), Menes.JsonReference.FromValue(value), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithNot(JsonSchema? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), Menes.JsonReference.FromValue(value), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithIf(JsonSchema? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), Menes.JsonReference.FromValue(value), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithThen(JsonSchema? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), Menes.JsonReference.FromValue(value), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithElse(JsonSchema? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), Menes.JsonReference.FromValue(value), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithDependentSchemas(JsonSchema.SchemaProperties? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), Menes.JsonReference.FromValue(value), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMultipleOf(JsonSchema.PositiveNumber? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), value, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMaximum(Menes.JsonNumber? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, value, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithExclusiveMaximum(Menes.JsonNumber? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, value, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMinimum(Menes.JsonNumber? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, value, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithExclusiveMinimum(Menes.JsonNumber? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, value, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMaxLength(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, value, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMinLength(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, value, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithPattern(Menes.JsonString? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, value, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMaxItems(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, value, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMinItems(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, value, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithUniqueItems(Menes.JsonBoolean? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, value, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMaxContains(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, value, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMinContains(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, value, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithItems(JsonSchema.SchemaItems? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, Menes.JsonReference.FromValue(value), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithAdditionalItems(JsonSchema.SchemaAdditionalItems? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), Menes.JsonReference.FromValue(value), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithContains(JsonSchema? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), Menes.JsonReference.FromValue(value), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMaxProperties(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), value, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithMinProperties(JsonSchema.NonNegativeInteger? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, value, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithRequired(JsonSchema.UniqueStringArray? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, value, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithProperties(JsonSchema.SchemaProperties? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, Menes.JsonReference.FromValue(value), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithAdditionalProperties(JsonSchema.SchemaAdditionalProperties? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), Menes.JsonReference.FromValue(value), this.GetPatternProperties(), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithPatternProperties(JsonSchema.SchemaProperties? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), Menes.JsonReference.FromValue(value), this.GetPropertyNames(), this.GetJsonProperties());
        }
        public JsonSchema WithPropertyNames(JsonSchema? value)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), Menes.JsonReference.FromValue(value), this.GetJsonProperties());
        }
        public JsonSchema ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), newAdditional);
        }
        public JsonSchema ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public JsonSchema ReplaceAll((string, Menes.JsonAny) newAdditional1)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public JsonSchema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public JsonSchema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public JsonSchema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
        }
        public JsonSchema Add(params (string, Menes.JsonAny)[] newAdditional)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            foreach ((string name, Menes.JsonAny value) in newAdditional)
            {
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(name, value));
            }
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public JsonSchema Add((string name, Menes.JsonAny value) newAdditional1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public JsonSchema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public JsonSchema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public JsonSchema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public JsonSchema Remove(params string[] namesToRemove)
        {
            System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!ihs.Contains(property.Name))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public JsonSchema Remove(string itemToRemove1)
        {
            System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
            ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!ihs.Contains(property.Name))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public JsonSchema Remove(string itemToRemove1, string itemToRemove2)
        {
            System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
            ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!ihs.Contains(property.Name))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public JsonSchema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
        {
            System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
            ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!ihs.Contains(property.Name))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public JsonSchema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
        {
            System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
            ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!ihs.Contains(property.Name))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public JsonSchema Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!removeIfTrue(property))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new JsonSchema(this.Ref, this.Defs, this.Id, this.Anchor, this.Schema, this.Title, this.Description, this.Comment, this.Type, this.Format, this.Enum, this.Const, this.GetAllOf(), this.GetAnyOf(), this.GetOneOf(), this.GetNot(), this.GetIf(), this.GetThen(), this.GetElse(), this.GetDependentSchemas(), this.MultipleOf, this.Maximum, this.ExclusiveMaximum, this.Minimum, this.ExclusiveMinimum, this.MaxLength, this.MinLength, this.Pattern, this.MaxItems, this.MinItems, this.UniqueItems, this.MaxContains, this.MinContains, this.GetItems(), this.GetAdditionalItems(), this.GetContains(), this.MaxProperties, this.MinProperties, this.Required, this.GetProperties(), this.GetAdditionalProperties(), this.GetPatternProperties(), this.GetPropertyNames(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
                if (this.defs is Menes.JsonAny defs)
                {
                    writer.WritePropertyName(EncodedDefsPropertyName);
                    defs.WriteTo(writer);
                }
                if (this.id is Menes.JsonString id)
                {
                    writer.WritePropertyName(EncodedIdPropertyName);
                    id.WriteTo(writer);
                }
                if (this.anchor is Menes.JsonString anchor)
                {
                    writer.WritePropertyName(EncodedAnchorPropertyName);
                    anchor.WriteTo(writer);
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
                if (this.type is JsonSchema.TypeEnumOrArrayOfTypeEnum type)
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
                if (this.additionalItems is Menes.JsonReference additionalItems)
                {
                    writer.WritePropertyName(EncodedAdditionalItemsPropertyName);
                    additionalItems.WriteTo(writer);
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
                if (this.required is JsonSchema.UniqueStringArray required)
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
            return this.Ref.Equals(other.Ref) && this.Defs.Equals(other.Defs) && this.Id.Equals(other.Id) && this.Anchor.Equals(other.Anchor) && this.Schema.Equals(other.Schema) && this.Title.Equals(other.Title) && this.Description.Equals(other.Description) && this.Comment.Equals(other.Comment) && this.Type.Equals(other.Type) && this.Format.Equals(other.Format) && this.Enum.Equals(other.Enum) && this.Const.Equals(other.Const) && this.AllOf.Equals(other.AllOf) && this.AnyOf.Equals(other.AnyOf) && this.OneOf.Equals(other.OneOf) && this.Not.Equals(other.Not) && this.If.Equals(other.If) && this.Then.Equals(other.Then) && this.Else.Equals(other.Else) && this.DependentSchemas.Equals(other.DependentSchemas) && this.MultipleOf.Equals(other.MultipleOf) && this.Maximum.Equals(other.Maximum) && this.ExclusiveMaximum.Equals(other.ExclusiveMaximum) && this.Minimum.Equals(other.Minimum) && this.ExclusiveMinimum.Equals(other.ExclusiveMinimum) && this.MaxLength.Equals(other.MaxLength) && this.MinLength.Equals(other.MinLength) && this.Pattern.Equals(other.Pattern) && this.MaxItems.Equals(other.MaxItems) && this.MinItems.Equals(other.MinItems) && this.UniqueItems.Equals(other.UniqueItems) && this.MaxContains.Equals(other.MaxContains) && this.MinContains.Equals(other.MinContains) && this.Items.Equals(other.Items) && this.AdditionalItems.Equals(other.AdditionalItems) && this.Contains.Equals(other.Contains) && this.MaxProperties.Equals(other.MaxProperties) && this.MinProperties.Equals(other.MinProperties) && this.Required.Equals(other.Required) && this.Properties.Equals(other.Properties) && this.AdditionalProperties.Equals(other.AdditionalProperties) && this.PatternProperties.Equals(other.PatternProperties) && this.PropertyNames.Equals(other.PropertyNames) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            if (this.IsNull)
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
            }
            Menes.ValidationContext context = validationContext;
            if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
            {
                if (this.Ref is Menes.JsonString @ref)
                {
                    context = Menes.Validation.ValidateProperty(context, @ref, RefPropertyNamePath);
                }
                if (this.Defs is Menes.JsonAny defs)
                {
                    context = Menes.Validation.ValidateProperty(context, defs, DefsPropertyNamePath);
                }
                if (this.Id is Menes.JsonString id)
                {
                    context = Menes.Validation.ValidateProperty(context, id, IdPropertyNamePath);
                }
                if (this.Anchor is Menes.JsonString anchor)
                {
                    context = Menes.Validation.ValidateProperty(context, anchor, AnchorPropertyNamePath);
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
                if (this.Type is JsonSchema.TypeEnumOrArrayOfTypeEnum type)
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
                if (this.AllOf is JsonSchema.NonEmptySubschemaArray allOf)
                {
                    context = Menes.Validation.ValidateProperty(context, allOf, AllOfPropertyNamePath);
                }
                if (this.AnyOf is JsonSchema.NonEmptySubschemaArray anyOf)
                {
                    context = Menes.Validation.ValidateProperty(context, anyOf, AnyOfPropertyNamePath);
                }
                if (this.OneOf is JsonSchema.NonEmptySubschemaArray oneOf)
                {
                    context = Menes.Validation.ValidateProperty(context, oneOf, OneOfPropertyNamePath);
                }
                if (this.Not is JsonSchema not)
                {
                    context = Menes.Validation.ValidateProperty(context, not, NotPropertyNamePath);
                }
                if (this.If is JsonSchema @if)
                {
                    context = Menes.Validation.ValidateProperty(context, @if, IfPropertyNamePath);
                }
                if (this.Then is JsonSchema then)
                {
                    context = Menes.Validation.ValidateProperty(context, then, ThenPropertyNamePath);
                }
                if (this.Else is JsonSchema @else)
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
                if (this.Items is JsonSchema.SchemaItems items)
                {
                    context = Menes.Validation.ValidateProperty(context, items, ItemsPropertyNamePath);
                }
                if (this.AdditionalItems is JsonSchema.SchemaAdditionalItems additionalItems)
                {
                    context = Menes.Validation.ValidateProperty(context, additionalItems, AdditionalItemsPropertyNamePath);
                }
                if (this.Contains is JsonSchema contains)
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
                if (this.Required is JsonSchema.UniqueStringArray required)
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
                if (this.PropertyNames is JsonSchema propertyNames)
                {
                    context = Menes.Validation.ValidateProperty(context, propertyNames, PropertyNamesPropertyNamePath);
                }
                foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
                {
                    string propertyName = property.Name;
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
            }
            context = Menes.Validation.ValidateNot<JsonSchema, JsonSchema>(context, this);
            return context;
        }
        public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
        {
            return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
        }
        public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
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
        public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
        {
            System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
            int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
            return this.TryGet(bytes.Slice(0, written), out value);
        }
        public override string ToString()
        {
            return Menes.JsonAny.From(this).ToString();
        }
        private Menes.JsonReference? GetAllOf()
        {
            if (this.allOf is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(AllOfPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetAnyOf()
        {
            if (this.anyOf is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(AnyOfPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetOneOf()
        {
            if (this.oneOf is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(OneOfPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetNot()
        {
            if (this.not is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(NotPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetIf()
        {
            if (this.@if is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(IfPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetThen()
        {
            if (this.then is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(ThenPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetElse()
        {
            if (this.@else is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(ElsePropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetDependentSchemas()
        {
            if (this.dependentSchemas is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(DependentSchemasPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetItems()
        {
            if (this.items is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(ItemsPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetAdditionalItems()
        {
            if (this.additionalItems is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(AdditionalItemsPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetContains()
        {
            if (this.contains is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(ContainsPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetProperties()
        {
            if (this.properties is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(PropertiesPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetAdditionalProperties()
        {
            if (this.additionalProperties is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(AdditionalPropertiesPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetPatternProperties()
        {
            if (this.patternProperties is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(PatternPropertiesPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetPropertyNames()
        {
            if (this.propertyNames is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(PropertyNamesPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
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
        public readonly struct TypeEnum : Menes.IJsonValue, System.IEquatable<TypeEnum>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, TypeEnum> FromJsonElement = e => new TypeEnum(e);
            public static readonly TypeEnum Null = new TypeEnum(default(System.Text.Json.JsonElement));
            public static readonly System.Collections.Immutable.ImmutableArray<string> EnumValues = BuildEnumValues();
            public static readonly TypeEnum Null1 = new TypeEnum(EnumValues[0]);
            public static readonly TypeEnum Boolean = new TypeEnum(EnumValues[1]);
            public static readonly TypeEnum Object = new TypeEnum(EnumValues[2]);
            public static readonly TypeEnum Array = new TypeEnum(EnumValues[3]);
            public static readonly TypeEnum Number = new TypeEnum(EnumValues[4]);
            public static readonly TypeEnum String = new TypeEnum(EnumValues[5]);
            public static readonly TypeEnum Integer = new TypeEnum(EnumValues[6]);
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
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TypeEnum(property)
                        : Null)
                    : Null;
            public static TypeEnum FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TypeEnum(property)
                        : Null)
                    : Null;
            public static TypeEnum FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
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
                context = value.ValidateAsString(context, MaxLength, MinLength, Pattern, EnumValues, (string?)null);
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
            public override string ToString()
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
            private static System.Collections.Immutable.ImmutableArray<string> BuildEnumValues()
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
        public readonly struct TypeEnumOrArrayOfTypeEnum : Menes.IJsonValue
        {
            public static readonly TypeEnumOrArrayOfTypeEnum Null = new TypeEnumOrArrayOfTypeEnum(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema.TypeEnumOrArrayOfTypeEnum> FromJsonElement = e => new JsonSchema.TypeEnumOrArrayOfTypeEnum(e);
            private readonly JsonSchema.TypeEnum? item1;
            private readonly Menes.JsonArray<JsonSchema.TypeEnum>? item2;
            public TypeEnumOrArrayOfTypeEnum(JsonSchema.TypeEnum clrInstance)
            {
                if (clrInstance.HasJsonElement)
                {
                    this.JsonElement = clrInstance.JsonElement;
                    this.item1 = null;
                }
                else
                {
                    this.item1 = clrInstance;
                    this.JsonElement = default;
                }
                this.item2 = null;
            }
            public TypeEnumOrArrayOfTypeEnum(Menes.JsonArray<JsonSchema.TypeEnum> clrInstance)
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
            public TypeEnumOrArrayOfTypeEnum(System.Text.Json.JsonElement jsonElement)
            {
                this.item1 = null;
                this.item2 = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public TypeEnumOrArrayOfTypeEnum? AsOptional => this.IsNull ? default(TypeEnumOrArrayOfTypeEnum?) : this;
            public bool IsTypeEnum => this.item1 is JsonSchema.TypeEnum || (JsonSchema.TypeEnum.IsConvertibleFrom(this.JsonElement) && JsonSchema.TypeEnum.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool IsArrayOfTypeEnum => this.item2 is Menes.JsonArray<JsonSchema.TypeEnum> || (Menes.JsonArray<JsonSchema.TypeEnum>.IsConvertibleFrom(this.JsonElement) && Menes.JsonArray<JsonSchema.TypeEnum>.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator JsonSchema.TypeEnum(TypeEnumOrArrayOfTypeEnum value) => value.AsTypeEnum();
            public static implicit operator TypeEnumOrArrayOfTypeEnum(JsonSchema.TypeEnum value) => new TypeEnumOrArrayOfTypeEnum(value);
            public static explicit operator Menes.JsonArray<JsonSchema.TypeEnum>(TypeEnumOrArrayOfTypeEnum value) => value.AsArrayOfTypeEnum();
            public static implicit operator TypeEnumOrArrayOfTypeEnum(Menes.JsonArray<JsonSchema.TypeEnum> value) => new TypeEnumOrArrayOfTypeEnum(value);
            public static TypeEnumOrArrayOfTypeEnum FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TypeEnumOrArrayOfTypeEnum(property)
                        : Null)
                    : Null;
            public static TypeEnumOrArrayOfTypeEnum FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TypeEnumOrArrayOfTypeEnum(property)
                        : Null)
                    : Null;
            public static TypeEnumOrArrayOfTypeEnum FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new TypeEnumOrArrayOfTypeEnum(property)
                        : Null)
                    : Null;
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                if (JsonSchema.TypeEnum.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                if (Menes.JsonArray<JsonSchema.TypeEnum>.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                return false;
            }
            public JsonSchema.TypeEnum AsTypeEnum() => this.item1 ?? new JsonSchema.TypeEnum(this.JsonElement);
            public Menes.JsonArray<JsonSchema.TypeEnum> AsArrayOfTypeEnum() => this.item2 ?? new Menes.JsonArray<JsonSchema.TypeEnum>(this.JsonElement);
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.item1 is JsonSchema.TypeEnum item1)
                {
                    item1.WriteTo(writer);
                }
                else if (this.item2 is Menes.JsonArray<JsonSchema.TypeEnum> item2)
                {
                    item2.WriteTo(writer);
                }
                else
                {
                    this.JsonElement.WriteTo(writer);
                }
            }
            public override string ToString()
            {
                var builder = new System.Text.StringBuilder();
                if (this.IsTypeEnum)
                {
                    builder.Append("{");
                    builder.Append("TypeEnum");
                    builder.Append(", ");
                    builder.Append(this.AsTypeEnum().ToString());
                    builder.AppendLine("}");
                }
                if (this.IsArrayOfTypeEnum)
                {
                    builder.Append("{");
                    builder.Append("JsonArrayJsonSchemaTypeEnum");
                    builder.Append(", ");
                    builder.Append(this.AsArrayOfTypeEnum().ToString());
                    builder.AppendLine("}");
                }
                return builder.Length > 0 ? builder.ToString() : this.JsonElement.ToString();
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.ValidationContext validationContext1 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
                Menes.ValidationContext validationContext2 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
                if (this.IsTypeEnum)
                {
                    validationContext1 = this.AsTypeEnum().Validate(validationContext1);
                }
                else
                {
                    validationContext1 = validationContext1.WithError("The value is not convertible to a JsonSchema.TypeEnum.");
                }
                if (this.IsArrayOfTypeEnum)
                {
                    validationContext2 = this.AsArrayOfTypeEnum().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a Menes.JsonArray<JsonSchema.TypeEnum>.");
                }
                return Menes.Validation.ValidateOneOf(validationContext, validationContext1, validationContext2);
            }
        }
        public readonly struct PositiveNumber : Menes.IJsonValue, System.IEquatable<PositiveNumber>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, PositiveNumber> FromJsonElement = e => new PositiveNumber(e);
            public static readonly PositiveNumber Null = new PositiveNumber(default(System.Text.Json.JsonElement));
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
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new PositiveNumber(property)
                        : Null)
                    : Null;
            public static PositiveNumber FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new PositiveNumber(property)
                        : Null)
                    : Null;
            public static PositiveNumber FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
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
                context = value.ValidateAsNumber(context, MultipleOf, Maximum, ExclusiveMaximum, Minimum, ExclusiveMinimum, (System.Collections.Immutable.ImmutableArray<Menes.JsonNumber>?)null, (Menes.JsonNumber?)null);
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
            public override string ToString()
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
        }
        public readonly struct NonNegativeInteger : Menes.IJsonValue, System.IEquatable<NonNegativeInteger>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, NonNegativeInteger> FromJsonElement = e => new NonNegativeInteger(e);
            public static readonly NonNegativeInteger Null = new NonNegativeInteger(default(System.Text.Json.JsonElement));
            private static readonly Menes.JsonNumber? MultipleOf = null;
            private static readonly Menes.JsonNumber? Maximum = null;
            private static readonly Menes.JsonNumber? ExclusiveMaximum = null;
            private static readonly Menes.JsonNumber? Minimum = 0;
            private static readonly Menes.JsonNumber? ExclusiveMinimum = null;
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
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new NonNegativeInteger(property)
                        : Null)
                    : Null;
            public static NonNegativeInteger FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new NonNegativeInteger(property)
                        : Null)
                    : Null;
            public static NonNegativeInteger FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
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
                context = value.ValidateAsNumber(context, MultipleOf, Maximum, ExclusiveMaximum, Minimum, ExclusiveMinimum, (System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>?)null, (Menes.JsonInteger?)null);
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
            public override string ToString()
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
        }
        public readonly struct UniqueStringArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonString>, System.Collections.IEnumerable, System.IEquatable<UniqueStringArray>, System.IEquatable<Menes.JsonArray<Menes.JsonString>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, UniqueStringArray> FromJsonElement = e => new UniqueStringArray(e);
            public static readonly UniqueStringArray Null = new UniqueStringArray(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<Menes.JsonString>? value;
            public UniqueStringArray(Menes.JsonArray<Menes.JsonString> jsonArray)
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
            public UniqueStringArray(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public int Length
            {
                get
                {
                    if (this.HasJsonElement)
                    {
                        return this.JsonElement.GetArrayLength();
                    }
                    if (this.value is Menes.JsonArray<Menes.JsonString> value)
                    {
                        return value.Length;
                    }
                    return 0;
                }
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public UniqueStringArray? AsOptional => this.IsNull ? default(UniqueStringArray?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator UniqueStringArray(Menes.JsonArray<Menes.JsonString> value)
            {
                return new UniqueStringArray(value);
            }
            public static implicit operator Menes.JsonArray<Menes.JsonString>(UniqueStringArray value)
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
            public static UniqueStringArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new UniqueStringArray(property)
                        : Null)
                    : Null;
            public static UniqueStringArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new UniqueStringArray(property)
                        : Null)
                    : Null;
            public static UniqueStringArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new UniqueStringArray(property)
                        : Null)
                    : Null;
            public bool Equals(UniqueStringArray other)
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
                if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
                {
                    context = array.ValidateUniqueItems(context, true);
                }
                return context;
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
            public UniqueStringArray Add(params Menes.JsonString[] items)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    arrayBuilder.Add(item);
                }
                foreach (Menes.JsonString item in items)
                {
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Add(in Menes.JsonString item1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Add(in Menes.JsonString item1, in Menes.JsonString item2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Add(in Menes.JsonString item1, in Menes.JsonString item2, in Menes.JsonString item3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Add(in Menes.JsonString item1, in Menes.JsonString item2, in Menes.JsonString item3, in Menes.JsonString item4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                arrayBuilder.Add(item4);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Insert(int indexToInsert, params Menes.JsonString[] items)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                int index = 0;
                foreach (Menes.JsonString item in this)
                {
                    if (index == indexToInsert)
                    {
                        foreach (Menes.JsonString itemToInsert in items)
                        {
                            arrayBuilder.Add(itemToInsert);
                        }
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Insert(int indexToInsert, in Menes.JsonString item1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                int index = 0;
                foreach (Menes.JsonString item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Insert(int indexToInsert, in Menes.JsonString item1, in Menes.JsonString item2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                int index = 0;
                foreach (Menes.JsonString item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Insert(int indexToInsert, in Menes.JsonString item1, in Menes.JsonString item2, in Menes.JsonString item3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                int index = 0;
                foreach (Menes.JsonString item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                        arrayBuilder.Add(item3);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Insert(int indexToInsert, in Menes.JsonString item1, in Menes.JsonString item2, in Menes.JsonString item3, in Menes.JsonString item4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                int index = 0;
                foreach (Menes.JsonString item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                        arrayBuilder.Add(item3);
                        arrayBuilder.Add(item4);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Remove(params Menes.JsonString[] items)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    bool found = false;
                    foreach (Menes.JsonString itemToRemove in items)
                    {
                        if (itemToRemove.Equals(item))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        arrayBuilder.Add(item);
                    }
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Remove(Menes.JsonString item1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    if (item1.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Remove(Menes.JsonString item1, Menes.JsonString item2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Remove(Menes.JsonString item1, Menes.JsonString item2, Menes.JsonString item3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Remove(Menes.JsonString item1, Menes.JsonString item2, Menes.JsonString item3, Menes.JsonString item4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray RemoveAt(int indexToRemove)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                int index = 0;
                foreach (Menes.JsonString item in this)
                {
                    if (index == indexToRemove)
                    {
                        index++;
                        continue;
                    }
                    arrayBuilder.Add(item);
                    index++;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray RemoveRange(int startIndex, int length)
            {
                if (startIndex < 0 || startIndex > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(startIndex));
                }
                if (length < 1 || startIndex + length > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(length));
                }
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                int index = 0;
                foreach (Menes.JsonString item in this)
                {
                    if (index >= startIndex && index < startIndex + length)
                    {
                        index++;
                        continue;
                    }
                    arrayBuilder.Add(item);
                    index++;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public UniqueStringArray Remove(System.Predicate<Menes.JsonString> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonString>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
                foreach (Menes.JsonString item in this)
                {
                    if (removeIfTrue(item))
                    {
                        continue;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
        }
        public readonly struct NonEmptyBooleanArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonBoolean>, System.Collections.IEnumerable, System.IEquatable<NonEmptyBooleanArray>, System.IEquatable<Menes.JsonArray<Menes.JsonBoolean>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, NonEmptyBooleanArray> FromJsonElement = e => new NonEmptyBooleanArray(e);
            public static readonly NonEmptyBooleanArray Null = new NonEmptyBooleanArray(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<Menes.JsonBoolean>? value;
            public NonEmptyBooleanArray(Menes.JsonArray<Menes.JsonBoolean> jsonArray)
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
            public NonEmptyBooleanArray(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public int Length
            {
                get
                {
                    if (this.HasJsonElement)
                    {
                        return this.JsonElement.GetArrayLength();
                    }
                    if (this.value is Menes.JsonArray<Menes.JsonBoolean> value)
                    {
                        return value.Length;
                    }
                    return 0;
                }
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public NonEmptyBooleanArray? AsOptional => this.IsNull ? default(NonEmptyBooleanArray?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator NonEmptyBooleanArray(Menes.JsonArray<Menes.JsonBoolean> value)
            {
                return new NonEmptyBooleanArray(value);
            }
            public static implicit operator Menes.JsonArray<Menes.JsonBoolean>(NonEmptyBooleanArray value)
            {
                if (value.value is Menes.JsonArray<Menes.JsonBoolean> clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonArray<Menes.JsonBoolean>(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonArray<Menes.JsonBoolean>.IsConvertibleFrom(jsonElement);
            }
            public static NonEmptyBooleanArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new NonEmptyBooleanArray(property)
                        : Null)
                    : Null;
            public static NonEmptyBooleanArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new NonEmptyBooleanArray(property)
                        : Null)
                    : Null;
            public static NonEmptyBooleanArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new NonEmptyBooleanArray(property)
                        : Null)
                    : Null;
            public bool Equals(NonEmptyBooleanArray other)
            {
                return this.Equals((Menes.JsonArray<Menes.JsonBoolean>)other);
            }
            public bool Equals(Menes.JsonArray<Menes.JsonBoolean> other)
            {
                return ((Menes.JsonArray<Menes.JsonBoolean>)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonArray<Menes.JsonBoolean> array = this;
                Menes.ValidationContext context = validationContext;
                if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
                {
                    context = array.ValidateMinItems(context, 1);
                    context = array.ValidateItems(context);
                }
                return context;
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                if (this.value is Menes.JsonArray<Menes.JsonBoolean> clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public Menes.JsonArray<Menes.JsonBoolean>.JsonArrayEnumerator GetEnumerator()
            {
                return ((Menes.JsonArray<Menes.JsonBoolean>)this).GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Menes.JsonBoolean> System.Collections.Generic.IEnumerable<Menes.JsonBoolean>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            public NonEmptyBooleanArray Add(params Menes.JsonBoolean[] items)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    arrayBuilder.Add(item);
                }
                foreach (Menes.JsonBoolean item in items)
                {
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Add(in Menes.JsonBoolean item1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Add(in Menes.JsonBoolean item1, in Menes.JsonBoolean item2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Add(in Menes.JsonBoolean item1, in Menes.JsonBoolean item2, in Menes.JsonBoolean item3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Add(in Menes.JsonBoolean item1, in Menes.JsonBoolean item2, in Menes.JsonBoolean item3, in Menes.JsonBoolean item4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                arrayBuilder.Add(item4);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Insert(int indexToInsert, params Menes.JsonBoolean[] items)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                int index = 0;
                foreach (Menes.JsonBoolean item in this)
                {
                    if (index == indexToInsert)
                    {
                        foreach (Menes.JsonBoolean itemToInsert in items)
                        {
                            arrayBuilder.Add(itemToInsert);
                        }
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Insert(int indexToInsert, in Menes.JsonBoolean item1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                int index = 0;
                foreach (Menes.JsonBoolean item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Insert(int indexToInsert, in Menes.JsonBoolean item1, in Menes.JsonBoolean item2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                int index = 0;
                foreach (Menes.JsonBoolean item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Insert(int indexToInsert, in Menes.JsonBoolean item1, in Menes.JsonBoolean item2, in Menes.JsonBoolean item3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                int index = 0;
                foreach (Menes.JsonBoolean item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                        arrayBuilder.Add(item3);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Insert(int indexToInsert, in Menes.JsonBoolean item1, in Menes.JsonBoolean item2, in Menes.JsonBoolean item3, in Menes.JsonBoolean item4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                int index = 0;
                foreach (Menes.JsonBoolean item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                        arrayBuilder.Add(item3);
                        arrayBuilder.Add(item4);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Remove(params Menes.JsonBoolean[] items)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    bool found = false;
                    foreach (Menes.JsonBoolean itemToRemove in items)
                    {
                        if (itemToRemove.Equals(item))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        arrayBuilder.Add(item);
                    }
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Remove(Menes.JsonBoolean item1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    if (item1.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Remove(Menes.JsonBoolean item1, Menes.JsonBoolean item2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Remove(Menes.JsonBoolean item1, Menes.JsonBoolean item2, Menes.JsonBoolean item3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Remove(Menes.JsonBoolean item1, Menes.JsonBoolean item2, Menes.JsonBoolean item3, Menes.JsonBoolean item4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray RemoveAt(int indexToRemove)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                int index = 0;
                foreach (Menes.JsonBoolean item in this)
                {
                    if (index == indexToRemove)
                    {
                        index++;
                        continue;
                    }
                    arrayBuilder.Add(item);
                    index++;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray RemoveRange(int startIndex, int length)
            {
                if (startIndex < 0 || startIndex > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(startIndex));
                }
                if (length < 1 || startIndex + length > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(length));
                }
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                int index = 0;
                foreach (Menes.JsonBoolean item in this)
                {
                    if (index >= startIndex && index < startIndex + length)
                    {
                        index++;
                        continue;
                    }
                    arrayBuilder.Add(item);
                    index++;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptyBooleanArray Remove(System.Predicate<Menes.JsonBoolean> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonBoolean>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonBoolean>();
                foreach (Menes.JsonBoolean item in this)
                {
                    if (removeIfTrue(item))
                    {
                        continue;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
        }
        public readonly struct NonEmptySubschemaArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<JsonSchema>, System.Collections.IEnumerable, System.IEquatable<NonEmptySubschemaArray>, System.IEquatable<Menes.JsonArray<JsonSchema>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, NonEmptySubschemaArray> FromJsonElement = e => new NonEmptySubschemaArray(e);
            public static readonly NonEmptySubschemaArray Null = new NonEmptySubschemaArray(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<JsonSchema>? value;
            public NonEmptySubschemaArray(Menes.JsonArray<JsonSchema> jsonArray)
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
            public NonEmptySubschemaArray(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public int Length
            {
                get
                {
                    if (this.HasJsonElement)
                    {
                        return this.JsonElement.GetArrayLength();
                    }
                    if (this.value is Menes.JsonArray<JsonSchema> value)
                    {
                        return value.Length;
                    }
                    return 0;
                }
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public NonEmptySubschemaArray? AsOptional => this.IsNull ? default(NonEmptySubschemaArray?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator NonEmptySubschemaArray(Menes.JsonArray<JsonSchema> value)
            {
                return new NonEmptySubschemaArray(value);
            }
            public static implicit operator Menes.JsonArray<JsonSchema>(NonEmptySubschemaArray value)
            {
                if (value.value is Menes.JsonArray<JsonSchema> clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonArray<JsonSchema>(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonArray<JsonSchema>.IsConvertibleFrom(jsonElement);
            }
            public static NonEmptySubschemaArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new NonEmptySubschemaArray(property)
                        : Null)
                    : Null;
            public static NonEmptySubschemaArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new NonEmptySubschemaArray(property)
                        : Null)
                    : Null;
            public static NonEmptySubschemaArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new NonEmptySubschemaArray(property)
                        : Null)
                    : Null;
            public bool Equals(NonEmptySubschemaArray other)
            {
                return this.Equals((Menes.JsonArray<JsonSchema>)other);
            }
            public bool Equals(Menes.JsonArray<JsonSchema> other)
            {
                return ((Menes.JsonArray<JsonSchema>)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonArray<JsonSchema> array = this;
                Menes.ValidationContext context = validationContext;
                if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
                {
                    context = array.ValidateMinItems(context, 1);
                    context = array.ValidateItems(context);
                }
                return context;
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                if (this.value is Menes.JsonArray<JsonSchema> clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public Menes.JsonArray<JsonSchema>.JsonArrayEnumerator GetEnumerator()
            {
                return ((Menes.JsonArray<JsonSchema>)this).GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<JsonSchema> System.Collections.Generic.IEnumerable<JsonSchema>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            public NonEmptySubschemaArray Add(params JsonSchema[] items)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    arrayBuilder.Add(item);
                }
                foreach (JsonSchema item in items)
                {
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Add(in JsonSchema item1)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Add(in JsonSchema item1, in JsonSchema item2)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Add(in JsonSchema item1, in JsonSchema item2, in JsonSchema item3)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Add(in JsonSchema item1, in JsonSchema item2, in JsonSchema item3, in JsonSchema item4)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                arrayBuilder.Add(item4);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Insert(int indexToInsert, params JsonSchema[] items)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                int index = 0;
                foreach (JsonSchema item in this)
                {
                    if (index == indexToInsert)
                    {
                        foreach (JsonSchema itemToInsert in items)
                        {
                            arrayBuilder.Add(itemToInsert);
                        }
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Insert(int indexToInsert, in JsonSchema item1)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                int index = 0;
                foreach (JsonSchema item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Insert(int indexToInsert, in JsonSchema item1, in JsonSchema item2)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                int index = 0;
                foreach (JsonSchema item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Insert(int indexToInsert, in JsonSchema item1, in JsonSchema item2, in JsonSchema item3)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                int index = 0;
                foreach (JsonSchema item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                        arrayBuilder.Add(item3);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Insert(int indexToInsert, in JsonSchema item1, in JsonSchema item2, in JsonSchema item3, in JsonSchema item4)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                int index = 0;
                foreach (JsonSchema item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                        arrayBuilder.Add(item3);
                        arrayBuilder.Add(item4);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Remove(params JsonSchema[] items)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    bool found = false;
                    foreach (JsonSchema itemToRemove in items)
                    {
                        if (itemToRemove.Equals(item))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        arrayBuilder.Add(item);
                    }
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Remove(JsonSchema item1)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    if (item1.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Remove(JsonSchema item1, JsonSchema item2)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Remove(JsonSchema item1, JsonSchema item2, JsonSchema item3)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Remove(JsonSchema item1, JsonSchema item2, JsonSchema item3, JsonSchema item4)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray RemoveAt(int indexToRemove)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                int index = 0;
                foreach (JsonSchema item in this)
                {
                    if (index == indexToRemove)
                    {
                        index++;
                        continue;
                    }
                    arrayBuilder.Add(item);
                    index++;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray RemoveRange(int startIndex, int length)
            {
                if (startIndex < 0 || startIndex > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(startIndex));
                }
                if (length < 1 || startIndex + length > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(length));
                }
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                int index = 0;
                foreach (JsonSchema item in this)
                {
                    if (index >= startIndex && index < startIndex + length)
                    {
                        index++;
                        continue;
                    }
                    arrayBuilder.Add(item);
                    index++;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public NonEmptySubschemaArray Remove(System.Predicate<JsonSchema> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<JsonSchema>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<JsonSchema>();
                foreach (JsonSchema item in this)
                {
                    if (removeIfTrue(item))
                    {
                        continue;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
        }

        public readonly struct SchemaProperties : Menes.IJsonObject, System.IEquatable<JsonSchema.SchemaProperties>, Menes.IJsonAdditionalProperties<JsonSchema>
        {
            public static readonly JsonSchema.SchemaProperties Null = new JsonSchema.SchemaProperties(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema.SchemaProperties> FromJsonElement = e => new JsonSchema.SchemaProperties(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties<JsonSchema>? additionalPropertiesBacking;
            public SchemaProperties(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalPropertiesBacking = null;
            }
            public SchemaProperties(params (string, JsonSchema)[] additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<JsonSchema>.FromValues(additionalPropertiesBacking);
            }
            public SchemaProperties((string, JsonSchema) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<JsonSchema>.FromValues(additionalProperty1);
            }
            public SchemaProperties((string, JsonSchema) additionalProperty1, (string, JsonSchema) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<JsonSchema>.FromValues(additionalProperty1, additionalProperty2);
            }
            public SchemaProperties((string, JsonSchema) additionalProperty1, (string, JsonSchema) additionalProperty2, (string, JsonSchema) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<JsonSchema>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public SchemaProperties((string, JsonSchema) additionalProperty1, (string, JsonSchema) additionalProperty2, (string, JsonSchema) additionalProperty3, (string, JsonSchema) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<JsonSchema>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private SchemaProperties(Menes.JsonProperties<JsonSchema>? additionalPropertiesBacking)
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
                    Menes.JsonProperties<JsonSchema>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
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
            public Menes.JsonProperties<JsonSchema>.JsonPropertyEnumerator JsonAdditionalProperties
            {
                get
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<JsonSchema> ap)
                    {
                        return new Menes.JsonProperties<JsonSchema>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<JsonSchema>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<JsonSchema>.JsonPropertyEnumerator(Menes.JsonProperties<JsonSchema>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static JsonSchema.SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new JsonSchema.SchemaProperties(property)
                        : Null)
                    : Null;
            public static JsonSchema.SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new JsonSchema.SchemaProperties(property)
                        : Null)
                    : Null;
            public static JsonSchema.SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new JsonSchema.SchemaProperties(property)
                        : Null)
                : Null;
            public JsonSchema.SchemaProperties ReplaceAll(Menes.JsonProperties<JsonSchema> newAdditional)
            {
                return new JsonSchema.SchemaProperties(newAdditional);
            }
            public JsonSchema.SchemaProperties ReplaceAll(params (string, JsonSchema)[] newAdditional)
            {
                return new JsonSchema.SchemaProperties(Menes.JsonProperties<JsonSchema>.FromValues(newAdditional));
            }
            public JsonSchema.SchemaProperties ReplaceAll((string, JsonSchema) newAdditional1)
            {
                return new JsonSchema.SchemaProperties(Menes.JsonProperties<JsonSchema>.FromValues(newAdditional1));
            }
            public JsonSchema.SchemaProperties ReplaceAll((string, JsonSchema) newAdditional1, (string, JsonSchema) newAdditional2)
            {
                return new JsonSchema.SchemaProperties(Menes.JsonProperties<JsonSchema>.FromValues(newAdditional1, newAdditional2));
            }
            public JsonSchema.SchemaProperties ReplaceAll((string, JsonSchema) newAdditional1, (string, JsonSchema) newAdditional2, (string, JsonSchema) newAdditional3)
            {
                return new JsonSchema.SchemaProperties(Menes.JsonProperties<JsonSchema>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public JsonSchema.SchemaProperties ReplaceAll((string, JsonSchema) newAdditional1, (string, JsonSchema) newAdditional2, (string, JsonSchema) newAdditional3, (string, JsonSchema) newAdditional4)
            {
                return new JsonSchema.SchemaProperties(Menes.JsonProperties<JsonSchema>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
            }
            public JsonSchema.SchemaProperties Add(params (string, JsonSchema)[] newAdditional)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                foreach ((string name, JsonSchema value) in newAdditional)
                {
                    arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(name, value));
                }
                return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
            }
            public JsonSchema.SchemaProperties Add((string name, JsonSchema value) newAdditional1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(newAdditional1.name, newAdditional1.value)); return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
            }
            public JsonSchema.SchemaProperties Add((string name, JsonSchema value) newAdditional1, (string name, JsonSchema value) newAdditional2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(newAdditional2.name, newAdditional2.value)); return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
            }
            public JsonSchema.SchemaProperties Add((string name, JsonSchema value) newAdditional1, (string name, JsonSchema value) newAdditional2, (string name, JsonSchema value) newAdditional3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(newAdditional3.name, newAdditional3.value)); return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
            }
            public JsonSchema.SchemaProperties Add((string name, JsonSchema value) newAdditional1, (string name, JsonSchema value) newAdditional2, (string name, JsonSchema value) newAdditional3, (string name, JsonSchema value) newAdditional4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    arrayBuilder.Add(property);
                }
                arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<JsonSchema>.From(newAdditional4.name, newAdditional4.value)); return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
            }
            public JsonSchema.SchemaProperties Remove(params string[] namesToRemove)
            {
                System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
            }
            public JsonSchema.SchemaProperties Remove(string itemToRemove1)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
            }
            public JsonSchema.SchemaProperties Remove(string itemToRemove1, string itemToRemove2)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
            }
            public JsonSchema.SchemaProperties Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
            }
            public JsonSchema.SchemaProperties Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
            {
                System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
                ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    if (!ihs.Contains(property.Name))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
            }
            public JsonSchema.SchemaProperties Remove(System.Predicate<Menes.JsonPropertyReference<JsonSchema>> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<JsonSchema>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<JsonSchema>>();
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                {
                    if (!removeIfTrue(property))
                    {
                        arrayBuilder.Add(property);
                    }
                }
                return new JsonSchema.SchemaProperties(new Menes.JsonProperties<JsonSchema>(arrayBuilder.ToImmutable()));
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
                    Menes.JsonProperties<JsonSchema>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
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
                if (this.IsNull)
                {
                    return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
                }
                Menes.ValidationContext context = validationContext;
                if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
                {
                    foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
                    {
                        string propertyName = property.Name;
                        context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                    }
                }
                return context;
            }
            public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JsonSchema value)
            {
                return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JsonSchema value)
            {
                foreach (Menes.JsonPropertyReference<JsonSchema> property in this.JsonAdditionalProperties)
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
            public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JsonSchema value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGet(bytes.Slice(0, written), out value);
            }
            public override string ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonProperties<JsonSchema> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<JsonSchema> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<JsonSchema>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }

        public readonly struct SchemaAdditionalProperties : Menes.IJsonValue
        {
            public static readonly SchemaAdditionalProperties Null = new SchemaAdditionalProperties(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema.SchemaAdditionalProperties> FromJsonElement = e => new JsonSchema.SchemaAdditionalProperties(e);
            private readonly Menes.JsonReference? item1;
            private readonly Menes.JsonBoolean? item2;
            public SchemaAdditionalProperties(JsonSchema clrInstance)
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
            public bool IsJsonSchema => this.item1 is Menes.JsonReference || (JsonSchema.IsConvertibleFrom(this.JsonElement) && JsonSchema.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool IsJsonBoolean => this.item2 is Menes.JsonBoolean || (Menes.JsonBoolean.IsConvertibleFrom(this.JsonElement) && Menes.JsonBoolean.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator JsonSchema(SchemaAdditionalProperties value) => value.AsJsonSchema();
            public static implicit operator SchemaAdditionalProperties(JsonSchema value) => new SchemaAdditionalProperties(value);
            public static explicit operator Menes.JsonBoolean(SchemaAdditionalProperties value) => value.AsJsonBoolean();
            public static implicit operator SchemaAdditionalProperties(Menes.JsonBoolean value) => new SchemaAdditionalProperties(value);
            public static SchemaAdditionalProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaAdditionalProperties(property)
                        : Null)
                    : Null;
            public static SchemaAdditionalProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaAdditionalProperties(property)
                        : Null)
                    : Null;
            public static SchemaAdditionalProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaAdditionalProperties(property)
                        : Null)
                    : Null;
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                if (JsonSchema.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                if (Menes.JsonBoolean.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                return false;
            }
            public JsonSchema AsJsonSchema() => this.item1?.AsValue<JsonSchema>() ?? new JsonSchema(this.JsonElement);
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
            public override string ToString()
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
                if (this.IsJsonBoolean)
                {
                    validationContext2 = this.AsJsonBoolean().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a Menes.JsonBoolean.");
                }
                return Menes.Validation.ValidateOneOf(validationContext, validationContext1, validationContext2);
            }
        }
        public readonly struct SchemaAdditionalItems : Menes.IJsonValue
        {
            public static readonly SchemaAdditionalItems Null = new SchemaAdditionalItems(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema.SchemaAdditionalItems> FromJsonElement = e => new JsonSchema.SchemaAdditionalItems(e);
            private readonly Menes.JsonReference? item1;
            private readonly Menes.JsonBoolean? item2;
            public SchemaAdditionalItems(JsonSchema clrInstance)
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
            public SchemaAdditionalItems(Menes.JsonBoolean clrInstance)
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
            public SchemaAdditionalItems(System.Text.Json.JsonElement jsonElement)
            {
                this.item1 = null;
                this.item2 = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public SchemaAdditionalItems? AsOptional => this.IsNull ? default(SchemaAdditionalItems?) : this;
            public bool IsJsonSchema => this.item1 is Menes.JsonReference || (JsonSchema.IsConvertibleFrom(this.JsonElement) && JsonSchema.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool IsJsonBoolean => this.item2 is Menes.JsonBoolean || (Menes.JsonBoolean.IsConvertibleFrom(this.JsonElement) && Menes.JsonBoolean.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator JsonSchema(SchemaAdditionalItems value) => value.AsJsonSchema();
            public static implicit operator SchemaAdditionalItems(JsonSchema value) => new SchemaAdditionalItems(value);
            public static explicit operator Menes.JsonBoolean(SchemaAdditionalItems value) => value.AsJsonBoolean();
            public static implicit operator SchemaAdditionalItems(Menes.JsonBoolean value) => new SchemaAdditionalItems(value);
            public static SchemaAdditionalItems FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaAdditionalItems(property)
                        : Null)
                    : Null;
            public static SchemaAdditionalItems FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaAdditionalItems(property)
                        : Null)
                    : Null;
            public static SchemaAdditionalItems FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaAdditionalItems(property)
                        : Null)
                    : Null;
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                if (JsonSchema.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                if (Menes.JsonBoolean.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                return false;
            }
            public JsonSchema AsJsonSchema() => this.item1?.AsValue<JsonSchema>() ?? new JsonSchema(this.JsonElement);
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
            public override string ToString()
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
                if (this.IsJsonBoolean)
                {
                    validationContext2 = this.AsJsonBoolean().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a Menes.JsonBoolean.");
                }
                return Menes.Validation.ValidateOneOf(validationContext, validationContext1, validationContext2);
            }
        }
        public readonly struct SchemaItems : Menes.IJsonValue
        {
            public static readonly SchemaItems Null = new SchemaItems(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, JsonSchema.SchemaItems> FromJsonElement = e => new JsonSchema.SchemaItems(e);
            private readonly Menes.JsonReference? item1;
            private readonly Menes.JsonReference? item2;
            private readonly JsonSchema.NonEmptyBooleanArray? item3;
            public SchemaItems(JsonSchema clrInstance)
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
                this.item3 = null;
            }
            public SchemaItems(JsonSchema.NonEmptySubschemaArray clrInstance)
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
                this.item3 = null;
            }
            public SchemaItems(JsonSchema.NonEmptyBooleanArray clrInstance)
            {
                if (clrInstance.HasJsonElement)
                {
                    this.JsonElement = clrInstance.JsonElement;
                    this.item3 = null;
                }
                else
                {
                    this.item3 = clrInstance;
                    this.JsonElement = default;
                }
                this.item1 = null;
                this.item2 = null;
            }
            public SchemaItems(System.Text.Json.JsonElement jsonElement)
            {
                this.item1 = null;
                this.item2 = null;
                this.item3 = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.item1 is null && this.item2 is null && this.item3 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public SchemaItems? AsOptional => this.IsNull ? default(SchemaItems?) : this;
            public bool IsJsonSchema => this.item1 is Menes.JsonReference || (JsonSchema.IsConvertibleFrom(this.JsonElement) && JsonSchema.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool IsNonEmptySubschemaArray => this.item2 is Menes.JsonReference || (JsonSchema.NonEmptySubschemaArray.IsConvertibleFrom(this.JsonElement) && JsonSchema.NonEmptySubschemaArray.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool IsNonEmptyBooleanArray => this.item3 is JsonSchema.NonEmptyBooleanArray || (JsonSchema.NonEmptyBooleanArray.IsConvertibleFrom(this.JsonElement) && JsonSchema.NonEmptyBooleanArray.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator JsonSchema(SchemaItems value) => value.AsJsonSchema();
            public static implicit operator SchemaItems(JsonSchema value) => new SchemaItems(value);
            public static explicit operator JsonSchema.NonEmptySubschemaArray(SchemaItems value) => value.AsNonEmptySubschemaArray();
            public static implicit operator SchemaItems(JsonSchema.NonEmptySubschemaArray value) => new SchemaItems(value);
            public static implicit operator SchemaItems(Menes.JsonArray<JsonSchema> value)
            {
                return new SchemaItems((JsonSchema.NonEmptySubschemaArray)value);
            }
            public static explicit operator JsonSchema.NonEmptyBooleanArray(SchemaItems value) => value.AsNonEmptyBooleanArray();
            public static implicit operator SchemaItems(JsonSchema.NonEmptyBooleanArray value) => new SchemaItems(value);
            public static implicit operator SchemaItems(Menes.JsonArray<Menes.JsonBoolean> value)
            {
                return new SchemaItems((JsonSchema.NonEmptyBooleanArray)value);
            }
            public static SchemaItems FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaItems(property)
                        : Null)
                    : Null;
            public static SchemaItems FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaItems(property)
                        : Null)
                    : Null;
            public static SchemaItems FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaItems(property)
                        : Null)
                    : Null;
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                if (JsonSchema.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                if (JsonSchema.NonEmptySubschemaArray.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                if (JsonSchema.NonEmptyBooleanArray.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                return false;
            }
            public JsonSchema AsJsonSchema() => this.item1?.AsValue<JsonSchema>() ?? new JsonSchema(this.JsonElement);
            public JsonSchema.NonEmptySubschemaArray AsNonEmptySubschemaArray() => this.item2?.AsValue<JsonSchema.NonEmptySubschemaArray>() ?? new JsonSchema.NonEmptySubschemaArray(this.JsonElement);
            public JsonSchema.NonEmptyBooleanArray AsNonEmptyBooleanArray() => this.item3 ?? new JsonSchema.NonEmptyBooleanArray(this.JsonElement);
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
                else if (this.item3 is JsonSchema.NonEmptyBooleanArray item3)
                {
                    item3.WriteTo(writer);
                }
                else
                {
                    this.JsonElement.WriteTo(writer);
                }
            }
            public override string ToString()
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
                if (this.IsNonEmptySubschemaArray)
                {
                    builder.Append("{");
                    builder.Append("NonEmptySubschemaArray");
                    builder.Append(", ");
                    builder.Append(this.AsNonEmptySubschemaArray().ToString());
                    builder.AppendLine("}");
                }
                if (this.IsNonEmptyBooleanArray)
                {
                    builder.Append("{");
                    builder.Append("NonEmptyBooleanArray");
                    builder.Append(", ");
                    builder.Append(this.AsNonEmptyBooleanArray().ToString());
                    builder.AppendLine("}");
                }
                return builder.Length > 0 ? builder.ToString() : this.JsonElement.ToString();
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.ValidationContext validationContext1 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
                Menes.ValidationContext validationContext2 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
                Menes.ValidationContext validationContext3 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
                if (this.IsJsonSchema)
                {
                    validationContext1 = this.AsJsonSchema().Validate(validationContext1);
                }
                else
                {
                    validationContext1 = validationContext1.WithError("The value is not convertible to a JsonSchema.");
                }
                if (this.IsNonEmptySubschemaArray)
                {
                    validationContext2 = this.AsNonEmptySubschemaArray().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a JsonSchema.NonEmptySubschemaArray.");
                }
                if (this.IsNonEmptyBooleanArray)
                {
                    validationContext3 = this.AsNonEmptyBooleanArray().Validate(validationContext3);
                }
                else
                {
                    validationContext3 = validationContext3.WithError("The value is not convertible to a JsonSchema.NonEmptyBooleanArray.");
                }
                return Menes.Validation.ValidateOneOf(validationContext, validationContext1, validationContext2, validationContext3);
            }
        }
    }
}
