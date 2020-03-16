namespace Menes.Client.Specs.Steps
{
    using System.IO;
    using Menes.Client;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class CreatePetStoreServiceSteps
    {
        private readonly ScenarioContext scenarioContext;

        public CreatePetStoreServiceSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I load the OpenApiDocument for ""(.*)"" as ""(.*)""")]
        public void GivenILoadTheOpenApiDocumentForThePetStoreAs(string yamlFileName, string documentName)
        {
            var reader = new OpenApiStreamReader(new OpenApiReaderSettings { ReferenceResolution = ReferenceResolutionSetting.ResolveLocalReferences });
            using FileStream yamlStream = File.OpenRead(yamlFileName);
            OpenApiDocument openApiDocument = reader.Read(yamlStream, out _);
            this.scenarioContext.Set(openApiDocument, documentName);
        }
        
        [Given(@"I generate the service for the ""(.*)"" in the namespace ""(.*)"" with the service name ""(.*)""")]
        public void GivenIGenerateTheServiceForThe(string documentName, string ns, string serviceName)
        {
            OpenApiDocument openApiDocument = this.scenarioContext.Get<OpenApiDocument>(documentName);
            var sb = new ServiceBuilder();
            string code = sb.BuildService(openApiDocument, ns, serviceName);
            this.scenarioContext.Set(code, serviceName);
        }
        
        [Then(@"the code for the service ""(.*)"" should be ""(.*)""")]
        public void ThenTheResultShouldBe(string serviceName, string code)
        {
            Assert.AreEqual(code, this.scenarioContext.Get<string>(serviceName));
        }
    }
}
