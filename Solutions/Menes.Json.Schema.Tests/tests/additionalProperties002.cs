// <copyright file="additionalProperties002.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.AdditionalProperties002
{
public readonly struct TestSchema : Menes.IJsonObject, System.IEquatable<TestSchema>, Menes.IJsonAdditionalProperties<Menes.JsonBoolean>
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
    private readonly Menes.JsonProperties<Menes.JsonBoolean>? additionalPropertiesBacking;
    public TestSchema(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
        this.foo = null;
        this.bar = null;
        this.additionalPropertiesBacking = null;
    }
    public TestSchema(Menes.JsonAny? foo, Menes.JsonAny? bar, Menes.JsonProperties<Menes.JsonBoolean> additionalPropertiesBacking)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public TestSchema(Menes.JsonAny? foo, Menes.JsonAny? bar, params (string, Menes.JsonBoolean)[] additionalPropertiesBacking)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonBoolean>.FromValues(additionalPropertiesBacking);
    }
    public TestSchema(Menes.JsonAny? foo = null, Menes.JsonAny? bar = null)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = null;
    }
    public TestSchema(Menes.JsonAny? foo, Menes.JsonAny? bar, (string, Menes.JsonBoolean) additionalProperty1)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonBoolean>.FromValues(additionalProperty1);
    }
    public TestSchema(Menes.JsonAny? foo, Menes.JsonAny? bar, (string, Menes.JsonBoolean) additionalProperty1, (string, Menes.JsonBoolean) additionalProperty2)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonBoolean>.FromValues(additionalProperty1, additionalProperty2);
    }
    public TestSchema(Menes.JsonAny? foo, Menes.JsonAny? bar, (string, Menes.JsonBoolean) additionalProperty1, (string, Menes.JsonBoolean) additionalProperty2, (string, Menes.JsonBoolean) additionalProperty3)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonBoolean>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
    }
    public TestSchema(Menes.JsonAny? foo, Menes.JsonAny? bar, (string, Menes.JsonBoolean) additionalProperty1, (string, Menes.JsonBoolean) additionalProperty2, (string, Menes.JsonBoolean) additionalProperty3, (string, Menes.JsonBoolean) additionalProperty4)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonBoolean>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
    }
    private TestSchema(Menes.JsonAny? foo, Menes.JsonAny? bar, Menes.JsonProperties<Menes.JsonBoolean>? additionalPropertiesBacking)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.foo is null || this.foo.Value.IsNull) && (this.bar is null || this.bar.Value.IsNull);
    public TestSchema? AsOptional => this.IsNull ? default(TestSchema?) : this;
    public Menes.JsonAny? Foo => this.foo ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, FooPropertyNameBytes.Span).AsOptional;
    public Menes.JsonAny? Bar => this.bar ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, BarPropertyNameBytes.Span).AsOptional;
    public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
    public int JsonAdditionalPropertiesCount
    {
        get
        {
            Menes.JsonProperties<Menes.JsonBoolean>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
            int count = 0;

            while (enumerator.MoveNext())
            {
                count++;
            }

            return count;
        }
    }
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public Menes.JsonProperties<Menes.JsonBoolean>.JsonPropertyEnumerator JsonAdditionalProperties
    {
        get
        {
            if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonBoolean> ap)
            {
                return new Menes.JsonProperties<Menes.JsonBoolean>.JsonPropertyEnumerator(ap, KnownProperties);
            }

            if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
            {
                return new Menes.JsonProperties<Menes.JsonBoolean>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
            }

            return new Menes.JsonProperties<Menes.JsonBoolean>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonBoolean>.Empty, KnownProperties);
        }
    }
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
        return new TestSchema(value, this.Bar, this.GetJsonProperties());
    }
    public TestSchema WithBar(Menes.JsonAny? value)
    {
        return new TestSchema(this.Foo, value, this.GetJsonProperties());
    }
    public TestSchema ReplaceAll(Menes.JsonProperties<Menes.JsonBoolean> newAdditional)
    {
        return new TestSchema(this.Foo, this.Bar, newAdditional);
    }
    public TestSchema ReplaceAll(params (string, Menes.JsonBoolean)[] newAdditional)
    {
        return new TestSchema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonBoolean>.FromValues(newAdditional));
    }
    public TestSchema ReplaceAll((string, Menes.JsonBoolean) newAdditional1)
    {
        return new TestSchema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonBoolean>.FromValues(newAdditional1));
    }
    public TestSchema ReplaceAll((string, Menes.JsonBoolean) newAdditional1, (string, Menes.JsonBoolean) newAdditional2)
    {
        return new TestSchema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonBoolean>.FromValues(newAdditional1, newAdditional2));
    }
    public TestSchema ReplaceAll((string, Menes.JsonBoolean) newAdditional1, (string, Menes.JsonBoolean) newAdditional2, (string, Menes.JsonBoolean) newAdditional3)
    {
        return new TestSchema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonBoolean>.FromValues(newAdditional1, newAdditional2, newAdditional3));
    }
    public TestSchema ReplaceAll((string, Menes.JsonBoolean) newAdditional1, (string, Menes.JsonBoolean) newAdditional2, (string, Menes.JsonBoolean) newAdditional3, (string, Menes.JsonBoolean) newAdditional4)
    {
        return new TestSchema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonBoolean>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
    }
    public TestSchema Add(params (string, Menes.JsonBoolean)[] newAdditional)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        foreach ((string name, Menes.JsonBoolean value) in newAdditional)
        {
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(name, value));
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonBoolean value) newAdditional1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional1.name, newAdditional1.value)); return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonBoolean value) newAdditional1, (string name, Menes.JsonBoolean value) newAdditional2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional2.name, newAdditional2.value)); return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonBoolean value) newAdditional1, (string name, Menes.JsonBoolean value) newAdditional2, (string name, Menes.JsonBoolean value) newAdditional3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional3.name, newAdditional3.value)); return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonBoolean value) newAdditional1, (string name, Menes.JsonBoolean value) newAdditional2, (string name, Menes.JsonBoolean value) newAdditional3, (string name, Menes.JsonBoolean value) newAdditional4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional4.name, newAdditional4.value)); return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(params string[] namesToRemove)
    {
        System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1, string itemToRemove2)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonBoolean>> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            if (!removeIfTrue(property))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
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
            Menes.JsonProperties<Menes.JsonBoolean>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
            while (enumerator.MoveNext())
            {
                enumerator.Current.Write(writer);
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
        return this.Foo.Equals(other.Foo) && this.Bar.Equals(other.Bar) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        if (this.IsNull)
        {
            return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
        }
        Menes.ValidationContext context = validationContext;
        if (this.HasJsonElement && IsConvertibleFrom(this.JsonElement))
        {
            if (this.Foo is Menes.JsonAny foo)
            {
                context = Menes.Validation.ValidateProperty(context, foo, FooPropertyNamePath);
            }
            if (this.Bar is Menes.JsonAny bar)
            {
                context = Menes.Validation.ValidateProperty(context, bar, BarPropertyNamePath);
            }
            foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
            {
                string propertyName = property.Name;
                context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
            }
        }
        return context;
    }
    public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonBoolean value)
    {
        return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
    }
    public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonBoolean value)
    {
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            if (property.NameEquals(utf8PropertyName))
            {
                value = property.AsValue();
                return true;
            }
        }
        value = default;
        return false;
    }
    public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonBoolean value)
    {
        System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
        int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
        return this.TryGet(bytes.Slice(0, written), out value);
    }
    public override string ToString()
    {
        return Menes.JsonAny.From(this).ToString();
    }
    private Menes.JsonProperties<Menes.JsonBoolean> GetJsonProperties()
    {
        if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonBoolean> props)
        {
            return props;
        }
        return new Menes.JsonProperties<Menes.JsonBoolean>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
    }
}///  <summary>
/// additionalProperties allows a schema which should validate
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
            System.Console.WriteLine("Failed AdditionalProperties002.Tests.Test0: no additional properties is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// an additional valid property is valid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\" : 1, \"bar\" : 2, \"quux\" : true}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties002.Tests.Test1: an additional valid property is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// an additional invalid property is invalid
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\" : 1, \"bar\" : 2, \"quux\" : 12}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties002.Tests.Test2: an additional invalid property is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}