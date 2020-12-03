// <copyright file="TypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeModel
{
    using System.Collections.Immutable;

    /// <summary>
    /// A type declaration.
    /// </summary>
    public class TypeDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDeclaration"/> class.
        /// </summary>
        /// <param name="absoluteKeywordLocation">The <see cref="AbsoluteKeywordLocation"/>.</param>
        /// <param name="schema">The <see cref="Schema"/>.</param>
        /// <param name="parent">The <see cref="Parent"/>.</param>
        public TypeDeclaration(string absoluteKeywordLocation, Draft201909Schema schema, TypeDeclaration parent)
        {
            this.AbsoluteKeywordLocation = absoluteKeywordLocation;
            this.Schema = schema;
            this.Parent = parent;
            this.EmbeddedTypes = ImmutableArray<TypeDeclaration>.Empty;
        }

        /// <summary>
        /// Gets the absolute keyword location of the type declaration.
        /// </summary>
        public string AbsoluteKeywordLocation { get; }

        /// <summary>
        /// Gets the schema element for the type declaration.
        /// </summary>
        public Draft201909Schema Schema { get; }

        /// <summary>
        /// Gets the parent declaration.
        /// </summary>
        public TypeDeclaration Parent { get; }

        /// <summary>
        /// Gets the types embedded in this declaration.
        /// </summary>
        public ImmutableArray<TypeDeclaration> EmbeddedTypes { get; }
    }
}
