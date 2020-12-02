// <copyright file="IJsonValue.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
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
        /// Gets a value indicating whether this can be represented as a <see cref="JsonNumber"/>.
        /// </summary>
        bool IsNumber { get; }

        /// <summary>
        /// Gets a value indicating whether this can be represented as a <see cref="JsonInteger"/>.
        /// </summary>
        bool IsInteger { get; }

        /// <summary>
        /// Gets a value indicating whether this can be represented as a <see cref="JsonString"/>.
        /// </summary>
        bool IsString { get; }

        /// <summary>
        /// Gets a value indicating whether this can be represented as a <see cref="JsonBoolean"/>.
        /// </summary>
        bool IsBoolean { get; }

        /// <summary>
        /// Gets a value indicating whether this can be represented as a <see cref="IJsonObject"/>.
        /// </summary>
        bool IsObject { get; }

        /// <summary>
        /// Gets a value indicating whether this is a JSON array.
        /// </summary>
        bool IsArray { get; }

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
        /// Determines if this value equals the other value.
        /// </summary>
        /// <typeparam name="T">The type of the other value with which to compare.</typeparam>
        /// <param name="other">The other value with which to compare.</param>
        /// <returns>True if they are equal.</returns>
        bool Equals<T>(in T other)
            where T : struct, IJsonValue;

        /// <summary>
        /// Writes the value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Any.</param>
        void WriteTo(Utf8JsonWriter writer);

        /// <summary>
        /// Validate the element.
        /// </summary>
        /// <param name="validationContext">The current validation context.</param>
        /// <param name="level">The validation level.</param>
        /// <returns>The validation context updated with the results of the validation.</returns>
        ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag);
    }
}