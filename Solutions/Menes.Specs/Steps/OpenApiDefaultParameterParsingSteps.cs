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
        private Exception? exception;

        public OpenApiDefaultParameterParsingSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I have constructed the OpenAPI specification with a (.*) parameter with name (.*), type (.*), format (.*) and default value (.*)")]
        public void GivenIConstructASimpleParameter(
            string parameterLocation,
            string parameterName,
            string parameterType,
            string parameterFormat,
            string parameterDefaultValue)
        {
            //// Build OpenAPI spec object from scratch to mimic reality. Cutting corners by initializing an
            //// OpenApiDocument directly removes the ability for the the parameter type to be inferred. Something
            //// that this test is trying to cover.

            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"{parameterLocation}\", \"schema\": {{ \"type\": \"{parameterType}\", \"format\": \"{parameterFormat}\", \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given(@"I have constructed the OpenAPI specification with a parameter with name '(.*)', of type array, containing items of type '(.*)', and the default value for the parameter is '(.*)'")]
        public void GivenIConstructAnArrayParameterWithSimpleItems(
            string parameterName,
            string arrayItemType,
            string parameterDefaultValue)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"query\", \"schema\": {{ \"type\": \"array\", \"items\": {{ type: \"{arrayItemType}\" }}, \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given(@"I have constructed the OpenAPI specification with a parameter with name '(.*)', of type array, containing items which are arrays themselves with item type '(.*)', and the default value for the parameter is '(.*)'")]
        public void GivenIConstructAnArrayParameterWithArrayItems(
            string parameterName,
            string nestedArrayItemType,
            string parameterDefaultValue)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"query\", \"schema\": {{ \"type\": \"array\", \"items\": {{ \"type\": \"array\", \"items\": {{ \"type\": \"{nestedArrayItemType}\" }} }}, \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given(@"I have constructed the OpenAPI specification with a parameter with name '(.*)', of type array, containing items which are objects which has the property structure '(.*)', and the default value for the parameter is '(.*)'")]
        public void GivenIConstructAnArrayParameterWithObjectItems(
            string parameterName,
            string objectProperties,
            string parameterDefaultValue)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"query\", \"schema\": {{ \"type\": \"array\", \"items\": {{ \"type\": \"object\", \"properties\": {objectProperties} }}, \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given(@"I have constructed the OpenAPI specification with a parameter with name '(.*)', of type object, containing properties in the structure '(.*)', and the default value for the parameter is '(.*)'")]
        public void GivenIConstructAnObjectParameterWithSimpleProperties(
            string parameterName,
            string objectProperties,
            string parameterDefaultValue)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"query\", \"schema\": {{ \"type\": \"object\", \"properties\": {objectProperties}, \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given(@"I have constructed the OpenAPI specification with a (.*) parameter with name (.*), type (.*), format (.*) and a null default value")]
        public void GivenIConstructAParameterWithANullDefaultValue(
            string parameterLocation,
            string parameterName,
            string parameterType,
            string parameterFormat)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"{parameterLocation}\", \"schema\": {{ \"type\": \"{parameterType}\", \"format\": \"{parameterFormat}\", \"default\": null, \"nullable\": true }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [When(@"I try to parse the default value")]
        public async System.Threading.Tasks.Task WhenITryToParseTheDefaultValueAsync()
        {
            IPathMatcher matcher = this.scenarioContext.Get<IPathMatcher>();

            IOpenApiParameterBuilder<HttpRequest> builder = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IOpenApiParameterBuilder<HttpRequest>>();

            matcher.FindOperationPathTemplate("/pets", "GET", out OpenApiOperationPathTemplate? operationPathTemplate);

            var context = new DefaultHttpContext();

            try
            {
                this.parameters = await builder.BuildParametersAsync(context.Request, operationPathTemplate!);
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [Then(@"the parameter (.*) should be (.*) of type (.*)")]
        public void ThenTheSerializedResultShouldBe(string parameterName, string expectedResultAsString, string expectedType)
        {
            object expectedResult = expectedType switch
            {
                "ByteArrayFromBase64String" => Convert.FromBase64String(expectedResultAsString),
                "System.DateTimeOffset" => DateTimeOffset.Parse(expectedResultAsString),
                "System.Guid" => Guid.Parse(expectedResultAsString),
                "System.Uri" => new Uri(expectedResultAsString),
                _ => Convert.ChangeType(expectedResultAsString, Type.GetType(expectedType) !)
            };

            Assert.AreEqual(expectedResult, this.parameters![parameterName]);
        }

        [Then(@"an '(.*)' should be thrown")]
        public void ThenAnShouldBeThrown(string exceptionType)
        {
            Assert.IsNotNull(this.exception);

            Assert.AreEqual(exceptionType, this.exception!.GetType().Name.ToString());
        }

        private void InitializeDocumentProviderAndPathMatcher(string openApiSpec)
        {
            OpenApiDocument document = new OpenApiStringReader().Read(openApiSpec, out OpenApiDiagnostic diagnostic);

            Assert.IsEmpty(diagnostic.Errors);

            var documentProvider = new OpenApiDocumentProvider(new LoggerFactory().CreateLogger<OpenApiDocumentProvider>());
            documentProvider.Add(document);

            this.scenarioContext.Set<IOpenApiDocumentProvider>(documentProvider);

            var matcher = new PathMatcher(documentProvider);

            this.scenarioContext.Set<IPathMatcher>(matcher);
        }
    }
}
