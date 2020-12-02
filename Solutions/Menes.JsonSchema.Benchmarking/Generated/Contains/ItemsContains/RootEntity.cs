// <copyright file="RootEntity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace ContainsFeature.ItemsContains
{
public readonly struct RootEntity : Menes.IJsonValue, Menes.IJsonArray<RootEntity, RootEntity.ItemsEntity>
{
public static readonly RootEntity Null = default(RootEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
private readonly System.Collections.Immutable.ImmutableArray<RootEntity.ItemsEntity>? _menesArrayValueBacking;
public RootEntity(System.Text.Json.JsonElement jsonElement)
{
    this._menesJsonElementBacking = jsonElement;
this._menesArrayValueBacking = default;
}
public RootEntity(System.Collections.Immutable.ImmutableArray<RootEntity.ItemsEntity> value)
{
    this._menesArrayValueBacking = value;
    this._menesJsonElementBacking = default;
}
public static implicit operator RootEntity(System.Collections.Immutable.ImmutableArray<RootEntity.ItemsEntity> items)
{
    return new RootEntity(items);
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
if (this.IsArray)
{
int arrayLength = 0;
int containsCount = 0;
var arrayEnumerator = this.EnumerateArray();
while (arrayEnumerator.MoveNext())
{
var containsResult = arrayEnumerator.Current.As<RootEntity.ContainsEntity>().Validate(result.CreateChildContext(), level);
if (containsResult.IsValid)
{
    containsCount++;
}
result = arrayEnumerator.Current.As<RootEntity.ItemsEntity>().Validate(result, level);
        if (level == Menes.ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }
result = result.WithLocalItemIndex(arrayLength);
   arrayLength++;
}
        if (containsCount == 0)
        {
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "9.3.1.4.  contains - no items found");
}
else
{
    result = result.WithResult(isValid: false);
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
public RootEntity.MenesArrayEnumerator GetEnumerator()
{
    return new RootEntity.MenesArrayEnumerator(this);
}
public RootEntity.MenesArrayEnumerator EnumerateArray()
{
    return new RootEntity.MenesArrayEnumerator(this);
}
System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
{
    return this.GetEnumerator();
}
System.Collections.Generic.IEnumerator<RootEntity.ItemsEntity> System.Collections.Generic.IEnumerable<RootEntity.ItemsEntity>.GetEnumerator()
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
public RootEntity Add<T1>(T1 item1)
    where T1 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<RootEntity.ItemsEntity>());
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Add<T1, T2>(T1 item1, T2 item2)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item2.As<RootEntity.ItemsEntity>());
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item2.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item3.As<RootEntity.ItemsEntity>());
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
    where T1 : struct, Menes.IJsonValue
    where T2 : struct, Menes.IJsonValue
    where T3 : struct, Menes.IJsonValue
    where T4 : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
    arrayBuilder.Add(item1.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item2.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item3.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item4.As<RootEntity.ItemsEntity>());
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Add<T>(params T[] items)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
foreach(var oldItem in this._menesArrayValueBacking)
{
arrayBuilder.Add(oldItem);
}
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<RootEntity.ItemsEntity>());
}
return new RootEntity(arrayBuilder.ToImmutable());
}
public RootEntity Insert<T>(int index, T item1)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<RootEntity.ItemsEntity>());
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
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item2.As<RootEntity.ItemsEntity>());
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
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item2.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item3.As<RootEntity.ItemsEntity>());
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
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
    arrayBuilder.Add(item1.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item2.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item3.As<RootEntity.ItemsEntity>());
    arrayBuilder.Add(item4.As<RootEntity.ItemsEntity>());
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
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
int currentIndex = 0;
bool inserted = false;
foreach(var oldItem in this._menesArrayValueBacking)
{
if (currentIndex == index)
{
foreach (var item1 in items)
{
    arrayBuilder.Add(item1.As<RootEntity.ItemsEntity>());
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
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
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
public RootEntity RemoveIf(System.Predicate<RootEntity.ItemsEntity> condition)
{
    return this.RemoveIf<RootEntity.ItemsEntity>(condition);
}
public RootEntity RemoveIf<T>(System.Predicate<T> condition)
    where T : struct, Menes.IJsonValue
{
var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<RootEntity.ItemsEntity>();
foreach(var item in this._menesArrayValueBacking)
{
    if (!condition(item.As<T>()))
    {
        arrayBuilder.Add(item);
    }
}
return new RootEntity(arrayBuilder.ToImmutable());
}
private bool AllBackingFieldsAreNull()
{
if (this._menesArrayValueBacking is not null)
{
    return false;
}
return true;
}
public readonly struct ItemsEntity : Menes.IJsonValue
{
public static readonly ItemsEntity Null = default(ItemsEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
public ItemsEntity(System.Text.Json.JsonElement jsonElement)
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
if (this.IsNumber)
{
    var number = (double)this.As<Menes.JsonNumber>();
    if (System.Math.Abs(System.Math.IEEERemainder((double)number, (double)2)) > 1.0E-18)
    {
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.2.1.  multipleOf - item must be a multiple of 2");
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
}
/// <inheritdoc />
public T As<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(ItemsEntity))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<ItemsEntity, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(RootEntity.ItemsEntity))
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
}
public readonly struct ContainsEntity : Menes.IJsonValue
{
public static readonly ContainsEntity Null = default(ContainsEntity);
private readonly System.Text.Json.JsonElement _menesJsonElementBacking;
public ContainsEntity(System.Text.Json.JsonElement jsonElement)
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
if (this.IsNumber)
{
    var number = (double)this.As<Menes.JsonNumber>();
    if (System.Math.Abs(System.Math.IEEERemainder((double)number, (double)3)) > 1.0E-18)
    {
if (level >= Menes.ValidationLevel.Basic)
{
    result = result.WithResult(isValid: false, message: "6.2.1.  multipleOf - item must be a multiple of 3");
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
}
/// <inheritdoc />
public T As<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(ContainsEntity))
{
    return Corvus.Extensions.CastTo<T>.From(this);
}
    return Menes.JsonValue.As<ContainsEntity, T>(this);
}
/// <inheritdoc />
public bool Is<T>()
    where T : struct, Menes.IJsonValue
{
if (typeof(T) == typeof(RootEntity.ContainsEntity))
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
}
/// <summary>
/// An enumerator for the array values in a <see cref="RootEntity"/>.
/// </summary>
public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<RootEntity.ItemsEntity>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<RootEntity.ItemsEntity>, System.Collections.IEnumerator
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
    public RootEntity.ItemsEntity Current
    {
        get
        {
            if (this.hasJsonEnumerator)
            {
                return new RootEntity.ItemsEntity(this.jsonEnumerator.Current);
            }
            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<RootEntity.ItemsEntity> array && this.index >= 0 && this.index < array.Length)
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
    System.Collections.Generic.IEnumerator<RootEntity.ItemsEntity> System.Collections.Generic.IEnumerable<RootEntity.ItemsEntity>.GetEnumerator()
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
        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<RootEntity.ItemsEntity> array && this.index + 1 < array.Length)
        {
            this.index++;
            return true;
        }
        return false;
    }
}
}
}
