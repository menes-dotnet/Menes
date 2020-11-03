// <copyright file="ref000.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Ref000
{
public readonly struct Schema : Menes.IJsonObject, System.IEquatable<Schema>
{
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    private const string FooPropertyNamePath = ".foo";
    private static readonly System.ReadOnlyMemory<byte> FooPropertyNameBytes = new byte[] { 102, 111, 111 };
    private static readonly System.Text.Json.JsonEncodedText EncodedFooPropertyName = System.Text.Json.JsonEncodedText.Encode(FooPropertyNameBytes.Span);
    private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(FooPropertyNameBytes);
    private readonly Menes.JsonReference? foo;
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
        this.foo = null;
    }
    public Schema(Schema? foo = null)
    {
        if (foo is Schema item1)
        {
            this.foo = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.foo = null;
        }
        this.JsonElement = default;
    }
    private Schema(Menes.JsonReference? foo)
    {
        if (foo is Menes.JsonReference item1)
        {
            this.foo = item1;
        }
        else
        {
            this.foo = null;
        }
        this.JsonElement = default;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.foo is null || this.foo.Value.IsNull);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
    public Schema? Foo => this.foo?.AsValue<Schema>() ?? Schema.FromOptionalProperty(this.JsonElement, FooPropertyNameBytes.Span).AsOptional;
    public int PropertiesCount => KnownProperties.Length;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
    }
    public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null)
            : Null;
    public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null)
            : Null;
    public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null)
        : Null;
    public Schema WithFoo(Schema? value)
    {
        return new Schema(Menes.JsonReference.FromValue(value));
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
            if (this.foo is Menes.JsonReference foo)
            {
                writer.WritePropertyName(EncodedFooPropertyName);
                foo.WriteTo(writer);
            }
            writer.WriteEndObject();
        }
    }
    public bool Equals(Schema other)
    {
        if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
        {
            return false;
        }
        if (this.HasJsonElement && other.HasJsonElement)
        {
            return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
        }
        return this.Foo.Equals(other.Foo);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        if (this.IsNull)
        {
            return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {{JsonValueKind.Object}}");
        }
        Menes.ValidationContext context = validationContext;
        if (this.Foo is Schema foo)
        {
            context = Menes.Validation.ValidateProperty(context, foo, FooPropertyNamePath);
        }
        if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
        {
            int propCount = 0;
            int targetPropCount = KnownProperties.Length;
            var additionalPropertyEnumerator = this.JsonElement.EnumerateObject();
            while (additionalPropertyEnumerator.MoveNext())
            {
                propCount++;
                if (propCount > targetPropCount)
                {
                    context = context.WithError("core 9.3.2.3. No additional properties were expected.");
                    break;
                }
            }
        }
        return context;
    }
    public override string ToString()
    {
        return Menes.JsonAny.From(this).ToString();
    }
    private Menes.JsonReference? GetFoo()
    {
        if (this.foo is Menes.JsonReference reference)
        {
            return reference;
        }
        if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(FooPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
        {
            return new Menes.JsonReference(value);
        }
        return default;
    }
}///  <summary>
/// root pointer ref
/// </summary>
public static class Tests
{
/// <summary>
/// match
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": false}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Ref000.Tests.Test0: match");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// recursive match
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": {\"foo\": false}}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Ref000.Tests.Test1: recursive match");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// mismatch
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"bar\": false}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Ref000.Tests.Test2: mismatch");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// recursive mismatch
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": {\"bar\": false}}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Ref000.Tests.Test3: recursive mismatch");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}