// <copyright file="JsonPropertiesSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Steps
{
    using System;
    using System.Text;
    using Menes.Json;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Steps for Json value types.
    /// </summary>
    [Binding]
    public class JsonPropertiesSteps
    {
        private const string ObjectResult = "ObjectResult";

        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPropertiesSteps"/> class.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public JsonPropertiesSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Set a property to an <see cref="JsonObject"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The serialized value of the property.</param>
        [When(@"I set the property (.*) to the value (.*) on the JsonObject using a string")]
        public void WhenISetThePropertyNamedWithValueToTheJsonObject(string propertyName, string value)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonObject>(JsonValueSteps.SubjectUnderTest).SetProperty(propertyName, JsonAny.ParseUriValue(value)), ObjectResult);
        }

        /// <summary>
        /// Set a property to an <see cref="JsonAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The serialized value of the property.</param>
        [When(@"I set the property (.*) to the value (.*) on the JsonAny using a string")]
        public void WhenISetThePropertyNamedWithValueToTheJsonAny(string propertyName, string value)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest).SetProperty(propertyName, JsonAny.ParseUriValue(value)), ObjectResult);
        }

        /// <summary>
        /// Set a property to an <see cref="JsonNotAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The serialized value of the property.</param>
        [When(@"I set the property (.*) to the value (.*) on the JsonNotAny using a string")]
        public void WhenISetThePropertyNamedWithValueToTheJsonNotAny(string propertyName, string value)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonNotAny>(JsonValueSteps.SubjectUnderTest).SetProperty(propertyName, JsonAny.ParseUriValue(value)), ObjectResult);
        }

        /// <summary>
        /// Set a property to an <see cref="JsonObject"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The serialized value of the property.</param>
        [When(@"I set the property (.*) to the value (.*) on the JsonObject using a ReadOnlySpan<char>")]
        public void WhenISetThePropertyNamedWithValueToTheJsonObjectUsingAReadOnlySpanChar(string propertyName, string value)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonObject>(JsonValueSteps.SubjectUnderTest).SetProperty(propertyName.AsSpan(), JsonAny.ParseUriValue(value)), ObjectResult);
        }

        /// <summary>
        /// Set a property to an <see cref="JsonAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The serialized value of the property.</param>
        [When(@"I set the property (.*) to the value (.*) on the JsonAny using a ReadOnlySpan<char>")]
        public void WhenISetThePropertyNamedWithValueToTheJsonAnyUsingAReadOnlySpanChar(string propertyName, string value)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest).SetProperty(propertyName.AsSpan(), JsonAny.ParseUriValue(value)), ObjectResult);
        }

        /// <summary>
        /// Set a property to an <see cref="JsonNotAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The serialized value of the property.</param>
        [When(@"I set the property (.*) to the value (.*) on the JsonNotAny using a ReadOnlySpan<char>")]
        public void WhenISetThePropertyNamedWithValueToTheJsonNotAnyUsingAReadOnlySpanChar(string propertyName, string value)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonNotAny>(JsonValueSteps.SubjectUnderTest).SetProperty(propertyName.AsSpan(), JsonAny.ParseUriValue(value)), ObjectResult);
        }

        /// <summary>
        /// Set a property to an <see cref="JsonObject"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The serialized value of the property.</param>
        [When(@"I set the property (.*) to the value (.*) on the JsonObject using a ReadOnlySpan<byte>")]
        public void WhenISetThePropertyNamedWithValueToTheJsonObjectUsingAReadOnlySpanByte(string propertyName, string value)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonObject>(JsonValueSteps.SubjectUnderTest).SetProperty(Encoding.UTF8.GetBytes(propertyName), JsonAny.ParseUriValue(value)), ObjectResult);
        }

        /// <summary>
        /// Set a property to an <see cref="JsonAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The serialized value of the property.</param>
        [When(@"I set the property (.*) to the value (.*) on the JsonAny using a ReadOnlySpan<byte>")]
        public void WhenISetThePropertyNamedWithValueToTheJsonAnyUsingAReadOnlySpanByte(string propertyName, string value)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest).SetProperty(Encoding.UTF8.GetBytes(propertyName), JsonAny.ParseUriValue(value)), ObjectResult);
        }

        /// <summary>
        /// Set a property to an <see cref="JsonNotAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The serialized value of the property.</param>
        [When(@"I set the property (.*) to the value (.*) on the JsonNotAny using a ReadOnlySpan<byte>")]
        public void WhenISetThePropertyNamedWithValueToTheJsonNotAnyUsingAReadOnlySpanByte(string propertyName, string value)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonNotAny>(JsonValueSteps.SubjectUnderTest).SetProperty(Encoding.UTF8.GetBytes(propertyName), JsonAny.ParseUriValue(value)), ObjectResult);
        }

        /// <summary>
        /// Validate the given property on a <see cref="IJsonObject"/> found in the scenario context with key <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The serialized value of the property.</param>
        [Then(@"the property (.*) should be (.*)")]
        public void ThenThePropertyNamedShouldBe(string propertyName, string value)
        {
            Assert.IsTrue(this.scenarioContext.Get<IJsonObject>(ObjectResult).TryGetProperty(propertyName, out JsonAny actualValue));
            Assert.AreEqual(JsonAny.ParseUriValue(value), actualValue);
        }

        /// <summary>
        /// Remove a property from an <see cref="JsonObject"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        [When(@"I remove the property (.*) from the JsonObject using a string")]
        public void WhenIRemoveThePropertyNamedFromTheJsonObject(string propertyName)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonObject>(JsonValueSteps.SubjectUnderTest).RemoveProperty(propertyName), ObjectResult);
        }

        /// <summary>
        /// Remove a property from an <see cref="JsonAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        [When(@"I remove the property (.*) from the JsonAny using a string")]
        public void WhenIRemoveThePropertyNamedFromTheJsonAny(string propertyName)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest).RemoveProperty(propertyName), ObjectResult);
        }

        /// <summary>
        /// Remove a property from an <see cref="JsonNotAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        [When(@"I remove the property (.*) from the JsonNotAny using a string")]
        public void WhenIRemoveThePropertyNamedFromTheJsonNotAny(string propertyName)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonNotAny>(JsonValueSteps.SubjectUnderTest).RemoveProperty(propertyName), ObjectResult);
        }

        /// <summary>
        /// Remove a property from an <see cref="JsonObject"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        [When(@"I remove the property (.*) from the JsonObject using a ReadOnlySpan<char>")]
        public void WhenIRemoveThePropertyNamedFromTheJsonObjectUsingAReadOnlySpanOfChar(string propertyName)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonObject>(JsonValueSteps.SubjectUnderTest).RemoveProperty(propertyName.AsSpan()), ObjectResult);
        }

        /// <summary>
        /// Remove a property from an <see cref="JsonAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        [When(@"I remove the property (.*) from the JsonAny using a ReadOnlySpan<char>")]
        public void WhenIRemoveThePropertyNamedFromTheJsonAnyUsingAReadOnlySpanOfChar(string propertyName)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest).RemoveProperty(propertyName.AsSpan()), ObjectResult);
        }

        /// <summary>
        /// Remove a property from an <see cref="JsonNotAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        [When(@"I remove the property (.*) from the JsonNotAny using a ReadOnlySpan<char>")]
        public void WhenIRemoveThePropertyNamedFromTheJsonNotAnyUsingAReadOnlySpanOfChar(string propertyName)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonNotAny>(JsonValueSteps.SubjectUnderTest).RemoveProperty(propertyName.AsSpan()), ObjectResult);
        }

        /// <summary>
        /// Remove a property from an <see cref="JsonObject"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        [When(@"I remove the property (.*) from the JsonObject using a ReadOnlySpan<byte>")]
        public void WhenIRemoveThePropertyNamedFromTheJsonObjectUsingAReadOnlySpanOfByte(string propertyName)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonObject>(JsonValueSteps.SubjectUnderTest).RemoveProperty(Encoding.UTF8.GetBytes(propertyName)), ObjectResult);
        }

        /// <summary>
        /// Remove a property from an <see cref="JsonAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        [When(@"I remove the property (.*) from the JsonAny using a ReadOnlySpan<byte>")]
        public void WhenIRemoveThePropertyNamedFromTheJsonAnyUsingAReadOnlySpanOfByte(string propertyName)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest).RemoveProperty(Encoding.UTF8.GetBytes(propertyName)), ObjectResult);
        }

        /// <summary>
        /// Remove a property from an <see cref="JsonNotAny"/> found in <see cref="JsonValueSteps.SubjectUnderTest"/> and store it in <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        [When(@"I remove the property (.*) from the JsonNotAny using a ReadOnlySpan<byte>")]
        public void WhenIRemoveThePropertyNamedFromTheJsonNotAnyUsingAReadOnlySpanOfByte(string propertyName)
        {
            this.scenarioContext.Set(this.scenarioContext.Get<JsonNotAny>(JsonValueSteps.SubjectUnderTest).RemoveProperty(Encoding.UTF8.GetBytes(propertyName)), ObjectResult);
        }

        /// <summary>
        /// Validate that the given property on a <see cref="IJsonObject"/> found in the scenario context with key <see cref="ObjectResult"/> has not been defined.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        [Then(@"the property (.*) should not be defined")]
        public void ThenThePropertyNamedShouldNotBeDefined(string propertyName)
        {
            Assert.IsFalse(this.scenarioContext.Get<IJsonObject>(ObjectResult).HasProperty(propertyName));
        }
    }
}
