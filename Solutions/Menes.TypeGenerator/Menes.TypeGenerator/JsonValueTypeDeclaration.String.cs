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
        public static readonly JsonValueTypeDeclaration String = new JsonValueTypeDeclaration(typeof(JsonString).Name, "string", ValueKind.String);

        /// <summary>
        /// Get the <see cref="System.Guid"/> type for JSON Schema guid or uuid.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Guid = new JsonValueTypeDeclaration(typeof(JsonGuid).Name, "string", ValueKind.String);

        /// <summary>
        /// Get the <see cref="System.Uri"/> type for JSON Schema uri.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Uri = new JsonValueTypeDeclaration(typeof(JsonUri).Name, "string", ValueKind.String);

        /// <summary>
        /// Get the byte array type for JSON Schema uri.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Byte = new JsonValueTypeDeclaration(typeof(JsonByteArray).Name, "string", ValueKind.String);
    }
}
