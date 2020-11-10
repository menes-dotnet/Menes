// <copyright file="PropertyDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    /// <summary>
    /// A property that will be exposed on the entity.
    /// </summary>
    public class PropertyDeclaration
    {
        /// <summary>
        /// Gets or sets the json property name of the property.
        /// </summary>
        public string? JsonPropertyName { get; set; }

        /// <summary>
        /// Gets or sets the dotnet property name of the property.
        /// </summary>
        public string? DotnetPropertyName { get; set; }

        /// <summary>
        /// Gets or sets the dotnet field name of the property.
        /// </summary>
        public string? DotnetFieldName { get; set; }

        /// <summary>
        /// Gets or sets the type declaration for the property.
        /// </summary>
        public TypeDeclaration? TypeDeclaration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this property is optional.
        /// </summary>
        public bool IsRequired { get; set; }
    }
}
