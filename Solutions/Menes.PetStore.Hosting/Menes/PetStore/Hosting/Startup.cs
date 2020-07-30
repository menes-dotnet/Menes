// <copyright file="Startup.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

[assembly: Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup(typeof(Menes.PetStore.Hosting.Startup))]

namespace Menes.PetStore.Hosting
{
    using Menes.PetStore.Responses;
    using Menes.PetStore.Responses.Mappers;
    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Startup code for the Function.
    /// </summary>
    public class Startup : FunctionsStartup
    {
        /// <inheritdoc/>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IServiceCollection services = builder.Services;

            services.AddLogging();
            services.AddHttpClient();

            services.AddHalDocumentMapper<PetResource, PetResourceMapper>();
            services.AddHalDocumentMapper<PetListResource, PetListResourceMapper>();

            services.AddOpenApiHttpRequestHosting<SimpleOpenApiContext>(LoadDocuments);

            // We can add all the services here
            // We will only actually *provide* services that are in the YAML file(s) we load below
            // So you can register everything, and use the yaml files you deploy to decide what is responded to by this instance
            services.AddSingleton<IOpenApiService, PetStoreService>();
        }

        private static void LoadDocuments(IOpenApiHostConfiguration hostConfig)
        {
            hostConfig.Documents.RegisterOpenApiServiceWithEmbeddedDefinition(
                typeof(PetStoreService).Assembly,
                "Menes.PetStore.PetStore.yaml");

            hostConfig.Documents.AddSwaggerEndpoint();
        }
    }
}