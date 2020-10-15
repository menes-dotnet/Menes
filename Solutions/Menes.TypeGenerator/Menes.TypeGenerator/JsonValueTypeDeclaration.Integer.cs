// <copyright file="JsonValueTypeDeclaration.Integer.cs" company="Endjin Limited">
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
        /// Get the number type for JSON Schema Integer.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Integer = new JsonValueTypeDeclaration(typeof(JsonInteger).Name, new[] { "Menes.JsonInteger", "int", "long" }, ValueKind.Number);

        /// <summary>
        /// Get the <see cref="long"/> type for JSON Schema int64.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Int64 = new JsonValueTypeDeclaration(typeof(JsonInt64).Name, new[] { "long" }, ValueKind.Number);

        /// <summary>
        /// Get the <see cref="int"/> type for JSON Schema int32.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Int32 = new JsonValueTypeDeclaration(typeof(JsonInt32).Name, new[] { "int" }, ValueKind.Number);
    }
}
