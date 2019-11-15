// <copyright file="MenesContainerBindings.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Marain.Claims.SpecFlow.Bindings
{
    using Corvus.SpecFlow.Extensions;
    using Menes;
    using Microsoft.Extensions.DependencyInjection;
    using TechTalk.SpecFlow;

    /// <summary>
    ///     Container related bindings to configure the service provider for features.
    /// </summary>
    [Binding]
    public static class MenesContainerBindings
    {
        /// <summary>
        /// Initializes the container before each feature's tests are run.
        /// </summary>
        /// <param name="featureContext">The SpecFlow test context.</param>
        [BeforeFeature("@setupContainer", Order = ContainerBeforeFeatureOrder.PopulateServiceCollection)]
        public static void InitializeContainer(FeatureContext featureContext)
        {
            ContainerBindings.ConfigureServices(
                featureContext,
                serviceCollection =>
                {
                    serviceCollection.AddLogging();
                    serviceCollection.AddOpenApiHttpRequestHosting<SimpleOpenApiContext>(null);
                });
        }
    }
}
