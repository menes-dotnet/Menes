// <copyright file="EmbeddedOpenApiDefinitionAttribute.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;

    /// <summary>
    /// Applied to Open API Services that provide their service definition YAML as an
    /// embedded resource.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EmbeddedOpenApiDefinitionAttribute : Attribute
    {
        /// <summary>
        /// Creates an <see cref="EmbeddedOpenApiDefinitionAttribute"/>.
        /// </summary>
        /// <param name="resourceName">
        /// The name of the embedded resource that contains the YAML.
        /// </param>
        public EmbeddedOpenApiDefinitionAttribute(string resourceName)
        {
            this.ResourceName = resourceName;
        }

        /// <summary>
        /// Gets the name of the resource that contains the YAML.
        /// </summary>
        public string ResourceName { get; }
    }
}