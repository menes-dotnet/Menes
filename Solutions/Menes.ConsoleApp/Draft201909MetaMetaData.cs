// <copyright file="Draft201909MetaMetaData.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace TestSpace
{
    public readonly struct Draft201909MetaMetaData : Menes.IJsonObject
    {
        public static readonly Draft201909MetaMetaData Null = default(Draft201909MetaMetaData);
        private static readonly System.ReadOnlyMemory<char> _MenesTitleJsonPropertyName = System.MemoryExtensions.AsMemory("title");
        private static readonly System.ReadOnlyMemory<char> _MenesDescriptionJsonPropertyName = System.MemoryExtensions.AsMemory("description");
        private static readonly System.ReadOnlyMemory<char> _MenesDefaultJsonPropertyName = System.MemoryExtensions.AsMemory("@default");
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
        private readonly Draft201909MetaMetaData.DefaultEntity? @default;
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
        public Draft201909MetaMetaData(Menes.JsonString? title = null, Menes.JsonString? description = null, Draft201909MetaMetaData.DefaultEntity? @default = null, Menes.JsonBoolean? deprecated = null, Menes.JsonBoolean? readOnly = null, Menes.JsonBoolean? writeOnly = null, Draft201909MetaMetaData.ExamplesArray? examples = null)
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
        private Draft201909MetaMetaData(Menes.JsonString? title, Menes.JsonString? description, Draft201909MetaMetaData.DefaultEntity? @default, Menes.JsonBoolean? deprecated, Menes.JsonBoolean? readOnly, Menes.JsonBoolean? writeOnly, Draft201909MetaMetaData.ExamplesArray? examples, Menes.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
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
        public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        /// <inheritdoc />
        public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
        public Menes.JsonString? Title => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesTitleUtf8JsonPropertyName.Span) : this.title;
        public Menes.JsonString? Description => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesDescriptionUtf8JsonPropertyName.Span) : this.description;
        public Draft201909MetaMetaData.DefaultEntity? Default => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaMetaData.DefaultEntity>(_MenesDefaultUtf8JsonPropertyName.Span) : this.@default;
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
            if (this.@default is Draft201909MetaMetaData.DefaultEntity @default)
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
            return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
        }
        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, Menes.IJsonValue
        {
            if (typeof(T) == typeof(Draft201909MetaMetaData))
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
        public Draft201909MetaMetaData.MenesPropertyEnumerator GetEnumerator() { return new Draft201909MetaMetaData.MenesPropertyEnumerator(this); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
        public Draft201909MetaMetaData WithTitle(Menes.JsonString value)
        {
            return new Draft201909MetaMetaData(value, this.description, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaMetaData WithDescription(Menes.JsonString value)
        {
            return new Draft201909MetaMetaData(this.title, value, this.@default, this.deprecated, this.readOnly, this.writeOnly, this.examples, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaMetaData WithDefault(Draft201909MetaMetaData.DefaultEntity value)
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
            result = default; ;
            return false;
        }
        public readonly struct DefaultEntity : Menes.IJsonValue
        {
            public static readonly DefaultEntity Null = default(DefaultEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            public DefaultEntity(System.Text.Json.JsonElement jsonElement)
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
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaMetaData.DefaultEntity))
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
        public readonly struct ExamplesArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Draft201909MetaMetaData.ExamplesArray.ItemsEntity>, System.Collections.IEnumerable
        {
            public static readonly ExamplesArray Null = default(ExamplesArray);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Draft201909MetaMetaData.ExamplesArray.ItemsEntity>? _menesArrayValueBacking;
            public ExamplesArray(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public ExamplesArray(System.Collections.Immutable.ImmutableArray<Draft201909MetaMetaData.ExamplesArray.ItemsEntity> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
            }
            public static implicit operator ExamplesArray(System.Collections.Immutable.ImmutableArray<Draft201909MetaMetaData.ExamplesArray.ItemsEntity> items)
            {
                return new Draft201909MetaMetaData.ExamplesArray(items);
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
                if (typeof(T) == typeof(Draft201909MetaMetaData.ExamplesArray))
                {
                    return this.Validate().Valid;
                }
                return this.As<T>().Validate().Valid;
            }
            public Draft201909MetaMetaData.ExamplesArray.MenesArrayEnumerator GetEnumerator() { return new Draft201909MetaMetaData.ExamplesArray.MenesArrayEnumerator(this); }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
            System.Collections.Generic.IEnumerator<Draft201909MetaMetaData.ExamplesArray.ItemsEntity> System.Collections.Generic.IEnumerable<Draft201909MetaMetaData.ExamplesArray.ItemsEntity>.GetEnumerator() { return this.GetEnumerator(); }
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
                    return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(Draft201909MetaMetaData.ExamplesArray.ItemsEntity))
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
            /// An enumerator for the array values in a <see cref="ExamplesArray"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Draft201909MetaMetaData.ExamplesArray.ItemsEntity>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Draft201909MetaMetaData.ExamplesArray.ItemsEntity>, System.Collections.IEnumerator
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
                public Draft201909MetaMetaData.ExamplesArray.ItemsEntity Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Draft201909MetaMetaData.ExamplesArray.ItemsEntity(this.jsonEnumerator.Current);
                        }
                        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Draft201909MetaMetaData.ExamplesArray.ItemsEntity> array && this.index >= 0 && this.index < array.Length)
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
                System.Collections.Generic.IEnumerator<Draft201909MetaMetaData.ExamplesArray.ItemsEntity> System.Collections.Generic.IEnumerable<Draft201909MetaMetaData.ExamplesArray.ItemsEntity>.GetEnumerator()
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
                    else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Draft201909MetaMetaData.ExamplesArray.ItemsEntity> array && this.index < array.Length)
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
                        if (this.instance.TryGetPropertyAtIndex(this.index, out var result))
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
                return false;
            }
        }
    }
}
