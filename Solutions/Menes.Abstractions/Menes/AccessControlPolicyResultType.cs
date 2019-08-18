// <copyright file="AccessControlPolicyResultType.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Describes whether an access policy was evaluated, and if so what the outcome was.
    /// </summary>
    public enum AccessControlPolicyResultType
    {
        /// <summary>
        /// The policy has determined that the client is not allowed to perform the operation.
        /// </summary>
        NotAllowed,

        /// <summary>
        /// The policy has determined that the client is allowed to perform the operation.
        /// </summary>
        Allowed,

        /// <summary>
        /// The client's identity is unknown, so the policy has not been evaluated.
        /// </summary>
        NotAuthenticated,
    }
}
