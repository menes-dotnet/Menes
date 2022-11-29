// <copyright file="AccessControlPolicyResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The result of evaluating an <see cref="IOpenApiAccessControlPolicy"/>, indicating whether
    /// an operation should be allowed, with an optional explanation if it is disallowed.
    /// </summary>
    [DebuggerDisplay("{ResultType}")]
    public readonly struct AccessControlPolicyResult
    {
        /// <summary>
        /// Create an <see cref="AccessControlPolicyResult"/> disallowing an operation, along with
        /// an explanation for why the operation is to be blocked.
        /// </summary>
        /// <param name="resultType">The <see cref="AccessControlPolicyResultType"/>.</param>
        /// <param name="explanation">
        /// An explanation for why the operation is blocked. May be returned in a Problem Details
        /// response body.
        /// </param>
        public AccessControlPolicyResult(
            AccessControlPolicyResultType resultType,
            string? explanation = null)
        {
            if (resultType == AccessControlPolicyResultType.Allowed && !string.IsNullOrEmpty(explanation))
            {
                throw new ArgumentException(
                    "Explanations are only supported when access is not allowed",
                    nameof(resultType));
            }

            this.ResultType = resultType;
            this.Explanation = explanation;
        }

        /// <summary>
        /// Gets a value indicating whether the operation is to be allowed.
        /// </summary>
        public bool Allow => this.ResultType == AccessControlPolicyResultType.Allowed;

        /// <summary>
        /// Gets an explanation of why the operation is blocked. May be returned in a Problem
        /// Details response body.
        /// </summary>
        public string? Explanation { get; }

        /// <summary>
        /// Gets a value describing whether the access policy was evaluated, and if so what the
        /// outcome was.
        /// </summary>
        public AccessControlPolicyResultType ResultType { get; }
    }
}