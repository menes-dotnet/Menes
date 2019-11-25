// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("OpenApiOperationInvoker")]
    [NUnit.Framework.CategoryAttribute("perScenarioContainer")]
    public partial class OpenApiOperationInvokerFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "OpenApiOperationInvoker.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "OpenApiOperationInvoker", "    In order to implement an Open API service\r\n    As a developer\r\n    I want the" +
                    " OpenApiOperationInvoker to invoke my service implementation method, and all ass" +
                    "ociated services", ProgrammingLanguage.CSharp, new string[] {
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
        public virtual void ScenarioTearDown()
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
        [NUnit.Framework.DescriptionAttribute("The request details are passed to the access checker")]
        [NUnit.Framework.TestCaseAttribute("/test/1", "op1", "GET", null)]
        [NUnit.Framework.TestCaseAttribute("/test/2", "op2", "GET", null)]
        [NUnit.Framework.TestCaseAttribute("/test/1", "op1", "PUT", null)]
        [NUnit.Framework.TestCaseAttribute("/test/2", "op2", "POST", null)]
        public virtual void TheRequestDetailsArePassedToTheAccessChecker(string path, string operationId, string httpMethod, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The request details are passed to the access checker", null, exampleTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
    testRunner.Given(string.Format("the operation path template has an Operation with an operationId of \'{0}\'", operationId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
    testRunner.When(string.Format("I handle a \'{0}\' request for \'{1}\'", httpMethod, path), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
    testRunner.Then(string.Format("the access checker should receive a path of \'{0}\'", path), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
    testRunner.And(string.Format("the access checker should receive an operationId of \'{0}\'", operationId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
    testRunner.And(string.Format("the access checker should receive an HttpMethod of \'{0}\'", httpMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
    testRunner.And("the access checker should receive the Open API context", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The access checker blocks the request without an explanation")]
        [NUnit.Framework.TestCaseAttribute("null", "NotAllowed", "OpenApiForbiddenException", null)]
        [NUnit.Framework.TestCaseAttribute("Forbidden", "NotAllowed", "OpenApiForbiddenException", null)]
        [NUnit.Framework.TestCaseAttribute("Unauthorized", "NotAllowed", "OpenApiForbiddenException", null)]
        [NUnit.Framework.TestCaseAttribute("ServerError", "NotAllowed", "OpenApiForbiddenException", null)]
        [NUnit.Framework.TestCaseAttribute("null", "NotAuthenticated", "OpenApiUnauthorizedException", null)]
        [NUnit.Framework.TestCaseAttribute("Forbidden", "NotAuthenticated", "OpenApiForbiddenException", null)]
        [NUnit.Framework.TestCaseAttribute("Unauthorized", "NotAuthenticated", "OpenApiUnauthorizedException", null)]
        public virtual void TheAccessCheckerBlocksTheRequestWithoutAnExplanation(string configuredStatusWhenUnauthenticated, string resultType, string exceptionType, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The access checker blocks the request without an explanation", null, exampleTags);
#line 23
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 24
    testRunner.Given(string.Format("I have configured unauthenticated requests to produce {0}", configuredStatusWhenUnauthenticated), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
    testRunner.And("the operation path template has an Operation with an operationId of \'op1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
    testRunner.When("I handle a \'GET\' request for \'/test/1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
    testRunner.And(string.Format("the access checker blocks access with \'{0}\'", resultType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
    testRunner.Then("the operation method should not be invoked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
    testRunner.And(string.Format("the invoker should map an \'{0}\' with no explanation", exceptionType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
    testRunner.And("the invoker should pass the result from the exception mapper to the result builde" +
                    "r", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
    testRunner.And("the invoker should return the result from the result builder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The access checker blocks the request without an explanation and unauthenticated " +
            "requests should produce ServerError")]
        public virtual void TheAccessCheckerBlocksTheRequestWithoutAnExplanationAndUnauthenticatedRequestsShouldProduceServerError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The access checker blocks the request without an explanation and unauthenticated " +
                    "requests should produce ServerError", null, ((string[])(null)));
#line 43
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 44
    testRunner.Given("I have configured unauthenticated requests to produce ServerError", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
    testRunner.And("the operation path template has an Operation with an operationId of \'op1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
    testRunner.When("I handle a \'GET\' request for \'/test/1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
    testRunner.And("the access checker blocks access with \'NotAuthenticated\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
    testRunner.Then("the operation method should not be invoked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
    testRunner.And("the invoker should complete without exceptions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
    testRunner.And("invoker should return a 500 error result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The access checker blocks the request with an explanation")]
        public virtual void TheAccessCheckerBlocksTheRequestWithAnExplanation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The access checker blocks the request with an explanation", null, ((string[])(null)));
#line 52
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 53
    testRunner.Given("the operation path template has an Operation with an operationId of \'op1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
    testRunner.When("I handle a \'GET\' request for \'/test/1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
    testRunner.And("the access checker blocks access with an explanation of \'no dice\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
    testRunner.Then("the operation method should not be invoked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
    testRunner.And("the invoker should map an OpenApiForbiddenException with an explanation of \'no di" +
                    "ce\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
    testRunner.And("the invoker should pass the result from the exception mapper to the result builde" +
                    "r", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
    testRunner.And("the invoker should return the result from the result builder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The access checker does not block the request")]
        public virtual void TheAccessCheckerDoesNotBlockTheRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The access checker does not block the request", null, ((string[])(null)));
#line 61
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 62
    testRunner.Given("the operation path template has an Operation with an operationId of \'op1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
    testRunner.When("I handle a \'GET\' request for \'/test/1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
    testRunner.And("the access checker allows access", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
    testRunner.Then("the invoker should complete without exceptions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
    testRunner.And("the operation method should be invoked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
    testRunner.And("the invoker should pass the method result to the result builder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
    testRunner.And("the invoker should return the result from the result builder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
