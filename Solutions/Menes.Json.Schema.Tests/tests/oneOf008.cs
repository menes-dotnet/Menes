// <copyright file="oneOf008.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.OneOf008
{
public readonly struct Schema : Menes.IJsonValue
{
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    private readonly Schema.Item1Value? item1;
    private readonly Schema.Item2Value? item2;
    public Schema(Schema.Item1Value clrInstance)
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
    public Schema(Schema.Item2Value clrInstance)
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
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.item1 = null;
        this.item2 = null;
        this.JsonElement = jsonElement;
    }
    public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
    public bool IsItem1Value => this.item1 is Schema.Item1Value || (Schema.Item1Value.IsConvertibleFrom(this.JsonElement) && Schema.Item1Value.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
    public bool IsItem2Value => this.item2 is Schema.Item2Value || (Schema.Item2Value.IsConvertibleFrom(this.JsonElement) && Schema.Item2Value.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static explicit operator Schema.Item1Value(Schema value) => value.AsItem1Value();
    public static implicit operator Schema(Schema.Item1Value value) => new Schema(value);
    public static explicit operator Schema.Item2Value(Schema value) => value.AsItem2Value();
    public static implicit operator Schema(Schema.Item2Value value) => new Schema(value);
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
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        if (Schema.Item1Value.IsConvertibleFrom(jsonElement))
        {
            return true;
        }
        if (Schema.Item2Value.IsConvertibleFrom(jsonElement))
        {
            return true;
        }
        return false;
    }
    public Schema.Item1Value AsItem1Value() => this.item1 ?? new Schema.Item1Value(this.JsonElement);
    public Schema.Item2Value AsItem2Value() => this.item2 ?? new Schema.Item2Value(this.JsonElement);
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.item1 is Schema.Item1Value item1)
        {
            item1.WriteTo(writer);
        }
        else if (this.item2 is Schema.Item2Value item2)
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
        if (this.IsItem1Value)
        {
            builder.Append("{");
            builder.Append("Item1Value");
            builder.Append(", ");
            builder.Append(this.AsItem1Value().ToString());
            builder.AppendLine("}");
        }
        if (this.IsItem2Value)
        {
            builder.Append("{");
            builder.Append("Item2Value");
            builder.Append(", ");
            builder.Append(this.AsItem2Value().ToString());
            builder.AppendLine("}");
        }
        return builder.Length > 0 ? builder.ToString() : this.JsonElement.ToString();
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.ValidationContext validationContext1 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
        Menes.ValidationContext validationContext2 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
        if (this.IsItem1Value)
        {
            validationContext1 = this.AsItem1Value().Validate(validationContext1);
        }
        else
        {
            validationContext1 = validationContext1.WithError("The value is not convertible to a Schema.Item1Value.");
        }
        if (this.IsItem2Value)
        {
            validationContext2 = this.AsItem2Value().Validate(validationContext2);
        }
        else
        {
            validationContext2 = validationContext2.WithError("The value is not convertible to a Schema.Item2Value.");
        }
        return Menes.Validation.ValidateOneOf(validationContext, ("Schema.Item1Value", validationContext1), ("Schema.Item2Value", validationContext2));
    }

    public readonly struct Item1Value : Menes.IJsonObject, System.IEquatable<Schema.Item1Value>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly Schema.Item1Value Null = new Schema.Item1Value(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Schema.Item1Value> FromJsonElement = e => new Schema.Item1Value(e);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public Item1Value(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.additionalPropertiesBacking = null;
        }
        public Item1Value(params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public Item1Value((string, Menes.JsonAny) additionalProperty1)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public Item1Value((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public Item1Value((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public Item1Value((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private Item1Value(Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public Schema.Item1Value? AsOptional => this.IsNull ? default(Schema.Item1Value?) : this;
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
        public static Schema.Item1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.Item1Value(property)
                    : Null)
                : Null;
        public static Schema.Item1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.Item1Value(property)
                    : Null)
                : Null;
        public static Schema.Item1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.Item1Value(property)
                    : Null)
            : Null;
        public Schema.Item1Value ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Schema.Item1Value(newAdditional);
        }
        public Schema.Item1Value ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Schema.Item1Value(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Schema.Item1Value ReplaceAll((string, Menes.JsonAny) newAdditional1)
        {
            return new Schema.Item1Value(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Schema.Item1Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Schema.Item1Value(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Schema.Item1Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Schema.Item1Value(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Schema.Item1Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Schema.Item1Value(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
        }
        public Schema.Item1Value Add(params (string, Menes.JsonAny)[] newAdditional)
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
            return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Add((string name, Menes.JsonAny value) newAdditional1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Remove(params string[] namesToRemove)
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
            return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Remove(string itemToRemove1)
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
            return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Remove(string itemToRemove1, string itemToRemove2)
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
            return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
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
            return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
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
            return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!removeIfTrue(property))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new Schema.Item1Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
        public bool Equals(Schema.Item1Value other)
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
                return validationContext.WithError($"6.1.1. type: the element with type {{this.JsonElement.ValueKind}} is not convertible to {{JsonValueKind.Object}}");
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

    public readonly struct Item2Value : Menes.IJsonObject, System.IEquatable<Schema.Item2Value>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly Schema.Item2Value Null = new Schema.Item2Value(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Schema.Item2Value> FromJsonElement = e => new Schema.Item2Value(e);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public Item2Value(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.additionalPropertiesBacking = null;
        }
        public Item2Value(params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public Item2Value((string, Menes.JsonAny) additionalProperty1)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public Item2Value((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public Item2Value((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public Item2Value((string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private Item2Value(Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public Schema.Item2Value? AsOptional => this.IsNull ? default(Schema.Item2Value?) : this;
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
        public static Schema.Item2Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.Item2Value(property)
                    : Null)
                : Null;
        public static Schema.Item2Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.Item2Value(property)
                    : Null)
                : Null;
        public static Schema.Item2Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.Item2Value(property)
                    : Null)
            : Null;
        public Schema.Item2Value ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Schema.Item2Value(newAdditional);
        }
        public Schema.Item2Value ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Schema.Item2Value(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Schema.Item2Value ReplaceAll((string, Menes.JsonAny) newAdditional1)
        {
            return new Schema.Item2Value(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Schema.Item2Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Schema.Item2Value(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Schema.Item2Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Schema.Item2Value(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Schema.Item2Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Schema.Item2Value(Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
        }
        public Schema.Item2Value Add(params (string, Menes.JsonAny)[] newAdditional)
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
            return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Add((string name, Menes.JsonAny value) newAdditional1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Remove(params string[] namesToRemove)
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
            return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Remove(string itemToRemove1)
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
            return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Remove(string itemToRemove1, string itemToRemove2)
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
            return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
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
            return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
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
            return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!removeIfTrue(property))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new Schema.Item2Value(new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
        public bool Equals(Schema.Item2Value other)
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
                return validationContext.WithError($"6.1.1. type: the element with type {{this.JsonElement.ValueKind}} is not convertible to {{JsonValueKind.Object}}");
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
/// oneOf with required
/// </summary>
public static class Tests
{
/// <summary>
/// both invalid - invalid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"bar\": 2}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed OneOf008.Tests.Test0: both invalid - invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// first valid - valid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": 1, \"bar\": 2}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed OneOf008.Tests.Test1: first valid - valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// second valid - valid
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": 1, \"baz\": 3}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed OneOf008.Tests.Test2: second valid - valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// both valid - invalid
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": 1, \"bar\": 2, \"baz\" : 3}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed OneOf008.Tests.Test3: both valid - invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}