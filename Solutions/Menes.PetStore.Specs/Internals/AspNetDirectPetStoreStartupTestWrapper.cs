// <copyright file="AspNetDirectPetStoreStartupTestWrapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Specs.Bindings
{
    using System;

    using Menes.PetStore.Hosting.AspNetCore.DirectPipeline;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Enables tests to meddle with service collections after the DirectPipeline host's Startup
    /// class has finished configuring services.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This supports the <c>@useStubServiceImplementation</c> tag. For that to work, we need to
    /// adjust the service collection after the Startup class has run. This is slightly problematic
    /// because the ASP.NET host startup code invokes configuration callbacks before it invokes the
    /// Startup type's configuration method.
    /// </para>
    /// <para>
    /// When tests are running in Functions mode, we actually invoke the Functions configuration
    /// code ourselves as part of the fakery around reproducing aspects of the Functions host when
    /// hosting code directly in the test process. So the fact that ASP.NET Core invokes
    /// configuration callbacks before Startup configuration doesn't matter because ASP.NET Core
    /// isn't the thing running the Startup type of the code under test.
    /// </para>
    /// <para>
    /// In ASP.NET Core direct pipeline mode, we don't use the mechanisms we use in Functions mode,
    /// so we need to adapt the existing startup type to be able to inject the code we need at the
    /// right point.
    /// </para>
    /// </remarks>
    public class AspNetDirectPetStoreStartupTestWrapper
    {
        private readonly Action<IServiceCollection> postStartupConfigurationCallback;
        private readonly Startup hostStartup;

        public AspNetDirectPetStoreStartupTestWrapper(
            Action<IServiceCollection> postStartupConfigurationCallback)
        {
            this.postStartupConfigurationCallback = postStartupConfigurationCallback;
            this.hostStartup = new Startup();
        }

        /// <summary>
        /// Called by ASP.NET Core during DI initialization.
        /// </summary>
        /// <param name="services">The DI service collection to initialize.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            this.hostStartup.ConfigureServices(services);

            this.postStartupConfigurationCallback(services);
        }

        /// <summary>
        /// Called by ASP.NET Core to enable us to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Pipeline builder.</param>
        /// <param name="env">Host environment information.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.hostStartup.Configure(app, env);
        }
    }
}