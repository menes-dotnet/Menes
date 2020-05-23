// <copyright file="ShortCircuitingAccessControlPolicyAdapterSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Idg.AsyncTest;
    using Idg.AsyncTest.TaskExtensions;
    using Menes;
    using Menes.AccessControlPolicies;
    using Moq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class ShortCircuitingAccessControlPolicyAdapterSteps
    {
        private Mock<IOpenApiAccessControlPolicy>? firstPolicy;
        private CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>? firstPolicyCompletion;
        private List<(Mock<IOpenApiAccessControlPolicy> policy, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion)>? otherPolicies;
        private ClaimsPrincipal? claimsPrincipal;
        private string? tenantId;
        private Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>? checkResultTask;

        [Given("I have configured (.*) other access policies")]
        public void GivenIHaveConfiguredOtherAccessPolicies(int numberOfPolicies)
        {
            this.firstPolicy = new Mock<IOpenApiAccessControlPolicy>();
            this.firstPolicyCompletion = new CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>();
            this.firstPolicy
                .Setup(m => m.ShouldAllowAsync(It.IsAny<IOpenApiContext>(), It.IsAny<AccessCheckOperationDescriptor[]>()))
                .Returns((IOpenApiContext context, AccessCheckOperationDescriptor[] requests)
                => this.firstPolicyCompletion.GetTask(new ShouldAllowArgs(requests, context)));

            this.otherPolicies = Enumerable
                .Range(0, numberOfPolicies)
                .Select(_ =>
                {
                    var mock = new Mock<IOpenApiAccessControlPolicy>();
                    var args = new CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>();
                    mock.Setup(m => m.ShouldAllowAsync(It.IsAny<IOpenApiContext>(), It.IsAny<AccessCheckOperationDescriptor[]>()))
                        .Returns((IOpenApiContext context, AccessCheckOperationDescriptor[] requests)
                            => args.GetTask(new ShouldAllowArgs(requests, context)));

                    return (mock, args);
                })
                .ToList();
        }

        [When("I invoke the adapter for a '(.*)' request for '(.*)' with an operationId of '(.*)'")]
        public void WhenIInvokeTheAdapterForARequestForWithAnOperationIdOf(
            string httpMethod,
            string path,
            string operationId)
        {
            var adapter = new ShortCircuitingAccessControlPolicyAdapter(
                this.firstPolicy!.Object,
                this.otherPolicies.Select(op => op.policy.Object));

            this.claimsPrincipal = new ClaimsPrincipal();
            this.tenantId = Guid.NewGuid().ToString();
            this.checkResultTask = adapter.ShouldAllowAsync(
                new SimpleOpenApiContext { CurrentPrincipal = this.claimsPrincipal, CurrentTenantId = this.tenantId },
                new AccessCheckOperationDescriptor(path, operationId, httpMethod));
        }

        [When("the first policy allows access")]
        public void WhenTheFirstPolicyAllowsAccess()
        {
            var result = new Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>();
            CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion = this.firstPolicyCompletion!;
            result.Add(completion.Arguments[0].Requests[0], new AccessControlPolicyResult(AccessControlPolicyResultType.Allowed));
            completion.SupplyResult(result);
        }

        [When("the first policy denies access with result '(.*)'")]
        public void WhenTheFirstPolicyDeniesAccessWithResult(AccessControlPolicyResultType resultType)
        {
            var result = new Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>();
            CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion = this.firstPolicyCompletion!;
            result.Add(completion.Arguments[0].Requests[0], new AccessControlPolicyResult(resultType));
            completion.SupplyResult(result);
        }

        [When("the other policy (.*) allows access")]
        public void WhenTheOtherPolicyAllowsAccess(int policyIndex)
        {
            var result = new Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>();
            CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion = this.otherPolicies![policyIndex].completion;
            result.Add(completion.Arguments[0].Requests[0], new AccessControlPolicyResult(AccessControlPolicyResultType.Allowed));
            completion.SupplyResult(result);
        }

        [When("the other policy (.*) denies access")]
        public void WhenTheOtherPolicyDeniesAccess(int policyIndex)
        {
            var result = new Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>();
            CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion = this.otherPolicies![policyIndex].completion;
            result.Add(completion.Arguments[0].Requests[0], new AccessControlPolicyResult(AccessControlPolicyResultType.NotAllowed));
            completion.SupplyResult(result);
        }

        [When("the other policy (.*) denies access with explanation '(.*)'")]
        public void WhenTheOtherPolicyDeniesAccessWithExplanation(int policyIndex, string explanation)
        {
            var result = new Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>();
            CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion = this.otherPolicies![policyIndex].completion;
            result.Add(completion.Arguments[0].Requests[0], new AccessControlPolicyResult(AccessControlPolicyResultType.NotAllowed, explanation));
            completion.SupplyResult(result);
        }

        [Then("the first policy should receive a path of '(.*)'")]
        public void ThenTheFirstPolicyShouldReceiveAPathOf(string path)
        {
            Assert.AreEqual(path, this.firstPolicyCompletion!.Arguments[0].Requests[0].Path);
        }

        [Then("the first policy should receive an operationId of '(.*)'")]
        public void ThenTheFirstPolicyShouldReceiveAnOperationIdOf(string operationId)
        {
            Assert.AreEqual(operationId, this.firstPolicyCompletion!.Arguments[0].Requests[0].OperationId);
        }

        [Then("the first policy should receive an HttpMethod of '(.*)'")]
        public void ThenTheFirstPolicyShouldReceiveAnHttpMethodOf(string method)
        {
            Assert.AreEqual(method, this.firstPolicyCompletion!.Arguments[0].Requests[0].Method);
        }

        [Then("the first policy should receive the ClaimsPrincipal")]
        public void ThenTheFirstPolicyShouldReceiveTheClaimsPrincipal()
        {
            Assert.AreSame(this.claimsPrincipal, this.firstPolicyCompletion!.Arguments[0].Context.CurrentPrincipal);
        }

        [Then("the first policy should receive the Tenant")]
        public void ThenTheFirstPolicyShouldReceiveTheTenant()
        {
            Assert.AreSame(this.tenantId, this.firstPolicyCompletion!.Arguments[0].Context.CurrentTenantId);
        }

        [Then("the adapter result should allow the operation")]
        public async Task ThenTheAdapterResultShouldAllowTheOperationAsync()
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = await this.checkResultTask.WithTimeout(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
            Assert.IsTrue(result.Values.First().Allow);
        }

        [Then("the adapter result should have no explanation")]
        public async Task ThenTheAdapterResultShouldHaveNoExplanationAsync()
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = await this.checkResultTask.WithTimeout().ConfigureAwait(false);
            Assert.IsNull(result.Values.First().Explanation);
        }

        [Then("none of the other policies should have been invoked")]
        public async Task ThenNoneOfTheOtherPoliciesShouldHaveBeenInvokedAsync()
        {
            await this.checkResultTask.WithTimeout().ConfigureAwait(false);
            foreach ((_, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.otherPolicies!)
            {
                Assert.IsEmpty(completion.Arguments);
            }
        }

        [Then("the other policies should receive a path of '(.*)'")]
        public void ThenTheOtherPoliciesShouldReceiveAPathOf(string path)
        {
            foreach ((_, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.otherPolicies!)
            {
                Assert.AreEqual(path, completion.Arguments[0].Requests[0].Path);
            }
        }

        [Then("the other policies should receive an operationId of '(.*)'")]
        public void ThenTheOtherPoliciesShouldReceiveAnOperationIdOf(string operationId)
        {
            foreach ((_, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.otherPolicies!)
            {
                Assert.AreEqual(operationId, completion.Arguments[0].Requests[0].OperationId);
            }
        }

        [Then("the other policies should receive an HttpMethod of '(.*)'")]
        public void ThenTheOtherPoliciesShouldReceiveAnHttpMethodOf(string method)
        {
            foreach ((_, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.otherPolicies!)
            {
                Assert.AreEqual(method, completion.Arguments[0].Requests[0].Method);
            }
        }

        [Then("the other policies should receive the ClaimsPrincipal")]
        public void ThenTheOtherPoliciesShouldReceiveTheClaimsPrincipal()
        {
            foreach ((_, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.otherPolicies!)
            {
                Assert.AreSame(this.claimsPrincipal, completion.Arguments[0].Context.CurrentPrincipal);
            }
        }

        [Then("the other policies should receive the Tenant")]
        public void ThenTheOtherPoliciesShouldReceiveTheTenant()
        {
            foreach ((_, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.otherPolicies!)
            {
                Assert.AreSame(this.tenantId, completion.Arguments[0].Context.CurrentTenantId);
            }
        }

        [Then("the adapter result should block the operation")]
        public async Task ThenTheAdapterResultShouldBlockTheOperationAsync()
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = await this.checkResultTask.WithTimeout().ConfigureAwait(false);
            Assert.IsFalse(result.Values.First().Allow);
        }

        [Then("the adapter result should have an explanation of '(.*)'")]
        public async Task ThenTheAdapterResultShouldHaveAnExplanationOfAsync(string explanation)
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = await this.checkResultTask.WithTimeout().ConfigureAwait(false);
            Assert.AreEqual(explanation, result.Values.First().Explanation);
        }

        [When("the first policy denies access")]
        public void WhenTheFirstPolicyDeniesAccess()
        {
            var result = new Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>();
            CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion = this.firstPolicyCompletion!;
            result.Add(completion.Arguments[0].Requests[0], new AccessControlPolicyResult(AccessControlPolicyResultType.NotAllowed));
            completion.SupplyResult(result);
        }

        [Then("the adapter result type should be '(.*)'")]
        public async Task ThenTheAdapterResultTypeShouldBeAsync(string resultTypeString)
        {
            AccessControlPolicyResultType resultType = Enum.Parse<AccessControlPolicyResultType>(resultTypeString);
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = await this.checkResultTask.WithTimeout().ConfigureAwait(false);
            Assert.AreEqual(resultType, result.Values.First().ResultType);
        }

        [When("the other policy (.*) denies access with result '(.*)' and explanation '(.*)'")]
        public void WhenTheOtherPolicyDeniesAccessWithResultAndExplanation(int policyIndex, string resultTypeString, string explanation)
        {
            AccessControlPolicyResultType resultType = Enum.Parse<AccessControlPolicyResultType>(resultTypeString);

            var result = new Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>();
            CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion = this.otherPolicies![policyIndex].completion;
            result.Add(completion.Arguments[0].Requests[0], new AccessControlPolicyResult(resultType, explanation));
            completion.SupplyResult(result);
        }

        private class ShouldAllowArgs
        {
            public ShouldAllowArgs(
                AccessCheckOperationDescriptor[] requests,
                IOpenApiContext context)
            {
                this.Requests = requests;
                this.Context = context;
            }

            public AccessCheckOperationDescriptor[] Requests { get; }

            public IOpenApiContext Context { get; }
        }
    }
}
