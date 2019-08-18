// <copyright file="OpenApiAccessChecker.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Applies access control to an incoming request by combining the results of all
    /// registered <see cref="IOpenApiAccessControlPolicy{TTenant}"/>. implementations.
    /// </summary>
    /// <typeparam name="TTenant">The type of the tenant.</typeparam>
    public class OpenApiAccessChecker<TTenant> : IOpenApiAccessChecker<TTenant>
    {
        private readonly IEnumerable<IOpenApiAccessControlPolicy<TTenant>> accessControlPolicies;

        /// <summary>
        /// Creates an <see cref="OpenApiAccessChecker{TTenant}"/>.
        /// </summary>
        /// <param name="accessControlPolicies">
        /// The access control policies to aggregate the results for.
        /// </param>
        public OpenApiAccessChecker(
            IEnumerable<IOpenApiAccessControlPolicy<TTenant>> accessControlPolicies)
        {
            this.accessControlPolicies = accessControlPolicies;
        }

        /// <inheritdoc />
        public Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> CheckAccessPoliciesAsync(
            IOpenApiContext<TTenant> context,
            params AccessCheckOperationDescriptor[] requests)
        {
            return OpenApiAccessPolicyAggregator.EvaluteAccessPoliciesConcurrentlyAsync(
                this.accessControlPolicies, context.CurrentPrincipal, context.CurrentTenant, requests);
        }
    }
}
