// <copyright file="IOpenApiScopeBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Implemented by types which want to configure scoped services that
    /// have been registered in the <see cref="IServiceProvider"/> based on the
    /// request context.
    /// </summary>
    /// <typeparam name="TRequest">The type of the underlying request context.</typeparam>
    public interface IOpenApiScopeBuilder<TRequest>
    {
        /// <summary>
        /// Sets values in the service provider appropriate for the request scope.
        /// </summary>
        /// <param name="serviceProvider">The service provider for the request scope.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="method">The method of the request.</param>
        /// <param name="request">The actual request in the underlying host.</param>
        /// <param name="parameters">The parameters passed in the request.</param>
        /// <param name="operationPathTemplate">The <see cref="OpenApiOperationPathTemplate"/> resolved for the request.</param>
        /// <returns>A <see cref="Task"/> which completes when the builder has updated the relevant scoped services in the service provider.</returns>
        Task BuildScope(IServiceProvider serviceProvider, string path, string method, TRequest request, object parameters, OpenApiOperationPathTemplate operationPathTemplate);
    }
}