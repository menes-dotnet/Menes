// <copyright file="oneOf003.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.OneOf003
{
public readonly struct TestSchema : Menes.IJsonValue, System.IEquatable<TestSchema>
{
    public static readonly System.Func<System.Text.Json.JsonElement, TestSchema> FromJsonElement = e => new TestSchema(e);
    public static readonly TestSchema Null = new TestSchema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonAny? value;
    public TestSchema(Menes.JsonAny value)
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
    public TestSchema(System.Text.Json.JsonElement jsonElement)
    {
        this.value = null;
        this.JsonElement = jsonElement;
    }
    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public TestSchema? AsOptional => this.IsNull ? default(TestSchema?) : this;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static implicit operator TestSchema(Menes.JsonAny value)
    {
        return new TestSchema(value);
    }
    public static implicit operator Menes.JsonAny(TestSchema value)
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
    public bool Equals(TestSchema other)
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
        Menes.ValidationContext oneOfValidationContext1 = Menes.ValidationContext.Root.WithPath(context.Path);
        Menes.ValidationContext oneOfValidationContext2 = Menes.ValidationContext.Root.WithPath(context.Path);
        Menes.ValidationContext oneOfValidationContext3 = Menes.ValidationContext.Root.WithPath(context.Path);
        Menes.JsonAny jsonAnyOneOfValue0 = Menes.JsonAny.From(value).As<Menes.JsonAny>();
        oneOfValidationContext1 = jsonAnyOneOfValue0.Validate(oneOfValidationContext1);
        Menes.JsonNotAny jsonNotAnyOneOfValue1 = Menes.JsonAny.From(value).As<Menes.JsonNotAny>();
        oneOfValidationContext2 = jsonNotAnyOneOfValue1.Validate(oneOfValidationContext2);
        Menes.JsonNotAny jsonNotAnyOneOfValue2 = Menes.JsonAny.From(value).As<Menes.JsonNotAny>();
        oneOfValidationContext3 = jsonNotAnyOneOfValue2.Validate(oneOfValidationContext3);
        context = Menes.Validation.ValidateOneOf(context, oneOfValidationContext1, oneOfValidationContext2, oneOfValidationContext3);
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
///  <summary>
/// oneOf with boolean schemas, one true
/// </summary>
public static class Tests
{
/// <summary>
/// any value is valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("\"foo\"");
        var schema = new TestSchema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed OneOf003.Tests.Test0: any value is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}