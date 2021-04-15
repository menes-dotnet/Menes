// <copyright file="Draft201909MetaCore.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.JsonSchema
{
    public readonly struct Draft201909MetaCore : Menes.JsonSchema.IJsonObject<Draft201909MetaCore>
    {
        public static readonly Draft201909MetaCore Null = default(Draft201909MetaCore);
        private static readonly System.ReadOnlyMemory<char> _MenesIdJsonPropertyName = System.MemoryExtensions.AsMemory("$id");
        private static readonly System.ReadOnlyMemory<char> _MenesSchemaJsonPropertyName = System.MemoryExtensions.AsMemory("$schema");
        private static readonly System.ReadOnlyMemory<char> _MenesAnchorJsonPropertyName = System.MemoryExtensions.AsMemory("$anchor");
        private static readonly System.ReadOnlyMemory<char> _MenesRefJsonPropertyName = System.MemoryExtensions.AsMemory("$ref");
        private static readonly System.ReadOnlyMemory<char> _MenesRecursiveRefJsonPropertyName = System.MemoryExtensions.AsMemory("$recursiveRef");
        private static readonly System.ReadOnlyMemory<char> _MenesRecursiveAnchorJsonPropertyName = System.MemoryExtensions.AsMemory("$recursiveAnchor");
        private static readonly System.ReadOnlyMemory<char> _MenesVocabularyJsonPropertyName = System.MemoryExtensions.AsMemory("$vocabulary");
        private static readonly System.ReadOnlyMemory<char> _MenesCommentJsonPropertyName = System.MemoryExtensions.AsMemory("$comment");
        private static readonly System.ReadOnlyMemory<char> _MenesDefsJsonPropertyName = System.MemoryExtensions.AsMemory("$defs");
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
        private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>> _menesAdditionalPropertiesBacking;
        private readonly Menes.JsonSchema.JsonBoolean? _menesBooleanTypeBacking;
        private readonly Draft201909MetaCore.IdValue? id;
        private readonly Menes.JsonSchema.JsonUri? schema;
        private readonly Draft201909MetaCore.AnchorValue? anchor;
        private readonly Menes.JsonSchema.JsonUriReference? @ref;
        private readonly Menes.JsonSchema.JsonUriReference? recursiveRef;
        private readonly Menes.JsonSchema.JsonBoolean? recursiveAnchor;
        private readonly Draft201909MetaCore.VocabularyEntity? vocabulary;
        private readonly Menes.JsonSchema.JsonString? comment;
        private readonly Draft201909MetaCore.DefsEntity? defs;
        public Draft201909MetaCore(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>>.Empty;
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
        public Draft201909MetaCore(Draft201909MetaCore.IdValue? id = null, Menes.JsonSchema.JsonUri? schema = null, Draft201909MetaCore.AnchorValue? anchor = null, Menes.JsonSchema.JsonUriReference? @ref = null, Menes.JsonSchema.JsonUriReference? recursiveRef = null, Menes.JsonSchema.JsonBoolean? recursiveAnchor = null, Draft201909MetaCore.VocabularyEntity? vocabulary = null, Menes.JsonSchema.JsonString? comment = null, Draft201909MetaCore.DefsEntity? defs = null)
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
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>>.Empty;
            this._menesBooleanTypeBacking = default;
        }
        public Draft201909MetaCore(Menes.JsonSchema.JsonBoolean value)
        {
            this._menesJsonElementBacking = default;
            this._menesBooleanTypeBacking = value;
            this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>>.Empty;
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
        private Draft201909MetaCore(Draft201909MetaCore.IdValue? id, Menes.JsonSchema.JsonUri? schema, Draft201909MetaCore.AnchorValue? anchor, Menes.JsonSchema.JsonUriReference? @ref, Menes.JsonSchema.JsonUriReference? recursiveRef, Menes.JsonSchema.JsonBoolean? recursiveAnchor, Draft201909MetaCore.VocabularyEntity? vocabulary, Menes.JsonSchema.JsonString? comment, Draft201909MetaCore.DefsEntity? defs, Menes.JsonSchema.JsonBoolean? _menesBooleanTypeBacking, in System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>> _menesAdditionalPropertiesBacking)
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
        public static implicit operator Menes.JsonSchema.JsonBoolean(Draft201909MetaCore value)
        {
            return value.As<Menes.JsonSchema.JsonBoolean>();
        }
        public static implicit operator Draft201909MetaCore(Menes.JsonSchema.JsonBoolean value)
        {
            return value.As<Draft201909MetaCore>();
        }
        public static implicit operator bool(Draft201909MetaCore value)
        {
            return (bool)(Menes.JsonSchema.JsonBoolean)value;
        }
        public static implicit operator Draft201909MetaCore(bool value)
        {
            return (Draft201909MetaCore)(Menes.JsonSchema.JsonBoolean)value;
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
        public Draft201909MetaCore.IdValue? Id => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.IdValue>(_MenesIdUtf8JsonPropertyName.Span) : this.id;
        public Menes.JsonSchema.JsonUri? Schema => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonSchema.JsonUri>(_MenesSchemaUtf8JsonPropertyName.Span) : this.schema;
        public Draft201909MetaCore.AnchorValue? Anchor => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.AnchorValue>(_MenesAnchorUtf8JsonPropertyName.Span) : this.anchor;
        public Menes.JsonSchema.JsonUriReference? Ref => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonSchema.JsonUriReference>(_MenesRefUtf8JsonPropertyName.Span) : this.@ref;
        public Menes.JsonSchema.JsonUriReference? RecursiveRef => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonSchema.JsonUriReference>(_MenesRecursiveRefUtf8JsonPropertyName.Span) : this.recursiveRef;
        public Menes.JsonSchema.JsonBoolean? RecursiveAnchor => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonSchema.JsonBoolean>(_MenesRecursiveAnchorUtf8JsonPropertyName.Span) : this.recursiveAnchor;
        public Draft201909MetaCore.VocabularyEntity? Vocabulary => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.VocabularyEntity>(_MenesVocabularyUtf8JsonPropertyName.Span) : this.vocabulary;
        public Menes.JsonSchema.JsonString? Comment => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Menes.JsonSchema.JsonString>(_MenesCommentUtf8JsonPropertyName.Span) : this.comment;
        public Draft201909MetaCore.DefsEntity? Defs => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<Draft201909MetaCore.DefsEntity>(_MenesDefsUtf8JsonPropertyName.Span) : this.defs;
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
                    return 9 + this._menesAdditionalPropertiesBacking.Length;
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
                result = result.WithLocalProperty("$id");
                if (this.TryGetProperty<Draft201909MetaCore.IdValue>(_MenesIdJsonPropertyName.Span, out Draft201909MetaCore.IdValue value0))
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
                result = result.WithLocalProperty("$schema");
                if (this.TryGetProperty<Menes.JsonSchema.JsonUri>(_MenesSchemaJsonPropertyName.Span, out Menes.JsonSchema.JsonUri value1))
                {
                    result = value1.Validate(result, level);
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
                result = result.WithLocalProperty("$anchor");
                if (this.TryGetProperty<Draft201909MetaCore.AnchorValue>(_MenesAnchorJsonPropertyName.Span, out Draft201909MetaCore.AnchorValue value2))
                {
                    result = value2.Validate(result, level);
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
                result = result.WithLocalProperty("$ref");
                if (this.TryGetProperty<Menes.JsonSchema.JsonUriReference>(_MenesRefJsonPropertyName.Span, out Menes.JsonSchema.JsonUriReference value3))
                {
                    result = value3.Validate(result, level);
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
                result = result.WithLocalProperty("$recursiveRef");
                if (this.TryGetProperty<Menes.JsonSchema.JsonUriReference>(_MenesRecursiveRefJsonPropertyName.Span, out Menes.JsonSchema.JsonUriReference value4))
                {
                    result = value4.Validate(result, level);
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
                result = result.WithLocalProperty("$recursiveAnchor");
                if (this.TryGetProperty<Menes.JsonSchema.JsonBoolean>(_MenesRecursiveAnchorJsonPropertyName.Span, out Menes.JsonSchema.JsonBoolean value5))
                {
                    result = value5.Validate(result, level);
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
                result = result.WithLocalProperty("$vocabulary");
                if (this.TryGetProperty<Draft201909MetaCore.VocabularyEntity>(_MenesVocabularyJsonPropertyName.Span, out Draft201909MetaCore.VocabularyEntity value6))
                {
                    result = value6.Validate(result, level);
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
                result = result.WithLocalProperty("$comment");
                if (this.TryGetProperty<Menes.JsonSchema.JsonString>(_MenesCommentJsonPropertyName.Span, out Menes.JsonSchema.JsonString value7))
                {
                    result = value7.Validate(result, level);
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
                result = result.WithLocalProperty("$defs");
                if (this.TryGetProperty<Draft201909MetaCore.DefsEntity>(_MenesDefsJsonPropertyName.Span, out Draft201909MetaCore.DefsEntity value8))
                {
                    result = value8.Validate(result, level);
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
            if (this.id is Draft201909MetaCore.IdValue id)
            {
                writer.WritePropertyName(_MenesIdEncodedJsonPropertyName);
                id.WriteTo(writer);
            }
            if (this.schema is Menes.JsonSchema.JsonUri schema)
            {
                writer.WritePropertyName(_MenesSchemaEncodedJsonPropertyName);
                schema.WriteTo(writer);
            }
            if (this.anchor is Draft201909MetaCore.AnchorValue anchor)
            {
                writer.WritePropertyName(_MenesAnchorEncodedJsonPropertyName);
                anchor.WriteTo(writer);
            }
            if (this.@ref is Menes.JsonSchema.JsonUriReference @ref)
            {
                writer.WritePropertyName(_MenesRefEncodedJsonPropertyName);
                @ref.WriteTo(writer);
            }
            if (this.recursiveRef is Menes.JsonSchema.JsonUriReference recursiveRef)
            {
                writer.WritePropertyName(_MenesRecursiveRefEncodedJsonPropertyName);
                recursiveRef.WriteTo(writer);
            }
            if (this.recursiveAnchor is Menes.JsonSchema.JsonBoolean recursiveAnchor)
            {
                writer.WritePropertyName(_MenesRecursiveAnchorEncodedJsonPropertyName);
                recursiveAnchor.WriteTo(writer);
            }
            if (this.vocabulary is Draft201909MetaCore.VocabularyEntity vocabulary)
            {
                writer.WritePropertyName(_MenesVocabularyEncodedJsonPropertyName);
                vocabulary.WriteTo(writer);
            }
            if (this.comment is Menes.JsonSchema.JsonString comment)
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
            where T : struct, Menes.JsonSchema.IJsonValue
        {
            if (typeof(T) == typeof(Draft201909MetaCore))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }
            return Menes.JsonSchema.JsonValue.As<Draft201909MetaCore, T>(this);
        }
        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, Menes.JsonSchema.IJsonValue
        {
            if (typeof(T) == typeof(Draft201909MetaCore))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsJsonPropertyName.Span))
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
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesIdJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesSchemaJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesAnchorJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRefJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRecursiveRefJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesRecursiveAnchorJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesVocabularyJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesCommentJsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesDefsJsonPropertyName.Span))
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
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentUtf8JsonPropertyName.Span))
                {
                    return true;
                }
                if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsUtf8JsonPropertyName.Span))
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
        /// <inheritdoc />
        public bool TryGetPropertyAtIndex(int index, out Menes.JsonSchema.IProperty result)
        {
            var rc = this.TryGetPropertyAtIndex(index, out Menes.JsonSchema.Property<Draft201909MetaCore> prop);
            result = prop;
            return rc;
        }
        public Draft201909MetaCore RemoveProperty(string propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
        }
        public Draft201909MetaCore RemoveProperty(System.ReadOnlySpan<char> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
        }
        public Draft201909MetaCore RemoveProperty(System.ReadOnlySpan<byte> propertyName)
        {
            return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
        }
        public Draft201909MetaCore SetProperty<T>(string name, T value)
        where T : struct, Menes.JsonSchema.IJsonValue
        {
            var propertyName = System.MemoryExtensions.AsSpan(name);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdJsonPropertyName.Span))
            {
                return this.WithId(value.As<Draft201909MetaCore.IdValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaJsonPropertyName.Span))
            {
                return this.WithSchema(value.As<Menes.JsonSchema.JsonUri>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorJsonPropertyName.Span))
            {
                return this.WithAnchor(value.As<Draft201909MetaCore.AnchorValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefJsonPropertyName.Span))
            {
                return this.WithRef(value.As<Menes.JsonSchema.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefJsonPropertyName.Span))
            {
                return this.WithRecursiveRef(value.As<Menes.JsonSchema.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorJsonPropertyName.Span))
            {
                return this.WithRecursiveAnchor(value.As<Menes.JsonSchema.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyJsonPropertyName.Span))
            {
                return this.WithVocabulary(value.As<Draft201909MetaCore.VocabularyEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentJsonPropertyName.Span))
            {
                return this.WithComment(value.As<Menes.JsonSchema.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsJsonPropertyName.Span))
            {
                return this.WithDefs(value.As<Draft201909MetaCore.DefsEntity>());
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
        public Draft201909MetaCore SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
        where T : struct, Menes.JsonSchema.IJsonValue
        {
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdJsonPropertyName.Span))
            {
                return this.WithId(value.As<Draft201909MetaCore.IdValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaJsonPropertyName.Span))
            {
                return this.WithSchema(value.As<Menes.JsonSchema.JsonUri>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorJsonPropertyName.Span))
            {
                return this.WithAnchor(value.As<Draft201909MetaCore.AnchorValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefJsonPropertyName.Span))
            {
                return this.WithRef(value.As<Menes.JsonSchema.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefJsonPropertyName.Span))
            {
                return this.WithRecursiveRef(value.As<Menes.JsonSchema.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorJsonPropertyName.Span))
            {
                return this.WithRecursiveAnchor(value.As<Menes.JsonSchema.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyJsonPropertyName.Span))
            {
                return this.WithVocabulary(value.As<Draft201909MetaCore.VocabularyEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentJsonPropertyName.Span))
            {
                return this.WithComment(value.As<Menes.JsonSchema.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsJsonPropertyName.Span))
            {
                return this.WithDefs(value.As<Draft201909MetaCore.DefsEntity>());
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
        public Draft201909MetaCore SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
        where T : struct, Menes.JsonSchema.IJsonValue
        {
            System.Span<char> name = stackalloc char[utf8Name.Length];
            int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
            var propertyName = name.Slice(0, writtenCount);
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesIdJsonPropertyName.Span))
            {
                return this.WithId(value.As<Draft201909MetaCore.IdValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesSchemaJsonPropertyName.Span))
            {
                return this.WithSchema(value.As<Menes.JsonSchema.JsonUri>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesAnchorJsonPropertyName.Span))
            {
                return this.WithAnchor(value.As<Draft201909MetaCore.AnchorValue>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRefJsonPropertyName.Span))
            {
                return this.WithRef(value.As<Menes.JsonSchema.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveRefJsonPropertyName.Span))
            {
                return this.WithRecursiveRef(value.As<Menes.JsonSchema.JsonUriReference>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesRecursiveAnchorJsonPropertyName.Span))
            {
                return this.WithRecursiveAnchor(value.As<Menes.JsonSchema.JsonBoolean>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesVocabularyJsonPropertyName.Span))
            {
                return this.WithVocabulary(value.As<Draft201909MetaCore.VocabularyEntity>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesCommentJsonPropertyName.Span))
            {
                return this.WithComment(value.As<Menes.JsonSchema.JsonString>());
            }
            if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesDefsJsonPropertyName.Span))
            {
                return this.WithDefs(value.As<Draft201909MetaCore.DefsEntity>());
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
        public Draft201909MetaCore.MenesPropertyEnumerator GetEnumerator()
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
        System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<Draft201909MetaCore>> System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<Draft201909MetaCore>>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public Draft201909MetaCore WithId(Draft201909MetaCore.IdValue value)
        {
            return new Draft201909MetaCore(value, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaCore WithSchema(Menes.JsonSchema.JsonUri value)
        {
            return new Draft201909MetaCore(this.id, value, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaCore WithAnchor(Draft201909MetaCore.AnchorValue value)
        {
            return new Draft201909MetaCore(this.id, this.schema, value, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaCore WithRef(Menes.JsonSchema.JsonUriReference value)
        {
            return new Draft201909MetaCore(this.id, this.schema, this.anchor, value, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaCore WithRecursiveRef(Menes.JsonSchema.JsonUriReference value)
        {
            return new Draft201909MetaCore(this.id, this.schema, this.anchor, this.@ref, value, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaCore WithRecursiveAnchor(Menes.JsonSchema.JsonBoolean value)
        {
            return new Draft201909MetaCore(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, value, this.vocabulary, this.comment, this.defs, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaCore WithVocabulary(Draft201909MetaCore.VocabularyEntity value)
        {
            return new Draft201909MetaCore(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, value, this.comment, this.defs, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaCore WithComment(Menes.JsonSchema.JsonString value)
        {
            return new Draft201909MetaCore(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, value, this.defs, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
        }
        public Draft201909MetaCore WithDefs(Draft201909MetaCore.DefsEntity value)
        {
            return new Draft201909MetaCore(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, value, this._menesBooleanTypeBacking, this._menesAdditionalPropertiesBacking);
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
        /// <inheritdoc />
        private bool TryGetPropertyAtIndex(int index, out Menes.JsonSchema.Property<Draft201909MetaCore> result)
        {
            if (this.HasJsonElement)
            {
                int jsonPropertyIndex = 0;
                foreach (var property in this.JsonElement.EnumerateObject())
                {
                    if (jsonPropertyIndex == index)
                    {
                        result = new Menes.JsonSchema.Property<Draft201909MetaCore>(property);
                        return true;
                    }
                    jsonPropertyIndex++;
                }
            }
            int currentIndex = 0;
            if (currentIndex == index)
            {
                result = new Menes.JsonSchema.Property<Draft201909MetaCore>(this, _MenesIdJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.JsonSchema.Property<Draft201909MetaCore>(this, _MenesSchemaJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.JsonSchema.Property<Draft201909MetaCore>(this, _MenesAnchorJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.JsonSchema.Property<Draft201909MetaCore>(this, _MenesRefJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.JsonSchema.Property<Draft201909MetaCore>(this, _MenesRecursiveRefJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.JsonSchema.Property<Draft201909MetaCore>(this, _MenesRecursiveAnchorJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.JsonSchema.Property<Draft201909MetaCore>(this, _MenesVocabularyJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.JsonSchema.Property<Draft201909MetaCore>(this, _MenesCommentJsonPropertyName);
                return true;
            }
            currentIndex++;
            if (currentIndex == index)
            {
                result = new Menes.JsonSchema.Property<Draft201909MetaCore>(this, _MenesDefsJsonPropertyName);
                return true;
            }
            currentIndex++;
            foreach (var property in this._menesAdditionalPropertiesBacking)
            {
                if (currentIndex == index)
                {
                    result = new Menes.JsonSchema.Property<Draft201909MetaCore>(this, property.NameAsMemory);
                    return true;
                }
                currentIndex++;
            }
            result = default; ;
            return false;
        }
        private Draft201909MetaCore WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonAny>> value)
        {
            return new Draft201909MetaCore(this.id, this.schema, this.anchor, this.@ref, this.recursiveRef, this.recursiveAnchor, this.vocabulary, this.comment, this.defs, this._menesBooleanTypeBacking, value);
        }
        public readonly struct IdValue : Menes.JsonSchema.IJsonValue
        {
            public static readonly IdValue Null = default(IdValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonSchema.JsonUriReference? _menesStringTypeBacking;
            private static readonly System.Text.RegularExpressions.Regex _MenesPatternExpression = new System.Text.RegularExpressions.Regex("^[^#]*#?$", System.Text.RegularExpressions.RegexOptions.Compiled);
            public IdValue(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesStringTypeBacking = default;
            }
            public IdValue(Menes.JsonSchema.JsonUriReference value)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = value;
            }
            private IdValue(Menes.JsonSchema.JsonUriReference? _menesStringTypeBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = _menesStringTypeBacking;
            }
            public static implicit operator Menes.JsonSchema.JsonUriReference(IdValue value)
            {
                return value.As<Menes.JsonSchema.JsonUriReference>();
            }
            public static implicit operator IdValue(Menes.JsonSchema.JsonUriReference value)
            {
                return value.As<Draft201909MetaCore.IdValue>();
            }
            public static implicit operator Menes.JsonSchema.JsonString(IdValue value)
            {
                return value.As<Menes.JsonSchema.JsonString>();
            }
            public static implicit operator IdValue(Menes.JsonSchema.JsonString value)
            {
                return value.As<Draft201909MetaCore.IdValue>();
            }
            public static implicit operator string(IdValue value)
            {
                return (string)(Menes.JsonSchema.JsonString)value;
            }
            public static implicit operator IdValue(string value)
            {
                return (Draft201909MetaCore.IdValue)(Menes.JsonSchema.JsonString)value;
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
            public Menes.JsonSchema.ValidationContext Validate(in Menes.JsonSchema.ValidationContext validationContext, Menes.JsonSchema.ValidationLevel level = Menes.JsonSchema.ValidationLevel.Flag)
            {
                Menes.JsonSchema.ValidationContext result = validationContext;
                if (level != Menes.JsonSchema.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (!this.IsString)
                {
                    if (level >= Menes.JsonSchema.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of string");
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
                if (this.IsString)
                {
                    result = this.As<Menes.JsonSchema.JsonUriReference>().Validate(result);
                    if (level == Menes.JsonSchema.ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }
                }
                if (this.IsString)
                {
                    var value = (string)this.As<Menes.JsonSchema.JsonString>();
                    if (!_MenesPatternExpression.IsMatch(value))
                    {
                        if (level >= Menes.JsonSchema.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.3.3.  pattern - value must match the regular expression ^[^#]*#?$");
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
                where T : struct, Menes.JsonSchema.IJsonValue
            {
                if (typeof(T) == typeof(IdValue))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonSchema.JsonValue.As<IdValue, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.JsonSchema.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaCore.IdValue))
                {
                    return this.Validate(Menes.JsonSchema.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.JsonSchema.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, Menes.JsonSchema.IJsonValue
            {
                if (!other.IsString)
                {
                    return false;
                }
                return ((Menes.JsonSchema.JsonString)this).Equals(other);
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
        public readonly struct AnchorValue : Menes.JsonSchema.IJsonValue
        {
            public static readonly AnchorValue Null = default(AnchorValue);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonSchema.JsonString? _menesStringTypeBacking;
            private static readonly System.Text.RegularExpressions.Regex _MenesPatternExpression = new System.Text.RegularExpressions.Regex("^[A-Za-z][-A-Za-z0-9.:_]*$", System.Text.RegularExpressions.RegexOptions.Compiled);
            public AnchorValue(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesStringTypeBacking = default;
            }
            public AnchorValue(Menes.JsonSchema.JsonString value)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = value;
            }
            private AnchorValue(Menes.JsonSchema.JsonString? _menesStringTypeBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = _menesStringTypeBacking;
            }
            public static implicit operator Menes.JsonSchema.JsonString(AnchorValue value)
            {
                return value.As<Menes.JsonSchema.JsonString>();
            }
            public static implicit operator AnchorValue(Menes.JsonSchema.JsonString value)
            {
                return value.As<Draft201909MetaCore.AnchorValue>();
            }
            public static implicit operator string(AnchorValue value)
            {
                return (string)(Menes.JsonSchema.JsonString)value;
            }
            public static implicit operator AnchorValue(string value)
            {
                return (Draft201909MetaCore.AnchorValue)(Menes.JsonSchema.JsonString)value;
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
            public Menes.JsonSchema.ValidationContext Validate(in Menes.JsonSchema.ValidationContext validationContext, Menes.JsonSchema.ValidationLevel level = Menes.JsonSchema.ValidationLevel.Flag)
            {
                Menes.JsonSchema.ValidationContext result = validationContext;
                if (level != Menes.JsonSchema.ValidationLevel.Flag)
                {
                    result = result.UsingStack();
                }
                if (!this.IsString)
                {
                    if (level >= Menes.JsonSchema.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of string");
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
                if (this.IsString)
                {
                    var value = (string)this.As<Menes.JsonSchema.JsonString>();
                    if (!_MenesPatternExpression.IsMatch(value))
                    {
                        if (level >= Menes.JsonSchema.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.3.3.  pattern - value must match the regular expression ^[A-Za-z][-A-Za-z0-9.:_]*$");
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
                where T : struct, Menes.JsonSchema.IJsonValue
            {
                if (typeof(T) == typeof(AnchorValue))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonSchema.JsonValue.As<AnchorValue, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.JsonSchema.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaCore.AnchorValue))
                {
                    return this.Validate(Menes.JsonSchema.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.JsonSchema.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, Menes.JsonSchema.IJsonValue
            {
                if (!other.IsString)
                {
                    return false;
                }
                return ((Menes.JsonSchema.JsonString)this).Equals(other);
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
        public readonly struct VocabularyEntity : Menes.JsonSchema.IJsonObject<VocabularyEntity>
        {
            public static readonly VocabularyEntity Null = default(VocabularyEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>> _menesAdditionalPropertiesBacking;
            public VocabularyEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>>.Empty;
            }
            private VocabularyEntity(in System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>> _menesAdditionalPropertiesBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
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
                        return this._menesAdditionalPropertiesBacking.Length;
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
                if (!this.IsObject)
                {
                    if (level >= Menes.JsonSchema.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of object");
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
                    foreach (var property in this.EnumerateObject())
                    {
                        var propertyName = new Menes.JsonSchema.JsonString(property.NameAsMemory).As<Menes.JsonSchema.JsonUri>();
                        result = propertyName.Validate(result, level);
                        if (level == Menes.JsonSchema.ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }
                        if (!result.HasEvaluatedLocalProperty(property.Name))
                        {
                            result = result.WithLocalProperty(property.Name);
                            result = property.Value<Menes.JsonSchema.JsonBoolean>().Validate(result, level);
                            if (level == Menes.JsonSchema.ValidationLevel.Flag && !result.IsValid)
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
                if (typeof(T) == typeof(VocabularyEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonSchema.JsonValue.As<VocabularyEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.JsonSchema.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaCore.VocabularyEntity))
                {
                    return this.Validate(Menes.JsonSchema.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.JsonSchema.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, Menes.JsonSchema.IJsonValue
            {
                if (!other.IsObject)
                {
                    return false;
                }
                var otherObject = Corvus.Extensions.CastTo<Menes.JsonSchema.IJsonObject>.From(other);
                MenesPropertyEnumerator firstEnumerator = this.EnumerateObject();
                if (this.PropertyCount != otherObject.PropertyCount)
                {
                    return false;
                }
                while (firstEnumerator.MoveNext())
                {
                    if (!otherObject.TryGetProperty<Menes.JsonSchema.JsonAny>(firstEnumerator.Current.NameAsMemory.Span, out Menes.JsonSchema.JsonAny otherProperty))
                    {
                        return false;
                    }
                    if (!firstEnumerator.Current.Value<Menes.JsonSchema.JsonAny>().Equals(otherProperty))
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
                var rc = this.TryGetPropertyAtIndex(index, out Menes.JsonSchema.Property<VocabularyEntity> prop);
                result = prop;
                return rc;
            }
            public VocabularyEntity RemoveProperty(string propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
            }
            public VocabularyEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
            }
            public VocabularyEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
            }
            public VocabularyEntity SetProperty<T>(string name, T value)
            where T : struct, Menes.JsonSchema.IJsonValue
            {
                var propertyName = System.MemoryExtensions.AsSpan(name);
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>(propertyName, value.As<Menes.JsonSchema.JsonBoolean>()));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>(propertyName, value.As<Menes.JsonSchema.JsonBoolean>()));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public VocabularyEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
            where T : struct, Menes.JsonSchema.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>(propertyName, value.As<Menes.JsonSchema.JsonBoolean>()));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>(propertyName, value.As<Menes.JsonSchema.JsonBoolean>()));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public VocabularyEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
            where T : struct, Menes.JsonSchema.IJsonValue
            {
                System.Span<char> name = stackalloc char[utf8Name.Length];
                int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
                var propertyName = name.Slice(0, writtenCount);
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>(propertyName, value.As<Menes.JsonSchema.JsonBoolean>()));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>(propertyName, value.As<Menes.JsonSchema.JsonBoolean>()));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public Draft201909MetaCore.VocabularyEntity.MenesPropertyEnumerator GetEnumerator()
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
            System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<Draft201909MetaCore.VocabularyEntity>> System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<Draft201909MetaCore.VocabularyEntity>>.GetEnumerator()
            {
                return this.GetEnumerator();
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
                if (this._menesAdditionalPropertiesBacking.Length > 0)
                {
                    return false;
                }
                return true;
            }
            /// <inheritdoc />
            private bool TryGetPropertyAtIndex(int index, out Menes.JsonSchema.Property<VocabularyEntity> result)
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        if (jsonPropertyIndex == index)
                        {
                            result = new Menes.JsonSchema.Property<VocabularyEntity>(property);
                            return true;
                        }
                        jsonPropertyIndex++;
                    }
                }
                int currentIndex = 0;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (currentIndex == index)
                    {
                        result = new Menes.JsonSchema.Property<VocabularyEntity>(this, property.NameAsMemory);
                        return true;
                    }
                    currentIndex++;
                }
                result = default; ;
                return false;
            }
            private VocabularyEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty<Menes.JsonSchema.JsonBoolean>> value)
            {
                return new VocabularyEntity(value);
            }
            /// <summary>
            /// An enumerator for the properties in a <see cref="VocabularyEntity"/>.
            /// </summary>
            public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<VocabularyEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<VocabularyEntity>>, System.Collections.IEnumerator
            {
                private VocabularyEntity instance;
                private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                private int propertyCount;
                internal MenesPropertyEnumerator(VocabularyEntity instance)
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
                public Menes.JsonSchema.Property<VocabularyEntity> Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.JsonSchema.Property<VocabularyEntity>(this.jsonEnumerator.Current);
                        }
                        else if (this.index >= 0)
                        {
                            if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.JsonSchema.Property<VocabularyEntity> result))
                            {
                                return result;
                            }
                            throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                        }
                        return new Menes.JsonSchema.Property<VocabularyEntity>(this.instance, default);
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the properties in a <see cref="VocabularyEntity"/>.</returns>
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
                System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<VocabularyEntity>> System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<VocabularyEntity>>.GetEnumerator()
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
        public readonly struct DefsEntity : Menes.JsonSchema.IJsonObject<DefsEntity>
        {
            public static readonly DefsEntity Null = default(DefsEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty> _menesAdditionalPropertiesBacking;
            public DefsEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty>.Empty;
            }
            private DefsEntity(in System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty> _menesAdditionalPropertiesBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
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
                        return this._menesAdditionalPropertiesBacking.Length;
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
                if (!this.IsObject)
                {
                    if (level >= Menes.JsonSchema.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of object");
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
                    foreach (var property in this.EnumerateObject())
                    {
                        if (!result.HasEvaluatedLocalProperty(property.Name))
                        {
                            result = result.WithLocalProperty(property.Name);
                            result = property.Value<Draft201909Schema>().Validate(result, level);
                            if (level == Menes.JsonSchema.ValidationLevel.Flag && !result.IsValid)
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
                if (typeof(T) == typeof(DefsEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonSchema.JsonValue.As<DefsEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.JsonSchema.IJsonValue
            {
                if (typeof(T) == typeof(Draft201909MetaCore.DefsEntity))
                {
                    return this.Validate(Menes.JsonSchema.ValidationContext.ValidContext).IsValid;
                }
                return this.As<T>().Validate(Menes.JsonSchema.ValidationContext.ValidContext).IsValid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, Menes.JsonSchema.IJsonValue
            {
                if (!other.IsObject)
                {
                    return false;
                }
                var otherObject = Corvus.Extensions.CastTo<Menes.JsonSchema.IJsonObject>.From(other);
                MenesPropertyEnumerator firstEnumerator = this.EnumerateObject();
                if (this.PropertyCount != otherObject.PropertyCount)
                {
                    return false;
                }
                while (firstEnumerator.MoveNext())
                {
                    if (!otherObject.TryGetProperty<Menes.JsonSchema.JsonAny>(firstEnumerator.Current.NameAsMemory.Span, out Menes.JsonSchema.JsonAny otherProperty))
                    {
                        return false;
                    }
                    if (!firstEnumerator.Current.Value<Menes.JsonSchema.JsonAny>().Equals(otherProperty))
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
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        property = additionalProperty.Value<Draft201909Schema>()?.As<T>() ?? default;
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
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        property = additionalProperty.Value<Draft201909Schema>()?.As<T>() ?? default;
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
                foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)
                {
                    if (additionalProperty.NameEquals(propertyName))
                    {
                        property = additionalProperty.Value<Draft201909Schema>()?.As<T>() ?? default;
                        return true;
                    }
                }
                property = default;
                return false;
            }
            /// <inheritdoc />
            public bool TryGetPropertyAtIndex(int index, out Menes.JsonSchema.IProperty result)
            {
                var rc = this.TryGetPropertyAtIndex(index, out Menes.JsonSchema.Property<DefsEntity> prop);
                result = prop;
                return rc;
            }
            public DefsEntity RemoveProperty(string propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
            }
            public DefsEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
            }
            public DefsEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
            {
                return this.SetProperty(propertyName, Menes.JsonSchema.JsonNull.Instance);
            }
            public DefsEntity SetProperty<T>(string name, T value)
            where T : struct, Menes.JsonSchema.IJsonValue
            {
                var propertyName = System.MemoryExtensions.AsSpan(name);
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonSchema.AdditionalProperty>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty(propertyName, Menes.JsonSchema.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty(propertyName, Menes.JsonSchema.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public DefsEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
            where T : struct, Menes.JsonSchema.IJsonValue
            {
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonSchema.AdditionalProperty>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty(propertyName, Menes.JsonSchema.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty(propertyName, Menes.JsonSchema.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public DefsEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
            where T : struct, Menes.JsonSchema.IJsonValue
            {
                System.Span<char> name = stackalloc char[utf8Name.Length];
                int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
                var propertyName = name.Slice(0, writtenCount);
                var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonSchema.AdditionalProperty>();
                bool added = false;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (!property.NameEquals(propertyName))
                    {
                        arrayBuilder.Add(property);
                    }
                    else
                    {
                        arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty(propertyName, Menes.JsonSchema.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                        added = true;
                    }
                }
                if (!added)
                {
                    arrayBuilder.Add(new Menes.JsonSchema.AdditionalProperty(propertyName, Menes.JsonSchema.JsonValueBacking.From<Draft201909Schema>(value.As<Draft201909Schema>())));
                }
                return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
                return this;
            }
            public Draft201909MetaCore.DefsEntity.MenesPropertyEnumerator GetEnumerator()
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
            System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<Draft201909MetaCore.DefsEntity>> System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<Draft201909MetaCore.DefsEntity>>.GetEnumerator()
            {
                return this.GetEnumerator();
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
                if (this._menesAdditionalPropertiesBacking.Length > 0)
                {
                    return false;
                }
                return true;
            }
            /// <inheritdoc />
            private bool TryGetPropertyAtIndex(int index, out Menes.JsonSchema.Property<DefsEntity> result)
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (var property in this.JsonElement.EnumerateObject())
                    {
                        if (jsonPropertyIndex == index)
                        {
                            result = new Menes.JsonSchema.Property<DefsEntity>(property);
                            return true;
                        }
                        jsonPropertyIndex++;
                    }
                }
                int currentIndex = 0;
                foreach (var property in this._menesAdditionalPropertiesBacking)
                {
                    if (currentIndex == index)
                    {
                        result = new Menes.JsonSchema.Property<DefsEntity>(this, property.NameAsMemory);
                        return true;
                    }
                    currentIndex++;
                }
                result = default; ;
                return false;
            }
            private DefsEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.JsonSchema.AdditionalProperty> value)
            {
                return new DefsEntity(value);
            }
            /// <summary>
            /// An enumerator for the properties in a <see cref="DefsEntity"/>.
            /// </summary>
            public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<DefsEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<DefsEntity>>, System.Collections.IEnumerator
            {
                private DefsEntity instance;
                private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
                private bool hasJsonEnumerator;
                private int index;
                private int propertyCount;
                internal MenesPropertyEnumerator(DefsEntity instance)
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
                public Menes.JsonSchema.Property<DefsEntity> Current
                {
                    get
                    {
                        if (this.hasJsonEnumerator)
                        {
                            return new Menes.JsonSchema.Property<DefsEntity>(this.jsonEnumerator.Current);
                        }
                        else if (this.index >= 0)
                        {
                            if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.JsonSchema.Property<DefsEntity> result))
                            {
                                return result;
                            }
                            throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                        }
                        return new Menes.JsonSchema.Property<DefsEntity>(this.instance, default);
                    }
                }
                /// <inheritdoc/>
                object System.Collections.IEnumerator.Current => this.Current;
                /// <summary>
                /// Returns a fresh copy of the enumerator
                /// </summary>
                /// <returns>An enumerator for the properties in a <see cref="DefsEntity"/>.</returns>
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
                System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<DefsEntity>> System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<DefsEntity>>.GetEnumerator()
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
        /// An enumerator for the properties in a <see cref="Draft201909MetaCore"/>.
        /// </summary>
        public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<Draft201909MetaCore>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<Draft201909MetaCore>>, System.Collections.IEnumerator
        {
            private Draft201909MetaCore instance;
            private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
            private bool hasJsonEnumerator;
            private int index;
            private int propertyCount;
            internal MenesPropertyEnumerator(Draft201909MetaCore instance)
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
            public Menes.JsonSchema.Property<Draft201909MetaCore> Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new Menes.JsonSchema.Property<Draft201909MetaCore>(this.jsonEnumerator.Current);
                    }
                    else if (this.index >= 0)
                    {
                        if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.JsonSchema.Property<Draft201909MetaCore> result))
                        {
                            return result;
                        }
                        throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                    }
                    return new Menes.JsonSchema.Property<Draft201909MetaCore>(this.instance, default);
                }
            }
            /// <inheritdoc/>
            object System.Collections.IEnumerator.Current => this.Current;
            /// <summary>
            /// Returns a fresh copy of the enumerator
            /// </summary>
            /// <returns>An enumerator for the properties in a <see cref="Draft201909MetaCore"/>.</returns>
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
            System.Collections.Generic.IEnumerator<Menes.JsonSchema.Property<Draft201909MetaCore>> System.Collections.Generic.IEnumerable<Menes.JsonSchema.Property<Draft201909MetaCore>>.GetEnumerator()
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
