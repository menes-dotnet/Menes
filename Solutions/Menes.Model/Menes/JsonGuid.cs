// <copyright file="JsonGuid.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;
    using System.Text.RegularExpressions;

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
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonGuid item) => JsonAny.From(item);

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
        public override string ToString()
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.GetRawText();
            }

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
            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError("6.1.1. type: the element is not convertible from the given type");
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
