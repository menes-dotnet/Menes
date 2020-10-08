// <copyright file="JsonGuid.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with Guids in situ, whether they
    /// originated from JSON or are a .NET Guid.
    /// </summary>
    public readonly struct JsonGuid : IJsonValue, IEquatable<JsonGuid>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonGuid> FromJsonElement = e => new JsonGuid(e);

        /// <summary>
        /// A <see cref="JsonGuid"/> representing a null value.
        /// </summary>
        public static readonly JsonGuid Null = new JsonGuid(default(JsonElement));

        private readonly Guid? clrGuid;

        /// <summary>
        /// Creates a <see cref="JsonGuid"/> wrapper around a .NET Guid.
        /// </summary>
        /// <param name="clrGuid">The .NET Guid.</param>
        public JsonGuid(Guid clrGuid)
        {
            this.clrGuid = clrGuid;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonGuid"/> wrapper around a .NET Guid.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Guid value to represent.
        /// </param>
        public JsonGuid(JsonElement jsonElement)
        {
            if (!IsConvertibleFrom(jsonElement))
            {
                throw new JsonException("The element must be a JSON string");
            }

            this.clrGuid = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrGuid == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this Guid as a nullable value type.
        /// </summary>
        public JsonGuid? AsOptional => this.IsNull ? default(JsonGuid?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Guid(JsonGuid value) => value.CreateOrGetClrGuid();

        /// <summary>
        /// Implicit conversion from an <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonGuid(Guid value) => new JsonGuid(value);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <param name="checkKindOnly">If <c>true</c>, check the <see cref="JsonElement.ValueKind"/> only.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement, bool checkKindOnly = true)
        {
            if (jsonElement.ValueKind != JsonValueKind.String && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                return false;
            }

            if (!checkKindOnly && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                // TODO: This is very expensive while our parse allocates a string -
                // it would be better to validate that it is parsable from the byte array
                if (!jsonElement.TryGetGuid(out Guid _))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets a <see cref="JsonGuid"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonGuid"/> or null.</returns>
        public static JsonGuid FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonGuid(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonGuid"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonGuid"/> or null.</returns>
        public static JsonGuid FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonGuid(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonGuid"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonGuid"/> or null.</returns>
        public static JsonGuid FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonGuid(property)
                : Null;

        /// <summary>
        /// Gets the Guid's value as a .NET Guid.
        /// </summary>
        /// <returns>The Guid value as a <see cref="Guid"/>.</returns>
        public Guid CreateOrGetClrGuid() => this.clrGuid ?? this.JsonElement.GetGuid();

        /// <summary>
        /// Writes the Guid value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Guid.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrGuid is Guid guid)
            {
                writer.WriteStringValue(guid);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrGuid is Guid _)
            {
                var abw = new ArrayBufferWriter<byte>();
                using var utfw = new Utf8JsonWriter(abw);
                this.WriteTo(utfw);
                utfw.Flush();
                return new JsonAny(abw.WrittenMemory);
            }

            return new JsonAny(this.JsonElement);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.CreateOrGetClrGuid().ToString();
        }

        /// <inheritdoc/>
        public bool Equals(JsonGuid other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            return this.CreateOrGetClrGuid().Equals(other.CreateOrGetClrGuid());
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            return validationContext;
        }
    }
}
