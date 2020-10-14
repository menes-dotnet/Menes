// <copyright file="JsonDiscriminatedUnionExample.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501

namespace Examples
{
    public readonly struct JsonDiscriminatedUnionExample : Menes.IJsonValue
    {
        public static readonly JsonDiscriminatedUnionExample Null = new JsonDiscriminatedUnionExample(default(System.Text.Json.JsonElement));
        private static readonly System.ReadOnlyMemory<byte> DiscriminatorPropertyName = new byte[] { 99, 111, 110, 116, 101, 110, 116, 84, 121, 112, 101 };
        private static readonly System.ReadOnlyMemory<byte> JsonBooleanDiscriminatorValue = new byte[] { 97, 98, 105, 116, 102, 97, 107, 101 };
        private static readonly System.ReadOnlyMemory<byte> JsonInt64DiscriminatorValue = new byte[] { 115, 116, 105, 108, 108, 113, 117, 105, 116, 101, 102, 97, 107, 101 };
        private static readonly System.ReadOnlyMemory<byte> JsonObjectExampleDiscriminatorValue = new byte[] { 116, 111, 116, 97, 108, 70, 97, 107, 101, 114, 121 };
        private readonly Menes.JsonBoolean? item1;
        private readonly Menes.JsonInt64? item2;
        private readonly Menes.JsonReference? item3;
        public JsonDiscriminatedUnionExample(Menes.JsonBoolean clrInstance)
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
        public JsonDiscriminatedUnionExample(Menes.JsonInt64 clrInstance)
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
        public JsonDiscriminatedUnionExample(Examples.JsonObjectExample clrInstance)
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
        public JsonDiscriminatedUnionExample(System.Text.Json.JsonElement jsonElement)
        {
            this.item1 = null;
            this.item2 = null;
            this.item3 = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.item1 is null && this.item2 is null && this.item3 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public JsonDiscriminatedUnionExample? AsOptional => this.IsNull ? default(JsonDiscriminatedUnionExample?) : this;
        public bool IsJsonBoolean => this.item1 is Menes.JsonBoolean || (this.JsonElement.TryGetProperty(DiscriminatorPropertyName.Span, out System.Text.Json.JsonElement propVal) && propVal.ValueEquals(JsonBooleanDiscriminatorValue.Span));
        public bool IsJsonInt64 => this.item2 is Menes.JsonInt64 || (this.JsonElement.TryGetProperty(DiscriminatorPropertyName.Span, out System.Text.Json.JsonElement propVal) && propVal.ValueEquals(JsonInt64DiscriminatorValue.Span));
        public bool IsJsonObjectExample => this.item3 is Menes.JsonReference || (this.JsonElement.TryGetProperty(DiscriminatorPropertyName.Span, out System.Text.Json.JsonElement propVal) && propVal.ValueEquals(JsonObjectExampleDiscriminatorValue.Span));
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static explicit operator Menes.JsonBoolean(JsonDiscriminatedUnionExample value) => value.AsJsonBoolean();
        public static implicit operator JsonDiscriminatedUnionExample(Menes.JsonBoolean value) => new JsonDiscriminatedUnionExample(value);
        public static explicit operator Menes.JsonInt64(JsonDiscriminatedUnionExample value) => value.AsJsonInt64();
        public static implicit operator JsonDiscriminatedUnionExample(Menes.JsonInt64 value) => new JsonDiscriminatedUnionExample(value);
        public static explicit operator Examples.JsonObjectExample(JsonDiscriminatedUnionExample value) => value.AsJsonObjectExample();
        public static implicit operator JsonDiscriminatedUnionExample(Examples.JsonObjectExample value) => new JsonDiscriminatedUnionExample(value);
        public static JsonDiscriminatedUnionExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new JsonDiscriminatedUnionExample(property)
                : Null;
        public static JsonDiscriminatedUnionExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new JsonDiscriminatedUnionExample(property)
                : Null;
        public static JsonDiscriminatedUnionExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new JsonDiscriminatedUnionExample(property)
                : Null;
        public Menes.JsonBoolean AsJsonBoolean() => this.IsJsonBoolean ? this.item1 ?? new Menes.JsonBoolean(this.JsonElement) : throw new System.Text.Json.JsonException("The union value is not a Menes.JsonBoolean");
        public Menes.JsonInt64 AsJsonInt64() => this.IsJsonInt64 ? this.item2 ?? new Menes.JsonInt64(this.JsonElement) : throw new System.Text.Json.JsonException("The union value is not a Menes.JsonInt64");
        public Examples.JsonObjectExample AsJsonObjectExample() => this.IsJsonObjectExample ? this.item3?.AsValue<Examples.JsonObjectExample>() ?? new Examples.JsonObjectExample(this.JsonElement) : throw new System.Text.Json.JsonException("The union value is not a Examples.JsonObjectExample");
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
            Menes.ValidationContext context = validationContext;
            if (this.IsJsonBoolean)
            {
                context = this.AsJsonBoolean().Validate(context);
            }
            if (this.IsJsonInt64)
            {
                context = this.AsJsonInt64().Validate(context);
            }
            if (this.IsJsonObjectExample)
            {
                context = this.AsJsonObjectExample().Validate(context);
            }
            return context;
        }
    }
}
