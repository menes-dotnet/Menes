﻿// <copyright file="JsonReference.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Text.Json;
    using Corvus.Extensions;

    /// <summary>
    /// A boxing reference to a value optimized to be backed with a JsonElement.
    /// </summary>
    /// <remarks>
    /// This is used when a value is set on a complex JSON object, to avoid a recursive reference. It boxes the instance.
    /// </remarks>
    public readonly struct JsonReference
    {
        private readonly IJsonValue? value;
        private readonly JsonElement jsonElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReference"/> class.
        /// </summary>
        /// <param name="value">The value from which to construct the reference.</param>
        public JsonReference(IJsonValue value)
        {
            if (value.HasJsonElement)
            {
                this.jsonElement = value.JsonElement;
                this.value = null;
            }
            else
            {
                this.value = value;
                this.jsonElement = default;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReference"/> struct.
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> from which to construct the reference.</param>
        public JsonReference(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/>.</typeparam>
        /// <returns>The value.</returns>
        public TValue AsValue<TValue>()
            where TValue : struct, IJsonValue
        {
            if (this.value is null)
            {
                return JsonAny.As<TValue>(this.jsonElement);
            }
            else
            {
                return CastTo<TValue>.From(this.value);
            }
        }

        /// <summary>
        /// Write the value of this reference to the given writer.
        /// </summary>
        /// <param name="writer">The writer to which to write the reference.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.value is null)
            {
                this.jsonElement.WriteTo(writer);
            }
            else
            {
                this.value.WriteTo(writer);
            }
        }
    }
}