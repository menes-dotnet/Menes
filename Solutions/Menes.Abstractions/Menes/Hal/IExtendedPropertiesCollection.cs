// <copyright file="IExtendedPropertiesCollection.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An entity that maps a bag of properties to/from one or more types.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The types do not have to be polymorphic, and a best-effort is made to map the properties.
    /// </para>
    /// <para>
    /// This pattern is useful for implementing C# versions of the oneof, anyof, allof patterns in JsonSchema.
    /// </para>
    /// </remarks>
    public interface IExtendedPropertiesCollection
    {
        /// <summary>
        /// Sets the properties using an object instance.
        /// </summary>
        /// <typeparam name="T">The type of the properties object.</typeparam>
        /// <param name="properties">The object from which to derive the properties.</param>
        void SetProperties<T>(T properties);

        /// <summary>
        /// Gets the properties as an instance of an object of a given type.
        /// </summary>
        /// <typeparam name="T">The type of the properties object.</typeparam>
        /// <param name="result">The properties deserialized to the relevant type.</param>
        /// <returns>True if it was possible to get the properties as the given type.</returns>
        bool TryGetPropertiesAs<T>([MaybeNullWhen(false)] out T result);
    }
}