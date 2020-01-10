// <copyright file="MenesContainerBindings.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Marain.Claims.SpecFlow.Bindings
{
    using Corvus.Monitoring.Instrumentation;
    using Corvus.SpecFlow.Extensions;
    using Menes;
    using Menes.Specs.Fakes;
    using Menes.Specs.Steps.TestClasses;
    using Microsoft.Extensions.DependencyInjection;
    using TechTalk.SpecFlow;

    /// <summary>
    ///     Container related bindings to configure the service provider for features.
    /// </summary>
    [Binding]
    public static class MenesContainerBindings
    {
        /// <summary>
        /// Initializes the container before each scenario's tests are run.
        /// </summary>
        /// <param name="scenarioContext">The SpecFlow test context.</param>
        [BeforeScenario("@perScenarioContainer", Order = ContainerBeforeFeatureOrder.PopulateServiceCollection)]
        public static void InitializeContainer(ScenarioContext scenarioContext)
        {
            ContainerBindings.ConfigureServices(
                scenarioContext,
                serviceCollection =>
                {
                    serviceCollection.AddLogging();
                    serviceCollection.AddOpenApiHttpRequestHosting(null);

                    var instrumentationProvider = new FakeInstrumentationProvider();
                    serviceCollection.AddSingleton(instrumentationProvider);
                    serviceCollection.AddSingleton<IOperationsInstrumentation>(instrumentationProvider);
                    serviceCollection.AddSingleton<IExceptionsInstrumentation>(instrumentationProvider);
                    serviceCollection.AddInstrumentation();
                    serviceCollection.AddInstrumentationSourceTagging();

                    OperationInvokerTestContext.AddServices(serviceCollection);
                });
        }
    }
}