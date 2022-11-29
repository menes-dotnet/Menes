// <copyright file="Steps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class Steps
    {
        private static readonly HttpClient HttpClient = HttpClientFactory.Create();

        private static readonly Uri BaseUri = new("http://localhost:7071");

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

        [When("I request the pet with Id (.*)")]
        public Task WhenIRequestThePetWithId(int petId)
        {
            return this.SendGetRequest($"/pets/{petId}");
        }

        [When("I request that a new pet be created")]
        public Task WhenIRequestThatANewPetBeCreated(Table table)
        {
            if (table.RowCount != 1)
            {
                Assert.Fail("Exactly one row of pet details must be supplied.");
            }

            TableRow petRow = table.Rows[0];

            // We want to be able to send invalid values for Id to test that the validation is working correctly.
            // But if the value is a valid integer, we need to make sure it's passed correctly, so...
            string? idFieldValue = ParseStringValue(petRow["Id"]);
            object? id = long.TryParse(idFieldValue, out long idAsLong)
                ? idAsLong
                : idFieldValue;

            var pet = new
            {
                id,
                name = ParseStringValue(petRow["Name"]),
                tag = ParseStringValue(petRow["Tag"]),
                size = ParseStringValue(petRow["Size"]),
            };

            return this.SendPostRequest("/pets", pet);
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
            JToken token = this.GetRequiredTokenFromResponseObject(propertyPath);
            string value = token.Value<string>()!;
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

            Assert.IsTrue(response.Headers.TryGetValues(headerName, out IEnumerable<string>? values));
            Assert.IsNotEmpty(values!);
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
            JToken actualToken = this.GetRequiredTokenFromResponseObject(propertyPath);

            int actualValue = actualToken.Value<int>();
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Then("the response object should have a property called '(.*)'")]
        public void ThenTheResponseObjectShouldHaveAPropertyCalled(string propertyPath)
        {
            this.GetRequiredTokenFromResponseObject(propertyPath);
        }

        [Then("the response object should have a string property called '(.*)' with value '(.*)'")]
        public void ThenTheResponseObjectShouldHaveAStringPropertyCalledWithValue(string propertyPath, string expectedValue)
        {
            JToken actualToken = this.GetRequiredTokenFromResponseObject(propertyPath);

            string? actualValue = actualToken.Value<string>();
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Then("the response object should not have a property called '(.*)'")]
        public void ThenTheResponseObjectShouldNotHaveAPropertyCalled(string propertyPath)
        {
            JObject data = this.scenarioContext.Get<JObject>();
            JToken? token = data.SelectToken(propertyPath);
            Assert.IsNull(token);
        }

        [Then("the response object should have an array property called '(.*)' containing (.*) entries")]
        public void ThenTheResponseObjectShouldHaveAnArrayPropertyCalledContainingEntries(string propertyPath, int expectedEntryCount)
        {
            JToken actualToken = this.GetRequiredTokenFromResponseObject(propertyPath);
            JToken[] tokenArray = actualToken.ToArray();
            Assert.AreEqual(expectedEntryCount, tokenArray.Length);
        }

        private async Task SendGetRequest(string path)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(new Uri(BaseUri, path)).ConfigureAwait(false);

            this.scenarioContext.Set(response);

            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!string.IsNullOrEmpty(content))
            {
                var data = JObject.Parse(content);

                this.scenarioContext.Set(data);
            }
        }

        private async Task SendPostRequest(string path, object body)
        {
            string requestContentString = JsonConvert.SerializeObject(body);
            var requestContent = new StringContent(requestContentString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await HttpClient.PostAsync(new Uri(BaseUri, path), requestContent).ConfigureAwait(false);

            this.scenarioContext.Set(response);

            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!string.IsNullOrEmpty(responseContent))
            {
                var data = JObject.Parse(responseContent);

                this.scenarioContext.Set(data);
            }
        }

        private JToken GetRequiredTokenFromResponseObject(string propertyPath)
        {
            JObject data = this.scenarioContext.Get<JObject>();
            JToken? token = data.SelectToken(propertyPath);
            Assert.IsNotNull(token);
            return token!;
        }

        private static string? ParseStringValue(string input, string? valueIfEmpty = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                return valueIfEmpty;
            }

            return input;
        }
    }
}