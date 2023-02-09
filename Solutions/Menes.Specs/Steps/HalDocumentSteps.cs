// <copyright file="HalDocumentSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Nodes;

    using Corvus.Testing.SpecFlow;

    using Menes.Hal;
    using Menes.Links;

    using Microsoft.Extensions.DependencyInjection;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    [Binding]
    public class HalDocumentSteps
    {
        private readonly JsonSerializerOptions serializerOptions;
        private readonly ScenarioContext scenarioContext;

        private readonly IHalDocumentFactory halDocumentFactory;

        private TestDomainClass? domainData;

        public HalDocumentSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;

            IServiceProvider serviceProvider = ContainerBindings.GetServiceProvider(this.scenarioContext);
            this.serializerOptions = serviceProvider.GetRequiredService<IOpenApiConfiguration>().SerializerOptions;
            this.halDocumentFactory = serviceProvider.GetRequiredService<IHalDocumentFactory>();
        }

        [Given("I have a domain class")]
        public void GivenIHaveADomainClass()
        {
            this.domainData = new TestDomainClass
            {
                Property1 = 500,
                Property2 = "This is a string",
                Property3 = 48.2M,
            };
        }

        [Given("I have created an instance of HalDocument{T} from the domain class")]
        public void GivenIHaveCreatedAnInstanceOfHalDocumentFromTheDomainClass()
        {
            IHalDocumentFactory halDocumentFactory = this.halDocumentFactory;
            HalDocument halDocument = halDocumentFactory.CreateHalDocumentFrom(this.domainData!);
            this.scenarioContext.Set(halDocument);
        }

        [When("I serialize it to JSON")]
        public void WhenISerializeItToJSON()
        {
            HalDocument document = this.scenarioContext.Get<HalDocument>();

            // We're actually going to serialize to a JObject as this will make it easier to
            // check the results.
            var result = (JsonObject)JsonNode.Parse(JsonSerializer.Serialize(document, this.serializerOptions))!;

            this.scenarioContext.Set(result);
        }

        [When("I deserialize the JSON back to a HalDocument")]
        public void WhenIDeserializeTheJSONBackToAHalDocument()
        {
            JsonObject previouslySerializedHalDocument = this.scenarioContext.Get<JsonObject>();

            HalDocument result = previouslySerializedHalDocument.Deserialize<HalDocument>(this.serializerOptions)!;

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
            IHalDocumentFactory halDocumentFactory = this.halDocumentFactory;
            document.AddEmbeddedResource("somerel", halDocumentFactory.CreateHalDocument());
        }

        [Then("the properties of the domain class should be serialized as top level properties in the JSON")]
        public void ThenThePropertiesOfTheDomainClassShouldBeSerializedAsTopLevelPropertiesInTheJSON()
        {
            JsonObject result = this.scenarioContext.Get<JsonObject>();
            TestDomainClass dto = this.domainData!;

            Assert.NotNull(result["property1"]);
            Assert.NotNull(result["property2"]);
            Assert.NotNull(result["property3"]);

            Assert.AreEqual(dto.Property1, result["property1"]!.GetValue<int>());
            Assert.AreEqual(dto.Property2, result["property2"]!.GetValue<string>());
            Assert.AreEqual(dto.Property3, result["property3"]!.GetValue<decimal>());
        }

        [Then("the properties of the original document should be present in the deserialized document")]
        public void ThenThePropertiesOfTheOriginalDocumentShouldBePresentInTheDeserializedDocument()
        {
            HalDocument result = this.scenarioContext.Get<HalDocument>();
            TestDomainClass dtoIn = this.domainData!;
            Assert.IsTrue(result.TryGetProperties(out TestDomainClass? dtoOut));

            Assert.AreEqual(dtoIn.Property1, dtoOut!.Property1);
            Assert.AreEqual(dtoIn.Property2, dtoOut.Property2);
            Assert.AreEqual(dtoIn.Property3, dtoOut.Property3);
        }

        [Then("the _embedded collection should be serialized as a top level property of the JSON")]
        public void ThenThe_EmbeddedCollectionShouldBeSerializedAsATopLevelPropertyOfTheJSON()
        {
            JsonObject result = this.scenarioContext.Get<JsonObject>();
            Assert.NotNull(result["_embedded"]);
        }

        [Then("the _embedded collection should be present in the deserialized document")]
        public void ThenThe_EmbeddedCollectionShouldBePresentInTheDeserializedDocument()
        {
            HalDocument result = this.scenarioContext.Get<HalDocument>();
            Assert.AreEqual(1, result.EmbeddedResources.Count());
        }

        [Then("the _links collection should be serialized as a top level property of the JSON")]
        public void ThenThe_LinksCollectionShouldBeSerializedAsATopLevelPropertyOfTheJSON()
        {
            JsonObject result = this.scenarioContext.Get<JsonObject>();
            Assert.NotNull(result["_links"]);
        }

        [Then("the _links collection should be present in the deserialized document")]
        public void ThenThe_LinksCollectionShouldBePresentInTheDeserializedDocument()
        {
            HalDocument result = this.scenarioContext.Get<HalDocument>();
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