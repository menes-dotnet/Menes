﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.3.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Menes.Specs.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("OpenApiDefaultParameterParsing")]
    [NUnit.Framework.CategoryAttribute("perScenarioContainer")]
    public partial class OpenApiDefaultParameterParsingFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "perScenarioContainer"};
        
#line 1 "OpenApiDefaultParameterParsing.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "OpenApiDefaultParameterParsing", @"	In order to simplify setting values for parameters required for the underlying operation
	As a developer
	I want to be able to specify default values for those parameters within the OpenAPI specification and have those parameters validated and serialized for use downstream.", ProgrammingLanguage.CSharp, new string[] {
                        "perScenarioContainer"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Parameters with valid values for simple types")]
        [NUnit.Framework.TestCaseAttribute("query", "openApiDate", "string", "date", "2017-07-21", "2017-07-21T00:00:00Z", "System.DateTimeOffset", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiDateTime", "string", "date-time", "\"2017-07-21T17:32:28Z\"", "2017-07-21T17:32:28+00:00", "System.String", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiPassword", "string", "password", "myVErySeCurePAsSworD123", "myVErySeCurePAsSworD123", "System.String", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiByte", "string", "byte", "U3dhZ2dlciByb2Nrcw==", "U3dhZ2dlciByb2Nrcw==", "ByteArrayFromBase64String", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiString", "string", "uuid", "9b7d63fb-1689-4697-9571-00d10b873d78", "9b7d63fb-1689-4697-9571-00d10b873d78", "System.Guid", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiString", "string", "uri", "\"https://myuri.com\"", "https://myuri.com", "System.Uri", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiString", "string", "", "\"I said \\\"What is a \'PC\'?\\\"\"", "I said \"What is a \'PC\'?\"", "System.String", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiBoolean", "boolean", "", "true", "true", "System.Boolean", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiLong", "integer", "int64", "9223372036854775807", "9223372036854775807", "System.Int64", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiInteger", "integer", "", "1234", "1234", "System.Int32", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiFloat", "number", "float", "1234.5", "1234.5", "System.Single", null)]
        [NUnit.Framework.TestCaseAttribute("query", "openApiDouble", "number", "double", "1234.5678", "1234.5678", "System.Double", null)]
        [NUnit.Framework.TestCaseAttribute("header", "openApiDate", "string", "date", "2017-07-21", "2017-07-21T00:00:00Z", "System.DateTimeOffset", null)]
        [NUnit.Framework.TestCaseAttribute("header", "openApiDateTime", "string", "date-time", "\"2017-07-21T17:32:28Z\"", "2017-07-21T17:32:28+00:00", "System.String", null)]
        [NUnit.Framework.TestCaseAttribute("header", "openApiPassword", "string", "password", "myVErySeCurePAsSworD123", "myVErySeCurePAsSworD123", "System.String", null)]
        [NUnit.Framework.TestCaseAttribute("header", "openApiByte", "string", "byte", "U3dhZ2dlciByb2Nrcw==", "U3dhZ2dlciByb2Nrcw==", "ByteArrayFromBase64String", null)]
        [NUnit.Framework.TestCaseAttribute("header", "openApiString", "string", "", "\"I said \\\"What is a \'PC\'?\\\"\"", "I said \"What is a \'PC\'?\"", "System.String", null)]
        [NUnit.Framework.TestCaseAttribute("header", "openApiBoolean", "boolean", "", "true", "true", "System.Boolean", null)]
        [NUnit.Framework.TestCaseAttribute("header", "openApiLong", "integer", "int64", "9223372036854775807", "9223372036854775807", "System.Int64", null)]
        [NUnit.Framework.TestCaseAttribute("header", "openApiInteger", "integer", "", "1234", "1234", "System.Int32", null)]
        [NUnit.Framework.TestCaseAttribute("header", "openApiFloat", "number", "float", "1234.5", "1234.5", "System.Single", null)]
        [NUnit.Framework.TestCaseAttribute("header", "openApiDouble", "number", "double", "1234.5678", "1234.5678", "System.Double", null)]
        [NUnit.Framework.TestCaseAttribute("cookie", "openApiDate", "string", "date", "2017-07-21", "2017-07-21T00:00:00Z", "System.DateTimeOffset", null)]
        [NUnit.Framework.TestCaseAttribute("cookie", "openApiDateTime", "string", "date-time", "\"2017-07-21T17:32:28Z\"", "2017-07-21T17:32:28+00:00", "System.String", null)]
        [NUnit.Framework.TestCaseAttribute("cookie", "openApiPassword", "string", "password", "myVErySeCurePAsSworD123", "myVErySeCurePAsSworD123", "System.String", null)]
        [NUnit.Framework.TestCaseAttribute("cookie", "openApiByte", "string", "byte", "U3dhZ2dlciByb2Nrcw==", "U3dhZ2dlciByb2Nrcw==", "ByteArrayFromBase64String", null)]
        [NUnit.Framework.TestCaseAttribute("cookie", "openApiString", "string", "", "\"I said \\\"What the ♻😟¥a is a \'PC\'?\\\"\"", "I said \"What the ♻😟¥a is a \'PC\'?\"", "System.String", null)]
        [NUnit.Framework.TestCaseAttribute("cookie", "openApiBoolean", "boolean", "", "true", "true", "System.Boolean", null)]
        [NUnit.Framework.TestCaseAttribute("cookie", "openApiLong", "integer", "int64", "9223372036854775807", "9223372036854775807", "System.Int64", null)]
        [NUnit.Framework.TestCaseAttribute("cookie", "openApiInteger", "integer", "", "1234", "1234", "System.Int32", null)]
        [NUnit.Framework.TestCaseAttribute("cookie", "openApiFloat", "number", "float", "1234.5", "1234.5", "System.Single", null)]
        [NUnit.Framework.TestCaseAttribute("cookie", "openApiDouble", "number", "double", "1234.5678", "1234.5678", "System.Double", null)]
        public virtual void ParametersWithValidValuesForSimpleTypes(string parameterLocation, string parameterName, string type, string format, string defaultValue, string expectedResult, string expectedResultType, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("ParameterLocation", parameterLocation);
            argumentsOfScenario.Add("ParameterName", parameterName);
            argumentsOfScenario.Add("Type", type);
            argumentsOfScenario.Add("Format", format);
            argumentsOfScenario.Add("DefaultValue", defaultValue);
            argumentsOfScenario.Add("ExpectedResult", expectedResult);
            argumentsOfScenario.Add("ExpectedResultType", expectedResultType);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Parameters with valid values for simple types", null, tagsOfScenario, argumentsOfScenario);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 9
 testRunner.Given(string.Format("I have constructed the OpenAPI specification with a {0} parameter with name {1}, " +
                            "type {2}, format {3} and default value {4}", parameterLocation, parameterName, type, format, defaultValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 10
 testRunner.When("I try to parse the default value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 11
 testRunner.Then(string.Format("the parameter {0} should be {1} of type {2}", parameterName, expectedResult, expectedResultType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Array parameter with items of simple type")]
        public virtual void ArrayParameterWithItemsOfSimpleType()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Array parameter with items of simple type", null, tagsOfScenario, argumentsOfScenario);
#line 48
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 49
 testRunner.Given("I have constructed the OpenAPI specification with a parameter with name \'openApiA" +
                        "rray\', of type array, containing items of type \'integer\', and the default value " +
                        "for the parameter is \'[1,2,3,4,5]\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 50
 testRunner.When("I try to parse the default value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 51
 testRunner.Then("the parameter openApiArray should be [1,2,3,4,5] of type System.String", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Array parameter with items of array type")]
        public virtual void ArrayParameterWithItemsOfArrayType()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Array parameter with items of array type", null, tagsOfScenario, argumentsOfScenario);
#line 53
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 54
 testRunner.Given("I have constructed the OpenAPI specification with a parameter with name \'openApiN" +
                        "estedArray\', of type array, containing items which are arrays themselves with it" +
                        "em type \'integer\', and the default value for the parameter is \'[[1],[2,3],[4,5,6" +
                        "]]\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 55
 testRunner.When("I try to parse the default value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 56
 testRunner.Then("the parameter openApiNestedArray should be [[1],[2,3],[4,5,6]] of type System.Str" +
                        "ing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Array parameter with items of object type")]
        public virtual void ArrayParameterWithItemsOfObjectType()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Array parameter with items of object type", null, tagsOfScenario, argumentsOfScenario);
#line 58
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 59
 testRunner.Given(@"I have constructed the OpenAPI specification with a parameter with name 'openApiArrayWithObjectItems', of type array, containing items which are objects which has the property structure '{ ""id"": { ""type"": ""integer"" }, ""name"": {""type"": ""string""} }', and the default value for the parameter is '[{""id"": 123, ""name"": ""Ed""}, {""id"": 456, ""name"": ""Ian""}]'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 60
 testRunner.When("I try to parse the default value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 61
 testRunner.Then("the parameter openApiArrayWithObjectItems should be [{\"id\":123,\"name\":\"Ed\"},{\"id\"" +
                        ":456,\"name\":\"Ian\"}] of type System.String", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Object parameter with properties of simple types")]
        public virtual void ObjectParameterWithPropertiesOfSimpleTypes()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Object parameter with properties of simple types", null, tagsOfScenario, argumentsOfScenario);
#line 63
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 64
 testRunner.Given(@"I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ ""id"": { ""type"": ""integer"" }, ""name"": {""type"": ""string""} }', and the default value for the parameter is '{""id"":123, ""name"": ""Ed""}'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 65
 testRunner.When("I try to parse the default value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 66
 testRunner.Then("the parameter openApiObject should be {\"id\":123,\"name\":\"Ed\"} of type System.Strin" +
                        "g", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Object parameter with properties of complex types")]
        public virtual void ObjectParameterWithPropertiesOfComplexTypes()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Object parameter with properties of complex types", null, tagsOfScenario, argumentsOfScenario);
#line 68
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 69
 testRunner.Given(@"I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ ""names"": { ""type"": ""array"", ""items"": { ""type"": ""string"" } }, ""details"": {""type"": ""object"", ""properties"": { ""age"": { ""type"": ""integer"" }, ""hairColour"": { ""type"": ""string"" } } } }', and the default value for the parameter is '{""names"": [""Ed"",""Ian""] , ""details"": {""age"": 24, ""hairColour"": ""Brown""} }'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 70
 testRunner.When("I try to parse the default value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 71
 testRunner.Then("the parameter openApiObjectWithComplexProperties should be {\"names\":[\"Ed\",\"Ian\"]," +
                        "\"details\":{\"age\":24,\"hairColour\":\"Brown\"}} of type System.String", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Any parameter with null default value")]
        public virtual void AnyParameterWithNullDefaultValue()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Any parameter with null default value", null, tagsOfScenario, argumentsOfScenario);
#line 73
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 74
 testRunner.Given("I have constructed the OpenAPI specification with a query parameter with name ope" +
                        "nApiNull, type string, format null and a null default value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 75
 testRunner.When("I try to parse the default value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 76
 testRunner.Then("an \'OpenApiSpecificationException\' should be thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
