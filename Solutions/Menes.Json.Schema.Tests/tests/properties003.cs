// <copyright file="properties003.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Properties003
{
public readonly struct Schema : Menes.IJsonObject, System.IEquatable<Schema>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
{
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    private const string FooBarPropertyNamePath = ".foo\nbar";
    private const string FooBar1PropertyNamePath = ".foo\"bar";
    private const string FooBar2PropertyNamePath = ".foo\\bar";
    private const string FooBar3PropertyNamePath = ".foo\rbar";
    private const string FooBar4PropertyNamePath = ".foo\tbar";
    private const string FooBar5PropertyNamePath = ".foo\fbar";
    private static readonly System.ReadOnlyMemory<byte> FooBarPropertyNameBytes = new byte[] { 102, 111, 111, 10, 98, 97, 114 };
    private static readonly System.ReadOnlyMemory<byte> FooBar1PropertyNameBytes = new byte[] { 102, 111, 111, 34, 98, 97, 114 };
    private static readonly System.ReadOnlyMemory<byte> FooBar2PropertyNameBytes = new byte[] { 102, 111, 111, 92, 98, 97, 114 };
    private static readonly System.ReadOnlyMemory<byte> FooBar3PropertyNameBytes = new byte[] { 102, 111, 111, 13, 98, 97, 114 };
    private static readonly System.ReadOnlyMemory<byte> FooBar4PropertyNameBytes = new byte[] { 102, 111, 111, 9, 98, 97, 114 };
    private static readonly System.ReadOnlyMemory<byte> FooBar5PropertyNameBytes = new byte[] { 102, 111, 111, 12, 98, 97, 114 };
    private static readonly System.Text.Json.JsonEncodedText EncodedFooBarPropertyName = System.Text.Json.JsonEncodedText.Encode(FooBarPropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedFooBar1PropertyName = System.Text.Json.JsonEncodedText.Encode(FooBar1PropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedFooBar2PropertyName = System.Text.Json.JsonEncodedText.Encode(FooBar2PropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedFooBar3PropertyName = System.Text.Json.JsonEncodedText.Encode(FooBar3PropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedFooBar4PropertyName = System.Text.Json.JsonEncodedText.Encode(FooBar4PropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedFooBar5PropertyName = System.Text.Json.JsonEncodedText.Encode(FooBar5PropertyNameBytes.Span);
    private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(FooBarPropertyNameBytes, FooBar1PropertyNameBytes, FooBar2PropertyNameBytes, FooBar3PropertyNameBytes, FooBar4PropertyNameBytes, FooBar5PropertyNameBytes);
    private readonly Menes.JsonNumber? fooBar;
    private readonly Menes.JsonNumber? fooBar1;
    private readonly Menes.JsonNumber? fooBar2;
    private readonly Menes.JsonNumber? fooBar3;
    private readonly Menes.JsonNumber? fooBar4;
    private readonly Menes.JsonNumber? fooBar5;
    private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
        this.fooBar = null;
        this.fooBar1 = null;
        this.fooBar2 = null;
        this.fooBar3 = null;
        this.fooBar4 = null;
        this.fooBar5 = null;
        this.additionalPropertiesBacking = null;
    }
    public Schema(Menes.JsonNumber? fooBar, Menes.JsonNumber? fooBar1, Menes.JsonNumber? fooBar2, Menes.JsonNumber? fooBar3, Menes.JsonNumber? fooBar4, Menes.JsonNumber? fooBar5, Menes.JsonProperties<Menes.JsonAny> additionalPropertiesBacking)
    {
        this.fooBar = fooBar;
        this.fooBar1 = fooBar1;
        this.fooBar2 = fooBar2;
        this.fooBar3 = fooBar3;
        this.fooBar4 = fooBar4;
        this.fooBar5 = fooBar5;
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public Schema(Menes.JsonNumber? fooBar, Menes.JsonNumber? fooBar1, Menes.JsonNumber? fooBar2, Menes.JsonNumber? fooBar3, Menes.JsonNumber? fooBar4, Menes.JsonNumber? fooBar5, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
    {
        this.fooBar = fooBar;
        this.fooBar1 = fooBar1;
        this.fooBar2 = fooBar2;
        this.fooBar3 = fooBar3;
        this.fooBar4 = fooBar4;
        this.fooBar5 = fooBar5;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
    }
    public Schema(Menes.JsonNumber? fooBar = null, Menes.JsonNumber? fooBar1 = null, Menes.JsonNumber? fooBar2 = null, Menes.JsonNumber? fooBar3 = null, Menes.JsonNumber? fooBar4 = null, Menes.JsonNumber? fooBar5 = null)
    {
        this.fooBar = fooBar;
        this.fooBar1 = fooBar1;
        this.fooBar2 = fooBar2;
        this.fooBar3 = fooBar3;
        this.fooBar4 = fooBar4;
        this.fooBar5 = fooBar5;
        this.JsonElement = default;
        this.additionalPropertiesBacking = null;
    }
    public Schema(Menes.JsonNumber? fooBar, Menes.JsonNumber? fooBar1, Menes.JsonNumber? fooBar2, Menes.JsonNumber? fooBar3, Menes.JsonNumber? fooBar4, Menes.JsonNumber? fooBar5, (string, Menes.JsonAny) additionalProperty1)
    {
        this.fooBar = fooBar;
        this.fooBar1 = fooBar1;
        this.fooBar2 = fooBar2;
        this.fooBar3 = fooBar3;
        this.fooBar4 = fooBar4;
        this.fooBar5 = fooBar5;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
    }
    public Schema(Menes.JsonNumber? fooBar, Menes.JsonNumber? fooBar1, Menes.JsonNumber? fooBar2, Menes.JsonNumber? fooBar3, Menes.JsonNumber? fooBar4, Menes.JsonNumber? fooBar5, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
    {
        this.fooBar = fooBar;
        this.fooBar1 = fooBar1;
        this.fooBar2 = fooBar2;
        this.fooBar3 = fooBar3;
        this.fooBar4 = fooBar4;
        this.fooBar5 = fooBar5;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
    }
    public Schema(Menes.JsonNumber? fooBar, Menes.JsonNumber? fooBar1, Menes.JsonNumber? fooBar2, Menes.JsonNumber? fooBar3, Menes.JsonNumber? fooBar4, Menes.JsonNumber? fooBar5, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
    {
        this.fooBar = fooBar;
        this.fooBar1 = fooBar1;
        this.fooBar2 = fooBar2;
        this.fooBar3 = fooBar3;
        this.fooBar4 = fooBar4;
        this.fooBar5 = fooBar5;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
    }
    public Schema(Menes.JsonNumber? fooBar, Menes.JsonNumber? fooBar1, Menes.JsonNumber? fooBar2, Menes.JsonNumber? fooBar3, Menes.JsonNumber? fooBar4, Menes.JsonNumber? fooBar5, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
    {
        this.fooBar = fooBar;
        this.fooBar1 = fooBar1;
        this.fooBar2 = fooBar2;
        this.fooBar3 = fooBar3;
        this.fooBar4 = fooBar4;
        this.fooBar5 = fooBar5;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
    }
    private Schema(Menes.JsonNumber? fooBar, Menes.JsonNumber? fooBar1, Menes.JsonNumber? fooBar2, Menes.JsonNumber? fooBar3, Menes.JsonNumber? fooBar4, Menes.JsonNumber? fooBar5, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
    {
        this.fooBar = fooBar;
        this.fooBar1 = fooBar1;
        this.fooBar2 = fooBar2;
        this.fooBar3 = fooBar3;
        this.fooBar4 = fooBar4;
        this.fooBar5 = fooBar5;
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.fooBar is null || this.fooBar.Value.IsNull) && (this.fooBar1 is null || this.fooBar1.Value.IsNull) && (this.fooBar2 is null || this.fooBar2.Value.IsNull) && (this.fooBar3 is null || this.fooBar3.Value.IsNull) && (this.fooBar4 is null || this.fooBar4.Value.IsNull) && (this.fooBar5 is null || this.fooBar5.Value.IsNull);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
    public Menes.JsonNumber? FooBar => this.fooBar ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, FooBarPropertyNameBytes.Span).AsOptional;
    public Menes.JsonNumber? FooBar1 => this.fooBar1 ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, FooBar1PropertyNameBytes.Span).AsOptional;
    public Menes.JsonNumber? FooBar2 => this.fooBar2 ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, FooBar2PropertyNameBytes.Span).AsOptional;
    public Menes.JsonNumber? FooBar3 => this.fooBar3 ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, FooBar3PropertyNameBytes.Span).AsOptional;
    public Menes.JsonNumber? FooBar4 => this.fooBar4 ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, FooBar4PropertyNameBytes.Span).AsOptional;
    public Menes.JsonNumber? FooBar5 => this.fooBar5 ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, FooBar5PropertyNameBytes.Span).AsOptional;
    public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
    public int JsonAdditionalPropertiesCount
    {
        get
        {
            Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
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
    public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
    {
        get
        {
            if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> ap)
            {
                return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(ap, KnownProperties);
            }

            if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
            {
                return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
            }

            return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonAny>.Empty, KnownProperties);
        }
    }
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
    public Schema WithFooBar(Menes.JsonNumber? value)
    {
        return new Schema(value, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, this.GetJsonProperties());
    }
    public Schema WithFooBar1(Menes.JsonNumber? value)
    {
        return new Schema(this.FooBar, value, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, this.GetJsonProperties());
    }
    public Schema WithFooBar2(Menes.JsonNumber? value)
    {
        return new Schema(this.FooBar, this.FooBar1, value, this.FooBar3, this.FooBar4, this.FooBar5, this.GetJsonProperties());
    }
    public Schema WithFooBar3(Menes.JsonNumber? value)
    {
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, value, this.FooBar4, this.FooBar5, this.GetJsonProperties());
    }
    public Schema WithFooBar4(Menes.JsonNumber? value)
    {
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, value, this.FooBar5, this.GetJsonProperties());
    }
    public Schema WithFooBar5(Menes.JsonNumber? value)
    {
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, value, this.GetJsonProperties());
    }
    public Schema ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
    {
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, newAdditional);
    }
    public Schema ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
    {
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
    }
    public Schema ReplaceAll((string, Menes.JsonAny) newAdditional1)
    {
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
    }
    public Schema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
    {
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
    }
    public Schema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
    {
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
    }
    public Schema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
    {
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
    }
    public Schema Add(params (string, Menes.JsonAny)[] newAdditional)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        foreach ((string name, Menes.JsonAny value) in newAdditional)
        {
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(name, value));
        }
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonAny value) newAdditional1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(params string[] namesToRemove)
    {
        System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1, string itemToRemove2)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
    {
        System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
        ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            if (!ihs.Contains(property.Name))
            {
                arrayBuilder.Add(property);
            }
        }
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            if (!removeIfTrue(property))
            {
                arrayBuilder.Add(property);
            }
        }
        return new Schema(this.FooBar, this.FooBar1, this.FooBar2, this.FooBar3, this.FooBar4, this.FooBar5, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            if (this.fooBar is Menes.JsonNumber fooBar)
            {
                writer.WritePropertyName(EncodedFooBarPropertyName);
                fooBar.WriteTo(writer);
            }
            if (this.fooBar1 is Menes.JsonNumber fooBar1)
            {
                writer.WritePropertyName(EncodedFooBar1PropertyName);
                fooBar1.WriteTo(writer);
            }
            if (this.fooBar2 is Menes.JsonNumber fooBar2)
            {
                writer.WritePropertyName(EncodedFooBar2PropertyName);
                fooBar2.WriteTo(writer);
            }
            if (this.fooBar3 is Menes.JsonNumber fooBar3)
            {
                writer.WritePropertyName(EncodedFooBar3PropertyName);
                fooBar3.WriteTo(writer);
            }
            if (this.fooBar4 is Menes.JsonNumber fooBar4)
            {
                writer.WritePropertyName(EncodedFooBar4PropertyName);
                fooBar4.WriteTo(writer);
            }
            if (this.fooBar5 is Menes.JsonNumber fooBar5)
            {
                writer.WritePropertyName(EncodedFooBar5PropertyName);
                fooBar5.WriteTo(writer);
            }
            Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
            while (enumerator.MoveNext())
            {
                enumerator.Current.Write(writer);
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
        return this.FooBar.Equals(other.FooBar) && this.FooBar1.Equals(other.FooBar1) && this.FooBar2.Equals(other.FooBar2) && this.FooBar3.Equals(other.FooBar3) && this.FooBar4.Equals(other.FooBar4) && this.FooBar5.Equals(other.FooBar5) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        if (this.IsNull)
        {
            return validationContext.WithError($"6.1.1. type: the element with type {{this.JsonElement.ValueKind}} is not convertible to {{JsonValueKind.Object}}");
        }
        Menes.ValidationContext context = validationContext;
        if (this.FooBar is Menes.JsonNumber fooBar)
        {
            context = Menes.Validation.ValidateProperty(context, fooBar, FooBarPropertyNamePath);
        }
        if (this.FooBar1 is Menes.JsonNumber fooBar1)
        {
            context = Menes.Validation.ValidateProperty(context, fooBar1, FooBar1PropertyNamePath);
        }
        if (this.FooBar2 is Menes.JsonNumber fooBar2)
        {
            context = Menes.Validation.ValidateProperty(context, fooBar2, FooBar2PropertyNamePath);
        }
        if (this.FooBar3 is Menes.JsonNumber fooBar3)
        {
            context = Menes.Validation.ValidateProperty(context, fooBar3, FooBar3PropertyNamePath);
        }
        if (this.FooBar4 is Menes.JsonNumber fooBar4)
        {
            context = Menes.Validation.ValidateProperty(context, fooBar4, FooBar4PropertyNamePath);
        }
        if (this.FooBar5 is Menes.JsonNumber fooBar5)
        {
            context = Menes.Validation.ValidateProperty(context, fooBar5, FooBar5PropertyNamePath);
        }
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            string propertyName = property.Name;
            context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
        }
        return context;
    }
    public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
    {
        return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
    }
    public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
    {
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
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
    public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
    {
        System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
        int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
        return this.TryGet(bytes.Slice(0, written), out value);
    }
    public override string ToString()
    {
        return Menes.JsonAny.From(this).ToString();
    }
    private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
    {
        if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
        {
            return props;
        }
        return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
    }
}///  <summary>
/// properties with escaped characters
/// </summary>
public static class Tests
{
/// <summary>
/// object with all numbers is valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"foo\\nbar\": 1,\r\n                    \"foo\\\"bar\": 1,\r\n                    \"foo\\\\bar\": 1,\r\n                    \"foo\\rbar\": 1,\r\n                    \"foo\\tbar\": 1,\r\n                    \"foo\\fbar\": 1\r\n                }");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Properties003.Tests.Test0: object with all numbers is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// object with strings is invalid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"foo\\nbar\": \"1\",\r\n                    \"foo\\\"bar\": \"1\",\r\n                    \"foo\\\\bar\": \"1\",\r\n                    \"foo\\rbar\": \"1\",\r\n                    \"foo\\tbar\": \"1\",\r\n                    \"foo\\fbar\": \"1\"\r\n                }");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Properties003.Tests.Test1: object with strings is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}