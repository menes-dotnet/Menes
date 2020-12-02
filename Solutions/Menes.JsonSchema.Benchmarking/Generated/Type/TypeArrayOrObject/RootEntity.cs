// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace TypeFeature.TypeArrayOrObject
{
public readonly struct RootEntity : Menes.IJsonObject<RootEntity>, Menes.IJsonArray<RootEntity, Menes.JsonAny>
{
public static readonly RootEntity Null = default(RootEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking;
private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? _menesArrayValueBacking;
public RootEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
this._menesArrayValueBacking = default;
}
public RootEntity(System.Collections.Immutable.ImmutableArray<Menes.JsonAny> value)
{
    this._menesArrayValueBacking = value;
    this._menesJsonElementBacking = default;
this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>>.Empty;
}
private RootEntity(in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<Menes.JsonAny>> _menesAdditionalPropertiesBacking)
{
    this._menesJsonElementBacking = default;
this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;
this._menesArrayValueBacking = default;
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
public bool IsArray => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Array) || (!this.HasJsonElement && this._menesArrayValueBacking is not null);
/// <inheritdoc />
public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;
/// <inheritdoc />
public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;
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
           return this._menesAdditionalPropertiesBacking.Length;
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
if (!this.IsArray && !this.IsObject)
{
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.1.1.  type - item must be one of array,object");
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
writer.WriteStartObject();
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
public RootEntity Add<T1>(T1 item1)
    where T1 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonAny>());
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Add<T1, T2>(T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonAny>());
    arrayBuilder.Add(item2.As<Menes.JsonAny>());
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonAny>());
    arrayBuilder.Add(item2.As<Menes.JsonAny>());
    arrayBuilder.Add(item3.As<Menes.JsonAny>());
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<Menes.JsonAny>());
    arrayBuilder.Add(item2.As<Menes.JsonAny>());
    arrayBuilder.Add(item3.As<Menes.JsonAny>());
    arrayBuilder.Add(item4.As<Menes.JsonAny>());
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Add<T>(params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<Menes.JsonAny>());
}
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Insert<T>(int index, T item1)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonAny>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Insert<T1, T2>(int index, T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonAny>());
    arrayBuilder.Add(item2.As<Menes.JsonAny>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonAny>());
    arrayBuilder.Add(item2.As<Menes.JsonAny>());
    arrayBuilder.Add(item3.As<Menes.JsonAny>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<Menes.JsonAny>());
    arrayBuilder.Add(item2.As<Menes.JsonAny>());
    arrayBuilder.Add(item3.As<Menes.JsonAny>());
    arrayBuilder.Add(item4.As<Menes.JsonAny>());
    inserted = true;
}
arrayBuilder.Add(oldItem);
currentIndex++;
}
if (!inserted)
{
    throw new System.IndexOutOfRangeException($"The given index {index} was out of range.");
}
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Insert<T>(int index, params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<Menes.JsonAny>());
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
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity RemoveAt(int index)
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
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
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity RemoveIf(System.Predicate<Menes.JsonAny> condition)
{
    return this.RemoveIf<Menes.JsonAny>(condition);
}
public RootEntity RemoveIf<T>(System.Predicate<T> condition)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
foreach(var item in this._menesArrayValueBacking)
{
    if (!condition(item.As<T>()))
    {
        arrayBuilder.Add(item);
    }
}
return new RootEntity(arrayBuilder.ToImmutable());
}
/// <summary>
/// Enumerate the array.
/// </summary>
/// <returns>An array enumerator.</returns>
public MenesArrayEnumerator EnumerateArray()
{
    return new MenesArrayEnumerator(this);
}
/// <summary>
/// Enumerate the properties in the object.
/// </summary>
/// <returns>The object enumerator.</returns>
public MenesPropertyEnumerator EnumerateObject()
{
    return new MenesPropertyEnumerator(this);
}
/// <inheritdoc/>
public System.Collections.IEnumerator GetEnumerator()
{
    if (this.IsObject)
    {
        return this.EnumerateObject();
    }
    if (this.IsArray)
    {
        return this.EnumerateArray();
    }
    throw new System.InvalidOperationException("Cannot enumerate a non array or object type.");
}
System.Collections.Generic.IEnumerator<Menes.Property<RootEntity>> System.Collections.Generic.IEnumerable<Menes.Property<RootEntity>>.GetEnumerator()
{
    return this.EnumerateObject();
}
System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
{
    return this.EnumerateArray();
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
if (this._menesAdditionalPropertiesBacking.Length > 0)
{
    return false;
}
if (this._menesArrayValueBacking is not null)
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
    return new RootEntity(value);
}
/// <summary>
/// An enumerator for the array values in a <see cref="RootEntity"/>.
/// </summary>
public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.JsonAny>, System.Collections.IEnumerator
{
    private RootEntity instance;
    private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;
    private bool hasJsonEnumerator;
    private int index;
    internal MenesArrayEnumerator(RootEntity instance)
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
    public Menes.JsonAny Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new Menes.JsonAny(this.jsonEnumerator.Current);
            }
            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index >= 0 && this.index < array.Length)
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
    /// <returns>An enumerator for the array values in a <see cref="RootEntity"/>.</returns>
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
    System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
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
        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonAny> array && this.index + 1 < array.Length)
        {
            this.index++;
            return true;
        }
        return false;
    }
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
