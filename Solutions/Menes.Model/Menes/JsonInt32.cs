// <copyright file="JsonInt32.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with ints in situ, whether they
    /// originated from JSON or are a .NET int.
    /// </summary>
    public readonly struct JsonInt32 : IJsonValue, IEquatable<JsonInt32>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonInt32> FromJsonElement = e => new JsonInt32(e);

        /// <summary>
        /// A <see cref="JsonInt32"/> representing a null value.
        /// </summary>
        public static readonly JsonInt32 Null = new JsonInt32(default(JsonElement));

        private readonly int? clrInt32;

        /// <summary>
        /// Creates a <see cref="JsonInt32"/> wrapper around a .NET int.
        /// </summary>
        /// <param name="clrInt32">The .NET int.</param>
        public JsonInt32(int clrInt32)
        {
            this.clrInt32 = clrInt32;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonInt32"/> wrapper around a .NET int.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the int value to represent.
        /// </param>
        public JsonInt32(JsonElement jsonElement)
        {
            this.clrInt32 = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrInt32 == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this int as a nullable value type.
        /// </summary>
        public JsonInt32? AsOptional => this.IsNull ? default(JsonInt32?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator int(JsonInt32 value) => value.CreateOrGetClrInt32();

        /// <summary>
        /// Implicit conversion from an <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInt32(int value) => new JsonInt32(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonInt32 item) => JsonAny.From(item);

        /// <summary>
        /// Gets a value indicating whether an instance is convertible from
        /// this value type.
        /// </summary>
        /// <param name="jsonElement">The element to convert.</param>
        /// <returns><c>True</c> if the element can be converted from the given JsonElement.</returns>
        public static bool IsConvertibleFrom(JsonElement jsonElement)
        {
            return jsonElement.ValueKind == JsonValueKind.Number || jsonElement.ValueKind == JsonValueKind.Null;
        }

        /// <summary>
        /// Gets a <see cref="JsonInt32"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonInt32"/> or null.</returns>
        public static JsonInt32 FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonInt32(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonInt32"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonInt32"/> or null.</returns>
        public static JsonInt32 FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonInt32(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonInt32"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonInt32"/> or null.</returns>
        public static JsonInt32 FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonInt32(property)
                : Null;

        /// <summary>
        /// Gets the int's value as a .NET int.
        /// </summary>
        /// <returns>The int value as a <see cref="int"/>.</returns>
        public int CreateOrGetClrInt32() => this.clrInt32 ?? this.JsonElement.GetInt32();

        /// <summary>
        /// Writes the int value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the int.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrInt32 is int int32)
            {
                writer.WriteNumberValue(int32);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            return this.IsNull ? null : this.CreateOrGetClrInt32().ToString();
        }

        /// <inheritdoc/>
        public bool Equals(JsonInt32 other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            return this.CreateOrGetClrInt32().Equals(other.CreateOrGetClrInt32());
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
        /// Provides the numeric validations.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="multipleOf">A value which, when divided into the value, produces a remainder of zero.</param>
        /// <param name="maximum">The value is less than or equal to the maximum value.</param>
        /// <param name="exclusiveMaximum">The value is less than the exclusive maximum value.</param>
        /// <param name="minimum">The value is greater than or equal to the minimum value.</param>
        /// <param name="exclusiveMinimum">The value is greater than the exclusive minimum value.</param>
        /// <param name="enumeration">The value must equal one of the values in the enumeration.</param>
        /// <param name="constValue">The value must equal the constant value.</param>
        /// <returns>The validation context updated to reflect the results of the validation.</returns>
        /// <remarks>These are rolled up into a single method to ensure string conversion occurs only once.</remarks>
        public ValidationContext ValidateAsNumber(in ValidationContext validationContext, int? multipleOf = null, int? maximum = null, int? exclusiveMaximum = null, int? minimum = null, int? exclusiveMinimum = null, in ImmutableArray<int>? enumeration = null, in int? constValue = null)
        {
            ValidationContext context = validationContext;
            int value = this.CreateOrGetClrInt32();
            if (multipleOf is int mo && (value % mo != 0))
            {
                context = context.WithError($"6.2.1 multipleOf: The value should have been a multiple of '{mo}', but was '{value}' with remainder '{value % mo}'");
            }

            if (maximum is int max && (value > max))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been <= '{max}', but was '{value}'");
            }

            if (exclusiveMaximum is int exMax && (value >= exMax))
            {
                context = context.WithError($"6.2.3 maximum: The value should have been < '{exMax}', but was '{value}'");
            }

            if (minimum is int min && (value < min))
            {
                context = context.WithError($"6.2.4 minimum: The value should have been >= '{min}', but was '{value}'");
            }

            if (exclusiveMinimum is int exMin && (value <= exMin))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been > '{exMin}', but was '{value}'");
            }

            if (enumeration is ImmutableArray<int> values)
            {
                context = Validation.ValidateEnum(context, value, values);
            }

            if (constValue is int cv)
            {
                context = Validation.ValidateConst(context, value, cv);
            }

            return context;
        }
    }
}
