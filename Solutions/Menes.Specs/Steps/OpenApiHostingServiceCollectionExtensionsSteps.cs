// <copyright file="OpenApiHostingServiceCollectionExtensionsSteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System.Linq;
    using Menes.Hal;
    using Menes.Specs.Steps.TestClasses;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class OpenApiHostingServiceCollectionExtensionsSteps
    {
        private readonly ScenarioContext scenarioContext;

        public OpenApiHostingServiceCollectionExtensionsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I have created a service collection to register my services against")]
        public void GivenIHaveCreatedAServiceCollectionToRegisterMyServicesAgainst()
        {
            this.scenarioContext.Set(new ServiceCollection());
        }

        [When(@"I register a HalDocumentMapper for a resource type to the service collection")]
        public void WhenIRegisterAHalDocumentMapperForAResourceTypeToTheServiceCollection()
        {
            this.scenarioContext.Get<ServiceCollection>().AddHalDocumentMapper<Pet, PetHalDocumentMapper>();
        }

        [When(@"I register a HalDocumentMapper for a resource and context type to the service collection")]
        public void WhenIAddAHalDocumentMapperForAResourceAndContextTypeToTheServiceCollection()
        {
            this.scenarioContext.Get<ServiceCollection>().AddHalDocumentMapper<Pet, MappingContext, PetHalDocumentMapperWithContext>();
        }

        [Then(@"it should be added as a Singleton with the service type matching the concrete type of the mapper")]
        public void ThenItShouldBeAddedAsASingletonWithTheServiceTypeMatchingTheMapperType()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>().FirstOrDefault(x => x.ServiceType == typeof(PetHalDocumentMapper));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }

        [Then(@"it should be added as a Singleton with the service type matching the concrete type of the mapper with context")]
        public void ThenItShouldBeAddedAsASingletonWithTheServiceTypeMatchingTheMapperTypeWithContext()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>().FirstOrDefault(x => x.ServiceType == typeof(PetHalDocumentMapperWithContext));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }

        [Then(@"It should be added as a Singleton with a service type of IHalDocumentMapper")]
        public void ThenItShouldBeAddedAsASingletonWithAServiceTypeOfIHalDocumentMapper()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>().FirstOrDefault(x => x.ServiceType == typeof(IHalDocumentMapper));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }

        [Then(@"it should be added as a Singleton with a service type of IHalDocumentMapper\{TResource}")]
        public void ThenItShouldBeAddedAsASingletonWithAServiceTypeOfIHalDocumentMapperTResource()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>().FirstOrDefault(x => x.ServiceType == typeof(IHalDocumentMapper<Pet>));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }

        [Then(@"it should be added as a Singleton with a service type of IHalDocumentMapper{TResource, TContext}")]
        public void ThenItShouldBeAddedAsASingletonWithAServiceTypeOfIHalDocumentMapperWithResourceAndContext()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>().FirstOrDefault(x => x.ServiceType == typeof(IHalDocumentMapper<Pet, MappingContext>));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }
    }
}
