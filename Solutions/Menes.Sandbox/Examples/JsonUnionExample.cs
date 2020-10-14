// <copyright file="JsonUnionExample.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501

namespace Examples
{
    public readonly struct JsonUnionExample : Menes.IJsonValue
    {
        public static readonly JsonUnionExample Null = new JsonUnionExample(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonBoolean? item1;
        private readonly Menes.JsonInt64? item2;
        private readonly Menes.JsonReference? item3;
        public JsonUnionExample(Menes.JsonBoolean clrInstance)
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
            this.item3 = null;
        }
        public JsonUnionExample(Menes.JsonInt64 clrInstance)
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
            this.item3 = null;
        }
        public JsonUnionExample(JsonObjectExample clrInstance)
        {
            if (clrInstance.HasJsonElement)
            {
                this.JsonElement = clrInstance.JsonElement;
                this.item3 = null;
            }
            else
            {
                this.item3 = Menes.JsonReference.FromValue(clrInstance);
                this.JsonElement = default;
            }
            this.item1 = null;
            this.item2 = null;
        }
        public JsonUnionExample(System.Text.Json.JsonElement jsonElement)
        {
            this.item1 = null;
            this.item2 = null;
            this.item3 = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.item1 is null && this.item2 is null && this.item3 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public JsonUnionExample? AsOptional => this.IsNull ? default(JsonUnionExample?) : this;
        public bool IsJsonBoolean => this.item1 is Menes.JsonBoolean || Menes.JsonBoolean.IsConvertibleFrom(this.JsonElement);
        public bool IsJsonInt64 => this.item2 is Menes.JsonInt64 || Menes.JsonInt64.IsConvertibleFrom(this.JsonElement);
        public bool IsJsonObjectExample => this.item3 is Menes.JsonReference || Examples.JsonObjectExample.IsConvertibleFrom(this.JsonElement);
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement
        {
            get;
        }
        public static explicit operator Menes.JsonBoolean(JsonUnionExample value) => value.AsJsonBoolean();
        public static implicit operator JsonUnionExample(Menes.JsonBoolean value) => new JsonUnionExample(value);
        public static explicit operator Menes.JsonInt64(JsonUnionExample value) => value.AsJsonInt64();
        public static implicit operator JsonUnionExample(Menes.JsonInt64 value) => new JsonUnionExample(value);
        public static explicit operator JsonObjectExample(JsonUnionExample value) => value.AsJsonObjectExample();
        public static implicit operator JsonUnionExample(JsonObjectExample value) => new JsonUnionExample(value);
        public static JsonUnionExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new JsonUnionExample(property)
                : Null;
        public static JsonUnionExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new JsonUnionExample(property)
                : Null;
        public static JsonUnionExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new JsonUnionExample(property)
                : Null;
        public Menes.JsonBoolean AsJsonBoolean() => this.item1 ?? new Menes.JsonBoolean(this.JsonElement);
        public Menes.JsonInt64 AsJsonInt64() => this.item2 ?? new Menes.JsonInt64(this.JsonElement);
        public JsonObjectExample AsJsonObjectExample() => this.item3?.AsValue<JsonObjectExample>() ?? new JsonObjectExample(this.JsonElement);
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.item1 is Menes.JsonBoolean item1)
            {
                item1.WriteTo(writer);
            }
            else if (this.item2 is Menes.JsonInt64 item2)
            {
                item2.WriteTo(writer);
            }
            else if (this.item3 is Menes.JsonReference item3)
            {
                item3.WriteTo(writer);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }
        public override string? ToString()
        {
            var builder = new System.Text.StringBuilder();
            if (this.IsJsonBoolean)
            {
                builder.Append("{");
                builder.Append("JsonBoolean");
                builder.Append(", ");
                builder.Append(this.AsJsonBoolean().ToString());
                builder.AppendLine("}");
            }
            if (this.IsJsonInt64)
            {
                builder.Append("{");
                builder.Append("JsonInt64");
                builder.Append(", ");
                builder.Append(this.AsJsonInt64().ToString());
                builder.AppendLine("}");
            }
            if (this.IsJsonObjectExample)
            {
                builder.Append("{");
                builder.Append("JsonObjectExample");
                builder.Append(", ");
                builder.Append(this.AsJsonObjectExample().ToString());
                builder.AppendLine("}");
            }
            return builder.Length > 0 ? builder.ToString() : this.JsonElement.ToString();
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            if (this.IsNull)
            {
                return validationContext;
            }
            Menes.ValidationContext validationContext1 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
            Menes.ValidationContext validationContext2 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
            Menes.ValidationContext validationContext3 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
            if (this.IsJsonBoolean)
            {
                validationContext1 = this.AsJsonBoolean().Validate(validationContext1);
            }
            else
            {
                validationContext1 = validationContext1.WithError("The value is not convertible to a Menes.JsonBoolean.");
            }
            if (this.IsJsonInt64)
            {
                validationContext2 = this.AsJsonInt64().Validate(validationContext2);
            }
            else
            {
                validationContext2 = validationContext2.WithError("The value is not convertible to a Menes.JsonInt64.");
            }
            if (this.IsJsonObjectExample)
            {
                validationContext3 = this.AsJsonObjectExample().Validate(validationContext3);
            }
            else
            {
                validationContext3 = validationContext3.WithError("The value is not convertible to a Examples.JsonObjectExample.");
            }
            return Menes.Validation.ValidateAnyOf(validationContext, validationContext1, validationContext2, validationContext3);
        }
    }
}
