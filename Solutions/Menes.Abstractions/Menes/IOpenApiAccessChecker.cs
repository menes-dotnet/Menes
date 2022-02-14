// <copyright file="IOpenApiAccessChecker.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface implemented by types responsible for applying access control to an incoming request.
    /// </summary>
    public interface IOpenApiAccessChecker
    {
        /// <summary>
        /// Invoked prior to executing a service operation implementation. Determines whether
        /// access to the operation is permitted.
        /// </summary>
        /// <param name="context">
        /// The Open API context for the request. Checkers can use this to discover the caller
        /// identity and tenant.
        /// </param>
        /// <param name="requests">
        /// The list of operation descriptors to check.
        /// </param>
        /// <returns>
        /// A task that produces a dictionary mapping the requests to their corresponding
        /// <see cref="AccessControlPolicyResult"/> indicating the outcome of the policy evaluation.
        /// </returns>
        Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> CheckAccessPoliciesAsync(
            IOpenApiContext context,
            params AccessCheckOperationDescriptor[] requests);
    }
}