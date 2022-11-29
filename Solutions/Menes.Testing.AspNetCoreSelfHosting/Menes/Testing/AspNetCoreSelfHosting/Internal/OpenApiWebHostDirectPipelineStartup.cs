// <copyright file="OpenApiWebHostDirectPipelineStartup.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable CA1822 // This wants to make things static because it doesn't understand the reflection-based usage model

namespace Menes.Testing.AspNetCoreSelfHosting.Internal
{
    using Menes.Hosting.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// Startup class used with <see cref="IWebHostBuilder"/> to initialise a webhost for tests
    /// the use ASP.NET direct pipeline hosting.
    /// </summary>
    internal class OpenApiWebHostDirectPipelineStartup
    {
        /// <summary>
        /// Configures the function host, adding a catch-all route that then hands off to Menes to process the request.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to configure.</param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseMenesCatchAll();
        }
    }
}