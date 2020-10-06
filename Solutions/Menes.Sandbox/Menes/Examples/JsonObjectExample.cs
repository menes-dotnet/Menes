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
    public readonly struct JsonObjectExample : IJsonValue, IJsonAdditionalProperties
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
        private readonly JsonString? first;
        private readonly JsonInt32? second;
        private readonly JsonDuration? third;
        private readonly JsonReference? children;
        private readonly JsonProperties? additionalProperties;

        /// <summary>
        /// Creates a <see cref="JsonObjectExample"/> wrapper around a .NET properties.
        /// </summary>
        /// <param name="first">The first property.</param>
        /// <param name="second">The second property.</param>
        /// <param name="third">The optional third property.</param>
        /// <param name="children">The children of this object.</param>
        /// <param name="additionalProperties">Additional properties.</param>
        public JsonObjectExample(JsonString first, JsonInt32 second, JsonDuration? third = null, in IEnumerable<JsonObjectExample>? children = null, params (string, JsonString)[] additionalProperties)
        {
            this.JsonElement = default;
            this.first = first;
            this.second = second;
            this.third = third;
            if (children is IEnumerable<JsonObjectExample> c)
            {
                this.children = JsonReference.FromValue(new JsonArray<JsonObjectExample>(c));
            }
            else
            {
                this.children = null;
            }

            this.additionalProperties = JsonProperties.FromValues(additionalProperties);
        }

        /// <summary>
        /// Creates a <see cref="JsonObjectExample"/> wrapper around a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the object to represent.
        /// </param>
        public JsonObjectExample(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.first = null;
            this.second = null;
            this.third = null;
            this.children = null;
            this.additionalProperties = null;
        }

        private JsonObjectExample(JsonString first, JsonInt32 second, JsonDuration? third, JsonReference? children, JsonProperties? additionalProperties)
        {
            this.JsonElement = default;
            this.first = first;
            this.second = second;
            this.third = third;
            this.children = children;
            this.additionalProperties = additionalProperties;
        }

        /// <summary>
        /// Gets a value indicating whether this represents a null value.
        /// </summary>
        public bool IsNull => this.first is null && this.second is null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this value as a nullable value type.
        /// </summary>
        public JsonObjectExample? AsOptional => this.IsNull ? default(JsonObjectExample?) : this;

        /// <summary>
        /// Gets the first.
        /// </summary>
        public JsonString First => this.first ?? JsonString.FromOptionalProperty(this.JsonElement, FirstPropertyNameBytes.Span);

        /// <summary>
        /// Gets the second.
        /// </summary>
        public JsonInt32 Second => this.second ?? JsonInt32.FromOptionalProperty(this.JsonElement, SecondPropertyNameBytes.Span);

        /// <summary>
        /// Gets the third.
        /// </summary>
        public JsonDuration? Third => this.third ?? JsonDuration.FromOptionalProperty(this.JsonElement, ThirdPropertyNameBytes.Span).AsOptional;

        /// <summary>
        /// Gets the children.
        /// </summary>
        public JsonArray<JsonObjectExample>? Children => this.children?.AsValue<JsonArray<JsonObjectExample>>() ?? JsonArray<JsonObjectExample>.FromOptionalProperty(this.JsonElement, ChildrenPropertyNameBytes.Span).AsOptional;

        /// <summary>
        /// Gets a value indicating whether this is backed by a <see cref="JsonElement"/>.
        /// </summary>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <summary>
        /// Gets the backing <see cref="JsonElement"/>.
        /// </summary>
        /// <remarks>
        /// This will be <see cref="JsonValueKind.Undefined"/> if it is not backed
        /// by a <see cref="JsonElement"/>. See <see cref="HasJsonElement"/>.
        /// </remarks>
        public JsonElement JsonElement { get; }

        /// <inheritdoc/>
        public JsonPropertyEnumerator AdditionalProperties
        {
            get
            {
                if (this.additionalProperties is JsonProperties ap)
                {
                    return new JsonPropertyEnumerator(ap, KnownProperties);
                }

                if (this.JsonElement.ValueKind == JsonValueKind.Object)
                {
                    return new JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                }

                return new JsonPropertyEnumerator(JsonProperties.Empty, KnownProperties);
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
            return new JsonObjectExample(newFirst, this.Second, this.Third, this.GetChildren(), this.GetAdditionalProperties());
        }

        /// <summary>
        /// Gets a version of this object with new value for the second property.
        /// </summary>
        /// <param name="newSecond">The new value for the second property.</param>
        /// <returns>A new instance of the <see cref="JsonObjectExample"/> with the second property set.</returns>
        public JsonObjectExample WithSecond(JsonInt32 newSecond)
        {
            return new JsonObjectExample(this.First, newSecond, this.Third, this.GetChildren(), this.GetAdditionalProperties());
        }

        /// <summary>
        /// Gets a version of this object with new value for the third property.
        /// </summary>
        /// <param name="newThird">The new value for the third property.</param>
        /// <returns>A new instance of the <see cref="JsonObjectExample"/> with the second property set.</returns>
        public JsonObjectExample WithThird(JsonDuration? newThird)
        {
            return new JsonObjectExample(this.First, this.Second, newThird, this.GetChildren(), this.GetAdditionalProperties());
        }

        /// <summary>
        /// Gets a version of this object with new value for the third property.
        /// </summary>
        /// <param name="newChildren">The new value for the children.</param>
        /// <returns>A new instance of the <see cref="JsonObjectExample"/> with the second property set.</returns>
        public JsonObjectExample WithChildren(JsonArray<JsonObjectExample> newChildren)
        {
            return new JsonObjectExample(this.First, this.Second, this.third, JsonReference.FromValue(newChildren), this.GetAdditionalProperties());
        }

        /// <summary>
        /// Gets a version of this object with new additional properties.
        /// </summary>
        /// <param name="newAdditional">The new value for the additionalProperties.</param>
        /// <returns>A new instance of the <see cref="JsonObjectExample"/> with the second property set.</returns>
        public JsonObjectExample WithAdditionalProperties(params (string, JsonString)[] newAdditional)
        {
            return new JsonObjectExample(this.First, this.Second, this.Third, this.GetChildren(), JsonProperties.FromValues(newAdditional));
        }

        /// <summary>
        /// Writes the object value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.first is JsonString first)
            {
                writer.WriteStartObject();

                writer.WritePropertyName(EncodedFirstPropertyName);
                first.WriteTo(writer);

                if (this.second is JsonInt32 second)
                {
                    writer.WritePropertyName(EncodedSecondPropertyName);
                    second.WriteTo(writer);
                }

                if (this.third is JsonDuration third)
                {
                    writer.WritePropertyName(EncodedThirdPropertyName);
                    third.WriteTo(writer);
                }

                if (this.children is JsonReference children)
                {
                    writer.WritePropertyName(EncodedChildrenPropertyName);
                    children.WriteTo(writer);
                }

                JsonPropertyEnumerator enumerator = this.AdditionalProperties;

                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }

                writer.WriteEndObject();
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.first is JsonString _)
            {
                var abw = new ArrayBufferWriter<byte>();
                using var utfw = new Utf8JsonWriter(abw);
                this.WriteTo(utfw);
                utfw.Flush();
                return new JsonAny(abw.WrittenMemory);
            }

            return new JsonAny(this.JsonElement);
        }

        /// <summary>
        /// Gets an additional property as a <see cref="JsonString"/>.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value as a <see cref="JsonString"/>.</param>
        /// <returns><c>True</c> if the property was successfully retrieved.</returns>
        public bool TryGetAdditionalProperty(string propertyName, [NotNullWhen(true)] out JsonString? value)
        {
            return this.TryGetAdditionalProperty(propertyName.AsSpan(), out value);
        }

        /// <summary>
        /// Gets an additional property as a <see cref="JsonString"/>.
        /// </summary>
        /// <param name="utf8PropertyName">The property name.</param>
        /// <param name="value">The property value as a <see cref="JsonString"/>.</param>
        /// <returns><c>True</c> if the property was successfully retrieved.</returns>
        public bool TryGetAdditionalProperty(ReadOnlySpan<byte> utf8PropertyName, [NotNullWhen(true)] out JsonString? value)
        {
            foreach (JsonPropertyReference property in this.AdditionalProperties)
            {
                if (property.NameEquals(utf8PropertyName))
                {
                    value = property.AsValue<JsonString>();
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Gets an additional property as a <see cref="JsonString"/>.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value as a <see cref="JsonString"/>.</param>
        /// <returns><c>True</c> if the property was successfully retrieved.</returns>
        public bool TryGetAdditionalProperty(ReadOnlySpan<char> propertyName, [NotNullWhen(true)] out JsonString? value)
        {
            Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
            int written = Encoding.UTF8.GetBytes(propertyName, bytes);
            return this.TryGetAdditionalProperty(bytes.Slice(0, written), out value);
        }

        private JsonProperties? GetAdditionalProperties()
        {
            if (this.additionalProperties is JsonProperties props)
            {
                return props;
            }

            return new JsonProperties(this.AdditionalProperties);
        }

        private JsonReference? GetChildren()
        {
            if (this.children is JsonReference)
            {
                return this.children;
            }

            if (this.HasJsonElement && this.JsonElement.TryGetProperty(ChildrenPropertyNameBytes.Span, out JsonElement value))
            {
                return new JsonReference(value);
            }

            return default;
        }
    }
}
