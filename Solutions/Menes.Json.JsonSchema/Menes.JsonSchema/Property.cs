// <copyright file="Property.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System;
    using System.Text;
    using System.Text.Json;

    /// <summary>
    /// A property accessor.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="IJsonValue"/> that owns this property.</typeparam>
    public readonly struct Property<T> : IProperty
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
        /// Gets the name of the property as a string.
        /// </summary>
        public string Name
        {
            get
            {
                if (this.name is ReadOnlyMemory<char> name)
                {
                    return name.ToString();
                }

                return this.jsonProperty.Name;
            }
        }

        /// <inheritdoc />
        public ReadOnlyMemory<char> NameAsMemory
        {
            get
            {
                if (this.name is ReadOnlyMemory<char> name)
                {
                    return name;
                }

                return this.jsonProperty.Name.AsMemory();
            }
        }

        /// <summary>
        /// Get the value of this property from the given owner.
        /// </summary>
        /// <typeparam name="TValue">The type with which to retrieve the value of the property.</typeparam>
        /// <returns>The value of the property.</returns>
        public TValue Value<TValue>()
            where TValue : struct, IJsonValue
        {
            if (this.name is ReadOnlyMemory<char> name)
            {
                if (this.owner.TryGetProperty(name.Span, out TValue value))
                {
                    return value;
                }
                else
                {
                    throw new InvalidOperationException("The object was modified while enumerating properties.");
                }
            }

            return this.jsonProperty.Value.As<TValue>();
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
                Span<char> name = stackalloc char[utf8Name.Length];
                int written = Encoding.UTF8.GetChars(utf8Name, name);
                return ourName.Span.SequenceEqual(name.Slice(0, written));
            }

            return this.jsonProperty.NameEquals(utf8Name);
        }
    }
}
