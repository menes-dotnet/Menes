// <copyright file="ValidationContextSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Steps
{
    using System;
    using Menes.Json;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Steps for Json value types.
    /// </summary>
    [Binding]
    public class ValidationContextSteps
    {
        private const string ValidationContextKey = "ValidationContext";

        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationContextSteps"/> class.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public ValidationContextSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Creates a <see cref="ValidationContext"/> with relevant initial conditions and stores it in the context key <see cref="ValidationContextKey"/>.
        /// </summary>
        /// <param name="validInvalid">The string <c>valid</c> or <c>invalid</c>.</param>
        /// <param name="withWithoutResults">The string <c>with</c> or <c>without</c> to determine whether we are <see cref="ValidationContext.UsingResults()"/>.</param>
        /// <param name="withWithoutStack">The string <c>with</c> or <c>without</c> to determine whether we are <see cref="ValidationContext.UsingStack()"/>.</param>
        /// <param name="withWithoutEvaluatedProperties">The string <c>with</c> or <c>without</c> to determine whether we are <see cref="ValidationContext.UsingEvaluatedProperties()"/>.</param>
        /// <param name="withWithoutEvaluatedItems">The string <c>with</c> or <c>without</c> to determine whether we are <see cref="ValidationContext.UsingEvaluatedItems()"/>.</param>
        [Given(@"a (.*) validation context (.*) results, (.*) a stack, (.*) evaluated properties, and (.*) evaluated items")]
        public void GivenAValidOrInvalidValidationContextWithOrWithoutAStackWithOrWithoutEvaluatedPropertiesAndWithOrWithoutEvaluatedItems(string validInvalid, string withWithoutResults, string withWithoutStack, string withWithoutEvaluatedProperties, string withWithoutEvaluatedItems)
        {
            ValidationContext context = validInvalid == "valid" ? ValidationContext.ValidContext : ValidationContext.InvalidContext;

            if (withWithoutResults == "with")
            {
                context = context.UsingResults();
            }

            if (withWithoutStack == "with")
            {
                context = context.UsingStack();
            }

            if (withWithoutEvaluatedProperties == "with")
            {
                context = context.UsingEvaluatedProperties();
            }

            if (withWithoutEvaluatedItems == "with")
            {
                context = context.UsingEvaluatedItems();
            }

            this.scenarioContext.Set(context, ValidationContextKey);
        }

        /// <summary>
        /// Adds a valid or invalid result to the <see cref="ValidationContext"/> stored in the context key <see cref="ValidationContextKey"/>, with an optional message, and stores the result in the context key <see cref="ValidationContextKey"/>.
        /// </summary>
        /// <param name="validOrInvalidResult">The string <c>valid</c> or <c>invalid</c>.</param>
        /// <param name="message">A message or the string <c>&lt;null&gt;</c> if no message is supplied.</param>
        [When(@"I add a (.*) result with the message (.*)")]
        public void WhenIAddAValidOrInvalidResultWithTheMessage(string validOrInvalidResult, string message)
        {
            ValidationContext context = this.scenarioContext.Get<ValidationContext>(ValidationContextKey);
            context = context.WithResult(validOrInvalidResult == "valid", message == "<null>" ? null : message);
            this.scenarioContext.Set(context, ValidationContextKey);
        }

        /// <summary>
        /// Gets the <see cref="ValidationContext"/> from the context key <see cref="ValidationContextKey"/> and verifies whether it is valid or invalid.
        /// </summary>
        /// <param name="validOrInvalid">The string <c>valid</c> or <c>invalid</c>.</param>
        [Then(@"the validationResult should be (.*)")]
        public void ThenTheValidationResultShouldBeValid(string validOrInvalid)
        {
            ValidationContext context = this.scenarioContext.Get<ValidationContext>(ValidationContextKey);
            if (validOrInvalid == "valid")
            {
                Assert.IsTrue(context.IsValid);
            }
            else
            {
                Assert.IsFalse(context.IsValid);
            }
        }

        /// <summary>
        /// Gets the <see cref="ValidationContext"/> stored in the context key <see cref="ValidationContextKey"/>, and uses <see cref="ValidationContext.WithLocalProperty(int)"/> to apply
        /// the propertiess in the given index array.
        /// </summary>
        /// <param name="propertyIndexArray">A string containing the comma separated list of property indices.</param>
        [When(@"I evaluate the properties at \[(.*)]")]
        public void WhenIEvaluateThePropertiesAt(string propertyIndexArray)
        {
            ValidationContext context = this.scenarioContext.Get<ValidationContext>(ValidationContextKey);

            foreach (string propertyIndex in propertyIndexArray.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
            {
                context = context.WithLocalProperty(int.Parse(propertyIndex));
            }

            this.scenarioContext.Set(context, ValidationContextKey);
        }

        /// <summary>
        /// Validates that for the  <see cref="ValidationContext"/> stored in the context key <see cref="ValidationContextKey"/>, <see cref="ValidationContext.HasEvaluatedLocalProperty(int)"/> evaluates to false for the given indices in the array.
        /// </summary>
        /// <param name="propertyIndexArray">A string containing the comma separated list of property indices.</param>
        [Then(@"the properties at \[(.*)] should not be evaluated")]
        public void ThenThePropertiesAtShouldNotBeEvaluated(string propertyIndexArray)
        {
            if (propertyIndexArray == "<none>")
            {
                return;
            }

            ValidationContext context = this.scenarioContext.Get<ValidationContext>(ValidationContextKey);

            foreach (string propertyIndex in propertyIndexArray.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
            {
                Assert.IsFalse(context.HasEvaluatedLocalProperty(int.Parse(propertyIndex)));
            }
        }

        /// <summary>
        /// Validates that for the  <see cref="ValidationContext"/> stored in the context key <see cref="ValidationContextKey"/>, <see cref="ValidationContext.HasEvaluatedLocalProperty(int)"/> evaluates to false for the given indices in the array.
        /// </summary>
        /// <param name="propertyIndexArray">A string containing the comma separated list of property indices.</param>
        [Then(@"the properties at \[(.*)] should be evaluated")]
        public void ThenThePropertiesAtShouldBeEvaluated(string propertyIndexArray)
        {
            if (propertyIndexArray == "<none>")
            {
                return;
            }

            ValidationContext context = this.scenarioContext.Get<ValidationContext>(ValidationContextKey);

            foreach (string propertyIndex in propertyIndexArray.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
            {
                Assert.IsTrue(context.HasEvaluatedLocalProperty(int.Parse(propertyIndex)));
            }
        }
    }
}
