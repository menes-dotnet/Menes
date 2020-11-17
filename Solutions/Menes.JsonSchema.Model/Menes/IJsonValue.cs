// <copyright file="IJsonValue.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    /// <summary>
    /// Represents any value that can be represented as Json.
    /// </summary>
    public interface IJsonValue
    {
        /// <summary>
        /// Gets a value indicating whether this represents an undefined value.
        /// </summary>
        bool IsUndefined { get; }

        /// <summary>
        /// Gets a value indicating whether this represents a null value.
        /// </summary>
        bool IsNull { get; }

        /// <summary>
        /// Gets a value indicating whether this is backed by a <see cref="JsonElement"/>.
        /// </summary>
        bool HasJsonElement { get; }

        /// <summary>
        /// Gets the backing <see cref="JsonElement"/>.
        /// </summary>
        /// <remarks>
        /// This will be <see cref="JsonValueKind.Undefined"/> if it is not backed
        /// by a <see cref="JsonElement"/>. See <see cref="HasJsonElement"/>.
        /// </remarks>
        JsonElement JsonElement { get; }

        /// <summary>
        /// Casts the value to the given type.
        /// </summary>
        /// <typeparam name="T">The <see cref="IJsonValue"/> type to which to cast this value.</typeparam>
        /// <returns>An instance of the specified type, initialized from this type's backing data.</returns>
        T As<T>()
            where T : struct, IJsonValue;

        /// <summary>
        /// Determines if the value would be valid if cast to the given type.
        /// </summary>
        /// <typeparam name="T">The <see cref="IJsonValue"/> type to test.</typeparam>
        /// <returns><c>true</c> if an instance of the specified type, initialized from this type's backing data, would be valid.</returns>
        bool Is<T>()
            where T : struct, IJsonValue;

        /// <summary>
        /// Writes the value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Any.</param>
        void WriteTo(Utf8JsonWriter writer);

        /// <summary>
        /// Validate the element.
        /// </summary>
        /// <param name="validationResult">The current validation result.</param>
        /// <param name="level">The required validation level.</param>
        /// <param name="evaluatedProperties">The properties that have been evaluated.</param>
        /// <returns>The validation context updated with the results of the validation.</returns>
        ValidationResult Validate(in ValidationResult validationResult, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null);

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
        bool TryGetProperty<T>(ReadOnlySpan<char> propertyName, out T property)
            where T : struct, IJsonValue;

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
        bool TryGetProperty<T>(string propertyName, out T property)
            where T : struct, IJsonValue;

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="utf8PropertyName">The utf8 encoded name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
        bool TryGetProperty<T>(ReadOnlySpan<byte> utf8PropertyName, out T property)
            where T : struct, IJsonValue;
    }
}