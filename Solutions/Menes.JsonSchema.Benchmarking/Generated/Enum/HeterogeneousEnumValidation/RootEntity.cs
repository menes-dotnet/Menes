// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace EnumFeature.HeterogeneousEnumValidation
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
bool foundMatch = false;
if (!foundMatch)
{
    if (this.IsNumber)
    {
        if ((double)this.As<Menes.JsonNumber>() != (double)RootEntity.EnumValues.Item0)
        {
            foundMatch = false;
        }
        else
        {
            foundMatch = true;
        }
    }
}
if (!foundMatch)
{
    if (this.IsString)
    {
       if (System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), RootEntity.EnumValues.Item1.AsSpan()))
        {
            foundMatch = true;
        }
    }
}
if (!foundMatch)
{
    if (this.IsArray)
    {
        var firstEnumerator = RootEntity.EnumValues.Item2.EnumerateArray();
        var secondEnumerator = this.As<Menes.JsonAny>().EnumerateArray();
        bool failed = false;
        while(firstEnumerator.MoveNext())
        {
            if (!secondEnumerator.MoveNext())
            {
                 failed = true;
                 break;
            }
            else if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
            {
                 failed = true;
                 break;
            }
        }
       if (!failed && !secondEnumerator.MoveNext())
       {
           foundMatch = true;
       }
    }
}
if (!foundMatch)
{
    if (this.IsBoolean)
    {
        if ((bool)this.As<Menes.JsonBoolean>() == (bool)RootEntity.EnumValues.Item3)
        {
            foundMatch = true;
        }
    }
}
if (!foundMatch)
{
    if (this.IsObject)
    {
        if (this.As<Menes.JsonAny>().Equals(RootEntity.EnumValues.Item4))
        {
               foundMatch = true;
        }
    }
}
if (!foundMatch)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.1.2. enum - does not match enum values 6, \"foo\", [], true, {\"foo\": 12}");
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
// 
public static class EnumValues
{
public static readonly Menes.JsonNumber Item0 = new Menes.JsonNumber((double)6);
internal static readonly Menes.JsonString Item1 = new Menes.JsonString("foo");
public static readonly Menes.JsonString Foo = new Menes.JsonString("foo");
public static readonly Menes.JsonAny Item2 = new Menes.JsonAny("[]");
public static readonly Menes.JsonBoolean Item3 = new Menes.JsonBoolean(true);
public static readonly Menes.JsonAny Item4 = new Menes.JsonAny("{\"foo\": 12}");
}
}
}
