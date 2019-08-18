// <copyright file="ExemptOperationIdsAccessPolicy.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.AccessControlPolicies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    /// <summary>
    /// Access control policy that allows operations based on the operation id.
    /// </summary>
    /// <typeparam name="TTenant">The type of the tenant.</typeparam>
    /// <remarks>
    /// <para>
    /// When using an access control policy, you may want to exempt certain Open API operations
    /// from that policy. This might be because they need to implement their own access control
    /// mechanisms in a way that requires access to the body of the request. Or there may be
    /// special cases in which a particular operation is open to all authenticated callers, and
    /// we'd like to avoid the overhead of evaluating policies when we know in advance that the
    /// outcome will always be to allow the caller in. This policy enables exemption based on
    /// the Open API service operation id.
    /// </para>
    /// <para>
    /// This policy evaluates quickly because it does not need to access any external policy.
    /// Therefore consider using the <see cref="ShortCircuitingAccessControlPolicyAdapter{TTenant}"/> to
    /// avoid evaluating other policies in the case where this allows an operation in.
    /// </para>
    /// </remarks>
    public class ExemptOperationIdsAccessPolicy<TTenant> : IOpenApiAccessControlPolicy<TTenant>
    {
        private readonly string[] exemptOperationIds;

        /// <summary>
        /// Create an <see cref="ExemptOperationIdsAccessPolicy{TTenant}"/>.
        /// </summary>
        /// <param name="exemptOperationIds">
        /// The Open API operation ids that should always be granted access.
        /// </param>
        public ExemptOperationIdsAccessPolicy(
            IEnumerable<string> exemptOperationIds)
        {
            this.exemptOperationIds = exemptOperationIds.ToArray();
        }

        /// <inheritdoc/>
        public Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> ShouldAllowAsync(
            ClaimsPrincipal principal,
            TTenant tenant,
            params AccessCheckOperationDescriptor[] requests)
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = requests.ToDictionary(request => request, request => this.ShouldAllow(request.OperationId));

            return Task.FromResult(result);
        }

        private AccessControlPolicyResult ShouldAllow(string operationId)
        {
            bool isExemptOperation = this.exemptOperationIds.Contains(operationId);
            return new AccessControlPolicyResult(isExemptOperation
                ? AccessControlPolicyResultType.Allowed
                : AccessControlPolicyResultType.NotAllowed);
        }
    }
}
