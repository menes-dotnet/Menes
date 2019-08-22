// <copyright file="ITenantedOpenApiContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Interface implemented by types that provide a context that is built up in the Open API host.
    /// </summary>
    /// <typeparam name="TTenant">The type of the tenant.</typeparam>
    public interface ITenantedOpenApiContext<TTenant> : IOpenApiContext
    {
        /// <summary>
        /// Gets or sets the current principal for the request.
        /// </summary>
        TTenant CurrentTenant { get; set; }
    }
}
