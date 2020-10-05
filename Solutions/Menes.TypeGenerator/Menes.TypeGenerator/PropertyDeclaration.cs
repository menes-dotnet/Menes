// <copyright file="PropertyDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    /// <summary>
    /// Implemented by property declarations.
    /// </summary>
    public class PropertyDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyDeclaration"/> class.
        /// </summary>
        /// <param name="parent">The parent type for the property.</param>
        /// <param name="jsonPropertyName">The name of the JSON property.</param>
        /// <param name="type">The type of the property.</param>
        public PropertyDeclaration(ITypeDeclaration parent, string jsonPropertyName, ITypeDeclaration type)
        {
            this.Parent = parent;
            this.JsonPropertyName = jsonPropertyName;
            this.Type = type;
        }

        /// <summary>
        /// Gets the (unqualified) name of the property.
        /// </summary>
        public string JsonPropertyName { get; }

        /// <summary>
        /// Gets the parent type declaring the property.
        /// </summary>
        public ITypeDeclaration Parent { get; }

        /// <summary>
        /// Gets the type of the property.
        /// </summary>
        public ITypeDeclaration Type { get; }
    }
}
