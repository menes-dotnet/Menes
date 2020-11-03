// <copyright file="anyOf000.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.AnyOf000
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
        Menes.JsonInteger anyOfitem1 = Menes.JsonAny.From(value).As<Menes.JsonInteger>();
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
    public readonly struct AnyOfValidationItem2Value : Menes.IJsonValue, System.IEquatable<AnyOfValidationItem2Value>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, AnyOfValidationItem2Value> FromJsonElement = e => new AnyOfValidationItem2Value(e);
        public static readonly AnyOfValidationItem2Value Null = new AnyOfValidationItem2Value(default(System.Text.Json.JsonElement));
        private static readonly Menes.JsonNumber? MultipleOf = null;
        private static readonly Menes.JsonNumber? Maximum = null;
        private static readonly Menes.JsonNumber? ExclusiveMaximum = null;
        private static readonly Menes.JsonNumber? Minimum = 2;
        private static readonly Menes.JsonNumber? ExclusiveMinimum = null;
        private readonly Menes.JsonAny? value;
        public AnyOfValidationItem2Value(Menes.JsonAny value)
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
        public AnyOfValidationItem2Value(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public AnyOfValidationItem2Value? AsOptional => this.IsNull ? default(AnyOfValidationItem2Value?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator AnyOfValidationItem2Value(Menes.JsonAny value)
        {
            return new AnyOfValidationItem2Value(value);
        }
        public static implicit operator Menes.JsonAny(AnyOfValidationItem2Value value)
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
        public static AnyOfValidationItem2Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new AnyOfValidationItem2Value(property)
                    : Null)
                : Null;
        public static AnyOfValidationItem2Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new AnyOfValidationItem2Value(property)
                    : Null)
                : Null;
        public static AnyOfValidationItem2Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new AnyOfValidationItem2Value(property)
                    : Null)
                : Null;
        public bool Equals(AnyOfValidationItem2Value other)
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
            context = value.As<Menes.JsonNumber>().ValidateAsNumber(context, MultipleOf, Maximum, ExclusiveMaximum, Minimum, ExclusiveMinimum, null, null);
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
/// anyOf
/// </summary>
public static class Tests
{
/// <summary>
/// first anyOf valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("1");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AnyOf000.Tests.Test0: first anyOf valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// second anyOf valid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("2.5");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AnyOf000.Tests.Test1: second anyOf valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// both anyOf valid
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("3");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed AnyOf000.Tests.Test2: both anyOf valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// neither anyOf valid
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("1.5");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed AnyOf000.Tests.Test3: neither anyOf valid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}