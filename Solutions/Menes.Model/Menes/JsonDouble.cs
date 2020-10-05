// <copyright file="JsonDouble.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with doubles in situ, whether they
    /// originated from JSON or are a .NET double.
    /// </summary>
    public readonly struct JsonDouble : IJsonValue
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonDouble> FromJsonElement = e => new JsonDouble(e);

        /// <summary>
        /// A <see cref="JsonDouble"/> representing a null value.
        /// </summary>
        public static readonly JsonDouble Null = new JsonDouble(default(JsonElement));

        private readonly double? clrDouble;

        /// <summary>
        /// Creates a <see cref="JsonDouble"/> wrapper around a .NET double.
        /// </summary>
        /// <param name="clrDouble">The .NET double.</param>
        public JsonDouble(double clrDouble)
        {
            this.clrDouble = clrDouble;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonDouble"/> wrapper around a .NET double.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the double value to represent.
        /// </param>
        public JsonDouble(JsonElement jsonElement)
        {
            if (!IsConvertibleFrom(jsonElement))
            {
                throw new JsonException("The element must be a JSON number");
            }

            this.clrDouble = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrDouble == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this double as a nullable value type.
        /// </summary>
        public JsonDouble? AsOptional => this.IsNull ? default(JsonDouble?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="double"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator double(JsonDouble value) => value.CreateOrGetClrDouble();

        /// <summary>
        /// Implicit conversion from <see cref="double"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDouble(double value) => new JsonDouble(value);

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
        /// Gets a <see cref="JsonDouble"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDouble"/> or null.</returns>
        public static JsonDouble FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDouble(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDouble"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonDouble"/> or null.</returns>
        public static JsonDouble FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonDouble(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonDouble"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonDouble"/> or null.</returns>
        public static JsonDouble FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonDouble(property)
                : Null;

        /// <summary>
        /// Gets the double's value as a .NET double.
        /// </summary>
        /// <returns>The double value as a <see cref="double"/>.</returns>
        public double CreateOrGetClrDouble() => this.clrDouble ?? this.JsonElement.GetDouble();

        /// <summary>
        /// Writes the double value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the double.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrDouble is double single)
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
            if (this.clrDouble is double _)
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
            return this.CreateOrGetClrDouble().ToString();
        }
    }
}
