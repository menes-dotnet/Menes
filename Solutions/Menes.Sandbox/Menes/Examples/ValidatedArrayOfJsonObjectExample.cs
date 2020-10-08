// <copyright file="ValidatedArrayOfJsonObjectExample.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Examples
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.Json;

    /// <summary>
    /// An example of a JsonArray that has validation.
    /// </summary>
    /// <remarks>
    /// JsonArrays are interesting, because they are essentially just like objects in that they are
    /// compound types, so they need to be able to do validation on the types from which they are compounded.
    /// </remarks>
    public readonly struct ValidatedArrayOfJsonObjectExample : IJsonValue, IEnumerable<JsonObjectExample>, IEnumerable, IEquatable<ValidatedArrayOfJsonObjectExample>, IEquatable<JsonArray<JsonObjectExample>>
    {
        /// <summary>
        /// The function that constructs an instance from a <see cref="JsonElement"/>.
        /// </summary>
        public static readonly Func<JsonElement, ValidatedArrayOfJsonObjectExample> FromJsonElement = e => new ValidatedArrayOfJsonObjectExample(e);

        /// <summary>
        /// A <see cref="JsonArray{TItem}"/> representing a null value.
        /// </summary>
        public static readonly ValidatedArrayOfJsonObjectExample Null = new ValidatedArrayOfJsonObjectExample(default(JsonElement));

        private readonly JsonArray<JsonObjectExample>? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatedArrayOfJsonObjectExample"/> struct.
        /// </summary>
        /// <param name="jsonArrayOfJsonObjectExample">The JSON array from which to construct this string.</param>
        public ValidatedArrayOfJsonObjectExample(JsonArray<JsonObjectExample> jsonArrayOfJsonObjectExample)
        {
            if (jsonArrayOfJsonObjectExample.HasJsonElement)
            {
                this.JsonElement = jsonArrayOfJsonObjectExample.JsonElement;
                this.value = null;
            }
            else
            {
                this.value = jsonArrayOfJsonObjectExample;
                this.JsonElement = default;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatedArrayOfJsonObjectExample"/> struct.
        /// </summary>
        /// <param name="jsonElement">The json element from which to initialize the element.</param>
        public ValidatedArrayOfJsonObjectExample(JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this ValidatedArrayOfJsonObjectExample as a nullable value type.
        /// </summary>
        public ValidatedArrayOfJsonObjectExample? AsOptional => this.IsNull ? default(ValidatedArrayOfJsonObjectExample?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Convert a <see cref="JsonArray{JsonObjectExample}"/> to a <see cref="ValidatedArrayOfJsonObjectExample"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator ValidatedArrayOfJsonObjectExample(JsonArray<JsonObjectExample> value)
        {
            return new ValidatedArrayOfJsonObjectExample(value);
        }

        /// <summary>
        /// Convert a <see cref="ValidatedArrayOfJsonObjectExample"/> to a <see cref="JsonArray{JsonObjectExample}"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonArray<JsonObjectExample>(ValidatedArrayOfJsonObjectExample value)
        {
            if (value.value is JsonArray<JsonObjectExample> clrValue)
            {
                return clrValue;
            }

            return new JsonArray<JsonObjectExample>(value.JsonElement);
        }

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement)
        {
            return JsonArray<JsonObjectExample>.IsConvertibleFrom(jsonElement);
        }

        /// <summary>
        /// Gets a <see cref="JsonArray{TItem}"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonArray{TItem}"/> or null.</returns>
        public static ValidatedArrayOfJsonObjectExample FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? ValidatedArrayOfJsonObjectExample.FromJsonElement(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonArray{TItem}"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonArray{TItem}"/> or null.</returns>
        public static ValidatedArrayOfJsonObjectExample FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? ValidatedArrayOfJsonObjectExample.FromJsonElement(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonArray{TItem}"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonArray{TItem}"/> or null.</returns>
        public static ValidatedArrayOfJsonObjectExample FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? ValidatedArrayOfJsonObjectExample.FromJsonElement(property)
                : Null;

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.HasJsonElement)
            {
                return JsonAny.FromJsonElement(this.JsonElement);
            }

            if (this.value is JsonArray<JsonObjectExample> clrArray)
            {
                return clrArray.AsJsonAny();
            }

            return JsonAny.Null;
        }

        /// <inheritdoc/>
        public bool Equals(ValidatedArrayOfJsonObjectExample other)
        {
            return this.Equals((JsonArray<JsonObjectExample>)other);
        }

        /// <inheritdoc/>
        public bool Equals(JsonArray<JsonObjectExample> other)
        {
            return ((JsonArray<JsonObjectExample>)this).Equals(other);
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            JsonArray<JsonObjectExample> array = this;
            ValidationContext context = validationContext;
            context = array.ValidateMinItems(context, 10);
            context = array.ValidateMaxItems(context, 100);
            context = array.ValidateItems(context);
            return array.Validate(context);
        }

        /// <inheritdoc/>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }

            if (this.value is JsonArray<JsonObjectExample> clrValue)
            {
                clrValue.WriteTo(writer);
            }
        }

        /// <summary>
        /// Enumerate the array.
        /// </summary>
        /// <returns>The enumerator for the array.</returns>
        public JsonArray<JsonObjectExample>.JsonArrayEnumerator GetEnumerator()
        {
            return ((JsonArray<JsonObjectExample>)this).GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator<JsonObjectExample> IEnumerable<JsonObjectExample>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
