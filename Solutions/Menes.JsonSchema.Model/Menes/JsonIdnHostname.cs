// <copyright file="JsonIdnHostname.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents the hostname json type.
    /// </summary>
    public readonly struct JsonIdnHostname : IJsonValue
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonIdnHostname Null = default;
        private static readonly Regex InvalidPattern = new Regex(@"(^[\p{Mn}\p{Mc}\p{Me}\u302E\u00b7])|.*\u302E.*|.*[^l]\u00b7.*|.*\u00b7[^l].*|.*\u00b7$|\u0374$|\u0375$|\u0374[^\p{IsGreekandCoptic}]|\u0375[^\p{IsGreekandCoptic}]|^\u05F3|[^\p{IsHebrew}]\u05f3|^\u05f4|[^\p{IsHebrew}]\u05f4|[\u0660-\u0669][\u06F0-\u06F9]|[\u06F0-\u06F9][\u0660-\u0669]|^\u200D|[^\uA953\u094d\u0acd\u0c4d\u0d3b\u09cd\u0a4d\u0b4d\u0bcd\u0ccd\u0d4d\u1039\u0d3c\u0eba\ua8f3\ua8f4]\u200D|^\u30fb$|[^\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]\u30fb|\u30fb[^\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]|[\u0640\u07fa\u3031\u3032\u3033\u3034\u3035\u302e\u302f\u303b]|..--", RegexOptions.Compiled);

        private static readonly IdnMapping IdnMapping = new IdnMapping { AllowUnassigned = true, UseStd3AsciiRules = true };
        private readonly ReadOnlyMemory<char>? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIdnHostname"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonIdnHostname(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIdnHostname"/> struct.
        /// </summary>
        /// <param name="value">The backing string value.</param>
        public JsonIdnHostname(string value)
        {
            this.value = value.AsMemory();
            this.JsonElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonIdnHostname"/> struct.
        /// </summary>
        /// <param name="value">The backing string value.</param>
        public JsonIdnHostname(ReadOnlyMemory<char> value)
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
        public static implicit operator JsonIdnHostname(string value)
        {
            return new JsonIdnHostname(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="string"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator string?(JsonIdnHostname value)
        {
            return value.GetString();
        }

        /// <summary>
        /// Implicit conversion from <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator JsonIdnHostname(ReadOnlyMemory<char> value)
        {
            return new JsonIdnHostname(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator ReadOnlyMemory<char>(JsonIdnHostname value)
        {
            return value.AsMemory();
        }

        /// <summary>
        /// Implicit conversion from <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator JsonIdnHostname(ReadOnlySpan<char> value)
        {
            return new JsonIdnHostname(value.ToArray());
        }

        /// <summary>
        /// Implicit conversion from <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="value">The string value from which to convert.</param>
        public static implicit operator ReadOnlySpan<char>(JsonIdnHostname value)
        {
            return value.AsSpan();
        }

        /// <summary>
        /// Gets the <see cref="JsonIdnHostname"/> as a <see cref="string"/>.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string? GetString()
        {
            return this.HasJsonElement ? this.JsonElement.GetString() : this.value?.ToString();
        }

        /// <summary>
        /// Gets the <see cref="JsonIdnHostname"/> as a <see cref="ReadOnlyMemory{T}"/> of <see cref="char"/>.
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
        /// Gets the <see cref="JsonIdnHostname"/> as a <see cref="ReadOnlySpan{T}"/> of char.
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
            if (typeof(T) == typeof(JsonIdnHostname))
            {
                return Corvus.Extensions.CastTo<T>.From(this);
            }

            return JsonValue.As<T>(JsonValue.FlattenToJsonElementBacking(this).JsonElement);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonIdnHostname))
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

            JsonIdnHostname otherString = other.As<JsonIdnHostname>();
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

            if ((this.HasJsonElement && (this.JsonElement.ValueKind != JsonValueKind.String || !MatchValue(this.JsonElement.GetString()))) || (this.value is ReadOnlyMemory<char> value && !MatchValue(value.ToString())))
            {
                if (level >= ValidationLevel.Basic)
                {
                    string? il = null;
                    string? akl = null;

                    instanceLocation?.TryPeek(out il);
                    absoluteKeywordLocation?.TryPeek(out akl);
                    result.AddResult(valid: false, message: $"6.1.1.  type - should have matched an email address.", instanceLocation: il, absoluteKeywordLocation: akl);
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

        private static bool MatchValue(string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            if (value.StartsWith("xn--"))
            {
                try
                {
                    string unicode = IdnMapping.GetUnicode(value);
                    return !InvalidPattern.IsMatch(unicode);
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    IdnMapping.GetAscii(value);
                    return !InvalidPattern.IsMatch(value);
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }
        }
    }
}
