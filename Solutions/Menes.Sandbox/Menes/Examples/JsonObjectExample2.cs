// <copyright file="JsonObjectExample2.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <Generated />

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501

namespace Menes.Examples
{
    public readonly struct JsonObjectExample2 : Menes.IJsonObject, System.IEquatable<Menes.Examples.JsonObjectExample2>, Menes.IJsonAdditionalProperties
    {
        public static readonly Menes.Examples.JsonObjectExample2 Null = new Menes.Examples.JsonObjectExample2(default);
        public static readonly System.Func<System.Text.Json.JsonElement, Menes.Examples.JsonObjectExample2> FromJsonElement = e => new Menes.Examples.JsonObjectExample2(e);
        private const string FirstPropertyName = "first";
        private const string SecondPropertyName = "second";
        private const string ThirdPropertyName = "third";
        private const string ChildrenPropertyName = "children";
        private const string FirstPropertyNamePath = ".first";
        private const string SecondPropertyNamePath = ".second";
        private const string ThirdPropertyNamePath = ".third";
        private const string ChildrenPropertyNamePath = ".children";
        private static readonly System.Text.Json.JsonEncodedText EncodedFirstPropertyName = System.Text.Json.JsonEncodedText.Encode(FirstPropertyName);
        private static readonly System.Text.Json.JsonEncodedText EncodedSecondPropertyName = System.Text.Json.JsonEncodedText.Encode(SecondPropertyName);
        private static readonly System.Text.Json.JsonEncodedText EncodedThirdPropertyName = System.Text.Json.JsonEncodedText.Encode(ThirdPropertyName);
        private static readonly System.Text.Json.JsonEncodedText EncodedChildrenPropertyName = System.Text.Json.JsonEncodedText.Encode(ChildrenPropertyName);
        private static readonly System.ReadOnlyMemory<byte> FirstPropertyNameBytes = System.Text.Encoding.UTF8.GetBytes(FirstPropertyName);
        private static readonly System.ReadOnlyMemory<byte> SecondPropertyNameBytes = System.Text.Encoding.UTF8.GetBytes(SecondPropertyName);
        private static readonly System.ReadOnlyMemory<byte> ThirdPropertyNameBytes = System.Text.Encoding.UTF8.GetBytes(ThirdPropertyName);
        private static readonly System.ReadOnlyMemory<byte> ChildrenPropertyNameBytes = System.Text.Encoding.UTF8.GetBytes(ChildrenPropertyName);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(FirstPropertyNameBytes, SecondPropertyNameBytes, ThirdPropertyNameBytes, ChildrenPropertyNameBytes);
        private readonly Menes.JsonString? first;
        private readonly Menes.JsonInt32? second;
        private readonly Menes.JsonDuration? third;
        private readonly Menes.JsonReference? children;
        private readonly Menes.JsonProperties? additionalProperties;
        public JsonObjectExample2(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.first = null;
            this.second = null;
            this.third = null;
            this.children = null;
            this.additionalProperties = null;
        }
        public JsonObjectExample2(Menes.JsonString first, Menes.JsonInt32 second)
        {
            this.first = first;
            this.second = second;
            this.third = null;
            this.children = null;
            this.JsonElement = default;
            this.additionalProperties = null;
        }
        public JsonObjectExample2(Menes.JsonString first, Menes.JsonInt32 second, Menes.JsonDuration? third, Menes.JsonArray<Menes.Examples.JsonObjectExample2>? children, Menes.JsonProperties additionalProperties)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Menes.JsonArray<Menes.Examples.JsonObjectExample2> item1)
            {
                this.children = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.children = null;
            }
            this.JsonElement = default;
            this.additionalProperties = additionalProperties;
        }
        public JsonObjectExample2(Menes.JsonString first, Menes.JsonInt32 second, Menes.JsonDuration? third, Menes.JsonArray<Menes.Examples.JsonObjectExample2>? children, params (string, Menes.JsonString)[] additionalProperties)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Menes.JsonArray<Menes.Examples.JsonObjectExample2> item1)
            {
                this.children = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.children = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperties);
        }
        public JsonObjectExample2(Menes.JsonString first, Menes.JsonInt32 second, Menes.JsonDuration? third, Menes.JsonArray<Menes.Examples.JsonObjectExample2>? children)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Menes.JsonArray<Menes.Examples.JsonObjectExample2> item1)
            {
                this.children = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.children = null;
            }
            this.JsonElement = default;
            this.additionalProperties = null;
        }
        public JsonObjectExample2(Menes.JsonString first, Menes.JsonInt32 second, Menes.JsonDuration? third, Menes.JsonArray<Menes.Examples.JsonObjectExample2>? children, (string, Menes.JsonString) additionalProperty1)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Menes.JsonArray<Menes.Examples.JsonObjectExample2> item1)
            {
                this.children = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.children = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1);
        }
        public JsonObjectExample2(Menes.JsonString first, Menes.JsonInt32 second, Menes.JsonDuration? third, Menes.JsonArray<Menes.Examples.JsonObjectExample2>? children, (string, Menes.JsonString) additionalProperty1, (string, Menes.JsonString) additionalProperty2)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Menes.JsonArray<Menes.Examples.JsonObjectExample2> item1)
            {
                this.children = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.children = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1, additionalProperty2);
        }
        public JsonObjectExample2(Menes.JsonString first, Menes.JsonInt32 second, Menes.JsonDuration? third, Menes.JsonArray<Menes.Examples.JsonObjectExample2>? children, (string, Menes.JsonString) additionalProperty1, (string, Menes.JsonString) additionalProperty2, (string, Menes.JsonString) additionalProperty3)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Menes.JsonArray<Menes.Examples.JsonObjectExample2> item1)
            {
                this.children = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.children = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public JsonObjectExample2(Menes.JsonString first, Menes.JsonInt32 second, Menes.JsonDuration? third, Menes.JsonArray<Menes.Examples.JsonObjectExample2>? children, (string, Menes.JsonString) additionalProperty1, (string, Menes.JsonString) additionalProperty2, (string, Menes.JsonString) additionalProperty3, (string, Menes.JsonString) additionalProperty4)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Menes.JsonArray<Menes.Examples.JsonObjectExample2> item1)
            {
                this.children = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.children = null;
            }
            this.JsonElement = default;
            this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private JsonObjectExample2(Menes.JsonString first, Menes.JsonInt32 second, Menes.JsonDuration? third, Menes.JsonReference? children, Menes.JsonProperties? additionalProperties)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Menes.JsonReference item1)
            {
                this.children = item1;
            }
            else
            {
                this.children = null;
            }
            this.JsonElement = default;
            this.additionalProperties = additionalProperties;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.first is null || this.first.Value.IsNull) && (this.second is null || this.second.Value.IsNull) && (this.third is null || this.third.Value.IsNull) && (this.children is null || this.children.Value.IsNull);
        public Menes.Examples.JsonObjectExample2? AsOptional => this.IsNull ? default(Menes.Examples.JsonObjectExample2?) : this;
        public Menes.JsonString First => this.first ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, FirstPropertyNameBytes.Span);
        public Menes.JsonInt32 Second => this.second ?? Menes.JsonInt32.FromOptionalProperty(this.JsonElement, SecondPropertyNameBytes.Span);
        public Menes.JsonDuration? Third => this.third ?? Menes.JsonDuration.FromOptionalProperty(this.JsonElement, ThirdPropertyNameBytes.Span).AsOptional;
        public Menes.JsonArray<Menes.Examples.JsonObjectExample2>? Children => this.children?.AsValue<Menes.JsonArray<Menes.Examples.JsonObjectExample2>>() ?? Menes.JsonArray<Menes.Examples.JsonObjectExample2>.FromOptionalProperty(this.JsonElement, ChildrenPropertyNameBytes.Span).AsOptional;
        public int PropertiesCount => KnownProperties.Length + this.AdditionalPropertiesCount; public int AdditionalPropertiesCount
        {
            get
            {
                JsonPropertyEnumerator enumerator = this.AdditionalProperties;
                int count = 0;

                while (enumerator.MoveNext())
                {
                    count++;
                }

                return count;
            }
        }
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement
        {
            get;
        }
        public Menes.JsonPropertyEnumerator AdditionalProperties
        {
            get
            {
                if (this.additionalProperties is Menes.JsonProperties ap)
                {
                    return new Menes.JsonPropertyEnumerator(ap, KnownProperties);
                }

                if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    return new Menes.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                }

                return new Menes.JsonPropertyEnumerator(Menes.JsonProperties.Empty, KnownProperties);
            }
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
        }
        public static Menes.Examples.JsonObjectExample2 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Menes.Examples.JsonObjectExample2(property)
                : Null;
        public static Menes.Examples.JsonObjectExample2 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Menes.Examples.JsonObjectExample2(property)
                : Null;
        public static Menes.Examples.JsonObjectExample2 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new Menes.Examples.JsonObjectExample2(property)
                : Null;
        public Menes.Examples.JsonObjectExample2 WithFirst(Menes.JsonString value)
        {
            return new Menes.Examples.JsonObjectExample2(value, this.Second, this.Third, this.GetChildren(), this.GetJsonProperties());
        }
        public Menes.Examples.JsonObjectExample2 WithSecond(Menes.JsonInt32 value)
        {
            return new Menes.Examples.JsonObjectExample2(this.First, value, this.Third, this.GetChildren(), this.GetJsonProperties());
        }
        public Menes.Examples.JsonObjectExample2 WithThird(Menes.JsonDuration? value)
        {
            return new Menes.Examples.JsonObjectExample2(this.First, this.Second, value, this.GetChildren(), this.GetJsonProperties());
        }
        public Menes.Examples.JsonObjectExample2 WithChildren(Menes.JsonArray<Menes.Examples.JsonObjectExample2>? value)
        {
            return new Menes.Examples.JsonObjectExample2(this.First, this.Second, this.Third, value, this.GetJsonProperties());
        }
        public Menes.Examples.JsonObjectExample2 WithAdditionalProperties(JsonProperties newAdditional)
        {
            return new Menes.Examples.JsonObjectExample2(this.First, this.Second, this.Third, this.GetChildren(), newAdditional);
        }
        public Menes.Examples.JsonObjectExample2 WithAdditionalProperties(params (string, Menes.JsonString)[] newAdditional)
        {
            return new Menes.Examples.JsonObjectExample2(this.First, this.Second, this.Third, this.GetChildren(), Menes.JsonProperties.FromValues(newAdditional));
        }
        public Menes.Examples.JsonObjectExample2 WithAdditionalProperties((string, Menes.JsonString) newAdditional1)
        {
            return new Menes.Examples.JsonObjectExample2(this.First, this.Second, this.Third, this.GetChildren(), Menes.JsonProperties.FromValues(newAdditional1));
        }
        public Menes.Examples.JsonObjectExample2 WithAdditionalProperties((string, Menes.JsonString) newAdditional1, (string, Menes.JsonString) newAdditional2)
        {
            return new Menes.Examples.JsonObjectExample2(this.First, this.Second, this.Third, this.GetChildren(), Menes.JsonProperties.FromValues(newAdditional1, newAdditional2));
        }
        public Menes.Examples.JsonObjectExample2 WithAdditionalProperties((string, Menes.JsonString) newAdditional1, (string, Menes.JsonString) newAdditional2, (string, Menes.JsonString) newAdditional3)
        {
            return new Menes.Examples.JsonObjectExample2(this.First, this.Second, this.Third, this.GetChildren(), Menes.JsonProperties.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Menes.Examples.JsonObjectExample2 WithAdditionalProperties((string, Menes.JsonString) newAdditional1, (string, Menes.JsonString) newAdditional2, (string, Menes.JsonString) newAdditional3, (string, Menes.JsonString) newAdditional4)
        {
            return new Menes.Examples.JsonObjectExample2(this.First, this.Second, this.Third, this.GetChildren(), Menes.JsonProperties.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                if (this.first is Menes.JsonString first)
                {
                    writer.WritePropertyName(EncodedFirstPropertyName);
                    first.WriteTo(writer);
                }
                if (this.second is Menes.JsonInt32 second)
                {
                    writer.WritePropertyName(EncodedSecondPropertyName);
                    second.WriteTo(writer);
                }
                if (this.third is Menes.JsonDuration third)
                {
                    writer.WritePropertyName(EncodedThirdPropertyName);
                    third.WriteTo(writer);
                }
                if (this.children is JsonReference children)
                {
                    writer.WritePropertyName(EncodedChildrenPropertyName);
                    children.WriteTo(writer);
                }
                Menes.JsonPropertyEnumerator enumerator = this.AdditionalProperties;
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(Menes.Examples.JsonObjectExample2 other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }
            if (this.HasJsonElement && other.HasJsonElement)
            {
                return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
            }
            return this.First.Equals(other.First) && this.Second.Equals(other.Second) && this.Third.Equals(other.Third) && this.Children.Equals(other.Children) && System.Linq.Enumerable.SequenceEqual(this.AdditionalProperties, other.AdditionalProperties);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.ValidationContext context = validationContext;
            context = Validation.ValidateRequiredProperty(context, this.First, FirstPropertyNamePath);
            context = Validation.ValidateRequiredProperty(context, this.Second, SecondPropertyNamePath);
            if (this.Third is Menes.JsonDuration third)
            {
                context = Menes.Validation.ValidateProperty(context, third, ThirdPropertyNamePath);
            }
            if (this.Children is Menes.JsonArray<Menes.Examples.JsonObjectExample2> children)
            {
                context = Menes.Validation.ValidateProperty(context, children, ChildrenPropertyNamePath);
            }
            foreach (JsonPropertyReference property in this.AdditionalProperties)
            {
                context = Validation.ValidateProperty(context, property.AsValue<Menes.JsonString>(), "." + property.Name);
            }
            return context;
        }
        public bool TryGetAdditionalProperty(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonString? value)
        {
            return this.TryGetAdditionalProperty(System.MemoryExtensions.AsSpan(propertyName), out value);
        }
        public bool TryGetAdditionalProperty(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonString? value)
        {
            foreach (Menes.JsonPropertyReference property in this.AdditionalProperties)
            {
                if (property.NameEquals(utf8PropertyName))
                {
                    value = property.AsValue<Menes.JsonString>();
                    return true;
                }
            }
            value = default;
            return false;
        }
        public bool TryGetAdditionalProperty(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonString? value)
        {
            System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
            int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
            return this.TryGetAdditionalProperty(bytes.Slice(0, written), out value);
        }
        private Menes.JsonReference? GetChildren()
        {
            if (this.children is Menes.JsonReference)
            {
                return this.children;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(ChildrenPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonProperties GetJsonProperties()
        {
            if (this.additionalProperties is Menes.JsonProperties props)
            {
                return props;
            }
            return new Menes.JsonProperties(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.AdditionalProperties));
        }
    }
}