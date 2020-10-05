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
        /// Gets a value indicating whether this represents a null value.
        /// </summary>
        public bool IsNull { get; }

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
        /// Gets the value as a <see cref="JsonAny"/>.
        /// </summary>
        /// <returns>The element as a JsonAny.</returns>
        JsonAny AsJsonAny();

        /// <summary>
        /// Writes the value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Any.</param>
        public void Write(Utf8JsonWriter writer);
    }
}