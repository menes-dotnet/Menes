// <copyright file="JsonDecimal.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with decimals in situ, whether they
    /// originated from JSON or are a .NET decimal.
    /// </summary>
    public readonly struct JsonDecimal : IJsonValue
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonDecimal> FromJsonElement = e => new JsonDecimal(e);

        /// <summary>
        /// A <see cref="JsonDecimal"/> representing a null value.
        /// </summary>
        public static readonly JsonDecimal Null = new JsonDecimal(default(JsonElement));

        private readonly decimal? clrDecimal;

        /// <summary>
        /// Creates a <see cref="JsonDecimal"/> wrapper around a .NET decimal.
        /// </summary>
        /// <param name="clrDecimal">The .NET decimal.</param>
        public JsonDecimal(decimal clrDecimal)
        {
            this.clrDecimal = clrDecimal;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonDecimal"/> wrapper around a .NET decimal.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the decimal value to represent.
        /// </param>
        public JsonDecimal(JsonElement jsonElement)
        {
            if (!IsConvertibleFrom(jsonElement))
            {
                throw new JsonException("The element must be a JSON number");
            }

            this.clrDecimal = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrDecimal == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this decimal as a nullable value type.
        /// </summary>
        public JsonDecimal? AsOptional => this.IsNull ? default(JsonDecimal?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator decimal(JsonDecimal value) => value.CreateOrGetClrDecimal();

        /// <summary>
        /// Implicit conversion from <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDecimal(decimal value) => new JsonDecimal(value);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <param name="checkKindOnly">If <c>true</c>, check the <see cref="JsonElement.ValueKind"/> only.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static bool IsConvertibleFrom(JsonElement jsonElement, bool checkKindOnly = true)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (jsonElement.ValueKind != JsonValueKind.Number && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets a <see cref="JsonDecimal"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDecimal"/> or null.</returns>
        public static JsonDecimal FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDecimal(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDecimal"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDecimal"/> or null.</returns>
        public static JsonDecimal FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDecimal(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDecimal"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonDecimal"/> or null.</returns>
        public static JsonDecimal FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonDecimal(property)
                : Null;

        /// <summary>
        /// Gets the decimal's value as a .NET decimal.
        /// </summary>
        /// <returns>The decimal value as a <see cref="decimal"/>.</returns>
        public decimal CreateOrGetClrDecimal() => this.clrDecimal ?? this.JsonElement.GetDecimal();

        /// <summary>
        /// Writes the decimal value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the decimal.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrDecimal is decimal single)
            {
                writer.WriteNumberValue(single);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            if (this.clrDecimal is decimal _)
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
            return this.CreateOrGetClrDecimal().ToString();
        }
    }
}
