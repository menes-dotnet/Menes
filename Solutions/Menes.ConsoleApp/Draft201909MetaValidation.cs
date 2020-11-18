// <copyright file="Draft201909MetaValidation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
using System;

namespace TestSpace
{
    public readonly struct Draft201909MetaValidation : Menes.IJsonValue
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
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
        private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
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
        /// <inheritdoc />
        public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
        /// <inheritdoc />
        public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
        /// <inheritdoc />
        public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        /// <inheritdoc />
        public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
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
        public readonly struct MultipleOfValue : Menes.IJsonValue
        {
            public static readonly MultipleOfValue Null = default(MultipleOfValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonNumber? _menesNumberTypeBacking;
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
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
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
                if (this._menesNumberTypeBacking is not null)
                {
                    return false;
                }
                return true;
            }
        }
        public readonly struct MaximumValue : Menes.IJsonValue
        {
            public static readonly MaximumValue Null = default(MaximumValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonNumber? _menesNumberTypeBacking;
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
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaValidation.MaximumValue))
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
                if (this._menesNumberTypeBacking is not null)
                {
                    return false;
                }
                return true;
            }
        }
        public readonly struct ExclusiveMaximumValue : Menes.IJsonValue
        {
            public static readonly ExclusiveMaximumValue Null = default(ExclusiveMaximumValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonNumber? _menesNumberTypeBacking;
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
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaValidation.ExclusiveMaximumValue))
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
                if (this._menesNumberTypeBacking is not null)
                {
                    return false;
                }
                return true;
            }
        }
        public readonly struct MinimumValue : Menes.IJsonValue
        {
            public static readonly MinimumValue Null = default(MinimumValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonNumber? _menesNumberTypeBacking;
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
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaValidation.MinimumValue))
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
                if (this._menesNumberTypeBacking is not null)
                {
                    return false;
                }
                return true;
            }
        }
        public readonly struct ExclusiveMinimumValue : Menes.IJsonValue
        {
            public static readonly ExclusiveMinimumValue Null = default(ExclusiveMinimumValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonNumber? _menesNumberTypeBacking;
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
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaValidation.ExclusiveMinimumValue))
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
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
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
                if (this._menesIntegerTypeBacking is not null)
                {
                    return false;
                }
                return true;
            }
        }
        public readonly struct PatternValue : Menes.IJsonValue
        {
            public static readonly PatternValue Null = default(PatternValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonString? _menesStringTypeBacking;
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
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaValidation.PatternValue))
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
                if (this._menesStringTypeBacking is not null)
                {
                    return false;
                }
                return true;
            }
        }
        public readonly struct UniqueItemsValue : Menes.IJsonValue
        {
            public static readonly UniqueItemsValue Null = default(UniqueItemsValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
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
                if (typeof(T) == typeof(Draft201909MetaValidation.UniqueItemsValue))
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
                if (this._menesBooleanTypeBacking is not null)
                {
                    return false;
                }
                return true;
            }
        }
        public readonly struct StringArrayEntity : Menes.IJsonValue
        {
            public static readonly StringArrayEntity Null = default(StringArrayEntity);
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
                if (typeof(T) == typeof(Draft201909MetaValidation.StringArrayEntity))
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
        public readonly struct DependentRequiredEntity : Menes.IJsonValue
        {
            public static readonly DependentRequiredEntity Null = default(DependentRequiredEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Draft201909MetaValidation.StringArrayEntity>> _menesAdditionalPropertiesBacking;
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
        public readonly struct ConstEntity : Menes.IJsonValue
        {
            public static readonly ConstEntity Null = default(ConstEntity);
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
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
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
        public readonly struct EnumArray : Menes.IJsonValue
        {
            public static readonly EnumArray Null = default(EnumArray);
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
                if (typeof(T) == typeof(Draft201909MetaValidation.EnumArray))
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
            public readonly struct ItemsEntity : Menes.IJsonValue
            {
                public static readonly ItemsEntity Null = default(ItemsEntity);
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
                    return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
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
        public readonly struct TypeEntity : Menes.IJsonValue
        {
            public static readonly TypeEntity Null = default(TypeEntity);
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
                TypeEntity flattened = Menes.JsonValue.FlattenToJsonElementBacking(this);
                result = ValidateAnyOf(flattened, result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);
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
                if (typeof(T) == typeof(Draft201909MetaValidation.TypeEntity))
                {
                    return this.Validate().Valid;
                }
                return this.As<T>().Validate().Valid;
            }
            private readonly Draft201909MetaValidation.TypeEntity.SimpleTypesEntity AsSimpleTypesEntity()
            {
                return this.As<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>();
            }
            private readonly Draft201909MetaValidation.TypeEntity.AnyOf1Array AsAnyOf1Array()
            {
                return this.As<Draft201909MetaValidation.TypeEntity.AnyOf1Array>();
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
            public readonly struct SimpleTypesEntity : Menes.IJsonValue
            {
                public static readonly SimpleTypesEntity Null = default(SimpleTypesEntity);
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
                    if (typeof(T) == typeof(Draft201909MetaValidation.TypeEntity.SimpleTypesEntity))
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
            public readonly struct AnyOf1Array : Menes.IJsonValue
            {
                public static readonly AnyOf1Array Null = default(AnyOf1Array);
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
                    if (typeof(T) == typeof(Draft201909MetaValidation.TypeEntity.AnyOf1Array))
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
