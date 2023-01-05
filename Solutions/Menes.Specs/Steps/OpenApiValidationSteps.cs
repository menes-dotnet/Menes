// <copyright file="OpenApiValidationSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;

    using Corvus.Testing.SpecFlow;

    using Menes.Exceptions;
    using Menes.Validation;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    [Binding]
    public class OpenApiValidationSteps
    {
        private readonly ScenarioContext scenarioContext;
        private string? payload;
        private bool result;
        private Exception? ex;

        public OpenApiValidationSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("the schema '(.*)'")]
        public void GivenTheSchema(string schema)
        {
            var reader = new OpenApiStringReader();
            OpenApiSchema openApiSchema = reader.ReadFragment<OpenApiSchema>(schema, OpenApiSpecVersion.OpenApi3_0, out OpenApiDiagnostic diagnostic);

            if (diagnostic.Errors.Count > 0)
            {
                throw new ArgumentException("Invalid schema", nameof(schema));
            }

            this.scenarioContext.Set(openApiSchema);
        }

        [Given("the payload '(.*)'")]
        public void GivenThePayload(string payload)
        {
            this.payload = payload;
        }

        [When("I validate the payload against the schema")]
        public void WhenIValidateThePayloadAgainstTheSchema()
        {
            OpenApiSchema schema = this.scenarioContext.Get<OpenApiSchema>();

            OpenApiSchemaValidator validator = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<OpenApiSchemaValidator>();
            try
            {
                validator.ValidateAndThrow(this.payload!, schema);
                this.result = true;
            }
            catch (OpenApiInvalidFormatException ex)
            {
                this.result = false;
                this.ex = ex;
            }
        }

        [Then("the result should be valid")]
        public void ThenTheResultShouldBeValid()
        {
            Assert.IsTrue(this.result, this.ex?.ToString() ?? "(No exception)");
        }

        [Then("the result should be invalid")]
        public void ThenTheResultShouldBeInvalid()
        {
            Assert.IsFalse(this.result);
        }
    }
}