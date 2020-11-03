// <copyright file="JsonByteArray.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Enables the Json resources to work with ByteArrays in situ, whether they
    /// originated from JSON or are a .NET byte array.
    /// </summary>
    public readonly struct JsonByteArray : IJsonValue, IEquatable<JsonByteArray>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonByteArray> FromJsonElement = e => new JsonByteArray(e);

        /// <summary>
        /// A <see cref="JsonByteArray"/> representing a null value.
        /// </summary>
        public static readonly JsonByteArray Null = new JsonByteArray(default);

        private readonly ReadOnlyMemory<byte>? clrByteArray;

        /// <summary>
        /// Creates a <see cref="JsonByteArray"/> wrapper around a .NET byte array.
        /// </summary>
        /// <param name="clrByteArray">The .NET byte array.</param>
        public JsonByteArray(in ReadOnlyMemory<byte> clrByteArray)
        {
            this.clrByteArray = clrByteArray;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonByteArray"/> wrapper around a .NET byte array.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the ByteArray value to represent.
        /// </param>
        public JsonByteArray(JsonElement jsonElement)
        {
            this.clrByteArray = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrByteArray == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this ByteArray as a nullable value type.
        /// </summary>
        public JsonByteArray? AsOptional => this.IsNull ? default(JsonByteArray?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="ReadOnlyMemory{T}"/> of <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator ReadOnlyMemory<byte>(in JsonByteArray value) => value.CreateOrGetClrByteArray();

        /// <summary>
        /// Implicit conversion from an <see cref="ReadOnlyMemory{T}"/> of <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonByteArray(in ReadOnlyMemory<byte> value) => new JsonByteArray(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonByteArray item) => JsonAny.From(item);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement)
        {
            return jsonElement.ValueKind == JsonValueKind.String || jsonElement.ValueKind == JsonValueKind.Null;
        }

        /// <summary>
        /// Gets a <see cref="JsonByteArray"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonByteArray"/> or null.</returns>
        public static JsonByteArray FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonByteArray(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonByteArray"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonByteArray"/> or null.</returns>
        public static JsonByteArray FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonByteArray(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonByteArray"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonByteArray"/> or null.</returns>
        public static JsonByteArray FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonByteArray(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets the ByteArray's value as a .NET byte array.
        /// </summary>
        /// <returns>The ByteArray value as a <see cref="ReadOnlyMemory{T}"/> of byte.</returns>
        public ReadOnlyMemory<byte> CreateOrGetClrByteArray() => this.clrByteArray ?? this.JsonElement.GetBytesFromBase64();

        /// <summary>
        /// Writes the ByteArray value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the ByteArray.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.JsonElement.ValueKind == JsonValueKind.Undefined && this.clrByteArray is ReadOnlyMemory<byte> byteArray)
            {
                writer.WriteBase64StringValue(byteArray.Span);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.IsNull)
            {
                return string.Empty;
            }

            if (this.HasJsonElement)
            {
                return this.JsonElement.GetRawText();
            }
            else
            {
                return Convert.ToBase64String(this.CreateOrGetClrByteArray().Span);
            }
        }

        /// <summary>
        /// Provides the string validations.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="minLength">The minimum length of the string representation.</param>
        /// <param name="maxLength">The maximum length of the string representation.</param>
        /// <param name="pattern">The pattern to which the string must conform.</param>
        /// <param name="enumeration">The values which the string must match.</param>
        /// <param name="constValue">A constant value against which the string must match.</param>
        /// <returns>The validation context updated to reflect the results of the validation.</returns>
        /// <remarks>These are rolled up into a single method to ensure string conversion occurs only once.</remarks>
        public ValidationContext ValidateAsString(in ValidationContext validationContext, int? minLength = null, int? maxLength = null, Regex? pattern = null, in ImmutableArray<string>? enumeration = null, string? constValue = null)
        {
            return Validation.ValidateString(validationContext, this.ToString(), minLength, maxLength, pattern, enumeration, constValue);
        }

        /// <inheritdoc/>
        public bool Equals(JsonByteArray other)
        {
            if (this.clrByteArray is ReadOnlyMemory<byte> byteArrayA && other.clrByteArray is ReadOnlyMemory<byte> otherByteArrayA)
            {
                return byteArrayA.Span.SequenceEqual(otherByteArrayA.Span);
            }

            if (this.clrByteArray is ReadOnlyMemory<byte> byteArrayB && other.HasJsonElement)
            {
                // We should probably stackalloc a buffer here and do it by hand, if we can. May still need to fall back if large.
                return byteArrayB.Span.SequenceEqual(other.CreateOrGetClrByteArray().Span);
            }

            if (other.clrByteArray is ReadOnlyMemory<byte> byteArrayC && this.HasJsonElement)
            {
                // Again with the stackalloc of a buffer
                return byteArrayC.Span.SequenceEqual(this.CreateOrGetClrByteArray().Span);
            }

            if (other.HasJsonElement && this.HasJsonElement)
            {
                // Two stackalloc buffers?
                return other.CreateOrGetClrByteArray().Span.SequenceEqual(this.CreateOrGetClrByteArray().Span);
            }

            return this.IsNull == other.IsNull;
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.IsNull || (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement)))
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {JsonValueKind.String}");
            }

            return validationContext;
        }
    }
}
