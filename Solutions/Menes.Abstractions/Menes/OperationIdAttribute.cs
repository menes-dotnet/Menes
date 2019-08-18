// <copyright file="OperationIdAttribute.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;

    /// <summary>
    /// Mark a method as an OpenAPI operation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class OperationIdAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationIdAttribute"/> class.
        /// </summary>
        /// <param name="operationId">The operation ID.</param>
        public OperationIdAttribute(string operationId)
        {
            this.OperationId = operationId;
        }

        /// <summary>
        /// Gets the operation ID.
        /// </summary>
        public string OperationId { get; }
    }
}