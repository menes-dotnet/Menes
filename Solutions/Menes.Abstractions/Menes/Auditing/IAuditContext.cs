// <copyright file="IAuditContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Auditing
{
    using System.Threading.Tasks;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Interface implemented by auditing services.
    /// </summary>
    public interface IAuditContext
    {
        /// <summary>
        /// Gets a value indicating whether auditing is enabled.
        /// </summary>
        bool IsAuditingEnabled { get; }

        /// <summary>
        /// Log a failure to a set of audit sinks.
        /// </summary>
        /// <param name="context">The OpenAPI context.</param>
        /// <param name="statusCode">The (error) status code.</param>
        /// <param name="operation">The operation that failed.</param>
        /// <returns>A <see cref="Task"/> which completes when the audit failure record has been logged.</returns>
        Task AuditFailureAsync(IOpenApiContext context, int statusCode, OpenApiOperation operation);

        /// <summary>
        /// Log a result to a set of audit sinks.
        /// </summary>
        /// <param name="context">The OpenAPI context.</param>
        /// <param name="result">The result of the operation.</param>
        /// <param name="operation">The operation that produced the result.</param>
        /// <returns>A <see cref="Task"/> which completes when the audit record has been logged.</returns>
        Task AuditResultAsync(IOpenApiContext context, object result, OpenApiOperation operation);
    }
}