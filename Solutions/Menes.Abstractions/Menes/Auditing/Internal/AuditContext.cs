// <copyright file="AuditContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Auditing
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Menes.Auditing.Internal;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Provides auditing services.
    /// </summary>
    public class AuditContext : IAuditContext
    {
        private readonly IEnumerable<IAuditLogBuilder> auditLogBuilders;
        private readonly IEnumerable<IAuditLogSink> auditSinks;

        private readonly ILogger<AuditContext> logger;

        /// <summary>
        /// Creates an instance of an <see cref="AuditContext"/>.
        /// </summary>
        /// <param name="auditLogBuilders">The audit log builders.</param>
        /// <param name="auditSinks">The audit sinks.</param>
        /// <param name="logger">The logger.</param>
        public AuditContext(IEnumerable<IAuditLogBuilder> auditLogBuilders, IEnumerable<IAuditLogSink> auditSinks, ILogger<AuditContext> logger)
        {
            if (auditLogBuilders is null)
            {
                throw new System.ArgumentNullException(nameof(auditLogBuilders));
            }

            if (auditSinks is null)
            {
                throw new System.ArgumentNullException(nameof(auditSinks));
            }

            this.logger = logger;
            this.auditLogBuilders = auditLogBuilders.OrderBy(b => b.Priority).ToList();
            this.auditSinks = auditSinks.ToList();
            this.IsAuditingEnabled = auditSinks.Any() && this.auditSinks.Any();

            if (!this.IsAuditingEnabled && logger.IsEnabled(LogLevel.Warning))
            {
                logger.LogWarning("OpenApi auditing is not enabled. Found [{auditSinkCount}] sinks and [{auditLogBuilderCount}] audit log builders.", this.auditSinks.Count(), this.auditLogBuilders.Count());
            }
        }

        /// <inheritdoc/>
        public bool IsAuditingEnabled { get; }

        /// <inheritdoc/>
        public async Task AuditFailureAsync(int statusCode, OpenApiOperation operation)
        {
            if (this.IsAuditingEnabled)
            {
                var log = new AuditLog
                {
                    Operation = operation.OperationId,
                    Result = statusCode,
                };

                await this.auditSinks.LogAsync(log).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task AuditResultAsync(object result, OpenApiOperation operation)
        {
            if (this.IsAuditingEnabled)
            {
                AuditLog log = this.BuildAuditLog(result, operation);
                await this.auditSinks.LogAsync(log).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Build an audit log for a given result, operation, and context.
        /// </summary>
        /// <param name="result">The result of the operation.</param>
        /// <param name="operation">The OpenAPI operation.</param>
        /// <returns>The audit log entry for the result, operation, and context.</returns>
        private AuditLog BuildAuditLog(object result, OpenApiOperation operation)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Building audit log for [{operation}]",
                    operation.OperationId);
            }

            foreach (IAuditLogBuilder auditLogBuilder in this.auditLogBuilders)
            {
                if (auditLogBuilder.CanBuildAuditLog(result, operation))
                {
                    return auditLogBuilder.BuildAuditLog(result, operation);
                }
            }

            if (this.logger.IsEnabled(LogLevel.Warning))
            {
                this.logger.LogWarning(
                    "Unable to build audit log for [{operation}]",
                    operation.OperationId);
            }

            return null;
        }
    }
}
