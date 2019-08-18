// <copyright file="IOpenApiContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Security.Claims;

    /// <summary>
    /// Interface implemented by types that provide a context that is built up in the Open API host.
    /// </summary>
    /// <typeparam name="TTenant">The type of the tenant for the context.</typeparam>
    public interface IOpenApiContext<TTenant>
    {
        /// <summary>
        /// Gets or sets the current principal for the request.
        /// </summary>
        ClaimsPrincipal CurrentPrincipal { get; set; }

        /// <summary>
        /// Gets or sets the current tenant for the request.
        /// </summary>
        TTenant CurrentTenant { get; set; }
    }
}
