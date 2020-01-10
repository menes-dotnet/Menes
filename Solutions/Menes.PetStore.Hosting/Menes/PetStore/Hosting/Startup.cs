// <copyright file="Startup.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

[assembly: Microsoft.Azure.WebJobs.Hosting.WebJobsStartup(typeof(Menes.PetStore.Hosting.Startup))]

namespace Menes.PetStore.Hosting
{
    using System.IO;
    using Menes.PetStore.Responses;
    using Menes.PetStore.Responses.Mappers;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;

    /// <summary>
    /// Startup code for the Function.
    /// </summary>
    public class Startup : IWebJobsStartup
    {
        /// <inheritdoc/>
        public void Configure(IWebJobsBuilder builder)
        {
            IServiceCollection services = builder.Services;

            services.AddLogging();
            services.AddHttpClient();

            services.AddHalDocumentMapper<PetResource, PetResourceMapper>();
            services.AddHalDocumentMapper<PetListResource, PetListResourceMapper>();

            services.AddOpenApiHttpRequestHosting(LoadDocuments);

            // We can add all the services here
            // We will only actually *provide* services that are in the YAML file(s) we load below
            // So you can register everything, and use the yaml files you deploy to decide what is responded to by this instance
            // These services need to be scoped to the request.
            services.AddOpenApiService<PetStoreService>();
        }

        private static void LoadDocuments(IOpenApiHostConfiguration hostConfig)
        {
            OpenApiDocument openApiDocument;
            using (FileStream stream = File.OpenRead(".\\yaml\\petstore.yaml"))
            {
                openApiDocument = new OpenApiStreamReader().Read(stream, out _);
            }

            hostConfig.Documents.Add(openApiDocument);
            hostConfig.Documents.AddSwaggerEndpoint();
        }
    }
}