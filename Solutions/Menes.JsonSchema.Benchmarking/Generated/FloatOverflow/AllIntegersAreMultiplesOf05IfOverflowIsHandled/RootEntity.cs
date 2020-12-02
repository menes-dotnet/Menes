// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace FloatOverflowFeature.AllIntegersAreMultiplesOf05IfOverflowIsHandled
{
public readonly struct RootEntity : Menes.IJsonValue
{
public static readonly RootEntity Null = default(RootEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly Menes.JsonInteger? _menesIntegerTypeBacking;
public RootEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesIntegerTypeBacking = default;
}
public RootEntity(Menes.JsonInteger value)
{
    this._menesJsonElementBacking = default;
    this._menesIntegerTypeBacking = value;
}
private RootEntity(Menes.JsonInteger? _menesIntegerTypeBacking)
{
    this._menesJsonElementBacking = default;
this._menesIntegerTypeBacking = _menesIntegerTypeBacking;
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
/// <inheritdoc />
public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();
/// <inheritdoc />
public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());
/// <inheritdoc />
public bool IsNumber => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number) || (!this.HasJsonElement && this._menesIntegerTypeBacking is not null);
/// <inheritdoc />
public bool IsInteger => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number && (this.JsonElement.GetDouble() == System.Math.Floor(this.JsonElement.GetDouble()))) || (!this.HasJsonElement && this._menesIntegerTypeBacking is not null);
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
if (!this.IsInteger)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of integer");
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
    if (System.Math.Abs(System.Math.IEEERemainder((double)number, (double)0.5)) > 1.0E-18)
    {
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.2.1.  multipleOf - item must be a multiple of 0.5");
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
    if (!other.IsNumber)
    {
        return false;
    }
    return ((Menes.JsonNumber)this).Equals(other);
}
private bool AllBackingFieldsAreNull()
{
if (this._menesIntegerTypeBacking is not null)
{
    return false;
}
return true;
}
}
}
