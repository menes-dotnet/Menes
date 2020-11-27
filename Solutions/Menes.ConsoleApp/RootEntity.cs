// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Driver.GeneratedTypes
{
    public readonly struct RootEntity : Menes.IJsonValue
    {
        public static readonly RootEntity Null = default(RootEntity);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        public RootEntity(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
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
        public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
        {
            evaluatedProperties = evaluatedProperties ?? new System.Collections.Generic.HashSet<string>();
            var composedEvaluatedProperties = new System.Collections.Generic.HashSet<string>();
            Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
            result = ValidateIfThenElse(this, result, level, composedEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
            return result;
            Menes.ValidationResult ValidateIfThenElse(in RootEntity that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush1)
                {
                    aklPush1.Push("#/if");
                }
                System.Collections.Generic.HashSet<string> localEvaluatedProperties = new System.Collections.Generic.HashSet<string>();
                localEvaluatedProperties.Clear();
                var ifValue = that.AsJsonAny();
                var ifResult = ifValue.Validate(null, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop1)
                {
                    aklPop1.Pop();
                }
                if (ifResult.Valid)
                {
                    if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush2)
                    {
                        aklPush2.Push("#/then");
                    }
                    var thenValue = that.AsThenEntity();
                    var thenResult = thenValue.Validate(null, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                    if (!thenResult.Valid)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            string? il = null;
                            string? akl = null;
                            instanceLocation?.TryPeek(out il);
                            absoluteKeywordLocation?.TryPeek(out akl);
                            result.AddResult(valid: false, message: "9.2.2.2. then", instanceLocation: il, absoluteKeywordLocation: akl);
                        }
                        else
                        {
                            result.SetValid(false);
                        }
                    }
                    else
                    {
                        if (level == Menes.ValidationLevel.Verbose)
                        {
                            string? il = null;
                            string? akl = null;
                            instanceLocation?.TryPeek(out il);
                            absoluteKeywordLocation?.TryPeek(out akl);
                            result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
                        }
                    }
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop2)
                {
                    aklPop2.Pop();
                }
                else
                {
                    if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush3)
                    {
                        aklPush3.Push("#/else");
                    }
                    var elseValue = that.AsElseEntity();
                    var elseResult = elseValue.Validate(null, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);
                    if (!elseResult.Valid)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            string? il = null;
                            string? akl = null;
                            instanceLocation?.TryPeek(out il);
                            absoluteKeywordLocation?.TryPeek(out akl);
                            result.AddResult(valid: false, message: "9.2.2.3. else", instanceLocation: il, absoluteKeywordLocation: akl);
                        }
                        else
                        {
                            result.SetValid(false);
                        }
                    }
                    else
                    {
                        if (level == Menes.ValidationLevel.Verbose)
                        {
                            string? il = null;
                            string? akl = null;
                            instanceLocation?.TryPeek(out il);
                            absoluteKeywordLocation?.TryPeek(out akl);
                            result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
                        }
                    }
                }
                if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop3)
                {
                    aklPop3.Pop();
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
                return this.Validate().Valid;
            }
            return this.As<T>().Validate().Valid;
        }
        public readonly Menes.JsonAny AsJsonAny()
        {
            return this.As<Menes.JsonAny>();
        }
        public readonly RootEntity.ThenEntity AsThenEntity()
        {
            return this.As<RootEntity.ThenEntity>();
        }
        public readonly RootEntity.ElseEntity AsElseEntity()
        {
            return this.As<RootEntity.ElseEntity>();
        }
        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, Menes.IJsonValue
        {
            return false;
        }
        private bool AllBackingFieldsAreNull()
        {
            return true;
        }
        public readonly struct ThenEntity : Menes.IJsonValue
        {
            public static readonly ThenEntity Null = default(ThenEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonString? _menesStringTypeBacking;
            private static readonly Menes.JsonString _MenesConstValue = new Menes.JsonString("then");
            public ThenEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesStringTypeBacking = default;
            }
            public ThenEntity(Menes.JsonString value)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = value;
            }
            private ThenEntity(Menes.JsonString? _menesStringTypeBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = _menesStringTypeBacking;
            }
            public static implicit operator Menes.JsonString(ThenEntity value)
            {
                return value.As<Menes.JsonString>();
            }
            public static implicit operator ThenEntity(Menes.JsonString value)
            {
                return value.As<RootEntity.ThenEntity>();
            }
            public static implicit operator string(ThenEntity value)
            {
                return (string)(Menes.JsonString)value;
            }
            public static implicit operator ThenEntity(string value)
            {
                return (RootEntity.ThenEntity)(Menes.JsonString)value;
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
            public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                evaluatedProperties = evaluatedProperties ?? new System.Collections.Generic.HashSet<string>();
                var composedEvaluatedProperties = new System.Collections.Generic.HashSet<string>();
                Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
                if (!this.IsString)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        string? il = null;
                        string? akl = null;
                        instanceLocation?.TryPeek(out il);
                        absoluteKeywordLocation?.TryPeek(out akl);
                        result.AddResult(valid: false, message: "6.1.1.  type - item must be one of string", instanceLocation: il, absoluteKeywordLocation: akl);
                    }
                    else
                    {
                        result.SetValid(false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.Valid)
                    {
                        return result;
                    }
                }
                if (!this.IsString)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        string? il = null;
                        string? akl = null;
                        instanceLocation?.TryPeek(out il);
                        absoluteKeywordLocation?.TryPeek(out akl);
                        result.AddResult(valid: false, message: "6.1.3. const - does not match const value \"then\"", instanceLocation: il, absoluteKeywordLocation: akl);
                    }
                    else
                    {
                        result.SetValid(false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.Valid)
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
                            string? il = null;
                            string? akl = null;
                            instanceLocation?.TryPeek(out il);
                            absoluteKeywordLocation?.TryPeek(out akl);
                            result.AddResult(valid: false, message: "6.1.3. const - does not match const value \"then\"", instanceLocation: il, absoluteKeywordLocation: akl);
                        }
                        else
                        {
                            result.SetValid(false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.Valid)
                        {
                            return result;
                        }
                    }
                    else
                    {
                        if (level == Menes.ValidationLevel.Verbose)
                        {
                            string? il = null;
                            string? akl = null;
                            instanceLocation?.TryPeek(out il);
                            absoluteKeywordLocation?.TryPeek(out akl);
                            result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
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
                if (typeof(T) == typeof(ThenEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<ThenEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.ThenEntity))
                {
                    return this.Validate().Valid;
                }
                return this.As<T>().Validate().Valid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(T other)
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
        public readonly struct ElseEntity : Menes.IJsonValue
        {
            public static readonly ElseEntity Null = default(ElseEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonString? _menesStringTypeBacking;
            private static readonly Menes.JsonString _MenesConstValue = new Menes.JsonString("else");
            public ElseEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesStringTypeBacking = default;
            }
            public ElseEntity(Menes.JsonString value)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = value;
            }
            private ElseEntity(Menes.JsonString? _menesStringTypeBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesStringTypeBacking = _menesStringTypeBacking;
            }
            public static implicit operator Menes.JsonString(ElseEntity value)
            {
                return value.As<Menes.JsonString>();
            }
            public static implicit operator ElseEntity(Menes.JsonString value)
            {
                return value.As<RootEntity.ElseEntity>();
            }
            public static implicit operator string(ElseEntity value)
            {
                return (string)(Menes.JsonString)value;
            }
            public static implicit operator ElseEntity(string value)
            {
                return (RootEntity.ElseEntity)(Menes.JsonString)value;
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
            public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                evaluatedProperties = evaluatedProperties ?? new System.Collections.Generic.HashSet<string>();
                var composedEvaluatedProperties = new System.Collections.Generic.HashSet<string>();
                Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;
                if (!this.IsString)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        string? il = null;
                        string? akl = null;
                        instanceLocation?.TryPeek(out il);
                        absoluteKeywordLocation?.TryPeek(out akl);
                        result.AddResult(valid: false, message: "6.1.1.  type - item must be one of string", instanceLocation: il, absoluteKeywordLocation: akl);
                    }
                    else
                    {
                        result.SetValid(false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.Valid)
                    {
                        return result;
                    }
                }
                if (!this.IsString)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        string? il = null;
                        string? akl = null;
                        instanceLocation?.TryPeek(out il);
                        absoluteKeywordLocation?.TryPeek(out akl);
                        result.AddResult(valid: false, message: "6.1.3. const - does not match const value \"else\"", instanceLocation: il, absoluteKeywordLocation: akl);
                    }
                    else
                    {
                        result.SetValid(false);
                    }
                    if (level == Menes.ValidationLevel.Flag && !result.Valid)
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
                            string? il = null;
                            string? akl = null;
                            instanceLocation?.TryPeek(out il);
                            absoluteKeywordLocation?.TryPeek(out akl);
                            result.AddResult(valid: false, message: "6.1.3. const - does not match const value \"else\"", instanceLocation: il, absoluteKeywordLocation: akl);
                        }
                        else
                        {
                            result.SetValid(false);
                        }
                        if (level == Menes.ValidationLevel.Flag && !result.Valid)
                        {
                            return result;
                        }
                    }
                    else
                    {
                        if (level == Menes.ValidationLevel.Verbose)
                        {
                            string? il = null;
                            string? akl = null;
                            instanceLocation?.TryPeek(out il);
                            absoluteKeywordLocation?.TryPeek(out akl);
                            result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
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
                if (typeof(T) == typeof(ElseEntity))
                {
                    return Corvus.Extensions.CastTo<T>.From(this);
                }
                return Menes.JsonValue.As<ElseEntity, T>(this);
            }
            /// <inheritdoc />
            public bool Is<T>()
                where T : struct, Menes.IJsonValue
            {
                if (typeof(T) == typeof(RootEntity.ElseEntity))
                {
                    return this.Validate().Valid;
                }
                return this.As<T>().Validate().Valid;
            }
            /// <inheritdoc/>
            public bool Equals<T>(T other)
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
    }
}
