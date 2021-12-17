// <copyright file="HttpResultBuilderSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Corvus.Testing.SpecFlow;
    using Menes.Converters;
    using Menes.Internal;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class HttpResultBuilderSteps
    {
        private readonly ScenarioContext scenarioContext;
        private OpenApiOperation? operation;
        private OpenApiResult? result;
        private Exception? exception;

        public HttpResultBuilderSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("I have an OpenApiOperation")]
        public void GivenIHaveAnOpenApiOperation()
        {
            this.operation = new OpenApiOperation();
            this.operation.Responses.Add(
                "200",
                new OpenApiResponse { Content = new Dictionary<string, OpenApiMediaType> { { "application/hal+json", new OpenApiMediaType() } } });
        }

        [Given("I have an OpenApiResult with a (.*) response")]
        public void GivenIHaveAnOpenApiResultWithAResponse(int response)
        {
            this.result = new OpenApiResult { StatusCode = response };
        }

        [Given(@"I have an OpenApiResult with a (.*) response and an ""(.*)"" body")]
        public void GivenIHaveAnOpenApiResultWithAResponseAndAnBody(int result, string mediaType)
        {
            this.result = new OpenApiResult { StatusCode = result };
            this.result.Results.Add(mediaType, "This is a payload");
        }

        [When(@"I pass the OpenApiOperation and OpenApiResult to HttpRequestResultBuilder\.BuildResult")]
        public void WhenIPassTheOpenApiOperationAndOpenApiResultToHttpRequestResultBuilder_BuildResult()
        {
            this.exception = null;
            try
            {
                var resultBuilder =
                    new OpenApiActionResultBuilder(
                        new[]
                        {
                            new OpenApiResultActionResultOutputBuilder(
                            Enumerable.Empty<IOpenApiConverter>(),
                            ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<ILogger<OpenApiResultActionResultOutputBuilder>>()),
                        },
                        ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<ILogger<OpenApiActionResultBuilder>>());
                resultBuilder.BuildResult(this.result!, this.operation!);
            }
            catch (Exception x)
            {
                this.exception = x;
            }
        }

        [Then("it should throw an OutputBuilderNotFoundException")]
        public void ThenItShouldThrowAnOutputBuilderNotFoundException()
        {
            Assert.IsInstanceOf<OutputBuilderNotFoundException>(this.exception);
        }

        [Then("it should not throw an OutputBuilderNotFoundException")]
        public void ThenItShouldNotThrowAnOutputBuilderNotFoundException()
        {
            Assert.IsNotInstanceOf<OutputBuilderNotFoundException>(this.exception);
        }
    }
}
