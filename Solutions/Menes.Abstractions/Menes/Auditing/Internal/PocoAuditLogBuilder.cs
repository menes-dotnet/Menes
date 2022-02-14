// <copyright file="PocoAuditLogBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Auditing.Internal
{
    using System;
    using Menes;
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
            return new AuditLog(operation.OperationId)
            {
                CreatedDateTimeUtc = DateTimeOffset.UtcNow,
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