// <copyright file="ExceptionInstrumentationSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using Idg.AsyncTest.TaskExtensions;
    using Menes.Specs.Fakes;
    using NUnit.Framework;
    using Reqnroll;

    [Binding]
    public class ExceptionInstrumentationSteps : InstrumentationStepsBase
    {
        private Exception? operationException;

        public ExceptionInstrumentationSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
        }

        [When("the operation throws an exception")]
        public async System.Threading.Tasks.Task WhenTheOperationThrowsAnExceptionAsync()
        {
            this.operationException = new Exception("eek!");
            this.InvokerContext.OperationCompletionSource.SupplyException(this.operationException);
            await this.InvokerContext.OperationInvocationTask.WhenCompleteIgnoringErrors().ConfigureAwait(false);
        }

        [Then("the instrumentation should report the exception thrown by the operation")]
        public void ThenTheInstrumentationShouldReportTheExceptionThrownByTheOperation()
        {
            ExceptionDetail exception = this.GetSingleExceptionDetail();
            Assert.AreSame(this.operationException, exception.Exception);
        }

        [Then("the exception instrumentation should report an OpenAPI operation id of '(.*)'")]
        public void ThenTheExceptionInstrumentationShouldReportAnOpenAPIOperationIdOf(string operationId)
        {
            ExceptionDetail exception = this.GetSingleExceptionDetail();
            Assert.AreEqual(operationId, exception.AdditionalDetail?.Properties["Menes.OperationId"]);
        }

        [Then("the request should not have been finished at the point when the exception was reported")]
        public void ThenTheRequestShouldNotHaveBeenFinishedAtThePointWhenTheExceptionWasReported()
        {
            ExceptionDetail exception = this.GetSingleExceptionDetail();
            OperationDetail operation = this.GetSingleOperationDetail();
            Assert.AreSame(operation, exception.OperationInProgressAtTime);
        }

        protected ExceptionDetail GetSingleExceptionDetail()
        {
            Assert.AreEqual(1, this.InstrumentationProvider.Exceptions.Count, "Exceptions.Count");
            return this.InstrumentationProvider.Exceptions[0];
        }
    }
}