// <copyright file="SelfHostedApiBindings.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Specs.Bindings
{
    using System.Linq;
    using System.Threading.Tasks;
    using Corvus.Testing.SpecFlow;
    using Menes.PetStore.Hosting;
    using Menes.PetStore.Specs.Stubs;
    using Menes.Testing.AspNetCoreSelfHosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Logging;
    using TechTalk.SpecFlow;

    [Binding]
    public static class SelfHostedApiBindings
    {
        [BeforeScenario("useSelfHostedApi", Order = ContainerBeforeScenarioOrder.ServiceProviderAvailable)]
        public static Task StartSelfHostedApi(ScenarioContext scenarioContext)
        {
            var hostManager = new OpenApiWebHostManager();
            scenarioContext.Set(hostManager);

            return hostManager.StartHostAsync<Startup>(
                "http://localhost:7071",
                services =>
                {
                    // Ensure log level for the service is set to debug.
                    services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Debug));

                    if (scenarioContext.ScenarioInfo.Tags.Contains("useStubServiceImplementation"))
                    {
                        ServiceDescriptor petStoreServiceDescriptor = services.First(x => x.ImplementationType == typeof(PetStoreService));
                        services.Remove(petStoreServiceDescriptor);
                        services.AddSingleton<IOpenApiService, StubPetStoreService>();
                    }
                });
        }

        [AfterScenario("useSelfHostedApi")]
        public static Task StopSelfHostedApi(ScenarioContext scenarioContext)
        {
            OpenApiWebHostManager hostManager = scenarioContext.Get<OpenApiWebHostManager>();
            return hostManager.StopAllHostsAsync();
        }
    }
}
