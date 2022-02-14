// <copyright file="SelfHostedApiBindings.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Specs.Bindings
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Corvus.Testing.SpecFlow;

    using Menes.PetStore.Specs.Internals;
    using Menes.PetStore.Specs.Stubs;
    using Menes.Testing.AspNetCoreSelfHosting;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework.Internal;

    using TechTalk.SpecFlow;

    [Binding]
    public static class SelfHostedApiBindings
    {
        [BeforeScenario("useSelfHostedApi", Order = ContainerBeforeScenarioOrder.ServiceProviderAvailable)]
        public static Task StartSelfHostedApi(ScenarioContext scenarioContext)
        {
            bool emulateFunctionsHost = TestExecutionContext.CurrentContext.TestObject switch
            {
                IMultiModeTest<TestHostTypes> multiModeTest => multiModeTest.TestType == TestHostTypes.EmulateFunctionWithActionResult,
                _ => true,
            };

            var hostManager = new OpenApiWebHostManager();
            scenarioContext.Set(hostManager);

            if (emulateFunctionsHost)
            {
                IConfiguration config = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "TestKey", "TestValue" },
                    })
                    .Build();
                return hostManager.StartInProcessFunctionsHostAsync<Menes.PetStore.Hosting.Startup>(
                    "http://localhost:7071",
                    config,
                    ConfigureServices);
            }
            else
            {
                return hostManager.StartInProcessAspNetHostAsync(
                    "http://localhost:7071",
                    new AspNetDirectPetStoreStartupTestWrapper(ConfigureServices));
            }

            void ConfigureServices(IServiceCollection services)
            {
                // Ensure log level for the service is set to debug.
                services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Debug));

                if (scenarioContext.ScenarioInfo.Tags.Contains("useStubServiceImplementation"))
                {
                    ServiceDescriptor petStoreServiceDescriptor = services.First(x => x.ImplementationType == typeof(PetStoreService));
                    services.Remove(petStoreServiceDescriptor);
                    services.AddSingleton<IOpenApiService, StubPetStoreService>();
                }
            }
        }

        [AfterScenario("useSelfHostedApi")]
        public static Task StopSelfHostedApi(ScenarioContext scenarioContext)
        {
            OpenApiWebHostManager hostManager = scenarioContext.Get<OpenApiWebHostManager>();
            return hostManager.StopAllHostsAsync();
        }
    }
}