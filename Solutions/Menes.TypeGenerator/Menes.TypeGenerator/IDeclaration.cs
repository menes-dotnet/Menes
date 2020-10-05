// <copyright file="IDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    /// <summary>
    /// A syntax declaration.
    /// </summary>
    public interface IDeclaration
    {
        /// <summary>
        /// Gets the local (unqualified) name of the declaration.
        /// </summary>
        /// <remarks>
        /// This is the "leaf name" of the scope - so e.g. a nested scope like <c>Menes.TypeGenerator.Example</c>
        /// would be represented as three <see cref="IDeclaration"/> instances, with <see cref="Name"/> values of <c>Menes</c>, <c>TypeGenerator</c> and <c>Example</c>
        /// or as pre-compounded declarations such as one called <c>Menes.TypeGenerator</c> and one called <c>Example</c>.
        /// </remarks>
        string Name { get; }

        /// <summary>
        /// Gets the parent declaration.
        /// </summary>
        IDeclaration? Parent { get; }
    }
}
