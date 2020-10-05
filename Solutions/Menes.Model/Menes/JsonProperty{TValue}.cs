// <copyright file="JsonProperty{TValue}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Reflection;
    using System.Text;
    using System.Text.Json;
    using Corvus.Extensions;

    /// <summary>
    /// Enables the Json resources to work with strongly-typed properties in situ, whether they
    /// originated from JSON or are a .NET value.
    /// </summary>
    /// <typeparam name="TValue">The type of the <see cref="IJsonValue"/> as a property.</typeparam>
    public readonly struct JsonProperty<TValue>
        where TValue : struct, IJsonValue
    {
        private static readonly Func<JsonElement, TValue> ValueFactory = GetValueFactory();
        private static readonly Func<JsonElement, bool, bool> IsValueConvertibleFrom = GetIsValueConvertibleFrom();

        private readonly JsonProperty jsonProperty;
        private readonly ReadOnlyMemory<byte>? propertyName;
        private readonly IJsonValue? value;
        private readonly JsonElement valueElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonProperty{TValue}"/> struct.
        /// </summary>
        /// <param name="jsonProperty">The json property to wrap.</param>
        public JsonProperty(JsonProperty jsonProperty)
        {
            if (!IsValueConvertibleFrom(jsonProperty.Value, true))
            {
                throw new JsonException($"The element must be a convertible to a {typeof(TValue).FullName}");
            }

            this.jsonProperty = jsonProperty;
            this.propertyName = null;
            this.value = null;
            this.valueElement = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonProperty{TValue}"/> struct.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public JsonProperty(string name, TValue value)
        {
            this.jsonProperty = default;
            this.propertyName = Encoding.UTF8.GetBytes(name);

            if (value.HasJsonElement)
            {
                this.valueElement = value.JsonElement;
                this.value = null;
            }
            else
            {
                this.value = value;
                this.valueElement = default;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonProperty{TValue}"/> struct.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public JsonProperty(ReadOnlyMemory<byte> name, TValue value)
        {
            this.jsonProperty = default;
            this.propertyName = name;
            if (value.HasJsonElement)
            {
                this.valueElement = value.JsonElement;
                this.value = null;
            }
            else
            {
                this.value = value;
                this.valueElement = default;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonProperty{TValue}"/> struct.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public JsonProperty(ReadOnlySpan<char> name, TValue value)
        {
            this.jsonProperty = default;

            Span<byte> output = stackalloc byte[name.Length * 4];
            int bytesWritten = Encoding.UTF8.GetBytes(name, output);
            this.propertyName = output.Slice(0, bytesWritten).ToArray();
            if (value.HasJsonElement)
            {
                this.valueElement = value.JsonElement;
                this.value = null;
            }
            else
            {
                this.value = value;
                this.valueElement = default;
            }
        }

        /// <summary>
        /// Gets the name of this property.
        /// </summary>
        public string Name
        {
            get
            {
                if (this.propertyName is ReadOnlyMemory<byte> pn)
                {
                    return Encoding.UTF8.GetString(pn.Span);
                }

                return this.jsonProperty.Name;
            }
        }

        /// <summary>
        /// Gets the value of this property.
        /// </summary>
        public TValue Value
        {
            get
            {
                if (this.value is TValue value)
                {
                    return value;
                }
                else if (this.valueElement.ValueKind != JsonValueKind.Undefined)
                {
                    return ValueFactory(this.valueElement);
                }

                return ValueFactory(this.jsonProperty.Value);
            }
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="text">The text to match.</param>
        /// <returns><c>True</c> if the text matches the name of the property.</returns>
        public bool NameEquals(string text)
        {
            if (this.propertyName is ReadOnlyMemory<byte> _)
            {
                return this.NameEquals(Encoding.UTF8.GetBytes(text));
            }

            return this.jsonProperty.NameEquals(text);
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="text">The text to match.</param>
        /// <returns><c>True</c> if the text matches the name of the property.</returns>
        public bool NameEquals(ReadOnlySpan<char> text)
        {
            if (this.propertyName is ReadOnlyMemory<byte> pn)
            {
                Span<byte> output = stackalloc byte[text.Length * 4];
                int bytesWritten = Encoding.UTF8.GetBytes(text, output);
                return this.NameEquals(output.Slice(0, bytesWritten));
            }

            return this.jsonProperty.NameEquals(text);
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="utf8Text">The text to match.</param>
        /// <returns><c>True</c> if the text matches the name of the property.</returns>
        public bool NameEquals(ReadOnlySpan<byte> utf8Text)
        {
            if (this.propertyName is ReadOnlyMemory<byte> pn)
            {
                return pn.Span.SequenceEqual(utf8Text);
            }

            return this.jsonProperty.NameEquals(utf8Text);
        }

        /// <summary>
        /// Write the property.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to which to write the property.</param>
        public void Write(Utf8JsonWriter writer)
        {
            if (this.propertyName is ReadOnlyMemory<byte> pn)
            {
                writer.WritePropertyName(pn.Span);
                if (this.valueElement.ValueKind != JsonValueKind.Undefined)
                {
                    this.valueElement.WriteTo(writer);
                }
                else
                {
                    this.value!.WriteTo(writer);
                }
            }
            else
            {
                this.jsonProperty.WriteTo(writer);
            }
        }

        private static Func<JsonElement, TValue> GetValueFactory()
        {
            FieldInfo? fieldInfo = typeof(TValue).GetField("FromJsonElement", BindingFlags.Static | BindingFlags.Public);
            if (fieldInfo is null)
            {
                throw new Exception($"The value type {typeof(TValue).FullName} must provide a static public field: 'Func<JsonElement, TValue> FromJsonElement'");
            }

            return CastTo<Func<JsonElement, TValue>>.From(fieldInfo.GetValue(null));
        }

        private static Func<JsonElement, bool, bool> GetIsValueConvertibleFrom()
        {
            MethodInfo? method = typeof(TValue).GetMethod("IsConvertibleFrom", BindingFlags.Static | BindingFlags.Public);

            if (method is null)
            {
                throw new Exception($"The value type {typeof(TValue).FullName} must provide a static public method: 'bool IsConvertibleFrom(JsonElement jsonElement, bool checkKindOnly)'");
            }

            return (Func<JsonElement, bool, bool>)Delegate.CreateDelegate(typeof(Func<JsonElement, bool, bool>), method);
        }
    }
}
