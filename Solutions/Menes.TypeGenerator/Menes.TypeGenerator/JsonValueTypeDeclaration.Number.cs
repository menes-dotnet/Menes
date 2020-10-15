// <copyright file="JsonValueTypeDeclaration.Number.cs" company="Endjin Limited">
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
        /// Get the number type for JSON Schema number.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Number = new JsonValueTypeDeclaration(typeof(JsonNumber).Name, new[] { "Menes.JsonNumber", "float", "double", "decimal", "int", "long" }, ValueKind.Number);

        /// <summary>
        /// Get the <see cref="float"/> type for JSON Schema float.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Float = new JsonValueTypeDeclaration(typeof(JsonSingle).Name, new[] { "float" }, ValueKind.Number);

        /// <summary>
        /// Get the <see cref="double"/> type for JSON Schema double.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Double = new JsonValueTypeDeclaration(typeof(JsonDouble).Name, new[] { "double" }, ValueKind.Number);

        /// <summary>
        /// Get the <see cref="decimal"/> type for JSON Schema decimal.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Decimal = new JsonValueTypeDeclaration(typeof(JsonDecimal).Name, new[] { "decimal" }, ValueKind.Number);
    }
}
