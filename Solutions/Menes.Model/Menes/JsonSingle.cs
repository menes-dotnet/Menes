// <copyright file="JsonSingle.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with floats in situ, whether they
    /// originated from JSON or are a .NET float.
    /// </summary>
    public readonly struct JsonSingle : IJsonValue
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonSingle> FromJsonElement = e => new JsonSingle(e);

        /// <summary>
        /// A <see cref="JsonSingle"/> representing a null value.
        /// </summary>
        public static readonly JsonSingle Null = new JsonSingle(default(JsonElement));

        private readonly float? clrSingle;

        /// <summary>
        /// Creates a <see cref="JsonSingle"/> wrapper around a .NET float.
        /// </summary>
        /// <param name="clrSingle">The .NET float.</param>
        public JsonSingle(float clrSingle)
        {
            this.clrSingle = clrSingle;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonSingle"/> wrapper around a .NET float.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the float value to represent.
        /// </param>
        public JsonSingle(JsonElement jsonElement)
        {
            if (!IsConvertibleFrom(jsonElement))
            {
                throw new JsonException("The element must be a JSON number");
            }

            this.clrSingle = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrSingle == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this float as a nullable value type.
        /// </summary>
        public JsonSingle? AsOptional => this.IsNull ? default(JsonSingle?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="float"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator float(JsonSingle value) => value.CreateOrGetClrSingle();

        /// <summary>
        /// Implicit conversion from <see cref="float"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonSingle(float value) => new JsonSingle(value);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <param name="checkKindOnly">If <c>true</c>, check the <see cref="JsonElement.ValueKind"/> only.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement, bool checkKindOnly = true)
        {
            if (jsonElement.ValueKind != JsonValueKind.Number && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                return false;
            }

            if (!checkKindOnly && jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
            {
                // TODO: This is very expensive while our parse allocates a string -
                // it would be better to validate that it is parsable from the byte array
                if (!jsonElement.TryGetSingle(out float _))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets a <see cref="JsonSingle"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonSingle"/> or null.</returns>
        public static JsonSingle FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonSingle(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonSingle"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonSingle"/> or null.</returns>
        public static JsonSingle FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonSingle(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonSingle"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonSingle"/> or null.</returns>
        public static JsonSingle FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonSingle(property)
                : Null;

        /// <summary>
        /// Gets the float value as a .NET float.
        /// </summary>
        /// <returns>The float value as a <see cref="float"/>.</returns>
        public float CreateOrGetClrSingle() => this.clrSingle ?? this.JsonElement.GetSingle();

        /// <summary>
        /// Writes the float value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the float.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrSingle is float single)
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
            if (this.clrSingle is float _)
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
            return this.CreateOrGetClrSingle().ToString();
        }
    }
}
