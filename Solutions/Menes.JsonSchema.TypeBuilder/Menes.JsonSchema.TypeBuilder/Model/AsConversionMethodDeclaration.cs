// <copyright file="AsConversionMethodDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    /// <summary>
    /// A conversion declaration for an <c>As{SomeTypeName}()</c> method.
    /// </summary>
    public class AsConversionMethodDeclaration : ConversionOperatorDeclaration
    {
        /// <summary>
        /// Gets or sets the method name for the explicit As{TypeSuffix}() and Is{TypeSuffix}() conversion.
        /// </summary>
        public string? DotnetMethodTypeSuffix { get; set; }
    }
}
