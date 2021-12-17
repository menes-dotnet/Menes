// <copyright file="OpenApiHostActionResultExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AspNetCore
{
    using System.Threading.Tasks;

    using Menes;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Extension methods for HttpRequest.
    /// </summary>
    /// <remarks>
    /// This is used in scenarios where we want to return an <see cref="IActionResult"/> to the
    /// hosting framework (e.g. in Azure Functions v3).
    /// </remarks>
    public static class OpenApiHostActionResultExtensions
    {
        /// <summary>
        /// Uses the <see cref="IOpenApiHost{HttpRequest, IActionResult}"/> to handle the request.
        /// </summary>
        /// <param name="host">The host to handle the request.</param>
        /// <param name="httpRequest">The request to handle.</param>
        /// <param name="parameters">Any dynamically constructed parameters sent to the request.</param>
        /// <returns>The result of the request.</returns>
        public static Task<IActionResult> HandleRequestAsync(this IOpenApiHost<HttpRequest, IActionResult> host, HttpRequest httpRequest, object parameters)
        {
            return host.HandleRequestAsync(httpRequest.Path, httpRequest.Method, httpRequest, parameters);
        }
    }
}