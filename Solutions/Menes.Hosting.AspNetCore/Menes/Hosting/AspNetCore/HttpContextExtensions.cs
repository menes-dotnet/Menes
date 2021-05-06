// <copyright file="HttpContextExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AspNetCore
{
    using System.Threading.Tasks;

    using Menes.Internal;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Extension methods for HttpContext.
    /// </summary>
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Uses the <see cref="IOpenApiHost{HttpRequest, IActionResult}"/> to handle the request.
        /// </summary>
        /// <param name="host">The host to handle the request.</param>
        /// <param name="httpContext">The context for the request to handle.</param>
        /// <param name="parameters">Any dynamically constructed parameters sent to the request.</param>
        /// <returns>The result of the request.</returns>
        public static async Task HandleRequestAsync(
            this IOpenApiHost<HttpRequest, IHttpResponseResult> host, HttpContext httpContext, object parameters)
        {
            HttpRequest httpRequest = httpContext.Request;
            IHttpResponseResult result = await host.HandleRequestAsync(httpRequest.Path, httpRequest.Method, httpRequest, parameters);
            await result.ExecuteResultAsync(httpContext.Response);
        }
    }
}