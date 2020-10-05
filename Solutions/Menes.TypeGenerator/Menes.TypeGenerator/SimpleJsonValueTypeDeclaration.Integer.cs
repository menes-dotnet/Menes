// <copyright file="SimpleJsonValueTypeDeclaration.Integer.cs" company="Endjin Limited">
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
        /// Get the <see cref="long"/> type for JSON Schema int64.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Int64 = new SimpleJsonValueTypeDeclaration(typeof(JsonInt64).FullName);

        /// <summary>
        /// Get the <see cref="int"/> type for JSON Schema int32.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Int32 = new SimpleJsonValueTypeDeclaration(typeof(JsonInt32).FullName);
    }
}
