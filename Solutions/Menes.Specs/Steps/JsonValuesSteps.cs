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
        /// Compares the value in JsonString in the context variable <c>Value</c> with the expected string, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the string (.*)")]
        public void WhenICompareItToTheString(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey).Equals(expected), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBoolean in the context variable <c>Value</c> with the expected boolean, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the boolean (.*)")]
        public void WhenICompareItToTheBoolean(bool expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey).Equals(expected), ResultKey);
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
        /// Compares the value in JsonBoolean in the context variable <c>Value</c> with the expected boolean, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the boolean to the IJsonValue (.*)")]
        public void WhenICompareTheBooleanToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonString in the context variable <c>Value</c> with the expected string, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the string to the object (.*)")]
        public void WhenICompareTheStringToTheObject(string expected)
        {
            object? obj = JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonString>(ValueKey)).Equals(obj), ResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBoolean in the context variable <c>Value</c> with the expected boolean, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the boolean to the object (.*)")]
        public void WhenICompareTheBooleanToTheObject(string expected)
        {
            object? obj = JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBoolean>(ValueKey)).Equals(obj), ResultKey);
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
