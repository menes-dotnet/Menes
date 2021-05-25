// <copyright file="JsonValuesSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Steps
{
    using System.Text.Json;
    using Menes.Json;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Steps for Json value types.
    /// </summary>
    [Binding]
    public class JsonValuesSteps
    {
        private const string ValueKey = "Value";
        private const string ResultKey = "Result";

        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonValuesSteps"/> class.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public JsonValuesSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        /* string */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonString (.*)")]
        public void GivenTheJsonElementBackedJsonString(string value)
        {
            this.scenarioContext.Set<JsonString>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonString (.*)")]
        public void GivenTheDotnetBackedJsonString(string value)
        {
            this.scenarioContext.Set(new JsonString(value), ValueKey);
        }

        /// <summary>
        /// Compares the value in JsonString in the context variable <c>Value</c> with the expected string, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the string (.*)")]
        public void WhenICompareItToTheString(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonString in the context variable <c>Value</c> with the expected string, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the string to the IJsonValue (.*)")]
        public void WhenICompareTheStringToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonString in the context variable <c>Value</c> with the expected string, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the string to the object (.*)")]
        public void WhenICompareTheStringToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonString>(ValueKey)).Equals(obj), ResultKey);
        }

        /* boolean */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonBoolean (.*)")]
        public void GivenTheJsonElementBackedJsonBoolean(string value)
        {
            this.scenarioContext.Set<JsonBoolean>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonBoolean (.*)")]
        public void GivenTheDotnetBackedJsonBoolean(string value)
        {
            this.scenarioContext.Set(new JsonBoolean(value == "true"), ValueKey);
        }

        /// <summary>
        /// Compares the value in JsonBoolean in the context variable <c>Value</c> with the expected boolean, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the boolean (.*)")]
        public void WhenICompareItToTheBoolean(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBoolean in the context variable <c>Value</c> with the expected boolean, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the boolean to the IJsonValue (.*)")]
        public void WhenICompareTheBooleanToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBoolean in the context variable <c>Value</c> with the expected boolean, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the boolean to the object (.*)")]
        public void WhenICompareTheBooleanToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBoolean>(ValueKey)).Equals(obj), ResultKey);
        }

        /* array */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonArray (.*)")]
        public void GivenTheJsonElementBackedJsonArray(string value)
        {
            this.scenarioContext.Set<JsonArray>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonArray (.*)")]
        public void GivenTheDotnetBackedJsonArray(string value)
        {
            this.scenarioContext.Set(new JsonArray(new JsonArray(((JsonArray)JsonAny.ParseUriValue(value)).AsItemsList)), ValueKey);
        }

        /// <summary>
        /// Compares the value in JsonArray in the context variable <c>Value</c> with the expected array, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the array (.*)")]
        public void WhenICompareItToTheArray(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey).Equals((JsonArray)JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonArray in the context variable <c>Value</c> with the expected array, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the array to the IJsonValue (.*)")]
        public void WhenICompareTheArrayToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonArray in the context variable <c>Value</c> with the expected array, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the array to the object (.*)")]
        public void WhenICompareTheArrayToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonArray>(ValueKey)).Equals(obj), ResultKey);
        }

        /* base64content */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonBase64Content (.*)")]
        public void GivenTheJsonElementBackedJsonBase64Content(string value)
        {
            this.scenarioContext.Set<JsonBase64Content>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonBase64Content (.*)")]
        public void GivenTheDotnetBackedJsonBase64Content(string value)
        {
            this.scenarioContext.Set(new JsonBase64Content(value), ValueKey);
        }

        /// <summary>
        /// Compares the value in JsonBase64Content in the context variable <c>Value</c> with the expected base64Content, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the base64content (.*)")]
        public void WhenICompareItToTheBase64Content(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey).Equals((JsonBase64Content)JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBase64Content in the context variable <c>Value</c> with the expected base64Content, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the base64content to the IJsonValue (.*)")]
        public void WhenICompareTheBase64ContentToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBase64Content in the context variable <c>Value</c> with the expected base64Content, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the base64content to the object (.*)")]
        public void WhenICompareTheBase64ContentToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBase64Content>(ValueKey)).Equals(obj), ResultKey);
        }

        /* base64string */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonBase64String (.*)")]
        public void GivenTheJsonElementBackedJsonBase64String(string value)
        {
            this.scenarioContext.Set<JsonBase64String>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonBase64String (.*)")]
        public void GivenTheDotnetBackedJsonBase64String(string value)
        {
            this.scenarioContext.Set(new JsonBase64String(value), ValueKey);
        }

        /// <summary>
        /// Compares the value in JsonBase64String in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the base64string (.*)")]
        public void WhenICompareItToTheBase64String(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey).Equals((JsonBase64String)JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBase64String in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the base64string to the IJsonValue (.*)")]
        public void WhenICompareTheBase64StringToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBase64String in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the base64string to the object (.*)")]
        public void WhenICompareTheBase64StringToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBase64String>(ValueKey)).Equals(obj), ResultKey);
        }

        /// <summary>
        /// Asserts that the result from a previous comparison stored in the context variable <c>Result</c> is as expected.
        /// </summary>
        /// <param name="expected">The expected result.</param>
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(bool expected)
        {
            Assert.AreEqual(expected, this.scenarioContext.Get<bool>(ResultKey));
        }
    }
}
