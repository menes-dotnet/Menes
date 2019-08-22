// <copyright file="IOpenApiContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Security.Claims;

    /// <summary>
    /// Interface implemented by types that provide a context that is built up in the Open API host.
    /// </summary>
    public interface IOpenApiContext
    {
        /// <summary>
        /// Gets or sets the current principal for the request.
        /// </summary>
        ClaimsPrincipal CurrentPrincipal { get; set; }

        /// <summary>
        /// Gets the current tenant ID for the request.
        /// </summary>
        string CurrentTenantId { get; }
    }
}
