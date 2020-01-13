// <copyright file="IOpenApiRequestScopeFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Builds the service provider scope for a request, using <see cref="IOpenApiScopeBuilder{TRequest}"/>.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    public interface IOpenApiRequestScopeFactory<TRequest>
    {
        /// <summary>
        /// Builds the scope for the request.
        /// </summary>
        /// <param name="serviceProvider">The root service provider for the scope.</param>
        /// <param name="path">The path for the request.</param>
        /// <param name="method">The method for the request.</param>
        /// <param name="request">The request itself.</param>
        /// <param name="parameters">The parameters for the request.</param>
        /// <param name="operationPathTemplate">The resolved OpenAPI operation path template for the request.</param>
        /// <returns>The new service scope for the request.</returns>
        public Task<IServiceScope> BuildScopeAsync(IServiceProvider serviceProvider, string path, string method, TRequest request, object parameters, OpenApiOperationPathTemplate operationPathTemplate);
    }
}
