// <copyright file="OpenApiMisconfigurationDetectionSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Corvus.Testing.SpecFlow;
    using Menes.Converters;
    using Menes.Exceptions;
    using Menes.Internal;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using Moq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class OpenApiMisconfigurationDetectionSteps
    {
        private readonly ScenarioContext scenarioContext;
        private OpenApiOperation? operation;
        private OpenApiDocument? document;
        private Exception? exception;

        public OpenApiMisconfigurationDetectionSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("I have an OpenApiOperation with multiple 2xx responses")]
        public void GivenIHaveAnOpenApiOperationWithMultiple2xxResponses()
        {
            this.operation = new OpenApiOperation();
            this.operation.Responses.Add(
                "200",
                new OpenApiResponse());
            this.operation.Responses.Add(
                "201",
                new OpenApiResponse());
        }

        [Given("I have an OpenApiOperation with a 200 response and a default response")]
        public void GivenIHaveAnOpenApiOperationWithAResponseAndADefaultResponse()
        {
            this.operation = new OpenApiOperation();
            this.operation.Responses.Add(
                "200",
                new OpenApiResponse());
            this.operation.Responses.Add(
                "default",
                new OpenApiResponse());
        }

        [Given("I have an OpenApiOperation with an argument type that lists an undefined property as required")]
        public void GivenIHaveAnOpenApiOperationWithAnArgumentTypeThatListsAnUndefinedPropertyAsRequired()
        {
            var intSchema = new OpenApiSchema
            {
                Type = "integer",
                Format = "int32",
            };
            var schemaListingAnUndefinedPropertyAsRequired = new OpenApiSchema
            {
                Type = "object",
                AdditionalPropertiesAllowed = false,
                Properties = new Dictionary<string, OpenApiSchema>
                {
                    { "RightSpelling", intSchema },
                },
                Required = new HashSet<string> { "WriteSpelngi" },
            };
            var parameter = new OpenApiParameter
            {
                Schema = schemaListingAnUndefinedPropertyAsRequired,
            };
            this.operation = new OpenApiOperation { OperationId = "Ic" };
            this.operation.Responses.Add(
                "200",
                new OpenApiResponse());
            this.operation.Parameters.Add(parameter);

            this.document = new OpenApiDocument
            {
                Paths = new OpenApiPaths(),
            };
            this.document.Paths.Add("/", new OpenApiPathItem { Operations = new Dictionary<OperationType, OpenApiOperation> { { OperationType.Get, this.operation } } });
        }

        [When(@"I pass the OpenApiOperation to OpenApiActionResult\.CanConstructFrom")]
        public void WhenIPassTheOpenApiOperationToOpenApiActionResult_CanConstructFrom()
        {
            this.exception = null;
            try
            {
                var outputBuilder = new PocoActionResultOutputBuilder(
                    Enumerable.Empty<IOpenApiConverter>(),
                    ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<ILogger<PocoActionResultOutputBuilder>>());
                outputBuilder.CanBuildOutput(new object(), this.operation!);
            }
            catch (Exception x)
            {
                this.exception = x;
            }
        }

        [Then("it should throw an OpenApiServiceMismatchException")]
        public void ThenItShouldThrowAnOpenApiServiceMismatchException()
        {
            Assert.IsInstanceOf<OpenApiServiceMismatchException>(this.exception);
        }

        [Given("I have an OpenApiOperation with a 200 response")]
        public void GivenIHaveAnOpenApiOperationWithAResponse()
        {
            this.operation = new OpenApiOperation();
            this.operation.Responses.Add(
                "200",
                new OpenApiResponse());
        }

        [When("I ask the OpenApiExceptionHandler for a response for an unmapped exception")]
        public void WhenIAskTheOpenApiExceptionHandlerForAResponseForAnUnmappedException()
        {
            this.exception = null;
            try
            {
                var exceptionHandler = new OpenApiExceptionMapper(ContainerBindings.GetServiceProvider(this.scenarioContext), new Mock<ILogger<OpenApiExceptionMapper>>().Object);
                exceptionHandler.GetResponse(new InvalidOperationException(), this.operation!);
            }
            catch (Exception x)
            {
                this.exception = x;
            }
        }

        [When("I add the OpenApiDocument containing the OpenApiOperation to a OpenApiDocumentProvider")]
        public void WhenIAddTheOpenApiDocumentContainingTheOpenApiOperationToAOpenApiDocumentProvider()
        {
            this.exception = null;
            var doc = new OpenApiDocumentProvider(new Mock<ILogger<OpenApiDocumentProvider>>().Object);
            try
            {
                doc.Add(this.document!);
            }
            catch (Exception x)
            {
                this.exception = x;
            }
        }
    }
}