// <copyright file="JsonValue.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Buffers;
    using System.Collections.Concurrent;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text.Json;
    using Corvus.Extensions;

    /// <summary>
    /// Utilities for working with <see cref="IJsonValue"/>.
    /// </summary>
    public static class JsonValue
    {
        private static readonly ConcurrentDictionary<Type, object> FactoryCache = new ConcurrentDictionary<Type, object>();
        private static readonly ConcurrentDictionary<Type, object> JsonElementFactoryCache = new ConcurrentDictionary<Type, object>();

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
            // If we're going to JsonAny, use the special constructor
            // and avoid boxing if we are using a JsonElement, or serialization
            // if we are not a JsonElement.
            if (typeof(TTarget) == typeof(JsonAny))
            {
                return CastTo<TTarget>.From(JsonAny.From(element));
            }

            Func<TSource, TTarget> func = CastTo<Func<TSource, TTarget>>.From(FactoryCache.GetOrAdd(typeof(TTarget), t =>
            {
                Type returnType = typeof(TTarget);
                Type[] argumentTypes = new[] { typeof(TSource) };
                ConstructorInfo ctor = returnType.GetConstructor(argumentTypes);
                if (ctor == null)
                {
                    return new Func<TSource, TTarget>((TSource source) => FlattenToJsonElementBacking(source).JsonElement.As<TTarget>());
                }

                var dynamic = new DynamicMethod(
                    $"${returnType.Name}_From{typeof(TSource).Name}",
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
