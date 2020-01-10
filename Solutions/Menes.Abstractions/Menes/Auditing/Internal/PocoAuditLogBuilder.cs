// <copyright file="PocoAuditLogBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Auditing.Internal
{
    using System;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An audit log builder for POCOs.
    /// </summary>
    public class PocoAuditLogBuilder : IAuditLogBuilder
    {
        /// <inheritdoc />
        public int Priority => 10000;

        /// <inheritdoc />
        public AuditLog BuildAuditLog(object result, OpenApiOperation operation)
        {
            return new AuditLog
            {
                CreatedDateTimeUtc = DateTimeOffset.UtcNow,
                Operation = operation.OperationId,
                Result = 200,
            };
        }

        /// <inheritdoc />
        public bool CanBuildAuditLog(object result, OpenApiOperation operation)
        {
            return true;
        }
    }
}
