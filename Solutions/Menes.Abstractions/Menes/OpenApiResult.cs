// <copyright file="OpenApiResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;

    /// <summary>
    /// A named result set for an open api operation.
    /// </summary>
    public class OpenApiResult
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets a map of named results.
        /// </summary>
        /// <remarks>
        /// <para>The infrastructure will map these back to the appropriate response elements.</para>
        /// <para>
        /// Typically you will supply either a header name, or a media type (for body repsonses).
        /// </para>
        /// </remarks>
        public Dictionary<string, object> Results { get; } = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets additional data that will be attached to the audit log if auditing has been
        /// configured.
        /// </summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>No sensitive data should be stored in this collection.</item>
        ///         <item>Everything stored in this collection should be serializable.</item>
        ///         <item>Avoid putting large amounts of data into the collection.</item>
        ///     </list>
        /// </remarks>
        public Dictionary<string, object> AuditData { get; set; } = new Dictionary<string, object>();
    }
}