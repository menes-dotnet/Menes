// <copyright file="IAuditLogSink.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Auditing
{
    using System.Threading.Tasks;
    using Menes;

    /// <summary>
    /// Interface for a service to manage audit logs.
    /// </summary>
    public interface IAuditLogSink
    {
        /// <summary>
        /// Adds an entry to the log.
        /// </summary>
        /// <param name="context">The current OpenApi context.</param>
        /// <param name="log">The entry to log.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task LogAsync(IOpenApiContext context, AuditLog log);
    }
}
