// <copyright file="SimpleOpenApiContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Security.Claims;

    /// <summary>
    /// A simple OpenAPI context.
    /// </summary>
    public class SimpleOpenApiContext : IOpenApiContext
    {
        /// <inheritdoc/>
        public ClaimsPrincipal? CurrentPrincipal { get; set; }

        /// <inheritdoc/>
        public string? CurrentTenantId { get; set; }

        /// <inheritdoc/>
        public object? AdditionalContext { get; set; }
    }
}