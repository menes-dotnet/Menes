// <copyright file="Person.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501

namespace Examples
{
    public readonly struct Person : Menes.IJsonObject, System.IEquatable<Person>
    {
        public static readonly Person Null = new Person(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Person> FromJsonElement = e => new Person(e);
        private const string AnotherPersonPropertyNamePath = ".anotherPerson";
        private const string FirstNamePropertyNamePath = ".firstName";
        private const string LastNamePropertyNamePath = ".lastName";
        private const string ContactPropertyNamePath = ".contact";
        private const string AgePropertyNamePath = ".age";
        private static readonly System.ReadOnlyMemory<byte> AnotherPersonPropertyNameBytes = new byte[] { 97, 110, 111, 116, 104, 101, 114, 80, 101, 114, 115, 111, 110 };
        private static readonly System.ReadOnlyMemory<byte> FirstNamePropertyNameBytes = new byte[] { 102, 105, 114, 115, 116, 78, 97, 109, 101 };
        private static readonly System.ReadOnlyMemory<byte> LastNamePropertyNameBytes = new byte[] { 108, 97, 115, 116, 78, 97, 109, 101 };
        private static readonly System.ReadOnlyMemory<byte> ContactPropertyNameBytes = new byte[] { 99, 111, 110, 116, 97, 99, 116 };
        private static readonly System.ReadOnlyMemory<byte> AgePropertyNameBytes = new byte[] { 97, 103, 101 };
        private static readonly System.Text.Json.JsonEncodedText EncodedAnotherPersonPropertyName = System.Text.Json.JsonEncodedText.Encode(AnotherPersonPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedFirstNamePropertyName = System.Text.Json.JsonEncodedText.Encode(FirstNamePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedLastNamePropertyName = System.Text.Json.JsonEncodedText.Encode(LastNamePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedContactPropertyName = System.Text.Json.JsonEncodedText.Encode(ContactPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedAgePropertyName = System.Text.Json.JsonEncodedText.Encode(AgePropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(AnotherPersonPropertyNameBytes, FirstNamePropertyNameBytes, LastNamePropertyNameBytes, ContactPropertyNameBytes, AgePropertyNameBytes);
        private readonly Menes.JsonReference? anotherPerson;
        private readonly Menes.JsonString? firstName;
        private readonly Menes.JsonString? lastName;
        private readonly Person.ContactValue? contact;
        private readonly Person.AgeValue? age;
        public Person(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.anotherPerson = null;
            this.firstName = null;
            this.lastName = null;
            this.contact = null;
            this.age = null;
        }
        public Person(Person? anotherPerson, Menes.JsonString? firstName, Menes.JsonString? lastName, Person.ContactValue? contact, Person.AgeValue? age)
        {
            if (anotherPerson is Person item1)
            {
                this.anotherPerson = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.anotherPerson = null;
            }
            this.firstName = firstName;
            this.lastName = lastName;
            this.contact = contact;
            this.age = age;
            this.JsonElement = default;
        }
        private Person(Menes.JsonReference? anotherPerson, Menes.JsonString? firstName, Menes.JsonString? lastName, Person.ContactValue? contact, Person.AgeValue? age)
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
            this.contact = contact;
            this.age = age;
            this.JsonElement = default;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.anotherPerson is null || this.anotherPerson.Value.IsNull) && (this.firstName is null || this.firstName.Value.IsNull) && (this.lastName is null || this.lastName.Value.IsNull) && (this.contact is null || this.contact.Value.IsNull) && (this.age is null || this.age.Value.IsNull);
        public Person? AsOptional => this.IsNull ? default(Person?) : this;
        public Person? AnotherPerson => this.anotherPerson?.AsValue<Person>() ?? Person.FromOptionalProperty(this.JsonElement, AnotherPersonPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? FirstName => this.firstName ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, FirstNamePropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? LastName => this.lastName ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, LastNamePropertyNameBytes.Span).AsOptional;
        public Person.ContactValue? Contact => this.contact ?? Person.ContactValue.FromOptionalProperty(this.JsonElement, ContactPropertyNameBytes.Span).AsOptional;
        public Person.AgeValue? Age => this.age ?? Person.AgeValue.FromOptionalProperty(this.JsonElement, AgePropertyNameBytes.Span).AsOptional;
        public int PropertiesCount => KnownProperties.Length;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
        }
        public static Person FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Person(property)
                    : Null)
                : Null;
        public static Person FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Person(property)
                    : Null)
                : Null;
        public static Person FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Person(property)
                    : Null)
            : Null;
        public Person WithAnotherPerson(Person? value)
        {
            return new Person(Menes.JsonReference.FromValue(value), this.FirstName, this.LastName, this.Contact, this.Age);
        }
        public Person WithFirstName(Menes.JsonString? value)
        {
            return new Person(this.GetAnotherPerson(), value, this.LastName, this.Contact, this.Age);
        }
        public Person WithLastName(Menes.JsonString? value)
        {
            return new Person(this.GetAnotherPerson(), this.FirstName, value, this.Contact, this.Age);
        }
        public Person WithContact(Person.ContactValue? value)
        {
            return new Person(this.GetAnotherPerson(), this.FirstName, this.LastName, value, this.Age);
        }
        public Person WithAge(Person.AgeValue? value)
        {
            return new Person(this.GetAnotherPerson(), this.FirstName, this.LastName, this.Contact, value);
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
                if (this.contact is Person.ContactValue contact)
                {
                    writer.WritePropertyName(EncodedContactPropertyName);
                    contact.WriteTo(writer);
                }
                if (this.age is Person.AgeValue age)
                {
                    writer.WritePropertyName(EncodedAgePropertyName);
                    age.WriteTo(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(Person other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }
            if (this.HasJsonElement && other.HasJsonElement)
            {
                return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
            }
            return this.AnotherPerson.Equals(other.AnotherPerson) && this.FirstName.Equals(other.FirstName) && this.LastName.Equals(other.LastName) && this.Contact.Equals(other.Contact) && this.Age.Equals(other.Age);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.ValidationContext context = validationContext;
            if (this.AnotherPerson is Person anotherPerson)
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
            if (this.Contact is Person.ContactValue contact)
            {
                context = Menes.Validation.ValidateProperty(context, contact, ContactPropertyNamePath);
            }
            if (this.Age is Person.AgeValue age)
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
        public readonly struct ContactValue : Menes.IJsonValue, System.IEquatable<ContactValue>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, ContactValue> FromJsonElement = e => new ContactValue(e);
            public static readonly ContactValue Null = new ContactValue(default(System.Text.Json.JsonElement));
            private static readonly Menes.JsonAny? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? EnumValues = BuildEnumValues();
            private readonly Menes.JsonAny? value;
            public ContactValue(Menes.JsonAny value)
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
            public ContactValue(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public ContactValue? AsOptional => this.IsNull ? default(ContactValue?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator ContactValue(Menes.JsonAny value)
            {
                return new ContactValue(value);
            }
            public static implicit operator Menes.JsonAny(ContactValue value)
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
            public static ContactValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new ContactValue(property)
                        : Null)
                    : Null;
            public static ContactValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new ContactValue(property)
                        : Null)
                    : Null;
            public static ContactValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new ContactValue(property)
                        : Null)
                    : Null;
            public bool Equals(ContactValue other)
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
                Menes.JsonString item1 = Menes.JsonAny.From(value).As<Menes.JsonString>();
                anyOfValidationContext1 = item1.Validate(anyOfValidationContext1);
                Menes.JsonString item2 = Menes.JsonAny.From(value).As<Menes.JsonString>();
                anyOfValidationContext2 = item2.Validate(anyOfValidationContext2);
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
            public override string? ToString()
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
            private static Menes.JsonAny? BuildConstValue()
            {
                return null;
            }
            private static System.Collections.Immutable.ImmutableArray<Menes.JsonAny>? BuildEnumValues()
            {
                return null;
            }
        }
        public readonly struct AgeValue : Menes.IJsonValue, System.IEquatable<AgeValue>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, AgeValue> FromJsonElement = e => new AgeValue(e);
            public static readonly AgeValue Null = new AgeValue(default(System.Text.Json.JsonElement));
            private static readonly Menes.JsonInteger? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<Menes.JsonInteger>? EnumValues = BuildEnumValues();
            private static readonly Menes.JsonInteger? MultipleOf = null;
            private static readonly Menes.JsonInteger? Maximum = null;
            private static readonly Menes.JsonInteger? ExclusiveMaximum = null;
            private static readonly Menes.JsonInteger? Minimum = 0;
            private static readonly Menes.JsonInteger? ExclusiveMinimum = null;
            private readonly Menes.JsonInteger? value;
            public AgeValue(Menes.JsonInteger value)
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
            public AgeValue(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public AgeValue? AsOptional => this.IsNull ? default(AgeValue?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator AgeValue(Menes.JsonInteger value)
            {
                return new AgeValue(value);
            }
            public static implicit operator AgeValue(int value)
            {
                return new AgeValue(value);
            }
            public static implicit operator AgeValue(long value)
            {
                return new AgeValue(value);
            }
            public static implicit operator int(AgeValue value)
            {
                return (int)(Menes.JsonInteger)value;
            }
            public static implicit operator long(AgeValue value)
            {
                return (long)(Menes.JsonInteger)value;
            }
            public static implicit operator Menes.JsonInteger(AgeValue value)
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
            public static AgeValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new AgeValue(property)
                        : Null)
                    : Null;
            public static AgeValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new AgeValue(property)
                        : Null)
                    : Null;
            public static AgeValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new AgeValue(property)
                        : Null)
                    : Null;
            public bool Equals(AgeValue other)
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
