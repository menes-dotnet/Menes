// <copyright file="JsonObjectExample.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <Generated />

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501

namespace Examples
{
    public readonly struct JsonObjectExample : Menes.IJsonObject, System.IEquatable<Examples.JsonObjectExample>, Menes.IJsonAdditionalProperties
    {
        public static readonly Examples.JsonObjectExample Null = new Examples.JsonObjectExample(default);
        public static readonly System.Func<System.Text.Json.JsonElement, Examples.JsonObjectExample> FromJsonElement = e => new Examples.JsonObjectExample(e);
        private const string FirstPropertyNamePath = ".first";
        private const string SecondPropertyNamePath = ".second";
        private const string ThirdPropertyNamePath = ".third";
        private const string ChildrenPropertyNamePath = ".children";
        private static readonly System.ReadOnlyMemory<byte> FirstPropertyNameBytes = new byte[] { 102, 105, 114, 115, 116 };
        private static readonly System.ReadOnlyMemory<byte> SecondPropertyNameBytes = new byte[] { 115, 101, 99, 111, 110, 100 };
        private static readonly System.ReadOnlyMemory<byte> ThirdPropertyNameBytes = new byte[] { 116, 104, 105, 114, 100 };
        private static readonly System.ReadOnlyMemory<byte> ChildrenPropertyNameBytes = new byte[] { 99, 104, 105, 108, 100, 114, 101, 110 };
        private static readonly System.Text.Json.JsonEncodedText EncodedFirstPropertyName = System.Text.Json.JsonEncodedText.Encode(FirstPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedSecondPropertyName = System.Text.Json.JsonEncodedText.Encode(SecondPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedThirdPropertyName = System.Text.Json.JsonEncodedText.Encode(ThirdPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedChildrenPropertyName = System.Text.Json.JsonEncodedText.Encode(ChildrenPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(FirstPropertyNameBytes, SecondPropertyNameBytes, ThirdPropertyNameBytes, ChildrenPropertyNameBytes);
        private readonly Menes.JsonString? first;
        private readonly Examples.JsonObjectExample.EnumeratedInt32? second;
        private readonly Menes.JsonDuration? third;
        private readonly Menes.JsonReference? children;
        private readonly Menes.JsonProperties? additionalProperties;
        public JsonObjectExample(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.first = null;
            this.second = null;
            this.third = null;
            this.children = null;
            this.additionalProperties = null;
        }
        public JsonObjectExample(Menes.JsonString first, Examples.JsonObjectExample.EnumeratedInt32 second)
        {
            this.first = first;
            this.second = second;
            this.third = null;
            this.children = null;
            this.JsonElement = default;
            this.additionalProperties = null;
        }
        public JsonObjectExample(Menes.JsonString first, Examples.JsonObjectExample.EnumeratedInt32 second, Menes.JsonDuration? third, Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample? children, Menes.JsonProperties additionalProperties)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample item1)
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
        public JsonObjectExample(Menes.JsonString first, Examples.JsonObjectExample.EnumeratedInt32 second, Menes.JsonDuration? third, Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample? children, params (string, Menes.JsonString)[] additionalProperties)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample item1)
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
        public JsonObjectExample(Menes.JsonString first, Examples.JsonObjectExample.EnumeratedInt32 second, Menes.JsonDuration? third, Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample? children)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample item1)
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
        public JsonObjectExample(Menes.JsonString first, Examples.JsonObjectExample.EnumeratedInt32 second, Menes.JsonDuration? third, Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample? children, (string, Menes.JsonString) additionalProperty1)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample item1)
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
        public JsonObjectExample(Menes.JsonString first, Examples.JsonObjectExample.EnumeratedInt32 second, Menes.JsonDuration? third, Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample? children, (string, Menes.JsonString) additionalProperty1, (string, Menes.JsonString) additionalProperty2)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample item1)
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
        public JsonObjectExample(Menes.JsonString first, Examples.JsonObjectExample.EnumeratedInt32 second, Menes.JsonDuration? third, Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample? children, (string, Menes.JsonString) additionalProperty1, (string, Menes.JsonString) additionalProperty2, (string, Menes.JsonString) additionalProperty3)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample item1)
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
        public JsonObjectExample(Menes.JsonString first, Examples.JsonObjectExample.EnumeratedInt32 second, Menes.JsonDuration? third, Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample? children, (string, Menes.JsonString) additionalProperty1, (string, Menes.JsonString) additionalProperty2, (string, Menes.JsonString) additionalProperty3, (string, Menes.JsonString) additionalProperty4)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample item1)
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
        private JsonObjectExample(Menes.JsonString first, Examples.JsonObjectExample.EnumeratedInt32 second, Menes.JsonDuration? third, Menes.JsonReference? children, Menes.JsonProperties? additionalProperties)
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
        public Examples.JsonObjectExample? AsOptional => this.IsNull ? default(Examples.JsonObjectExample?) : this;
        public Menes.JsonString First => this.first ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, FirstPropertyNameBytes.Span);
        public Examples.JsonObjectExample.EnumeratedInt32 Second => this.second ?? Examples.JsonObjectExample.EnumeratedInt32.FromOptionalProperty(this.JsonElement, SecondPropertyNameBytes.Span);
        public Menes.JsonDuration? Third => this.third ?? Menes.JsonDuration.FromOptionalProperty(this.JsonElement, ThirdPropertyNameBytes.Span).AsOptional;
        public Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample? Children => this.children?.AsValue<Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample>() ?? Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample.FromOptionalProperty(this.JsonElement, ChildrenPropertyNameBytes.Span).AsOptional;
        public int PropertiesCount => KnownProperties.Length + this.AdditionalPropertiesCount;
        public int AdditionalPropertiesCount
        {
            get
            {
                Menes.JsonPropertyEnumerator enumerator = this.AdditionalProperties;
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
        public static Examples.JsonObjectExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Examples.JsonObjectExample(property)
                : Null;
        public static Examples.JsonObjectExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Examples.JsonObjectExample(property)
                : Null;
        public static Examples.JsonObjectExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new Examples.JsonObjectExample(property)
                : Null;
        public Examples.JsonObjectExample WithFirst(Menes.JsonString value)
        {
            return new Examples.JsonObjectExample(value, this.Second, this.Third, this.GetChildren(), this.GetJsonProperties());
        }
        public Examples.JsonObjectExample WithSecond(Examples.JsonObjectExample.EnumeratedInt32 value)
        {
            return new Examples.JsonObjectExample(this.First, value, this.Third, this.GetChildren(), this.GetJsonProperties());
        }
        public Examples.JsonObjectExample WithThird(Menes.JsonDuration? value)
        {
            return new Examples.JsonObjectExample(this.First, this.Second, value, this.GetChildren(), this.GetJsonProperties());
        }
        public Examples.JsonObjectExample WithChildren(Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample? value)
        {
            return new Examples.JsonObjectExample(this.First, this.Second, this.Third, value, this.GetJsonProperties());
        }
        public Examples.JsonObjectExample WithAdditionalProperties(Menes.JsonProperties newAdditional)
        {
            return new Examples.JsonObjectExample(this.First, this.Second, this.Third, this.GetChildren(), newAdditional);
        }
        public Examples.JsonObjectExample WithAdditionalProperties(params (string, Menes.JsonString)[] newAdditional)
        {
            return new Examples.JsonObjectExample(this.First, this.Second, this.Third, this.GetChildren(), Menes.JsonProperties.FromValues(newAdditional));
        }
        public Examples.JsonObjectExample WithAdditionalProperties((string, Menes.JsonString) newAdditional1)
        {
            return new Examples.JsonObjectExample(this.First, this.Second, this.Third, this.GetChildren(), Menes.JsonProperties.FromValues(newAdditional1));
        }
        public Examples.JsonObjectExample WithAdditionalProperties((string, Menes.JsonString) newAdditional1, (string, Menes.JsonString) newAdditional2)
        {
            return new Examples.JsonObjectExample(this.First, this.Second, this.Third, this.GetChildren(), Menes.JsonProperties.FromValues(newAdditional1, newAdditional2));
        }
        public Examples.JsonObjectExample WithAdditionalProperties((string, Menes.JsonString) newAdditional1, (string, Menes.JsonString) newAdditional2, (string, Menes.JsonString) newAdditional3)
        {
            return new Examples.JsonObjectExample(this.First, this.Second, this.Third, this.GetChildren(), Menes.JsonProperties.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Examples.JsonObjectExample WithAdditionalProperties((string, Menes.JsonString) newAdditional1, (string, Menes.JsonString) newAdditional2, (string, Menes.JsonString) newAdditional3, (string, Menes.JsonString) newAdditional4)
        {
            return new Examples.JsonObjectExample(this.First, this.Second, this.Third, this.GetChildren(), Menes.JsonProperties.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                if (this.second is Examples.JsonObjectExample.EnumeratedInt32 second)
                {
                    writer.WritePropertyName(EncodedSecondPropertyName);
                    second.WriteTo(writer);
                }
                if (this.third is Menes.JsonDuration third)
                {
                    writer.WritePropertyName(EncodedThirdPropertyName);
                    third.WriteTo(writer);
                }
                if (this.children is Menes.JsonReference children)
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
        public bool Equals(Examples.JsonObjectExample other)
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
            context = Menes.Validation.ValidateRequiredProperty(context, this.First, FirstPropertyNamePath);
            context = Menes.Validation.ValidateRequiredProperty(context, this.Second, SecondPropertyNamePath);
            if (this.Third is Menes.JsonDuration third)
            {
                context = Menes.Validation.ValidateProperty(context, third, ThirdPropertyNamePath);
            }
            if (this.Children is Examples.JsonObjectExample.ValidatedArrayOfJsonObjectExample children)
            {
                context = Menes.Validation.ValidateProperty(context, children, ChildrenPropertyNamePath);
            }
            foreach (Menes.JsonPropertyReference property in this.AdditionalProperties)
            {
                context = Menes.Validation.ValidateProperty(context, property.AsValue<Menes.JsonString>(), "." + property.Name);
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
        public readonly struct ValidatedArrayOfJsonObjectExample : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Examples.JsonObjectExample>, System.Collections.IEnumerable, System.IEquatable<ValidatedArrayOfJsonObjectExample>, System.IEquatable<Menes.JsonArray<Examples.JsonObjectExample>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, ValidatedArrayOfJsonObjectExample> FromJsonElement = e => new ValidatedArrayOfJsonObjectExample(e);
            public static readonly ValidatedArrayOfJsonObjectExample Null = new ValidatedArrayOfJsonObjectExample(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<Examples.JsonObjectExample>? value;
            public ValidatedArrayOfJsonObjectExample(Menes.JsonArray<Examples.JsonObjectExample> jsonArray)
            {
                if (jsonArray.HasJsonElement)
                {
                    this.JsonElement = jsonArray.JsonElement;
                    this.value = null;
                }
                else
                {
                    this.value = jsonArray;
                    this.JsonElement = default;
                }
            }
            public ValidatedArrayOfJsonObjectExample(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public ValidatedArrayOfJsonObjectExample? AsOptional => this.IsNull ? default(ValidatedArrayOfJsonObjectExample?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement
            {
                get;
            }
            public static implicit operator ValidatedArrayOfJsonObjectExample(Menes.JsonArray<Examples.JsonObjectExample> value)
            {
                return new ValidatedArrayOfJsonObjectExample(value);
            }
            public static implicit operator Menes.JsonArray<Examples.JsonObjectExample>(ValidatedArrayOfJsonObjectExample value)
            {
                if (value.value is Menes.JsonArray<Examples.JsonObjectExample> clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonArray<Examples.JsonObjectExample>(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonArray<Examples.JsonObjectExample>.IsConvertibleFrom(jsonElement);
            }
            public static ValidatedArrayOfJsonObjectExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? ValidatedArrayOfJsonObjectExample.FromJsonElement(property)
                    : Null;
            public static ValidatedArrayOfJsonObjectExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? ValidatedArrayOfJsonObjectExample.FromJsonElement(property)
                    : Null;
            public static ValidatedArrayOfJsonObjectExample FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? ValidatedArrayOfJsonObjectExample.FromJsonElement(property)
                    : Null;
            public bool Equals(ValidatedArrayOfJsonObjectExample other)
            {
                return this.Equals((Menes.JsonArray<Examples.JsonObjectExample>)other);
            }
            public bool Equals(Menes.JsonArray<Examples.JsonObjectExample> other)
            {
                return ((Menes.JsonArray<Examples.JsonObjectExample>)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonArray<Examples.JsonObjectExample> array = this;
                Menes.ValidationContext context = validationContext;
                context = array.Validate(context);
                context = array.ValidateMinItems(context, 10);
                return array.ValidateItems(context);
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                if (this.value is Menes.JsonArray<Examples.JsonObjectExample> clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public Menes.JsonArray<Examples.JsonObjectExample>.JsonArrayEnumerator GetEnumerator()
            {
                return ((Menes.JsonArray<Examples.JsonObjectExample>)this).GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Examples.JsonObjectExample> System.Collections.Generic.IEnumerable<Examples.JsonObjectExample>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
        public readonly struct EnumeratedInt32 : Menes.IJsonValue, System.IEquatable<EnumeratedInt32>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, EnumeratedInt32> FromJsonElement = e => new EnumeratedInt32(e);
            public static readonly EnumeratedInt32 Null = new EnumeratedInt32(default(System.Text.Json.JsonElement));
            private static readonly int? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<int>? EnumValues = BuildEnumValues();
            private static readonly int? MultipleOf = null;
            private static readonly int? Maximum = null;
            private static readonly int? ExclusiveMaximum = null;
            private static readonly int? Minimum = null;
            private static readonly int? ExclusiveMinimum = null;
            private readonly Menes.JsonInt32? value;
            public EnumeratedInt32(Menes.JsonInt32 value)
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
            public EnumeratedInt32(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public EnumeratedInt32? AsOptional => this.IsNull ? default(EnumeratedInt32?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement
            {
                get;
            }
            public static implicit operator EnumeratedInt32(Menes.JsonInt32 value)
            {
                return new EnumeratedInt32(value);
            }
            public static implicit operator EnumeratedInt32(int value)
            {
                return new EnumeratedInt32(value);
            }
            public static implicit operator Menes.JsonInt32(EnumeratedInt32 value)
            {
                if (value.value is Menes.JsonInt32 clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonInt32(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonInt32.IsConvertibleFrom(jsonElement);
            }
            public static EnumeratedInt32 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? EnumeratedInt32.FromJsonElement(property)
                    : Null;
            public static EnumeratedInt32 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? EnumeratedInt32.FromJsonElement(property)
                    : Null;
            public static EnumeratedInt32 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? EnumeratedInt32.FromJsonElement(property)
                    : Null;
            public bool Equals(EnumeratedInt32 other)
            {
                return this.Equals((Menes.JsonInt32)other);
            }
            public bool Equals(Menes.JsonInt32 other)
            {
                return ((Menes.JsonInt32)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonInt32 value = this;
                Menes.ValidationContext context = validationContext;
                context = value.Validate(context);
                context = value.ValidateAsNumber(context, MultipleOf, Maximum, ExclusiveMaximum, Minimum, ExclusiveMinimum, EnumValues, ConstValue);
                return context;
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else if (this.value is Menes.JsonInt32 clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            private static int? BuildConstValue()
            {
                return null;
            }
            private static System.Collections.Immutable.ImmutableArray<int>? BuildEnumValues()
            {
                System.Collections.Immutable.ImmutableArray<int>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<int>();
                arrayBuilder.Add(100);
                arrayBuilder.Add(200);
                arrayBuilder.Add(300);
                return arrayBuilder.ToImmutable();
            }
        }
    }
}