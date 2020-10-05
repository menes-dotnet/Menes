// <copyright file="SimpleJsonValueTypeDeclaration.String.cs" company="Endjin Limited">
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
        /// Get the <see cref="string"/> type for JSON Schema string.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration String = new SimpleJsonValueTypeDeclaration(typeof(JsonString).FullName);

        /// <summary>
        /// Get the <see cref="System.Guid"/> type for JSON Schema guid or uuid.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Guid = new SimpleJsonValueTypeDeclaration(typeof(JsonGuid).FullName);

        /// <summary>
        /// Get the <see cref="System.Uri"/> type for JSON Schema uri.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Uri = new SimpleJsonValueTypeDeclaration(typeof(JsonUri).FullName);

        /// <summary>
        /// Get the byte array type for JSON Schema uri.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Byte = new SimpleJsonValueTypeDeclaration(typeof(JsonByteArray).FullName);
    }
}
