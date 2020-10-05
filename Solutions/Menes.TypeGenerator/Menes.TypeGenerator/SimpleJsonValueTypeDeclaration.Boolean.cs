// <copyright file="SimpleJsonValueTypeDeclaration.Boolean.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    /// <summary>
    /// A simple type declaration.
    /// </summary>
    public partial class SimpleJsonValueTypeDeclaration : ITypeDeclaration
    {
        /// <summary>
        /// Get the <see cref="bool"/> type for JSON Schema Boolean.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Boolean = new SimpleJsonValueTypeDeclaration(typeof(JsonBoolean).FullName);
    }
}
