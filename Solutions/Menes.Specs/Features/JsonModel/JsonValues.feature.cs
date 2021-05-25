﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Features.JsonModel
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("JsonValues")]
    public partial class JsonValuesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "JsonValues.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/JsonModel", "JsonValues", "\tValidate the Json Value Wrappers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Equals for json element backed value as a string")]
        [NUnit.Framework.TestCaseAttribute("Hello", "Hello", "true", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "Goodbye", "false", null)]
        public virtual void EqualsForJsonElementBackedValueAsAString(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for json element backed value as a string", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 4
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
#line 5
 testRunner.Given(string.Format("the JsonElement backed JsonString {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
 testRunner.When(string.Format("I compare it to the string {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 7
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for dotnet backed value as a string")]
        [NUnit.Framework.TestCaseAttribute("Hello", "Hello", "true", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "Goodbye", "false", null)]
        public virtual void EqualsForDotnetBackedValueAsAString(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for dotnet backed value as a string", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 14
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
 testRunner.Given(string.Format("the dotnet backed JsonString {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
 testRunner.When(string.Format("I compare it to the string {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 17
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for string json element backed value as an IJsonValue")]
        [NUnit.Framework.TestCaseAttribute("Hello", "Hello", "true", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "Goodbye", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "2018-11-13T20:20:39+00:00", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "hello@endjin.com", "false", null)]
        public virtual void EqualsForStringJsonElementBackedValueAsAnIJsonValue(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for string json element backed value as an IJsonValue", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 24
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
#line 25
 testRunner.Given(string.Format("the JsonElement backed JsonString {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 26
 testRunner.When(string.Format("I compare the string to the IJsonValue {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 27
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for string dotnet backed value as an IJsonValue")]
        [NUnit.Framework.TestCaseAttribute("Hello", "Hello", "true", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "Goodbye", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "2018-11-13T20:20:39+00:00", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "hello@endjin.com", "false", null)]
        public virtual void EqualsForStringDotnetBackedValueAsAnIJsonValue(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for string dotnet backed value as an IJsonValue", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 42
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
 testRunner.Given(string.Format("the dotnet backed JsonString {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 44
 testRunner.When(string.Format("I compare the string to the IJsonValue {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 45
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for string json element backed value as an object")]
        [NUnit.Framework.TestCaseAttribute("Hello", "Hello", "true", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "Goodbye", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "2018-11-13T20:20:39+00:00", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "hello@endjin.com", "false", null)]
        public virtual void EqualsForStringJsonElementBackedValueAsAnObject(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for string json element backed value as an object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 60
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
#line 61
 testRunner.Given(string.Format("the JsonElement backed JsonString {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 62
 testRunner.When(string.Format("I compare the string to the object {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 63
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for string dotnet backed value as an object")]
        [NUnit.Framework.TestCaseAttribute("Hello", "Hello", "true", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "Goodbye", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "2018-11-13T20:20:39+00:00", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Hello", "hello@endjin.com", "false", null)]
        public virtual void EqualsForStringDotnetBackedValueAsAnObject(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for string dotnet backed value as an object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 78
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
#line 79
 testRunner.Given(string.Format("the dotnet backed JsonString {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 80
 testRunner.When(string.Format("I compare the string to the object {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 81
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for json element backed value as a boolean")]
        [NUnit.Framework.TestCaseAttribute("Hello", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("1", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("1.1", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("[1,2,3]", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("{ \"first\": \"1\" }", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("true", "true", "true", null)]
        [NUnit.Framework.TestCaseAttribute("false", "false", "true", null)]
        [NUnit.Framework.TestCaseAttribute("true", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("2018-11-13T20:20:39+00:00", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("hello@endjin.com", "true", "false", null)]
        public virtual void EqualsForJsonElementBackedValueAsABoolean(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for json element backed value as a boolean", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 96
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
#line 97
 testRunner.Given(string.Format("the JsonElement backed JsonBoolean {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 98
 testRunner.When(string.Format("I compare it to the boolean {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 99
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for dotnet backed value as a boolean")]
        [NUnit.Framework.TestCaseAttribute("false", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "false", "true", null)]
        [NUnit.Framework.TestCaseAttribute("true", "true", "true", null)]
        [NUnit.Framework.TestCaseAttribute("true", "false", "false", null)]
        public virtual void EqualsForDotnetBackedValueAsABoolean(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for dotnet backed value as a boolean", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 115
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
#line 116
 testRunner.Given(string.Format("the dotnet backed JsonBoolean {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 117
 testRunner.When(string.Format("I compare it to the boolean {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 118
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for boolean json element backed value as an IJsonValue")]
        [NUnit.Framework.TestCaseAttribute("false", "Hello", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("true", "true", "true", null)]
        [NUnit.Framework.TestCaseAttribute("false", "false", "true", null)]
        [NUnit.Framework.TestCaseAttribute("true", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "2018-11-13T20:20:39+00:00", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "hello@endjin.com", "false", null)]
        public virtual void EqualsForBooleanJsonElementBackedValueAsAnIJsonValue(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for boolean json element backed value as an IJsonValue", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 127
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
#line 128
 testRunner.Given(string.Format("the JsonElement backed JsonBoolean {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 129
 testRunner.When(string.Format("I compare the boolean to the IJsonValue {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 130
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for boolean dotnet backed value as an IJsonValue")]
        [NUnit.Framework.TestCaseAttribute("false", "Hello", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("true", "true", "true", null)]
        [NUnit.Framework.TestCaseAttribute("false", "false", "true", null)]
        [NUnit.Framework.TestCaseAttribute("true", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "2018-11-13T20:20:39+00:00", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "hello@endjin.com", "false", null)]
        public virtual void EqualsForBooleanDotnetBackedValueAsAnIJsonValue(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for boolean dotnet backed value as an IJsonValue", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 146
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
#line 147
 testRunner.Given(string.Format("the dotnet backed JsonBoolean {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 148
 testRunner.When(string.Format("I compare the boolean to the IJsonValue {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 149
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for boolean json element backed value as an object")]
        [NUnit.Framework.TestCaseAttribute("false", "Hello", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("true", "true", "true", null)]
        [NUnit.Framework.TestCaseAttribute("false", "false", "true", null)]
        [NUnit.Framework.TestCaseAttribute("true", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "2018-11-13T20:20:39+00:00", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "hello@endjin.com", "false", null)]
        public virtual void EqualsForBooleanJsonElementBackedValueAsAnObject(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for boolean json element backed value as an object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 165
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
#line 166
 testRunner.Given(string.Format("the JsonElement backed JsonBoolean {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 167
 testRunner.When(string.Format("I compare the boolean to the object {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 168
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for boolean dotnet backed value as an object")]
        [NUnit.Framework.TestCaseAttribute("false", "Hello", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("true", "true", "true", null)]
        [NUnit.Framework.TestCaseAttribute("false", "false", "true", null)]
        [NUnit.Framework.TestCaseAttribute("true", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "2018-11-13T20:20:39+00:00", "false", null)]
        [NUnit.Framework.TestCaseAttribute("false", "hello@endjin.com", "false", null)]
        public virtual void EqualsForBooleanDotnetBackedValueAsAnObject(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for boolean dotnet backed value as an object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 184
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
#line 185
 testRunner.Given(string.Format("the dotnet backed JsonBoolean {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 186
 testRunner.When(string.Format("I compare the boolean to the object {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 187
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion