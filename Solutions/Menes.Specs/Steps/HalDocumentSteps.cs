// <copyright file="HalDocumentSteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CS1591 // Elements should be documented

namespace Menes.Specs.Steps
{
    using Corvus.Extensions.Json;
    using Corvus.SpecFlow.Extensions;
    using Menes.Hal;
    using Menes.Links;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class HalDocumentSteps
    {
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;

        public HalDocumentSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
        }

        [Given("I have a domain class")]
        public void GivenIHaveADomainClass()
        {
            var myDto = new TestDomainClass
            {
                Property1 = 500,
                Property2 = "This is a string",
                Property3 = 48.2M,
            };

            this.scenarioContext.Set(myDto);
        }

        [Given("I have created an instance of HalDocument{T} from the domain class")]
        public void GivenIHaveCreatedAnInstanceOfHalDocumentFromTheDomainClass()
        {
            IHalDocumentFactory halDocumentFactory = ContainerBindings.GetServiceProvider(this.featureContext).GetService<IHalDocumentFactory>();
            HalDocument halDocument = halDocumentFactory.CreateHalDocumentFrom(this.scenarioContext.Get<TestDomainClass>());
            this.scenarioContext.Set(halDocument);
        }

        [When("I serialize it to JSON")]
        public void WhenISerializeItToJSON()
        {
            HalDocument document = this.scenarioContext.Get<HalDocument>();

            // We're actually going to serialize to a JObject as this will make it easier to
            // check the results.
            IJsonSerializerSettingsProvider serializerSettingsProvider = ContainerBindings.GetServiceProvider(this.featureContext).GetRequiredService<IJsonSerializerSettingsProvider>();
            var serializer = JsonSerializer.Create(serializerSettingsProvider.Instance);
            var result = JObject.FromObject(document, serializer);

            this.scenarioContext.Set(result);
        }

        [Given(@"I add a link to the HalDocument\{T}")]
        public void GivenIAddALinkToTheHalDocumentT()
        {
            HalDocument document = this.scenarioContext.Get<HalDocument>();
            document.AddLink("somrel", new WebLink("http://marain.io/examples/link"));
        }

        [Given(@"I add an embedded resource to the HalDocument\{T}")]
        public void GivenIAddAnEmbeddedResourceToTheHalDocumentT()
        {
            HalDocument document = this.scenarioContext.Get<HalDocument>();
            IHalDocumentFactory halDocumentFactory = ContainerBindings.GetServiceProvider(this.featureContext).GetService<IHalDocumentFactory>();
            document.AddEmbeddedResource("somerel", halDocumentFactory.CreateHalDocument());
        }


        [Then("the properties of the domain class should be serialized as top level properties in the JSON")]
        public void ThenThePropertiesOfTheDomainClassShouldBeSerializedAsTopLevelPropertiesInTheJSON()
        {
            JObject result = this.scenarioContext.Get<JObject>();
            TestDomainClass dto = this.scenarioContext.Get<TestDomainClass>();

            Assert.NotNull(result["property1"]);
            Assert.NotNull(result["property2"]);
            Assert.NotNull(result["property3"]);

            Assert.AreEqual(dto.Property1, result["property1"].Value<int>());
            Assert.AreEqual(dto.Property2, result["property2"].Value<string>());
            Assert.AreEqual(dto.Property3, result["property3"].Value<decimal>());
        }

        [Then("the _embedded collection should be serialized as a top level property of the JSON")]
        public void ThenThe_EmbeddedCollectionShouldBeSerializedAsATopLevelPropertyOfTheJSON()
        {
            JObject result = this.scenarioContext.Get<JObject>();
            Assert.NotNull(result["_embedded"]);
        }

        [Then("the _links collection should be serialized as a top level property of the JSON")]
        public void ThenThe_LinksCollectionShouldBeSerializedAsATopLevelPropertyOfTheJSON()
        {
            JObject result = this.scenarioContext.Get<JObject>();
            Assert.NotNull(result["_links"]);
        }

        private class TestDomainClass
        {
            public int Property1 { get; set; }

            public string Property2 { get; set; }

            public decimal Property3 { get; set; }
        }
    }
}
