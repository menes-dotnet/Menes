// <copyright file="JsonValue.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Collections.Concurrent;
    using System.Text.Json;
    using Corvus.Extensions;

    /// <summary>
    /// Utilities for working with <see cref="IJsonValue"/>.
    /// </summary>
    public static class JsonValue
    {
        private static readonly ConcurrentDictionary<Type, object> FactoryCache = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Get a <see cref="IJsonValue"/> constructed from the given <see cref="JsonElement"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IJsonValue"/> to get.</typeparam>
        /// <param name="element">The <see cref="JsonElement"/> around which to create the instance.</param>
        /// <returns>An instance of the given <see cref="IJsonValue"/>.</returns>
        /// <remarks>This may not be a valid instance. Call <see cref="IJsonValue.Validate(in ValidationResult, ValidationLevel, System.Collections.Generic.HashSet{string})"/> to determine whether it is or not, after construction.</remarks>
        public static T As<T>(this JsonElement element)
            where T : struct, IJsonValue
        {
            Func<JsonElement, T> func = CastTo<Func<JsonElement, T>>.From(FactoryCache.GetOrAdd(typeof(T), t => t.GetField("FromJsonElement").GetValue(null)));
            return func(element);
        }

        /// <summary>
        /// Takes an <see cref="IJsonValue"/>, and collapses it to a backing <see cref="JsonElement"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IJsonValue"/>.</typeparam>
        /// <param name="value">The value to flatten into its <see cref="JsonElement"/> backing.</param>
        /// <returns>An instance of the <see cref="IJsonValue"/> flattened to a <see cref="JsonElement"/>.</returns>
        /// <remarks>This is helpful if you are going to carry out multiple operations which are more efficient against a <see cref="JsonElement"/>
        /// representation, rather than a mixed CLR/Json set of types.</remarks>
        public static T FlattenToJsonElementBacking<T>(this T value)
            where T : struct, IJsonValue
        {
            if (value.IsNull)
            {
                return value;
            }

            if (value.IsUndefined)
            {
                return value;
            }

            if (value.HasJsonElement)
            {
                return value;
            }

            var abw = new ArrayBufferWriter<byte>();
            using var utfw = new Utf8JsonWriter(abw);
            value.WriteTo(utfw);
            utfw.Flush();
            var reader = new Utf8JsonReader(abw.WrittenMemory.Span);
            using var document = JsonDocument.ParseValue(ref reader);
            return document.RootElement.Clone().As<T>();
        }
    }
}
