// <copyright file="OpenApiWebHostManager.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Testing.AspNetCoreSelfHosting
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Menes.Testing.AspNetCoreSelfHosting.Internal;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Manages the execution of OpenApi services being run as part of a test scenario or feature.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class allows you to use the same Startup class that's used in an Azure function to run services in memory.
    /// To run the same services in memory as your function, obtain an instance of this class (if you wish to run multiple
    /// services, you can create a single instance of this class to manage all services). Then use the
    /// <see cref="StartAspNetHostAsync"/> method to add services, supplying the Startup class from your function and/or a
    /// callback to configure the service collection and the base url (including port number where necessary) that the
    /// endpoints should be made available on.
    /// </para>
    /// <para>
    /// Note that this assumes you're using an instance method in your function host rather than the older static method
    /// approach. This means that your initialisation will have been moved into a Startup class that implements
    /// <c>IWebJobsStartup</c> or <c>FunctionsStartup</c>; this is the class that should be supplied to
    /// <see cref="StartAspNetHostAsync"/>.
    /// </para>
    /// <para>
    /// You will normally make this call in a method tagged with either <c>BeforeScenario</c> or <c>BeforeFeature</c>. In the
    /// corresponding <c>AfterScenario</c> or <c>AfterFeature</c> method, you should call the
    /// <see cref="StopAllHostsAsync"/> method to stop and dispose the services. If you don't do this, the service will
    /// remain running. This may impact other features/scenarios as they will not be able to start a new instance of the
    /// service on the same Url.
    /// </para>
    /// </remarks>
    public class OpenApiWebHostManager
    {
        private readonly List<IWebHost> webHosts = new();

        /// <summary>
        /// Starts a new in-process host using the given Uri and startup class, with basic emulation of the Azure Functions
        /// host's request routing.
        /// </summary>
        /// <typeparam name="TFunctionStartup">The type of the startup class. This should be the type of the class from the
        /// function host project that is used to initialise the OpenApi services and dependencies.</typeparam>
        /// <param name="baseUrl">The url that the function will be exposed on.</param>
        /// <param name="additionalServiceConfigurationCallback">
        /// A callback that will allow you to make changes to the <see cref="IServiceCollection"/> after the code in
        /// your startup class has executed. You can use this to swap out services for stubs or fakes.
        /// </param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<IWebHost> StartInProcessFunctionsHostAsync<TFunctionStartup>(
            string baseUrl,
            Action<IServiceCollection>? additionalServiceConfigurationCallback = null)
            where TFunctionStartup : class, IWebJobsStartup, new()
            => this.StartInProcessFunctionsHostAsync(new TFunctionStartup(), baseUrl, additionalServiceConfigurationCallback);

        /// <summary>
        /// Starts a new in-process host using the given Uri and startup class, with basic emulation of the Azure Functions
        /// host's request routing.
        /// </summary>
        /// <typeparam name="TFunctionStartup">The type of the startup class. This should be the type of the class from the
        /// function host project that is used to initialise the OpenApi services and dependencies.</typeparam>
        /// <param name="baseUrl">The url that the function will be exposed on.</param>
        /// <param name="configuration">Configuration to supply to the startup class.</param>
        /// <param name="additionalServiceConfigurationCallback">
        /// A callback that will allow you to make changes to the <see cref="IServiceCollection"/> after the code in
        /// your startup class has executed. You can use this to swap out services for stubs or fakes.
        /// </param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<IWebHost> StartInProcessFunctionsHostAsync<TFunctionStartup>(
            string baseUrl,
            IConfiguration configuration,
            Action<IServiceCollection>? additionalServiceConfigurationCallback = null)
            where TFunctionStartup : class, IWebJobsStartup2, new()
            => this.StartInProcessFunctionsHostAsync(new TFunctionStartup(), baseUrl, configuration, additionalServiceConfigurationCallback);

        /// <summary>
        /// Starts a new in-process host using the given Uri and startup class, with basic emulation of the Azure Functions
        /// host's request routing.
        /// </summary>
        /// <typeparam name="TFunctionStartup">The type of the startup class. This should be the type of the class from the
        /// function host project that is used to initialise the OpenApi services and dependencies.</typeparam>
        /// <param name="startupInstance">The startup instance to use.</param>
        /// <param name="baseUrl">The url that the function will be exposed on.</param>
        /// <param name="additionalServiceConfigurationCallback">
        /// A callback that will allow you to make changes to the <see cref="IServiceCollection"/> after the code in
        /// your startup class has executed. You can use this to swap out services for stubs or fakes.
        /// </param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<IWebHost> StartInProcessFunctionsHostAsync<TFunctionStartup>(
            TFunctionStartup startupInstance,
            string baseUrl,
            Action<IServiceCollection>? additionalServiceConfigurationCallback = null)
            where TFunctionStartup : class, IWebJobsStartup
            => this.StartAspNetHostAsync(
                baseUrl,
                services =>
                {
                    // Shim to allow us to invoke the configuration method of the services startup class.
                    // (We pass a completely different class in for ASP.NET Core to use as the startup
                    // class, in order to fake the bits of the Functions host that we need to fake,
                    // which is why we need to invoke the real startup directly. This also has the
                    // benefit of enabling us to control the order: it's important that the additional
                    // configuration callback is invoked after Startup configuration, because that
                    // callback is used by some tests to replace certain services set up by Startup.)
                    var webJobBuilder = new WebJobBuilder(services);
                    startupInstance.Configure(webJobBuilder);

                    // Invoke any extra container configuration.
                    additionalServiceConfigurationCallback?.Invoke(services);
                },
                webHostBuilder => webHostBuilder.UseStartup<OpenApiWebHostStartup>());

        /// <summary>
        /// Starts a new in-process host using the given Uri and startup class, with basic emulation of the Azure Functions
        /// host's request routing.
        /// </summary>
        /// <typeparam name="TFunctionStartup">The type of the startup class. This should be the type of the class from the
        /// function host project that is used to initialise the OpenApi services and dependencies.</typeparam>
        /// <param name="startupInstance">The startup instance to use.</param>
        /// <param name="baseUrl">The url that the function will be exposed on.</param>
        /// <param name="configuration">Configuration to supply to the startup class.</param>
        /// <param name="additionalServiceConfigurationCallback">
        /// A callback that will allow you to make changes to the <see cref="IServiceCollection"/> after the code in
        /// your startup class has executed. You can use this to swap out services for stubs or fakes.
        /// </param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<IWebHost> StartInProcessFunctionsHostAsync<TFunctionStartup>(
            TFunctionStartup startupInstance,
            string baseUrl,
            IConfiguration configuration,
            Action<IServiceCollection>? additionalServiceConfigurationCallback = null)
            where TFunctionStartup : class, IWebJobsStartup2
            => this.StartAspNetHostAsync(
                baseUrl,
                services =>
                {
                    // This needs to be a separate implementation from the version that doesn't
                    // take a config, because we want that to be able to work with older
                    // startup classes that don't implement IWebJobsStartup2.

                    // Shim to allow us to invoke the configuration method of the services startup class.
                    // (We pass a completely different class in for ASP.NET Core to use as the startup
                    // class, in order to fake the bits of the Functions host that we need to fake,
                    // which is why we need to invoke the real startup directly. This also has the
                    // benefit of enabling us to control the order: it's important that the additional
                    // configuration callback is invoked after Startup configuration, because that
                    // callback is used by some tests to replace certain services set up by Startup.)
                    var webJobBuilder = new WebJobBuilder(services);
                    var context = new WebJobsBuilderContext
                    {
                        Configuration = configuration,
                    };
                    services.AddSingleton(configuration);
                    startupInstance.Configure(context, webJobBuilder);

                    // Invoke any extra container configuration.
                    additionalServiceConfigurationCallback?.Invoke(services);
                },
                webHostBuilder => webHostBuilder.UseStartup<OpenApiWebHostStartup>());

        /// <summary>
        /// Starts a new in-process host using the given Uri and a pre-instantiated instance of the startup class.
        /// </summary>
        /// <typeparam name="TStartup">The type of the startup class. This should be the type of the class from the
        /// ASP.NET host project that is used to initialise the OpenApi services and dependencies.</typeparam>
        /// <param name="baseUrl">The url that the function will be exposed on.</param>
        /// <param name="startupInstance">The instantiated startup class to use.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks>
        /// If you need to run further service configuration that is guaranteed to execute after the Startup
        /// DI configuration when testing with ASP.NET direct pipeline hosting, use a wrapper startup class
        /// because that's the only way to ensure that your configuration will run after Startup. (The ASP.NET
        /// web host startup prefers to run the Startup methods after all other configuration has occurred.)
        /// </remarks>
        public Task<IWebHost> StartInProcessAspNetHostAsync<TStartup>(
            string baseUrl,
            TStartup startupInstance)
            where TStartup : class
            => this.StartAspNetHostAsync(
                baseUrl,
                services => services.AddSingleton(startupInstance),
                webHostBuilder => webHostBuilder.UseStartup<TStartup>());

        /// <summary>
        /// Stops all of the function hosts that were started via <see cref="StartAspNetHostAsync"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task StopAllHostsAsync()
        {
            foreach (IWebHost current in this.webHosts)
            {
                await current.StopAsync().ConfigureAwait(false);
                current.Dispose();
            }
        }

        /// <summary>
        /// Starts a new function host using the given Uri and startup class.
        /// </summary>
        /// <param name="baseUrl">The url that the function will be exposed on.</param>
        /// <param name="serviceConfigurationCallback">
        /// A callback that will allow you to configure the <see cref="IServiceCollection"/> for your service.
        /// </param>
        /// <param name="webHostBuilderCallback">
        /// A callback that will allow you to configure the <see cref="IWebHostBuilder"/> for your service.
        /// </param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task<IWebHost> StartAspNetHostAsync(
            string baseUrl,
            Action<IServiceCollection> serviceConfigurationCallback,
            Action<IWebHostBuilder> webHostBuilderCallback)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            if (serviceConfigurationCallback is null)
            {
                throw new ArgumentNullException(nameof(serviceConfigurationCallback));
            }

            IWebHostBuilder builder = WebHost.CreateDefaultBuilder();
            builder.UseUrls(baseUrl);
            webHostBuilderCallback(builder);

            builder.ConfigureServices(serviceConfigurationCallback);

            IWebHost host = builder.Build();

            this.webHosts.Add(host);

            await host.StartAsync();
            return host;
        }
    }
}