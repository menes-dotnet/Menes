// <copyright file="items003.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Items003
{
public readonly struct TestSchema : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonNotAny>, System.Collections.IEnumerable, System.IEquatable<TestSchema>, System.IEquatable<Menes.JsonArray<Menes.JsonNotAny>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, TestSchema> FromJsonElement = e => new TestSchema(e);
    public static readonly TestSchema Null = new TestSchema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<Menes.JsonNotAny>? value;
    public TestSchema(Menes.JsonArray<Menes.JsonNotAny> jsonArray)
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
    public TestSchema(System.Text.Json.JsonElement jsonElement)
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
            if (this.value is Menes.JsonArray<Menes.JsonNotAny> value)
            {
                return value.Length;
            }
            return 0;
        }
    }
    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public TestSchema? AsOptional => this.IsNull ? default(TestSchema?) : this;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static implicit operator TestSchema(Menes.JsonArray<Menes.JsonNotAny> value)
    {
        return new TestSchema(value);
    }
    public static implicit operator Menes.JsonArray<Menes.JsonNotAny>(TestSchema value)
    {
        if (value.value is Menes.JsonArray<Menes.JsonNotAny> clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonArray<Menes.JsonNotAny>(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonArray<Menes.JsonNotAny>.IsConvertibleFrom(jsonElement);
    }
    public static TestSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new TestSchema(property)
                : Null)
            : Null;
    public static TestSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new TestSchema(property)
                : Null)
            : Null;
    public static TestSchema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new TestSchema(property)
                : Null)
            : Null;
    public bool Equals(TestSchema other)
    {
        return this.Equals((Menes.JsonArray<Menes.JsonNotAny>)other);
    }
    public bool Equals(Menes.JsonArray<Menes.JsonNotAny> other)
    {
        return ((Menes.JsonArray<Menes.JsonNotAny>)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonArray<Menes.JsonNotAny> array = this;
        Menes.ValidationContext context = validationContext;
        if (!this.HasJsonElement || IsConvertibleFrom(this.JsonElement))
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
        if (this.value is Menes.JsonArray<Menes.JsonNotAny> clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public Menes.JsonArray<Menes.JsonNotAny>.JsonArrayEnumerator GetEnumerator()
    {
        return ((Menes.JsonArray<Menes.JsonNotAny>)this).GetEnumerator();
    }
    System.Collections.Generic.IEnumerator<Menes.JsonNotAny> System.Collections.Generic.IEnumerable<Menes.JsonNotAny>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public TestSchema Add(params Menes.JsonNotAny[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
        {
            arrayBuilder.Add(item);
        }
        foreach (Menes.JsonNotAny item in items)
        {
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in Menes.JsonNotAny item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in Menes.JsonNotAny item1, in Menes.JsonNotAny item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in Menes.JsonNotAny item1, in Menes.JsonNotAny item2, in Menes.JsonNotAny item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in Menes.JsonNotAny item1, in Menes.JsonNotAny item2, in Menes.JsonNotAny item3, in Menes.JsonNotAny item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        arrayBuilder.Add(item4);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Insert(int indexToInsert, params Menes.JsonNotAny[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        int index = 0;
        foreach (Menes.JsonNotAny item in this)
        {
            if (index == indexToInsert)
            {
                foreach (Menes.JsonNotAny itemToInsert in items)
                {
                    arrayBuilder.Add(itemToInsert);
                }
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Insert(int indexToInsert, in Menes.JsonNotAny item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        int index = 0;
        foreach (Menes.JsonNotAny item in this)
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
    public TestSchema Insert(int indexToInsert, in Menes.JsonNotAny item1, in Menes.JsonNotAny item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        int index = 0;
        foreach (Menes.JsonNotAny item in this)
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
    public TestSchema Insert(int indexToInsert, in Menes.JsonNotAny item1, in Menes.JsonNotAny item2, in Menes.JsonNotAny item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        int index = 0;
        foreach (Menes.JsonNotAny item in this)
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
    public TestSchema Insert(int indexToInsert, in Menes.JsonNotAny item1, in Menes.JsonNotAny item2, in Menes.JsonNotAny item3, in Menes.JsonNotAny item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        int index = 0;
        foreach (Menes.JsonNotAny item in this)
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
    public TestSchema Remove(params Menes.JsonNotAny[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
        {
            bool found = false;
            foreach (Menes.JsonNotAny itemToRemove in items)
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
    public TestSchema Remove(Menes.JsonNotAny item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
        {
            if (item1.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(Menes.JsonNotAny item1, Menes.JsonNotAny item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
        {
            if (item1.Equals(item) || item2.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(Menes.JsonNotAny item1, Menes.JsonNotAny item2, Menes.JsonNotAny item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(Menes.JsonNotAny item1, Menes.JsonNotAny item2, Menes.JsonNotAny item3, Menes.JsonNotAny item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema RemoveAt(int indexToRemove)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        int index = 0;
        foreach (Menes.JsonNotAny item in this)
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
    public TestSchema RemoveRange(int startIndex, int length)
    {
        if (startIndex < 0 || startIndex > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(startIndex));
        }
        if (length < 1 || startIndex + length > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(length));
        }
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        int index = 0;
        foreach (Menes.JsonNotAny item in this)
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
    public TestSchema Remove(System.Predicate<Menes.JsonNotAny> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonNotAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonNotAny>();
        foreach (Menes.JsonNotAny item in this)
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
/// items with boolean schema (false)
/// </summary>
public static class Tests
{
/// <summary>
/// any non-empty array is invalid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[ 1, \"foo\", true ]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Items003.Tests.Test0: any non-empty array is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// empty array is valid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Items003.Tests.Test1: empty array is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}