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
        private const string EqualsResultKey = "EqualsResult";
        private const string EqualityResultKey = "EqualityResult";
        private const string InequalityResultKey = "InequalityResult";

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
            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey).Equals((JsonString)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey) == (JsonString)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey) != (JsonString)JsonAny.ParseUriValue(expected), InequalityResultKey);
        }

        /// <summary>
        /// Compares the value in JsonString in the context variable <c>Value</c> with the expected string, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the string to the IJsonValue (.*)")]
        public void WhenICompareTheStringToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonString in the context variable <c>Value</c> with the expected string, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the string to the object (.*)")]
        public void WhenICompareTheStringToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonString>(ValueKey)).Equals(obj), EqualsResultKey);
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
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey).Equals((JsonBoolean)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey) == (JsonBoolean)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey) != (JsonBoolean)JsonAny.ParseUriValue(expected), InequalityResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBoolean in the context variable <c>Value</c> with the expected boolean, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the boolean to the IJsonValue (.*)")]
        public void WhenICompareTheBooleanToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBoolean in the context variable <c>Value</c> with the expected boolean, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the boolean to the object (.*)")]
        public void WhenICompareTheBooleanToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBoolean>(ValueKey)).Equals(obj), EqualsResultKey);
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
            this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey).Equals((JsonArray)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey) == (JsonArray)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey) != (JsonArray)JsonAny.ParseUriValue(expected), InequalityResultKey);
        }

        /// <summary>
        /// Compares the value in JsonArray in the context variable <c>Value</c> with the expected array, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the array to the IJsonValue (.*)")]
        public void WhenICompareTheArrayToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonArray in the context variable <c>Value</c> with the expected array, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the array to the object (.*)")]
        public void WhenICompareTheArrayToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonArray>(ValueKey)).Equals(obj), EqualsResultKey);
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
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey).Equals((JsonBase64Content)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey) == (JsonBase64Content)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey) != (JsonBase64Content)JsonAny.ParseUriValue(expected), InequalityResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBase64Content in the context variable <c>Value</c> with the expected base64Content, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the base64content to the IJsonValue (.*)")]
        public void WhenICompareTheBase64ContentToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBase64Content in the context variable <c>Value</c> with the expected base64Content, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the base64content to the object (.*)")]
        public void WhenICompareTheBase64ContentToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBase64Content>(ValueKey)).Equals(obj), EqualsResultKey);
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
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey).Equals((JsonBase64String)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey) == (JsonBase64String)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey) != (JsonBase64String)JsonAny.ParseUriValue(expected), InequalityResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBase64String in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the base64string to the IJsonValue (.*)")]
        public void WhenICompareTheBase64StringToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonBase64String in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the base64string to the object (.*)")]
        public void WhenICompareTheBase64StringToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBase64String>(ValueKey)).Equals(obj), EqualsResultKey);
        }

        /* content */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonContent (.*)")]
        public void GivenTheJsonElementBackedJsonContent(string value)
        {
            this.scenarioContext.Set<JsonContent>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonContent (.*)")]
        public void GivenTheDotnetBackedJsonContent(string value)
        {
            this.scenarioContext.Set(new JsonContent((string)JsonAny.ParseUriValue(value)), ValueKey);
        }

        /// <summary>
        /// Compares the value in JsonContent in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the content (.*)")]
        public void WhenICompareItToTheContent(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonContent>(ValueKey).Equals((JsonContent)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonContent>(ValueKey) == (JsonContent)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonContent>(ValueKey) != (JsonContent)JsonAny.ParseUriValue(expected), InequalityResultKey);
        }

        /// <summary>
        /// Compares the value in JsonContent in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the content to the IJsonValue (.*)")]
        public void WhenICompareTheContentToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonContent>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonContent in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the content to the object (.*)")]
        public void WhenICompareTheContentToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonContent>(ValueKey)).Equals(obj), EqualsResultKey);
        }

        /* date */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonDate (.*)")]
        public void GivenTheJsonElementBackedJsonDate(string value)
        {
            this.scenarioContext.Set<JsonDate>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonDate (.*)")]
        public void GivenTheDotnetBackedJsonDate(string value)
        {
            this.scenarioContext.Set(new JsonDate((string)JsonAny.ParseUriValue(value)), ValueKey);
        }

        /// <summary>
        /// Compares the value in JsonDate in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the date (.*)")]
        public void WhenICompareItToTheDate(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDate>(ValueKey).Equals((JsonDate)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDate>(ValueKey) == (JsonDate)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDate>(ValueKey) != (JsonDate)JsonAny.ParseUriValue(expected), InequalityResultKey);
        }

        /// <summary>
        /// Compares the value in JsonDate in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the date to the IJsonValue (.*)")]
        public void WhenICompareTheDateToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDate>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonDate in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the date to the object (.*)")]
        public void WhenICompareTheDateToTheObject(string expected)
        {
            object? obj = expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonDate>(ValueKey)).Equals(obj), EqualsResultKey);
        }

        /// <summary>
        /// Asserts that the result from a previous comparison stored in the context variable <c>Result</c> is as expected.
        /// </summary>
        /// <param name="expected">The expected result.</param>
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(bool expected)
        {
            Assert.AreEqual(expected, this.scenarioContext.Get<bool>(EqualsResultKey));
            if (this.scenarioContext.ContainsKey(EqualityResultKey))
            {
                Assert.AreEqual(expected, this.scenarioContext.Get<bool>(EqualityResultKey));
            }

            if (this.scenarioContext.ContainsKey(InequalityResultKey))
            {
                Assert.AreNotEqual(expected, this.scenarioContext.Get<bool>(InequalityResultKey));
            }
        }
    }
}
