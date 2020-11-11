// <copyright file="CommonTypeDeclarations.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    /// <summary>
    /// Gets common type declarations.
    /// </summary>
    public static class CommonTypeDeclarations
    {
        /// <summary>
        /// The {}/true type declaration.
        /// </summary>
        public static readonly TypeDeclaration AnyTypeDeclaration = new TypeDeclaration { IsBooleanTrueType = true };

        /// <summary>
        /// The not {}/false type declaration.
        /// </summary>
        public static readonly TypeDeclaration NotTypeDeclaration = new TypeDeclaration { IsBooleanFalseType = true };
    }
}
