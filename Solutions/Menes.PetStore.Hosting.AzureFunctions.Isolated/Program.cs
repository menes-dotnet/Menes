using Menes;
using Menes.PetStore;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights()
    .AddPetStore()
    .AddOpenApiActionResultHosting<SimpleOpenApiContext>(PetStoreOpenApiHostConfiguration.LoadDocuments);

builder.Build().Run();
