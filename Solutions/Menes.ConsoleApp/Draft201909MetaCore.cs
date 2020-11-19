// <copyright file="Draft201909MetaCore.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace TestSpace
{
    public readonly struct Draft201909MetaCore : Menes.IJsonValue
    {
        public static readonly Draft201909MetaCore Null = default(Draft201909MetaCore);
        private static readonly System.ReadOnlyMemory<char> _MenesIdJsonPropertyName = System.MemoryExtensions.AsMemory("id");
        private static readonly System.ReadOnlyMemory<char> _MenesSchemaJsonPropertyName = System.MemoryExtensions.AsMemory("schema");
        private static readonly System.ReadOnlyMemory<char> _MenesAnchorJsonPropertyName = System.MemoryExtensions.AsMemory("anchor");
        private static readonly System.ReadOnlyMemory<char> _MenesRefJsonPropertyName = System.MemoryExtensions.AsMemory("@ref");
        private static readonly System.ReadOnlyMemory<char> _MenesRecursiveRefJsonPropertyName = System.MemoryExtensions.AsMemory("recursiveRef");
        private static readonly System.ReadOnlyMemory<char> _MenesRecursiveAnchorJsonPropertyName = System.MemoryExtensions.AsMemory("recursiveAnchor");
        private static readonly System.ReadOnlyMemory<char> _MenesVocabularyJsonPropertyName = System.MemoryExtensions.AsMemory("vocabulary");
        private static readonly System.ReadOnlyMemory<char> _MenesCommentJsonPropertyName = System.MemoryExtensions.AsMemory("comment");
        private static readonly System.ReadOnlyMemory<char> _MenesDefsJsonPropertyName = System.MemoryExtensions.AsMemory("defs");
        private static readonly System.ReadOnlyMemory<byte> _MenesIdUtf8JsonPropertyName = new byte[] { 36, 105, 100 };
        private static readonly System.ReadOnlyMemory<byte> _MenesSchemaUtf8JsonPropertyName = new byte[] { 36, 115, 99, 104, 101, 109, 97 };
        private static readonly System.ReadOnlyMemory<byte> _MenesAnchorUtf8JsonPropertyName = new byte[] { 36, 97, 110, 99, 104, 111, 114 };
        private static readonly System.ReadOnlyMemory<byte> _MenesRefUtf8JsonPropertyName = new byte[] { 36, 114, 101, 102 };
        private static readonly System.ReadOnlyMemory<byte> _MenesRecursiveRefUtf8JsonPropertyName = new byte[] { 36, 114, 101, 99, 117, 114, 115, 105, 118, 101, 82, 101, 102 };
        private static readonly System.ReadOnlyMemory<byte> _MenesRecursiveAnchorUtf8JsonPropertyName = new byte[] { 36, 114, 101, 99, 117, 114, 115, 105, 118, 101, 65, 110, 99, 104, 111, 114 };
        private static readonly System.ReadOnlyMemory<byte> _MenesVocabularyUtf8JsonPropertyName = new byte[] { 36, 118, 111, 99, 97, 98, 117, 108, 97, 114, 121 };
        private static readonly System.ReadOnlyMemory<byte> _MenesCommentUtf8JsonPropertyName = new byte[] { 36, 99, 111, 109, 109, 101, 110, 116 };
        private static readonly System.ReadOnlyMemory<byte> _MenesDefsUtf8JsonPropertyName = new byte[] { 36, 100, 101, 102, 115 };
        private static readonly System.Text.Json.JsonEncodedText _MenesIdEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesIdUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesSchemaEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesSchemaUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesAnchorEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesAnchorUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesRefEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesRefUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesRecursiveRefEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesRecursiveRefUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesRecursiveAnchorEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesRecursiveAnchorUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesVocabularyEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesVocabularyUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesCommentEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesCommentUtf8JsonPropertyName.Span);
        private static readonly System.Text.Json.JsonEncodedText _MenesDefsEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesDefsUtf8JsonPropertyName.Span);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
        private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
        private readonly Draft201909MetaCore.IdValue? id;
        private readonly Menes.JsonUri? schema;
        private readonly Draft201909MetaCore.AnchorValue? anchor;
        private readonly Menes.JsonString? @ref;
        private readonly Menes.JsonString? recursiveRef;
        private readonly Menes.JsonBoolean? recursiveAnchor;
        private readonly Draft201909MetaCore.VocabularyEntity? vocabulary;
        private readonly Menes.JsonString? comment;
        private readonly Draft201909MetaCore.DefsEntity? defs;
        public Draft201909MetaCore(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
            this.id = default;
            this.schema = default;
            this.anchor = default;
            this.@ref = default;
            this.recursiveRef = default;
            this.recursiveAnchor = default;
            this.vocabulary = default;
            this.comment = default;
            this.defs = default;
        }
        public Draft201909MetaCore(Draft201909MetaCore.IdValue? id = null, Menes.JsonUri? schema = null, Draft201909MetaCore.AnchorValue? anchor = null, Menes.JsonString? @ref = null, Menes.JsonString? recursiveRef = null, Menes.JsonBoolean? recursiveAnchor = null, Draft201909MetaCore.VocabularyEntity? vocabulary = null, Menes.JsonString? comment = null, Draft201909MetaCore.DefsEntity? defs = null)
        {
            this._menesJsonElementBacking = default;
            this.id = id;
            this.schema = schema;
            this.anchor = anchor;
            this.@ref = @ref;
            this.recursiveRef = recursiveRef;
            this.recursiveAnchor = recursiveAnchor;
            this.vocabulary = vocabulary;
            this.comment = comment;
            this.defs = defs;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
        }
        public Draft201909MetaCore(Menes.JsonBoolean value)
        {
            this._menesJsonElementBacking = default;
            this._menesBooleanTypeBacking = value;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
            this.id = default;
            this.schema = default;
            this.anchor = default;
            this.@ref = default;
            this.recursiveRef = default;
            this.recursiveAnchor = default;
            this.vocabulary = default;
            this.comment = default;
            this.defs = default;
        }
        private Draft201909MetaCore(Draft201909MetaCore.IdValue? id, Menes.JsonUri? schema, Draft201909MetaCore.AnchorValue? anchor, Menes.JsonString? @ref, Menes.JsonString? recursiveRef, Menes.JsonBoolean? recursiveAnchor, Draft201909MetaCore.VocabularyEntity? vocabulary, Menes.JsonString? comment, Draft201909MetaCore.DefsEntity? defs, Menes.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
        {
            this._menesJsonElementBacking = default;
            this.id = id;
            this.schema = schema;
            this.anchor = anchor;
            this.@ref = @ref;
            this.recursiveRef = recursiveRef;
            this.recursiveAnchor = recursiveAnchor;
            this.vocabulary = vocabulary;
            this.comment = comment;
            this.defs = defs;
            this._menesBooleanTypeBacking = _menesBooleanTypeBacking;
            this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
        }
        public static implicit operator Menes.JsonBoolean(Draft201909MetaCore value)
        {
            return value.As<Menes.JsonBoolean>();
        }
        public static implicit operator Draft201909MetaCore(Menes.JsonBoolean value)
        {
            return value.As<Draft201909MetaCore>();
        }
        public static implicit operator bool(Draft201909MetaCore value)
        {
            return (bool)(Menes.JsonBoolean)value;
        }
        public static implicit operator Draft201909MetaCore(bool value)
        {
            return (Draft201909MetaCore)(Menes.JsonBoolean)value;
        }
        /// <inheritdoc />
        public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
        /// <inheritdoc />
        public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
        /// <inheritdoc />
        public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        /// <inheritdoc />
        public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
        public Draft201909MetaCore.IdValue? Id => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.IdValue>(_MenesIdUtf8JsonPropertyName.Span) : this.id;
        public Menes.JsonUri? Schema => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonUri>(_MenesSchemaUtf8JsonPropertyName.Span) : this.schema;
        public Draft201909MetaCore.AnchorValue? Anchor => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.AnchorValue>(_MenesAnchorUtf8JsonPropertyName.Span) : this.anchor;
        public Menes.JsonString? Ref => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesRefUtf8JsonPropertyName.Span) : this.@ref;
        public Menes.JsonString? RecursiveRef => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesRecursiveRefUtf8JsonPropertyName.Span) : this.recursiveRef;
        public Menes.JsonBoolean? RecursiveAnchor => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonBoolean>(_MenesRecursiveAnchorUtf8JsonPropertyName.Span) : this.recursiveAnchor;
        public Draft201909MetaCore.VocabularyEntity? Vocabulary => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.VocabularyEntity>(_MenesVocabularyUtf8JsonPropertyName.Span) : this.vocabulary;
        public Menes.JsonString? Comment => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonString>(_MenesCommentUtf8JsonPropertyName.Span) : this.comment;
        public Draft201909MetaCore.DefsEntity? Defs => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.DefsEntity>(_MenesDefsUtf8JsonPropertyName.Span) : this.defs;
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
            if (this.id is Draft201909MetaCore.IdValue id)
            {
                writer.WritePropertyName(_MenesIdEncodedJsonPropertyName);
                id.WriteTo(writer);
            }
            if (this.schema is Menes.JsonUri schema)
            {
                writer.WritePropertyName(_MenesSchemaEncodedJsonPropertyName);
                schema.WriteTo(writer);
            }
            if (this.anchor is Draft201909MetaCore.AnchorValue anchor)
            {
                writer.WritePropertyName(_MenesAnchorEncodedJsonPropertyName);
                anchor.WriteTo(writer);
            }
            if (this.@ref is Menes.JsonString @ref)
            {
                writer.WritePropertyName(_MenesRefEncodedJsonPropertyName);
                @ref.WriteTo(writer);
            }
            if (this.recursiveRef is Menes.JsonString recursiveRef)
            {
                writer.WritePropertyName(_MenesRecursiveRefEncodedJsonPropertyName);
                recursiveRef.WriteTo(writer);
            }
            if (this.recursiveAnchor is Menes.JsonBoolean recursiveAnchor)
            {
                writer.WritePropertyName(_MenesRecursiveAnchorEncodedJsonPropertyName);
                recursiveAnchor.WriteTo(writer);
            }
            if (this.vocabulary is Draft201909MetaCore.VocabularyEntity vocabulary)
            {
                writer.WritePropertyName(_MenesVocabularyEncodedJsonPropertyName);
                vocabulary.WriteTo(writer);
            }
            if (this.comment is Menes.JsonString comment)
            {
                writer.WritePropertyName(_MenesCommentEncodedJsonPropertyName);
                comment.WriteTo(writer);
            }
            if (this.defs is Draft201909MetaCore.DefsEntity defs)
            {
                writer.WritePropertyName(_MenesDefsEncodedJsonPropertyName);
                defs.WriteTo(writer);
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
            if (typeof(T) == typeof(Draft201909MetaCore))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdJsonPropertyName.Span))
            {
                if (!(this.Id?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaJsonPropertyName.Span))
            {
                if (!(this.Schema?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorJsonPropertyName.Span))
            {
                if (!(this.Anchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefJsonPropertyName.Span))
            {
                if (!(this.Ref?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefJsonPropertyName.Span))
            {
                if (!(this.RecursiveRef?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorJsonPropertyName.Span))
            {
                if (!(this.RecursiveAnchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyJsonPropertyName.Span))
            {
                if (!(this.Vocabulary?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentJsonPropertyName.Span))
            {
                if (!(this.Comment?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsJsonPropertyName.Span))
            {
                if (!(this.Defs?.As<T>() is T result))
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
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesIdJsonPropertyName.Span))
            {
                if (!(this.Id?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesSchemaJsonPropertyName.Span))
            {
                if (!(this.Schema?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAnchorJsonPropertyName.Span))
            {
                if (!(this.Anchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRefJsonPropertyName.Span))
            {
                if (!(this.Ref?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRecursiveRefJsonPropertyName.Span))
            {
                if (!(this.RecursiveRef?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRecursiveAnchorJsonPropertyName.Span))
            {
                if (!(this.RecursiveAnchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesVocabularyJsonPropertyName.Span))
            {
                if (!(this.Vocabulary?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesCommentJsonPropertyName.Span))
            {
                if (!(this.Comment?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDefsJsonPropertyName.Span))
            {
                if (!(this.Defs?.As<T>() is T result))
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
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdUtf8JsonPropertyName.Span))
            {
                if (!(this.Id?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaUtf8JsonPropertyName.Span))
            {
                if (!(this.Schema?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorUtf8JsonPropertyName.Span))
            {
                if (!(this.Anchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefUtf8JsonPropertyName.Span))
            {
                if (!(this.Ref?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefUtf8JsonPropertyName.Span))
            {
                if (!(this.RecursiveRef?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorUtf8JsonPropertyName.Span))
            {
                if (!(this.RecursiveAnchor?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyUtf8JsonPropertyName.Span))
            {
                if (!(this.Vocabulary?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentUtf8JsonPropertyName.Span))
            {
                if (!(this.Comment?.As<T>() is T result))
                {
                    property = default;
                    return false;
                }
                property = result;
                return true;
                return true;
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsUtf8JsonPropertyName.Span))
            {
                if (!(this.Defs?.As<T>() is T result))
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
            if (this.id is not null)
            {
                return false;
            }
            if (this.schema is not null)
            {
                return false;
            }
            if (this.anchor is not null)
            {
                return false;
            }
            if (this.@ref is not null)
            {
                return false;
            }
            if (this.recursiveRef is not null)
            {
                return false;
            }
            if (this.recursiveAnchor is not null)
            {
                return false;
            }
            if (this.vocabulary is not null)
            {
                return false;
            }
            if (this.comment is not null)
            {
                return false;
            }
            if (this.defs is not null)
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
        public readonly struct IdValue : Menes.IJsonValue
        {
            public static readonly IdValue Null = default(IdValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonString? _menesStringTypeBacking;
            public IdValue(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesStringTypeBacking = default;
            }
            public IdValue(Menes.JsonString value)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = value;
            }
            private IdValue(Menes.JsonString? _menesStringTypeBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = _menesStringTypeBacking;
            }
            public static implicit operator Menes.JsonString(IdValue value)
            {
                return value.As<Menes.JsonString>();
            }
            public static implicit operator IdValue(Menes.JsonString value)
            {
                return value.As<Draft201909MetaCore.IdValue>();
            }
            public static implicit operator string(IdValue value)
            {
                return (string)(Menes.JsonString)value;
            }
            public static implicit operator IdValue(string value)
            {
                return (Draft201909MetaCore.IdValue)(Menes.JsonString)value;
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
                if (typeof(T) == typeof(Draft201909MetaCore.IdValue))
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
        public readonly struct AnchorValue : Menes.IJsonValue
        {
            public static readonly AnchorValue Null = default(AnchorValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonString? _menesStringTypeBacking;
            public AnchorValue(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesStringTypeBacking = default;
            }
            public AnchorValue(Menes.JsonString value)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = value;
            }
            private AnchorValue(Menes.JsonString? _menesStringTypeBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = _menesStringTypeBacking;
            }
            public static implicit operator Menes.JsonString(AnchorValue value)
            {
                return value.As<Menes.JsonString>();
            }
            public static implicit operator AnchorValue(Menes.JsonString value)
            {
                return value.As<Draft201909MetaCore.AnchorValue>();
            }
            public static implicit operator string(AnchorValue value)
            {
                return (string)(Menes.JsonString)value;
            }
            public static implicit operator AnchorValue(string value)
            {
                return (Draft201909MetaCore.AnchorValue)(Menes.JsonString)value;
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
                if (typeof(T) == typeof(Draft201909MetaCore.AnchorValue))
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
        public readonly struct VocabularyEntity : Menes.IJsonValue
        {
            public static readonly VocabularyEntity Null = default(VocabularyEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonBoolean>> _menesAdditionalPropertiesBacking;
            public VocabularyEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonBoolean>>.Empty;
            }
            private VocabularyEntity(in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonBoolean>> _menesAdditionalPropertiesBacking)
            {
                this._menesJsonElementBacking = default;
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
                if (typeof(T) == typeof(Draft201909MetaCore.VocabularyEntity))
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
        public readonly struct DefsEntity : Menes.IJsonValue
        {
            public static readonly DefsEntity Null = default(DefsEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking;
            public DefsEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty>.Empty;
            }
            private DefsEntity(in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking)
            {
                this._menesJsonElementBacking = default;
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
                if (typeof(T) == typeof(Draft201909MetaCore.DefsEntity))
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
                        property = additionalProperty.Value<Draft201909MetaCore>()?.As<T>() ?? default;
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
                        property = additionalProperty.Value<Draft201909MetaCore>()?.As<T>() ?? default;
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
                        property = additionalProperty.Value<Draft201909MetaCore>()?.As<T>() ?? default;
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
    }
}
