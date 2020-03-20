namespace Menes.Specs.Steps
{
    using System.Collections.Generic;
    using System.IO;
    using Corvus.SpecFlow.Extensions;
    using Menes;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.Extensions.DependencyInjection;
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

        [Given(@"I generate the service for the ""(.*)"" with the service name ""(.*)""")]
        public void GivenIGenerateTheServiceForThe(string documentName, string serviceName)
        {
            OpenApiDocument openApiDocument = this.scenarioContext.Get<OpenApiDocument>(documentName);
            ServiceBuilder serviceBuilder = ContainerBindings.GetServiceProvider(this.scenarioContext).GetService<ServiceBuilder>();
            var types = new Dictionary<string, TypeDeclarationSyntax>();
            serviceBuilder.BuildService(openApiDocument, serviceName, types);

            // TODO: replace this stuff
            var compiler = new ServiceCompiler();
            IDictionary<string, string> compiledTypes = compiler.CompileService(serviceName, "Menes.Tests", "Menes.Tests.Schema", types);

            this.scenarioContext.Set(compiledTypes, serviceName);
        }

        [Then(@"the code for the service ""(.*)"" should be ""(.*)""")]
        public void ThenTheCodeForTheServiceShouldBe(string serviceName, string code)
        {
            IDictionary<string, string> types = this.scenarioContext.Get<IDictionary<string, string>>(serviceName);

            Assert.AreEqual(code, types[serviceName]);
        }
    }
}
