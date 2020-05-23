// <copyright file="WebJobBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Testing.AspNetCoreSelfHosting.Internal
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// A basic <see cref="IWebJobsBuilder"/> implementation created to allow the <see cref="ServiceCollection"/> supplied to
    /// the <see cref="IWebHostBuilder"/> startup class to be passed through to the <see cref="IWebJobsStartup"/> for the
    /// function being hosted.
    /// </summary>
    internal class WebJobBuilder : IWebJobsBuilder
    {
        /// <summary>
        /// Creates a new instance of the <see cref="WebJobBuilder"/> class.
        /// </summary>
        /// <param name="collection">The <see cref="IServiceCollection"/> to populate.</param>
        public WebJobBuilder(IServiceCollection collection)
        {
            this.Services = collection;
        }

        /// <summary>
        /// Gets the current <see cref="IServiceCollection"/>.
        /// </summary>
        public IServiceCollection Services { get; }
    }
}
