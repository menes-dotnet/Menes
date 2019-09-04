// <copyright file="ShortCircuitingAccessControlPolicyAdapter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.AccessControlPolicies
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Menes.Internal;

    /// <summary>
    /// An <see cref="IOpenApiAccessControlPolicy"/> that wraps set of policies, enabling the
    /// first to avoid the evalution of the rest.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This 'short-circuits' evaluation in the same sense as the C# <c>||</c> operator: if the
    /// first operand of that operator evaluates to true, the second one does not get evaluated.
    /// This is useful if the second operand has side effects or is non-trivial to compute.
    /// </para>
    /// <para>
    /// In a similar way, this adapter enables us to avoid evaluation of the other policies in the
    /// case where the first policy would allow the request through. This has no bearing on the
    /// final outcome: the <see cref="OpenApiAccessChecker"/> implements a logical and, in that it
    /// only requires a single policy to say Deny to block the request. But it works more like the
    /// C# <c>|</c> operator in that it evaluates all the policies. (It does that so that it can
    /// evaluate them in parallel.) In cases where one policy is significantly cheaper to evaluate
    /// (e.g., one just looks for a known operation ID, while the other sends a request to the
    /// Claims service, or looks data up in a store service) short circuiting is useful because it
    /// avoids wastefully evaluating a slow-running policy that is doomed to have no effect on the
    /// outcome.
    /// </para>
    /// </remarks>
    public class ShortCircuitingAccessControlPolicyAdapter : IOpenApiAccessControlPolicy
    {
        private readonly IOpenApiAccessControlPolicy firstPolicy;
        private readonly IEnumerable<IOpenApiAccessControlPolicy> otherPolicies;

        /// <summary>
        /// Create a <see cref="ShortCircuitingAccessControlPolicyAdapter"/>.
        /// </summary>
        /// <param name="firstPolicy">
        /// The policy that will be evaluated first. If this returns Allow, we will return an
        /// Allow result immediately without evaluting the other policies. Note that if this
        /// returns Deny, we will ignore any Explanation, because we will go on to evalute the
        /// other policies as if the first policy were not present.
        /// </param>
        /// <param name="otherPolicies">
        /// The policies that will be evaluated only if the first policy returns Deny.
        /// </param>
        public ShortCircuitingAccessControlPolicyAdapter(
            IOpenApiAccessControlPolicy firstPolicy,
            IEnumerable<IOpenApiAccessControlPolicy> otherPolicies)
        {
            this.firstPolicy = firstPolicy;
            this.otherPolicies = otherPolicies;
        }

        /// <inheritdoc/>
        public async Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> ShouldAllowAsync(
            IOpenApiContext context,
            params AccessCheckOperationDescriptor[] requests)
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> firstPolicyResults = await this.firstPolicy.ShouldAllowAsync(context, requests).ConfigureAwait(false);

            // Get the "denys" from the first policy results so we can feed them into the second.
            AccessCheckOperationDescriptor[] deniedByFirstPolicy = firstPolicyResults.Where(x => !x.Value.Allow).Select(x => x.Key).ToArray();

            // If there weren't any denies from the first policy, then we can return immediately as
            // there's no further work to do.
            if (deniedByFirstPolicy.Length == 0)
            {
                return firstPolicyResults;
            }

            // Evaluate the remaining requests.
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> otherPolicyResults = await OpenApiAccessPolicyAggregator.EvaluteAccessPoliciesConcurrentlyAsync(
                this.otherPolicies,
                context,
                deniedByFirstPolicy).ConfigureAwait(false);

            // Merge the result from the other policies into that from the first.
            otherPolicyResults.ForEach(x => firstPolicyResults[x.Key] = x.Value);
            return firstPolicyResults;
        }
    }
}
