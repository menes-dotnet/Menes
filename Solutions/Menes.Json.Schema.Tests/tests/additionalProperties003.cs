// <copyright file="additionalProperties003.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.AdditionalProperties003
{
public readonly struct Schema : Menes.IJsonObject, System.IEquatable<Schema>, Menes.IJsonAdditionalProperties<Menes.JsonBoolean>
{
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
    private readonly Menes.JsonProperties<Menes.JsonBoolean>? additionalPropertiesBacking;
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
        this.additionalPropertiesBacking = null;
    }
    public Schema(params (string, Menes.JsonBoolean)[] additionalPropertiesBacking)
    {
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonBoolean>.FromValues(additionalPropertiesBacking);
    }
    public Schema((string, Menes.JsonBoolean) additionalProperty1)
    {
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonBoolean>.FromValues(additionalProperty1);
    }
    public Schema((string, Menes.JsonBoolean) additionalProperty1, (string, Menes.JsonBoolean) additionalProperty2)
    {
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonBoolean>.FromValues(additionalProperty1, additionalProperty2);
    }
    public Schema((string, Menes.JsonBoolean) additionalProperty1, (string, Menes.JsonBoolean) additionalProperty2, (string, Menes.JsonBoolean) additionalProperty3)
    {
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonBoolean>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
    }
    public Schema((string, Menes.JsonBoolean) additionalProperty1, (string, Menes.JsonBoolean) additionalProperty2, (string, Menes.JsonBoolean) additionalProperty3, (string, Menes.JsonBoolean) additionalProperty4)
    {
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonBoolean>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
    }
    private Schema(Menes.JsonProperties<Menes.JsonBoolean>? additionalPropertiesBacking)
    {
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
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
    public Schema ReplaceAll(Menes.JsonProperties<Menes.JsonBoolean> newAdditional)
    {
        return new Schema(newAdditional);
    }
    public Schema ReplaceAll(params (string, Menes.JsonBoolean)[] newAdditional)
    {
        return new Schema(Menes.JsonProperties<Menes.JsonBoolean>.FromValues(newAdditional));
    }
    public Schema ReplaceAll((string, Menes.JsonBoolean) newAdditional1)
    {
        return new Schema(Menes.JsonProperties<Menes.JsonBoolean>.FromValues(newAdditional1));
    }
    public Schema ReplaceAll((string, Menes.JsonBoolean) newAdditional1, (string, Menes.JsonBoolean) newAdditional2)
    {
        return new Schema(Menes.JsonProperties<Menes.JsonBoolean>.FromValues(newAdditional1, newAdditional2));
    }
    public Schema ReplaceAll((string, Menes.JsonBoolean) newAdditional1, (string, Menes.JsonBoolean) newAdditional2, (string, Menes.JsonBoolean) newAdditional3)
    {
        return new Schema(Menes.JsonProperties<Menes.JsonBoolean>.FromValues(newAdditional1, newAdditional2, newAdditional3));
    }
    public Schema ReplaceAll((string, Menes.JsonBoolean) newAdditional1, (string, Menes.JsonBoolean) newAdditional2, (string, Menes.JsonBoolean) newAdditional3, (string, Menes.JsonBoolean) newAdditional4)
    {
        return new Schema(Menes.JsonProperties<Menes.JsonBoolean>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
    }
    public Schema Add(params (string, Menes.JsonBoolean)[] newAdditional)
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
        return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonBoolean value) newAdditional1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional1.name, newAdditional1.value)); return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonBoolean value) newAdditional1, (string name, Menes.JsonBoolean value) newAdditional2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional2.name, newAdditional2.value)); return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonBoolean value) newAdditional1, (string name, Menes.JsonBoolean value) newAdditional2, (string name, Menes.JsonBoolean value) newAdditional3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional3.name, newAdditional3.value)); return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonBoolean value) newAdditional1, (string name, Menes.JsonBoolean value) newAdditional2, (string name, Menes.JsonBoolean value) newAdditional3, (string name, Menes.JsonBoolean value) newAdditional4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonBoolean>.From(newAdditional4.name, newAdditional4.value)); return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(params string[] namesToRemove)
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
        return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1)
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
        return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1, string itemToRemove2)
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
        return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
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
        return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
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
        return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonBoolean>> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonBoolean>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonBoolean>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonBoolean> property in this.JsonAdditionalProperties)
        {
            if (!removeIfTrue(property))
            {
                arrayBuilder.Add(property);
            }
        }
        return new Schema(new Menes.JsonProperties<Menes.JsonBoolean>(arrayBuilder.ToImmutable()));
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
            Menes.JsonProperties<Menes.JsonBoolean>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
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
        return System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
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
/// additionalProperties can exist by itself
/// </summary>
public static class Tests
{
/// <summary>
/// an additional valid property is valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\" : true}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties003.Tests.Test0: an additional valid property is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// an additional invalid property is invalid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\" : 1}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed AdditionalProperties003.Tests.Test1: an additional invalid property is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}