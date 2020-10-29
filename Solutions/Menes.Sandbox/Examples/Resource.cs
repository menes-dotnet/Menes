// <copyright file="Resource.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600, CS1591, SA1028, SA1107, SA1516, SA1513, SA1501, SA1119

namespace Examples
{
    public readonly struct Resource : Menes.IJsonObject, System.IEquatable<Resource>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly Resource Null = new Resource(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Resource> FromJsonElement = e => new Resource(e);
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
        public Resource(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.contentType = null;
            this.links = null;
            this.embedded = null;
            this.additionalPropertiesBacking = null;
        }
        public Resource(Resource.LinksEntity links)
        {
            this.contentType = null;
            if (links is Resource.LinksEntity item1)
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
        public Resource(Resource.LinksEntity links, Menes.JsonString? contentType, Resource.EmbeddedEntity? embedded, Menes.JsonProperties<Menes.JsonAny> additionalPropertiesBacking)
        {
            this.contentType = contentType;
            if (links is Resource.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is Resource.EmbeddedEntity item2)
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
        public Resource(Resource.LinksEntity links, Menes.JsonString? contentType, Resource.EmbeddedEntity? embedded, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.contentType = contentType;
            if (links is Resource.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is Resource.EmbeddedEntity item2)
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
        public Resource(Resource.LinksEntity links, Menes.JsonString? contentType, Resource.EmbeddedEntity? embedded)
        {
            this.contentType = contentType;
            if (links is Resource.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is Resource.EmbeddedEntity item2)
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
        public Resource(Resource.LinksEntity links, Menes.JsonString? contentType, Resource.EmbeddedEntity? embedded, (string, Menes.JsonAny) additionalProperty1)
        {
            this.contentType = contentType;
            if (links is Resource.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is Resource.EmbeddedEntity item2)
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
        public Resource(Resource.LinksEntity links, Menes.JsonString? contentType, Resource.EmbeddedEntity? embedded, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.contentType = contentType;
            if (links is Resource.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is Resource.EmbeddedEntity item2)
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
        public Resource(Resource.LinksEntity links, Menes.JsonString? contentType, Resource.EmbeddedEntity? embedded, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.contentType = contentType;
            if (links is Resource.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is Resource.EmbeddedEntity item2)
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
        public Resource(Resource.LinksEntity links, Menes.JsonString? contentType, Resource.EmbeddedEntity? embedded, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.contentType = contentType;
            if (links is Resource.LinksEntity item1)
            {
                this.links = Menes.JsonReference.FromValue(item1);
            }
            else
            {
                this.links = null;
            }
            if (embedded is Resource.EmbeddedEntity item2)
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
        private Resource(Menes.JsonReference links, Menes.JsonString? contentType, Menes.JsonReference? embedded, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
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
        public Resource? AsOptional => this.IsNull ? default(Resource?) : this;
        public Menes.JsonString? ContentType => this.contentType ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, ContentTypePropertyNameBytes.Span).AsOptional;
        public Resource.LinksEntity Links => this.links?.AsValue<Resource.LinksEntity>() ?? Resource.LinksEntity.FromOptionalProperty(this.JsonElement, LinksPropertyNameBytes.Span);
        public Resource.EmbeddedEntity? Embedded => this.embedded?.AsValue<Resource.EmbeddedEntity>() ?? Resource.EmbeddedEntity.FromOptionalProperty(this.JsonElement, EmbeddedPropertyNameBytes.Span).AsOptional;
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
        public static Resource FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Resource(property)
                    : Null)
                : Null;
        public static Resource FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Resource(property)
                    : Null)
                : Null;
        public static Resource FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Resource(property)
                    : Null)
            : Null;
        public Resource WithContentType(Menes.JsonString? value)
        {
            return new Resource(this.GetLinks(), value, this.GetEmbedded(), this.GetJsonProperties());
        }
        public Resource WithLinks(Resource.LinksEntity value)
        {
            return new Resource(Menes.JsonReference.FromValue(value), this.ContentType, this.GetEmbedded(), this.GetJsonProperties());
        }
        public Resource WithEmbedded(Resource.EmbeddedEntity? value)
        {
            return new Resource(this.GetLinks(), this.ContentType, Menes.JsonReference.FromValue(value), this.GetJsonProperties());
        }
        public Resource WithAdditionalProperties(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Resource(this.GetLinks(), this.ContentType, this.GetEmbedded(), newAdditional);
        }
        public Resource WithAdditionalProperties(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Resource(this.GetLinks(), this.ContentType, this.GetEmbedded(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Resource WithAdditionalProperties((string, Menes.JsonAny) newAdditional1)
        {
            return new Resource(this.GetLinks(), this.ContentType, this.GetEmbedded(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Resource WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Resource(this.GetLinks(), this.ContentType, this.GetEmbedded(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Resource WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Resource(this.GetLinks(), this.ContentType, this.GetEmbedded(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Resource WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Resource(this.GetLinks(), this.ContentType, this.GetEmbedded(), Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
        public bool Equals(Resource other)
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
            if (this.Embedded is Resource.EmbeddedEntity embedded)
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

        public readonly struct LinksEntity : Menes.IJsonObject, System.IEquatable<Resource.LinksEntity>, Menes.IJsonAdditionalProperties<Links>
        {
            public static readonly Resource.LinksEntity Null = new Resource.LinksEntity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, Resource.LinksEntity> FromJsonElement = e => new Resource.LinksEntity(e);
            private const string SelfPropertyNamePath = ".self";
            private static readonly System.ReadOnlyMemory<byte> SelfPropertyNameBytes = new byte[] { 115, 101, 108, 102 };
            private static readonly System.Text.Json.JsonEncodedText EncodedSelfPropertyName = System.Text.Json.JsonEncodedText.Encode(SelfPropertyNameBytes.Span);
            private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(SelfPropertyNameBytes);
            private readonly Menes.JsonReference? self;
            private readonly Menes.JsonProperties<Links>? additionalPropertiesBacking;
            public LinksEntity(System.Text.Json.JsonElement jsonElement)
            {
                this.JsonElement = jsonElement;
                this.self = null;
                this.additionalPropertiesBacking = null;
            }
            public LinksEntity(Link self)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = null;
            }
            public LinksEntity(Link self, params (string, Links)[] additionalPropertiesBacking)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalPropertiesBacking);
            }
            public LinksEntity(Link self, (string, Links) additionalProperty1)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1);
            }
            public LinksEntity(Link self, (string, Links) additionalProperty1, (string, Links) additionalProperty2)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1, additionalProperty2);
            }
            public LinksEntity(Link self, (string, Links) additionalProperty1, (string, Links) additionalProperty2, (string, Links) additionalProperty3)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
            }
            public LinksEntity(Link self, (string, Links) additionalProperty1, (string, Links) additionalProperty2, (string, Links) additionalProperty3, (string, Links) additionalProperty4)
            {
                if (self is Link item1)
                {
                    this.self = Menes.JsonReference.FromValue(item1);
                }
                else
                {
                    this.self = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = Menes.JsonProperties<Links>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
            }
            private LinksEntity(Menes.JsonReference self, Menes.JsonProperties<Links>? additionalPropertiesBacking)
            {
                if (self is Menes.JsonReference item1)
                {
                    this.self = item1;
                }
                else
                {
                    this.self = null;
                }
                this.JsonElement = default;
                this.additionalPropertiesBacking = additionalPropertiesBacking;
            }
            public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.self is null || this.self.Value.IsNull);
            public Resource.LinksEntity? AsOptional => this.IsNull ? default(Resource.LinksEntity?) : this;
            public Link Self => this.self?.AsValue<Link>() ?? Link.FromOptionalProperty(this.JsonElement, SelfPropertyNameBytes.Span);
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
            public static Resource.LinksEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new Resource.LinksEntity(property)
                        : Null)
                    : Null;
            public static Resource.LinksEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new Resource.LinksEntity(property)
                        : Null)
                    : Null;
            public static Resource.LinksEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new Resource.LinksEntity(property)
                        : Null)
                : Null;
            public Resource.LinksEntity WithSelf(Link value)
            {
                return new Resource.LinksEntity(Menes.JsonReference.FromValue(value), this.GetJsonProperties());
            }
            public Resource.LinksEntity WithAdditionalProperties(Menes.JsonProperties<Links> newAdditional)
            {
                return new Resource.LinksEntity(this.GetSelf(), newAdditional);
            }
            public Resource.LinksEntity WithAdditionalProperties(params (string, Links)[] newAdditional)
            {
                return new Resource.LinksEntity(this.GetSelf(), Menes.JsonProperties<Links>.FromValues(newAdditional));
            }
            public Resource.LinksEntity WithAdditionalProperties((string, Links) newAdditional1)
            {
                return new Resource.LinksEntity(this.GetSelf(), Menes.JsonProperties<Links>.FromValues(newAdditional1));
            }
            public Resource.LinksEntity WithAdditionalProperties((string, Links) newAdditional1, (string, Links) newAdditional2)
            {
                return new Resource.LinksEntity(this.GetSelf(), Menes.JsonProperties<Links>.FromValues(newAdditional1, newAdditional2));
            }
            public Resource.LinksEntity WithAdditionalProperties((string, Links) newAdditional1, (string, Links) newAdditional2, (string, Links) newAdditional3)
            {
                return new Resource.LinksEntity(this.GetSelf(), Menes.JsonProperties<Links>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public Resource.LinksEntity WithAdditionalProperties((string, Links) newAdditional1, (string, Links) newAdditional2, (string, Links) newAdditional3, (string, Links) newAdditional4)
            {
                return new Resource.LinksEntity(this.GetSelf(), Menes.JsonProperties<Links>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                    Menes.JsonProperties<Links>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Write(writer);
                    }
                    writer.WriteEndObject();
                }
            }
            public bool Equals(Resource.LinksEntity other)
            {
                if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
                {
                    return false;
                }
                if (this.HasJsonElement && other.HasJsonElement)
                {
                    return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
                }
                return this.Self.Equals(other.Self) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.ValidationContext context = validationContext;
                context = Menes.Validation.ValidateRequiredProperty(context, this.Self, SelfPropertyNamePath);
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
            private Menes.JsonProperties<Links> GetJsonProperties()
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Links> props)
                {
                    return props;
                }
                return new Menes.JsonProperties<Links>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
            }
        }

        public readonly struct EmbeddedEntity : Menes.IJsonObject, System.IEquatable<Resource.EmbeddedEntity>, Menes.IJsonAdditionalProperties<EmbeddedResources>
        {
            public static readonly Resource.EmbeddedEntity Null = new Resource.EmbeddedEntity(default(System.Text.Json.JsonElement));
            public static readonly System.Func<System.Text.Json.JsonElement, Resource.EmbeddedEntity> FromJsonElement = e => new Resource.EmbeddedEntity(e);
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
            public Resource.EmbeddedEntity? AsOptional => this.IsNull ? default(Resource.EmbeddedEntity?) : this;
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
            public static Resource.EmbeddedEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new Resource.EmbeddedEntity(property)
                        : Null)
                    : Null;
            public static Resource.EmbeddedEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new Resource.EmbeddedEntity(property)
                        : Null)
                    : Null;
            public static Resource.EmbeddedEntity FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new Resource.EmbeddedEntity(property)
                        : Null)
                : Null;
            public Resource.EmbeddedEntity WithAdditionalProperties(Menes.JsonProperties<EmbeddedResources> newAdditional)
            {
                return new Resource.EmbeddedEntity(newAdditional);
            }
            public Resource.EmbeddedEntity WithAdditionalProperties(params (string, EmbeddedResources)[] newAdditional)
            {
                return new Resource.EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>.FromValues(newAdditional));
            }
            public Resource.EmbeddedEntity WithAdditionalProperties((string, EmbeddedResources) newAdditional1)
            {
                return new Resource.EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>.FromValues(newAdditional1));
            }
            public Resource.EmbeddedEntity WithAdditionalProperties((string, EmbeddedResources) newAdditional1, (string, EmbeddedResources) newAdditional2)
            {
                return new Resource.EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>.FromValues(newAdditional1, newAdditional2));
            }
            public Resource.EmbeddedEntity WithAdditionalProperties((string, EmbeddedResources) newAdditional1, (string, EmbeddedResources) newAdditional2, (string, EmbeddedResources) newAdditional3)
            {
                return new Resource.EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>.FromValues(newAdditional1, newAdditional2, newAdditional3));
            }
            public Resource.EmbeddedEntity WithAdditionalProperties((string, EmbeddedResources) newAdditional1, (string, EmbeddedResources) newAdditional2, (string, EmbeddedResources) newAdditional3, (string, EmbeddedResources) newAdditional4)
            {
                return new Resource.EmbeddedEntity(Menes.JsonProperties<EmbeddedResources>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
            public bool Equals(Resource.EmbeddedEntity other)
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
    }
    public readonly struct Links : Menes.IJsonValue
    {
        public static readonly Links Null = new Links(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Links> FromJsonElement = e => new Links(e);
        private readonly Menes.JsonReference? item1;
        private readonly Menes.JsonReference? item2;
        public Links(Link clrInstance)
        {
            if (clrInstance.HasJsonElement)
            {
                this.JsonElement = clrInstance.JsonElement;
                this.item1 = null;
            }
            else
            {
                this.item1 = Menes.JsonReference.FromValue(clrInstance);
                this.JsonElement = default;
            }
            this.item2 = null;
        }
        public Links(LinkCollection clrInstance)
        {
            if (clrInstance.HasJsonElement)
            {
                this.JsonElement = clrInstance.JsonElement;
                this.item2 = null;
            }
            else
            {
                this.item2 = Menes.JsonReference.FromValue(clrInstance);
                this.JsonElement = default;
            }
            this.item1 = null;
        }
        public Links(System.Text.Json.JsonElement jsonElement)
        {
            this.item1 = null;
            this.item2 = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public Links? AsOptional => this.IsNull ? default(Links?) : this;
        public bool IsLink => this.item1 is Menes.JsonReference || (Link.IsConvertibleFrom(this.JsonElement) && Link.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
        public bool IsLinkCollection => this.item2 is Menes.JsonReference || (LinkCollection.IsConvertibleFrom(this.JsonElement) && LinkCollection.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static explicit operator Link(Links value) => value.AsLink();
        public static implicit operator Links(Link value) => new Links(value);
        public static explicit operator LinkCollection(Links value) => value.AsLinkCollection();
        public static implicit operator Links(LinkCollection value) => new Links(value);
        public static implicit operator Links(Menes.JsonArray<Link> value)
        {
            return new Links(value);
        }
        public static Links FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Links(property)
                    : Null)
                : Null;
        public static Links FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Links(property)
                    : Null)
                : Null;
        public static Links FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Links(property)
                    : Null)
                : Null;
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            if (Link.IsConvertibleFrom(jsonElement))
            {
                return true;
            }
            if (LinkCollection.IsConvertibleFrom(jsonElement))
            {
                return true;
            }
            return false;
        }
        public Link AsLink() => this.item1?.AsValue<Link>() ?? new Link(this.JsonElement);
        public LinkCollection AsLinkCollection() => this.item2?.AsValue<LinkCollection>() ?? new LinkCollection(this.JsonElement);
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.item1 is Menes.JsonReference item1)
            {
                item1.WriteTo(writer);
            }
            else if (this.item2 is Menes.JsonReference item2)
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
            if (this.IsLink)
            {
                builder.Append("{");
                builder.Append("Link");
                builder.Append(", ");
                builder.Append(this.AsLink().ToString());
                builder.AppendLine("}");
            }
            if (this.IsLinkCollection)
            {
                builder.Append("{");
                builder.Append("LinkCollection");
                builder.Append(", ");
                builder.Append(this.AsLinkCollection().ToString());
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
            if (this.IsLink)
            {
                validationContext1 = this.AsLink().Validate(validationContext1);
            }
            else
            {
                validationContext1 = validationContext1.WithError("The value is not convertible to a Link.");
            }
            if (this.IsLinkCollection)
            {
                validationContext2 = this.AsLinkCollection().Validate(validationContext2);
            }
            else
            {
                validationContext2 = validationContext2.WithError("The value is not convertible to a LinkCollection.");
            }
            return Menes.Validation.ValidateAnyOf(validationContext, validationContext1, validationContext2);
        }
    }

