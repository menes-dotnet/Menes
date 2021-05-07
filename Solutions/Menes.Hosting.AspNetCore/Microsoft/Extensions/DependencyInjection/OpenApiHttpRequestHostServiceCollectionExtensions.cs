// <copyright file="OpenApiHttpRequestHostServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using Menes;
    using Menes.Hosting.AspNetCore;
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
        /// <typeparam name="TContext">The type of the OpenApi context.</typeparam>
        /// <param name="services">The service collection to configure.</param>
        /// <param name="configureHost">A function to configure the host.</param>
        /// <param name="configureEnvironment">A function to configure the environment.</param>
        /// <returns>The configured service collection.</returns>
        [Obsolete("Use AddOpenApiActionResultHosting, or consider changing to AddOpenApiAspNetPipelineHosting")]
        public static IServiceCollection AddOpenApiHttpRequestHosting<TContext>(
            this IServiceCollection services,
            Action<IOpenApiHostConfiguration>? configureHost,
            Action<IOpenApiConfiguration>? configureEnvironment = null)
            where TContext : class, IOpenApiContext, new()
        {
            return services.AddOpenApiActionResultHosting<TContext>(configureHost, configureEnvironment);
        }

        /// <summary>
        /// Adds <see cref="HttpRequest"/> / <see cref="IActionResult"/> based hosting.
        /// </summary>
        /// <typeparam name="TContext">The type of the OpenApi context.</typeparam>
        /// <param name="services">The service collection to configure.</param>
        /// <param name="configureHost">A function to configure the host.</param>
        /// <param name="configureEnvironment">A function to configure the environment.</param>
        /// <returns>The configured service collection.</returns>
        public static IServiceCollection AddOpenApiActionResultHosting<TContext>(
            this IServiceCollection services,
            Action<IOpenApiHostConfiguration>? configureHost,
            Action<IOpenApiConfiguration>? configureEnvironment = null)
            where TContext : class, IOpenApiContext, new()
        {
            services.AddSingleton<IResponseOutputBuilder<IActionResult>, PocoActionResultOutputBuilder>();
            services.AddSingleton<IResponseOutputBuilder<IActionResult>, OpenApiResultActionResultOutputBuilder>();

            services.AddSingleton<IOpenApiContextBuilder<HttpRequest>, OpenApiContextBuilder<HttpRequest, TContext>>();
            services.AddSingleton<IOpenApiParameterBuilder<HttpRequest>, HttpRequestParameterBuilder>();
            services.AddSingleton<IOpenApiResultBuilder<IActionResult>, OpenApiActionResultBuilder>();

            services.AddOpenApiHosting<HttpRequest, IActionResult>(
                configureHost,
                configureEnvironment);

            return services;
        }

        /// <summary>
        /// Adds <see cref="HttpRequest"/> / middleware-based hosting.
        /// </summary>
        /// <typeparam name="TContext">The type of the OpenApi context.</typeparam>
        /// <param name="services">The service collection to configure.</param>
        /// <param name="configureHost">A function to configure the host.</param>
        /// <param name="configureEnvironment">A function to configure the environment.</param>
        /// <returns>The configured service collection.</returns>
        public static IServiceCollection AddOpenApiAspNetPipelineHosting<TContext>(
            this IServiceCollection services,
            Action<IOpenApiHostConfiguration>? configureHost,
            Action<IOpenApiConfiguration>? configureEnvironment = null)
            where TContext : class, IOpenApiContext, new()
        {
            services.AddSingleton<IResponseOutputBuilder<IHttpResponseResult>, PocoHttpResponseOutputBuilder>();
            services.AddSingleton<IResponseOutputBuilder<IHttpResponseResult>, OpenApiResultHttpResponseOutputBuilder>();

            services.AddSingleton<IOpenApiContextBuilder<HttpRequest>, OpenApiContextBuilder<HttpRequest, TContext>>();
            services.AddSingleton<IOpenApiParameterBuilder<HttpRequest>, HttpRequestParameterBuilder>();
            services.AddSingleton<IOpenApiResultBuilder<IHttpResponseResult>, OpenApiHttpResponseResultBuilder>();

            services.AddOpenApiHosting<HttpRequest, IHttpResponseResult>(
                configureHost,
                configureEnvironment);

            services.AddSingleton<MenesCatchAllMiddleware>();

            return services;
        }
    }
}