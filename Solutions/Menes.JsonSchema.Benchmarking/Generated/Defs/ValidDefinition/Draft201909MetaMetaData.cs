// <copyright file="Draft201909MetaMetaData.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace DefsFeature.ValidDefinition
{
    public readonly struct Draft201909MetaMetaData : Menes.IJsonObject<Draft201909MetaMetaData>
    {
        public static readonly Draft201909MetaMetaData Null = default(Draft201909MetaMetaData);
        private static readonly System.ReadOnlyMemory<char> _MenesTitleJsonPropertyName = System.MemoryExtensions.AsMemory("title");
        private static readonly System.ReadOnlyMemory<char> _MenesDescriptionJsonPropertyName = System.MemoryExtensions.AsMemory("description");
        private static readonly System.ReadOnlyMemory<char> _MenesDefaultJsonPropertyName = System.MemoryExtensions.AsMemory("default");
        private static readonly System.ReadOnlyMemory<char> _MenesDeprecatedJsonPropertyName = System.MemoryExtensions.AsMemory("deprecated");
        private static readonly System.ReadOnlyMemory<char> _MenesReadOnlyJsonPropertyName = System.MemoryExtensions.AsMemory("readOnly");
        private static readonly System.ReadOnlyMemory<char> _MenesWriteOnlyJsonPropertyName = System.MemoryExtensions.AsMemory("writeOnly");
        private static readonly System.ReadOnlyMemory<char> _MenesExamplesJsonPropertyName = System.MemoryExtensions.AsMemory("examples");
        private static readonly System.ReadOnlyMemory<byte> _MenesTitleUtf8JsonPropertyName = new byte[] { 116, 105, 116, 108, 101 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDescriptionUtf8JsonPropertyName = new byte[] { 100, 101, 115, 99, 114, 105, 112, 116, 105, 111, 110 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDefaultUtf8JsonPropertyName = new byte[] { 100, 101, 102, 97, 117, 108, 116 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDeprecatedUtf8JsonPropertyName = new byte[] { 100, 101, 112, 114, 101, 99, 97, 116, 101, 100 };
        private static readonly System.ReadOnlyMemory<byte> _MenesReadOnlyUtf8JsonPropertyName = new byte[] { 114, 101, 97, 100, 79, 110, 108, 121 };
        private static readonly System.ReadOnlyMemory<byte> _MenesWriteOnlyUtf8JsonPropertyName = new byte[] { 119, 114, 105, 116, 101, 79, 110, 108, 121 };
        private static readonly System.ReadOnlyMemory<byte> _MenesExamplesUtf8JsonPropertyName = new byte[] { 101, 120, 97, 109, 112, 108, 101, 115 };
        private static readonly System.Text.Json.JsonEncodedText _MenesTitleEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesTitleUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDescriptionEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDescriptionUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDefaultEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDefaultUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDeprecatedEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDeprecatedUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesReadOnlyEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesReadOnlyUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesWriteOnlyEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesWriteOnlyUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesExamplesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesExamplesUtf8JsonPropertyName.Span);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
        private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
        private readonly Menes.JsonString? title;
        private readonly Menes.JsonString? description;
        private readonly Menes.JsonAny? @default;
        private readonly Menes.JsonBoolean? deprecated;
        private readonly Menes.JsonBoolean? readOnly;
        private readonly Menes.JsonBoolean? writeOnly;
        private readonly Draft201909MetaMetaData.ExamplesArray? examples;
        public Draft201909MetaMetaData(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
            this.title = default;
            this.description = default;
            this.@default = default;
            this.deprecated = default;
            this.readOnly = default;
            this.writeOnly = default;
            this.examples = default;
        }
        public Draft201909MetaMetaData(Menes.JsonString? title = null, Menes.JsonString? description = null, Menes.JsonAny? @default = null, Menes.JsonBoolean? deprecated = null, Menes.JsonBoolean? readOnly = null, Menes.JsonBoolean? writeOnly = null, Draft201909MetaMetaData.ExamplesArray? examples = null)
        {
            this._menesJsonElementBacking = default;
            this.title = title;
            this.description = description;
            this.@default = @default;
            this.deprecated = deprecated;
            this.readOnly = readOnly;
            this.writeOnly = writeOnly;
            this.examples = examples;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
        }
        public Draft201909MetaMetaData(Menes.JsonBoolean value)
        {
            this._menesJsonElementBacking = default;
            this._menesBooleanTypeBacking = value;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this.title = default;
            this.description = default;
            this.@default = default;
            this.deprecated = default;
            this.readOnly = default;
            this.writeOnly = default;
            this.examples = default;
        }
        private Draft201909MetaMetaData(Menes.JsonString? title, Menes.JsonString? description, Menes.JsonAny? @default, Menes.JsonBoolean? deprecated, Menes.JsonBoolean? readOnly, Menes.JsonBoolean? writeOnly, Draft201909MetaMetaData.ExamplesArray? examples, Menes.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
        {
            this._menesJsonElementBacking = default;
            this.title = title;
            this.description = description;
            this.@default = @default;
            this.deprecated = deprecated;
            this.readOnly = readOnly;
            this.writeOnly = writeOnly;
            this.examples = examples;
            this._menesBooleanTypeBacking = _menesBooleanTypeBacking;
            this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
        }
        public static implicit operator Menes.JsonBoolean(Draft201909MetaMetaData value)
        {
            return value.As<Menes.JsonBoolean>();
        }
        public static implicit operator Draft201909MetaMetaData(Menes.JsonBoolean value)
        {
            return value.As<Draft201909MetaMetaData>();
        }
        public static implicit operator bool(Draft201909MetaMetaData value)
        {
            return (bool)(Menes.JsonBoolean)value;
        }
        public static implicit operator Draft201909MetaMetaData(bool value)
        {
            return (Draft201909MetaMetaData)(Menes.JsonBoolean)value;
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
        public Menes.JsonString? Title => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesTitleUtf8JsonPropertyName.Span) : this.title;
        public Menes.JsonString? Description => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesDescriptionUtf8JsonPropertyName.Span) : this.description;
        public Menes.JsonAny? Default => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonAny>(_MenesDefaultUtf8JsonPropertyName.Span) : this.@default;
        public Menes.JsonBoolean? Deprecated => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonBoolean>(_MenesDeprecatedUtf8JsonPropertyName.Span) : this.deprecated;
        public Menes.JsonBoolean? ReadOnly => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonBoolean>(_MenesReadOnlyUtf8JsonPropertyName.Span) : this.readOnly;
        public Menes.JsonBoolean? WriteOnly => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonBoolean>(_MenesWriteOnlyUtf8JsonPropertyName.Span) : this.writeOnly;
        public Draft201909MetaMetaData.ExamplesArray? Examples => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaMetaData.ExamplesArray>(_MenesExamplesUtf8JsonPropertyName.Span) : this.examples;
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
                    return 7 + this._menesAdditionalPropertiesBacking.Length;
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
                result = result.WithLocalProperty("title");
                if (this.TryGetProperty<Menes.JsonString>(_MenesTitleJsonPropertyName.Span, out Menes.JsonString value0))
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
                result = result.WithLocalProperty("description");
                if (this.TryGetProperty<Menes.JsonString>(_MenesDescriptionJsonPropertyName.Span, out Menes.JsonString value1))
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
                result = result.WithLocalProperty("default");
                if (this.TryGetProperty<Menes.JsonAny>(_MenesDefaultJsonPropertyName.Span, out Menes.JsonAny value2))
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
                result = result.WithLocalProperty("deprecated");
                if (this.TryGetProperty<Menes.JsonBoolean>(_MenesDeprecatedJsonPropertyName.Span, out Menes.JsonBoolean value3))
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
                result = result.WithLocalProperty("readOnly");
                if (this.TryGetProperty<Menes.JsonBoolean>(_MenesReadOnlyJsonPropertyName.Span, out Menes.JsonBoolean value4))
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
                result = result.WithLocalProperty("writeOnly");
                if (this.TryGetProperty<Menes.JsonBoolean>(_MenesWriteOnlyJsonPropertyName.Span, out Menes.JsonBoolean value5))
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
                result = result.WithLocalProperty("examples");
                if (this.TryGetProperty<Draft201909MetaMetaData.ExamplesArray>(_MenesExamplesJsonPropertyName.Span, out Draft201909MetaMetaData.ExamplesArray value6))
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
            if (this.title is Menes.JsonString title)
            {
                writer.WritePropertyName(_MenesTitleEncodedJsonPropertyName);
                title.WriteTo(writer);
            }
            if (this.description is Menes.JsonString description)
            {
                writer.WritePropertyName(_MenesDescriptionEncodedJsonPropertyName);
                description.WriteTo(writer);
            }
            if (this.@default is Menes.JsonAny @default)
            {
                writer.WritePropertyName(_MenesDefaultEncodedJsonPropertyName);
                @default.WriteTo(writer);
            }
            if (this.deprecated is Menes.JsonBoolean deprecated)
            {
                writer.WritePropertyName(_MenesDeprecatedEncodedJsonPropertyName);
                deprecated.WriteTo(writer);
            }
            if (this.readOnly is Menes.JsonBoolean readOnly)
            {
                writer.WritePropertyName(_MenesReadOnlyEncodedJsonPropertyName);
                readOnly.WriteTo(writer);
            }
            if (this.writeOnly is Menes.JsonBoolean writeOnly)
            {
                writer.WritePropertyName(_MenesWriteOnlyEncodedJsonPropertyName);
                writeOnly.WriteTo(writer);
            }
            if (this.examples is Draft201909MetaMetaData.ExamplesArray examples)
            {
                writer.WritePropertyName(_MenesExamplesEncodedJsonPropertyName);
                examples.WriteTo(writer);
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
            if (typeof(T) == typeof(Draft201909MetaMetaData))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }
            return Menes.JsonValue.As<Draft201909MetaMetaData, T>(this);
        }
        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, Menes.IJsonValue
        {
            if (typeof(T) == typeof(Draft201909MetaMetaData))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesJsonPropertyName.Span))
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
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesTitleJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDescriptionJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDefaultJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDeprecatedJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesReadOnlyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesWriteOnlyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesExamplesJsonPropertyName.Span))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesUtf8JsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesTitleJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDescriptionJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDefaultJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDeprecatedJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesReadOnlyJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesWriteOnlyJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesExamplesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleUtf8JsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionUtf8JsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultUtf8JsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedUtf8JsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyUtf8JsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyUtf8JsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesUtf8JsonPropertyName.Span))
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
            var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<Draft201909MetaMetaData> prop);
            result = prop;
            return rc;
        }
        public Draft201909MetaMetaData RemoveProperty(string propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public Draft201909MetaMetaData RemoveProperty(System.ReadOnlySpan<char> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public Draft201909MetaMetaData RemoveProperty(System.ReadOnlySpan<byte> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public Draft201909MetaMetaData SetProperty<T>(string name, T value)
        where T : struct, Menes.IJsonValue
        {
            var propertyName = System.MemoryExtensions.AsSpan(name);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleJsonPropertyName.Span))
            {
                return this.WithTitle(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionJsonPropertyName.Span))
            {
                return this.WithDescription(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultJsonPropertyName.Span))
            {
                return this.WithDefault(value.As<Menes.JsonAny>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedJsonPropertyName.Span))
            {
                return this.WithDeprecated(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyJsonPropertyName.Span))
            {
                return this.WithReadOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyJsonPropertyName.Span))
            {
                return this.WithWriteOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesJsonPropertyName.Span))
            {
                return this.WithExamples(value.As<Draft201909MetaMetaData.ExamplesArray>());
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
        public Draft201909MetaMetaData SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
        where T : struct, Menes.IJsonValue
        {
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleJsonPropertyName.Span))
            {
                return this.WithTitle(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionJsonPropertyName.Span))
            {
                return this.WithDescription(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultJsonPropertyName.Span))
            {
                return this.WithDefault(value.As<Menes.JsonAny>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedJsonPropertyName.Span))
            {
                return this.WithDeprecated(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyJsonPropertyName.Span))
            {
                return this.WithReadOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyJsonPropertyName.Span))
            {
                return this.WithWriteOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesJsonPropertyName.Span))
            {
                return this.WithExamples(value.As<Draft201909MetaMetaData.ExamplesArray>());
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
        public Draft201909MetaMetaData SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
        where T : struct, Menes.IJsonValue
        {
            System.Span<char> name = stackalloc char[utf8Name.Length];
            int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
            var propertyName = name.Slice(0, writtenCount);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesTitleJsonPropertyName.Span))
            {
                return this.WithTitle(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDescriptionJsonPropertyName.Span))
            {
                return this.WithDescription(value.As<Menes.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefaultJsonPropertyName.Span))
            {
                return this.WithDefault(value.As<Menes.JsonAny>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDeprecatedJsonPropertyName.Span))
            {
                return this.WithDeprecated(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesReadOnlyJsonPropertyName.Span))
            {
                return this.WithReadOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesWriteOnlyJsonPropertyName.Span))
            {
                return this.WithWriteOnly(value.As<Menes.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesExamplesJsonPropertyName.Span))
            {
                return this.WithExamples(value.As<Draft201909MetaMetaData.ExamplesArray>());
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
        public Draft201909MetaMetaData.MenesPropertyEnumerator GetEnumerator()
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
        System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaMetaData>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaMetaData>>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public Draft201909MetaMetaData WithTitle(Menes.JsonString value)
        {
            return new Draft201909MetaMetaData(value, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaMetaData WithDescription(Menes.JsonString value)
        {
            return new Draft201909MetaMetaData(this.title, value, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaMetaData WithDefault(Menes.JsonAny value)
        {
            return new Draft201909MetaMetaData(this.title, this.description, value, this.deprecated, this.readOnly, this.writeOnly, this.examples, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaMetaData WithDeprecated(Menes.JsonBoolean value)
        {
            return new Draft201909MetaMetaData(this.title, this.description, this.@default, value, this.readOnly, this.writeOnly, this.examples, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaMetaData WithReadOnly(Menes.JsonBoolean value)
        {
            return new Draft201909MetaMetaData(this.title, this.description, this.@default, this.deprecated, value, this.writeOnly, this.examples, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaMetaData WithWriteOnly(Menes.JsonBoolean value)
        {
            return new Draft201909MetaMetaData(this.title, this.description, this.@default, this.deprecated, this.readOnly, value, this.examples, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaMetaData WithExamples(Draft201909MetaMetaData.ExamplesArray value)
        {
            return new Draft201909MetaMetaData(this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, value, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
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
        private bool TryGetPropertyAtIndex(int index, out Menes.Property<Draft201909MetaMetaData> result)
        {
            if (this.HasJsonElement)
            {
                int jsonPropertyIndex = 0;
                foreach (var property in this.JsonElement.EnumerateObject())
                {
                    if (jsonPropertyIndex == index)
                    {
                        result = new Menes.Property<Draft201909MetaMetaData>(property);
                        return true;
                    }
                    jsonPropertyIndex++;
                }
            }
            int currentIndex = 0;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaMetaData>(this, _MenesTitleJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaMetaData>(this, _MenesDescriptionJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaMetaData>(this, _MenesDefaultJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaMetaData>(this, _MenesDeprecatedJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaMetaData>(this, _MenesReadOnlyJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaMetaData>(this, _MenesWriteOnlyJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Draft201909MetaMetaData>(this, _MenesExamplesJsonPropertyName);
                return true;
            }
            currentIndex++;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (currentIndex == index)
                {
                    result = new Menes.Property<Draft201909MetaMetaData>(this, property.NameAsMemory);
                    return true;
                }
                currentIndex++;
            }
            result = default; ;
            return false;
        }
        private Draft201909MetaMetaData WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
        {
            return new Draft201909MetaMetaData(this.title, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this._menesBooleanTypeBacking, value);
        }
        public readonly struct ExamplesArray : Menes.IJsonValue, Menes.IJsonArray<ExamplesArray, Menes.JsonAny>
        {
            public static readonly ExamplesArray Null = default(ExamplesArray);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
            public ExamplesArray(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public ExamplesArray(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
            }
            public static implicit operator ExamplesArray(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> items)
            {
                return new Draft201909MetaMetaData.ExamplesArray(items);
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
                        result = arrayEnumerator.Current.As<Menes.JsonAny>().Validate(result, level);
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                        result = result.WithLocalItemIndex(arrayLength);
                        arrayLength++;
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
                if (typeof(T) == typeof(ExamplesArray))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<ExamplesArray, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaMetaData.ExamplesArray))
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
            public Draft201909MetaMetaData.ExamplesArray.MenesArrayEnumerator GetEnumerator()
            {
                return new Draft201909MetaMetaData.ExamplesArray.MenesArrayEnumerator(this);
            }
            public Draft201909MetaMetaData.ExamplesArray.MenesArrayEnumerator EnumerateArray()
            {
                return new Draft201909MetaMetaData.ExamplesArray.MenesArrayEnumerator(this);
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
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
            public ExamplesArray Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray Add<T1, T2>(T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                arrayBuilder.Add(item3.As<Menes.JsonAny>());
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
                where T4 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                arrayBuilder.Add(item2.As<Menes.JsonAny>());
                arrayBuilder.Add(item3.As<Menes.JsonAny>());
                arrayBuilder.Add(item4.As<Menes.JsonAny>());
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray Add<T>(params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                foreach (var item1 in items)
                {
                    arrayBuilder.Add(item1.As<Menes.JsonAny>());
                }
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray Insert<T>(int index, T item1)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray Insert<T1, T2>(int index, T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        arrayBuilder.Add(item3.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
                where T4 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(item1.As<Menes.JsonAny>());
                        arrayBuilder.Add(item2.As<Menes.JsonAny>());
                        arrayBuilder.Add(item3.As<Menes.JsonAny>());
                        arrayBuilder.Add(item4.As<Menes.JsonAny>());
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray Insert<T>(int index, params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        foreach (var item1 in items)
                        {
                            arrayBuilder.Add(item1.As<Menes.JsonAny>());
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
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray RemoveAt(int index)
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
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
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
            }
            public ExamplesArray RemoveIf(System.Predicate<Menes.JsonAny> condition)
            {
                return this.RemoveIf<Menes.JsonAny>(condition);
            }
            public ExamplesArray RemoveIf<T>(System.Predicate<T> condition)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var item in this._menesArrayValueBacking)
                {
                    if (!condition(item.As<T>()))
                    {
                        arrayBuilder.Add(item);
                    }
                }
                return new Draft201909MetaMetaData.ExamplesArray(arrayBuilder.ToImmutable());
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
            /// An enumerator for the array values in a <see cref="ExamplesArray"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
            {
                private ExamplesArray instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(ExamplesArray instance)
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
                public Menes.JsonAny Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.JsonAny(this.jsonEnumerator.Current);
                        }
                        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index >= 0 && this.index < array.Length)
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
                /// <returns>An enumerator for the array values in a <see cref="ExamplesArray"/>.</returns>
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
                System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
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
                    else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index + 1 < array.Length)
                    {
                        this.index++;
                        return true;
                    }
                    return false;
                }
            }
        }
        /// <summary>
        /// An enumerator for the properties in a <see cref="Draft201909MetaMetaData"/>.
        /// </summary>
        public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaMetaData>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaMetaData>>, System.Collections.IEnumerator
        {
            private Draft201909MetaMetaData instance;
            private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
            private bool hasJsonEnumerator;
            private int index;
            private int propertyCount;
            internal MenesPropertyEnumerator(Draft201909MetaMetaData instance)
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
            public Menes.Property<Draft201909MetaMetaData> Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new Menes.Property<Draft201909MetaMetaData>(this.jsonEnumerator.Current);
                    }
                    else if (this.index >= 0)
                    {
                        if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<Draft201909MetaMetaData> result))
                        {
                            return result;
                        }
                        throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                    }
                    return new Menes.Property<Draft201909MetaMetaData>(this.instance, default);
                }
            }
            /// <inheritdoc/>
            object System.Collections.IEnumerator.Current => this.Current;
            /// <summary>
            /// Returns a fresh copy of the enumerator
            /// </summary>
            /// <returns>An enumerator for the properties in a <see cref="Draft201909MetaMetaData"/>.</returns>
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
            System.Collections.Generic.IEnumerator<Menes.Property<Draft201909MetaMetaData>> System.Collections.Generic.IEnumerable<Menes.Property<Draft201909MetaMetaData>>.GetEnumerator()
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
