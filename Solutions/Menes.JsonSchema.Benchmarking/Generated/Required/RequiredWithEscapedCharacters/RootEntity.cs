// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace RequiredFeature.RequiredWithEscapedCharacters
{
public readonly struct RootEntity : Menes.IJsonObject<RootEntity>
{
public static readonly RootEntity Null = default(RootEntity);
private static readonly System.ReadOnlyMemory<char> _MenesFooBarJsonPropertyName = System.MemoryExtensions.AsMemory("foo\nbar");
private static readonly System.ReadOnlyMemory<char> _MenesFooBar1JsonPropertyName = System.MemoryExtensions.AsMemory("foo\"bar");
private static readonly System.ReadOnlyMemory<char> _MenesFooBar2JsonPropertyName = System.MemoryExtensions.AsMemory("foo\\bar");
private static readonly System.ReadOnlyMemory<char> _MenesFooBar3JsonPropertyName = System.MemoryExtensions.AsMemory("foo\rbar");
private static readonly System.ReadOnlyMemory<char> _MenesFooBar4JsonPropertyName = System.MemoryExtensions.AsMemory("foo\tbar");
private static readonly System.ReadOnlyMemory<char> _MenesFooBar5JsonPropertyName = System.MemoryExtensions.AsMemory("foo\fbar");
private static readonly System.ReadOnlyMemory<byte>  _MenesFooBarUtf8JsonPropertyName = new byte[] { 102, 111, 111, 10, 98, 97, 114 };
private static readonly System.ReadOnlyMemory<byte>  _MenesFooBar1Utf8JsonPropertyName = new byte[] { 102, 111, 111, 34, 98, 97, 114 };
private static readonly System.ReadOnlyMemory<byte>  _MenesFooBar2Utf8JsonPropertyName = new byte[] { 102, 111, 111, 92, 98, 97, 114 };
private static readonly System.ReadOnlyMemory<byte>  _MenesFooBar3Utf8JsonPropertyName = new byte[] { 102, 111, 111, 13, 98, 97, 114 };
private static readonly System.ReadOnlyMemory<byte>  _MenesFooBar4Utf8JsonPropertyName = new byte[] { 102, 111, 111, 9, 98, 97, 114 };
private static readonly System.ReadOnlyMemory<byte>  _MenesFooBar5Utf8JsonPropertyName = new byte[] { 102, 111, 111, 12, 98, 97, 114 };
private static readonly  System.Text.Json.JsonEncodedText _MenesFooBarEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFooBarUtf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesFooBar1EncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFooBar1Utf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesFooBar2EncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFooBar2Utf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesFooBar3EncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFooBar3Utf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesFooBar4EncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFooBar4Utf8JsonPropertyName.Span);
private static readonly  System.Text.Json.JsonEncodedText _MenesFooBar5EncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesFooBar5Utf8JsonPropertyName.Span);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
private readonly Menes.JsonAny? fooBar;
private readonly Menes.JsonAny? fooBar1;
private readonly Menes.JsonAny? fooBar2;
private readonly Menes.JsonAny? fooBar3;
private readonly Menes.JsonAny? fooBar4;
private readonly Menes.JsonAny? fooBar5;
public RootEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
this.fooBar = default;
this.fooBar1 = default;
this.fooBar2 = default;
this.fooBar3 = default;
this.fooBar4 = default;
this.fooBar5 = default;
}
public RootEntity(Menes.JsonAny fooBar, Menes.JsonAny fooBar1, Menes.JsonAny fooBar2, Menes.JsonAny fooBar3, Menes.JsonAny fooBar4, Menes.JsonAny fooBar5)
{
    this._menesJsonElementBacking = default;
this.fooBar = fooBar;
this.fooBar1 = fooBar1;
this.fooBar2 = fooBar2;
this.fooBar3 = fooBar3;
this.fooBar4 = fooBar4;
this.fooBar5 = fooBar5;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
}
private RootEntity(Menes.JsonAny? fooBar, Menes.JsonAny? fooBar1, Menes.JsonAny? fooBar2, Menes.JsonAny? fooBar3, Menes.JsonAny? fooBar4, Menes.JsonAny? fooBar5, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
{
    this._menesJsonElementBacking = default;
this.fooBar = fooBar;
this.fooBar1 = fooBar1;
this.fooBar2 = fooBar2;
this.fooBar3 = fooBar3;
this.fooBar4 = fooBar4;
this.fooBar5 = fooBar5;
this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
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
public Menes.JsonAny FooBar => this.HasJsonElement ? this.GetPropertyFromJsonElement<Menes.JsonAny>(_MenesFooBarUtf8JsonPropertyName.Span) : this.fooBar ?? Menes.JsonAny.Null;
public Menes.JsonAny FooBar1 => this.HasJsonElement ? this.GetPropertyFromJsonElement<Menes.JsonAny>(_MenesFooBar1Utf8JsonPropertyName.Span) : this.fooBar1 ?? Menes.JsonAny.Null;
public Menes.JsonAny FooBar2 => this.HasJsonElement ? this.GetPropertyFromJsonElement<Menes.JsonAny>(_MenesFooBar2Utf8JsonPropertyName.Span) : this.fooBar2 ?? Menes.JsonAny.Null;
public Menes.JsonAny FooBar3 => this.HasJsonElement ? this.GetPropertyFromJsonElement<Menes.JsonAny>(_MenesFooBar3Utf8JsonPropertyName.Span) : this.fooBar3 ?? Menes.JsonAny.Null;
public Menes.JsonAny FooBar4 => this.HasJsonElement ? this.GetPropertyFromJsonElement<Menes.JsonAny>(_MenesFooBar4Utf8JsonPropertyName.Span) : this.fooBar4 ?? Menes.JsonAny.Null;
public Menes.JsonAny FooBar5 => this.HasJsonElement ? this.GetPropertyFromJsonElement<Menes.JsonAny>(_MenesFooBar5Utf8JsonPropertyName.Span) : this.fooBar5 ?? Menes.JsonAny.Null;
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
           return 6 + this._menesAdditionalPropertiesBacking.Length;
       }
   }
}
/// <inheritdoc />
public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)
{
Menes.ValidationContext result = validationContext;
if (level != Menes.ValidationLevel.Flag)
{
    result = result.UsingStack();
}
if (this.IsObject)
{
    result = result.WithLocalProperty("foo\nbar");
    if (this.TryGetProperty<Menes.JsonAny>(_MenesFooBarJsonPropertyName.Span, out Menes.JsonAny value0))
    {
        result = value0.Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
    }
    else
    {
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.5.3. required - required property not present.");
}
else
{
    result = result.WithResult(isValid: false);
}
        if (level == Menes.ValidationLevel.Flag)
        {
            return result;
        }
    }
    result = result.WithLocalProperty("foo\"bar");
    if (this.TryGetProperty<Menes.JsonAny>(_MenesFooBar1JsonPropertyName.Span, out Menes.JsonAny value1))
    {
        result = value1.Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
    }
    else
    {
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.5.3. required - required property not present.");
}
else
{
    result = result.WithResult(isValid: false);
}
        if (level == Menes.ValidationLevel.Flag)
        {
            return result;
        }
    }
    result = result.WithLocalProperty("foo\\bar");
    if (this.TryGetProperty<Menes.JsonAny>(_MenesFooBar2JsonPropertyName.Span, out Menes.JsonAny value2))
    {
        result = value2.Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
    }
    else
    {
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.5.3. required - required property not present.");
}
else
{
    result = result.WithResult(isValid: false);
}
        if (level == Menes.ValidationLevel.Flag)
        {
            return result;
        }
    }
    result = result.WithLocalProperty("foo\rbar");
    if (this.TryGetProperty<Menes.JsonAny>(_MenesFooBar3JsonPropertyName.Span, out Menes.JsonAny value3))
    {
        result = value3.Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
    }
    else
    {
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.5.3. required - required property not present.");
}
else
{
    result = result.WithResult(isValid: false);
}
        if (level == Menes.ValidationLevel.Flag)
        {
            return result;
        }
    }
    result = result.WithLocalProperty("foo\tbar");
    if (this.TryGetProperty<Menes.JsonAny>(_MenesFooBar4JsonPropertyName.Span, out Menes.JsonAny value4))
    {
        result = value4.Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
    }
    else
    {
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.5.3. required - required property not present.");
}
else
{
    result = result.WithResult(isValid: false);
}
        if (level == Menes.ValidationLevel.Flag)
        {
            return result;
        }
    }
    result = result.WithLocalProperty("foo\fbar");
    if (this.TryGetProperty<Menes.JsonAny>(_MenesFooBar5JsonPropertyName.Span, out Menes.JsonAny value5))
    {
        result = value5.Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
    }
    else
    {
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.5.3. required - required property not present.");
}
else
{
    result = result.WithResult(isValid: false);
}
        if (level == Menes.ValidationLevel.Flag)
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
writer.WriteStartObject();
    if (this.fooBar is Menes.JsonAny fooBar)
    {
        writer.WritePropertyName(_MenesFooBarEncodedJsonPropertyName);
        fooBar.WriteTo(writer);
    }
    if (this.fooBar1 is Menes.JsonAny fooBar1)
    {
        writer.WritePropertyName(_MenesFooBar1EncodedJsonPropertyName);
        fooBar1.WriteTo(writer);
    }
    if (this.fooBar2 is Menes.JsonAny fooBar2)
    {
        writer.WritePropertyName(_MenesFooBar2EncodedJsonPropertyName);
        fooBar2.WriteTo(writer);
    }
    if (this.fooBar3 is Menes.JsonAny fooBar3)
    {
        writer.WritePropertyName(_MenesFooBar3EncodedJsonPropertyName);
        fooBar3.WriteTo(writer);
    }
    if (this.fooBar4 is Menes.JsonAny fooBar4)
    {
        writer.WritePropertyName(_MenesFooBar4EncodedJsonPropertyName);
        fooBar4.WriteTo(writer);
    }
    if (this.fooBar5 is Menes.JsonAny fooBar5)
    {
        writer.WritePropertyName(_MenesFooBar5EncodedJsonPropertyName);
        fooBar5.WriteTo(writer);
    }
    foreach (var property in this._menesAdditionalPropertiesBacking)
    {
        property.WriteTo(writer);
    }
