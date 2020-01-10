// <copyright file="IAuditLogBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Auditing.Internal
{
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Interface implemented by types that are used to build <see cref="AuditLog"/> entries
    /// from OpenApi operation results.
    /// </summary>
    public interface IAuditLogBuilder
    {
        /// <summary>
        /// Gets the priority of the output builder.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The candidate audit log builders will be executed in priority order, lowest to highest.
        /// </para>
        /// </remarks>
        int Priority { get; }

        /// <summary>
        /// Indicates whether the builder can build a result for the given operation and result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="operation">The operation.</param>
        /// <returns>True if the builder can handle the operation and result.</returns>
        bool CanBuildAuditLog(object result, OpenApiOperation operation);

        /// <summary>
        /// Build the result for the operation.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="operation">The operation.</param>
        /// <returns>The <see cref="AuditLog"/> constructed from the operation and result.</returns>
        AuditLog BuildAuditLog(object result, OpenApiOperation operation);
    }
}