// <copyright file="PetStoreInitializationExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using Menes;
    using Menes.PetStore;
    using Menes.PetStore.Responses;
    using Menes.PetStore.Responses.Mappers;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Common DI initialization for PetStore.
    /// </summary>
    public static class PetStoreInitializationExtensions
    {
        /// <summary>
        /// Add services required by PetStore to DI.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddPetStore(this IServiceCollection services)
        {
            return services
                .AddLogging()
                .AddHttpClient()    // Needed because the PetStore grabs images from flickr
                .AddPetStoreMenesServices();
        }

        private static IServiceCollection AddPetStoreMenesServices(this IServiceCollection services)
        {
            // We can add all the services here
            // We will only actually *provide* services that are in the YAML file(s) we load below
            // So you can register everything, and use the yaml files you deploy to decide what is responded to by this instance
            services.AddSingleton<IOpenApiService, PetStoreService>();

            // Mappers for our return types. These use the special AddHalDocumentMapper extension, which will ensure
            // that their ConfigureLinkMap methods are added as part of initialisation.
            services.AddHalDocumentMapper<PetResource, PetResourceMapper>();
            services.AddHalDocumentMapper<PetListResource, PetListResourceMapper>();

            // This converter used to be added by default as part of Menes v1.x initialisation, but this is no longer
            // the case in v2.0 onwards. However, we have specified that our pets will have their Size value, which is
            // represented by the Size enumeration, returned as a string. This conversion could be done manually in the
            // PetResourceMapper, but we can achieve the same goal using the StringEnumConverter.
            services.AddSingleton<JsonConverter>(new StringEnumConverter(true));

            return services;
        }
    }
}