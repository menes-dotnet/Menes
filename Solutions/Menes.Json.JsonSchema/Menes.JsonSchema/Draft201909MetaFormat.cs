// <copyright file="Draft201909MetaFormat.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.JsonSchema
{
    public readonly struct Draft201909MetaFormat : Menes.JsonSchema.IJsonObject<Draft201909MetaFormat>
    {
        public static readonly Draft201909MetaFormat Null = default(Draft201909MetaFormat);
        private static readonly System.ReadOnlyMemory<char> _MenesFormatJsonPropertyName = System.MemoryExtensions.AsMemory("format");
        private static readonly System.ReadOnlyMemory<byte> _MenesFormatUtf8JsonPropertyName = new byte[] { 102, 111, 114, 109, 97, 116 };
        private static readonly System.Text.Json.JsonEncodedText _MenesFormatEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFormatUtf8JsonPropertyName.Span);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>> _menesAdditionalPropertiesBacking;
        private readonly Menes.JsonSchema.JsonBoolean? _menesBooleanTypeBacking;
        private readonly Menes.JsonSchema.JsonString? format;
        public Draft201909MetaFormat(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
            this.format = default;
        }
        public Draft201909MetaFormat(Menes.JsonSchema.JsonString? format = null)
        {
            this._menesJsonElementBacking = default;
            this.format = format;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
        }
        public Draft201909MetaFormat(Menes.JsonSchema.JsonBoolean value)
        {
            this._menesJsonElementBacking = default;
            this._menesBooleanTypeBacking = value;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>>.Empty;
            this.format = default;
        }
        private Draft201909MetaFormat(Menes.JsonSchema.JsonString? format, Menes.JsonSchema.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>> _menesAdditionalPropertiesBacking)
        {
            this._menesJsonElementBacking = default;
            this.format = format;
            this._menesBooleanTypeBacking = _menesBooleanTypeBacking;
            this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
        }
        public static implicit operator Menes.JsonSchema.JsonBoolean(Draft201909MetaFormat value)
        {
            return value.As<Menes.JsonSchema.JsonBoolean>();
        }
        public static implicit operator Draft201909MetaFormat(Menes.JsonSchema.JsonBoolean value)
        {
            return value.As<Draft201909MetaFormat>();
        }
        public static implicit operator bool(Draft201909MetaFormat value)
        {
            return (bool)(Menes.JsonSchema.JsonBoolean)value;
        }
        public static implicit operator Draft201909MetaFormat(bool value)
        {
            return (Draft201909MetaFormat)(Menes.JsonSchema.JsonBoolean)value;
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
        public Menes.JsonSchema.JsonString? Format => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonSchema.JsonString>(_MenesFormatUtf8JsonPropertyName.Span) : this.format;
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
                    return 1 + this._menesAdditionalPropertiesBacking.Length;
                }
            }
        }
        /// <inheritdoc />
        public Menes.JsonSchema.ValidationContext Validate(in Menes.JsonSchema.ValidationContext validationContext, Menes.JsonSchema.ValidationLevel level = Menes.JsonSchema.ValidationLevel.Flag)
        {
            Menes.JsonSchema.ValidationContext result = validationContext;
            if (level != Menes.JsonSchema.ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }
            if (!this.IsObject && !this.IsBoolean)
            {
                if (level >= Menes.JsonSchema.ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of object,boolean");
                }
                else
                {
                    result = result.WithResult(isValid: false);
                }
                if (level == Menes.JsonSchema.ValidationLevel.Flag && !result.IsValid)
                {
                    return result;
                }
            }
            if (this.IsObject)
            {
                result = result.WithLocalProperty("format");
                if (this.TryGetProperty<Menes.JsonSchema.JsonString>(_MenesFormatJsonPropertyName.Span, out Menes.JsonSchema.JsonString value0))
                {
                    result = value0.Validate(result, level);
                    if (level == Menes.JsonSchema.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                else
                {
                    if (level == Menes.JsonSchema.ValidationLevel.Verbose)
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
            if (this.format is Menes.JsonSchema.JsonString format)
            {
                writer.WritePropertyName(_MenesFormatEncodedJsonPropertyName);
                format.WriteTo(writer);
            }
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                property.WriteTo(writer);
            }
            writer.WriteEndObject();
        }
        /// <inheritdoc />
        public T As<T>()
            where T : struct, Menes.JsonSchema.IJsonValue
        {
            if (typeof(T) == typeof(Draft201909MetaFormat))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }
            return Menes.JsonSchema.JsonValue.As<Draft201909MetaFormat, T>(this);
        }
        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, Menes.JsonSchema.IJsonValue
        {
            if (typeof(T) == typeof(Draft201909MetaFormat))
            {
                return this.Validate(Menes.JsonSchema.ValidationContext.ValidContext).IsValid;
            }
            return this.As<T>().Validate(Menes.JsonSchema.ValidationContext.ValidContext).IsValid;
        }
        /// <inheritdoc/>
        public bool Equals<T>(in T other)
            where T : struct, Menes.JsonSchema.IJsonValue
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatJsonPropertyName.Span))
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
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFormatJsonPropertyName.Span))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatUtf8JsonPropertyName.Span))
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
            where T : struct, Menes.JsonSchema.IJsonValue
        {
            if (this.HasJsonElement)
            {
                if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                {
                    property = Menes.JsonSchema.JsonValue.As<T>(value);
                    return true;
                }
                property = default;
                return false;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatJsonPropertyName.Span))
            {
                if (!(this.Format?.As<T>() is T result))
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
            where T : struct, Menes.JsonSchema.IJsonValue
        {
            if (this.HasJsonElement)
            {
                if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                {
                    property = Menes.JsonSchema.JsonValue.As<T>(value);
                    return true;
                }
                property = default;
                return false;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFormatJsonPropertyName.Span))
            {
                if (!(this.Format?.As<T>() is T result))
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
            where T : struct, Menes.JsonSchema.IJsonValue
        {
            if (this.HasJsonElement)
            {
                if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
                {
                    property = Menes.JsonSchema.JsonValue.As<T>(value);
                    return true;
                }
                property = default;
                return false;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatUtf8JsonPropertyName.Span))
            {
                if (!(this.Format?.As<T>() is T result))
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
        public bool TryGetPropertyAtIndex(int index, out Menes.JsonSchema.IProperty result)
        {
            var rc = this.TryGetPropertyAtIndex(index, out Menes.JsonSchema.Property<Draft201909MetaFormat> prop);
            result = prop;
            return rc;
        }
        public Draft201909MetaFormat RemoveProperty(string propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
        }
        public Draft201909MetaFormat RemoveProperty(System.ReadOnlySpan<char> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
        }
        public Draft201909MetaFormat RemoveProperty(System.ReadOnlySpan<byte> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
        }
        public Draft201909MetaFormat SetProperty<T>(string name, T value)
        where T : struct, Menes.JsonSchema.IJsonValue
        {
            var propertyName = System.MemoryExtensions.AsSpan(name);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatJsonPropertyName.Span))
            {
                return this.WithFormat(value.As<Menes.JsonSchema.JsonString>());
            }
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>>();
            bool added = false;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (!property.NameEquals(propertyName))
                {
                    arrayBuilder.Add(property);
                }
                else
                {
                    arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>(propertyName, value.As<Menes.JsonSchema.JsonAny>()));
                    added = true;
                }
            }
            if (!added)
            {
                arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>(propertyName, value.As<Menes.JsonSchema.JsonAny>()));
            }
            return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
            return this;
        }
        public Draft201909MetaFormat SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
        where T : struct, Menes.JsonSchema.IJsonValue
        {
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatJsonPropertyName.Span))
            {
                return this.WithFormat(value.As<Menes.JsonSchema.JsonString>());
            }
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>>();
            bool added = false;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (!property.NameEquals(propertyName))
                {
                    arrayBuilder.Add(property);
                }
                else
                {
                    arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>(propertyName, value.As<Menes.JsonSchema.JsonAny>()));
                    added = true;
                }
            }
            if (!added)
            {
                arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>(propertyName, value.As<Menes.JsonSchema.JsonAny>()));
            }
            return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
            return this;
        }
        public Draft201909MetaFormat SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
        where T : struct, Menes.JsonSchema.IJsonValue
        {
            System.Span<char> name = stackalloc char[utf8Name.Length];
            int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
            var propertyName = name.Slice(0, writtenCount);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFormatJsonPropertyName.Span))
            {
                return this.WithFormat(value.As<Menes.JsonSchema.JsonString>());
            }
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>>();
            bool added = false;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (!property.NameEquals(propertyName))
                {
                    arrayBuilder.Add(property);
                }
                else
                {
                    arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>(propertyName, value.As<Menes.JsonSchema.JsonAny>()));
                    added = true;
                }
            }
            if (!added)
            {
                arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>(propertyName, value.As<Menes.JsonSchema.JsonAny>()));
            }
            return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
            return this;
        }
        public Draft201909MetaFormat.MenesPropertyEnumerator GetEnumerator()
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
        System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<Draft201909MetaFormat>> System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<Draft201909MetaFormat>>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public Draft201909MetaFormat WithFormat(Menes.JsonSchema.JsonString value)
        {
            return new Draft201909MetaFormat(value, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        private TPropertyValue GetPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
            where TPropertyValue : struct, Menes.JsonSchema.IJsonValue
        {
            return this.GetOptionalPropertyFromJsonElement<TPropertyValue>(propertyName) ?? default;
        }
        private TPropertyValue? GetOptionalPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
            where TPropertyValue : struct, Menes.JsonSchema.IJsonValue
        {
            return this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object ?
                 (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                     ? Menes.JsonSchema.JsonValue.As<TPropertyValue>(property)
                     : null)
                 : null;
        }
        private bool AllBackingFieldsAreNull()
        {
            if (this.format is not null)
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
        private bool TryGetPropertyAtIndex(int index, out Menes.JsonSchema.Property<Draft201909MetaFormat> result)
        {
            if (this.HasJsonElement)
            {
                int jsonPropertyIndex = 0;
                foreach (var property in this.JsonElement.EnumerateObject())
                {
                    if (jsonPropertyIndex == index)
                    {
                        result = new Menes.JsonSchema.Property<Draft201909MetaFormat>(property);
                        return true;
                    }
                    jsonPropertyIndex++;
                }
            }
            int currentIndex = 0;
            if (currentIndex == index)
            {
                result = new Menes.JsonSchema.Property<Draft201909MetaFormat>(this, _MenesFormatJsonPropertyName);
                return true;
            }
            currentIndex++;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (currentIndex == index)
                {
                    result = new Menes.JsonSchema.Property<Draft201909MetaFormat>(this, property.NameAsMemory);
                    return true;
                }
                currentIndex++;
            }
            result = default; ;
            return false;
        }
        private Draft201909MetaFormat WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>> value)
        {
            return new Draft201909MetaFormat(this.format, this._menesBooleanTypeBacking, value);
        }
        /// <summary>
        /// An enumerator for the properties in a <see cref="Draft201909MetaFormat"/>.
        /// </summary>
        public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<Draft201909MetaFormat>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<Draft201909MetaFormat>>, System.Collections.IEnumerator
        {
            private Draft201909MetaFormat instance;
            private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
            private bool hasJsonEnumerator;
            private int index;
            private int propertyCount;
            internal MenesPropertyEnumerator(Draft201909MetaFormat instance)
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
            public Menes.JsonSchema.Property<Draft201909MetaFormat> Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new Menes.JsonSchema.Property<Draft201909MetaFormat>(this.jsonEnumerator.Current);
                    }
                    else if (this.index >= 0)
                    {
                        if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.JsonSchema.Property<Draft201909MetaFormat> result))
                        {
                            return result;
                        }
                        throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                    }
                    return new Menes.JsonSchema.Property<Draft201909MetaFormat>(this.instance, default);
                }
            }
            /// <inheritdoc/>
            object System.Collections.IEnumerator.Current => this.Current;
            /// <summary>
            /// Returns a fresh copy of the enumerator
            /// </summary>
            /// <returns>An enumerator for the properties in a <see cref="Draft201909MetaFormat"/>.</returns>
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
            System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<Draft201909MetaFormat>> System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<Draft201909MetaFormat>>.GetEnumerator()
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
