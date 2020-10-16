// <copyright file="Schema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501, SA1119, IDE0047, IDE0034

namespace Menes.JsonSchema
{
    public readonly struct Schema : Menes.IJsonObject, System.IEquatable<Schema>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
        private const string TypePropertyNamePath = ".type";
        private const string FormatPropertyNamePath = ".format";
        private const string EnumPropertyNamePath = ".enum";
        private const string ConstPropertyNamePath = ".const";
        private const string AllofPropertyNamePath = ".allOf";
        private const string AnyofPropertyNamePath = ".anyOf";
        private const string OneofPropertyNamePath = ".oneOf";
        private const string NotPropertyNamePath = ".not";
        private const string MultipleofPropertyNamePath = ".multipleOf";
        private const string MaximumPropertyNamePath = ".maximum";
        private const string ExclusivemaximumPropertyNamePath = ".exclusiveMaximum";
        private const string MinimumPropertyNamePath = ".minimum";
        private const string ExclusiveminimumPropertyNamePath = ".exclusiveMinimum";
        private const string MaxlengthPropertyNamePath = ".maxLength";
        private const string MinlengthPropertyNamePath = ".minLength";
        private const string PatternPropertyNamePath = ".pattern";
        private const string MaxitemsPropertyNamePath = ".maxItems";
        private const string MinitemsPropertyNamePath = ".minItems";
        private const string UniqueitemsPropertyNamePath = ".uniqueItems";
        private const string MaxcontainsPropertyNamePath = ".maxContains";
        private const string ItemsPropertyNamePath = ".items";
        private const string ContainsPropertyNamePath = ".contains";
        private const string MaxpropertiesPropertyNamePath = ".maxProperties";
        private const string MinpropertiesPropertyNamePath = ".minProperties";
        private const string RequiredPropertyNamePath = ".required";
        private const string PropertiesPropertyNamePath = ".properties";
        private const string AdditionalpropertiesPropertyNamePath = ".additionalProperties";
        private static readonly System.ReadOnlyMemory<byte> TypePropertyNameBytes = new byte[] { 116, 121, 112, 101 };
        private static readonly System.ReadOnlyMemory<byte> FormatPropertyNameBytes = new byte[] { 102, 111, 114, 109, 97, 116 };
        private static readonly System.ReadOnlyMemory<byte> EnumPropertyNameBytes = new byte[] { 101, 110, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> ConstPropertyNameBytes = new byte[] { 99, 111, 110, 115, 116 };
        private static readonly System.ReadOnlyMemory<byte> AllofPropertyNameBytes = new byte[] { 97, 108, 108, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> AnyofPropertyNameBytes = new byte[] { 97, 110, 121, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> OneofPropertyNameBytes = new byte[] { 111, 110, 101, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> NotPropertyNameBytes = new byte[] { 110, 111, 116 };
        private static readonly System.ReadOnlyMemory<byte> MultipleofPropertyNameBytes = new byte[] { 109, 117, 108, 116, 105, 112, 108, 101, 79, 102 };
        private static readonly System.ReadOnlyMemory<byte> MaximumPropertyNameBytes = new byte[] { 109, 97, 120, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> ExclusivemaximumPropertyNameBytes = new byte[] { 101, 120, 99, 108, 117, 115, 105, 118, 101, 77, 97, 120, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> MinimumPropertyNameBytes = new byte[] { 109, 105, 110, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> ExclusiveminimumPropertyNameBytes = new byte[] { 101, 120, 99, 108, 117, 115, 105, 118, 101, 77, 105, 110, 105, 109, 117, 109 };
        private static readonly System.ReadOnlyMemory<byte> MaxlengthPropertyNameBytes = new byte[] { 109, 97, 120, 76, 101, 110, 103, 116, 104 };
        private static readonly System.ReadOnlyMemory<byte> MinlengthPropertyNameBytes = new byte[] { 109, 105, 110, 76, 101, 110, 103, 116, 104 };
        private static readonly System.ReadOnlyMemory<byte> PatternPropertyNameBytes = new byte[] { 112, 97, 116, 116, 101, 114, 110 };
        private static readonly System.ReadOnlyMemory<byte> MaxitemsPropertyNameBytes = new byte[] { 109, 97, 120, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> MinitemsPropertyNameBytes = new byte[] { 109, 105, 110, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> UniqueitemsPropertyNameBytes = new byte[] { 117, 110, 105, 113, 117, 101, 73, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> MaxcontainsPropertyNameBytes = new byte[] { 109, 97, 120, 67, 111, 110, 116, 97, 105, 110, 115 };
        private static readonly System.ReadOnlyMemory<byte> ItemsPropertyNameBytes = new byte[] { 105, 116, 101, 109, 115 };
        private static readonly System.ReadOnlyMemory<byte> ContainsPropertyNameBytes = new byte[] { 99, 111, 110, 116, 97, 105, 110, 115 };
        private static readonly System.ReadOnlyMemory<byte> MaxpropertiesPropertyNameBytes = new byte[] { 109, 97, 120, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> MinpropertiesPropertyNameBytes = new byte[] { 109, 105, 110, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> RequiredPropertyNameBytes = new byte[] { 114, 101, 113, 117, 105, 114, 101, 100 };
        private static readonly System.ReadOnlyMemory<byte> PropertiesPropertyNameBytes = new byte[] { 112, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.ReadOnlyMemory<byte> AdditionalpropertiesPropertyNameBytes = new byte[] { 97, 100, 100, 105, 116, 105, 111, 110, 97, 108, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
        private static readonly System.Text.Json.JsonEncodedText EncodedTypePropertyName = System.Text.Json.JsonEncodedText.Encode(TypePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedFormatPropertyName = System.Text.Json.JsonEncodedText.Encode(FormatPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedEnumPropertyName = System.Text.Json.JsonEncodedText.Encode(EnumPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedConstPropertyName = System.Text.Json.JsonEncodedText.Encode(ConstPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedAllofPropertyName = System.Text.Json.JsonEncodedText.Encode(AllofPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedAnyofPropertyName = System.Text.Json.JsonEncodedText.Encode(AnyofPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedOneofPropertyName = System.Text.Json.JsonEncodedText.Encode(OneofPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedNotPropertyName = System.Text.Json.JsonEncodedText.Encode(NotPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMultipleofPropertyName = System.Text.Json.JsonEncodedText.Encode(MultipleofPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaximumPropertyName = System.Text.Json.JsonEncodedText.Encode(MaximumPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedExclusivemaximumPropertyName = System.Text.Json.JsonEncodedText.Encode(ExclusivemaximumPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMinimumPropertyName = System.Text.Json.JsonEncodedText.Encode(MinimumPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedExclusiveminimumPropertyName = System.Text.Json.JsonEncodedText.Encode(ExclusiveminimumPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaxlengthPropertyName = System.Text.Json.JsonEncodedText.Encode(MaxlengthPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMinlengthPropertyName = System.Text.Json.JsonEncodedText.Encode(MinlengthPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedPatternPropertyName = System.Text.Json.JsonEncodedText.Encode(PatternPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaxitemsPropertyName = System.Text.Json.JsonEncodedText.Encode(MaxitemsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMinitemsPropertyName = System.Text.Json.JsonEncodedText.Encode(MinitemsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedUniqueitemsPropertyName = System.Text.Json.JsonEncodedText.Encode(UniqueitemsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaxcontainsPropertyName = System.Text.Json.JsonEncodedText.Encode(MaxcontainsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedItemsPropertyName = System.Text.Json.JsonEncodedText.Encode(ItemsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedContainsPropertyName = System.Text.Json.JsonEncodedText.Encode(ContainsPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMaxpropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(MaxpropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedMinpropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(MinpropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedRequiredPropertyName = System.Text.Json.JsonEncodedText.Encode(RequiredPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedPropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(PropertiesPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedAdditionalpropertiesPropertyName = System.Text.Json.JsonEncodedText.Encode(AdditionalpropertiesPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(TypePropertyNameBytes, FormatPropertyNameBytes, EnumPropertyNameBytes, ConstPropertyNameBytes, AllofPropertyNameBytes, AnyofPropertyNameBytes, OneofPropertyNameBytes, NotPropertyNameBytes, MultipleofPropertyNameBytes, MaximumPropertyNameBytes, ExclusivemaximumPropertyNameBytes, MinimumPropertyNameBytes, ExclusiveminimumPropertyNameBytes, MaxlengthPropertyNameBytes, MinlengthPropertyNameBytes, PatternPropertyNameBytes, MaxitemsPropertyNameBytes, MinitemsPropertyNameBytes, UniqueitemsPropertyNameBytes, MaxcontainsPropertyNameBytes, ItemsPropertyNameBytes, ContainsPropertyNameBytes, MaxpropertiesPropertyNameBytes, MinpropertiesPropertyNameBytes, RequiredPropertyNameBytes, PropertiesPropertyNameBytes, AdditionalpropertiesPropertyNameBytes);
        private readonly Schema.TypeEnum? type;
        private readonly Menes.JsonString? format;
        private readonly Menes.JsonArray<Menes.JsonAny>? @enum;
        private readonly Menes.JsonAny? @const;
        private readonly Menes.JsonReference? allof;
        private readonly Menes.JsonReference? anyof;
        private readonly Menes.JsonReference? oneof;
        private readonly Menes.JsonReference? not;
        private readonly Schema.PositiveInteger? multipleof;
        private readonly Menes.JsonInteger? maximum;
        private readonly Menes.JsonInteger? exclusivemaximum;
        private readonly Menes.JsonInteger? minimum;
        private readonly Menes.JsonInteger? exclusiveminimum;
        private readonly Schema.NonNegativeInteger? maxlength;
        private readonly Schema.NonNegativeInteger? minlength;
        private readonly Menes.JsonString? pattern;
        private readonly Schema.NonNegativeInteger? maxitems;
        private readonly Schema.NonNegativeInteger? minitems;
        private readonly Menes.JsonBoolean? uniqueitems;
        private readonly Schema.NonNegativeInteger? maxcontains;
        private readonly Menes.JsonReference? items;
        private readonly Menes.JsonReference? contains;
        private readonly Schema.NonNegativeInteger? maxproperties;
        private readonly Schema.NonNegativeInteger? minproperties;
        private readonly Menes.JsonReference? required;
        private readonly Menes.JsonReference? properties;
        private readonly Menes.JsonReference? additionalproperties;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalProperties;
        public Schema(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.type = null;
            this.format = null;
            this.@enum = null;
            this.@const = null;
            this.allof = null;
            this.anyof = null;
            this.oneof = null;
            this.not = null;
            this.multipleof = null;
            this.maximum = null;
            this.exclusivemaximum = null;
            this.minimum = null;
            this.exclusiveminimum = null;
            this.maxlength = null;
            this.minlength = null;
            this.pattern = null;
            this.maxitems = null;
            this.minitems = null;
            this.uniqueitems = null;
            this.maxcontains = null;
            this.items = null;
            this.contains = null;
            this.maxproperties = null;
            this.minproperties = null;
            this.required = null;
            this.properties = null;
            this.additionalproperties = null;
            this.additionalProperties = null;
        }
        public Schema(Schema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Schema.ValidatedArrayOfSchemaOrReference? allof, Schema.ValidatedArrayOfSchemaOrReference? anyof, Schema.ValidatedArrayOfSchemaOrReference? oneof, Schema.SchemaOrReference? not, Schema.PositiveInteger? multipleof, Menes.JsonInteger? maximum, Menes.JsonInteger? exclusivemaximum, Menes.JsonInteger? minimum, Menes.JsonInteger? exclusiveminimum, Schema.NonNegativeInteger? maxlength, Schema.NonNegativeInteger? minlength, Menes.JsonString? pattern, Schema.NonNegativeInteger? maxitems, Schema.NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, Schema.NonNegativeInteger? maxcontains, Schema.SchemaOrReference? items, Schema.SchemaOrReference? contains, Schema.NonNegativeInteger? maxproperties, Schema.NonNegativeInteger? minproperties, Schema.ValidatedArrayOfJsonString? required, Schema.SchemaProperties? properties, Schema.SchemaAdditionalProperties? additionalproperties, Menes.JsonProperties<Menes.JsonAny> additionalProperties)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is Schema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is Schema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is Schema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is Schema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            this.multipleof = multipleof;
            this.maximum = maximum;
            this.exclusivemaximum = exclusivemaximum;
            this.minimum = minimum;
            this.exclusiveminimum = exclusiveminimum;
            this.maxlength = maxlength;
            this.minlength = minlength;
            this.pattern = pattern;
            this.maxitems = maxitems;
            this.minitems = minitems;
            this.uniqueitems = uniqueitems;
            this.maxcontains = maxcontains;
            if (items is Schema.SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is Schema.SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is Schema.ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is Schema.SchemaProperties item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is Schema.SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = additionalProperties;
        }
        public Schema(Schema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Schema.ValidatedArrayOfSchemaOrReference? allof, Schema.ValidatedArrayOfSchemaOrReference? anyof, Schema.ValidatedArrayOfSchemaOrReference? oneof, Schema.SchemaOrReference? not, Schema.PositiveInteger? multipleof, Menes.JsonInteger? maximum, Menes.JsonInteger? exclusivemaximum, Menes.JsonInteger? minimum, Menes.JsonInteger? exclusiveminimum, Schema.NonNegativeInteger? maxlength, Schema.NonNegativeInteger? minlength, Menes.JsonString? pattern, Schema.NonNegativeInteger? maxitems, Schema.NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, Schema.NonNegativeInteger? maxcontains, Schema.SchemaOrReference? items, Schema.SchemaOrReference? contains, Schema.NonNegativeInteger? maxproperties, Schema.NonNegativeInteger? minproperties, Schema.ValidatedArrayOfJsonString? required, Schema.SchemaProperties? properties, Schema.SchemaAdditionalProperties? additionalproperties, params (string, Menes.JsonAny)[] additionalProperties)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is Schema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is Schema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is Schema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is Schema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            this.multipleof = multipleof;
            this.maximum = maximum;
            this.exclusivemaximum = exclusivemaximum;
            this.minimum = minimum;
            this.exclusiveminimum = exclusiveminimum;
            this.maxlength = maxlength;
            this.minlength = minlength;
            this.pattern = pattern;
            this.maxitems = maxitems;
            this.minitems = minitems;
            this.uniqueitems = uniqueitems;
            this.maxcontains = maxcontains;
            if (items is Schema.SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is Schema.SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is Schema.ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is Schema.SchemaProperties item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is Schema.SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperties);
        }
        public Schema(Schema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Schema.ValidatedArrayOfSchemaOrReference? allof, Schema.ValidatedArrayOfSchemaOrReference? anyof, Schema.ValidatedArrayOfSchemaOrReference? oneof, Schema.SchemaOrReference? not, Schema.PositiveInteger? multipleof, Menes.JsonInteger? maximum, Menes.JsonInteger? exclusivemaximum, Menes.JsonInteger? minimum, Menes.JsonInteger? exclusiveminimum, Schema.NonNegativeInteger? maxlength, Schema.NonNegativeInteger? minlength, Menes.JsonString? pattern, Schema.NonNegativeInteger? maxitems, Schema.NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, Schema.NonNegativeInteger? maxcontains, Schema.SchemaOrReference? items, Schema.SchemaOrReference? contains, Schema.NonNegativeInteger? maxproperties, Schema.NonNegativeInteger? minproperties, Schema.ValidatedArrayOfJsonString? required, Schema.SchemaProperties? properties, Schema.SchemaAdditionalProperties? additionalproperties)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is Schema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is Schema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is Schema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is Schema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            this.multipleof = multipleof;
            this.maximum = maximum;
            this.exclusivemaximum = exclusivemaximum;
            this.minimum = minimum;
            this.exclusiveminimum = exclusiveminimum;
            this.maxlength = maxlength;
            this.minlength = minlength;
            this.pattern = pattern;
            this.maxitems = maxitems;
            this.minitems = minitems;
            this.uniqueitems = uniqueitems;
            this.maxcontains = maxcontains;
            if (items is Schema.SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is Schema.SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is Schema.ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is Schema.SchemaProperties item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is Schema.SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = null;
        }
        public Schema(Schema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Schema.ValidatedArrayOfSchemaOrReference? allof, Schema.ValidatedArrayOfSchemaOrReference? anyof, Schema.ValidatedArrayOfSchemaOrReference? oneof, Schema.SchemaOrReference? not, Schema.PositiveInteger? multipleof, Menes.JsonInteger? maximum, Menes.JsonInteger? exclusivemaximum, Menes.JsonInteger? minimum, Menes.JsonInteger? exclusiveminimum, Schema.NonNegativeInteger? maxlength, Schema.NonNegativeInteger? minlength, Menes.JsonString? pattern, Schema.NonNegativeInteger? maxitems, Schema.NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, Schema.NonNegativeInteger? maxcontains, Schema.SchemaOrReference? items, Schema.SchemaOrReference? contains, Schema.NonNegativeInteger? maxproperties, Schema.NonNegativeInteger? minproperties, Schema.ValidatedArrayOfJsonString? required, Schema.SchemaProperties? properties, Schema.SchemaAdditionalProperties? additionalproperties, (string, Menes.JsonAny) additionalProperty1)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is Schema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is Schema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is Schema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is Schema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            this.multipleof = multipleof;
            this.maximum = maximum;
            this.exclusivemaximum = exclusivemaximum;
            this.minimum = minimum;
            this.exclusiveminimum = exclusiveminimum;
            this.maxlength = maxlength;
            this.minlength = minlength;
            this.pattern = pattern;
            this.maxitems = maxitems;
            this.minitems = minitems;
            this.uniqueitems = uniqueitems;
            this.maxcontains = maxcontains;
            if (items is Schema.SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is Schema.SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is Schema.ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is Schema.SchemaProperties item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is Schema.SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public Schema(Schema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Schema.ValidatedArrayOfSchemaOrReference? allof, Schema.ValidatedArrayOfSchemaOrReference? anyof, Schema.ValidatedArrayOfSchemaOrReference? oneof, Schema.SchemaOrReference? not, Schema.PositiveInteger? multipleof, Menes.JsonInteger? maximum, Menes.JsonInteger? exclusivemaximum, Menes.JsonInteger? minimum, Menes.JsonInteger? exclusiveminimum, Schema.NonNegativeInteger? maxlength, Schema.NonNegativeInteger? minlength, Menes.JsonString? pattern, Schema.NonNegativeInteger? maxitems, Schema.NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, Schema.NonNegativeInteger? maxcontains, Schema.SchemaOrReference? items, Schema.SchemaOrReference? contains, Schema.NonNegativeInteger? maxproperties, Schema.NonNegativeInteger? minproperties, Schema.ValidatedArrayOfJsonString? required, Schema.SchemaProperties? properties, Schema.SchemaAdditionalProperties? additionalproperties, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is Schema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is Schema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is Schema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is Schema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            this.multipleof = multipleof;
            this.maximum = maximum;
            this.exclusivemaximum = exclusivemaximum;
            this.minimum = minimum;
            this.exclusiveminimum = exclusiveminimum;
            this.maxlength = maxlength;
            this.minlength = minlength;
            this.pattern = pattern;
            this.maxitems = maxitems;
            this.minitems = minitems;
            this.uniqueitems = uniqueitems;
            this.maxcontains = maxcontains;
            if (items is Schema.SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is Schema.SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is Schema.ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is Schema.SchemaProperties item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is Schema.SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public Schema(Schema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Schema.ValidatedArrayOfSchemaOrReference? allof, Schema.ValidatedArrayOfSchemaOrReference? anyof, Schema.ValidatedArrayOfSchemaOrReference? oneof, Schema.SchemaOrReference? not, Schema.PositiveInteger? multipleof, Menes.JsonInteger? maximum, Menes.JsonInteger? exclusivemaximum, Menes.JsonInteger? minimum, Menes.JsonInteger? exclusiveminimum, Schema.NonNegativeInteger? maxlength, Schema.NonNegativeInteger? minlength, Menes.JsonString? pattern, Schema.NonNegativeInteger? maxitems, Schema.NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, Schema.NonNegativeInteger? maxcontains, Schema.SchemaOrReference? items, Schema.SchemaOrReference? contains, Schema.NonNegativeInteger? maxproperties, Schema.NonNegativeInteger? minproperties, Schema.ValidatedArrayOfJsonString? required, Schema.SchemaProperties? properties, Schema.SchemaAdditionalProperties? additionalproperties, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is Schema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is Schema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is Schema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is Schema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            this.multipleof = multipleof;
            this.maximum = maximum;
            this.exclusivemaximum = exclusivemaximum;
            this.minimum = minimum;
            this.exclusiveminimum = exclusiveminimum;
            this.maxlength = maxlength;
            this.minlength = minlength;
            this.pattern = pattern;
            this.maxitems = maxitems;
            this.minitems = minitems;
            this.uniqueitems = uniqueitems;
            this.maxcontains = maxcontains;
            if (items is Schema.SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is Schema.SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is Schema.ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is Schema.SchemaProperties item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is Schema.SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public Schema(Schema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Schema.ValidatedArrayOfSchemaOrReference? allof, Schema.ValidatedArrayOfSchemaOrReference? anyof, Schema.ValidatedArrayOfSchemaOrReference? oneof, Schema.SchemaOrReference? not, Schema.PositiveInteger? multipleof, Menes.JsonInteger? maximum, Menes.JsonInteger? exclusivemaximum, Menes.JsonInteger? minimum, Menes.JsonInteger? exclusiveminimum, Schema.NonNegativeInteger? maxlength, Schema.NonNegativeInteger? minlength, Menes.JsonString? pattern, Schema.NonNegativeInteger? maxitems, Schema.NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, Schema.NonNegativeInteger? maxcontains, Schema.SchemaOrReference? items, Schema.SchemaOrReference? contains, Schema.NonNegativeInteger? maxproperties, Schema.NonNegativeInteger? minproperties, Schema.ValidatedArrayOfJsonString? required, Schema.SchemaProperties? properties, Schema.SchemaAdditionalProperties? additionalproperties, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is Schema.ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is Schema.ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is Schema.ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is Schema.SchemaOrReference item4)
            {
                this.not = Menes.JsonReference.FromValue(item4);
            }
            else
            {
                this.not = null;
            }
            this.multipleof = multipleof;
            this.maximum = maximum;
            this.exclusivemaximum = exclusivemaximum;
            this.minimum = minimum;
            this.exclusiveminimum = exclusiveminimum;
            this.maxlength = maxlength;
            this.minlength = minlength;
            this.pattern = pattern;
            this.maxitems = maxitems;
            this.minitems = minitems;
            this.uniqueitems = uniqueitems;
            this.maxcontains = maxcontains;
            if (items is Schema.SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is Schema.SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is Schema.ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is Schema.SchemaProperties item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is Schema.SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private Schema(Schema.TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Menes.JsonReference? allof, Menes.JsonReference? anyof, Menes.JsonReference? oneof, Menes.JsonReference? not, Schema.PositiveInteger? multipleof, Menes.JsonInteger? maximum, Menes.JsonInteger? exclusivemaximum, Menes.JsonInteger? minimum, Menes.JsonInteger? exclusiveminimum, Schema.NonNegativeInteger? maxlength, Schema.NonNegativeInteger? minlength, Menes.JsonString? pattern, Schema.NonNegativeInteger? maxitems, Schema.NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, Schema.NonNegativeInteger? maxcontains, Menes.JsonReference? items, Menes.JsonReference? contains, Schema.NonNegativeInteger? maxproperties, Schema.NonNegativeInteger? minproperties, Menes.JsonReference? required, Menes.JsonReference? properties, Menes.JsonReference? additionalproperties, Menes.JsonProperties<Menes.JsonAny>? additionalProperties)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is Menes.JsonReference item1)
            {
                this.allof = item1;
            }
            else
            {
                this.allof = null;
            }
            if (anyof is Menes.JsonReference item2)
            {
                this.anyof = item2;
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is Menes.JsonReference item3)
            {
                this.oneof = item3;
            }
            else
            {
                this.oneof = null;
            }
            if (not is Menes.JsonReference item4)
            {
                this.not = item4;
            }
            else
            {
                this.not = null;
            }
            this.multipleof = multipleof;
            this.maximum = maximum;
            this.exclusivemaximum = exclusivemaximum;
            this.minimum = minimum;
            this.exclusiveminimum = exclusiveminimum;
            this.maxlength = maxlength;
            this.minlength = minlength;
            this.pattern = pattern;
            this.maxitems = maxitems;
            this.minitems = minitems;
            this.uniqueitems = uniqueitems;
            this.maxcontains = maxcontains;
            if (items is Menes.JsonReference item5)
            {
                this.items = item5;
            }
            else
            {
                this.items = null;
            }
            if (contains is Menes.JsonReference item6)
            {
                this.contains = item6;
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is Menes.JsonReference item7)
            {
                this.required = item7;
            }
            else
            {
                this.required = null;
            }
            if (properties is Menes.JsonReference item8)
            {
                this.properties = item8;
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is Menes.JsonReference item9)
            {
                this.additionalproperties = item9;
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = additionalProperties;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.type is null || this.type.Value.IsNull) && (this.format is null || this.format.Value.IsNull) && (this.@enum is null || this.@enum.Value.IsNull) && (this.@const is null || this.@const.Value.IsNull) && (this.allof is null || this.allof.Value.IsNull) && (this.anyof is null || this.anyof.Value.IsNull) && (this.oneof is null || this.oneof.Value.IsNull) && (this.not is null || this.not.Value.IsNull) && (this.multipleof is null || this.multipleof.Value.IsNull) && (this.maximum is null || this.maximum.Value.IsNull) && (this.exclusivemaximum is null || this.exclusivemaximum.Value.IsNull) && (this.minimum is null || this.minimum.Value.IsNull) && (this.exclusiveminimum is null || this.exclusiveminimum.Value.IsNull) && (this.maxlength is null || this.maxlength.Value.IsNull) && (this.minlength is null || this.minlength.Value.IsNull) && (this.pattern is null || this.pattern.Value.IsNull) && (this.maxitems is null || this.maxitems.Value.IsNull) && (this.minitems is null || this.minitems.Value.IsNull) && (this.uniqueitems is null || this.uniqueitems.Value.IsNull) && (this.maxcontains is null || this.maxcontains.Value.IsNull) && (this.items is null || this.items.Value.IsNull) && (this.contains is null || this.contains.Value.IsNull) && (this.maxproperties is null || this.maxproperties.Value.IsNull) && (this.minproperties is null || this.minproperties.Value.IsNull) && (this.required is null || this.required.Value.IsNull) && (this.properties is null || this.properties.Value.IsNull) && (this.additionalproperties is null || this.additionalproperties.Value.IsNull);
        public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
        public Schema.TypeEnum? Type => this.type ?? Schema.TypeEnum.FromOptionalProperty(this.JsonElement, TypePropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Format => this.format ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, FormatPropertyNameBytes.Span).AsOptional;
        public Menes.JsonArray<Menes.JsonAny>? Enum => this.@enum ?? Menes.JsonArray<Menes.JsonAny>.FromOptionalProperty(this.JsonElement, EnumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonAny? Const => this.@const ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, ConstPropertyNameBytes.Span).AsOptional;
        public Schema.ValidatedArrayOfSchemaOrReference? Allof => this.allof?.AsValue<Schema.ValidatedArrayOfSchemaOrReference>() ?? Schema.ValidatedArrayOfSchemaOrReference.FromOptionalProperty(this.JsonElement, AllofPropertyNameBytes.Span).AsOptional;
        public Schema.ValidatedArrayOfSchemaOrReference? Anyof => this.anyof?.AsValue<Schema.ValidatedArrayOfSchemaOrReference>() ?? Schema.ValidatedArrayOfSchemaOrReference.FromOptionalProperty(this.JsonElement, AnyofPropertyNameBytes.Span).AsOptional;
        public Schema.ValidatedArrayOfSchemaOrReference? Oneof => this.oneof?.AsValue<Schema.ValidatedArrayOfSchemaOrReference>() ?? Schema.ValidatedArrayOfSchemaOrReference.FromOptionalProperty(this.JsonElement, OneofPropertyNameBytes.Span).AsOptional;
        public Schema.SchemaOrReference? Not => this.not?.AsValue<Schema.SchemaOrReference>() ?? Schema.SchemaOrReference.FromOptionalProperty(this.JsonElement, NotPropertyNameBytes.Span).AsOptional;
        public Schema.PositiveInteger? Multipleof => this.multipleof ?? Schema.PositiveInteger.FromOptionalProperty(this.JsonElement, MultipleofPropertyNameBytes.Span).AsOptional;
        public Menes.JsonInteger? Maximum => this.maximum ?? Menes.JsonInteger.FromOptionalProperty(this.JsonElement, MaximumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonInteger? Exclusivemaximum => this.exclusivemaximum ?? Menes.JsonInteger.FromOptionalProperty(this.JsonElement, ExclusivemaximumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonInteger? Minimum => this.minimum ?? Menes.JsonInteger.FromOptionalProperty(this.JsonElement, MinimumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonInteger? Exclusiveminimum => this.exclusiveminimum ?? Menes.JsonInteger.FromOptionalProperty(this.JsonElement, ExclusiveminimumPropertyNameBytes.Span).AsOptional;
        public Schema.NonNegativeInteger? Maxlength => this.maxlength ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxlengthPropertyNameBytes.Span).AsOptional;
        public Schema.NonNegativeInteger? Minlength => this.minlength ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinlengthPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Pattern => this.pattern ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, PatternPropertyNameBytes.Span).AsOptional;
        public Schema.NonNegativeInteger? Maxitems => this.maxitems ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxitemsPropertyNameBytes.Span).AsOptional;
        public Schema.NonNegativeInteger? Minitems => this.minitems ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinitemsPropertyNameBytes.Span).AsOptional;
        public Menes.JsonBoolean? Uniqueitems => this.uniqueitems ?? Menes.JsonBoolean.FromOptionalProperty(this.JsonElement, UniqueitemsPropertyNameBytes.Span).AsOptional;
        public Schema.NonNegativeInteger? Maxcontains => this.maxcontains ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxcontainsPropertyNameBytes.Span).AsOptional;
        public Schema.SchemaOrReference? Items => this.items?.AsValue<Schema.SchemaOrReference>() ?? Schema.SchemaOrReference.FromOptionalProperty(this.JsonElement, ItemsPropertyNameBytes.Span).AsOptional;
        public Schema.SchemaOrReference? Contains => this.contains?.AsValue<Schema.SchemaOrReference>() ?? Schema.SchemaOrReference.FromOptionalProperty(this.JsonElement, ContainsPropertyNameBytes.Span).AsOptional;
        public Schema.NonNegativeInteger? Maxproperties => this.maxproperties ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxpropertiesPropertyNameBytes.Span).AsOptional;
        public Schema.NonNegativeInteger? Minproperties => this.minproperties ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinpropertiesPropertyNameBytes.Span).AsOptional;
        public Schema.ValidatedArrayOfJsonString? Required => this.required?.AsValue<Schema.ValidatedArrayOfJsonString>() ?? Schema.ValidatedArrayOfJsonString.FromOptionalProperty(this.JsonElement, RequiredPropertyNameBytes.Span).AsOptional;
        public Schema.SchemaProperties? Properties => this.properties?.AsValue<Schema.SchemaProperties>() ?? Schema.SchemaProperties.FromOptionalProperty(this.JsonElement, PropertiesPropertyNameBytes.Span).AsOptional;
        public Schema.SchemaAdditionalProperties? Additionalproperties => this.additionalproperties?.AsValue<Schema.SchemaAdditionalProperties>() ?? Schema.SchemaAdditionalProperties.FromOptionalProperty(this.JsonElement, AdditionalpropertiesPropertyNameBytes.Span).AsOptional;
        public int PropertiesCount => KnownProperties.Length + this.AdditionalPropertiesCount;
        public int AdditionalPropertiesCount
        {
            get
            {
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.AdditionalProperties;
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
        public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator AdditionalProperties
        {
            get
            {
                if (this.additionalProperties is Menes.JsonProperties<Menes.JsonAny> ap)
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
        public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null;
        public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null;
        public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null;
        public Schema WithType(Schema.TypeEnum? value)
        {
            return new Schema(value, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithFormat(Menes.JsonString? value)
        {
            return new Schema(this.Type, value, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithEnum(Menes.JsonArray<Menes.JsonAny>? value)
        {
            return new Schema(this.Type, this.Format, value, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithConst(Menes.JsonAny? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, value, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithAllof(Schema.ValidatedArrayOfSchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, Menes.JsonReference.FromValue(value), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithAnyof(Schema.ValidatedArrayOfSchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), Menes.JsonReference.FromValue(value), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithOneof(Schema.ValidatedArrayOfSchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), Menes.JsonReference.FromValue(value), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithNot(Schema.SchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), Menes.JsonReference.FromValue(value), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMultipleof(Schema.PositiveInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), value, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMaximum(Menes.JsonInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, value, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithExclusivemaximum(Menes.JsonInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, value, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMinimum(Menes.JsonInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, value, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithExclusiveminimum(Menes.JsonInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, value, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMaxlength(Schema.NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, value, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMinlength(Schema.NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, value, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithPattern(Menes.JsonString? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, value, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMaxitems(Schema.NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, value, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMinitems(Schema.NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, value, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithUniqueitems(Menes.JsonBoolean? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, value, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMaxcontains(Schema.NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, value, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithItems(Schema.SchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, Menes.JsonReference.FromValue(value), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithContains(Schema.SchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), Menes.JsonReference.FromValue(value), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMaxproperties(Schema.NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), value, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMinproperties(Schema.NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, value, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithRequired(Schema.ValidatedArrayOfJsonString? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, Menes.JsonReference.FromValue(value), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithProperties(Schema.SchemaProperties? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), Menes.JsonReference.FromValue(value), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithAdditionalproperties(Schema.SchemaAdditionalProperties? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), Menes.JsonReference.FromValue(value), this.GetJsonProperties());
        }
        public Schema WithAdditionalProperties(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), newAdditional);
        }
        public Schema WithAdditionalProperties(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Schema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Schema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Schema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Schema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                if (this.type is Schema.TypeEnum type)
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
                if (this.allof is Menes.JsonReference allof)
                {
                    writer.WritePropertyName(EncodedAllofPropertyName);
                    allof.WriteTo(writer);
                }
                if (this.anyof is Menes.JsonReference anyof)
                {
                    writer.WritePropertyName(EncodedAnyofPropertyName);
                    anyof.WriteTo(writer);
                }
                if (this.oneof is Menes.JsonReference oneof)
                {
                    writer.WritePropertyName(EncodedOneofPropertyName);
                    oneof.WriteTo(writer);
                }
                if (this.not is Menes.JsonReference not)
                {
                    writer.WritePropertyName(EncodedNotPropertyName);
                    not.WriteTo(writer);
                }
                if (this.multipleof is Schema.PositiveInteger multipleof)
                {
                    writer.WritePropertyName(EncodedMultipleofPropertyName);
                    multipleof.WriteTo(writer);
                }
                if (this.maximum is Menes.JsonInteger maximum)
                {
                    writer.WritePropertyName(EncodedMaximumPropertyName);
                    maximum.WriteTo(writer);
                }
                if (this.exclusivemaximum is Menes.JsonInteger exclusivemaximum)
                {
                    writer.WritePropertyName(EncodedExclusivemaximumPropertyName);
                    exclusivemaximum.WriteTo(writer);
                }
                if (this.minimum is Menes.JsonInteger minimum)
                {
                    writer.WritePropertyName(EncodedMinimumPropertyName);
                    minimum.WriteTo(writer);
                }
                if (this.exclusiveminimum is Menes.JsonInteger exclusiveminimum)
                {
                    writer.WritePropertyName(EncodedExclusiveminimumPropertyName);
                    exclusiveminimum.WriteTo(writer);
                }
                if (this.maxlength is Schema.NonNegativeInteger maxlength)
                {
                    writer.WritePropertyName(EncodedMaxlengthPropertyName);
                    maxlength.WriteTo(writer);
                }
                if (this.minlength is Schema.NonNegativeInteger minlength)
                {
                    writer.WritePropertyName(EncodedMinlengthPropertyName);
                    minlength.WriteTo(writer);
                }
                if (this.pattern is Menes.JsonString pattern)
                {
                    writer.WritePropertyName(EncodedPatternPropertyName);
                    pattern.WriteTo(writer);
                }
                if (this.maxitems is Schema.NonNegativeInteger maxitems)
                {
                    writer.WritePropertyName(EncodedMaxitemsPropertyName);
                    maxitems.WriteTo(writer);
                }
                if (this.minitems is Schema.NonNegativeInteger minitems)
                {
                    writer.WritePropertyName(EncodedMinitemsPropertyName);
                    minitems.WriteTo(writer);
                }
                if (this.uniqueitems is Menes.JsonBoolean uniqueitems)
                {
                    writer.WritePropertyName(EncodedUniqueitemsPropertyName);
                    uniqueitems.WriteTo(writer);
                }
                if (this.maxcontains is Schema.NonNegativeInteger maxcontains)
                {
                    writer.WritePropertyName(EncodedMaxcontainsPropertyName);
                    maxcontains.WriteTo(writer);
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
                if (this.maxproperties is Schema.NonNegativeInteger maxproperties)
                {
                    writer.WritePropertyName(EncodedMaxpropertiesPropertyName);
                    maxproperties.WriteTo(writer);
                }
                if (this.minproperties is Schema.NonNegativeInteger minproperties)
                {
                    writer.WritePropertyName(EncodedMinpropertiesPropertyName);
                    minproperties.WriteTo(writer);
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
                if (this.additionalproperties is Menes.JsonReference additionalproperties)
                {
                    writer.WritePropertyName(EncodedAdditionalpropertiesPropertyName);
                    additionalproperties.WriteTo(writer);
                }
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.AdditionalProperties;
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(Schema other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }
            if (this.HasJsonElement && other.HasJsonElement)
            {
                return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
            }
            return this.Type.Equals(other.Type) && this.Format.Equals(other.Format) && this.Enum.Equals(other.Enum) && this.Const.Equals(other.Const) && this.Allof.Equals(other.Allof) && this.Anyof.Equals(other.Anyof) && this.Oneof.Equals(other.Oneof) && this.Not.Equals(other.Not) && this.Multipleof.Equals(other.Multipleof) && this.Maximum.Equals(other.Maximum) && this.Exclusivemaximum.Equals(other.Exclusivemaximum) && this.Minimum.Equals(other.Minimum) && this.Exclusiveminimum.Equals(other.Exclusiveminimum) && this.Maxlength.Equals(other.Maxlength) && this.Minlength.Equals(other.Minlength) && this.Pattern.Equals(other.Pattern) && this.Maxitems.Equals(other.Maxitems) && this.Minitems.Equals(other.Minitems) && this.Uniqueitems.Equals(other.Uniqueitems) && this.Maxcontains.Equals(other.Maxcontains) && this.Items.Equals(other.Items) && this.Contains.Equals(other.Contains) && this.Maxproperties.Equals(other.Maxproperties) && this.Minproperties.Equals(other.Minproperties) && this.Required.Equals(other.Required) && this.Properties.Equals(other.Properties) && this.Additionalproperties.Equals(other.Additionalproperties) && System.Linq.Enumerable.SequenceEqual(this.AdditionalProperties, other.AdditionalProperties);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.ValidationContext context = validationContext;
            if (this.Type is Schema.TypeEnum type)
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
            if (this.Allof is Schema.ValidatedArrayOfSchemaOrReference allof)
            {
                context = Menes.Validation.ValidateProperty(context, allof, AllofPropertyNamePath);
            }
            if (this.Anyof is Schema.ValidatedArrayOfSchemaOrReference anyof)
            {
                context = Menes.Validation.ValidateProperty(context, anyof, AnyofPropertyNamePath);
            }
            if (this.Oneof is Schema.ValidatedArrayOfSchemaOrReference oneof)
            {
                context = Menes.Validation.ValidateProperty(context, oneof, OneofPropertyNamePath);
            }
            if (this.Not is Schema.SchemaOrReference not)
            {
                context = Menes.Validation.ValidateProperty(context, not, NotPropertyNamePath);
            }
            if (this.Multipleof is Schema.PositiveInteger multipleof)
            {
                context = Menes.Validation.ValidateProperty(context, multipleof, MultipleofPropertyNamePath);
            }
            if (this.Maximum is Menes.JsonInteger maximum)
            {
                context = Menes.Validation.ValidateProperty(context, maximum, MaximumPropertyNamePath);
            }
            if (this.Exclusivemaximum is Menes.JsonInteger exclusivemaximum)
            {
                context = Menes.Validation.ValidateProperty(context, exclusivemaximum, ExclusivemaximumPropertyNamePath);
            }
            if (this.Minimum is Menes.JsonInteger minimum)
            {
                context = Menes.Validation.ValidateProperty(context, minimum, MinimumPropertyNamePath);
            }
            if (this.Exclusiveminimum is Menes.JsonInteger exclusiveminimum)
            {
                context = Menes.Validation.ValidateProperty(context, exclusiveminimum, ExclusiveminimumPropertyNamePath);
            }
            if (this.Maxlength is Schema.NonNegativeInteger maxlength)
            {
                context = Menes.Validation.ValidateProperty(context, maxlength, MaxlengthPropertyNamePath);
            }
            if (this.Minlength is Schema.NonNegativeInteger minlength)
            {
                context = Menes.Validation.ValidateProperty(context, minlength, MinlengthPropertyNamePath);
            }
            if (this.Pattern is Menes.JsonString pattern)
            {
                context = Menes.Validation.ValidateProperty(context, pattern, PatternPropertyNamePath);
            }
            if (this.Maxitems is Schema.NonNegativeInteger maxitems)
            {
                context = Menes.Validation.ValidateProperty(context, maxitems, MaxitemsPropertyNamePath);
            }
            if (this.Minitems is Schema.NonNegativeInteger minitems)
            {
                context = Menes.Validation.ValidateProperty(context, minitems, MinitemsPropertyNamePath);
            }
            if (this.Uniqueitems is Menes.JsonBoolean uniqueitems)
            {
                context = Menes.Validation.ValidateProperty(context, uniqueitems, UniqueitemsPropertyNamePath);
            }
            if (this.Maxcontains is Schema.NonNegativeInteger maxcontains)
            {
                context = Menes.Validation.ValidateProperty(context, maxcontains, MaxcontainsPropertyNamePath);
            }
            if (this.Items is Schema.SchemaOrReference items)
            {
                context = Menes.Validation.ValidateProperty(context, items, ItemsPropertyNamePath);
            }
            if (this.Contains is Schema.SchemaOrReference contains)
            {
                context = Menes.Validation.ValidateProperty(context, contains, ContainsPropertyNamePath);
            }
            if (this.Maxproperties is Schema.NonNegativeInteger maxproperties)
            {
                context = Menes.Validation.ValidateProperty(context, maxproperties, MaxpropertiesPropertyNamePath);
            }
            if (this.Minproperties is Schema.NonNegativeInteger minproperties)
            {
                context = Menes.Validation.ValidateProperty(context, minproperties, MinpropertiesPropertyNamePath);
            }
            if (this.Required is Schema.ValidatedArrayOfJsonString required)
            {
                context = Menes.Validation.ValidateProperty(context, required, RequiredPropertyNamePath);
            }
            if (this.Properties is Schema.SchemaProperties properties)
            {
                context = Menes.Validation.ValidateProperty(context, properties, PropertiesPropertyNamePath);
            }
            if (this.Additionalproperties is Schema.SchemaAdditionalProperties additionalproperties)
            {
                context = Menes.Validation.ValidateProperty(context, additionalproperties, AdditionalpropertiesPropertyNamePath);
            }
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.AdditionalProperties)
            {
                context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
            }
            return context;
        }
        public bool TryGetAdditionalProperty(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny? value)
        {
            return this.TryGetAdditionalProperty(System.MemoryExtensions.AsSpan(propertyName), out value);
        }
        public bool TryGetAdditionalProperty(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny? value)
        {
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.AdditionalProperties)
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
        private Menes.JsonReference? GetAllof()
        {
            if (this.allof is Menes.JsonReference)
            {
                return this.allof;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(AllofPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetAnyof()
        {
            if (this.anyof is Menes.JsonReference)
            {
                return this.anyof;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(AnyofPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetOneof()
        {
            if (this.oneof is Menes.JsonReference)
            {
                return this.oneof;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(OneofPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
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
        private Menes.JsonReference? GetAdditionalproperties()
        {
            if (this.additionalproperties is Menes.JsonReference)
            {
                return this.additionalproperties;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(AdditionalpropertiesPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
        {
            if (this.additionalProperties is Menes.JsonProperties<Menes.JsonAny> props)
            {
                return props;
            }
            return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.AdditionalProperties));
        }

        public readonly struct SchemaReference : Menes.IJsonObject, System.IEquatable<Schema.SchemaReference>
        {
            public static readonly Schema.SchemaReference Null = new Schema.SchemaReference(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, Schema.SchemaReference> FromJsonElement = e => new Schema.SchemaReference(e);
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
            public Schema.SchemaReference? AsOptional => this.IsNull ? default(Schema.SchemaReference?) : this;
            public Menes.JsonString Ref => this.@ref ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, RefPropertyNameBytes.Span);
            public int PropertiesCount => KnownProperties.Length;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static Schema.SchemaReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.SchemaReference(property)
                    : Null;
            public static Schema.SchemaReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.SchemaReference(property)
                    : Null;
            public static Schema.SchemaReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.SchemaReference(property)
                    : Null;
            public Schema.SchemaReference WithRef(Menes.JsonString value)
            {
                return new Schema.SchemaReference(value);
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
            public bool Equals(Schema.SchemaReference other)
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
            public static readonly System.Func<System.Text.Json.JsonElement, Schema.SchemaOrReference> FromJsonElement = e => new Schema.SchemaOrReference(e);
            private readonly Menes.JsonReference? item1;
            private readonly Menes.JsonReference? item2;
            public SchemaOrReference(Schema clrInstance)
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
            public SchemaOrReference(Schema.SchemaReference clrInstance)
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
            public bool IsSchema => this.item1 is Menes.JsonReference || Schema.IsConvertibleFrom(this.JsonElement);
            public bool IsSchemaReference => this.item2 is Menes.JsonReference || Schema.SchemaReference.IsConvertibleFrom(this.JsonElement);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator Schema(SchemaOrReference value) => value.AsSchema();
            public static implicit operator SchemaOrReference(Schema value) => new SchemaOrReference(value);
            public static explicit operator Schema.SchemaReference(SchemaOrReference value) => value.AsSchemaReference();
            public static implicit operator SchemaOrReference(Schema.SchemaReference value) => new SchemaOrReference(value);
            public static SchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaOrReference(property)
                    : Null;
            public static SchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaOrReference(property)
                    : Null;
            public static SchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaOrReference(property)
                    : Null;
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                if (Schema.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                if (Schema.SchemaReference.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                return false;
            }
            public Schema AsSchema() => this.item1?.AsValue<Schema>() ?? new Schema(this.JsonElement);
            public Schema.SchemaReference AsSchemaReference() => this.item2?.AsValue<Schema.SchemaReference>() ?? new Schema.SchemaReference(this.JsonElement);
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
                if (this.IsSchema)
                {
                    builder.Append("{");
                    builder.Append("Schema");
                    builder.Append(", ");
                    builder.Append(this.AsSchema().ToString());
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
                if (this.IsSchema)
                {
                    validationContext1 = this.AsSchema().Validate(validationContext1);
                }
                else
                {
                    validationContext1 = validationContext1.WithError("The value is not convertible to a Schema.");
                }
                if (this.IsSchemaReference)
                {
                    validationContext2 = this.AsSchemaReference().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a Schema.SchemaReference.");
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
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? TypeEnum.FromJsonElement(property)
                    : Null;
            public static TypeEnum FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? TypeEnum.FromJsonElement(property)
                    : Null;
            public static TypeEnum FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? TypeEnum.FromJsonElement(property)
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
        public readonly struct PositiveInteger : Menes.IJsonValue, System.IEquatable<PositiveInteger>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, PositiveInteger> FromJsonElement = e => new PositiveInteger(e);
            public static readonly PositiveInteger Null = new PositiveInteger(default(System.Text.Json.JsonElement));
            private static readonly Menes.JsonInteger? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>? EnumValues = BuildEnumValues();
            private static readonly Menes.JsonInteger? MultipleOf = null;
            private static readonly Menes.JsonInteger? Maximum = null;
            private static readonly Menes.JsonInteger? ExclusiveMaximum = null;
            private static readonly Menes.JsonInteger? Minimum = null;
            private static readonly Menes.JsonInteger? ExclusiveMinimum = 0;
            private readonly Menes.JsonInteger? value;
            public PositiveInteger(Menes.JsonInteger value)
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
            public PositiveInteger(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public PositiveInteger? AsOptional => this.IsNull ? default(PositiveInteger?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator PositiveInteger(Menes.JsonInteger value)
            {
                return new PositiveInteger(value);
            }
            public static implicit operator PositiveInteger(int value)
            {
                return new PositiveInteger(value);
            }
            public static implicit operator PositiveInteger(long value)
            {
                return new PositiveInteger(value);
            }
            public static implicit operator Menes.JsonInteger(PositiveInteger value)
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
            public static PositiveInteger FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? PositiveInteger.FromJsonElement(property)
                    : Null;
            public static PositiveInteger FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? PositiveInteger.FromJsonElement(property)
                    : Null;
            public static PositiveInteger FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? PositiveInteger.FromJsonElement(property)
                    : Null;
            public bool Equals(PositiveInteger other)
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
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? NonNegativeInteger.FromJsonElement(property)
                    : Null;
            public static NonNegativeInteger FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? NonNegativeInteger.FromJsonElement(property)
                    : Null;
            public static NonNegativeInteger FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? NonNegativeInteger.FromJsonElement(property)
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
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? ValidatedArrayOfJsonString.FromJsonElement(property)
                    : Null;
            public static ValidatedArrayOfJsonString FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? ValidatedArrayOfJsonString.FromJsonElement(property)
                    : Null;
            public static ValidatedArrayOfJsonString FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? ValidatedArrayOfJsonString.FromJsonElement(property)
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
        public readonly struct ValidatedArrayOfSchemaOrReference : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Schema.SchemaOrReference>, System.Collections.IEnumerable, System.IEquatable<ValidatedArrayOfSchemaOrReference>, System.IEquatable<Menes.JsonArray<Schema.SchemaOrReference>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, ValidatedArrayOfSchemaOrReference> FromJsonElement = e => new ValidatedArrayOfSchemaOrReference(e);
            public static readonly ValidatedArrayOfSchemaOrReference Null = new ValidatedArrayOfSchemaOrReference(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<Schema.SchemaOrReference>? value;
            public ValidatedArrayOfSchemaOrReference(Menes.JsonArray<Schema.SchemaOrReference> jsonArray)
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
            public static implicit operator ValidatedArrayOfSchemaOrReference(Menes.JsonArray<Schema.SchemaOrReference> value)
            {
                return new ValidatedArrayOfSchemaOrReference(value);
            }
            public static implicit operator Menes.JsonArray<Schema.SchemaOrReference>(ValidatedArrayOfSchemaOrReference value)
            {
                if (value.value is Menes.JsonArray<Schema.SchemaOrReference> clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonArray<Schema.SchemaOrReference>(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonArray<Schema.SchemaOrReference>.IsConvertibleFrom(jsonElement);
            }
            public static ValidatedArrayOfSchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? ValidatedArrayOfSchemaOrReference.FromJsonElement(property)
                    : Null;
            public static ValidatedArrayOfSchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? ValidatedArrayOfSchemaOrReference.FromJsonElement(property)
                    : Null;
            public static ValidatedArrayOfSchemaOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? ValidatedArrayOfSchemaOrReference.FromJsonElement(property)
                    : Null;
            public bool Equals(ValidatedArrayOfSchemaOrReference other)
            {
                return this.Equals((Menes.JsonArray<Schema.SchemaOrReference>)other);
            }
            public bool Equals(Menes.JsonArray<Schema.SchemaOrReference> other)
            {
                return ((Menes.JsonArray<Schema.SchemaOrReference>)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonArray<Schema.SchemaOrReference> array = this;
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
                if (this.value is Menes.JsonArray<Schema.SchemaOrReference> clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public Menes.JsonArray<Schema.SchemaOrReference>.JsonArrayEnumerator GetEnumerator()
            {
                return ((Menes.JsonArray<Schema.SchemaOrReference>)this).GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Schema.SchemaOrReference> System.Collections.Generic.IEnumerable<Schema.SchemaOrReference>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public readonly struct SchemaProperties : Menes.IJsonObject, System.IEquatable<Schema.SchemaProperties>, Menes.IJsonAdditionalProperties<Schema.SchemaOrReference>
        {
            public static readonly Schema.SchemaProperties Null = new Schema.SchemaProperties(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, Schema.SchemaProperties> FromJsonElement = e => new Schema.SchemaProperties(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties<Schema.SchemaOrReference>? additionalProperties;
            public SchemaProperties(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalProperties = null;
            }
            public SchemaProperties(params (string, Schema.SchemaOrReference)[] additionalProperties)
            {
                this.JsonElement = default;
                this.additionalProperties = Menes.JsonProperties<Schema.SchemaOrReference>.FromValues(additionalProperties);
            }
            public SchemaProperties((string, Schema.SchemaOrReference) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalProperties = Menes.JsonProperties<Schema.SchemaOrReference>.FromValues(additionalProperty1);
            }
            public SchemaProperties((string, Schema.SchemaOrReference) additionalProperty1, (string, Schema.SchemaOrReference) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalProperties = Menes.JsonProperties<Schema.SchemaOrReference>.FromValues(additionalProperty1, additionalProperty2);
            }
            public SchemaProperties((string, Schema.SchemaOrReference) additionalProperty1, (string, Schema.SchemaOrReference) additionalProperty2, (string, Schema.SchemaOrReference) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalProperties = Menes.JsonProperties<Schema.SchemaOrReference>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public SchemaProperties((string, Schema.SchemaOrReference) additionalProperty1, (string, Schema.SchemaOrReference) additionalProperty2, (string, Schema.SchemaOrReference) additionalProperty3, (string, Schema.SchemaOrReference) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalProperties = Menes.JsonProperties<Schema.SchemaOrReference>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private SchemaProperties(Menes.JsonProperties<Schema.SchemaOrReference>? additionalProperties)
            {
                this.JsonElement = default;
                this.additionalProperties = additionalProperties;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public Schema.SchemaProperties? AsOptional => this.IsNull ? default(Schema.SchemaProperties?) : this;
            public int PropertiesCount => KnownProperties.Length + this.AdditionalPropertiesCount;
            public int AdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonProperties<Schema.SchemaOrReference>.JsonPropertyEnumerator enumerator = this.AdditionalProperties;
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
            public Menes.JsonProperties<Schema.SchemaOrReference>.JsonPropertyEnumerator AdditionalProperties
            {
                get
                {
                    if (this.additionalProperties is Menes.JsonProperties<Schema.SchemaOrReference> ap)
                    {
                        return new Menes.JsonProperties<Schema.SchemaOrReference>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<Schema.SchemaOrReference>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<Schema.SchemaOrReference>.JsonPropertyEnumerator(Menes.JsonProperties<Schema.SchemaOrReference>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static Schema.SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.SchemaProperties(property)
                    : Null;
            public static Schema.SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.SchemaProperties(property)
                    : Null;
            public static Schema.SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.SchemaProperties(property)
                    : Null;
            public Schema.SchemaProperties WithAdditionalProperties(Menes.JsonProperties<Schema.SchemaOrReference> newAdditional)
            {
                return new Schema.SchemaProperties(newAdditional);
            }
            public Schema.SchemaProperties WithAdditionalProperties(params (string, Schema.SchemaOrReference)[] newAdditional)
            {
                return new Schema.SchemaProperties(Menes.JsonProperties<Schema.SchemaOrReference>.FromValues(newAdditional));
            }
            public Schema.SchemaProperties WithAdditionalProperties((string, Schema.SchemaOrReference) newAdditional1)
            {
                return new Schema.SchemaProperties(Menes.JsonProperties<Schema.SchemaOrReference>.FromValues(newAdditional1));
            }
            public Schema.SchemaProperties WithAdditionalProperties((string, Schema.SchemaOrReference) newAdditional1, (string, Schema.SchemaOrReference) newAdditional2)
            {
                return new Schema.SchemaProperties(Menes.JsonProperties<Schema.SchemaOrReference>.FromValues(newAdditional1, newAdditional2));
            }
            public Schema.SchemaProperties WithAdditionalProperties((string, Schema.SchemaOrReference) newAdditional1, (string, Schema.SchemaOrReference) newAdditional2, (string, Schema.SchemaOrReference) newAdditional3)
            {
                return new Schema.SchemaProperties(Menes.JsonProperties<Schema.SchemaOrReference>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public Schema.SchemaProperties WithAdditionalProperties((string, Schema.SchemaOrReference) newAdditional1, (string, Schema.SchemaOrReference) newAdditional2, (string, Schema.SchemaOrReference) newAdditional3, (string, Schema.SchemaOrReference) newAdditional4)
            {
                return new Schema.SchemaProperties(Menes.JsonProperties<Schema.SchemaOrReference>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                    Menes.JsonProperties<Schema.SchemaOrReference>.JsonPropertyEnumerator enumerator = this.AdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(Schema.SchemaProperties other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return System.Linq.Enumerable.SequenceEqual(this.AdditionalProperties, other.AdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.ValidationContext context = validationContext;
                foreach (Menes.JsonPropertyReference<Schema.SchemaOrReference> property in this.AdditionalProperties)
                {
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
                return context;
            }
            public bool TryGetAdditionalProperty(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Schema.SchemaOrReference? value)
            {
                return this.TryGetAdditionalProperty(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGetAdditionalProperty(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Schema.SchemaOrReference? value)
            {
                foreach (Menes.JsonPropertyReference<Schema.SchemaOrReference> property in this.AdditionalProperties)
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
            public bool TryGetAdditionalProperty(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Schema.SchemaOrReference? value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGetAdditionalProperty(bytes.Slice(0, written), out value);
            }
            public override string? ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonProperties<Schema.SchemaOrReference> GetJsonProperties()
            {
                if (this.additionalProperties is Menes.JsonProperties<Schema.SchemaOrReference> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<Schema.SchemaOrReference>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.AdditionalProperties));
            }
        }

        public readonly struct SchemaAdditionalProperties : Menes.IJsonValue
        {
            public static readonly SchemaAdditionalProperties Null = new SchemaAdditionalProperties(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, Schema.SchemaAdditionalProperties> FromJsonElement = e => new Schema.SchemaAdditionalProperties(e);
            private readonly Menes.JsonReference? item1;
            private readonly Menes.JsonBoolean? item2;
            public SchemaAdditionalProperties(Schema.SchemaOrReference clrInstance)
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
            public bool IsSchemaOrReference => this.item1 is Menes.JsonReference || Schema.SchemaOrReference.IsConvertibleFrom(this.JsonElement);
            public bool IsJsonBoolean => this.item2 is Menes.JsonBoolean || Menes.JsonBoolean.IsConvertibleFrom(this.JsonElement);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator Schema.SchemaOrReference(SchemaAdditionalProperties value) => value.AsSchemaOrReference();
            public static implicit operator SchemaAdditionalProperties(Schema.SchemaOrReference value) => new SchemaAdditionalProperties(value);
            public static explicit operator Menes.JsonBoolean(SchemaAdditionalProperties value) => value.AsJsonBoolean();
            public static implicit operator SchemaAdditionalProperties(Menes.JsonBoolean value) => new SchemaAdditionalProperties(value);
            public static SchemaAdditionalProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaAdditionalProperties(property)
                    : Null;
            public static SchemaAdditionalProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaAdditionalProperties(property)
                    : Null;
            public static SchemaAdditionalProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaAdditionalProperties(property)
                    : Null;
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                if (Schema.SchemaOrReference.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                if (Menes.JsonBoolean.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                return false;
            }
            public Schema.SchemaOrReference AsSchemaOrReference() => this.item1?.AsValue<Schema.SchemaOrReference>() ?? new Schema.SchemaOrReference(this.JsonElement);
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
                    validationContext1 = validationContext1.WithError("The value is not convertible to a Schema.SchemaOrReference.");
                }
                if (this.IsJsonBoolean)
                {
                    validationContext2 = this.AsJsonBoolean().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a Menes.JsonBoolean.");
                }
                return Menes.Validation.ValidateOneOf(validationContext, ("Schema.SchemaOrReference", validationContext1), ("Menes.JsonBoolean", validationContext2));
            }
        }
    }
}
