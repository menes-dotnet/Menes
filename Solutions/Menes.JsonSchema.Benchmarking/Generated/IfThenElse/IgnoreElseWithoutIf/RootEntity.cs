// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace IfThenElseFeature.IgnoreElseWithoutIf
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
        private bool AllBackingFieldsAreNull()
        {
            return true;
        }
        public readonly struct ElseEntity : Menes.IJsonValue
        {
            public static readonly ElseEntity Null = default(ElseEntity);
            private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
            private readonly Menes.JsonNumber? _menesNumberTypeBacking;
            private static readonly Menes.JsonNumber _MenesConstValue = new Menes.JsonNumber((double)0);
            public ElseEntity(System.Text.Json.JsonElement jsonElement)
            {
                this._menesJsonElementBacking = jsonElement;
                this._menesNumberTypeBacking = default;
            }
            public ElseEntity(Menes.JsonNumber value)
            {
                this._menesJsonElementBacking = default;
                this._menesNumberTypeBacking = value;
            }
            private ElseEntity(Menes.JsonNumber? _menesNumberTypeBacking)
            {
                this._menesJsonElementBacking = default;
                this._menesNumberTypeBacking = _menesNumberTypeBacking;
            }
            public static implicit operator Menes.JsonInteger(ElseEntity value)
            {
                return value.As<Menes.JsonInteger>();
            }
            public static implicit operator ElseEntity(Menes.JsonInteger value)
            {
                return value.As<RootEntity.ElseEntity>();
            }
            public static implicit operator Menes.JsonNumber(ElseEntity value)
            {
                return value.As<Menes.JsonNumber>();
            }
            public static implicit operator ElseEntity(Menes.JsonNumber value)
            {
                return value.As<RootEntity.ElseEntity>();
            }
            public static implicit operator int(ElseEntity value)
            {
                return (int)(Menes.JsonNumber)value;
            }
            public static implicit operator ElseEntity(int value)
            {
                return (RootEntity.ElseEntity)(Menes.JsonNumber)value;
            }
            public static implicit operator long(ElseEntity value)
            {
                return (long)(Menes.JsonNumber)value;
            }
            public static implicit operator ElseEntity(long value)
            {
                return (RootEntity.ElseEntity)(Menes.JsonNumber)value;
            }
            public static implicit operator double(ElseEntity value)
            {
                return (double)(Menes.JsonNumber)value;
            }
            public static implicit operator ElseEntity(double value)
            {
                return (RootEntity.ElseEntity)(Menes.JsonNumber)value;
            }
            public static implicit operator float(ElseEntity value)
            {
                return (float)(Menes.JsonNumber)value;
            }
            public static implicit operator ElseEntity(float value)
            {
                return (RootEntity.ElseEntity)(Menes.JsonNumber)value;
            }
            /// <inheritdoc />
            public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
            /// <inheritdoc />
            public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
            /// <inheritdoc />
            public bool IsNumber => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number) || (!this.HasJsonElement && this._menesNumberTypeBacking is not null);
            /// <inheritdoc />
            public bool IsInteger => false;
            /// <inheritdoc />
            public bool IsString => false;
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
                if (!this.IsNumber)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of number");
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
                if (!this.IsNumber)
                {
                    if (level >= Menes.ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value 0");
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
                    if ((double)this != (double)_MenesConstValue)
                    {
                        if (level >= Menes.ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, message: "6.1.3. const - does not match const value 0");
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
                if (this.IsNumber)
                {
                    var number = (double)this.As<Menes.JsonNumber>();
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
                this._menesNumberTypeBacking?.WriteTo(writer);
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
                if (!other.IsNumber)
                {
                    return false;
                }
                return ((Menes.JsonNumber)this).Equals(other);
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
    }
}
