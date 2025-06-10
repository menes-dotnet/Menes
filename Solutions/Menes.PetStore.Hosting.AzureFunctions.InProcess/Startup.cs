[assembly: Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup(typeof(Menes.PetStore.Hosting.AzureFunctions.InProcess.Startup))]

namespace Menes.PetStore.Hosting.AzureFunctions.InProcess;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
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
        IConfiguration configuration = builder.GetContext().Configuration;

        services.AddPetStore();
        services.AddOpenApiActionResultHosting<SimpleOpenApiContext>(PetStoreOpenApiHostConfiguration.LoadDocuments);
    }
}