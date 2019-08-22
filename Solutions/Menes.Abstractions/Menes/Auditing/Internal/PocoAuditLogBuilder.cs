// <copyright file="PocoAuditLogBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Endjin.Auditing.Internal
{
    using System;
    using Menes;
    using Menes.Auditing;
    using Menes.Auditing.Internal;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An audit log builder for POCOs.
    /// </summary>
    public class PocoAuditLogBuilder : IAuditLogBuilder
    {
        /// <inheritdoc />
        public int Priority => 10000;

        /// <inheritdoc />
        public AuditLog BuildAuditLog(IOpenApiContext context, object result, OpenApiOperation operation)
        {
            return new AuditLog
            {
                CreatedDateTimeUtc = DateTimeOffset.UtcNow,
                Operation = operation.OperationId,
                Result = 200,
                TenantId = context.CurrentTenantId,
                UserId = context.CurrentPrincipal?.Identity?.Name,
            };
        }

        /// <inheritdoc />
        public bool CanBuildAuditLog(IOpenApiContext context, object result, OpenApiOperation operation)
        {
            return true;
        }
    }
}
