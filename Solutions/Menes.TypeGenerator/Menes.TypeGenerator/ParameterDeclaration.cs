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
        /// <param name="typeName">The name of the type of the parameter.</param>
        public ParameterDeclaration(string name, string typeName)
        {
            this.Name = name;
            this.TypeName = typeName;
        }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the type name of the parameter.
        /// </summary>
        public string TypeName { get; }
    }
}
