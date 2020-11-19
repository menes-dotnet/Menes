// <copyright file="ArrayConversionOperatorDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    /// <summary>
    /// A conversion operator declaration for an array.
    /// </summary>
    public class ArrayConversionOperatorDeclaration
    {
        /// <summary>
        /// Gets or sets the target type of items in the conversion.
        /// </summary>
        public TypeDeclaration? TargetItemType { get; set; }

        /// <summary>
        /// Gets or sets the type via which the source item type is converted to the target.
        /// </summary>
        public TypeDeclaration? ViaItemType { get; set; }

        /// <summary>
        /// Gets or sets the type via which the source array type is converted to the target.
        /// </summary>
        public TypeDeclaration? ViaArrayType { get; set; }
    }
}
