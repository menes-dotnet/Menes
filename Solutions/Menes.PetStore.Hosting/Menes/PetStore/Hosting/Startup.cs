﻿// <copyright file="Startup.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

[assembly: Microsoft.Azure.WebJobs.Hosting.WebJobsStartup(typeof(Menes.PetStore.Hosting.Startup))]

namespace Menes.PetStore.Hosting
{
    using System.IO;
    using Menes.Auditing.AuditLogSinks.Development;
    using Menes.PetStore.Responses;
    using Menes.PetStore.Responses.Mappers;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;
    using Serilog;
    using Serilog.Filters;

    /// <summary>
    /// Startup code for the Function.
    /// </summary>
    public class Startup : IWebJobsStartup
    {
        /// <inheritdoc/>
        public void Configure(IWebJobsBuilder builder)
        {
            IServiceCollection services = builder.Services;

            LoggerConfiguration loggerConfig = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .MinimumLevel.Debug()
                    .WriteTo.Logger(lc => lc.Filter.ByExcluding(Matching.FromSource("Menes.OpenApi")).WriteTo.Console().MinimumLevel.Debug())
                    .WriteTo.Logger(lc => lc.Filter.ByIncludingOnly(Matching.FromSource("Menes.OpenApi")).WriteTo.Console().MinimumLevel.Debug());

            Log.Logger = loggerConfig.CreateLogger();

            services.AddDefaultJsonSerializerSettings();

            services.AddHalDocumentMapper<PetResource, PetResourceMapper>();
            services.AddHalDocumentMapper<PetListResource, PetListResourceMapper>();

            services.AddOpenApiHttpRequestHosting<SimpleOpenApiContext>(hostConfig =>
            {
                LoadDocuments(hostConfig);
            });

            services.AddOpenApiAuditing();
            services.AddAuditLogSink<ConsoleAuditLogSink>();

            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            // We can add all the services here
            // We will only actually *provide* services that are in the YAML file(s) we load below
            // So you can register everything, and use the yaml files you deploy to decide what is responded to by this instance
            services.AddSingleton<IOpenApiService, PetStoreService>();
        }

        private static void LoadDocuments(IOpenApiHostConfiguration hostConfig)
        {
            using (FileStream stream = File.OpenRead(".\\yaml\\petstore.yaml"))
            {
                OpenApiDocument openApiDocument = new OpenApiStreamReader().Read(stream, out OpenApiDiagnostic diagnostics);
                hostConfig.Documents.Add(openApiDocument);
                hostConfig.Documents.AddSwaggerEndpoint();
            }
        }
    }
}
