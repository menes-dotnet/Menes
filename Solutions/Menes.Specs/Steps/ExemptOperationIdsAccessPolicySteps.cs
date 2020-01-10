﻿// <copyright file="ExemptOperationIdsAccessPolicySteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CS1591 // Elements should be documented

namespace Menes.Specs.Steps
{
    using System.Collections.Generic;
    using System.Linq;
    using Idg.AsyncTest.TaskExtensions;
    using Menes;
    using Menes.AccessControlPolicies;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class ExemptOperationIdsAccessPolicySteps
    {
        private ExemptOperationIdsAccessPolicy policy;
        private IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result;

        [Given("I have a policy that exempts ids '(.*)' and '(.*)'")]
        public void GivenIHaveAPolicyThatExemptsIdsAnd(string opId1, string opId2)
        {
            this.policy = new ExemptOperationIdsAccessPolicy(new[] { opId1, opId2 });
        }

        [When("I evaluate the exemption policy with an operation id of '(.*)'")]
        public async System.Threading.Tasks.Task WhenIEvaluateTheExemptionPolicyWithAnOperationIdOfAsync(string operationId)
        {
            this.result = await this.policy.ShouldAllowAsync(
                new AccessCheckOperationDescriptor("/a/path", operationId, "GET"))
                .WithTimeout()
                .ConfigureAwait(false);
        }

        [Then("the policy should allow the operation")]
        public void ThenThePolicyShouldAllowTheOperation()
        {
            Assert.IsTrue(this.result.Values.First().Allow);
        }

        [Then("the policy should deny the operation")]
        public void ThenThePolicyShouldDenyTheOperation()
        {
            Assert.IsFalse(this.result.Values.First().Allow);
        }
    }
}
