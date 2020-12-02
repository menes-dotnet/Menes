// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace EnumFeature.NulCharactersInStrings
{
public readonly struct RootEntity : Menes.IJsonValue
{
public static readonly RootEntity Null = default(RootEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly Menes.JsonString? _menesStringTypeBacking;
public RootEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesStringTypeBacking = default;
}
public RootEntity(Menes.JsonString value)
{
    this._menesJsonElementBacking = default;
    this._menesStringTypeBacking = value;
}
private RootEntity(Menes.JsonString? _menesStringTypeBacking)
{
    this._menesJsonElementBacking = default;
this._menesStringTypeBacking = _menesStringTypeBacking;
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
public bool IsNumber => false;
/// <inheritdoc />
public bool IsInteger=> false;
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
bool foundMatch = false;
if (!foundMatch)
{
    if (this.IsString)
    {
       if (System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), RootEntity.EnumValues.Item0.AsSpan()))
        {
            foundMatch = true;
        }
    }
}
if (!foundMatch)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.1.2. enum - does not match enum values \"hello\\u0000there\"");
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
// 
public static class EnumValues
{
internal static readonly Menes.JsonString Item0 = new Menes.JsonString("hello\0there");
public static readonly Menes.JsonString HelloThere = new Menes.JsonString("hello\0there");
}
}
}
