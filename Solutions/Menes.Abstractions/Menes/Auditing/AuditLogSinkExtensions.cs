// <copyright file="AuditLogSinkExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Auditing
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for the audit log repository.
    /// </summary>
    public static class AuditLogSinkExtensions
    {
        /// <summary>
        /// Adds an entry to each of a set of audit services.
        /// </summary>
        /// <param name="auditSinks">A collection of audit services.</param>
        /// <param name="context">The current OpenApi context.</param>
        /// <param name="log">The audit log to write.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task LogAsync(
            this IEnumerable<IAuditLogSink> auditSinks,
            IOpenApiContext context,
            AuditLog log)
        {
            IEnumerable<Task> tasks = auditSinks.Select(x => x.LogAsync(context, log));
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
