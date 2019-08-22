// <copyright file="HttpRequestExtensions.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Endjin.OpenApi
{
    using System.Threading.Tasks;
    using Endjin.Composition;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Extension methods for HttpRequest.
    /// </summary>
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// Uses the <see cref="IOpenApiHost{HttpRequest, IActionResult}"/> to handle the request.
        /// </summary>
        /// <param name="httpRequest">The request to handle.</param>
        /// <returns>The result of the request.</returns>
        public static Task<IActionResult> HandleRequestAsync(this HttpRequest httpRequest)
        {
            IOpenApiHost<HttpRequest, IActionResult> host = ServiceRoot.ServiceProvider.GetRequiredService<IOpenApiHost<HttpRequest, IActionResult>>();
            return host.HandleRequestAsync(httpRequest.Path, httpRequest.Method, httpRequest);
        }
    }
}
