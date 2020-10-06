﻿// <copyright file="SimpleJsonValueTypeDeclaration.Number.cs" company="Endjin Limited">
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
        /// Get the <see cref="float"/> type for JSON Schema float.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Float = new SimpleJsonValueTypeDeclaration(typeof(JsonSingle).FullName);

        /// <summary>
        /// Get the <see cref="double"/> type for JSON Schema double.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Double = new SimpleJsonValueTypeDeclaration(typeof(JsonDouble).FullName);

        /// <summary>
        /// Get the <see cref="decimal"/> type for JSON Schema decimal.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Decimal = new SimpleJsonValueTypeDeclaration(typeof(JsonDecimal).FullName);
    }
}