writer.WriteEndObject();
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
/// <inheritdoc/>
public bool HasProperty(System.ReadOnlySpan<char> propertyName)
{
    if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
    {
        return true;
    }
    else
    {
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBarJsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar1JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar2JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar3JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar4JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar5JsonPropertyName.Span))
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
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBarJsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBar1JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBar2JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBar3JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBar4JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBar5JsonPropertyName.Span))
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
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBarUtf8JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar1Utf8JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar2Utf8JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar3Utf8JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar4Utf8JsonPropertyName.Span))
    {
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar5Utf8JsonPropertyName.Span))
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
    where T : struct, Menes.IJsonValue
{
    if (this.HasJsonElement)
    {
        if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
        {
            property = Menes.JsonValue.As<T>(value);
            return true;
        }
        property = default;
        return false;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBarJsonPropertyName.Span))
    {
        property = this.FooBar.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar1JsonPropertyName.Span))
    {
        property = this.FooBar1.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar2JsonPropertyName.Span))
    {
        property = this.FooBar2.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar3JsonPropertyName.Span))
    {
        property = this.FooBar3.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar4JsonPropertyName.Span))
    {
        property = this.FooBar4.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar5JsonPropertyName.Span))
    {
        property = this.FooBar5.As<T>();
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
    where T : struct, Menes.IJsonValue
{
    if (this.HasJsonElement)
    {
        if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
        {
            property = Menes.JsonValue.As<T>(value);
            return true;
        }
        property = default;
        return false;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBarJsonPropertyName.Span))
    {
        property = this.FooBar.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBar1JsonPropertyName.Span))
    {
        property = this.FooBar1.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBar2JsonPropertyName.Span))
    {
        property = this.FooBar2.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBar3JsonPropertyName.Span))
    {
        property = this.FooBar3.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBar4JsonPropertyName.Span))
    {
        property = this.FooBar4.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesFooBar5JsonPropertyName.Span))
    {
        property = this.FooBar5.As<T>();
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
    where T : struct, Menes.IJsonValue
{
    if (this.HasJsonElement)
    {
        if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))
        {
            property = Menes.JsonValue.As<T>(value);
            return true;
        }
        property = default;
        return false;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBarUtf8JsonPropertyName.Span))
    {
        property = this.FooBar.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar1Utf8JsonPropertyName.Span))
    {
        property = this.FooBar1.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar2Utf8JsonPropertyName.Span))
    {
        property = this.FooBar2.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar3Utf8JsonPropertyName.Span))
    {
        property = this.FooBar3.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar4Utf8JsonPropertyName.Span))
    {
        property = this.FooBar4.As<T>();
        return true;
    }
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar5Utf8JsonPropertyName.Span))
    {
        property = this.FooBar5.As<T>();
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
public bool TryGetPropertyAtIndex(int index, out Menes.IProperty result)
{
    var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<RootEntity> prop);
    result = prop;
    return rc;
}
public RootEntity RemoveProperty(string propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public RootEntity RemoveProperty(System.ReadOnlySpan<char> propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public RootEntity RemoveProperty(System.ReadOnlySpan<byte> propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public RootEntity SetProperty<T>(string name, T value)
where T : struct, Menes.IJsonValue
{
    var propertyName = System.MemoryExtensions.AsSpan(name);
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBarJsonPropertyName.Span))
{
    return this.WithFooBar(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar1JsonPropertyName.Span))
{
    return this.WithFooBar1(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar2JsonPropertyName.Span))
{
    return this.WithFooBar2(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar3JsonPropertyName.Span))
{
    return this.WithFooBar3(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar4JsonPropertyName.Span))
{
    return this.WithFooBar4(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar5JsonPropertyName.Span))
{
    return this.WithFooBar5(value.As<Menes.JsonAny>());
}
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
bool added = false;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (!property.NameEquals(propertyName))
    {
        arrayBuilder.Add(property);
    }
    else
    {
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
        added = true;
    }
}
if (!added)
{
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
}
return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
return this;
}
public RootEntity SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
where T : struct, Menes.IJsonValue
{
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBarJsonPropertyName.Span))
{
    return this.WithFooBar(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar1JsonPropertyName.Span))
{
    return this.WithFooBar1(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar2JsonPropertyName.Span))
{
    return this.WithFooBar2(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar3JsonPropertyName.Span))
{
    return this.WithFooBar3(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar4JsonPropertyName.Span))
{
    return this.WithFooBar4(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar5JsonPropertyName.Span))
{
    return this.WithFooBar5(value.As<Menes.JsonAny>());
}
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
bool added = false;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (!property.NameEquals(propertyName))
    {
        arrayBuilder.Add(property);
    }
    else
    {
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
        added = true;
    }
}
if (!added)
{
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
}
return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
return this;
}
public RootEntity SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
where T : struct, Menes.IJsonValue
{
    System.Span<char> name = stackalloc char[utf8Name.Length];
    int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
    var propertyName = name.Slice(0, writtenCount);
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBarJsonPropertyName.Span))
{
    return this.WithFooBar(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar1JsonPropertyName.Span))
{
    return this.WithFooBar1(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar2JsonPropertyName.Span))
{
    return this.WithFooBar2(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar3JsonPropertyName.Span))
{
    return this.WithFooBar3(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar4JsonPropertyName.Span))
{
    return this.WithFooBar4(value.As<Menes.JsonAny>());
}
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesFooBar5JsonPropertyName.Span))
{
    return this.WithFooBar5(value.As<Menes.JsonAny>());
}
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<Menes.JsonAny>>();
bool added = false;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (!property.NameEquals(propertyName))
    {
        arrayBuilder.Add(property);
    }
    else
    {
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
        added = true;
    }
}
if (!added)
{
        arrayBuilder.Add(new Menes.AdditionalProperty<Menes.JsonAny>(propertyName, value.As<Menes.JsonAny>()));
}
return this.WithAdditionalProperties(arrayBuilder.ToImmutable());
return this;
}
public RootEntity.MenesPropertyEnumerator GetEnumerator()
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
System.Collections.Generic.IEnumerator<Menes.Property<RootEntity>> System.Collections.Generic.IEnumerable<Menes.Property<RootEntity>>.GetEnumerator()
{
    return this.GetEnumerator();
}
public RootEntity WithFooBar(Menes.JsonAny value)
{
    return new RootEntity(value, this.fooBar1, this.fooBar2, this.fooBar3, this.fooBar4, this.fooBar5, this._menesAdditionalPropertiesBacking);
}
public RootEntity WithFooBar1(Menes.JsonAny value)
{
    return new RootEntity(this.fooBar, value, this.fooBar2, this.fooBar3, this.fooBar4, this.fooBar5, this._menesAdditionalPropertiesBacking);
}
public RootEntity WithFooBar2(Menes.JsonAny value)
{
    return new RootEntity(this.fooBar, this.fooBar1, value, this.fooBar3, this.fooBar4, this.fooBar5, this._menesAdditionalPropertiesBacking);
}
public RootEntity WithFooBar3(Menes.JsonAny value)
{
    return new RootEntity(this.fooBar, this.fooBar1, this.fooBar2, value, this.fooBar4, this.fooBar5, this._menesAdditionalPropertiesBacking);
}
public RootEntity WithFooBar4(Menes.JsonAny value)
{
    return new RootEntity(this.fooBar, this.fooBar1, this.fooBar2, this.fooBar3, value, this.fooBar5, this._menesAdditionalPropertiesBacking);
}
public RootEntity WithFooBar5(Menes.JsonAny value)
{
    return new RootEntity(this.fooBar, this.fooBar1, this.fooBar2, this.fooBar3, this.fooBar4, value, this._menesAdditionalPropertiesBacking);
}
private TPropertyValue GetPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
    where TPropertyValue : struct, Menes.IJsonValue
{
    return this.GetOptionalPropertyFromJsonElement<TPropertyValue>(propertyName) ?? default;
}
private TPropertyValue? GetOptionalPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)
    where TPropertyValue : struct, Menes.IJsonValue
{
    return this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object ?
         (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
             ? Menes.JsonValue.As<TPropertyValue>(property)
             : null)
         : null;
}
private bool AllBackingFieldsAreNull()
{
if (this.fooBar is not null)
{
    return false;
}
if (this.fooBar1 is not null)
{
    return false;
}
if (this.fooBar2 is not null)
{
    return false;
}
if (this.fooBar3 is not null)
{
    return false;
}
if (this.fooBar4 is not null)
{
    return false;
}
if (this.fooBar5 is not null)
{
    return false;
}
if (this._menesAdditionalPropertiesBacking.Length > 0)
{
    return false;
}
return true;
}
/// <inheritdoc />
private bool TryGetPropertyAtIndex(int index, out Menes.Property<RootEntity> result)
{
if (this.HasJsonElement)
{
    int jsonPropertyIndex = 0;
    foreach (var property in this.JsonElement.EnumerateObject())
    {
        if (jsonPropertyIndex == index)
        {
            result = new Menes.Property<RootEntity>(property);
            return true;
        }
        jsonPropertyIndex++;
    }
}
int currentIndex = 0;
    if (currentIndex == index)
    {
        result = new Menes.Property<RootEntity>(this, _MenesFooBarJsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<RootEntity>(this, _MenesFooBar1JsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<RootEntity>(this, _MenesFooBar2JsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<RootEntity>(this, _MenesFooBar3JsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<RootEntity>(this, _MenesFooBar4JsonPropertyName);
      return true;
    }
    currentIndex++;
    if (currentIndex == index)
    {
        result = new Menes.Property<RootEntity>(this, _MenesFooBar5JsonPropertyName);
      return true;
    }
    currentIndex++;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (currentIndex == index)
    {
        result = new Menes.Property<RootEntity>(this, property.NameAsMemory);
        return true;
    }
    currentIndex++;
}
    result = default;;
    return false;
}
private RootEntity WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
{
    return new RootEntity(this.fooBar, this.fooBar1, this.fooBar2, this.fooBar3, this.fooBar4, this.fooBar5, value);
}
/// <summary>
/// An enumerator for the properties in a <see cref="RootEntity"/>.
/// </summary>
public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<RootEntity>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<RootEntity>>, System.Collections.IEnumerator
{
    private RootEntity instance;
    private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    private int propertyCount;
    internal MenesPropertyEnumerator(RootEntity instance)
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
    public Menes.Property<RootEntity> Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Menes.Property<RootEntity>(this.jsonEnumerator.Current);
            }
            else if (this.index >= 0)
            {
                if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<RootEntity> result))
                {
                    return result;
                }
                throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
            }
            return new Menes.Property<RootEntity>(this.instance, default);
        }
    }
    /// <inheritdoc/>
    object System.Collections.IEnumerator.Current => this.Current;
    /// <summary>
    /// Returns a fresh copy of the enumerator
    /// </summary>
    /// <returns>An enumerator for the properties in a <see cref="RootEntity"/>.</returns>
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
    System.Collections.Generic.IEnumerator<Menes.Property<RootEntity>> System.Collections.Generic.IEnumerable<Menes.Property<RootEntity>>.GetEnumerator()
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
