// <copyright file="OperationInstrumentationSteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System.Threading.Tasks;
    using Menes.Specs.Fakes;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class OperationInstrumentationSteps : InstrumentationStepsBase
    {
        public OperationInstrumentationSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
        }

        [When("the operation completes")]
        public async Task WhenTheOperationCompletes()
        {
            this.InvokerContext.OperationCompletionSource.Complete();
            await this.InvokerContext.OperationInvocationTask!.ConfigureAwait(false);
        }

        [Then("instrumentation should have already reported the request by the time the operation implementation is invoked")]
        public void ThenInstrumentationShouldHaveAlreadyReportedTheRequestByTheTimeTheOperationImplementationIsInvoked()
        {
            Assert.AreEqual(1, this.InvokerContext.ReportedOperationCountWhenOperationBodyInvoked);
        }

        [Then("the operation instrumentation should report an OpenAPI operation id of '(.*)'")]
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
    }
}