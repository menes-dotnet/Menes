// <copyright file="Person.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501

namespace Examples
{
    public readonly struct Person : Menes.IJsonObject, System.IEquatable<Person>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
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
        private readonly Person.ContactEntity? contact;
        private readonly Person.AgeValue? age;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public Person(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.anotherPerson = null;
            this.firstName = null;
            this.lastName = null;
            this.contact = null;
            this.age = null;
            this.additionalPropertiesBacking = null;
        }
        public Person(Menes.JsonString firstName, Menes.JsonString lastName)
        {
            this.anotherPerson = null;
            this.firstName = firstName;
            this.lastName = lastName;
            this.contact = null;
            this.age = null;
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public Person(Menes.JsonString firstName, Menes.JsonString lastName, Person? anotherPerson, Person.ContactEntity? contact, Person.AgeValue? age, Menes.JsonProperties<Menes.JsonAny> additionalPropertiesBacking)
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
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public Person(Menes.JsonString firstName, Menes.JsonString lastName, Person? anotherPerson, Person.ContactEntity? contact, Person.AgeValue? age, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
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
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public Person(Menes.JsonString firstName, Menes.JsonString lastName, Person? anotherPerson, Person.ContactEntity? contact, Person.AgeValue? age)
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
            this.additionalPropertiesBacking = null;
        }
        public Person(Menes.JsonString firstName, Menes.JsonString lastName, Person? anotherPerson, Person.ContactEntity? contact, Person.AgeValue? age, (string, Menes.JsonAny) additionalProperty1)
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
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public Person(Menes.JsonString firstName, Menes.JsonString lastName, Person? anotherPerson, Person.ContactEntity? contact, Person.AgeValue? age, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
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
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public Person(Menes.JsonString firstName, Menes.JsonString lastName, Person? anotherPerson, Person.ContactEntity? contact, Person.AgeValue? age, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
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
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public Person(Menes.JsonString firstName, Menes.JsonString lastName, Person? anotherPerson, Person.ContactEntity? contact, Person.AgeValue? age, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
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
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private Person(Menes.JsonString firstName, Menes.JsonString lastName, Menes.JsonReference? anotherPerson, Person.ContactEntity? contact, Person.AgeValue? age, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
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
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.anotherPerson is null || this.anotherPerson.Value.IsNull) && (this.firstName is null || this.firstName.Value.IsNull) && (this.lastName is null || this.lastName.Value.IsNull) && (this.contact is null || this.contact.Value.IsNull) && (this.age is null || this.age.Value.IsNull);
        public Person? AsOptional => this.IsNull ? default(Person?) : this;
        public Person? AnotherPerson => this.anotherPerson?.AsValue<Person>() ?? Person.FromOptionalProperty(this.JsonElement, AnotherPersonPropertyNameBytes.Span).AsOptional;
        public Menes.JsonString FirstName => this.firstName ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, FirstNamePropertyNameBytes.Span);
        public Menes.JsonString LastName => this.lastName ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, LastNamePropertyNameBytes.Span);
        public Person.ContactEntity? Contact => this.contact ?? Person.ContactEntity.FromOptionalProperty(this.JsonElement, ContactPropertyNameBytes.Span).AsOptional;
        public Person.AgeValue? Age => this.age ?? Person.AgeValue.FromOptionalProperty(this.JsonElement, AgePropertyNameBytes.Span).AsOptional;
        public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
        public int JsonAdditionalPropertiesCount
        {
            get
            {
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                int count = 0;

                while (enumerator.MoveNext())
                {
                    count++;
                }

                return count;
            }
        }
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
        {
            get
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> ap)
                {
                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(ap, KnownProperties);
                }

                if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                }

                return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonAny>.Empty, KnownProperties);
            }
        }
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
            return new Person(this.FirstName, this.LastName, Menes.JsonReference.FromValue(value), this.Contact, this.Age, this.GetJsonProperties());
        }
        public Person WithFirstName(Menes.JsonString value)
        {
            return new Person(value, this.LastName, this.GetAnotherPerson(), this.Contact, this.Age, this.GetJsonProperties());
        }
        public Person WithLastName(Menes.JsonString value)
        {
            return new Person(this.FirstName, value, this.GetAnotherPerson(), this.Contact, this.Age, this.GetJsonProperties());
        }
        public Person WithContact(Person.ContactEntity? value)
        {
            return new Person(this.FirstName, this.LastName, this.GetAnotherPerson(), value, this.Age, this.GetJsonProperties());
        }
        public Person WithAge(Person.AgeValue? value)
        {
            return new Person(this.FirstName, this.LastName, this.GetAnotherPerson(), this.Contact, value, this.GetJsonProperties());
        }
        public Person WithAdditionalProperties(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Person(this.FirstName, this.LastName, this.GetAnotherPerson(), this.Contact, this.Age, newAdditional);
        }
        public Person WithAdditionalProperties(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Person(this.FirstName, this.LastName, this.GetAnotherPerson(), this.Contact, this.Age, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Person WithAdditionalProperties((string, Menes.JsonAny) newAdditional1)
        {
            return new Person(this.FirstName, this.LastName, this.GetAnotherPerson(), this.Contact, this.Age, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Person WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Person(this.FirstName, this.LastName, this.GetAnotherPerson(), this.Contact, this.Age, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Person WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Person(this.FirstName, this.LastName, this.GetAnotherPerson(), this.Contact, this.Age, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Person WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Person(this.FirstName, this.LastName, this.GetAnotherPerson(), this.Contact, this.Age, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                if (this.contact is Person.ContactEntity contact)
                {
                    writer.WritePropertyName(EncodedContactPropertyName);
                    contact.WriteTo(writer);
                }
                if (this.age is Person.AgeValue age)
                {
                    writer.WritePropertyName(EncodedAgePropertyName);
                    age.WriteTo(writer);
                }
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
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
            return this.AnotherPerson.Equals(other.AnotherPerson) && this.FirstName.Equals(other.FirstName) && this.LastName.Equals(other.LastName) && this.Contact.Equals(other.Contact) && this.Age.Equals(other.Age) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.ValidationContext context = validationContext;
            if (this.AnotherPerson is Person anotherPerson)
            {
                context = Menes.Validation.ValidateProperty(context, anotherPerson, AnotherPersonPropertyNamePath);
            }
            context = Menes.Validation.ValidateRequiredProperty(context, this.FirstName, FirstNamePropertyNamePath);
            context = Menes.Validation.ValidateRequiredProperty(context, this.LastName, LastNamePropertyNamePath);
            if (this.Contact is Person.ContactEntity contact)
            {
                context = Menes.Validation.ValidateProperty(context, contact, ContactPropertyNamePath);
            }
            if (this.Age is Person.AgeValue age)
            {
                context = Menes.Validation.ValidateProperty(context, age, AgePropertyNamePath);
            }
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
            }
            return context;
        }
        public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
        {
            return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
        }
        public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
        {
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (property.NameEquals(utf8PropertyName))
                {
                    value = property.AsValue();
                    return true;
                }
            }
            value = default;
            return false;
        }
        public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
        {
            System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
            int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
            return this.TryGet(bytes.Slice(0, written), out value);
        }
        public override string ToString()
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
        private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
        {
            if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
            {
                return props;
            }
            return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
        }
        public readonly struct ContactEntity : Menes.IJsonValue
        {
            public static readonly ContactEntity Null = new ContactEntity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, Person.ContactEntity> FromJsonElement = e => new Person.ContactEntity(e);
            private readonly Menes.JsonEmail? item1;
            private readonly Menes.JsonString? item2;
            public ContactEntity(Menes.JsonEmail clrInstance)
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
            public ContactEntity(Menes.JsonString clrInstance)
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
            public ContactEntity(System.Text.Json.JsonElement jsonElement)
            {
                this.item1 = null;
                this.item2 = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public ContactEntity? AsOptional => this.IsNull ? default(ContactEntity?) : this;
            public bool IsJsonEmail => this.item1 is Menes.JsonEmail || (Menes.JsonEmail.IsConvertibleFrom(this.JsonElement) && Menes.JsonEmail.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool IsJsonString => this.item2 is Menes.JsonString || (Menes.JsonString.IsConvertibleFrom(this.JsonElement) && Menes.JsonString.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static explicit operator Menes.JsonEmail(ContactEntity value) => value.AsJsonEmail();
            public static implicit operator ContactEntity(Menes.JsonEmail value) => new ContactEntity(value);
            public static explicit operator Menes.JsonString(ContactEntity value) => value.AsJsonString();
            public static implicit operator ContactEntity(Menes.JsonString value) => new ContactEntity(value);
            public static ContactEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new ContactEntity(property)
                        : Null)
                    : Null;
            public static ContactEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new ContactEntity(property)
                        : Null)
                    : Null;
            public static ContactEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new ContactEntity(property)
                        : Null)
                    : Null;
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                if (Menes.JsonEmail.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                if (Menes.JsonString.IsConvertibleFrom(jsonElement))
                {
                    return true;
                }
                return false;
            }
            public Menes.JsonEmail AsJsonEmail() => this.item1 ?? new Menes.JsonEmail(this.JsonElement);
            public Menes.JsonString AsJsonString() => this.item2 ?? new Menes.JsonString(this.JsonElement);
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.item1 is Menes.JsonEmail item1)
                {
                    item1.WriteTo(writer);
                }
                else if (this.item2 is Menes.JsonString item2)
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
                if (this.IsJsonEmail)
                {
                    builder.Append("{");
                    builder.Append("JsonEmail");
                    builder.Append(", ");
                    builder.Append(this.AsJsonEmail().ToString());
                    builder.AppendLine("}");
                }
                if (this.IsJsonString)
                {
                    builder.Append("{");
                    builder.Append("JsonString");
                    builder.Append(", ");
                    builder.Append(this.AsJsonString().ToString());
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
                if (this.IsJsonEmail)
                {
                    validationContext1 = this.AsJsonEmail().Validate(validationContext1);
                }
                else
                {
                    validationContext1 = validationContext1.WithError("The value is not convertible to a Menes.JsonEmail.");
                }
                if (this.IsJsonString)
                {
                    validationContext2 = this.AsJsonString().Validate(validationContext2);
                }
                else
                {
                    validationContext2 = validationContext2.WithError("The value is not convertible to a Menes.JsonString.");
                }
                return Menes.Validation.ValidateAnyOf(validationContext, validationContext1, validationContext2);
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
            public override string ToString()
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
