// <copyright file="JsonValueTypeDeclaration.String.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    /// <summary>
    /// A simple type declaration.
    /// </summary>
    public partial class JsonValueTypeDeclaration : ITypeDeclaration
    {
        /// <summary>
        /// Get the <see cref="string"/> type for JSON Schema string.
        /// </summary>
        public static readonly JsonValueTypeDeclaration String = new JsonValueTypeDeclaration(typeof(JsonString).FullName, "string", ValueKind.String);

        /// <summary>
        /// Get the <see cref="System.Guid"/> type for JSON Schema guid or uuid.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Guid = new JsonValueTypeDeclaration(typeof(JsonGuid).FullName, "string", ValueKind.String);

        /// <summary>
        /// Get the <see cref="System.Uri"/> type for JSON Schema uri.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Uri = new JsonValueTypeDeclaration(typeof(JsonUri).FullName, "string", ValueKind.String);

        /// <summary>
        /// Get the byte array type for JSON Schema uri.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Byte = new JsonValueTypeDeclaration(typeof(JsonByteArray).FullName, "string", ValueKind.String);
    }
}
