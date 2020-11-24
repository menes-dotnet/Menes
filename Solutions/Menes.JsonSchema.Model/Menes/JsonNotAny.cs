// <copyright file="JsonNotAny.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.Json;
    using Corvus.Extensions;

    /// <summary>
    /// Represents the {}/true json type.
    /// </summary>
    public readonly struct JsonNotAny : IJsonValue, IJsonObject, IJsonArray
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonNotAny Null = default;

        private readonly IJsonValue? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNotAny"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonNotAny(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNotAny"/> struct.
        /// </summary>
        /// <param name="value">The <see cref="IJsonValue"/> from which this JsonNotAny is constructed.</param>
        private JsonNotAny(IJsonValue value)
        {
            this.value = value;
            this.JsonElement = default;
        }

        /// <inheritdoc />
        public bool IsUndefined => this.JsonElement.ValueKind == JsonValueKind.Undefined && (this.value is null || this.value.IsUndefined);

        /// <inheritdoc />
        public bool IsNull => (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null) && (this.value is null || this.value.IsNull);

        /// <inheritdoc />
        public bool IsNumber => this.JsonElement.ValueKind == JsonValueKind.Number || (this.value is not null && this.value.IsNumber);

        /// <inheritdoc />
        public bool IsInteger => this.JsonElement.ValueKind == JsonValueKind.Number || (this.value is not null && this.value.IsInteger);

        /// <inheritdoc />
        public bool IsString => this.JsonElement.ValueKind == JsonValueKind.String || (this.value is not null && this.value.IsString);

        /// <inheritdoc />
        public bool IsObject => this.JsonElement.ValueKind == JsonValueKind.Object || (this.value is not null && this.value.IsObject);

        /// <inheritdoc />
        public bool IsArray => this.JsonElement.ValueKind == JsonValueKind.Array || (this.value is not null && this.value.IsArray);

        /// <inheritdoc />
        public bool IsBoolean => this.JsonElement.ValueKind == JsonValueKind.True || this.JsonElement.ValueKind == JsonValueKind.False;

        /// <inheritdoc />
        public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

        /// <inheritdoc />
        public JsonElement JsonElement { get; }

        /// <inheritdoc />
        public int PropertyCount
        {
            get
            {
                if (this.HasJsonElement)
                {
                    int jsonPropertyIndex = 0;
                    foreach (JsonProperty property in this.JsonElement.EnumerateObject())
                    {
                        jsonPropertyIndex++;
                    }

                    return jsonPropertyIndex;
                }
                else if (this.value is IJsonObject jobject)
                {
                    return jobject.PropertyCount;
                }

                return 0;
            }
        }

        /// <summary>
        /// Creates an instance of a <see cref="JsonNotAny"/>, avoiding boxing if possible.
        /// </summary>
        /// <typeparam name="T">The type from which to create a <see cref="JsonNotAny"/>.</typeparam>
        /// <param name="value">The value from which to create a <see cref="JsonNotAny"/>.</param>
        /// <returns>A <see cref="JsonNotAny"/> constructed from the given value.</returns>
        public static JsonNotAny From<T>(T value)
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonNotAny))
            {
                return CastTo<JsonNotAny>.From(value);
            }
            else if (value.HasJsonElement)
            {
                return new JsonNotAny(value.JsonElement);
            }
            else if (value.IsNull)
            {
                return default;
            }
            else
            {
                // This boxes the value through the interface.
                return new JsonNotAny(value);
            }
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonNotAny))
            {
                return CastTo<T>.From(this);
            }

            if (this.value is T value)
            {
                return value;
            }

            return JsonValue.As<JsonNotAny, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonNotAny))
            {
                return this.Validate().Valid;
            }

            if (this.value is T)
            {
                return true;
            }

            return JsonValue.As<JsonNotAny, T>(this).Validate(ValidationResult.ValidResult, ValidationLevel.Flag).Valid;
        }

        /// <summary>
        /// Enumerate the array.
        /// </summary>
        /// <returns>An array enumerator.</returns>
        public MenesArrayEnumerator EnumerateArray()
        {
            return new MenesArrayEnumerator(this);
        }

        /// <summary>
        /// Enumerate the properties in the object.
        /// </summary>
        /// <returns>The object enumerator.</returns>
        public MenesPropertyEnumerator EnumerateObject()
        {
            return new MenesPropertyEnumerator(this);
        }

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
        public bool TryGetProperty<T>(ReadOnlySpan<char> propertyName, out T property)
            where T : struct, IJsonValue
        {
            if (!this.IsObject)
            {
                property = default;
                return false;
            }

            if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out JsonElement value))
            {
                property = value.As<T>();
                return true;
            }
            else if (this.value is IJsonObject jobject)
            {
                return jobject.TryGetProperty<T>(propertyName, out property);
            }

            property = default;
            return false;
        }

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
        public bool TryGetProperty<T>(string propertyName, out T property)
            where T : struct, IJsonValue
        {
            if (!this.IsObject)
            {
                property = default;
                return false;
            }

            if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out JsonElement value))
            {
                property = value.As<T>();
                return true;
            }
            else if (this.value is IJsonObject jobject)
            {
                return jobject.TryGetProperty<T>(propertyName, out property);
            }

            property = default;
            return false;
        }

        /// <summary>
        /// Try to get a named property.
        /// </summary>
        /// <typeparam name="T">The type of the property to get.</typeparam>
        /// <param name="utf8PropertyName">The utf8 encoded name of the property.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns><c>True</c> if there was a property with the given name.</returns>
        public bool TryGetProperty<T>(ReadOnlySpan<byte> utf8PropertyName, out T property)
            where T : struct, IJsonValue
        {
            if (!this.IsObject)
            {
                property = default;
                return false;
            }

            if (this.HasJsonElement && this.JsonElement.TryGetProperty(utf8PropertyName, out JsonElement value))
            {
                property = value.As<T>();
                return true;
            }
            else if (this.value is IJsonObject jobject)
            {
                return jobject.TryGetProperty<T>(utf8PropertyName, out property);
            }

            property = default;
            return false;
        }

        /// <inheritdoc />
        public ValidationResult Validate(ValidationResult? validationResult = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, Stack<string>? absoluteKeywordLocation = null, Stack<string>? instanceLocation = null)
        {
            ValidationResult result = validationResult ?? ValidationResult.InvalidResult;

            if (level >= ValidationLevel.Basic)
            {
                string? il = null;
                string? akl = null;

                instanceLocation?.TryPeek(out il);
                absoluteKeywordLocation?.TryPeek(out akl);

                result.AddResult(valid: false, message: "6.1.1.  type is 'false'", instanceLocation: il, absoluteKeywordLocation: akl);
            }
            else
            {
                result.SetValid(false);
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

            if (this.value is not null)
            {
                this.value.WriteTo(writer);
                return;
            }

            writer.WriteNullValue();
        }

        /// <inheritdoc/>
        public IEnumerator GetEnumerator()
        {
            if (this.IsObject)
            {
                return this.EnumerateObject();
            }

            if (this.IsArray)
            {
                return this.EnumerateArray();
            }

            throw new InvalidOperationException("Cannot enumerate a non array or object type.");
        }

        /// <inheritdoc/>
        public int GetArrayLength()
        {
            if (this.value is IJsonArray array)
            {
                return array.GetArrayLength();
            }

            if (this.JsonElement.ValueKind == JsonValueKind.Array)
            {
                return this.JsonElement.GetArrayLength();
            }

            return 0;
        }

        /// <inheritdoc/>
        public T GetItemAtIndex<T>(int index)
            where T : struct, IJsonValue
        {
            if (this.value is IJsonArray array)
            {
                return array.GetItemAtIndex<T>(index);
            }

            if (this.JsonElement.ValueKind == JsonValueKind.Array)
            {
                int currentIndex = 0;
                foreach (JsonElement item in this.JsonElement.EnumerateArray())
                {
                    if (currentIndex == index)
                    {
                        return item.As<T>();
                    }

                    currentIndex++;
                }

                throw new IndexOutOfRangeException();
            }

            return default;
        }

        /// <inheritdoc/>
        public bool TryGetPropertyAtIndex(int index, out IProperty property)
        {
            return this.TryGetPropertyAtIndex(index, out property);
        }

        private bool TryGetPropertyAtIndex(int index, out Property<JsonNotAny> property)
        {
            if (this.value is IJsonObject jsonObject)
            {
                if (jsonObject.TryGetPropertyAtIndex(index, out IProperty prop))
                {
                    property = new Property<JsonNotAny>(this, prop.NameAsMemory);
                    return true;
                }
            }
            else if (this.HasJsonElement && this.JsonElement.ValueKind == JsonValueKind.Object)
            {
                int currentIndex = 0;
                foreach (JsonProperty item in this.JsonElement.EnumerateObject())
                {
                    if (currentIndex == index)
                    {
                        property = new Property<JsonNotAny>(item);
                        return true;
                    }

                    currentIndex++;
                }
            }

            property = default;
            return false;
        }

        /// <summary>
        /// An enumerator for the properties in a <see cref="JsonNotAny"/>.
        /// </summary>
        public struct MenesPropertyEnumerator : IEnumerable<Property<JsonNotAny>>, IEnumerable, IEnumerator<Property<JsonNotAny>>, IEnumerator
        {
            private JsonNotAny instance;
            private JsonElement.ObjectEnumerator jsonEnumerator;
            private bool hasJsonEnumerator;
            private int index;
            private int propertyCount;

            /// <summary>
            /// Initializes a new instance of the <see cref="MenesPropertyEnumerator"/> struct.
            /// </summary>
            /// <param name="instance">The <see cref="JsonNotAny"/> instance from which to construct the enumerator.</param>
            internal MenesPropertyEnumerator(JsonNotAny instance)
            {
                this.instance = instance;
                this.propertyCount = instance.PropertyCount;
                if (this.instance.HasJsonElement)
                {
                    this.index = -2;
                    this.hasJsonEnumerator = true;
                    this.jsonEnumerator = this.instance.JsonElement.EnumerateObject();
                }
                else
                {
                    this.index = -1;
                    this.hasJsonEnumerator = false;
                    this.jsonEnumerator = default;
                }
            }

            /// <inheritdoc/>
            public Property<JsonNotAny> Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new Property<JsonNotAny>(this.jsonEnumerator.Current);
                    }
                    else if (this.index >= 0)
                    {
                        if (this.instance.TryGetPropertyAtIndex(this.index, out Property<JsonNotAny> result))
                        {
                            return result;
                        }

                        throw new InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                    }

                    return new Property<JsonNotAny>(this.instance, default);
                }
            }

            /// <inheritdoc/>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Returns a fresh copy of the enumerator.
            /// </summary>
            /// <returns>An enumerator for the properties in a <see cref="JsonNotAny"/>.</returns>
            public MenesPropertyEnumerator GetEnumerator()
            {
                MenesPropertyEnumerator result = this;
                result.Reset();
                return result;
            }

            /// <inheritdoc/>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            /// <inheritdoc/>
            IEnumerator<Property<JsonNotAny>> IEnumerable<Property<JsonNotAny>>.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            /// <inheritdoc/>
            public void Dispose()
            {
                if (this.hasJsonEnumerator)
                {
                    this.jsonEnumerator.Dispose();
                }
            }

            /// <inheritdoc/>
            public void Reset()
            {
                if (this.hasJsonEnumerator)
                {
                    this.jsonEnumerator.Reset();
                }
            }

            /// <inheritdoc/>
            public bool MoveNext()
            {
                if (this.hasJsonEnumerator)
                {
                    return this.jsonEnumerator.MoveNext();
                }
                else
                {
                    if (this.index + 1 < this.propertyCount)
                    {
                        this.index++;
                        return true;
                    }

                    return false;
                }
            }
        }

        /// <summary>
        /// An enumerator for the array values in a <see cref="JsonNotAny"/>.
        /// </summary>
        public struct MenesArrayEnumerator : IEnumerable<JsonNotAny>, IEnumerable, IEnumerator<JsonNotAny>, IEnumerator
        {
            private JsonNotAny instance;
            private JsonElement.ArrayEnumerator jsonEnumerator;
            private bool hasJsonEnumerator;
            private int index;

            /// <summary>
            /// Initializes a new instance of the <see cref="MenesArrayEnumerator"/> struct.
            /// </summary>
            /// <param name="instance">The <see cref="JsonNotAny"/> instance for which this is an array enumerator.</param>
            internal MenesArrayEnumerator(JsonNotAny instance)
            {
                this.instance = instance;
                if (this.instance.HasJsonElement)
                {
                    this.index = -2;
                    this.hasJsonEnumerator = true;
                    this.jsonEnumerator = this.instance.JsonElement.EnumerateArray();
                }
                else
                {
                    this.index = -1;
                    this.hasJsonEnumerator = false;
                    this.jsonEnumerator = default;
                }
            }

            /// <inheritdoc/>
            public JsonNotAny Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new JsonNotAny(this.jsonEnumerator.Current);
                    }
                    else if (this.instance.value is IJsonArray array && this.index >= 0 && this.index < array.GetArrayLength())
                    {
                        return array.GetItemAtIndex<JsonNotAny>(this.index);
                    }

                    return default;
                }
            }

            /// <inheritdoc/>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Returns a fresh copy of the enumerator.
            /// </summary>
            /// <returns>An enumerator for the array values in a <see cref="JsonNotAny"/>.</returns>
            public MenesArrayEnumerator GetEnumerator()
            {
                MenesArrayEnumerator result = this;
                result.Reset();
                return result;
            }

            /// <inheritdoc/>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            /// <inheritdoc/>
            IEnumerator<JsonNotAny> IEnumerable<JsonNotAny>.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            /// <inheritdoc/>
            public void Dispose()
            {
                if (this.hasJsonEnumerator)
                {
                    this.jsonEnumerator.Dispose();
                }
            }

            /// <inheritdoc/>
            public void Reset()
            {
                if (this.hasJsonEnumerator)
                {
                    this.jsonEnumerator.Reset();
                }
                else
                {
                    this.index = -1;
                }
            }

            /// <inheritdoc/>
            public bool MoveNext()
            {
                if (this.hasJsonEnumerator)
                {
                    return this.jsonEnumerator.MoveNext();
                }
                else if (this.instance.value is IJsonArray array && this.index + 1 < array.GetArrayLength())
                {
                    this.index++;
                    return true;
                }

                return false;
            }
        }
    }
}
