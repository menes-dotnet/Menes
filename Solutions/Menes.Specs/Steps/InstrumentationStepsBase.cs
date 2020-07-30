﻿namespace Menes.Specs.Steps
{
    using Corvus.Testing.SpecFlow;
    using Menes.Internal;
    using Menes.Specs.Fakes;
    using Menes.Specs.Steps.TestClasses;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    public abstract class InstrumentationStepsBase
    {
        protected InstrumentationStepsBase(ScenarioContext scenarioContext)
        {
            this.ScenarioContext = scenarioContext;
        }

        protected ScenarioContext ScenarioContext { get; }

        protected OpenApiOperationInvoker<object, object> Invoker
            => ContainerBindings.GetServiceProvider(this.ScenarioContext).GetRequiredService<OpenApiOperationInvoker<object, object>>();

        private protected OperationInvokerTestContext InvokerContext
            => ContainerBindings.GetServiceProvider(this.ScenarioContext).GetRequiredService<OperationInvokerTestContext>();

        private protected FakeInstrumentationProvider InstrumentationProvider
            => ContainerBindings.GetServiceProvider(this.ScenarioContext).GetRequiredService<FakeInstrumentationProvider>();

        protected OperationDetail GetSingleOperationDetail()
        {
            Assert.AreEqual(1, this.InstrumentationProvider.Operations.Count, "Operations.Count");
            return this.InstrumentationProvider.Operations[0];
        }
    }
}