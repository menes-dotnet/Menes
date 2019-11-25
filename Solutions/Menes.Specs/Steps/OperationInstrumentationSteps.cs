// <copyright file="OperationInstrumentationSteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Corvus.SpecFlow.Extensions;
    using Idg.AsyncTest;
    using Idg.AsyncTest.TaskExtensions;
    using Menes.Internal;
    using Menes.Specs.Fakes;
    using Menes.Specs.Steps.TestClasses;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Moq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class OperationInstrumentationSteps : IOpenApiService
    {
        private readonly MethodInfo operationMethodInfo = typeof(OperationInstrumentationSteps).GetMethod(nameof(TestOperation), BindingFlags.NonPublic | BindingFlags.Instance);
        private readonly CompletionSource operationCompletionSource = new CompletionSource();
        private readonly ScenarioContext scenarioContext;
        private Task operationInvocationTask;
        private int reportedOperationCountWhenOpeartionBodyInvoked;

        public OperationInstrumentationSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario("@perScenarioContainer", Order = ContainerBeforeFeatureOrder.ServiceProviderAvailable)]
        public static void InitializeMocks(ScenarioContext scenarioContext)
        {
            OperationInvokerTestContext invokerContext = ContainerBindings.GetServiceProvider(scenarioContext).GetRequiredService<OperationInvokerTestContext>();

            var allowed = new AccessControlPolicyResult(AccessControlPolicyResultType.Allowed);
            invokerContext.AccessChecker
                .Setup(c => c.CheckAccessPoliciesAsync(It.IsAny<IOpenApiContext>(), It.IsAny<AccessCheckOperationDescriptor[]>()))
                .Returns((IOpenApiContext _, AccessCheckOperationDescriptor[] descriptors) => Task.FromResult<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>(
                    descriptors.ToDictionary(d => d, __ => allowed)));
            invokerContext.ParameterBuilder
                .Setup(pb => pb.BuildParametersAsync(It.IsAny<object>(), It.IsAny<OpenApiOperationPathTemplate>()))
                .ReturnsAsync(new Dictionary<string, object>());
        }

        [Given("the operation locator maps the operation id '(.*)' to an operation named '(.*)'")]
        public void GivenTheOperationLocatorMapsTheOperationIdToAnOperationNamed(string operationId, string operationName)
        {
            Assert.AreEqual(nameof(TestOperation), operationName, "Menes uses the method name as the operation name, so this test can only work if the operation specified in the spec matches the name of the operation method supplied");

            var operation = new OpenApiServiceOperation(
                this,
                this.operationMethodInfo,
                new Mock<IOpenApiConfiguration>().Object);
            this.InvokerContext.OperationLocator
                .Setup(m => m.TryGetOperation(operationId, out operation))
                .Returns(true);
        }

        [When("I handle a '(.*)' to '(.*)' with an operation id of '(.*)'")]
        public void WhenIHandleAToWithAnOperationIdOf(string method, string path, string operationId)
        {
            var template = new OpenApiOperationPathTemplate(
                new OpenApiOperation { OperationId = operationId },
                new OpenApiPathTemplate(path, new OpenApiPathItem()));
            this.operationInvocationTask = this.Invoker.InvokeAsync(method, path, null, template, new Mock<IOpenApiContext>().Object);
        }

        [When("the operation invoker has been invoked")]
        public async Task WhenTheOperationInvokerHasBeenInvoked()
        {
            await this.operationCompletionSource.WaitAsync().WithTimeout().ConfigureAwait(false);
        }

        [When("the operation completes")]
        public async Task WhenTheOperationCompletes()
        {
            this.operationCompletionSource.Complete();
            await this.operationInvocationTask.ConfigureAwait(false);
        }

        [Then("instrumentation should start a request named '(.*)'")]
        public void ThenInstrumentationShouldStartARequestNamed(string requestName)
        {
            OperationDetail operation = this.GetSingleOperationDetail();
            Assert.AreEqual(requestName, operation.Name);
        }

        [Then("instrumentation should have already reported the request by the time the operation implementation is invoked")]
        public void ThenInstrumentationShouldHaveAlreadyReportedTheRequestByTheTimeTheOperationImplementationIsInvoked()
        {
            Assert.AreEqual(1, this.reportedOperationCountWhenOpeartionBodyInvoked);
        }

        [Then("the instrumentation should report an OpenAPI operation id of '(.*)'")]
        public void ThenTheInstrumentationShouldReportAnOpenAPIOperationIdOf(string operationId)
        {
            OperationDetail operation = this.GetSingleOperationDetail();
            Assert.AreEqual(operationId, operation.AdditionalDetail?.Properties["Menes.OperationId"]);
        }

        [Then("the request should not have been finished yet")]
        public void ThenTheRequestShouldNotHaveBeenFinishedYet()
        {
            OperationDetail operation = this.GetSingleOperationDetail();
            Assert.IsFalse(operation.IsDisposed);
        }

        [Then("the request should have been finished")]
        public void ThenTheRequestShouldHaveBeenFinished()
        {
            OperationDetail operation = this.GetSingleOperationDetail();
            Assert.IsTrue(operation.IsDisposed);
        }

        private OpenApiOperationInvoker<object, object> Invoker
            => ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<OpenApiOperationInvoker<object, object>>();

        private OperationInvokerTestContext InvokerContext
            => ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<OperationInvokerTestContext>();

        private FakeInstrumentationProvider InstrumentationProvider
            => ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<FakeInstrumentationProvider>();

        private Task TestOperation()
        {
            this.reportedOperationCountWhenOpeartionBodyInvoked = this.InstrumentationProvider.Operations.Count;
            return this.operationCompletionSource.GetTask();
        }

        private OperationDetail GetSingleOperationDetail()
        {
            Assert.AreEqual(1, this.InstrumentationProvider.Operations.Count, "Operations.Count");
            OperationDetail operation = this.InstrumentationProvider.Operations[0];
            return operation;
        }
    }
}