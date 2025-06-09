// <copyright file="PetStoreContainerBindings.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Specs.Bindings
{
    using Corvus.Testing.ReqnRoll;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Reqnroll;

    public static class PetStoreContainerBindings
    {
        [BeforeScenario("perScenarioContainer", Order = ContainerBeforeScenarioOrder.PopulateServiceCollection)]
        public static void ConfigureCommonServices(ScenarioContext scenarioContext)
        {
            ContainerBindings.ConfigureServices(
                scenarioContext,
                services =>
                {
                    services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Debug));
                    services.AddJsonNetSerializerSettingsProvider();
                });
        }
    }
}