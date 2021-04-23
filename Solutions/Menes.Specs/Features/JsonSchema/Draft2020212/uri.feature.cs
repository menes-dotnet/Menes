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
namespace Features.JsonSchema.Draft2020212
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("uri draft2020-12")]
    [NUnit.Framework.CategoryAttribute("draft2020-12")]
    public partial class UriDraft2020_12Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "draft2020-12"};
        
#line 1 "uri.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/JsonSchema/Draft2020212", "uri draft2020-12", "    In order to use json-schema\r\n    As a developer\r\n    I want to support uri in" +
                    " draft2020-12", ProgrammingLanguage.CSharp, new string[] {
                        "draft2020-12"});
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
        [NUnit.Framework.DescriptionAttribute("validation of URIs")]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/000/data", "true", "a valid URL with anchor tag", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/001/data", "true", "a valid URL with anchor tag and parentheses", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/002/data", "true", "a valid URL with URL-encoded stuff", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/003/data", "true", "a valid puny-coded URL", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/004/data", "true", "a valid URL with many special characters", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/005/data", "true", "a valid URL based on IPv4", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/006/data", "true", "a valid URL with ftp scheme", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/007/data", "true", "a valid URL for a simple text file", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/008/data", "true", "a valid URL", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/009/data", "true", "a valid mailto URI", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/010/data", "true", "a valid newsgroup URI", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/011/data", "true", "a valid tel URI", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/012/data", "true", "a valid URN", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/013/data", "false", "an invalid protocol-relative URI Reference", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/014/data", "false", "an invalid relative URI Reference", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/015/data", "false", "an invalid URI", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/016/data", "false", "an invalid URI though valid URI reference", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/017/data", "false", "an invalid URI with spaces", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/018/data", "false", "an invalid URI with spaces and missing scheme", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/019/data", "false", "an invalid URI with comma in scheme", null)]
        public virtual void ValidationOfURIs(string inputDataReference, string valid, string description, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("inputDataReference", inputDataReference);
            argumentsOfScenario.Add("valid", valid);
            argumentsOfScenario.Add("description", description);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("validation of URIs", "/* Schema: \r\n{\"format\": \"uri\"}\r\n*/", tagsOfScenario, argumentsOfScenario, this._featureTags);
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
#line 12
    testRunner.Given("the input JSON file \"uri.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 13
    testRunner.And("the schema at \"#/0/schema\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
    testRunner.And(string.Format("the input data at \"{0}\"", inputDataReference), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
    testRunner.And("I generate a type for the schema", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
    testRunner.And("I construct an instance of the schema type from the data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
    testRunner.When("I validate the instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
    testRunner.Then(string.Format("the result will be {0}", valid), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
