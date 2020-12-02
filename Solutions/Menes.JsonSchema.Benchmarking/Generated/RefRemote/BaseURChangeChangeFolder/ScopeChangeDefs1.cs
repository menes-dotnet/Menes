// <copyright file="ScopeChangeDefs1.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace RefRemoteFeature.BaseURChangeChangeFolder
{
public readonly struct ScopeChangeDefs1 : Menes.IJsonObject<ScopeChangeDefs1>
{
public static readonly ScopeChangeDefs1 Null = default(ScopeChangeDefs1);
private static readonly System.ReadOnlyMemory<char> _MenesListJsonPropertyName = System.MemoryExtensions.AsMemory("list");
private static readonly System.ReadOnlyMemory<byte>  _MenesListUtf8JsonPropertyName = new byte[] { 108, 105, 115, 116 };
private static readonly  System.Text.Json.JsonEncodedText _MenesListEncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_MenesListUtf8JsonPropertyName.Span);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
private readonly ScopeChangeDefs1.BaseUriChangeFolderArray? list;
public ScopeChangeDefs1(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
this.list = default;
}
public ScopeChangeDefs1(ScopeChangeDefs1.BaseUriChangeFolderArray? list = null)
{
    this._menesJsonElementBacking = default;
this.list = list;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
}
private ScopeChangeDefs1(ScopeChangeDefs1.BaseUriChangeFolderArray? list, in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
{
    this._menesJsonElementBacking = default;
this.list = list;
this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
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
public bool IsString => false;
/// <inheritdoc />
public bool IsObject => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object) || (!this.HasJsonElement && !this.AllBackingFieldsAreNull());
/// <inheritdoc />
public bool IsBoolean => false;
/// <inheritdoc />
public bool IsArray => false;
/// <inheritdoc />
public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
/// <inheritdoc />
public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
public ScopeChangeDefs1.BaseUriChangeFolderArray? List => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<ScopeChangeDefs1.BaseUriChangeFolderArray>(_MenesListUtf8JsonPropertyName.Span) : this.list;
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
           return 1 + this._menesAdditionalPropertiesBacking.Length;
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
if (!this.IsObject)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of object");
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
if (this.IsObject)
{
    result = result.WithLocalProperty("list");
    if (this.TryGetProperty<ScopeChangeDefs1.BaseUriChangeFolderArray>(_MenesListJsonPropertyName.Span, out ScopeChangeDefs1.BaseUriChangeFolderArray value0))
    {
        result = value0.Validate(result, level);
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
writer.WriteStartObject();
    if (this.list is ScopeChangeDefs1.BaseUriChangeFolderArray list)
    {
        writer.WritePropertyName(_MenesListEncodedJsonPropertyName);
        list.WriteTo(writer);
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
if (typeof(T) == typeof(ScopeChangeDefs1))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<ScopeChangeDefs1, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(ScopeChangeDefs1))
{
    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
}
    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
}
/// <inheritdoc/>
public bool Equals<T>(in T other)
    where T : struct, Menes.IJsonValue
{
    if (!other.IsObject)
    {
        return false;
    }
    var otherObject = Corvus.Extensions.CastTo<Menes.IJsonObject>.From(other);
MenesPropertyEnumerator firstEnumerator = this.EnumerateObject();
if (this.PropertyCount != otherObject.PropertyCount)
{
    return false;
}
while (firstEnumerator.MoveNext())
{
    if (!otherObject.TryGetProperty<Menes.JsonAny>(firstEnumerator.Current.NameAsMemory.Span, out Menes.JsonAny otherProperty))
    {
        return false;
    }
    if (!firstEnumerator.Current.Value<Menes.JsonAny>().Equals(otherProperty))
    {
        return false;
    }
}
return true;
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
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesListJsonPropertyName.Span))
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
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesListJsonPropertyName.Span))
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
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesListUtf8JsonPropertyName.Span))
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
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesListJsonPropertyName.Span))
    {
        if (!(this.List?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
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
    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _MenesListJsonPropertyName.Span))
    {
        if (!(this.List?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
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
    if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesListUtf8JsonPropertyName.Span))
    {
        if (!(this.List?.As<T>() is T result))
        {
            property = default;
            return false;
        }
        property = result;
        return true;
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
    var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<ScopeChangeDefs1> prop);
    result = prop;
    return rc;
}
public ScopeChangeDefs1 RemoveProperty(string propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public ScopeChangeDefs1 RemoveProperty(System.ReadOnlySpan<char> propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public ScopeChangeDefs1 RemoveProperty(System.ReadOnlySpan<byte> propertyName)
{
    return this.SetProperty(propertyName, Menes.JsonNull.Instance);
}
public ScopeChangeDefs1 SetProperty<T>(string name, T value)
where T : struct, Menes.IJsonValue
{
    var propertyName = System.MemoryExtensions.AsSpan(name);
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesListJsonPropertyName.Span))
{
    return this.WithList(value.As<ScopeChangeDefs1.BaseUriChangeFolderArray>());
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
public ScopeChangeDefs1 SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)
where T : struct, Menes.IJsonValue
{
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesListJsonPropertyName.Span))
{
    return this.WithList(value.As<ScopeChangeDefs1.BaseUriChangeFolderArray>());
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
public ScopeChangeDefs1 SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)
where T : struct, Menes.IJsonValue
{
    System.Span<char> name = stackalloc char[utf8Name.Length];
    int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);
    var propertyName = name.Slice(0, writtenCount);
if (System.MemoryExtensions.SequenceEqual(propertyName, _MenesListJsonPropertyName.Span))
{
    return this.WithList(value.As<ScopeChangeDefs1.BaseUriChangeFolderArray>());
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
public ScopeChangeDefs1.MenesPropertyEnumerator GetEnumerator()
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
System.Collections.Generic.IEnumerator<Menes.Property<ScopeChangeDefs1>> System.Collections.Generic.IEnumerable<Menes.Property<ScopeChangeDefs1>>.GetEnumerator()
{
    return this.GetEnumerator();
}
public ScopeChangeDefs1 WithList(ScopeChangeDefs1.BaseUriChangeFolderArray value)
{
    return new ScopeChangeDefs1(value, this._menesAdditionalPropertiesBacking);
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
if (this.list is not null)
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
private bool TryGetPropertyAtIndex(int index, out Menes.Property<ScopeChangeDefs1> result)
{
if (this.HasJsonElement)
{
    int jsonPropertyIndex = 0;
    foreach (var property in this.JsonElement.EnumerateObject())
    {
        if (jsonPropertyIndex == index)
        {
            result = new Menes.Property<ScopeChangeDefs1>(property);
            return true;
        }
        jsonPropertyIndex++;
    }
}
int currentIndex = 0;
    if (currentIndex == index)
    {
        result = new Menes.Property<ScopeChangeDefs1>(this, _MenesListJsonPropertyName);
      return true;
    }
    currentIndex++;
foreach (var property in this._menesAdditionalPropertiesBacking)
{
    if (currentIndex == index)
    {
        result = new Menes.Property<ScopeChangeDefs1>(this, property.NameAsMemory);
        return true;
    }
    currentIndex++;
}
    result = default;;
    return false;
}
private ScopeChangeDefs1 WithAdditionalProperties(System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> value)
{
    return new ScopeChangeDefs1(this.list, value);
}
public readonly struct BaseUriChangeFolderArray : Menes.IJsonValue, Menes.IJsonArray<BaseUriChangeFolderArray, Menes.JsonInteger>
{
public static readonly BaseUriChangeFolderArray Null = default(BaseUriChangeFolderArray);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>? _menesArrayValueBacking;
public BaseUriChangeFolderArray(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesArrayValueBacking = default;
}
public BaseUriChangeFolderArray(System.Collections.Immutable.ImmutableArray<Menes.JsonInteger> value)
{
    this._menesArrayValueBacking = value;
    this._menesJsonElementBacking = default;
}
public static implicit operator BaseUriChangeFolderArray(System.Collections.Immutable.ImmutableArray<Menes.JsonInteger> items)
{
    return new ScopeChangeDefs1.BaseUriChangeFolderArray(items);
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
public bool IsString => false;
/// <inheritdoc />
public bool IsObject => false;
/// <inheritdoc />
public bool IsBoolean => false;
/// <inheritdoc />
public bool IsArray => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Array) || (!this.HasJsonElement && this._menesArrayValueBacking is not null);
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
if (!this.IsArray)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of array");
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
if (!this.IsArray)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.1.1. type - expected an array type.");
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
if (this.IsArray)
{
int arrayLength = 0;
var arrayEnumerator = this.EnumerateArray();
while (arrayEnumerator.MoveNext())
{
result = arrayEnumerator.Current.As<Menes.JsonInteger>().Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
result = result.WithLocalItemIndex(arrayLength);
   arrayLength++;
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
writer.WriteStartArray();
foreach (var item in this._menesArrayValueBacking)
{
    item.WriteTo(writer);
}
writer.WriteEndArray();
}
/// <inheritdoc />
public T As<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(BaseUriChangeFolderArray))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<BaseUriChangeFolderArray, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(ScopeChangeDefs1.BaseUriChangeFolderArray))
{
    return this.Validate(Menes.ValidationContext.ValidContext).IsValid;
}
    return this.As<T>().Validate(Menes.ValidationContext.ValidContext).IsValid;
}
/// <inheritdoc/>
public bool Equals<T>(in T other)
    where T : struct, Menes.IJsonValue
{
    if (!other.IsArray)
    {
        return false;
    }
MenesArrayEnumerator firstEnumerator = this.EnumerateArray();
Menes.JsonAny.MenesArrayEnumerator secondEnumerator = other.As<Menes.JsonAny>().EnumerateArray();
while (firstEnumerator.MoveNext())
{
    if (!secondEnumerator.MoveNext())
    {
        // We've run out of items in the second enumerator.
        return false;
    }
    if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
    {
        return false;
    }
}
// If we have extra items in the second enumerator, return false.
return !secondEnumerator.MoveNext();
}
public ScopeChangeDefs1.BaseUriChangeFolderArray.MenesArrayEnumerator GetEnumerator()
{
    return new ScopeChangeDefs1.BaseUriChangeFolderArray.MenesArrayEnumerator(this);
}
public ScopeChangeDefs1.BaseUriChangeFolderArray.MenesArrayEnumerator EnumerateArray()
{
    return new ScopeChangeDefs1.BaseUriChangeFolderArray.MenesArrayEnumerator(this);
}
System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
{
    return this.GetEnumerator();
}
System.Collections.Generic.IEnumerator<Menes.JsonInteger> System.Collections.Generic.IEnumerable<Menes.JsonInteger>.GetEnumerator()
{
    return this.GetEnumerator();
}
/// <inheritdoc />
public int GetArrayLength()
{
    if (this.HasJsonElement)
    {
        return this.JsonElement.GetArrayLength();
    }
    return this._menesArrayValueBacking?.Length ?? 0;
}
/// <inheritdoc />
public T GetItemAtIndex<T>(int index)
    where T : struct, Menes.IJsonValue
{
    if (this.HasJsonElement)
    {
        int currentIndex = 0;
        foreach (var item in this.JsonElement.EnumerateArray())
        {
            if (currentIndex == index)
            {
                return Menes.JsonValue.As<T>(item);
            }
        }
        throw new System.IndexOutOfRangeException();
    }
    if (this._menesArrayValueBacking is not null)
    {
        return this._menesArrayValueBacking.Value[index].As<T>();
    }
    return default;
}
public BaseUriChangeFolderArray Add<T1>(T1 item1)
    where T1 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonInteger>());
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray Add<T1, T2>(T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonInteger>());
    arrayBuilder.Add(item2.As<Menes.JsonInteger>());
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonInteger>());
    arrayBuilder.Add(item2.As<Menes.JsonInteger>());
    arrayBuilder.Add(item3.As<Menes.JsonInteger>());
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonInteger>());
    arrayBuilder.Add(item2.As<Menes.JsonInteger>());
    arrayBuilder.Add(item3.As<Menes.JsonInteger>());
    arrayBuilder.Add(item4.As<Menes.JsonInteger>());
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray Add<T>(params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<Menes.JsonInteger>());
}
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray Insert<T>(int index, T item1)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonInteger>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray Insert<T1, T2>(int index, T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonInteger>());
    arrayBuilder.Add(item2.As<Menes.JsonInteger>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonInteger>());
    arrayBuilder.Add(item2.As<Menes.JsonInteger>());
    arrayBuilder.Add(item3.As<Menes.JsonInteger>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonInteger>());
    arrayBuilder.Add(item2.As<Menes.JsonInteger>());
    arrayBuilder.Add(item3.As<Menes.JsonInteger>());
    arrayBuilder.Add(item4.As<Menes.JsonInteger>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray Insert<T>(int index, params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<Menes.JsonInteger>());
}
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray RemoveAt(int index)
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
int currentIndex = 0;
bool removed = false;
foreach(var item in this._menesArrayValueBacking)
{
    if (currentIndex != index)
    {
        arrayBuilder.Add(item);
    }
    else
    {
        removed = true;
    }
    currentIndex++;
}
if (!removed)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
public BaseUriChangeFolderArray RemoveIf(System.Predicate<Menes.JsonInteger> condition)
{
    return this.RemoveIf<Menes.JsonInteger>(condition);
}
public BaseUriChangeFolderArray RemoveIf<T>(System.Predicate<T> condition)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
foreach(var item in this._menesArrayValueBacking)
{
    if (!condition(item.As<T>()))
    {
        arrayBuilder.Add(item);
    }
}
return new ScopeChangeDefs1.BaseUriChangeFolderArray(arrayBuilder.ToImmutable());
}
private bool AllBackingFieldsAreNull()
{
if (this._menesArrayValueBacking is not null)
{
    return false;
}
return true;
}
/// <summary>
/// An enumerator for the array values in a <see cref="BaseUriChangeFolderArray"/>.
/// </summary>
public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonInteger>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonInteger>, System.Collections.IEnumerator
{
    private BaseUriChangeFolderArray instance;
    private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    internal MenesArrayEnumerator(BaseUriChangeFolderArray instance)
    {
        this.instance = instance;
        if (this.instance.HasJsonElement)
        {
            this.index = -2;
            this.hasJsonEnumerator = true;
            this.jsonEnumerator = this.instance.JsonElement.EnumerateArray();
        }
        else
        {
            this.index = -1;
            this.hasJsonEnumerator = false;
            this.jsonEnumerator = default;
        }
    }
    /// <inheritdoc/>
    public Menes.JsonInteger Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Menes.JsonInteger(this.jsonEnumerator.Current);
            }
            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonInteger> array && this.index >= 0 && this.index < array.Length)
            {
                return array[this.index];
            }
            return default;
        }
    }
    /// <inheritdoc/>
    object System.Collections.IEnumerator.Current => this.Current;
    /// <summary>
    /// Returns a fresh copy of the enumerator
    /// </summary>
    /// <returns>An enumerator for the array values in a <see cref="BaseUriChangeFolderArray"/>.</returns>
    public MenesArrayEnumerator GetEnumerator()
    {
        MenesArrayEnumerator result = this;
        result.Reset();
        return result;
    }
    /// <inheritdoc/>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    /// <inheritdoc/>
    System.Collections.Generic.IEnumerator<Menes.JsonInteger> System.Collections.Generic.IEnumerable<Menes.JsonInteger>.GetEnumerator()
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
        else
        {
            this.index = -1;
        }
    }
    /// <inheritdoc/>
    public bool MoveNext()
    {
        if (this.hasJsonEnumerator)
        {
            return this.jsonEnumerator.MoveNext();
        }
        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonInteger> array && this.index + 1 < array.Length)
        {
            this.index++;
            return true;
        }
        return false;
    }
}
}
/// <summary>
/// An enumerator for the properties in a <see cref="ScopeChangeDefs1"/>.
/// </summary>
public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<ScopeChangeDefs1>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<ScopeChangeDefs1>>, System.Collections.IEnumerator
{
    private ScopeChangeDefs1 instance;
    private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    private int propertyCount;
    internal MenesPropertyEnumerator(ScopeChangeDefs1 instance)
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
    public Menes.Property<ScopeChangeDefs1> Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Menes.Property<ScopeChangeDefs1>(this.jsonEnumerator.Current);
            }
            else if (this.index >= 0)
            {
                if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<ScopeChangeDefs1> result))
                {
                    return result;
                }
                throw new System.InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
            }
            return new Menes.Property<ScopeChangeDefs1>(this.instance, default);
        }
    }
    /// <inheritdoc/>
    object System.Collections.IEnumerator.Current => this.Current;
    /// <summary>
    /// Returns a fresh copy of the enumerator
    /// </summary>
    /// <returns>An enumerator for the properties in a <see cref="ScopeChangeDefs1"/>.</returns>
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
    System.Collections.Generic.IEnumerator<Menes.Property<ScopeChangeDefs1>> System.Collections.Generic.IEnumerable<Menes.Property<ScopeChangeDefs1>>.GetEnumerator()
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
