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
    using Microsoft.Azure.WebJobs.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Manages the execution of OpenApi services being run as part of a test scenario or feature.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class allows you to use the same Startup class that's used in an Azure function to run services in memory.
    /// To run the same services in memory as your function, obtain an instance of this class (if you wish to run multiple
    /// services, you can create a single instance of this class to manage all services). Then use the
    /// <see cref="StartHostAsync"/> method to add services, supplying the Startup class from your function and/or a
    /// callback to configure the service collection and the base url (including port number where necessary) that the
    /// endpoints should be made available on.
    /// </para>
    /// <para>
    /// Note that this assumes you're using an instance method in your function host rather than the older static method
    /// approach. This means that your initialisation will have been moved into a Startup class that implements
    /// <c>IWebJobsStartup</c> or <c>FunctionsStartup</c>; this is the class that should be supplied to
    /// <see cref="StartHostAsync"/>.
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
        private readonly List<IWebHost> webHosts = new List<IWebHost>();

        /// <summary>
        /// Starts a new function host using the given Uri and startup class.
        /// </summary>
        /// <typeparam name="TFunctionStartup">The type of the startup class. This should be the type of the class from the
        /// function host project that is used to initialise the OpenApi services and dependencies.</typeparam>
        /// <param name="baseUrl">The url that the function will be exposed on.</param>
        /// <param name="additionalServiceConfigurationCallback">
        /// A callback that will allow you to make changes to the <see cref="IServiceCollection"/> after the code in
        /// your startup class has executed. You can use this to swap out services for stubs or fakes.
        /// </param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task StartHostAsync<TFunctionStartup>(
            string baseUrl,
            Action<IServiceCollection>? additionalServiceConfigurationCallback = null)
            where TFunctionStartup : IWebJobsStartup, new()
        {
            return this.StartHostAsync(baseUrl, s =>
            {
                // Shim to allow us to invoke the configuration method of the services startup class.
                var webJobBuilder = new WebJobBuilder(s);
                var targetStartup = new TFunctionStartup();
                targetStartup.Configure(webJobBuilder);

                // Invoke any extra container configuration.
                additionalServiceConfigurationCallback?.Invoke(s);
            });
        }

        /// <summary>
        /// Starts a new function host using the given Uri and startup class.
        /// </summary>
        /// <param name="baseUrl">The url that the function will be exposed on.</param>
        /// <param name="serviceConfigurationCallback">
        /// A callback that will allow you to configure the <see cref="IServiceCollection"/> for your service.
        /// </param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task StartHostAsync(
            string baseUrl,
            Action<IServiceCollection> serviceConfigurationCallback)
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
            builder.UseStartup<OpenApiWebHostStartup>();

            builder.ConfigureServices(serviceConfigurationCallback);

            IWebHost host = builder.Build();

            this.webHosts.Add(host);

            return host.StartAsync();
        }

        /// <summary>
        /// Stops all of the function hosts that were started via <see cref="StartHostAsync"/>.
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
    }
}
