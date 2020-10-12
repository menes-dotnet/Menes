// <copyright file="JsonUri.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Enables the Json resources to work with Uris in situ, whether they
    /// originated from JSON or are a .NET Uri.
    /// </summary>
    public readonly struct JsonUri : IJsonValue, IEquatable<JsonUri>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonUri> FromJsonElement = e => new JsonUri(e);

        /// <summary>
        /// A <see cref="JsonUri"/> representing a null value.
        /// </summary>
        public static readonly JsonUri Null = new JsonUri(default(JsonElement));

        private readonly string? clrUri;

        /// <summary>
        /// Creates a <see cref="JsonUri"/> wrapper around a .NET Uri.
        /// </summary>
        /// <param name="clrUri">The .NET Uri.</param>
        public JsonUri(Uri clrUri)
        {
            this.clrUri = clrUri.ToString();
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonUri"/> wrapper around a .NET Uri.
        /// </summary>
        /// <param name="clrUri">The .NET Uri.</param>
        public JsonUri(string clrUri)
        {
            this.clrUri = clrUri;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonUri"/> wrapper around a .NET Uri.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Uri value to represent.
        /// </param>
        public JsonUri(JsonElement jsonElement)
        {
            this.clrUri = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrUri == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this Uri as a nullable value type.
        /// </summary>
        public JsonUri? AsOptional => this.IsNull ? default(JsonUri?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="Uri"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Uri(JsonUri value) => value.CreateOrGetClrUri();

        /// <summary>
        /// Implicit conversion from an <see cref="Uri"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonUri(Uri value) => new JsonUri(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonUri item) => JsonAny.From(item);

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
        /// Gets a <see cref="JsonUri"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonUri"/> or null.</returns>
        public static JsonUri FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonUri(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonUri"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonUri"/> or null.</returns>
        public static JsonUri FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonUri(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonUri"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonUri"/> or null.</returns>
        public static JsonUri FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonUri(property)
                : Null;

        /// <summary>
        /// Gets the Uri's value as a .NET Uri.
        /// </summary>
        /// <returns>The Uri value as a <see cref="Uri"/>.</returns>
        public Uri CreateOrGetClrUri() => new Uri(this.CreateOrGetClrString(), UriKind.RelativeOrAbsolute);

        /// <summary>
        /// Writes the Uri value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Uri.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrUri is string uri)
            {
                writer.WriteStringValue(uri);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            // We are ensuring we behave like Uri.ToString() but without the overhead
            // of creating the Uri instance.
            return this.CreateOrGetClrString();
        }

        /// <inheritdoc/>
        public bool Equals(JsonUri other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            if (this.clrUri is string value && other.clrUri is string otherValue)
            {
                return value.Equals(otherValue);
            }

            if (this.clrUri is string && other.HasJsonElement)
            {
                return other.JsonElement.ValueEquals(this.clrUri);
            }

            if (other.clrUri is string && this.HasJsonElement)
            {
                return this.JsonElement.ValueEquals(other.clrUri);
            }

            return JsonAny.From(this).Equals(JsonAny.From(other));
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

        private string CreateOrGetClrString()
        {
            return this.clrUri ?? this.JsonElement.GetString();
        }
    }
}
