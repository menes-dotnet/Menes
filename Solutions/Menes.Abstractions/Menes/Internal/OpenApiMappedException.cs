// <copyright file="OpenApiMappedException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;

    /// <summary>
    ///     Represents a mapping of an exception to a specific OpenApi response.
    /// </summary>
    internal class OpenApiMappedException
    {
        /// <summary>
        ///     Gets or sets the type of exception to map.
        /// </summary>
        public Type ExceptionType { get; set; }

        /// <summary>
        ///     Gets or sets the formatter to use to convert the exception to a response body.
        /// </summary>
        public Type FormatterType { get; set; }

        /// <summary>
        ///     Gets or sets the operation id that this applies to.
        /// </summary>
        public string OperationId { get; set; }

        /// <summary>
        ///     Gets or sets the response code to return.
        /// </summary>
        public int StatusCode { get; set; }
    }
}