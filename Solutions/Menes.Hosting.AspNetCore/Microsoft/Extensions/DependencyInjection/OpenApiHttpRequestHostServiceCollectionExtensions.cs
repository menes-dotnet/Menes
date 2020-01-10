// <copyright file="OpenApiHttpRequestHostServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using Menes;
    using Menes.Internal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Extensions to register open api request hosting for <see cref="HttpRequest"/> and <see cref="IActionResult"/>.
    /// </summary>
    public static class OpenApiHttpRequestHostServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="HttpRequest"/> / <see cref="IActionResult"/> based hosting.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        /// <param name="configureHost">A function to configure the host.</param>
        /// <param name="configureEnvironment">A function to configure the environment.</param>
        /// <returns>The configured service collection.</returns>
        public static IServiceCollection AddOpenApiHttpRequestHosting(this IServiceCollection services, Action<IOpenApiHostConfiguration> configureHost, Action<IOpenApiConfiguration> configureEnvironment = null)
        {
            services.AddSingleton<IActionResultOutputBuilder, PocoActionResultOutputBuilder>();
            services.AddSingleton<IActionResultOutputBuilder, OpenApiResultActionResultOutputBuilder>();

            services.AddSingleton<IOpenApiParameterBuilder<HttpRequest>, HttpRequestParameterBuilder>();
            services.AddSingleton<IOpenApiResultBuilder<IActionResult>, HttpRequestResultBuilder>();

            services.AddOpenApiHosting<HttpRequest, IActionResult>(
                configureHost,
                configureEnvironment);

            return services;
        }
    }
}