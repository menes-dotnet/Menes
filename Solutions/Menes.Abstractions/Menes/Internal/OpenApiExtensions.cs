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
            return httpMethod.ToLowerInvariant() switch
            {
                "delete"  => OperationType.Delete,
                "get"     => OperationType.Get,
                "head"    => OperationType.Head,
                "options" => OperationType.Options,
                "patch"   => OperationType.Patch,
                "post"    => OperationType.Post,
                "put"     => OperationType.Put,
                "trace"   => OperationType.Trace,

                _ => throw new ArgumentException("Unsupported Http Method", nameof(httpMethod)),
            };
        }
    }
}