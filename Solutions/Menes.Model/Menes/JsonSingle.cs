// <copyright file="JsonSingle.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with floats in situ, whether they
    /// originated from JSON or are a .NET float.
    /// </summary>
    public readonly struct JsonSingle : IJsonValue, IEquatable<JsonSingle>
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
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonSingle item) => JsonAny.From(item);

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
        /// Gets a <see cref="JsonSingle"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonSingle"/> or null.</returns>
        public static JsonSingle FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonSingle(property)
                    : Null)
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
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonSingle(property)
                    : Null)
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
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonSingle(property)
                    : Null)
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
        public override string? ToString()
        {
            return this.CreateOrGetClrSingle().ToString();
        }

        /// <inheritdoc/>
        public bool Equals(JsonSingle other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            return this.CreateOrGetClrSingle().Equals(other.CreateOrGetClrSingle());
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError("6.1.1. type: the element is not convertible from the given type");
            }

            if (this.HasJsonElement && !this.JsonElement.TryGetSingle(out _))
            {
                return validationContext.WithError("6.1.1. type: the element is not convertible to an float.");
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
        public ValidationContext ValidateAsNumber(in ValidationContext validationContext, float? multipleOf = null, float? maximum = null, float? exclusiveMaximum = null, float? minimum = null, float? exclusiveMinimum = null, in ImmutableArray<float>? enumeration = null, in float? constValue = null)
        {
            ValidationContext context = validationContext;
            float value = this.CreateOrGetClrSingle();
            if (multipleOf is float mo && (value % mo != 0))
            {
                context = context.WithError($"6.2.1 multipleOf: The value should have been a multiple of '{mo}', but was '{value}' with remainder '{value % mo}'");
            }

            if (maximum is float max && (value > max))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been <= '{max}', but was '{value}'");
            }

            if (exclusiveMaximum is float exMax && (value >= exMax))
            {
                context = context.WithError($"6.2.3 maximum: The value should have been < '{exMax}', but was '{value}'");
            }

            if (minimum is float min && (value < min))
            {
                context = context.WithError($"6.2.4 minimum: The value should have been >= '{min}', but was '{value}'");
            }

            if (exclusiveMinimum is float exMin && (value <= exMin))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been > '{exMin}', but was '{value}'");
            }

            if (enumeration is ImmutableArray<float> values)
            {
                context = Validation.ValidateEnum(context, value, values);
            }

            if (constValue is float cv)
            {
                context = Validation.ValidateConst(context, value, cv);
            }

            return context;
        }
    }
}
