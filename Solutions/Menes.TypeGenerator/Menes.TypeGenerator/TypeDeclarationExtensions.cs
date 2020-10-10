// <copyright file="TypeDeclarationExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    /// <summary>
    /// Extensions for <see cref="ITypeDeclaration"/> types.
    /// </summary>
    public static partial class TypeDeclarationExtensions
    {
        /// <summary>
        /// Gets an optional version of the given type declaration.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration for which to provide an optional version.</param>
        /// <returns>The optional version of the type declaration.</returns>
        public static OptionalTypeDeclaration AsOptional(this ITypeDeclaration typeDeclaration)
        {
            if (typeDeclaration is OptionalTypeDeclaration optional)
            {
                return optional;
            }

            return new OptionalTypeDeclaration(typeDeclaration);
        }

        /// <summary>
        /// Adds an array property for the given item type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to which to add the property.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="propertyType">The type of the property.</param>
        public static void AddPropertyDeclaration(this ITypeDeclaration typeDeclaration, string propertyName, ITypeDeclaration propertyType)
        {
            typeDeclaration.AddPropertyDeclaration(new PropertyDeclaration(typeDeclaration, propertyName, propertyType));
        }

        /// <summary>
        /// Adds an array property for the given item type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to which to add the property.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="propertyType">The type of the property.</param>
        public static void AddOptionalPropertyDeclaration(this ITypeDeclaration typeDeclaration, string propertyName, ITypeDeclaration propertyType)
        {
            typeDeclaration.AddPropertyDeclaration(new PropertyDeclaration(typeDeclaration, propertyName, propertyType.AsOptional()));
        }
    }
}
