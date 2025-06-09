// <copyright file="AccessControlPolicySteps.cs" company="Endjin Limited">
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
    using Menes.Internal;

    using NSubstitute;

    using NUnit.Framework;

    using Reqnroll;

    /// <summary>
    /// Steps for the AccessControlPolicy feature specs.
    /// </summary>
    [Binding]
    public class AccessControlPolicySteps
    {
        private List<(IOpenApiAccessControlPolicy Policy, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> Completion)>? policies;
        private ClaimsPrincipal? claimsPrincipal;
        private string? tenantId;
        private Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>? checkResultTask;

        [Given("I have configured (.*) access control policies")]
        [Given("I have configured (.*) access control policy")]
        public void GivenIHaveConfiguredAccessControlPolicies(int numberOfPolicies)
        {
            this.policies = Enumerable
                .Range(0, numberOfPolicies)
                .Select(_ =>
                {
                    IOpenApiAccessControlPolicy mock = Substitute.For<IOpenApiAccessControlPolicy>();
                    CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> args = new();
                    mock.ShouldAllowAsync(Arg.Any<IOpenApiContext>(), Arg.Any<AccessCheckOperationDescriptor[]>())
                        .Returns(callInfo => args.GetTask(new ShouldAllowArgs(callInfo.ArgAt<AccessCheckOperationDescriptor[]>(1), callInfo.ArgAt<IOpenApiContext>(0))));

                    return (mock, args);
                })
                .ToList();
        }

        [When("I check access for a '(.*)' request for '(.*)' with an operationId of '(.*)'")]
        public void WhenICheckAccessForARequestForWithAnOperationIdOf(string method, string path, string operationId)
        {
            OpenApiAccessChecker checker = new(this.policies!.Select(m => m.Policy));

            this.claimsPrincipal = new ClaimsPrincipal();
            this.tenantId = Guid.NewGuid().ToString();
            IOpenApiContext openApiContext = Substitute.For<IOpenApiContext>();
            openApiContext.CurrentPrincipal = this.claimsPrincipal;
            openApiContext.CurrentTenantId = this.tenantId;
            this.checkResultTask = checker.CheckAccessPoliciesAsync(openApiContext, new AccessCheckOperationDescriptor(path, operationId, method));
        }

        [When("policy (.*) blocks access without explanation")]
        public void WhenPolicyBlocksAccessWithoutExplanation(int policyIndex)
        {
            Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = new();
            CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion = this.policies![policyIndex].Completion;
            result.Add(completion.Arguments[0].Requests[0], new AccessControlPolicyResult(AccessControlPolicyResultType.NotAllowed));
            completion.SupplyResult(result);
        }

        [When("policy (.*) blocks access with explanation '(.*)'")]
        public void WhenPolicyBlocksAccessWithExplanation(int policyIndex, string explanation)
        {
            Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = new();
            CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion = this.policies![policyIndex].Completion;
            result.Add(completion.Arguments[0].Requests[0], new AccessControlPolicyResult(AccessControlPolicyResultType.NotAllowed, explanation));
            completion.SupplyResult(result);
        }

        [When("policy (.*) allows access")]
        public void WhenPolicyAllowsAccess(int policyIndex)
        {
            Dictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = new();
            CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion = this.policies![policyIndex].Completion;
            result.Add(completion.Arguments[0].Requests[0], new AccessControlPolicyResult(AccessControlPolicyResultType.Allowed));
            completion.SupplyResult(result);
        }

        [Then("each policy should receive a path of '(.*)'")]
        public void ThenEachPolicyShouldReceiveAPathOf(string path)
        {
            foreach ((IOpenApiAccessControlPolicy _, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.policies!)
            {
                Assert.AreEqual(path, completion.Arguments[0].Requests[0].Path);
            }
        }

        [Then("each policy should receive an operationId of '(.*)'")]
        public void ThenEachPolicyShouldReceiveAnOperationIdOf(string operationId)
        {
            foreach ((IOpenApiAccessControlPolicy _, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.policies!)
            {
                Assert.AreEqual(operationId, completion.Arguments[0].Requests[0].OperationId);
            }
        }

        [Then("each policy should receive an HttpMethod of '(.*)'")]
        public void ThenEachPolicyShouldReceiveAnHttpMethodOf(string method)
        {
            foreach ((IOpenApiAccessControlPolicy _, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.policies!)
            {
                Assert.AreEqual(method, completion.Arguments[0].Requests[0].Method);
            }
        }

        [Then("each policy should receive the ClaimsPrincipal attached to the context")]
        public void ThenEachPolicyShouldReceiveTheClaimsPrincipalAttachedToTheContext()
        {
            foreach ((IOpenApiAccessControlPolicy _, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.policies!)
            {
                Assert.AreSame(this.claimsPrincipal, completion.Arguments[0].Context.CurrentPrincipal);
            }
        }

        [Then("each policy should receive the Tenant attached to the context")]
        public void ThenEachPolicyShouldReceiveTheTenantAttachedToTheContext()
        {
            foreach ((IOpenApiAccessControlPolicy _, CompletionSourceWithArgs<ShouldAllowArgs, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> completion) in this.policies!)
            {
                Assert.AreSame(this.tenantId, completion.Arguments[0].Context.CurrentTenantId);
            }
        }

        [Then("the result should block the operation")]
        public async Task ThenTheResultShouldBlockTheOperation()
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = await this.checkResultTask.WithTimeout().ConfigureAwait(false);
            Assert.AreEqual(AccessControlPolicyResultType.NotAllowed, result.Values.First().ResultType);
        }

        [Then("the result should have no explanation")]
        public async Task ThenTheResultShouldHaveNoExplanation()
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = await this.checkResultTask.WithTimeout().ConfigureAwait(false);
            Assert.IsNull(result.Values.First().Explanation);
        }

        [Then("the result should have the explanation '(.*)'")]
        public async Task ThenTheResultShouldHaveTheExplanation(string expectedExplanation)
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = await this.checkResultTask.WithTimeout().ConfigureAwait(false);
            Assert.AreEqual(expectedExplanation, result.Values.First().Explanation);
        }

        [Then("the result should allow the operation")]
        public async Task ThenTheResultShouldAllowTheOperation()
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = await this.checkResultTask.WithTimeout().ConfigureAwait(false);
            Assert.IsTrue(result.Values.First().Allow);
        }

        private class ShouldAllowArgs
        {
            public ShouldAllowArgs(AccessCheckOperationDescriptor[] requests, IOpenApiContext context)
            {
                this.Requests = requests;
                this.Context = context;
            }

            public AccessCheckOperationDescriptor[] Requests { get; }

            public IOpenApiContext Context { get; }
        }
    }
}