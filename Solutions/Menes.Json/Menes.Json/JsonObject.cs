// <copyright file="JsonObject.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.Text.Json;

    /// <summary>
    /// A JSON object.
    /// </summary>
    public readonly struct JsonObject : IJsonObject<JsonObject>, IEquatable<JsonObject>
    {
        private readonly JsonElement jsonElement;
        private readonly ImmutableDictionary<JsonEncodedText, JsonAny>? properties;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonObject"/> struct.
        /// </summary>
        /// <param name="jsonElement">The JSON element from which to construct the object.</param>
        public JsonObject(JsonElement jsonElement)
        {
            this.jsonElement = jsonElement;
            this.properties = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonObject"/> struct.
        /// </summary>
        /// <param name="properties">An immutable dictionary of properties for the object.</param>
        public JsonObject(ImmutableDictionary<JsonEncodedText, JsonAny> properties)
        {
            this.jsonElement = default;
            this.properties = properties;
        }

        /// <summary>
        /// Gets the <see cref="JsonValueKind"/>.
        /// </summary>
        public JsonValueKind ValueKind
        {
            get
            {
                if (this.properties is not null)
                {
                    return JsonValueKind.Object;
                }

                return this.jsonElement.ValueKind;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is backed by a <see cref="JsonElement"/>.
        /// </summary>
        public bool HasJsonElement => this.properties is null;

        /// <summary>
        /// Gets the backing <see cref="JsonElement"/>.
        /// </summary>
        public JsonElement AsJsonElement
        {
            get
            {
                if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
                {
                    return PropertiesToJsonElement(properties);
                }

                return this.jsonElement;
            }
        }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
                return new JsonAny(this);
            }
        }

        /// <summary>
        /// Gets the object as a property dictionary.
        /// </summary>
        public ImmutableDictionary<JsonEncodedText, JsonAny> AsPropertyDictionary
        {
            get
            {
                if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
                {
                    return properties;
                }

                if (this.jsonElement.ValueKind == JsonValueKind.Object)
                {
                    ImmutableDictionary<JsonEncodedText, JsonAny>.Builder builder = ImmutableDictionary.CreateBuilder<JsonEncodedText, JsonAny>();
                    foreach (JsonProperty property in this.jsonElement.EnumerateObject())
                    {
                        builder.Add(JsonEncodedText.Encode(property.Name), new JsonAny(property.Value));
                    }

                    return builder.ToImmutable();
                }

                return ImmutableDictionary<JsonEncodedText, JsonAny>.Empty;
            }
        }

        /// <summary>
        /// Implicit conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(JsonObject value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Implicit conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonObject(JsonAny value)
        {
            return value.AsObject;
        }

        /// <summary>
        /// Write a property dictionary to a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="properties">The property dictionary to write.</param>
        /// <returns>A JsonElement serialized from the properties.</returns>
        public static JsonElement PropertiesToJsonElement(ImmutableDictionary<JsonEncodedText, JsonAny> properties)
        {
            var abw = new ArrayBufferWriter<byte>();
            using var writer = new Utf8JsonWriter(abw);
            WriteProperties(properties, writer);
            writer.Flush();
            var reader = new Utf8JsonReader(abw.WrittenSpan);
            using var document = JsonDocument.ParseValue(ref reader);
            return document.RootElement.Clone();
        }

        /// <summary>
        /// Writes a property dictionary to a JSON writer.
        /// </summary>
        /// <param name="properties">The property dictionary to write.</param>
        /// <param name="writer">The writer to which to write the object.</param>
        public static void WriteProperties(ImmutableDictionary<JsonEncodedText, JsonAny> properties, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            foreach (KeyValuePair<JsonEncodedText, JsonAny> property in properties)
            {
                writer.WritePropertyName(property.Key);
                property.Value.WriteTo(writer);
            }

            writer.WriteEndObject();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;

            return Json.Validate.TypeObject(this.ValueKind, result, level);
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.As<JsonObject, T>();
        }

        /// <summary>
        /// Writes the object to the <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                WriteProperties(properties, writer);
            }
            else
            {
                this.jsonElement.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        public JsonObjectEnumerator EnumerateObject()
        {
            if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return new JsonObjectEnumerator(properties);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.Object)
            {
                return new JsonObjectEnumerator(this.jsonElement);
            }

            return default;
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            if (other.ValueKind == JsonValueKind.Object)
            {
                return this.Equals(other.AsObject());
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(JsonObject other)
        {
            if (other.ValueKind != this.ValueKind || this.ValueKind != JsonValueKind.Object)
            {
                return false;
            }

            int count = 0;
            foreach (Property property in this.EnumerateObject())
            {
                if (!other.TryGetProperty(property.NameAsJsonEncodedText, out JsonAny value) || !property.Value.Equals(value))
                {
                    return false;
                }

                count++;
            }

            int otherCount = 0;
            foreach (Property otherProperty in other.EnumerateObject())
            {
                otherCount++;
            }

            return count == otherCount;
        }

        /// <inheritdoc/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "Stylecop issue")]
        public bool TryGetProperty(JsonEncodedText name, out JsonAny value)
        {
            if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(name, out value);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.Object)
            {
                ReadOnlySpan<byte> utf8Source = name.EncodedUtf8Bytes;

                int idx = utf8Source.IndexOf(JsonConstants.BackSlash);

                ReadOnlySpan<byte> utf8Unescaped;
                if (idx >= 0)
                {
                    utf8Unescaped = JsonReaderHelper.GetUnescapedSpan(utf8Source, idx);
                }
                else
                {
                    utf8Unescaped = utf8Source;
                }

                if (this.jsonElement.TryGetProperty(utf8Unescaped, out JsonElement jsonElement))
                {
                    value = new JsonAny(jsonElement);
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <inheritdoc/>
        public bool TryGetProperty(string name, out JsonAny value)
        {
            if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(JsonEncodedText.Encode(name), out value);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.Object)
            {
                if (this.jsonElement.TryGetProperty(name, out JsonElement jsonElement))
                {
                    value = new JsonAny(jsonElement);
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <inheritdoc/>
        public bool TryGetProperty(ReadOnlySpan<char> name, out JsonAny value)
        {
            if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(JsonEncodedText.Encode(name), out value);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.Object)
            {
                if (this.jsonElement.TryGetProperty(name, out JsonElement jsonElement))
                {
                    value = new JsonAny(jsonElement);
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <inheritdoc/>
        public bool TryGetProperty(ReadOnlySpan<byte> utf8name, out JsonAny value)
        {
            if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(JsonEncodedText.Encode(utf8name), out value);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.Object)
            {
                if (this.jsonElement.TryGetProperty(utf8name, out JsonElement jsonElement))
                {
                    value = new JsonAny(jsonElement);
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(JsonEncodedText name)
        {
            if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(name, out _);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElement.TryGetProperty(name.ToString(), out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(string name)
        {
            if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(JsonEncodedText.Encode(name), out _);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElement.TryGetProperty(name, out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<char> name)
        {
            if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(JsonEncodedText.Encode(name), out _);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElement.TryGetProperty(name, out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<byte> utf8name)
        {
            if (this.properties is ImmutableDictionary<JsonEncodedText, JsonAny> properties)
            {
                return properties.TryGetValue(JsonEncodedText.Encode(utf8name), out _);
            }

            if (this.jsonElement.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElement.TryGetProperty(utf8name, out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public JsonObject SetProperty<TValue>(JsonEncodedText name, TValue value)
            where TValue : IJsonValue
        {
            return new JsonObject(this.AsPropertyDictionary.SetItem(name, value.AsAny));
        }

        /// <inheritdoc/>
        public JsonObject SetProperty<TValue>(string name, TValue value)
            where TValue : IJsonValue
        {
            return this.SetProperty(JsonEncodedText.Encode(name), value);
        }

        /// <inheritdoc/>
        public JsonObject SetProperty<TValue>(ReadOnlySpan<char> name, TValue value)
            where TValue : IJsonValue
        {
            return this.SetProperty(JsonEncodedText.Encode(name), value);
        }

        /// <inheritdoc/>
        public JsonObject SetProperty<TValue>(ReadOnlySpan<byte> utf8Name, TValue value)
            where TValue : IJsonValue
        {
            return this.SetProperty(JsonEncodedText.Encode(utf8Name), value);
        }

        /// <inheritdoc/>
        public JsonObject RemoveProperty(JsonEncodedText name)
        {
            return new JsonObject(this.AsPropertyDictionary.Remove(name));
        }

        /// <inheritdoc/>
        public JsonObject RemoveProperty(string name)
        {
            return this.RemoveProperty(JsonEncodedText.Encode(name));
        }

        /// <inheritdoc/>
        public JsonObject RemoveProperty(ReadOnlySpan<char> name)
        {
            return this.RemoveProperty(JsonEncodedText.Encode(name));
        }

        /// <inheritdoc/>
        public JsonObject RemoveProperty(ReadOnlySpan<byte> utf8Name)
        {
            return this.RemoveProperty(JsonEncodedText.Encode(utf8Name));
        }
    }
}
