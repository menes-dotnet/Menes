// <copyright file="JsonArraySteps.cs" company="Endjin Limited">
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
    public class JsonArraySteps
    {
        private const string ArrayValueResultkey = "ArrayValueResult";
        private const string ArrayExceptionKey = "ArrayException";

        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonArraySteps"/> class.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public JsonArraySteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Gets the <see cref="JsonArray"/> from the context with key <see cref="JsonValueSteps.SubjectUnderTest"/>
        /// and removes the item at the given index, storing the result in <see cref="ArrayValueResultkey"/>.
        /// </summary>
        /// <param name="index">The index at which to remove the item.</param>
        [When(@"I remove the item at index (.*) from the JsonArray")]
        public void WhenIRemoveTheItemAtIndexFromTheJsonArray(int index)
        {
            try
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonArray>(JsonValueSteps.SubjectUnderTest).RemoveAt(index), ArrayValueResultkey);
            }
            catch (Exception ex)
            {
                this.scenarioContext.Set(ex, ArrayExceptionKey);
            }
        }

        /// <summary>
        /// Gets the <see cref="JsonArray"/> from the context with key <see cref="JsonValueSteps.SubjectUnderTest"/>
        /// and removes the item at the given index, storing the result in <see cref="ArrayValueResultkey"/>.
        /// </summary>
        /// <param name="index">The index at which to remove the item.</param>
        [When(@"I remove the item at index (.*) from the JsonAny")]
        public void WhenIRemoveTheItemAtIndexFromTheJsonAny(int index)
        {
            try
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest).RemoveAt(index), ArrayValueResultkey);
            }
            catch (Exception ex)
            {
                this.scenarioContext.Set(ex, ArrayExceptionKey);
            }
        }

        /// <summary>
        /// Gets the <see cref="JsonArray"/> from the context with key <see cref="JsonValueSteps.SubjectUnderTest"/>
        /// and removes the item at the given index, storing the result in <see cref="ArrayValueResultkey"/>.
        /// </summary>
        /// <param name="index">The index at which to remove the item.</param>
        [When(@"I remove the item at index (.*) from the JsonNotAny")]
        public void WhenIRemoveTheItemAtIndexFromTheJsonNotAny(int index)
        {
            try
            {
                this.scenarioContext.Set(this.scenarioContext.Get<JsonNotAny>(JsonValueSteps.SubjectUnderTest).RemoveAt(index), ArrayValueResultkey);
            }
            catch (Exception ex)
            {
                this.scenarioContext.Set(ex, ArrayExceptionKey);
            }
        }

        /// <summary>
        /// Gets the <see cref="JsonArray"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonArray at index (.*) should be (.*) of type JsonObject")]
        public void ThenTheItemAtShouldBeTheObject(int index, string expected)
        {
            JsonArray value = this.scenarioContext.Get<JsonArray>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonArray, JsonObject>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonArray"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonArray at index (.*) should be (.*) of type JsonArray")]
        public void ThenTheItemAtShouldBeTheArray(int index, string expected)
        {
            JsonArray value = this.scenarioContext.Get<JsonArray>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonArray, JsonArray>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonArray"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonArray at index (.*) should be (.*) of type JsonNumber")]
        public void ThenTheItemAtShouldBeTheNumber(int index, string expected)
        {
            JsonArray value = this.scenarioContext.Get<JsonArray>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonArray, JsonNumber>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonArray"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonArray at index (.*) should be (.*) of type JsonBoolean")]
        public void ThenTheItemAtShouldBeTheBoolean(int index, string expected)
        {
            JsonArray value = this.scenarioContext.Get<JsonArray>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonArray, JsonBoolean>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonArray"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonArray at index (.*) should be (.*) of type JsonString")]
        public void ThenTheItemAtShouldBeTheString(int index, string expected)
        {
            JsonArray value = this.scenarioContext.Get<JsonArray>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonArray, JsonString>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonArray"/> from the context with key <see cref="JsonValueSteps.SubjectUnderTest"/>
        /// and sets the item at the given index to the provided value storing the result in <see cref="ArrayValueResultkey"/>.
        /// </summary>
        /// <param name="index">The index at which to remove the item.</param>
        /// <param name="value">The serialized value to set.</param>
        [When(@"I set the item in the JsonArray at index (.*) to the value (.*)")]
        public void WhenISetTheItemToTheValue(int index, string value)
        {
            JsonArray sut = this.scenarioContext.Get<JsonArray>(JsonValueSteps.SubjectUnderTest);
            try
            {
                this.scenarioContext.Set(sut.SetItem(index, JsonAny.ParseUriValue(value)), ArrayValueResultkey);
            }
            catch (Exception ex)
            {
                this.scenarioContext.Set(ex, ArrayExceptionKey);
            }
        }

        /// <summary>
        /// Gets the <see cref="JsonAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonAny at index (.*) should be (.*) of type JsonObject")]
        public void ThenTheItemInTheJsonAnyAtShouldBeTheObject(int index, string expected)
        {
            JsonAny value = this.scenarioContext.Get<JsonAny>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonAny, JsonObject>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonAny at index (.*) should be (.*) of type JsonArray")]
        public void ThenTheItemInTheJsonAnyAtShouldBeTheArray(int index, string expected)
        {
            JsonAny value = this.scenarioContext.Get<JsonArray>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonAny, JsonArray>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonAny at index (.*) should be (.*) of type JsonNumber")]
        public void ThenTheItemInTheJsonAnyAtShouldBeTheNumber(int index, string expected)
        {
            JsonAny value = this.scenarioContext.Get<JsonAny>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonAny, JsonNumber>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonAny at index (.*) should be (.*) of type JsonBoolean")]
        public void ThenTheItemInTheJsonAnyAtShouldBeTheBoolean(int index, string expected)
        {
            JsonAny value = this.scenarioContext.Get<JsonAny>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonAny, JsonBoolean>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonAny at index (.*) should be (.*) of type JsonString")]
        public void ThenTheItemInTheJsonAnyAtShouldBeTheString(int index, string expected)
        {
            JsonAny value = this.scenarioContext.Get<JsonAny>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonAny, JsonString>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonAny"/> from the context with key <see cref="JsonValueSteps.SubjectUnderTest"/>
        /// and sets the item at the given index to the provided value storing the result in <see cref="ArrayValueResultkey"/>.
        /// </summary>
        /// <param name="index">The index at which to remove the item.</param>
        /// <param name="value">The serialized value to set.</param>
        [When(@"I set the item in the JsonAny at index (.*) to the value (.*)")]
        public void WhenISetTheItemInTheJsonAnyToTheValue(int index, string value)
        {
            JsonAny sut = this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest);
            try
            {
                this.scenarioContext.Set(sut.SetItem(index, JsonAny.ParseUriValue(value)), ArrayValueResultkey);
            }
            catch (Exception ex)
            {
                this.scenarioContext.Set(ex, ArrayExceptionKey);
            }
        }

        /// <summary>
        /// Gets the <see cref="JsonNotAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonNotAny at index (.*) should be (.*) of type JsonObject")]
        public void ThenTheItemInTheJsonNotAnyAtShouldBeTheObject(int index, string expected)
        {
            JsonNotAny value = this.scenarioContext.Get<JsonNotAny>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonNotAny, JsonObject>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonNotAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonNotAny at index (.*) should be (.*) of type JsonNotAny")]
        public void ThenTheItemInTheJsonNotAnyAtShouldBeTheArray(int index, string expected)
        {
            JsonNotAny value = this.scenarioContext.Get<JsonNotAny>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonNotAny, JsonNotAny>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonNotAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonNotAny at index (.*) should be (.*) of type JsonNumber")]
        public void ThenTheItemInTheJsonNotAnyAtShouldBeTheNumber(int index, string expected)
        {
            JsonNotAny value = this.scenarioContext.Get<JsonNotAny>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonNotAny, JsonNumber>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonNotAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonNotAny at index (.*) should be (.*) of type JsonBoolean")]
        public void ThenTheItemInTheJsonNotAnyAtShouldBeTheBoolean(int index, string expected)
        {
            JsonNotAny value = this.scenarioContext.Get<JsonNotAny>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonNotAny, JsonBoolean>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonNotAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonNotAny at index (.*) should be (.*) of type JsonString")]
        public void ThenTheItemInTheJsonNotAnyAtShouldBeTheString(int index, string expected)
        {
            JsonNotAny value = this.scenarioContext.Get<JsonNotAny>(ArrayValueResultkey);
            Assert.AreEqual(JsonAny.ParseUriValue(expected), value.GetItem<JsonNotAny, JsonString>(index));
        }

        /// <summary>
        /// Gets the <see cref="JsonNotAny"/> from the context with key <see cref="ArrayValueResultkey"/>
        /// and compares the item at the given index with the given value.
        /// </summary>
        /// <param name="index">The index at which to test the item.</param>
        /// <param name="expected">The serialized value expected to be found at the given index.</param>
        [Then(@"the item in the JsonNotAny at index (.*) should be (.*) of type <undefined>")]
        public void ThenTheItemInTheJsonNotAnyAtShouldBeUndefined(int index, string expected)
        {
            JsonNotAny value = this.scenarioContext.Get<JsonNotAny>(ArrayValueResultkey);
            Assert.IsTrue(value.Length <= index);
        }

        /// <summary>
        /// Gets the <see cref="JsonNotAny"/> from the context with key <see cref="JsonValueSteps.SubjectUnderTest"/>
        /// and sets the item at the given index to the provided value storing the result in <see cref="ArrayValueResultkey"/>.
        /// </summary>
        /// <param name="index">The index at which to remove the item.</param>
        /// <param name="value">The serialized value to set.</param>
        [When(@"I set the item in the JsonNotAny at index (.*) to the value (.*)")]
        public void WhenISetTheItemInTheJsonNotAnyToTheValue(int index, string value)
        {
            JsonNotAny sut = this.scenarioContext.Get<JsonNotAny>(JsonValueSteps.SubjectUnderTest);
            this.scenarioContext.Set(sut.SetItem(index, JsonAny.ParseUriValue(value)), ArrayValueResultkey);
        }
    }
}
