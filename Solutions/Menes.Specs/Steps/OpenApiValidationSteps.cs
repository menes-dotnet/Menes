// <copyright file="OpenApiValidationSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Corvus.Testing.SpecFlow;
    using Menes.Exceptions;
    using Menes.Validation;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class OpenApiValidationSteps
    {
        private const string ResultKey = "Result";
        private readonly ScenarioContext scenarioContext;

        private OpenApiDocument? openApiDocument;

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

        [Given("an OpenApi document with the schemas section '(.*)'")]
        public void GivenAnOpenApiDocumentWithTheSchemasSection(string schemas)
        {
            string doc = "{ "
                + "'openapi': '3.0.0',"
                + "'info': { 'version': '1.0.0', 'title': 'Career Canvas' },"
                + "'paths': {},"
                + "'components': {"
                + "'schemas': " + schemas + " } }";
            this.openApiDocument = new OpenApiStreamReader()
                .Read(new MemoryStream(Encoding.UTF8.GetBytes(doc)), out OpenApiDiagnostic diagnostics);
            Assert.AreEqual(
                0,
                diagnostics.Errors.Count,
                $"Test OpenAPI document had errors: {string.Join(", ", diagnostics.Errors.Select(e => e.ToString()))}");
        }

        [Given("I am using the schema '(.*)' from the OpenApi document")]
        public void GivenIAmUsingTheSchemaFromTheOpenApiDocument(string schemaName)
        {
            this.scenarioContext.Set(this.openApiDocument!.Components.Schemas[schemaName]);
        }

        [Given("the payload '(.*)'")]
        public void GivenThePayload(string payload)
        {
            this.scenarioContext.Set(JToken.Parse(payload));
        }

        [When("I validate the payload against the schema")]
        public void WhenIValidateThePayloadAgainstTheSchema()
        {
            OpenApiSchema schema = this.scenarioContext.Get<OpenApiSchema>();
            JToken payload = this.scenarioContext.Get<JToken>();

            OpenApiSchemaValidator validator = ContainerBindings.GetServiceProvider(this.scenarioContext).GetService<OpenApiSchemaValidator>();
            try
            {
                validator.ValidateAndThrow(payload, schema);
                this.scenarioContext.Set(true, ResultKey);
            }
            catch (OpenApiBadRequestException ex)
            {
                this.scenarioContext.Set(false, ResultKey);
                this.scenarioContext.Set(ex, "Exception");
            }
        }

        [Then("the result should be valid")]
        public void ThenTheResultShouldBeValid()
        {
            Assert.IsTrue(this.scenarioContext.Get<bool>(ResultKey));
        }

        [Then("the result should be invalid")]
        public void ThenTheResultShouldBeInvalid()
        {
            Assert.IsFalse(this.scenarioContext.Get<bool>(ResultKey));
        }
    }
}
