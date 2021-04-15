// <copyright file="ContainerConfiguration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Hooks
{
    using System.Net.Http;
    using Drivers;
    using Menes.Json;
    using Menes.Json.Schema;
    using Menes.JsonSchema.TypeModel;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SolidToken.SpecFlow.DependencyInjection;

    /// <summary>
    /// Container configuration class.
    /// </summary>
    public static class ContainerConfiguration
    {
        /// <summary>
        /// Setup the service collection for dependency injection.
        /// </summary>
        /// <returns>The <see cref="IServiceCollection"/> configured with relevant services.</returns>
        /// <remarks>AddScoped for feature-level items, AddTransient for scenario level services.</remarks>
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IDocumentResolver>(serviceProvider => new CompoundDocumentResolver(new FakeWebDocumentResolver(serviceProvider.GetRequiredService<IConfiguration>()["jsonSchemaBuilderDriverSettings:remotesBaseDirectory"]), new FileSystemDocumentResolver(), new HttpClientDocumentResolver(new HttpClient())));
            services.AddTransient<JsonWalker>();
            services.AddTransient<JsonSchemaBuilder>();
            services.AddTransient<JsonSchemaBuilderDriver>();
            services.AddTransient<IConfiguration>(sp =>
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("appsettings.json", true);
                configurationBuilder.AddJsonFile("appsettings.local.json", true);
                return configurationBuilder.Build();
            });

            return services;
        }
    }
}
