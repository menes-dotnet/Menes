// <copyright file="IHalDocumentSteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CS1591 // Elements should be documented

namespace Menes.Specs.Steps
{
    using System.Linq;
    using Corvus.Extensions.Json;
    using Corvus.SpecFlow.Extensions;
    using Menes.Hal;
    using Menes.Links;
    using Menes.Specs.Fakes;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class IHalDocumentSteps
    {
        private readonly ScenarioContext scenarioContext;

        public IHalDocumentSteps(ScenarioContext scenarioContext)
        {
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

        [Given("I have created an instance of IHalDocument from the domain class")]
        public void GivenIHaveCreatedAnInstanceOfIHalDocumentFromTheDomainClass()
        {
            IHalDocumentFactory halDocumentFactory = ContainerBindings.GetServiceProvider(this.scenarioContext).GetService<IHalDocumentFactory>();
            IHalDocument halDocument = halDocumentFactory.CreateHalDocumentFrom(this.scenarioContext.Get<TestDomainClass>());
            this.scenarioContext.Set(halDocument);
        }

        [Given("I have created an instance of a custom IHalDocument from the domain class")]
        public void GivenIHaveCreatedAnInstanceOfACustomIHalDocumentFromTheDomainClass()
        {
            IHalDocumentFactory halDocumentFactory = ContainerBindings.GetServiceProvider(this.scenarioContext).GetService<IHalDocumentFactory>();
            CustomHalDocument halDocument = halDocumentFactory.CreateHalDocumentFrom<CustomHalDocument, TestDomainClass>(this.scenarioContext.Get<TestDomainClass>());
            this.scenarioContext.Set<IHalDocument>(halDocument);
        }

        [When("I serialize it to JSON")]
        public void WhenISerializeItToJSON()
        {
            IHalDocument document = this.scenarioContext.Get<IHalDocument>();

            // We're actually going to serialize to a JObject as this will make it easier to
            // check the results.
            IJsonSerializerSettingsProvider serializerSettingsProvider = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IJsonSerializerSettingsProvider>();
            var serializer = JsonSerializer.Create(serializerSettingsProvider.Instance);
            var result = JObject.FromObject(document, serializer);

            this.scenarioContext.Set(result);
        }

        [When("I deserialize the JSON back to a IHalDocument")]
        public void WhenIDeserializeTheJSONBackToAIHalDocument()
        {
            JObject previouslySerializedIHalDocument = this.scenarioContext.Get<JObject>();

            IJsonSerializerSettingsProvider serializerSettingsProvider = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IJsonSerializerSettingsProvider>();
            var serializer = JsonSerializer.Create(serializerSettingsProvider.Instance);
            IHalDocument result = previouslySerializedIHalDocument.ToObject<IHalDocument>(serializer);

            this.scenarioContext.Set(result);
        }

        [When("I deserialize the JSON back to a custom IHalDocument")]
        public void WhenIDeserializeTheJSONBackToACustomIHalDocument()
        {
            JObject previouslySerializedIHalDocument = this.scenarioContext.Get<JObject>();

            IJsonSerializerSettingsProvider serializerSettingsProvider = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IJsonSerializerSettingsProvider>();
            var serializer = JsonSerializer.Create(serializerSettingsProvider.Instance);
            CustomHalDocument result = previouslySerializedIHalDocument.ToObject<CustomHalDocument>(serializer);

            this.scenarioContext.Set<IHalDocument>(result);
        }

        [Given("I add a link to the IHalDocument")]
        public void GivenIAddALinkToTheIHalDocumentT()
        {
            IHalDocument document = this.scenarioContext.Get<IHalDocument>();
            document.AddLink("somrel", new WebLink("http://marain.io/examples/link"));
        }

        [Given("I add an embedded resource to the IHalDocument")]
        public void GivenIAddAnEmbeddedResourceToTheIHalDocumentT()
        {
            IHalDocument document = this.scenarioContext.Get<IHalDocument>();
            IHalDocumentFactory halDocumentFactory = ContainerBindings.GetServiceProvider(this.scenarioContext).GetService<IHalDocumentFactory>();
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

        [Then("the properties of the original document should be present in the deserialized document")]
        public void ThenThePropertiesOfTheOriginalDocumentShouldBePresentInTheDeserializedDocument()
        {
            IHalDocument result = this.scenarioContext.Get<IHalDocument>();
            TestDomainClass dtoIn = this.scenarioContext.Get<TestDomainClass>();
            Assert.IsTrue(result.TryGetPropertiesAs(out TestDomainClass? dtoOut));

            Assert.AreEqual(dtoIn.Property1, dtoOut!.Property1);
            Assert.AreEqual(dtoIn.Property2, dtoOut.Property2);
            Assert.AreEqual(dtoIn.Property3, dtoOut.Property3);
        }

        [Then("the _embedded collection should be serialized as a top level property of the JSON")]
        public void ThenThe_EmbeddedCollectionShouldBeSerializedAsATopLevelPropertyOfTheJSON()
        {
            JObject result = this.scenarioContext.Get<JObject>();
            Assert.NotNull(result["_embedded"]);
        }

        [Then("the _embedded collection should be present in the deserialized document")]
        public void ThenThe_EmbeddedCollectionShouldBePresentInTheDeserializedDocument()
        {
            IHalDocument result = this.scenarioContext.Get<IHalDocument>();
            Assert.AreEqual(1, result.EmbeddedResources.Count());
        }

        [Then("the _links collection should be serialized as a top level property of the JSON")]
        public void ThenThe_LinksCollectionShouldBeSerializedAsATopLevelPropertyOfTheJSON()
        {
            JObject result = this.scenarioContext.Get<JObject>();
            Assert.NotNull(result["_links"]);
        }

        [Then("the _links collection should be present in the deserialized document")]
        public void ThenThe_LinksCollectionShouldBePresentInTheDeserializedDocument()
        {
            IHalDocument result = this.scenarioContext.Get<IHalDocument>();
            Assert.AreEqual(1, result.Links.Count());

            WebLink link = result.GetLinksForRelation("somrel").Single();

            Assert.AreEqual("http://marain.io/examples/link", link.Href);
        }

        private class TestDomainClass
        {
            public int Property1 { get; set; }

            public string? Property2 { get; set; }

            public decimal Property3 { get; set; }
        }
    }
}
