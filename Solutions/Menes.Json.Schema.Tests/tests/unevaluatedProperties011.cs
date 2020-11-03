// <copyright file="unevaluatedProperties011.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.UnevaluatedProperties011
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
        private const string BarPropertyNamePath = ".bar";
        private static readonly System.ReadOnlyMemory<byte> BarPropertyNameBytes = new byte[] { 98, 97, 114 };
        private static readonly System.Text.Json.JsonEncodedText EncodedBarPropertyName = System.Text.Json.JsonEncodedText.Encode(BarPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(BarPropertyNameBytes);
        private readonly Schema.Item1Value.BarValue? bar;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public Item1Value(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.bar = null;
            this.additionalPropertiesBacking = null;
        }
        public Item1Value(Schema.Item1Value.BarValue bar)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public Item1Value(Schema.Item1Value.BarValue bar, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public Item1Value(Schema.Item1Value.BarValue bar, (string, Menes.JsonAny) additionalProperty1)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public Item1Value(Schema.Item1Value.BarValue bar, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public Item1Value(Schema.Item1Value.BarValue bar, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public Item1Value(Schema.Item1Value.BarValue bar, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private Item1Value(Schema.Item1Value.BarValue bar, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.bar = bar;
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.bar is null || this.bar.Value.IsNull);
        public Schema.Item1Value? AsOptional => this.IsNull ? default(Schema.Item1Value?) : this;
        public Schema.Item1Value.BarValue Bar => this.bar ?? Schema.Item1Value.BarValue.FromOptionalProperty(this.JsonElement, BarPropertyNameBytes.Span);
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
        public Schema.Item1Value WithBar(Schema.Item1Value.BarValue value)
        {
            return new Schema.Item1Value(value, this.GetJsonProperties());
        }
        public Schema.Item1Value ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Schema.Item1Value(this.Bar, newAdditional);
        }
        public Schema.Item1Value ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Schema.Item1Value(this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Schema.Item1Value ReplaceAll((string, Menes.JsonAny) newAdditional1)
        {
            return new Schema.Item1Value(this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Schema.Item1Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Schema.Item1Value(this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Schema.Item1Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Schema.Item1Value(this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Schema.Item1Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Schema.Item1Value(this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
            return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Add((string name, Menes.JsonAny value) newAdditional1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item1Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item1Value(this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
                if (this.bar is Schema.Item1Value.BarValue bar)
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
            return this.Bar.Equals(other.Bar) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            if (this.IsNull)
            {
                return validationContext.WithError($"6.1.1. type: the element with type {{this.JsonElement.ValueKind}} is not convertible to {{JsonValueKind.Object}}");
            }
            Menes.ValidationContext context = validationContext;
            context = Menes.Validation.ValidateRequiredProperty(context, this.Bar, BarPropertyNamePath);
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
        public readonly struct BarValue : Menes.IJsonValue, System.IEquatable<BarValue>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, BarValue> FromJsonElement = e => new BarValue(e);
            public static readonly BarValue Null = new BarValue(default(System.Text.Json.JsonElement));
            private static readonly Menes.JsonAny ConstValue = BuildConstValue();
            private readonly Menes.JsonAny? value;
            public BarValue(Menes.JsonAny value)
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
            public BarValue(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public BarValue? AsOptional => this.IsNull ? default(BarValue?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator BarValue(Menes.JsonAny value)
            {
                return new BarValue(value);
            }
            public static implicit operator Menes.JsonAny(BarValue value)
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
            public static BarValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new BarValue(property)
                        : Null)
                    : Null;
            public static BarValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new BarValue(property)
                        : Null)
                    : Null;
            public static BarValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new BarValue(property)
                        : Null)
                    : Null;
            public bool Equals(BarValue other)
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
                context = Menes.Validation.ValidateConst(context, value, ConstValue);
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
            private static Menes.JsonAny BuildConstValue()
            {
                using var document = System.Text.Json.JsonDocument.Parse("\"bar\"");
                return new Menes.JsonAny(document.RootElement.Clone());
            }
        }
    }

    public readonly struct Item2Value : Menes.IJsonObject, System.IEquatable<Schema.Item2Value>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly Schema.Item2Value Null = new Schema.Item2Value(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Schema.Item2Value> FromJsonElement = e => new Schema.Item2Value(e);
        private const string BazPropertyNamePath = ".baz";
        private static readonly System.ReadOnlyMemory<byte> BazPropertyNameBytes = new byte[] { 98, 97, 122 };
        private static readonly System.Text.Json.JsonEncodedText EncodedBazPropertyName = System.Text.Json.JsonEncodedText.Encode(BazPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(BazPropertyNameBytes);
        private readonly Schema.Item2Value.BazValue? baz;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public Item2Value(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.baz = null;
            this.additionalPropertiesBacking = null;
        }
        public Item2Value(Schema.Item2Value.BazValue baz)
        {
            this.baz = baz;
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public Item2Value(Schema.Item2Value.BazValue baz, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.baz = baz;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public Item2Value(Schema.Item2Value.BazValue baz, (string, Menes.JsonAny) additionalProperty1)
        {
            this.baz = baz;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public Item2Value(Schema.Item2Value.BazValue baz, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.baz = baz;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public Item2Value(Schema.Item2Value.BazValue baz, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.baz = baz;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public Item2Value(Schema.Item2Value.BazValue baz, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.baz = baz;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private Item2Value(Schema.Item2Value.BazValue baz, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.baz = baz;
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.baz is null || this.baz.Value.IsNull);
        public Schema.Item2Value? AsOptional => this.IsNull ? default(Schema.Item2Value?) : this;
        public Schema.Item2Value.BazValue Baz => this.baz ?? Schema.Item2Value.BazValue.FromOptionalProperty(this.JsonElement, BazPropertyNameBytes.Span);
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
        public Schema.Item2Value WithBaz(Schema.Item2Value.BazValue value)
        {
            return new Schema.Item2Value(value, this.GetJsonProperties());
        }
        public Schema.Item2Value ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Schema.Item2Value(this.Baz, newAdditional);
        }
        public Schema.Item2Value ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Schema.Item2Value(this.Baz, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Schema.Item2Value ReplaceAll((string, Menes.JsonAny) newAdditional1)
        {
            return new Schema.Item2Value(this.Baz, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Schema.Item2Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Schema.Item2Value(this.Baz, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Schema.Item2Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Schema.Item2Value(this.Baz, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Schema.Item2Value ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Schema.Item2Value(this.Baz, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
            return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Add((string name, Menes.JsonAny value) newAdditional1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.Item2Value Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            return new Schema.Item2Value(this.Baz, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
                if (this.baz is Schema.Item2Value.BazValue baz)
                {
                    writer.WritePropertyName(EncodedBazPropertyName);
                    baz.WriteTo(writer);
                }
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
            return this.Baz.Equals(other.Baz) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            if (this.IsNull)
            {
                return validationContext.WithError($"6.1.1. type: the element with type {{this.JsonElement.ValueKind}} is not convertible to {{JsonValueKind.Object}}");
            }
            Menes.ValidationContext context = validationContext;
            context = Menes.Validation.ValidateRequiredProperty(context, this.Baz, BazPropertyNamePath);
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
        public readonly struct BazValue : Menes.IJsonValue, System.IEquatable<BazValue>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, BazValue> FromJsonElement = e => new BazValue(e);
            public static readonly BazValue Null = new BazValue(default(System.Text.Json.JsonElement));
            private static readonly Menes.JsonAny ConstValue = BuildConstValue();
            private readonly Menes.JsonAny? value;
            public BazValue(Menes.JsonAny value)
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
            public BazValue(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public BazValue? AsOptional => this.IsNull ? default(BazValue?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator BazValue(Menes.JsonAny value)
            {
                return new BazValue(value);
            }
            public static implicit operator Menes.JsonAny(BazValue value)
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
            public static BazValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new BazValue(property)
                        : Null)
                    : Null;
            public static BazValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new BazValue(property)
                        : Null)
                    : Null;
            public static BazValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new BazValue(property)
                        : Null)
                    : Null;
            public bool Equals(BazValue other)
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
                context = Menes.Validation.ValidateConst(context, value, ConstValue);
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
            private static Menes.JsonAny BuildConstValue()
            {
                using var document = System.Text.Json.JsonDocument.Parse("\"baz\"");
                return new Menes.JsonAny(document.RootElement.Clone());
            }
        }
    }
}
///  <summary>
/// unevaluatedProperties with oneOf
/// </summary>
public static class Tests
{
/// <summary>
/// with no unevaluated properties
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"foo\": \"foo\",\r\n                    \"bar\": \"bar\"\r\n                }");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedProperties011.Tests.Test0: with no unevaluated properties");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// with unevaluated properties
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"foo\": \"foo\",\r\n                    \"bar\": \"bar\",\r\n                    \"quux\": \"quux\"\r\n                }");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedProperties011.Tests.Test1: with unevaluated properties");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}