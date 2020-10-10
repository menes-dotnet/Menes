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
        /// Get the <see cref="float"/> type for JSON Schema float.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Float = new JsonValueTypeDeclaration(typeof(JsonSingle).FullName);

        /// <summary>
        /// Get the <see cref="double"/> type for JSON Schema double.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Double = new JsonValueTypeDeclaration(typeof(JsonDouble).FullName);

        /// <summary>
        /// Get the <see cref="decimal"/> type for JSON Schema decimal.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Decimal = new JsonValueTypeDeclaration(typeof(JsonDecimal).FullName);
    }
}
