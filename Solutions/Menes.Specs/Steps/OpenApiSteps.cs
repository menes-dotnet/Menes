// <copyright file="OpenApiSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Steps
{
    using System.Threading.Tasks;
    using Drivers;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Step definitions for the OpenApi specs.
    /// </summary>
    [Binding]
    public class OpenApiSteps
    {
        private const string InputOpenApiDocument = "InputOpenApiDocument";
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;
        private readonly OpenApiServiceBuilderDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiSteps"/> class.
        /// </summary>
        /// <param name="featureContext">The current feature context.</param>
        /// <param name="scenarioContext">The current scenario context.</param>
        /// <param name="driver">The openapi service builder driver.</param>
        public OpenApiSteps(FeatureContext featureContext, ScenarioContext scenarioContext, OpenApiServiceBuilderDriver driver)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
            this.driver = driver;
        }

        /// <summary>
        /// Puts the initial OpenApi document reference in a scenario property called <see cref="InputOpenApiDocument"/>.
        /// </summary>
        /// <param name="inputFileNameOrUri">The OpenAPI document file name in JSON syntax.</param>
        [Given(@"the input OpenApi document ""(.*)""")]
        public void GivenTheInputOpenApiDocument(string inputFileNameOrUri)
        {
            this.scenarioContext.Add(InputOpenApiDocument, inputFileNameOrUri);
        }

        /// <summary>
        /// Builds the services defined in the document found in the scenario property called <see cref="InputOpenApiDocument"/>.
        /// </summary>
        /// <returns>A task which completes when the service has been built.</returns>
        [When(@"I build the service")]
        public async Task WhenIBuildTheService()
        {
            await this.driver.BuildServices(this.scenarioContext.Get<string>(InputOpenApiDocument));
        }
    }
}
