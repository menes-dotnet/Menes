// <copyright file="IOpenApiOperationInvoker.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Invokes an Open API operation.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface IOpenApiOperationInvoker<TRequest, TResponse>
    {
        /// <summary>
        /// Invoke the given operation.
        /// </summary>
        /// <param name="serviceProvider">The service provider for the invokation context.</param>
        /// <param name="path">The operation path.</param>
        /// <param name="method">The operation method.</param>
        /// <param name="request">The request.</param>
        /// <param name="parameters">Parameters sent with the request.</param>
        /// <param name="operationPathTemplate">The path template for the operation.</param>
        /// <returns>A <see cref="Task{T}"/> which, when complete, provides the response.</returns>
        Task<TResponse> InvokeAsync(IServiceProvider serviceProvider, string path, string method, TRequest request, object parameters, OpenApiOperationPathTemplate operationPathTemplate);
    }
}