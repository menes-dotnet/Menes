// <copyright file="IOpenApiAccessControlPolicy.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    /// <summary>
    /// An access control policy for an OpenApi service.
    /// </summary>
    /// <typeparam name="TTenant">The type of the tenant.</typeparam>
    /// <remarks>
    /// <para>
    /// The host obtains every access control policy registered through DI, and for each request it
    /// will ask each one whether the operation is allowed, and if any say no, it will produce a
    /// 403 forbidden result.
    /// </para>
    /// </remarks>
    public interface IOpenApiAccessControlPolicy<TTenant>
    {
        /// <summary>
        /// Invoked to determine whether the client is allowed to perform an operation.
        /// </summary>
        /// <param name="principal">Provides access to all of the caller's claims.</param>
        /// <param name="tenant">The tenant to use.</param>
        /// <param name="requests">The list of operation descriptors to check.</param>
        /// <returns>
        /// A task that produces a dictionary mapping the requests to their corresponding
        /// <see cref="AccessControlPolicyResult"/> indicating the outcome of the policy evaluation.
        /// </returns>
        Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> ShouldAllowAsync(
            ClaimsPrincipal principal,
            TTenant tenant,
            params AccessCheckOperationDescriptor[] requests);
    }
}
