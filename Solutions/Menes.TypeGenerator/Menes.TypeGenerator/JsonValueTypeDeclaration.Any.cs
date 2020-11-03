// <copyright file="JsonValueTypeDeclaration.Any.cs" company="Endjin Limited">
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
        /// Get the type for JSON Schema Any (or 'true').
        /// </summary>
        public static readonly JsonValueTypeDeclaration Any = new JsonValueTypeDeclaration(typeof(JsonAny).Name, new[] { "Menes.JsonAny" }, ValueKind.Any);

        /// <summary>
        /// Get the type for JSON Schema Menes.JsonNotAny (or 'false').
        /// </summary>
        public static readonly JsonValueTypeDeclaration NotAny = new JsonValueTypeDeclaration(typeof(JsonNotAny).Name, new[] { "Menes.JsonNotAny" }, ValueKind.Any);
    }
}
