// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace TypeFeature.MultipleTypesCanBeSpecifiedInAnArray
{
    public readonly struct RootEntity : Menes.IJsonValue
    {
        public static readonly RootEntity Null = default(RootEntity);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly Menes.JsonInteger? _menesIntegerTypeBacking;
        private readonly Menes.JsonString? _menesStringTypeBacking;
        public RootEntity(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesIntegerTypeBacking = default;
            this._menesStringTypeBacking = default;
        }
        public RootEntity(Menes.JsonInteger value)
        {
            this._menesJsonElementBacking = default;
            this._menesIntegerTypeBacking = value;
            this._menesStringTypeBacking = default;
        }
        public RootEntity(Menes.JsonString value)
        {
            this._menesJsonElementBacking = default;
            this._menesStringTypeBacking = value;
            this._menesIntegerTypeBacking = default;
        }
        private RootEntity(Menes.JsonInteger? _menesIntegerTypeBacking, Menes.JsonString? _menesStringTypeBacking)
        {
            this._menesJsonElementBacking = default;
            this._menesIntegerTypeBacking = _menesIntegerTypeBacking;
            this._menesStringTypeBacking = _menesStringTypeBacking;
        }
        public static implicit operator Menes.JsonInteger(RootEntity value)
        {
            return value.As<Menes.JsonInteger>();
        }
        public static implicit operator RootEntity(Menes.JsonInteger value)
        {
            return value.As<RootEntity>();
        }
        public static implicit operator Menes.JsonNumber(RootEntity value)
        {
            return value.As<Menes.JsonNumber>();
        }
        public static implicit operator RootEntity(Menes.JsonNumber value)
        {
            return value.As<RootEntity>();
        }
        public static implicit operator long(RootEntity value)
        {
            return (long)(Menes.JsonInteger)value;
        }
        public static implicit operator RootEntity(long value)
        {
            return (RootEntity)(Menes.JsonInteger)value;
        }
        public static implicit operator int(RootEntity value)
        {
            return (int)(Menes.JsonInteger)value;
        }
        public static implicit operator RootEntity(int value)
        {
            return (RootEntity)(Menes.JsonInteger)value;
        }
        public static implicit operator Menes.JsonString(RootEntity value)
        {
            return value.As<Menes.JsonString>();
        }
        public static implicit operator RootEntity(Menes.JsonString value)
        {
            return value.As<RootEntity>();
        }
        public static implicit operator string(RootEntity value)
        {
            return (string)(Menes.JsonString)value;
        }
        public static implicit operator RootEntity(string value)
        {
            return (RootEntity)(Menes.JsonString)value;
        }
        /// <inheritdoc />
        public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
        /// <inheritdoc />
        public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
        /// <inheritdoc />
        public bool IsNumber => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number) || (!this.HasJsonElement && this._menesIntegerTypeBacking is not null);
        /// <inheritdoc />
        public bool IsInteger => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number && (this.JsonElement.GetDouble() == System.Math.Floor(this.JsonElement.GetDouble()))) || (!this.HasJsonElement && this._menesIntegerTypeBacking is not null);
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
            if (!this.IsInteger && !this.IsString)
            {
                if (level >= Menes.ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of integer,string");
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
            this._menesIntegerTypeBacking?.WriteTo(writer);
            this._menesStringTypeBacking?.WriteTo(writer);
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
            if (this._menesIntegerTypeBacking is not null)
            {
                return false;
            }
            if (this._menesStringTypeBacking is not null)
            {
                return false;
            }
            return true;
        }
    }
}
