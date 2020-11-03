// <copyright file="JsonObject.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// A Json object which allows you to build an object with any properties..
    /// </summary>
    public readonly struct JsonObject : IJsonAdditionalProperties<JsonAny>, IEquatable<JsonObject>, IJsonObject
    {
        /// <summary>
        /// A <see cref="JsonObject"/> representing a null value.
        /// </summary>
        public static readonly JsonObject Null = new JsonObject(default(JsonElement));

        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonObject> FromJsonElement = e => new JsonObject(e);

        private readonly JsonProperties<JsonAny>? additionalProperties;

        /// <summary>
        /// Creates a <see cref="JsonObject"/> wrapper around a .NET properties.
        /// </summary>
        /// <param name="additionalProperties">Additional properties.</param>
        public JsonObject(JsonProperties<JsonAny> additionalProperties)
        {
            this.JsonElement = default;
            this.additionalProperties = additionalProperties;
        }

        /// <summary>
        /// Creates a <see cref="JsonObject"/> wrapper around a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the object to represent.
        /// </param>
        public JsonObject(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.additionalProperties = null;
        }

        /// <summary>
        /// Gets a value indicating whether this represents a null value.
        /// </summary>
        public bool IsNull => this.additionalProperties is null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this value as a nullable value type.
        /// </summary>
        public JsonObject? AsOptional => this.IsNull ? default(JsonObject?) : this;

        /// <summary>
        /// Gets the number of properties on this object.
        /// </summary>
        public int PropertiesCount => this.JsonAdditionalPropertiesCount;

        /// <summary>
        /// Gets the number of properties in the additional properties.
        /// </summary>
        public int JsonAdditionalPropertiesCount
        {
            get
            {
                JsonProperties<JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                int count = 0;

                while (enumerator.MoveNext())
                {
                    count++;
                }

                return count;
            }
        }

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
        public JsonProperties<JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
        {
            get
            {
                if (this.additionalProperties is JsonProperties<JsonAny> ap)
                {
                    return new JsonProperties<JsonAny>.JsonPropertyEnumerator(ap, ImmutableArray<ReadOnlyMemory<byte>>.Empty);
                }

                if (this.JsonElement.ValueKind == JsonValueKind.Object)
                {
                    return new JsonProperties<JsonAny>.JsonPropertyEnumerator(this.JsonElement, ImmutableArray<ReadOnlyMemory<byte>>.Empty);
                }

                return new JsonProperties<JsonAny>.JsonPropertyEnumerator(JsonProperties<JsonAny>.Empty, ImmutableArray<ReadOnlyMemory<byte>>.Empty);
            }
        }

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonObject item) => JsonAny.From(item);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement)
        {
            return jsonElement.ValueKind == JsonValueKind.Object || jsonElement.ValueKind == JsonValueKind.Null;
        }

        /// <summary>
        /// Gets a <see cref="JsonObject"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonObject"/> or null.</returns>
        public static JsonObject FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonObject(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonObject"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonObject"/> or null.</returns>
        public static JsonObject FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonObject(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonObject"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonObject"/> or null.</returns>
        public static JsonObject FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonObject(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a version of this object with new additional properties.
        /// </summary>
        /// <param name="newAdditional">The new value for the additionalProperties.</param>
        /// <returns>A new instance of the <see cref="JsonObject"/> with the second property set.</returns>
        public JsonObject ReplaceAll(params (string, JsonAny)[] newAdditional)
        {
            return new JsonObject(JsonProperties<JsonAny>.FromValues(newAdditional));
        }

        /// <summary>
        /// Writes the object value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }
            else
            {
                writer.WriteStartObject();

                JsonProperties<JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;

                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }

                writer.WriteEndObject();
            }
        }

        /// <inheritdoc/>
        public bool Equals(JsonObject other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.JsonAdditionalPropertiesCount != other.JsonAdditionalPropertiesCount)
            {
                return false;
            }

            foreach (JsonPropertyReference<JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!other.TryGet(property.Name, out JsonAny value))
                {
                    return false;
                }

                if (!value.Equals(this))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.IsNull)
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {JsonValueKind.Object}");
            }

            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {JsonValueKind.Object}");
            }

            return validationContext;
        }

        /// <summary>
        /// Gets an additional property as a <see cref="JsonAny"/>.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value as a <see cref="JsonAny"/>.</param>
        /// <returns><c>True</c> if the property was successfully retrieved.</returns>
        public bool TryGet(string propertyName, [NotNullWhen(true)] out JsonAny value)
        {
            return this.TryGet(propertyName.AsSpan(), out value);
        }

        /// <summary>
        /// Gets an additional property as a <see cref="JsonAny"/>.
        /// </summary>
        /// <param name="utf8PropertyName">The property name.</param>
        /// <param name="value">The property value as a <see cref="JsonAny"/>.</param>
        /// <returns><c>True</c> if the property was successfully retrieved.</returns>
        public bool TryGet(ReadOnlySpan<byte> utf8PropertyName, [NotNullWhen(true)] out JsonAny value)
        {
            foreach (JsonPropertyReference<JsonAny> property in this.JsonAdditionalProperties)
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

        /// <summary>
        /// Gets an additional property as a <see cref="JsonAny"/>.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value as a <see cref="JsonAny"/>.</param>
        /// <returns><c>True</c> if the property was successfully retrieved.</returns>
        public bool TryGet(ReadOnlySpan<char> propertyName, [NotNullWhen(true)] out JsonAny value)
        {
            Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
            int written = Encoding.UTF8.GetBytes(propertyName, bytes);
            return this.TryGet(bytes.Slice(0, written), out value);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonAny.From(this).ToString();
        }

        private JsonProperties<JsonAny> GetAdditionalProperties()
        {
            if (this.additionalProperties is JsonProperties<JsonAny> props)
            {
                return props;
            }

            return new JsonProperties<JsonAny>(this.JsonAdditionalProperties.ToImmutableArray());
        }
    }
}
