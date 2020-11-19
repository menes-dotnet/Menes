// <copyright file="Property.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// A property accessor.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="IJsonValue"/> that owns this property.</typeparam>
    public readonly struct Property<T>
        where T : struct, IJsonObject
    {
        private readonly ReadOnlyMemory<char>? name;
        private readonly T owner;
        private readonly JsonProperty jsonProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Property{T}"/> struct.
        /// </summary>
        /// <param name="jsonProperty">The backing <see cref="JsonProperty"/>.</param>
        public Property(JsonProperty jsonProperty)
        {
            this.owner = default;
            this.jsonProperty = jsonProperty;
            this.name = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Property{T}"/> struct.
        /// </summary>
        /// <param name="owner">The property owner.</param>
        /// <param name="name">the name of the property.</param>
        public Property(in T owner, ReadOnlyMemory<char> name)
        {
            this.owner = owner;
            this.name = name;
            this.jsonProperty = default;
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <returns><c>true</c> if the names are equal.</returns>
        public bool NameEquals(string name)
        {
            if (this.name is ReadOnlyMemory<char> ourName)
            {
                return ourName.Span.SequenceEqual(name.AsSpan());
            }

            return this.jsonProperty.NameEquals(name);
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <returns><c>true</c> if the names are equal.</returns>
        public bool NameEquals(ReadOnlySpan<char> name)
        {
            if (this.name is ReadOnlyMemory<char> ourName)
            {
                return ourName.Span.SequenceEqual(name);
            }

            return this.jsonProperty.NameEquals(name);
        }

        /// <summary>
        /// Compares the specified string to the name of this property.
        /// </summary>
        /// <param name="utf8Name">The name of the property.</param>
        /// <returns><c>true</c> if the names are equal.</returns>
        public bool NameEquals(ReadOnlySpan<byte> utf8Name)
        {
            if (this.name is ReadOnlyMemory<char> ourName)
            {
                // We have to allocate a string for now
                // In NetCore5.x land we can use <c>UTF8Encoding.GetChars</c> and stackalloc a Span<char>.
                // (see: https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getchars?view=net-5.0)
                string name = Encoding.UTF8.GetString(utf8Name);
                return ourName.Span.SequenceEqual(name);
            }

            return this.jsonProperty.NameEquals(utf8Name);
        }

        /// <summary>
        /// Get the value of this property from the given owner.
        /// </summary>
        /// <typeparam name="TValue">The type with which to retrieve the value of the property.</typeparam>
        /// <param name="value">The value of the property.</param>
        /// <returns><c>true</c> if the property was available.</returns>
        public bool TryGetValue<TValue>(out TValue value)
            where TValue : struct, IJsonValue
        {
            if (this.name is ReadOnlyMemory<char> name)
            {
                return this.owner.TryGetProperty(name.Span, out value);
            }

            value = this.jsonProperty.Value.As<TValue>();
            return true;
        }
    }
}
