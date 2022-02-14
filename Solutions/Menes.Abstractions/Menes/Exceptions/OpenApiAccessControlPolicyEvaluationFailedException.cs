// <copyright file="OpenApiAccessControlPolicyEvaluationFailedException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Exceptions
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception that is thrown by an <see cref="IOpenApiAccessControlPolicy"/> if it fails
    /// to evaluate due for an unexpected reason - e.g. a configuration error, third party
    /// service unavailable or similar.
    /// </summary>
    public class OpenApiAccessControlPolicyEvaluationFailedException : Exception
    {
        /// <summary>
        /// Creates a new instance of <see cref="OpenApiAccessControlPolicyEvaluationFailedException"/> with
        /// the specified error message.
        /// </summary>
        /// <param name="policyName">The name of the policy that threw the exception.</param>
        /// <param name="requests">The list of requests that were being evaluated.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public OpenApiAccessControlPolicyEvaluationFailedException(string policyName, AccessCheckOperationDescriptor[] requests, string message, Exception innerException)
            : base(message, innerException)
        {
            this.PolicyName = policyName;
            this.Requests = requests;

            this.AddProblemDetails();
        }

        /// <summary>
        /// Gets the name of the <see cref="IOpenApiAccessControlPolicy"/> that threw the exception.
        /// </summary>
        public string PolicyName { get; }

        /// <summary>
        /// Gets the list of <see cref="AccessCheckOperationDescriptor"/> that was being evaluated when the error occurred.
        /// </summary>
        public AccessCheckOperationDescriptor[] Requests { get; }

        private void AddProblemDetails()
        {
            this.AddProblemDetailsTitle($"Unexpected error when trying to evaluate access control policy [{this.PolicyName ?? "policy name not supplied"}]");
            this.AddProblemDetailsExplanation(this.Message);
            this.AddProblemDetailsType("/endjin/openapi/errors/access/evaluation-failed");

            if (!string.IsNullOrEmpty(this.PolicyName))
            {
                this.AddProblemDetailsExtension("Policy Name", this.PolicyName);
            }

            if (this.Requests?.Length > 0)
            {
                this.AddProblemDetailsExtension("Requests", string.Join(Environment.NewLine, this.Requests.Select(r => $"{r.OperationId}: {r.Method} {r.Path}")));
            }
        }
    }
}