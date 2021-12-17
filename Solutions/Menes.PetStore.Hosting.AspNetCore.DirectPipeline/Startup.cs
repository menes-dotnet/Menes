// <copyright file="Startup.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Hosting.AspNetCore.DirectPipeline
{
    using Menes.Hosting.AspNetCore;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Startup code for the web host.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Called by ASP.NET Core during DI initialization.
        /// </summary>
        /// <param name="services">The DI service collection to initialize.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPetStore();

            services.AddOpenApiAspNetPipelineHosting<SimpleOpenApiContext>(PetStoreOpenApiHostConfiguration.LoadDocuments);
        }

        /// <summary>
        /// Called by ASP.NET Core to enable us to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Pipeline builder.</param>
        /// <param name="env">Host environment information.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMenesCatchAll();
        }
    }
}