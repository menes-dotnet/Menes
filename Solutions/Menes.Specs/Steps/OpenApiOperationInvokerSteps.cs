// <copyright file="OpenApiOperationInvokerSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using Corvus.Testing.SpecFlow;
    using Idg.AsyncTest.TaskExtensions;
    using Menes.Exceptions;
    using Menes.Internal;
    using Menes.Specs.Steps.TestClasses;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Moq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class OpenApiOperationInvokerSteps : IOpenApiService
    {
        private const string OperationInvokedScenarioContextKey = "OperationInvoked";

        private readonly Mock<IOpenApiConfiguration> openApiConfiguration = new Mock<IOpenApiConfiguration>();
        private readonly Mock<IOpenApiContext> openApiContext = new Mock<IOpenApiContext>();
        private readonly OpenApiResult exceptionMapperResult = new OpenApiResult();
        private readonly object resultBuilderResult = new object();
        private readonly object resultBuilderErrorResult = new object();
        private readonly ScenarioContext scenarioContext;
        private ResponseWhenUnauthenticated? responseWhenUnauthenticated;
        private OpenApiOperation? openApiOperation;
        private OpenApiOperationPathTemplate? operationPathTemplate;
        private Task<object>? invokerResultTask;

        public OpenApiOperationInvokerSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        private OpenApiOperationInvoker<object, object> Invoker
            => ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<OpenApiOperationInvoker<object, object>>();

        private OperationInvokerTestContext InvokerContext
            => ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<OperationInvokerTestContext>();

        [Given("I have configured unauthenticated requests to produce (.*)")]
        public void GivenIAmHaveConfiguredTheUnauthenticatedStatusCodeToBe(string status)
        {
            if (status != "null")
            {
                this.responseWhenUnauthenticated = (ResponseWhenUnauthenticated)Enum.Parse(typeof(ResponseWhenUnauthenticated), status);
            }
        }

        [Given("the operation path template has an Operation with an operationId of '(.*)'")]
        public void GivenTheOperationPathTemplateHasAnOperationWithAnOperationIdOf(string operationId)
        {
            this.openApiOperation = new OpenApiOperation { OperationId = operationId };
            this.operationPathTemplate = new OpenApiOperationPathTemplate(this.openApiOperation, new OpenApiPathTemplate("/", new OpenApiPathItem()));

            MethodInfo serviceMethod = typeof(OpenApiOperationInvokerSteps).GetMethod(
                nameof(this.ServiceMethodImplementation),
                BindingFlags.NonPublic | BindingFlags.Instance)
                ?? throw new InvalidOperationException($"Unable to get method info for {nameof(this.ServiceMethodImplementation)}");

            var openApiServiceOperation = new OpenApiServiceOperation(this, serviceMethod, this.openApiConfiguration.Object);
            this.InvokerContext.OperationLocator
                .Setup(m => m.TryGetOperation(operationId, out openApiServiceOperation))
                .Returns(true);
        }

        [When("I handle a '(.*)' request for '(.*)'")]
        public async Task WhenIHandleARequestFor(string method, string path)
        {
            var parameterBuilder = new Mock<IOpenApiParameterBuilder<object>>();
            parameterBuilder
                .Setup(m => m.BuildParametersAsync(It.IsAny<object>(), this.operationPathTemplate!))
                .Returns(Task.FromResult<IDictionary<string, object>>(new Dictionary<string, object>()));

            this.InvokerContext.ExceptionMapper
                .Setup(m => m.GetResponse(It.IsAny<Exception>(), It.IsAny<OpenApiOperation>()))
                .Returns(this.exceptionMapperResult);

            this.InvokerContext.ResultBuilder
                .Setup(m => m.BuildResult(It.IsAny<object>(), this.openApiOperation!))
                .Returns(this.resultBuilderResult);
            this.InvokerContext.ResultBuilder
                .Setup(m => m.BuildErrorResult(It.IsAny<int>()))
                .Returns(this.resultBuilderErrorResult);

            IOpenApiConfiguration configuration = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IOpenApiConfiguration>();
            if (this.responseWhenUnauthenticated.HasValue)
            {
                configuration.AccessPolicyUnauthenticatedResponse = this.responseWhenUnauthenticated.Value;
            }

            this.InvokerContext.UseManualAccessChecks();

            this.invokerResultTask = this.Invoker.InvokeAsync(
                path,
                method,
                new object(),
                this.operationPathTemplate!,
                this.openApiContext.Object);

            await this.InvokerContext.AccessCheckCalls!.WaitAsync().WithTimeout().ConfigureAwait(false);
        }

        [When("the access checker blocks access with '(.*)'")]
        public async Task WhenTheAccessCheckerBlocksAccessWithoutAnExplanationAsync(AccessControlPolicyResultType resultType)
        {
            var result = new Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>
            {
                { this.InvokerContext.AccessCheckCalls!.Arguments[0].Requests[0], new AccessControlPolicyResult(resultType) },
            };
            this.InvokerContext.AccessCheckCalls!.SupplyResult(result);
            await this.WaitForInvokerToFinishIgnoringErrors().ConfigureAwait(false);
        }

        [When("the access checker blocks access with an explanation of '(.*)'")]
        public async Task WhenTheAccessCheckerBlocksAccessWithAnExplanationOfAsync(string explanation)
        {
            var result = new Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>
            {
                { this.InvokerContext.AccessCheckCalls!.Arguments[0].Requests[0], new AccessControlPolicyResult(AccessControlPolicyResultType.NotAllowed, explanation) },
            };
            this.InvokerContext.AccessCheckCalls!.SupplyResult(result);
            await this.WaitForInvokerToFinishIgnoringErrors().ConfigureAwait(false);
        }

        [When("the access checker allows access")]
        public async Task WhenTheAccessCheckerAllowsAccess()
        {
            var result = new Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>
            {
                { this.InvokerContext.AccessCheckCalls!.Arguments[0].Requests[0], new AccessControlPolicyResult(AccessControlPolicyResultType.Allowed) },
            };
            this.InvokerContext.AccessCheckCalls!.SupplyResult(result);
            await this.WaitForInvokerToFinishIgnoringErrors().ConfigureAwait(false);
        }

        [Then("the access checker should receive a path of '(.*)'")]
        public void ThenTheAccessCheckerShouldReceiveAPathOf(string path)
        {
            Assert.AreEqual(path, this.InvokerContext.AccessCheckCalls!.Arguments[0].Requests[0].Path);
        }

        [Then("the access checker should receive an operationId of '(.*)'")]
        public void ThenTheAccessCheckerShouldReceiveAnOperationIdOf(string operationId)
        {
            Assert.AreEqual(operationId, this.InvokerContext.AccessCheckCalls!.Arguments[0].Requests[0].OperationId);
        }

        [Then("the access checker should receive an HttpMethod of '(.*)'")]
        public void ThenTheAccessCheckerShouldReceiveAnHttpMethodOf(string method)
        {
            Assert.AreEqual(method, this.InvokerContext.AccessCheckCalls!.Arguments[0].Requests[0].Method);
        }

        [Then("the access checker should receive the Open API context")]
        public void ThenTheAccessCheckerShouldReceiveTheOpenAPIContext()
        {
            Assert.AreSame(this.openApiContext.Object, this.InvokerContext.AccessCheckCalls!.Arguments[0].Context);
        }

        [Then("the invoker should complete without exceptions")]
        public async Task ThenTheInvokerShouldCompleteWithoutExceptions()
        {
            await this.invokerResultTask!.ConfigureAwait(false);
        }

        [Then("the operation method should not be invoked")]
        public void ThenTheOperationMethodShouldNotBeInvoked()
        {
            Assert.False(this.scenarioContext.ContainsKey(OperationInvokedScenarioContextKey));
        }

        [Then("the operation method should be invoked")]
        public void ThenTheOperationMethodShouldBeInvoked()
        {
            Assert.True(this.scenarioContext.ContainsKey(OperationInvokedScenarioContextKey));
        }

        [Then("the invoker should map an '(.*)' with no explanation")]
        public void ThenTheInvokerShouldMapAnOpenApiForbiddenExceptionWithNoExplanation(string exceptionType)
        {
            this.InvokerContext.ExceptionMapper.Verify(m => m.GetResponse(
                It.Is<Exception>(x => x.GetType().Name == exceptionType && !x.Data.Contains("detail")),
                this.openApiOperation!));
        }

        [Then("the invoker should map an OpenApiForbiddenException with an explanation of '(.*)'")]
        public void ThenTheInvokerShouldMapAnOpenApiForbiddenExceptionWithAnExplanationOf(string explanation)
        {
            this.InvokerContext.ExceptionMapper.Verify(m => m.GetResponse(
                It.Is<Exception>(x => x is OpenApiForbiddenException && ((string?)x.Data["detail"]) == explanation),
                this.openApiOperation!));
        }

        [Then("the invoker should pass the method result to the result builder")]
        public void ThenTheInvokerShouldPassTheMethodResultToTheResultBuilder()
        {
            this.InvokerContext.ResultBuilder.Verify(m => m.BuildResult(
                this.scenarioContext[OperationInvokedScenarioContextKey],
                this.openApiOperation!));
        }

        [Then("the invoker should pass the result from the exception mapper to the result builder")]
        public void ThenTheInvokerShouldPassTheResultFromTheExceptionMapperToTheResultBuilder()
        {
            this.InvokerContext.ResultBuilder.Verify(m => m.BuildResult(this.exceptionMapperResult, this.openApiOperation!));
        }

        [Then("the invoker should return the result from the result builder")]
        public async Task ThenTheInvokerShouldReturnTheResultFromTheResultBuilder()
        {
            object result = await this.invokerResultTask!.ConfigureAwait(false);
            Assert.AreSame(this.resultBuilderResult, result);
        }

        [Then("invoker should return a (.*) error result")]
        public async Task ThenInvokerShouldReturnAErrorResult(int statusCode)
        {
            object result = await this.invokerResultTask!.ConfigureAwait(false);
            Assert.AreSame(this.resultBuilderErrorResult, result);
            this.InvokerContext.ResultBuilder.Verify(m => m.BuildErrorResult(statusCode));
        }

        private Task<OpenApiResult> ServiceMethodImplementation()
        {
            var result = new OpenApiResult { StatusCode = 200 };
            this.scenarioContext.Set(result, OperationInvokedScenarioContextKey);

            return Task.FromResult(result);
        }

        private async Task WaitForInvokerToFinishIgnoringErrors()
        {
            // We ignore errors, because some tests expect exceptions.
            await this.invokerResultTask.WhenCompleteIgnoringErrors().WithTimeout().ConfigureAwait(false);
        }
    }
}
