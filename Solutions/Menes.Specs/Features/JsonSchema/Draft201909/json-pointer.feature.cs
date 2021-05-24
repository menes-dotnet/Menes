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
namespace Features.JsonSchema.Draft201909
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("json-pointer draft2019-09")]
    [NUnit.Framework.CategoryAttribute("draft2019-09")]
    public partial class Json_PointerDraft2019_09Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "draft2019-09"};
        
#line 1 "json-pointer.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/JsonSchema/Draft201909", "json-pointer draft2019-09", "    In order to use json-schema\r\n    As a developer\r\n    I want to support json-p" +
                    "ointer in draft2019-09", ProgrammingLanguage.CSharp, new string[] {
                        "draft2019-09"});
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
        [NUnit.Framework.DescriptionAttribute("validation of JSON-pointers (JSON String Representation)")]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/000/data", "true", "a valid JSON-pointer", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/001/data", "false", "not a valid JSON-pointer (~ not escaped)", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/002/data", "true", "valid JSON-pointer with empty segment", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/003/data", "true", "valid JSON-pointer with the last empty segment", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/004/data", "true", "valid JSON-pointer as stated in RFC 6901 #1", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/005/data", "true", "valid JSON-pointer as stated in RFC 6901 #2", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/006/data", "true", "valid JSON-pointer as stated in RFC 6901 #3", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/007/data", "true", "valid JSON-pointer as stated in RFC 6901 #4", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/008/data", "true", "valid JSON-pointer as stated in RFC 6901 #5", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/009/data", "true", "valid JSON-pointer as stated in RFC 6901 #6", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/010/data", "true", "valid JSON-pointer as stated in RFC 6901 #7", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/011/data", "true", "valid JSON-pointer as stated in RFC 6901 #8", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/012/data", "true", "valid JSON-pointer as stated in RFC 6901 #9", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/013/data", "true", "valid JSON-pointer as stated in RFC 6901 #10", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/014/data", "true", "valid JSON-pointer as stated in RFC 6901 #11", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/015/data", "true", "valid JSON-pointer as stated in RFC 6901 #12", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/016/data", "true", "valid JSON-pointer used adding to the last array position", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/017/data", "true", "valid JSON-pointer (- used as object member name)", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/018/data", "true", "valid JSON-pointer (multiple escaped characters)", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/019/data", "true", "valid JSON-pointer (escaped with fraction part) #1", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/020/data", "true", "valid JSON-pointer (escaped with fraction part) #2", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/021/data", "false", "not a valid JSON-pointer (URI Fragment Identifier) #1", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/022/data", "false", "not a valid JSON-pointer (URI Fragment Identifier) #2", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/023/data", "false", "not a valid JSON-pointer (URI Fragment Identifier) #3", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/024/data", "false", "not a valid JSON-pointer (some escaped, but not all) #1", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/025/data", "false", "not a valid JSON-pointer (some escaped, but not all) #2", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/026/data", "false", "not a valid JSON-pointer (wrong escape character) #1", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/027/data", "false", "not a valid JSON-pointer (wrong escape character) #2", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/028/data", "false", "not a valid JSON-pointer (multiple characters not escaped)", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/029/data", "false", "not a valid JSON-pointer (isn\'t empty nor starts with /) #1", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/030/data", "false", "not a valid JSON-pointer (isn\'t empty nor starts with /) #2", null)]
        [NUnit.Framework.TestCaseAttribute("#/000/tests/031/data", "false", "not a valid JSON-pointer (isn\'t empty nor starts with /) #3", null)]
        public virtual void ValidationOfJSON_PointersJSONStringRepresentation(string inputDataReference, string valid, string description, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("inputDataReference", inputDataReference);
            argumentsOfScenario.Add("valid", valid);
            argumentsOfScenario.Add("description", description);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("validation of JSON-pointers (JSON String Representation)", "/* Schema: \r\n{\"format\": \"json-pointer\"}\r\n*/", tagsOfScenario, argumentsOfScenario, this._featureTags);
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
    testRunner.Given("the input JSON file \"json-pointer.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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