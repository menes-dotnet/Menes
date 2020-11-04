// <copyright file="ref003.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Ref003
{
public readonly struct TestSchema : Menes.IJsonObject, System.IEquatable<TestSchema>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
{
    public static readonly TestSchema Null = new TestSchema(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, TestSchema> FromJsonElement = e => new TestSchema(e);
    private const string TildePropertyNamePath = ".tilde";
    private const string SlashPropertyNamePath = ".slash";
    private const string PercentPropertyNamePath = ".percent";
    private static readonly System.ReadOnlyMemory<byte> TildePropertyNameBytes = new byte[] { 116, 105, 108, 100, 101 };
    private static readonly System.ReadOnlyMemory<byte> SlashPropertyNameBytes = new byte[] { 115, 108, 97, 115, 104 };
    private static readonly System.ReadOnlyMemory<byte> PercentPropertyNameBytes = new byte[] { 112, 101, 114, 99, 101, 110, 116 };
    private static readonly System.Text.Json.JsonEncodedText EncodedTildePropertyName = System.Text.Json.JsonEncodedText.Encode(TildePropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedSlashPropertyName = System.Text.Json.JsonEncodedText.Encode(SlashPropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedPercentPropertyName = System.Text.Json.JsonEncodedText.Encode(PercentPropertyNameBytes.Span);
    private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(TildePropertyNameBytes, SlashPropertyNameBytes, PercentPropertyNameBytes);
    private readonly Menes.JsonInteger? tilde;
    private readonly Menes.JsonInteger? slash;
    private readonly Menes.JsonInteger? percent;
    private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
    public TestSchema(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
        this.tilde = null;
        this.slash = null;
        this.percent = null;
        this.additionalPropertiesBacking = null;
    }
    public TestSchema(Menes.JsonInteger? tilde, Menes.JsonInteger? slash, Menes.JsonInteger? percent, Menes.JsonProperties<Menes.JsonAny> additionalPropertiesBacking)
    {
        this.tilde = tilde;
        this.slash = slash;
        this.percent = percent;
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public TestSchema(Menes.JsonInteger? tilde, Menes.JsonInteger? slash, Menes.JsonInteger? percent, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
    {
        this.tilde = tilde;
        this.slash = slash;
        this.percent = percent;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
    }
    public TestSchema(Menes.JsonInteger? tilde = null, Menes.JsonInteger? slash = null, Menes.JsonInteger? percent = null)
    {
        this.tilde = tilde;
        this.slash = slash;
        this.percent = percent;
        this.JsonElement = default;
        this.additionalPropertiesBacking = null;
    }
    public TestSchema(Menes.JsonInteger? tilde, Menes.JsonInteger? slash, Menes.JsonInteger? percent, (string, Menes.JsonAny) additionalProperty1)
    {
        this.tilde = tilde;
        this.slash = slash;
        this.percent = percent;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
    }
    public TestSchema(Menes.JsonInteger? tilde, Menes.JsonInteger? slash, Menes.JsonInteger? percent, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
    {
        this.tilde = tilde;
        this.slash = slash;
        this.percent = percent;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
    }
    public TestSchema(Menes.JsonInteger? tilde, Menes.JsonInteger? slash, Menes.JsonInteger? percent, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
    {
        this.tilde = tilde;
        this.slash = slash;
        this.percent = percent;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
    }
    public TestSchema(Menes.JsonInteger? tilde, Menes.JsonInteger? slash, Menes.JsonInteger? percent, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
    {
        this.tilde = tilde;
        this.slash = slash;
        this.percent = percent;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
    }
    private TestSchema(Menes.JsonInteger? tilde, Menes.JsonInteger? slash, Menes.JsonInteger? percent, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
    {
        this.tilde = tilde;
        this.slash = slash;
        this.percent = percent;
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.tilde is null || this.tilde.Value.IsNull) && (this.slash is null || this.slash.Value.IsNull) && (this.percent is null || this.percent.Value.IsNull);
    public TestSchema? AsOptional => this.IsNull ? default(TestSchema?) : this;
    public Menes.JsonInteger? Tilde => this.tilde ?? Menes.JsonInteger.FromOptionalProperty(this.JsonElement, TildePropertyNameBytes.Span).AsOptional;
    public Menes.JsonInteger? Slash => this.slash ?? Menes.JsonInteger.FromOptionalProperty(this.JsonElement, SlashPropertyNameBytes.Span).AsOptional;
    public Menes.JsonInteger? Percent => this.percent ?? Menes.JsonInteger.FromOptionalProperty(this.JsonElement, PercentPropertyNameBytes.Span).AsOptional;
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
    public TestSchema WithTilde(Menes.JsonInteger? value)
    {
        return new TestSchema(value, this.Slash, this.Percent, this.GetJsonProperties());
    }
    public TestSchema WithSlash(Menes.JsonInteger? value)
    {
        return new TestSchema(this.Tilde, value, this.Percent, this.GetJsonProperties());
    }
    public TestSchema WithPercent(Menes.JsonInteger? value)
    {
        return new TestSchema(this.Tilde, this.Slash, value, this.GetJsonProperties());
    }
    public TestSchema ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
    {
        return new TestSchema(this.Tilde, this.Slash, this.Percent, newAdditional);
    }
    public TestSchema ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
    {
        return new TestSchema(this.Tilde, this.Slash, this.Percent, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
    }
    public TestSchema ReplaceAll((string, Menes.JsonAny) newAdditional1)
    {
        return new TestSchema(this.Tilde, this.Slash, this.Percent, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
    }
    public TestSchema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
    {
        return new TestSchema(this.Tilde, this.Slash, this.Percent, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
    }
    public TestSchema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
    {
        return new TestSchema(this.Tilde, this.Slash, this.Percent, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
    }
    public TestSchema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
    {
        return new TestSchema(this.Tilde, this.Slash, this.Percent, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
    }
    public TestSchema Add(params (string, Menes.JsonAny)[] newAdditional)
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
        return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonAny value) newAdditional1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(params string[] namesToRemove)
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
        return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1)
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
        return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1, string itemToRemove2)
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
        return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
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
        return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
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
        return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public TestSchema Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            if (!removeIfTrue(property))
            {
                arrayBuilder.Add(property);
            }
        }
        return new TestSchema(this.Tilde, this.Slash, this.Percent, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            if (this.tilde is Menes.JsonInteger tilde)
            {
                writer.WritePropertyName(EncodedTildePropertyName);
                tilde.WriteTo(writer);
            }
            if (this.slash is Menes.JsonInteger slash)
            {
                writer.WritePropertyName(EncodedSlashPropertyName);
                slash.WriteTo(writer);
            }
            if (this.percent is Menes.JsonInteger percent)
            {
                writer.WritePropertyName(EncodedPercentPropertyName);
                percent.WriteTo(writer);
            }
            Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
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
        return this.Tilde.Equals(other.Tilde) && this.Slash.Equals(other.Slash) && this.Percent.Equals(other.Percent) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
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
            if (this.Tilde is Menes.JsonInteger tilde)
            {
                context = Menes.Validation.ValidateProperty(context, tilde, TildePropertyNamePath);
            }
            if (this.Slash is Menes.JsonInteger slash)
            {
                context = Menes.Validation.ValidateProperty(context, slash, SlashPropertyNamePath);
            }
            if (this.Percent is Menes.JsonInteger percent)
            {
                context = Menes.Validation.ValidateProperty(context, percent, PercentPropertyNamePath);
            }
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                string propertyName = property.Name;
                context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
            }
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
/// escaped pointer ref
/// </summary>
public static class Tests
{
/// <summary>
/// slash invalid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"slash\": \"aoeu\"}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Ref003.Tests.Test0: slash invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// tilde invalid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"tilde\": \"aoeu\"}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Ref003.Tests.Test1: tilde invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// percent invalid
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"percent\": \"aoeu\"}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Ref003.Tests.Test2: percent invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// slash valid
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"slash\": 123}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Ref003.Tests.Test3: slash valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// tilde valid
/// </summary>
    public static bool Test4()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"tilde\": 123}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Ref003.Tests.Test4: tilde valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// percent valid
/// </summary>
    public static bool Test5()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"percent\": 123}");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Ref003.Tests.Test5: percent valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}