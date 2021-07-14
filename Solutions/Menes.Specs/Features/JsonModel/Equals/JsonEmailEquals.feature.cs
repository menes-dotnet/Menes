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
namespace Features.JsonModel.Equals
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("JsonEmailEquals")]
    public partial class JsonEmailEqualsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "JsonEmailEquals.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/JsonModel/Equals", "JsonEmailEquals", "\tValidate the Json Equals operator, equality overrides and hashcode", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Equals for json element backed value as a email")]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"hello@endjin.com\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"Garbage\"", "\"hello@endjin.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("null", "null", "true", null)]
        [NUnit.Framework.TestCaseAttribute("null", "\"hello@endjin.com\"", "false", null)]
        public virtual void EqualsForJsonElementBackedValueAsAEmail(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for json element backed value as a email", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
 testRunner.Given(string.Format("the JsonElement backed JsonEmail {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.When(string.Format("I compare it to the email {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for dotnet backed value as a email")]
        [NUnit.Framework.TestCaseAttribute("\"Garbage\"", "\"hello@endjin.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"hello@endjin.com\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"Goodbye\"", "false", null)]
        public virtual void EqualsForDotnetBackedValueAsAEmail(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for dotnet backed value as a email", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 18
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
#line 19
 testRunner.Given(string.Format("the dotnet backed JsonEmail {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 20
 testRunner.When(string.Format("I compare it to the email {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for email json element backed value as an IJsonValue")]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"Garbage\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"hello@endjin.com\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"http://foo.bar/?baz=qux#quux\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        public virtual void EqualsForEmailJsonElementBackedValueAsAnIJsonValue(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for email json element backed value as an IJsonValue", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 29
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
#line 30
 testRunner.Given(string.Format("the JsonElement backed JsonEmail {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 31
 testRunner.When(string.Format("I compare the email to the IJsonValue {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 32
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for email dotnet backed value as an IJsonValue")]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"http://foo.bar/?baz=qux#quux\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"Garbage\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"hello@endjin.com\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        public virtual void EqualsForEmailDotnetBackedValueAsAnIJsonValue(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for email dotnet backed value as an IJsonValue", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 56
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
#line 57
 testRunner.Given(string.Format("the dotnet backed JsonEmail {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 58
 testRunner.When(string.Format("I compare the email to the IJsonValue {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 59
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for email json element backed value as an object")]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"hello@endjin.com\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"http://foo.bar/?baz=qux#quux\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "<new object()>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "null", "false", null)]
        public virtual void EqualsForEmailJsonElementBackedValueAsAnObject(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for email json element backed value as an object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 83
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
#line 84
 testRunner.Given(string.Format("the JsonElement backed JsonEmail {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 85
 testRunner.When(string.Format("I compare the email to the object {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 86
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for email dotnet backed value as an object")]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"hello@endjin.com\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"http://foo.bar/?baz=qux#quux\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "<new object()>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "null", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "<null>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"hello@endjin.com\"", "<undefined>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("null", "null", "true", null)]
        [NUnit.Framework.TestCaseAttribute("null", "<null>", "true", null)]
        [NUnit.Framework.TestCaseAttribute("null", "<undefined>", "false", null)]
        public virtual void EqualsForEmailDotnetBackedValueAsAnObject(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for email dotnet backed value as an object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 111
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
#line 112
 testRunner.Given(string.Format("the dotnet backed JsonEmail {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 113
 testRunner.When(string.Format("I compare the email to the object {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 114
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion