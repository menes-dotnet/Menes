// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace OneOfFeature.NestedOneOfToCheckValidationSemantics
{
public readonly struct RootEntity : Menes.IJsonValue
{
public static readonly RootEntity Null = default(RootEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
public RootEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
}
public static implicit operator RootEntity.OneOf0Entity(RootEntity value)
{
    return value.As<RootEntity.OneOf0Entity>();
}
public static implicit operator RootEntity(RootEntity.OneOf0Entity value)
{
    return value.As<RootEntity>();
}
public static implicit operator Menes.JsonNull(RootEntity value)
{
    return (Menes.JsonNull)(RootEntity.OneOf0Entity)value;
}
public static implicit operator RootEntity(Menes.JsonNull value)
{
    return (RootEntity)(RootEntity.OneOf0Entity)value;
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
result = ValidateOneOf(this, result, level);
return result;
Menes.ValidationContext ValidateOneOf(in RootEntity that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
{
  Menes.ValidationContext result = validationContext;
int oneOfCount = 0;
var oneOf0 = that.AsOneOf0Entity();
Menes.ValidationContext oneOfResult0;
if (level == Menes.ValidationLevel.Flag)
{
    oneOfResult0 = oneOf0.Validate(validationContext.CreateChildContext(), level);
}
else
{
    oneOfResult0 = oneOf0.Validate(validationContext.CreateChildContext("#/oneOf/0"), level);
}
if (oneOfResult0.IsValid)
{
    oneOfCount++;
}
result = result.MergeChildContext(oneOfResult0, false);
if (oneOfCount == 0)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "9.2.1.2. oneOf - no schema matched");
}
else
{
    result = result.WithResult(isValid: false);
}
}
else if (oneOfCount > 1)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "9.2.1.2. oneOf - multiple schema matched");
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
public readonly RootEntity.OneOf0Entity AsOneOf0Entity()
{
        return this.As<RootEntity.OneOf0Entity>();
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
public readonly struct OneOf0Entity : Menes.IJsonValue
{
public static readonly OneOf0Entity Null = default(OneOf0Entity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
public OneOf0Entity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
}
public static implicit operator Menes.JsonNull(OneOf0Entity value)
{
    return value.As<Menes.JsonNull>();
}
public static implicit operator OneOf0Entity(Menes.JsonNull value)
{
    return value.As<RootEntity.OneOf0Entity>();
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
result = ValidateOneOf(this, result, level);
return result;
Menes.ValidationContext ValidateOneOf(in RootEntity.OneOf0Entity that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
{
  Menes.ValidationContext result = validationContext;
int oneOfCount = 0;
var oneOf0 = that.AsJsonNull();
Menes.ValidationContext oneOfResult0;
if (level == Menes.ValidationLevel.Flag)
{
    oneOfResult0 = oneOf0.Validate(validationContext.CreateChildContext(), level);
}
else
{
    oneOfResult0 = oneOf0.Validate(validationContext.CreateChildContext("#/oneOf/0/oneOf/0"), level);
}
if (oneOfResult0.IsValid)
{
    oneOfCount++;
}
result = result.MergeChildContext(oneOfResult0, false);
if (oneOfCount == 0)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "9.2.1.2. oneOf - no schema matched");
}
else
{
    result = result.WithResult(isValid: false);
}
}
else if (oneOfCount > 1)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "9.2.1.2. oneOf - multiple schema matched");
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
if (typeof(T) == typeof(OneOf0Entity))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<OneOf0Entity, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(RootEntity.OneOf0Entity))
{
    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
}
    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
}
public readonly Menes.JsonNull AsJsonNull()
{
        return this.As<Menes.JsonNull>();
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
}
}
}
