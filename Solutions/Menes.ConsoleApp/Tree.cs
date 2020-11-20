// <copyright file="Tree.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace TestSpace
{
    public readonly struct Tree : Menes.IJsonObject
    {
        public static readonly Tree Null = default(Tree);
        private static readonly System.ReadOnlyMemory<char> _MenesMetaJsonPropertyName = System.MemoryExtensions.AsMemory("meta");
        private static readonly System.ReadOnlyMemory<char> _MenesNodesJsonPropertyName = System.MemoryExtensions.AsMemory("nodes");
        private static readonly System.ReadOnlyMemory<byte> _MenesMetaUtf8JsonPropertyName = new byte[] { 109, 101, 116, 97 };
        private static readonly System.ReadOnlyMemory<byte> _MenesNodesUtf8JsonPropertyName = new byte[] { 110, 111, 100, 101, 115 };
        private static readonly System.Text.Json.JsonEncodedText _MenesMetaEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesMetaUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesNodesEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesNodesUtf8JsonPropertyName.Span);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
        private readonly Menes.JsonString? meta;
        private readonly Menes.JsonValueBacking nodes;
        public Tree(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this.meta = default;
            this.nodes = default;
        }
        public Tree(Menes.JsonString meta, Tree.NodesArray nodes)
        {
            this._menesJsonElementBacking = default;
            this.meta = meta;
            this.nodes = Menes.JsonValueBacking.From<Tree.NodesArray>(nodes);
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
        }
        private Tree(Menes.JsonString? meta, Menes.JsonValueBacking nodes, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
        {
            this._menesJsonElementBacking = default;
            this.meta = meta;
            this.nodes = nodes;
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
        public Menes.JsonString Meta => this.HasJsonElement ? this.GetPropertyFromJsonElement<Menes.JsonString>(_MenesMetaUtf8JsonPropertyName.Span) : this.meta ?? Menes.JsonString.Null;
        public Tree.NodesArray Nodes => this.HasJsonElement ? this.GetPropertyFromJsonElement<Tree.NodesArray>(_MenesNodesUtf8JsonPropertyName.Span) : this.nodes.As<Tree.NodesArray>() ?? Tree.NodesArray.Null;
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
            if (this.meta is Menes.JsonString meta)
            {
                writer.WritePropertyName(_MenesMetaEncodedJsonPropertyName);
                meta.WriteTo(writer);
            }
            if (this.nodes is Menes.JsonValueBacking nodes && !nodes.IsNull)
            {
                writer.WritePropertyName(_MenesNodesEncodedJsonPropertyName);
                nodes.WriteTo(writer);
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
            if (typeof(T) == typeof(Tree))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }
            return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
        }
        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, Menes.IJsonValue
        {
            if (typeof(T) == typeof(Tree))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMetaJsonPropertyName.Span))
            {
                property = this.Meta.As<T>();
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesNodesJsonPropertyName.Span))
            {
                property = this.Nodes.As<T>();
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
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesMetaJsonPropertyName.Span))
            {
                property = this.Meta.As<T>();
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesNodesJsonPropertyName.Span))
            {
                property = this.Nodes.As<T>();
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesMetaUtf8JsonPropertyName.Span))
            {
                property = this.Meta.As<T>();
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesNodesUtf8JsonPropertyName.Span))
            {
                property = this.Nodes.As<T>();
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
        public Tree.MenesPropertyEnumerator GetEnumerator() { return new Tree.MenesPropertyEnumerator(this); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
        public Tree WithMeta(Menes.JsonString value)
        {
            return new Tree(value, this.nodes, this._menesAdditionalPropertiesBacking);
        }
        public Tree WithNodes(Tree.NodesArray value)
        {
            return new Tree(this.meta, Menes.JsonValueBacking.From<Tree.NodesArray>(value), this._menesAdditionalPropertiesBacking);
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
            if (this.meta is not null)
            {
                return false;
            }
            if (!this.nodes.IsNull)
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
        private bool TryGetPropertyAtIndex(int index, out Menes.Property<Tree> result)
        {
            if (this.HasJsonElement)
            {
                int jsonPropertyIndex = 0;
                foreach (var property in this.JsonElement.EnumerateObject())
                {
                    if (jsonPropertyIndex == index)
                    {
                        result = new Menes.Property<Tree>(property);
                        return true;
                    }
                    jsonPropertyIndex++;
                }
            }
            int currentIndex = 0;
            if (currentIndex == index)
            {
                result = new Menes.Property<Tree>(this, _MenesMetaJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.Property<Tree>(this, _MenesNodesJsonPropertyName);
                return true;
            }
            currentIndex++;
            result = default; ;
            return false;
        }
        public readonly struct NodesArray : Menes.IJsonValue, System.Collections.IEnumerable
        {
            public static readonly NodesArray Null = default(NodesArray);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking>? _menesArrayValueBacking;
            public NodesArray(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesArrayValueBacking = default;
            }
            public NodesArray(System.Collections.Immutable.ImmutableArray<Tree.NodeEntity> value)
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                foreach (var item in value)
                {
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item));
                }
                this._menesArrayValueBacking = arrayBuilder.ToImmutable();
                this._menesJsonElementBacking = default;
            }
            private NodesArray(System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking> value)
            {
                this._menesArrayValueBacking = value;
                this._menesJsonElementBacking = default;
            }
            public static implicit operator NodesArray(System.Collections.Immutable.ImmutableArray<Tree.NodeEntity> items)
            {
                return new Tree.NodesArray(items);
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
                if (typeof(T) == typeof(NodesArray))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Tree.NodesArray))
                {
                    return this.Validate().Valid;
                }
                return this.As<T>().Validate().Valid;
            }
            public Tree.NodesArray.MenesArrayEnumerator GetEnumerator() { return new Tree.NodesArray.MenesArrayEnumerator(this); }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
            public NodesArray Add<T1>(T1 item1)
