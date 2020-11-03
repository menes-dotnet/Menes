// <copyright file="JsonValueTypeDeclaration.Null.cs" company="Endjin Limited">
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
        /// Get the <see cref="bool"/> type for JSON Schema Boolean.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Null = new JsonValueTypeDeclaration(typeof(JsonNull).Name, new[] { "Menes.JsonNull" }, ValueKind.Null);
    }
}
