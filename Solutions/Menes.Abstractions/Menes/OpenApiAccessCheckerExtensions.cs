// <copyright file="OpenApiAccessCheckerExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for classes implementing <see cref="IOpenApiAccessChecker"/>.
    /// </summary>
    public static class OpenApiAccessCheckerExtensions
    {
        /// <summary>
        /// An extension method that provides simpler syntax when using the <see cref="IOpenApiAccessChecker"/>
        /// to check access for a single operation.
        /// </summary>
        /// <param name="checker">The underlying <see cref="IOpenApiAccessChecker"/> to use.</param>
        /// <param name="path">The request path.</param>
        /// <param name="operationId">The request Operation Id.</param>
        /// <param name="httpMethod">The request Http method.</param>
        /// <returns>A task that resolves to the result of the access check.</returns>
        public static async Task<AccessControlPolicyResult> CheckAccessPolicyAsync(
            this IOpenApiAccessChecker checker,
            string path,
            string operationId,
            string httpMethod)
        {
            var request = new AccessCheckOperationDescriptor(path, operationId, httpMethod);
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = await checker.CheckAccessPoliciesAsync(request).ConfigureAwait(false);

            return result.Values.Single();
        }
    }
}
