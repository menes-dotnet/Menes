// <copyright file="JsonAny.cs" company="Endjin Limited">
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
    public readonly struct JsonAny : IJsonValue, IJsonObject, IJsonArray
    {
        /// <summary>
        /// The null value.
        /// </summary>
        public static readonly JsonAny Null = default;

        private readonly IJsonValue? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonAny"/> struct.
        /// </summary>
        /// <param name="jsonElement">The backing json element.</param>
        public JsonAny(JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonAny"/> struct.
        /// </summary>
        /// <param name="jsonText">The JSON text fragment from which to construct this element.</param>
        public JsonAny(string jsonText)
        {
            using var document = JsonDocument.Parse(jsonText);
            this.JsonElement = document.RootElement.Clone();
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonAny"/> struct.
        /// </summary>
        /// <param name="value">The <see cref="IJsonValue"/> from which this JsonAny is constructed.</param>
        private JsonAny(IJsonValue value)
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
        /// Creates an instance of a <see cref="JsonAny"/>, avoiding boxing if possible.
        /// </summary>
        /// <typeparam name="T">The type from which to create a <see cref="JsonAny"/>.</typeparam>
        /// <param name="value">The value from which to create a <see cref="JsonAny"/>.</param>
        /// <returns>A <see cref="JsonAny"/> constructed from the given value.</returns>
        public static JsonAny From<T>(T value)
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonAny))
            {
                return CastTo<JsonAny>.From(value);
            }
            else if (value.HasJsonElement)
            {
                return new JsonAny(value.JsonElement);
            }
            else if (value.IsNull)
            {
                return default;
            }
            else
            {
                // This boxes the value through the interface.
                return new JsonAny(value);
            }
        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<char> propertyName)
        {
            if (!this.IsObject)
            {
                return false;
            }

            if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
            {
                return true;
            }
            else if (this.value is IJsonObject jobject)
            {
                return jobject.HasProperty(propertyName);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(string propertyName)
        {
            if (!this.IsObject)
            {
                return false;
            }

            if (this.HasJsonElement && this.JsonElement.TryGetProperty(propertyName, out _))
            {
                return true;
            }
            else if (this.value is IJsonObject jobject)
            {
                return jobject.HasProperty(propertyName);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<byte> utf8PropertyName)
        {
            if (!this.IsObject)
            {
                return false;
            }

            if (this.HasJsonElement && this.JsonElement.TryGetProperty(utf8PropertyName, out _))
            {
                return true;
            }
            else if (this.value is IJsonObject jobject)
            {
                return jobject.HasProperty(utf8PropertyName);
            }

            return false;
        }

        /// <inheritdoc />
        public T As<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonAny))
            {
                return CastTo<T>.From(this);
            }

            if (this.value is T value)
            {
                return value;
            }

            return JsonValue.As<JsonAny, T>(this);
        }

        /// <inheritdoc />
        public bool Is<T>()
            where T : struct, IJsonValue
        {
            if (typeof(T) == typeof(JsonAny))
            {
                return this.Validate(ValidationContext.ValidContext).IsValid;
            }

            if (this.value is T)
            {
                return true;
            }

            return JsonValue.As<JsonAny, T>(this).Validate(ValidationContext.ValidContext).IsValid;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            if (this.IsNull)
            {
                return other.IsNull;
            }

            if (this.IsString)
            {
                return this.As<JsonString>().Equals(other);
            }

            if (this.IsBoolean)
            {
                return this.As<JsonBoolean>().Equals(other);
            }

            if (this.IsInteger)
            {
                return this.As<JsonInteger>().Equals(other);
            }

            if (this.IsNumber)
            {
                return this.As<JsonNumber>().Equals(other);
            }

            if (this.IsArray)
            {
                if (!other.IsArray)
                {
                    return false;
                }

                if (typeof(T) == typeof(JsonAny))
                {
                    return this.ArrayEqual(CastTo<JsonAny>.From(other));
                }

                // Reverse the order so we can get the type matching.
                return other.Equals(this);
            }

            if (this.IsObject)
            {
                if (!other.IsObject)
                {
                    return false;
                }

                if (typeof(T) == typeof(JsonAny))
                {
                    return this.ObjectEqual(CastTo<JsonAny>.From(other));
                }

                return other.Equals(this);
            }

            return false;
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
        public ValidationContext Validate(ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
        {
            if (level == Menes.ValidationLevel.Verbose)
            {
                return validationContext.WithResult(isValid: true, message: "6.1.1.  type is '{}'");
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

        private bool TryGetPropertyAtIndex(int index, out Property<JsonAny> property)
        {
            if (this.value is IJsonObject jsonObject)
            {
                if (jsonObject.TryGetPropertyAtIndex(index, out IProperty prop))
                {
                    property = new Property<JsonAny>(this, prop.NameAsMemory);
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
                        property = new Property<JsonAny>(item);
                        return true;
                    }

                    currentIndex++;
                }
            }

            property = default;
            return false;
        }

        private bool ObjectEqual(JsonAny other)
        {
            MenesPropertyEnumerator firstEnumerator = this.EnumerateObject();

            if (this.PropertyCount != other.PropertyCount)
            {
                return false;
            }

            while (firstEnumerator.MoveNext())
            {
                if (!other.TryGetProperty<JsonAny>(firstEnumerator.Current.NameAsMemory.Span, out JsonAny otherProperty))
                {
                    return false;
                }

                if (!firstEnumerator.Current.Value<JsonAny>().Equals(otherProperty))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ArrayEqual(JsonAny other)
        {
            MenesArrayEnumerator firstEnumerator = this.EnumerateArray();
            MenesArrayEnumerator secondEnumerator = other.EnumerateArray();

            while (firstEnumerator.MoveNext())
            {
                if (!secondEnumerator.MoveNext())
                {
                    // We've run out of items in the second enumerator.
                    return false;
                }

                if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
                {
                    return false;
                }
            }

            // If we have extra items in the second enumerator, return false.
            return !secondEnumerator.MoveNext();
        }

        /// <summary>
        /// An enumerator for the properties in a <see cref="JsonAny"/>.
        /// </summary>
        public struct MenesPropertyEnumerator : IEnumerable<Property<JsonAny>>, IEnumerable, IEnumerator<Property<JsonAny>>, IEnumerator
        {
            private readonly JsonAny instance;
            private readonly bool hasJsonEnumerator;
            private readonly int propertyCount;
            private JsonElement.ObjectEnumerator jsonEnumerator;
            private int index;

            /// <summary>
            /// Initializes a new instance of the <see cref="MenesPropertyEnumerator"/> struct.
            /// </summary>
            /// <param name="instance">The <see cref="JsonAny"/> instance from which to construct the enumerator.</param>
            internal MenesPropertyEnumerator(JsonAny instance)
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
            public Property<JsonAny> Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new Property<JsonAny>(this.jsonEnumerator.Current);
                    }
                    else if (this.index >= 0)
                    {
                        if (this.instance.TryGetPropertyAtIndex(this.index, out Property<JsonAny> result))
                        {
                            return result;
                        }

                        throw new InvalidOperationException("Unable to get the property in the enumeration. The collection has been modified.");
                    }

                    return new Property<JsonAny>(this.instance, default);
                }
            }

            /// <inheritdoc/>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Returns a fresh copy of the enumerator.
            /// </summary>
            /// <returns>An enumerator for the properties in a <see cref="JsonAny"/>.</returns>
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
            IEnumerator<Property<JsonAny>> IEnumerable<Property<JsonAny>>.GetEnumerator()
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
        /// An enumerator for the array values in a <see cref="JsonAny"/>.
        /// </summary>
        public struct MenesArrayEnumerator : IEnumerable<JsonAny>, IEnumerable, IEnumerator<JsonAny>, IEnumerator
        {
            private readonly JsonAny instance;
            private readonly bool hasJsonEnumerator;
            private JsonElement.ArrayEnumerator jsonEnumerator;
            private int index;

            /// <summary>
            /// Initializes a new instance of the <see cref="MenesArrayEnumerator"/> struct.
            /// </summary>
            /// <param name="instance">The <see cref="JsonAny"/> instance for which this is an array enumerator.</param>
            internal MenesArrayEnumerator(JsonAny instance)
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
            public JsonAny Current
            {
                get
                {
                    if (this.hasJsonEnumerator)
                    {
                        return new JsonAny(this.jsonEnumerator.Current);
                    }
                    else if (this.instance.value is IJsonArray array && this.index >= 0 && this.index < array.GetArrayLength())
                    {
                        return array.GetItemAtIndex<JsonAny>(this.index);
                    }

                    return default;
                }
            }

            /// <inheritdoc/>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Returns a fresh copy of the enumerator.
            /// </summary>
            /// <returns>An enumerator for the array values in a <see cref="JsonAny"/>.</returns>
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
            IEnumerator<JsonAny> IEnumerable<JsonAny>.GetEnumerator()
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