where T1 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item1.As<Tree.NodeEntity>()));
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray Add<T1, T2>(T1 item1, T2 item2)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item1.As<Tree.NodeEntity>()));
                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item2.As<Tree.NodeEntity>()));
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
                where T1 : struct, Menes.IJsonValue
                where T2 : struct, Menes.IJsonValue
                where T3 : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item1.As<Tree.NodeEntity>()));
                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item2.As<Tree.NodeEntity>()));
                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item3.As<Tree.NodeEntity>()));
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
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
                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item1.As<Tree.NodeEntity>()));
                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item2.As<Tree.NodeEntity>()));
                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item3.As<Tree.NodeEntity>()));
                arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item4.As<Tree.NodeEntity>()));
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray Add<T>(params T[] items)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    arrayBuilder.Add(oldItem);
                }
                foreach (var item1 in items)
                {
                    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item1.As<Tree.NodeEntity>()));
                }
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray Insert<T>(int index, T item1)
                where T : struct, Menes.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();
                int currentIndex = 0;
                bool inserted = false;
                foreach (var oldItem in this._menesArrayValueBacking)
                {
                    if (currentIndex == index)
                    {
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item1.As<Tree.NodeEntity>()));
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray Insert<T1, T2>(int index, T1 item1, T2 item2)
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
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item1.As<Tree.NodeEntity>()));
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item2.As<Tree.NodeEntity>()));
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
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
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item1.As<Tree.NodeEntity>()));
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item2.As<Tree.NodeEntity>()));
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item3.As<Tree.NodeEntity>()));
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
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
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item1.As<Tree.NodeEntity>()));
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item2.As<Tree.NodeEntity>()));
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item3.As<Tree.NodeEntity>()));
                        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item4.As<Tree.NodeEntity>()));
                        inserted = true;
                    }
                    arrayBuilder.Add(oldItem);
                    currentIndex++;
                }
                if (!inserted)
                {
                    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
                }
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray Insert<T>(int index, params T[] items)
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
                            arrayBuilder.Add(Menes.JsonArrayValueBacking.From<Tree.NodeEntity>(item1.As<Tree.NodeEntity>()));
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
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray RemoveAt(int index)
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
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
            }
            public NodesArray RemoveIf(System.Predicate<Tree.NodeEntity> condition)
            {
                return this.RemoveIf<Tree.NodeEntity>(condition);
            }
            public NodesArray RemoveIf<T>(System.Predicate<T> condition)
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
                return new Tree.NodesArray(arrayBuilder.ToImmutable());
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
            /// An enumerator for the array values in a <see cref="NodesArray"/>.
            /// </summary>
            public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Tree.NodeEntity>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Tree.NodeEntity>, System.Collections.IEnumerator
            {
                private NodesArray instance;
                private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                internal MenesArrayEnumerator(NodesArray instance)
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
                public Tree.NodeEntity Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Tree.NodeEntity(this.jsonEnumerator.Current);
                        }
                        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking> array && this.index >= 0 && this.index < array.Length)
                        {
                            return array[this.index].As<Tree.NodeEntity>();
                        }
                        return default;
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the array values in a <see cref="NodesArray"/>.</returns>
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
                System.Collections.Generic.IEnumerator<Tree.NodeEntity> System.Collections.Generic.IEnumerable<Tree.NodeEntity>.GetEnumerator()
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
        public readonly struct NodeEntity : Menes.IJsonObject
        {
            public static readonly NodeEntity Null = default(NodeEntity);
            private static readonly System.ReadOnlyMemory<char> _MenesValueJsonPropertyName = System.MemoryExtensions.AsMemory("value");
            private static readonly System.ReadOnlyMemory<char> _MenesSubtreeJsonPropertyName = System.MemoryExtensions.AsMemory("subtree");
            private static readonly System.ReadOnlyMemory<byte> _MenesValueUtf8JsonPropertyName = new byte[] { 118, 97, 108, 117, 101 };
            private static readonly System.ReadOnlyMemory<byte> _MenesSubtreeUtf8JsonPropertyName = new byte[] { 115, 117, 98, 116, 114, 101, 101 };
            private static readonly System.Text.Json.JsonEncodedText _MenesValueEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesValueUtf8JsonPropertyName.Span);
            private static readonly System.Text.Json.JsonEncodedText _MenesSubtreeEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesSubtreeUtf8JsonPropertyName.Span);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
            private readonly Menes.JsonNumber? value;
            private readonly Menes.JsonValueBacking subtree;
            public NodeEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
                this.value = default;
                this.subtree = default;
            }
            public NodeEntity(Menes.JsonNumber value, Tree? subtree = null)
            {
                this._menesJsonElementBacking = default;
                this.value = value;
                this.subtree = Menes.JsonValueBacking.From<Tree>(subtree);
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            }
            private NodeEntity(Menes.JsonNumber? value, Menes.JsonValueBacking subtree, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
            {
                this._menesJsonElementBacking = default;
                this.value = value;
                this.subtree = subtree;
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
            public Menes.JsonNumber Value => this.HasJsonElement ? this.GetPropertyFromJsonElement<Menes.JsonNumber>(_MenesValueUtf8JsonPropertyName.Span) : this.value ?? Menes.JsonNumber.Null;
            public Tree? Subtree => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Tree>(_MenesSubtreeUtf8JsonPropertyName.Span) : this.subtree.As<Tree>();
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
                if (this.value is Menes.JsonNumber value)
                {
                    writer.WritePropertyName(_MenesValueEncodedJsonPropertyName);
                    value.WriteTo(writer);
                }
                if (this.subtree is Menes.JsonValueBacking subtree && !subtree.IsNull)
                {
                    writer.WritePropertyName(_MenesSubtreeEncodedJsonPropertyName);
                    subtree.WriteTo(writer);
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
                if (typeof(T) == typeof(NodeEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(Tree.NodeEntity))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesValueJsonPropertyName.Span))
                {
                    property = this.Value.As<T>();
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSubtreeJsonPropertyName.Span))
                {
                    if (!(this.Subtree?.As<T>() is T result))
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
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesValueJsonPropertyName.Span))
                {
                    property = this.Value.As<T>();
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesSubtreeJsonPropertyName.Span))
                {
                    if (!(this.Subtree?.As<T>() is T result))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesValueUtf8JsonPropertyName.Span))
                {
                    property = this.Value.As<T>();
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSubtreeUtf8JsonPropertyName.Span))
                {
                    if (!(this.Subtree?.As<T>() is T result))
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
            public Tree.NodeEntity.MenesPropertyEnumerator GetEnumerator() { return new Tree.NodeEntity.MenesPropertyEnumerator(this); }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
            public NodeEntity WithValue(Menes.JsonNumber value)
            {
                return new NodeEntity(value, this.subtree, this._menesAdditionalPropertiesBacking);
            }
            public NodeEntity WithSubtree(Tree value)
            {
                return new NodeEntity(this.value, Menes.JsonValueBacking.From<Tree>(value), this._menesAdditionalPropertiesBacking);
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
                if (this.value is not null)
                {
                    return false;
                }
                if (!this.subtree.IsNull)
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
            private bool TryGetPropertyAtIndex(int index, out Menes.Property<NodeEntity> result)
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        if (jsonPropertyIndex == index)
                        {
                            result = new Menes.Property<NodeEntity>(property);
                            return true;
                        }
                        jsonPropertyIndex++;
                    }
                }
                int currentIndex = 0;
                if (currentIndex == index)
                {
                    result = new Menes.Property<NodeEntity>(this, _MenesValueJsonPropertyName);
                    return true;
                }
                currentIndex++;
                if (currentIndex == index)
                {
                    result = new Menes.Property<NodeEntity>(this, _MenesSubtreeJsonPropertyName);
                    return true;
                }
                currentIndex++;
                result = default; ;
                return false;
            }
            /// <summary>
            /// An enumerator for the properties in a <see cref="NodeEntity"/>.
            /// </summary>
            public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<NodeEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<NodeEntity>>, System.Collections.IEnumerator
            {
                private NodeEntity instance;
                private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                private int propertyCount;
                internal MenesPropertyEnumerator(NodeEntity instance)
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
                public Menes.Property<NodeEntity> Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.Property<NodeEntity>(this.jsonEnumerator.Current);
                        }
                        else if (this.index >= 0)
                        {
                            if (this.instance.TryGetPropertyAtIndex(this.index, out var result))
                            {
                                return result;
                            }
                            throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                        }
                        return new Menes.Property<NodeEntity>(this.instance, default);
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the properties in a <see cref="NodeEntity"/>.</returns>
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
                System.Collections.Generic.IEnumerator<Menes.Property<NodeEntity>> System.Collections.Generic.IEnumerable<Menes.Property<NodeEntity>>.GetEnumerator()
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
        /// <summary>
        /// An enumerator for the properties in a <see cref="Tree"/>.
        /// </summary>
        public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<Tree>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<Tree>>, System.Collections.IEnumerator
        {
            private Tree instance;
            private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
            private bool hasJsonEnumerator;
            private int index;
            private int propertyCount;
            internal MenesPropertyEnumerator(Tree instance)
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
            public Menes.Property<Tree> Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new Menes.Property<Tree>(this.jsonEnumerator.Current);
                    }
                    else if (this.index >= 0)
                    {
                        if (this.instance.TryGetPropertyAtIndex(this.index, out var result))
                        {
                            return result;
                        }
                        throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                    }
                    return new Menes.Property<Tree>(this.instance, default);
                }
            }
            /// <inheritdoc/>
            object System.Collections.IEnumerator.Current => this.Current;
            /// <summary>
            /// Returns a fresh copy of the enumerator
            /// </summary>
            /// <returns>An enumerator for the properties in a <see cref="Tree"/>.</returns>
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
            System.Collections.Generic.IEnumerator<Menes.Property<Tree>> System.Collections.Generic.IEnumerable<Menes.Property<Tree>>.GetEnumerator()
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
