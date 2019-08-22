﻿// <copyright file="OpenApiResultAuditLogBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Auditing.Internal
{
    using System;
    using Menes;
    using Menes.Auditing;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An audit log builder for OpenApiResults.
    /// </summary>
    public class OpenApiResultAuditLogBuilder : IAuditLogBuilder
    {
        /// <inheritdoc />
        public int Priority => 100;

        /// <inheritdoc />
        public AuditLog BuildAuditLog(IOpenApiContext context, object result, OpenApiOperation operation)
        {
            var openApiResult = result as OpenApiResult;

            return new AuditLog
            {
                CreatedDateTimeUtc = DateTimeOffset.UtcNow,
                Operation = operation.OperationId,
                Result = openApiResult.StatusCode,
                TenantId = context.CurrentTenantId,
                UserId = context.CurrentPrincipal?.Identity?.Name,
                Properties = openApiResult.AuditData,
            };
        }

        /// <inheritdoc />
        public bool CanBuildAuditLog(IOpenApiContext context, object result, OpenApiOperation operation)
        {
            return result is OpenApiResult;
        }
    }
}
