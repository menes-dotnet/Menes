// <copyright file="JsonValueCastSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Steps
{
    using System;
    using System.Collections.Immutable;
    using System.Text;
    using Menes.Json;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Steps for Json value types.
    /// </summary>
    [Binding]
    public class JsonValueCastSteps
    {
        private const string CastResultKey = "CastResult";

        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonValueCastSteps"/> class.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public JsonValueCastSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Cast the value stored in the context variable <see cref="JsonValueSteps.SubjectUnderTest"/> to a JsonAny and store in the <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonArray to JsonAny")]
        public void WhenICastTheJsonArrayToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonArray>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Gets the value store in <see cref="CastResultKey"/> and matches it against the JsonAny serialized in <paramref name="match"/>.
        /// </summary>
        /// <param name="match">The serialized form of the result to match.</param>
        [Then(@"the result should equal the JsonAny '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonAny(string match)
        {
            Assert.AreEqual(JsonAny.ParseUriValue(match), this.scenarioContext.Get<JsonAny>(CastResultKey));
        }

        /// <summary>
        /// Cast the value stored in the context variable <see cref="JsonValueSteps.SubjectUnderTest"/> to a JsonArray and store it in the <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonArray")]
        public void WhenICastTheJsonAnyToJsonArray()
        {
            this.scenarioContext.Set<IJsonValue>((JsonArray)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Comparse the IJsonValue in the <see cref="CastResultKey"/> with the serialized <paramref name="jsonArray"/>.
        /// </summary>
        /// <param name="jsonArray">The serialized JsonArray with which to compare the result.</param>
        [Then(@"the result should equal the JsonArray '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonArray(string jsonArray)
        {
            Assert.AreEqual(JsonAny.ParseUriValue(jsonArray).AsArray, this.scenarioContext.Get<IJsonValue>(CastResultKey));
        }

        /// <summary>
        /// Compares the two lists.
        /// </summary>
        /// <param name="immutableList">The immutable list with which to compare the result.</param>
        [Then(@"the result should equal the ImmutableList<JsonAny> '(.*)'")]
        public void ThenTheResultShouldEqualTheImmutableList(string immutableList)
        {
            ImmutableList<JsonAny> expected = JsonAny.ParseUriValue(immutableList).AsArray.AsItemsList;
            ImmutableList<JsonAny> actual = this.scenarioContext.Get<ImmutableList<JsonAny>>(CastResultKey);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Gets the item in the <see cref="JsonValueSteps.SubjectUnderTest"/>, casts it to <see cref="ImmutableList{JsonAny}"/> and stores it in the <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonArray to ImmutableList<JsonAny>")]
        public void WhenICastTheJsonArrayToImmutableList()
        {
            this.scenarioContext.Set((ImmutableList<JsonAny>)this.scenarioContext.Get<JsonArray>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Gets the item in the <see cref="JsonValueSteps.SubjectUnderTest"/>, casts it to <see cref="JsonArray"/> and stores it in the <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ImmutableList<JsonAny> to JsonArray")]
        public void WhenICastTheImmutableListToJsonArray()
        {
            this.scenarioContext.Set((JsonArray)this.scenarioContext.Get<ImmutableList<JsonAny>>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the two <see cref="JsonString"/> instances.
        /// </summary>
        /// <param name="expectedString">The string with which to compare the result.</param>
        [Then(@"the result should equal the JsonString '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonString(string expectedString)
        {
            JsonString expected = new (expectedString);
            JsonString actual = this.scenarioContext.Get<JsonString>(CastResultKey);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Compares a <see cref="ReadOnlyMemory{Char}"/> built from the <see cref="ReadOnlySpan{Char}"/> and stored in <see cref="CastResultKey"/> against the <see cref="ReadOnlyMemory{Char}"/> built from the expected string.
        /// </summary>
        /// <param name="expectedString">The string with which to compare the result.</param>
        [Then(@"the result should equal the ReadOnlySpan<char> '(.*)'")]
        public void ThenTheResultShouldEqualTheReadOnlySpanOfChar(string expectedString)
        {
            ReadOnlyMemory<char> expected = expectedString.AsMemory();
            ReadOnlyMemory<char> actual = this.scenarioContext.Get<ReadOnlyMemory<char>>(CastResultKey);
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        /// <summary>
        /// Compares a <see cref="ReadOnlyMemory{Byte}"/> built from the <see cref="ReadOnlySpan{Byte}"/> and stored in <see cref="CastResultKey"/> against the <see cref="ReadOnlyMemory{Byte}"/> built from the expected string.
        /// </summary>
        /// <param name="expectedString">The string with which to compare the result.</param>
        [Then(@"the result should equal the ReadOnlySpan<byte> '(.*)'")]
        public void ThenTheResultShouldEqualTheReadOnlySpanOfByte(string expectedString)
        {
            byte[] expected = Encoding.UTF8.GetBytes(expectedString);
            ReadOnlyMemory<byte> actual = this.scenarioContext.Get<ReadOnlyMemory<byte>>(CastResultKey);
            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        /// <summary>
        /// Compares a string stored in <see cref="CastResultKey"/> against the expected string.
        /// </summary>
        /// <param name="expected">The string with which to compare the result.</param>
        [Then(@"the result should equal the string '(.*)'")]
        public void ThenTheResultShouldEqualTheString(string expected)
        {
            string actual = this.scenarioContext.Get<string>(CastResultKey);
            Assert.AreEqual(expected, actual);
        }

        /* base64content */

        /// <summary>
        /// Casts the <see cref="JsonBase64Content"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBase64Content to JsonAny")]
        public void WhenICastTheJsonBase64ContentToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonBase64Content>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonBase64Content"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonBase64Content")]
        public void WhenICastTheJsonAnyToJsonBase64Content()
        {
            this.scenarioContext.Set((JsonBase64Content)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonBase64Content"/> in the context value <see cref="CastResultKey"/> with the given JsonBase64Content.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonBase64Content"/>.</param>
        [Then(@"the result should equal the JsonBase64Content '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonBase64Content(string expectedValue)
        {
            JsonBase64Content expected = JsonAny.ParseUriValue(expectedValue).AsString;
            Assert.AreEqual(expected, this.scenarioContext.Get<JsonBase64Content>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonBase64Content"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBase64Content to JsonString")]
        public void WhenICastTheJsonBase64ContentToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonBase64Content>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonBase64Content"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonBase64Content")]
        public void WhenICastTheJsonStringToJsonBase64Content()
        {
            this.scenarioContext.Set((JsonBase64Content)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonBase64Content"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBase64Content to ReadOnlySpan<char>")]
        public void WhenICastTheJsonBase64ContentToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonBase64Content>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonBase64Content"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonBase64Content")]
        public void WhenICastTheReadOnlySpanOfCharToJsonBase64Content()
        {
            this.scenarioContext.Set((JsonBase64Content)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonBase64Content"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBase64Content to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonBase64ContentToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonBase64Content>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonBase64Content"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonBase64Content")]
        public void WhenICastTheReadOnlySpanOfByteToJsonBase64Content()
        {
            this.scenarioContext.Set((JsonBase64Content)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonBase64Content"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="string"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBase64Content to string")]
        public void WhenICastTheJsonBase64ContentToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonBase64Content>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonBase64Content"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonBase64Content")]
        public void WhenICastTheStringToJsonBase64Content()
        {
            this.scenarioContext.Set((JsonBase64Content)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /* base64String */

        /// <summary>
        /// Casts the <see cref="JsonBase64String"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBase64String to JsonAny")]
        public void WhenICastTheJsonBase64StringToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonBase64String>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonBase64String"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonBase64String")]
        public void WhenICastTheJsonAnyToJsonBase64String()
        {
            this.scenarioContext.Set((JsonBase64String)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonBase64String"/> in the context value <see cref="CastResultKey"/> with the given JsonBase64String.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonBase64String"/>.</param>
        [Then(@"the result should equal the JsonBase64String '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonBase64String(string expectedValue)
        {
            JsonBase64String expected = JsonAny.ParseUriValue(expectedValue).AsString;
            Assert.AreEqual(expected, this.scenarioContext.Get<JsonBase64String>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonBase64String"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBase64String to JsonString")]
        public void WhenICastTheJsonBase64StringToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonBase64String>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonBase64String"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonBase64String")]
        public void WhenICastTheJsonStringToJsonBase64String()
        {
            this.scenarioContext.Set((JsonBase64String)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonBase64String"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBase64String to ReadOnlySpan<char>")]
        public void WhenICastTheJsonBase64StringToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonBase64String>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonBase64String"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonBase64String")]
        public void WhenICastTheReadOnlySpanOfCharToJsonBase64String()
        {
            this.scenarioContext.Set((JsonBase64String)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonBase64String"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBase64String to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonBase64StringToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonBase64String>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonBase64String"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonBase64String")]
        public void WhenICastTheReadOnlySpanOfByteToJsonBase64String()
        {
            this.scenarioContext.Set((JsonBase64String)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonBase64String"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="string"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBase64String to string")]
        public void WhenICastTheJsonBase64StringToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonBase64String>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonBase64String"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonBase64String")]
        public void WhenICastTheStringToJsonBase64String()
        {
            this.scenarioContext.Set((JsonBase64String)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }
    }
}
