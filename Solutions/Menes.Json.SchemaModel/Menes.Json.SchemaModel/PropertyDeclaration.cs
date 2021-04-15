﻿// <copyright file="PropertyDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeModel
{
    using System;

    /// <summary>
    /// A property declaration in a <see cref="TypeDeclaration"/>.
    /// </summary>
    public class PropertyDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyDeclaration"/> class.
        /// </summary>
        /// <param name="type">The type of the property.</param>
        /// <param name="jsonPropertyName">The json property name.</param>
        /// <param name="isRequired">Whether the property is required by default.</param>
        /// <param name="isInLocalScope">Whether the property is in the local scope.</param>
        public PropertyDeclaration(TypeDeclaration type, string jsonPropertyName, bool isRequired, bool isInLocalScope)
        {
            this.Type = type;
            this.JsonPropertyName = jsonPropertyName;
            this.IsRequired = isRequired;
            this.IsDefinedInLocalScope = isInLocalScope;
        }

        /// <summary>
        /// Gets the type of the property.
        /// </summary>
        public TypeDeclaration Type { get; }

        /// <summary>
        /// Gets the json property name of the property.
        /// </summary>
        public string JsonPropertyName { get; }

        /// <summary>
        /// Gets a value indicating whether this property is required.
        /// </summary>
        public bool IsRequired { get; }

        /// <summary>
        /// Gets a value indicating whether this property is defined in the local scope.
        /// </summary>
        /// <remarks>If true, then this property is defined in the current schema. If false, it
        /// has been dervied from a merged type.</remarks>
        public bool IsDefinedInLocalScope { get; }

        /// <summary>
        /// Gets or sets the dotnet property name.
        /// </summary>
        public string? DotnetPropertyName { get; set; }

        /// <summary>
        /// Gets a value indicating whether this property has a default value.
        /// </summary>
        public bool HasDefaultValue => this.Type.Schema.Default is not null;

        /// <summary>
        /// Gets the default value for the property.
        /// </summary>
        public string? DefaultValue => this.Type.Schema.Default is JsonAny def ? System.Text.Encoding.UTF8.GetString(def.GetRawText()) : default;

        /// <summary>
        /// Gets the constructor parameter name for this property.
        /// </summary>
        public string? ConstructorParameterName => this.DotnetPropertyName is string dnpn ? char.ToLower(dnpn[0]) + dnpn[1..] : null;
    }
}
