// <copyright file="Property{T}.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json
{
    using System;
    using System.Text.Json;

    /// <summary>
    /// A property on a <see cref="JsonObject"/>.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    public readonly struct Property<T>
        where T : struct, IJsonValue
    {
        private readonly JsonProperty? jsonProperty;
        private readonly JsonEncodedText? name;
        private readonly T? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> struct.
        /// </summary>
        /// <param name="jsonProperty">The JSON property over which to construct this instance.</param>
        public Property(JsonProperty jsonProperty)
        {
            this.jsonProperty = jsonProperty;
            this.name = default;
            this.value = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> struct.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The property value.</param>
        public Property(JsonEncodedText name, T value)
        {
            this.jsonProperty = default;
            this.name = name;
            this.value = value;
        }

        /// <summary>
        /// Gets the value kind of the property value.
        /// </summary>
        public JsonValueKind ValueKind
        {
            get
            {
                if (this.jsonProperty is JsonProperty jsonProperty)
                {
                    return jsonProperty.Value.ValueKind;
                }

                if (this.value is T value)
                {
                    return value.ValueKind;
                }

                return JsonValueKind.Undefined;
            }
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public JsonEncodedText NameAsJsonEncodedText
        {
            get
            {
                if (this.jsonProperty is JsonProperty jsonProperty)
                {
                    return JsonEncodedText.Encode(jsonProperty.Name);
                }

                if (this.name is JsonEncodedText encodedName)
                {
                    return encodedName;
                }

                return default;
            }
        }

        /// <summary>
        /// Gets the value of the property.
        /// </summary>
        public T Value
        {
            get
            {
                if (this.jsonProperty is JsonProperty jsonProperty)
                {
                    return new JsonAny(jsonProperty.Value).As<T>();
                }

                if (this.value is T value)
                {
                    return value;
                }

                return default;
            }
        }

        /// <summary>
        /// Gets the name of the property as a string.
        /// </summary>
        public string Name
        {
            get
            {
                if (this.jsonProperty is JsonProperty jsonProperty)
                {
                    return jsonProperty.Name;
                }

                if (this.name is JsonEncodedText encodedName)
                {
                    return encodedName.ToString();
                }

                throw new InvalidOperationException("The property does not have a name.");
            }
        }

        /// <summary>
        /// Compares the specified UTF-8 encoded text to the name of this property.
        /// </summary>
        /// <param name="utf8Name">The name to match.</param>
        /// <returns><c>True</c> if the name matches.</returns>
        public bool NameEquals(ReadOnlySpan<byte> utf8Name)
        {
            if (this.jsonProperty is JsonProperty jsonProperty)
            {
                return jsonProperty.NameEquals(utf8Name);
            }

            if (this.name is JsonEncodedText encodedName)
            {
                return encodedName.Equals(JsonEncodedText.Encode(utf8Name));
            }

            return false;
        }

        /// <summary>
        /// Compares the specified text to the name of this property.
        /// </summary>
        /// <param name="name">The name to match.</param>
        /// <returns><c>True</c> if the name matches.</returns>
        public bool NameEquals(ReadOnlySpan<char> name)
        {
            if (this.jsonProperty is JsonProperty jsonProperty)
            {
                return jsonProperty.NameEquals(name);
            }

            if (this.name is JsonEncodedText encodedName)
            {
                return encodedName.Equals(JsonEncodedText.Encode(name));
            }

            return false;
        }

        /// <summary>
        /// Compares the specified text to the name of this property.
        /// </summary>
        /// <param name="name">The name to match.</param>
        /// <returns><c>True</c> if the name matches.</returns>
        public bool NameEquals(string name)
        {
            if (this.jsonProperty is JsonProperty jsonProperty)
            {
                return jsonProperty.NameEquals(name);
            }

            if (this.name is JsonEncodedText encodedName)
            {
                return encodedName.Equals(JsonEncodedText.Encode(name));
            }

            return false;
        }

        /// <summary>
        /// Compares the specified text to the name of this property.
        /// </summary>
        /// <param name="name">The name to match.</param>
        /// <returns><c>True</c> if the name matches.</returns>
        public bool NameEquals(JsonEncodedText name)
        {
            if (this.jsonProperty is JsonProperty jsonProperty)
            {
                return jsonProperty.NameEquals(JsonReaderHelper.GetUnescapedSpan(name.EncodedUtf8Bytes, 0));
            }

            if (this.name is JsonEncodedText encodedName)
            {
                return encodedName.Equals(name);
            }

            return false;
        }
    }
}
