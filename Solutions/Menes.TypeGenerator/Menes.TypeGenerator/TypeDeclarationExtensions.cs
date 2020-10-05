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
    }
}
