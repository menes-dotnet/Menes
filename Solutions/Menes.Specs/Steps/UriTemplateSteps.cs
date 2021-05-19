// <copyright file="UriTemplateSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Steps
{
    using System;
    using System.Collections.Immutable;
    using System.Text.Json;
    using Menes.Json;
    using Menes.Json.UriTemplates;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Steps for URI template validation.
    /// </summary>
    [Binding]
    public class UriTemplateSteps
    {
        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UriTemplateSteps"/> class.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public UriTemplateSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Set the level for the scenario in the context variable "Level".
        /// </summary>
        /// <param name="level">The level to set.</param>
        [Given(@"the Level is (.*)")]
        public void GivenTheLevelIs(int level)
        {
            this.scenarioContext.Set(level, "Level");
        }

        /// <summary>
        /// Build the variables into an <see cref="ImmutableDictionary{TKey, TValue}"/> of <see cref="string"/> to <see cref="JsonAny"/> and set the context variable "Variables".
        /// </summary>
        /// <param name="table">The table of variables.</param>
        [Given(@"the variables")]
        public void GivenTheVariables(Table table)
        {
            ImmutableDictionary<string, JsonAny>.Builder builder = ImmutableDictionary.CreateBuilder<string, JsonAny>();

            foreach (TableRow row in table.Rows)
            {
                builder.Add(row["name"], JsonAny.Parse(row["value"]));
            }

            this.scenarioContext.Set(builder.ToImmutable(), "Variables");
        }

        /// <summary>
        /// Apply the variables to the template and store the result in the context variable "Result".
        /// </summary>
        /// <param name="template">The URI template.</param>
        [When(@"I apply the variables to the template (.*)")]
        public void WhenIApplyTheVariablesToTheTemplateVar(string template)
        {
            try
            {
                var uriTemplate = new UriTemplate(template, parameters: this.scenarioContext.Get<ImmutableDictionary<string, JsonAny>>("Variables"));
                this.scenarioContext.Set(uriTemplate.Resolve(), "Result");
            }
            catch (Exception ex)
            {
                this.scenarioContext.Set(ex, "Exception");
            }
        }

        /// <summary>
        /// Ensure that the result is one of the expected options.
        /// </summary>
        /// <param name="result">The result array.</param>
        [Then(@"the result should be one of (.*)")]
        public void ThenTheResultShouldBeOneOf(string result)
        {
            JsonArray array = JsonAny.Parse(result);

            // This is the weird way it expects an exception in the test schema
            if (array.Length == 1)
            {
                using JsonArrayEnumerator enumerator = array.EnumerateArray();
                enumerator.MoveNext();
                if (enumerator.Current.ValueKind == JsonValueKind.False)
                {
                    Assert.IsTrue(this.scenarioContext.ContainsKey("Exception"));
                    return;
                }
            }

            Assert.False(this.scenarioContext.ContainsKey("Exception"));
            string actual = this.scenarioContext.Get<string>("Result");
            foreach (string expected in array.EnumerateArray())
            {
                if (expected == actual)
                {
                    return;
                }
            }

            Assert.Fail($"{result} did not contain {actual}");
        }
    }
}
