﻿// <copyright file="JsonIpV6.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents the ipv6 json type.
    /// </summary>
    public readonly struct JsonIpV6 : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonIpV6 Null = default;

        private static readonly Regex ZoneIdExpression = new Regex("%.*$", RegexOptions.Compiled);

        private readonly ReadOnlyMemory<char>? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIpV6"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonIpV6(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIpV6"/> struct.
        /// </summary>
        /// <param name="value">The backing string value.</param>
        public JsonIpV6(string value)
        {
            this.value = value.AsMemory();
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIpV6"/> struct.
        /// </summary>
        /// <param name="value">The backing string value.</param>
        public JsonIpV6(ReadOnlyMemory<char> value)
        {
            this.value = value;
            this.JsonElement = default;
        }

        /// <inheritdoc />
        public bool IsUndefined => this.JsonElement.ValueKind == JsonValueKind.Undefined && this.value is null;

        /// <inheritdoc />
        public bool IsNull => (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null) && this.value is null;

        /// <inheritdoc />
        public bool IsNumber => false;

        /// <inheritdoc />
        public bool IsInteger => false;

        /// <inheritdoc />
        public bool IsString => true;

        /// <inheritdoc />
        public bool IsObject => false;

        /// <inheritdoc />
        public bool IsBoolean => false;

        /// <inheritdoc />
        public bool IsArray => false;

        /// <inheritdoc />
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc />
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion from <see cref="string"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator JsonIpV6(string value) => new JsonIpV6(value);

        /// <summary>
        /// Implicit conversion to <see cref="string"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator string?(JsonIpV6 value) => value.GetString();

        /// <summary>
        /// Implicit conversion from <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator JsonIpV6(ReadOnlyMemory<char> value) => new JsonIpV6(value);

        /// <summary>
        /// Implicit conversion to <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator ReadOnlyMemory<char>(JsonIpV6 value) => value.AsMemory();

        /// <summary>
        /// Implicit conversion from <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator JsonIpV6(ReadOnlySpan<char> value) => new JsonIpV6(value.ToArray());

        /// <summary>
        /// Implicit conversion from <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator ReadOnlySpan<char>(JsonIpV6 value) => value.AsSpan();

        /// <summary>
        /// Gets the <see cref="JsonIpV6"/> as a <see cref="string"/>.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string? GetString()
        {
            return this.HasJsonElement ? this.JsonElement.GetString() : this.value?.ToString();
        }

        /// <summary>
        /// Gets the <see cref="JsonIpV6"/> as a <see cref="ReadOnlyMemory{T}"/> of <see cref="char"/>.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public ReadOnlyMemory<char> AsMemory()
        {
            return this.HasJsonElement ? this.JsonElement.GetString().AsMemory() : this.value ?? ReadOnlyMemory<char>.Empty;
        }

        /// <summary>
        /// Gets the length of the string.
        /// </summary>
        /// <returns>The length of the string, or 0 if the string is null or empty.</returns>
        public int GetLength()
        {
            return this.HasJsonElement ? this.JsonElement.GetString()?.Length ?? 0 : (this.value ?? ReadOnlyMemory<char>.Empty).Length;
        }

        /// <summary>
        /// Returns true if the value matches the given regular expression.
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        /// <returns><c>True</c> if the string matches the regular expression.</returns>
        public bool IsMatch(Regex regex)
        {
            return regex.IsMatch(this.GetString());
        }

        /// <summary>
        /// Gets the <see cref="JsonIpV6"/> as a <see cref="ReadOnlySpan{T}"/> of char.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public ReadOnlySpan<char> AsSpan()
        {
            return this.AsMemory().Span;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.IsNull ? "null" : this;
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonIpV6))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<T>(JsonValue.FlattenToJsonElementBacking(this).JsonElement);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonIpV6))
            {
                return this.Validate().Valid;
            }

            return this.As<T>().Validate().Valid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            if (!other.IsString)
            {
                return false;
            }

            JsonIpV6 otherString = other.As<JsonIpV6>();
            if (!otherString.Validate().Valid)
            {
                return false;
            }

            return this.AsSpan().SequenceEqual(otherString.AsSpan());
        }

        /// <inheritdoc />
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.ValidResult;

            if ((this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || !Parse(this.JsonElement.GetString()))) || (this.value is ReadOnlyMemory<char> value && !Parse(value.ToString())))
            {
                if (level >= ValidationLevel.Basic)
                {
                    string? il = null;
                    string? akl = null;

                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);
                    result.AddResult(valid: false, message: $"6.1.1.  type - should have matched an IPv6 address.", instanceLocation: il, absoluteKeywordLocation: akl);
                }
                else
                {
                    result.SetValid(false);
                }
            }
            else
            {
                if (level == ValidationLevel.Verbose)
                {
                    string? il = null;
                    string? akl = null;

                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);

                    result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);
                }
            }

            return result;
        }

        /// <inheritdoc />
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
                return;
            }

            if (this.value is ReadOnlyMemory<char> v)
            {
                writer.WriteStringValue(v.Span);
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        private static bool Parse(string? ipv6)
        {
            if (IPAddress.TryParse(ipv6, out IPAddress address))
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    return !ZoneIdExpression.IsMatch(ipv6);
                }
            }

            return false;
        }
    }
}