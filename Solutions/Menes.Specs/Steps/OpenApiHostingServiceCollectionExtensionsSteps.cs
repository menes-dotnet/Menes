// <copyright file="OpenApiHostingServiceCollectionExtensionsSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Menes.Auditing;
    using Menes.Auditing.AuditLogSinks.Development;
    using Menes.Auditing.Internal;
    using Menes.Hal;
    using Menes.Specs.Steps.TestClasses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
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

        [Given("I have created a service collection to register my services against")]
        public void GivenIHaveCreatedAServiceCollectionToRegisterMyServicesAgainst()
        {
            this.scenarioContext.Set(new ServiceCollection());
        }

        [Given("I have added AspNetCore OpenApi hosting to the service collection")]
        [When("I add AspNetCore OpenApi hosting to the service collection")]
        public void WhenIAddOpenApiHostingToTheServiceCollection()
        {
            ServiceCollection collection = this.scenarioContext.Get<ServiceCollection>();

            collection.AddLogging();
            collection.AddOpenApiActionResultHosting<SimpleOpenApiContext>(_ => { }, null);
        }

        [Given("I have built the service provider from the service collection")]
        [When("I build the service provider from the service collection")]
        public void GivenIHaveBuiltTheServiceCollection()
        {
            ServiceProvider provider = this.scenarioContext.Get<ServiceCollection>().BuildServiceProvider();
            this.scenarioContext.Set(provider);
        }

        [Given("I have registered a HalDocumentMapper for a resource type to the service collection")]
        [When("I register a HalDocumentMapper for a resource type to the service collection")]
        public void WhenIRegisterAHalDocumentMapperForAResourceTypeToTheServiceCollection()
        {
            this.scenarioContext.Get<ServiceCollection>().AddHalDocumentMapper<Pet, PetHalDocumentMapper>();
        }

        [Given("I have registered a HalDocumentMapper for a resource and context type to the service collection")]
        [When("I register a HalDocumentMapper for a resource and context type to the service collection")]
        public void WhenIAddAHalDocumentMapperForAResourceAndContextTypeToTheServiceCollection()
        {
            this.scenarioContext.Get<ServiceCollection>()
                .AddHalDocumentMapper<Pet, MappingContext, PetHalDocumentMapperWithContext>();
        }

        [Then("a service is available as a Singleton for type IOpenApiHost{HttpRequest, IActionResult}")]
        public void ThenAServiceIsAddedAsASingletonForTypeIOpenApiHostHttpRequestIActionResult()
        {
            this.AssertServiceIsAvailableFromServiceProvider<IOpenApiHost<HttpRequest, IActionResult>>();
            this.AssertServiceIsASingleton<IOpenApiHost<HttpRequest, IActionResult>>();
        }

        [Then("it should be available as a Singleton with the service type matching the concrete type of the mapper")]
        public void ThenItShouldBeAvailableAsASingletonWithTheServiceTypeMatchingTheMapperType()
        {
            this.AssertServiceIsAvailableFromServiceProvider<PetHalDocumentMapper>();
            this.AssertServiceIsASingleton<PetHalDocumentMapper>();
        }

        [Then("it should be available as a Singleton with the service type matching the concrete type of the mapper with context")]
        public void ThenItShouldBeAvailableAsASingletonWithTheServiceTypeMatchingTheMapperTypeWithContext()
        {
            this.AssertServiceIsAvailableFromServiceProvider<PetHalDocumentMapperWithContext>();
            this.AssertServiceIsASingleton<PetHalDocumentMapperWithContext>();
        }

        [Then("It should be available as a Singleton with a service type of IHalDocumentMapper")]
        public void ThenItShouldBeAvailableAsASingletonWithAServiceTypeOfIHalDocumentMapper()
        {
            this.AssertServiceIsAvailableFromServiceProvider<IHalDocumentMapper>();
            this.AssertServiceIsASingleton<IHalDocumentMapper>();
        }

        [Then("it should be available as a Singleton with a service type of IHalDocumentMapper{TResource}")]
        public void ThenItShouldBeAvailableAsASingletonWithAServiceTypeOfIHalDocumentMapperTResource()
        {
            this.AssertServiceIsAvailableFromServiceProvider<IHalDocumentMapper<Pet>>();
            this.AssertServiceIsASingleton<IHalDocumentMapper<Pet>>();
        }

        [Then("it should be available as a Singleton with a service type of IHalDocumentMapper{TResource, TContext}")]
        public void ThenItShouldBeAvailableAsASingletonWithAServiceTypeOfIHalDocumentMapperWithResourceAndContext()
        {
            this.AssertServiceIsAvailableFromServiceProvider<IHalDocumentMapper<Pet, MappingContext>>();
            this.AssertServiceIsASingleton<IHalDocumentMapper<Pet, MappingContext>>();
        }

        [When("I request an instance of the OpenApi host")]
        public void WhenIRequestAnInstanceOfTheOpenApiHost()
        {
            ServiceProvider provider = this.scenarioContext.Get<ServiceProvider>();
            IOpenApiHost<HttpRequest, IActionResult> host =
                provider.GetRequiredService<IOpenApiHost<HttpRequest, IActionResult>>();

            this.scenarioContext.Set(host);
        }

        [Then("the HalDocumentMapper for resource type has configured its links")]
        public void ThenTheHalDocumentMapperForResourceTypeHasConfiguredItsLinks()
        {
            ServiceProvider provider = this.scenarioContext.Get<ServiceProvider>();
            PetHalDocumentMapper mapper = provider.GetRequiredService<PetHalDocumentMapper>();
            Assert.IsTrue(mapper.LinkMapConfigured);
        }

        [Then("the HalDocumentMapper for resource and context types has configured its links")]
        public void ThenTheHalDocumentMapperForResourceAndContextTypesHasConfiguredItsLinks()
        {
            ServiceProvider provider = this.scenarioContext.Get<ServiceProvider>();
            PetHalDocumentMapperWithContext mapper = provider.GetRequiredService<PetHalDocumentMapperWithContext>();
            Assert.IsTrue(mapper.LinkMapConfigured);
        }

        [Then("the exception of type '(.*)' is mapped to response code '(.*)'")]
        public void ThenTheExceptionOfTypeIsMappedToResponseCode(string exceptionType, int statusCode)
        {
            IOpenApiExceptionMapper exceptionMapper = this.scenarioContext.Get<ServiceProvider>()
                .GetRequiredService<IOpenApiExceptionMapper>();

            // The only way to tell if it's been mapped without reflecting into the guts of the mapper is to try and register
            // a new mapper for the given type/status code... even with this we need a little bit of reflection to invoke the
            // method.
            Type type = Type.GetType(exceptionType) ?? throw new InvalidOperationException($"Unable to find type {exceptionType}");
            MethodInfo mapMethod = exceptionMapper
                .GetType()
                .GetMethods()
                .First(x => x.Name == "Map" && x.GetGenericArguments().Length == 1);

            MethodInfo createdMapMethod = mapMethod.MakeGenericMethod(type);

            try
            {
                createdMapMethod.Invoke(exceptionMapper, new object?[] { statusCode, null });

                Assert.Fail($"Exception of type '{exceptionType}' was not registered");
            }
            catch (TargetInvocationException ex) when (ex.InnerException is ArgumentException)
            {
                // This is the expected exception result, so swallow to let the test pass. Anything
            }
        }

        [Then("an audit log builder service is available for auditing operations which return OpenApiResults")]
        public void ThenAnAuditLogBuilderServiceIsAddedForAuditingOperationsWhichReturnOpenApiResults()
        {
            this.AssertServiceIsAvailableFromServiceProvider<IAuditLogBuilder, OpenApiResultAuditLogBuilder>();
        }

        [Then("an audit log builder service is available for auditing operations which return a POCO")]
        public void ThenAnAuditLogBuilderServiceIsAddedForAuditingOperationsWhichReturnAPoco()
        {
            this.AssertServiceIsAvailableFromServiceProvider<IAuditLogBuilder, PocoAuditLogBuilder>();
        }

        [Then("an audit log sink service is available for console logging")]
        public void ThenAnAuditLogSinkServiceIsAddedForConsoleLogging()
        {
            this.AssertServiceIsAvailableFromServiceProvider<IAuditLogSink, ConsoleAuditLogSink>();
        }

        [Then("auditing is enabled")]
        public void ThenAuditingIsEnabled()
        {
            IAuditContext auditContext = this.scenarioContext.Get<ServiceProvider>().GetRequiredService<IAuditContext>();
            Assert.IsTrue(auditContext.IsAuditingEnabled);
        }

        private void AssertServiceIsAvailableFromServiceProvider<TService>()
        {
            TService service = this.scenarioContext.Get<ServiceProvider>().GetService<TService>();

            Assert.IsNotNull(service);
        }

        private void AssertServiceIsAvailableFromServiceProvider<TService, TExpectedConcreteType>()
            where TService : notnull
        {
            TService[] services = this.scenarioContext.Get<ServiceProvider>().GetServices<TService>().ToArray();

            Assert.IsNotEmpty(services);
            Assert.IsTrue(services.Any(x => typeof(TExpectedConcreteType) == x.GetType()));
        }

        private void AssertServiceIsASingleton<TService>()
        {
            ServiceProvider provider = this.scenarioContext.Get<ServiceProvider>();

            using IServiceScope scope1 = provider.CreateScope();
            using IServiceScope scope2 = provider.CreateScope();

            TService serviceInScope1 = scope1.ServiceProvider.GetRequiredService<TService>();
            TService serviceInScope2 = scope2.ServiceProvider.GetRequiredService<TService>();

            Assert.AreSame(serviceInScope1, serviceInScope2);
        }
    }
}