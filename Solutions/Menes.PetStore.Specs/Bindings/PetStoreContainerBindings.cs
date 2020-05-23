// <copyright file="PetStoreContainerBindings.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Bindings
{
    using Corvus.Testing.SpecFlow;
    using Microsoft.Extensions.DependencyInjection;
    using TechTalk.SpecFlow;

    public static class PetStoreContainerBindings
    {
        [BeforeScenario("perScenarioContainer", Order = ContainerBeforeScenarioOrder.PopulateServiceCollection)]
        public static void ConfigureCommonServices(ScenarioContext scenarioContext)
        {
            ContainerBindings.ConfigureServices(
                scenarioContext,
                services =>
                {
                    services.AddJsonSerializerSettings();
                });
        }
    }
}
