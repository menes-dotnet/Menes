// <copyright file="JsonValue.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text.Json;
    using Corvus.Extensions;
    using NodaTime;

    /// <summary>
    /// Utilities for working with <see cref="IJsonValue"/>.
    /// </summary>
    public static class JsonValue
    {
        private static readonly ConcurrentDictionary<Type, object> FactoryCache = new ConcurrentDictionary<Type, object>();
        private static readonly ConcurrentDictionary<Type, object> JsonElementFactoryCache = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Sets a <see cref="JsonString"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, string value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonString)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonString"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, string value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonString)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonString"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, string value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonString)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonString"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, ReadOnlySpan<char> value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonString)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonString"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonString)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonString"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonString)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonString"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, ReadOnlyMemory<char> value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonString)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonString"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, ReadOnlyMemory<char> value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonString)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonString"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, ReadOnlyMemory<char> value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonString)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, int value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, int value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, int value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, long value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, long value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, long value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, double value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, double value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, double value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, float value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, float value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonNumber"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, float value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonNumber)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonGuid"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, Guid value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonGuid)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonGuid"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, Guid value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonGuid)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonGuid"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, Guid value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonGuid)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonBoolean"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, bool value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonBoolean)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonBoolean"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, bool value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonBoolean)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonBoolean"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, bool value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonBoolean)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonDate"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, LocalDate value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDate)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonDate"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, LocalDate value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDate)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonDate"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, LocalDate value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDate)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonDateTime"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, OffsetDateTime value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDateTime)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonDateTime"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, OffsetDateTime value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDateTime)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonDateTime"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, OffsetDateTime value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDateTime)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonTime"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, OffsetTime value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonTime)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonTime"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, OffsetTime value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonTime)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonTime"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, OffsetTime value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonTime)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonDuration"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, Duration value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDuration)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonDuration"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, Duration value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDuration)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonDuration"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, Duration value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDuration)value);
        }

        /// <summary>
        /// Sets a <see cref="JsonDateTime"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, string propertyName, DateTimeOffset value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDateTime)OffsetDateTime.FromDateTimeOffset(value));
        }

        /// <summary>
        /// Sets a <see cref="JsonDuration"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<byte> propertyName, DateTimeOffset value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDateTime)OffsetDateTime.FromDateTimeOffset(value));
        }

        /// <summary>
        /// Sets a <see cref="JsonDuration"/> value from a raw dotnet type.
        /// </summary>
        /// <typeparam name="T">The type on which to set the property.</typeparam>
        /// <param name="target">The instance on which to set the property.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">The vlaue to set.</param>
        /// <returns>An instance of the type, with the property set.</returns>
        public static T SetProperty<T>(this T target, ReadOnlySpan<char> propertyName, DateTimeOffset value)
            where T : struct, IJsonObject<T>
        {
            return target.SetProperty(propertyName, (JsonDateTime)OffsetDateTime.FromDateTimeOffset(value));
        }

        /// <summary>
        /// Get a <see cref="IJsonValue"/> constructed from the given <see cref="IJsonValue"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of <see cref="IJsonValue"/> to convert from.</typeparam>
        /// <typeparam name="TTarget">The type of <see cref="IJsonValue"/> to get.</typeparam>
        /// <param name="element">The <see cref="JsonElement"/> around which to create the instance.</param>
        /// <returns>An instance of the given <see cref="IJsonValue"/>.</returns>
        /// <remarks>This may not be a valid instance. Call <see cref="IJsonValue.Validate(ValidationResult?, ValidationLevel, System.Collections.Generic.HashSet{string}?, System.Collections.Generic.Stack{string}?, System.Collections.Generic.Stack{string}?)"/> to determine whether it is or not, after construction.</remarks>
        public static TTarget As<TSource, TTarget>(this TSource element)
            where TSource : struct, IJsonValue
            where TTarget : struct, IJsonValue
        {
            if (element.HasJsonElement)
            {
                return element.JsonElement.As<TTarget>();
            }

            // If we're going to JsonAny, use the special constructor
            // and avoid boxing if we are using a JsonElement, or serialization
            // if we are not a JsonElement.
            if (typeof(TTarget) == typeof(JsonAny))
            {
                return CastTo<TTarget>.From(JsonAny.From(element));
            }

            // If we're going to JsonAny, use the special constructor
            // and avoid boxing if we are using a JsonElement, or serialization
            // if we are not a JsonElement.
            if (typeof(TTarget) == typeof(JsonNull))
            {
                return CastTo<TTarget>.From(JsonNull.From(element));
            }

            Func<TSource, TTarget> func = CastTo<Func<TSource, TTarget>>.From(FactoryCache.GetOrAdd(typeof(TTarget), t =>
            {
                Type sourceType = typeof(TSource);

                Type returnType = typeof(TTarget);
                Type[] argumentTypes = new[] { sourceType };

                ConstructorInfo ctor = returnType.GetConstructor(argumentTypes);
                if (ctor == null)
                {
                    return new Func<TSource, TTarget>((TSource source) => FlattenToJsonElementBacking(source).JsonElement.As<TTarget>());
                }

                var dynamic = new DynamicMethod(
                    $"${returnType.Name}_From{sourceType.Name}",
                    returnType,
                    argumentTypes,
                    returnType);
                ILGenerator il = dynamic.GetILGenerator();

                il.DeclareLocal(returnType);
                il.Emit(OpCodes.Ldarg, 0);
                il.Emit(OpCodes.Newobj, ctor);
                il.Emit(OpCodes.Ret);

                return (Func<TSource, TTarget>)dynamic.CreateDelegate(typeof(Func<TSource, TTarget>));
            }));
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

        /// <summary>
        /// Get a <see cref="IJsonValue"/> constructed from the given <see cref="JsonElement"/>.
        /// </summary>
        /// <typeparam name="TTarget">The type of <see cref="IJsonValue"/> to get.</typeparam>
        /// <param name="element">The <see cref="JsonElement"/> around which to create the instance.</param>
        /// <returns>An instance of the given <see cref="IJsonValue"/>.</returns>
        /// <remarks>This may not be a valid instance. Call <see cref="IJsonValue.Validate(ValidationResult?, ValidationLevel, System.Collections.Generic.HashSet{string}?, System.Collections.Generic.Stack{string}?, System.Collections.Generic.Stack{string}?)"/> to determine whether it is or not, after construction.</remarks>
        public static TTarget As<TTarget>(this JsonElement element)
            where TTarget : struct, IJsonValue
        {
            Func<JsonElement, TTarget> func = CastTo<Func<JsonElement, TTarget>>.From(JsonElementFactoryCache.GetOrAdd(typeof(TTarget), t =>
            {
                Type returnType = typeof(TTarget);
                Type[] argumentTypes = new[] { typeof(JsonElement) };
                ConstructorInfo ctor = returnType.GetConstructor(argumentTypes);
                if (ctor == null)
                {
                    throw new MissingMethodException("There is no constructor that takes a JsonElement for this IJsonValue.");
                }

                var dynamic = new DynamicMethod(
                    $"${returnType.Name}_FromJsonElement",
                    returnType,
                    argumentTypes,
                    returnType);
                ILGenerator il = dynamic.GetILGenerator();

                il.DeclareLocal(returnType);
                il.Emit(OpCodes.Ldarg, 0);
                il.Emit(OpCodes.Newobj, ctor);
                il.Emit(OpCodes.Ret);

                return (Func<JsonElement, TTarget>)dynamic.CreateDelegate(typeof(Func<JsonElement, TTarget>));
            }));
            return func(element);
        }
    }
}
