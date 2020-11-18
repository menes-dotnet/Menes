﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.4.0.0
//      SpecFlow Generator Version:3.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Features.JsonSchema
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("properties")]
    public partial class PropertiesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "properties.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/JsonSchema", "properties", "    In order to use json-schema\r\n    As a developer\r\n    I want to support proper" +
                    "ties", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("object properties validation")]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/000/data", "true", "both properties present and valid is valid", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/001/data", "false", "one property invalid is invalid", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/002/data", "false", "both properties invalid is invalid", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/003/data", "true", "doesn\'t invalidate other properties", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/004/data", "true", "ignores arrays", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/005/data", "true", "ignores other non-objects", null)]
        public virtual void ObjectPropertiesValidation(string inputDataReference, string valid, string description, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("inputDataReference", inputDataReference);
            argumentsOfScenario.Add("valid", valid);
            argumentsOfScenario.Add("description", description);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("object properties validation", "/* Schema: \r\n{\r\n            \"properties\": {\r\n                \"foo\": {\"type\": \"int" +
                    "eger\"},\r\n                \"bar\": {\"type\": \"string\"}\r\n            }\r\n        }\r\n*/" +
                    "", tagsOfScenario, argumentsOfScenario);
#line 6
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
#line 15
    testRunner.Given("the input JSON file \"properties.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
    testRunner.And("the schema at \"#/0/schema\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
    testRunner.And(string.Format("the input data at \"{0}\"", inputDataReference), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
    testRunner.And("I generate a type for the schema", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
    testRunner.And("I construct an instance of the schema type from the data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
    testRunner.When("I validate the instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
    testRunner.Then(string.Format("the result will be {0}", valid), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("properties, patternProperties, additionalProperties interaction")]
        [NUnit.Framework.TestCaseAttribute("#/001/tests/000/data", "true", "property validates property", null)]
        [NUnit.Framework.TestCaseAttribute("#/001/tests/001/data", "false", "property invalidates property", null)]
        [NUnit.Framework.TestCaseAttribute("#/001/tests/002/data", "false", "patternProperty invalidates property", null)]
        [NUnit.Framework.TestCaseAttribute("#/001/tests/003/data", "true", "patternProperty validates nonproperty", null)]
        [NUnit.Framework.TestCaseAttribute("#/001/tests/004/data", "false", "patternProperty invalidates nonproperty", null)]
        [NUnit.Framework.TestCaseAttribute("#/001/tests/005/data", "true", "additionalProperty ignores property", null)]
        [NUnit.Framework.TestCaseAttribute("#/001/tests/006/data", "true", "additionalProperty validates others", null)]
        [NUnit.Framework.TestCaseAttribute("#/001/tests/007/data", "false", "additionalProperty invalidates others", null)]
        public virtual void PropertiesPatternPropertiesAdditionalPropertiesInteraction(string inputDataReference, string valid, string description, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("inputDataReference", inputDataReference);
            argumentsOfScenario.Add("valid", valid);
            argumentsOfScenario.Add("description", description);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("properties, patternProperties, additionalProperties interaction", @"/* Schema: 
{
            ""properties"": {
                ""foo"": {""type"": ""array"", ""maxItems"": 3},
                ""bar"": {""type"": ""array""}
            },
            ""patternProperties"": {""f.o"": {""minItems"": 2}},
            ""additionalProperties"": {""type"": ""integer""}
        }
*/", tagsOfScenario, argumentsOfScenario);
#line 32
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
#line 43
    testRunner.Given("the input JSON file \"properties.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 44
    testRunner.And("the schema at \"#/1/schema\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
    testRunner.And(string.Format("the input data at \"{0}\"", inputDataReference), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 46
    testRunner.And("I generate a type for the schema", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 47
    testRunner.And("I construct an instance of the schema type from the data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
    testRunner.When("I validate the instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 49
    testRunner.Then(string.Format("the result will be {0}", valid), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("properties with boolean schema")]
        [NUnit.Framework.TestCaseAttribute("#/002/tests/000/data", "true", "no property present is valid", null)]
        [NUnit.Framework.TestCaseAttribute("#/002/tests/001/data", "true", "only \'true\' property present is valid", null)]
        [NUnit.Framework.TestCaseAttribute("#/002/tests/002/data", "false", "only \'false\' property present is invalid", null)]
        [NUnit.Framework.TestCaseAttribute("#/002/tests/003/data", "false", "both properties present is invalid", null)]
        public virtual void PropertiesWithBooleanSchema(string inputDataReference, string valid, string description, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("inputDataReference", inputDataReference);
            argumentsOfScenario.Add("valid", valid);
            argumentsOfScenario.Add("description", description);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("properties with boolean schema", "/* Schema: \r\n{\r\n            \"properties\": {\r\n                \"foo\": true,\r\n      " +
                    "          \"bar\": false\r\n            }\r\n        }\r\n*/", tagsOfScenario, argumentsOfScenario);
#line 62
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
#line 71
    testRunner.Given("the input JSON file \"properties.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 72
    testRunner.And("the schema at \"#/2/schema\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 73
    testRunner.And(string.Format("the input data at \"{0}\"", inputDataReference), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
    testRunner.And("I generate a type for the schema", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 75
    testRunner.And("I construct an instance of the schema type from the data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 76
    testRunner.When("I validate the instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 77
    testRunner.Then(string.Format("the result will be {0}", valid), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("properties with escaped characters")]
        [NUnit.Framework.TestCaseAttribute("#/003/tests/000/data", "true", "object with all numbers is valid", null)]
        [NUnit.Framework.TestCaseAttribute("#/003/tests/001/data", "false", "object with strings is invalid", null)]
        public virtual void PropertiesWithEscapedCharacters(string inputDataReference, string valid, string description, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("inputDataReference", inputDataReference);
            argumentsOfScenario.Add("valid", valid);
            argumentsOfScenario.Add("description", description);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("properties with escaped characters", @"/* Schema: 
{
            ""properties"": {
                ""foo\nbar"": {""type"": ""number""},
                ""foo\""bar"": {""type"": ""number""},
                ""foo\\bar"": {""type"": ""number""},
                ""foo\rbar"": {""type"": ""number""},
                ""foo\tbar"": {""type"": ""number""},
                ""foo\fbar"": {""type"": ""number""}
            }
        }
*/", tagsOfScenario, argumentsOfScenario);
#line 86
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
#line 99
    testRunner.Given("the input JSON file \"properties.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 100
    testRunner.And("the schema at \"#/3/schema\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 101
    testRunner.And(string.Format("the input data at \"{0}\"", inputDataReference), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 102
    testRunner.And("I generate a type for the schema", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 103
    testRunner.And("I construct an instance of the schema type from the data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 104
    testRunner.When("I validate the instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 105
    testRunner.Then(string.Format("the result will be {0}", valid), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion