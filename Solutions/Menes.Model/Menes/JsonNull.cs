// <copyright file="JsonNull.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Collections.Concurrent;
    using System.Reflection;
    using System.Text;
    using System.Text.Json;
    using Corvus.Extensions;
    using NodaTime;

    /// <summary>
    /// Enables the Json resources to work with "any" types in situ, whether they
    /// originated from JSON or are an arbitrary .NET type.
    /// </summary>
    public readonly struct JsonNull : IJsonValue, IEquatable<JsonNull>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonNull> FromJsonElement = e => new JsonNull(e);

        /// <summary>
        /// A <see cref="JsonNull"/> representing a null value.
        /// </summary>
        public static readonly JsonNull Null = new JsonNull(default);

        private static readonly ConcurrentDictionary<Type, object> FactoryCache = new ConcurrentDictionary<Type, object>();
        private static readonly ConcurrentDictionary<Type, Func<JsonElement, bool>> IsConvertibleCache = new ConcurrentDictionary<Type, Func<JsonElement, bool>>();

        /// <summary>
        /// Creates a <see cref="JsonNull"/> wrapper around a .NET Any.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Any value to represent.
        /// </param>
        public JsonNull(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
        }

        /// <inheritdoc/>
        public bool IsNull => this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null;

        /// <summary>
        /// Gets this Any as a nullable value type.
        /// </summary>
        public JsonNull? AsOptional => this.IsNull ? default(JsonNull?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

        /// <summary>
        /// Implicit conversion from string.
        /// </summary>
        /// <param name="value">The string value.</param>
        public static implicit operator JsonNull(string? value)
        {
            return From<JsonString>(value ?? JsonString.Null);
        }

        /// <summary>
        /// Implicit conversion from double.
        /// </summary>
        /// <param name="value">The double value.</param>
        public static implicit operator JsonNull(double? value)
        {
            return From<JsonDouble>(value);
        }

        /// <summary>
        /// Implicit conversion from float.
        /// </summary>
        /// <param name="value">The float value.</param>
        public static implicit operator JsonNull(float? value)
        {
            return From<JsonSingle>(value);
        }

        /// <summary>
        /// Implicit conversion from int.
        /// </summary>
        /// <param name="value">The int value.</param>
        public static implicit operator JsonNull(int? value)
        {
            return From<JsonInt32>(value);
        }

        /// <summary>
        /// Implicit conversion from long.
        /// </summary>
        /// <param name="value">The long value.</param>
        public static implicit operator JsonNull(long? value)
        {
            return From<JsonInt64>(value);
        }

        /// <summary>
        /// Implicit conversion from uri.
        /// </summary>
        /// <param name="value">The uri value.</param>
        public static implicit operator JsonNull(Uri? value)
        {
            return From<JsonUri>(value ?? JsonUri.Null);
        }

        /// <summary>
        /// Implicit conversion from guid.
        /// </summary>
        /// <param name="value">The guid value.</param>
        public static implicit operator JsonNull(Guid? value)
        {
            return From<JsonGuid>(value);
        }

        /// <summary>
        /// Implicit conversion from bool.
        /// </summary>
        /// <param name="value">The guid value.</param>
        public static implicit operator JsonNull(bool? value)
        {
            return From<JsonBoolean>(value);
        }

        /// <summary>
        /// Implicit conversion from LocalDate.
        /// </summary>
        /// <param name="value">The LocalDate value.</param>
        public static implicit operator JsonNull(LocalDate? value)
        {
            return From<JsonDate>(value);
        }

        /// <summary>
        /// Implicit conversion from OffsetDateTime.
        /// </summary>
        /// <param name="value">The OffsetDateTime value.</param>
        public static implicit operator JsonNull(OffsetDateTime? value)
        {
            return From<JsonDateTime>(value);
        }

        /// <summary>
        /// Implicit conversion from decimal.
        /// </summary>
        /// <param name="value">The decimal value.</param>
        public static implicit operator JsonNull(decimal? value)
        {
            return From<JsonDecimal>(value);
        }

        /// <summary>
        /// Implicit conversion from Duration.
        /// </summary>
        /// <param name="value">The Duration value.</param>
        public static implicit operator JsonNull(Duration? value)
        {
            return From<JsonDuration>(value);
        }

        /// <summary>
        /// Implicit conversion from OffsetTime.
        /// </summary>
        /// <param name="value">The OffsetTime value.</param>
        public static implicit operator JsonNull(OffsetTime? value)
        {
            return From<JsonTime>(value);
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonNumber?(JsonNull value)
        {
            return value.As<JsonNumber>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonBoolean?(JsonNull value)
        {
            return value.As<JsonBoolean>();
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonByteArray?(JsonNull value)
        {
            return value.As<JsonByteArray>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDate?(JsonNull value)
        {
            return value.As<JsonDate>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDateTime?(JsonNull value)
        {
            return value.As<JsonDateTime>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDecimal?(JsonNull value)
        {
            return value.As<JsonDecimal>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDouble?(JsonNull value)
        {
            return value.As<JsonDouble>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonDuration?(JsonNull value)
        {
            return value.As<JsonDuration>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonEmail?(JsonNull value)
        {
            return value.As<JsonEmail>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonGuid?(JsonNull value)
        {
            return value.As<JsonGuid>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonHostName?(JsonNull value)
        {
            return value.As<JsonHostName>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInt32?(JsonNull value)
        {
            return value.As<JsonInt32>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInt64?(JsonNull value)
        {
            return value.As<JsonInt64>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonInteger?(JsonNull value)
        {
            return value.As<JsonInteger>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonIPv4?(JsonNull value)
        {
            return value.As<JsonIPv4>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonIPv6?(JsonNull value)
        {
            return value.As<JsonIPv6>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonObject?(JsonNull value)
        {
            return value.As<JsonObject>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonSingle?(JsonNull value)
        {
            return value.As<JsonSingle>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonString?(JsonNull value)
        {
            return value.As<JsonString>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonTime?(JsonNull value)
        {
            return value.As<JsonTime>().AsOptional;
        }

        /// <summary>
        /// Implicit conversion to standard types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator JsonUri?(JsonNull value)
        {
            return value.As<JsonUri>().AsOptional;
        }

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
            return true;
        }

        /// <summary>
        /// Gets a <see cref="JsonNull"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonNull"/> or null.</returns>
        public static JsonNull FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonNull(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonNull"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonNull"/> or null.</returns>
        public static JsonNull FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out JsonElement property)
                    ? new JsonNull(property)
                    : Null)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonNull"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonNull"/> or null.</returns>
        public static JsonNull FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.ValueKind == JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                    ? new JsonNull(property)
                    : Null)
                : Null;

        /// <summary>
        /// Get a json element as the given <see cref="IJsonValue"/> type.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IJsonValue"/> to get.</typeparam>
        /// <param name="element">The <see cref="JsonElement"/> around which to create the instance.</param>
        /// <returns>An instance of the given <see cref="IJsonValue"/>.</returns>
        public static T As<T>(JsonElement element)
            where T : IJsonValue
        {
            Func<JsonElement, T> func = CastTo<Func<JsonElement, T>>.From(FactoryCache.GetOrAdd(typeof(T), t => t.GetField("FromJsonElement").GetValue(null)));
            return func(element);
        }

        /// <summary>
        /// Get a a value which determines .
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IJsonValue"/> to convert.</typeparam>
        /// <param name="element">The <see cref="JsonElement"/> around which to create the instance.</param>
        /// <returns><c>True</c> is the JsonElement can be converted, otherwise false.</returns>
        public static bool IsConvertibleFrom<T>(JsonElement element)
            where T : IJsonValue
        {
            Func<JsonElement, bool> func = IsConvertibleCache.GetOrAdd(typeof(T), t => GetIsItemConvertibleFrom<T>());
            return func(element);
        }

        /// <summary>
        /// Gets a JsonNull from an <see cref="IJsonValue"/>.
        /// </summary>
        /// <typeparam name="TValue">The value to convert to a <see cref="JsonNull"/>.</typeparam>
        /// <param name="val">The value to convert.</param>
        /// <returns>A <see cref="JsonNull"/>.</returns>
        public static JsonNull From<TValue>(TValue? val)
            where TValue : struct, IJsonValue
        {
            if (!(val is TValue value))
            {
                return Null;
            }

            if (value.IsNull)
            {
                return Null;
            }

            if (value.HasJsonElement)
            {
                return new JsonNull(value.JsonElement);
            }

            var abw = new ArrayBufferWriter<byte>();
            using var utfw = new Utf8JsonWriter(abw);
            value.WriteTo(utfw);
            utfw.Flush();
            var reader = new Utf8JsonReader(abw.WrittenMemory.Span);
            return new JsonNull(JsonDocument.ParseValue(ref reader).RootElement.Clone());
        }

        /// <summary>
        /// Writes the Null value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Any.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            this.JsonElement.WriteTo(writer);
        }

        /// <inheritdoc/>
        public bool Equals(JsonNull other)
        {
            return this.IsNull && other.IsNull;
        }

        /// <summary>
        /// Get this element as the given <see cref="IJsonValue"/> type.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IJsonValue"/> to get.</typeparam>
        /// <returns>An instance of the given <see cref="IJsonValue"/>.</returns>
        public T As<T>()
            where T : IJsonValue
        {
            if (this is T that)
            {
                return that;
            }

            return As<T>(this.JsonElement);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.IsNull)
            {
                return "null";
            }

            // Normalise the write.
            var abw1 = new ArrayBufferWriter<byte>();
            using var writer1 = new Utf8JsonWriter(abw1);
            this.WriteTo(writer1);
            writer1.Flush();
            return Encoding.UTF8.GetString(abw1.WrittenSpan);
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
            if (!this.IsNull)
            {
                return validationContext.WithError($"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not null and not convertible to {JsonValueKind.Null}");
            }

            return validationContext;
        }

        private static Func<JsonElement, bool> GetIsItemConvertibleFrom<T>()
        {
            MethodInfo? method = typeof(T).GetMethod("IsConvertibleFrom", BindingFlags.Static | BindingFlags.Public);

            if (method is null)
            {
                throw new Exception($"The item type {typeof(T).FullName} must provide a static public method: 'bool IsConvertibleFrom(JsonElement jsonElement)'");
            }

            return (Func<JsonElement, bool>)Delegate.CreateDelegate(typeof(Func<JsonElement, bool>), method);
        }
    }
}
