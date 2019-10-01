// <copyright file="ServiceBuilderOptions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder
{
    /// <summary>
    /// Options to configure the <see cref="ServiceBuilder"/>.
    /// </summary>
    public class ServiceBuilderOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether to default to IdentifierCase
        /// when making serialization assumptions.
        /// </summary>
        public bool DefaultToIdentifierCase { get; set; }
    }
}
