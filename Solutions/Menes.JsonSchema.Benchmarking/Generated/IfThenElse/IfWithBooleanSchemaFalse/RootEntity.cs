// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace IfThenElseFeature.IfWithBooleanSchemaFalse
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
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
        {
            Menes.ValidationContext result = validationContext;
            if (level != Menes.ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }
            result = ValidateIfThenElse(this, result, level);
            return result;
            Menes.ValidationContext ValidateIfThenElse(in RootEntity that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level)
            {
                var ifValue = that.AsJsonNotAny();
                Menes.ValidationContext ifResult;
                if (level == Menes.ValidationLevel.Flag)
                {
                    ifResult = ifValue.Validate(validationContext.CreateChildContext(), level);
                }
                else
                {
                    ifResult = ifValue.Validate(validationContext.CreateChildContext("#/if"), level);
                }
                if (ifResult.IsValid)
                {
                    result = result.MergeChildContext(ifResult, false);
                    var thenValue = that.AsThenEntity();
                    Menes.ValidationContext thenResult;
                    if (level == Menes.ValidationLevel.Flag)
                    {
                        thenResult = thenValue.Validate(validationContext.CreateChildContext(), level);
                    }
                    else
                    {
                        thenResult = thenValue.Validate(validationContext.CreateChildContext("#/then"), level);
                    }
                    if (!thenResult.IsValid)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "9.2.2.2. then");
                        }
                        else
                        {
                            result = result.WithResult(isValid: false);
                        }
                    }
                    else
                    {
                        result = result.MergeChildContext(thenResult, false);
                        if (level == Menes.ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true);
                        }
                    }
                }
                else
                {
                    var elseValue = that.AsElseEntity();
                    Menes.ValidationContext elseResult;
                    if (level == Menes.ValidationLevel.Flag)
                    {
                        elseResult = elseValue.Validate(validationContext.CreateChildContext(), level);
                    }
                    else
                    {
                        elseResult = elseValue.Validate(validationContext.CreateChildContext("#/else"), level);
                    }
                    if (!elseResult.IsValid)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "9.2.2.3. else");
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
                        result = result.MergeChildContext(elseResult, false);
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
        public readonly Menes.JsonNotAny AsJsonNotAny()
        {
            return this.As<Menes.JsonNotAny>();
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
        public bool Equals<T>(in T other)
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
                        result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"then\"");
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
                            result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"then\"");
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
                        result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"else\"");
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
                            result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value \"else\"");
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
    }
}
