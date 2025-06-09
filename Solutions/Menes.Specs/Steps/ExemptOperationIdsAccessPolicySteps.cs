// <copyright file="ExemptOperationIdsAccessPolicySteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using Idg.AsyncTest.TaskExtensions;
    using Menes;
    using Menes.AccessControlPolicies;
    using NUnit.Framework;
    using Reqnroll;

    [Binding]
    public class ExemptOperationIdsAccessPolicySteps
    {
        private ExemptOperationIdsAccessPolicy? policy;
        private IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>? result;

        [Given("I have a policy that exempts ids '(.*)' and '(.*)'")]
        public void GivenIHaveAPolicyThatExemptsIdsAnd(string opId1, string opId2)
        {
            this.policy = new ExemptOperationIdsAccessPolicy(new[] { opId1, opId2 });
        }

        [When("I evaluate the exemption policy with an operation id of '(.*)'")]
        public async System.Threading.Tasks.Task WhenIEvaluateTheExemptionPolicyWithAnOperationIdOfAsync(string operationId)
        {
            this.result = await this.policy!.ShouldAllowAsync(
                new SimpleOpenApiContext {  CurrentPrincipal = new ClaimsPrincipal(), CurrentTenantId = Guid.NewGuid().ToString() },
                new AccessCheckOperationDescriptor("/a/path", operationId, "GET"))
                .WithTimeout()
                .ConfigureAwait(false);
        }

        [Then("the policy should allow the operation")]
        public void ThenThePolicyShouldAllowTheOperation()
        {
            Assert.IsTrue(this.result!.Values.First().Allow);
        }

        [Then("the policy should deny the operation")]
        public void ThenThePolicyShouldDenyTheOperation()
        {
            Assert.IsFalse(this.result!.Values.First().Allow);
        }
    }
}