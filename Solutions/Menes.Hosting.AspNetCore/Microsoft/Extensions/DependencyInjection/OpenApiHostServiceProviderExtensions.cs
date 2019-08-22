// <copyright file="OpenApiHostServiceProviderExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Threading.Tasks;
    using Menes;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Extension methods for service prvider.
    /// </summary>
    public static class OpenApiHostServiceProviderExtensions
    {
        /// <summary>
        /// Gets an <see cref="IOpenApiHost{HttpRequest, IActionResult}"/> to handle the request.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The host to service the request.</returns>
        public static IOpenApiHost<HttpRequest, IActionResult> GetOpenApiHost(this IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IOpenApiHost<HttpRequest, IActionResult>>();
        }
    }
}
