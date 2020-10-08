// <copyright file="JsonAny.cs" company="Endjin Limited">
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

    /// <summary>
    /// Enables the Json resources to work with "any" types in situ, whether they
    /// originated from JSON or are an arbitrary .NET type.
    /// </summary>
    public readonly struct JsonAny : IJsonValue, IEquatable<JsonAny>
    {
        /// <summary>
        /// The function that constructs an instance from a JsonElement.
        /// </summary>
        public static readonly Func<JsonElement, JsonAny> FromJsonElement = e => new JsonAny(e);

        /// <summary>
        /// A <see cref="JsonAny"/> representing a null value.
        /// </summary>
        public static readonly JsonAny Null = new JsonAny(default(JsonElement));

        private static readonly ConcurrentDictionary<Type, object> FactoryCache = new ConcurrentDictionary<Type, object>();
        private static readonly ConcurrentDictionary<Type, Func<JsonElement, bool>> IsConvertibleCache = new ConcurrentDictionary<Type, Func<JsonElement, bool>>();

        private readonly ReadOnlyMemory<byte>? utf8JsonText;

        /// <summary>
        /// Creates a <see cref="JsonAny"/> wrapper around a utf8 byte stream.
        /// </summary>
        /// <param name="utf8JsonText">
        /// A utf8 bytes stream containing value to represent.
        /// </param>
        public JsonAny(ReadOnlyMemory<byte> utf8JsonText)
        {
            this.utf8JsonText = utf8JsonText;
            this.JsonElement = default;
        }

        /// <summary>
        /// Creates a <see cref="JsonAny"/> wrapper around a .NET Any.
        /// </summary>
        /// <param name="jsonElement">
        /// A JSON element containing the Any value to represent.
        /// </param>
        public JsonAny(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.utf8JsonText = null;
        }

        /// <inheritdoc/>
        public bool IsNull => this.JsonElement.ValueKind == JsonValueKind.Undefined;

        /// <summary>
        /// Gets this Any as a nullable value type.
        /// </summary>
        public JsonAny? AsOptional => this.IsNull ? default(JsonAny?) : this;

        /// <inheritdoc/>
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc/>
        public JsonElement JsonElement { get; }

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
        /// Gets a <see cref="JsonAny"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonAny"/> or null.</returns>
        public static JsonAny FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<char> propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonAny(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonAny"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>A <see cref="JsonAny"/> or null.</returns>
        public static JsonAny FromOptionalProperty(in JsonElement parentDocument, string propertyName) =>
            parentDocument.TryGetProperty(propertyName, out JsonElement property)
                ? new JsonAny(property)
                : Null;

        /// <summary>
        /// Gets a <see cref="JsonAny"/> from a property in a JSON element, or <see cref="Null"/> if the property is not present.
        /// </summary>
        /// <param name="parentDocument">The parent JSON element.</param>
        /// <param name="utf8PropertyName">
        /// The property name as a UTF8 encoded string.
        /// </param>
        /// <returns>A <see cref="JsonAny"/> or null.</returns>
        public static JsonAny FromOptionalProperty(in JsonElement parentDocument, ReadOnlySpan<byte> utf8PropertyName) =>
            parentDocument.TryGetProperty(utf8PropertyName, out JsonElement property)
                ? new JsonAny(property)
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
        /// Writes the Any value to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The output to which to write the Any.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.utf8JsonText is ReadOnlyMemory<byte> utf8JsonText)
            {
                writer.WriteStringValue(utf8JsonText.Span);
            }
            else
            {
                this.JsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonAny AsJsonAny()
        {
            return this;
        }

        /// <inheritdoc/>
        public bool Equals(JsonAny other)
        {
            if (this.utf8JsonText is ReadOnlyMemory<byte> utf8JsonTextA && other.utf8JsonText is ReadOnlyMemory<byte> otherUtf8JsonTextA)
            {
                return utf8JsonTextA.Span.SequenceEqual(otherUtf8JsonTextA.Span);
            }

            if (this.utf8JsonText is ReadOnlyMemory<byte> utf8JsonTextB && other.HasJsonElement)
            {
                var abw = new ArrayBufferWriter<byte>();
                using var writer = new Utf8JsonWriter(abw);
                other.WriteTo(writer);
                writer.Flush();
                return utf8JsonTextB.Span.SequenceEqual(abw.WrittenSpan);
            }

            if (other.utf8JsonText is ReadOnlyMemory<byte> utf8JsonTextC && this.HasJsonElement)
            {
                var abw = new ArrayBufferWriter<byte>();
                using var writer = new Utf8JsonWriter(abw);
                this.WriteTo(writer);
                writer.Flush();
                return utf8JsonTextC.Span.SequenceEqual(abw.WrittenSpan);
            }

            if (this.HasJsonElement && other.HasJsonElement)
            {
                var abw1 = new ArrayBufferWriter<byte>();
                using var writer1 = new Utf8JsonWriter(abw1);
                other.WriteTo(writer1);
                writer1.Flush();

                var abw2 = new ArrayBufferWriter<byte>();
                using var writer2 = new Utf8JsonWriter(abw2);
                other.WriteTo(writer2);
                writer2.Flush();
                return abw1.WrittenSpan.SequenceEqual(abw2.WrittenSpan);
            }

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

            return As<T>(this.AsJsonElement());
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.utf8JsonText is ReadOnlyMemory<byte> utf8JsonText)
            {
                return Encoding.UTF8.GetString(utf8JsonText.Span);
            }
            else
            {
                return this.JsonElement.ToString();
            }
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext validationContext)
        {
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

        private JsonElement AsJsonElement()
        {
            if (this.utf8JsonText is ReadOnlyMemory<byte> utf8JsonText)
            {
                using var doc = JsonDocument.Parse(utf8JsonText);
                return doc.RootElement.Clone();
            }

            return this.JsonElement;
        }
    }
}
