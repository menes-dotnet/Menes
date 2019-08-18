// <copyright file="AccessCheckOperationDescriptor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Contains information about an operation that needs to be part of an
    /// access check for a user, using the <see cref="IOpenApiAccessChecker{TTenant}"/>,
    /// <see cref="IOpenApiAccessControlPolicy{TTenant}"/> or one of the other classes
    /// involved in that process.
    /// </summary>
    [DebuggerDisplay("{OperationId} - {Method} {Path}")]
    public class AccessCheckOperationDescriptor : IEquatable<AccessCheckOperationDescriptor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessCheckOperationDescriptor"/> class.
        /// </summary>
        /// <param name="path">The <see cref="Path"/>.</param>
        /// <param name="operationId">The <see cref="OperationId"/>.</param>
        /// <param name="method">The <see cref="Method"/>.</param>
        public AccessCheckOperationDescriptor(string path, string operationId, string method)
        {
            this.Path = path ?? throw new ArgumentNullException(nameof(path));
            this.OperationId = operationId ?? throw new ArgumentNullException(nameof(operationId));
            this.Method = method ?? throw new ArgumentNullException(nameof(method));
        }

        /// <summary>
        /// Gets the Id of the operation that the request is for.
        /// </summary>
        public string OperationId { get; }

        /// <summary>
        /// Gets the path of the request.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the HTTP method that has been used to invoke the operation.
        /// </summary>
        public string Method { get; }

        /// <summary>
        /// Compares the supplied objects to see if their values are equal.
        /// </summary>
        /// <param name="left">The left hand side of the equality check.</param>
        /// <param name="right">The right hand side of the equality check.</param>
        /// <returns>True if the values are equal, false otherwise.</returns>
        public static bool operator ==(AccessCheckOperationDescriptor left, AccessCheckOperationDescriptor right)
        {
            if (object.ReferenceEquals(left, right))
            {
                // This check also catches the scenario where both are null.
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Compares the supplied objects to see if their values are not equal.
        /// </summary>
        /// <param name="left">The left hand side of the equality check.</param>
        /// <param name="right">The right hand side of the equality check.</param>
        /// <returns>False if the values are equal, true otherwise.</returns>
        public static bool operator !=(AccessCheckOperationDescriptor left, AccessCheckOperationDescriptor right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public bool Equals(AccessCheckOperationDescriptor other)
        {
            if (other == null)
            {
                return false;
            }

            return string.Equals(this.OperationId, other.OperationId, StringComparison.InvariantCultureIgnoreCase)
                && string.Equals(this.Path, other.Path, StringComparison.InvariantCultureIgnoreCase)
                && string.Equals(this.Method, other.Method, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as AccessCheckOperationDescriptor);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return string.Concat(this.OperationId.ToLowerInvariant(), this.Path.ToLowerInvariant(), this.Method.ToLowerInvariant()).GetHashCode();
        }
    }
}
