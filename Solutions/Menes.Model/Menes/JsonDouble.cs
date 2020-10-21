// <copyright file="JsonDouble.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with doubles in situ, whether they
    /// originated from JSON or are a .NET double.
    /// </summary>
    public readonly struct JsonDouble : IJsonValue, IEquatable<JsonDouble>
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
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonDouble item) => JsonAny.From(item);

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
            return jsonElement.ValueKind == JsonValueKind.Number || jsonElement.ValueKind == JsonValueKind.Null;
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
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonDouble(property)
                    : Null)
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
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonDouble(property)
                    : Null)
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
            parentDocument.ValueKind != JsonValueKind.Undefined ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonDouble(property)
                    : Null)
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
        public override string? ToString()
        {
            return this.IsNull ? null : this.CreateOrGetClrDouble().ToString();
        }

        /// <inheritdoc/>
        public bool Equals(JsonDouble other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }

            return this.CreateOrGetClrDouble().Equals(other.CreateOrGetClrDouble());
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError("6.1.1. type: the element is not convertible from the given type");
            }

            if (this.HasJsonElement)
            {
                if (!this.JsonElement.TryGetDouble(out _))
                {
                    return validationContext.WithError($"6.1.1. type: the element is not convertible to a double.");
                }
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
        public ValidationContext ValidateAsNumber(in ValidationContext validationContext, double? multipleOf = null, double? maximum = null, double? exclusiveMaximum = null, double? minimum = null, double? exclusiveMinimum = null, in ImmutableArray<double>? enumeration = null, in double? constValue = null)
        {
            ValidationContext context = validationContext;
            double value = this.CreateOrGetClrDouble();
            if (multipleOf is double mo && (value % mo != 0))
            {
                context = context.WithError($"6.2.1 multipleOf: The value should have been a multiple of '{mo}', but was '{value}' with remainder '{value % mo}'");
            }

            if (maximum is double max && (value > max))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been <= '{max}', but was '{value}'");
            }

            if (exclusiveMaximum is double exMax && (value >= exMax))
            {
                context = context.WithError($"6.2.3 maximum: The value should have been < '{exMax}', but was '{value}'");
            }

            if (minimum is double min && (value < min))
            {
                context = context.WithError($"6.2.4 minimum: The value should have been >= '{min}', but was '{value}'");
            }

            if (exclusiveMinimum is double exMin && (value <= exMin))
            {
                context = context.WithError($"6.2.2 maximum: The value should have been > '{exMin}', but was '{value}'");
            }

            if (enumeration is ImmutableArray<double> values)
            {
                context = Validation.ValidateEnum(context, value, values);
            }

            if (constValue is double cv)
            {
                context = Validation.ValidateConst(context, value, cv);
            }

            return context;
        }
    }
}
