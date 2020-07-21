// <copyright file="Steps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Specs.Steps
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class Steps
    {
        private static readonly Uri BaseUri = new Uri("http://localhost:7071");

        private readonly ScenarioContext scenarioContext;

        public Steps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [When("I request a list of pets")]
        public Task WhenIRequestAListOfPets()
        {
            return this.SendGetRequest("/pets");
        }

        [Given("I have requested a list of pets with a limit of (.*)")]
        [When("I request a list of pets with a limit of (.*)")]
        public Task WhenIRequestAListOfPetsWithALimitOf(int limit)
        {
            return this.SendGetRequest($"/pets?limit={limit}");
        }

        [When("I request a list of pets using the value of '(.*)' from the previous response object")]
        public Task WhenIRequestAListOfPetsUsingTheValueOfFromThePreviousResponseObject(string propertyPath)
        {
            JToken token = this.GetExpectedTokenFromResponseObject(propertyPath);
            string value = token.Value<string>();
            return this.SendGetRequest(value);
        }

        [Then("the response status code should be '(.*)'")]
        public void ThenTheResponseStatusCodeShouldBe(HttpStatusCode expectedStatusCode)
        {
            HttpResponseMessage response = this.scenarioContext.Get<HttpResponseMessage>();
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
        }

        [Then("the response should contain the '(.*)' header")]
        public void ThenTheResponseShouldContainTheHeader(string headerName)
        {
            HttpResponseMessage response = this.scenarioContext.Get<HttpResponseMessage>();

            Assert.IsTrue(response.Headers.TryGetValues(headerName, out IEnumerable<string> values));
            Assert.IsNotEmpty(values);
        }

        [Then("the response should not contain the '(.*)' header")]
        public void ThenTheResponseShouldNotContainTheHeader(string headerName)
        {
            HttpResponseMessage response = this.scenarioContext.Get<HttpResponseMessage>();

            Assert.IsFalse(response.Headers.Contains(headerName));
        }

        [Then("the response object should have an integer property called '(.*)' with value (.*)")]
        public void ThenTheResponseShouldHaveSetTo(string propertyPath, int expectedValue)
        {
            JToken actualToken = this.GetExpectedTokenFromResponseObject(propertyPath);

            int actualValue = actualToken.Value<int>();
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Then("the response object should have a property called '(.*)'")]
        public void ThenTheResponseObjectShouldHaveAPropertyCalled(string propertyPath)
        {
            this.GetExpectedTokenFromResponseObject(propertyPath);
        }

        [Then("the response object should not have a property called '(.*)'")]
        public void ThenTheResponseObjectShouldNotHaveAPropertyCalled(string propertyPath)
        {
            JObject data = this.scenarioContext.Get<JObject>();
            JToken token = data.SelectToken(propertyPath);
            Assert.IsNull(token);
        }

        [Then(@"the response object should have an array property called '(.*)' containing (.*) entries")]
        public void ThenTheResponseObjectShouldHaveAnArrayPropertyCalledContainingEntries(string propertyPath, int expectedEntryCount)
        {
            JToken actualToken = this.GetExpectedTokenFromResponseObject(propertyPath);
            JToken[] tokenArray = actualToken.ToArray();
            Assert.AreEqual(expectedEntryCount, tokenArray.Length);
        }

        private async Task SendGetRequest(string path)
        {
            using var client = new HttpClient();
            HttpResponseMessage petListResponse = await client.GetAsync(new Uri(BaseUri, path)).ConfigureAwait(false);

            this.scenarioContext.Set(petListResponse);

            string content = await petListResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JObject.Parse(content);

            this.scenarioContext.Set(data);
        }

        private JToken GetExpectedTokenFromResponseObject(string propertyPath)
        {
            JObject data = this.scenarioContext.Get<JObject>();
            JToken token = data.SelectToken(propertyPath);
            Assert.IsNotNull(token);
            return token;
        }
    }
}
