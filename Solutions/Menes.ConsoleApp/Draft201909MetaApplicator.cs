// <copyright file="Draft201909MetaApplicator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace TestSpace
{
public readonly struct Draft201909MetaApplicator : Menes.IJsonObject
{
public static readonly Draft201909MetaApplicator Null = default(Draft201909MetaApplicator);
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
private static readonly System.ReadOnlyMemory<byte>  _MenesAdditionalItemsUtf8JsonPropertyName = new byte[] { 97, 100, 100, 105, 116, 105, 111, 110, 97, 108, 73, 116, 101, 109, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesUnevaluatedItemsUtf8JsonPropertyName = new byte[] { 117, 110, 101, 118, 97, 108, 117, 97, 116, 101, 100, 73, 116, 101, 109, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesItemsUtf8JsonPropertyName = new byte[] { 105, 116, 101, 109, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesContainsUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 97, 105, 110, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesAdditionalPropertiesUtf8JsonPropertyName = new byte[] { 97, 100, 100, 105, 116, 105, 111, 110, 97, 108, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesUnevaluatedPropertiesUtf8JsonPropertyName = new byte[] { 117, 110, 101, 118, 97, 108, 117, 97, 116, 101, 100, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesPropertiesUtf8JsonPropertyName = new byte[] { 112, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesPatternPropertiesUtf8JsonPropertyName = new byte[] { 112, 97, 116, 116, 101, 114, 110, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesDependentSchemasUtf8JsonPropertyName = new byte[] { 100, 101, 112, 101, 110, 100, 101, 110, 116, 83, 99, 104, 101, 109, 97, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesPropertyNamesUtf8JsonPropertyName = new byte[] { 112, 114, 111, 112, 101, 114, 116, 121, 78, 97, 109, 101, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesIfUtf8JsonPropertyName = new byte[] { 105, 102 };
private static readonly System.ReadOnlyMemory<byte>  _MenesThenUtf8JsonPropertyName = new byte[] { 116, 104, 101, 110 };
private static readonly System.ReadOnlyMemory<byte>  _MenesElseUtf8JsonPropertyName = new byte[] { 101, 108, 115, 101 };
private static readonly System.ReadOnlyMemory<byte>  _MenesAllOfUtf8JsonPropertyName = new byte[] { 97, 108, 108, 79, 102 };
private static readonly System.ReadOnlyMemory<byte>  _MenesAnyOfUtf8JsonPropertyName = new byte[] { 97, 110, 121, 79, 102 };
private static readonly System.ReadOnlyMemory<byte>  _MenesOneOfUtf8JsonPropertyName = new byte[] { 111, 110, 101, 79, 102 };
private static readonly System.ReadOnlyMemory<byte>  _MenesNotUtf8JsonPropertyName = new byte[] { 110, 111, 116 };
private static readonly  System.Text.Json.JsonEncodedText _MenesAdditionalItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesAdditionalItemsUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesUnevaluatedItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesUnevaluatedItemsUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesItemsUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesContainsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContainsUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesAdditionalPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesAdditionalPropertiesUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesUnevaluatedPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesUnevaluatedPropertiesUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesPropertiesUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesPatternPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesPatternPropertiesUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesDependentSchemasEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDependentSchemasUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesPropertyNamesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesPropertyNamesUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesIfEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesIfUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesThenEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesThenUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesElseEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesElseUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesAllOfEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesAllOfUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesAnyOfEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesAnyOfUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesOneOfEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesOneOfUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesNotEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesNotUtf8JsonPropertyName.Span);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
private readonly Menes.JsonValueBacking additionalItems;
private readonly Menes.JsonValueBacking unevaluatedItems;
private readonly Draft201909MetaApplicator.ItemsEntity? items;
private readonly Menes.JsonValueBacking contains;
private readonly Menes.JsonValueBacking additionalProperties;
private readonly Menes.JsonValueBacking unevaluatedProperties;
private readonly Menes.JsonValueBacking properties;
private readonly Menes.JsonValueBacking patternProperties;
private readonly Menes.JsonValueBacking dependentSchemas;
private readonly Menes.JsonValueBacking propertyNames;
private readonly Menes.JsonValueBacking @if;
private readonly Menes.JsonValueBacking then;
private readonly Menes.JsonValueBacking @else;
private readonly Menes.JsonValueBacking allOf;
private readonly Menes.JsonValueBacking anyOf;
private readonly Menes.JsonValueBacking oneOf;
private readonly Menes.JsonValueBacking not;
public Draft201909MetaApplicator(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
this._menesBooleanTypeBacking = default;
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
}
public Draft201909MetaApplicator(Draft201909MetaApplicator? additionalItems = null, Draft201909MetaApplicator? unevaluatedItems = null, Draft201909MetaApplicator.ItemsEntity? items = null, Draft201909MetaApplicator? contains = null, Draft201909MetaApplicator? additionalProperties = null, Draft201909MetaApplicator? unevaluatedProperties = null, Draft201909MetaApplicator.PropertiesEntity? properties = null, Draft201909MetaApplicator.PatternPropertiesEntity? patternProperties = null, Draft201909MetaApplicator.DependentSchemasEntity? dependentSchemas = null, Draft201909MetaApplicator? propertyNames = null, Draft201909MetaApplicator? @if = null, Draft201909MetaApplicator? then = null, Draft201909MetaApplicator? @else = null, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? allOf = null, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? anyOf = null, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? oneOf = null, Draft201909MetaApplicator? not = null)
{
    this._menesJsonElementBacking = default;
this.additionalItems = Menes.JsonValueBacking.From(additionalItems);
this.unevaluatedItems = Menes.JsonValueBacking.From(unevaluatedItems);
this.items = items;
this.contains = Menes.JsonValueBacking.From(contains);
this.additionalProperties = Menes.JsonValueBacking.From(additionalProperties);
this.unevaluatedProperties = Menes.JsonValueBacking.From(unevaluatedProperties);
this.properties = Menes.JsonValueBacking.From(properties);
this.patternProperties = Menes.JsonValueBacking.From(patternProperties);
this.dependentSchemas = Menes.JsonValueBacking.From(dependentSchemas);
this.propertyNames = Menes.JsonValueBacking.From(propertyNames);
this.@if = Menes.JsonValueBacking.From(@if);
this.then = Menes.JsonValueBacking.From(then);
this.@else = Menes.JsonValueBacking.From(@else);
this.allOf = Menes.JsonValueBacking.From(allOf);
this.anyOf = Menes.JsonValueBacking.From(anyOf);
this.oneOf = Menes.JsonValueBacking.From(oneOf);
this.not = Menes.JsonValueBacking.From(not);
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
this._menesBooleanTypeBacking = default;
}
public Draft201909MetaApplicator(Menes.JsonBoolean value)
{
    this._menesJsonElementBacking = default;
    this._menesBooleanTypeBacking = value;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
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
}
private Draft201909MetaApplicator(Menes.JsonValueBacking additionalItems, Menes.JsonValueBacking unevaluatedItems, Draft201909MetaApplicator.ItemsEntity? items, Menes.JsonValueBacking contains, Menes.JsonValueBacking additionalProperties, Menes.JsonValueBacking unevaluatedProperties, Menes.JsonValueBacking properties, Menes.JsonValueBacking patternProperties, Menes.JsonValueBacking dependentSchemas, Menes.JsonValueBacking propertyNames, Menes.JsonValueBacking @if, Menes.JsonValueBacking then, Menes.JsonValueBacking @else, Menes.JsonValueBacking allOf, Menes.JsonValueBacking anyOf, Menes.JsonValueBacking oneOf, Menes.JsonValueBacking not, Menes.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
{
    this._menesJsonElementBacking = default;
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
this._menesBooleanTypeBacking = _menesBooleanTypeBacking;
this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
}
public static implicit operator Menes.JsonBoolean(Draft201909MetaApplicator value)
{
    return value.As<Menes.JsonBoolean>();
}
public static implicit operator Draft201909MetaApplicator(Menes.JsonBoolean value)
{
    return value.As<Draft201909MetaApplicator>();
}
public static implicit operator bool(Draft201909MetaApplicator value)
{
    return (bool)(Menes.JsonBoolean)value;
}
public static implicit operator Draft201909MetaApplicator(bool value)
{
    return (Draft201909MetaApplicator)(Menes.JsonBoolean)value;
}
/// <inheritdoc />
public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
/// <inheritdoc />
public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
/// <inheritdoc />
public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
/// <inheritdoc />
public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
public Draft201909MetaApplicator? AdditionalItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesAdditionalItemsUtf8JsonPropertyName.Span) : this.additionalItems.Value<Draft201909MetaApplicator>();
public Draft201909MetaApplicator? UnevaluatedItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesUnevaluatedItemsUtf8JsonPropertyName.Span) : this.unevaluatedItems.Value<Draft201909MetaApplicator>();
public Draft201909MetaApplicator.ItemsEntity? Items => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity>(_MenesItemsUtf8JsonPropertyName.Span) : this.items;
public Draft201909MetaApplicator? Contains => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesContainsUtf8JsonPropertyName.Span) : this.contains.Value<Draft201909MetaApplicator>();
public Draft201909MetaApplicator? AdditionalProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesAdditionalPropertiesUtf8JsonPropertyName.Span) : this.additionalProperties.Value<Draft201909MetaApplicator>();
public Draft201909MetaApplicator? UnevaluatedProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesUnevaluatedPropertiesUtf8JsonPropertyName.Span) : this.unevaluatedProperties.Value<Draft201909MetaApplicator>();
public Draft201909MetaApplicator.PropertiesEntity? Properties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.PropertiesEntity>(_MenesPropertiesUtf8JsonPropertyName.Span) : this.properties.Value<Draft201909MetaApplicator.PropertiesEntity>();
public Draft201909MetaApplicator.PatternPropertiesEntity? PatternProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.PatternPropertiesEntity>(_MenesPatternPropertiesUtf8JsonPropertyName.Span) : this.patternProperties.Value<Draft201909MetaApplicator.PatternPropertiesEntity>();
public Draft201909MetaApplicator.DependentSchemasEntity? DependentSchemas => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.DependentSchemasEntity>(_MenesDependentSchemasUtf8JsonPropertyName.Span) : this.dependentSchemas.Value<Draft201909MetaApplicator.DependentSchemasEntity>();
public Draft201909MetaApplicator? PropertyNames => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesPropertyNamesUtf8JsonPropertyName.Span) : this.propertyNames.Value<Draft201909MetaApplicator>();
public Draft201909MetaApplicator? If => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesIfUtf8JsonPropertyName.Span) : this.@if.Value<Draft201909MetaApplicator>();
public Draft201909MetaApplicator? Then => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesThenUtf8JsonPropertyName.Span) : this.then.Value<Draft201909MetaApplicator>();
public Draft201909MetaApplicator? Else => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesElseUtf8JsonPropertyName.Span) : this.@else.Value<Draft201909MetaApplicator>();
public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? AllOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesAllOfUtf8JsonPropertyName.Span) : this.allOf.Value<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>();
public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? AnyOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesAnyOfUtf8JsonPropertyName.Span) : this.anyOf.Value<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>();
public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? OneOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesOneOfUtf8JsonPropertyName.Span) : this.oneOf.Value<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>();
public Draft201909MetaApplicator? Not => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator>(_MenesNotUtf8JsonPropertyName.Span) : this.not.Value<Draft201909MetaApplicator>();
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
writer.WriteStartObject();
    if (this.additionalItems is Menes.JsonValueBacking additionalItems && !additionalItems.IsNull)
    {
        writer.WritePropertyName(_MenesAdditionalItemsEncodedJsonPropertyName);
        additionalItems.WriteTo(writer);
    }
    if (this.unevaluatedItems is Menes.JsonValueBacking unevaluatedItems && !unevaluatedItems.IsNull)
    {
        writer.WritePropertyName(_MenesUnevaluatedItemsEncodedJsonPropertyName);
        unevaluatedItems.WriteTo(writer);
    }
    if (this.items is Draft201909MetaApplicator.ItemsEntity items)
    {
        writer.WritePropertyName(_MenesItemsEncodedJsonPropertyName);
        items.WriteTo(writer);
    }
    if (this.contains is Menes.JsonValueBacking contains && !contains.IsNull)
    {
        writer.WritePropertyName(_MenesContainsEncodedJsonPropertyName);
        contains.WriteTo(writer);
    }
    if (this.additionalProperties is Menes.JsonValueBacking additionalProperties && !additionalProperties.IsNull)
    {
        writer.WritePropertyName(_MenesAdditionalPropertiesEncodedJsonPropertyName);
        additionalProperties.WriteTo(writer);
    }
    if (this.unevaluatedProperties is Menes.JsonValueBacking unevaluatedProperties && !unevaluatedProperties.IsNull)
    {
        writer.WritePropertyName(_MenesUnevaluatedPropertiesEncodedJsonPropertyName);
        unevaluatedProperties.WriteTo(writer);
    }
    if (this.properties is Menes.JsonValueBacking properties && !properties.IsNull)
    {
        writer.WritePropertyName(_MenesPropertiesEncodedJsonPropertyName);
        properties.WriteTo(writer);
    }
    if (this.patternProperties is Menes.JsonValueBacking patternProperties && !patternProperties.IsNull)
    {
        writer.WritePropertyName(_MenesPatternPropertiesEncodedJsonPropertyName);
        patternProperties.WriteTo(writer);
    }
    if (this.dependentSchemas is Menes.JsonValueBacking dependentSchemas && !dependentSchemas.IsNull)
    {
        writer.WritePropertyName(_MenesDependentSchemasEncodedJsonPropertyName);
        dependentSchemas.WriteTo(writer);
    }
    if (this.propertyNames is Menes.JsonValueBacking propertyNames && !propertyNames.IsNull)
    {
        writer.WritePropertyName(_MenesPropertyNamesEncodedJsonPropertyName);
        propertyNames.WriteTo(writer);
    }
    if (this.@if is Menes.JsonValueBacking @if && !@if.IsNull)
    {
        writer.WritePropertyName(_MenesIfEncodedJsonPropertyName);
        @if.WriteTo(writer);
    }
    if (this.then is Menes.JsonValueBacking then && !then.IsNull)
    {
        writer.WritePropertyName(_MenesThenEncodedJsonPropertyName);
        then.WriteTo(writer);
    }
    if (this.@else is Menes.JsonValueBacking @else && !@else.IsNull)
    {
        writer.WritePropertyName(_MenesElseEncodedJsonPropertyName);
        @else.WriteTo(writer);
    }
    if (this.allOf is Menes.JsonValueBacking allOf && !allOf.IsNull)
    {
        writer.WritePropertyName(_MenesAllOfEncodedJsonPropertyName);
        allOf.WriteTo(writer);
    }
    if (this.anyOf is Menes.JsonValueBacking anyOf && !anyOf.IsNull)
    {
        writer.WritePropertyName(_MenesAnyOfEncodedJsonPropertyName);
        anyOf.WriteTo(writer);
    }
    if (this.oneOf is Menes.JsonValueBacking oneOf && !oneOf.IsNull)
    {
        writer.WritePropertyName(_MenesOneOfEncodedJsonPropertyName);
        oneOf.WriteTo(writer);
    }
    if (this.not is Menes.JsonValueBacking not && !not.IsNull)
    {
        writer.WritePropertyName(_MenesNotEncodedJsonPropertyName);
        not.WriteTo(writer);
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
    return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaApplicator))
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
if (!this.additionalItems.IsNull)
{
    return false;
}
if (!this.unevaluatedItems.IsNull)
{
    return false;
}
if (this.items is not null)
{
    return false;
}
if (!this.contains.IsNull)
{
    return false;
}
if (!this.additionalProperties.IsNull)
{
    return false;
}
if (!this.unevaluatedProperties.IsNull)
{
    return false;
}
if (!this.properties.IsNull)
{
    return false;
}
if (!this.patternProperties.IsNull)
{
    return false;
}
if (!this.dependentSchemas.IsNull)
{
    return false;
}
if (!this.propertyNames.IsNull)
{
    return false;
}
if (!this.@if.IsNull)
{
    return false;
}
if (!this.then.IsNull)
{
    return false;
}
if (!this.@else.IsNull)
{
    return false;
}
if (!this.allOf.IsNull)
{
    return false;
}
if (!this.anyOf.IsNull)
{
    return false;
}
if (!this.oneOf.IsNull)
{
    return false;
}
if (!this.not.IsNull)
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
public readonly struct ItemsEntity : Menes.IJsonValue
{
public static readonly ItemsEntity Null = default(ItemsEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
public ItemsEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
}
public static implicit operator Draft201909MetaApplicator(ItemsEntity value)
{
    return value.As<Draft201909MetaApplicator>();
}
public static implicit operator ItemsEntity(Draft201909MetaApplicator value)
{
    return value.As<Draft201909MetaApplicator.ItemsEntity>();
}
public static implicit operator Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(ItemsEntity value)
{
    return value.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>();
}
public static implicit operator ItemsEntity(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity value)
{
    return value.As<Draft201909MetaApplicator.ItemsEntity>();
}
public static implicit operator ItemsEntity(System.Collections.Immutable.ImmutableArray<Draft201909MetaApplicator> items)
{
    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaApplicator>();
    foreach (var item in items)
    {
        arrayBuilder.Add((Draft201909MetaApplicator)item);
    }
    return (ItemsEntity)(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity)arrayBuilder.ToImmutable();
}
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
ItemsEntity flattened = Menes.JsonValue.FlattenToJsonElementBacking(this);
result = ValidateAnyOf(flattened, result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);
return result;
Menes.ValidationResult ValidateAnyOf(in Draft201909MetaApplicator.ItemsEntity that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
{
if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush0)
{
    aklPush0.Push("https://json-schema.org/draft/2019-09/meta/applicator#/properties/items/anyOf/0");
}
var anyOf0 = that.AsDraft201909MetaApplicator();
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
    aklPush1.Push("https://json-schema.org/draft/2019-09/meta/applicator#/properties/items/anyOf/1");
}
var anyOf1 = that.AsSchemaArrayEntity();
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
if (typeof(T) == typeof(Draft201909MetaApplicator.ItemsEntity))
{
    return this.Validate().Valid;
}
    return this.As<T>().Validate().Valid;
}
public readonly Draft201909MetaApplicator AsDraft201909MetaApplicator()
{
    return this.As<Draft201909MetaApplicator>();
}
public readonly Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity AsSchemaArrayEntity()
{
    return this.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>();
}
private bool AllBackingFieldsAreNull()
{
return true;
}
public readonly struct SchemaArrayEntity : Menes.IJsonValue, System.Collections.IEnumerable
{
public static readonly SchemaArrayEntity Null = default(SchemaArrayEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonValueBacking>? _menesArrayValueBacking;
public SchemaArrayEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesArrayValueBacking = default;
}
public SchemaArrayEntity(System.Collections.Immutable.ImmutableArray<Draft201909MetaApplicator> value)
{
    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonValueBacking>();
    foreach (var item in value)
    {
        arrayBuilder.Add(Menes.JsonValueBacking.From<Draft201909MetaApplicator>(item));
    }
    this._menesArrayValueBacking = arrayBuilder.ToImmutable();
    this._menesJsonElementBacking = default;
}
public static implicit operator SchemaArrayEntity(System.Collections.Immutable.ImmutableArray<Draft201909MetaApplicator> items)
{
    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(items);
}
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
writer.WriteStartArray();
foreach (var item in this._menesArrayValueBacking)
{
    item.WriteTo(writer);
}
writer.WriteEndArray();
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
if (typeof(T) == typeof(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity))
{
    return this.Validate().Valid;
}
    return this.As<T>().Validate().Valid;
}
public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity.MenesArrayEnumerator GetEnumerator(){    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity.MenesArrayEnumerator(this);}System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){    return this.GetEnumerator();}private bool AllBackingFieldsAreNull()
{
if (this._menesArrayValueBacking is not null)
{
    return false;
}
return true;
}
/// <summary>
/// An enumerator for the array values in a <see cref="SchemaArrayEntity"/>.
/// </summary>
public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Draft201909MetaApplicator>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Draft201909MetaApplicator>, System.Collections.IEnumerator
{
    private SchemaArrayEntity instance;
    private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    internal MenesArrayEnumerator(SchemaArrayEntity instance)
    {
        this.instance = instance;
        if (this.instance.HasJsonElement)
        {
            this.index = -2;
            this.hasJsonEnumerator = true;
            this.jsonEnumerator = this.instance.JsonElement.EnumerateArray();
        }
        else
        {
            this.index = -1;
            this.hasJsonEnumerator = false;
            this.jsonEnumerator = default;
        }
    }
    /// <inheritdoc/>
    public Draft201909MetaApplicator Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Draft201909MetaApplicator(this.jsonEnumerator.Current);
            }
            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonValueBacking> array && this.index >= 0 && this.index < array.Length)
            {
                return array[this.index].Value<Draft201909MetaApplicator>() ?? default;
            }
            return default;
        }
    }
    /// <inheritdoc/>
    object System.Collections.IEnumerator.Current => this.Current;
    /// <summary>
    /// Returns a fresh copy of the enumerator
    /// </summary>
    /// <returns>An enumerator for the array values in a <see cref="SchemaArrayEntity"/>.</returns>
    public MenesArrayEnumerator GetEnumerator()
    {
        MenesArrayEnumerator result = this;
        result.Reset();
        return result;
    }
    /// <inheritdoc/>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    /// <inheritdoc/>
    System.Collections.Generic.IEnumerator<Draft201909MetaApplicator> System.Collections.Generic.IEnumerable<Draft201909MetaApplicator>.GetEnumerator()
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
        else
        {
            this.index = -1;
        }
    }
    /// <inheritdoc/>
    public bool MoveNext()
    {
        if (this.hasJsonEnumerator)
        {
            return this.jsonEnumerator.MoveNext();
        }
        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonValueBacking> array && this.index < array.Length)
        {
            this.index++;
            return true;
        }
        return false;
    }
}
}
}
public readonly struct PropertiesEntity : Menes.IJsonObject
{
public static readonly PropertiesEntity Null = default(PropertiesEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking;
public PropertiesEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty>.Empty;
}
private PropertiesEntity(in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking)
{
    this._menesJsonElementBacking = default;
this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
}
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
    return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaApplicator.PropertiesEntity))
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
            property = additionalProperty.Value<Draft201909MetaApplicator>()?.As<T>() ?? default;
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
            property = additionalProperty.Value<Draft201909MetaApplicator>()?.As<T>() ?? default;
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
            property = additionalProperty.Value<Draft201909MetaApplicator>()?.As<T>() ?? default;
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
public readonly struct PatternPropertiesEntity : Menes.IJsonObject
{
public static readonly PatternPropertiesEntity Null = default(PatternPropertiesEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking;
public PatternPropertiesEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty>.Empty;
}
private PatternPropertiesEntity(in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking)
{
    this._menesJsonElementBacking = default;
this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
}
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
    return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaApplicator.PatternPropertiesEntity))
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
            property = additionalProperty.Value<Draft201909MetaApplicator>()?.As<T>() ?? default;
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
            property = additionalProperty.Value<Draft201909MetaApplicator>()?.As<T>() ?? default;
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
            property = additionalProperty.Value<Draft201909MetaApplicator>()?.As<T>() ?? default;
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
public readonly struct PropertyNamesEntity : Menes.IJsonValue
{
public static readonly PropertyNamesEntity Null = default(PropertyNamesEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
public PropertyNamesEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
}
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
if (typeof(T) == typeof(Draft201909MetaApplicator.PatternPropertiesEntity.PropertyNamesEntity))
{
    return this.Validate().Valid;
}
    return this.As<T>().Validate().Valid;
}
private bool AllBackingFieldsAreNull()
{
return true;
}
}
}
public readonly struct DependentSchemasEntity : Menes.IJsonObject
{
public static readonly DependentSchemasEntity Null = default(DependentSchemasEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking;
public DependentSchemasEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty>.Empty;
}
private DependentSchemasEntity(in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking)
{
    this._menesJsonElementBacking = default;
this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
}
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
    return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaApplicator.DependentSchemasEntity))
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
            property = additionalProperty.Value<Draft201909MetaApplicator>()?.As<T>() ?? default;
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
            property = additionalProperty.Value<Draft201909MetaApplicator>()?.As<T>() ?? default;
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
            property = additionalProperty.Value<Draft201909MetaApplicator>()?.As<T>() ?? default;
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
}
}
