// <copyright file="AdditionalProperty.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// A property accessor using a <see cref="JsonValueBacking"/>.
    /// </summary>
    public readonly struct AdditionalProperty
    {
        private readonly ReadOnlyMemory<char> name;
        private readonly JsonValueBacking value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Property{T}"/> struct.
        /// </summary>
        /// <param name="name">the name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public AdditionalProperty(ReadOnlyMemory<char> name, in JsonValueBacking value)
        {
            this.name = name;
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Property{T}"/> struct.
        /// </summary>
        /// <param name="name">the name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public AdditionalProperty(string name, in JsonValueBacking value)
        {
            this.name = name.AsMemory();
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Property{T}"/> struct.
        /// </summary>
        /// <param name="name">the name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public AdditionalProperty(ReadOnlySpan<char> name, in JsonValueBacking value)
        {
            this.name = name.ToArray();
            this.value = value;
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string Name => this.name.ToString();

        /// <summary>
        /// Gets the property name as a <see cref="ReadOnlyMemory{T}"/> of <see cref="char"/>.
        /// </summary>
        public ReadOnlyMemory<char> NameAsMemory => this.name;

        /// <summary>
        /// Gets the value of the property as the given type.
        /// </summary>
        /// <typeparam name="TValue">The <see cref="IJsonValue"/> type to return.</typeparam>
        /// <returns>The value of the backing type.</returns>
        public TValue? Value<TValue>()
            where TValue : struct, IJsonValue
        {
            return this.value.As<TValue>();
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <returns><c>true</c> if the names are equal.</returns>
        public bool NameEquals(string name)
        {
            return this.name.Span.SequenceEqual(name.AsSpan());
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <returns><c>true</c> if the names are equal.</returns>
        public bool NameEquals(ReadOnlySpan<char> name)
        {
            return this.name.Span.SequenceEqual(name);
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="utf8Name">The name of the property.</param>
        /// <returns><c>true</c> if the names are equal.</returns>
        public bool NameEquals(ReadOnlySpan<byte> utf8Name)
        {
            // The output can't be longer than the input.
            Span<char> name = stackalloc char[utf8Name.Length];
            int writtenCount = Encoding.UTF8.GetChars(utf8Name, name);
            return this.name.Span.SequenceEqual(name.Slice(0, writtenCount));
        }

        /// <summary>
        /// Writes the property to a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the property name/value pair.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (!this.value.IsNull)
            {
                writer.WritePropertyName(this.name.Span);
                this.value.WriteTo(writer);
            }
        }
    }
}
