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
        private const string EqualsObjectBackedResultKey = "EqualsObjectBackedResult";
        private const string EqualityResultKey = "EqualityResult";
        private const string InequalityResultKey = "InequalityResult";
        private const string HashCodeResultKey = "HashCodeResult";

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
            if (value == "null")
            {
                this.scenarioContext.Set(JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonString((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonString in the context variable <c>Value</c> with the expected string, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the string (.*)")]
        public void WhenICompareItToTheString(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey).Equals(new JsonString((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey).Equals((JsonString)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey) == (JsonString)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey) != (JsonString)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonString>(ValueKey).GetHashCode() == ((JsonString)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
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
            object? obj = expected == "<undefined>" ? default(JsonString) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonString>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonString>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
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
            if (value == "null")
            {
                this.scenarioContext.Set(JsonNull.Instance.AsAny.AsBoolean, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonBoolean(value == "true"), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonBoolean in the context variable <c>Value</c> with the expected boolean, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the boolean (.*)")]
        public void WhenICompareItToTheBoolean(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey).Equals(new JsonBoolean((bool)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey).Equals((JsonBoolean)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey) == (JsonBoolean)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey) != (JsonBoolean)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey).GetHashCode() == ((JsonBoolean)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
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
            object? obj = expected == "<undefined>" ? default(JsonBoolean) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBoolean>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonBoolean>(ValueKey).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
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
            if (value == "null")
            {
                this.scenarioContext.Set(JsonNull.Instance.AsAny.AsArray, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonArray(new JsonArray(((JsonArray)JsonAny.ParseUriValue(value)).AsItemsList)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonArray in the context variable <c>Value</c> with the expected array, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the array (.*)")]
        public void WhenICompareItToTheArray(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey).Equals(new JsonArray(((JsonArray)JsonAny.ParseUriValue(expected)).AsItemsList)), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey).Equals((JsonArray)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey) == (JsonArray)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey) != (JsonArray)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey).GetHashCode() == ((JsonArray)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
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
            object? obj = expected == "<undefined>" ? default(JsonArray) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonArray>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(ValueKey).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
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
            if (value == "null")
            {
                this.scenarioContext.Set((JsonBase64Content)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonBase64Content(JsonAny.ParseUriValue(value).AsString.GetString()), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonBase64Content in the context variable <c>Value</c> with the expected base64Content, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the base64content (.*)")]
        public void WhenICompareItToTheBase64Content(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey).Equals(new JsonBase64Content((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey).Equals((JsonBase64Content)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey) == (JsonBase64Content)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey) != (JsonBase64Content)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64Content>(ValueKey).GetHashCode() == ((JsonBase64Content)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
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
            object? obj = expected == "<undefined>" ? default(JsonBase64Content) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBase64Content>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBase64Content>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
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
            if (value == "null")
            {
                this.scenarioContext.Set((JsonBase64String)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonBase64String(JsonAny.ParseUriValue(value).AsString.GetString()), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonBase64String in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the base64string (.*)")]
        public void WhenICompareItToTheBase64String(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey).Equals(new JsonBase64String((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey).Equals((JsonBase64String)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey) == (JsonBase64String)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey) != (JsonBase64String)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonBase64String>(ValueKey).GetHashCode() == ((JsonBase64String)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
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
            object? obj = expected == "<undefined>" ? default(JsonBase64String) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBase64String>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonBase64String>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
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
            if (value == "null")
            {
                this.scenarioContext.Set((JsonContent)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonContent((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonContent in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the content (.*)")]
        public void WhenICompareItToTheContent(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonContent>(ValueKey).Equals(new JsonContent((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonContent>(ValueKey).Equals((JsonContent)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonContent>(ValueKey) == (JsonContent)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonContent>(ValueKey) != (JsonContent)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonContent>(ValueKey).GetHashCode() == ((JsonContent)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
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
            object? obj = expected == "<undefined>" ? default(JsonContent) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonContent>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonContent>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
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
            if (value == "null")
            {
                this.scenarioContext.Set((JsonDate)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonDate((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonDate in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the date (.*)")]
        public void WhenICompareItToTheDate(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonDate>(ValueKey).Equals(new JsonDate((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonDate>(ValueKey).Equals((JsonDate)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDate>(ValueKey) == (JsonDate)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDate>(ValueKey) != (JsonDate)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDate>(ValueKey).GetHashCode() == ((JsonDate)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
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
            object? obj = expected == "<undefined>" ? default(JsonDate) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonDate>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonDate>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* dateTime */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonDateTime (.*)")]
        public void GivenTheJsonElementBackedJsonDateTime(string value)
        {
            this.scenarioContext.Set<JsonDateTime>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonDateTime (.*)")]
        public void GivenTheDotnetBackedJsonDateTime(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonDateTime)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonDateTime((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonDateTime in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the dateTime (.*)")]
        public void WhenICompareItToTheDateTime(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonDateTime>(ValueKey).Equals(new JsonDateTime((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonDateTime>(ValueKey).Equals((JsonDateTime)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDateTime>(ValueKey) == (JsonDateTime)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDateTime>(ValueKey) != (JsonDateTime)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDateTime>(ValueKey).GetHashCode() == ((JsonDateTime)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonDateTime in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the dateTime to the IJsonValue (.*)")]
        public void WhenICompareTheDateTimeToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDateTime>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonDateTime in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the dateTime to the object (.*)")]
        public void WhenICompareTheDateTimeToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonDateTime) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonDateTime>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonDateTime>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* duration */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonDuration (.*)")]
        public void GivenTheJsonElementBackedJsonDuration(string value)
        {
            this.scenarioContext.Set<JsonDuration>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonDuration (.*)")]
        public void GivenTheDotnetBackedJsonDuration(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonDuration)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonDuration((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonDuration in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the duration (.*)")]
        public void WhenICompareItToTheDuration(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonDuration>(ValueKey).Equals(new JsonDuration((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonDuration>(ValueKey).Equals((JsonDuration)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDuration>(ValueKey) == (JsonDuration)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDuration>(ValueKey) != (JsonDuration)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDuration>(ValueKey).GetHashCode() == ((JsonDuration)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonDuration in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the duration to the IJsonValue (.*)")]
        public void WhenICompareTheDurationToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonDuration>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonDuration in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the duration to the object (.*)")]
        public void WhenICompareTheDurationToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonDuration) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonDuration>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonDuration>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* email */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonEmail (.*)")]
        public void GivenTheJsonElementBackedJsonEmail(string value)
        {
            this.scenarioContext.Set<JsonEmail>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonEmail (.*)")]
        public void GivenTheDotnetBackedJsonEmail(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonEmail)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonEmail((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonEmail in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the email (.*)")]
        public void WhenICompareItToTheEmail(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonEmail>(ValueKey).Equals(new JsonEmail((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonEmail>(ValueKey).Equals((JsonEmail)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonEmail>(ValueKey) == (JsonEmail)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonEmail>(ValueKey) != (JsonEmail)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonEmail>(ValueKey).GetHashCode() == ((JsonEmail)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonEmail in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the email to the IJsonValue (.*)")]
        public void WhenICompareTheEmailToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonEmail>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonEmail in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the email to the object (.*)")]
        public void WhenICompareTheEmailToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonEmail) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonEmail>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonEmail>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* idnEmail */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonIdnEmail (.*)")]
        public void GivenTheJsonElementBackedJsonIdnEmail(string value)
        {
            this.scenarioContext.Set<JsonIdnEmail>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonIdnEmail (.*)")]
        public void GivenTheDotnetBackedJsonIdnEmail(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonIdnEmail)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonIdnEmail((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonIdnEmail in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the idnEmail (.*)")]
        public void WhenICompareItToTheIdnEmail(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnEmail>(ValueKey).Equals(new JsonIdnEmail((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnEmail>(ValueKey).Equals((JsonIdnEmail)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnEmail>(ValueKey) == (JsonIdnEmail)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnEmail>(ValueKey) != (JsonIdnEmail)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnEmail>(ValueKey).GetHashCode() == ((JsonIdnEmail)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIdnEmail in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the idnEmail to the IJsonValue (.*)")]
        public void WhenICompareTheIdnEmailToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnEmail>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIdnEmail in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the idnEmail to the object (.*)")]
        public void WhenICompareTheIdnEmailToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonIdnEmail) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIdnEmail>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIdnEmail>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* hostname */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonHostname (.*)")]
        public void GivenTheJsonElementBackedJsonHostname(string value)
        {
            this.scenarioContext.Set<JsonHostname>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonHostname (.*)")]
        public void GivenTheDotnetBackedJsonHostname(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonHostname)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonHostname((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonHostname in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the hostname (.*)")]
        public void WhenICompareItToTheHostname(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonHostname>(ValueKey).Equals(new JsonHostname((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonHostname>(ValueKey).Equals((JsonHostname)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonHostname>(ValueKey) == (JsonHostname)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonHostname>(ValueKey) != (JsonHostname)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonHostname>(ValueKey).GetHashCode() == ((JsonHostname)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonHostname in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the hostname to the IJsonValue (.*)")]
        public void WhenICompareTheHostnameToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonHostname>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonHostname in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the hostname to the object (.*)")]
        public void WhenICompareTheHostnameToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonHostname) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonHostname>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonHostname>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* idnHostname */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonIdnHostname (.*)")]
        public void GivenTheJsonElementBackedJsonIdnHostname(string value)
        {
            this.scenarioContext.Set<JsonIdnHostname>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonIdnHostname (.*)")]
        public void GivenTheDotnetBackedJsonIdnHostname(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonIdnHostname)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonIdnHostname((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonIdnHostname in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the idnHostname (.*)")]
        public void WhenICompareItToTheIdnHostname(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnHostname>(ValueKey).Equals(new JsonIdnHostname((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnHostname>(ValueKey).Equals((JsonIdnHostname)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnHostname>(ValueKey) == (JsonIdnHostname)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnHostname>(ValueKey) != (JsonIdnHostname)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnHostname>(ValueKey).GetHashCode() == ((JsonIdnHostname)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIdnHostname in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the idnHostname to the IJsonValue (.*)")]
        public void WhenICompareTheIdnHostnameToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIdnHostname>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIdnHostname in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the idnHostname to the object (.*)")]
        public void WhenICompareTheIdnHostnameToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonIdnHostname) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIdnHostname>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIdnHostname>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* integer */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonInteger (.*)")]
        public void GivenTheJsonElementBackedJsonInteger(string value)
        {
            this.scenarioContext.Set<JsonInteger>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonInteger (.*)")]
        public void GivenTheDotnetBackedJsonInteger(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonInteger)JsonNull.Instance.AsAny.AsNumber, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonInteger((long)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonInteger in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the integer (.*)")]
        public void WhenICompareItToTheInteger(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonInteger>(ValueKey).Equals(new JsonInteger((long)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonInteger>(ValueKey).Equals((JsonInteger)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonInteger>(ValueKey) == (JsonInteger)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonInteger>(ValueKey) != (JsonInteger)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonInteger>(ValueKey).GetHashCode() == ((JsonInteger)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonInteger in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the integer to the IJsonValue (.*)")]
        public void WhenICompareTheIntegerToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonInteger>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonInteger in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the integer to the object (.*)")]
        public void WhenICompareTheIntegerToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonInteger) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonInteger>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonInteger>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* number */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonNumber (.*)")]
        public void GivenTheJsonElementBackedJsonNumber(string value)
        {
            this.scenarioContext.Set<JsonNumber>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonNumber (.*)")]
        public void GivenTheDotnetBackedJsonNumber(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set(JsonNull.Instance.AsAny.AsNumber, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonNumber((double)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonNumber in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the number (.*)")]
        public void WhenICompareItToTheNumber(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonNumber>(ValueKey).Equals(new JsonNumber((double)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonNumber>(ValueKey).Equals((JsonNumber)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonNumber>(ValueKey) == (JsonNumber)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonNumber>(ValueKey) != (JsonNumber)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonNumber>(ValueKey).GetHashCode() == ((JsonNumber)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonNumber in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the number to the IJsonValue (.*)")]
        public void WhenICompareTheNumberToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonNumber>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonNumber in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the number to the object (.*)")]
        public void WhenICompareTheNumberToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonNumber) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonNumber>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonNumber>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* ipV4 */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonIpV4 (.*)")]
        public void GivenTheJsonElementBackedJsonIpV4(string value)
        {
            this.scenarioContext.Set<JsonIpV4>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonIpV4 (.*)")]
        public void GivenTheDotnetBackedJsonIpV4(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonIpV4)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonIpV4((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonIpV4 in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the ipV4 (.*)")]
        public void WhenICompareItToTheIpV4(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV4>(ValueKey).Equals(new JsonIpV4((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV4>(ValueKey).Equals((JsonIpV4)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV4>(ValueKey) == (JsonIpV4)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV4>(ValueKey) != (JsonIpV4)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV4>(ValueKey).GetHashCode() == ((JsonIpV4)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIpV4 in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the ipV4 to the IJsonValue (.*)")]
        public void WhenICompareTheIpV4ToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV4>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIpV4 in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the ipV4 to the object (.*)")]
        public void WhenICompareTheIpV4ToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonIpV4) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIpV4>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIpV4>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* ipV6 */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonIpV6 (.*)")]
        public void GivenTheJsonElementBackedJsonIpV6(string value)
        {
            this.scenarioContext.Set<JsonIpV6>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonIpV6 (.*)")]
        public void GivenTheDotnetBackedJsonIpV6(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonIpV6)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonIpV6((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonIpV6 in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the ipV6 (.*)")]
        public void WhenICompareItToTheIpV6(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV6>(ValueKey).Equals(new JsonIpV6((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV6>(ValueKey).Equals((JsonIpV6)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV6>(ValueKey) == (JsonIpV6)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV6>(ValueKey) != (JsonIpV6)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV6>(ValueKey).GetHashCode() == ((JsonIpV6)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIpV6 in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the ipV6 to the IJsonValue (.*)")]
        public void WhenICompareTheIpV6ToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIpV6>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIpV6 in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the ipV6 to the object (.*)")]
        public void WhenICompareTheIpV6ToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonIpV6) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIpV6>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIpV6>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* uri */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonUri (.*)")]
        public void GivenTheJsonElementBackedJsonUri(string value)
        {
            this.scenarioContext.Set<JsonUri>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonUri (.*)")]
        public void GivenTheDotnetBackedJsonUri(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonUri)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonUri((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonUri in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the uri (.*)")]
        public void WhenICompareItToTheUri(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonUri>(ValueKey).Equals(new JsonUri((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonUri>(ValueKey).Equals((JsonUri)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonUri>(ValueKey) == (JsonUri)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonUri>(ValueKey) != (JsonUri)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonUri>(ValueKey).GetHashCode() == ((JsonUri)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonUri in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the uri to the IJsonValue (.*)")]
        public void WhenICompareTheUriToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonUri>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonUri in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the uri to the object (.*)")]
        public void WhenICompareTheUriToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonUri) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonUri>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonUri>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* uriReference */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonUriReference (.*)")]
        public void GivenTheJsonElementBackedJsonUriReference(string value)
        {
            this.scenarioContext.Set<JsonUriReference>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonUriReference (.*)")]
        public void GivenTheDotnetBackedJsonUriReference(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonUriReference)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonUriReference((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonUriReference in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the uriReference (.*)")]
        public void WhenICompareItToTheUriReference(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonUriReference>(ValueKey).Equals(new JsonUriReference((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonUriReference>(ValueKey).Equals((JsonUriReference)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonUriReference>(ValueKey) == (JsonUriReference)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonUriReference>(ValueKey) != (JsonUriReference)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonUriReference>(ValueKey).GetHashCode() == ((JsonUriReference)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonUriReference in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the uriReference to the IJsonValue (.*)")]
        public void WhenICompareTheUriReferenceToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonUriReference>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonUriReference in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the uriReference to the object (.*)")]
        public void WhenICompareTheUriReferenceToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonUriReference) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonUriReference>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonUriReference>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* iri */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonIri (.*)")]
        public void GivenTheJsonElementBackedJsonIri(string value)
        {
            this.scenarioContext.Set<JsonIri>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonIri (.*)")]
        public void GivenTheDotnetBackedJsonIri(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonIri)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonIri((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonIri in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the iri (.*)")]
        public void WhenICompareItToTheIri(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonIri>(ValueKey).Equals(new JsonIri((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonIri>(ValueKey).Equals((JsonIri)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIri>(ValueKey) == (JsonIri)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIri>(ValueKey) != (JsonIri)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIri>(ValueKey).GetHashCode() == ((JsonIri)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIri in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the iri to the IJsonValue (.*)")]
        public void WhenICompareTheIriToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIri>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIri in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the iri to the object (.*)")]
        public void WhenICompareTheIriToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonIri) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIri>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIri>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
        }

        /* iriReference */

        /// <summary>
        /// Store a <see cref="JsonElement"/>-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The json value.</param>
        [Given(@"the JsonElement backed JsonIriReference (.*)")]
        public void GivenTheJsonElementBackedJsonIriReference(string value)
        {
            this.scenarioContext.Set<JsonIriReference>(JsonAny.ParseUriValue(value), ValueKey);
        }

        /// <summary>
        /// Store a dotnet-type-backed value in the context variable <c>Value</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        [Given(@"the dotnet backed JsonIriReference (.*)")]
        public void GivenTheDotnetBackedJsonIriReference(string value)
        {
            if (value == "null")
            {
                this.scenarioContext.Set((JsonIriReference)JsonNull.Instance.AsAny.AsString, ValueKey);
            }
            else
            {
                this.scenarioContext.Set(new JsonIriReference((string)JsonAny.ParseUriValue(value)), ValueKey);
            }
        }

        /// <summary>
        /// Compares the value in JsonIriReference in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare it to the iriReference (.*)")]
        public void WhenICompareItToTheIriReference(string expected)
        {
            if (expected != "null")
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonIriReference>(ValueKey).Equals(new JsonIriReference((string)JsonAny.ParseUriValue(expected))), EqualsObjectBackedResultKey);
            }

            this.scenarioContext.Set(this.scenarioContext.Get<JsonIriReference>(ValueKey).Equals((JsonIriReference)JsonAny.ParseUriValue(expected)), EqualsResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIriReference>(ValueKey) == (JsonIriReference)JsonAny.ParseUriValue(expected), EqualityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIriReference>(ValueKey) != (JsonIriReference)JsonAny.ParseUriValue(expected), InequalityResultKey);
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIriReference>(ValueKey).GetHashCode() == ((JsonIriReference)JsonAny.ParseUriValue(expected)).GetHashCode(), HashCodeResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIriReference in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the iriReference to the IJsonValue (.*)")]
        public void WhenICompareTheIriReferenceToTheIJsonValue(string expected)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonIriReference>(ValueKey).Equals(JsonAny.ParseUriValue(expected)), EqualsResultKey);
        }

        /// <summary>
        /// Compares the value in JsonIriReference in the context variable <c>Value</c> with the expected base64String, and set it into the context variable <c>Result</c>.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        [When(@"I compare the iriReference to the object (.*)")]
        public void WhenICompareTheIriReferenceToTheObject(string expected)
        {
            object? obj = expected == "<undefined>" ? default(JsonIriReference) : expected == "<null>" ? null : expected == "<new object()>" ? new object() : JsonAny.ParseUriValue(expected);
            this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIriReference>(ValueKey)).Equals(obj), EqualsResultKey);
            if (obj is not null)
            {
                this.scenarioContext.Set(((object)this.scenarioContext.Get<JsonIriReference>(ValueKey)).GetHashCode() == obj.GetHashCode(), HashCodeResultKey);
            }
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

            if (this.scenarioContext.ContainsKey(HashCodeResultKey))
            {
                Assert.AreEqual(expected, this.scenarioContext.Get<bool>(HashCodeResultKey));
            }

            if (this.scenarioContext.ContainsKey(EqualsObjectBackedResultKey))
            {
                Assert.AreEqual(expected, this.scenarioContext.Get<bool>(EqualsObjectBackedResultKey));
            }
        }
    }
}
