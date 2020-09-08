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
namespace Menes.PetStore.Specs.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Create Pet")]
    [NUnit.Framework.CategoryAttribute("perScenarioContainer")]
    [NUnit.Framework.CategoryAttribute("useSelfHostedApi")]
    public partial class CreatePetFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "perScenarioContainer",
                "useSelfHostedApi"};
        
#line 1 "CreatePet.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Create Pet", "\tIn order to manage the list of pets\r\n\tAs a pet shop owner\r\n\tI want to be able to" +
                    " add information for a new pet", ProgrammingLanguage.CSharp, new string[] {
                        "perScenarioContainer",
                        "useSelfHostedApi"});
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
        [NUnit.Framework.DescriptionAttribute("Create a new pet with valid data")]
        [NUnit.Framework.TestCaseAttribute("All fields provided", "2000", "Fluffy", "three-headed-dog", "large", null)]
        public virtual void CreateANewPetWithValidData(string notes, string id, string name, string tag, string size, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Notes", notes);
            argumentsOfScenario.Add("Id", id);
            argumentsOfScenario.Add("Name", name);
            argumentsOfScenario.Add("Tag", tag);
            argumentsOfScenario.Add("Size", size);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a new pet with valid data", null, tagsOfScenario, argumentsOfScenario);
#line 9
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
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Tag",
                            "Size"});
                table1.AddRow(new string[] {
                            string.Format("{0}", id),
                            string.Format("{0}", name),
                            string.Format("{0}", tag),
                            string.Format("{0}", size)});
#line 10
 testRunner.When("I request that a new pet be created", ((string)(null)), table1, "When ");
#line hidden
#line 13
 testRunner.Then("the response status code should be \'Created\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 14
 testRunner.And("the response object should have a property called \'_links.self\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
 testRunner.And("the response should contain the \'Location\' header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
 testRunner.And(string.Format("the response object should have an integer property called \'id\' with value {0}", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.And(string.Format("the response object should have a string property called \'name\' with value \'{0}\'", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
 testRunner.And(string.Format("the response object should have a string property called \'tag\' with value \'{0}\'", tag), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
 testRunner.And(string.Format("the response object should have a string property called \'size\' with value \'{0}\'", size), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
 testRunner.And("the response object should have a property called \'globalIdentifier\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to create a new pet with invalid data")]
        [NUnit.Framework.TestCaseAttribute("Missing Id", "", "Fluffy", "three-headed-dog", "large", null)]
        [NUnit.Framework.TestCaseAttribute("Non-integer Id", "invalid", "Fluffy", "three-headed-dog", "large", null)]
        [NUnit.Framework.TestCaseAttribute("Missing name", "2000", "", "three-headed-dog", "large", null)]
        [NUnit.Framework.TestCaseAttribute("Missing tag", "2000", "Fluffy", "", "large", null)]
        [NUnit.Framework.TestCaseAttribute("Missing size", "2000", "Fluffy", "three-headed-dog", "", null)]
        [NUnit.Framework.TestCaseAttribute("Invalid size", "2000", "Fluffy", "three-headed-dog", "huge", null)]
        public virtual void AttemptToCreateANewPetWithInvalidData(string notes, string id, string name, string tag, string size, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Notes", notes);
            argumentsOfScenario.Add("Id", id);
            argumentsOfScenario.Add("Name", name);
            argumentsOfScenario.Add("Tag", tag);
            argumentsOfScenario.Add("Size", size);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to create a new pet with invalid data", null, tagsOfScenario, argumentsOfScenario);
#line 26
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
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "GlobalIdentifier",
                            "Name",
                            "Tag",
                            "Size"});
                table2.AddRow(new string[] {
                            string.Format("{0}", id),
                            "<GlobalIdentifier>",
                            string.Format("{0}", name),
                            string.Format("{0}", tag),
                            string.Format("{0}", size)});
#line 27
 testRunner.When("I request that a new pet be created", ((string)(null)), table2, "When ");
#line hidden
#line 30
 testRunner.Then("the response status code should be \'BadRequest\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
