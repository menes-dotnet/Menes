// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace EnumFeature.EnumWithTrueDoesNotMatch1
{
    public readonly struct RootEntity : Menes.IJsonValue
    {
        public static readonly RootEntity Null = default(RootEntity);
        private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
        private readonly Menes.JsonBoolean? _menesBooleanTypeBacking;
        public RootEntity(System.Text.Json.JsonElement jsonElement)
        {
            this._menesJsonElementBacking = jsonElement;
            this._menesBooleanTypeBacking = default;
        }
        public RootEntity(Menes.JsonBoolean value)
        {
            this._menesJsonElementBacking = default;
            this._menesBooleanTypeBacking = value;
        }
        private RootEntity(Menes.JsonBoolean? _menesBooleanTypeBacking)
        {
            this._menesJsonElementBacking = default;
            this._menesBooleanTypeBacking = _menesBooleanTypeBacking;
        }
        public static implicit operator Menes.JsonBoolean(RootEntity value)
        {
            return value.As<Menes.JsonBoolean>();
        }
        public static implicit operator RootEntity(Menes.JsonBoolean value)
        {
            return value.As<RootEntity>();
        }
        public static implicit operator bool(RootEntity value)
        {
            return (bool)(Menes.JsonBoolean)value;
        }
        public static implicit operator RootEntity(bool value)
        {
            return (RootEntity)(Menes.JsonBoolean)value;
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
        public bool IsBoolean => (this.HasJsonElement && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.True || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.False)) || (!this.HasJsonElement && _menesBooleanTypeBacking is not null);
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
            if (!this.IsBoolean)
            {
                if (level >= Menes.ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of boolean");
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
            bool foundMatch = false;
            if (!foundMatch)
            {
                if (this.IsBoolean)
                {
                    if ((bool)this == (bool)RootEntity.EnumValues.Item0)
                    {
                        foundMatch = true;
                    }
                }
            }
            if (!foundMatch)
            {
                if (level >= Menes.ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, message: "6.1.2. enum - does not match enum values true");
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
            this._menesBooleanTypeBacking?.WriteTo(writer);
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
            if (!other.IsBoolean)
            {
                return false;
            }
            return ((Menes.JsonBoolean)this).Equals(other);
        }
        private bool AllBackingFieldsAreNull()
        {
            if (this._menesBooleanTypeBacking is not null)
            {
                return false;
            }
            return true;
        }
        // 
        public static class EnumValues
        {
            public static readonly Menes.JsonBoolean Item0 = new Menes.JsonBoolean(true);
        }
    }
}
