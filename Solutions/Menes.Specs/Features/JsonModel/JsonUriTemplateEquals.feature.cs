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
    [NUnit.Framework.DescriptionAttribute("JsonUriTemplateEquals")]
    public partial class JsonUriTemplateEqualsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "JsonUriTemplateEquals.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/JsonModel", "JsonUriTemplateEquals", "\tValidate the Json Equals operator, equality overrides and hashcode", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Equals for json element backed value as a uriTemplate")]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"http://example.com/dictionary/{term:1}/{term}\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"http://example.com/dictionary/{term:1}/{term2}\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("null", "null", "true", null)]
        [NUnit.Framework.TestCaseAttribute("null", "\"http://example.com/dictionary/{term:1}/{term}\"", "false", null)]
        public virtual void EqualsForJsonElementBackedValueAsAUriTemplate(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for json element backed value as a uriTemplate", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 5
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
#line 6
 testRunner.Given(string.Format("the JsonElement backed JsonUriTemplate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.When(string.Format("I compare it to the uriTemplate {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for dotnet backed value as a uriTemplate")]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"http://example.com/dictionary/{term:1}/{term}\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"http://example.com/dictionary/{term:1}/{term2}\"", "false", null)]
        public virtual void EqualsForDotnetBackedValueAsAUriTemplate(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for dotnet backed value as a uriTemplate", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 17
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
#line 18
 testRunner.Given(string.Format("the dotnet backed JsonUriTemplate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 19
 testRunner.When(string.Format("I compare it to the uriTemplate {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 20
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for uriTemplate json element backed value as an IJsonValue")]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"hello@endjin.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"http://example.com/dictionary/{term:1}/{term}\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        public virtual void EqualsForUriTemplateJsonElementBackedValueAsAnIJsonValue(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for uriTemplate json element backed value as an IJsonValue", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 27
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
#line 28
 testRunner.Given(string.Format("the JsonElement backed JsonUriTemplate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 29
 testRunner.When(string.Format("I compare the uriTemplate to the IJsonValue {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for uriTemplate dotnet backed value as an IJsonValue")]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"hello@endjin.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"http://example.com/dictionary/{term:1}/{term}\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        public virtual void EqualsForUriTemplateDotnetBackedValueAsAnIJsonValue(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for uriTemplate dotnet backed value as an IJsonValue", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 54
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
#line 55
 testRunner.Given(string.Format("the dotnet backed JsonUriTemplate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 56
 testRunner.When(string.Format("I compare the uriTemplate to the IJsonValue {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 57
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for uriTemplate json element backed value as an object")]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"hello@endjin.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"http://example.com/dictionary/{term:1}/{term}\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "null", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "<new object()>", "false", null)]
        public virtual void EqualsForUriTemplateJsonElementBackedValueAsAnObject(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for uriTemplate json element backed value as an object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 81
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
#line 82
 testRunner.Given(string.Format("the JsonElement backed JsonUriTemplate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 83
 testRunner.When(string.Format("I compare the uriTemplate to the object {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 84
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for uriTemplate dotnet backed value as an object")]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"hello@endjin.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"http://example.com/dictionary/{term:1}/{term}\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "null", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "<null>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "<undefined>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("null", "null", "true", null)]
        [NUnit.Framework.TestCaseAttribute("null", "<null>", "true", null)]
        [NUnit.Framework.TestCaseAttribute("null", "<undefined>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"http://example.com/dictionary/{term:1}/{term}\"", "<new object()>", "false", null)]
        public virtual void EqualsForUriTemplateDotnetBackedValueAsAnObject(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for uriTemplate dotnet backed value as an object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 109
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
#line 110
 testRunner.Given(string.Format("the dotnet backed JsonUriTemplate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 111
 testRunner.When(string.Format("I compare the uriTemplate to the object {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 112
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
