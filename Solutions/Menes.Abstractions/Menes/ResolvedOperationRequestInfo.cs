// <copyright file="ResolvedOperationRequestInfo.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Represents the information needed to make a web request to an OpenApi
    /// operation, with the operation's path template resolved to a Uri.
    /// </summary>
    public class ResolvedOperationRequestInfo
    {
        /// <summary>
        /// Gets or sets the resolved Uri of the operation. This is created from the path
        /// template of the operation and any values needed to populate path and query parameters.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="OperationType"/> that should be used with the
        /// <see cref="Uri"/> to access the operation. This corresponds to an Http method.
        /// </summary>
        public OperationType OperationType { get; set; }
    }
}