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
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

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

            ConfigureMenes(services);

            // This converter used to be added by default as part of Menes v1.x initialisation, but this is no longer
            // the case in v2.0 onwards. However, we have specified that our pets will have their Size value, which is
            // represented by the Size enumeration, returned as a string. This conversion could be done manually in the
            // PetResourceMapper, but we can achieve the same goal using the StringEnumConverter.
            services.AddSingleton<JsonConverter>(new StringEnumConverter(true));
        }

        private static void ConfigureMenes(IServiceCollection services)
        {
            // Main Menes setup call.
            services.AddOpenApiHttpRequestHosting<SimpleOpenApiContext>(LoadDocuments);

            // We can add all the services here
            // We will only actually *provide* services that are in the YAML file(s) we load below
            // So you can register everything, and use the yaml files you deploy to decide what is responded to by this instance
            services.AddSingleton<IOpenApiService, PetStoreService>();

            // Mappers for our return types. These use the special AddHalDocumentMapper extension, which will ensure
            // that their ConfigureLinkMap methods are added as part of initialisation.
            services.AddHalDocumentMapper<PetResource, PetResourceMapper>();
            services.AddHalDocumentMapper<PetListResource, PetListResourceMapper>();
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