// <copyright file="ParameterDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    /// <summary>
    /// A declaration of a parameter.
    /// </summary>
    public class ParameterDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="type">The type of the parameter.</param>
        public ParameterDeclaration(string name, ITypeDeclaration type)
        {
            this.Name = name;
            this.Type = type;
        }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the type of the parameter.
        /// </summary>
        public ITypeDeclaration Type { get; }
    }
}
