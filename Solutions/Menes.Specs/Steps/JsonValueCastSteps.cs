// <copyright file="JsonValueCastSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Steps
{
    using System;
    using System.Collections.Immutable;
    using System.Text;
    using Menes.Json;
    using NodaTime;
    using NodaTime.Text;
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
            JsonString expected = JsonAny.ParseUriValue(expectedString);
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

        /* content */

        /// <summary>
        /// Casts the <see cref="JsonContent"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonContent to JsonAny")]
        public void WhenICastTheJsonContentToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonContent>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonContent"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonContent")]
        public void WhenICastTheJsonAnyToJsonContent()
        {
            this.scenarioContext.Set((JsonContent)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonContent"/> in the context value <see cref="CastResultKey"/> with the given JsonContent.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonContent"/>.</param>
        [Then(@"the result should equal the JsonContent '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonContent(string expectedValue)
        {
            JsonContent expected = JsonAny.ParseUriValue(expectedValue);
            Assert.AreEqual(expected, this.scenarioContext.Get<JsonContent>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonContent"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonContent to JsonString")]
        public void WhenICastTheJsonContentToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonContent>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonContent"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonContent")]
        public void WhenICastTheJsonStringToJsonContent()
        {
            this.scenarioContext.Set((JsonContent)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonContent"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonContent to ReadOnlySpan<char>")]
        public void WhenICastTheJsonContentToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonContent>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonContent"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonContent")]
        public void WhenICastTheReadOnlySpanOfCharToJsonContent()
        {
            this.scenarioContext.Set((JsonContent)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonContent"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonContent to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonContentToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonContent>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonContent"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonContent")]
        public void WhenICastTheReadOnlySpanOfByteToJsonContent()
        {
            this.scenarioContext.Set((JsonContent)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonContent"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="string"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonContent to string")]
        public void WhenICastTheJsonContentToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonContent>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonContent"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonContent")]
        public void WhenICastTheStringToJsonContent()
        {
            this.scenarioContext.Set((JsonContent)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /* email */

        /// <summary>
        /// Casts the <see cref="JsonEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonEmail to JsonAny")]
        public void WhenICastTheJsonEmailToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonEmail>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonEmail"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonEmail")]
        public void WhenICastTheJsonAnyToJsonEmail()
        {
            this.scenarioContext.Set((JsonEmail)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonEmail"/> in the context value <see cref="CastResultKey"/> with the given JsonEmail.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonEmail"/>.</param>
        [Then(@"the result should equal the JsonEmail '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonEmail(string expectedValue)
        {
            JsonEmail expected = JsonAny.ParseUriValue(expectedValue).AsString;
            Assert.AreEqual(expected, this.scenarioContext.Get<JsonEmail>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonEmail to JsonString")]
        public void WhenICastTheJsonEmailToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonEmail>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonEmail"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonEmail")]
        public void WhenICastTheJsonStringToJsonEmail()
        {
            this.scenarioContext.Set((JsonEmail)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonEmail to ReadOnlySpan<char>")]
        public void WhenICastTheJsonEmailToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonEmail>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonEmail")]
        public void WhenICastTheReadOnlySpanOfCharToJsonEmail()
        {
            this.scenarioContext.Set((JsonEmail)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonEmail to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonEmailToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonEmail>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonEmail"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonEmail")]
        public void WhenICastTheReadOnlySpanOfByteToJsonEmail()
        {
            this.scenarioContext.Set((JsonEmail)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="string"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonEmail to string")]
        public void WhenICastTheJsonEmailToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonEmail>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonEmail"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonEmail")]
        public void WhenICastTheStringToJsonEmail()
        {
            this.scenarioContext.Set((JsonEmail)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /* boolean */

        /// <summary>
        /// Casts the <see cref="JsonBoolean"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBoolean to JsonAny")]
        public void WhenICastTheJsonBooleanToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonBoolean>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonBoolean"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonBoolean")]
        public void WhenICastTheJsonAnyToJsonBoolean()
        {
            this.scenarioContext.Set<IJsonValue>((JsonBoolean)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonBoolean"/> in the context value <see cref="CastResultKey"/> with the given JsonBoolean.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonContent"/>.</param>
        [Then(@"the result should equal the JsonBoolean '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonBoolean(string expectedValue)
        {
            Assert.AreEqual(JsonAny.ParseUriValue(expectedValue).AsBoolean, this.scenarioContext.Get<IJsonValue>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonBoolean"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="bool"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonBoolean to bool")]
        public void WhenICastTheJsonBooleanToBool()
        {
            this.scenarioContext.Set((bool)this.scenarioContext.Get<JsonBoolean>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="bool"/> in the context value <see cref="CastResultKey"/> with the given bool.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonContent"/>.</param>
        [Then(@"the result should equal the bool (.*)")]
        public void ThenTheResultShouldEqualTheBool(bool expectedValue)
        {
            Assert.AreEqual(expectedValue, this.scenarioContext.Get<bool>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="bool"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonBoolean"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the bool to JsonBoolean")]
        public void WhenICastTheBoolToJsonBoolean()
        {
            this.scenarioContext.Set<IJsonValue>((JsonBoolean)this.scenarioContext.Get<bool>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDate"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDate to JsonAny")]
        public void WhenICastTheJsonDateToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonDate>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDate"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonDate")]
        public void WhenICastTheJsonAnyToJsonDate()
        {
            this.scenarioContext.Set<IJsonValue>((JsonDate)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonDate"/> in the context value <see cref="CastResultKey"/> with the given JsonDate.
        /// </summary>
        /// <param name="value">The string representation of the date.</param>
        [Then(@"the result should equal the JsonDate '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonDate(string value)
        {
            Assert.AreEqual(new JsonDate(value), this.scenarioContext.Get<IJsonValue>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonDate"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDate to JsonString")]
        public void WhenICastTheJsonDateToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonDate>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDate"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonDate")]
        public void WhenICastTheJsonStringToJsonDate()
        {
            this.scenarioContext.Set((JsonDate)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDate"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="LocalDate"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDate to LocalDate")]
        public void WhenICastTheJsonDateToLocalDate()
        {
            this.scenarioContext.Set((LocalDate)this.scenarioContext.Get<JsonDate>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonDate"/> in the context value <see cref="CastResultKey"/> with the given LocalDate.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="LocalDate"/>.</param>
        [Then(@"the result should equal the LocalDate '(.*)'")]
        public void ThenTheResultShouldEqualTheLocalDate(string expectedValue)
        {
            Assert.AreEqual(LocalDatePattern.Iso.Parse(expectedValue).Value, this.scenarioContext.Get<LocalDate>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="LocalDate"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDate"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the LocalDate to JsonDate")]
        public void WhenICastTheLocalDateToJsonDate()
        {
            this.scenarioContext.Set((JsonDate)this.scenarioContext.Get<LocalDate>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDate"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDate to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonDateToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonDate>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDate"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDate to ReadOnlySpan<char>")]
        public void WhenICastTheJsonDateToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonDate>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDate"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonDate")]
        public void WhenICastTheReadOnlySpanOfByteToJsonDate()
        {
            this.scenarioContext.Set((JsonDate)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Char}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDate"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonDate")]
        public void WhenICastTheReadOnlySpanOfCharToJsonDate()
        {
            this.scenarioContext.Set((JsonDate)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDate"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see langword="string"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDate to string")]
        public void WhenICastTheJsonDateToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonDate>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDate"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonDate")]
        public void WhenICastTheStringToJsonDate()
        {
            this.scenarioContext.Set((JsonDate)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDateTime"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDateTime to JsonAny")]
        public void WhenICastTheJsonDateTimeToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonDateTime>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDateTime"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonDateTime")]
        public void WhenICastTheJsonAnyToJsonDateTime()
        {
            this.scenarioContext.Set<IJsonValue>((JsonDateTime)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonDateTime"/> in the context value <see cref="CastResultKey"/> with the given JsonDateTime.
        /// </summary>
        /// <param name="value">The string representation of the dateTime.</param>
        [Then(@"the result should equal the JsonDateTime '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonDateTime(string value)
        {
            Assert.AreEqual(new JsonDateTime(value), this.scenarioContext.Get<IJsonValue>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonDateTime"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDateTime to JsonString")]
        public void WhenICastTheJsonDateTimeToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonDateTime>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDateTime"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonDateTime")]
        public void WhenICastTheJsonStringToJsonDateTime()
        {
            this.scenarioContext.Set((JsonDateTime)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDateTime"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="OffsetDateTime"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDateTime to OffsetDateTime")]
        public void WhenICastTheJsonDateTimeToOffsetDateTime()
        {
            this.scenarioContext.Set((OffsetDateTime)this.scenarioContext.Get<JsonDateTime>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonDateTime"/> in the context value <see cref="CastResultKey"/> with the given OffsetDateTime.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="OffsetDateTime"/>.</param>
        [Then(@"the result should equal the OffsetDateTime '(.*)'")]
        public void ThenTheResultShouldEqualTheOffsetDateTime(string expectedValue)
        {
            Assert.AreEqual(OffsetDateTimePattern.ExtendedIso.Parse(expectedValue).Value, this.scenarioContext.Get<OffsetDateTime>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="OffsetDateTime"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDateTime"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the OffsetDateTime to JsonDateTime")]
        public void WhenICastTheOffsetDateTimeToJsonDateTime()
        {
            this.scenarioContext.Set((JsonDateTime)this.scenarioContext.Get<OffsetDateTime>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDateTime"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDateTime to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonDateTimeToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonDateTime>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDateTime"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDateTime to ReadOnlySpan<char>")]
        public void WhenICastTheJsonDateTimeToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonDateTime>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDateTime"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonDateTime")]
        public void WhenICastTheReadOnlySpanOfByteToJsonDateTime()
        {
            this.scenarioContext.Set((JsonDateTime)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Char}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDateTime"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonDateTime")]
        public void WhenICastTheReadOnlySpanOfCharToJsonDateTime()
        {
            this.scenarioContext.Set((JsonDateTime)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDateTime"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see langword="string"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDateTime to string")]
        public void WhenICastTheJsonDateTimeToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonDateTime>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDateTime"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonDateTime")]
        public void WhenICastTheStringToJsonDateTime()
        {
            this.scenarioContext.Set((JsonDateTime)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDuration"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDuration to JsonAny")]
        public void WhenICastTheJsonDurationToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonDuration>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDuration"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonDuration")]
        public void WhenICastTheJsonAnyToJsonDuration()
        {
            this.scenarioContext.Set<IJsonValue>((JsonDuration)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonDuration"/> in the context value <see cref="CastResultKey"/> with the given JsonDuration.
        /// </summary>
        /// <param name="value">The string representation of the duration.</param>
        [Then(@"the result should equal the JsonDuration '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonDuration(string value)
        {
            Assert.AreEqual(new JsonDuration(value), this.scenarioContext.Get<IJsonValue>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonDuration"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDuration to JsonString")]
        public void WhenICastTheJsonDurationToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonDuration>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDuration"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonDuration")]
        public void WhenICastTheJsonStringToJsonDuration()
        {
            this.scenarioContext.Set((JsonDuration)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDuration"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="Period"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDuration to Period")]
        public void WhenICastTheJsonDurationToPeriod()
        {
            this.scenarioContext.Set((Period)this.scenarioContext.Get<JsonDuration>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonDuration"/> in the context value <see cref="CastResultKey"/> with the given Period.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="Period"/>.</param>
        [Then(@"the result should equal the Period '(.*)'")]
        public void ThenTheResultShouldEqualThePeriod(string expectedValue)
        {
            Assert.AreEqual(PeriodPattern.NormalizingIso.Parse(expectedValue).Value, this.scenarioContext.Get<Period>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="Period"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDuration"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the Period to JsonDuration")]
        public void WhenICastThePeriodToJsonDuration()
        {
            this.scenarioContext.Set((JsonDuration)this.scenarioContext.Get<Period>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDuration"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDuration to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonDurationToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonDuration>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDuration"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDuration to ReadOnlySpan<char>")]
        public void WhenICastTheJsonDurationToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonDuration>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDuration"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonDuration")]
        public void WhenICastTheReadOnlySpanOfByteToJsonDuration()
        {
            this.scenarioContext.Set((JsonDuration)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Char}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDuration"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonDuration")]
        public void WhenICastTheReadOnlySpanOfCharToJsonDuration()
        {
            this.scenarioContext.Set((JsonDuration)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonDuration"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see langword="string"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonDuration to string")]
        public void WhenICastTheJsonDurationToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonDuration>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonDuration"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonDuration")]
        public void WhenICastTheStringToJsonDuration()
        {
            this.scenarioContext.Set((JsonDuration)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /* string */

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonAny")]
        public void WhenICastTheJsonStringToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonString")]
        public void WhenICastTheJsonAnyToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonString")]
        public void WhenICastTheJsonStringToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to ReadOnlySpan<char>")]
        public void WhenICastTheJsonStringToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonString")]
        public void WhenICastTheReadOnlySpanOfCharToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonStringToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonString")]
        public void WhenICastTheReadOnlySpanOfByteToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="string"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to string")]
        public void WhenICastTheJsonStringToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonString")]
        public void WhenICastTheStringToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /* hostname */

        /// <summary>
        /// Casts the <see cref="JsonHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonHostname to JsonAny")]
        public void WhenICastTheJsonHostnameToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonHostname>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonHostname"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonHostname")]
        public void WhenICastTheJsonAnyToJsonHostname()
        {
            this.scenarioContext.Set((JsonHostname)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonHostname"/> in the context value <see cref="CastResultKey"/> with the given JsonHostname.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonHostname"/>.</param>
        [Then(@"the result should equal the JsonHostname '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonHostname(string expectedValue)
        {
            JsonHostname expected = JsonAny.ParseUriValue(expectedValue).AsString;
            Assert.AreEqual(expected, this.scenarioContext.Get<JsonHostname>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonHostname to JsonString")]
        public void WhenICastTheJsonHostnameToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonHostname>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonHostname"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonHostname")]
        public void WhenICastTheJsonStringToJsonHostname()
        {
            this.scenarioContext.Set((JsonHostname)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonHostname to ReadOnlySpan<char>")]
        public void WhenICastTheJsonHostnameToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonHostname>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonHostname")]
        public void WhenICastTheReadOnlySpanOfCharToJsonHostname()
        {
            this.scenarioContext.Set((JsonHostname)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonHostname to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonHostnameToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonHostname>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonHostname"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonHostname")]
        public void WhenICastTheReadOnlySpanOfByteToJsonHostname()
        {
            this.scenarioContext.Set((JsonHostname)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="string"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonHostname to string")]
        public void WhenICastTheJsonHostnameToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonHostname>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonHostname"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonHostname")]
        public void WhenICastTheStringToJsonHostname()
        {
            this.scenarioContext.Set((JsonHostname)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /* idnIdnEmail */

        /// <summary>
        /// Casts the <see cref="JsonIdnEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonIdnEmail to JsonAny")]
        public void WhenICastTheJsonIdnEmailToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonIdnEmail>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonIdnEmail"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonIdnEmail")]
        public void WhenICastTheJsonAnyToJsonIdnEmail()
        {
            this.scenarioContext.Set((JsonIdnEmail)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonIdnEmail"/> in the context value <see cref="CastResultKey"/> with the given JsonIdnEmail.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonIdnEmail"/>.</param>
        [Then(@"the result should equal the JsonIdnEmail '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonIdnEmail(string expectedValue)
        {
            JsonIdnEmail expected = JsonAny.ParseUriValue(expectedValue).AsString;
            Assert.AreEqual(expected, this.scenarioContext.Get<JsonIdnEmail>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonIdnEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonIdnEmail to JsonString")]
        public void WhenICastTheJsonIdnEmailToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonIdnEmail>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonIdnEmail"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonIdnEmail")]
        public void WhenICastTheJsonStringToJsonIdnEmail()
        {
            this.scenarioContext.Set((JsonIdnEmail)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonIdnEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonIdnEmail to ReadOnlySpan<char>")]
        public void WhenICastTheJsonIdnEmailToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonIdnEmail>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonIdnEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonIdnEmail")]
        public void WhenICastTheReadOnlySpanOfCharToJsonIdnEmail()
        {
            this.scenarioContext.Set((JsonIdnEmail)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonIdnEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonIdnEmail to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonIdnEmailToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonIdnEmail>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonIdnEmail"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonIdnEmail")]
        public void WhenICastTheReadOnlySpanOfByteToJsonIdnEmail()
        {
            this.scenarioContext.Set((JsonIdnEmail)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonIdnEmail"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="string"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonIdnEmail to string")]
        public void WhenICastTheJsonIdnEmailToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonIdnEmail>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonIdnEmail"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonIdnEmail")]
        public void WhenICastTheStringToJsonIdnEmail()
        {
            this.scenarioContext.Set((JsonIdnEmail)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /* idnHostname */

        /// <summary>
        /// Casts the <see cref="JsonIdnHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonIdnHostname to JsonAny")]
        public void WhenICastTheJsonIdnHostnameToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonIdnHostname>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonIdnHostname"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonIdnHostname")]
        public void WhenICastTheJsonAnyToJsonIdnHostname()
        {
            this.scenarioContext.Set((JsonIdnHostname)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonIdnHostname"/> in the context value <see cref="CastResultKey"/> with the given JsonIdnHostname.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonIdnHostname"/>.</param>
        [Then(@"the result should equal the JsonIdnHostname '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonIdnHostname(string expectedValue)
        {
            JsonIdnHostname expected = JsonAny.ParseUriValue(expectedValue).AsString;
            Assert.AreEqual(expected, this.scenarioContext.Get<JsonIdnHostname>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonIdnHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonString"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonIdnHostname to JsonString")]
        public void WhenICastTheJsonIdnHostnameToJsonString()
        {
            this.scenarioContext.Set((JsonString)this.scenarioContext.Get<JsonIdnHostname>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonString"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonIdnHostname"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonString to JsonIdnHostname")]
        public void WhenICastTheJsonStringToJsonIdnHostname()
        {
            this.scenarioContext.Set((JsonIdnHostname)this.scenarioContext.Get<JsonString>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonIdnHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonIdnHostname to ReadOnlySpan<char>")]
        public void WhenICastTheJsonIdnHostnameToReadOnlySpanOfChar()
        {
            this.scenarioContext.Set<ReadOnlyMemory<char>>(((ReadOnlySpan<char>)this.scenarioContext.Get<JsonIdnHostname>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonIdnHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Char}"/>, converts that to a <see cref="ReadOnlyMemory{Char}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<char> to JsonIdnHostname")]
        public void WhenICastTheReadOnlySpanOfCharToJsonIdnHostname()
        {
            this.scenarioContext.Set((JsonIdnHostname)this.scenarioContext.Get<ReadOnlyMemory<char>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonIdnHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="ReadOnlySpan{Byte}"/>, converts that to a <see cref="ReadOnlyMemory{Byte}"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonIdnHostname to ReadOnlySpan<byte>")]
        public void WhenICastTheJsonIdnHostnameToReadOnlySpanOfByte()
        {
            this.scenarioContext.Set<ReadOnlyMemory<byte>>(((ReadOnlySpan<byte>)this.scenarioContext.Get<JsonIdnHostname>(JsonValueSteps.SubjectUnderTest)).ToArray().AsMemory(), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="ReadOnlySpan{Byte}"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonIdnHostname"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the ReadOnlySpan<byte> to JsonIdnHostname")]
        public void WhenICastTheReadOnlySpanOfByteToJsonIdnHostname()
        {
            this.scenarioContext.Set((JsonIdnHostname)this.scenarioContext.Get<ReadOnlyMemory<byte>>(JsonValueSteps.SubjectUnderTest).Span, CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonIdnHostname"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="string"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonIdnHostname to string")]
        public void WhenICastTheJsonIdnHostnameToString()
        {
            this.scenarioContext.Set((string)this.scenarioContext.Get<JsonIdnHostname>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="string"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonIdnHostname"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the string to JsonIdnHostname")]
        public void WhenICastTheStringToJsonIdnHostname()
        {
            this.scenarioContext.Set((JsonIdnHostname)this.scenarioContext.Get<string>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /* integer */

        /// <summary>
        /// Casts the <see cref="JsonInteger"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonInteger to JsonAny")]
        public void WhenICastTheJsonIntegerToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonInteger>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonInteger"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonInteger")]
        public void WhenICastTheJsonAnyToJsonInteger()
        {
            this.scenarioContext.Set<IJsonValue>((JsonInteger)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonInteger"/> in the context value <see cref="CastResultKey"/> with the given JsonInteger.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonContent"/>.</param>
        [Then(@"the result should equal the JsonInteger '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonInteger(string expectedValue)
        {
            Assert.AreEqual((JsonInteger)JsonAny.ParseUriValue(expectedValue), this.scenarioContext.Get<IJsonValue>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="JsonInteger"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="long"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonInteger to long")]
        public void WhenICastTheJsonIntegerToLong()
        {
            this.scenarioContext.Set((long)this.scenarioContext.Get<JsonInteger>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="long"/> in the context value <see cref="CastResultKey"/> with the given long.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonContent"/>.</param>
        [Then(@"the result should equal the long (.*)")]
        public void ThenTheResultShouldEqualTheLong(long expectedValue)
        {
            Assert.AreEqual(expectedValue, this.scenarioContext.Get<long>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="long"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonInteger"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the long to JsonInteger")]
        public void WhenICastTheLongToJsonInteger()
        {
            this.scenarioContext.Set<IJsonValue>((JsonInteger)this.scenarioContext.Get<long>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonInteger"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="int"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonInteger to int")]
        public void WhenICastTheJsonIntegerToInt()
        {
            this.scenarioContext.Set((int)this.scenarioContext.Get<JsonInteger>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="int"/> in the context value <see cref="CastResultKey"/> with the given int.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonContent"/>.</param>
        [Then(@"the result should equal the int (.*)")]
        public void ThenTheResultShouldEqualTheInt(int expectedValue)
        {
            Assert.AreEqual(expectedValue, this.scenarioContext.Get<int>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="int"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonInteger"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the int to JsonInteger")]
        public void WhenICastTheIntToJsonInteger()
        {
            this.scenarioContext.Set<IJsonValue>((JsonInteger)this.scenarioContext.Get<int>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonInteger"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="double"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonInteger to double")]
        public void WhenICastTheJsonIntegerToDouble()
        {
            this.scenarioContext.Set((double)this.scenarioContext.Get<JsonInteger>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="double"/> in the context value <see cref="CastResultKey"/> with the given double.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonContent"/>.</param>
        [Then(@"the result should equal the double (.*)")]
        public void ThenTheResultShouldEqualTheDouble(double expectedValue)
        {
            Assert.AreEqual(expectedValue, this.scenarioContext.Get<double>(CastResultKey));
        }

        /// <summary>
        /// Casts the <see cref="double"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonInteger"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the double to JsonInteger")]
        public void WhenICastTheDoubleToJsonInteger()
        {
            this.scenarioContext.Set<IJsonValue>((JsonInteger)this.scenarioContext.Get<double>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonInteger"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="float"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonInteger to float")]
        public void WhenICastTheJsonIntegerToFloat()
        {
            this.scenarioContext.Set((float)this.scenarioContext.Get<JsonInteger>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="float"/> in the context value <see cref="CastResultKey"/> with the given float.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonContent"/>.</param>
        [Then(@"the result should equal the float (.*)")]
        public void ThenTheResultShouldEqualTheFloat(float expectedValue)
        {
            Assert.AreEqual(expectedValue, this.scenarioContext.Get<float>(CastResultKey), 0.00001);
        }

        /// <summary>
        /// Casts the <see cref="float"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonInteger"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the float to JsonInteger")]
        public void WhenICastTheFloatToJsonInteger()
        {
            this.scenarioContext.Set<IJsonValue>((JsonInteger)this.scenarioContext.Get<float>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /* number */

        /// <summary>
        /// Casts the <see cref="JsonNumber"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonInteger"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonNumber to JsonInteger")]
        public void WhenICastTheJsonNumberToJsonInteger()
        {
            this.scenarioContext.Set((JsonInteger)this.scenarioContext.Get<JsonNumber>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonInteger"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonNumber"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonInteger to JsonNumber")]
        public void WhenICastTheJsonIntegerToJsonNumber()
        {
            this.scenarioContext.Set((JsonNumber)this.scenarioContext.Get<JsonInteger>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonNumber"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonAny"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonNumber to JsonAny")]
        public void WhenICastTheJsonNumberToJsonAny()
        {
            this.scenarioContext.Set((JsonAny)this.scenarioContext.Get<JsonNumber>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonAny"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonNumber"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonAny to JsonNumber")]
        public void WhenICastTheJsonAnyToJsonNumber()
        {
            this.scenarioContext.Set<IJsonValue>((JsonNumber)this.scenarioContext.Get<JsonAny>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Compares the <see cref="JsonNumber"/> in the context value <see cref="CastResultKey"/> with the given JsonNumber.
        /// </summary>
        /// <param name="expectedValue">The serialized form of the <see cref="JsonContent"/>.</param>
        [Then(@"the result should equal the JsonNumber '(.*)'")]
        public void ThenTheResultShouldEqualTheJsonNumber(string expectedValue)
        {
            Assert.AreEqual((JsonNumber)JsonAny.ParseUriValue(expectedValue), this.scenarioContext.Get<IJsonValue>(CastResultKey).AsAny, 0.00001);
        }

        /// <summary>
        /// Casts the <see cref="JsonNumber"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="long"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonNumber to long")]
        public void WhenICastTheJsonNumberToLong()
        {
            this.scenarioContext.Set((long)this.scenarioContext.Get<JsonNumber>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="long"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonNumber"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the long to JsonNumber")]
        public void WhenICastTheLongToJsonNumber()
        {
            this.scenarioContext.Set<IJsonValue>((JsonNumber)this.scenarioContext.Get<long>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonNumber"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="int"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonNumber to int")]
        public void WhenICastTheJsonNumberToInt()
        {
            this.scenarioContext.Set((int)this.scenarioContext.Get<JsonNumber>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="int"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonNumber"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the int to JsonNumber")]
        public void WhenICastTheIntToJsonNumber()
        {
            this.scenarioContext.Set<IJsonValue>((JsonNumber)this.scenarioContext.Get<int>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonNumber"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="double"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonNumber to double")]
        public void WhenICastTheJsonNumberToDouble()
        {
            this.scenarioContext.Set((double)this.scenarioContext.Get<JsonNumber>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="double"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonNumber"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the double to JsonNumber")]
        public void WhenICastTheDoubleToJsonNumber()
        {
            this.scenarioContext.Set<IJsonValue>((JsonNumber)this.scenarioContext.Get<double>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="JsonNumber"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="float"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the JsonNumber to float")]
        public void WhenICastTheJsonNumberToFloat()
        {
            this.scenarioContext.Set((float)this.scenarioContext.Get<JsonNumber>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }

        /// <summary>
        /// Casts the <see cref="float"/> in the key <see cref="JsonValueSteps.SubjectUnderTest"/> to <see cref="JsonNumber"/> and stores it in <see cref="CastResultKey"/>.
        /// </summary>
        [When(@"I cast the float to JsonNumber")]
        public void WhenICastTheFloatToJsonNumber()
        {
            this.scenarioContext.Set<IJsonValue>((JsonNumber)this.scenarioContext.Get<float>(JsonValueSteps.SubjectUnderTest), CastResultKey);
        }
    }
}
