// <copyright file="TypeDeclarationExtensions.Arrays.cs" company="Endjin Limited">
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
        /// Adds an array property for the given item type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to which to add the property.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="itemType">The type of the items in the array.</param>
        public static void AddArrayProperty(this ITypeDeclaration typeDeclaration, string propertyName, ITypeDeclaration itemType)
        {
            typeDeclaration.AddPropertyDeclaration(new PropertyDeclaration(typeDeclaration, propertyName, new ArrayTypeDeclaration(itemType)));
        }
    }
}
