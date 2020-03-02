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
        /// Creates a <see cref="OpenApiMappedException"/>.
        /// </summary>
        /// <param name="exceptionType">The <see cref="ExceptionType"/>.</param>
        /// <param name="statusCode">The <see cref="StatusCode"/>.</param>
        /// <param name="operationId">The <see cref="OperationId"/>.</param>
        /// <param name="formatterType">The <see cref="FormatterType"/>.</param>
        internal OpenApiMappedException(
            Type exceptionType,
            int statusCode,
            string? operationId = null,
            Type? formatterType = null)
        {
            this.ExceptionType = exceptionType;
            this.StatusCode = statusCode;
            this.FormatterType = formatterType;
            this.OperationId = operationId;
        }

        /// <summary>
        ///     Gets the type of exception to map.
        /// </summary>
        public Type ExceptionType { get; }

        /// <summary>
        ///     Gets the formatter to use to convert the exception to a response body.
        /// </summary>
        public Type? FormatterType { get; }

        /// <summary>
        ///     Gets the operation id that this applies to.
        /// </summary>
        public string? OperationId { get; }

        /// <summary>
        ///     Gets the response code to return.
        /// </summary>
        public int StatusCode { get; }
    }
}