    public readonly struct Link : Menes.IJsonObject, System.IEquatable<Link>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly Link Null = new Link(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Link> FromJsonElement = e => new Link(e);
        private const string HrefPropertyNamePath = ".href";
        private const string TemplatedPropertyNamePath = ".templated";
        private const string TypePropertyNamePath = ".type";
        private const string NamePropertyNamePath = ".name";
        private const string ProfilePropertyNamePath = ".profile";
        private const string DescriptionPropertyNamePath = ".description";
        private const string HreflangPropertyNamePath = ".hreflang";
        private static readonly System.ReadOnlyMemory<byte> HrefPropertyNameBytes = new byte[] { 104, 114, 101, 102 };
        private static readonly System.ReadOnlyMemory<byte> TemplatedPropertyNameBytes = new byte[] { 116, 101, 109, 112, 108, 97, 116, 101, 100 };
        private static readonly System.ReadOnlyMemory<byte> TypePropertyNameBytes = new byte[] { 116, 121, 112, 101 };
        private static readonly System.ReadOnlyMemory<byte> NamePropertyNameBytes = new byte[] { 110, 97, 109, 101 };
        private static readonly System.ReadOnlyMemory<byte> ProfilePropertyNameBytes = new byte[] { 112, 114, 111, 102, 105, 108, 101 };
        private static readonly System.ReadOnlyMemory<byte> DescriptionPropertyNameBytes = new byte[] { 100, 101, 115, 99, 114, 105, 112, 116, 105, 111, 110 };
        private static readonly System.ReadOnlyMemory<byte> HreflangPropertyNameBytes = new byte[] { 104, 114, 101, 102, 108, 97, 110, 103 };
        private static readonly System.Text.Json.JsonEncodedText EncodedHrefPropertyName = System.Text.Json.JsonEncodedText.Encode(HrefPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedTemplatedPropertyName = System.Text.Json.JsonEncodedText.Encode(TemplatedPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedTypePropertyName = System.Text.Json.JsonEncodedText.Encode(TypePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedNamePropertyName = System.Text.Json.JsonEncodedText.Encode(NamePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedProfilePropertyName = System.Text.Json.JsonEncodedText.Encode(ProfilePropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedDescriptionPropertyName = System.Text.Json.JsonEncodedText.Encode(DescriptionPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedHreflangPropertyName = System.Text.Json.JsonEncodedText.Encode(HreflangPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(HrefPropertyNameBytes, TemplatedPropertyNameBytes, TypePropertyNameBytes, NamePropertyNameBytes, ProfilePropertyNameBytes, DescriptionPropertyNameBytes, HreflangPropertyNameBytes);
        private readonly Menes.JsonUri? href;
        private readonly Menes.JsonBoolean? templated;
        private readonly Link.TypeValue? type;
        private readonly Menes.JsonString? name;
        private readonly Menes.JsonUri? profile;
        private readonly Menes.JsonString? description;
        private readonly Link.HreflangValue? hreflang;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public Link(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.href = null;
            this.templated = null;
            this.type = null;
            this.name = null;
            this.profile = null;
            this.description = null;
            this.hreflang = null;
            this.additionalPropertiesBacking = null;
        }
        public Link(Menes.JsonUri href)
        {
            this.href = href;
            this.templated = null;
            this.type = null;
            this.name = null;
            this.profile = null;
            this.description = null;
            this.hreflang = null;
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public Link(Menes.JsonUri href, Menes.JsonBoolean? templated, Link.TypeValue? type, Menes.JsonString? name, Menes.JsonUri? profile, Menes.JsonString? description, Link.HreflangValue? hreflang, Menes.JsonProperties<Menes.JsonAny> additionalPropertiesBacking)
        {
            this.href = href;
            this.templated = templated;
            this.type = type;
            this.name = name;
            this.profile = profile;
            this.description = description;
            this.hreflang = hreflang;
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public Link(Menes.JsonUri href, Menes.JsonBoolean? templated, Link.TypeValue? type, Menes.JsonString? name, Menes.JsonUri? profile, Menes.JsonString? description, Link.HreflangValue? hreflang, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.href = href;
            this.templated = templated;
            this.type = type;
            this.name = name;
            this.profile = profile;
            this.description = description;
            this.hreflang = hreflang;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public Link(Menes.JsonUri href, Menes.JsonBoolean? templated, Link.TypeValue? type, Menes.JsonString? name, Menes.JsonUri? profile, Menes.JsonString? description, Link.HreflangValue? hreflang)
        {
            this.href = href;
            this.templated = templated;
            this.type = type;
            this.name = name;
            this.profile = profile;
            this.description = description;
            this.hreflang = hreflang;
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public Link(Menes.JsonUri href, Menes.JsonBoolean? templated, Link.TypeValue? type, Menes.JsonString? name, Menes.JsonUri? profile, Menes.JsonString? description, Link.HreflangValue? hreflang, (string, Menes.JsonAny) additionalProperty1)
        {
            this.href = href;
            this.templated = templated;
            this.type = type;
            this.name = name;
            this.profile = profile;
            this.description = description;
            this.hreflang = hreflang;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public Link(Menes.JsonUri href, Menes.JsonBoolean? templated, Link.TypeValue? type, Menes.JsonString? name, Menes.JsonUri? profile, Menes.JsonString? description, Link.HreflangValue? hreflang, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.href = href;
            this.templated = templated;
            this.type = type;
            this.name = name;
            this.profile = profile;
            this.description = description;
            this.hreflang = hreflang;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public Link(Menes.JsonUri href, Menes.JsonBoolean? templated, Link.TypeValue? type, Menes.JsonString? name, Menes.JsonUri? profile, Menes.JsonString? description, Link.HreflangValue? hreflang, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.href = href;
            this.templated = templated;
            this.type = type;
            this.name = name;
            this.profile = profile;
            this.description = description;
            this.hreflang = hreflang;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public Link(Menes.JsonUri href, Menes.JsonBoolean? templated, Link.TypeValue? type, Menes.JsonString? name, Menes.JsonUri? profile, Menes.JsonString? description, Link.HreflangValue? hreflang, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.href = href;
            this.templated = templated;
            this.type = type;
            this.name = name;
            this.profile = profile;
            this.description = description;
            this.hreflang = hreflang;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.href is null || this.href.Value.IsNull) && (this.templated is null || this.templated.Value.IsNull) && (this.type is null || this.type.Value.IsNull) && (this.name is null || this.name.Value.IsNull) && (this.profile is null || this.profile.Value.IsNull) && (this.description is null || this.description.Value.IsNull) && (this.hreflang is null || this.hreflang.Value.IsNull);
        public Link? AsOptional => this.IsNull ? default(Link?) : this;
        public Menes.JsonUri Href => this.href ?? Menes.JsonUri.FromOptionalProperty(this.JsonElement, HrefPropertyNameBytes.Span);
        public Menes.JsonBoolean? Templated => this.templated ?? Menes.JsonBoolean.FromOptionalProperty(this.JsonElement, TemplatedPropertyNameBytes.Span).AsOptional;
        public Link.TypeValue? Type => this.type ?? Link.TypeValue.FromOptionalProperty(this.JsonElement, TypePropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Name => this.name ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, NamePropertyNameBytes.Span).AsOptional;
        public Menes.JsonUri? Profile => this.profile ?? Menes.JsonUri.FromOptionalProperty(this.JsonElement, ProfilePropertyNameBytes.Span).AsOptional;
        public Menes.JsonString? Description => this.description ?? Menes.JsonString.FromOptionalProperty(this.JsonElement, DescriptionPropertyNameBytes.Span).AsOptional;
        public Link.HreflangValue? Hreflang => this.hreflang ?? Link.HreflangValue.FromOptionalProperty(this.JsonElement, HreflangPropertyNameBytes.Span).AsOptional;
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
        public static Link FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Link(property)
                    : Null)
                : Null;
        public static Link FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Link(property)
                    : Null)
                : Null;
        public static Link FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Link(property)
                    : Null)
            : Null;
        public Link WithHref(Menes.JsonUri value)
        {
            return new Link(value, this.Templated, this.Type, this.Name, this.Profile, this.Description, this.Hreflang, this.GetJsonProperties());
        }
        public Link WithTemplated(Menes.JsonBoolean? value)
        {
            return new Link(this.Href, value, this.Type, this.Name, this.Profile, this.Description, this.Hreflang, this.GetJsonProperties());
        }
        public Link WithType(Link.TypeValue? value)
        {
            return new Link(this.Href, this.Templated, value, this.Name, this.Profile, this.Description, this.Hreflang, this.GetJsonProperties());
        }
        public Link WithName(Menes.JsonString? value)
        {
            return new Link(this.Href, this.Templated, this.Type, value, this.Profile, this.Description, this.Hreflang, this.GetJsonProperties());
        }
        public Link WithProfile(Menes.JsonUri? value)
        {
            return new Link(this.Href, this.Templated, this.Type, this.Name, value, this.Description, this.Hreflang, this.GetJsonProperties());
        }
        public Link WithDescription(Menes.JsonString? value)
        {
            return new Link(this.Href, this.Templated, this.Type, this.Name, this.Profile, value, this.Hreflang, this.GetJsonProperties());
        }
        public Link WithHreflang(Link.HreflangValue? value)
        {
            return new Link(this.Href, this.Templated, this.Type, this.Name, this.Profile, this.Description, value, this.GetJsonProperties());
        }
        public Link WithAdditionalProperties(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Link(this.Href, this.Templated, this.Type, this.Name, this.Profile, this.Description, this.Hreflang, newAdditional);
        }
        public Link WithAdditionalProperties(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Link(this.Href, this.Templated, this.Type, this.Name, this.Profile, this.Description, this.Hreflang, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Link WithAdditionalProperties((string, Menes.JsonAny) newAdditional1)
        {
            return new Link(this.Href, this.Templated, this.Type, this.Name, this.Profile, this.Description, this.Hreflang, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Link WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Link(this.Href, this.Templated, this.Type, this.Name, this.Profile, this.Description, this.Hreflang, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Link WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Link(this.Href, this.Templated, this.Type, this.Name, this.Profile, this.Description, this.Hreflang, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Link WithAdditionalProperties((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Link(this.Href, this.Templated, this.Type, this.Name, this.Profile, this.Description, this.Hreflang, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
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
                if (this.href is Menes.JsonUri href)
                {
                    writer.WritePropertyName(EncodedHrefPropertyName);
                    href.WriteTo(writer);
                }
                if (this.templated is Menes.JsonBoolean templated)
                {
                    writer.WritePropertyName(EncodedTemplatedPropertyName);
                    templated.WriteTo(writer);
                }
                if (this.type is Link.TypeValue type)
                {
                    writer.WritePropertyName(EncodedTypePropertyName);
                    type.WriteTo(writer);
                }
                if (this.name is Menes.JsonString name)
                {
                    writer.WritePropertyName(EncodedNamePropertyName);
                    name.WriteTo(writer);
                }
                if (this.profile is Menes.JsonUri profile)
                {
                    writer.WritePropertyName(EncodedProfilePropertyName);
                    profile.WriteTo(writer);
                }
                if (this.description is Menes.JsonString description)
                {
                    writer.WritePropertyName(EncodedDescriptionPropertyName);
                    description.WriteTo(writer);
                }
                if (this.hreflang is Link.HreflangValue hreflang)
                {
                    writer.WritePropertyName(EncodedHreflangPropertyName);
                    hreflang.WriteTo(writer);
                }
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(Link other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }
            if (this.HasJsonElement && other.HasJsonElement)
            {
                return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
            }
            return this.Href.Equals(other.Href) && this.Templated.Equals(other.Templated) && this.Type.Equals(other.Type) && this.Name.Equals(other.Name) && this.Profile.Equals(other.Profile) && this.Description.Equals(other.Description) && this.Hreflang.Equals(other.Hreflang) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.ValidationContext context = validationContext;
            context = Menes.Validation.ValidateRequiredProperty(context, this.Href, HrefPropertyNamePath);
            if (this.Templated is Menes.JsonBoolean templated)
            {
                context = Menes.Validation.ValidateProperty(context, templated, TemplatedPropertyNamePath);
            }
            if (this.Type is Link.TypeValue type)
            {
                context = Menes.Validation.ValidateProperty(context, type, TypePropertyNamePath);
            }
            if (this.Name is Menes.JsonString name)
            {
                context = Menes.Validation.ValidateProperty(context, name, NamePropertyNamePath);
            }
            if (this.Profile is Menes.JsonUri profile)
            {
                context = Menes.Validation.ValidateProperty(context, profile, ProfilePropertyNamePath);
            }
            if (this.Description is Menes.JsonString description)
            {
                context = Menes.Validation.ValidateProperty(context, description, DescriptionPropertyNamePath);
            }
            if (this.Hreflang is Link.HreflangValue hreflang)
            {
                context = Menes.Validation.ValidateProperty(context, hreflang, HreflangPropertyNamePath);
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
        private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
        {
            if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
            {
                return props;
            }
            return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
        }
        public readonly struct TypeValue : Menes.IJsonValue, System.IEquatable<TypeValue>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, TypeValue> FromJsonElement = e => new TypeValue(e);
            public static readonly TypeValue Null = new TypeValue(default(System.Text.Json.JsonElement));
            private static readonly string? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<string>? EnumValues = BuildEnumValues();
            private static readonly int? MaxLength = null;
            private static readonly int? MinLength = null;
            private static readonly System.Text.RegularExpressions.Regex? Pattern = new System.Text.RegularExpressions.Regex("^(application|audio|example|image|message|model|multipart|text|video)\\\\/[a-zA-Z0-9!#\\\\$&\\\\.\\\\+-\\\\^_]{1,127}$", System.Text.RegularExpressions.RegexOptions.Compiled);
            private readonly Menes.JsonString? value;
            public TypeValue(Menes.JsonString value)
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
            public TypeValue(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public TypeValue? AsOptional => this.IsNull ? default(TypeValue?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator TypeValue(Menes.JsonString value)
            {
                return new TypeValue(value);
            }
            public static implicit operator TypeValue(string value)
            {
                return new TypeValue(value);
            }
            public static implicit operator string(TypeValue value)
            {
                return (string)(Menes.JsonString)value;
            }
            public static implicit operator Menes.JsonString(TypeValue value)
            {
                if (value.value is Menes.JsonString clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonString(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonString.IsConvertibleFrom(jsonElement);
            }
            public static TypeValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TypeValue(property)
                        : Null)
                    : Null;
            public static TypeValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new TypeValue(property)
                        : Null)
                    : Null;
            public static TypeValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new TypeValue(property)
                        : Null)
                    : Null;
            public bool Equals(TypeValue other)
            {
                return this.Equals((Menes.JsonString)other);
            }
            public bool Equals(Menes.JsonString other)
            {
                return ((Menes.JsonString)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonString value = this;
                Menes.ValidationContext context = validationContext;
                context = value.Validate(context);
                context = value.ValidateAsString(context, MinLength, MaxLength, Pattern, EnumValues, ConstValue);
                return context;
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else if (this.value is Menes.JsonString clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public override string ToString()
            {
                if (this.value is Menes.JsonString clrValue)
                {
                    return clrValue.ToString();
                }
                else
                {
                    return this.JsonElement.GetRawText();
                }
            }
            private static string? BuildConstValue()
            {
                return null;
            }
            private static System.Collections.Immutable.ImmutableArray<string>? BuildEnumValues()
            {
                return null;
            }
        }
        public readonly struct HreflangValue : Menes.IJsonValue, System.IEquatable<HreflangValue>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, HreflangValue> FromJsonElement = e => new HreflangValue(e);
            public static readonly HreflangValue Null = new HreflangValue(default(System.Text.Json.JsonElement));
            private static readonly string? ConstValue = BuildConstValue();
            private static readonly System.Collections.Immutable.ImmutableArray<string>? EnumValues = BuildEnumValues();
            private static readonly int? MaxLength = null;
            private static readonly int? MinLength = null;
            private static readonly System.Text.RegularExpressions.Regex? Pattern = new System.Text.RegularExpressions.Regex("^([a-zA-Z]{2,3}(-[a-zA-Z]{3}(-[a-zA-Z]{3}){0,2})?(-[a-zA-Z]{4})?(-([a-zA-Z]{2}|[0-9]{3}))?(-([a-zA-Z0-9]{5,8}|[0-9][a-zA-Z0-9]{3}))*([0-9A-WY-Za-wy-z](-[a-zA-Z0-9]{2,8}){1,})*(x-[a-zA-Z0-9]{2,8})?)|(x-[a-zA-Z0-9]{2,8})|(en-GB-oed)|(i-ami)|(i-bnn)|(i-default)|(i-enochian)|(i-hak)|(i-klingon)|(i-lux)|(i-mingo)|(i-navajo)|(i-pwn)|(i-tao)|(i-tay)|(i-tsu)|(sgn-BE-FR)|(sgn-BE-NL)|(sgn-CH-DE)|(art-lojban)|(cel-gaulish)|(no-bok)|(no-nyn)|(zh-guoyu)|(zh-hakka)|(zh-min)|(zh-min-nan)|(zh-xiang)$", System.Text.RegularExpressions.RegexOptions.Compiled);
            private readonly Menes.JsonString? value;
            public HreflangValue(Menes.JsonString value)
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
            public HreflangValue(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public HreflangValue? AsOptional => this.IsNull ? default(HreflangValue?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator HreflangValue(Menes.JsonString value)
            {
                return new HreflangValue(value);
            }
            public static implicit operator HreflangValue(string value)
            {
                return new HreflangValue(value);
            }
            public static implicit operator string(HreflangValue value)
            {
                return (string)(Menes.JsonString)value;
            }
            public static implicit operator Menes.JsonString(HreflangValue value)
            {
                if (value.value is Menes.JsonString clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonString(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonString.IsConvertibleFrom(jsonElement);
            }
            public static HreflangValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new HreflangValue(property)
                        : Null)
                    : Null;
            public static HreflangValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new HreflangValue(property)
                        : Null)
                    : Null;
            public static HreflangValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new HreflangValue(property)
                        : Null)
                    : Null;
            public bool Equals(HreflangValue other)
            {
                return this.Equals((Menes.JsonString)other);
            }
            public bool Equals(Menes.JsonString other)
            {
                return ((Menes.JsonString)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonString value = this;
                Menes.ValidationContext context = validationContext;
                context = value.Validate(context);
                context = value.ValidateAsString(context, MinLength, MaxLength, Pattern, EnumValues, ConstValue);
                return context;
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else if (this.value is Menes.JsonString clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public override string ToString()
            {
                if (this.value is Menes.JsonString clrValue)
                {
                    return clrValue.ToString();
                }
                else
                {
                    return this.JsonElement.GetRawText();
                }
            }
            private static string? BuildConstValue()
            {
                return null;
            }
            private static System.Collections.Immutable.ImmutableArray<string>? BuildEnumValues()
            {
                return null;
            }
        }
    }
    public readonly struct LinkCollection : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Link>, System.Collections.IEnumerable, System.IEquatable<LinkCollection>, System.IEquatable<Menes.JsonArray<Link>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, LinkCollection> FromJsonElement = e => new LinkCollection(e);
        public static readonly LinkCollection Null = new LinkCollection(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<Link>? value;
        public LinkCollection(Menes.JsonArray<Link> jsonArray)
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
        public LinkCollection(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public LinkCollection? AsOptional => this.IsNull ? default(LinkCollection?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator LinkCollection(Menes.JsonArray<Link> value)
        {
            return new LinkCollection(value);
        }
        public static implicit operator Menes.JsonArray<Link>(LinkCollection value)
        {
            if (value.value is Menes.JsonArray<Link> clrValue)
            {
                return clrValue;
            }
            return new Menes.JsonArray<Link>(value.JsonElement);
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return Menes.JsonArray<Link>.IsConvertibleFrom(jsonElement);
        }
        public static LinkCollection FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new LinkCollection(property)
                    : Null)
                : Null;
        public static LinkCollection FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new LinkCollection(property)
                    : Null)
                : Null;
        public static LinkCollection FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new LinkCollection(property)
                    : Null)
                : Null;
        public bool Equals(LinkCollection other)
        {
            return this.Equals((Menes.JsonArray<Link>)other);
        }
        public bool Equals(Menes.JsonArray<Link> other)
        {
            return ((Menes.JsonArray<Link>)this).Equals(other);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.JsonArray<Link> array = this;
            Menes.ValidationContext context = validationContext;
            context = array.Validate(context);
            return array.ValidateItems(context);
        }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }
            if (this.value is Menes.JsonArray<Link> clrValue)
            {
                clrValue.WriteTo(writer);
            }
        }
        public Menes.JsonArray<Link>.JsonArrayEnumerator GetEnumerator()
        {
            return ((Menes.JsonArray<Link>)this).GetEnumerator();
        }
        System.Collections.Generic.IEnumerator<Link> System.Collections.Generic.IEnumerable<Link>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public readonly struct EmbeddedResources : Menes.IJsonValue
    {
        public static readonly EmbeddedResources Null = new EmbeddedResources(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, EmbeddedResources> FromJsonElement = e => new EmbeddedResources(e);
        private readonly Menes.JsonReference? item1;
        private readonly Menes.JsonReference? item2;
        public EmbeddedResources(Resource clrInstance)
        {
            if (clrInstance.HasJsonElement)
            {
                this.JsonElement = clrInstance.JsonElement;
                this.item1 = null;
            }
            else
            {
                this.item1 = Menes.JsonReference.FromValue(clrInstance);
                this.JsonElement = default;
            }
            this.item2 = null;
        }
        public EmbeddedResources(ResourceCollection clrInstance)
        {
            if (clrInstance.HasJsonElement)
            {
                this.JsonElement = clrInstance.JsonElement;
                this.item2 = null;
            }
            else
            {
                this.item2 = Menes.JsonReference.FromValue(clrInstance);
                this.JsonElement = default;
            }
            this.item1 = null;
        }
        public EmbeddedResources(System.Text.Json.JsonElement jsonElement)
        {
            this.item1 = null;
            this.item2 = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.item1 is null && this.item2 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public EmbeddedResources? AsOptional => this.IsNull ? default(EmbeddedResources?) : this;
        public bool IsResource => this.item1 is Menes.JsonReference || (Resource.IsConvertibleFrom(this.JsonElement) && Resource.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
        public bool IsResourceCollection => this.item2 is Menes.JsonReference || (ResourceCollection.IsConvertibleFrom(this.JsonElement) && ResourceCollection.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static explicit operator Resource(EmbeddedResources value) => value.AsResource();
        public static implicit operator EmbeddedResources(Resource value) => new EmbeddedResources(value);
        public static explicit operator ResourceCollection(EmbeddedResources value) => value.AsResourceCollection();
        public static implicit operator EmbeddedResources(ResourceCollection value) => new EmbeddedResources(value);
        public static implicit operator EmbeddedResources(Menes.JsonArray<Resource> value)
        {
            return new EmbeddedResources(value);
        }
        public static EmbeddedResources FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new EmbeddedResources(property)
                    : Null)
                : Null;
        public static EmbeddedResources FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new EmbeddedResources(property)
                    : Null)
                : Null;
        public static EmbeddedResources FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new EmbeddedResources(property)
                    : Null)
                : Null;
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            if (Resource.IsConvertibleFrom(jsonElement))
            {
                return true;
            }
            if (ResourceCollection.IsConvertibleFrom(jsonElement))
            {
                return true;
            }
            return false;
        }
        public Resource AsResource() => this.item1?.AsValue<Resource>() ?? new Resource(this.JsonElement);
        public ResourceCollection AsResourceCollection() => this.item2?.AsValue<ResourceCollection>() ?? new ResourceCollection(this.JsonElement);
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.item1 is Menes.JsonReference item1)
            {
                item1.WriteTo(writer);
            }
            else if (this.item2 is Menes.JsonReference item2)
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
            if (this.IsResource)
            {
                builder.Append("{");
                builder.Append("Resource");
                builder.Append(", ");
                builder.Append(this.AsResource().ToString());
                builder.AppendLine("}");
            }
            if (this.IsResourceCollection)
            {
                builder.Append("{");
                builder.Append("ResourceCollection");
                builder.Append(", ");
                builder.Append(this.AsResourceCollection().ToString());
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
            if (this.IsResource)
            {
                validationContext1 = this.AsResource().Validate(validationContext1);
            }
            else
            {
                validationContext1 = validationContext1.WithError("The value is not convertible to a Resource.");
            }
            if (this.IsResourceCollection)
            {
                validationContext2 = this.AsResourceCollection().Validate(validationContext2);
            }
            else
            {
                validationContext2 = validationContext2.WithError("The value is not convertible to a ResourceCollection.");
            }
            return Menes.Validation.ValidateAnyOf(validationContext, validationContext1, validationContext2);
        }
    }

    public readonly struct ResourceCollection : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Resource>, System.Collections.IEnumerable, System.IEquatable<ResourceCollection>, System.IEquatable<Menes.JsonArray<Resource>>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, ResourceCollection> FromJsonElement = e => new ResourceCollection(e);
        public static readonly ResourceCollection Null = new ResourceCollection(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonArray<Resource>? value;
        public ResourceCollection(Menes.JsonArray<Resource> jsonArray)
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
        public ResourceCollection(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public ResourceCollection? AsOptional => this.IsNull ? default(ResourceCollection?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator ResourceCollection(Menes.JsonArray<Resource> value)
        {
            return new ResourceCollection(value);
        }
        public static implicit operator Menes.JsonArray<Resource>(ResourceCollection value)
        {
            if (value.value is Menes.JsonArray<Resource> clrValue)
            {
                return clrValue;
            }
            return new Menes.JsonArray<Resource>(value.JsonElement);
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return Menes.JsonArray<Resource>.IsConvertibleFrom(jsonElement);
        }
        public static ResourceCollection FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new ResourceCollection(property)
                    : Null)
                : Null;
        public static ResourceCollection FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new ResourceCollection(property)
                    : Null)
                : Null;
        public static ResourceCollection FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new ResourceCollection(property)
                    : Null)
                : Null;
        public bool Equals(ResourceCollection other)
        {
            return this.Equals((Menes.JsonArray<Resource>)other);
        }
        public bool Equals(Menes.JsonArray<Resource> other)
        {
            return ((Menes.JsonArray<Resource>)this).Equals(other);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.JsonArray<Resource> array = this;
            Menes.ValidationContext context = validationContext;
            context = array.Validate(context);
            return array.ValidateItems(context);
        }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }
            if (this.value is Menes.JsonArray<Resource> clrValue)
            {
                clrValue.WriteTo(writer);
            }
        }
        public Menes.JsonArray<Resource>.JsonArrayEnumerator GetEnumerator()
        {
            return ((Menes.JsonArray<Resource>)this).GetEnumerator();
        }
        System.Collections.Generic.IEnumerator<Resource> System.Collections.Generic.IEnumerable<Resource>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}