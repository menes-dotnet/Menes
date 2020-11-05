// <copyright file="properties001.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Properties001
{
public readonly struct TestSchema : Menes.IJsonObject, System.IEquatable<TestSchema>, Menes.IJsonAdditionalProperties<Menes.JsonInteger>
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
    private readonly TestSchema.FooArray? foo;
    private readonly Menes.JsonArray<Menes.JsonAny>? bar;
    private readonly Menes.JsonProperties<Menes.JsonInteger>? additionalPropertiesBacking;
    private static readonly System.Text.RegularExpressions.Regex PatternPropertyRegex0 = new System.Text.RegularExpressions.Regex("f.o", System.Text.RegularExpressions.RegexOptions.Compiled);
    public TestSchema(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
        this.foo = null;
        this.bar = null;
        this.additionalPropertiesBacking = null;
    }
    public TestSchema(TestSchema.FooArray? foo, Menes.JsonArray<Menes.JsonAny>? bar, Menes.JsonProperties<Menes.JsonInteger> additionalPropertiesBacking)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public TestSchema(TestSchema.FooArray? foo, Menes.JsonArray<Menes.JsonAny>? bar, params (string, Menes.JsonInteger)[] additionalPropertiesBacking)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonInteger>.FromValues(additionalPropertiesBacking);
    }
    public TestSchema(TestSchema.FooArray? foo = null, Menes.JsonArray<Menes.JsonAny>? bar = null)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = null;
    }
    public TestSchema(TestSchema.FooArray? foo, Menes.JsonArray<Menes.JsonAny>? bar, (string, Menes.JsonInteger) additionalProperty1)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonInteger>.FromValues(additionalProperty1);
    }
    public TestSchema(TestSchema.FooArray? foo, Menes.JsonArray<Menes.JsonAny>? bar, (string, Menes.JsonInteger) additionalProperty1, (string, Menes.JsonInteger) additionalProperty2)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonInteger>.FromValues(additionalProperty1, additionalProperty2);
    }
    public TestSchema(TestSchema.FooArray? foo, Menes.JsonArray<Menes.JsonAny>? bar, (string, Menes.JsonInteger) additionalProperty1, (string, Menes.JsonInteger) additionalProperty2, (string, Menes.JsonInteger) additionalProperty3)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonInteger>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
    }
    public TestSchema(TestSchema.FooArray? foo, Menes.JsonArray<Menes.JsonAny>? bar, (string, Menes.JsonInteger) additionalProperty1, (string, Menes.JsonInteger) additionalProperty2, (string, Menes.JsonInteger) additionalProperty3, (string, Menes.JsonInteger) additionalProperty4)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonInteger>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
    }
    private TestSchema(TestSchema.FooArray? foo, Menes.JsonArray<Menes.JsonAny>? bar, Menes.JsonProperties<Menes.JsonInteger>? additionalPropertiesBacking)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.foo is null || this.foo.Value.IsNull) && (this.bar is null || this.bar.Value.IsNull);
    public TestSchema? AsOptional => this.IsNull ? default(TestSchema?) : this;
    public TestSchema.FooArray? Foo => this.foo ?? TestSchema.FooArray.FromOptionalProperty(this.JsonElement, FooPropertyNameBytes.Span).AsOptional;
    public Menes.JsonArray<Menes.JsonAny>? Bar => this.bar ?? Menes.JsonArray<Menes.JsonAny>.FromOptionalProperty(this.JsonElement, BarPropertyNameBytes.Span).AsOptional;
    public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
    public int JsonAdditionalPropertiesCount
    {
        get
        {
            Menes.JsonProperties<Menes.JsonInteger>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
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
    public Menes.JsonProperties<Menes.JsonInteger>.JsonPropertyEnumerator JsonAdditionalProperties
    {
        get
        {
            if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonInteger> ap)
            {
                return new Menes.JsonProperties<Menes.JsonInteger>.JsonPropertyEnumerator(ap, KnownProperties);
            }

            if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
            {
                return new Menes.JsonProperties<Menes.JsonInteger>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
            }

            return new Menes.JsonProperties<Menes.JsonInteger>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonInteger>.Empty, KnownProperties);
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
    public TestSchema WithFoo(TestSchema.FooArray? value)
    {
        return new TestSchema(value, this.Bar, this.GetJsonProperties());
    }
    public TestSchema WithBar(Menes.JsonArray<Menes.JsonAny>? value)
    {
        return new TestSchema(this.Foo, value, this.GetJsonProperties());
    }
    public TestSchema ReplaceAll(Menes.JsonProperties<Menes.JsonInteger> newAdditional)
    {
        return new TestSchema(this.Foo, this.Bar, newAdditional);
    }
    public TestSchema ReplaceAll(params (string, Menes.JsonInteger)[] newAdditional)
    {
        return new TestSchema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonInteger>.FromValues(newAdditional));
    }
    public TestSchema ReplaceAll((string, Menes.JsonInteger) newAdditional1)
    {
        return new TestSchema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonInteger>.FromValues(newAdditional1));
    }
    public TestSchema ReplaceAll((string, Menes.JsonInteger) newAdditional1, (string, Menes.JsonInteger) newAdditional2)
    {
        return new TestSchema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonInteger>.FromValues(newAdditional1, newAdditional2));
    }
    public TestSchema ReplaceAll((string, Menes.JsonInteger) newAdditional1, (string, Menes.JsonInteger) newAdditional2, (string, Menes.JsonInteger) newAdditional3)
    {
        return new TestSchema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonInteger>.FromValues(newAdditional1, newAdditional2, newAdditional3));
    }
    public TestSchema ReplaceAll((string, Menes.JsonInteger) newAdditional1, (string, Menes.JsonInteger) newAdditional2, (string, Menes.JsonInteger) newAdditional3, (string, Menes.JsonInteger) newAdditional4)
    {
        return new TestSchema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonInteger>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
    }
    public TestSchema Add(params (string, Menes.JsonInteger)[] newAdditional)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        foreach ((string name, Menes.JsonInteger value) in newAdditional)
        {
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(name, value));
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonInteger value) newAdditional1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(newAdditional1.name, newAdditional1.value)); return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonInteger value) newAdditional1, (string name, Menes.JsonInteger value) newAdditional2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(newAdditional2.name, newAdditional2.value)); return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonInteger value) newAdditional1, (string name, Menes.JsonInteger value) newAdditional2, (string name, Menes.JsonInteger value) newAdditional3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(newAdditional3.name, newAdditional3.value)); return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonInteger value) newAdditional1, (string name, Menes.JsonInteger value) newAdditional2, (string name, Menes.JsonInteger value) newAdditional3, (string name, Menes.JsonInteger value) newAdditional4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonInteger>.From(newAdditional4.name, newAdditional4.value)); return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(params string[] namesToRemove)
    {
        System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1, string itemToRemove2)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonInteger>> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonInteger>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonInteger>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
        {
            if (!removeIfTrue(property))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonInteger>(arrayBuilder.ToImmutable()));
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
            if (this.foo is TestSchema.FooArray foo)
            {
                writer.WritePropertyName(EncodedFooPropertyName);
                foo.WriteTo(writer);
            }
            if (this.bar is Menes.JsonArray<Menes.JsonAny> bar)
            {
                writer.WritePropertyName(EncodedBarPropertyName);
                bar.WriteTo(writer);
            }
            Menes.JsonProperties<Menes.JsonInteger>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
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
        if (!this.HasJsonElement || IsConvertibleFrom(this.JsonElement))
        {
            System.Collections.Generic.HashSet<string> matchedProperties = new System.Collections.Generic.HashSet<string>(this.PropertiesCount);
            if (this.Foo is TestSchema.FooArray foo)
            {
                context = Menes.Validation.ValidateProperty(context, foo, FooPropertyNamePath);
            }
            if (this.Bar is Menes.JsonArray<Menes.JsonAny> bar)
            {
                context = Menes.Validation.ValidateProperty(context, bar, BarPropertyNamePath);
            }
            foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
            {
                string propertyName = property.Name;
                var patternContext = this.ValidatePatternProperty(Menes.ValidationContext.Root, property.Name, property.AsValue(), "." + property.Name);
                if (patternContext.LastWasValid)
                {
                    continue;
                }
                context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
            }
        }
        return context;
    }
    public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonInteger value)
    {
        return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
    }
    public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonInteger value)
    {
        foreach (Menes.JsonPropertyReference<Menes.JsonInteger> property in this.JsonAdditionalProperties)
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
    public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonInteger value)
    {
        System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
        int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
        return this.TryGet(bytes.Slice(0, written), out value);
    }
    public override string ToString()
    {
        return Menes.JsonAny.From(this).ToString();
    }
    private Menes.JsonProperties<Menes.JsonInteger> GetJsonProperties()
    {
        if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonInteger> props)
        {
            return props;
        }
        return new Menes.JsonProperties<Menes.JsonInteger>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
    }
    private Menes.ValidationContext ValidatePatternProperty<TItem>(in Menes.ValidationContext validationContext, string propertyName, in TItem value, string propertyPathToAppend)
       where TItem : struct, IJsonValue
    {
        var anyValue = Menes.JsonAny.From(value);
        if (PatternPropertyRegex0.IsMatch(propertyName) && anyValue.As<TestSchema.TestSchemaValue>().Validate(Menes.ValidationContext.Root).IsValid)
        {
            return validationContext;
        }
        return validationContext.WithError("core 9.3.2.2. patternProperties: Unable to match any of the provided patternProperties.");
    }
    public readonly struct TestSchemaValue : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.IEquatable<TestSchemaValue>, System.IEquatable<Menes.JsonArray<Menes.JsonAny>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, TestSchemaValue> FromJsonElement = e => new TestSchemaValue(e);
        public static readonly TestSchemaValue Null = new TestSchemaValue(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<Menes.JsonAny>? value;
        public TestSchemaValue(Menes.JsonArray<Menes.JsonAny> jsonArray)
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
        public TestSchemaValue(System.Text.Json.JsonElement jsonElement)
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
        public TestSchemaValue? AsOptional => this.IsNull ? default(TestSchemaValue?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator TestSchemaValue(Menes.JsonArray<Menes.JsonAny> value)
        {
            return new TestSchemaValue(value);
        }
        public static implicit operator Menes.JsonArray<Menes.JsonAny>(TestSchemaValue value)
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
        public static TestSchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new TestSchemaValue(property)
                    : Null)
                : Null;
        public static TestSchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new TestSchemaValue(property)
                    : Null)
                : Null;
        public static TestSchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new TestSchemaValue(property)
                    : Null)
                : Null;
        public bool Equals(TestSchemaValue other)
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
                context = array.ValidateMinItems(context, 2);
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
        public TestSchemaValue Add(params Menes.JsonAny[] items)
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
        public TestSchemaValue Add(in Menes.JsonAny item1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public TestSchemaValue Add(in Menes.JsonAny item1, in Menes.JsonAny item2)
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
        public TestSchemaValue Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
        public TestSchemaValue Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
        public TestSchemaValue Insert(int indexToInsert, params Menes.JsonAny[] items)
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
        public TestSchemaValue Insert(int indexToInsert, in Menes.JsonAny item1)
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
        public TestSchemaValue Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2)
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
        public TestSchemaValue Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
        public TestSchemaValue Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
        public TestSchemaValue Remove(params Menes.JsonAny[] items)
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
        public TestSchemaValue Remove(Menes.JsonAny item1)
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
        public TestSchemaValue Remove(Menes.JsonAny item1, Menes.JsonAny item2)
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
        public TestSchemaValue Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3)
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
        public TestSchemaValue Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3, Menes.JsonAny item4)
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
        public TestSchemaValue RemoveAt(int indexToRemove)
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
        public TestSchemaValue RemoveRange(int startIndex, int length)
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
        public TestSchemaValue Remove(System.Predicate<Menes.JsonAny> removeIfTrue)
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
    public readonly struct FooArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.IEquatable<FooArray>, System.IEquatable<Menes.JsonArray<Menes.JsonAny>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, FooArray> FromJsonElement = e => new FooArray(e);
        public static readonly FooArray Null = new FooArray(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<Menes.JsonAny>? value;
        public FooArray(Menes.JsonArray<Menes.JsonAny> jsonArray)
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
        public FooArray(System.Text.Json.JsonElement jsonElement)
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
        public FooArray? AsOptional => this.IsNull ? default(FooArray?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator FooArray(Menes.JsonArray<Menes.JsonAny> value)
        {
            return new FooArray(value);
        }
        public static implicit operator Menes.JsonArray<Menes.JsonAny>(FooArray value)
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
        public static FooArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new FooArray(property)
                    : Null)
                : Null;
        public static FooArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new FooArray(property)
                    : Null)
                : Null;
        public static FooArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new FooArray(property)
                    : Null)
                : Null;
        public bool Equals(FooArray other)
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
            context = array.Validate(context);
            context = array.ValidateMaxItems(context, 3);
            context = array.ValidateItems(context);
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
        public FooArray Add(params Menes.JsonAny[] items)
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
        public FooArray Add(in Menes.JsonAny item1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
            foreach (Menes.JsonAny item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public FooArray Add(in Menes.JsonAny item1, in Menes.JsonAny item2)
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
        public FooArray Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
        public FooArray Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
        public FooArray Insert(int indexToInsert, params Menes.JsonAny[] items)
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
        public FooArray Insert(int indexToInsert, in Menes.JsonAny item1)
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
        public FooArray Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2)
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
        public FooArray Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
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
        public FooArray Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
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
        public FooArray Remove(params Menes.JsonAny[] items)
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
        public FooArray Remove(Menes.JsonAny item1)
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
        public FooArray Remove(Menes.JsonAny item1, Menes.JsonAny item2)
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
        public FooArray Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3)
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
        public FooArray Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3, Menes.JsonAny item4)
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
        public FooArray RemoveAt(int indexToRemove)
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
        public FooArray RemoveRange(int startIndex, int length)
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
        public FooArray Remove(System.Predicate<Menes.JsonAny> removeIfTrue)
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
}///  <summary>
/// properties, patternProperties, additionalProperties interaction
/// </summary>
public static class Tests
{
/// <summary>
/// property validates property
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": [1, 2]}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Properties001.Tests.Test0: property validates property");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// property invalidates property
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": [1, 2, 3, 4]}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Properties001.Tests.Test1: property invalidates property");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// patternProperty invalidates property
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": []}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Properties001.Tests.Test2: patternProperty invalidates property");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// patternProperty validates nonproperty
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"fxo\": [1, 2]}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Properties001.Tests.Test3: patternProperty validates nonproperty");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// patternProperty invalidates nonproperty
/// </summary>
    public static bool Test4()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"fxo\": []}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Properties001.Tests.Test4: patternProperty invalidates nonproperty");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// additionalProperty ignores property
/// </summary>
    public static bool Test5()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"bar\": []}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Properties001.Tests.Test5: additionalProperty ignores property");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// additionalProperty validates others
/// </summary>
    public static bool Test6()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"quux\": 3}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Properties001.Tests.Test6: additionalProperty validates others");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// additionalProperty invalidates others
/// </summary>
    public static bool Test7()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"quux\": \"foo\"}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Properties001.Tests.Test7: additionalProperty invalidates others");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}