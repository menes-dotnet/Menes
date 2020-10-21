// <copyright file="SomeType0.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501

namespace Examples
{
    public readonly struct SomeType0 : Menes.IJsonObject, System.IEquatable<SomeType0>
    {
        public static readonly SomeType0 Null = new SomeType0(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, SomeType0> FromJsonElement = e => new SomeType0(e);
        private const string AnotherPersonPropertyNamePath = ".anotherPerson";
        private const string FirstNamePropertyNamePath = ".firstName";
        private const string LastNamePropertyNamePath = ".lastName";
        private const string AgePropertyNamePath = ".age";
        private static readonly System.ReadOnlyMemory<byte> AnotherPersonPropertyNameBytes = new byte[] { 97, 110, 111, 116, 104, 101, 114, 80, 101, 114, 115, 111, 110 };
        private static readonly System.ReadOnlyMemory<byte> FirstNamePropertyNameBytes = new byte[] { 102, 105, 114, 115, 116, 78, 97, 109, 101 };
        private static readonly System.ReadOnlyMemory<byte> LastNamePropertyNameBytes = new byte[] { 108, 97, 115, 116, 78, 97, 109, 101 };
        private static readonly System.ReadOnlyMemory<byte> AgePropertyNameBytes = new byte[] { 97, 103, 101 };
        private static readonly System.Text.Json.JsonEncodedText EncodedAnotherPersonPropertyName = System.Text.Json.JsonEncodedText.Encode(AnotherPersonPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedFirstNamePropertyName = System.Text.Json.JsonEncodedText.Encode(FirstNamePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedLastNamePropertyName = System.Text.Json.JsonEncodedText.Encode(LastNamePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedAgePropertyName = System.Text.Json.JsonEncodedText.Encode(AgePropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(AnotherPersonPropertyNameBytes, FirstNamePropertyNameBytes, LastNamePropertyNameBytes, AgePropertyNameBytes);
        private readonly Menes.JsonReference? anotherPerson;
        private readonly Menes.JsonString? firstName;
        private readonly Menes.JsonString? lastName;
        private readonly SomeType0.SomeType3? age;
        public SomeType0(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.anotherPerson = null;
            this.firstName = null;
            this.lastName = null;
            this.age = null;
        }
        public SomeType0(SomeType0? anotherPerson, Menes.JsonString? firstName, Menes.JsonString? lastName, SomeType0.SomeType3? age)
        {
            if (anotherPerson is SomeType0 item1)
            {
                this.anotherPerson = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.anotherPerson = null;
            }
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.JsonElement = default;
        }
        private SomeType0(Menes.JsonReference? anotherPerson, Menes.JsonString? firstName, Menes.JsonString? lastName, SomeType0.SomeType3? age)
        {
            if (anotherPerson is Menes.JsonReference item1)
            {
                this.anotherPerson = item1;
            }
            else
            {
                this.anotherPerson = null;
            }
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.JsonElement = default;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.anotherPerson is null || this.anotherPerson.Value.IsNull) && (this.firstName is null || this.firstName.Value.IsNull) && (this.lastName is null || this.lastName.Value.IsNull) && (this.age is null || this.age.Value.IsNull);
        public SomeType0? AsOptional => this.IsNull ? default(SomeType0?) : this;
        public SomeType0? AnotherPerson => this.anotherPerson?.AsValue<SomeType0>() ?? SomeType0.FromOptionalProperty(this.JsonElement, AnotherPersonPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? FirstName => this.firstName ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, FirstNamePropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? LastName => this.lastName ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, LastNamePropertyNameBytes.Span).AsOptional;
        public SomeType0.SomeType3? Age => this.age ?? SomeType0.SomeType3.FromOptionalProperty(this.JsonElement, AgePropertyNameBytes.Span).AsOptional;
        public int PropertiesCount => KnownProperties.Length;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
        }
        public static SomeType0 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SomeType0(property)
                    : Null)
                : Null;
        public static SomeType0 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SomeType0(property)
                    : Null)
                : Null;
        public static SomeType0 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new SomeType0(property)
                    : Null)
            : Null;
        public SomeType0 WithAnotherPerson(SomeType0? value)
        {
            return new SomeType0(Menes.JsonReference.FromValue(value), this.FirstName, this.LastName, this.Age);
        }
        public SomeType0 WithFirstName(Menes.JsonString? value)
        {
            return new SomeType0(this.GetAnotherPerson(), value, this.LastName, this.Age);
        }
        public SomeType0 WithLastName(Menes.JsonString? value)
        {
            return new SomeType0(this.GetAnotherPerson(), this.FirstName, value, this.Age);
        }
        public SomeType0 WithAge(SomeType0.SomeType3? value)
        {
            return new SomeType0(this.GetAnotherPerson(), this.FirstName, this.LastName, value);
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
                if (this.anotherPerson is Menes.JsonReference anotherPerson)
                {
                    writer.WritePropertyName(EncodedAnotherPersonPropertyName);
                    anotherPerson.WriteTo(writer);
                }
                if (this.firstName is Menes.JsonString firstName)
                {
                    writer.WritePropertyName(EncodedFirstNamePropertyName);
                    firstName.WriteTo(writer);
                }
                if (this.lastName is Menes.JsonString lastName)
                {
                    writer.WritePropertyName(EncodedLastNamePropertyName);
                    lastName.WriteTo(writer);
                }
                if (this.age is SomeType0.SomeType3 age)
                {
                    writer.WritePropertyName(EncodedAgePropertyName);
                    age.WriteTo(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(SomeType0 other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }
            if (this.HasJsonElement && other.HasJsonElement)
            {
                return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
            }
            return this.AnotherPerson.Equals(other.AnotherPerson) && this.FirstName.Equals(other.FirstName) && this.LastName.Equals(other.LastName) && this.Age.Equals(other.Age);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.ValidationContext context = validationContext;
            if (this.AnotherPerson is SomeType0 anotherPerson)
            {
                context = Menes.Validation.ValidateProperty(context, anotherPerson, AnotherPersonPropertyNamePath);
            }
            if (this.FirstName is Menes.JsonString firstName)
            {
                context = Menes.Validation.ValidateProperty(context, firstName, FirstNamePropertyNamePath);
            }
            if (this.LastName is Menes.JsonString lastName)
            {
                context = Menes.Validation.ValidateProperty(context, lastName, LastNamePropertyNamePath);
            }
            if (this.Age is SomeType0.SomeType3 age)
            {
                context = Menes.Validation.ValidateProperty(context, age, AgePropertyNamePath);
            }
            return context;
        }
        public override string? ToString()
        {
            return Menes.JsonAny.From(this).ToString();
        }
        private Menes.JsonReference? GetAnotherPerson()
        {
            if (this.anotherPerson is Menes.JsonReference)
            {
                return this.anotherPerson;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(AnotherPersonPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        public readonly struct SomeType3 : Menes.IJsonValue, System.IEquatable<SomeType3>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, SomeType3> FromJsonElement = e => new SomeType3(e);
            public static readonly SomeType3 Null = new SomeType3(default(System.Text.Json.JsonElement));
            private static readonly Menes.JsonInteger? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>? EnumValues = BuildEnumValues();
            private static readonly Menes.JsonInteger? MultipleOf = null;
            private static readonly Menes.JsonInteger? Maximum = null;
            private static readonly Menes.JsonInteger? ExclusiveMaximum = null;
            private static readonly Menes.JsonInteger? Minimum = 0;
            private static readonly Menes.JsonInteger? ExclusiveMinimum = null;
            private readonly Menes.JsonInteger? value;
            public SomeType3(Menes.JsonInteger value)
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
            public SomeType3(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public SomeType3? AsOptional => this.IsNull ? default(SomeType3?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator SomeType3(Menes.JsonInteger value)
            {
                return new SomeType3(value);
            }
            public static implicit operator SomeType3(int value)
            {
                return new SomeType3(value);
            }
            public static implicit operator SomeType3(long value)
            {
                return new SomeType3(value);
            }
            public static implicit operator int(SomeType3 value)
            {
                return (int)(Menes.JsonInteger)value;
            }
            public static implicit operator long(SomeType3 value)
            {
                return (long)(Menes.JsonInteger)value;
            }
            public static implicit operator Menes.JsonInteger(SomeType3 value)
            {
                if (value.value is Menes.JsonInteger clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonInteger(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonInteger.IsConvertibleFrom(jsonElement);
            }
            public static SomeType3 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SomeType3(property)
                        : Null)
                    : Null;
            public static SomeType3 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SomeType3(property)
                        : Null)
                    : Null;
            public static SomeType3 FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new SomeType3(property)
                        : Null)
                    : Null;
            public bool Equals(SomeType3 other)
            {
                return this.Equals((Menes.JsonInteger)other);
            }
            public bool Equals(Menes.JsonInteger other)
            {
                return ((Menes.JsonInteger)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonInteger value = this;
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
                else if (this.value is Menes.JsonInteger clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public override string? ToString()
            {
                if (this.value is Menes.JsonInteger clrValue)
                {
                    return clrValue.ToString();
                }
                else
                {
                    return this.JsonElement.GetRawText();
                }
            }
            private static Menes.JsonInteger? BuildConstValue()
            {
                return null;
            }
            private static System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>? BuildEnumValues()
            {
                return null;
            }
        }
    }
}
