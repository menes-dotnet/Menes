// <copyright file="uniqueItems000.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.UniqueItems000
{
public readonly struct TestSchema : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.IEquatable<TestSchema>, System.IEquatable<Menes.JsonArray<Menes.JsonAny>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, TestSchema> FromJsonElement = e => new TestSchema(e);
    public static readonly TestSchema Null = new TestSchema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<Menes.JsonAny>? value;
    public TestSchema(Menes.JsonArray<Menes.JsonAny> jsonArray)
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
            if (this.value is Menes.JsonArray<Menes.JsonAny> value)
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
    public static implicit operator TestSchema(Menes.JsonArray<Menes.JsonAny> value)
    {
        return new TestSchema(value);
    }
    public static implicit operator Menes.JsonArray<Menes.JsonAny>(TestSchema value)
    {
        if (value.value is Menes.JsonArray<Menes.JsonAny> clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonArray<Menes.JsonAny>(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonArray<Menes.JsonAny>.IsConvertibleFrom(jsonElement);
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
        return this.Equals((Menes.JsonArray<Menes.JsonAny>)other);
    }
    public bool Equals(Menes.JsonArray<Menes.JsonAny> other)
    {
        return ((Menes.JsonArray<Menes.JsonAny>)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonArray<Menes.JsonAny> array = this;
        Menes.ValidationContext context = validationContext;
        if (!this.HasJsonElement || IsConvertibleFrom(this.JsonElement))
        {
            context = array.ValidateUniqueItems(context, true);
        }
        return context;
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        if (this.value is Menes.JsonArray<Menes.JsonAny> clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public Menes.JsonArray<Menes.JsonAny>.JsonArrayEnumerator GetEnumerator()
    {
        return ((Menes.JsonArray<Menes.JsonAny>)this).GetEnumerator();
    }
    System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public TestSchema Add(params Menes.JsonAny[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        foreach (Menes.JsonAny item in items)
        {
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in Menes.JsonAny item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in Menes.JsonAny item1, in Menes.JsonAny item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        arrayBuilder.Add(item4);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Insert(int indexToInsert, params Menes.JsonAny[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
        {
            if (index == indexToInsert)
            {
                foreach (Menes.JsonAny itemToInsert in items)
                {
                    arrayBuilder.Add(itemToInsert);
                }
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Insert(int indexToInsert, in Menes.JsonAny item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
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
    public TestSchema Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
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
    public TestSchema Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
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
    public TestSchema Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
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
    public TestSchema Remove(params Menes.JsonAny[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            bool found = false;
            foreach (Menes.JsonAny itemToRemove in items)
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
    public TestSchema Remove(Menes.JsonAny item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            if (item1.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(Menes.JsonAny item1, Menes.JsonAny item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            if (item1.Equals(item) || item2.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public TestSchema Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3, Menes.JsonAny item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
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
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
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
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
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
    public TestSchema Remove(System.Predicate<Menes.JsonAny> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
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
/// uniqueItems validation
/// </summary>
public static class Tests
{
/// <summary>
/// unique array of integers is valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[1, 2]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test0: unique array of integers is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-unique array of integers is invalid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[1, 1]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test1: non-unique array of integers is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// numbers are unique if mathematically unequal
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[1.0, 1.00, 1]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test2: numbers are unique if mathematically unequal");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// false is not equal to zero
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[0, false]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test3: false is not equal to zero");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// true is not equal to one
/// </summary>
    public static bool Test4()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[1, true]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test4: true is not equal to one");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// unique array of objects is valid
/// </summary>
    public static bool Test5()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{\"foo\": \"bar\"}, {\"foo\": \"baz\"}]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test5: unique array of objects is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-unique array of objects is invalid
/// </summary>
    public static bool Test6()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{\"foo\": \"bar\"}, {\"foo\": \"bar\"}]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test6: non-unique array of objects is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// unique array of nested objects is valid
/// </summary>
    public static bool Test7()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}},\r\n                    {\"foo\": {\"bar\" : {\"baz\" : false}}}\r\n                ]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test7: unique array of nested objects is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-unique array of nested objects is invalid
/// </summary>
    public static bool Test8()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}},\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}}\r\n                ]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test8: non-unique array of nested objects is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// unique array of arrays is valid
/// </summary>
    public static bool Test9()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[\"foo\"], [\"bar\"]]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test9: unique array of arrays is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-unique array of arrays is invalid
/// </summary>
    public static bool Test10()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[\"foo\"], [\"foo\"]]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test10: non-unique array of arrays is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// 1 and true are unique
/// </summary>
    public static bool Test11()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[1, true]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test11: 1 and true are unique");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// 0 and false are unique
/// </summary>
    public static bool Test12()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[0, false]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test12: 0 and false are unique");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// [1] and [true] are unique
/// </summary>
    public static bool Test13()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[1], [true]]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test13: [1] and [true] are unique");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// [0] and [false] are unique
/// </summary>
    public static bool Test14()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[0], [false]]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test14: [0] and [false] are unique");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// nested [1] and [true] are unique
/// </summary>
    public static bool Test15()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[[1], \"foo\"], [[true], \"foo\"]]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test15: nested [1] and [true] are unique");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// nested [0] and [false] are unique
/// </summary>
    public static bool Test16()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[[0], \"foo\"], [[false], \"foo\"]]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test16: nested [0] and [false] are unique");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// unique heterogeneous types are valid
/// </summary>
    public static bool Test17()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{}, [1], true, null, 1, \"{}\"]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test17: unique heterogeneous types are valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-unique heterogeneous types are invalid
/// </summary>
    public static bool Test18()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{}, [1], true, null, {}, 1]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test18: non-unique heterogeneous types are invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// different objects are unique
/// </summary>
    public static bool Test19()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{\"a\": 1, \"b\": 2}, {\"a\": 2, \"b\": 1}]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test19: different objects are unique");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// objects are non-unique despite key order
/// </summary>
    public static bool Test20()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{\"a\": 1, \"b\": 2}, {\"b\": 2, \"a\": 1}]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test20: objects are non-unique despite key order");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// {"a": false} and {"a": 0} are unique
/// </summary>
    public static bool Test21()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{\"a\": false}, {\"a\": 0}]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test21: {\"a\": false} and {\"a\": 0} are unique");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// {"a": true} and {"a": 1} are unique
/// </summary>
    public static bool Test22()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{\"a\": true}, {\"a\": 1}]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems000.Tests.Test22: {\"a\": true} and {\"a\": 1} are unique");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}