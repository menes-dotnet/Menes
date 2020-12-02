// <copyright file="Draft201909MetaApplicator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace DefsFeature.InvalidDefinition
{
    public readonly struct Draft201909MetaApplicator : Menes.IJsonObject<Draft201909MetaApplicator>
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
        private static readonly System.ReadOnlyMemory<char> _MenesIfJsonPropertyName = System.MemoryExtensions.AsMemory("if");
        private static readonly System.ReadOnlyMemory<char> _MenesThenJsonPropertyName = System.MemoryExtensions.AsMemory("then");
        private static readonly System.ReadOnlyMemory<char> _MenesElseJsonPropertyName = System.MemoryExtensions.AsMemory("else");
        private static readonly System.ReadOnlyMemory<char> _MenesAllOfJsonPropertyName = System.MemoryExtensions.AsMemory("allOf");
        private static readonly System.ReadOnlyMemory<char> _MenesAnyOfJsonPropertyName = System.MemoryExtensions.AsMemory("anyOf");
        private static readonly System.ReadOnlyMemory<char> _MenesOneOfJsonPropertyName = System.MemoryExtensions.AsMemory("oneOf");
        private static readonly System.ReadOnlyMemory<char> _MenesNotJsonPropertyName = System.MemoryExtensions.AsMemory("not");
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
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
        private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
        private readonly Draft201909Schema? additionalItems;
        private readonly Draft201909Schema? unevaluatedItems;
        private readonly Draft201909MetaApplicator.ItemsEntity? items;
        private readonly Draft201909Schema? contains;
        private readonly Draft201909Schema? additionalProperties;
        private readonly Draft201909Schema? unevaluatedProperties;
        private readonly Draft201909MetaApplicator.PropertiesEntity? properties;
        private readonly Draft201909MetaApplicator.PatternPropertiesEntity? patternProperties;
        private readonly Draft201909MetaApplicator.DependentSchemasEntity? dependentSchemas;
        private readonly Draft201909Schema? propertyNames;
        private readonly Draft201909Schema? @if;
        private readonly Draft201909Schema? then;
        private readonly Draft201909Schema? @else;
        private readonly Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? allOf;
        private readonly Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? anyOf;
        private readonly Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? oneOf;
        private readonly Draft201909Schema? not;
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
        public Draft201909MetaApplicator(Draft201909Schema? additionalItems = null, Draft201909Schema? unevaluatedItems = null, Draft201909MetaApplicator.ItemsEntity? items = null, Draft201909Schema? contains = null, Draft201909Schema? additionalProperties = null, Draft201909Schema? unevaluatedProperties = null, Draft201909MetaApplicator.PropertiesEntity? properties = null, Draft201909MetaApplicator.PatternPropertiesEntity? patternProperties = null, Draft201909MetaApplicator.DependentSchemasEntity? dependentSchemas = null, Draft201909Schema? propertyNames = null, Draft201909Schema? @if = null, Draft201909Schema? then = null, Draft201909Schema? @else = null, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? allOf = null, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? anyOf = null, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? oneOf = null, Draft201909Schema? not = null)
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
        private Draft201909MetaApplicator(Draft201909Schema? additionalItems, Draft201909Schema? unevaluatedItems, Draft201909MetaApplicator.ItemsEntity? items, Draft201909Schema? contains, Draft201909Schema? additionalProperties, Draft201909Schema? unevaluatedProperties, Draft201909MetaApplicator.PropertiesEntity? properties, Draft201909MetaApplicator.PatternPropertiesEntity? patternProperties, Draft201909MetaApplicator.DependentSchemasEntity? dependentSchemas, Draft201909Schema? propertyNames, Draft201909Schema? @if, Draft201909Schema? then, Draft201909Schema? @else, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? allOf, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? anyOf, Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? oneOf, Draft201909Schema? not, Menes.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
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
        public Draft201909Schema? AdditionalItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesAdditionalItemsUtf8JsonPropertyName.Span) : this.additionalItems;
        public Draft201909Schema? UnevaluatedItems => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesUnevaluatedItemsUtf8JsonPropertyName.Span) : this.unevaluatedItems;
        public Draft201909MetaApplicator.ItemsEntity? Items => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity>(_MenesItemsUtf8JsonPropertyName.Span) : this.items;
        public Draft201909Schema? Contains => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesContainsUtf8JsonPropertyName.Span) : this.contains;
        public Draft201909Schema? AdditionalProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesAdditionalPropertiesUtf8JsonPropertyName.Span) : this.additionalProperties;
        public Draft201909Schema? UnevaluatedProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesUnevaluatedPropertiesUtf8JsonPropertyName.Span) : this.unevaluatedProperties;
        public Draft201909MetaApplicator.PropertiesEntity? Properties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.PropertiesEntity>(_MenesPropertiesUtf8JsonPropertyName.Span) : this.properties;
        public Draft201909MetaApplicator.PatternPropertiesEntity? PatternProperties => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.PatternPropertiesEntity>(_MenesPatternPropertiesUtf8JsonPropertyName.Span) : this.patternProperties;
        public Draft201909MetaApplicator.DependentSchemasEntity? DependentSchemas => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.DependentSchemasEntity>(_MenesDependentSchemasUtf8JsonPropertyName.Span) : this.dependentSchemas;
        public Draft201909Schema? PropertyNames => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesPropertyNamesUtf8JsonPropertyName.Span) : this.propertyNames;
        public Draft201909Schema? If => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesIfUtf8JsonPropertyName.Span) : this.@if;
        public Draft201909Schema? Then => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesThenUtf8JsonPropertyName.Span) : this.then;
        public Draft201909Schema? Else => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesElseUtf8JsonPropertyName.Span) : this.@else;
        public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? AllOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesAllOfUtf8JsonPropertyName.Span) : this.allOf;
        public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? AnyOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesAnyOfUtf8JsonPropertyName.Span) : this.anyOf;
        public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity? OneOf => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesOneOfUtf8JsonPropertyName.Span) : this.oneOf;
        public Draft201909Schema? Not => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909Schema>(_MenesNotUtf8JsonPropertyName.Span) : this.not;
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
                    return 17 + this._menesAdditionalPropertiesBacking.Length;
                }
            }
        }
        /// <inheritdoc />
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
        {
            Menes.ValidationContext result = validationContext;
            if (level != Menes.ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }
            if (!this.IsObject && !this.IsBoolean)
            {
                if (level >= Menes.ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of object,boolean");
                }
                else
                {
                    result = result.WithResult(isValid: false);
                }
                if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                {
                    return result;
                }
            }
            if (this.IsObject)
            {
                result = result.WithLocalProperty("additionalItems");
                if (this.TryGetProperty<Draft201909Schema>(_MenesAdditionalItemsJsonPropertyName.Span, out Draft201909Schema value0))
                {
                    result = value0.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("unevaluatedItems");
                if (this.TryGetProperty<Draft201909Schema>(_MenesUnevaluatedItemsJsonPropertyName.Span, out Draft201909Schema value1))
                {
                    result = value1.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("items");
                if (this.TryGetProperty<Draft201909MetaApplicator.ItemsEntity>(_MenesItemsJsonPropertyName.Span, out Draft201909MetaApplicator.ItemsEntity value2))
                {
                    result = value2.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("contains");
                if (this.TryGetProperty<Draft201909Schema>(_MenesContainsJsonPropertyName.Span, out Draft201909Schema value3))
                {
                    result = value3.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("additionalProperties");
                if (this.TryGetProperty<Draft201909Schema>(_MenesAdditionalPropertiesJsonPropertyName.Span, out Draft201909Schema value4))
                {
                    result = value4.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("unevaluatedProperties");
                if (this.TryGetProperty<Draft201909Schema>(_MenesUnevaluatedPropertiesJsonPropertyName.Span, out Draft201909Schema value5))
                {
                    result = value5.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("properties");
                if (this.TryGetProperty<Draft201909MetaApplicator.PropertiesEntity>(_MenesPropertiesJsonPropertyName.Span, out Draft201909MetaApplicator.PropertiesEntity value6))
                {
                    result = value6.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("patternProperties");
                if (this.TryGetProperty<Draft201909MetaApplicator.PatternPropertiesEntity>(_MenesPatternPropertiesJsonPropertyName.Span, out Draft201909MetaApplicator.PatternPropertiesEntity value7))
                {
                    result = value7.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("dependentSchemas");
                if (this.TryGetProperty<Draft201909MetaApplicator.DependentSchemasEntity>(_MenesDependentSchemasJsonPropertyName.Span, out Draft201909MetaApplicator.DependentSchemasEntity value8))
                {
                    result = value8.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("propertyNames");
                if (this.TryGetProperty<Draft201909Schema>(_MenesPropertyNamesJsonPropertyName.Span, out Draft201909Schema value9))
                {
                    result = value9.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("if");
                if (this.TryGetProperty<Draft201909Schema>(_MenesIfJsonPropertyName.Span, out Draft201909Schema value10))
                {
                    result = value10.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("then");
                if (this.TryGetProperty<Draft201909Schema>(_MenesThenJsonPropertyName.Span, out Draft201909Schema value11))
                {
                    result = value11.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("else");
                if (this.TryGetProperty<Draft201909Schema>(_MenesElseJsonPropertyName.Span, out Draft201909Schema value12))
                {
                    result = value12.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("allOf");
                if (this.TryGetProperty<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesAllOfJsonPropertyName.Span, out Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity value13))
                {
                    result = value13.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("anyOf");
                if (this.TryGetProperty<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesAnyOfJsonPropertyName.Span, out Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity value14))
                {
                    result = value14.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("oneOf");
                if (this.TryGetProperty<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>(_MenesOneOfJsonPropertyName.Span, out Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity value15))
                {
                    result = value15.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
                    }
                }
                result = result.WithLocalProperty("not");
                if (this.TryGetProperty<Draft201909Schema>(_MenesNotJsonPropertyName.Span, out Draft201909Schema value16))
                {
                    result = value16.Validate(result, level);
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true);
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
            if (this.additionalItems is Draft201909Schema additionalItems)
            {
                writer.WritePropertyName(_MenesAdditionalItemsEncodedJsonPropertyName);
                additionalItems.WriteTo(writer);
            }
            if (this.unevaluatedItems is Draft201909Schema unevaluatedItems)
            {
                writer.WritePropertyName(_MenesUnevaluatedItemsEncodedJsonPropertyName);
                unevaluatedItems.WriteTo(writer);
            }
            if (this.items is Draft201909MetaApplicator.ItemsEntity items)
            {
                writer.WritePropertyName(_MenesItemsEncodedJsonPropertyName);
                items.WriteTo(writer);
            }
            if (this.contains is Draft201909Schema contains)
            {
                writer.WritePropertyName(_MenesContainsEncodedJsonPropertyName);
                contains.WriteTo(writer);
            }
            if (this.additionalProperties is Draft201909Schema additionalProperties)
            {
                writer.WritePropertyName(_MenesAdditionalPropertiesEncodedJsonPropertyName);
                additionalProperties.WriteTo(writer);
            }
            if (this.unevaluatedProperties is Draft201909Schema unevaluatedProperties)
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
            if (this.propertyNames is Draft201909Schema propertyNames)
            {
                writer.WritePropertyName(_MenesPropertyNamesEncodedJsonPropertyName);
                propertyNames.WriteTo(writer);
            }
            if (this.@if is Draft201909Schema @if)
            {
                writer.WritePropertyName(_MenesIfEncodedJsonPropertyName);
                @if.WriteTo(writer);
            }
            if (this.then is Draft201909Schema then)
            {
                writer.WritePropertyName(_MenesThenEncodedJsonPropertyName);
                then.WriteTo(writer);
            }
            if (this.@else is Draft201909Schema @else)
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
            if (this.not is Draft201909Schema not)
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
            if (typeof(T) == typeof(Draft201909MetaApplicator))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }
            return Menes.JsonValue.As<Draft201909MetaApplicator, T>(this);
        }
        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, Menes.IJsonValue
        {
            if (typeof(T) == typeof(Draft201909MetaApplicator))
            {
                return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
        }
        /// <inheritdoc/>
        public bool Equals<T>(in T other)
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
        /// <inheritdoc />
        public bool TryGetPropertyAtIndex(int index, out Menes.IProperty result)
        {
            var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<Draft201909MetaApplicator> prop);
            result = prop;
            return rc;
        }
        public Draft201909MetaApplicator RemoveProperty(string propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public Draft201909MetaApplicator RemoveProperty(System.ReadOnlySpan<char> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public Draft201909MetaApplicator RemoveProperty(System.ReadOnlySpan<byte> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public Draft201909MetaApplicator SetProperty<T>(string name, T value)
        where T : struct, Menes.IJsonValue
        {
            var propertyName = System.MemoryExtensions.AsSpan(name);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalItemsJsonPropertyName.Span))
            {
                return this.WithAdditionalItems(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedItemsJsonPropertyName.Span))
            {
                return this.WithUnevaluatedItems(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesItemsJsonPropertyName.Span))
            {
                return this.WithItems(value.As<Draft201909MetaApplicator.ItemsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContainsJsonPropertyName.Span))
            {
                return this.WithContains(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalPropertiesJsonPropertyName.Span))
            {
                return this.WithAdditionalProperties(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedPropertiesJsonPropertyName.Span))
            {
                return this.WithUnevaluatedProperties(value.As<Draft201909Schema>());
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
                return this.WithPropertyNames(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIfJsonPropertyName.Span))
            {
                return this.WithIf(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesThenJsonPropertyName.Span))
            {
                return this.WithThen(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesElseJsonPropertyName.Span))
            {
                return this.WithElse(value.As<Draft201909Schema>());
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
                return this.WithNot(value.As<Draft201909Schema>());
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
        public Draft201909MetaApplicator SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
        where T : struct, Menes.IJsonValue
        {
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalItemsJsonPropertyName.Span))
            {
                return this.WithAdditionalItems(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedItemsJsonPropertyName.Span))
            {
                return this.WithUnevaluatedItems(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesItemsJsonPropertyName.Span))
            {
                return this.WithItems(value.As<Draft201909MetaApplicator.ItemsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContainsJsonPropertyName.Span))
            {
                return this.WithContains(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalPropertiesJsonPropertyName.Span))
            {
                return this.WithAdditionalProperties(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedPropertiesJsonPropertyName.Span))
            {
                return this.WithUnevaluatedProperties(value.As<Draft201909Schema>());
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
                return this.WithPropertyNames(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIfJsonPropertyName.Span))
            {
                return this.WithIf(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesThenJsonPropertyName.Span))
            {
                return this.WithThen(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesElseJsonPropertyName.Span))
            {
                return this.WithElse(value.As<Draft201909Schema>());
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
                return this.WithNot(value.As<Draft201909Schema>());
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
        public Draft201909MetaApplicator SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
        where T : struct, Menes.IJsonValue
        {
            System.Span<char> name = stackalloc char[utf8Name.Length];
            int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
            var propertyName = name.Slice(0, writtenCount);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalItemsJsonPropertyName.Span))
            {
                return this.WithAdditionalItems(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedItemsJsonPropertyName.Span))
            {
                return this.WithUnevaluatedItems(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesItemsJsonPropertyName.Span))
            {
                return this.WithItems(value.As<Draft201909MetaApplicator.ItemsEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesContainsJsonPropertyName.Span))
            {
                return this.WithContains(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAdditionalPropertiesJsonPropertyName.Span))
            {
                return this.WithAdditionalProperties(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesUnevaluatedPropertiesJsonPropertyName.Span))
            {
                return this.WithUnevaluatedProperties(value.As<Draft201909Schema>());
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
                return this.WithPropertyNames(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIfJsonPropertyName.Span))
            {
                return this.WithIf(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesThenJsonPropertyName.Span))
            {
                return this.WithThen(value.As<Draft201909Schema>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesElseJsonPropertyName.Span))
            {
                return this.WithElse(value.As<Draft201909Schema>());
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
                return this.WithNot(value.As<Draft201909Schema>());
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
        public Draft201909MetaApplicator.MenesPropertyEnumerator GetEnumerator()
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
        System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaApplicator>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaApplicator>>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public Draft201909MetaApplicator WithAdditionalItems(Draft201909Schema value)
        {
            return new Draft201909MetaApplicator(value, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithUnevaluatedItems(Draft201909Schema value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, value, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithItems(Draft201909MetaApplicator.ItemsEntity value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, value, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithContains(Draft201909Schema value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, value, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithAdditionalProperties(Draft201909Schema value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, value, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithUnevaluatedProperties(Draft201909Schema value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, value, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithProperties(Draft201909MetaApplicator.PropertiesEntity value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, value, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithPatternProperties(Draft201909MetaApplicator.PatternPropertiesEntity value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, value, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithDependentSchemas(Draft201909MetaApplicator.DependentSchemasEntity value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, value, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithPropertyNames(Draft201909Schema value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, value, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithIf(Draft201909Schema value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, value, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithThen(Draft201909Schema value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, value, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithElse(Draft201909Schema value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, value, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithAllOf(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, value, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithAnyOf(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, value, this.oneOf, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithOneOf(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, value, this.not, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaApplicator WithNot(Draft201909Schema value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, value, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
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
        private bool TryGetPropertyAtIndex(int index, out Menes.Property<Draft201909MetaApplicator> result)
        {
            if (this.HasJsonElement)
            {
                int jsonPropertyIndex = 0;
                foreach (var property in this.JsonElement.EnumerateObject())
                {
                    if (jsonPropertyIndex == index)
                    {
                        result = new Menes.Property<Draft201909MetaApplicator>(property);
                        return true;
                    }
                    jsonPropertyIndex++;
                }
            }
            int currentIndex = 0;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesAdditionalItemsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesUnevaluatedItemsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesItemsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesContainsJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesAdditionalPropertiesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesUnevaluatedPropertiesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesPropertiesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesPatternPropertiesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesDependentSchemasJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesPropertyNamesJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesIfJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesThenJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesElseJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesAllOfJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesAnyOfJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesOneOfJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaApplicator>(this, _MenesNotJsonPropertyName);
                return true;
            }
            currentIndex++;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (currentIndex == index)
                {
                    result = new Menes.Property<Draft201909MetaApplicator>(this, property.NameAsMemory);
                    return true;
                }
                currentIndex++;
            }
            result = default; ;
            return false;
        }
        private Draft201909MetaApplicator WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
        {
            return new Draft201909MetaApplicator(this.additionalItems, this.unevaluatedItems, this.items, this.contains, this.additionalProperties, this.unevaluatedProperties, this.properties, this.patternProperties, this.dependentSchemas, this.propertyNames, this.@if, this.then, this.@else, this.allOf, this.anyOf, this.oneOf, this.not, this._menesBooleanTypeBacking, value);
        }
        public readonly struct ItemsEntity : Menes.IJsonValue
        {
            public static readonly ItemsEntity Null = default(ItemsEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            public ItemsEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
            }
            public static implicit operator Draft201909Schema(ItemsEntity value)
            {
                return value.As<Draft201909Schema>();
            }
            public static implicit operator ItemsEntity(Draft201909Schema value)
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
            public static implicit operator ItemsEntity(System.Collections.Immutable.ImmutableArray<Draft201909Schema> items)
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Draft201909Schema>();
                foreach (var item in items)
                {
                    arrayBuilder.Add((Draft201909Schema)item);
                }
                return (ItemsEntity)(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity)arrayBuilder.ToImmutable();
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
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                if (level != Menes.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                result = ValidateAnyOf(this, result, level);
                return result;
                Menes.ValidationContext ValidateAnyOf(in Draft201909MetaApplicator.ItemsEntity that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
                {
                    Menes.ValidationContext result = validationContext;
                    var anyOf0 = that.AsDraft201909Schema();
                    Menes.ValidationContext anyOfResult0;
                    if (level == Menes.ValidationLevel.Flag)
                    {
                        anyOfResult0 = anyOf0.Validate(validationContext.CreateChildContext(), level);
                    }
                    else
                    {
                        anyOfResult0 = anyOf0.Validate(validationContext.CreateChildContext("https://json-schema.org/draft/2019-09/meta/applicator#/properties/items/anyOf/0"), level);
                    }
                    if (anyOfResult0.IsValid)
                    {
                        result = result.MergeChildContext(anyOfResult0, false);
                    }
                    var anyOf1 = that.AsSchemaArrayEntity();
                    Menes.ValidationContext anyOfResult1;
                    if (level == Menes.ValidationLevel.Flag)
                    {
                        anyOfResult1 = anyOf1.Validate(validationContext.CreateChildContext(), level);
                    }
                    else
                    {
                        anyOfResult1 = anyOf1.Validate(validationContext.CreateChildContext("https://json-schema.org/draft/2019-09/meta/applicator#/properties/items/anyOf/1"), level);
                    }
                    if (anyOfResult1.IsValid)
                    {
                        result = result.MergeChildContext(anyOfResult1, false);
                    }
                    if (!anyOfResult0.IsValid && !anyOfResult1.IsValid)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "9.2.1.2. anyOf");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                    }
                    else
                    {
                        if (level == Menes.ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true);
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
                if (typeof(T) == typeof(Draft201909MetaApplicator.ItemsEntity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            public readonly Draft201909Schema AsDraft201909Schema()
            {
                return this.As<Draft201909Schema>();
            }
            public readonly Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity AsSchemaArrayEntity()
            {
                return this.As<Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity>();
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, Menes.IJsonValue
            {
                return false;
            }
            private bool AllBackingFieldsAreNull()
            {
                return true;
            }
            public readonly struct SchemaArrayEntity : Menes.IJsonValue, Menes.IJsonArray<SchemaArrayEntity, Draft201909Schema>
            {
                public static readonly SchemaArrayEntity Null = default(SchemaArrayEntity);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking>? _menesArrayValueBacking;
                public SchemaArrayEntity(System.Text.Json.JsonElement jsonElement)
                {
                    this._menesJsonElementBacking = jsonElement;
                    this._menesArrayValueBacking = default;
                }
                public SchemaArrayEntity(System.Collections.Immutable.ImmutableArray<Draft201909Schema> value)
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    foreach (var item in value)
                    {
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item));
                    }
                    this._menesArrayValueBacking = arrayBuilder.ToImmutable();
                    this._menesJsonElementBacking = default;
                }
                private SchemaArrayEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking> value)
                {
                    this._menesArrayValueBacking = value;
                    this._menesJsonElementBacking = default;
                }
                public static implicit operator SchemaArrayEntity(System.Collections.Immutable.ImmutableArray<Draft201909Schema> items)
                {
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(items);
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
                public bool IsObject => false;
                /// <inheritdoc />
                public bool IsBoolean => false;
                /// <inheritdoc />
                public bool IsArray => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Array) || (!this.HasJsonElement && this._menesArrayValueBacking is not null);
                /// <inheritdoc />
                public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
                /// <inheritdoc />
                public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
                /// <inheritdoc />
                public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
                {
                    Menes.ValidationContext result = validationContext;
                    if (level != Menes.ValidationLevel.Flag)
                    {
                        result = result.UsingStack();
                    }
                    if (!this.IsArray)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of array");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    if (!this.IsArray)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.1. type - expected an array type.");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    if (this.IsArray)
                    {
                        int arrayLength = 0;
                        var arrayEnumerator = this.EnumerateArray();
                        while (arrayEnumerator.MoveNext())
                        {
                            result = arrayEnumerator.Current.As<Draft201909Schema>().Validate(result, level);
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
                            }
                            result = result.WithLocalItemIndex(arrayLength);
                            arrayLength++;
                        }
                        if (arrayLength < 1)
                        {
                            if (level >= Menes.ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, message: "6.4.2.  minItems - expected a minimum of 1 items");
                            }
                            else
                            {
                                result = result.WithResult(isValid: false);
                            }
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                            {
                                return result;
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
                    if (typeof(T) == typeof(SchemaArrayEntity))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<SchemaArrayEntity, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity))
                    {
                        return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                    }
                    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                /// <inheritdoc/>
                public bool Equals<T>(in T other)
                    where T : struct, Menes.IJsonValue
                {
                    if (!other.IsArray)
                    {
                        return false;
                    }
                    MenesArrayEnumerator firstEnumerator = this.EnumerateArray();
                    Menes.JsonAny.MenesArrayEnumerator secondEnumerator = other.As<Menes.JsonAny>().EnumerateArray();
                    while (firstEnumerator.MoveNext())
                    {
                        if (!secondEnumerator.MoveNext())
                        {
                            // We've run out of items in the second enumerator.
                            return false;
                        }
                        if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
                        {
                            return false;
                        }
                    }
                    // If we have extra items in the second enumerator, return false.
                    return !secondEnumerator.MoveNext();
                }
                public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity.MenesArrayEnumerator GetEnumerator()
                {
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity.MenesArrayEnumerator(this);
                }
                public Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity.MenesArrayEnumerator EnumerateArray()
                {
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity.MenesArrayEnumerator(this);
                }
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                System.Collections.Generic.IEnumerator<Draft201909Schema> System.Collections.Generic.IEnumerable<Draft201909Schema>.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
                /// <inheritdoc />
                public int GetArrayLength()
                {
                    if (this.HasJsonElement)
                    {
                        return this.JsonElement.GetArrayLength();
                    }
                    return this._menesArrayValueBacking?.Length ?? 0;
                }
                /// <inheritdoc />
                public T GetItemAtIndex<T>(int index)
                    where T : struct, Menes.IJsonValue
                {
                    if (this.HasJsonElement)
                    {
                        int currentIndex = 0;
                        foreach (var item in this.JsonElement.EnumerateArray())
                        {
                            if (currentIndex == index)
                            {
                                return Menes.JsonValue.As<T>(item);
                            }
                        }
                        throw new System.IndexOutOfRangeException();
                    }
                    if (this._menesArrayValueBacking is not null)
                    {
                        return this._menesArrayValueBacking.Value[index].As<T>();
                    }
                    return default;
                }
                public SchemaArrayEntity Add<T1>(T1 item1)
                    where T1 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item1.As<Draft201909Schema>()));
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity Add<T1, T2>(T1 item1, T2 item2)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item1.As<Draft201909Schema>()));
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item2.As<Draft201909Schema>()));
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                    where T3 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item1.As<Draft201909Schema>()));
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item2.As<Draft201909Schema>()));
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item3.As<Draft201909Schema>()));
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                    where T3 : struct, Menes.IJsonValue
                    where T4 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item1.As<Draft201909Schema>()));
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item2.As<Draft201909Schema>()));
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item3.As<Draft201909Schema>()));
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item4.As<Draft201909Schema>()));
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity Add<T>(params T[] items)
                    where T : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        arrayBuilder.Add(oldItem);
                    }
                    foreach (var item1 in items)
                    {
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item1.As<Draft201909Schema>()));
                    }
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity Insert<T>(int index, T item1)
                    where T : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    int currentIndex = 0;
                    bool inserted = false;
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        if (currentIndex == index)
                        {
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item1.As<Draft201909Schema>()));
                            inserted = true;
                        }
                        arrayBuilder.Add(oldItem);
                        currentIndex++;
                    }
                    if (!inserted)
                    {
                        throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                    }
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity Insert<T1, T2>(int index, T1 item1, T2 item2)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    int currentIndex = 0;
                    bool inserted = false;
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        if (currentIndex == index)
                        {
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item1.As<Draft201909Schema>()));
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item2.As<Draft201909Schema>()));
                            inserted = true;
                        }
                        arrayBuilder.Add(oldItem);
                        currentIndex++;
                    }
                    if (!inserted)
                    {
                        throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                    }
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                    where T3 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    int currentIndex = 0;
                    bool inserted = false;
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        if (currentIndex == index)
                        {
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item1.As<Draft201909Schema>()));
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item2.As<Draft201909Schema>()));
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item3.As<Draft201909Schema>()));
                            inserted = true;
                        }
                        arrayBuilder.Add(oldItem);
                        currentIndex++;
                    }
                    if (!inserted)
                    {
                        throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                    }
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
                    where T1 : struct, Menes.IJsonValue
                    where T2 : struct, Menes.IJsonValue
                    where T3 : struct, Menes.IJsonValue
                    where T4 : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    int currentIndex = 0;
                    bool inserted = false;
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        if (currentIndex == index)
                        {
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item1.As<Draft201909Schema>()));
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item2.As<Draft201909Schema>()));
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item3.As<Draft201909Schema>()));
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item4.As<Draft201909Schema>()));
                            inserted = true;
                        }
                        arrayBuilder.Add(oldItem);
                        currentIndex++;
                    }
                    if (!inserted)
                    {
                        throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                    }
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity Insert<T>(int index, params T[] items)
                    where T : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    int currentIndex = 0;
                    bool inserted = false;
                    foreach (var oldItem in this._menesArrayValueBacking)
                    {
                        if (currentIndex == index)
                        {
                            foreach (var item1 in items)
                            {
                                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Draft201909Schema>(item1.As<Draft201909Schema>()));
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
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity RemoveAt(int index)
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    int currentIndex = 0;
                    bool removed = false;
                    foreach (var item in this._menesArrayValueBacking)
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
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
                }
                public SchemaArrayEntity RemoveIf(System.Predicate<Draft201909Schema> condition)
                {
                    return this.RemoveIf<Draft201909Schema>(condition);
                }
                public SchemaArrayEntity RemoveIf<T>(System.Predicate<T> condition)
                    where T : struct, Menes.IJsonValue
                {
                    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                    foreach (var item in this._menesArrayValueBacking)
                    {
                        if (!condition(item.As<T>()))
                        {
                            arrayBuilder.Add(item);
                        }
                    }
                    return new Draft201909MetaApplicator.ItemsEntity.SchemaArrayEntity(arrayBuilder.ToImmutable());
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
                /// An enumerator for the array values in a <see cref="SchemaArrayEntity"/>.
                /// </summary>
                public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Draft201909Schema>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Draft201909Schema>, System.Collections.IEnumerator
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
                    public Draft201909Schema Current
                    {
                        get
                        {
                            if (this.hasJsonEnumerator)
                            {
                                return new Draft201909Schema(this.jsonEnumerator.Current);
                            }
                            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking> array && this.index >= 0 && this.index < array.Length)
                            {
                                return array[this.index].As<Draft201909Schema>();
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
                    System.Collections.Generic.IEnumerator<Draft201909Schema> System.Collections.Generic.IEnumerable<Draft201909Schema>.GetEnumerator()
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
                        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking> array && this.index + 1 < array.Length)
                        {
                            this.index++;
                            return true;
                        }
                        return false;
                    }
                }
            }
        }
        public readonly struct PropertiesEntity : Menes.IJsonObject<PropertiesEntity>
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
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                if (level != Menes.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (!this.IsObject)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of object");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                if (this.IsObject)
                {
                    foreach (var property in this.EnumerateObject())
                    {
                        if (!result.HasEvaluatedLocalProperty(property.Name))
                        {
                            result = result.WithLocalProperty(property.Name);
                            result = property.Value<Draft201909Schema>().Validate(result, level);
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
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
                if (typeof(T) == typeof(PropertiesEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<PropertiesEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaApplicator.PropertiesEntity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
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
                var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<PropertiesEntity> prop);
                result = prop;
                return rc;
            }
            public PropertiesEntity RemoveProperty(string propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public PropertiesEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public PropertiesEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public PropertiesEntity SetProperty<T>(string name, T value)
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
            public PropertiesEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
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
            public PropertiesEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
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
            public Draft201909MetaApplicator.PropertiesEntity.MenesPropertyEnumerator GetEnumerator()
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
            System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaApplicator.PropertiesEntity>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaApplicator.PropertiesEntity>>.GetEnumerator()
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
            private bool TryGetPropertyAtIndex(int index, out Menes.Property<PropertiesEntity> result)
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        if (jsonPropertyIndex == index)
                        {
                            result = new Menes.Property<PropertiesEntity>(property);
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
                        result = new Menes.Property<PropertiesEntity>(this, property.NameAsMemory);
                        return true;
                    }
                    currentIndex++;
                }
                result = default; ;
                return false;
            }
            private PropertiesEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> value)
            {
                return new PropertiesEntity(value);
            }
            /// <summary>
            /// An enumerator for the properties in a <see cref="PropertiesEntity"/>.
            /// </summary>
            public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<PropertiesEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<PropertiesEntity>>, System.Collections.IEnumerator
            {
                private PropertiesEntity instance;
                private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                private int propertyCount;
                internal MenesPropertyEnumerator(PropertiesEntity instance)
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
                public Menes.Property<PropertiesEntity> Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.Property<PropertiesEntity>(this.jsonEnumerator.Current);
                        }
                        else if (this.index >= 0)
                        {
                            if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<PropertiesEntity> result))
                            {
                                return result;
                            }
                            throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                        }
                        return new Menes.Property<PropertiesEntity>(this.instance, default);
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the properties in a <see cref="PropertiesEntity"/>.</returns>
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
                System.Collections.Generic.IEnumerator<Menes.Property<PropertiesEntity>> System.Collections.Generic.IEnumerable<Menes.Property<PropertiesEntity>>.GetEnumerator()
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
        public readonly struct PatternPropertiesEntity : Menes.IJsonObject<PatternPropertiesEntity>
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
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                if (level != Menes.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (!this.IsObject)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of object");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                if (this.IsObject)
                {
                    foreach (var property in this.EnumerateObject())
                    {
                        var propertyName = new Menes.JsonString(property.NameAsMemory).As<Draft201909MetaApplicator.PatternPropertiesEntity.PropertyNamesEntity>();
                        result = propertyName.Validate(result, level);
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                        if (!result.HasEvaluatedLocalProperty(property.Name))
                        {
                            result = result.WithLocalProperty(property.Name);
                            result = property.Value<Draft201909Schema>().Validate(result, level);
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
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
                if (typeof(T) == typeof(PatternPropertiesEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<PatternPropertiesEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaApplicator.PatternPropertiesEntity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
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
                var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<PatternPropertiesEntity> prop);
                result = prop;
                return rc;
            }
            public PatternPropertiesEntity RemoveProperty(string propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public PatternPropertiesEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public PatternPropertiesEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public PatternPropertiesEntity SetProperty<T>(string name, T value)
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
            public PatternPropertiesEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
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
            public PatternPropertiesEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
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
            public Draft201909MetaApplicator.PatternPropertiesEntity.MenesPropertyEnumerator GetEnumerator()
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
            System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaApplicator.PatternPropertiesEntity>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaApplicator.PatternPropertiesEntity>>.GetEnumerator()
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
            private bool TryGetPropertyAtIndex(int index, out Menes.Property<PatternPropertiesEntity> result)
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        if (jsonPropertyIndex == index)
                        {
                            result = new Menes.Property<PatternPropertiesEntity>(property);
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
                        result = new Menes.Property<PatternPropertiesEntity>(this, property.NameAsMemory);
                        return true;
                    }
                    currentIndex++;
                }
                result = default; ;
                return false;
            }
            private PatternPropertiesEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> value)
            {
                return new PatternPropertiesEntity(value);
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
                public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
                {
                    Menes.ValidationContext result = validationContext;
                    if (level != Menes.ValidationLevel.Flag)
                    {
                        result = result.UsingStack();
                    }
                    if (this.IsString)
                    {
                        result = this.As<Menes.JsonRegex>().Validate(result);
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
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
                }
                /// <inheritdoc />
                public T As<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(PropertyNamesEntity))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<PropertyNamesEntity, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(Draft201909MetaApplicator.PatternPropertiesEntity.PropertyNamesEntity))
                    {
                        return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                    }
                    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                /// <inheritdoc/>
                public bool Equals<T>(in T other)
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
            /// An enumerator for the properties in a <see cref="PatternPropertiesEntity"/>.
            /// </summary>
            public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<PatternPropertiesEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<PatternPropertiesEntity>>, System.Collections.IEnumerator
            {
                private PatternPropertiesEntity instance;
                private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                private int propertyCount;
                internal MenesPropertyEnumerator(PatternPropertiesEntity instance)
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
                public Menes.Property<PatternPropertiesEntity> Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.Property<PatternPropertiesEntity>(this.jsonEnumerator.Current);
                        }
                        else if (this.index >= 0)
                        {
                            if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<PatternPropertiesEntity> result))
                            {
                                return result;
                            }
                            throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                        }
                        return new Menes.Property<PatternPropertiesEntity>(this.instance, default);
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the properties in a <see cref="PatternPropertiesEntity"/>.</returns>
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
                System.Collections.Generic.IEnumerator<Menes.Property<PatternPropertiesEntity>> System.Collections.Generic.IEnumerable<Menes.Property<PatternPropertiesEntity>>.GetEnumerator()
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
        public readonly struct DependentSchemasEntity : Menes.IJsonObject<DependentSchemasEntity>
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
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                if (level != Menes.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (!this.IsObject)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of object");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                if (this.IsObject)
                {
                    foreach (var property in this.EnumerateObject())
                    {
                        if (!result.HasEvaluatedLocalProperty(property.Name))
                        {
                            result = result.WithLocalProperty(property.Name);
                            result = property.Value<Draft201909Schema>().Validate(result, level);
                            if (level == Menes.ValidationLevel.Flag && !result.IsValid)
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
                if (typeof(T) == typeof(DependentSchemasEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<DependentSchemasEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaApplicator.DependentSchemasEntity))
                {
                    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
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
                var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<DependentSchemasEntity> prop);
                result = prop;
                return rc;
            }
            public DependentSchemasEntity RemoveProperty(string propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public DependentSchemasEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public DependentSchemasEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public DependentSchemasEntity SetProperty<T>(string name, T value)
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
            public DependentSchemasEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
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
            public DependentSchemasEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
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
            public Draft201909MetaApplicator.DependentSchemasEntity.MenesPropertyEnumerator GetEnumerator()
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
            System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaApplicator.DependentSchemasEntity>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaApplicator.DependentSchemasEntity>>.GetEnumerator()
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
            private bool TryGetPropertyAtIndex(int index, out Menes.Property<DependentSchemasEntity> result)
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        if (jsonPropertyIndex == index)
                        {
                            result = new Menes.Property<DependentSchemasEntity>(property);
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
                        result = new Menes.Property<DependentSchemasEntity>(this, property.NameAsMemory);
                        return true;
                    }
                    currentIndex++;
                }
                result = default; ;
                return false;
            }
            private DependentSchemasEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> value)
            {
                return new DependentSchemasEntity(value);
            }
            /// <summary>
            /// An enumerator for the properties in a <see cref="DependentSchemasEntity"/>.
            /// </summary>
            public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<DependentSchemasEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<DependentSchemasEntity>>, System.Collections.IEnumerator
            {
                private DependentSchemasEntity instance;
                private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                private int propertyCount;
                internal MenesPropertyEnumerator(DependentSchemasEntity instance)
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
                public Menes.Property<DependentSchemasEntity> Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.Property<DependentSchemasEntity>(this.jsonEnumerator.Current);
                        }
                        else if (this.index >= 0)
                        {
                            if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<DependentSchemasEntity> result))
                            {
                                return result;
                            }
                            throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                        }
                        return new Menes.Property<DependentSchemasEntity>(this.instance, default);
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the properties in a <see cref="DependentSchemasEntity"/>.</returns>
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
                System.Collections.Generic.IEnumerator<Menes.Property<DependentSchemasEntity>> System.Collections.Generic.IEnumerable<Menes.Property<DependentSchemasEntity>>.GetEnumerator()
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
        /// An enumerator for the properties in a <see cref="Draft201909MetaApplicator"/>.
        /// </summary>
        public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaApplicator>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaApplicator>>, System.Collections.IEnumerator
        {
            private Draft201909MetaApplicator instance;
            private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
            private bool hasJsonEnumerator;
            private int index;
            private int propertyCount;
            internal MenesPropertyEnumerator(Draft201909MetaApplicator instance)
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
            public Menes.Property<Draft201909MetaApplicator> Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new Menes.Property<Draft201909MetaApplicator>(this.jsonEnumerator.Current);
                    }
                    else if (this.index >= 0)
                    {
                        if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<Draft201909MetaApplicator> result))
                        {
                            return result;
                        }
                        throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                    }
                    return new Menes.Property<Draft201909MetaApplicator>(this.instance, default);
                }
            }
            /// <inheritdoc/>
            object System.Collections.IEnumerator.Current => this.Current;
            /// <summary>
            /// Returns a fresh copy of the enumerator
            /// </summary>
            /// <returns>An enumerator for the properties in a <see cref="Draft201909MetaApplicator"/>.</returns>
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
            System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaApplicator>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaApplicator>>.GetEnumerator()
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
