// <copyright file="MenesContainerBindings.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Marain.Claims.SpecFlow.Bindings
{
    using Corvus.ContentHandling;
    using Corvus.Monitoring.Instrumentation;
    using Corvus.Testing.ReqnRoll;
    using Menes;
    using Menes.Specs.Fakes;
    using Menes.Specs.Steps.TestClasses;
    using Microsoft.Extensions.DependencyInjection;
    using Reqnroll;

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
                    serviceCollection.AddOpenApiAspNetPipelineHosting<SimpleOpenApiContext>(
                        null,
                        config =>
                        {
                            config.DiscriminatedTypes.Add("registeredDiscriminatedType1", typeof(RegisteredDiscriminatedType1));
                            config.DiscriminatedTypes.Add("registeredDiscriminatedType2", typeof(RegisteredDiscriminatedType2));
                        });
                    serviceCollection.AddContent(cf =>
                    {
                        cf.RegisterTransientContent<RegisteredContentType1>();
                        cf.RegisterTransientContent<RegisteredContentType2>();
                    });

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