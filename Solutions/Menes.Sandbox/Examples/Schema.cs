// <copyright file="Schema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <Generated />

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501, SA1119, IDE0047

namespace Examples
{
    public readonly struct Schema : Menes.IJsonObject, System.IEquatable<Schema>, Menes.IJsonAdditionalProperties
    {
        public static readonly Schema Null = new Schema(default);
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
        private readonly TypeEnum? type;
        private readonly Menes.JsonString? format;
        private readonly Menes.JsonArray<Menes.JsonAny>? @enum;
        private readonly Menes.JsonAny? @const;
        private readonly Menes.JsonReference? allof;
        private readonly Menes.JsonReference? anyof;
        private readonly Menes.JsonReference? oneof;
        private readonly Menes.JsonReference? not;
        private readonly PositiveInteger? multipleof;
        private readonly Menes.JsonInt64? maximum;
        private readonly Menes.JsonInt64? exclusivemaximum;
        private readonly Menes.JsonInt64? minimum;
        private readonly Menes.JsonInt64? exclusiveminimum;
        private readonly NonNegativeInteger? maxlength;
        private readonly NonNegativeInteger? minlength;
        private readonly Menes.JsonString? pattern;
        private readonly NonNegativeInteger? maxitems;
        private readonly NonNegativeInteger? minitems;
        private readonly Menes.JsonBoolean? uniqueitems;
        private readonly NonNegativeInteger? maxcontains;
        private readonly Menes.JsonReference? items;
        private readonly Menes.JsonReference? contains;
        private readonly NonNegativeInteger? maxproperties;
        private readonly NonNegativeInteger? minproperties;
        private readonly Menes.JsonReference? required;
        private readonly Menes.JsonReference? properties;
        private readonly Menes.JsonReference? additionalproperties;
        private readonly Menes.JsonProperties? additionalProperties;
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

        public Schema(TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, ValidatedArrayOfSchemaOrReference? allof, ValidatedArrayOfSchemaOrReference? anyof, ValidatedArrayOfSchemaOrReference? oneof, SchemaOrReference? not, PositiveInteger? multipleof, Menes.JsonInt64? maximum, Menes.JsonInt64? exclusivemaximum, Menes.JsonInt64? minimum, Menes.JsonInt64? exclusiveminimum, NonNegativeInteger? maxlength, NonNegativeInteger? minlength, Menes.JsonString? pattern, NonNegativeInteger? maxitems, NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, NonNegativeInteger? maxcontains, SchemaOrReference? items, SchemaOrReference? contains, NonNegativeInteger? maxproperties, NonNegativeInteger? minproperties, ValidatedArrayOfJsonString? required, SchemaPropertiesOrReference? properties, SchemaAdditionalProperties? additionalproperties, Menes.JsonProperties additionalProperties)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is SchemaOrReference item4)
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
            if (items is SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is SchemaPropertiesOrReference item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is SchemaAdditionalProperties item9)
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
        public Schema(TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, ValidatedArrayOfSchemaOrReference? allof, ValidatedArrayOfSchemaOrReference? anyof, ValidatedArrayOfSchemaOrReference? oneof, SchemaOrReference? not, PositiveInteger? multipleof, Menes.JsonInt64? maximum, Menes.JsonInt64? exclusivemaximum, Menes.JsonInt64? minimum, Menes.JsonInt64? exclusiveminimum, NonNegativeInteger? maxlength, NonNegativeInteger? minlength, Menes.JsonString? pattern, NonNegativeInteger? maxitems, NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, NonNegativeInteger? maxcontains, SchemaOrReference? items, SchemaOrReference? contains, NonNegativeInteger? maxproperties, NonNegativeInteger? minproperties, ValidatedArrayOfJsonString? required, SchemaPropertiesOrReference? properties, SchemaAdditionalProperties? additionalproperties, params (string, Menes.JsonAny)[] additionalProperties)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is SchemaOrReference item4)
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
            if (items is SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is SchemaPropertiesOrReference item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperties);
        }
        public Schema(TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, ValidatedArrayOfSchemaOrReference? allof, ValidatedArrayOfSchemaOrReference? anyof, ValidatedArrayOfSchemaOrReference? oneof, SchemaOrReference? not, PositiveInteger? multipleof, Menes.JsonInt64? maximum, Menes.JsonInt64? exclusivemaximum, Menes.JsonInt64? minimum, Menes.JsonInt64? exclusiveminimum, NonNegativeInteger? maxlength, NonNegativeInteger? minlength, Menes.JsonString? pattern, NonNegativeInteger? maxitems, NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, NonNegativeInteger? maxcontains, SchemaOrReference? items, SchemaOrReference? contains, NonNegativeInteger? maxproperties, NonNegativeInteger? minproperties, ValidatedArrayOfJsonString? required, SchemaPropertiesOrReference? properties, SchemaAdditionalProperties? additionalproperties)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is SchemaOrReference item4)
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
            if (items is SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is SchemaPropertiesOrReference item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is SchemaAdditionalProperties item9)
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
        public Schema(TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, ValidatedArrayOfSchemaOrReference? allof, ValidatedArrayOfSchemaOrReference? anyof, ValidatedArrayOfSchemaOrReference? oneof, SchemaOrReference? not, PositiveInteger? multipleof, Menes.JsonInt64? maximum, Menes.JsonInt64? exclusivemaximum, Menes.JsonInt64? minimum, Menes.JsonInt64? exclusiveminimum, NonNegativeInteger? maxlength, NonNegativeInteger? minlength, Menes.JsonString? pattern, NonNegativeInteger? maxitems, NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, NonNegativeInteger? maxcontains, SchemaOrReference? items, SchemaOrReference? contains, NonNegativeInteger? maxproperties, NonNegativeInteger? minproperties, ValidatedArrayOfJsonString? required, SchemaPropertiesOrReference? properties, SchemaAdditionalProperties? additionalproperties, (string, Menes.JsonAny) additionalProperty1)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is SchemaOrReference item4)
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
            if (items is SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is SchemaPropertiesOrReference item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1);
        }
        public Schema(TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, ValidatedArrayOfSchemaOrReference? allof, ValidatedArrayOfSchemaOrReference? anyof, ValidatedArrayOfSchemaOrReference? oneof, SchemaOrReference? not, PositiveInteger? multipleof, Menes.JsonInt64? maximum, Menes.JsonInt64? exclusivemaximum, Menes.JsonInt64? minimum, Menes.JsonInt64? exclusiveminimum, NonNegativeInteger? maxlength, NonNegativeInteger? minlength, Menes.JsonString? pattern, NonNegativeInteger? maxitems, NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, NonNegativeInteger? maxcontains, SchemaOrReference? items, SchemaOrReference? contains, NonNegativeInteger? maxproperties, NonNegativeInteger? minproperties, ValidatedArrayOfJsonString? required, SchemaPropertiesOrReference? properties, SchemaAdditionalProperties? additionalproperties, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is SchemaOrReference item4)
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
            if (items is SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is SchemaPropertiesOrReference item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1, additionalProperty2);
        }
        public Schema(TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, ValidatedArrayOfSchemaOrReference? allof, ValidatedArrayOfSchemaOrReference? anyof, ValidatedArrayOfSchemaOrReference? oneof, SchemaOrReference? not, PositiveInteger? multipleof, Menes.JsonInt64? maximum, Menes.JsonInt64? exclusivemaximum, Menes.JsonInt64? minimum, Menes.JsonInt64? exclusiveminimum, NonNegativeInteger? maxlength, NonNegativeInteger? minlength, Menes.JsonString? pattern, NonNegativeInteger? maxitems, NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, NonNegativeInteger? maxcontains, SchemaOrReference? items, SchemaOrReference? contains, NonNegativeInteger? maxproperties, NonNegativeInteger? minproperties, ValidatedArrayOfJsonString? required, SchemaPropertiesOrReference? properties, SchemaAdditionalProperties? additionalproperties, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is SchemaOrReference item4)
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
            if (items is SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is SchemaPropertiesOrReference item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public Schema(TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, ValidatedArrayOfSchemaOrReference? allof, ValidatedArrayOfSchemaOrReference? anyof, ValidatedArrayOfSchemaOrReference? oneof, SchemaOrReference? not, PositiveInteger? multipleof, Menes.JsonInt64? maximum, Menes.JsonInt64? exclusivemaximum, Menes.JsonInt64? minimum, Menes.JsonInt64? exclusiveminimum, NonNegativeInteger? maxlength, NonNegativeInteger? minlength, Menes.JsonString? pattern, NonNegativeInteger? maxitems, NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, NonNegativeInteger? maxcontains, SchemaOrReference? items, SchemaOrReference? contains, NonNegativeInteger? maxproperties, NonNegativeInteger? minproperties, ValidatedArrayOfJsonString? required, SchemaPropertiesOrReference? properties, SchemaAdditionalProperties? additionalproperties, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.type = type;
            this.format = format;
            this.@enum = @enum;
            this.@const = @const;
            if (allof is ValidatedArrayOfSchemaOrReference item1)
            {
                this.allof = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.allof = null;
            }
            if (anyof is ValidatedArrayOfSchemaOrReference item2)
            {
                this.anyof = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.anyof = null;
            }
            if (oneof is ValidatedArrayOfSchemaOrReference item3)
            {
                this.oneof = Menes.JsonReference.FromValue(item3);
            }
            else
            {
                this.oneof = null;
            }
            if (not is SchemaOrReference item4)
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
            if (items is SchemaOrReference item5)
            {
                this.items = Menes.JsonReference.FromValue(item5);
            }
            else
            {
                this.items = null;
            }
            if (contains is SchemaOrReference item6)
            {
                this.contains = Menes.JsonReference.FromValue(item6);
            }
            else
            {
                this.contains = null;
            }
            this.maxproperties = maxproperties;
            this.minproperties = minproperties;
            if (required is ValidatedArrayOfJsonString item7)
            {
                this.required = Menes.JsonReference.FromValue(item7);
            }
            else
            {
                this.required = null;
            }
            if (properties is SchemaPropertiesOrReference item8)
            {
                this.properties = Menes.JsonReference.FromValue(item8);
            }
            else
            {
                this.properties = null;
            }
            if (additionalproperties is SchemaAdditionalProperties item9)
            {
                this.additionalproperties = Menes.JsonReference.FromValue(item9);
            }
            else
            {
                this.additionalproperties = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private Schema(TypeEnum? type, Menes.JsonString? format, Menes.JsonArray<Menes.JsonAny>? @enum, Menes.JsonAny? @const, Menes.JsonReference? allof, Menes.JsonReference? anyof, Menes.JsonReference? oneof, Menes.JsonReference? not, PositiveInteger? multipleof, Menes.JsonInt64? maximum, Menes.JsonInt64? exclusivemaximum, Menes.JsonInt64? minimum, Menes.JsonInt64? exclusiveminimum, NonNegativeInteger? maxlength, NonNegativeInteger? minlength, Menes.JsonString? pattern, NonNegativeInteger? maxitems, NonNegativeInteger? minitems, Menes.JsonBoolean? uniqueitems, NonNegativeInteger? maxcontains, Menes.JsonReference? items, Menes.JsonReference? contains, NonNegativeInteger? maxproperties, NonNegativeInteger? minproperties, Menes.JsonReference? required, Menes.JsonReference? properties, Menes.JsonReference? additionalproperties, Menes.JsonProperties? additionalProperties)
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
        public TypeEnum? Type => this.type ?? Schema.TypeEnum.FromOptionalProperty(this.JsonElement, TypePropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Format => this.format ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, FormatPropertyNameBytes.Span).AsOptional;
        public Menes.JsonArray<Menes.JsonAny>? Enum => this.@enum ?? Menes.JsonArray<Menes.JsonAny>.FromOptionalProperty(this.JsonElement, EnumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonAny? Const => this.@const ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, ConstPropertyNameBytes.Span).AsOptional;
        public ValidatedArrayOfSchemaOrReference? Allof => this.allof?.AsValue<ValidatedArrayOfSchemaOrReference>() ?? Schema.ValidatedArrayOfSchemaOrReference.FromOptionalProperty(this.JsonElement, AllofPropertyNameBytes.Span).AsOptional;
        public ValidatedArrayOfSchemaOrReference? Anyof => this.anyof?.AsValue<ValidatedArrayOfSchemaOrReference>() ?? Schema.ValidatedArrayOfSchemaOrReference.FromOptionalProperty(this.JsonElement, AnyofPropertyNameBytes.Span).AsOptional;
        public ValidatedArrayOfSchemaOrReference? Oneof => this.oneof?.AsValue<ValidatedArrayOfSchemaOrReference>() ?? Schema.ValidatedArrayOfSchemaOrReference.FromOptionalProperty(this.JsonElement, OneofPropertyNameBytes.Span).AsOptional;
        public SchemaOrReference? Not => this.not?.AsValue<SchemaOrReference>() ?? Schema.SchemaOrReference.FromOptionalProperty(this.JsonElement, NotPropertyNameBytes.Span).AsOptional;
        public PositiveInteger? Multipleof => this.multipleof ?? Schema.PositiveInteger.FromOptionalProperty(this.JsonElement, MultipleofPropertyNameBytes.Span).AsOptional;
        public Menes.JsonInt64? Maximum => this.maximum ?? Menes.JsonInt64.FromOptionalProperty(this.JsonElement, MaximumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonInt64? Exclusivemaximum => this.exclusivemaximum ?? Menes.JsonInt64.FromOptionalProperty(this.JsonElement, ExclusivemaximumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonInt64? Minimum => this.minimum ?? Menes.JsonInt64.FromOptionalProperty(this.JsonElement, MinimumPropertyNameBytes.Span).AsOptional;
        public Menes.JsonInt64? Exclusiveminimum => this.exclusiveminimum ?? Menes.JsonInt64.FromOptionalProperty(this.JsonElement, ExclusiveminimumPropertyNameBytes.Span).AsOptional;
        public NonNegativeInteger? Maxlength => this.maxlength ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxlengthPropertyNameBytes.Span).AsOptional;
        public NonNegativeInteger? Minlength => this.minlength ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinlengthPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Pattern => this.pattern ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, PatternPropertyNameBytes.Span).AsOptional;
        public NonNegativeInteger? Maxitems => this.maxitems ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxitemsPropertyNameBytes.Span).AsOptional;
        public NonNegativeInteger? Minitems => this.minitems ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinitemsPropertyNameBytes.Span).AsOptional;
        public Menes.JsonBoolean? Uniqueitems => this.uniqueitems ?? Menes.JsonBoolean.FromOptionalProperty(this.JsonElement, UniqueitemsPropertyNameBytes.Span).AsOptional;
        public NonNegativeInteger? Maxcontains => this.maxcontains ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxcontainsPropertyNameBytes.Span).AsOptional;
        public SchemaOrReference? Items => this.items?.AsValue<SchemaOrReference>() ?? Schema.SchemaOrReference.FromOptionalProperty(this.JsonElement, ItemsPropertyNameBytes.Span).AsOptional;
        public SchemaOrReference? Contains => this.contains?.AsValue<SchemaOrReference>() ?? Schema.SchemaOrReference.FromOptionalProperty(this.JsonElement, ContainsPropertyNameBytes.Span).AsOptional;
        public NonNegativeInteger? Maxproperties => this.maxproperties ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MaxpropertiesPropertyNameBytes.Span).AsOptional;
        public NonNegativeInteger? Minproperties => this.minproperties ?? Schema.NonNegativeInteger.FromOptionalProperty(this.JsonElement, MinpropertiesPropertyNameBytes.Span).AsOptional;
        public ValidatedArrayOfJsonString? Required => this.required?.AsValue<ValidatedArrayOfJsonString>() ?? Schema.ValidatedArrayOfJsonString.FromOptionalProperty(this.JsonElement, RequiredPropertyNameBytes.Span).AsOptional;
        public SchemaPropertiesOrReference? Properties => this.properties?.AsValue<SchemaPropertiesOrReference>() ?? Schema.SchemaPropertiesOrReference.FromOptionalProperty(this.JsonElement, PropertiesPropertyNameBytes.Span).AsOptional;
        public SchemaAdditionalProperties? Additionalproperties => this.additionalproperties?.AsValue<SchemaAdditionalProperties>() ?? Schema.SchemaAdditionalProperties.FromOptionalProperty(this.JsonElement, AdditionalpropertiesPropertyNameBytes.Span).AsOptional;
        public int PropertiesCount => KnownProperties.Length + this.AdditionalPropertiesCount;
        public int AdditionalPropertiesCount
        {
            get
            {
                Menes.JsonPropertyEnumerator enumerator = this.AdditionalProperties;
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
        public Menes.JsonPropertyEnumerator AdditionalProperties
        {
            get
            {
                if (this.additionalProperties is Menes.JsonProperties ap)
                {
                    return new Menes.JsonPropertyEnumerator(ap, KnownProperties);
                }

                if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    return new Menes.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                }

                return new Menes.JsonPropertyEnumerator(Menes.JsonProperties.Empty, KnownProperties);
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
        public Schema WithType(TypeEnum? value)
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
        public Schema WithAllof(ValidatedArrayOfSchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, Menes.JsonReference.FromValue(value), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithAnyof(ValidatedArrayOfSchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), Menes.JsonReference.FromValue(value), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithOneof(ValidatedArrayOfSchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), Menes.JsonReference.FromValue(value), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithNot(SchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), Menes.JsonReference.FromValue(value), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMultipleof(PositiveInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), value, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMaximum(Menes.JsonInt64? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, value, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithExclusivemaximum(Menes.JsonInt64? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, value, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMinimum(Menes.JsonInt64? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, value, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithExclusiveminimum(Menes.JsonInt64? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, value, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMaxlength(NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, value, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMinlength(NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, value, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithPattern(Menes.JsonString? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, value, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMaxitems(NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, value, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMinitems(NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, value, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithUniqueitems(Menes.JsonBoolean? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, value, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMaxcontains(NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, value, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithItems(SchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, Menes.JsonReference.FromValue(value), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithContains(SchemaOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), Menes.JsonReference.FromValue(value), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMaxproperties(NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), value, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithMinproperties(NonNegativeInteger? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, value, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithRequired(ValidatedArrayOfJsonString? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, Menes.JsonReference.FromValue(value), this.GetProperties(), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithProperties(SchemaPropertiesOrReference? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), Menes.JsonReference.FromValue(value), this.GetAdditionalproperties(), this.GetJsonProperties());
        }
        public Schema WithAdditionalproperties(SchemaAdditionalProperties? value)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), Menes.JsonReference.FromValue(value), this.GetJsonProperties());
        }
        public Schema WithAdditionalProperties(Menes.JsonProperties newAdditional)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), newAdditional);
        }
        public Schema WithAdditionalProperties(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), Menes.JsonProperties.FromValues(newAdditional));
        }
        public Schema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), Menes.JsonProperties.FromValues(newAdditional1));
        }
        public Schema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), Menes.JsonProperties.FromValues(newAdditional1, newAdditional2));
        }
        public Schema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), Menes.JsonProperties.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Schema WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Schema(this.Type, this.Format, this.Enum, this.Const, this.GetAllof(), this.GetAnyof(), this.GetOneof(), this.GetNot(), this.Multipleof, this.Maximum, this.Exclusivemaximum, this.Minimum, this.Exclusiveminimum, this.Maxlength, this.Minlength, this.Pattern, this.Maxitems, this.Minitems, this.Uniqueitems, this.Maxcontains, this.GetItems(), this.GetContains(), this.Maxproperties, this.Minproperties, this.GetRequired(), this.GetProperties(), this.GetAdditionalproperties(), Menes.JsonProperties.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                if (this.type is TypeEnum type)
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
                if (this.multipleof is PositiveInteger multipleof)
                {
                    writer.WritePropertyName(EncodedMultipleofPropertyName);
                    multipleof.WriteTo(writer);
                }
                if (this.maximum is Menes.JsonInt64 maximum)
                {
                    writer.WritePropertyName(EncodedMaximumPropertyName);
                    maximum.WriteTo(writer);
                }
                if (this.exclusivemaximum is Menes.JsonInt64 exclusivemaximum)
                {
                    writer.WritePropertyName(EncodedExclusivemaximumPropertyName);
                    exclusivemaximum.WriteTo(writer);
                }
                if (this.minimum is Menes.JsonInt64 minimum)
                {
                    writer.WritePropertyName(EncodedMinimumPropertyName);
                    minimum.WriteTo(writer);
                }
                if (this.exclusiveminimum is Menes.JsonInt64 exclusiveminimum)
                {
                    writer.WritePropertyName(EncodedExclusiveminimumPropertyName);
                    exclusiveminimum.WriteTo(writer);
                }
                if (this.maxlength is NonNegativeInteger maxlength)
                {
                    writer.WritePropertyName(EncodedMaxlengthPropertyName);
                    maxlength.WriteTo(writer);
                }
                if (this.minlength is NonNegativeInteger minlength)
                {
                    writer.WritePropertyName(EncodedMinlengthPropertyName);
                    minlength.WriteTo(writer);
                }
                if (this.pattern is Menes.JsonString pattern)
                {
                    writer.WritePropertyName(EncodedPatternPropertyName);
                    pattern.WriteTo(writer);
                }
                if (this.maxitems is NonNegativeInteger maxitems)
                {
                    writer.WritePropertyName(EncodedMaxitemsPropertyName);
                    maxitems.WriteTo(writer);
                }
                if (this.minitems is NonNegativeInteger minitems)
                {
                    writer.WritePropertyName(EncodedMinitemsPropertyName);
                    minitems.WriteTo(writer);
                }
                if (this.uniqueitems is Menes.JsonBoolean uniqueitems)
                {
                    writer.WritePropertyName(EncodedUniqueitemsPropertyName);
                    uniqueitems.WriteTo(writer);
                }
                if (this.maxcontains is NonNegativeInteger maxcontains)
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
                if (this.maxproperties is NonNegativeInteger maxproperties)
                {
                    writer.WritePropertyName(EncodedMaxpropertiesPropertyName);
                    maxproperties.WriteTo(writer);
                }
                if (this.minproperties is NonNegativeInteger minproperties)
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
                Menes.JsonPropertyEnumerator enumerator = this.AdditionalProperties;
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
            if (this.Type is TypeEnum type)
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
            if (this.Allof is ValidatedArrayOfSchemaOrReference allof)
            {
                context = Menes.Validation.ValidateProperty(context, allof, AllofPropertyNamePath);
            }
            if (this.Anyof is ValidatedArrayOfSchemaOrReference anyof)
            {
                context = Menes.Validation.ValidateProperty(context, anyof, AnyofPropertyNamePath);
            }
            if (this.Oneof is ValidatedArrayOfSchemaOrReference oneof)
            {
                context = Menes.Validation.ValidateProperty(context, oneof, OneofPropertyNamePath);
            }
            if (this.Not is SchemaOrReference not)
            {
                context = Menes.Validation.ValidateProperty(context, not, NotPropertyNamePath);
            }
            if (this.Multipleof is PositiveInteger multipleof)
            {
                context = Menes.Validation.ValidateProperty(context, multipleof, MultipleofPropertyNamePath);
            }
            if (this.Maximum is Menes.JsonInt64 maximum)
            {
                context = Menes.Validation.ValidateProperty(context, maximum, MaximumPropertyNamePath);
            }
            if (this.Exclusivemaximum is Menes.JsonInt64 exclusivemaximum)
            {
                context = Menes.Validation.ValidateProperty(context, exclusivemaximum, ExclusivemaximumPropertyNamePath);
            }
            if (this.Minimum is Menes.JsonInt64 minimum)
            {
                context = Menes.Validation.ValidateProperty(context, minimum, MinimumPropertyNamePath);
            }
            if (this.Exclusiveminimum is Menes.JsonInt64 exclusiveminimum)
            {
                context = Menes.Validation.ValidateProperty(context, exclusiveminimum, ExclusiveminimumPropertyNamePath);
            }
            if (this.Maxlength is NonNegativeInteger maxlength)
            {
                context = Menes.Validation.ValidateProperty(context, maxlength, MaxlengthPropertyNamePath);
            }
            if (this.Minlength is NonNegativeInteger minlength)
            {
                context = Menes.Validation.ValidateProperty(context, minlength, MinlengthPropertyNamePath);
            }
            if (this.Pattern is Menes.JsonString pattern)
            {
                context = Menes.Validation.ValidateProperty(context, pattern, PatternPropertyNamePath);
            }
            if (this.Maxitems is NonNegativeInteger maxitems)
            {
                context = Menes.Validation.ValidateProperty(context, maxitems, MaxitemsPropertyNamePath);
            }
            if (this.Minitems is NonNegativeInteger minitems)
            {
                context = Menes.Validation.ValidateProperty(context, minitems, MinitemsPropertyNamePath);
            }
            if (this.Uniqueitems is Menes.JsonBoolean uniqueitems)
            {
                context = Menes.Validation.ValidateProperty(context, uniqueitems, UniqueitemsPropertyNamePath);
            }
            if (this.Maxcontains is NonNegativeInteger maxcontains)
            {
                context = Menes.Validation.ValidateProperty(context, maxcontains, MaxcontainsPropertyNamePath);
            }
            if (this.Items is SchemaOrReference items)
            {
                context = Menes.Validation.ValidateProperty(context, items, ItemsPropertyNamePath);
            }
            if (this.Contains is SchemaOrReference contains)
            {
                context = Menes.Validation.ValidateProperty(context, contains, ContainsPropertyNamePath);
            }
            if (this.Maxproperties is NonNegativeInteger maxproperties)
            {
                context = Menes.Validation.ValidateProperty(context, maxproperties, MaxpropertiesPropertyNamePath);
            }
            if (this.Minproperties is NonNegativeInteger minproperties)
            {
                context = Menes.Validation.ValidateProperty(context, minproperties, MinpropertiesPropertyNamePath);
            }
            if (this.Required is ValidatedArrayOfJsonString required)
            {
                context = Menes.Validation.ValidateProperty(context, required, RequiredPropertyNamePath);
            }
            if (this.Properties is SchemaPropertiesOrReference properties)
            {
                context = Menes.Validation.ValidateProperty(context, properties, PropertiesPropertyNamePath);
            }
            if (this.Additionalproperties is SchemaAdditionalProperties additionalproperties)
            {
                context = Menes.Validation.ValidateProperty(context, additionalproperties, AdditionalpropertiesPropertyNamePath);
            }
            foreach (Menes.JsonPropertyReference property in this.AdditionalProperties)
            {
                context = Menes.Validation.ValidateProperty(context, property.AsValue<Menes.JsonAny>(), "." + property.Name);
            }
            return context;
        }
        public bool TryGetAdditionalProperty(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny? value)
        {
            return this.TryGetAdditionalProperty(System.MemoryExtensions.AsSpan(propertyName), out value);
        }
        public bool TryGetAdditionalProperty(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny? value)
        {
            foreach (Menes.JsonPropertyReference property in this.AdditionalProperties)
            {
                if (property.NameEquals(utf8PropertyName))
                {
                    value = property.AsValue<Menes.JsonAny>();
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
        private Menes.JsonProperties GetJsonProperties()
        {
            if (this.additionalProperties is Menes.JsonProperties props)
            {
                return props;
            }
            return new Menes.JsonProperties(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.AdditionalProperties));
        }
        public readonly struct SchemaOrReference : Menes.IJsonValue
        {
            public static readonly SchemaOrReference Null = new SchemaOrReference(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonReference? item1;
            private readonly Menes.JsonString? item2;
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
            public SchemaOrReference(Menes.JsonString clrInstance)
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
            public SchemaOrReference(System.Text.Json.JsonElement jsonElement)
            {
                this.item1 = null;
                this.item2 = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public SchemaOrReference? AsOptional => this.IsNull ? default(SchemaOrReference?) : this;
            public bool IsSchema => this.item1 is Menes.JsonReference || Schema.IsConvertibleFrom(this.JsonElement);
            public bool IsJsonString => this.item2 is Menes.JsonString || Menes.JsonString.IsConvertibleFrom(this.JsonElement);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator Schema(SchemaOrReference value) => value.AsSchema();
            public static implicit operator SchemaOrReference(Schema value) => new SchemaOrReference(value);
            public static explicit operator Menes.JsonString(SchemaOrReference value) => value.AsJsonString();
            public static implicit operator SchemaOrReference(Menes.JsonString value) => new SchemaOrReference(value);
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
            public Schema AsSchema() => this.item1?.AsValue<Schema>() ?? new Schema(this.JsonElement);
            public Menes.JsonString AsJsonString() => this.item2 ?? new Menes.JsonString(this.JsonElement);
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.item1 is Menes.JsonReference item1)
                {
                    item1.WriteTo(writer);
                }
                else if (this.item2 is Menes.JsonString item2)
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
                if (this.IsJsonString)
                {
                    builder.Append("{");
                    builder.Append("JsonString");
                    builder.Append(", ");
                    builder.Append(this.AsJsonString().ToString());
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
                if (this.IsJsonString)
                {
                    validationContext2 = this.AsJsonString().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a Menes.JsonString.");
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
                return arrayBuilder.ToImmutable();
            }
        }
        public readonly struct PositiveInteger : Menes.IJsonValue, System.IEquatable<PositiveInteger>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, PositiveInteger> FromJsonElement = e => new PositiveInteger(e);
            public static readonly PositiveInteger Null = new PositiveInteger(default(System.Text.Json.JsonElement));
            private static readonly long? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<long>? EnumValues = BuildEnumValues();
            private static readonly long? MultipleOf = null;
            private static readonly long? Maximum = null;
            private static readonly long? ExclusiveMaximum = null;
            private static readonly long? Minimum = null;
            private static readonly long? ExclusiveMinimum = 0;
            private readonly Menes.JsonInt64? value;
            public PositiveInteger(Menes.JsonInt64 value)
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
            public static implicit operator PositiveInteger(Menes.JsonInt64 value)
            {
                return new PositiveInteger(value);
            }
            public static implicit operator PositiveInteger(long value)
            {
                return new PositiveInteger(value);
            }
            public static implicit operator Menes.JsonInt64(PositiveInteger value)
            {
                if (value.value is Menes.JsonInt64 clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonInt64(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonInt64.IsConvertibleFrom(jsonElement);
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
                return this.Equals((Menes.JsonInt64)other);
            }
            public bool Equals(Menes.JsonInt64 other)
            {
                return ((Menes.JsonInt64)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonInt64 value = this;
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
                else if (this.value is Menes.JsonInt64 clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            private static long? BuildConstValue()
            {
                return null;
            }
            private static System.Collections.Immutable.ImmutableArray<long>? BuildEnumValues()
            {
                return null;
            }
        }
        public readonly struct NonNegativeInteger : Menes.IJsonValue, System.IEquatable<NonNegativeInteger>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, NonNegativeInteger> FromJsonElement = e => new NonNegativeInteger(e);
            public static readonly NonNegativeInteger Null = new NonNegativeInteger(default(System.Text.Json.JsonElement));
            private static readonly long? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<long>? EnumValues = BuildEnumValues();
            private static readonly long? MultipleOf = null;
            private static readonly long? Maximum = null;
            private static readonly long? ExclusiveMaximum = null;
            private static readonly long? Minimum = 0;
            private static readonly long? ExclusiveMinimum = null;
            private readonly Menes.JsonInt64? value;
            public NonNegativeInteger(Menes.JsonInt64 value)
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
            public static implicit operator NonNegativeInteger(Menes.JsonInt64 value)
            {
                return new NonNegativeInteger(value);
            }
            public static implicit operator NonNegativeInteger(long value)
            {
                return new NonNegativeInteger(value);
            }
            public static implicit operator Menes.JsonInt64(NonNegativeInteger value)
            {
                if (value.value is Menes.JsonInt64 clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonInt64(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonInt64.IsConvertibleFrom(jsonElement);
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
                return this.Equals((Menes.JsonInt64)other);
            }
            public bool Equals(Menes.JsonInt64 other)
            {
                return ((Menes.JsonInt64)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonInt64 value = this;
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
                else if (this.value is Menes.JsonInt64 clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            private static long? BuildConstValue()
            {
                return null;
            }
            private static System.Collections.Immutable.ImmutableArray<long>? BuildEnumValues()
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
                context = array.ValidateUniqueItems(context, true);
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
        }
        public readonly struct ValidatedArrayOfSchemaOrReference : Menes.IJsonValue, System.Collections.Generic.IEnumerable<SchemaOrReference>, System.Collections.IEnumerable, System.IEquatable<ValidatedArrayOfSchemaOrReference>, System.IEquatable<Menes.JsonArray<SchemaOrReference>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, ValidatedArrayOfSchemaOrReference> FromJsonElement = e => new ValidatedArrayOfSchemaOrReference(e);
            public static readonly ValidatedArrayOfSchemaOrReference Null = new ValidatedArrayOfSchemaOrReference(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<SchemaOrReference>? value;
            public ValidatedArrayOfSchemaOrReference(Menes.JsonArray<SchemaOrReference> jsonArray)
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
            public static implicit operator ValidatedArrayOfSchemaOrReference(Menes.JsonArray<SchemaOrReference> value)
            {
                return new ValidatedArrayOfSchemaOrReference(value);
            }
            public static implicit operator Menes.JsonArray<SchemaOrReference>(ValidatedArrayOfSchemaOrReference value)
            {
                if (value.value is Menes.JsonArray<SchemaOrReference> clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonArray<SchemaOrReference>(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonArray<SchemaOrReference>.IsConvertibleFrom(jsonElement);
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
                return this.Equals((Menes.JsonArray<SchemaOrReference>)other);
            }
            public bool Equals(Menes.JsonArray<SchemaOrReference> other)
            {
                return ((Menes.JsonArray<SchemaOrReference>)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonArray<SchemaOrReference> array = this;
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
                if (this.value is Menes.JsonArray<SchemaOrReference> clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public Menes.JsonArray<SchemaOrReference>.JsonArrayEnumerator GetEnumerator()
            {
                return ((Menes.JsonArray<SchemaOrReference>)this).GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<SchemaOrReference> System.Collections.Generic.IEnumerable<SchemaOrReference>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public readonly struct SchemaProperties : Menes.IJsonObject, System.IEquatable<SchemaProperties>, Menes.IJsonAdditionalProperties
        {
            public static readonly SchemaProperties Null = new SchemaProperties(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, SchemaProperties> FromJsonElement = e => new SchemaProperties(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties? additionalProperties;
            public SchemaProperties(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalProperties = null;
            }
            public SchemaProperties(Menes.JsonProperties additionalProperties)
            {
                this.JsonElement = default;
                this.additionalProperties = additionalProperties;
            }
            public SchemaProperties(params (string, SchemaOrReference)[] additionalProperties)
            {
                this.JsonElement = default;
                this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperties);
            }
            public SchemaProperties((string, SchemaOrReference) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1);
            }
            public SchemaProperties((string, SchemaOrReference) additionalProperty1, (string, SchemaOrReference) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1, additionalProperty2);
            }
            public SchemaProperties((string, SchemaOrReference) additionalProperty1, (string, SchemaOrReference) additionalProperty2, (string, SchemaOrReference) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public SchemaProperties((string, SchemaOrReference) additionalProperty1, (string, SchemaOrReference) additionalProperty2, (string, SchemaOrReference) additionalProperty3, (string, SchemaOrReference) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private SchemaProperties(Menes.JsonProperties? additionalProperties)
            {
                this.JsonElement = default;
                this.additionalProperties = additionalProperties;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public SchemaProperties? AsOptional => this.IsNull ? default(SchemaProperties?) : this;
            public int PropertiesCount => KnownProperties.Length + this.AdditionalPropertiesCount;
            public int AdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonPropertyEnumerator enumerator = this.AdditionalProperties;
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
            public Menes.JsonPropertyEnumerator AdditionalProperties
            {
                get
                {
                    if (this.additionalProperties is Menes.JsonProperties ap)
                    {
                        return new Menes.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonPropertyEnumerator(Menes.JsonProperties.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaProperties(property)
                    : Null;
            public static SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaProperties(property)
                    : Null;
            public static SchemaProperties FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaProperties(property)
                    : Null;
            public SchemaProperties WithAdditionalProperties(Menes.JsonProperties newAdditional)
            {
                return new SchemaProperties(newAdditional);
            }
            public SchemaProperties WithAdditionalProperties(params (string, SchemaOrReference)[] newAdditional)
            {
                return new SchemaProperties(Menes.JsonProperties.FromValues(newAdditional));
            }
            public SchemaProperties WithAdditionalProperties((string, SchemaOrReference) newAdditional1)
            {
                return new SchemaProperties(Menes.JsonProperties.FromValues(newAdditional1));
            }
            public SchemaProperties WithAdditionalProperties((string, SchemaOrReference) newAdditional1, (string, SchemaOrReference) newAdditional2)
            {
                return new SchemaProperties(Menes.JsonProperties.FromValues(newAdditional1, newAdditional2));
            }
            public SchemaProperties WithAdditionalProperties((string, SchemaOrReference) newAdditional1, (string, SchemaOrReference) newAdditional2, (string, SchemaOrReference) newAdditional3)
            {
                return new SchemaProperties(Menes.JsonProperties.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public SchemaProperties WithAdditionalProperties((string, SchemaOrReference) newAdditional1, (string, SchemaOrReference) newAdditional2, (string, SchemaOrReference) newAdditional3, (string, SchemaOrReference) newAdditional4)
            {
                return new SchemaProperties(Menes.JsonProperties.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                    Menes.JsonPropertyEnumerator enumerator = this.AdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(SchemaProperties other)
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
                foreach (Menes.JsonPropertyReference property in this.AdditionalProperties)
                {
                    context = Menes.Validation.ValidateProperty(context, property.AsValue<SchemaOrReference>(), "." + property.Name);
                }
                return context;
            }
            public bool TryGetAdditionalProperty(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out SchemaOrReference? value)
            {
                return this.TryGetAdditionalProperty(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGetAdditionalProperty(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out SchemaOrReference? value)
            {
                foreach (Menes.JsonPropertyReference property in this.AdditionalProperties)
                {
                    if (property.NameEquals(utf8PropertyName))
                    {
                        value = property.AsValue<SchemaOrReference>();
                        return true;
                    }
                }
                value = default;
                return false;
            }
            public bool TryGetAdditionalProperty(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out SchemaOrReference? value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGetAdditionalProperty(bytes.Slice(0, written), out value);
            }
            private Menes.JsonProperties GetJsonProperties()
            {
                if (this.additionalProperties is Menes.JsonProperties props)
                {
                    return props;
                }
                return new Menes.JsonProperties(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.AdditionalProperties));
            }
        }

        public readonly struct SchemaPropertiesOrReference : Menes.IJsonValue
        {
            public static readonly SchemaPropertiesOrReference Null = new SchemaPropertiesOrReference(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonReference? item1;
            private readonly Menes.JsonString? item2;
            public SchemaPropertiesOrReference(SchemaProperties clrInstance)
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
            public SchemaPropertiesOrReference(Menes.JsonString clrInstance)
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
            public SchemaPropertiesOrReference(System.Text.Json.JsonElement jsonElement)
            {
                this.item1 = null;
                this.item2 = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public SchemaPropertiesOrReference? AsOptional => this.IsNull ? default(SchemaPropertiesOrReference?) : this;
            public bool IsSchemaProperties => this.item1 is Menes.JsonReference || Schema.SchemaProperties.IsConvertibleFrom(this.JsonElement);
            public bool IsJsonString => this.item2 is Menes.JsonString || Menes.JsonString.IsConvertibleFrom(this.JsonElement);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator SchemaProperties(SchemaPropertiesOrReference value) => value.AsSchemaProperties();
            public static implicit operator SchemaPropertiesOrReference(SchemaProperties value) => new SchemaPropertiesOrReference(value);
            public static explicit operator Menes.JsonString(SchemaPropertiesOrReference value) => value.AsJsonString();
            public static implicit operator SchemaPropertiesOrReference(Menes.JsonString value) => new SchemaPropertiesOrReference(value);
            public static SchemaPropertiesOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaPropertiesOrReference(property)
                    : Null;
            public static SchemaPropertiesOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaPropertiesOrReference(property)
                    : Null;
            public static SchemaPropertiesOrReference FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaPropertiesOrReference(property)
                    : Null;
            public SchemaProperties AsSchemaProperties() => this.item1?.AsValue<SchemaProperties>() ?? new SchemaProperties(this.JsonElement);
            public Menes.JsonString AsJsonString() => this.item2 ?? new Menes.JsonString(this.JsonElement);
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.item1 is Menes.JsonReference item1)
                {
                    item1.WriteTo(writer);
                }
                else if (this.item2 is Menes.JsonString item2)
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
                if (this.IsSchemaProperties)
                {
                    builder.Append("{");
                    builder.Append("SchemaProperties");
                    builder.Append(", ");
                    builder.Append(this.AsSchemaProperties().ToString());
                    builder.AppendLine("}");
                }
                if (this.IsJsonString)
                {
                    builder.Append("{");
                    builder.Append("JsonString");
                    builder.Append(", ");
                    builder.Append(this.AsJsonString().ToString());
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
                if (this.IsSchemaProperties)
                {
                    validationContext1 = this.AsSchemaProperties().Validate(validationContext1);
                }
                else
                {
                    validationContext1 = validationContext1.WithError("The value is not convertible to a Schema.SchemaProperties.");
                }
                if (this.IsJsonString)
                {
                    validationContext2 = this.AsJsonString().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a Menes.JsonString.");
                }
                return Menes.Validation.ValidateAnyOf(validationContext, validationContext1, validationContext2);
            }
        }
        public readonly struct SchemaAdditionalProperties : Menes.IJsonValue
        {
            public static readonly SchemaAdditionalProperties Null = new SchemaAdditionalProperties(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonReference? item1;
            private readonly Menes.JsonBoolean? item2;
            public SchemaAdditionalProperties(SchemaOrReference clrInstance)
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
            public bool IsSchemaOrReference => this.item1 is Menes.JsonReference /* || Schema.SchemaOrReference.IsConvertibleFrom(this.JsonElement) */;
            public bool IsJsonBoolean => this.item2 is Menes.JsonBoolean || Menes.JsonBoolean.IsConvertibleFrom(this.JsonElement);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator SchemaOrReference(SchemaAdditionalProperties value) => value.AsSchemaOrReference();
            public static implicit operator SchemaAdditionalProperties(SchemaOrReference value) => new SchemaAdditionalProperties(value);
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
            public SchemaOrReference AsSchemaOrReference() => this.item1?.AsValue<SchemaOrReference>() ?? new SchemaOrReference(this.JsonElement);
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
