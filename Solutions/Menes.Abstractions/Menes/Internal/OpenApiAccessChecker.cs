// <copyright file="OpenApiAccessChecker.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Applies access control to an incoming request by combining the results of all
    /// registered <see cref="IOpenApiAccessControlPolicy"/>. implementations.
    /// </summary>
    public class OpenApiAccessChecker : IOpenApiAccessChecker
    {
        private readonly IEnumerable<IOpenApiAccessControlPolicy> accessControlPolicies;

        /// <summary>
        /// Creates an <see cref="OpenApiAccessChecker"/>.
        /// </summary>
        /// <param name="accessControlPolicies">
        /// The access control policies to aggregate the results for.
        /// </param>
        public OpenApiAccessChecker(
            IEnumerable<IOpenApiAccessControlPolicy> accessControlPolicies)
        {
            this.accessControlPolicies = accessControlPolicies;
        }

        /// <inheritdoc />
        public Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> CheckAccessPoliciesAsync(
            IOpenApiContext context,
            params AccessCheckOperationDescriptor[] requests)
        {
            return OpenApiAccessPolicyAggregator.EvaluteAccessPoliciesConcurrentlyAsync(
                this.accessControlPolicies, context, requests);
        }
    }
}