// <copyright file="OpenApiOperationExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Extension methods for <see cref="OpenApiOperation"/>.
    /// </summary>
    public static class OpenApiOperationExtensions
    {
        /// <summary>
        /// Gets information to log.
        /// </summary>
        /// <param name="operation">The <see cref="OpenApiOperation"/>.</param>
        /// <returns>The information to log.</returns>
        public static string GetOperationId(this OpenApiOperation operation)
        {
            return operation.OperationId ?? "*";
        }
    }
}
