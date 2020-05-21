// <copyright file="OpenApiDocumentProviderSteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using Corvus.SpecFlow.Extensions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using TechTalk.SpecFlow;

    [Binding]
    public class OpenApiDocumentProviderSteps
    {
        private readonly ScenarioContext scenarioContext;

        public OpenApiDocumentProviderSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("I load an OpenApi document from the embedded resource '(.*)' and call it '(.*)'")]
        public void GivenILoadAnOpenApiDocumentFromTheEmbeddedResourceAndCallIt(
            string embeddedResourceName,
            string documentName)
        {
            OpenApiDocument openApiDocument = OpenApiServiceDefinitions.GetOpenApiServiceFromEmbeddedDefinition(
                typeof(OpenApiDocumentProviderSteps).Assembly,
                embeddedResourceName);

            this.scenarioContext.Set(openApiDocument, documentName);
        }

        [Given("I add the OpenApi document called '(.*)' to the OpenApiDocumentProvider")]
        [When("I add the OpenApi document called '(.*)' to the OpenApiDocumentProvider")]
        public void WhenIAddTheOpenApiDocumentCalledToTheOpenApiDocumentProvider(string documentName)
        {
            OpenApiDocumentProvider documentProvider = this.GetOpenApiDocumentProvider();
            OpenApiDocument document = this.scenarioContext.Get<OpenApiDocument>(documentName);

            documentProvider.Add(document);
        }

        [When("I get the operation path template for path '(.*)' and method '(.*)'")]
        public void WhenIGetTheOperationPathTemplateForPathAndMethod(string path, string method)
        {
            OpenApiDocumentProvider documentProvider = this.GetOpenApiDocumentProvider();
            documentProvider.GetOperationPathTemplate(path, method, out OpenApiOperationPathTemplate? template);
            this.scenarioContext.Set(template);
        }

        [Then("the OpenApiDocumentProvider contains (.*) document")]
        public void ThenTheOpenApiDocumentProviderContainsDocument(int expectedDocumentCount)
        {
            OpenApiDocumentProvider documentProvider = this.GetOpenApiDocumentProvider();
            Assert.AreEqual(expectedDocumentCount, documentProvider.AddedOpenApiDocuments.Count);
        }

        [Then("an operation template is returned")]
        public void ThenAnOperationTemplateIsReturned()
        {
            OpenApiOperationPathTemplate? template = this.scenarioContext.Get<OpenApiOperationPathTemplate?>();
            Assert.IsNotNull(template);
        }

        [Then("no operation template is returned")]
        public void ThenNoOperationTemplateIsReturned()
        {
            OpenApiOperationPathTemplate? template = this.scenarioContext.Get<OpenApiOperationPathTemplate?>();
            Assert.IsNull(template);
        }

        [Then("the operation template has operation Id '(.*)'")]
        public void ThenTheOperationTemplateHasOperationId(string expectedOperationId)
        {
            OpenApiOperationPathTemplate? template = this.scenarioContext.Get<OpenApiOperationPathTemplate?>();
            Assert.AreEqual(expectedOperationId, template?.Operation.OperationId);
        }

        private OpenApiDocumentProvider GetOpenApiDocumentProvider()
        {
            IOpenApiDocumentProvider documentProvider = ContainerBindings.GetServiceProvider(this.scenarioContext)
                .GetRequiredService<IOpenApiDocumentProvider>();

            return (OpenApiDocumentProvider)documentProvider;
        }
    }
}
