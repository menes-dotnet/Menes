// <copyright file="JsonUnionExample.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Examples
{
    using System;
    using System.Text.Json;
    using Menes;

    /// <summary>
    /// A union over a Json element.
    /// </summary>
    public readonly struct JsonUnionExample : IJsonValue
    {
        /// <summary>
        /// A <see cref="JsonUnionExample"/> representing a null value.
        /// </summary>
        public static readonly JsonUnionExample Null = new JsonUnionExample(default(JsonElement));

        private readonly JsonBoolean? firstInstance;
        private readonly JsonInt64? secondInstance;
        private readonly JsonReference? thirdInstance;

        /// <summary>
        /// Creates a <see cref="JsonUnionExample"/> wrapper around a .NET boolean.
        /// </summary>
        /// <param name="clrInstance">The .NET instance.</param>
        public JsonUnionExample(JsonBoolean clrInstance)
        {
            if (clrInstance.HasJsonElement)
            {
                this.JsonElement = clrInstance.JsonElement;
                this.firstInstance = null;
            }
            else
            {
                this.firstInstance = clrInstance;
                this.JsonElement = default;
            }

            this.secondInstance = null;
            this.thirdInstance = null;
        }

        /// <summary>
        /// Creates a <see cref="JsonUnionExample"/> wrapper around a .NET int64.
        /// </summary>
        /// <param name="clrInstance">The .NET instance.</param>
        public JsonUnionExample(JsonInt64 clrInstance)
        {
            this.firstInstance = null;
            if (clrInstance.HasJsonElement)
            {
                this.JsonElement = clrInstance.JsonElement;
                this.secondInstance = null;
            }
            else
            {
                this.secondInstance = clrInstance;
                this.JsonElement = default;
            }

            this.thirdInstance = null;
        }

        /// <summary>
        /// Creates a <see cref="JsonUnionExample"/> wrapper around a JsonObjectExample.
        /// </summary>
        /// <param name="clrInstance">The .NET instance.</param>
        public JsonUnionExample(JsonObjectExample clrInstance)
        {
            this.firstInstance = null;
            this.secondInstance = null;
            if (clrInstance.HasJsonElement)
            {
                this.thirdInstance = null;
                this.JsonElement = clrInstance.JsonElement;
            }
            else
            {
                this.thirdInstance = JsonReference.FromValue(clrInstance);
                this.JsonElement = default;
            }
        }

        /// <summary>
        /// Creates a <see cref="JsonBoolean"/> wrapper around a .NET bool.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the bool value to represent.
        /// </param>
        public JsonUnionExample(JsonElement jsonElement)
        {
            this.firstInstance = null;
            this.secondInstance = null;
            this.thirdInstance = null;
            this.JsonElement = jsonElement;
        }

        /// <summary>
        /// Gets a value indicating whether this represents a null value.
        /// </summary>
        public bool IsNull => this.firstInstance is null && this.secondInstance is null && this.thirdInstance is null && (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null);

        /// <summary>
        /// Gets this value as a nullable value type.
        /// </summary>
        public JsonUnionExample? AsOptional => this.IsNull ? default(JsonUnionExample?) : this;

        /// <summary>
        /// Gets a value indicating whether this represents a JsonBoolean value.
        /// </summary>
        public bool IsJsonBoolean => this.firstInstance is JsonBoolean || JsonBoolean.IsConvertibleFrom(this.JsonElement);

        /// <summary>
        /// Gets a value indicating whether this represents a JsonInt64 value.
        /// </summary>
        public bool IsJsonInt64 => this.secondInstance is JsonInt64 || JsonInt64.IsConvertibleFrom(this.JsonElement);

        /// <summary>
        /// Gets a value indicating whether this represents a JsonObjectExample value.
        /// </summary>
        public bool IsJsonObjectExample => this.thirdInstance is JsonReference || JsonObjectExample.IsConvertibleFrom(this.JsonElement);

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Explicit conversion to <see cref="JsonBoolean"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator JsonBoolean(JsonUnionExample value) => value.AsJsonBoolean();

        /// <summary>
        /// Explicit conversion to <see cref="JsonBoolean"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator JsonInt64(JsonUnionExample value) => value.AsJsonInt64();

        /// <summary>
        /// Explicit conversion to <see cref="JsonBoolean"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static explicit operator JsonObjectExample(JsonUnionExample value) => value.AsJsonObjectExample();

        /// <summary>
        /// Implicit conversion from <see cref="JsonBoolean"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonUnionExample(JsonBoolean value) => new JsonUnionExample(value);

        /// <summary>
        /// Implicit conversion from <see cref="JsonInt64"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonUnionExample(JsonInt64 value) => new JsonUnionExample(value);

        /// <summary>
        /// Implicit conversion from <see cref="JsonObjectExample"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonUnionExample(JsonObjectExample value) => new JsonUnionExample(value);

        /// <summary>
        /// Gets a <see cref="JsonUnionExample"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonUnionExample"/> or null.</returns>
        public static JsonUnionExample FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonUnionExample(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonUnionExample"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonUnionExample"/> or null.</returns>
        public static JsonUnionExample FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonUnionExample(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonUnionExample"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonUnionExample"/> or null.</returns>
        public static JsonUnionExample FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonUnionExample(property)
                : Null;

        /// <summary>
        /// Gets the value as an instance of the first type.
        /// </summary>
        /// <returns>The value as a <see cref="JsonBoolean"/>.</returns>
        public JsonBoolean AsJsonBoolean() => this.firstInstance ?? new JsonBoolean(this.JsonElement);

        /// <summary>
        /// Gets the value as an instance of the second type.
        /// </summary>
        /// <returns>The value as a <see cref="JsonInt64"/>.</returns>
        public JsonInt64 AsJsonInt64() => this.secondInstance ?? new JsonInt64(this.JsonElement);

        /// <summary>
        /// Gets the value as an instance of the second type.
        /// </summary>
        /// <returns>The value as a <see cref="JsonInt64"/>.</returns>
        public JsonObjectExample AsJsonObjectExample() => this.thirdInstance?.AsValue<JsonObjectExample>() ?? new JsonObjectExample(this.JsonElement);

        /// <summary>
        /// Writes the bool value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the bool.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.firstInstance is JsonBoolean first)
            {
                first.WriteTo(writer);
            }
            else if (this.secondInstance is JsonInt64 second)
            {
                second.WriteTo(writer);
            }
            else if (this.thirdInstance is JsonReference third)
            {
                third.WriteTo(writer);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (this.IsNull)
            {
                return validationContext;
            }

            ValidationContext jsonBooleanValidationContext = ValidationContext.Root.WithPath(validationContext.Path);
            ValidationContext jsonInt64ValidationContext = ValidationContext.Root.WithPath(validationContext.Path);
            ValidationContext jsonObjectExampleValidationContext = ValidationContext.Root.WithPath(validationContext.Path);

            if (this.IsJsonBoolean)
            {
                jsonBooleanValidationContext = this.AsJsonBoolean().Validate(jsonBooleanValidationContext);
            }
            else
            {
                jsonBooleanValidationContext = jsonBooleanValidationContext.WithError("The value is not convertible to a JsonBoolean.");
            }

            if (this.IsJsonInt64)
            {
                jsonInt64ValidationContext = this.AsJsonInt64().Validate(jsonInt64ValidationContext);
            }
            else
            {
                jsonInt64ValidationContext = jsonInt64ValidationContext.WithError("The value is not convertible to a JsonInt64.");
            }

            if (this.IsJsonObjectExample)
            {
                jsonObjectExampleValidationContext = this.AsJsonInt64().Validate(jsonObjectExampleValidationContext);
            }
            else
            {
                jsonObjectExampleValidationContext = jsonObjectExampleValidationContext.WithError("The value is not convertible to a JsonObjectExample.");
            }

            return Validation.ValidateOneOf(validationContext, ("JsonBoolean", jsonBooleanValidationContext), ("JsonInt64", jsonInt64ValidationContext), ("JsonObjectExample", jsonObjectExampleValidationContext));
        }
    }
}
