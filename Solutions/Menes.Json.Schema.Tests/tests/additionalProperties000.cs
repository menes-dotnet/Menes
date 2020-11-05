// <copyright file="additionalProperties000.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.AdditionalProperties000
{
public readonly struct TestSchema : Menes.IJsonObject, System.IEquatable<TestSchema>
{
    public static readonly TestSchema Null = new TestSchema(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, TestSchema> FromJsonElement = e => new TestSchema(e);
    private const string FooPropertyNamePath = ".foo";
    private const string BarPropertyNamePath = ".bar";
    private static readonly System.ReadOnlyMemory<byte> FooPropertyNameBytes = new byte[] { 102, 111, 111 };
    private static readonly System.ReadOnlyMemory<byte> BarPropertyNameBytes = new byte[] { 98, 97, 114 };
    private static readonly System.Text.Json.JsonEncodedText EncodedFooPropertyName = System.Text.Json.JsonEncodedText.Encode(FooPropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedBarPropertyName = System.Text.Json.JsonEncodedText.Encode(BarPropertyNameBytes.Span);
    private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(FooPropertyNameBytes, BarPropertyNameBytes);
    private readonly Menes.JsonAny? foo;
    private readonly Menes.JsonAny? bar;
    private static readonly System.Text.RegularExpressions.Regex PatternPropertyRegex0 = new System.Text.RegularExpressions.Regex("^v", System.Text.RegularExpressions.RegexOptions.Compiled);
    public TestSchema(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
        this.foo = null;
        this.bar = null;
    }
    public TestSchema(Menes.JsonAny? foo = null, Menes.JsonAny? bar = null)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.foo is null || this.foo.Value.IsNull) && (this.bar is null || this.bar.Value.IsNull);
    public TestSchema? AsOptional => this.IsNull ? default(TestSchema?) : this;
    public Menes.JsonAny? Foo => this.foo ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, FooPropertyNameBytes.Span).AsOptional;
    public Menes.JsonAny? Bar => this.bar ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, BarPropertyNameBytes.Span).AsOptional;
    public int PropertiesCount => KnownProperties.Length;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
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
    public TestSchema WithFoo(Menes.JsonAny? value)
    {
        return new TestSchema(value, this.Bar);
    }
    public TestSchema WithBar(Menes.JsonAny? value)
    {
        return new TestSchema(this.Foo, value);
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        else
        {
            writer.WriteStartObject();
            if (this.foo is Menes.JsonAny foo)
            {
                writer.WritePropertyName(EncodedFooPropertyName);
                foo.WriteTo(writer);
            }
            if (this.bar is Menes.JsonAny bar)
            {
                writer.WritePropertyName(EncodedBarPropertyName);
                bar.WriteTo(writer);
            }
            writer.WriteEndObject();
        }
    }
    public bool Equals(TestSchema other)
    {
        if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
        {
            return false;
        }
        if (this.HasJsonElement && other.HasJsonElement)
        {
            return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
        }
        return this.Foo.Equals(other.Foo) && this.Bar.Equals(other.Bar);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        if (this.IsNull)
        {
            return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
        }
        Menes.ValidationContext context = validationContext;
        if (!this.HasJsonElement || IsConvertibleFrom(this.JsonElement))
        {
            System.Collections.Generic.HashSet<string> matchedProperties = new System.Collections.Generic.HashSet<string>(this.PropertiesCount);
            matchedProperties.Add("foo");
            if (this.Foo is Menes.JsonAny foo)
            {
                context = Menes.Validation.ValidateProperty(context, foo, FooPropertyNamePath);
                context = this.ValidatePatternProperty(context, "foo", foo, FooPropertyNamePath).Item2;
            }
            matchedProperties.Add("bar");
            if (this.Bar is Menes.JsonAny bar)
            {
                context = Menes.Validation.ValidateProperty(context, bar, BarPropertyNamePath);
                context = this.ValidatePatternProperty(context, "bar", bar, BarPropertyNamePath).Item2;
            }
            if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
            {
                int propCount = 0;
                var additionalPropertyEnumerator = this.JsonElement.EnumerateObject();
                while (additionalPropertyEnumerator.MoveNext())
                {
                    string propertyName = additionalPropertyEnumerator.Current.Name;
                    var patternContext = this.ValidatePatternProperty(context, propertyName, Menes.JsonAny.FromJsonElement(additionalPropertyEnumerator.Current.Value), "." + propertyName);
                    context = patternContext.Item2;
                    if (patternContext.Item1)
                    {
                        matchedProperties.Add(propertyName);
                        continue;
                    }
                    int increment = 1;
                    for (int i = 0; i < KnownProperties.Length; ++i)
                    {
                        if (additionalPropertyEnumerator.Current.NameEquals(KnownProperties[i].Span))
                        {
                            increment = 0;
                            break;
                        }
                    }
                    propCount += increment;
                    if (propCount > 0)
                    {
                        context = context.WithError("core 9.3.2.3. No additional properties were expected.");
                        break;
                    }
                }
            }
        }
        return context;
    }
    public override string ToString()
    {
        return Menes.JsonAny.From(this).ToString();
    }
    private (bool, Menes.ValidationContext) ValidatePatternProperty<TItem>(in Menes.ValidationContext validationContext, string propertyName, in TItem value, string propertyPathToAppend)
       where TItem : struct, IJsonValue
    {
        var anyValue = Menes.JsonAny.From(value);
        bool isMatch = false;
        ValidationContext context = validationContext;
        bool isMatch0 = PatternPropertyRegex0.IsMatch(propertyName);
        if (isMatch0)
        {
            context = anyValue.As<Menes.JsonAny>().Validate(context);
        }
        isMatch = isMatch || isMatch0;
        return (isMatch, context);
    }
}///  <summary>
/// additionalProperties being false does not allow other properties
/// </summary>
public static class Tests
{
/// <summary>
/// no additional properties is valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": 1}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties000.Tests.Test0: no additional properties is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// an additional property is invalid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\" : 1, \"bar\" : 2, \"quux\" : \"boom\"}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties000.Tests.Test1: an additional property is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// ignores arrays
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[1, 2, 3]");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties000.Tests.Test2: ignores arrays");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// ignores strings
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("\"foobarbaz\"");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties000.Tests.Test3: ignores strings");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// ignores other non-objects
/// </summary>
    public static bool Test4()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("12");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties000.Tests.Test4: ignores other non-objects");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// patternProperties are not additional properties
/// </summary>
    public static bool Test5()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\":1, \"vroom\": 2}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties000.Tests.Test5: patternProperties are not additional properties");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}