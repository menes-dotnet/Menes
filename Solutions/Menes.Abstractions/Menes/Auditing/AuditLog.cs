// <copyright file="AuditLog.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Auditing
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Representation of an audit record.
    /// </summary>
    public class AuditLog
    {
        /// <summary>
        /// The registered content type used when this object is serialized/deserialized.
        /// </summary>
        public const string RegisteredContentType = "application/vnd.menes.auditing.audit-log";

        /// <summary>
        /// Creates an <see cref="AuditLog"/>.
        /// </summary>
        /// <param name="operation">The <see cref="Operation"/>.</param>
        public AuditLog(string operation)
        {
            this.Operation = operation;
        }

        /// <summary>
        /// Gets or sets the date and time that the audit log was created.
        /// </summary>
        public DateTimeOffset CreatedDateTimeUtc { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// Gets the content type used when this object is serialized/deserialized.
        /// </summary>
#pragma warning disable CA1822 // Mark members as static - accessed via reflection, so this need to be an instance member
        public string ContentType => RegisteredContentType;
#pragma warning restore CA1822

        /// <summary>
        /// Gets or sets the Id of the tenant for the operation.
        /// </summary>
        public string? TenantId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the user who attempted the audited activity.
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// Gets or sets the operation that is being audited.
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets the result of the action. This should be an HTTP status code.
        /// </summary>
        public int? Result { get; set; }

        /// <summary>
        /// Gets or sets a list of additional data for the audit log.
        /// </summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>No sensitive data should be stored in this collection.</item>
        ///         <item>Everything stored in this collection should be serializable.</item>
        ///         <item>Avoid putting large amounts of data into the collection.</item>
        ///     </list>
        /// </remarks>
        public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    }
}