// <copyright file="IfThenElse.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    /// <summary>
    /// Represents an If/Then/Else triple.
    /// </summary>
    public class IfThenElse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IfThenElse"/> class.
        /// </summary>
        /// <param name="ifType">The <see cref="If"/> type.</param>
        /// <param name="thenType">The <see cref="Then"/> type.</param>
        public IfThenElse(TypeDeclaration ifType, TypeDeclaration thenType)
        {
            this.If = ifType;
            this.Then = thenType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IfThenElse"/> class.
        /// </summary>
        /// <param name="ifType">The <see cref="If"/> type.</param>
        /// <param name="thenType">The <see cref="Then"/> type.</param>
        /// <param name="elseType">The <see cref="Else"/> type.</param>
        public IfThenElse(TypeDeclaration ifType, TypeDeclaration? thenType, TypeDeclaration? elseType)
        {
            this.If = ifType;
            this.Then = thenType;
            this.Else = elseType;
        }

        /// <summary>
        /// Gets the If type declaration.
        /// </summary>
        public TypeDeclaration If { get; }

        /// <summary>
        /// Gets the Then type declaration.
        /// </summary>
        public TypeDeclaration? Then { get; }

        /// <summary>
        /// Gets the Else type declaration.
        /// </summary>
        public TypeDeclaration? Else { get; }
    }
}
