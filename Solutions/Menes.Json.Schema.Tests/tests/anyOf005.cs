// <copyright file="anyOf005.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.AnyOf005
{
public readonly struct Schema : Menes.IJsonValue, System.IEquatable<Schema>
{
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonAny? value;
    public Schema(Menes.JsonAny value)
    {
        if (value.HasJsonElement)
        {
            this.JsonElement = value.JsonElement;
            this.value = null;
        }
        else
        {
            this.value = value;
            this.JsonElement = default;
        }
    }
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.value = null;
        this.JsonElement = jsonElement;
    }
    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static implicit operator Schema(Menes.JsonAny value)
    {
        return new Schema(value);
    }
    public static implicit operator Menes.JsonAny(Schema value)
    {
        if (value.value is Menes.JsonAny clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonAny(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonAny.IsConvertibleFrom(jsonElement);
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
    public bool Equals(Schema other)
    {
        return this.Equals((Menes.JsonAny)other);
    }
    public bool Equals(Menes.JsonAny other)
    {
        return ((Menes.JsonAny)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonAny value = this;
        Menes.ValidationContext context = validationContext;
        context = value.Validate(context);
        Menes.ValidationContext anyOfValidationContext1 = Menes.ValidationContext.Root.WithPath(context.Path);
        Menes.ValidationContext anyOfValidationContext2 = Menes.ValidationContext.Root.WithPath(context.Path);
        Schema.AnyOfValidationItem1Value anyOfitem1 = Menes.JsonAny.From(value).As<Schema.AnyOfValidationItem1Value>();
        anyOfValidationContext1 = anyOfitem1.Validate(anyOfValidationContext1);
        Schema.AnyOfValidationItem2Value anyOfitem2 = Menes.JsonAny.From(value).As<Schema.AnyOfValidationItem2Value>();
        anyOfValidationContext2 = anyOfitem2.Validate(anyOfValidationContext2);
        context = Menes.Validation.ValidateAnyOf(context, anyOfValidationContext1, anyOfValidationContext2);
        return context;
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        else if (this.value is Menes.JsonAny clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public override string ToString()
    {
        if (this.value is Menes.JsonAny clrValue)
        {
            return clrValue.ToString();
        }
        else
        {
            return this.JsonElement.GetRawText();
        }
    }

    public readonly struct AnyOfValidationItem1Value : Menes.IJsonObject, System.IEquatable<Schema.AnyOfValidationItem1Value>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly Schema.AnyOfValidationItem1Value Null = new Schema.AnyOfValidationItem1Value(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Schema.AnyOfValidationItem1Value> FromJsonElement = e => new Schema.AnyOfValidationItem1Value(e);
        private const string BarPropertyNamePath = ".bar";
        private static readonly System.ReadOnlyMemory<byte> BarPropertyNameBytes = new byte[] { 98, 97, 114 };
        private static readonly System.Text.Json.JsonEncodedText EncodedBarPropertyName = System.Text.Json.JsonEncodedText.Encode(BarPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(BarPropertyNameBytes);
        private readonly Menes.JsonInteger? bar;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public AnyOfValidationItem1Value(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.bar = null;
            this.additionalPropertiesBacking = null;
        }
        public AnyOfValidationItem1Value(Menes.JsonInteger bar)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public AnyOfValidationItem1Value(Menes.JsonInteger bar, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public AnyOfValidationItem1Value(Menes.JsonInteger bar, (string, Menes.JsonAny) additionalProperty1)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public AnyOfValidationItem1Value(Menes.JsonInteger bar, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public AnyOfValidationItem1Value(Menes.JsonInteger bar, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public AnyOfValidationItem1Value(Menes.JsonInteger bar, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private AnyOfValidationItem1Value(Menes.JsonInteger bar, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.bar is null || this.bar.Value.IsNull);
        public Schema.AnyOfValidationItem1Value? AsOptional => this.IsNull ? default(Schema.AnyOfValidationItem1Value?) : this;
        public Menes.JsonInteger Bar => this.bar ?? Menes.JsonInteger.FromOptionalProperty(this.JsonElement, BarPropertyNameBytes.Span);
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
        public static Schema.AnyOfValidationItem1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.AnyOfValidationItem1Value(property)
                    : Null)
                : Null;
        public static Schema.AnyOfValidationItem1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.AnyOfValidationItem1Value(property)
                    : Null)
                : Null;
        public static Schema.AnyOfValidationItem1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.AnyOfValidationItem1Value(property)
                    : Null)
            : Null;
        public Schema.AnyOfValidationItem1Value WithBar(Menes.JsonInteger value)
        {
            return new Schema.AnyOfValidationItem1Value(value, this.GetJsonProperties());
        }
        public Schema.AnyOfValidationItem1Value ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Schema.AnyOfValidationItem1Value(this.Bar, newAdditional);
        }
        public Schema.AnyOfValidationItem1Value ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Schema.AnyOfValidationItem1Value(this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Schema.AnyOfValidationItem1Value ReplaceAll((string, Menes.JsonAny) newAdditional1)
        {
            return new Schema.AnyOfValidationItem1Value(this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Schema.AnyOfValidationItem1Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Schema.AnyOfValidationItem1Value(this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Schema.AnyOfValidationItem1Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Schema.AnyOfValidationItem1Value(this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Schema.AnyOfValidationItem1Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Schema.AnyOfValidationItem1Value(this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
        }
        public Schema.AnyOfValidationItem1Value Add(params (string, Menes.JsonAny)[] newAdditional)
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
            return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem1Value Add((string name, Menes.JsonAny value) newAdditional1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem1Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem1Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem1Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem1Value Remove(params string[] namesToRemove)
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
            return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem1Value Remove(string itemToRemove1)
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
            return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem1Value Remove(string itemToRemove1, string itemToRemove2)
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
            return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem1Value Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
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
            return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem1Value Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
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
            return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem1Value Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!removeIfTrue(property))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new Schema.AnyOfValidationItem1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
                if (this.bar is Menes.JsonInteger bar)
                {
                    writer.WritePropertyName(EncodedBarPropertyName);
                    bar.WriteTo(writer);
                }
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(Schema.AnyOfValidationItem1Value other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }
            if (this.HasJsonElement && other.HasJsonElement)
            {
                return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
            }
            return this.Bar.Equals(other.Bar) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
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
                context = Menes.Validation.ValidateRequiredProperty(context, this.Bar, BarPropertyNamePath);
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
    }

    public readonly struct AnyOfValidationItem2Value : Menes.IJsonObject, System.IEquatable<Schema.AnyOfValidationItem2Value>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly Schema.AnyOfValidationItem2Value Null = new Schema.AnyOfValidationItem2Value(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Schema.AnyOfValidationItem2Value> FromJsonElement = e => new Schema.AnyOfValidationItem2Value(e);
        private const string FooPropertyNamePath = ".foo";
        private static readonly System.ReadOnlyMemory<byte> FooPropertyNameBytes = new byte[] { 102, 111, 111 };
        private static readonly System.Text.Json.JsonEncodedText EncodedFooPropertyName = System.Text.Json.JsonEncodedText.Encode(FooPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(FooPropertyNameBytes);
        private readonly Menes.JsonString? foo;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public AnyOfValidationItem2Value(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.foo = null;
            this.additionalPropertiesBacking = null;
        }
        public AnyOfValidationItem2Value(Menes.JsonString foo)
        {
            this.foo = foo;
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public AnyOfValidationItem2Value(Menes.JsonString foo, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.foo = foo;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public AnyOfValidationItem2Value(Menes.JsonString foo, (string, Menes.JsonAny) additionalProperty1)
        {
            this.foo = foo;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public AnyOfValidationItem2Value(Menes.JsonString foo, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.foo = foo;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public AnyOfValidationItem2Value(Menes.JsonString foo, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.foo = foo;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public AnyOfValidationItem2Value(Menes.JsonString foo, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.foo = foo;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private AnyOfValidationItem2Value(Menes.JsonString foo, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.foo = foo;
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.foo is null || this.foo.Value.IsNull);
        public Schema.AnyOfValidationItem2Value? AsOptional => this.IsNull ? default(Schema.AnyOfValidationItem2Value?) : this;
        public Menes.JsonString Foo => this.foo ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, FooPropertyNameBytes.Span);
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
        public static Schema.AnyOfValidationItem2Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.AnyOfValidationItem2Value(property)
                    : Null)
                : Null;
        public static Schema.AnyOfValidationItem2Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.AnyOfValidationItem2Value(property)
                    : Null)
                : Null;
        public static Schema.AnyOfValidationItem2Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.AnyOfValidationItem2Value(property)
                    : Null)
            : Null;
        public Schema.AnyOfValidationItem2Value WithFoo(Menes.JsonString value)
        {
            return new Schema.AnyOfValidationItem2Value(value, this.GetJsonProperties());
        }
        public Schema.AnyOfValidationItem2Value ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Schema.AnyOfValidationItem2Value(this.Foo, newAdditional);
        }
        public Schema.AnyOfValidationItem2Value ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Schema.AnyOfValidationItem2Value(this.Foo, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Schema.AnyOfValidationItem2Value ReplaceAll((string, Menes.JsonAny) newAdditional1)
        {
            return new Schema.AnyOfValidationItem2Value(this.Foo, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Schema.AnyOfValidationItem2Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Schema.AnyOfValidationItem2Value(this.Foo, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Schema.AnyOfValidationItem2Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Schema.AnyOfValidationItem2Value(this.Foo, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Schema.AnyOfValidationItem2Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Schema.AnyOfValidationItem2Value(this.Foo, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
        }
        public Schema.AnyOfValidationItem2Value Add(params (string, Menes.JsonAny)[] newAdditional)
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
            return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem2Value Add((string name, Menes.JsonAny value) newAdditional1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem2Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem2Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem2Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem2Value Remove(params string[] namesToRemove)
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
            return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem2Value Remove(string itemToRemove1)
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
            return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem2Value Remove(string itemToRemove1, string itemToRemove2)
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
            return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem2Value Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
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
            return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem2Value Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
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
            return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.AnyOfValidationItem2Value Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!removeIfTrue(property))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new Schema.AnyOfValidationItem2Value(this.Foo, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
                if (this.foo is Menes.JsonString foo)
                {
                    writer.WritePropertyName(EncodedFooPropertyName);
                    foo.WriteTo(writer);
                }
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(Schema.AnyOfValidationItem2Value other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }
            if (this.HasJsonElement && other.HasJsonElement)
            {
                return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
            }
            return this.Foo.Equals(other.Foo) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
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
                context = Menes.Validation.ValidateRequiredProperty(context, this.Foo, FooPropertyNamePath);
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
    }
}
///  <summary>
/// anyOf complex types
/// </summary>
public static class Tests
{
/// <summary>
/// first anyOf valid (complex)
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"bar\": 2}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AnyOf005.Tests.Test0: first anyOf valid (complex)");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// second anyOf valid (complex)
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": \"baz\"}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AnyOf005.Tests.Test1: second anyOf valid (complex)");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// both anyOf valid (complex)
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": \"baz\", \"bar\": 2}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AnyOf005.Tests.Test2: both anyOf valid (complex)");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// neither anyOf valid (complex)
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": 2, \"bar\": \"quux\"}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed AnyOf005.Tests.Test3: neither anyOf valid (complex)");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}