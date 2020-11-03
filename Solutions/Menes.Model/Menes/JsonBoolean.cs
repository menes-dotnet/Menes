// <copyright file="JsonBoolean.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;

    /// <summary>
    /// Enables the Json resources to work with booleans in situ, whether they
    /// originated from JSON or are a .NET boolean.
    /// </summary>
    public readonly struct JsonBoolean : IJsonValue, IEquatable<JsonBoolean>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonBoolean> FromJsonElement = e => new JsonBoolean(e);

        /// <summary>
        /// A <see cref="JsonBoolean"/> representing a null value.
        /// </summary>
        public static readonly JsonBoolean Null = new JsonBoolean(default(JsonElement));

        private readonly bool? clrBoolean;

        /// <summary>
        /// Creates a <see cref="JsonBoolean"/> wrapper around a .NET boolean.
        /// </summary>
        /// <param name="clrBoolean">The .NET boolean.</param>
        public JsonBoolean(bool clrBoolean)
        {
            this.clrBoolean = clrBoolean;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonBoolean"/> wrapper around a .NET bool.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the bool value to represent.
        /// </param>
        public JsonBoolean(JsonElement jsonElement)
        {
            this.clrBoolean = null;
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.clrBoolean == null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this boolean as a nullable value type.
        /// </summary>
        public JsonBoolean? AsOptional => this.IsNull ? default(JsonBoolean?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion to <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator bool(JsonBoolean value) => value.CreateOrGetClrBoolean();

        /// <summary>
        /// Implicit conversion from <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonBoolean(bool value) => new JsonBoolean(value);

        /// <summary>
        /// Create a JsonAny from the item.
        /// </summary>
        /// <param name="item">The value from which to create the <see cref="JsonAny"/>.</param>
        public static implicit operator JsonAny(JsonBoolean item) => JsonAny.From(item);

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
            return jsonElement.ValueKind == JsonValueKind.True || jsonElement.ValueKind == JsonValueKind.False || jsonElement.ValueKind == JsonValueKind.Null;
        }

        /// <summary>
        /// Gets a <see cref="JsonBoolean"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonBoolean"/> or null.</returns>
        public static JsonBoolean FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonBoolean(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonBoolean"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonBoolean"/> or null.</returns>
        public static JsonBoolean FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonBoolean(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonBoolean"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonBoolean"/> or null.</returns>
        public static JsonBoolean FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonBoolean(property)
                    : Null)
                : Null;

        /// <inheritdoc/>
        public bool Equals(JsonBoolean other)
        {
            // It's super cheap to create these booleans.
            return this.CreateOrGetClrBoolean() == other.CreateOrGetClrBoolean();
        }

        /// <summary>
        /// Gets the bool's value as a .NET bool.
        /// </summary>
        /// <returns>The bool value as a <see cref="bool"/>.</returns>
        public bool CreateOrGetClrBoolean() => this.clrBoolean ?? this.JsonElement.GetBoolean();

        /// <summary>
        /// Writes the bool value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the bool.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.clrBoolean is bool boolean)
            {
                writer.WriteBooleanValue(boolean);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.IsNull ? string.Empty : this.CreateOrGetClrBoolean().ToString();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.IsNull)
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is null and not convertible to {JsonValueKind.True} or {JsonValueKind.False}");
            }

            if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {JsonValueKind.True} or {JsonValueKind.False}");
            }

            return validationContext;
        }

        /// <summary>
        /// Provides the boolan validation.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="enumeration">The value must equal one of the values in the enumeration.</param>
        /// <param name="constValue">The value must equal the constant value.</param>
        /// <returns>The validation context updated to reflect the results of the validation.</returns>
        /// <remarks>These are rolled up into a single method to ensure string conversion occurs only once.</remarks>
        public ValidationContext ValidateAsBoolean(in ValidationContext validationContext, in ImmutableArray<bool>? enumeration = null, in bool? constValue = null)
        {
            ValidationContext context = validationContext;
            bool value = this.CreateOrGetClrBoolean();

            if (enumeration is ImmutableArray<bool> values)
            {
                context = Validation.ValidateEnum(context, value, values);
            }

            if (constValue is bool cv)
            {
                context = Validation.ValidateConst(context, value, cv);
            }

            return context;
        }
    }
}
