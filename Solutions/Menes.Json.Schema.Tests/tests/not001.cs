// <copyright file="not001.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Not001
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
        context = Menes.Validation.ValidateNot<Menes.JsonAny, Schema.NotTypeValidationValue>(context, this);
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
    public readonly struct NotTypeValidationValue : Menes.IJsonValue
    {
        public static readonly NotTypeValidationValue Null = new NotTypeValidationValue(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Schema.NotTypeValidationValue> FromJsonElement = e => new Schema.NotTypeValidationValue(e);
        private readonly Menes.JsonInteger? item1;
        private readonly Menes.JsonBoolean? item2;
        public NotTypeValidationValue(Menes.JsonInteger clrInstance)
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
        public NotTypeValidationValue(Menes.JsonBoolean clrInstance)
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
        public NotTypeValidationValue(System.Text.Json.JsonElement jsonElement)
        {
            this.item1 = null;
            this.item2 = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public NotTypeValidationValue? AsOptional => this.IsNull ? default(NotTypeValidationValue?) : this;
        public bool IsJsonInteger => this.item1 is Menes.JsonInteger || (Menes.JsonInteger.IsConvertibleFrom(this.JsonElement) && Menes.JsonInteger.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
        public bool IsJsonBoolean => this.item2 is Menes.JsonBoolean || (Menes.JsonBoolean.IsConvertibleFrom(this.JsonElement) && Menes.JsonBoolean.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static explicit operator Menes.JsonInteger(NotTypeValidationValue value) => value.AsJsonInteger();
        public static implicit operator NotTypeValidationValue(Menes.JsonInteger value) => new NotTypeValidationValue(value);
        public static explicit operator Menes.JsonBoolean(NotTypeValidationValue value) => value.AsJsonBoolean();
        public static implicit operator NotTypeValidationValue(Menes.JsonBoolean value) => new NotTypeValidationValue(value);
        public static NotTypeValidationValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new NotTypeValidationValue(property)
                    : Null)
                : Null;
        public static NotTypeValidationValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new NotTypeValidationValue(property)
                    : Null)
                : Null;
        public static NotTypeValidationValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new NotTypeValidationValue(property)
                    : Null)
                : Null;
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            if (Menes.JsonInteger.IsConvertibleFrom(jsonElement))
            {
                return true;
            }
            if (Menes.JsonBoolean.IsConvertibleFrom(jsonElement))
            {
                return true;
            }
            return false;
        }
        public Menes.JsonInteger AsJsonInteger() => this.item1 ?? new Menes.JsonInteger(this.JsonElement);
        public Menes.JsonBoolean AsJsonBoolean() => this.item2 ?? new Menes.JsonBoolean(this.JsonElement);
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.item1 is Menes.JsonInteger item1)
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
            if (this.IsJsonInteger)
            {
                builder.Append("{");
                builder.Append("JsonInteger");
                builder.Append(", ");
                builder.Append(this.AsJsonInteger().ToString());
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
            if (this.IsJsonInteger)
            {
                validationContext1 = this.AsJsonInteger().Validate(validationContext1);
            }
            else
            {
                validationContext1 = validationContext1.WithError("The value is not convertible to a Menes.JsonInteger.");
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
    }
}
///  <summary>
/// not multiple types
/// </summary>
public static class Tests
{
/// <summary>
/// valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("\"foo\"");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Not001.Tests.Test0: valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// mismatch
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("1");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Not001.Tests.Test1: mismatch");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// other mismatch
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("true");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Not001.Tests.Test2: other mismatch");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}