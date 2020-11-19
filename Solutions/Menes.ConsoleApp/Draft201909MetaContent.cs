// <copyright file="Draft201909MetaContent.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace TestSpace
{
    public readonly struct Draft201909MetaContent : Menes.IJsonValue
    {
        public static readonly Draft201909MetaContent Null = default(Draft201909MetaContent);
        private static readonly System.ReadOnlyMemory<char> _MenesContentMediaTypeJsonPropertyName = System.MemoryExtensions.AsMemory("contentMediaType");
        private static readonly System.ReadOnlyMemory<char> _MenesContentEncodingJsonPropertyName = System.MemoryExtensions.AsMemory("contentEncoding");
        private static readonly System.ReadOnlyMemory<char> _MenesContentSchemaJsonPropertyName = System.MemoryExtensions.AsMemory("contentSchema");
        private static readonly System.ReadOnlyMemory<byte> _MenesContentMediaTypeUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 77, 101, 100, 105, 97, 84, 121, 112, 101 };
        private static readonly System.ReadOnlyMemory<byte> _MenesContentEncodingUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 69, 110, 99, 111, 100, 105, 110, 103 };
        private static readonly System.ReadOnlyMemory<byte> _MenesContentSchemaUtf8JsonPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 83, 99, 104, 101, 109, 97 };
        private static readonly System.Text.Json.JsonEncodedText _MenesContentMediaTypeEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContentMediaTypeUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesContentEncodingEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContentEncodingUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesContentSchemaEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesContentSchemaUtf8JsonPropertyName.Span);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
        private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
        private readonly Menes.JsonString? contentMediaType;
        private readonly Menes.JsonString? contentEncoding;
        private readonly Menes.JsonValueBacking contentSchema;
        public Draft201909MetaContent(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
            this.contentMediaType = default;
            this.contentEncoding = default;
            this.contentSchema = default;
        }
        public Draft201909MetaContent(Menes.JsonString? contentMediaType = null, Menes.JsonString? contentEncoding = null, Draft201909MetaContent? contentSchema = null)
        {
            this._menesJsonElementBacking = default;
            this.contentMediaType = contentMediaType;
            this.contentEncoding = contentEncoding;
            this.contentSchema = Menes.JsonValueBacking.From(contentSchema);
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
        }
        public Draft201909MetaContent(Menes.JsonBoolean value)
        {
            this._menesJsonElementBacking = default;
            this._menesBooleanTypeBacking = value;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this.contentMediaType = default;
            this.contentEncoding = default;
            this.contentSchema = default;
        }
        private Draft201909MetaContent(Menes.JsonString? contentMediaType, Menes.JsonString? contentEncoding, Menes.JsonValueBacking contentSchema, Menes.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
        {
            this._menesJsonElementBacking = default;
            this.contentMediaType = contentMediaType;
            this.contentEncoding = contentEncoding;
            this.contentSchema = contentSchema;
            this._menesBooleanTypeBacking = _menesBooleanTypeBacking;
            this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
        }
        public static implicit operator Menes.JsonBoolean(Draft201909MetaContent value)
        {
            return value.As<Menes.JsonBoolean>();
        }
        public static implicit operator Draft201909MetaContent(Menes.JsonBoolean value)
        {
            return value.As<Draft201909MetaContent>();
        }
        public static implicit operator bool(Draft201909MetaContent value)
        {
            return (bool)(Menes.JsonBoolean)value;
        }
        public static implicit operator Draft201909MetaContent(bool value)
        {
            return (Draft201909MetaContent)(Menes.JsonBoolean)value;
        }
        /// <inheritdoc />
        public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
        /// <inheritdoc />
        public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
        /// <inheritdoc />
        public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        /// <inheritdoc />
        public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
        public Menes.JsonString? ContentMediaType => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesContentMediaTypeUtf8JsonPropertyName.Span) : this.contentMediaType;
        public Menes.JsonString? ContentEncoding => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesContentEncodingUtf8JsonPropertyName.Span) : this.contentEncoding;
        public Draft201909MetaContent? ContentSchema => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaContent>(_MenesContentSchemaUtf8JsonPropertyName.Span) : this.contentSchema.Value<Draft201909MetaContent>();
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
            if (this.contentSchema is Menes.JsonValueBacking contentSchema)
            {
                writer.WritePropertyName(_MenesContentSchemaEncodedJsonPropertyName);
                contentSchema.WriteTo(writer);
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
            if (typeof(T) == typeof(Draft201909MetaContent))
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
            if (this.contentMediaType is not null)
            {
                return false;
            }
            if (this.contentEncoding is not null)
            {
                return false;
            }
            if (!this.contentSchema.IsNull)
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
    }
}
