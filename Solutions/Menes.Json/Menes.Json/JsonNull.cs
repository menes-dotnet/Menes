﻿// <copyright file="JsonNull.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Text.Json;

    /// <summary>
    /// The JSON null value.
    /// </summary>
    public readonly struct JsonNull : IJsonValue
    {
        /// <summary>
        /// Gets the constant HashCode for a null instance.
        /// </summary>
        public static readonly int NullHashCode = new Guid("e55d355c-0834-4cb8-93f3-7fa3e0977e2a").GetHashCode();

        /// <summary>
        /// Gets a null value.
        /// </summary>
        public static readonly JsonNull Instance = default;

        private readonly JsonElement? jsonElementBacking;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNull"/> struct.
        /// </summary>
        /// <param name="jsonElement">The json element from which to construct the value.</param>
        public JsonNull(JsonElement jsonElement)
        {
            this.jsonElementBacking = jsonElement;
        }

        /// <inheritdoc/>
        public JsonElement AsJsonElement => this.jsonElementBacking ?? default;

        /// <inheritdoc/>
        public bool HasJsonElement => this.jsonElementBacking is not null;

        /// <inheritdoc/>
        public JsonValueKind ValueKind => JsonValueKind.Null;

        /// <inheritdoc/>
        public JsonAny AsAny => default;

        /// <summary>
        /// Implicit conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(JsonNull value)
        {
            return default;
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonNull(JsonAny value)
        {
            return default;
        }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(JsonNull lhs, JsonNull rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(JsonNull lhs, JsonNull rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            if (this.jsonElementBacking is JsonElement je)
            {
                return Json.Validate.TypeNull(je.ValueKind, validationContext ?? ValidationContext.ValidContext, level);
            }

            return Json.Validate.TypeNull(JsonValueKind.Null, validationContext ?? ValidationContext.ValidContext, level);
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return default;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            return this.ValueKind == other.ValueKind;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is JsonNull jany)
            {
                return this.Equals(jany);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return NullHashCode;
        }

        /// <inheritdoc/>
        public void WriteTo(Utf8JsonWriter writer)
        {
            writer.WriteNullValue();
        }
    }
}
