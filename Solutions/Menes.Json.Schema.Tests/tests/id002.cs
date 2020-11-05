// <copyright file="id002.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Id002
{
public readonly struct HttpsJsonSchemaOrgDraft201909Schema : Menes.IJsonValue
{
    public static readonly HttpsJsonSchemaOrgDraft201909Schema Null = new HttpsJsonSchemaOrgDraft201909Schema(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, HttpsJsonSchemaOrgDraft201909Schema> FromJsonElement = e => new HttpsJsonSchemaOrgDraft201909Schema(e);
    private readonly HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity? item1;
    private readonly Menes.JsonBoolean? item2;
    public HttpsJsonSchemaOrgDraft201909Schema(HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity clrInstance)
    {
        if (clrInstance.HasJsonElement)
        {
            this.JsonElement = clrInstance.JsonElement;
            this.item1 = null;
        }
        else
        {
            this.item1 = clrInstance;
            this.JsonElement = default;
        }
        this.item2 = null;
    }
    public HttpsJsonSchemaOrgDraft201909Schema(Menes.JsonBoolean clrInstance)
    {
        if (clrInstance.HasJsonElement)
        {
            this.JsonElement = clrInstance.JsonElement;
            this.item2 = null;
        }
        else
        {
            this.item2 = clrInstance;
            this.JsonElement = default;
        }
        this.item1 = null;
    }
    public HttpsJsonSchemaOrgDraft201909Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.item1 = null;
        this.item2 = null;
        this.JsonElement = jsonElement;
    }
    public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public HttpsJsonSchemaOrgDraft201909Schema? AsOptional => this.IsNull ? default(HttpsJsonSchemaOrgDraft201909Schema?) : this;
    public bool IsHttpsJsonSchemaOrgDraft201909SchemaEntity => this.item1 is HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity || (HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity.IsConvertibleFrom(this.JsonElement) && HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
    public bool IsJsonBoolean => this.item2 is Menes.JsonBoolean || (Menes.JsonBoolean.IsConvertibleFrom(this.JsonElement) && Menes.JsonBoolean.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static explicit operator HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(HttpsJsonSchemaOrgDraft201909Schema value) => value.AsHttpsJsonSchemaOrgDraft201909SchemaEntity();
    public static implicit operator HttpsJsonSchemaOrgDraft201909Schema(HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity value) => new HttpsJsonSchemaOrgDraft201909Schema(value);
    public static explicit operator Menes.JsonBoolean(HttpsJsonSchemaOrgDraft201909Schema value) => value.AsJsonBoolean();
    public static implicit operator HttpsJsonSchemaOrgDraft201909Schema(Menes.JsonBoolean value) => new HttpsJsonSchemaOrgDraft201909Schema(value);
    public static HttpsJsonSchemaOrgDraft201909Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new HttpsJsonSchemaOrgDraft201909Schema(property)
                : Null)
            : Null;
    public static HttpsJsonSchemaOrgDraft201909Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new HttpsJsonSchemaOrgDraft201909Schema(property)
                : Null)
            : Null;
    public static HttpsJsonSchemaOrgDraft201909Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new HttpsJsonSchemaOrgDraft201909Schema(property)
                : Null)
            : Null;
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        if (HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity.IsConvertibleFrom(jsonElement))
        {
            return true;
        }
        if (Menes.JsonBoolean.IsConvertibleFrom(jsonElement))
        {
            return true;
        }
        return false;
    }
    public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity AsHttpsJsonSchemaOrgDraft201909SchemaEntity() => this.item1 ?? new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(this.JsonElement);
    public Menes.JsonBoolean AsJsonBoolean() => this.item2 ?? new Menes.JsonBoolean(this.JsonElement);
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.item1 is HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity item1)
        {
            item1.WriteTo(writer);
        }
        else if (this.item2 is Menes.JsonBoolean item2)
        {
            item2.WriteTo(writer);
        }
        else
        {
            this.JsonElement.WriteTo(writer);
        }
    }
    public override string ToString()
    {
        var builder = new System.Text.StringBuilder();
        if (this.IsHttpsJsonSchemaOrgDraft201909SchemaEntity)
        {
            builder.Append("{");
            builder.Append("HttpsJsonSchemaOrgDraft201909SchemaEntity");
            builder.Append(", ");
            builder.Append(this.AsHttpsJsonSchemaOrgDraft201909SchemaEntity().ToString());
            builder.AppendLine("}");
        }
        if (this.IsJsonBoolean)
        {
            builder.Append("{");
            builder.Append("JsonBoolean");
            builder.Append(", ");
            builder.Append(this.AsJsonBoolean().ToString());
            builder.AppendLine("}");
        }
        return builder.Length > 0 ? builder.ToString() : this.JsonElement.ToString();
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.ValidationContext validationContext1 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
        Menes.ValidationContext validationContext2 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
        if (this.IsHttpsJsonSchemaOrgDraft201909SchemaEntity)
        {
            validationContext1 = this.AsHttpsJsonSchemaOrgDraft201909SchemaEntity().Validate(validationContext1);
        }
        else
        {
            validationContext1 = validationContext1.WithError("The value is not convertible to a HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity.");
        }
        if (this.IsJsonBoolean)
        {
            validationContext2 = this.AsJsonBoolean().Validate(validationContext2);
        }
        else
        {
            validationContext2 = validationContext2.WithError("The value is not convertible to a Menes.JsonBoolean.");
        }
        return Menes.Validation.ValidateAnyOf(validationContext, validationContext1, validationContext2);
    }

    public readonly struct HttpsJsonSchemaOrgDraft201909SchemaEntity : Menes.IJsonObject, System.IEquatable<HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Null = new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity> FromJsonElement = e => new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(e);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public HttpsJsonSchemaOrgDraft201909SchemaEntity(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.additionalPropertiesBacking = null;
        }
        public HttpsJsonSchemaOrgDraft201909SchemaEntity(params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public HttpsJsonSchemaOrgDraft201909SchemaEntity((string, Menes.JsonAny) additionalProperty1)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public HttpsJsonSchemaOrgDraft201909SchemaEntity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public HttpsJsonSchemaOrgDraft201909SchemaEntity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public HttpsJsonSchemaOrgDraft201909SchemaEntity((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private HttpsJsonSchemaOrgDraft201909SchemaEntity(Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity? AsOptional => this.IsNull ? default(HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity?) : this;
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
        public static HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(property)
                    : Null)
                : Null;
        public static HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(property)
                    : Null)
                : Null;
        public static HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(property)
                    : Null)
            : Null;
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(newAdditional);
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity ReplaceAll((string, Menes.JsonAny) newAdditional1)
        {
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Add(params (string, Menes.JsonAny)[] newAdditional)
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
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Add((string name, Menes.JsonAny value) newAdditional1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Remove(params string[] namesToRemove)
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
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Remove(string itemToRemove1)
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
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Remove(string itemToRemove1, string itemToRemove2)
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
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
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
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
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
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!removeIfTrue(property))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(HttpsJsonSchemaOrgDraft201909Schema.HttpsJsonSchemaOrgDraft201909SchemaEntity other)
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
            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}");
            }
            Menes.ValidationContext context = validationContext;
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
    }
}
///  <summary>
/// Unnormalized $ids are allowed but discouraged
/// </summary>
public static class Tests
{
/// <summary>
/// Unnormalized identifier
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$ref\": \"http://localhost:1234/foo/baz\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/foo/bar/../baz\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new HttpsJsonSchemaOrgDraft201909Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Id002.Tests.Test0: Unnormalized identifier");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// Unnormalized identifier and no ref
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/foo/bar/../baz\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new HttpsJsonSchemaOrgDraft201909Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Id002.Tests.Test1: Unnormalized identifier and no ref");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// Unnormalized identifier with empty fragment
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$ref\": \"http://localhost:1234/foo/baz\",\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/foo/bar/../baz#\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new HttpsJsonSchemaOrgDraft201909Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Id002.Tests.Test2: Unnormalized identifier with empty fragment");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// Unnormalized identifier with empty fragment and no ref
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"$defs\": {\r\n                        \"A\": {\r\n                            \"$id\": \"http://localhost:1234/foo/bar/../baz#\",\r\n                            \"type\": \"integer\"\r\n                        }\r\n                    }\r\n                }");
        var schema = new HttpsJsonSchemaOrgDraft201909Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Id002.Tests.Test3: Unnormalized identifier with empty fragment and no ref");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}