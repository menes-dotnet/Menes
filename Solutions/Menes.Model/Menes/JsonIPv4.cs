// <copyright file="JsonIPv4.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Enables the Json resources to work with strings in situ, whether they
    /// originated from JSON or are a .NET string.
    /// </summary>
    public readonly struct JsonIPv4 : IJsonValue, IEquatable<JsonIPv4>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonIPv4> FromJsonElement = e => new JsonIPv4(e);

        /// <summary>
        /// A <see cref="JsonIPv4"/> representing a null value.
        /// </summary>
        public static readonly JsonIPv4 Null = new JsonIPv4(default(JsonElement));

        private static readonly Regex ValidateIPv4 = new Regex("(?:(?:^|\\.)(?:2(?:5[0-5]|[0-4]\\d)|1?\\d?\\d)){4}", RegexOptions.Compiled);

        private readonly string? clrString;

        /// <summary>
        /// Creates a <see cref="JsonIPv4"/> wrapper around a .NET string.
        /// </summary>
        /// <param name="clrString">The .NET string.</param>
        public JsonIPv4(string clrString)
        {
            this.clrString = clrString;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonIPv4"/> wrapper around a .NET string.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the string value to represent.
        /// </param>
        public JsonIPv4(JsonElement jsonElement)
        {
            this.clrString = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrString == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this string as a nullable value type.
        /// </summary>
        public JsonIPv4? AsOptional => this.IsNull ? default(JsonIPv4?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to string.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator string(JsonIPv4 value) => value.CreateOrGetClrString();

        /// <summary>
        /// Implicit conversion from string.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonIPv4(string value) => new JsonIPv4(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonIPv4 item) => JsonAny.From(item);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static bool IsConvertibleFrom(JsonElement jsonElement)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            return jsonElement.ValueKind == JsonValueKind.String || jsonElement.ValueKind == JsonValueKind.Null;
        }

        /// <summary>
        /// Gets a <see cref="JsonIPv4"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonIPv4"/> or null.</returns>
        public static JsonIPv4 FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonIPv4(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonIPv4"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonIPv4"/> or null.</returns>
        public static JsonIPv4 FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonIPv4(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonIPv4"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonIPv4"/> or null.</returns>
        public static JsonIPv4 FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonIPv4(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets the string's value as a .NET string. This will allocate a new string if the
        /// underlying representation was not already a .NET string.
        /// </summary>
        /// <returns>The string value as a <see cref="string"/>.</returns>
        public string CreateOrGetClrString() => this.clrString ?? this.JsonElement.GetString();

        /// <summary>
        /// Writes the string value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the string.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrString is string text)
            {
                writer.WriteStringValue(text);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            return this.CreateOrGetClrString();
        }

        /// <inheritdoc/>
        public bool Equals(JsonIPv4 other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.clrString is string value && other.clrString is string otherValue)
            {
                return value.Equals(otherValue);
            }

            if (this.clrString is string && other.HasJsonElement)
            {
                return other.JsonElement.ValueEquals(this.clrString);
            }

            if (other.clrString is string && this.HasJsonElement)
            {
                return this.JsonElement.ValueEquals(other.clrString);
            }

            return JsonAny.From(this).Equals(JsonAny.From(other));
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {JsonValueKind.String}");
            }

            if (!this.IsNull)
            {
                string value = this.CreateOrGetClrString();
                if (!ValidateIPv4.IsMatch(value))
                {
                    return validationContext.WithError($"6.3.3. pattern: The string should match {ValidateIPv4} but was {value}.");
                }
            }

            return validationContext;
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
    }
}
