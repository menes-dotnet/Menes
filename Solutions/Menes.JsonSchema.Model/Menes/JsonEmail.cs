// <copyright file="JsonEmail.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents the email json type.
    /// </summary>
    public readonly struct JsonEmail : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonEmail Null = default;
        private static readonly Regex Pattern = new Regex("^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])$", RegexOptions.Compiled);

        private readonly ReadOnlyMemory<char>? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonEmail"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonEmail(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonEmail"/> struct.
        /// </summary>
        /// <param name="value">The backing string value.</param>
        public JsonEmail(string value)
        {
            this.value = value.AsMemory();
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonEmail"/> struct.
        /// </summary>
        /// <param name="value">The backing string value.</param>
        public JsonEmail(ReadOnlyMemory<char> value)
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
        public static implicit operator JsonEmail(string value)
        {
            return new JsonEmail(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="string"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator string?(JsonEmail value)
        {
            return value.GetString();
        }

        /// <summary>
        /// Implicit conversion from <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator JsonEmail(ReadOnlyMemory<char> value)
        {
            return new JsonEmail(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator ReadOnlyMemory<char>(JsonEmail value)
        {
            return value.AsMemory();
        }

        /// <summary>
        /// Implicit conversion from <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator JsonEmail(ReadOnlySpan<char> value)
        {
            return new JsonEmail(value.ToArray());
        }

        /// <summary>
        /// Implicit conversion from <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator ReadOnlySpan<char>(JsonEmail value)
        {
            return value.AsSpan();
        }

        /// <summary>
        /// Gets the <see cref="JsonEmail"/> as a <see cref="string"/>.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string? GetString()
        {
            return this.HasJsonElement ? this.JsonElement.GetString() : this.value?.ToString();
        }

        /// <summary>
        /// Gets the <see cref="JsonEmail"/> as a <see cref="ReadOnlyMemory{T}"/> of <see cref="char"/>.
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
        /// Gets the <see cref="JsonEmail"/> as a <see cref="ReadOnlySpan{T}"/> of char.
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
            if (typeof(T) == typeof(JsonEmail))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<T>(JsonValue.FlattenToJsonElementBacking(this).JsonElement);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonEmail))
            {
                return this.Validate(ValidationContext.ValidContext).IsValid;
            }

            return this.As<T>().Validate(ValidationContext.ValidContext).IsValid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(in T other)
            where T : struct, IJsonValue
        {
            if (!other.IsString)
            {
                return false;
            }

            JsonEmail otherString = other.As<JsonEmail>();
            if (!otherString.Validate(ValidationContext.ValidContext).IsValid)
            {
                return false;
            }

            return this.AsSpan().SequenceEqual(otherString.AsSpan());
        }

        /// <inheritdoc />
        public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
        {
            if ((this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || !Pattern.IsMatch(this.JsonElement.GetString()))) || (this.value is ReadOnlyMemory<char> value && !Pattern.IsMatch(value.ToString())))
            {
                if (level >= ValidationLevel.Basic)
                {
                    return validationContext.WithResult(isValid: false, message: $"6.1.1.  type - should have been 'string' with format 'email.");
                }
                else
                {
                    return validationContext.WithResult(isValid: false);
                }
            }
            else
            {
                if (level == ValidationLevel.Verbose)
                {
                    return validationContext.WithResult(isValid: true);
                }
            }

            return validationContext;
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
    }
}
