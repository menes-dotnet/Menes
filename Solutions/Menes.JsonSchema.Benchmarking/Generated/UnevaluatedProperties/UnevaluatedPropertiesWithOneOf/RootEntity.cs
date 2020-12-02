// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace UnevaluatedPropertiesFeature.UnevaluatedPropertiesWithOneOf
{
    public readonly struct RootEntity : Menes.IJsonObject<RootEntity>
    {
        public static readonly RootEntity Null = default(RootEntity);
        private static readonly System.ReadOnlyMemory<char> _MenesFooJsonPropertyName = System.MemoryExtensions.AsMemory("foo");
        private static readonly System.ReadOnlyMemory<byte> _MenesFooUtf8JsonPropertyName = new byte[] { 102, 111, 111 };
        private static readonly System.Text.Json.JsonEncodedText _MenesFooEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFooUtf8JsonPropertyName.Span);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
        private readonly Menes.JsonString? foo;
        public RootEntity(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this.foo = default;
        }
        public RootEntity(Menes.JsonString? foo = null)
        {
            this._menesJsonElementBacking = default;
            this.foo = foo;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
        }
        private RootEntity(Menes.JsonString? foo, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
        {
            this._menesJsonElementBacking = default;
            this.foo = foo;
            this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
        }
        public static implicit operator RootEntity.OneOf0Entity(RootEntity value)
        {
            return value.As<RootEntity.OneOf0Entity>();
        }
        public static implicit operator RootEntity(RootEntity.OneOf0Entity value)
        {
            return value.As<RootEntity>();
        }
        public static implicit operator RootEntity.OneOf1Entity(RootEntity value)
        {
            return value.As<RootEntity.OneOf1Entity>();
        }
        public static implicit operator RootEntity(RootEntity.OneOf1Entity value)
        {
            return value.As<RootEntity>();
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
        public Menes.JsonString? Foo => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesFooUtf8JsonPropertyName.Span) : this.foo;
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
            result = ValidateOneOf(this, result, level);
            if (this.IsObject)
            {
                result = result.UsingEvaluatedProperties();
                result = result.WithLocalProperty("foo");
                if (this.TryGetProperty<Menes.JsonString>(_MenesFooJsonPropertyName.Span, out Menes.JsonString value0))
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
            }
            if (this.IsObject)
            {
                foreach (var property in this.EnumerateObject())
                {
                    if (!result.HasEvaluatedLocalOrAppliedProperty(property.Name))
                    {
                        result = property.Value<Menes.JsonNotAny>().Validate(result, level);
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                        result = result.WithLocalProperty(property.Name);
                    }
                }
            }
            return result;
            Menes.ValidationContext ValidateOneOf(in RootEntity that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                int oneOfCount = 0;
                var oneOf0 = that.AsOneOf0Entity();
                Menes.ValidationContext oneOfResult0;
                if (level == Menes.ValidationLevel.Flag)
                {
                    oneOfResult0 = oneOf0.Validate(validationContext.CreateChildContext(), level);
                }
                else
                {
                    oneOfResult0 = oneOf0.Validate(validationContext.CreateChildContext("#/oneOf/0"), level);
                }
                if (oneOfResult0.IsValid)
                {
                    oneOfCount++;
                }
                result = result.MergeChildContext(oneOfResult0, false);
                var oneOf1 = that.AsOneOf1Entity();
                Menes.ValidationContext oneOfResult1;
                if (level == Menes.ValidationLevel.Flag)
                {
                    oneOfResult1 = oneOf1.Validate(validationContext.CreateChildContext(), level);
                }
                else
                {
                    oneOfResult1 = oneOf1.Validate(validationContext.CreateChildContext("#/oneOf/1"), level);
                }
                if (oneOfResult1.IsValid)
                {
                    oneOfCount++;
                    if (level == Menes.ValidationLevel.Flag && oneOfCount > 1)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "9.2.1.3. oneOf - multiple schema matched");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                    }
                }
                result = result.MergeChildContext(oneOfResult1, false);
                if (oneOfCount == 0)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "9.2.1.2. oneOf - no schema matched");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false);
                    }
                }
                else if (oneOfCount > 1)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "9.2.1.2. oneOf - multiple schema matched");
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
            writer.WriteStartObject();
            if (this.foo is Menes.JsonString foo)
            {
                writer.WritePropertyName(_MenesFooEncodedJsonPropertyName);
                foo.WriteTo(writer);
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
        public readonly RootEntity.OneOf0Entity AsOneOf0Entity()
        {
            return this.As<RootEntity.OneOf0Entity>();
        }
        public readonly RootEntity.OneOf1Entity AsOneOf1Entity()
        {
            return this.As<RootEntity.OneOf1Entity>();
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
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
                return this.WithFoo(value.As<Menes.JsonString>());
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
        public RootEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
        where T : struct, Menes.IJsonValue
        {
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
            {
                return this.WithFoo(value.As<Menes.JsonString>());
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
        public RootEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
        where T : struct, Menes.IJsonValue
        {
            System.Span<char> name = stackalloc char[utf8Name.Length];
            int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
            var propertyName = name.Slice(0, writtenCount);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooJsonPropertyName.Span))
            {
                return this.WithFoo(value.As<Menes.JsonString>());
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
        public RootEntity WithFoo(Menes.JsonString value)
        {
            return new RootEntity(value, this._menesAdditionalPropertiesBacking);
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
        private RootEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
        {
            return new RootEntity(this.foo, value);
        }
        public readonly struct OneOf0Entity : Menes.IJsonObject<OneOf0Entity>
        {
            public static readonly OneOf0Entity Null = default(OneOf0Entity);
            private static readonly System.ReadOnlyMemory<char> _MenesBarJsonPropertyName = System.MemoryExtensions.AsMemory("bar");
            private static readonly System.ReadOnlyMemory<byte> _MenesBarUtf8JsonPropertyName = new byte[] { 98, 97, 114 };
            private static readonly System.Text.Json.JsonEncodedText _MenesBarEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesBarUtf8JsonPropertyName.Span);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
            private readonly RootEntity.OneOf0Entity.BarEntity? bar;
            public OneOf0Entity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
                this.bar = default;
            }
            public OneOf0Entity(RootEntity.OneOf0Entity.BarEntity bar)
            {
                this._menesJsonElementBacking = default;
                this.bar = bar;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            }
            private OneOf0Entity(RootEntity.OneOf0Entity.BarEntity? bar, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
            {
                this._menesJsonElementBacking = default;
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
            public RootEntity.OneOf0Entity.BarEntity Bar => this.HasJsonElement ? this.GetPropertyFromJsonElement<RootEntity.OneOf0Entity.BarEntity>(_MenesBarUtf8JsonPropertyName.Span) : this.bar ?? RootEntity.OneOf0Entity.BarEntity.Null;
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
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                if (level != Menes.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (this.IsObject)
                {
                    result = result.WithLocalProperty("bar");
                    if (this.TryGetProperty<RootEntity.OneOf0Entity.BarEntity>(_MenesBarJsonPropertyName.Span, out RootEntity.OneOf0Entity.BarEntity value0))
                    {
                        result = value0.Validate(result, level);
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    else
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.5.3. required - required property not present.");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag)
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
                writer.WriteStartObject();
                if (this.bar is RootEntity.OneOf0Entity.BarEntity bar)
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
                if (typeof(T) == typeof(OneOf0Entity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<OneOf0Entity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.OneOf0Entity))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarJsonPropertyName.Span))
                {
                    property = this.Bar.As<T>();
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
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesBarJsonPropertyName.Span))
                {
                    property = this.Bar.As<T>();
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarUtf8JsonPropertyName.Span))
                {
                    property = this.Bar.As<T>();
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
                var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<OneOf0Entity> prop);
                result = prop;
                return rc;
            }
            public OneOf0Entity RemoveProperty(string propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public OneOf0Entity RemoveProperty(System.ReadOnlySpan<char> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public OneOf0Entity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public OneOf0Entity SetProperty<T>(string name, T value)
            where T : struct, Menes.IJsonValue
            {
                var propertyName = System.MemoryExtensions.AsSpan(name);
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarJsonPropertyName.Span))
                {
                    return this.WithBar(value.As<RootEntity.OneOf0Entity.BarEntity>());
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
            public OneOf0Entity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
            where T : struct, Menes.IJsonValue
            {
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarJsonPropertyName.Span))
                {
                    return this.WithBar(value.As<RootEntity.OneOf0Entity.BarEntity>());
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
            public OneOf0Entity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
            where T : struct, Menes.IJsonValue
            {
                System.Span<char> name = stackalloc char[utf8Name.Length];
                int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
                var propertyName = name.Slice(0, writtenCount);
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBarJsonPropertyName.Span))
                {
                    return this.WithBar(value.As<RootEntity.OneOf0Entity.BarEntity>());
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
            public RootEntity.OneOf0Entity.MenesPropertyEnumerator GetEnumerator()
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
            System.Collections.Generic.IEnumerator<Menes.Property<RootEntity.OneOf0Entity>> System.Collections.Generic.IEnumerable<Menes.Property<RootEntity.OneOf0Entity>>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            public OneOf0Entity WithBar(RootEntity.OneOf0Entity.BarEntity value)
            {
                return new OneOf0Entity(value, this._menesAdditionalPropertiesBacking);
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
            private bool TryGetPropertyAtIndex(int index, out Menes.Property<OneOf0Entity> result)
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        if (jsonPropertyIndex == index)
                        {
                            result = new Menes.Property<OneOf0Entity>(property);
                            return true;
                        }
                        jsonPropertyIndex++;
                    }
                }
                int currentIndex = 0;
                if (currentIndex == index)
                {
                    result = new Menes.Property<OneOf0Entity>(this, _MenesBarJsonPropertyName);
                    return true;
                }
                currentIndex++;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (currentIndex == index)
                    {
                        result = new Menes.Property<OneOf0Entity>(this, property.NameAsMemory);
                        return true;
                    }
                    currentIndex++;
                }
                result = default; ;
                return false;
            }
            private OneOf0Entity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
            {
                return new OneOf0Entity(this.bar, value);
            }
            public readonly struct BarEntity : Menes.IJsonValue
            {
                public static readonly BarEntity Null = default(BarEntity);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                private readonly Menes.JsonString? _menesStringTypeBacking;
                private static readonly Menes.JsonString _MenesConstValue = new Menes.JsonString("bar");
                public BarEntity(System.Text.Json.JsonElement jsonElement)
                {
                    this._menesJsonElementBacking = jsonElement;
                    this._menesStringTypeBacking = default;
                }
                public BarEntity(Menes.JsonString value)
                {
                    this._menesJsonElementBacking = default;
                    this._menesStringTypeBacking = value;
                }
                private BarEntity(Menes.JsonString? _menesStringTypeBacking)
                {
                    this._menesJsonElementBacking = default;
                    this._menesStringTypeBacking = _menesStringTypeBacking;
                }
                public static implicit operator Menes.JsonString(BarEntity value)
                {
                    return value.As<Menes.JsonString>();
                }
                public static implicit operator BarEntity(Menes.JsonString value)
                {
                    return value.As<RootEntity.OneOf0Entity.BarEntity>();
                }
                public static implicit operator string(BarEntity value)
                {
                    return (string)(Menes.JsonString)value;
                }
                public static implicit operator BarEntity(string value)
                {
                    return (RootEntity.OneOf0Entity.BarEntity)(Menes.JsonString)value;
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
                public bool IsString => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String) || (!this.HasJsonElement && this._menesStringTypeBacking is not null);
                /// <inheritdoc />
                public bool IsObject => false;
                /// <inheritdoc />
                public bool IsBoolean => false;
                /// <inheritdoc />
                public bool IsArray => false;
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
                    if (!this.IsString)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of string");
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
                    if (!this.IsString)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"bar\"");
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
                    else
                    {
                        if (!System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), _MenesConstValue.AsSpan()))
                        {
                            if (level >= Menes.ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"bar\"");
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
                    this._menesStringTypeBacking?.WriteTo(writer);
                }
                /// <inheritdoc />
                public T As<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(BarEntity))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<BarEntity, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(RootEntity.OneOf0Entity.BarEntity))
                    {
                        return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                    }
                    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                /// <inheritdoc/>
                public bool Equals<T>(in T other)
                    where T : struct, Menes.IJsonValue
                {
                    if (!other.IsString)
                    {
                        return false;
                    }
                    return ((Menes.JsonString)this).Equals(other);
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
            /// <summary>
            /// An enumerator for the properties in a <see cref="OneOf0Entity"/>.
            /// </summary>
            public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<OneOf0Entity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<OneOf0Entity>>, System.Collections.IEnumerator
            {
                private OneOf0Entity instance;
                private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                private int propertyCount;
                internal MenesPropertyEnumerator(OneOf0Entity instance)
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
                public Menes.Property<OneOf0Entity> Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.Property<OneOf0Entity>(this.jsonEnumerator.Current);
                        }
                        else if (this.index >= 0)
                        {
                            if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<OneOf0Entity> result))
                            {
                                return result;
                            }
                            throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                        }
                        return new Menes.Property<OneOf0Entity>(this.instance, default);
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the properties in a <see cref="OneOf0Entity"/>.</returns>
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
                System.Collections.Generic.IEnumerator<Menes.Property<OneOf0Entity>> System.Collections.Generic.IEnumerable<Menes.Property<OneOf0Entity>>.GetEnumerator()
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
        public readonly struct OneOf1Entity : Menes.IJsonObject<OneOf1Entity>
        {
            public static readonly OneOf1Entity Null = default(OneOf1Entity);
            private static readonly System.ReadOnlyMemory<char> _MenesBazJsonPropertyName = System.MemoryExtensions.AsMemory("baz");
            private static readonly System.ReadOnlyMemory<byte> _MenesBazUtf8JsonPropertyName = new byte[] { 98, 97, 122 };
            private static readonly System.Text.Json.JsonEncodedText _MenesBazEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesBazUtf8JsonPropertyName.Span);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
            private readonly RootEntity.OneOf1Entity.BazEntity? baz;
            public OneOf1Entity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
                this.baz = default;
            }
            public OneOf1Entity(RootEntity.OneOf1Entity.BazEntity baz)
            {
                this._menesJsonElementBacking = default;
                this.baz = baz;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            }
            private OneOf1Entity(RootEntity.OneOf1Entity.BazEntity? baz, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
            {
                this._menesJsonElementBacking = default;
                this.baz = baz;
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
            public RootEntity.OneOf1Entity.BazEntity Baz => this.HasJsonElement ? this.GetPropertyFromJsonElement<RootEntity.OneOf1Entity.BazEntity>(_MenesBazUtf8JsonPropertyName.Span) : this.baz ?? RootEntity.OneOf1Entity.BazEntity.Null;
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
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
            {
                Menes.ValidationContext result = validationContext;
                if (level != Menes.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (this.IsObject)
                {
                    result = result.WithLocalProperty("baz");
                    if (this.TryGetProperty<RootEntity.OneOf1Entity.BazEntity>(_MenesBazJsonPropertyName.Span, out RootEntity.OneOf1Entity.BazEntity value0))
                    {
                        result = value0.Validate(result, level);
                        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                    }
                    else
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.5.3. required - required property not present.");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                        if (level == Menes.ValidationLevel.Flag)
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
                writer.WriteStartObject();
                if (this.baz is RootEntity.OneOf1Entity.BazEntity baz)
                {
                    writer.WritePropertyName(_MenesBazEncodedJsonPropertyName);
                    baz.WriteTo(writer);
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
                if (typeof(T) == typeof(OneOf1Entity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<OneOf1Entity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.OneOf1Entity))
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
                    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBazJsonPropertyName.Span))
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
                    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesBazJsonPropertyName.Span))
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
                    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBazUtf8JsonPropertyName.Span))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBazJsonPropertyName.Span))
                {
                    property = this.Baz.As<T>();
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
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesBazJsonPropertyName.Span))
                {
                    property = this.Baz.As<T>();
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBazUtf8JsonPropertyName.Span))
                {
                    property = this.Baz.As<T>();
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
                var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<OneOf1Entity> prop);
                result = prop;
                return rc;
            }
            public OneOf1Entity RemoveProperty(string propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public OneOf1Entity RemoveProperty(System.ReadOnlySpan<char> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public OneOf1Entity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonNull.Instance);
            }
            public OneOf1Entity SetProperty<T>(string name, T value)
            where T : struct, Menes.IJsonValue
            {
                var propertyName = System.MemoryExtensions.AsSpan(name);
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBazJsonPropertyName.Span))
                {
                    return this.WithBaz(value.As<RootEntity.OneOf1Entity.BazEntity>());
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
            public OneOf1Entity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
            where T : struct, Menes.IJsonValue
            {
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBazJsonPropertyName.Span))
                {
                    return this.WithBaz(value.As<RootEntity.OneOf1Entity.BazEntity>());
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
            public OneOf1Entity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
            where T : struct, Menes.IJsonValue
            {
                System.Span<char> name = stackalloc char[utf8Name.Length];
                int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
                var propertyName = name.Slice(0, writtenCount);
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesBazJsonPropertyName.Span))
                {
                    return this.WithBaz(value.As<RootEntity.OneOf1Entity.BazEntity>());
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
            public RootEntity.OneOf1Entity.MenesPropertyEnumerator GetEnumerator()
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
            System.Collections.Generic.IEnumerator<Menes.Property<RootEntity.OneOf1Entity>> System.Collections.Generic.IEnumerable<Menes.Property<RootEntity.OneOf1Entity>>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            public OneOf1Entity WithBaz(RootEntity.OneOf1Entity.BazEntity value)
            {
                return new OneOf1Entity(value, this._menesAdditionalPropertiesBacking);
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
                if (this.baz is not null)
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
            private bool TryGetPropertyAtIndex(int index, out Menes.Property<OneOf1Entity> result)
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        if (jsonPropertyIndex == index)
                        {
                            result = new Menes.Property<OneOf1Entity>(property);
                            return true;
                        }
                        jsonPropertyIndex++;
                    }
                }
                int currentIndex = 0;
                if (currentIndex == index)
                {
                    result = new Menes.Property<OneOf1Entity>(this, _MenesBazJsonPropertyName);
                    return true;
                }
                currentIndex++;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (currentIndex == index)
                    {
                        result = new Menes.Property<OneOf1Entity>(this, property.NameAsMemory);
                        return true;
                    }
                    currentIndex++;
                }
                result = default; ;
                return false;
            }
            private OneOf1Entity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
            {
                return new OneOf1Entity(this.baz, value);
            }
            public readonly struct BazEntity : Menes.IJsonValue
            {
                public static readonly BazEntity Null = default(BazEntity);
                private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
                private readonly Menes.JsonString? _menesStringTypeBacking;
                private static readonly Menes.JsonString _MenesConstValue = new Menes.JsonString("baz");
                public BazEntity(System.Text.Json.JsonElement jsonElement)
                {
                    this._menesJsonElementBacking = jsonElement;
                    this._menesStringTypeBacking = default;
                }
                public BazEntity(Menes.JsonString value)
                {
                    this._menesJsonElementBacking = default;
                    this._menesStringTypeBacking = value;
                }
                private BazEntity(Menes.JsonString? _menesStringTypeBacking)
                {
                    this._menesJsonElementBacking = default;
                    this._menesStringTypeBacking = _menesStringTypeBacking;
                }
                public static implicit operator Menes.JsonString(BazEntity value)
                {
                    return value.As<Menes.JsonString>();
                }
                public static implicit operator BazEntity(Menes.JsonString value)
                {
                    return value.As<RootEntity.OneOf1Entity.BazEntity>();
                }
                public static implicit operator string(BazEntity value)
                {
                    return (string)(Menes.JsonString)value;
                }
                public static implicit operator BazEntity(string value)
                {
                    return (RootEntity.OneOf1Entity.BazEntity)(Menes.JsonString)value;
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
                public bool IsString => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String) || (!this.HasJsonElement && this._menesStringTypeBacking is not null);
                /// <inheritdoc />
                public bool IsObject => false;
                /// <inheritdoc />
                public bool IsBoolean => false;
                /// <inheritdoc />
                public bool IsArray => false;
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
                    if (!this.IsString)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of string");
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
                    if (!this.IsString)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"baz\"");
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
                    else
                    {
                        if (!System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), _MenesConstValue.AsSpan()))
                        {
                            if (level >= Menes.ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"baz\"");
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
                    this._menesStringTypeBacking?.WriteTo(writer);
                }
                /// <inheritdoc />
                public T As<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(BazEntity))
                    {
                        return Corvus.Extensions.CastTo<T>.From(this);
                    }
                    return Menes.JsonValue.As<BazEntity, T>(this);
                }
                /// <inheritdoc />
                public bool Is<T>()
                    where T : struct, Menes.IJsonValue
                {
                    if (typeof(T) == typeof(RootEntity.OneOf1Entity.BazEntity))
                    {
                        return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
                    }
                    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
                }
                /// <inheritdoc/>
                public bool Equals<T>(in T other)
                    where T : struct, Menes.IJsonValue
                {
                    if (!other.IsString)
                    {
                        return false;
                    }
                    return ((Menes.JsonString)this).Equals(other);
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
            /// <summary>
            /// An enumerator for the properties in a <see cref="OneOf1Entity"/>.
            /// </summary>
            public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<OneOf1Entity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<OneOf1Entity>>, System.Collections.IEnumerator
            {
                private OneOf1Entity instance;
                private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                private int propertyCount;
                internal MenesPropertyEnumerator(OneOf1Entity instance)
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
                public Menes.Property<OneOf1Entity> Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.Property<OneOf1Entity>(this.jsonEnumerator.Current);
                        }
                        else if (this.index >= 0)
                        {
                            if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<OneOf1Entity> result))
                            {
                                return result;
                            }
                            throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                        }
                        return new Menes.Property<OneOf1Entity>(this.instance, default);
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the properties in a <see cref="OneOf1Entity"/>.</returns>
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
                System.Collections.Generic.IEnumerator<Menes.Property<OneOf1Entity>> System.Collections.Generic.IEnumerable<Menes.Property<OneOf1Entity>>.GetEnumerator()
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
