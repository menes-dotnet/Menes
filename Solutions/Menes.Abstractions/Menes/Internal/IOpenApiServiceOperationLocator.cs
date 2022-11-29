// <copyright file="IOpenApiServiceOperationLocator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Interface implemented by types that can locate the <see cref="OpenApiServiceOperation"/> instances
    /// in this context.
    /// </summary>
    public interface IOpenApiServiceOperationLocator
    {
        /// <summary>
        /// Try to get an operation given an operation ID.
        /// </summary>
        /// <param name="operationId">The operation ID for which to get the operation.</param>
        /// <param name="operation">The operation corresponding to that operation ID.</param>
        /// <returns>True if an operation corresponding to that ID was found, otherwise false.</returns>
        bool TryGetOperation(string operationId, [NotNullWhen(true)] out OpenApiServiceOperation? operation);
    }
}