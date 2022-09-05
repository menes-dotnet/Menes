// <copyright file="TestOperationBindings.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Bindings
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using Corvus.Testing.SpecFlow;
    using Menes.Internal;
    using Menes.Specs.Fakes;
    using Menes.Specs.Steps.TestClasses;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Provides tests with the ability to invoke simple test OpenApi operations by specifying the
    /// <c>@useZeroArgumentTestOperations</c> tag. Must be used in conjunction with <c>@perScenarioContainer</c>.
    /// Also defines a test operation used by some tests.
    /// </summary>
    /// <remarks>
    /// <para>
    /// When the <c>@useZeroArgumentTestOperations</c> tag is specified, the scenario binding in this class configures
    /// the <see cref="IOpenApiParameterBuilder{TRequest}"/> mock to return an empty dictionary regardless of its
    /// inputs. This is necessary to enable the <see cref="OpenApiOperationInvoker{TRequest, TResponse}"/> to be able
    /// to invoke the operation. (The default behaviour if this particular mock is unconfigured is that it will return
    /// null, causing the attempt to invoke the operation to fail. In normal non-test operation, the real builder works
    /// out what to do based on the contents of the OpenApi spec.)
    /// </para>
    /// </remarks>
    [Binding]
    public class TestOperationBindings : IOpenApiService
    {
        private static readonly MethodInfo OperationMethodInfo = typeof(TestOperationBindings).GetMethod(nameof(TestOperation), BindingFlags.NonPublic | BindingFlags.Instance) ?? throw new InvalidOperationException($"Couldn't load method info for {nameof(TestOperation)}");
        private readonly ScenarioContext scenarioContext;

        public TestOperationBindings(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        private protected OperationInvokerTestContext InvokerContext
            => ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<OperationInvokerTestContext>();

        private protected FakeInstrumentationProvider InstrumentationProvider
            => ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<FakeInstrumentationProvider>();

        [BeforeScenario("@useZeroArgumentTestOperations", Order = ContainerBeforeFeatureOrder.ServiceProviderAvailable)]
        public static void InitializeMocksToEnableInvocation(ScenarioContext scenarioContext)
        {
            OperationInvokerTestContext invokerContext = ContainerBindings.GetServiceProvider(scenarioContext).GetRequiredService<OperationInvokerTestContext>();

            invokerContext.ParameterBuilder
                .Setup(pb => pb.BuildParametersAsync(It.IsAny<object>(), It.IsAny<OpenApiOperationPathTemplate>()))
                .ReturnsAsync(new Dictionary<string, object>());
        }

        [Given("the operation locator maps the operation id '(.*)' to an operation named '(.*)'")]
        public void GivenTheOperationLocatorMapsTheOperationIdToAnOperationNamed(string operationId, string operationName)
        {
            Assert.AreEqual(nameof(this.TestOperation), operationName, "Menes uses the method name as the operation name, so this test can only work if the operation specified in the spec matches the name of the operation method supplied");

            var operation = new OpenApiServiceOperation(
                this,
                OperationMethodInfo,
                new Mock<IOpenApiConfiguration>().Object);
            this.InvokerContext.OperationLocator
                .Setup(m => m.TryGetOperation(operationId, out operation))
                .Returns(true);
        }

        private Task TestOperation()
        {
            this.InvokerContext.ReportedOperationCountWhenOperationBodyInvoked = this.InstrumentationProvider.Operations.Count;
            return this.InvokerContext.OperationCompletionSource.GetTask();
        }
    }
}