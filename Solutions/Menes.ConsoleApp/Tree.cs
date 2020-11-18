// <copyright file="Tree.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable

using System;

namespace TestSpace
{
    public readonly struct Tree : Menes.IJsonValue
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
        private readonly Tree.MetaValue? meta;
        private readonly Menes.JsonValueBacking nodes;
        /// <inheritdoc />
        public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
        /// <inheritdoc />
        public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
        /// <inheritdoc />
        public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        /// <inheritdoc />
        public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
        public Tree.MetaValue Meta => this.HasJsonElement ? this.GetPropertyFromJsonElement<Tree.MetaValue>(_MenesMetaUtf8JsonPropertyName.Span) : this.meta ?? Tree.MetaValue.Null;
        public Tree.NodesArray Nodes => this.HasJsonElement ? this.GetPropertyFromJsonElement<Tree.NodesArray>(_MenesNodesUtf8JsonPropertyName.Span) : this.nodes.Value<Tree.NodesArray>() ?? Tree.NodesArray.Null;
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
            if (this.meta is Tree.MetaValue meta)
            {
                writer.WritePropertyName("_MenesMetaEncodedJsonPropertyName");
                meta.WriteTo(writer);
            }
            if (this.nodes is Menes.JsonValueBacking nodes)
            {
                writer.WritePropertyName("_MenesNodesEncodedJsonPropertyName");
                nodes.WriteTo(writer);
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
            T item = this.As<T>();
            return item.Validate().Valid;
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
            if (propertyName.SequenceEqual(_MenesMetaJsonPropertyName.Span))
            {
                property = this.Meta.As<T>();
                return true;
            }
            if (propertyName.SequenceEqual(_MenesNodesJsonPropertyName.Span))
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
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesMetaJsonPropertyName.Span))
            {
                property = this.Meta.As<T>();
                return true;
            }
            if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesNodesJsonPropertyName.Span))
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
            if (propertyName.SequenceEqual(_MenesMetaUtf8JsonPropertyName.Span))
            {
                property = this.Meta.As<T>();
                return true;
            }
            if (propertyName.SequenceEqual(_MenesNodesUtf8JsonPropertyName.Span))
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
        public readonly struct MetaValue : Menes.IJsonValue
        {
            public static readonly MetaValue Null = default(MetaValue);
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
                if (this._menesStringTypeBacking is Menes.JsonString _menesStringTypeBacking)
                {
                    _menesStringTypeBacking.WriteTo(writer);
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
                T item = this.As<T>();
                return item.Validate().Valid;
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
        public readonly struct NodesArray : Menes.IJsonValue
        {
            public static readonly NodesArray Null = default(NodesArray);
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
                T item = this.As<T>();
                return item.Validate().Valid;
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
                T item = this.As<T>();
                return item.Validate().Valid;
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
        public readonly struct NodeEntity : Menes.IJsonValue
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
            private readonly Tree.NodeEntity.ValueEntity? value;
            private readonly Tree.NodeEntity.SubtreeEntity? subtree;
            /// <inheritdoc />
            public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
            /// <inheritdoc />
            public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            /// <inheritdoc />
            public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
            public Tree.NodeEntity.ValueEntity Value => this.HasJsonElement ? this.GetPropertyFromJsonElement<Tree.NodeEntity.ValueEntity>(_MenesValueUtf8JsonPropertyName.Span) : this.value ?? Tree.NodeEntity.ValueEntity.Null;
            public Tree.NodeEntity.SubtreeEntity? Subtree => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Tree.NodeEntity.SubtreeEntity>(_MenesSubtreeUtf8JsonPropertyName.Span) : this.subtree;
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
                if (this.value is Tree.NodeEntity.ValueEntity value)
                {
                    writer.WritePropertyName("_MenesValueEncodedJsonPropertyName");
                    value.WriteTo(writer);
                }
                if (this.subtree is Tree.NodeEntity.SubtreeEntity subtree)
                {
                    writer.WritePropertyName("_MenesSubtreeEncodedJsonPropertyName");
                    subtree.WriteTo(writer);
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
                T item = this.As<T>();
                return item.Validate().Valid;
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
                if (propertyName.SequenceEqual(_MenesValueJsonPropertyName.Span))
                {
                    property = this.Value.As<T>();
                    return true;
                }
                if (propertyName.SequenceEqual(_MenesSubtreeJsonPropertyName.Span))
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
                if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesValueJsonPropertyName.Span))
                {
                    property = this.Value.As<T>();
                    return true;
                }
                if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_MenesSubtreeJsonPropertyName.Span))
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
                if (propertyName.SequenceEqual(_MenesValueUtf8JsonPropertyName.Span))
                {
                    property = this.Value.As<T>();
                    return true;
                }
                if (propertyName.SequenceEqual(_MenesSubtreeUtf8JsonPropertyName.Span))
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
                if (this.subtree is not null)
                {
                    return false;
                }
                if (this._menesAdditionalPropertiesBacking.Length > 0)
                {
                    return false;
                }
                return true;
            }
            public readonly struct ValueEntity : Menes.IJsonValue
            {
                public static readonly ValueEntity Null = default(ValueEntity);
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
                    _menesNumberTypeBacking?.WriteTo(writer);
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
                    T item = this.As<T>();
                    return item.Validate().Valid;
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
            public readonly struct SubtreeEntity : Menes.IJsonValue
            {
                public static readonly SubtreeEntity Null = default(SubtreeEntity);
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
                    T item = this.As<T>();
                    return item.Validate().Valid;
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
