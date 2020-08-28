// <copyright file="OpenApiDefaultParameterParsingSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CS1591 // Elements should be documented

namespace Menes.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Corvus.SpecFlow.Extensions;
    using Menes.Internal;
    using Menes.Links;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    [Binding]
    public class OpenApiDefaultParameterParsingSteps
    {
        private readonly ScenarioContext scenarioContext;
        private IDictionary<string, object>? parameters;

        public OpenApiDefaultParameterParsingSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I have constructed the OpenAPI specification with a (.*) parameter with name (.*), type (.*), format (.*) and default value (.*)")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithAParameterWithNameTypeFormatAndDefaultValue(
            string parameterLocation,
            string parameterName,
            string parameterType,
            string parameterFormat,
            string parameterDefaultValue)
        {
            //// Build OpenAPI spec object from scratch to mimic reality. Cutting corners by initializing an
            //// OpenApiDocument directly removes the ability for the the parameter type to be inferred. Something
            //// that this test is trying to cover.

            string openApiSpecSimpleTypes = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"{parameterLocation}\", \"schema\": {{ \"type\": \"{parameterType}\", \"format\": \"{parameterFormat}\", \"default\": {parameterDefaultValue} }} }} ], \"description\": \"Returns all pets from the system that the user has access to\", \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            OpenApiDocument document = new OpenApiStringReader().Read(openApiSpecSimpleTypes, out OpenApiDiagnostic diagnostic);

            //// Why is this not playing ball?
            ////Assert.IsEmpty(diagnostic.Errors);

            var documentProvider = new OpenApiDocumentProvider(new LoggerFactory().CreateLogger<OpenApiDocumentProvider>());
            documentProvider.Add(document);

            this.scenarioContext.Set<IOpenApiDocumentProvider>(documentProvider);

            var matcher = new PathMatcher(documentProvider);

            this.scenarioContext.Set<IPathMatcher>(matcher);
        }

        [When(@"I try to parse the default value")]
        public async System.Threading.Tasks.Task WhenITryToParseTheDefaultValueAsync()
        {
            IPathMatcher matcher = this.scenarioContext.Get<IPathMatcher>();

            IOpenApiParameterBuilder<HttpRequest> builder = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IOpenApiParameterBuilder<HttpRequest>>();

            matcher.FindOperationPathTemplate("/pets", "GET", out OpenApiOperationPathTemplate? operationPathTemplate);

            var context = new DefaultHttpContext();

            this.parameters = await builder.BuildParametersAsync(context.Request, operationPathTemplate!);
        }

        [Then(@"the parameter (.*) should be (.*) of type (.*)")]
        public void ThenTheSerializedResultShouldBe(string parameterName, string expectedResultAsString, string expectedType)
        {
            object expectedResult = expectedType switch
            {
                "ByteArrayFromBase64String" => Convert.FromBase64String(expectedResultAsString),
                "System.DateTimeOffset" => DateTimeOffset.Parse(expectedResultAsString),
                _ => Convert.ChangeType(expectedResultAsString, Type.GetType(expectedType) !)
            };

            Assert.AreEqual(expectedResult, this.parameters![parameterName]);
        }
    }
}
