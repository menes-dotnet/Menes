// <copyright file="Draft201909MetaValidation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace TestSpace
{
public readonly struct Draft201909MetaValidation : Menes.IJsonObject
{
public static readonly Draft201909MetaValidation Null = default(Draft201909MetaValidation);
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
private static readonly System.ReadOnlyMemory<byte>  _MenesMultipleOfUtf8JsonPropertyName = new byte[] { 109, 117, 108, 116, 105, 112, 108, 101, 79, 102 };
private static readonly System.ReadOnlyMemory<byte>  _MenesMaximumUtf8JsonPropertyName = new byte[] { 109, 97, 120, 105, 109, 117, 109 };
private static readonly System.ReadOnlyMemory<byte>  _MenesExclusiveMaximumUtf8JsonPropertyName = new byte[] { 101, 120, 99, 108, 117, 115, 105, 118, 101, 77, 97, 120, 105, 109, 117, 109 };
private static readonly System.ReadOnlyMemory<byte>  _MenesMinimumUtf8JsonPropertyName = new byte[] { 109, 105, 110, 105, 109, 117, 109 };
private static readonly System.ReadOnlyMemory<byte>  _MenesExclusiveMinimumUtf8JsonPropertyName = new byte[] { 101, 120, 99, 108, 117, 115, 105, 118, 101, 77, 105, 110, 105, 109, 117, 109 };
private static readonly System.ReadOnlyMemory<byte>  _MenesMaxLengthUtf8JsonPropertyName = new byte[] { 109, 97, 120, 76, 101, 110, 103, 116, 104 };
private static readonly System.ReadOnlyMemory<byte>  _MenesMinLengthUtf8JsonPropertyName = new byte[] { 109, 105, 110, 76, 101, 110, 103, 116, 104 };
private static readonly System.ReadOnlyMemory<byte>  _MenesPatternUtf8JsonPropertyName = new byte[] { 112, 97, 116, 116, 101, 114, 110 };
private static readonly System.ReadOnlyMemory<byte>  _MenesMaxItemsUtf8JsonPropertyName = new byte[] { 109, 97, 120, 73, 116, 101, 109, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesMinItemsUtf8JsonPropertyName = new byte[] { 109, 105, 110, 73, 116, 101, 109, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesUniqueItemsUtf8JsonPropertyName = new byte[] { 117, 110, 105, 113, 117, 101, 73, 116, 101, 109, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesMaxContainsUtf8JsonPropertyName = new byte[] { 109, 97, 120, 67, 111, 110, 116, 97, 105, 110, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesMinContainsUtf8JsonPropertyName = new byte[] { 109, 105, 110, 67, 111, 110, 116, 97, 105, 110, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesMaxPropertiesUtf8JsonPropertyName = new byte[] { 109, 97, 120, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesMinPropertiesUtf8JsonPropertyName = new byte[] { 109, 105, 110, 80, 114, 111, 112, 101, 114, 116, 105, 101, 115 };
private static readonly System.ReadOnlyMemory<byte>  _MenesRequiredUtf8JsonPropertyName = new byte[] { 114, 101, 113, 117, 105, 114, 101, 100 };
private static readonly System.ReadOnlyMemory<byte>  _MenesDependentRequiredUtf8JsonPropertyName = new byte[] { 100, 101, 112, 101, 110, 100, 101, 110, 116, 82, 101, 113, 117, 105, 114, 101, 100 };
private static readonly System.ReadOnlyMemory<byte>  _MenesConstUtf8JsonPropertyName = new byte[] { 99, 111, 110, 115, 116 };
private static readonly System.ReadOnlyMemory<byte>  _MenesEnumUtf8JsonPropertyName = new byte[] { 101, 110, 117, 109 };
private static readonly System.ReadOnlyMemory<byte>  _MenesTypeUtf8JsonPropertyName = new byte[] { 116, 121, 112, 101 };
private static readonly  System.Text.Json.JsonEncodedText _MenesMultipleOfEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMultipleOfUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesMaximumEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMaximumUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesExclusiveMaximumEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesExclusiveMaximumUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesMinimumEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMinimumUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesExclusiveMinimumEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesExclusiveMinimumUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesMaxLengthEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMaxLengthUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesMinLengthEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMinLengthUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesPatternEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesPatternUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesMaxItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMaxItemsUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesMinItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMinItemsUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesUniqueItemsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesUniqueItemsUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesMaxContainsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMaxContainsUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesMinContainsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMinContainsUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesMaxPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMaxPropertiesUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesMinPropertiesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMinPropertiesUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesRequiredEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesRequiredUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesDependentRequiredEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDependentRequiredUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesConstEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesConstUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesEnumEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesEnumUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesTypeEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesTypeUtf8JsonPropertyName.Span);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
private readonly Draft201909MetaValidation.MultipleOfValue? multipleOf;
private readonly Menes.JsonNumber? maximum;
private readonly Menes.JsonNumber? exclusiveMaximum;
private readonly Menes.JsonNumber? minimum;
private readonly Menes.JsonNumber? exclusiveMinimum;
private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxLength;
private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minLength;
private readonly Menes.JsonString? pattern;
private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxItems;
private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minItems;
private readonly Menes.JsonBoolean? uniqueItems;
private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxContains;
private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minContains;
private readonly Draft201909MetaValidation.NonNegativeIntegerValue? maxProperties;
private readonly Draft201909MetaValidation.NonNegativeIntegerValue? minProperties;
private readonly Draft201909MetaValidation.StringArrayEntity? required;
private readonly Draft201909MetaValidation.DependentRequiredEntity? dependentRequired;
private readonly Draft201909MetaValidation.ConstEntity? @const;
private readonly Draft201909MetaValidation.EnumArray? @enum;
private readonly Draft201909MetaValidation.TypeEntity? type;
public Draft201909MetaValidation(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
this._menesBooleanTypeBacking = default;
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
}
public Draft201909MetaValidation(Draft201909MetaValidation.MultipleOfValue? multipleOf = null, Menes.JsonNumber? maximum = null, Menes.JsonNumber? exclusiveMaximum = null, Menes.JsonNumber? minimum = null, Menes.JsonNumber? exclusiveMinimum = null, Draft201909MetaValidation.NonNegativeIntegerValue? maxLength = null, Draft201909MetaValidation.NonNegativeIntegerValue? minLength = null, Menes.JsonString? pattern = null, Draft201909MetaValidation.NonNegativeIntegerValue? maxItems = null, Draft201909MetaValidation.NonNegativeIntegerValue? minItems = null, Menes.JsonBoolean? uniqueItems = null, Draft201909MetaValidation.NonNegativeIntegerValue? maxContains = null, Draft201909MetaValidation.NonNegativeIntegerValue? minContains = null, Draft201909MetaValidation.NonNegativeIntegerValue? maxProperties = null, Draft201909MetaValidation.NonNegativeIntegerValue? minProperties = null, Draft201909MetaValidation.StringArrayEntity? required = null, Draft201909MetaValidation.DependentRequiredEntity? dependentRequired = null, Draft201909MetaValidation.ConstEntity? @const = null, Draft201909MetaValidation.EnumArray? @enum = null, Draft201909MetaValidation.TypeEntity? type = null)
{
    this._menesJsonElementBacking = default;
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
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
this._menesBooleanTypeBacking = default;
}
public Draft201909MetaValidation(Menes.JsonBoolean value)
{
    this._menesJsonElementBacking = default;
    this._menesBooleanTypeBacking = value;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
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
}
private Draft201909MetaValidation(Draft201909MetaValidation.MultipleOfValue? multipleOf, Menes.JsonNumber? maximum, Menes.JsonNumber? exclusiveMaximum, Menes.JsonNumber? minimum, Menes.JsonNumber? exclusiveMinimum, Draft201909MetaValidation.NonNegativeIntegerValue? maxLength, Draft201909MetaValidation.NonNegativeIntegerValue? minLength, Menes.JsonString? pattern, Draft201909MetaValidation.NonNegativeIntegerValue? maxItems, Draft201909MetaValidation.NonNegativeIntegerValue? minItems, Menes.JsonBoolean? uniqueItems, Draft201909MetaValidation.NonNegativeIntegerValue? maxContains, Draft201909MetaValidation.NonNegativeIntegerValue? minContains, Draft201909MetaValidation.NonNegativeIntegerValue? maxProperties, Draft201909MetaValidation.NonNegativeIntegerValue? minProperties, Draft201909MetaValidation.StringArrayEntity? required, Draft201909MetaValidation.DependentRequiredEntity? dependentRequired, Draft201909MetaValidation.ConstEntity? @const, Draft201909MetaValidation.EnumArray? @enum, Draft201909MetaValidation.TypeEntity? type, Menes.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
{
    this._menesJsonElementBacking = default;
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
this._menesBooleanTypeBacking = _menesBooleanTypeBacking;
this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
}
public static implicit operator Menes.JsonBoolean(Draft201909MetaValidation value)
{
    return value.As<Menes.JsonBoolean>();
}
public static implicit operator Draft201909MetaValidation(Menes.JsonBoolean value)
{
    return value.As<Draft201909MetaValidation>();
}
public static implicit operator bool(Draft201909MetaValidation value)
{
    return (bool)(Menes.JsonBoolean)value;
}
public static implicit operator Draft201909MetaValidation(bool value)
{
    return (Draft201909MetaValidation)(Menes.JsonBoolean)value;
}
/// <inheritdoc />
public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
/// <inheritdoc />
public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
/// <inheritdoc />
public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
/// <inheritdoc />
public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
public Draft201909MetaValidation.MultipleOfValue? MultipleOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.MultipleOfValue>(_MenesMultipleOfUtf8JsonPropertyName.Span) : this.multipleOf;
public Menes.JsonNumber? Maximum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonNumber>(_MenesMaximumUtf8JsonPropertyName.Span) : this.maximum;
public Menes.JsonNumber? ExclusiveMaximum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonNumber>(_MenesExclusiveMaximumUtf8JsonPropertyName.Span) : this.exclusiveMaximum;
public Menes.JsonNumber? Minimum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonNumber>(_MenesMinimumUtf8JsonPropertyName.Span) : this.minimum;
public Menes.JsonNumber? ExclusiveMinimum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonNumber>(_MenesExclusiveMinimumUtf8JsonPropertyName.Span) : this.exclusiveMinimum;
public Draft201909MetaValidation.NonNegativeIntegerValue? MaxLength => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxLengthUtf8JsonPropertyName.Span) : this.maxLength;
public Draft201909MetaValidation.NonNegativeIntegerValue? MinLength => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinLengthUtf8JsonPropertyName.Span) : this.minLength;
public Menes.JsonString? Pattern => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesPatternUtf8JsonPropertyName.Span) : this.pattern;
public Draft201909MetaValidation.NonNegativeIntegerValue? MaxItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxItemsUtf8JsonPropertyName.Span) : this.maxItems;
public Draft201909MetaValidation.NonNegativeIntegerValue? MinItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinItemsUtf8JsonPropertyName.Span) : this.minItems;
public Menes.JsonBoolean? UniqueItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonBoolean>(_MenesUniqueItemsUtf8JsonPropertyName.Span) : this.uniqueItems;
public Draft201909MetaValidation.NonNegativeIntegerValue? MaxContains => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxContainsUtf8JsonPropertyName.Span) : this.maxContains;
public Draft201909MetaValidation.NonNegativeIntegerValue? MinContains => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinContainsUtf8JsonPropertyName.Span) : this.minContains;
public Draft201909MetaValidation.NonNegativeIntegerValue? MaxProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMaxPropertiesUtf8JsonPropertyName.Span) : this.maxProperties;
public Draft201909MetaValidation.NonNegativeIntegerValue? MinProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.NonNegativeIntegerValue>(_MenesMinPropertiesUtf8JsonPropertyName.Span) : this.minProperties;
public Draft201909MetaValidation.StringArrayEntity? Required => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.StringArrayEntity>(_MenesRequiredUtf8JsonPropertyName.Span) : this.required;
public Draft201909MetaValidation.DependentRequiredEntity? DependentRequired => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.DependentRequiredEntity>(_MenesDependentRequiredUtf8JsonPropertyName.Span) : this.dependentRequired;
public Draft201909MetaValidation.ConstEntity? Const => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.ConstEntity>(_MenesConstUtf8JsonPropertyName.Span) : this.@const;
public Draft201909MetaValidation.EnumArray? Enum => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.EnumArray>(_MenesEnumUtf8JsonPropertyName.Span) : this.@enum;
public Draft201909MetaValidation.TypeEntity? Type => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaValidation.TypeEntity>(_MenesTypeUtf8JsonPropertyName.Span) : this.type;
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
           return 20 + this._menesAdditionalPropertiesBacking.Length;
       }
   }
}
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
    if (this.pattern is Menes.JsonString pattern)
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
if (typeof(T) == typeof(Draft201909MetaValidation))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<Draft201909MetaValidation, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation))
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
public Draft201909MetaValidation RemoveProperty(string propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public Draft201909MetaValidation RemoveProperty(System.ReadOnlySpan<char> propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public Draft201909MetaValidation RemoveProperty(System.ReadOnlySpan<byte> propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public Draft201909MetaValidation SetProperty<T>(string name, T value)
where T : struct, Menes.IJsonValue
{
    var propertyName = System.MemoryExtensions.AsSpan(name);
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
    return this.WithPattern(value.As<Menes.JsonString>());
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
    return this.WithConst(value.As<Draft201909MetaValidation.ConstEntity>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesEnumJsonPropertyName.Span))
{
    return this.WithEnum(value.As<Draft201909MetaValidation.EnumArray>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTypeJsonPropertyName.Span))
{
    return this.WithType(value.As<Draft201909MetaValidation.TypeEntity>());
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
}
public Draft201909MetaValidation SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
where T : struct, Menes.IJsonValue
{
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
    return this.WithPattern(value.As<Menes.JsonString>());
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
    return this.WithConst(value.As<Draft201909MetaValidation.ConstEntity>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesEnumJsonPropertyName.Span))
{
    return this.WithEnum(value.As<Draft201909MetaValidation.EnumArray>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTypeJsonPropertyName.Span))
{
    return this.WithType(value.As<Draft201909MetaValidation.TypeEntity>());
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
}
public Draft201909MetaValidation SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
where T : struct, Menes.IJsonValue
{
    System.Span<char> name = stackalloc char[utf8Name.Length];
    int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
    var propertyName = name.Slice(0, writtenCount);
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
    return this.WithPattern(value.As<Menes.JsonString>());
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
    return this.WithConst(value.As<Draft201909MetaValidation.ConstEntity>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesEnumJsonPropertyName.Span))
{
    return this.WithEnum(value.As<Draft201909MetaValidation.EnumArray>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTypeJsonPropertyName.Span))
{
    return this.WithType(value.As<Draft201909MetaValidation.TypeEntity>());
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
}
public Draft201909MetaValidation.MenesPropertyEnumerator GetEnumerator(){    return new Draft201909MetaValidation.MenesPropertyEnumerator(this);}System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){    return this.GetEnumerator();}public Draft201909MetaValidation WithMultipleOf(Draft201909MetaValidation.MultipleOfValue value)
{
    return new Draft201909MetaValidation(value, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithMaximum(Menes.JsonNumber value)
{
    return new Draft201909MetaValidation(this.multipleOf, value, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithExclusiveMaximum(Menes.JsonNumber value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, value, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithMinimum(Menes.JsonNumber value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, value, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithExclusiveMinimum(Menes.JsonNumber value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, value, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithMaxLength(Draft201909MetaValidation.NonNegativeIntegerValue value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, value, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithMinLength(Draft201909MetaValidation.NonNegativeIntegerValue value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, value, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithPattern(Menes.JsonString value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, value, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithMaxItems(Draft201909MetaValidation.NonNegativeIntegerValue value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, value, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithMinItems(Draft201909MetaValidation.NonNegativeIntegerValue value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, value, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithUniqueItems(Menes.JsonBoolean value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, value, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithMaxContains(Draft201909MetaValidation.NonNegativeIntegerValue value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, value, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithMinContains(Draft201909MetaValidation.NonNegativeIntegerValue value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, value, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithMaxProperties(Draft201909MetaValidation.NonNegativeIntegerValue value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, value, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithMinProperties(Draft201909MetaValidation.NonNegativeIntegerValue value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, value, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithRequired(Draft201909MetaValidation.StringArrayEntity value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, value, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithDependentRequired(Draft201909MetaValidation.DependentRequiredEntity value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, value, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithConst(Draft201909MetaValidation.ConstEntity value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, value, this.@enum, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithEnum(Draft201909MetaValidation.EnumArray value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, value, this.type, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
}
public Draft201909MetaValidation WithType(Draft201909MetaValidation.TypeEntity value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, value, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
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
private bool TryGetPropertyAtIndex(int index, out Menes.Property<Draft201909MetaValidation> result)
{
if (this.HasJsonElement)
{
    int jsonPropertyIndex = 0;
    foreach (var property in this.JsonElement.EnumerateObject())
    {
        if (jsonPropertyIndex == index)
        {
            result = new Menes.Property<Draft201909MetaValidation>(property);
            return true;
        }
        jsonPropertyIndex++;
    }
}
int currentIndex = 0;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMultipleOfJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMaximumJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesExclusiveMaximumJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMinimumJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesExclusiveMinimumJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMaxLengthJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMinLengthJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesPatternJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMaxItemsJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMinItemsJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesUniqueItemsJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMaxContainsJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMinContainsJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMaxPropertiesJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesMinPropertiesJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesRequiredJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesDependentRequiredJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesConstJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesEnumJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, _MenesTypeJsonPropertyName);
      return true;
    }
    currentIndex++;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (currentIndex == index)
    {
        result = new Menes.Property<Draft201909MetaValidation>(this, property.NameAsMemory);
        return true;
    }
    currentIndex++;
}
    result = default;;
    return false;
}
private Draft201909MetaValidation WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
{
    return new Draft201909MetaValidation(this.multipleOf, this.maximum, this.exclusiveMaximum, this.minimum, this.exclusiveMinimum, this.maxLength, this.minLength, this.pattern, this.maxItems, this.minItems, this.uniqueItems, this.maxContains, this.minContains, this.maxProperties, this.minProperties, this.required, this.dependentRequired, this.@const, this.@enum, this.type, this._menesBooleanTypeBacking, value);
}
public readonly struct MultipleOfValue : Menes.IJsonValue
{
public static readonly MultipleOfValue Null = default(MultipleOfValue);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly Menes.JsonNumber? _menesNumberTypeBacking;
public MultipleOfValue(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesNumberTypeBacking = default;
}
public MultipleOfValue(Menes.JsonNumber value)
{
    this._menesJsonElementBacking = default;
    this._menesNumberTypeBacking = value;
}
private MultipleOfValue(Menes.JsonNumber? _menesNumberTypeBacking)
{
    this._menesJsonElementBacking = default;
this._menesNumberTypeBacking = _menesNumberTypeBacking;
}
public static implicit operator Menes.JsonInteger(MultipleOfValue value)
{
    return value.As<Menes.JsonInteger>();
}
public static implicit operator MultipleOfValue(Menes.JsonInteger value)
{
    return value.As<Draft201909MetaValidation.MultipleOfValue>();
}
public static implicit operator Menes.JsonNumber(MultipleOfValue value)
{
    return (Menes.JsonNumber)value;
}
public static implicit operator MultipleOfValue(Menes.JsonNumber value)
{
    return (Draft201909MetaValidation.MultipleOfValue)value;
}
public static implicit operator int(MultipleOfValue value)
{
    return (int)(Menes.JsonNumber)value;
}
public static implicit operator MultipleOfValue(int value)
{
    return (Draft201909MetaValidation.MultipleOfValue)(Menes.JsonNumber)value;
}
public static implicit operator long(MultipleOfValue value)
{
    return (long)(Menes.JsonNumber)value;
}
public static implicit operator MultipleOfValue(long value)
{
    return (Draft201909MetaValidation.MultipleOfValue)(Menes.JsonNumber)value;
}
public static implicit operator double(MultipleOfValue value)
{
    return (double)(Menes.JsonNumber)value;
}
public static implicit operator MultipleOfValue(double value)
{
    return (Draft201909MetaValidation.MultipleOfValue)(Menes.JsonNumber)value;
}
public static implicit operator float(MultipleOfValue value)
{
    return (float)(Menes.JsonNumber)value;
}
public static implicit operator MultipleOfValue(float value)
{
    return (Draft201909MetaValidation.MultipleOfValue)(Menes.JsonNumber)value;
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
        this._menesNumberTypeBacking?.WriteTo(writer);
}
/// <inheritdoc />
public T As<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(MultipleOfValue))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<MultipleOfValue, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation.MultipleOfValue))
{
    return this.Validate().Valid;
}
    return this.As<T>().Validate().Valid;
}
private bool AllBackingFieldsAreNull()
{
if (this._menesNumberTypeBacking is not null)
{
    return false;
}
return true;
}
}
public readonly struct NonNegativeIntegerValue : Menes.IJsonValue
{
public static readonly NonNegativeIntegerValue Null = default(NonNegativeIntegerValue);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly Menes.JsonInteger? _menesIntegerTypeBacking;
public NonNegativeIntegerValue(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesIntegerTypeBacking = default;
}
public NonNegativeIntegerValue(Menes.JsonInteger value)
{
    this._menesJsonElementBacking = default;
    this._menesIntegerTypeBacking = value;
}
private NonNegativeIntegerValue(Menes.JsonInteger? _menesIntegerTypeBacking)
{
    this._menesJsonElementBacking = default;
this._menesIntegerTypeBacking = _menesIntegerTypeBacking;
}
public static implicit operator Menes.JsonInteger(NonNegativeIntegerValue value)
{
    return value.As<Menes.JsonInteger>();
}
public static implicit operator NonNegativeIntegerValue(Menes.JsonInteger value)
{
    return value.As<Draft201909MetaValidation.NonNegativeIntegerValue>();
}
public static implicit operator Menes.JsonNumber(NonNegativeIntegerValue value)
{
    return value.As<Menes.JsonNumber>();
}
public static implicit operator NonNegativeIntegerValue(Menes.JsonNumber value)
{
    return value.As<Draft201909MetaValidation.NonNegativeIntegerValue>();
}
public static implicit operator long(NonNegativeIntegerValue value)
{
    return (long)(Menes.JsonInteger)value;
}
public static implicit operator NonNegativeIntegerValue(long value)
{
    return (Draft201909MetaValidation.NonNegativeIntegerValue)(Menes.JsonInteger)value;
}
public static implicit operator int(NonNegativeIntegerValue value)
{
    return (int)(Menes.JsonInteger)value;
}
public static implicit operator NonNegativeIntegerValue(int value)
{
    return (Draft201909MetaValidation.NonNegativeIntegerValue)(Menes.JsonInteger)value;
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
        this._menesIntegerTypeBacking?.WriteTo(writer);
}
/// <inheritdoc />
public T As<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(NonNegativeIntegerValue))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<NonNegativeIntegerValue, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation.NonNegativeIntegerValue))
{
    return this.Validate().Valid;
}
    return this.As<T>().Validate().Valid;
}
private bool AllBackingFieldsAreNull()
{
if (this._menesIntegerTypeBacking is not null)
{
    return false;
}
return true;
}
}
public readonly struct StringArrayEntity : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonString>, System.Collections.IEnumerable
{
public static readonly StringArrayEntity Null = default(StringArrayEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonString>? _menesArrayValueBacking;
public StringArrayEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesArrayValueBacking = default;
}
public StringArrayEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonString> value)
{
    this._menesArrayValueBacking = value;
    this._menesJsonElementBacking = default;
}
public static implicit operator StringArrayEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonString> items)
{
    return new Draft201909MetaValidation.StringArrayEntity(items);
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
if (typeof(T) == typeof(StringArrayEntity))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<StringArrayEntity, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation.StringArrayEntity))
{
    return this.Validate().Valid;
}
    return this.As<T>().Validate().Valid;
}
public Draft201909MetaValidation.StringArrayEntity.MenesArrayEnumerator GetEnumerator(){    return new Draft201909MetaValidation.StringArrayEntity.MenesArrayEnumerator(this);}System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){    return this.GetEnumerator();}System.Collections.Generic.IEnumerator<Menes.JsonString> System.Collections.Generic.IEnumerable<Menes.JsonString>.GetEnumerator(){    return this.GetEnumerator();}public StringArrayEntity Add<T1>(T1 item1)
    where T1 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonString>());
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity Add<T1, T2>(T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonString>());
    arrayBuilder.Add(item2.As<Menes.JsonString>());
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonString>());
    arrayBuilder.Add(item2.As<Menes.JsonString>());
    arrayBuilder.Add(item3.As<Menes.JsonString>());
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonString>());
    arrayBuilder.Add(item2.As<Menes.JsonString>());
    arrayBuilder.Add(item3.As<Menes.JsonString>());
    arrayBuilder.Add(item4.As<Menes.JsonString>());
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity Add<T>(params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<Menes.JsonString>());
}
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity Insert<T>(int index, T item1)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonString>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity Insert<T1, T2>(int index, T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonString>());
    arrayBuilder.Add(item2.As<Menes.JsonString>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonString>());
    arrayBuilder.Add(item2.As<Menes.JsonString>());
    arrayBuilder.Add(item3.As<Menes.JsonString>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonString>());
    arrayBuilder.Add(item2.As<Menes.JsonString>());
    arrayBuilder.Add(item3.As<Menes.JsonString>());
    arrayBuilder.Add(item4.As<Menes.JsonString>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity Insert<T>(int index, params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<Menes.JsonString>());
}
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity RemoveAt(int index)
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
int currentIndex = 0;
bool removed = false;
foreach(var item in this._menesArrayValueBacking)
{
    if (currentIndex != index)
    {
        arrayBuilder.Add(item);
    }
    else
    {
        removed = true;
    }
    currentIndex++;
}
if (!removed)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
public StringArrayEntity RemoveIf(System.Predicate<Menes.JsonString> condition)
{
    return this.RemoveIf<Menes.JsonString>(condition);
}
public StringArrayEntity RemoveIf<T>(System.Predicate<T> condition)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
foreach(var item in this._menesArrayValueBacking)
{
    if (!condition(item.As<T>()))
    {
        arrayBuilder.Add(item);
    }
}
return new Draft201909MetaValidation.StringArrayEntity(arrayBuilder.ToImmutable());
}
private bool AllBackingFieldsAreNull()
{
if (this._menesArrayValueBacking is not null)
{
    return false;
}
return true;
}
/// <summary>
/// An enumerator for the array values in a <see cref="StringArrayEntity"/>.
/// </summary>
public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonString>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonString>, System.Collections.IEnumerator
{
    private StringArrayEntity instance;
    private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    internal MenesArrayEnumerator(StringArrayEntity instance)
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
    public Menes.JsonString Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Menes.JsonString(this.jsonEnumerator.Current);
            }
            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonString> array && this.index >= 0 && this.index < array.Length)
            {
                return array[this.index];
            }
            return default;
        }
    }
    /// <inheritdoc/>
    object System.Collections.IEnumerator.Current => this.Current;
    /// <summary>
    /// Returns a fresh copy of the enumerator
    /// </summary>
    /// <returns>An enumerator for the array values in a <see cref="StringArrayEntity"/>.</returns>
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
    System.Collections.Generic.IEnumerator<Menes.JsonString> System.Collections.Generic.IEnumerable<Menes.JsonString>.GetEnumerator()
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
        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonString> array && this.index + 1 < array.Length)
        {
            this.index++;
            return true;
        }
        return false;
    }
}
}
public readonly struct DependentRequiredEntity : Menes.IJsonObject
{
public static readonly DependentRequiredEntity Null = default(DependentRequiredEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>> _menesAdditionalPropertiesBacking;
public DependentRequiredEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>>.Empty;
}
private DependentRequiredEntity(in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>> _menesAdditionalPropertiesBacking)
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
if (typeof(T) == typeof(DependentRequiredEntity))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<DependentRequiredEntity, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation.DependentRequiredEntity))
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
public DependentRequiredEntity RemoveProperty(string propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public DependentRequiredEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public DependentRequiredEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public DependentRequiredEntity SetProperty<T>(string name, T value)
where T : struct, Menes.IJsonValue
{
    var propertyName = System.MemoryExtensions.AsSpan(name);
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>>();
bool added = false;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (!property.NameEquals(propertyName))
    {
        arrayBuilder.Add(property);
    }
    else
    {
        arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>(propertyName, value.As<Draft201909MetaValidation.StringArrayEntity>()));
        added = true;
    }
}
if (!added)
{
        arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>(propertyName, value.As<Draft201909MetaValidation.StringArrayEntity>()));
}
return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
}
public DependentRequiredEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>>();
bool added = false;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (!property.NameEquals(propertyName))
    {
        arrayBuilder.Add(property);
    }
    else
    {
        arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>(propertyName, value.As<Draft201909MetaValidation.StringArrayEntity>()));
        added = true;
    }
}
if (!added)
{
        arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>(propertyName, value.As<Draft201909MetaValidation.StringArrayEntity>()));
}
return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
}
public DependentRequiredEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
where T : struct, Menes.IJsonValue
{
    System.Span<char> name = stackalloc char[utf8Name.Length];
    int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
    var propertyName = name.Slice(0, writtenCount);
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>>();
bool added = false;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (!property.NameEquals(propertyName))
    {
        arrayBuilder.Add(property);
    }
    else
    {
        arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>(propertyName, value.As<Draft201909MetaValidation.StringArrayEntity>()));
        added = true;
    }
}
if (!added)
{
        arrayBuilder.Add(new Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>(propertyName, value.As<Draft201909MetaValidation.StringArrayEntity>()));
}
return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
}
public Draft201909MetaValidation.DependentRequiredEntity.MenesPropertyEnumerator GetEnumerator(){    return new Draft201909MetaValidation.DependentRequiredEntity.MenesPropertyEnumerator(this);}System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){    return this.GetEnumerator();}private TPropertyValue GetPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
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
private bool TryGetPropertyAtIndex(int index, out Menes.Property<DependentRequiredEntity> result)
{
if (this.HasJsonElement)
{
    int jsonPropertyIndex = 0;
    foreach (var property in this.JsonElement.EnumerateObject())
    {
        if (jsonPropertyIndex == index)
        {
            result = new Menes.Property<DependentRequiredEntity>(property);
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
        result = new Menes.Property<DependentRequiredEntity>(this, property.NameAsMemory);
        return true;
    }
    currentIndex++;
}
    result = default;;
    return false;
}
private DependentRequiredEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>> value)
{
    return new DependentRequiredEntity(value);
}
/// <summary>
/// An enumerator for the properties in a <see cref="DependentRequiredEntity"/>.
/// </summary>
public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<DependentRequiredEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<DependentRequiredEntity>>, System.Collections.IEnumerator
{
    private DependentRequiredEntity instance;
    private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    private int propertyCount;
    internal MenesPropertyEnumerator(DependentRequiredEntity instance)
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
    public Menes.Property<DependentRequiredEntity> Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Menes.Property<DependentRequiredEntity>(this.jsonEnumerator.Current);
            }
            else if (this.index >= 0)
            {
                if (this.instance.TryGetPropertyAtIndex(this.index, out var result))
                {
                    return result;
                }
                throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
            }
            return new Menes.Property<DependentRequiredEntity>(this.instance, default);
        }
    }
    /// <inheritdoc/>
    object System.Collections.IEnumerator.Current => this.Current;
    /// <summary>
    /// Returns a fresh copy of the enumerator
    /// </summary>
    /// <returns>An enumerator for the properties in a <see cref="DependentRequiredEntity"/>.</returns>
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
    System.Collections.Generic.IEnumerator<Menes.Property<DependentRequiredEntity>> System.Collections.Generic.IEnumerable<Menes.Property<DependentRequiredEntity>>.GetEnumerator()
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
        return false;
    }
}
}
public readonly struct ConstEntity : Menes.IJsonValue
{
public static readonly ConstEntity Null = default(ConstEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
public ConstEntity(System.Text.Json.JsonElement jsonElement)
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
if (level == Menes.ValidationLevel.Verbose)
{
    string? il = null;
    string? akl = null;
    instanceLocation?.TryPeek(out il);
    absoluteKeywordLocation?.TryPeek(out akl);
    result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
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
}
/// <inheritdoc />
public T As<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(ConstEntity))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<ConstEntity, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation.ConstEntity))
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
public readonly struct EnumArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Draft201909MetaValidation.EnumArray.ItemsEntity>, System.Collections.IEnumerable
{
public static readonly EnumArray Null = default(EnumArray);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.EnumArray.ItemsEntity>? _menesArrayValueBacking;
public EnumArray(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesArrayValueBacking = default;
}
public EnumArray(System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.EnumArray.ItemsEntity> value)
{
    this._menesArrayValueBacking = value;
    this._menesJsonElementBacking = default;
}
public static implicit operator EnumArray(System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.EnumArray.ItemsEntity> items)
{
    return new Draft201909MetaValidation.EnumArray(items);
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
if (typeof(T) == typeof(EnumArray))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<EnumArray, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation.EnumArray))
{
    return this.Validate().Valid;
}
    return this.As<T>().Validate().Valid;
}
public Draft201909MetaValidation.EnumArray.MenesArrayEnumerator GetEnumerator(){    return new Draft201909MetaValidation.EnumArray.MenesArrayEnumerator(this);}System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){    return this.GetEnumerator();}System.Collections.Generic.IEnumerator<Draft201909MetaValidation.EnumArray.ItemsEntity> System.Collections.Generic.IEnumerable<Draft201909MetaValidation.EnumArray.ItemsEntity>.GetEnumerator(){    return this.GetEnumerator();}public EnumArray Add<T1>(T1 item1)
    where T1 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray Add<T1, T2>(T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item3.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item3.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item4.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray Add<T>(params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
}
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray Insert<T>(int index, T item1)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray Insert<T1, T2>(int index, T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item3.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item3.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    arrayBuilder.Add(item4.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray Insert<T>(int index, params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.EnumArray.ItemsEntity>());
}
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray RemoveAt(int index)
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
int currentIndex = 0;
bool removed = false;
foreach(var item in this._menesArrayValueBacking)
{
    if (currentIndex != index)
    {
        arrayBuilder.Add(item);
    }
    else
    {
        removed = true;
    }
    currentIndex++;
}
if (!removed)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
public EnumArray RemoveIf(System.Predicate<Draft201909MetaValidation.EnumArray.ItemsEntity> condition)
{
    return this.RemoveIf<Draft201909MetaValidation.EnumArray.ItemsEntity>(condition);
}
public EnumArray RemoveIf<T>(System.Predicate<T> condition)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.EnumArray.ItemsEntity>();
foreach(var item in this._menesArrayValueBacking)
{
    if (!condition(item.As<T>()))
    {
        arrayBuilder.Add(item);
    }
}
return new Draft201909MetaValidation.EnumArray(arrayBuilder.ToImmutable());
}
private bool AllBackingFieldsAreNull()
{
if (this._menesArrayValueBacking is not null)
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
if (level == Menes.ValidationLevel.Verbose)
{
    string? il = null;
    string? akl = null;
    instanceLocation?.TryPeek(out il);
    absoluteKeywordLocation?.TryPeek(out akl);
    result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
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
}
/// <inheritdoc />
public T As<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(ItemsEntity))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<ItemsEntity, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation.EnumArray.ItemsEntity))
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
/// <summary>
/// An enumerator for the array values in a <see cref="EnumArray"/>.
/// </summary>
public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Draft201909MetaValidation.EnumArray.ItemsEntity>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Draft201909MetaValidation.EnumArray.ItemsEntity>, System.Collections.IEnumerator
{
    private EnumArray instance;
    private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    internal MenesArrayEnumerator(EnumArray instance)
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
    public Draft201909MetaValidation.EnumArray.ItemsEntity Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Draft201909MetaValidation.EnumArray.ItemsEntity(this.jsonEnumerator.Current);
            }
            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.EnumArray.ItemsEntity> array && this.index >= 0 && this.index < array.Length)
            {
                return array[this.index];
            }
            return default;
        }
    }
    /// <inheritdoc/>
    object System.Collections.IEnumerator.Current => this.Current;
    /// <summary>
    /// Returns a fresh copy of the enumerator
    /// </summary>
    /// <returns>An enumerator for the array values in a <see cref="EnumArray"/>.</returns>
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
    System.Collections.Generic.IEnumerator<Draft201909MetaValidation.EnumArray.ItemsEntity> System.Collections.Generic.IEnumerable<Draft201909MetaValidation.EnumArray.ItemsEntity>.GetEnumerator()
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
        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.EnumArray.ItemsEntity> array && this.index + 1 < array.Length)
        {
            this.index++;
            return true;
        }
        return false;
    }
}
}
public readonly struct TypeEntity : Menes.IJsonValue
{
public static readonly TypeEntity Null = default(TypeEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly Draft201909MetaValidation.TypeEntity.SimpleTypesEntity? _menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking;
private readonly Draft201909MetaValidation.TypeEntity.AnyOf1Array? _menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking;
public TypeEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking = default;
this._menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking = default;
}
public TypeEntity(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity value)
{
    this._menesJsonElementBacking = default;
    this._menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking = value;
this._menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking = default;
}
public TypeEntity(Draft201909MetaValidation.TypeEntity.AnyOf1Array value)
{
    this._menesJsonElementBacking = default;
    this._menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking = value;
this._menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking = default;
}
private TypeEntity(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity? _menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking, Draft201909MetaValidation.TypeEntity.AnyOf1Array? _menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking)
{
    this._menesJsonElementBacking = default;
this._menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking = _menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking;
this._menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking = _menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking;
}
public static implicit operator Draft201909MetaValidation.TypeEntity.SimpleTypesEntity(TypeEntity value)
{
    return value.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
}
public static implicit operator TypeEntity(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity value)
{
    return value.As<Draft201909MetaValidation.TypeEntity>();
}
public static implicit operator Draft201909MetaValidation.TypeEntity.AnyOf1Array(TypeEntity value)
{
    return value.As<Draft201909MetaValidation.TypeEntity.AnyOf1Array>();
}
public static implicit operator TypeEntity(Draft201909MetaValidation.TypeEntity.AnyOf1Array value)
{
    return value.As<Draft201909MetaValidation.TypeEntity>();
}
public static implicit operator Menes.JsonString(TypeEntity value)
{
    return (Menes.JsonString)(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity)value;
}
public static implicit operator TypeEntity(Menes.JsonString value)
{
    return (Draft201909MetaValidation.TypeEntity)(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity)value;
}
public static implicit operator string(TypeEntity value)
{
    return (string)(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity)value;
}
public static implicit operator TypeEntity(string value)
{
    return (Draft201909MetaValidation.TypeEntity)(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity)value;
}
public static implicit operator TypeEntity(System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity> items)
{
    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
    foreach (var item in items)
    {
        arrayBuilder.Add((Draft201909MetaValidation.TypeEntity.SimpleTypesEntity)item);
    }
    return (TypeEntity)(Draft201909MetaValidation.TypeEntity.AnyOf1Array)arrayBuilder.ToImmutable();
}
public static implicit operator TypeEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonString> items)
{
    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonString>();
    foreach (var item in items)
    {
        arrayBuilder.Add((Menes.JsonString)item);
    }
    return (TypeEntity)(Draft201909MetaValidation.TypeEntity.AnyOf1Array)arrayBuilder.ToImmutable();
}
public static implicit operator TypeEntity(System.Collections.Immutable.ImmutableArray<string> items)
{
    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<string>();
    foreach (var item in items)
    {
        arrayBuilder.Add((string)item);
    }
    return (TypeEntity)(Draft201909MetaValidation.TypeEntity.AnyOf1Array)arrayBuilder.ToImmutable();
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
result = ValidateAnyOf(this, result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);
return result;
Menes.ValidationResult ValidateAnyOf(in Draft201909MetaValidation.TypeEntity that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
{
if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush0)
{
    aklPush0.Push("https://json-schema.org/draft/2019-09/meta/validation#/properties/type/anyOf/0");
}
var anyOf0 = that.AsSimpleTypesEntity();
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
    aklPush1.Push("https://json-schema.org/draft/2019-09/meta/validation#/properties/type/anyOf/1");
}
var anyOf1 = that.AsAnyOf1Array();
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
        this._menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking?.WriteTo(writer);
        this._menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking?.WriteTo(writer);
}
/// <inheritdoc />
public T As<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(TypeEntity))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
if (typeof(T) == typeof(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity) && this._menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking is not null)
{
    return Corvus.Extensions.CastTo<T>.From(this._menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking);
}
if (typeof(T) == typeof(Draft201909MetaValidation.TypeEntity.AnyOf1Array) && this._menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking is not null)
{
    return Corvus.Extensions.CastTo<T>.From(this._menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking);
}
    return Menes.JsonValue.As<TypeEntity, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation.TypeEntity))
{
    return this.Validate().Valid;
}
if (typeof(T) == typeof(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity) && this._menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking is not null)
{
    return this._menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking.Value!.Validate().Valid;
}
if (typeof(T) == typeof(Draft201909MetaValidation.TypeEntity.AnyOf1Array) && this._menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking is not null)
{
    return this._menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking.Value!.Validate().Valid;
}
    return this.As<T>().Validate().Valid;
}
public readonly Draft201909MetaValidation.TypeEntity.SimpleTypesEntity AsSimpleTypesEntity()
{
    return this.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
}
public readonly Draft201909MetaValidation.TypeEntity.AnyOf1Array AsAnyOf1Array()
{
    return this.As<Draft201909MetaValidation.TypeEntity.AnyOf1Array>();
}
private bool AllBackingFieldsAreNull()
{
if (this._menesDraft201909MetaValidationTypeEntitySimpleTypesEntityAnyOfBacking is not null)
{
    return false;
}
if (this._menesDraft201909MetaValidationTypeEntityAnyOf1ArrayAnyOfBacking is not null)
{
    return false;
}
return true;
}
public readonly struct SimpleTypesEntity : Menes.IJsonValue
{
public static readonly SimpleTypesEntity Null = default(SimpleTypesEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly Menes.JsonString? _menesStringTypeBacking;
public SimpleTypesEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesStringTypeBacking = default;
}
public SimpleTypesEntity(Menes.JsonString value)
{
    this._menesJsonElementBacking = default;
    this._menesStringTypeBacking = value;
}
private SimpleTypesEntity(Menes.JsonString? _menesStringTypeBacking)
{
    this._menesJsonElementBacking = default;
this._menesStringTypeBacking = _menesStringTypeBacking;
}
public static implicit operator Menes.JsonString(SimpleTypesEntity value)
{
    return value.As<Menes.JsonString>();
}
public static implicit operator SimpleTypesEntity(Menes.JsonString value)
{
    return value.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
}
public static implicit operator string(SimpleTypesEntity value)
{
    return (string)(Menes.JsonString)value;
}
public static implicit operator SimpleTypesEntity(string value)
{
    return (Draft201909MetaValidation.TypeEntity.SimpleTypesEntity)(Menes.JsonString)value;
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
        this._menesStringTypeBacking?.WriteTo(writer);
}
/// <inheritdoc />
public T As<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(SimpleTypesEntity))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<SimpleTypesEntity, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity))
{
    return this.Validate().Valid;
}
    return this.As<T>().Validate().Valid;
}
private bool AllBackingFieldsAreNull()
{
if (this._menesStringTypeBacking is not null)
{
    return false;
}
return true;
}
}
public readonly struct AnyOf1Array : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>, System.Collections.IEnumerable
{
public static readonly AnyOf1Array Null = default(AnyOf1Array);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>? _menesArrayValueBacking;
public AnyOf1Array(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesArrayValueBacking = default;
}
public AnyOf1Array(System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity> value)
{
    this._menesArrayValueBacking = value;
    this._menesJsonElementBacking = default;
}
public static implicit operator AnyOf1Array(System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity> items)
{
    return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(items);
}
public static implicit operator AnyOf1Array(System.Collections.Immutable.ImmutableArray<Menes.JsonString> items)
{
    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
    foreach (var item in items)
    {
        arrayBuilder.Add((Draft201909MetaValidation.TypeEntity.SimpleTypesEntity)item);
    }
    return (AnyOf1Array)(Draft201909MetaValidation.TypeEntity.AnyOf1Array)arrayBuilder.ToImmutable();
}
public static implicit operator AnyOf1Array(System.Collections.Immutable.ImmutableArray<string> items)
{
    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
    foreach (var item in items)
    {
        arrayBuilder.Add((Draft201909MetaValidation.TypeEntity.SimpleTypesEntity)item);
    }
    return (AnyOf1Array)(Draft201909MetaValidation.TypeEntity.AnyOf1Array)arrayBuilder.ToImmutable();
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
if (typeof(T) == typeof(AnyOf1Array))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<AnyOf1Array, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(Draft201909MetaValidation.TypeEntity.AnyOf1Array))
{
    return this.Validate().Valid;
}
    return this.As<T>().Validate().Valid;
}
public Draft201909MetaValidation.TypeEntity.AnyOf1Array.MenesArrayEnumerator GetEnumerator(){    return new Draft201909MetaValidation.TypeEntity.AnyOf1Array.MenesArrayEnumerator(this);}System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){    return this.GetEnumerator();}System.Collections.Generic.IEnumerator<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity> System.Collections.Generic.IEnumerable<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>.GetEnumerator(){    return this.GetEnumerator();}public AnyOf1Array Add<T1>(T1 item1)
    where T1 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array Add<T1, T2>(T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item3.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item3.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item4.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array Add<T>(params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
}
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array Insert<T>(int index, T item1)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array Insert<T1, T2>(int index, T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item3.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item2.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item3.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    arrayBuilder.Add(item4.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array Insert<T>(int index, params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>());
}
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array RemoveAt(int index)
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
int currentIndex = 0;
bool removed = false;
foreach(var item in this._menesArrayValueBacking)
{
    if (currentIndex != index)
    {
        arrayBuilder.Add(item);
    }
    else
    {
        removed = true;
    }
    currentIndex++;
}
if (!removed)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
public AnyOf1Array RemoveIf(System.Predicate<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity> condition)
{
    return this.RemoveIf<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>(condition);
}
public AnyOf1Array RemoveIf<T>(System.Predicate<T> condition)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
foreach(var item in this._menesArrayValueBacking)
{
    if (!condition(item.As<T>()))
    {
        arrayBuilder.Add(item);
    }
}
return new Draft201909MetaValidation.TypeEntity.AnyOf1Array(arrayBuilder.ToImmutable());
}
private bool AllBackingFieldsAreNull()
{
if (this._menesArrayValueBacking is not null)
{
    return false;
}
return true;
}
/// <summary>
/// An enumerator for the array values in a <see cref="AnyOf1Array"/>.
/// </summary>
public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>, System.Collections.IEnumerator
{
    private AnyOf1Array instance;
    private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    internal MenesArrayEnumerator(AnyOf1Array instance)
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
    public Draft201909MetaValidation.TypeEntity.SimpleTypesEntity Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Draft201909MetaValidation.TypeEntity.SimpleTypesEntity(this.jsonEnumerator.Current);
            }
            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity> array && this.index >= 0 && this.index < array.Length)
            {
                return array[this.index];
            }
            return default;
        }
    }
    /// <inheritdoc/>
    object System.Collections.IEnumerator.Current => this.Current;
    /// <summary>
    /// Returns a fresh copy of the enumerator
    /// </summary>
    /// <returns>An enumerator for the array values in a <see cref="AnyOf1Array"/>.</returns>
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
    System.Collections.Generic.IEnumerator<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity> System.Collections.Generic.IEnumerable<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>.GetEnumerator()
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
        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity> array && this.index + 1 < array.Length)
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
/// An enumerator for the properties in a <see cref="Draft201909MetaValidation"/>.
/// </summary>
public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaValidation>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaValidation>>, System.Collections.IEnumerator
{
    private Draft201909MetaValidation instance;
    private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    private int propertyCount;
    internal MenesPropertyEnumerator(Draft201909MetaValidation instance)
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
    public Menes.Property<Draft201909MetaValidation> Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Menes.Property<Draft201909MetaValidation>(this.jsonEnumerator.Current);
            }
            else if (this.index >= 0)
            {
                if (this.instance.TryGetPropertyAtIndex(this.index, out var result))
                {
                    return result;
                }
                throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
            }
            return new Menes.Property<Draft201909MetaValidation>(this.instance, default);
        }
    }
    /// <inheritdoc/>
    object System.Collections.IEnumerator.Current => this.Current;
    /// <summary>
    /// Returns a fresh copy of the enumerator
    /// </summary>
    /// <returns>An enumerator for the properties in a <see cref="Draft201909MetaValidation"/>.</returns>
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
    System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaValidation>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaValidation>>.GetEnumerator()
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
        return false;
    }
}
}
}
