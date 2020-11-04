// <copyright file="uniqueItems003.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.UniqueItems003
{
public readonly struct TestSchema : Menes.IJsonValue, System.IEquatable<TestSchema>
{
    public static readonly System.Func<System.Text.Json.JsonElement, TestSchema> FromJsonElement = e => new TestSchema(e);
    public static readonly TestSchema Null = new TestSchema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonAny? value;
    public TestSchema(Menes.JsonAny value)
    {
        if (value.HasJsonElement)
        {
            this.JsonElement = value.JsonElement;
            this.value = null;
        }
        else
        {
            this.value = value;
            this.JsonElement = default;
        }
    }
    public TestSchema(System.Text.Json.JsonElement jsonElement)
    {
        this.value = null;
        this.JsonElement = jsonElement;
    }
    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public TestSchema? AsOptional => this.IsNull ? default(TestSchema?) : this;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static implicit operator TestSchema(Menes.JsonAny value)
    {
        return new TestSchema(value);
    }
    public static implicit operator Menes.JsonAny(TestSchema value)
    {
        if (value.value is Menes.JsonAny clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonAny(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonAny.IsConvertibleFrom(jsonElement);
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
        return this.Equals((Menes.JsonAny)other);
    }
    public bool Equals(Menes.JsonAny other)
    {
        return ((Menes.JsonAny)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonAny value = this;
        Menes.ValidationContext context = validationContext;
        context = value.Validate(context);
        return context;
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        else if (this.value is Menes.JsonAny clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public override string ToString()
    {
        if (this.value is Menes.JsonAny clrValue)
        {
            return clrValue.ToString();
        }
        else
        {
            return this.JsonElement.GetRawText();
        }
    }
}
///  <summary>
/// uniqueItems=false validation
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
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test0: unique array of integers is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-unique array of integers is valid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[1, 1]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test1: non-unique array of integers is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
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
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test2: numbers are unique if mathematically unequal");
            System.Console.WriteLine("Expected: valid but was invalid");
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
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test3: false is not equal to zero");
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
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test4: true is not equal to one");
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
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test5: unique array of objects is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-unique array of objects is valid
/// </summary>
    public static bool Test6()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{\"foo\": \"bar\"}, {\"foo\": \"bar\"}]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test6: non-unique array of objects is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
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
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test7: unique array of nested objects is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-unique array of nested objects is valid
/// </summary>
    public static bool Test8()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}},\r\n                    {\"foo\": {\"bar\" : {\"baz\" : true}}}\r\n                ]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test8: non-unique array of nested objects is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
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
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test9: unique array of arrays is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-unique array of arrays is valid
/// </summary>
    public static bool Test10()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[[\"foo\"], [\"foo\"]]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test10: non-unique array of arrays is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
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
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test11: 1 and true are unique");
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
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test12: 0 and false are unique");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// unique heterogeneous types are valid
/// </summary>
    public static bool Test13()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{}, [1], true, null, 1]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test13: unique heterogeneous types are valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-unique heterogeneous types are valid
/// </summary>
    public static bool Test14()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[{}, [1], true, null, {}, 1]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UniqueItems003.Tests.Test14: non-unique heterogeneous types are valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}