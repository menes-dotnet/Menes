// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace PropertiesFeature.PropertiesPatternPropertiesAdditionalPropertiesInteraction
{
    public readonly struct RootEntity : Menes.IJsonObject<RootEntity>
    {
        public static readonly RootEntity Null = default(RootEntity);
        private static readonly System.ReadOnlyMemory<char> _MenesFooJsonPropertyName = System.MemoryExtensions.AsMemory("foo");
        private static readonly System.ReadOnlyMemory<char> _MenesBarJsonPropertyName = System.MemoryExtensions.AsMemory("bar");
        private static readonly System.ReadOnlyMemory<byte> _MenesFooUtf8JsonPropertyName = new byte[] { 102, 111, 111 };
        private static readonly System.ReadOnlyMemory<byte> _MenesBarUtf8JsonPropertyName = new byte[] { 98, 97, 114 };
        private static readonly System.Text.Json.JsonEncodedText _MenesFooEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFooUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesBarEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesBarUtf8JsonPropertyName.Span);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonInteger>> _menesAdditionalPropertiesBacking;
        private readonly RootEntity.FooArray? foo;
        private readonly RootEntity.BarArray? bar;
        private static readonly System.Text.RegularExpressions.Regex _MenesPatternExpression0 = new System.Text.RegularExpressions.Regex("f.o", System.Text.RegularExpressions.RegexOptions.Compiled);
        public RootEntity(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonInteger>>.Empty;
            this.foo = default;
            this.bar = default;
        }
        public RootEntity(RootEntity.FooArray? foo = null, RootEntity.BarArray? bar = null)
        {
            this._menesJsonElementBacking = default;
            this.foo = foo;
            this.bar = bar;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonInteger>>.Empty;
        }
        private RootEntity(RootEntity.FooArray? foo, RootEntity.BarArray? bar, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonInteger>> _menesAdditionalPropertiesBacking)
        {
            this._menesJsonElementBacking = default;
            this.foo = foo;
            this.bar = bar;
            this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
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
        public RootEntity.FooArray? Foo => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<RootEntity.FooArray>(_MenesFooUtf8JsonPropertyName.Span) : this.foo;
        public RootEntity.BarArray? Bar => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<RootEntity.BarArray>(_MenesBarUtf8JsonPropertyName.Span) : this.bar;
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
                    return 2 + this._menesAdditionalPropertiesBacking.Length;
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
            if (this.IsObject)
            {
                result = result.UsingEvaluatedProperties();
                result = result.WithLocalProperty("foo");
                if (this.TryGetProperty<RootEntity.FooArray>(_MenesFooJsonPropertyName.Span, out RootEntity.FooArray value0))
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
                result = result.WithLocalProperty("bar");
                if (this.TryGetProperty<RootEntity.BarArray>(_MenesBarJsonPropertyName.Span, out RootEntity.BarArray value1))
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
            }
            if (this.IsObject)
            {
                foreach (var property in this.EnumerateObject())
                {
                    if (_MenesPatternExpression0.IsMatch(property.Name))
                    {
                        result = result.WithLocalProperty(property.Name);
                        result = property.Value<RootEntity.FOEntity>().Validate(result, level);
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    if (!result.HasEvaluatedLocalProperty(property.Name))
                    {
                        result = result.WithLocalProperty(property.Name);
                        result = property.Value<Menes.JsonInteger>().Validate(result, level);
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
            if (this.foo is RootEntity.FooArray foo)
            {
                writer.WritePropertyName(_MenesFooEncodedJsonPropertyName);
                foo.WriteTo(writer);
            }
            if (this.bar is RootEntity.BarArray bar)
            {
                writer.WritePropertyName(_MenesBarEncodedJsonPropertyName);
                bar.WriteTo(writer);
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
            if (typeof(T) == typeof(RootEntity))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }
            return Menes.JsonValue.As<RootEntity, T>(this);
        }
        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, Menes.IJsonValue
        {
            if (typeof(T) == typeof(RootEntity))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarJsonPropertyName.Span))
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
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesBarJsonPropertyName.Span))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarUtf8JsonPropertyName.Span))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
            {
                if (!(this.Foo?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarJsonPropertyName.Span))
            {
                if (!(this.Bar?.As<T>() is T result))
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
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooJsonPropertyName.Span))
            {
                if (!(this.Foo?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesBarJsonPropertyName.Span))
            {
                if (!(this.Bar?.As<T>() is T result))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooUtf8JsonPropertyName.Span))
            {
                if (!(this.Foo?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarUtf8JsonPropertyName.Span))
            {
                if (!(this.Bar?.As<T>() is T result))
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
            var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<RootEntity> prop);
            result = prop;
            return rc;
        }
        public RootEntity RemoveProperty(string propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public RootEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public RootEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonNull.Instance);
        }
        public RootEntity SetProperty<T>(string name, T value)
        where T : struct, Menes.IJsonValue
        {
            var propertyName = System.MemoryExtensions.AsSpan(name);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
            {
                return this.WithFoo(value.As<RootEntity.FooArray>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarJsonPropertyName.Span))
            {
                return this.WithBar(value.As<RootEntity.BarArray>());
            }
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonInteger>>();
            bool added = false;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (!property.NameEquals(propertyName))
                {
                    arrayBuilder.Add(property);
                }
                else
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonInteger>(propertyName, value.As<Menes.JsonInteger>()));
                    added = true;
                }
            }
            if (!added)
            {
                arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonInteger>(propertyName, value.As<Menes.JsonInteger>()));
            }
            return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
            return this;
        }
        public RootEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
        where T : struct, Menes.IJsonValue
        {
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
            {
                return this.WithFoo(value.As<RootEntity.FooArray>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarJsonPropertyName.Span))
            {
                return this.WithBar(value.As<RootEntity.BarArray>());
            }
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonInteger>>();
            bool added = false;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (!property.NameEquals(propertyName))
                {
                    arrayBuilder.Add(property);
                }
                else
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonInteger>(propertyName, value.As<Menes.JsonInteger>()));
                    added = true;
                }
            }
            if (!added)
            {
                arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonInteger>(propertyName, value.As<Menes.JsonInteger>()));
            }
            return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
            return this;
        }
        public RootEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
        where T : struct, Menes.IJsonValue
        {
            System.Span<char> name = stackalloc char[utf8Name.Length];
            int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
            var propertyName = name.Slice(0, writtenCount);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
            {
                return this.WithFoo(value.As<RootEntity.FooArray>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarJsonPropertyName.Span))
            {
                return this.WithBar(value.As<RootEntity.BarArray>());
            }
            var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonInteger>>();
            bool added = false;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (!property.NameEquals(propertyName))
                {
                    arrayBuilder.Add(property);
                }
                else
                {
                    arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonInteger>(propertyName, value.As<Menes.JsonInteger>()));
                    added = true;
                }
            }
            if (!added)
            {
                arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonInteger>(propertyName, value.As<Menes.JsonInteger>()));
            }
            return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
            return this;
        }
        public RootEntity.MenesPropertyEnumerator GetEnumerator()
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
        System.Collections.Generic.IEnumerator<Menes.Property<RootEntity>> System.Collections.Generic.IEnumerable<Menes.Property<RootEntity>>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public RootEntity WithFoo(RootEntity.FooArray value)
        {
            return new RootEntity(value, this.bar, this._menesAdditionalPropertiesBacking);
        }
        public RootEntity WithBar(RootEntity.BarArray value)
        {
            return new RootEntity(this.foo, value, this._menesAdditionalPropertiesBacking);
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
            if (this.foo is not null)
            {
                return false;
            }
            if (this.bar is not null)
            {
                return false;
            }
            if (this._menesAdditionalPropertiesBacking.Length > 0)
            {
                return false;
            }
            return true;
        }
        /// <inheritdoc />
        private bool TryGetPropertyAtIndex(int index, out Menes.Property<RootEntity> result)
        {
            if (this.HasJsonElement)
            {
                int jsonPropertyIndex = 0;
                foreach (var property in this.JsonElement.EnumerateObject())
                {
                    if (jsonPropertyIndex == index)
                    {
                        result = new Menes.Property<RootEntity>(property);
                        return true;
                    }
                    jsonPropertyIndex++;
                }
            }
            int currentIndex = 0;
            if (currentIndex == index)
            {
                result = new Menes.Property<RootEntity>(this, _MenesFooJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<RootEntity>(this, _MenesBarJsonPropertyName);
                return true;
            }
            currentIndex++;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (currentIndex == index)
                {
                    result = new Menes.Property<RootEntity>(this, property.NameAsMemory);
                    return true;
                }
                currentIndex++;
            }
            result = default; ;
            return false;
        }
        private RootEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonInteger>> value)
        {
            return new RootEntity(this.foo, this.bar, value);
        }
        public readonly struct FOEntity : Menes.IJsonValue, Menes.IJsonArray<FOEntity, Menes.JsonAny>
        {
            public static readonly FOEntity Null = default(FOEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
            public FOEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public FOEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
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
                if (this.IsArray)
                {
                    int arrayLength = 0;
                    var arrayEnumerator = this.EnumerateArray();
                    while (arrayEnumerator.MoveNext())
                    {
                        arrayLength++;
                    }
                    if (arrayLength < 2)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.4.2.  minItems - expected a minimum of 2 items");
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
                if (typeof(T) == typeof(FOEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<FOEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.FOEntity))
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
            public RootEntity.FOEntity.MenesArrayEnumerator GetEnumerator()
            {
                return new RootEntity.FOEntity.MenesArrayEnumerator(this);
            }
            public RootEntity.FOEntity.MenesArrayEnumerator EnumerateArray()
            {
                return new RootEntity.FOEntity.MenesArrayEnumerator(this);
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
            public FOEntity Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity Add<T1, T2>(T1 item1, T2 item2)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity Add<T>(params T[] items)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity Insert<T>(int index, T item1)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity Insert<T1, T2>(int index, T1 item1, T2 item2)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity Insert<T>(int index, params T[] items)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity RemoveAt(int index)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
            }
            public FOEntity RemoveIf(System.Predicate<Menes.JsonAny> condition)
            {
                return this.RemoveIf<Menes.JsonAny>(condition);
            }
            public FOEntity RemoveIf<T>(System.Predicate<T> condition)
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
                return new RootEntity.FOEntity(arrayBuilder.ToImmutable());
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
            /// An enumerator for the array values in a <see cref="FOEntity"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
            {
                private FOEntity instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(FOEntity instance)
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
                /// <returns>An enumerator for the array values in a <see cref="FOEntity"/>.</returns>
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
        public readonly struct FooArray : Menes.IJsonValue, Menes.IJsonArray<FooArray, Menes.JsonAny>
        {
            public static readonly FooArray Null = default(FooArray);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
            public FooArray(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public FooArray(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
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
                        arrayLength++;
                    }
                    if (arrayLength > 3)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.4.2.  minItems - expected a maximum of 3 items");
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
                if (typeof(T) == typeof(FooArray))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<FooArray, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.FooArray))
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
            public RootEntity.FooArray.MenesArrayEnumerator GetEnumerator()
            {
                return new RootEntity.FooArray.MenesArrayEnumerator(this);
            }
            public RootEntity.FooArray.MenesArrayEnumerator EnumerateArray()
            {
                return new RootEntity.FooArray.MenesArrayEnumerator(this);
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
            public FooArray Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray Add<T1, T2>(T1 item1, T2 item2)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray Add<T>(params T[] items)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray Insert<T>(int index, T item1)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray Insert<T1, T2>(int index, T1 item1, T2 item2)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray Insert<T>(int index, params T[] items)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray RemoveAt(int index)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
            }
            public FooArray RemoveIf(System.Predicate<Menes.JsonAny> condition)
            {
                return this.RemoveIf<Menes.JsonAny>(condition);
            }
            public FooArray RemoveIf<T>(System.Predicate<T> condition)
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
                return new RootEntity.FooArray(arrayBuilder.ToImmutable());
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
            /// An enumerator for the array values in a <see cref="FooArray"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
            {
                private FooArray instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(FooArray instance)
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
                /// <returns>An enumerator for the array values in a <see cref="FooArray"/>.</returns>
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
        public readonly struct BarArray : Menes.IJsonValue, Menes.IJsonArray<BarArray, Menes.JsonAny>
        {
            public static readonly BarArray Null = default(BarArray);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
            public BarArray(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public BarArray(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
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
                if (typeof(T) == typeof(BarArray))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<BarArray, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.BarArray))
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
            public RootEntity.BarArray.MenesArrayEnumerator GetEnumerator()
            {
                return new RootEntity.BarArray.MenesArrayEnumerator(this);
            }
            public RootEntity.BarArray.MenesArrayEnumerator EnumerateArray()
            {
                return new RootEntity.BarArray.MenesArrayEnumerator(this);
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
            public BarArray Add<T1>(T1 item1)
                where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(item1.As<Menes.JsonAny>());
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray Add<T1, T2>(T1 item1, T2 item2)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray Add<T>(params T[] items)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray Insert<T>(int index, T item1)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray Insert<T1, T2>(int index, T1 item1, T2 item2)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray Insert<T>(int index, params T[] items)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray RemoveAt(int index)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
            }
            public BarArray RemoveIf(System.Predicate<Menes.JsonAny> condition)
            {
                return this.RemoveIf<Menes.JsonAny>(condition);
            }
            public BarArray RemoveIf<T>(System.Predicate<T> condition)
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
                return new RootEntity.BarArray(arrayBuilder.ToImmutable());
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
            /// An enumerator for the array values in a <see cref="BarArray"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
            {
                private BarArray instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(BarArray instance)
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
                /// <returns>An enumerator for the array values in a <see cref="BarArray"/>.</returns>
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
        /// An enumerator for the properties in a <see cref="RootEntity"/>.
        /// </summary>
        public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<RootEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<RootEntity>>, System.Collections.IEnumerator
        {
            private RootEntity instance;
            private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
            private bool hasJsonEnumerator;
            private int index;
            private int propertyCount;
            internal MenesPropertyEnumerator(RootEntity instance)
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
            public Menes.Property<RootEntity> Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new Menes.Property<RootEntity>(this.jsonEnumerator.Current);
                    }
                    else if (this.index >= 0)
                    {
                        if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<RootEntity> result))
                        {
                            return result;
                        }
                        throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                    }
                    return new Menes.Property<RootEntity>(this.instance, default);
                }
            }
            /// <inheritdoc/>
            object System.Collections.IEnumerator.Current => this.Current;
            /// <summary>
            /// Returns a fresh copy of the enumerator
            /// </summary>
            /// <returns>An enumerator for the properties in a <see cref="RootEntity"/>.</returns>
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
            System.Collections.Generic.IEnumerator<Menes.Property<RootEntity>> System.Collections.Generic.IEnumerable<Menes.Property<RootEntity>>.GetEnumerator()
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
