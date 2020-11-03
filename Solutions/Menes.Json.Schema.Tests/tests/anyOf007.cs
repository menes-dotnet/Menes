// <copyright file="anyOf007.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.AnyOf007
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
        Schema.AnyOfValidationItem1Value anyOfitem1 = Menes.JsonAny.From(value).As<Schema.AnyOfValidationItem1Value>();
        anyOfValidationContext1 = anyOfitem1.Validate(anyOfValidationContext1);
        context = Menes.Validation.ValidateAnyOf(context, anyOfValidationContext1);
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
    public readonly struct AnyOfValidationItem1Value : Menes.IJsonValue, System.IEquatable<AnyOfValidationItem1Value>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, AnyOfValidationItem1Value> FromJsonElement = e => new AnyOfValidationItem1Value(e);
        public static readonly AnyOfValidationItem1Value Null = new AnyOfValidationItem1Value(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonAny? value;
        public AnyOfValidationItem1Value(Menes.JsonAny value)
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
        public AnyOfValidationItem1Value(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public AnyOfValidationItem1Value? AsOptional => this.IsNull ? default(AnyOfValidationItem1Value?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator AnyOfValidationItem1Value(Menes.JsonAny value)
        {
            return new AnyOfValidationItem1Value(value);
        }
        public static implicit operator Menes.JsonAny(AnyOfValidationItem1Value value)
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
        public static AnyOfValidationItem1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new AnyOfValidationItem1Value(property)
                    : Null)
                : Null;
        public static AnyOfValidationItem1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new AnyOfValidationItem1Value(property)
                    : Null)
                : Null;
        public static AnyOfValidationItem1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new AnyOfValidationItem1Value(property)
                    : Null)
                : Null;
        public bool Equals(AnyOfValidationItem1Value other)
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
            Menes.JsonNull anyOfitem1 = Menes.JsonAny.From(value).As<Menes.JsonNull>();
            anyOfValidationContext1 = anyOfitem1.Validate(anyOfValidationContext1);
            context = Menes.Validation.ValidateAnyOf(context, anyOfValidationContext1);
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
    }
}
///  <summary>
/// nested anyOf, to check validation semantics
/// </summary>
public static class Tests
{
/// <summary>
/// null is valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("null");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AnyOf007.Tests.Test0: null is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// anything non-null is invalid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("123");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed AnyOf007.Tests.Test1: anything non-null is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}