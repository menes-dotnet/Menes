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
        /// Get the <see cref="bool"/> type for JSON Schema Boolean.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Any = new JsonValueTypeDeclaration(typeof(JsonAny).Name, new[] { "Menes.JsonAny" }, ValueKind.Any);
    }
}
