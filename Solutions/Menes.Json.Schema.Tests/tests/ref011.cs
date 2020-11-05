// <copyright file="ref011.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Ref011
{
public readonly struct HttpLocalhost1234Tree : Menes.IJsonObject, System.IEquatable<HttpLocalhost1234Tree>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
{
    public static readonly HttpLocalhost1234Tree Null = new HttpLocalhost1234Tree(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, HttpLocalhost1234Tree> FromJsonElement = e => new HttpLocalhost1234Tree(e);
    private const string MetaPropertyNamePath = ".meta";
    private const string NodesPropertyNamePath = ".nodes";
    private static readonly System.ReadOnlyMemory<byte> MetaPropertyNameBytes = new byte[] { 109, 101, 116, 97 };
    private static readonly System.ReadOnlyMemory<byte> NodesPropertyNameBytes = new byte[] { 110, 111, 100, 101, 115 };
    private static readonly System.Text.Json.JsonEncodedText EncodedMetaPropertyName = System.Text.Json.JsonEncodedText.Encode(MetaPropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedNodesPropertyName = System.Text.Json.JsonEncodedText.Encode(NodesPropertyNameBytes.Span);
    private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(MetaPropertyNameBytes, NodesPropertyNameBytes);
    private readonly Menes.JsonString? meta;
    private readonly Menes.JsonReference? nodes;
    private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
    public HttpLocalhost1234Tree(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
        this.meta = null;
        this.nodes = null;
        this.additionalPropertiesBacking = null;
    }
    public HttpLocalhost1234Tree(Menes.JsonString meta, HttpLocalhost1234Tree.NodesArray nodes)
    {
        this.meta = meta;
        if (nodes is HttpLocalhost1234Tree.NodesArray item1)
        {
            this.nodes = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.nodes = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = null;
    }
    public HttpLocalhost1234Tree(Menes.JsonString meta, HttpLocalhost1234Tree.NodesArray nodes, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
    {
        this.meta = meta;
        if (nodes is HttpLocalhost1234Tree.NodesArray item1)
        {
            this.nodes = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.nodes = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
    }
    public HttpLocalhost1234Tree(Menes.JsonString meta, HttpLocalhost1234Tree.NodesArray nodes, (string, Menes.JsonAny) additionalProperty1)
    {
        this.meta = meta;
        if (nodes is HttpLocalhost1234Tree.NodesArray item1)
        {
            this.nodes = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.nodes = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
    }
    public HttpLocalhost1234Tree(Menes.JsonString meta, HttpLocalhost1234Tree.NodesArray nodes, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
    {
        this.meta = meta;
        if (nodes is HttpLocalhost1234Tree.NodesArray item1)
        {
            this.nodes = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.nodes = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
    }
    public HttpLocalhost1234Tree(Menes.JsonString meta, HttpLocalhost1234Tree.NodesArray nodes, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
    {
        this.meta = meta;
        if (nodes is HttpLocalhost1234Tree.NodesArray item1)
        {
            this.nodes = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.nodes = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
    }
    public HttpLocalhost1234Tree(Menes.JsonString meta, HttpLocalhost1234Tree.NodesArray nodes, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
    {
        this.meta = meta;
        if (nodes is HttpLocalhost1234Tree.NodesArray item1)
        {
            this.nodes = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.nodes = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
    }
    private HttpLocalhost1234Tree(Menes.JsonString meta, Menes.JsonReference nodes, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
    {
        this.meta = meta;
        if (nodes is Menes.JsonReference item1)
        {
            this.nodes = item1;
        }
        else
        {
            this.nodes = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.meta is null || this.meta.Value.IsNull) && (this.nodes is null || this.nodes.Value.IsNull);
    public HttpLocalhost1234Tree? AsOptional => this.IsNull ? default(HttpLocalhost1234Tree?) : this;
    public Menes.JsonString Meta => this.meta ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, MetaPropertyNameBytes.Span);
    public HttpLocalhost1234Tree.NodesArray Nodes => this.nodes?.AsValue<HttpLocalhost1234Tree.NodesArray>() ?? HttpLocalhost1234Tree.NodesArray.FromOptionalProperty(this.JsonElement, NodesPropertyNameBytes.Span);
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
    public static HttpLocalhost1234Tree FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new HttpLocalhost1234Tree(property)
                : Null)
            : Null;
    public static HttpLocalhost1234Tree FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new HttpLocalhost1234Tree(property)
                : Null)
            : Null;
    public static HttpLocalhost1234Tree FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new HttpLocalhost1234Tree(property)
                : Null)
        : Null;
    public HttpLocalhost1234Tree WithMeta(Menes.JsonString value)
    {
        return new HttpLocalhost1234Tree(value, this.GetNodes(), this.GetJsonProperties());
    }
    public HttpLocalhost1234Tree WithNodes(HttpLocalhost1234Tree.NodesArray value)
    {
        return new HttpLocalhost1234Tree(this.Meta, Menes.JsonReference.FromValue(value), this.GetJsonProperties());
    }
    public HttpLocalhost1234Tree ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
    {
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), newAdditional);
    }
    public HttpLocalhost1234Tree ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
    {
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
    }
    public HttpLocalhost1234Tree ReplaceAll((string, Menes.JsonAny) newAdditional1)
    {
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
    }
    public HttpLocalhost1234Tree ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
    {
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
    }
    public HttpLocalhost1234Tree ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
    {
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
    }
    public HttpLocalhost1234Tree ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
    {
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
    }
    public HttpLocalhost1234Tree Add(params (string, Menes.JsonAny)[] newAdditional)
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
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Tree Add((string name, Menes.JsonAny value) newAdditional1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Tree Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Tree Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Tree Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Tree Remove(params string[] namesToRemove)
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
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Tree Remove(string itemToRemove1)
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
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Tree Remove(string itemToRemove1, string itemToRemove2)
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
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Tree Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
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
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Tree Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
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
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Tree Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            if (!removeIfTrue(property))
            {
                arrayBuilder.Add(property);
            }
        }
        return new HttpLocalhost1234Tree(this.Meta, this.GetNodes(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            if (this.meta is Menes.JsonString meta)
            {
                writer.WritePropertyName(EncodedMetaPropertyName);
                meta.WriteTo(writer);
            }
            if (this.nodes is Menes.JsonReference nodes)
            {
                writer.WritePropertyName(EncodedNodesPropertyName);
                nodes.WriteTo(writer);
            }
            Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
            while (enumerator.MoveNext())
            {
                enumerator.Current.Write(writer);
            }
            writer.WriteEndObject();
        }
    }
    public bool Equals(HttpLocalhost1234Tree other)
    {
        if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
        {
            return false;
        }
        if (this.HasJsonElement && other.HasJsonElement)
        {
            return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
        }
        return this.Meta.Equals(other.Meta) && this.Nodes.Equals(other.Nodes) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        if (this.IsNull)
        {
            return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
        }
        if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
        {
            return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
        }
        Menes.ValidationContext context = validationContext;
        context = Menes.Validation.ValidateRequiredProperty(context, this.Meta, MetaPropertyNamePath);
        context = Menes.Validation.ValidateRequiredProperty(context, this.Nodes, NodesPropertyNamePath);
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
    private Menes.JsonReference GetNodes()
    {
        if (this.nodes is Menes.JsonReference reference)
        {
            return reference;
        }
        if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(NodesPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
        {
            return new Menes.JsonReference(value);
        }
        return default;
    }
    private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
    {
        if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
        {
            return props;
        }
        return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
    }
    public readonly struct NodesArray : Menes.IJsonValue, System.Collections.Generic.IEnumerable<HttpLocalhost1234Node>, System.Collections.IEnumerable, System.IEquatable<NodesArray>, System.IEquatable<Menes.JsonArray<HttpLocalhost1234Node>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, NodesArray> FromJsonElement = e => new NodesArray(e);
        public static readonly NodesArray Null = new NodesArray(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<HttpLocalhost1234Node>? value;
        public NodesArray(Menes.JsonArray<HttpLocalhost1234Node> jsonArray)
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
        public NodesArray(System.Text.Json.JsonElement jsonElement)
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
                if (this.value is Menes.JsonArray<HttpLocalhost1234Node> value)
                {
                    return value.Length;
                }
                return 0;
            }
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public NodesArray? AsOptional => this.IsNull ? default(NodesArray?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator NodesArray(Menes.JsonArray<HttpLocalhost1234Node> value)
        {
            return new NodesArray(value);
        }
        public static implicit operator Menes.JsonArray<HttpLocalhost1234Node>(NodesArray value)
        {
            if (value.value is Menes.JsonArray<HttpLocalhost1234Node> clrValue)
            {
                return clrValue;
            }
            return new Menes.JsonArray<HttpLocalhost1234Node>(value.JsonElement);
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return Menes.JsonArray<HttpLocalhost1234Node>.IsConvertibleFrom(jsonElement);
        }
        public static NodesArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new NodesArray(property)
                    : Null)
                : Null;
        public static NodesArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new NodesArray(property)
                    : Null)
                : Null;
        public static NodesArray FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new NodesArray(property)
                    : Null)
                : Null;
        public bool Equals(NodesArray other)
        {
            return this.Equals((Menes.JsonArray<HttpLocalhost1234Node>)other);
        }
        public bool Equals(Menes.JsonArray<HttpLocalhost1234Node> other)
        {
            return ((Menes.JsonArray<HttpLocalhost1234Node>)this).Equals(other);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.JsonArray<HttpLocalhost1234Node> array = this;
            Menes.ValidationContext context = validationContext;
            context = array.Validate(context);
            context = array.ValidateItems(context);
            return context;
        }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }
            if (this.value is Menes.JsonArray<HttpLocalhost1234Node> clrValue)
            {
                clrValue.WriteTo(writer);
            }
        }
        public Menes.JsonArray<HttpLocalhost1234Node>.JsonArrayEnumerator GetEnumerator()
        {
            return ((Menes.JsonArray<HttpLocalhost1234Node>)this).GetEnumerator();
        }
        System.Collections.Generic.IEnumerator<HttpLocalhost1234Node> System.Collections.Generic.IEnumerable<HttpLocalhost1234Node>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public NodesArray Add(params HttpLocalhost1234Node[] items)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
            {
                arrayBuilder.Add(item);
            }
            foreach (HttpLocalhost1234Node item in items)
            {
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public NodesArray Add(in HttpLocalhost1234Node item1)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public NodesArray Add(in HttpLocalhost1234Node item1, in HttpLocalhost1234Node item2)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public NodesArray Add(in HttpLocalhost1234Node item1, in HttpLocalhost1234Node item2, in HttpLocalhost1234Node item3)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            arrayBuilder.Add(item3);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public NodesArray Add(in HttpLocalhost1234Node item1, in HttpLocalhost1234Node item2, in HttpLocalhost1234Node item3, in HttpLocalhost1234Node item4)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
            {
                arrayBuilder.Add(item);
            }
            arrayBuilder.Add(item1);
            arrayBuilder.Add(item2);
            arrayBuilder.Add(item3);
            arrayBuilder.Add(item4);
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public NodesArray Insert(int indexToInsert, params HttpLocalhost1234Node[] items)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            int index = 0;
            foreach (HttpLocalhost1234Node item in this)
            {
                if (index == indexToInsert)
                {
                    foreach (HttpLocalhost1234Node itemToInsert in items)
                    {
                        arrayBuilder.Add(itemToInsert);
                    }
                }
                arrayBuilder.Add(item);
                ++index;
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public NodesArray Insert(int indexToInsert, in HttpLocalhost1234Node item1)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            int index = 0;
            foreach (HttpLocalhost1234Node item in this)
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
        public NodesArray Insert(int indexToInsert, in HttpLocalhost1234Node item1, in HttpLocalhost1234Node item2)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            int index = 0;
            foreach (HttpLocalhost1234Node item in this)
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
        public NodesArray Insert(int indexToInsert, in HttpLocalhost1234Node item1, in HttpLocalhost1234Node item2, in HttpLocalhost1234Node item3)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            int index = 0;
            foreach (HttpLocalhost1234Node item in this)
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
        public NodesArray Insert(int indexToInsert, in HttpLocalhost1234Node item1, in HttpLocalhost1234Node item2, in HttpLocalhost1234Node item3, in HttpLocalhost1234Node item4)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            int index = 0;
            foreach (HttpLocalhost1234Node item in this)
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
        public NodesArray Remove(params HttpLocalhost1234Node[] items)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
            {
                bool found = false;
                foreach (HttpLocalhost1234Node itemToRemove in items)
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
        public NodesArray Remove(HttpLocalhost1234Node item1)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
            {
                if (item1.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public NodesArray Remove(HttpLocalhost1234Node item1, HttpLocalhost1234Node item2)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
            {
                if (item1.Equals(item) || item2.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public NodesArray Remove(HttpLocalhost1234Node item1, HttpLocalhost1234Node item2, HttpLocalhost1234Node item3)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
            {
                if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public NodesArray Remove(HttpLocalhost1234Node item1, HttpLocalhost1234Node item2, HttpLocalhost1234Node item3, HttpLocalhost1234Node item4)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
            {
                if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                {
                    break;
                }
                arrayBuilder.Add(item);
            }
            return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
        }
        public NodesArray RemoveAt(int indexToRemove)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            int index = 0;
            foreach (HttpLocalhost1234Node item in this)
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
        public NodesArray RemoveRange(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex > this.Length - 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (length < 1 || startIndex + length > this.Length - 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(length));
            }
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            int index = 0;
            foreach (HttpLocalhost1234Node item in this)
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
        public NodesArray Remove(System.Predicate<HttpLocalhost1234Node> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<HttpLocalhost1234Node>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<HttpLocalhost1234Node>();
            foreach (HttpLocalhost1234Node item in this)
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
}public readonly struct HttpLocalhost1234Node : Menes.IJsonObject, System.IEquatable<HttpLocalhost1234Node>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
{
    public static readonly HttpLocalhost1234Node Null = new HttpLocalhost1234Node(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, HttpLocalhost1234Node> FromJsonElement = e => new HttpLocalhost1234Node(e);
    private const string ValuePropertyNamePath = ".value";
    private const string SubtreePropertyNamePath = ".subtree";
    private static readonly System.ReadOnlyMemory<byte> ValuePropertyNameBytes = new byte[] { 118, 97, 108, 117, 101 };
    private static readonly System.ReadOnlyMemory<byte> SubtreePropertyNameBytes = new byte[] { 115, 117, 98, 116, 114, 101, 101 };
    private static readonly System.Text.Json.JsonEncodedText EncodedValuePropertyName = System.Text.Json.JsonEncodedText.Encode(ValuePropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedSubtreePropertyName = System.Text.Json.JsonEncodedText.Encode(SubtreePropertyNameBytes.Span);
    private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(ValuePropertyNameBytes, SubtreePropertyNameBytes);
    private readonly Menes.JsonNumber? value;
    private readonly Menes.JsonReference? subtree;
    private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
    public HttpLocalhost1234Node(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
        this.value = null;
        this.subtree = null;
        this.additionalPropertiesBacking = null;
    }
    public HttpLocalhost1234Node(Menes.JsonNumber value)
    {
        this.value = value;
        this.subtree = null;
        this.JsonElement = default;
        this.additionalPropertiesBacking = null;
    }
    public HttpLocalhost1234Node(Menes.JsonNumber value, HttpLocalhost1234Tree? subtree, Menes.JsonProperties<Menes.JsonAny> additionalPropertiesBacking)
    {
        this.value = value;
        if (subtree is HttpLocalhost1234Tree item1)
        {
            this.subtree = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.subtree = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public HttpLocalhost1234Node(Menes.JsonNumber value, HttpLocalhost1234Tree? subtree, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
    {
        this.value = value;
        if (subtree is HttpLocalhost1234Tree item1)
        {
            this.subtree = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.subtree = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
    }
    public HttpLocalhost1234Node(Menes.JsonNumber value, HttpLocalhost1234Tree? subtree = null)
    {
        this.value = value;
        if (subtree is HttpLocalhost1234Tree item1)
        {
            this.subtree = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.subtree = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = null;
    }
    public HttpLocalhost1234Node(Menes.JsonNumber value, HttpLocalhost1234Tree? subtree, (string, Menes.JsonAny) additionalProperty1)
    {
        this.value = value;
        if (subtree is HttpLocalhost1234Tree item1)
        {
            this.subtree = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.subtree = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
    }
    public HttpLocalhost1234Node(Menes.JsonNumber value, HttpLocalhost1234Tree? subtree, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
    {
        this.value = value;
        if (subtree is HttpLocalhost1234Tree item1)
        {
            this.subtree = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.subtree = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
    }
    public HttpLocalhost1234Node(Menes.JsonNumber value, HttpLocalhost1234Tree? subtree, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
    {
        this.value = value;
        if (subtree is HttpLocalhost1234Tree item1)
        {
            this.subtree = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.subtree = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
    }
    public HttpLocalhost1234Node(Menes.JsonNumber value, HttpLocalhost1234Tree? subtree, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
    {
        this.value = value;
        if (subtree is HttpLocalhost1234Tree item1)
        {
            this.subtree = Menes.JsonReference.FromValue(item1);
        }
        else
        {
            this.subtree = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
    }
    private HttpLocalhost1234Node(Menes.JsonNumber value, Menes.JsonReference? subtree, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
    {
        this.value = value;
        if (subtree is Menes.JsonReference item1)
        {
            this.subtree = item1;
        }
        else
        {
            this.subtree = null;
        }
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.value is null || this.value.Value.IsNull) && (this.subtree is null || this.subtree.Value.IsNull);
    public HttpLocalhost1234Node? AsOptional => this.IsNull ? default(HttpLocalhost1234Node?) : this;
    public Menes.JsonNumber Value => this.value ?? Menes.JsonNumber.FromOptionalProperty(this.JsonElement, ValuePropertyNameBytes.Span);
    public HttpLocalhost1234Tree? Subtree => this.subtree?.AsValue<HttpLocalhost1234Tree>() ?? HttpLocalhost1234Tree.FromOptionalProperty(this.JsonElement, SubtreePropertyNameBytes.Span).AsOptional;
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
    public static HttpLocalhost1234Node FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new HttpLocalhost1234Node(property)
                : Null)
            : Null;
    public static HttpLocalhost1234Node FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new HttpLocalhost1234Node(property)
                : Null)
            : Null;
    public static HttpLocalhost1234Node FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new HttpLocalhost1234Node(property)
                : Null)
        : Null;
    public HttpLocalhost1234Node WithValue(Menes.JsonNumber value)
    {
        return new HttpLocalhost1234Node(value, this.GetSubtree(), this.GetJsonProperties());
    }
    public HttpLocalhost1234Node WithSubtree(HttpLocalhost1234Tree? value)
    {
        return new HttpLocalhost1234Node(this.Value, Menes.JsonReference.FromValue(value), this.GetJsonProperties());
    }
    public HttpLocalhost1234Node ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
    {
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), newAdditional);
    }
    public HttpLocalhost1234Node ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
    {
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
    }
    public HttpLocalhost1234Node ReplaceAll((string, Menes.JsonAny) newAdditional1)
    {
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
    }
    public HttpLocalhost1234Node ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
    {
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
    }
    public HttpLocalhost1234Node ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
    {
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
    }
    public HttpLocalhost1234Node ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
    {
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
    }
    public HttpLocalhost1234Node Add(params (string, Menes.JsonAny)[] newAdditional)
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
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Node Add((string name, Menes.JsonAny value) newAdditional1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Node Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Node Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Node Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Node Remove(params string[] namesToRemove)
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
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Node Remove(string itemToRemove1)
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
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Node Remove(string itemToRemove1, string itemToRemove2)
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
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Node Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
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
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Node Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
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
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public HttpLocalhost1234Node Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            if (!removeIfTrue(property))
            {
                arrayBuilder.Add(property);
            }
        }
        return new HttpLocalhost1234Node(this.Value, this.GetSubtree(), new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            if (this.value is Menes.JsonNumber value)
            {
                writer.WritePropertyName(EncodedValuePropertyName);
                value.WriteTo(writer);
            }
            if (this.subtree is Menes.JsonReference subtree)
            {
                writer.WritePropertyName(EncodedSubtreePropertyName);
                subtree.WriteTo(writer);
            }
            Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
            while (enumerator.MoveNext())
            {
                enumerator.Current.Write(writer);
            }
            writer.WriteEndObject();
        }
    }
    public bool Equals(HttpLocalhost1234Node other)
    {
        if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
        {
            return false;
        }
        if (this.HasJsonElement && other.HasJsonElement)
        {
            return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
        }
        return this.Value.Equals(other.Value) && this.Subtree.Equals(other.Subtree) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        if (this.IsNull)
        {
            return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
        }
        if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
        {
            return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
        }
        Menes.ValidationContext context = validationContext;
        context = Menes.Validation.ValidateRequiredProperty(context, this.Value, ValuePropertyNamePath);
        if (this.Subtree is HttpLocalhost1234Tree subtree)
        {
            context = Menes.Validation.ValidateProperty(context, subtree, SubtreePropertyNamePath);
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
    private Menes.JsonReference? GetSubtree()
    {
        if (this.subtree is Menes.JsonReference reference)
        {
            return reference;
        }
        if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty(SubtreePropertyNameBytes.Span, out System.Text.Json.JsonElement value))
        {
            return new Menes.JsonReference(value);
        }
        return default;
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
/// Recursive references between schemas
/// </summary>
public static class Tests
{
/// <summary>
/// valid tree
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{ \r\n                    \"meta\": \"root\",\r\n                    \"nodes\": [\r\n                        {\r\n                            \"value\": 1,\r\n                            \"subtree\": {\r\n                                \"meta\": \"child\",\r\n                                \"nodes\": [\r\n                                    {\"value\": 1.1},\r\n                                    {\"value\": 1.2}\r\n                                ]\r\n                            }\r\n                        },\r\n                        {\r\n                            \"value\": 2,\r\n                            \"subtree\": {\r\n                                \"meta\": \"child\",\r\n                                \"nodes\": [\r\n                                    {\"value\": 2.1},\r\n                                    {\"value\": 2.2}\r\n                                ]\r\n                            }\r\n                        }\r\n                    ]\r\n                }");
        var schema = new HttpLocalhost1234Tree(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Ref011.Tests.Test0: valid tree");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// invalid tree
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{ \r\n                    \"meta\": \"root\",\r\n                    \"nodes\": [\r\n                        {\r\n                            \"value\": 1,\r\n                            \"subtree\": {\r\n                                \"meta\": \"child\",\r\n                                \"nodes\": [\r\n                                    {\"value\": \"string is invalid\"},\r\n                                    {\"value\": 1.2}\r\n                                ]\r\n                            }\r\n                        },\r\n                        {\r\n                            \"value\": 2,\r\n                            \"subtree\": {\r\n                                \"meta\": \"child\",\r\n                                \"nodes\": [\r\n                                    {\"value\": 2.1},\r\n                                    {\"value\": 2.2}\r\n                                ]\r\n                            }\r\n                        }\r\n                    ]\r\n                }");
        var schema = new HttpLocalhost1234Tree(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Ref011.Tests.Test1: invalid tree");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}