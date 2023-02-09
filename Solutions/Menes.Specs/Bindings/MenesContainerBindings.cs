// <copyright file="MenesContainerBindings.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Marain.Claims.SpecFlow.Bindings
{
    using System;

    using Corvus.ContentHandling;
    using Corvus.Monitoring.Instrumentation;
    using Corvus.Testing.SpecFlow;
    using Menes;
    using Menes.Specs.Fakes;
    using Menes.Specs.Steps.TestClasses;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

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
                    // Ensures debug log code paths are executed as part of test. (Without this, it
                    // can be hard to notice when more significant lines of code are not covered
                    // when using test coverage visualizers like NCrunch or Visual Studio's Live
                    // Unit Testing.)
                    serviceCollection.AddLogging(configure => configure.SetMinimumLevel(LogLevel.Debug).AddProvider(new DummyLogger()));
                    serviceCollection.AddOpenApiAspNetPipelineHosting<SimpleOpenApiContext>(
                        null,
                        ConfigureOpenApi);
                    serviceCollection.AddOpenApiAzureFunctionsWorkerHosting<SimpleOpenApiContext>(
                        null,
                        ConfigureOpenApi);

                    static void ConfigureOpenApi(IOpenApiConfiguration config)
                    {
                        config.DiscriminatedTypes.Add("registeredDiscriminatedType1", typeof(RegisteredDiscriminatedType1));
                        config.DiscriminatedTypes.Add("registeredDiscriminatedType2", typeof(RegisteredDiscriminatedType2));
                    }

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

        private class DummyLogger : ILoggerProvider
        {
            public ILogger CreateLogger(string categoryName) => new Logger();

            public void Dispose()
            {
            }

            private class Logger : ILogger, IDisposable
            {
                public IDisposable? BeginScope<TState>(TState state)
                    where TState : notnull
                    => this;

                public void Dispose()
                {
                }

                public bool IsEnabled(LogLevel logLevel) => true;

                public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
                {
                }
            }
        }
    }
}