// <copyright file="OpenApiExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Extension methods for OpenApi.
    /// </summary>
    public static class OpenApiExtensions
    {
        /// <summary>
        /// Convert an HTTP method string to an OpenApi <see cref="OperationType"/>.
        /// </summary>
        /// <param name="httpMethod">The Http method string.</param>
        /// <returns>The operation type corresponding to that string.</returns>
        /// <exception cref="ArgumentException">Thrown if the method string is unsupported.</exception>
        public static OperationType ToOperationType(this string httpMethod)
        {
            switch (httpMethod.ToLowerInvariant())
            {
                case "delete":
                    return OperationType.Delete;
                case "get":
                    return OperationType.Get;
                case "head":
                    return OperationType.Head;
                case "options":
                    return OperationType.Options;
                case "patch":
                    return OperationType.Patch;
                case "post":
                    return OperationType.Post;
                case "put":
                    return OperationType.Put;
                case "trace":
                    return OperationType.Trace;
                default:
                    throw new ArgumentException("Unsupported Http Method", nameof(httpMethod));
            }
        }
    }
}