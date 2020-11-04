// <copyright file="refRemote003.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.RefRemote003
{
public readonly struct HttpLocalhost1234 : Menes.IJsonValue, System.Collections.Generic.IEnumerable<BaseUriChange>, System.Collections.IEnumerable, System.IEquatable<HttpLocalhost1234>, System.IEquatable<Menes.JsonArray<BaseUriChange>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, HttpLocalhost1234> FromJsonElement = e => new HttpLocalhost1234(e);
    public static readonly HttpLocalhost1234 Null = new HttpLocalhost1234(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<BaseUriChange>? value;
    public HttpLocalhost1234(Menes.JsonArray<BaseUriChange> jsonArray)
    {
        if (jsonArray.HasJsonElement)
        {
            this.JsonElement = jsonArray.JsonElement;
            this.value = null;
        }
        else
        {
            this.value = jsonArray;
            this.JsonElement = default;
        }
    }
    public HttpLocalhost1234(System.Text.Json.JsonElement jsonElement)
    {
        this.value = null;
        this.JsonElement = jsonElement;
    }
    public int Length
    {
        get
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.GetArrayLength();
            }
            if (this.value is Menes.JsonArray<BaseUriChange> value)
            {
                return value.Length;
            }
            return 0;
        }
    }
    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public HttpLocalhost1234? AsOptional => this.IsNull ? default(HttpLocalhost1234?) : this;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static implicit operator HttpLocalhost1234(Menes.JsonArray<BaseUriChange> value)
    {
        return new HttpLocalhost1234(value);
    }
    public static implicit operator Menes.JsonArray<BaseUriChange>(HttpLocalhost1234 value)
    {
        if (value.value is Menes.JsonArray<BaseUriChange> clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonArray<BaseUriChange>(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonArray<BaseUriChange>.IsConvertibleFrom(jsonElement);
    }
    public static HttpLocalhost1234 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new HttpLocalhost1234(property)
                : Null)
            : Null;
    public static HttpLocalhost1234 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new HttpLocalhost1234(property)
                : Null)
            : Null;
    public static HttpLocalhost1234 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new HttpLocalhost1234(property)
                : Null)
            : Null;
    public bool Equals(HttpLocalhost1234 other)
    {
        return this.Equals((Menes.JsonArray<BaseUriChange>)other);
    }
    public bool Equals(Menes.JsonArray<BaseUriChange> other)
    {
        return ((Menes.JsonArray<BaseUriChange>)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonArray<BaseUriChange> array = this;
        Menes.ValidationContext context = validationContext;
        if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
        {
            context = array.ValidateItems(context);
        }
        return context;
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        if (this.value is Menes.JsonArray<BaseUriChange> clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public Menes.JsonArray<BaseUriChange>.JsonArrayEnumerator GetEnumerator()
    {
        return ((Menes.JsonArray<BaseUriChange>)this).GetEnumerator();
    }
    System.Collections.Generic.IEnumerator<BaseUriChange> System.Collections.Generic.IEnumerable<BaseUriChange>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public HttpLocalhost1234 Add(params BaseUriChange[] items)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            arrayBuilder.Add(item);
        }
        foreach (BaseUriChange item in items)
        {
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Add(in BaseUriChange item1)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Add(in BaseUriChange item1, in BaseUriChange item2)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Add(in BaseUriChange item1, in BaseUriChange item2, in BaseUriChange item3)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Add(in BaseUriChange item1, in BaseUriChange item2, in BaseUriChange item3, in BaseUriChange item4)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        arrayBuilder.Add(item4);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Insert(int indexToInsert, params BaseUriChange[] items)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        int index = 0;
        foreach (BaseUriChange item in this)
        {
            if (index == indexToInsert)
            {
                foreach (BaseUriChange itemToInsert in items)
                {
                    arrayBuilder.Add(itemToInsert);
                }
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Insert(int indexToInsert, in BaseUriChange item1)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        int index = 0;
        foreach (BaseUriChange item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Insert(int indexToInsert, in BaseUriChange item1, in BaseUriChange item2)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        int index = 0;
        foreach (BaseUriChange item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Insert(int indexToInsert, in BaseUriChange item1, in BaseUriChange item2, in BaseUriChange item3)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        int index = 0;
        foreach (BaseUriChange item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Insert(int indexToInsert, in BaseUriChange item1, in BaseUriChange item2, in BaseUriChange item3, in BaseUriChange item4)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        int index = 0;
        foreach (BaseUriChange item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                arrayBuilder.Add(item4);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Remove(params BaseUriChange[] items)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            bool found = false;
            foreach (BaseUriChange itemToRemove in items)
            {
                if (itemToRemove.Equals(item))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                arrayBuilder.Add(item);
            }
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Remove(BaseUriChange item1)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            if (item1.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Remove(BaseUriChange item1, BaseUriChange item2)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            if (item1.Equals(item) || item2.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Remove(BaseUriChange item1, BaseUriChange item2, BaseUriChange item3)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Remove(BaseUriChange item1, BaseUriChange item2, BaseUriChange item3, BaseUriChange item4)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 RemoveAt(int indexToRemove)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        int index = 0;
        foreach (BaseUriChange item in this)
        {
            if (index == indexToRemove)
            {
                index++;
                continue;
            }
            arrayBuilder.Add(item);
            index++;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 RemoveRange(int startIndex, int length)
    {
        if (startIndex < 0 || startIndex > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(startIndex));
        }
        if (length < 1 || startIndex + length > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(length));
        }
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        int index = 0;
        foreach (BaseUriChange item in this)
        {
            if (index >= startIndex && index < startIndex + length)
            {
                index++;
                continue;
            }
            arrayBuilder.Add(item);
            index++;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public HttpLocalhost1234 Remove(System.Predicate<BaseUriChange> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<BaseUriChange>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<BaseUriChange>();
        foreach (BaseUriChange item in this)
        {
            if (removeIfTrue(item))
            {
                continue;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
}
public readonly struct BaseUriChange : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonInteger>, System.Collections.IEnumerable, System.IEquatable<BaseUriChange>, System.IEquatable<Menes.JsonArray<Menes.JsonInteger>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, BaseUriChange> FromJsonElement = e => new BaseUriChange(e);
    public static readonly BaseUriChange Null = new BaseUriChange(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<Menes.JsonInteger>? value;
    public BaseUriChange(Menes.JsonArray<Menes.JsonInteger> jsonArray)
    {
        if (jsonArray.HasJsonElement)
        {
            this.JsonElement = jsonArray.JsonElement;
            this.value = null;
        }
        else
        {
            this.value = jsonArray;
            this.JsonElement = default;
        }
    }
    public BaseUriChange(System.Text.Json.JsonElement jsonElement)
    {
        this.value = null;
        this.JsonElement = jsonElement;
    }
    public int Length
    {
        get
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.GetArrayLength();
            }
            if (this.value is Menes.JsonArray<Menes.JsonInteger> value)
            {
                return value.Length;
            }
            return 0;
        }
    }
    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public BaseUriChange? AsOptional => this.IsNull ? default(BaseUriChange?) : this;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static implicit operator BaseUriChange(Menes.JsonArray<Menes.JsonInteger> value)
    {
        return new BaseUriChange(value);
    }
    public static implicit operator Menes.JsonArray<Menes.JsonInteger>(BaseUriChange value)
    {
        if (value.value is Menes.JsonArray<Menes.JsonInteger> clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonArray<Menes.JsonInteger>(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonArray<Menes.JsonInteger>.IsConvertibleFrom(jsonElement);
    }
    public static BaseUriChange FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new BaseUriChange(property)
                : Null)
            : Null;
    public static BaseUriChange FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new BaseUriChange(property)
                : Null)
            : Null;
    public static BaseUriChange FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new BaseUriChange(property)
                : Null)
            : Null;
    public bool Equals(BaseUriChange other)
    {
        return this.Equals((Menes.JsonArray<Menes.JsonInteger>)other);
    }
    public bool Equals(Menes.JsonArray<Menes.JsonInteger> other)
    {
        return ((Menes.JsonArray<Menes.JsonInteger>)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonArray<Menes.JsonInteger> array = this;
        Menes.ValidationContext context = validationContext;
        if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
        {
            context = array.ValidateItems(context);
        }
        return context;
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        if (this.value is Menes.JsonArray<Menes.JsonInteger> clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public Menes.JsonArray<Menes.JsonInteger>.JsonArrayEnumerator GetEnumerator()
    {
        return ((Menes.JsonArray<Menes.JsonInteger>)this).GetEnumerator();
    }
    System.Collections.Generic.IEnumerator<Menes.JsonInteger> System.Collections.Generic.IEnumerable<Menes.JsonInteger>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public BaseUriChange Add(params Menes.JsonInteger[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            arrayBuilder.Add(item);
        }
        foreach (Menes.JsonInteger item in items)
        {
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Add(in Menes.JsonInteger item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Add(in Menes.JsonInteger item1, in Menes.JsonInteger item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Add(in Menes.JsonInteger item1, in Menes.JsonInteger item2, in Menes.JsonInteger item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Add(in Menes.JsonInteger item1, in Menes.JsonInteger item2, in Menes.JsonInteger item3, in Menes.JsonInteger item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        arrayBuilder.Add(item4);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Insert(int indexToInsert, params Menes.JsonInteger[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        int index = 0;
        foreach (Menes.JsonInteger item in this)
        {
            if (index == indexToInsert)
            {
                foreach (Menes.JsonInteger itemToInsert in items)
                {
                    arrayBuilder.Add(itemToInsert);
                }
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Insert(int indexToInsert, in Menes.JsonInteger item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        int index = 0;
        foreach (Menes.JsonInteger item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Insert(int indexToInsert, in Menes.JsonInteger item1, in Menes.JsonInteger item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        int index = 0;
        foreach (Menes.JsonInteger item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Insert(int indexToInsert, in Menes.JsonInteger item1, in Menes.JsonInteger item2, in Menes.JsonInteger item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        int index = 0;
        foreach (Menes.JsonInteger item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Insert(int indexToInsert, in Menes.JsonInteger item1, in Menes.JsonInteger item2, in Menes.JsonInteger item3, in Menes.JsonInteger item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        int index = 0;
        foreach (Menes.JsonInteger item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                arrayBuilder.Add(item4);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Remove(params Menes.JsonInteger[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            bool found = false;
            foreach (Menes.JsonInteger itemToRemove in items)
            {
                if (itemToRemove.Equals(item))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                arrayBuilder.Add(item);
            }
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Remove(Menes.JsonInteger item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            if (item1.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Remove(Menes.JsonInteger item1, Menes.JsonInteger item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            if (item1.Equals(item) || item2.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Remove(Menes.JsonInteger item1, Menes.JsonInteger item2, Menes.JsonInteger item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Remove(Menes.JsonInteger item1, Menes.JsonInteger item2, Menes.JsonInteger item3, Menes.JsonInteger item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange RemoveAt(int indexToRemove)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        int index = 0;
        foreach (Menes.JsonInteger item in this)
        {
            if (index == indexToRemove)
            {
                index++;
                continue;
            }
            arrayBuilder.Add(item);
            index++;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange RemoveRange(int startIndex, int length)
    {
        if (startIndex < 0 || startIndex > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(startIndex));
        }
        if (length < 1 || startIndex + length > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(length));
        }
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        int index = 0;
        foreach (Menes.JsonInteger item in this)
        {
            if (index >= startIndex && index < startIndex + length)
            {
                index++;
                continue;
            }
            arrayBuilder.Add(item);
            index++;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public BaseUriChange Remove(System.Predicate<Menes.JsonInteger> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonInteger>();
        foreach (Menes.JsonInteger item in this)
        {
            if (removeIfTrue(item))
            {
                continue;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
}
///  <summary>
/// base URI change
/// </summary>
public static class Tests
{
/// <summary>
/// base URI change ref valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[1]]");
        var schema = new HttpLocalhost1234(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed RefRemote003.Tests.Test0: base URI change ref valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// base URI change ref invalid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[\"a\"]]");
        var schema = new HttpLocalhost1234(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed RefRemote003.Tests.Test1: base URI change ref invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}