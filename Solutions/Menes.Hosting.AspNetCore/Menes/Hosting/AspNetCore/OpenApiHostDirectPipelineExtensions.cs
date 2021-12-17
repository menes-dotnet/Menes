// <copyright file="OpenApiHostDirectPipelineExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AspNetCore
{
    using System.Threading.Tasks;

    using Menes.Internal;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Extension methods for <see cref="IOpenApiHost{HttpRequest, IHttpResponseResult}"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Applications typically don't use this directly. Instead, they will normally use
    /// <see cref="OpenApiAspNetApplicationBuilderExtensions.UseMenesCatchAll(Microsoft.AspNetCore.Builder.IApplicationBuilder)"/>
    /// to Menes middleware that calls this to an ASP.NET Core pipeline.
    /// </para>
    /// <para>
    /// This does not require a dependency on MVC.
    /// </para>
    /// </remarks>
    public static class OpenApiHostDirectPipelineExtensions
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