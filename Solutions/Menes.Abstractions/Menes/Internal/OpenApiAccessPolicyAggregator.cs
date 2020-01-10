// <copyright file="OpenApiAccessPolicyAggregator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Evaluates multiple <see cref="IOpenApiAccessControlPolicy"/> implementations, and
    /// aggregates the results.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enables the <see cref="OpenApiAccessChecker"/> and
    /// <see cref="AccessControlPolicies.ShortCircuitingAccessControlPolicyAdapter"/> to share the same aggregation logic.
    /// </para>
    /// </remarks>
    internal static class OpenApiAccessPolicyAggregator
    {
        /// <summary>
        /// Evaluates multiple policies concurrently, and aggregates the results, returning an Allow
        /// result if all policies says Allow, and otherwise returning a Deny result where the
        /// Explanation is formed by appending any Explanations produced by the individual policies.
        /// </summary>
        /// <param name="accessControlPolicies">
        /// The policies to evaluate and aggregate.
        /// </param>
        /// <param name="requests">
        /// The list of operation descriptors to check.
        /// </param>
        /// <returns>
        /// A task that produces an <see cref="AccessControlPolicyResultType"/> indicating whether
        /// access is allowed, and if it is not, an optional textual explanation (which may be null).
        /// </returns>
        internal static async Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> EvaluteAccessPoliciesConcurrentlyAsync(
            IEnumerable<IOpenApiAccessControlPolicy> accessControlPolicies,
            params AccessCheckOperationDescriptor[] requests)
        {
            // Evaluate the set of requests with all policies simultaneously.
            IEnumerable<Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>> policyEvaluationTasks =
                accessControlPolicies.Select(
                    policy => policy.ShouldAllowAsync(
                        requests));

            // Wait for all policy evaluation to complete.
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>[] results = await Task.WhenAll(policyEvaluationTasks).ConfigureAwait(false);

            // "Roll up" the results. The results of the policy aggregation is a list of dictionaries, each dictionary
            // containing an entry for each of the requests supplied in the parameters. To build our result dictionary
            // we need to aggregate the entry for each request from each dictionary. To do this we use the
            // CombineResultTypes method for each result type, and concatenate any result explanations together.
            return requests.ToDictionary(
                request => request,
                request =>
                {
                    (AccessControlPolicyResultType resultType, string explanation) = results.Aggregate(
                    (resultType: AccessControlPolicyResultType.Allowed, explanation: default(string)),
                    (acc, result) =>
                    (CombineResultTypes(acc.resultType, result[request].ResultType),
                     string.IsNullOrWhiteSpace(acc.explanation)
                        ? result[request].Explanation
                        : string.IsNullOrWhiteSpace(result[request].Explanation) ? acc.explanation : acc.explanation + "; " + result[request].Explanation));

                    return new AccessControlPolicyResult(resultType, explanation);
                });
        }

        private static AccessControlPolicyResultType CombineResultTypes(
            AccessControlPolicyResultType t1,
            AccessControlPolicyResultType t2)
        {
            if (t1 == AccessControlPolicyResultType.NotAuthenticated ||
                t2 == AccessControlPolicyResultType.NotAuthenticated)
            {
                return AccessControlPolicyResultType.NotAuthenticated;
            }

            if (t1 == AccessControlPolicyResultType.NotAllowed ||
                t2 == AccessControlPolicyResultType.NotAllowed)
            {
                return AccessControlPolicyResultType.NotAllowed;
            }

            return AccessControlPolicyResultType.Allowed;
        }
    }
}
