// <copyright file="OpenApiContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Security.Claims;

    /// <summary>
    /// Provides a context that is built up in the Open API host.
    /// </summary>
    /// <typeparam name="TTenant">The type of the Tenant.</typeparam>
    public class OpenApiContext<TTenant> : IOpenApiContext<TTenant>
    {
        /// <summary>
        /// Gets or sets the current principal for the request.
        /// </summary>
        public ClaimsPrincipal CurrentPrincipal { get; set; }

        /// <summary>
        /// Gets or sets the current tenant for the request.
        /// </summary>
        public TTenant CurrentTenant { get; set; }
    }
}
