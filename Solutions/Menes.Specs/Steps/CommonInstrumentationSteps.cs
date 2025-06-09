// <copyright file="CommonInstrumentationSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System.Threading.Tasks;
    using Idg.AsyncTest.TaskExtensions;    using Menes.Specs.Fakes;
    using Microsoft.OpenApi.Models;
    using NSubstitute;
    using NUnit.Framework;
    using Reqnroll;

    [Binding]
    public class CommonInstrumentationSteps : InstrumentationStepsBase
    {
        public CommonInstrumentationSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
        }

        [When("I handle a '(.*)' to '(.*)' with an operation id of '(.*)'")]
        public void WhenIHandleAToWithAnOperationIdOf(string method, string path, string operationId)
        {
            var template = new OpenApiOperationPathTemplate(
                new OpenApiOperation { OperationId = operationId },
                new OpenApiPathTemplate(path, new OpenApiPathItem()));
            this.InvokerContext.OperationInvocationTask = this.Invoker.InvokeAsync(method, path, new object(), template, Substitute.For<IOpenApiContext>());
        }

        [When("the operation invoker has been invoked")]
        public async Task WhenTheOperationInvokerHasBeenInvoked()
        {
            await this.InvokerContext.OperationCompletionSource.WaitAsync().WithTimeout().ConfigureAwait(false);
        }

        [Then("instrumentation should start a request named '(.*)'")]
        public void ThenInstrumentationShouldStartARequestNamed(string requestName)
        {
            OperationDetail operation = this.GetSingleOperationDetail();
            Assert.AreEqual(requestName, operation.Name);
        }

        [Then("the request should have been finished")]
        public void ThenTheRequestShouldHaveBeenFinished()
        {
            OperationDetail operation = this.GetSingleOperationDetail();
            Assert.IsTrue(operation.IsDisposed);
        }
    }
}