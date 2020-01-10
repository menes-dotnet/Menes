// <copyright file="IOpenApiAccessControlPolicy.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// An access control policy for an OpenApi service.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The host obtains every access control policy registered through DI, and for each request it
    /// will ask each one whether the operation is allowed, and if any say no, it will produce a
    /// 403 forbidden result.
    /// </para>
    /// </remarks>
    public interface IOpenApiAccessControlPolicy
    {
        /// <summary>
        /// Invoked to determine whether the client is allowed to perform an operation.
        /// </summary>
        /// <param name="requests">The list of operation descriptors to check.</param>
        /// <returns>
        /// A task that produces a dictionary mapping the requests to their corresponding
        /// <see cref="AccessControlPolicyResult"/> indicating the outcome of the policy evaluation.
        /// </returns>
        Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> ShouldAllowAsync(
            params AccessCheckOperationDescriptor[] requests);
    }
}
