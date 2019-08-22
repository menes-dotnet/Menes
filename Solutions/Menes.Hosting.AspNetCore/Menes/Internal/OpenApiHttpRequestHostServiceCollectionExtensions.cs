// <copyright file="OpenApiHttpRequestHostServiceCollectionExtensions.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using Endjin.OpenApi;
    using Endjin.OpenApi.Internal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

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
        public static IServiceCollection AddOpenApiHttpRequestHosting(this IServiceCollection services, Action<OpenApiHostConfiguration> configureHost, Action<OpenApiConfiguration> configureEnvironment = null)
        {
            services.AddSingleton<IActionResultOutputBuilder, PocoActionResultOutputBuilder>();
            services.AddSingleton<IActionResultOutputBuilder, OpenApiResultActionResultOutputBuilder>();

            services.AddSingleton<IOpenApiContextBuilder<HttpRequest>, OpenApiContextBuilder<HttpRequest>>();
            services.AddSingleton<IOpenApiParameterBuilder<HttpRequest>, HttpRequestParameterBuilder>();
            services.AddSingleton<IOpenApiResultBuilder<IActionResult>, HttpRequestResultBuilder>();

            services.AddSingleton<JsonConverter, HalDocumentJsonConverter>();

            services.AddOpenApiHosting<HttpRequest, IActionResult>(
                configureHost,
                configureEnvironment);

            return services;
        }
    }
}