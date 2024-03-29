﻿// <copyright file="OpenApiWebHostStartup.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable CA1822 // This wants to make things static because it doesn't understand the reflection-based usage model

namespace Menes.Testing.AspNetCoreSelfHosting.Internal
{
    using System;
    using Menes;
    using Menes.Hosting.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Startup class used with <see cref="IWebHostBuilder"/> to initialise a webhost.
    /// </summary>
    internal class OpenApiWebHostStartup
    {
        /// <summary>
        /// Configures the <see cref="IServiceCollection"/>, adding MVC routing and then handing off to the specified
        /// Startup class to add further required services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add to.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        /// <summary>
        /// Configures the function host, adding a catch-all route that then hands off to Menes to process the request.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to configure.</param>
        public void Configure(IApplicationBuilder app)
        {
            var openApiRouteHandler = new RouteHandler(
                async context =>
                {
                    try
                    {
                        IOpenApiHost<HttpRequest, IActionResult> handler = context.RequestServices.GetRequiredService<IOpenApiHost<HttpRequest, IActionResult>>();
                        IActionResult result = await handler.HandleRequestAsync(context.Request, context).ConfigureAwait(false);
                        var actionContext = new ActionContext(context, context.GetRouteData(), new ActionDescriptor());
                        await result.ExecuteResultAsync(actionContext).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = 500;

                        ILogger<OpenApiWebHostStartup> logger = context.RequestServices.GetRequiredService<ILogger<OpenApiWebHostStartup>>();
                        logger?.LogError(ex, "An unexpected exception occurred when attempting to handle the request.");
                    }
                });

            var routeBuilder = new RouteBuilder(app, openApiRouteHandler);

            routeBuilder.MapRoute("CatchAll", "{*path}");
            IRouter router = routeBuilder.Build();
            app.UseRouter(router);
        }
    }
}