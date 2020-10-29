// <copyright file="GeneratedPerson.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501, SA1119

namespace Examples
{
    public readonly struct GeneratedPerson : Menes.IJsonObject, System.IEquatable<GeneratedPerson>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly GeneratedPerson Null = new GeneratedPerson(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, GeneratedPerson> FromJsonElement = e => new GeneratedPerson(e);
        private const string ContentTypePropertyNamePath = ".contentType";
        private const string LinksPropertyNamePath = "._links";
        private const string EmbeddedPropertyNamePath = "._embedded";
        private static readonly System.ReadOnlyMemory<byte> ContentTypePropertyNameBytes = new byte[] { 99, 111, 110, 116, 101, 110, 116, 84, 121, 112, 101 };
        private static readonly System.ReadOnlyMemory<byte> LinksPropertyNameBytes = new byte[] { 95, 108, 105, 110, 107, 115 };
        private static readonly System.ReadOnlyMemory<byte> EmbeddedPropertyNameBytes = new byte[] { 95, 101, 109, 98, 101, 100, 100, 101, 100 };
        private static readonly System.Text.Json.JsonEncodedText EncodedContentTypePropertyName = System.Text.Json.JsonEncodedText.Encode(ContentTypePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedLinksPropertyName = System.Text.Json.JsonEncodedText.Encode(LinksPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedEmbeddedPropertyName = System.Text.Json.JsonEncodedText.Encode(EmbeddedPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(ContentTypePropertyNameBytes, LinksPropertyNameBytes, EmbeddedPropertyNameBytes);
        private readonly Menes.JsonString? contentType;
        private readonly Menes.JsonReference? links;
        private readonly Menes.JsonReference? embedded;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public GeneratedPerson(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.contentType = null;
            this.links = null;
            this.embedded = null;
            this.additionalPropertiesBacking = null;
        }
        public GeneratedPerson(GeneratedPerson.LinksEntity links)
        {
            this.contentType = null;
            if (links is GeneratedPerson.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            this.embedded = null;
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public GeneratedPerson(GeneratedPerson.LinksEntity links, Menes.JsonString? contentType, GeneratedPerson.EmbeddedEntity? embedded, Menes.JsonProperties<Menes.JsonAny> additionalPropertiesBacking)
        {
            this.contentType = contentType;
            if (links is GeneratedPerson.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is GeneratedPerson.EmbeddedEntity item2)
            {
                this.embedded = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.embedded = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public GeneratedPerson(GeneratedPerson.LinksEntity links, Menes.JsonString? contentType, GeneratedPerson.EmbeddedEntity? embedded, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.contentType = contentType;
            if (links is GeneratedPerson.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is GeneratedPerson.EmbeddedEntity item2)
            {
                this.embedded = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.embedded = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public GeneratedPerson(GeneratedPerson.LinksEntity links, Menes.JsonString? contentType, GeneratedPerson.EmbeddedEntity? embedded)
        {
            this.contentType = contentType;
            if (links is GeneratedPerson.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is GeneratedPerson.EmbeddedEntity item2)
            {
                this.embedded = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.embedded = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public GeneratedPerson(GeneratedPerson.LinksEntity links, Menes.JsonString? contentType, GeneratedPerson.EmbeddedEntity? embedded, (string, Menes.JsonAny) additionalProperty1)
        {
            this.contentType = contentType;
            if (links is GeneratedPerson.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is GeneratedPerson.EmbeddedEntity item2)
            {
                this.embedded = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.embedded = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public GeneratedPerson(GeneratedPerson.LinksEntity links, Menes.JsonString? contentType, GeneratedPerson.EmbeddedEntity? embedded, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.contentType = contentType;
            if (links is GeneratedPerson.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is GeneratedPerson.EmbeddedEntity item2)
            {
                this.embedded = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.embedded = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public GeneratedPerson(GeneratedPerson.LinksEntity links, Menes.JsonString? contentType, GeneratedPerson.EmbeddedEntity? embedded, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.contentType = contentType;
            if (links is GeneratedPerson.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is GeneratedPerson.EmbeddedEntity item2)
            {
                this.embedded = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.embedded = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public GeneratedPerson(GeneratedPerson.LinksEntity links, Menes.JsonString? contentType, GeneratedPerson.EmbeddedEntity? embedded, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.contentType = contentType;
            if (links is GeneratedPerson.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is GeneratedPerson.EmbeddedEntity item2)
            {
                this.embedded = Menes.JsonReference.FromValue(item2);
            }
            else
            {
                this.embedded = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private GeneratedPerson(Menes.JsonReference links, Menes.JsonString? contentType, Menes.JsonReference? embedded, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.contentType = contentType;
            if (links is Menes.JsonReference item1)
            {
                this.links = item1;
            }
            else
            {
                this.links = null;
            }
            if (embedded is Menes.JsonReference item2)
            {
                this.embedded = item2;
            }
            else
            {
                this.embedded = null;
            }
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.contentType is null || this.contentType.Value.IsNull) && (this.links is null || this.links.Value.IsNull) && (this.embedded is null || this.embedded.Value.IsNull);
        public GeneratedPerson? AsOptional => this.IsNull ? default(GeneratedPerson?) : this;
        public Menes.JsonString? ContentType => this.contentType ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, ContentTypePropertyNameBytes.Span).AsOptional;
        public GeneratedPerson.LinksEntity Links => this.links?.AsValue<GeneratedPerson.LinksEntity>() ?? GeneratedPerson.LinksEntity.FromOptionalProperty(this.JsonElement, LinksPropertyNameBytes.Span);
        public GeneratedPerson.EmbeddedEntity? Embedded => this.embedded?.AsValue<GeneratedPerson.EmbeddedEntity>() ?? GeneratedPerson.EmbeddedEntity.FromOptionalProperty(this.JsonElement, EmbeddedPropertyNameBytes.Span).AsOptional;
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
        public static GeneratedPerson FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new GeneratedPerson(property)
                    : Null)
                : Null;
        public static GeneratedPerson FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new GeneratedPerson(property)
                    : Null)
                : Null;
        public static GeneratedPerson FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new GeneratedPerson(property)
                    : Null)
            : Null;
        public GeneratedPerson WithContentType(Menes.JsonString? value)
        {
            return new GeneratedPerson(this.GetLinks(), value, this.GetEmbedded(), this.GetJsonProperties());
        }
        public GeneratedPerson WithLinks(GeneratedPerson.LinksEntity value)
        {
            return new GeneratedPerson(Menes.JsonReference.FromValue(value), this.ContentType, this.GetEmbedded(), this.GetJsonProperties());
        }
        public GeneratedPerson WithEmbedded(GeneratedPerson.EmbeddedEntity? value)
        {
            return new GeneratedPerson(this.GetLinks(), this.ContentType, Menes.JsonReference.FromValue(value), this.GetJsonProperties());
        }
        public GeneratedPerson WithAdditionalProperties(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new GeneratedPerson(this.GetLinks(), this.ContentType, this.GetEmbedded(), newAdditional);
        }
        public GeneratedPerson WithAdditionalProperties(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new GeneratedPerson(this.GetLinks(), this.ContentType, this.GetEmbedded(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public GeneratedPerson WithAdditionalProperties((string, Menes.JsonAny) newAdditional1)
        {
            return new GeneratedPerson(this.GetLinks(), this.ContentType, this.GetEmbedded(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public GeneratedPerson WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new GeneratedPerson(this.GetLinks(), this.ContentType, this.GetEmbedded(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public GeneratedPerson WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new GeneratedPerson(this.GetLinks(), this.ContentType, this.GetEmbedded(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public GeneratedPerson WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new GeneratedPerson(this.GetLinks(), this.ContentType, this.GetEmbedded(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                if (this.contentType is Menes.JsonString contentType)
                {
                    writer.WritePropertyName(EncodedContentTypePropertyName);
                    contentType.WriteTo(writer);
                }
                if (this.links is Menes.JsonReference links)
                {
                    writer.WritePropertyName(EncodedLinksPropertyName);
                    links.WriteTo(writer);
                }
                if (this.embedded is Menes.JsonReference embedded)
                {
                    writer.WritePropertyName(EncodedEmbeddedPropertyName);
                    embedded.WriteTo(writer);
                }
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(GeneratedPerson other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }
            if (this.HasJsonElement && other.HasJsonElement)
            {
                return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
            }
            return this.ContentType.Equals(other.ContentType) && this.Links.Equals(other.Links) && this.Embedded.Equals(other.Embedded) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.ValidationContext context = validationContext;
            if (this.ContentType is Menes.JsonString contentType)
            {
                context = Menes.Validation.ValidateProperty(context, contentType, ContentTypePropertyNamePath);
            }
            context = Menes.Validation.ValidateRequiredProperty(context, this.Links, LinksPropertyNamePath);
            if (this.Embedded is GeneratedPerson.EmbeddedEntity embedded)
            {
                context = Menes.Validation.ValidateProperty(context, embedded, EmbeddedPropertyNamePath);
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
        private Menes.JsonReference GetLinks()
        {
            if (this.links is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(LinksPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
            {
                return new Menes.JsonReference(value);
            }
            return default;
        }
        private Menes.JsonReference? GetEmbedded()
        {
            if (this.embedded is Menes.JsonReference reference)
            {
                return reference;
            }
            if (this.HasJsonElement && this.JsonElement.TryGetProperty(EmbeddedPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
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

        public readonly struct LinksEntity : Menes.IJsonObject, System.IEquatable<GeneratedPerson.LinksEntity>, Menes.IJsonAdditionalProperties<Links>
        {
            public static readonly GeneratedPerson.LinksEntity Null = new GeneratedPerson.LinksEntity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, GeneratedPerson.LinksEntity> FromJsonElement = e => new GeneratedPerson.LinksEntity(e);
            private const string SelfPropertyNamePath = ".self";
            private const string PrimaryNamePropertyNamePath = ".primaryName";
            private static readonly System.ReadOnlyMemory<byte> SelfPropertyNameBytes = new byte[] { 115, 101, 108, 102 };
            private static readonly System.ReadOnlyMemory<byte> PrimaryNamePropertyNameBytes = new byte[] { 112, 114, 105, 109, 97, 114, 121, 78, 97, 109, 101 };
            private static readonly System.Text.Json.JsonEncodedText EncodedSelfPropertyName = System.Text.Json.JsonEncodedText.Encode(SelfPropertyNameBytes.Span);
            private static readonly System.Text.Json.JsonEncodedText EncodedPrimaryNamePropertyName = System.Text.Json.JsonEncodedText.Encode(PrimaryNamePropertyNameBytes.Span);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(SelfPropertyNameBytes, PrimaryNamePropertyNameBytes);
            private readonly Menes.JsonReference? self;
            private readonly Menes.JsonReference? primaryName;
            private readonly Menes.JsonProperties<Links>? additionalPropertiesBacking;
            public LinksEntity(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.self = null;
                this.primaryName = null;
                this.additionalPropertiesBacking = null;
            }
            public LinksEntity(Link self, Link primaryName)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                if (primaryName is Link item2)
                {
                    this.primaryName = Menes.JsonReference.FromValue(item2);
                }
                else
                {
                    this.primaryName = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = null;
            }
            public LinksEntity(Link self, Link primaryName, params (string, Links)[] additionalPropertiesBacking)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                if (primaryName is Link item2)
                {
                    this.primaryName = Menes.JsonReference.FromValue(item2);
                }
                else
                {
                    this.primaryName = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalPropertiesBacking);
            }
            public LinksEntity(Link self, Link primaryName, (string, Links) additionalProperty1)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                if (primaryName is Link item2)
                {
                    this.primaryName = Menes.JsonReference.FromValue(item2);
                }
                else
                {
                    this.primaryName = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1);
            }
            public LinksEntity(Link self, Link primaryName, (string, Links) additionalProperty1, (string, Links) additionalProperty2)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                if (primaryName is Link item2)
                {
                    this.primaryName = Menes.JsonReference.FromValue(item2);
                }
                else
                {
                    this.primaryName = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1, additionalProperty2);
            }
            public LinksEntity(Link self, Link primaryName, (string, Links) additionalProperty1, (string, Links) additionalProperty2, (string, Links) additionalProperty3)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                if (primaryName is Link item2)
                {
                    this.primaryName = Menes.JsonReference.FromValue(item2);
                }
                else
                {
                    this.primaryName = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public LinksEntity(Link self, Link primaryName, (string, Links) additionalProperty1, (string, Links) additionalProperty2, (string, Links) additionalProperty3, (string, Links) additionalProperty4)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                if (primaryName is Link item2)
                {
                    this.primaryName = Menes.JsonReference.FromValue(item2);
                }
                else
                {
                    this.primaryName = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private LinksEntity(Menes.JsonReference self, Menes.JsonReference primaryName, Menes.JsonProperties<Links>? additionalPropertiesBacking)
            {
                if (self is Menes.JsonReference item1)
                {
                    this.self = item1;
                }
                else
                {
                    this.self = null;
                }
                if (primaryName is Menes.JsonReference item2)
                {
                    this.primaryName = item2;
                }
                else
                {
                    this.primaryName = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.self is null || this.self.Value.IsNull) && (this.primaryName is null || this.primaryName.Value.IsNull);
            public GeneratedPerson.LinksEntity? AsOptional => this.IsNull ? default(GeneratedPerson.LinksEntity?) : this;
            public Link Self => this.self?.AsValue<Link>() ?? Link.FromOptionalProperty(this.JsonElement, SelfPropertyNameBytes.Span);
            public Link PrimaryName => this.primaryName?.AsValue<Link>() ?? Link.FromOptionalProperty(this.JsonElement, PrimaryNamePropertyNameBytes.Span);
            public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
            public int JsonAdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonProperties<Links>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
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
            public Menes.JsonProperties<Links>.JsonPropertyEnumerator JsonAdditionalProperties
            {
                get
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<Links> ap)
                    {
                        return new Menes.JsonProperties<Links>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<Links>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<Links>.JsonPropertyEnumerator(Menes.JsonProperties<Links>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static GeneratedPerson.LinksEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new GeneratedPerson.LinksEntity(property)
                        : Null)
                    : Null;
            public static GeneratedPerson.LinksEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new GeneratedPerson.LinksEntity(property)
                        : Null)
                    : Null;
            public static GeneratedPerson.LinksEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new GeneratedPerson.LinksEntity(property)
                        : Null)
                : Null;
            public GeneratedPerson.LinksEntity WithSelf(Link value)
            {
                return new GeneratedPerson.LinksEntity(Menes.JsonReference.FromValue(value), this.GetPrimaryName(), this.GetJsonProperties());
            }
            public GeneratedPerson.LinksEntity WithPrimaryName(Link value)
            {
                return new GeneratedPerson.LinksEntity(this.GetSelf(), Menes.JsonReference.FromValue(value), this.GetJsonProperties());
            }
            public GeneratedPerson.LinksEntity WithAdditionalProperties(Menes.JsonProperties<Links> newAdditional)
            {
                return new GeneratedPerson.LinksEntity(this.GetSelf(), this.GetPrimaryName(), newAdditional);
            }
            public GeneratedPerson.LinksEntity WithAdditionalProperties(params (string, Links)[] newAdditional)
            {
                return new GeneratedPerson.LinksEntity(this.GetSelf(), this.GetPrimaryName(), Menes.JsonProperties<Links>.FromValues(newAdditional));
            }
            public GeneratedPerson.LinksEntity WithAdditionalProperties((string, Links) newAdditional1)
            {
                return new GeneratedPerson.LinksEntity(this.GetSelf(), this.GetPrimaryName(), Menes.JsonProperties<Links>.FromValues(newAdditional1));
            }
            public GeneratedPerson.LinksEntity WithAdditionalProperties((string, Links) newAdditional1, (string, Links) newAdditional2)
            {
                return new GeneratedPerson.LinksEntity(this.GetSelf(), this.GetPrimaryName(), Menes.JsonProperties<Links>.FromValues(newAdditional1, newAdditional2));
            }
            public GeneratedPerson.LinksEntity WithAdditionalProperties((string, Links) newAdditional1, (string, Links) newAdditional2, (string, Links) newAdditional3)
            {
                return new GeneratedPerson.LinksEntity(this.GetSelf(), this.GetPrimaryName(), Menes.JsonProperties<Links>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public GeneratedPerson.LinksEntity WithAdditionalProperties((string, Links) newAdditional1, (string, Links) newAdditional2, (string, Links) newAdditional3, (string, Links) newAdditional4)
            {
                return new GeneratedPerson.LinksEntity(this.GetSelf(), this.GetPrimaryName(), Menes.JsonProperties<Links>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                    if (this.self is Menes.JsonReference self)
                    {
                        writer.WritePropertyName(EncodedSelfPropertyName);
                        self.WriteTo(writer);
                    }
                    if (this.primaryName is Menes.JsonReference primaryName)
                    {
                        writer.WritePropertyName(EncodedPrimaryNamePropertyName);
                        primaryName.WriteTo(writer);
                    }
                    Menes.JsonProperties<Links>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(GeneratedPerson.LinksEntity other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return this.Self.Equals(other.Self) && this.PrimaryName.Equals(other.PrimaryName) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.ValidationContext context = validationContext;
                context = Menes.Validation.ValidateRequiredProperty(context, this.Self, SelfPropertyNamePath);
                context = Menes.Validation.ValidateRequiredProperty(context, this.PrimaryName, PrimaryNamePropertyNamePath);
                foreach (Menes.JsonPropertyReference<Links> property in this.JsonAdditionalProperties)
                {
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
                return context;
            }
            public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Links value)
            {
                return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Links value)
            {
                foreach (Menes.JsonPropertyReference<Links> property in this.JsonAdditionalProperties)
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
            public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Links value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGet(bytes.Slice(0, written), out value);
            }
            public override string ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonReference GetSelf()
            {
                if (this.self is Menes.JsonReference reference)
                {
                    return reference;
                }
                if (this.HasJsonElement && this.JsonElement.TryGetProperty(SelfPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
                {
                    return new Menes.JsonReference(value);
                }
                return default;
            }
            private Menes.JsonReference GetPrimaryName()
            {
                if (this.primaryName is Menes.JsonReference reference)
                {
                    return reference;
                }
                if (this.HasJsonElement && this.JsonElement.TryGetProperty(PrimaryNamePropertyNameBytes.Span, out System.Text.Json.JsonElement value))
                {
                    return new Menes.JsonReference(value);
                }
                return default;
            }
            private Menes.JsonProperties<Links> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Links> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<Links>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }

        public readonly struct EmbeddedEntity : Menes.IJsonObject, System.IEquatable<GeneratedPerson.EmbeddedEntity>, Menes.IJsonAdditionalProperties<EmbeddedResources>
        {
            public static readonly GeneratedPerson.EmbeddedEntity Null = new GeneratedPerson.EmbeddedEntity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, GeneratedPerson.EmbeddedEntity> FromJsonElement = e => new GeneratedPerson.EmbeddedEntity(e);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;
            private readonly Menes.JsonProperties<EmbeddedResources>? additionalPropertiesBacking;
            public EmbeddedEntity(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.additionalPropertiesBacking = null;
            }
            public EmbeddedEntity(params (string, EmbeddedResources)[] additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<EmbeddedResources>.FromValues(additionalPropertiesBacking);
            }
            public EmbeddedEntity((string, EmbeddedResources) additionalProperty1)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<EmbeddedResources>.FromValues(additionalProperty1);
            }
            public EmbeddedEntity((string, EmbeddedResources) additionalProperty1, (string, EmbeddedResources) additionalProperty2)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<EmbeddedResources>.FromValues(additionalProperty1, additionalProperty2);
            }
            public EmbeddedEntity((string, EmbeddedResources) additionalProperty1, (string, EmbeddedResources) additionalProperty2, (string, EmbeddedResources) additionalProperty3)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<EmbeddedResources>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public EmbeddedEntity((string, EmbeddedResources) additionalProperty1, (string, EmbeddedResources) additionalProperty2, (string, EmbeddedResources) additionalProperty3, (string, EmbeddedResources) additionalProperty4)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<EmbeddedResources>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>? additionalPropertiesBacking)
            {
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public GeneratedPerson.EmbeddedEntity? AsOptional => this.IsNull ? default(GeneratedPerson.EmbeddedEntity?) : this;
            public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
            public int JsonAdditionalPropertiesCount
            {
                get
                {
                    Menes.JsonProperties<EmbeddedResources>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
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
            public Menes.JsonProperties<EmbeddedResources>.JsonPropertyEnumerator JsonAdditionalProperties
            {
                get
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<EmbeddedResources> ap)
                    {
                        return new Menes.JsonProperties<EmbeddedResources>.JsonPropertyEnumerator(ap, KnownProperties);
                    }

                    if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        return new Menes.JsonProperties<EmbeddedResources>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                    }

                    return new Menes.JsonProperties<EmbeddedResources>.JsonPropertyEnumerator(Menes.JsonProperties<EmbeddedResources>.Empty, KnownProperties);
                }
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
            }
            public static GeneratedPerson.EmbeddedEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new GeneratedPerson.EmbeddedEntity(property)
                        : Null)
                    : Null;
            public static GeneratedPerson.EmbeddedEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new GeneratedPerson.EmbeddedEntity(property)
                        : Null)
                    : Null;
            public static GeneratedPerson.EmbeddedEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new GeneratedPerson.EmbeddedEntity(property)
                        : Null)
                : Null;
            public GeneratedPerson.EmbeddedEntity WithAdditionalProperties(Menes.JsonProperties<EmbeddedResources> newAdditional)
            {
                return new GeneratedPerson.EmbeddedEntity(newAdditional);
            }
            public GeneratedPerson.EmbeddedEntity WithAdditionalProperties(params (string, EmbeddedResources)[] newAdditional)
            {
                return new GeneratedPerson.EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>.FromValues(newAdditional));
            }
            public GeneratedPerson.EmbeddedEntity WithAdditionalProperties((string, EmbeddedResources) newAdditional1)
            {
                return new GeneratedPerson.EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>.FromValues(newAdditional1));
            }
            public GeneratedPerson.EmbeddedEntity WithAdditionalProperties((string, EmbeddedResources) newAdditional1, (string, EmbeddedResources) newAdditional2)
            {
                return new GeneratedPerson.EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>.FromValues(newAdditional1, newAdditional2));
            }
            public GeneratedPerson.EmbeddedEntity WithAdditionalProperties((string, EmbeddedResources) newAdditional1, (string, EmbeddedResources) newAdditional2, (string, EmbeddedResources) newAdditional3)
            {
                return new GeneratedPerson.EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public GeneratedPerson.EmbeddedEntity WithAdditionalProperties((string, EmbeddedResources) newAdditional1, (string, EmbeddedResources) newAdditional2, (string, EmbeddedResources) newAdditional3, (string, EmbeddedResources) newAdditional4)
            {
                return new GeneratedPerson.EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                    Menes.JsonProperties<EmbeddedResources>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(GeneratedPerson.EmbeddedEntity other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.ValidationContext context = validationContext;
                foreach (Menes.JsonPropertyReference<EmbeddedResources> property in this.JsonAdditionalProperties)
                {
                    context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                }
                return context;
            }
            public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out EmbeddedResources value)
            {
                return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
            }
            public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out EmbeddedResources value)
            {
                foreach (Menes.JsonPropertyReference<EmbeddedResources> property in this.JsonAdditionalProperties)
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
            public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out EmbeddedResources value)
            {
                System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                return this.TryGet(bytes.Slice(0, written), out value);
            }
            public override string ToString()
            {
                return Menes.JsonAny.From(this).ToString();
            }
            private Menes.JsonProperties<EmbeddedResources> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<EmbeddedResources> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<EmbeddedResources>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }

        public readonly struct AdditionalPropertiesEntity : Menes.IJsonObject, System.IEquatable<GeneratedPerson.AdditionalPropertiesEntity>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
        {
            public static readonly GeneratedPerson.AdditionalPropertiesEntity Null = new GeneratedPerson.AdditionalPropertiesEntity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, GeneratedPerson.AdditionalPropertiesEntity> FromJsonElement = e => new GeneratedPerson.AdditionalPropertiesEntity(e);
            private const string LinksPropertyNamePath = "._links";
            private static readonly System.ReadOnlyMemory<byte> LinksPropertyNameBytes = new byte[] { 95, 108, 105, 110, 107, 115 };
            private static readonly System.Text.Json.JsonEncodedText EncodedLinksPropertyName = System.Text.Json.JsonEncodedText.Encode(LinksPropertyNameBytes.Span);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(LinksPropertyNameBytes);
            private readonly Menes.JsonReference? links;
            private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
            public AdditionalPropertiesEntity(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.links = null;
                this.additionalPropertiesBacking = null;
            }
            public AdditionalPropertiesEntity(GeneratedPerson.AdditionalPropertiesEntity.LinksEntity links)
            {
                if (links is GeneratedPerson.AdditionalPropertiesEntity.LinksEntity item1)
                {
                    this.links = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.links = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = null;
            }
            public AdditionalPropertiesEntity(GeneratedPerson.AdditionalPropertiesEntity.LinksEntity links, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
            {
                if (links is GeneratedPerson.AdditionalPropertiesEntity.LinksEntity item1)
                {
                    this.links = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.links = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
            }
            public AdditionalPropertiesEntity(GeneratedPerson.AdditionalPropertiesEntity.LinksEntity links, (string, Menes.JsonAny) additionalProperty1)
            {
                if (links is GeneratedPerson.AdditionalPropertiesEntity.LinksEntity item1)
                {
                    this.links = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.links = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
            }
            public AdditionalPropertiesEntity(GeneratedPerson.AdditionalPropertiesEntity.LinksEntity links, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
            {
                if (links is GeneratedPerson.AdditionalPropertiesEntity.LinksEntity item1)
                {
                    this.links = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.links = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
            }
            public AdditionalPropertiesEntity(GeneratedPerson.AdditionalPropertiesEntity.LinksEntity links, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
            {
                if (links is GeneratedPerson.AdditionalPropertiesEntity.LinksEntity item1)
                {
                    this.links = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.links = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public AdditionalPropertiesEntity(GeneratedPerson.AdditionalPropertiesEntity.LinksEntity links, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
            {
                if (links is GeneratedPerson.AdditionalPropertiesEntity.LinksEntity item1)
                {
                    this.links = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.links = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private AdditionalPropertiesEntity(Menes.JsonReference links, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
            {
                if (links is Menes.JsonReference item1)
                {
                    this.links = item1;
                }
                else
                {
                    this.links = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.links is null || this.links.Value.IsNull);
            public GeneratedPerson.AdditionalPropertiesEntity? AsOptional => this.IsNull ? default(GeneratedPerson.AdditionalPropertiesEntity?) : this;
            public GeneratedPerson.AdditionalPropertiesEntity.LinksEntity Links => this.links?.AsValue<GeneratedPerson.AdditionalPropertiesEntity.LinksEntity>() ?? GeneratedPerson.AdditionalPropertiesEntity.LinksEntity.FromOptionalProperty(this.JsonElement, LinksPropertyNameBytes.Span);
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
            public static GeneratedPerson.AdditionalPropertiesEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new GeneratedPerson.AdditionalPropertiesEntity(property)
                        : Null)
                    : Null;
            public static GeneratedPerson.AdditionalPropertiesEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new GeneratedPerson.AdditionalPropertiesEntity(property)
                        : Null)
                    : Null;
            public static GeneratedPerson.AdditionalPropertiesEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new GeneratedPerson.AdditionalPropertiesEntity(property)
                        : Null)
                : Null;
            public GeneratedPerson.AdditionalPropertiesEntity WithLinks(GeneratedPerson.AdditionalPropertiesEntity.LinksEntity value)
            {
                return new GeneratedPerson.AdditionalPropertiesEntity(Menes.JsonReference.FromValue(value), this.GetJsonProperties());
            }
            public GeneratedPerson.AdditionalPropertiesEntity WithAdditionalProperties(Menes.JsonProperties<Menes.JsonAny> newAdditional)
            {
                return new GeneratedPerson.AdditionalPropertiesEntity(this.GetLinks(), newAdditional);
            }
            public GeneratedPerson.AdditionalPropertiesEntity WithAdditionalProperties(params (string, Menes.JsonAny)[] newAdditional)
            {
                return new GeneratedPerson.AdditionalPropertiesEntity(this.GetLinks(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
            }
            public GeneratedPerson.AdditionalPropertiesEntity WithAdditionalProperties((string, Menes.JsonAny) newAdditional1)
            {
                return new GeneratedPerson.AdditionalPropertiesEntity(this.GetLinks(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
            }
            public GeneratedPerson.AdditionalPropertiesEntity WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
            {
                return new GeneratedPerson.AdditionalPropertiesEntity(this.GetLinks(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
            }
            public GeneratedPerson.AdditionalPropertiesEntity WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
            {
                return new GeneratedPerson.AdditionalPropertiesEntity(this.GetLinks(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public GeneratedPerson.AdditionalPropertiesEntity WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
            {
                return new GeneratedPerson.AdditionalPropertiesEntity(this.GetLinks(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                    if (this.links is Menes.JsonReference links)
                    {
                        writer.WritePropertyName(EncodedLinksPropertyName);
                        links.WriteTo(writer);
                    }
                    Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(GeneratedPerson.AdditionalPropertiesEntity other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return this.Links.Equals(other.Links) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.ValidationContext context = validationContext;
                context = Menes.Validation.ValidateRequiredProperty(context, this.Links, LinksPropertyNamePath);
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
            private Menes.JsonReference GetLinks()
            {
                if (this.links is Menes.JsonReference reference)
                {
                    return reference;
                }
                if (this.HasJsonElement && this.JsonElement.TryGetProperty(LinksPropertyNameBytes.Span, out System.Text.Json.JsonElement value))
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

            public readonly struct LinksEntity : Menes.IJsonObject, System.IEquatable<GeneratedPerson.AdditionalPropertiesEntity.LinksEntity>, Menes.IJsonAdditionalProperties<Links>
            {
                public static readonly GeneratedPerson.AdditionalPropertiesEntity.LinksEntity Null = new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(default(System.Text.Json.JsonElement));
                public static readonly System.Func<System.Text.Json.JsonElement, GeneratedPerson.AdditionalPropertiesEntity.LinksEntity> FromJsonElement = e => new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(e);
                private const string PrimaryNamePropertyNamePath = ".primaryName";
                private static readonly System.ReadOnlyMemory<byte> PrimaryNamePropertyNameBytes = new byte[] { 112, 114, 105, 109, 97, 114, 121, 78, 97, 109, 101 };
                private static readonly System.Text.Json.JsonEncodedText EncodedPrimaryNamePropertyName = System.Text.Json.JsonEncodedText.Encode(PrimaryNamePropertyNameBytes.Span);
                private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(PrimaryNamePropertyNameBytes);
                private readonly Menes.JsonReference? primaryName;
                private readonly Menes.JsonProperties<Links>? additionalPropertiesBacking;
                public LinksEntity(System.Text.Json.JsonElement jsonElement)
                {
                    this.JsonElement = jsonElement;
                    this.primaryName = null;
                    this.additionalPropertiesBacking = null;
                }
                public LinksEntity(Link primaryName)
                {
                    if (primaryName is Link item1)
                    {
                        this.primaryName = Menes.JsonReference.FromValue(item1);
                    }
                    else
                    {
                        this.primaryName = null;
                    }
                    this.JsonElement = default;
                    this.additionalPropertiesBacking = null;
                }
                public LinksEntity(Link primaryName, params (string, Links)[] additionalPropertiesBacking)
                {
                    if (primaryName is Link item1)
                    {
                        this.primaryName = Menes.JsonReference.FromValue(item1);
                    }
                    else
                    {
                        this.primaryName = null;
                    }
                    this.JsonElement = default;
                    this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalPropertiesBacking);
                }
                public LinksEntity(Link primaryName, (string, Links) additionalProperty1)
                {
                    if (primaryName is Link item1)
                    {
                        this.primaryName = Menes.JsonReference.FromValue(item1);
                    }
                    else
                    {
                        this.primaryName = null;
                    }
                    this.JsonElement = default;
                    this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1);
                }
                public LinksEntity(Link primaryName, (string, Links) additionalProperty1, (string, Links) additionalProperty2)
                {
                    if (primaryName is Link item1)
                    {
                        this.primaryName = Menes.JsonReference.FromValue(item1);
                    }
                    else
                    {
                        this.primaryName = null;
                    }
                    this.JsonElement = default;
                    this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1, additionalProperty2);
                }
                public LinksEntity(Link primaryName, (string, Links) additionalProperty1, (string, Links) additionalProperty2, (string, Links) additionalProperty3)
                {
                    if (primaryName is Link item1)
                    {
                        this.primaryName = Menes.JsonReference.FromValue(item1);
                    }
                    else
                    {
                        this.primaryName = null;
                    }
                    this.JsonElement = default;
                    this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
                }
                public LinksEntity(Link primaryName, (string, Links) additionalProperty1, (string, Links) additionalProperty2, (string, Links) additionalProperty3, (string, Links) additionalProperty4)
                {
                    if (primaryName is Link item1)
                    {
                        this.primaryName = Menes.JsonReference.FromValue(item1);
                    }
                    else
                    {
                        this.primaryName = null;
                    }
                    this.JsonElement = default;
                    this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
                }
                private LinksEntity(Menes.JsonReference primaryName, Menes.JsonProperties<Links>? additionalPropertiesBacking)
                {
                    if (primaryName is Menes.JsonReference item1)
                    {
                        this.primaryName = item1;
                    }
                    else
                    {
                        this.primaryName = null;
                    }
                    this.JsonElement = default;
                    this.additionalPropertiesBacking = additionalPropertiesBacking;
                }
                public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.primaryName is null || this.primaryName.Value.IsNull);
                public GeneratedPerson.AdditionalPropertiesEntity.LinksEntity? AsOptional => this.IsNull ? default(GeneratedPerson.AdditionalPropertiesEntity.LinksEntity?) : this;
                public Link PrimaryName => this.primaryName?.AsValue<Link>() ?? Link.FromOptionalProperty(this.JsonElement, PrimaryNamePropertyNameBytes.Span);
                public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
                public int JsonAdditionalPropertiesCount
                {
                    get
                    {
                        Menes.JsonProperties<Links>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
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
                public Menes.JsonProperties<Links>.JsonPropertyEnumerator JsonAdditionalProperties
                {
                    get
                    {
                        if (this.additionalPropertiesBacking is Menes.JsonProperties<Links> ap)
                        {
                            return new Menes.JsonProperties<Links>.JsonPropertyEnumerator(ap, KnownProperties);
                        }

                        if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                        {
                            return new Menes.JsonProperties<Links>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                        }

                        return new Menes.JsonProperties<Links>.JsonPropertyEnumerator(Menes.JsonProperties<Links>.Empty, KnownProperties);
                    }
                }
                public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
                {
                    return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
                }
                public static GeneratedPerson.AdditionalPropertiesEntity.LinksEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
                   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                            ? new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(property)
                            : Null)
                        : Null;
                public static GeneratedPerson.AdditionalPropertiesEntity.LinksEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
                   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                            ? new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(property)
                            : Null)
                        : Null;
                public static GeneratedPerson.AdditionalPropertiesEntity.LinksEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
                   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                        (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                            ? new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(property)
                            : Null)
                    : Null;
                public GeneratedPerson.AdditionalPropertiesEntity.LinksEntity WithPrimaryName(Link value)
                {
                    return new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(Menes.JsonReference.FromValue(value), this.GetJsonProperties());
                }
                public GeneratedPerson.AdditionalPropertiesEntity.LinksEntity WithAdditionalProperties(Menes.JsonProperties<Links> newAdditional)
                {
                    return new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(this.GetPrimaryName(), newAdditional);
                }
                public GeneratedPerson.AdditionalPropertiesEntity.LinksEntity WithAdditionalProperties(params (string, Links)[] newAdditional)
                {
                    return new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(this.GetPrimaryName(), Menes.JsonProperties<Links>.FromValues(newAdditional));
                }
                public GeneratedPerson.AdditionalPropertiesEntity.LinksEntity WithAdditionalProperties((string, Links) newAdditional1)
                {
                    return new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(this.GetPrimaryName(), Menes.JsonProperties<Links>.FromValues(newAdditional1));
                }
                public GeneratedPerson.AdditionalPropertiesEntity.LinksEntity WithAdditionalProperties((string, Links) newAdditional1, (string, Links) newAdditional2)
                {
                    return new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(this.GetPrimaryName(), Menes.JsonProperties<Links>.FromValues(newAdditional1, newAdditional2));
                }
                public GeneratedPerson.AdditionalPropertiesEntity.LinksEntity WithAdditionalProperties((string, Links) newAdditional1, (string, Links) newAdditional2, (string, Links) newAdditional3)
                {
                    return new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(this.GetPrimaryName(), Menes.JsonProperties<Links>.FromValues(newAdditional1, newAdditional2, newAdditional3));
                }
                public GeneratedPerson.AdditionalPropertiesEntity.LinksEntity WithAdditionalProperties((string, Links) newAdditional1, (string, Links) newAdditional2, (string, Links) newAdditional3, (string, Links) newAdditional4)
                {
                    return new GeneratedPerson.AdditionalPropertiesEntity.LinksEntity(this.GetPrimaryName(), Menes.JsonProperties<Links>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                        if (this.primaryName is Menes.JsonReference primaryName)
                        {
                            writer.WritePropertyName(EncodedPrimaryNamePropertyName);
                            primaryName.WriteTo(writer);
                        }
                        Menes.JsonProperties<Links>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                        while (enumerator.MoveNext())
                        {
                            enumerator.Current.Write(writer);
                        }
                        writer.WriteEndObject();
                    }
                }
                public bool Equals(GeneratedPerson.AdditionalPropertiesEntity.LinksEntity other)
                {
                    if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                    {
                        return false;
                    }
                    if (this.HasJsonElement && other.HasJsonElement)
                    {
                        return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                    }
                    return this.PrimaryName.Equals(other.PrimaryName) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
                }
                public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
                {
                    Menes.ValidationContext context = validationContext;
                    context = Menes.Validation.ValidateRequiredProperty(context, this.PrimaryName, PrimaryNamePropertyNamePath);
                    foreach (Menes.JsonPropertyReference<Links> property in this.JsonAdditionalProperties)
                    {
                        context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
                    }
                    return context;
                }
                public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Links value)
                {
                    return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
                }
                public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Links value)
                {
                    foreach (Menes.JsonPropertyReference<Links> property in this.JsonAdditionalProperties)
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
                public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Links value)
                {
                    System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
                    int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
                    return this.TryGet(bytes.Slice(0, written), out value);
                }
                public override string ToString()
                {
                    return Menes.JsonAny.From(this).ToString();
                }
                private Menes.JsonReference GetPrimaryName()
                {
                    if (this.primaryName is Menes.JsonReference reference)
                    {
                        return reference;
                    }
                    if (this.HasJsonElement && this.JsonElement.TryGetProperty(PrimaryNamePropertyNameBytes.Span, out System.Text.Json.JsonElement value))
                    {
                        return new Menes.JsonReference(value);
                    }
                    return default;
                }
                private Menes.JsonProperties<Links> GetJsonProperties()
                {
                    if (this.additionalPropertiesBacking is Menes.JsonProperties<Links> props)
                    {
                        return props;
                    }
                    return new Menes.JsonProperties<Links>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
                }
            }
        }
    }
}
