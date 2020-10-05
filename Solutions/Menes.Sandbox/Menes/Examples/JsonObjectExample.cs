// <copyright file="JsonObjectExample.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Examples
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Text.Json;
    using Menes;

    /// <summary>
    /// A Json object example, with additional properties of a specific type, two required values and an optional value.
    /// </summary>
    public readonly struct JsonObjectExample : IJsonValue, IJsonAdditionalProperties<JsonString>
    {
        /// <summary>
        /// A <see cref="JsonObjectExample"/> representing a null value.
        /// </summary>
        public static readonly JsonObjectExample Null = new JsonObjectExample(default);

        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonObjectExample> FromJsonElement = e => new JsonObjectExample(e);

        private const string FirstPropertyName = "first";
        private const string SecondPropertyName = "second";
        private const string ThirdPropertyName = "third";
        private const string ChildrenPropertyName = "children";
        private static readonly JsonEncodedText EncodedFirstPropertyName = JsonEncodedText.Encode(FirstPropertyName);
        private static readonly JsonEncodedText EncodedSecondPropertyName = JsonEncodedText.Encode(SecondPropertyName);
        private static readonly JsonEncodedText EncodedThirdPropertyName = JsonEncodedText.Encode(ThirdPropertyName);
        private static readonly JsonEncodedText EncodedChildrenPropertyName = JsonEncodedText.Encode(ChildrenPropertyName);
        private static readonly ReadOnlyMemory<byte> FirstPropertyNameBytes = Encoding.UTF8.GetBytes(FirstPropertyName);
        private static readonly ReadOnlyMemory<byte> SecondPropertyNameBytes = Encoding.UTF8.GetBytes(SecondPropertyName);
        private static readonly ReadOnlyMemory<byte> ThirdPropertyNameBytes = Encoding.UTF8.GetBytes(ThirdPropertyName);
        private static readonly ReadOnlyMemory<byte> ChildrenPropertyNameBytes = Encoding.UTF8.GetBytes(ChildrenPropertyName);
        private static readonly ImmutableArray<ReadOnlyMemory<byte>> KnownProperties = ImmutableArray.Create(FirstPropertyNameBytes, SecondPropertyNameBytes, ThirdPropertyNameBytes, ChildrenPropertyNameBytes);

        private readonly JsonElement jsonElement;
        private readonly JsonString? first;
        private readonly JsonInt32? second;
        private readonly JsonDuration? third;
        private readonly ReferenceOf<JsonArray<JsonObjectExample>>? children;
        private readonly ImmutableDictionary<ReadOnlyMemory<byte>, JsonString>? additionalProperties;

        /// <summary>
        /// Creates a <see cref="JsonObjectExample"/> wrapper around a .NET properties.
        /// </summary>
        /// <param name="first">The first property.</param>
        /// <param name="second">The second property.</param>
        /// <param name="third">The optional third property.</param>
        /// <param name="children">The children of this object.</param>
        /// <param name="additionalProperties">Additional extension properties.</param>
        public JsonObjectExample(JsonString first, JsonInt32 second, JsonDuration? third = null, ReferenceOf<JsonArray<JsonObjectExample>>? children = null, ImmutableDictionary<ReadOnlyMemory<byte>, JsonString>? additionalProperties = null)
        {
            this.jsonElement = default;
            this.first = first;
            this.second = second;
            this.third = third;
            this.children = children;
            this.additionalProperties = additionalProperties;
        }

        /// <summary>
        /// Creates a <see cref="JsonObjectExample"/> wrapper around a .NET properties.
        /// </summary>
        /// <param name="first">The first property.</param>
        /// <param name="second">The second property.</param>
        /// <param name="third">The optional third property.</param>
        /// <param name="children">The optional children of this object.</param>
        /// <param name="additionalProperties">Additional extension properties.</param>
        public JsonObjectExample(JsonString first, JsonInt32 second, JsonDuration? third = null, ReferenceOf<JsonArray<JsonObjectExample>>? children = null, ImmutableDictionary<string, JsonString>? additionalProperties = null)
        {
            this.jsonElement = default;
            this.first = first;
            this.second = second;
            this.third = third;
            this.children = children;
            this.additionalProperties = additionalProperties is ImmutableDictionary<string, JsonString> add ? BuildImmutableProperties(add) : null;
        }

        /// <summary>
        /// Creates a <see cref="JsonObjectExample"/> wrapper around a .NET properties.
        /// </summary>
        /// <param name="first">The first property.</param>
        /// <param name="second">The second property.</param>
        /// <param name="third">The optional third property.</param>
        /// <param name="children">The optional children of this object.</param>
        /// <param name="additionalProperties">Additional extension properties.</param>
        public JsonObjectExample(JsonString first, JsonInt32 second, JsonDuration? third = null, ReferenceOf<JsonArray<JsonObjectExample>>? children = null, params JsonProperty<JsonString>[] additionalProperties)
        {
            this.jsonElement = default;
            this.first = first;
            this.second = second;
            this.third = third;
            this.children = children;
            this.additionalProperties = BuildImmutableProperties(additionalProperties);
        }

        /// <summary>
        /// Creates a <see cref="JsonObjectExample"/> wrapper around a .NET properties.
        /// </summary>
        /// <param name="first">The first property.</param>
        /// <param name="second">The second property.</param>
        /// <param name="third">The optional third property.</param>
        /// <param name="children">The optional children of this object.</param>
        /// <param name="additionalProperties">Additional extension properties.</param>
        public JsonObjectExample(JsonString first, JsonInt32 second, JsonDuration? third = null, ReferenceOf<JsonArray<JsonObjectExample>>? children = null, params (string, JsonString)[] additionalProperties)
        {
            this.jsonElement = default;
            this.first = first;
            this.second = second;
            this.third = third;
            this.children = children;
            this.additionalProperties = BuildImmutableProperties(additionalProperties);
        }

        /// <summary>
        /// Creates a <see cref="JsonObjectExample"/> wrapper around a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the object to represent.
        /// </param>
        public JsonObjectExample(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.first = null;
            this.second = null;
            this.third = null;
            this.children = null;
            this.additionalProperties = null;
        }

        /// <summary>
        /// Gets a value indicating whether this represents a null value.
        /// </summary>
        public bool IsNull => this.first is null && this.second is null && (this.jsonElement.ValueKind == JsonValueKind.Undefined || this.jsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this value as a nullable value type.
        /// </summary>
        public JsonObjectExample? AsOptional => this.IsNull ? default(JsonObjectExample?) : this;

        /// <summary>
        /// Gets the first.
        /// </summary>
        public JsonString First => this.first ?? JsonString.FromOptionalProperty(this.jsonElement, FirstPropertyNameBytes.Span);

        /// <summary>
        /// Gets the second.
        /// </summary>
        public JsonInt32 Second => this.second ?? JsonInt32.FromOptionalProperty(this.jsonElement, SecondPropertyNameBytes.Span);

        /// <summary>
        /// Gets the third.
        /// </summary>
        public JsonDuration? Third => this.third ?? JsonDuration.FromOptionalProperty(this.jsonElement, ThirdPropertyNameBytes.Span).AsOptional;

        /// <summary>
        /// Gets the children.
        /// </summary>
        public JsonArray<JsonObjectExample>.JsonArrayEnumerator? Children => this.children?.Value.GetEnumerator() ?? JsonArray<JsonObjectExample>.GetEnumerator(this.jsonElement, ChildrenPropertyNameBytes.Span);

        /// <inheritdoc/>
        public JsonPropertyEnumerator<JsonString> AdditionalProperties
        {
            get
            {
                if (this.additionalProperties is ImmutableDictionary<ReadOnlyMemory<byte>, JsonString> ap)
                {
                    return new JsonPropertyEnumerator<JsonString>(ap, KnownProperties);
                }

                if (this.jsonElement.ValueKind == JsonValueKind.Object)
                {
                    return new JsonPropertyEnumerator<JsonString>(this.jsonElement, KnownProperties);
                }

                return new JsonPropertyEnumerator<JsonString>(ImmutableDictionary<ReadOnlyMemory<byte>, JsonString>.Empty, KnownProperties);
            }
        }

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <param name="checkKindOnly">If <c>true</c>, check the <see cref="JsonElement.ValueKind"/> only.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement, bool checkKindOnly = true)
        {
            if (jsonElement.ValueKind != JsonValueKind.Object && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                return false;
            }

            if (!checkKindOnly && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                JsonElement.ObjectEnumerator enumerator = jsonElement.EnumerateObject();

                bool seenFirst = false;
                bool seenSecond = false;
                bool seenThird = false;
                bool seenChildren = false;

                while (enumerator.MoveNext())
                {
                    // Skip the properties we know about, and short-circuit checking names we've already seen.
                    if (!seenFirst && enumerator.Current.NameEquals(FirstPropertyNameBytes.Span))
                    {
                        seenFirst = true;
                        if (!JsonString.IsConvertibleFrom(enumerator.Current.Value, checkKindOnly) || enumerator.Current.Value.ValueKind == JsonValueKind.Null)
                        {
                            return false;
                        }
                    }
                    else if (!seenSecond && enumerator.Current.NameEquals(SecondPropertyNameBytes.Span))
                    {
                        seenSecond = true;
                        if (!JsonInt32.IsConvertibleFrom(enumerator.Current.Value, checkKindOnly) || enumerator.Current.Value.ValueKind == JsonValueKind.Null)
                        {
                            return false;
                        }
                    }
                    else if (!seenThird && enumerator.Current.NameEquals(ThirdPropertyNameBytes.Span))
                    {
                        seenThird = true;
                        if (!JsonDuration.IsConvertibleFrom(enumerator.Current.Value, checkKindOnly))
                        {
                            return false;
                        }
                    }
                    else if (!seenChildren && enumerator.Current.NameEquals(ChildrenPropertyNameBytes.Span))
                    {
                        seenChildren = true;
                        if (!IsConvertibleFrom(enumerator.Current.Value, checkKindOnly))
                        {
                            return false;
                        }
                    }
                    else if (!JsonString.IsConvertibleFrom(enumerator.Current.Value, checkKindOnly))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gets a <see cref="JsonObjectExample"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonObjectExample"/> or null.</returns>
        public static JsonObjectExample FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonObjectExample(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonObjectExample"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonObjectExample"/> or null.</returns>
        public static JsonObjectExample FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonObjectExample(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonObjectExample"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonObjectExample"/> or null.</returns>
        public static JsonObjectExample FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonObjectExample(property)
                : Null;

        /// <summary>
        /// Gets a version of this object with new value for the first property.
        /// </summary>
        /// <param name="newFirst">The new value for the first property.</param>
        /// <returns>A new instance of the <see cref="JsonObjectExample"/> with the first property set.</returns>
        public JsonObjectExample WithFirst(JsonString newFirst)
        {
            return new JsonObjectExample(newFirst, this.Second, this.Third, this.GetChildren(), this.GetAdditionalPropertiesAsImmutableDictionary());
        }

        /// <summary>
        /// Gets a version of this object with new value for the second property.
        /// </summary>
        /// <param name="newSecond">The new value for the second property.</param>
        /// <returns>A new instance of the <see cref="JsonObjectExample"/> with the second property set.</returns>
        public JsonObjectExample WithSecond(JsonInt32 newSecond)
        {
            return new JsonObjectExample(this.First, newSecond, this.Third, this.GetChildren(), this.GetAdditionalPropertiesAsImmutableDictionary());
        }

        /// <summary>
        /// Gets a version of this object with new value for the third property.
        /// </summary>
        /// <param name="newThird">The new value for the third property.</param>
        /// <returns>A new instance of the <see cref="JsonObjectExample"/> with the second property set.</returns>
        public JsonObjectExample WithThird(JsonDuration? newThird)
        {
            return new JsonObjectExample(this.First, this.Second, newThird, this.GetChildren(), this.GetAdditionalPropertiesAsImmutableDictionary());
        }

        /// <summary>
        /// Gets a version of this object with new value for the third property.
        /// </summary>
        /// <param name="newChildren">The new value for the children.</param>
        /// <returns>A new instance of the <see cref="JsonObjectExample"/> with the second property set.</returns>
        public JsonObjectExample WithChildren(JsonArray<JsonObjectExample> newChildren)
        {
            return new JsonObjectExample(this.First, this.Second, this.third, new ReferenceOf<JsonArray<JsonObjectExample>>(newChildren), this.GetAdditionalPropertiesAsImmutableDictionary());
        }

        /// <summary>
        /// Gets a version of this object with new value for the additional properties.
        /// </summary>
        /// <param name="newAdditional">The new value for the additionalProperties.</param>
        /// <returns>A new instance of the <see cref="JsonObjectExample"/> with the second property set.</returns>
        public JsonObjectExample WithAdditionalProperties(ImmutableDictionary<ReadOnlyMemory<byte>, JsonString>? newAdditional)
        {
            return new JsonObjectExample(this.First, this.Second, this.Third, this.GetChildren(), newAdditional);
        }

        /// <summary>
        /// Gets a version of this object with new value for the additional properties.
        /// </summary>
        /// <param name="newAdditional">The new value for the additionalProperties.</param>
        /// <returns>A new instance of the <see cref="JsonObjectExample"/> with the second property set.</returns>
        public JsonObjectExample WithAdditionalProperties(ImmutableDictionary<string, JsonString>? newAdditional)
        {
            return new JsonObjectExample(this.First, this.Second, this.Third, this.GetChildren(), newAdditional is ImmutableDictionary<string, JsonString> na ? BuildImmutableProperties(na) : null);
        }

        /// <summary>
        /// Writes the object value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the object.</param>
        public void Write(Utf8JsonWriter writer)
        {
            if (this.first is JsonString first)
            {
                writer.WriteStartObject();

                writer.WritePropertyName(EncodedFirstPropertyName);
                first.Write(writer);

                if (this.second is JsonInt32 second)
                {
                    writer.WritePropertyName(EncodedSecondPropertyName);
                    second.Write(writer);
                }

                if (this.third is JsonDuration third)
                {
                    writer.WritePropertyName(EncodedThirdPropertyName);
                    third.Write(writer);
                }

                if (this.children is ReferenceOf<JsonArray<JsonObjectExample>> children)
                {
                    writer.WritePropertyName(EncodedChildrenPropertyName);
                    writer.WriteStartArray();
                    foreach (JsonObjectExample child in children.Value)
                    {
                        child.Write(writer);
                    }
                }

                if (this.additionalProperties is ImmutableDictionary<ReadOnlyMemory<byte>, JsonString> additionalProperties)
                {
                    foreach (KeyValuePair<ReadOnlyMemory<byte>, JsonString> additional in additionalProperties)
                    {
                        writer.WritePropertyName(additional.Key.Span);
                        additional.Value.Write(writer);
                    }
                }

                writer.WriteEndObject();
            }
            else
            {
                this.jsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.first is JsonString _)
            {
                var abw = new ArrayBufferWriter<byte>();
                using var utfw = new Utf8JsonWriter(abw);
                this.Write(utfw);
                utfw.Flush();
                return new JsonAny(abw.WrittenMemory);
            }

            return new JsonAny(this.jsonElement);
        }

        /// <inheritdoc/>
        public bool TryGetAdditionalProperty(string propertyName, [NotNullWhen(true)] out JsonString value)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool TryGetAdditionalProperty(ReadOnlySpan<byte> utf8PropertyName, [NotNullWhen(true)] out JsonString value)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool TryGetAdditionalProperty(ReadOnlySpan<char> propertyName, [NotNullWhen(true)] out JsonString value)
        {
            throw new NotImplementedException();
        }

        private static ImmutableDictionary<ReadOnlyMemory<byte>, JsonString> BuildImmutableProperties((string, JsonString)[] additionalProperties)
        {
            ImmutableDictionary<ReadOnlyMemory<byte>, JsonString>.Builder result = ImmutableDictionary.CreateBuilder<ReadOnlyMemory<byte>, JsonString>();

            foreach ((string name, JsonString value) in additionalProperties)
            {
                result.Add(Encoding.UTF8.GetBytes(name), value);
            }

            return result.ToImmutable();
        }

        private static ImmutableDictionary<ReadOnlyMemory<byte>, JsonString> BuildImmutableProperties(JsonProperty<JsonString>[] additionalProperties)
        {
            ImmutableDictionary<ReadOnlyMemory<byte>, JsonString>.Builder result = ImmutableDictionary.CreateBuilder<ReadOnlyMemory<byte>, JsonString>();

            foreach (JsonProperty<JsonString> property in additionalProperties)
            {
                result.Add(Encoding.UTF8.GetBytes(property.Name), property.Value);
            }

            return result.ToImmutable();
        }

        private static ImmutableDictionary<ReadOnlyMemory<byte>, JsonString> BuildImmutableProperties(ImmutableDictionary<string, JsonString> newAdditional)
        {
            ImmutableDictionary<ReadOnlyMemory<byte>, JsonString>.Builder result = ImmutableDictionary.CreateBuilder<ReadOnlyMemory<byte>, JsonString>();
            ImmutableDictionary<string, JsonString>.Enumerator enumerator = newAdditional.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(Encoding.UTF8.GetBytes(enumerator.Current.Key), enumerator.Current.Value);
            }

            return result.ToImmutable();
        }

        private static ImmutableDictionary<ReadOnlyMemory<byte>, JsonString> BuildImmutableProperties(in JsonElement jsonElement)
        {
            ImmutableDictionary<ReadOnlyMemory<byte>, JsonString>.Builder builder = ImmutableDictionary.CreateBuilder<ReadOnlyMemory<byte>, JsonString>();
            JsonElement.ObjectEnumerator enumerator = jsonElement.EnumerateObject();
            bool[] seenProperties = new bool[KnownProperties.Length];

            while (enumerator.MoveNext())
            {
                bool known = false;
                for (int i = 0; i < KnownProperties.Length; ++i)
                {
                    // Skip the properties we know about
                    if (!seenProperties[i] && enumerator.Current.NameEquals(KnownProperties[i].Span))
                    {
                        seenProperties[i] = true;
                        known = true;
                        break;
                    }
                }

                if (known)
                {
                    continue;
                }

                // TODO: Annoyingly, we have to allocate a string and then get the bytes back here, we can't just
                // read the name back out as bytes. We could probably do better by allocating a buffer, writing to the buffer
                // and slicing it back out again (or again, extending System.Text.Json so that we can get at the underlying storage; but
                // we'd still want to get a copy in this case)
                builder.Add(Encoding.UTF8.GetBytes(enumerator.Current.Name), new JsonString(enumerator.Current.Value));
            }

            return builder.ToImmutable();
        }

        private ReferenceOf<JsonArray<JsonObjectExample>> GetChildren()
        {
            return this.children ?? new ReferenceOf<JsonArray<JsonObjectExample>>(JsonArray<JsonObjectExample>.FromOptionalProperty(this.jsonElement, ChildrenPropertyNameBytes.Span));
        }

        private ImmutableDictionary<ReadOnlyMemory<byte>, JsonString>? GetAdditionalPropertiesAsImmutableDictionary()
        {
            if (this.additionalProperties is ImmutableDictionary<ReadOnlyMemory<byte>, JsonString> id)
            {
                return id;
            }

            return BuildImmutableProperties(this.jsonElement);
        }
    }
}
